// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Poly1305 message authentication code implementation as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// Poly1305 is a high-speed message authentication code designed by Daniel J. Bernstein.
/// It takes a 32-byte one-time key and a message to produce a 16-byte tag.
/// </para>
/// </remarks>
internal static class Poly1305
{
    /// <summary>
    /// Poly1305 tag size in bytes.
    /// </summary>
    public const int TagSizeBytes = 16;

    /// <summary>
    /// Poly1305 key size in bytes.
    /// </summary>
    public const int KeySizeBytes = 32;

    private const int BlockSize = 16;

    // p = 2^130 - 5
    private static readonly BigInteger P = (BigInteger.One << 130) - 5;

    /// <summary>
    /// Computes the Poly1305 MAC for the given message.
    /// </summary>
    public static void ComputeTag(ReadOnlySpan<byte> key, ReadOnlySpan<byte> message, Span<byte> tag)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytes} bytes.", nameof(tag));

        // Clamp r
        Span<byte> rBytes = stackalloc byte[16];
        key.Slice(0, 16).CopyTo(rBytes);
        rBytes[3] &= 0x0f;
        rBytes[7] &= 0x0f;
        rBytes[11] &= 0x0f;
        rBytes[15] &= 0x0f;
        rBytes[4] &= 0xfc;
        rBytes[8] &= 0xfc;
        rBytes[12] &= 0xfc;

        // Load r and s as BigIntegers
        BigInteger r = LoadLittleEndian(rBytes);
        BigInteger s = LoadLittleEndian(key.Slice(16, 16));

        // Process message
        Span<byte> block = stackalloc byte[17];
        BigInteger acc = BigInteger.Zero;
        int offset = 0;
        while (offset < message.Length)
        {
            int blockLen = Math.Min(BlockSize, message.Length - offset);

            // Load block and append 0x01
            block.Clear();
            message.Slice(offset, blockLen).CopyTo(block);
            block[blockLen] = 0x01;

            BigInteger n = LoadLittleEndian(block.Slice(0, blockLen + 1));
            acc = ((acc + n) * r) % P;

            offset += BlockSize;
        }

        // Add s and output (mod 2^128)
        BigInteger result = (acc + s) & ((BigInteger.One << 128) - 1);
        byte[] resultBytes = result.ToByteArray();

        // Output first 16 bytes (little-endian)
        for (int i = 0; i < TagSizeBytes; i++)
        {
            tag[i] = i < resultBytes.Length ? resultBytes[i] : (byte)0;
        }
    }

    /// <summary>
    /// Computes Poly1305 MAC for ChaCha20-Poly1305 AEAD construction.
    /// </summary>
    public static void ComputeAeadTag(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> tag)
    {
        int aadPadded = (aad.Length + 15) & ~15;
        int ctPadded = (ciphertext.Length + 15) & ~15;
        int totalLen = aadPadded + ctPadded + 16;

        byte[]? macInputArray = null;
        Span<byte> macInput = totalLen <= 512
            ? stackalloc byte[totalLen]
            : (macInputArray = ArrayPool<byte>.Shared.Rent(totalLen)).AsSpan(0, totalLen);

        try
        {
            macInput.Clear();
            aad.CopyTo(macInput.Slice(0));
            int pos = aadPadded;
            ciphertext.CopyTo(macInput.Slice(pos));
            pos += ctPadded;
            BinaryPrimitives.WriteUInt64LittleEndian(macInput.Slice(pos), (ulong)aad.Length);
            pos += sizeof(UInt64);
            BinaryPrimitives.WriteUInt64LittleEndian(macInput.Slice(pos), (ulong)ciphertext.Length);

            ComputeTag(key, macInput, tag);
        }
        finally
        {
            if (macInputArray != null)
            {
                ArrayPool<byte>.Shared.Return(macInputArray);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static BigInteger LoadLittleEndian(ReadOnlySpan<byte> data)
    {
        // BigInteger expects little-endian with an extra 0 byte if high bit is set
        byte[] temp = new byte[data.Length + 1];
        data.CopyTo(temp);
        temp[data.Length] = 0; // Ensure positive
        return new BigInteger(temp);
    }
}
