// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Core CCM (Counter with CBC-MAC) operations as specified in RFC 3610.
/// </summary>
/// <remarks>
/// <para>
/// CCM is an authenticated encryption mode for 128-bit block ciphers that combines
/// CBC-MAC for authentication with CTR mode for encryption.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>Defined for 128-bit block ciphers only (AES)</description></item>
///   <item><description>Authenticate-then-encrypt construction</description></item>
///   <item><description>Variable tag length (4-16 bytes)</description></item>
///   <item><description>Variable nonce length (7-13 bytes)</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class CcmCore
{
    /// <summary>
    /// Block size in bytes (128 bits = 16 bytes).
    /// </summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// Minimum tag size in bytes.
    /// </summary>
    public const int MinTagSizeBytes = 4;

    /// <summary>
    /// Maximum tag size in bytes.
    /// </summary>
    public const int MaxTagSizeBytes = 16;

    /// <summary>
    /// Minimum nonce size in bytes.
    /// </summary>
    public const int MinNonceSizeBytes = 7;

    /// <summary>
    /// Maximum nonce size in bytes.
    /// </summary>
    public const int MaxNonceSizeBytes = 13;

    /// <summary>
    /// Encrypts and authenticates data using CCM mode with AES.
    /// </summary>
    /// <param name="nonce">The nonce (7-13 bytes).</param>
    /// <param name="plaintext">The plaintext to encrypt.</param>
    /// <param name="associatedData">Additional authenticated data (can be empty).</param>
    /// <param name="ciphertext">Output buffer for ciphertext.</param>
    /// <param name="tag">Output buffer for authentication tag.</param>
    /// <param name="roundKeys">AES round keys.</param>
    /// <param name="rounds">Number of AES rounds.</param>
    public static void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        ValidateParameters(nonce, plaintext, tag);

        int L = 15 - nonce.Length;
        int M = tag.Length;

        // Compute CBC-MAC
        Span<byte> macTag = stackalloc byte[BlockSizeBytes];
        ComputeCbcMac(nonce, plaintext, associatedData, macTag, L, M, roundKeys, rounds);

        // Encrypt using CTR mode
        EncryptCtr(nonce, plaintext, ciphertext, L, roundKeys, rounds);

        // Encrypt the MAC tag
        Span<byte> s0 = stackalloc byte[BlockSizeBytes];
        FormatCounterBlock(nonce, 0, s0, L);
        AesCore.EncryptBlock(s0, s0, roundKeys, rounds);

        // XOR MAC with S_0 to get final tag
        for (int i = 0; i < M; i++)
        {
            tag[i] = (byte)(macTag[i] ^ s0[i]);
        }
    }

    /// <summary>
    /// Decrypts and verifies data using CCM mode.
    /// </summary>
    public static bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        ReadOnlySpan<byte> associatedData,
        Span<byte> plaintext,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        ValidateParameters(nonce, ciphertext, tag);

        int L = 15 - nonce.Length;
        int M = tag.Length;

        // Decrypt using CTR mode
        DecryptCtr(nonce, ciphertext, plaintext, L, roundKeys, rounds);

        // Compute CBC-MAC over decrypted plaintext
        Span<byte> macTag = stackalloc byte[BlockSizeBytes];
        ComputeCbcMac(nonce, plaintext, associatedData, macTag, L, M, roundKeys, rounds);

        // Encrypt the computed MAC tag
        Span<byte> s0 = stackalloc byte[BlockSizeBytes];
        FormatCounterBlock(nonce, 0, s0, L);
        AesCore.EncryptBlock(s0, s0, roundKeys, rounds);

        // XOR to get expected tag
        Span<byte> expectedTag = stackalloc byte[M];
        for (int i = 0; i < M; i++)
        {
            expectedTag[i] = (byte)(macTag[i] ^ s0[i]);
        }

        // Constant-time comparison
        return CryptoUtils.FixedTimeEquals(tag, expectedTag);
    }

    private static void ComputeCbcMac(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> message,
        ReadOnlySpan<byte> associatedData,
        Span<byte> mac,
        int L,
        int M,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        // Format B_0 block
        Span<byte> b = stackalloc byte[BlockSizeBytes];
        FormatB0Block(nonce, message.Length, associatedData.Length, L, M, b);

        // Initialize MAC with B_0
        Span<byte> x = stackalloc byte[BlockSizeBytes];
        AesCore.EncryptBlock(b, x, roundKeys, rounds);

        // Process AAD if present
        if (associatedData.Length > 0)
        {
            ProcessAad(associatedData, x, b, roundKeys, rounds);
        }

        // Process message
        int offset = 0;
        while (offset < message.Length)
        {
            int blockLen = Math.Min(BlockSizeBytes, message.Length - offset);
            b.Clear();
            message.Slice(offset, blockLen).CopyTo(b);

            // XOR with previous X and encrypt
            for (int i = 0; i < BlockSizeBytes; i++)
            {
                b[i] ^= x[i];
            }
            AesCore.EncryptBlock(b, x, roundKeys, rounds);

            offset += BlockSizeBytes;
        }

        // Copy MAC result
        x.Slice(0, M).CopyTo(mac);
    }

    private static void EncryptCtr(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        int L,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        Span<byte> counterBlock = stackalloc byte[BlockSizeBytes];
        Span<byte> keystream = stackalloc byte[BlockSizeBytes];

        int offset = 0;
        uint counter = 1; // Start from 1 (0 is used for MAC)

        while (offset < plaintext.Length)
        {
            // Format counter block
            FormatCounterBlock(nonce, counter, counterBlock, L);

            // Generate keystream
            AesCore.EncryptBlock(counterBlock, keystream, roundKeys, rounds);

            // XOR plaintext with keystream
            int remaining = plaintext.Length - offset;
            int bytesToProcess = Math.Min(remaining, BlockSizeBytes);

            for (int i = 0; i < bytesToProcess; i++)
            {
                ciphertext[offset + i] = (byte)(plaintext[offset + i] ^ keystream[i]);
            }

            offset += BlockSizeBytes;
            counter++;
        }
    }

    private static void DecryptCtr(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> plaintext,
        int L,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        // CTR decryption is same as encryption
        EncryptCtr(nonce, ciphertext, plaintext, L, roundKeys, rounds);
    }

    private static void FormatB0Block(
        ReadOnlySpan<byte> nonce,
        int messageLength,
        int aadLength,
        int L,
        int M,
        Span<byte> b0)
    {
        b0.Clear();

        // Flags byte
        byte flags = (byte)((L - 1) & 0x07);
        flags |= (byte)(((M - 2) / 2) << 3);
        if (aadLength > 0)
        {
            flags |= 0x40;
        }

        b0[0] = flags;

        // Nonce
        nonce.CopyTo(b0.Slice(1, nonce.Length));

        // Message length (big-endian)
        int lenOffset = BlockSizeBytes - L;
        for (int i = 0; i < L; i++)
        {
            b0[BlockSizeBytes - 1 - i] = (byte)(messageLength >> (i * 8));
        }
    }

    private static void FormatCounterBlock(
        ReadOnlySpan<byte> nonce,
        uint counter,
        Span<byte> block,
        int L)
    {
        block.Clear();

        // Flags byte
        byte flags = (byte)((L - 1) & 0x07);
        block[0] = flags;

        // Nonce
        nonce.CopyTo(block.Slice(1, nonce.Length));

        // Counter (big-endian)
        for (int i = 0; i < L; i++)
        {
            block[BlockSizeBytes - 1 - i] = (byte)(counter >> (i * 8));
        }
    }

    private static void ProcessAad(
        ReadOnlySpan<byte> aad,
        Span<byte> x,
        Span<byte> b,
        ReadOnlySpan<uint> roundKeys,
        int rounds)
    {
        b.Clear();
        int pos = 0;

        // Encode AAD length
        // aad.Length is int, so maximum value is int.MaxValue (~2GB)
        // This is always less than 0xFFFFFFFF, so always use medium form for large AAD
        if (aad.Length < 0xFF00)
        {
            // Short form: 2 bytes
            b[pos++] = (byte)(aad.Length >> 8);
            b[pos++] = (byte)aad.Length;
        }
        else
        {
            // Medium form: 6 bytes (0xFFFE + 4 bytes)
            b[pos++] = 0xFF;
            b[pos++] = 0xFE;
            b[pos++] = (byte)(aad.Length >> 24);
            b[pos++] = (byte)(aad.Length >> 16);
            b[pos++] = (byte)(aad.Length >> 8);
            b[pos++] = (byte)aad.Length;
        }

        // Copy AAD
        int aadOffset = 0;
        int remaining = BlockSizeBytes - pos;
        int toCopy = Math.Min(remaining, aad.Length);
        aad.Slice(0, toCopy).CopyTo(b.Slice(pos));
        aadOffset += toCopy;

        // Process first block
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            b[i] ^= x[i];
        }
        AesCore.EncryptBlock(b, x, roundKeys, rounds);

        // Process remaining AAD blocks
        while (aadOffset < aad.Length)
        {
            int blockLen = Math.Min(BlockSizeBytes, aad.Length - aadOffset);
            b.Clear();
            aad.Slice(aadOffset, blockLen).CopyTo(b);

            for (int i = 0; i < BlockSizeBytes; i++)
            {
                b[i] ^= x[i];
            }
            AesCore.EncryptBlock(b, x, roundKeys, rounds);

            aadOffset += BlockSizeBytes;
        }
    }

    private static void ValidateParameters(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> data,
        ReadOnlySpan<byte> tag)
    {
        if (nonce.Length < MinNonceSizeBytes || nonce.Length > MaxNonceSizeBytes)
            throw new ArgumentException($"Nonce must be between {MinNonceSizeBytes} and {MaxNonceSizeBytes} bytes.", nameof(nonce));

        int L = 15 - nonce.Length;
        long maxMessageLength = (1L << (8 * L)) - 1;
        if (data.Length > maxMessageLength)
            throw new ArgumentException($"Message too large for nonce length {nonce.Length}.", nameof(data));

        if (tag.Length < MinTagSizeBytes || tag.Length > MaxTagSizeBytes)
            throw new ArgumentException($"Tag must be between {MinTagSizeBytes} and {MaxTagSizeBytes} bytes.", nameof(tag));

        // Tag length must be even and in the valid set
        if (tag.Length % 2 != 0)
            throw new ArgumentException("Tag length must be even.", nameof(tag));
    }
}
