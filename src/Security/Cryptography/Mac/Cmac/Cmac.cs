// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using Aes = System.Security.Cryptography.Aes;
using CipherMode = System.Security.Cryptography.CipherMode;
using PaddingMode = System.Security.Cryptography.PaddingMode;

/// <summary>
/// Computes the CMAC (Cipher-based Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// CMAC is a MAC algorithm defined in NIST SP 800-38B and RFC 4493 that uses a
/// block cipher (AES) to provide data integrity and authenticity verification.
/// </para>
/// <para>
/// This implementation uses AES as the underlying block cipher and supports
/// 128-bit, 192-bit, and 256-bit keys.
/// </para>
/// <para>
/// The CMAC output is always 128 bits (16 bytes) for AES-CMAC.
/// </para>
/// </remarks>
public sealed class Cmac : HashAlgorithm
{
    private const int BlockSizeBytes = 16;
    private const int BlockSizeBits = 128;


    // Rb constant for 128-bit block size (x^128 + x^7 + x^2 + x + 1)
    private static readonly byte[] Rb = [0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                          0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x87];

    private readonly Aes _aes;
    private readonly byte[] _key;
    private readonly byte[] _k1;
    private readonly byte[] _k2;
    private readonly byte[] _buffer;
    private readonly byte[] _mac;
    private int _bufferLength;
    private bool _initialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cmac"/> class.
    /// </summary>
    /// <param name="key">The secret key (16, 24, or 32 bytes for AES-128, AES-192, or AES-256).</param>
    /// <exception cref="ArgumentNullException">Thrown when key is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when key length is invalid.</exception>
    public Cmac(byte[] key)
    {
        if (key is null || key.Length == 0) throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes for AES-128, AES-192, or AES-256.", nameof(key));

        _key = (byte[])key.Clone();
        _aes = Aes.Create();
        _aes.Key = _key;
        _aes.Mode = CipherMode.ECB;
        _aes.Padding = PaddingMode.None;

        _k1 = new byte[BlockSizeBytes];
        _k2 = new byte[BlockSizeBytes];
        _buffer = new byte[BlockSizeBytes];
        _mac = new byte[BlockSizeBytes];

        HashSizeValue = BlockSizeBits;

        GenerateSubkeys();
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key.Length switch
    {
        16 => "AES-128-CMAC",
        24 => "AES-192-CMAC",
        32 => "AES-256-CMAC",
        _ => "AES-CMAC"
    };

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a copy of the secret key used for CMAC computation.
    /// </summary>
    /// <remarks>
    /// This property is provided for API compatibility with other MAC implementations.
    /// </remarks>
    public byte[] Key => (byte[])_key.Clone();

    /// <summary>
    /// Creates a new AES-128-CMAC instance.
    /// </summary>
    /// <param name="key">The 16-byte secret key.</param>
    /// <returns>A new CMAC instance.</returns>
    public static Cmac CreateAes128(byte[] key)
    {
        if (key is null || key.Length != 16)
            throw new ArgumentException("Key must be exactly 16 bytes for AES-128-CMAC.", nameof(key));
        return new Cmac(key);
    }

    /// <summary>
    /// Creates a new AES-192-CMAC instance.
    /// </summary>
    /// <param name="key">The 24-byte secret key.</param>
    /// <returns>A new CMAC instance.</returns>
    public static Cmac CreateAes192(byte[] key)
    {
        if (key is null || key.Length != 24)
            throw new ArgumentException("Key must be exactly 24 bytes for AES-192-CMAC.", nameof(key));
        return new Cmac(key);
    }

    /// <summary>
    /// Creates a new AES-256-CMAC instance.
    /// </summary>
    /// <param name="key">The 32-byte secret key.</param>
    /// <returns>A new CMAC instance.</returns>
    public static Cmac CreateAes256(byte[] key)
    {
        if (key is null || key.Length != 32)
            throw new ArgumentException("Key must be exactly 32 bytes for AES-256-CMAC.", nameof(key));
        return new Cmac(key);
    }

    /// <summary>
    /// Creates a new CMAC instance with the specified key.
    /// </summary>
    /// <param name="key">The secret key (16, 24, or 32 bytes).</param>
    /// <returns>A new CMAC instance.</returns>
    public static Cmac Create(byte[] key) => new(key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_buffer, 0, BlockSizeBytes);
        Array.Clear(_mac, 0, BlockSizeBytes);
        _bufferLength = 0;
        _initialized = true;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (!_initialized)
        {
            Initialize();
        }

        int offset = 0;

        // If we have buffered data, try to complete a block
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            // Only process if we have a complete block AND there's more data coming
            if (_bufferLength == BlockSizeBytes && offset < source.Length)
            {
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }
        }

