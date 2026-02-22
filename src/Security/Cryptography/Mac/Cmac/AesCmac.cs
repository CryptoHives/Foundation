// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Computes AES-CMAC (Cipher-based Message Authentication Code) as defined in
/// NIST SP 800-38B and RFC 4493.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of AES-CMAC that uses the CryptoHives
/// AES cipher. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms.
/// </para>
/// <para>
/// AES-CMAC produces a 128-bit (16-byte) authentication tag and supports
/// AES-128, AES-192, and AES-256 key sizes.
/// </para>
/// <para>
/// Unlike HMAC which requires two passes, CMAC computes the tag in a single pass
/// using the underlying block cipher in CBC mode with derived subkeys.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// byte[] key = new byte[16]; // AES-128 key
/// byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
///
/// using var cmac = AesCmac.Create(key);
/// byte[] tag = cmac.ComputeHash(data);
/// </code>
/// </example>
public sealed class AesCmac : IMac
{
    private const int BlockSize = AesCore.BlockSizeBytes;
    private const int Rb = 0x87; // GF(2^128) polynomial reduction constant

    private readonly uint[] _roundKeys;
    private readonly int _rounds;
    private readonly byte[] _k1;
    private readonly byte[] _k2;
    private readonly byte[] _mac;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private bool _finalized;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly bool _useAesNi;
    private readonly Vector128<byte>[]? _niRoundKeys;
#endif

    /// <inheritdoc/>
    public string AlgorithmName => "AES-CMAC";

