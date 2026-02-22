// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

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
internal unsafe struct CcmCore
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
    /// Maximum number of round key words (AES-256: 4 × (8 + 7) = 60).
    /// </summary>
    private const int MaxRoundKeyWords = 60;

    private unsafe fixed uint _roundKeys[MaxRoundKeyWords];
    private readonly int _rounds;
#if NET8_0_OR_GREATER
    private readonly bool _useAesNi;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="CcmCore"/> struct with the specified key and SIMD support.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    public CcmCore(ReadOnlySpan<byte> key, SimdSupport simdSupport)
    {
        fixed (uint* p = _roundKeys)
        {
            var roundKeys = new Span<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if ((simdSupport & SimdSupport & SimdSupport.AesNi) != 0)
            {
                _useAesNi = true;
                _rounds = AesCoreAesNi.ExpandKey(key, MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys));
            }
            else
#endif
            {
                _rounds = AesCore.ExpandKey(key, roundKeys);
            }
        }
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES-CCM on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        AesCoreAesNi.IsSupported ? SimdSupport.AesNi : SimdSupport.None;
#else
        SimdSupport.None;
#endif

    /// <summary>
    /// Clears the round key material.
    /// </summary>
    public void Clear()
    {
        fixed (uint* p = _roundKeys)
        {
            new Span<uint>(p, MaxRoundKeyWords).Clear();
        }
    }

    /// <summary>
    /// Encrypts and authenticates data using CCM mode with AES.
    /// </summary>
    /// <param name="nonce">The nonce (7-13 bytes).</param>
    /// <param name="plaintext">The plaintext to encrypt.</param>
    /// <param name="associatedData">Additional authenticated data.</param>
    /// <param name="ciphertext">Output buffer for ciphertext.</param>
    /// <param name="tag">Output buffer for authentication tag.</param>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData,
        Span<byte> ciphertext,
        Span<byte> tag)
    {
        ValidateParameters(nonce, plaintext, tag);

        int L = 15 - nonce.Length;
        int M = tag.Length;

        // Compute CBC-MAC
        Span<byte> macTag = stackalloc byte[BlockSizeBytes];
        ComputeCbcMac(nonce, plaintext, associatedData, macTag, L, M);

        // Encrypt using CTR mode
        EncryptCtr(nonce, plaintext, ciphertext, L);

        // Encrypt the MAC tag
        Span<byte> s0 = stackalloc byte[BlockSizeBytes];
        FormatCounterBlock(nonce, 0, s0, L);
        EncryptBlockDispatch(s0, s0);

        // XOR MAC with S_0 to get final tag
        for (int i = 0; i < M; i++)
        {
            tag[i] = (byte)(macTag[i] ^ s0[i]);
        }
    }

    /// <summary>
    /// Decrypts and verifies data using CCM mode.
    /// </summary>
    /// <param name="nonce">The nonce (7-13 bytes).</param>
    /// <param name="ciphertext">The ciphertext to decrypt.</param>
    /// <param name="tag">The authentication tag to verify.</param>
    /// <param name="associatedData">Additional authenticated data.</param>
    /// <param name="plaintext">Output buffer for plaintext.</param>
    /// <returns>True if authentication succeeded; otherwise false.</returns>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        ReadOnlySpan<byte> associatedData,
        Span<byte> plaintext)
    {
        ValidateParameters(nonce, ciphertext, tag);

        int L = 15 - nonce.Length;
        int M = tag.Length;

        // Decrypt using CTR mode
        DecryptCtr(nonce, ciphertext, plaintext, L);

        // Compute CBC-MAC over decrypted plaintext
        Span<byte> macTag = stackalloc byte[BlockSizeBytes];
        ComputeCbcMac(nonce, plaintext, associatedData, macTag, L, M);

        // Encrypt the computed MAC tag
        Span<byte> s0 = stackalloc byte[BlockSizeBytes];
        FormatCounterBlock(nonce, 0, s0, L);
        EncryptBlockDispatch(s0, s0);

        // XOR to get expected tag
        Span<byte> expectedTag = stackalloc byte[M];
        for (int i = 0; i < M; i++)
        {
            expectedTag[i] = (byte)(macTag[i] ^ s0[i]);
        }

        // Constant-time comparison
        return CryptoUtils.FixedTimeEquals(tag, expectedTag);
    }

    private void ComputeCbcMac(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> message,
        ReadOnlySpan<byte> associatedData,
        Span<byte> mac,
        int L,
        int M)
    {
        // Format B_0 block
        Span<byte> b = stackalloc byte[BlockSizeBytes];
        FormatB0Block(nonce, message.Length, associatedData.Length, L, M, b);

        // Initialize MAC with B_0
        Span<byte> x = stackalloc byte[BlockSizeBytes];
        EncryptBlockDispatch(b, x);

        // Process AAD if present
        if (associatedData.Length > 0)
        {
            ProcessAad(associatedData, x, b);
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
            EncryptBlockDispatch(b, x);

            offset += BlockSizeBytes;
        }

        // Copy MAC result
        x.Slice(0, M).CopyTo(mac);
    }

    [SkipLocalsInit]
    private void EncryptCtr(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        int L)
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
            EncryptBlockDispatch(counterBlock, keystream);

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

    [SkipLocalsInit]
    private void DecryptCtr(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> plaintext,
        int L)
    {
        // CTR decryption is same as encryption
        EncryptCtr(nonce, ciphertext, plaintext, L);
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

    private void ProcessAad(
        ReadOnlySpan<byte> aad,
        Span<byte> x,
        Span<byte> b)
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
        EncryptBlockDispatch(b, x);

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
            EncryptBlockDispatch(b, x);

            aadOffset += BlockSizeBytes;
        }
    }

    /// <summary>
    /// Dispatches a single AES block encryption to AES-NI or managed implementation.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EncryptBlockDispatch(Span<byte> input, Span<byte> output)
    {
        fixed (uint* p = _roundKeys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (_useAesNi)
            {
                AesCoreAesNi.EncryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.EncryptBlock(input, output, roundKeys, _rounds);
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