        // Process complete blocks, but always keep the last block in the buffer
        while (offset + BlockSizeBytes < source.Length)
        {
            // If buffer is full, process it first
            if (_bufferLength == BlockSizeBytes)
            {
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            // Process directly from source
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
            offset += BlockSizeBytes;
        }

        // Buffer remaining data (this will be the last block or partial block)
        if (offset < source.Length)
        {
            // If buffer has data, we need to process it first if adding more would overflow
            if (_bufferLength > 0 && _bufferLength + (source.Length - offset) > BlockSizeBytes)
            {
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < BlockSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        byte[] lastBlock = new byte[BlockSizeBytes];

        if (_bufferLength == BlockSizeBytes)
        {
            // Complete block: XOR with K1
            for (int i = 0; i < BlockSizeBytes; i++)
            {
                lastBlock[i] = (byte)(_buffer[i] ^ _k1[i]);
            }
        }
        else
        {
            // Incomplete block: pad with 10*
            Array.Copy(_buffer, lastBlock, _bufferLength);
            lastBlock[_bufferLength] = 0x80;
            // Rest is already zeros

            // XOR with K2
            for (int i = 0; i < BlockSizeBytes; i++)
            {
                lastBlock[i] ^= _k2[i];
            }
        }

        // XOR with current MAC state
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            lastBlock[i] ^= _mac[i];
        }

        // Final encryption
        using var encryptor = _aes.CreateEncryptor();
        byte[] result = new byte[BlockSizeBytes];
        encryptor.TransformBlock(lastBlock, 0, BlockSizeBytes, result, 0);

        result.AsSpan().CopyTo(destination);
        bytesWritten = BlockSizeBytes;
        _initialized = false;

        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_key);
            ClearBuffer(_k1);
            ClearBuffer(_k2);
            ClearBuffer(_buffer);
            ClearBuffer(_mac);
            _aes.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Generates the CMAC subkeys K1 and K2 from the cipher key.
    /// </summary>
    private void GenerateSubkeys()
    {
        // L = AES-K(0^128)
        byte[] zeros = new byte[BlockSizeBytes];
        byte[] l = new byte[BlockSizeBytes];

        using var encryptor = _aes.CreateEncryptor();
        encryptor.TransformBlock(zeros, 0, BlockSizeBytes, l, 0);

        // K1 = L << 1 (with conditional XOR of Rb)
        LeftShiftOneWithRb(l, _k1);

        // K2 = K1 << 1 (with conditional XOR of Rb)
        LeftShiftOneWithRb(_k1, _k2);

        ClearBuffer(l);
    }

    /// <summary>
    /// Left shifts a 128-bit value by 1 bit and conditionally XORs with Rb.
    /// </summary>
    /// <param name="input">The input value.</param>
    /// <param name="output">The output value.</param>
    private static void LeftShiftOneWithRb(byte[] input, byte[] output)
    {
        bool msb = (input[0] & 0x80) != 0;

        // Left shift by 1 (use unchecked to avoid overflow exceptions)
        unchecked
        {
            for (int i = 0; i < BlockSizeBytes - 1; i++)
            {
                output[i] = (byte)((input[i] << 1) | (input[i + 1] >> 7));
            }
            output[BlockSizeBytes - 1] = (byte)(input[BlockSizeBytes - 1] << 1);
        }

        // If MSB was 1, XOR with Rb
        if (msb)
        {
            for (int i = 0; i < BlockSizeBytes; i++)
            {
                output[i] ^= Rb[i];
            }
        }
    }

    /// <summary>
    /// Processes a complete block by XORing with current MAC and encrypting.
    /// </summary>
    /// <param name="block">The block to process.</param>
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        byte[] xored = new byte[BlockSizeBytes];
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            xored[i] = (byte)(block[i] ^ _mac[i]);
        }

        using var encryptor = _aes.CreateEncryptor();
        encryptor.TransformBlock(xored, 0, BlockSizeBytes, _mac, 0);
    }
}