    /// <inheritdoc/>
    public int MacSize => BlockSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCmac"/> class.
    /// </summary>
    /// <param name="key">The secret key. Must be 16, 24, or 32 bytes.</param>
    /// <exception cref="ArgumentException">The key length is invalid.</exception>
    public AesCmac(byte[] key) : this(key.AsSpan())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCmac"/> class.
    /// </summary>
    /// <param name="key">The secret key. Must be 16, 24, or 32 bytes.</param>
    /// <exception cref="ArgumentException">The key length is invalid.</exception>
    public AesCmac(ReadOnlySpan<byte> key)
    {
        if (key.Length is not (16 or 24 or 32))
            throw new ArgumentException("Key must be 16, 24, or 32 bytes for AES-128, AES-192, or AES-256.", nameof(key));

#if NET8_0_OR_GREATER
        if (Aes.IsSupported)
        {
            _useAesNi = true;
            _niRoundKeys = new Vector128<byte>[15];
            _rounds = AesCoreAesNi.ExpandKey(key, _niRoundKeys);
            _roundKeys = [];
        }
        else
#endif
        {
            _roundKeys = new uint[60]; // AES-256: 4 × (8 + 7) = 60 words
            _rounds = AesCore.ExpandKey(key, _roundKeys);
        }

        _k1 = new byte[BlockSize];
        _k2 = new byte[BlockSize];
        DeriveSubkeys();

        _mac = new byte[BlockSize];
        _buffer = new byte[BlockSize];
        _bufferLength = 0;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AesCmac"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new AES-CMAC instance.</returns>
    public static AesCmac Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new instance of the <see cref="AesCmac"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new AES-CMAC instance.</returns>
    public static AesCmac Create(ReadOnlySpan<byte> key) => new(key);

    /// <inheritdoc/>
    public void Update(ReadOnlySpan<byte> input)
    {
        if (_finalized) throw new InvalidOperationException("Cannot update after finalization. Call Reset() first.");

        int offset = 0;

        // If we have buffered data, try to fill the block
        if (_bufferLength > 0)
        {
            int needed = BlockSize - _bufferLength;
            if (input.Length <= needed)
            {
                input.CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += input.Length;
                return;
            }

            input.Slice(0, needed).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength = BlockSize;

            // Process buffered full block (but only if there's more data after)
            if (input.Length > needed)
            {
                XorAndEncrypt(_mac, _buffer);
                _bufferLength = 0;
                offset = needed;
            }
        }

        // Process full blocks, keeping the last block in the buffer
        while (offset + BlockSize < input.Length)
        {
            XorAndEncrypt(_mac, input.Slice(offset, BlockSize));
            offset += BlockSize;
        }

        // Buffer remaining data
        int remaining = input.Length - offset;
        if (remaining > 0)
        {
            input.Slice(offset, remaining).CopyTo(_buffer.AsSpan(0));
            _bufferLength = remaining;
        }
    }

    /// <inheritdoc/>
    public void Finalize(Span<byte> destination)
    {
        if (destination.Length < BlockSize) throw new ArgumentException("Destination buffer is too small.", nameof(destination));
        if (_finalized) throw new InvalidOperationException("Already finalized. Call Reset() first.");

        if (_bufferLength == BlockSize)
        {
            // Complete block: XOR with K1
            for (int i = 0; i < BlockSize; i++)
            {
                _buffer[i] ^= _k1[i];
            }
        }
        else
        {
            // Incomplete block: pad with 10*0 and XOR with K2
            _buffer[_bufferLength] = 0x80;
            for (int i = _bufferLength + 1; i < BlockSize; i++)
            {
                _buffer[i] = 0x00;
            }

            for (int i = 0; i < BlockSize; i++)
            {
                _buffer[i] ^= _k2[i];
            }
        }

        XorAndEncrypt(_mac, _buffer);
        _mac.AsSpan().CopyTo(destination);
        _finalized = true;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _finalized = false;
        Array.Clear(_mac, 0, BlockSize);
        Array.Clear(_buffer, 0, BlockSize);
        _bufferLength = 0;
    }

    /// <summary>
    /// Computes the AES-CMAC tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public byte[] ComputeHash(ReadOnlySpan<byte> data)
    {
        Reset();
        Update(data);
        byte[] result = new byte[BlockSize];
        Finalize(result);
        return result;
    }

    /// <summary>
    /// Computes the AES-CMAC tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public byte[] ComputeHash(byte[] data)
    {
        return ComputeHash(data.AsSpan());
    }

    /// <summary>
    /// Computes the AES-CMAC tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var cmac = new AesCmac(key);
        return cmac.ComputeHash(data);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_roundKeys, 0, _roundKeys.Length);
#if NET8_0_OR_GREATER
            if (_niRoundKeys is not null)
                Array.Clear(_niRoundKeys, 0, _niRoundKeys.Length);
#endif
            Array.Clear(_k1, 0, _k1.Length);
            Array.Clear(_k2, 0, _k2.Length);
            Array.Clear(_mac, 0, _mac.Length);
            Array.Clear(_buffer, 0, _buffer.Length);
            _disposed = true;
        }
    }

    private void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (_useAesNi)
        {
            AesCoreAesNi.EncryptBlock(input, output, _niRoundKeys, _rounds);
            return;
        }
#endif
        AesCore.EncryptBlock(input, output, _roundKeys, _rounds);
    }

    private void XorAndEncrypt(Span<byte> mac, ReadOnlySpan<byte> block)
    {
        for (int i = 0; i < BlockSize; i++)
        {
            mac[i] ^= block[i];
        }

        Span<byte> temp = stackalloc byte[BlockSize];
        EncryptBlock(mac, temp);
        temp.CopyTo(mac);
    }

    private void DeriveSubkeys()
    {
        // L = AES-K(0^128)
        Span<byte> zero = stackalloc byte[BlockSize];
        Span<byte> l = stackalloc byte[BlockSize];
        EncryptBlock(zero, l);

        // K1 = L << 1 in GF(2^128)
        DoubleBlock(l, _k1);

        // K2 = K1 << 1 in GF(2^128)
        DoubleBlock(_k1, _k2);
    }

    /// <summary>
    /// Doubles a 128-bit block in GF(2^128) with reduction polynomial x^128 + x^7 + x^2 + x + 1.
    /// </summary>
    private static void DoubleBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        byte carry = 0;
        for (int i = BlockSize - 1; i >= 0; i--)
        {
            byte b = input[i];
            output[i] = (byte)((b << 1) | carry);
            carry = (byte)(b >> 7);
        }

        // If MSB was set, XOR with Rb
        if ((input[0] & 0x80) != 0)
        {
            output[BlockSize - 1] ^= Rb;
        }
    }
}
