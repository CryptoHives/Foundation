// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Buffers.Binary;
using Aes = System.Security.Cryptography.Aes;
using CipherMode = System.Security.Cryptography.CipherMode;
using PaddingMode = System.Security.Cryptography.PaddingMode;

/// <summary>
/// Computes the GMAC (Galois Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// GMAC is the authentication-only variant of GCM (Galois/Counter Mode),
/// defined in NIST SP 800-38D. It provides message authentication using
/// the same GHASH function as GCM without encryption.
/// </para>
/// <para>
/// This implementation uses AES as the underlying block cipher and supports
/// 128-bit, 192-bit, and 256-bit keys.
/// </para>
/// <para>
/// <strong>Important:</strong> The nonce (IV) must be unique for each message
/// authenticated with the same key. Reusing a nonce compromises security.
/// </para>
/// <para>
/// The output is always 128 bits (16 bytes).
/// </para>
/// </remarks>
public sealed class Gmac : HashAlgorithm
{
    private const int BlockSizeBytes = 16;
    private const int TagSizeBytes = 16;
    private const int TagSizeBits = 128;
    private const int DefaultNonceSizeBytes = 12;

    private readonly Aes _aes;
    private readonly byte[] _key;
    private readonly byte[] _nonce;
    private readonly byte[] _h;           // Hash subkey H = AES_K(0^128)
    private readonly byte[] _j0;          // Initial counter block
    private readonly byte[] _ghashState;  // Current GHASH state
    private readonly byte[] _buffer;
    private int _bufferLength;
    private long _aadLength;              // Length of authenticated data in bytes
    private bool _initialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="Gmac"/> class.
    /// </summary>
    /// <param name="key">The secret key (16, 24, or 32 bytes for AES-128, AES-192, or AES-256).</param>
    /// <param name="nonce">The nonce/IV (typically 12 bytes, must be unique per message).</param>
    /// <exception cref="ArgumentNullException">Thrown when key or nonce is null.</exception>
    /// <exception cref="ArgumentException">Thrown when key length is invalid or nonce is empty.</exception>
    public Gmac(byte[] key, byte[] nonce)
    {
        if (key is null) throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes for AES-128, AES-192, or AES-256.", nameof(key));
        if (nonce is null) throw new ArgumentNullException(nameof(nonce), "Nonce cannot be null.");
        if (nonce.Length == 0) throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));

        _key = (byte[])key.Clone();
        _nonce = (byte[])nonce.Clone();
        _aes = Aes.Create();
        _aes.Key = _key;
        _aes.Mode = CipherMode.ECB;
        _aes.Padding = PaddingMode.None;

        _h = new byte[BlockSizeBytes];
        _j0 = new byte[BlockSizeBytes];
        _ghashState = new byte[BlockSizeBytes];
        _buffer = new byte[BlockSizeBytes];

        HashSizeValue = TagSizeBits;

        // Compute H = AES_K(0^128)
        ComputeHashSubkey();

        // Compute J0 (initial counter block)
        ComputeJ0();

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key.Length switch
    {
        16 => "AES-128-GMAC",
        24 => "AES-192-GMAC",
        32 => "AES-256-GMAC",
        _ => "AES-GMAC"
    };

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a copy of the secret key.
    /// </summary>
    public byte[] Key => (byte[])_key.Clone();

    /// <summary>
    /// Gets a copy of the nonce.
    /// </summary>
    public byte[] Nonce => (byte[])_nonce.Clone();

    /// <summary>
    /// Creates a new AES-128-GMAC instance.
    /// </summary>
    /// <param name="key">The 16-byte secret key.</param>
    /// <param name="nonce">The nonce (typically 12 bytes).</param>
    /// <returns>A new GMAC instance.</returns>
    public static Gmac CreateAes128(byte[] key, byte[] nonce)
    {
        if (key is null || key.Length != 16)
            throw new ArgumentException("Key must be exactly 16 bytes for AES-128-GMAC.", nameof(key));
        return new Gmac(key, nonce);
    }

    /// <summary>
    /// Creates a new AES-192-GMAC instance.
    /// </summary>
    /// <param name="key">The 24-byte secret key.</param>
    /// <param name="nonce">The nonce (typically 12 bytes).</param>
    /// <returns>A new GMAC instance.</returns>
    public static Gmac CreateAes192(byte[] key, byte[] nonce)
    {
        if (key is null || key.Length != 24)
            throw new ArgumentException("Key must be exactly 24 bytes for AES-192-GMAC.", nameof(key));
        return new Gmac(key, nonce);
    }

    /// <summary>
    /// Creates a new AES-256-GMAC instance.
    /// </summary>
    /// <param name="key">The 32-byte secret key.</param>
    /// <param name="nonce">The nonce (typically 12 bytes).</param>
    /// <returns>A new GMAC instance.</returns>
    public static Gmac CreateAes256(byte[] key, byte[] nonce)
    {
        if (key is null || key.Length != 32)
            throw new ArgumentException("Key must be exactly 32 bytes for AES-256-GMAC.", nameof(key));
        return new Gmac(key, nonce);
    }

    /// <summary>
    /// Creates a new GMAC instance.
    /// </summary>
    /// <param name="key">The secret key (16, 24, or 32 bytes).</param>
    /// <param name="nonce">The nonce (typically 12 bytes).</param>
    /// <returns>A new GMAC instance.</returns>
    public static Gmac Create(byte[] key, byte[] nonce) => new(key, nonce);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_ghashState, 0, BlockSizeBytes);
        Array.Clear(_buffer, 0, BlockSizeBytes);
        _bufferLength = 0;
        _aadLength = 0;
        _initialized = true;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (!_initialized)
        {
            Initialize();
        }

        _aadLength += source.Length;
        int offset = 0;

        // Process any buffered data first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                GhashBlock(_buffer);
                _bufferLength = 0;
            }
        }

        // Process complete blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            GhashBlock(source.Slice(offset, BlockSizeBytes));
            offset += BlockSizeBytes;
        }

        // Buffer remaining data
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < TagSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Process final partial block if any (pad with zeros)
        if (_bufferLength > 0)
        {
            Array.Clear(_buffer, _bufferLength, BlockSizeBytes - _bufferLength);
            GhashBlock(_buffer);
        }

        // GMAC: Append length block [0 || len(A)]
        // In GMAC, there's no ciphertext, so the length block is [len(AAD) in bits || 0]
        // But for pure GMAC (authentication only), we use: [len(A) || 0] where A is the authenticated data
        Span<byte> lengthBlock = stackalloc byte[BlockSizeBytes];
        lengthBlock.Clear();
        // len(A) in bits as 64-bit big-endian at position 0-7
        BinaryPrimitives.WriteUInt64BigEndian(lengthBlock.Slice(0, 8), (ulong)_aadLength * 8);
        // len(C) = 0 for GMAC, already zero at position 8-15

        GhashBlock(lengthBlock);

        // Compute tag = GHASH_H(A || pad || len) XOR AES_K(J0)
        byte[] encJ0 = new byte[BlockSizeBytes];
        using (var encryptor = _aes.CreateEncryptor())
        {
            encryptor.TransformBlock(_j0, 0, BlockSizeBytes, encJ0, 0);
        }

        for (int i = 0; i < BlockSizeBytes; i++)
        {
            destination[i] = (byte)(_ghashState[i] ^ encJ0[i]);
        }

        bytesWritten = TagSizeBytes;
        _initialized = false;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_key);
            ClearBuffer(_nonce);
            ClearBuffer(_h);
            ClearBuffer(_j0);
            ClearBuffer(_ghashState);
            ClearBuffer(_buffer);
            _aes.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Computes the hash subkey H = AES_K(0^128).
    /// </summary>
    private void ComputeHashSubkey()
    {
        byte[] zeros = new byte[BlockSizeBytes];
        using var encryptor = _aes.CreateEncryptor();
        encryptor.TransformBlock(zeros, 0, BlockSizeBytes, _h, 0);
    }

    /// <summary>
    /// Computes J0, the initial counter block.
    /// </summary>
    private void ComputeJ0()
    {
        if (_nonce.Length == DefaultNonceSizeBytes)
        {
            // If nonce is 96 bits, J0 = nonce || 0^31 || 1
            Array.Copy(_nonce, _j0, DefaultNonceSizeBytes);
            _j0[15] = 0x01;
        }
        else
        {
            // Otherwise, J0 = GHASH_H(nonce || pad || [0 || len(nonce)])
            Array.Clear(_j0, 0, BlockSizeBytes);

            // Process nonce blocks
            int fullBlocks = _nonce.Length / BlockSizeBytes;
            for (int i = 0; i < fullBlocks; i++)
            {
                XorBlock(_j0, _nonce.AsSpan(i * BlockSizeBytes, BlockSizeBytes));
                GfMult(_j0, _h, _j0);
            }

            // Process remaining bytes with padding
            int remaining = _nonce.Length % BlockSizeBytes;
            if (remaining > 0)
            {
                Span<byte> padded = stackalloc byte[BlockSizeBytes];
                padded.Clear();
                _nonce.AsSpan(fullBlocks * BlockSizeBytes, remaining).CopyTo(padded);
                XorBlock(_j0, padded);
                GfMult(_j0, _h, _j0);
            }

            // Process length block
            Span<byte> lenBlock = stackalloc byte[BlockSizeBytes];
            lenBlock.Clear();
            BinaryPrimitives.WriteUInt64BigEndian(lenBlock.Slice(8, 8), (ulong)_nonce.Length * 8);
            XorBlock(_j0, lenBlock);
            GfMult(_j0, _h, _j0);
        }
    }

    /// <summary>
    /// Processes a block through GHASH.
    /// </summary>
    /// <param name="block">The 16-byte block to process.</param>
    private void GhashBlock(ReadOnlySpan<byte> block)
    {
        XorBlock(_ghashState, block);
        GfMult(_ghashState, _h, _ghashState);
    }

    /// <summary>
    /// XORs a block into the state.
    /// </summary>
    private static void XorBlock(byte[] state, ReadOnlySpan<byte> block)
    {
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            state[i] ^= block[i];
        }
    }

    /// <summary>
    /// Performs multiplication in GF(2^128) with the reducing polynomial x^128 + x^7 + x^2 + x + 1.
    /// </summary>
    /// <param name="x">First operand (16 bytes).</param>
    /// <param name="y">Second operand (16 bytes, typically H).</param>
    /// <param name="result">Result buffer (16 bytes).</param>
    private static void GfMult(byte[] x, byte[] y, byte[] result)
    {
        byte[] v = new byte[BlockSizeBytes];
        byte[] z = new byte[BlockSizeBytes];
        Array.Copy(y, v, BlockSizeBytes);

        unchecked
        {
            for (int i = 0; i < 128; i++)
            {
                // Get bit i of x (MSB first)
                int byteIndex = i / 8;
                int bitIndex = 7 - (i % 8);

                if ((x[byteIndex] & (1 << bitIndex)) != 0)
                {
                    // Z = Z XOR V
                    for (int j = 0; j < BlockSizeBytes; j++)
                    {
                        z[j] ^= v[j];
                    }
                }

                // Check if LSB of V is 1 (for reduction)
                bool lsb = (v[15] & 0x01) != 0;

                // V = V >> 1 (right shift)
                for (int j = BlockSizeBytes - 1; j > 0; j--)
                {
                    v[j] = (byte)((v[j] >> 1) | ((v[j - 1] & 0x01) << 7));
                }
                v[0] >>= 1;

                // If LSB was 1, XOR with R (0xE1 in MSB position = x^128 reduction)
                if (lsb)
                {
                    v[0] ^= 0xE1;
                }
            }
        }

        Array.Copy(z, result, BlockSizeBytes);
    }
}
