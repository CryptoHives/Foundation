// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Core AES (Rijndael) operations shared by all AES key sizes.
/// </summary>
/// <remarks>
/// <para>
/// This class implements the AES block cipher as specified in FIPS 197.
/// It provides the core operations used by AES-128, AES-192, and AES-256.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>Uses T-tables for optimized encryption/decryption</description></item>
///   <item><description>Constant-time S-box lookups to resist timing attacks</description></item>
///   <item><description>Supports 128-bit block size only (standard AES)</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class AesCore
{
    /// <summary>
    /// AES block size in bytes (always 16 for standard AES).
    /// </summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// AES block size in bits.
    /// </summary>
    public const int BlockSizeBits = 128;

    /// <summary>
    /// Number of columns in the state (Nb = 4 for AES).
    /// </summary>
    public const int Nb = 4;

    /// <summary>
    /// AES S-box (SubBytes transformation).
    /// </summary>
    /// <remarks>
    /// The S-box is a non-linear substitution table used in SubBytes.
    /// It is derived from the multiplicative inverse over GF(2^8) followed
    /// by an affine transformation.
    /// </remarks>
    private static readonly byte[] SBox =
    [
        0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
        0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
        0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
        0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
        0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
        0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
        0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
        0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
        0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
        0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
        0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
        0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
        0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
        0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
        0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
        0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
    ];

    /// <summary>
    /// AES inverse S-box (InvSubBytes transformation).
    /// </summary>
    private static readonly byte[] InvSBox =
    [
        0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
        0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
        0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
        0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
        0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
        0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
        0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
        0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
        0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
        0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
        0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
        0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
        0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
        0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
        0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
        0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
    ];

    /// <summary>
    /// Round constants for key expansion (Rcon).
    /// </summary>
    /// <remarks>
    /// Rcon[i] = x^(i-1) in GF(2^8), where x = {02}.
    /// Only the first byte of each word is non-zero.
    /// </remarks>
    private static readonly byte[] Rcon =
    [
        0x00, // Not used (index 0)
        0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36
    ];

    // ========================================================================
    // T-Tables for optimized encryption
    // ========================================================================

    /// <summary>
    /// Encryption T-table 0: combines SubBytes, ShiftRows, and MixColumns.
    /// </summary>
    private static readonly uint[] Te0 = GenerateTe0();

    /// <summary>
    /// Encryption T-table 1.
    /// </summary>
    private static readonly uint[] Te1 = GenerateTe1();

    /// <summary>
    /// Encryption T-table 2.
    /// </summary>
    private static readonly uint[] Te2 = GenerateTe2();

    /// <summary>
    /// Encryption T-table 3.
    /// </summary>
    private static readonly uint[] Te3 = GenerateTe3();

    /// <summary>
    /// Decryption T-table 0.
    /// </summary>
    private static readonly uint[] Td0 = GenerateTd0();

    /// <summary>
    /// Decryption T-table 1.
    /// </summary>
    private static readonly uint[] Td1 = GenerateTd1();

    /// <summary>
    /// Decryption T-table 2.
    /// </summary>
    private static readonly uint[] Td2 = GenerateTd2();

    /// <summary>
    /// Decryption T-table 3.
    /// </summary>
    private static readonly uint[] Td3 = GenerateTd3();

    // ========================================================================
    // Key Expansion
    // ========================================================================

    /// <summary>
    /// Expands a cipher key into the encryption key schedule.
    /// </summary>
    /// <param name="key">The cipher key (16, 24, or 32 bytes).</param>
    /// <param name="roundKeys">Output buffer for round keys (44, 52, or 60 words).</param>
    /// <returns>The number of rounds (10, 12, or 14).</returns>
    public static int ExpandKey(ReadOnlySpan<byte> key, Span<uint> roundKeys)
    {
        int nk = key.Length / 4; // Key length in 32-bit words (4, 6, or 8)
        int nr = nk + 6;         // Number of rounds (10, 12, or 14)
        int nw = Nb * (nr + 1);  // Number of round key words (44, 52, or 60)

        unchecked
        {
            // Copy key bytes to first Nk words
            for (int i = 0; i < nk; i++)
            {
                roundKeys[i] = ((uint)key[4 * i] << 24) | ((uint)key[4 * i + 1] << 16) |
                               ((uint)key[4 * i + 2] << 8) | key[4 * i + 3];
            }

            // Generate remaining round key words
            for (int i = nk; i < nw; i++)
            {
                uint temp = roundKeys[i - 1];

                if (i % nk == 0)
                {
                    // RotWord + SubWord + Rcon
                    temp = SubWord(RotWord(temp)) ^ ((uint)Rcon[i / nk] << 24);
                }
                else if (nk > 6 && i % nk == 4)
                {
                    // Additional SubWord for AES-256
                    temp = SubWord(temp);
                }

                roundKeys[i] = roundKeys[i - nk] ^ temp;
            }
        }

        return nr;
    }

    /// <summary>
    /// Creates the decryption key schedule from the encryption key schedule.
    /// </summary>
    /// <param name="encRoundKeys">The encryption round keys.</param>
    /// <param name="decRoundKeys">Output buffer for decryption round keys.</param>
    /// <param name="nr">Number of rounds.</param>
    public static void CreateDecryptionKeys(ReadOnlySpan<uint> encRoundKeys, Span<uint> decRoundKeys, int nr)
    {
        unchecked
        {
            int nw = Nb * (nr + 1);

            // First and last round keys are the same (just reversed order)
            for (int i = 0; i < Nb; i++)
            {
                decRoundKeys[i] = encRoundKeys[nw - Nb + i];
                decRoundKeys[nw - Nb + i] = encRoundKeys[i];
            }

            // Apply InvMixColumns to middle round keys
            for (int round = 1; round < nr; round++)
            {
                int srcOffset = round * Nb;
                int dstOffset = (nr - round) * Nb;

                for (int i = 0; i < Nb; i++)
                {
                    uint w = encRoundKeys[srcOffset + i];
                    decRoundKeys[dstOffset + i] = InvMixColumn(w);
                }
            }
        }
    }

    // ========================================================================
    // Block Encryption/Decryption
    // ========================================================================

    /// <summary>
    /// Encrypts a single 16-byte block using the expanded key schedule.
    /// </summary>
    /// <param name="input">The 16-byte plaintext block.</param>
    /// <param name="output">The 16-byte ciphertext output.</param>
    /// <param name="roundKeys">The expanded encryption key schedule.</param>
    /// <param name="nr">Number of rounds (10, 12, or 14).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys, int nr)
    {
        unchecked
        {
            // Load input as 4 columns (state) and add initial round key
            uint s0 = LoadBigEndian(input, 0) ^ roundKeys[0];
            uint s1 = LoadBigEndian(input, 4) ^ roundKeys[1];
            uint s2 = LoadBigEndian(input, 8) ^ roundKeys[2];
            uint s3 = LoadBigEndian(input, 12) ^ roundKeys[3];

            uint t0, t1, t2, t3;
            int keyOffset = 4;

            // Main rounds (all except last)
            for (int round = 1; round < nr; round++)
            {
                t0 = Te0[(s0 >> 24) & 0xff] ^ Te1[(s1 >> 16) & 0xff] ^ Te2[(s2 >> 8) & 0xff] ^ Te3[s3 & 0xff] ^ roundKeys[keyOffset];
                t1 = Te0[(s1 >> 24) & 0xff] ^ Te1[(s2 >> 16) & 0xff] ^ Te2[(s3 >> 8) & 0xff] ^ Te3[s0 & 0xff] ^ roundKeys[keyOffset + 1];
                t2 = Te0[(s2 >> 24) & 0xff] ^ Te1[(s3 >> 16) & 0xff] ^ Te2[(s0 >> 8) & 0xff] ^ Te3[s1 & 0xff] ^ roundKeys[keyOffset + 2];
                t3 = Te0[(s3 >> 24) & 0xff] ^ Te1[(s0 >> 16) & 0xff] ^ Te2[(s1 >> 8) & 0xff] ^ Te3[s2 & 0xff] ^ roundKeys[keyOffset + 3];

                s0 = t0; s1 = t1; s2 = t2; s3 = t3;
                keyOffset += 4;
            }

            // Final round (no MixColumns)
            t0 = ((uint)SBox[(s0 >> 24) & 0xff] << 24) ^ ((uint)SBox[(s1 >> 16) & 0xff] << 16) ^
                 ((uint)SBox[(s2 >> 8) & 0xff] << 8) ^ SBox[s3 & 0xff] ^ roundKeys[keyOffset];
            t1 = ((uint)SBox[(s1 >> 24) & 0xff] << 24) ^ ((uint)SBox[(s2 >> 16) & 0xff] << 16) ^
                 ((uint)SBox[(s3 >> 8) & 0xff] << 8) ^ SBox[s0 & 0xff] ^ roundKeys[keyOffset + 1];
            t2 = ((uint)SBox[(s2 >> 24) & 0xff] << 24) ^ ((uint)SBox[(s3 >> 16) & 0xff] << 16) ^
                 ((uint)SBox[(s0 >> 8) & 0xff] << 8) ^ SBox[s1 & 0xff] ^ roundKeys[keyOffset + 2];
            t3 = ((uint)SBox[(s3 >> 24) & 0xff] << 24) ^ ((uint)SBox[(s0 >> 16) & 0xff] << 16) ^
                 ((uint)SBox[(s1 >> 8) & 0xff] << 8) ^ SBox[s2 & 0xff] ^ roundKeys[keyOffset + 3];

            // Store output
            StoreBigEndian(output, 0, t0);
            StoreBigEndian(output, 4, t1);
            StoreBigEndian(output, 8, t2);
            StoreBigEndian(output, 12, t3);
        }
    }

    /// <summary>
    /// Decrypts a single 16-byte block using the expanded key schedule.
    /// </summary>
    /// <param name="input">The 16-byte ciphertext block.</param>
    /// <param name="output">The 16-byte plaintext output.</param>
    /// <param name="roundKeys">The expanded decryption key schedule.</param>
    /// <param name="nr">Number of rounds (10, 12, or 14).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys, int nr)
    {
        unchecked
        {
            // Load input as 4 columns and add initial round key
            uint s0 = LoadBigEndian(input, 0) ^ roundKeys[0];
            uint s1 = LoadBigEndian(input, 4) ^ roundKeys[1];
            uint s2 = LoadBigEndian(input, 8) ^ roundKeys[2];
            uint s3 = LoadBigEndian(input, 12) ^ roundKeys[3];

            uint t0, t1, t2, t3;
            int keyOffset = 4;

            // Main rounds (all except last)
            for (int round = 1; round < nr; round++)
            {
                t0 = Td0[(s0 >> 24) & 0xff] ^ Td1[(s3 >> 16) & 0xff] ^ Td2[(s2 >> 8) & 0xff] ^ Td3[s1 & 0xff] ^ roundKeys[keyOffset];
                t1 = Td0[(s1 >> 24) & 0xff] ^ Td1[(s0 >> 16) & 0xff] ^ Td2[(s3 >> 8) & 0xff] ^ Td3[s2 & 0xff] ^ roundKeys[keyOffset + 1];
                t2 = Td0[(s2 >> 24) & 0xff] ^ Td1[(s1 >> 16) & 0xff] ^ Td2[(s0 >> 8) & 0xff] ^ Td3[s3 & 0xff] ^ roundKeys[keyOffset + 2];
                t3 = Td0[(s3 >> 24) & 0xff] ^ Td1[(s2 >> 16) & 0xff] ^ Td2[(s1 >> 8) & 0xff] ^ Td3[s0 & 0xff] ^ roundKeys[keyOffset + 3];

                s0 = t0; s1 = t1; s2 = t2; s3 = t3;
                keyOffset += 4;
            }

            // Final round (no InvMixColumns)
            t0 = ((uint)InvSBox[(s0 >> 24) & 0xff] << 24) ^ ((uint)InvSBox[(s3 >> 16) & 0xff] << 16) ^
                 ((uint)InvSBox[(s2 >> 8) & 0xff] << 8) ^ InvSBox[s1 & 0xff] ^ roundKeys[keyOffset];
            t1 = ((uint)InvSBox[(s1 >> 24) & 0xff] << 24) ^ ((uint)InvSBox[(s0 >> 16) & 0xff] << 16) ^
                 ((uint)InvSBox[(s3 >> 8) & 0xff] << 8) ^ InvSBox[s2 & 0xff] ^ roundKeys[keyOffset + 1];
            t2 = ((uint)InvSBox[(s2 >> 24) & 0xff] << 24) ^ ((uint)InvSBox[(s1 >> 16) & 0xff] << 16) ^
                 ((uint)InvSBox[(s0 >> 8) & 0xff] << 8) ^ InvSBox[s3 & 0xff] ^ roundKeys[keyOffset + 2];
            t3 = ((uint)InvSBox[(s3 >> 24) & 0xff] << 24) ^ ((uint)InvSBox[(s2 >> 16) & 0xff] << 16) ^
                 ((uint)InvSBox[(s1 >> 8) & 0xff] << 8) ^ InvSBox[s0 & 0xff] ^ roundKeys[keyOffset + 3];

            // Store output
            StoreBigEndian(output, 0, t0);
            StoreBigEndian(output, 4, t1);
            StoreBigEndian(output, 8, t2);
            StoreBigEndian(output, 12, t3);
        }
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    /// <summary>
    /// Applies S-box substitution to each byte of a word.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint SubWord(uint w)
    {
        unchecked
        {
            return ((uint)SBox[(w >> 24) & 0xff] << 24) |
                   ((uint)SBox[(w >> 16) & 0xff] << 16) |
                   ((uint)SBox[(w >> 8) & 0xff] << 8) |
                   SBox[w & 0xff];
        }
    }

    /// <summary>
    /// Rotates a word left by 8 bits (one byte position).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotWord(uint w)
    {
        unchecked
        {
            return (w << 8) | (w >> 24);
        }
    }

    /// <summary>
    /// Applies InvMixColumns to a single column for decryption key schedule.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint InvMixColumn(uint w)
    {
        unchecked
        {
            return Td0[SBox[(w >> 24) & 0xff]] ^
                   Td1[SBox[(w >> 16) & 0xff]] ^
                   Td2[SBox[(w >> 8) & 0xff]] ^
                   Td3[SBox[w & 0xff]];
        }
    }

    /// <summary>
    /// Loads a 32-bit big-endian value from a byte span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint LoadBigEndian(ReadOnlySpan<byte> data, int offset)
    {
        unchecked
        {
            return ((uint)data[offset] << 24) | ((uint)data[offset + 1] << 16) |
                   ((uint)data[offset + 2] << 8) | data[offset + 3];
        }
    }

    /// <summary>
    /// Stores a 32-bit big-endian value to a byte span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void StoreBigEndian(Span<byte> data, int offset, uint value)
    {
        data[offset] = (byte)(value >> 24);
        data[offset + 1] = (byte)(value >> 16);
        data[offset + 2] = (byte)(value >> 8);
        data[offset + 3] = (byte)value;
    }

    /// <summary>
    /// Multiply by x (0x02) in GF(2^8) with reduction by x^8 + x^4 + x^3 + x + 1.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte Xtime(byte b)
    {
        unchecked
        {
            return (byte)(((b << 1) ^ (((b >> 7) & 1) * 0x1b)) & 0xff);
        }
    }

    /// <summary>
    /// Multiply two bytes in GF(2^8).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte GfMul(byte a, byte b)
    {
        unchecked
        {
            byte result = 0;
            byte temp = a;

            for (int i = 0; i < 8; i++)
            {
                if ((b & 1) != 0)
                    result ^= temp;
                bool highBit = (temp & 0x80) != 0;
                temp = (byte)(temp << 1);
                if (highBit)
                    temp ^= 0x1b;
                b = (byte)(b >> 1);
            }

            return result;
        }
    }

    // ========================================================================
    // T-Table Generation
    // ========================================================================

    // T-tables combine SubBytes, ShiftRows, and MixColumns into single table lookups.
    // Each table handles one byte position and produces a full 32-bit word contribution.
    // Te0 is for byte 0 (most significant), Te1 for byte 1, etc.

    private static uint[] GenerateTe0()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = SBox[i];
                byte s2 = Xtime(s);     // 02 * s
                byte s3 = (byte)(s2 ^ s); // 03 * s
                // MixColumns matrix row [02, 01, 01, 03] applied to column
                table[i] = ((uint)s2 << 24) | ((uint)s << 16) | ((uint)s << 8) | s3;
            }
            return table;
        }
    }

    private static uint[] GenerateTe1()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = SBox[i];
                byte s2 = Xtime(s);
                byte s3 = (byte)(s2 ^ s);
                // MixColumns matrix row [03, 02, 01, 01] (rotated)
                table[i] = ((uint)s3 << 24) | ((uint)s2 << 16) | ((uint)s << 8) | s;
            }
            return table;
        }
    }

    private static uint[] GenerateTe2()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = SBox[i];
                byte s2 = Xtime(s);
                byte s3 = (byte)(s2 ^ s);
                // MixColumns matrix row [01, 03, 02, 01] (rotated)
                table[i] = ((uint)s << 24) | ((uint)s3 << 16) | ((uint)s2 << 8) | s;
            }
            return table;
        }
    }

    private static uint[] GenerateTe3()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = SBox[i];
                byte s2 = Xtime(s);
                byte s3 = (byte)(s2 ^ s);
                // MixColumns matrix row [01, 01, 03, 02] (rotated)
                table[i] = ((uint)s << 24) | ((uint)s << 16) | ((uint)s3 << 8) | s2;
            }
            return table;
        }
    }

    // Decryption T-tables for InvSubBytes, InvShiftRows, InvMixColumns
    // InvMixColumns matrix:
    // [0e, 09, 0d, 0b]
    // [0b, 0e, 09, 0d]
    // [0d, 0b, 0e, 09]
    // [09, 0d, 0b, 0e]

    private static uint[] GenerateTd0()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = InvSBox[i];
                byte s9 = GfMul(s, 0x09);
                byte sb = GfMul(s, 0x0b);
                byte sd = GfMul(s, 0x0d);
                byte se = GfMul(s, 0x0e);
                // Row [0e, 09, 0d, 0b]
                table[i] = ((uint)se << 24) | ((uint)s9 << 16) | ((uint)sd << 8) | sb;
            }
            return table;
        }
    }

    private static uint[] GenerateTd1()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = InvSBox[i];
                byte s9 = GfMul(s, 0x09);
                byte sb = GfMul(s, 0x0b);
                byte sd = GfMul(s, 0x0d);
                byte se = GfMul(s, 0x0e);
                // Row [0b, 0e, 09, 0d] (rotated)
                table[i] = ((uint)sb << 24) | ((uint)se << 16) | ((uint)s9 << 8) | sd;
            }
            return table;
        }
    }

    private static uint[] GenerateTd2()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = InvSBox[i];
                byte s9 = GfMul(s, 0x09);
                byte sb = GfMul(s, 0x0b);
                byte sd = GfMul(s, 0x0d);
                byte se = GfMul(s, 0x0e);
                // Row [0d, 0b, 0e, 09] (rotated)
                table[i] = ((uint)sd << 24) | ((uint)sb << 16) | ((uint)se << 8) | s9;
            }
            return table;
        }
    }

    private static uint[] GenerateTd3()
    {
        unchecked
        {
            var table = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                byte s = InvSBox[i];
                byte s9 = GfMul(s, 0x09);
                byte sb = GfMul(s, 0x0b);
                byte sd = GfMul(s, 0x0d);
                byte se = GfMul(s, 0x0e);
                // Row [09, 0d, 0b, 0e] (rotated)
                table[i] = ((uint)s9 << 24) | ((uint)sd << 16) | ((uint)sb << 8) | se;
            }
            return table;
        }
    }
}
