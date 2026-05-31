// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Core Kalyna (DSTU 7624:2014) block cipher operations.
/// </summary>
/// <remarks>
/// Kalyna is the Ukrainian national standard block cipher. This implementation
/// supports 128-bit blocks with 128-bit or 256-bit keys (10 or 14 rounds) and
/// 256-bit blocks with 256-bit or 512-bit keys (14 or 18 rounds).
/// State is stored as a pair of 64-bit words in little-endian byte order,
/// matching the DSTU 7624:2014 specification.
/// </remarks>
[SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "Forward and inverse T-tables share a single initialization loop for efficiency.")]
internal unsafe struct KalynaCore
{
    public const int BlockSizeBytes = 16;
    private const int MaxRoundKeyWords = 152;

    private const int NumWords = 2;

    private fixed ulong _roundKeys[MaxRoundKeyWords];
    private int _rounds;
    private int _blockWords;
    private int _keyWords;

    // S-boxes from DSTU 7624:2014
    private static ReadOnlySpan<byte> S0 =>
    [
        0xA8, 0x43, 0x5F, 0x06, 0x6B, 0x75, 0x6C, 0x59, 0x71, 0xDF, 0x87, 0x95, 0x17, 0xF0, 0xD8, 0x09,
        0x6D, 0xF3, 0x1D, 0xCB, 0xC9, 0x4D, 0x2C, 0xAF, 0x79, 0xE0, 0x97, 0xFD, 0x6F, 0x4B, 0x45, 0x39,
        0x3E, 0xDD, 0xA3, 0x4F, 0xB4, 0xB6, 0x9A, 0x0E, 0x1F, 0xBF, 0x15, 0xE1, 0x49, 0xD2, 0x93, 0xC6,
        0x92, 0x72, 0x9E, 0x61, 0xD1, 0x63, 0xFA, 0xEE, 0xF4, 0x19, 0xD5, 0xAD, 0x58, 0xA4, 0xBB, 0xA1,
        0xDC, 0xF2, 0x83, 0x37, 0x42, 0xE4, 0x7A, 0x32, 0x9C, 0xCC, 0xAB, 0x4A, 0x8F, 0x6E, 0x04, 0x27,
        0x2E, 0xE7, 0xE2, 0x5A, 0x96, 0x16, 0x23, 0x2B, 0xC2, 0x65, 0x66, 0x0F, 0xBC, 0xA9, 0x47, 0x41,
        0x34, 0x48, 0xFC, 0xB7, 0x6A, 0x88, 0xA5, 0x53, 0x86, 0xF9, 0x5B, 0xDB, 0x38, 0x7B, 0xC3, 0x1E,
        0x22, 0x33, 0x24, 0x28, 0x36, 0xC7, 0xB2, 0x3B, 0x8E, 0x77, 0xBA, 0xF5, 0x14, 0x9F, 0x08, 0x55,
        0x9B, 0x4C, 0xFE, 0x60, 0x5C, 0xDA, 0x18, 0x46, 0xCD, 0x7D, 0x21, 0xB0, 0x3F, 0x1B, 0x89, 0xFF,
        0xEB, 0x84, 0x69, 0x3A, 0x9D, 0xD7, 0xD3, 0x70, 0x67, 0x40, 0xB5, 0xDE, 0x5D, 0x30, 0x91, 0xB1,
        0x78, 0x11, 0x01, 0xE5, 0x00, 0x68, 0x98, 0xA0, 0xC5, 0x02, 0xA6, 0x74, 0x2D, 0x0B, 0xA2, 0x76,
        0xB3, 0xBE, 0xCE, 0xBD, 0xAE, 0xE9, 0x8A, 0x31, 0x1C, 0xEC, 0xF1, 0x99, 0x94, 0xAA, 0xF6, 0x26,
        0x2F, 0xEF, 0xE8, 0x8C, 0x35, 0x03, 0xD4, 0x7F, 0xFB, 0x05, 0xC1, 0x5E, 0x90, 0x20, 0x3D, 0x82,
        0xF7, 0xEA, 0x0A, 0x0D, 0x7E, 0xF8, 0x50, 0x1A, 0xC4, 0x07, 0x57, 0xB8, 0x3C, 0x62, 0xE3, 0xC8,
        0xAC, 0x52, 0x64, 0x10, 0xD0, 0xD9, 0x13, 0x0C, 0x12, 0x29, 0x51, 0xB9, 0xCF, 0xD6, 0x73, 0x8D,
        0x81, 0x54, 0xC0, 0xED, 0x4E, 0x44, 0xA7, 0x2A, 0x85, 0x25, 0xE6, 0xCA, 0x7C, 0x8B, 0x56, 0x80
    ];

    private static ReadOnlySpan<byte> S1 =>
    [
        0xCE, 0xBB, 0xEB, 0x92, 0xEA, 0xCB, 0x13, 0xC1, 0xE9, 0x3A, 0xD6, 0xB2, 0xD2, 0x90, 0x17, 0xF8,
        0x42, 0x15, 0x56, 0xB4, 0x65, 0x1C, 0x88, 0x43, 0xC5, 0x5C, 0x36, 0xBA, 0xF5, 0x57, 0x67, 0x8D,
        0x31, 0xF6, 0x64, 0x58, 0x9E, 0xF4, 0x22, 0xAA, 0x75, 0x0F, 0x02, 0xB1, 0xDF, 0x6D, 0x73, 0x4D,
        0x7C, 0x26, 0x2E, 0xF7, 0x08, 0x5D, 0x44, 0x3E, 0x9F, 0x14, 0xC8, 0xAE, 0x54, 0x10, 0xD8, 0xBC,
        0x1A, 0x6B, 0x69, 0xF3, 0xBD, 0x33, 0xAB, 0xFA, 0xD1, 0x9B, 0x68, 0x4E, 0x16, 0x95, 0x91, 0xEE,
        0x4C, 0x63, 0x8E, 0x5B, 0xCC, 0x3C, 0x19, 0xA1, 0x81, 0x49, 0x7B, 0xD9, 0x6F, 0x37, 0x60, 0xCA,
        0xE7, 0x2B, 0x48, 0xFD, 0x96, 0x45, 0xFC, 0x41, 0x12, 0x0D, 0x79, 0xE5, 0x89, 0x8C, 0xE3, 0x20,
        0x30, 0xDC, 0xB7, 0x6C, 0x4A, 0xB5, 0x3F, 0x97, 0xD4, 0x62, 0x2D, 0x06, 0xA4, 0xA5, 0x83, 0x5F,
        0x2A, 0xDA, 0xC9, 0x00, 0x7E, 0xA2, 0x55, 0xBF, 0x11, 0xD5, 0x9C, 0xCF, 0x0E, 0x0A, 0x3D, 0x51,
        0x7D, 0x93, 0x1B, 0xFE, 0xC4, 0x47, 0x09, 0x86, 0x0B, 0x8F, 0x9D, 0x6A, 0x07, 0xB9, 0xB0, 0x98,
        0x18, 0x32, 0x71, 0x4B, 0xEF, 0x3B, 0x70, 0xA0, 0xE4, 0x40, 0xFF, 0xC3, 0xA9, 0xE6, 0x78, 0xF9,
        0x8B, 0x46, 0x80, 0x1E, 0x38, 0xE1, 0xB8, 0xA8, 0xE0, 0x0C, 0x23, 0x76, 0x1D, 0x25, 0x24, 0x05,
        0xF1, 0x6E, 0x94, 0x28, 0x9A, 0x84, 0xE8, 0xA3, 0x4F, 0x77, 0xD3, 0x85, 0xE2, 0x52, 0xF2, 0x82,
        0x50, 0x7A, 0x2F, 0x74, 0x53, 0xB3, 0x61, 0xAF, 0x39, 0x35, 0xDE, 0xCD, 0x1F, 0x99, 0xAC, 0xAD,
        0x72, 0x2C, 0xDD, 0xD0, 0x87, 0xBE, 0x5E, 0xA6, 0xEC, 0x04, 0xC6, 0x03, 0x34, 0xFB, 0xDB, 0x59,
        0xB6, 0xC2, 0x01, 0xF0, 0x5A, 0xED, 0xA7, 0x66, 0x21, 0x7F, 0x8A, 0x27, 0xC7, 0xC0, 0x29, 0xD7
    ];

    private static ReadOnlySpan<byte> S2 =>
    [
        0x93, 0xD9, 0x9A, 0xB5, 0x98, 0x22, 0x45, 0xFC, 0xBA, 0x6A, 0xDF, 0x02, 0x9F, 0xDC, 0x51, 0x59,
        0x4A, 0x17, 0x2B, 0xC2, 0x94, 0xF4, 0xBB, 0xA3, 0x62, 0xE4, 0x71, 0xD4, 0xCD, 0x70, 0x16, 0xE1,
        0x49, 0x3C, 0xC0, 0xD8, 0x5C, 0x9B, 0xAD, 0x85, 0x53, 0xA1, 0x7A, 0xC8, 0x2D, 0xE0, 0xD1, 0x72,
        0xA6, 0x2C, 0xC4, 0xE3, 0x76, 0x78, 0xB7, 0xB4, 0x09, 0x3B, 0x0E, 0x41, 0x4C, 0xDE, 0xB2, 0x90,
        0x25, 0xA5, 0xD7, 0x03, 0x11, 0x00, 0xC3, 0x2E, 0x92, 0xEF, 0x4E, 0x12, 0x9D, 0x7D, 0xCB, 0x35,
        0x10, 0xD5, 0x4F, 0x9E, 0x4D, 0xA9, 0x55, 0xC6, 0xD0, 0x7B, 0x18, 0x97, 0xD3, 0x36, 0xE6, 0x48,
        0x56, 0x81, 0x8F, 0x77, 0xCC, 0x9C, 0xB9, 0xE2, 0xAC, 0xB8, 0x2F, 0x15, 0xA4, 0x7C, 0xDA, 0x38,
        0x1E, 0x0B, 0x05, 0xD6, 0x14, 0x6E, 0x6C, 0x7E, 0x66, 0xFD, 0xB1, 0xE5, 0x60, 0xAF, 0x5E, 0x33,
        0x87, 0xC9, 0xF0, 0x5D, 0x6D, 0x3F, 0x88, 0x8D, 0xC7, 0xF7, 0x1D, 0xE9, 0xEC, 0xED, 0x80, 0x29,
        0x27, 0xCF, 0x99, 0xA8, 0x50, 0x0F, 0x37, 0x24, 0x28, 0x30, 0x95, 0xD2, 0x3E, 0x5B, 0x40, 0x83,
        0xB3, 0x69, 0x57, 0x1F, 0x07, 0x1C, 0x8A, 0xBC, 0x20, 0xEB, 0xCE, 0x8E, 0xAB, 0xEE, 0x31, 0xA2,
        0x73, 0xF9, 0xCA, 0x3A, 0x1A, 0xFB, 0x0D, 0xC1, 0xFE, 0xFA, 0xF2, 0x6F, 0xBD, 0x96, 0xDD, 0x43,
        0x52, 0xB6, 0x08, 0xF3, 0xAE, 0xBE, 0x19, 0x89, 0x32, 0x26, 0xB0, 0xEA, 0x4B, 0x64, 0x84, 0x82,
        0x6B, 0xF5, 0x79, 0xBF, 0x01, 0x5F, 0x75, 0x63, 0x1B, 0x23, 0x3D, 0x68, 0x2A, 0x65, 0xE8, 0x91,
        0xF6, 0xFF, 0x13, 0x58, 0xF1, 0x47, 0x0A, 0x7F, 0xC5, 0xA7, 0xE7, 0x61, 0x5A, 0x06, 0x46, 0x44,
        0x42, 0x04, 0xA0, 0xDB, 0x39, 0x86, 0x54, 0xAA, 0x8C, 0x34, 0x21, 0x8B, 0xF8, 0x0C, 0x74, 0x67
    ];

    private static ReadOnlySpan<byte> S3 =>
    [
        0x68, 0x8D, 0xCA, 0x4D, 0x73, 0x4B, 0x4E, 0x2A, 0xD4, 0x52, 0x26, 0xB3, 0x54, 0x1E, 0x19, 0x1F,
        0x22, 0x03, 0x46, 0x3D, 0x2D, 0x4A, 0x53, 0x83, 0x13, 0x8A, 0xB7, 0xD5, 0x25, 0x79, 0xF5, 0xBD,
        0x58, 0x2F, 0x0D, 0x02, 0xED, 0x51, 0x9E, 0x11, 0xF2, 0x3E, 0x55, 0x5E, 0xD1, 0x16, 0x3C, 0x66,
        0x70, 0x5D, 0xF3, 0x45, 0x40, 0xCC, 0xE8, 0x94, 0x56, 0x08, 0xCE, 0x1A, 0x3A, 0xD2, 0xE1, 0xDF,
        0xB5, 0x38, 0x6E, 0x0E, 0xE5, 0xF4, 0xF9, 0x86, 0xE9, 0x4F, 0xD6, 0x85, 0x23, 0xCF, 0x32, 0x99,
        0x31, 0x14, 0xAE, 0xEE, 0xC8, 0x48, 0xD3, 0x30, 0xA1, 0x92, 0x41, 0xB1, 0x18, 0xC4, 0x2C, 0x71,
        0x72, 0x44, 0x15, 0xFD, 0x37, 0xBE, 0x5F, 0xAA, 0x9B, 0x88, 0xD8, 0xAB, 0x89, 0x9C, 0xFA, 0x60,
        0xEA, 0xBC, 0x62, 0x0C, 0x24, 0xA6, 0xA8, 0xEC, 0x67, 0x20, 0xDB, 0x7C, 0x28, 0xDD, 0xAC, 0x5B,
        0x34, 0x7E, 0x10, 0xF1, 0x7B, 0x8F, 0x63, 0xA0, 0x05, 0x9A, 0x43, 0x77, 0x21, 0xBF, 0x27, 0x09,
        0xC3, 0x9F, 0xB6, 0xD7, 0x29, 0xC2, 0xEB, 0xC0, 0xA4, 0x8B, 0x8C, 0x1D, 0xFB, 0xFF, 0xC1, 0xB2,
        0x97, 0x2E, 0xF8, 0x65, 0xF6, 0x75, 0x07, 0x04, 0x49, 0x33, 0xE4, 0xD9, 0xB9, 0xD0, 0x42, 0xC7,
        0x6C, 0x90, 0x00, 0x8E, 0x6F, 0x50, 0x01, 0xC5, 0xDA, 0x47, 0x3F, 0xCD, 0x69, 0xA2, 0xE2, 0x7A,
        0xA7, 0xC6, 0x93, 0x0F, 0x0A, 0x06, 0xE6, 0x2B, 0x96, 0xA3, 0x1C, 0xAF, 0x6A, 0x12, 0x84, 0x39,
        0xE7, 0xB0, 0x82, 0xF7, 0xFE, 0x9D, 0x87, 0x5C, 0x81, 0x35, 0xDE, 0xB4, 0xA5, 0xFC, 0x80, 0xEF,
        0xCB, 0xBB, 0x6B, 0x76, 0xBA, 0x5A, 0x7D, 0x78, 0x0B, 0x95, 0xE3, 0xAD, 0x74, 0x98, 0x3B, 0x36,
        0x64, 0x6D, 0xDC, 0xF0, 0x59, 0xA9, 0x4C, 0x17, 0x7F, 0x91, 0xB8, 0xC9, 0x57, 0x1B, 0xE0, 0x61
    ];

    // Inverse S-boxes (IS_i[y] = x such that S_i[x] = y)
    private static readonly byte[] IS0 = ComputeInverse(S0);
    private static readonly byte[] IS1 = ComputeInverse(S1);
    private static readonly byte[] IS2 = ComputeInverse(S2);
    private static readonly byte[] IS3 = ComputeInverse(S3);

    // Forward T-tables: TF_c[x] encodes all 8 MDS output bytes when input byte at column
    // position c equals x. Byte r of TF_c[x] = GfMul(base[(c-r+8)%8], S[c%4][x]).
    // Combines SubBytes + ShiftRows + MixColumns in a single 8-byte lookup per input byte.
    // base = [01, 01, 05, 01, 08, 06, 07, 04] (forward MDS circulant row)
    private static readonly ulong[] TF0 = new ulong[256];
    private static readonly ulong[] TF1 = new ulong[256];
    private static readonly ulong[] TF2 = new ulong[256];
    private static readonly ulong[] TF3 = new ulong[256];
    private static readonly ulong[] TF4 = new ulong[256];
    private static readonly ulong[] TF5 = new ulong[256];
    private static readonly ulong[] TF6 = new ulong[256];
    private static readonly ulong[] TF7 = new ulong[256];

    // Inverse T-tables (partial): TI_c[x] encodes all 8 inverse-MDS output bytes without
    // folding in InvSubBytes (IS0[0] ≠ 0 breaks superposition after the linear layer).
    // Byte r of TI_c[x] = GfMul(invBase[(c-r+8)%8], x). InvShiftRows and InvSubBytes
    // are applied separately in DecryptBlock.
    // invBase = [AD, 95, 76, A8, 2F, 49, D7, CA] (inverse MDS circulant row)
    private static readonly ulong[] TI0 = new ulong[256];
    private static readonly ulong[] TI1 = new ulong[256];
    private static readonly ulong[] TI2 = new ulong[256];
    private static readonly ulong[] TI3 = new ulong[256];
    private static readonly ulong[] TI4 = new ulong[256];
    private static readonly ulong[] TI5 = new ulong[256];
    private static readonly ulong[] TI6 = new ulong[256];
    private static readonly ulong[] TI7 = new ulong[256];

    // Precomputed GF(2^8) multiplication tables for forward MDS constants (used in key expansion)
    private static readonly byte[] Gf04 = ComputeGfMulTable(0x04);
    private static readonly byte[] Gf05 = ComputeGfMulTable(0x05);
    private static readonly byte[] Gf06 = ComputeGfMulTable(0x06);
    private static readonly byte[] Gf07 = ComputeGfMulTable(0x07);
    private static readonly byte[] Gf08 = ComputeGfMulTable(0x08);

    static KalynaCore()
    {
        // Forward MDS circulant base row: [01, 01, 05, 01, 08, 06, 07, 04]
        // Column position c uses S-box S[c%4]: S0, S1, S2, S3, S0, S1, S2, S3.
        ReadOnlySpan<byte> fwdBase = [0x01, 0x01, 0x05, 0x01, 0x08, 0x06, 0x07, 0x04];
        ulong[][] tf = [TF0, TF1, TF2, TF3, TF4, TF5, TF6, TF7];
        for (int c = 0; c < 8; c++)
        {
            ulong[] table = tf[c];
            for (int x = 0; x < 256; x++)
            {
                byte sx = (c & 3) switch { 0 => S0[x], 1 => S1[x], 2 => S2[x], _ => S3[x] };
                ulong entry = 0;
                for (int r = 0; r < 8; r++)
                {
                    entry |= (ulong)GfMul(fwdBase[(c - r + 8) & 7], sx) << (r * 8);
                }

                table[x] = entry;
            }
        }

        // Inverse MDS circulant base row: [AD, 95, 76, A8, 2F, 49, D7, CA]
        // No S-box applied — InvSubBytes is handled separately in DecryptBlock.
        ReadOnlySpan<byte> invBase = [0xAD, 0x95, 0x76, 0xA8, 0x2F, 0x49, 0xD7, 0xCA];
        ulong[][] ti = [TI0, TI1, TI2, TI3, TI4, TI5, TI6, TI7];
        for (int c = 0; c < 8; c++)
        {
            ulong[] table = ti[c];
            for (int x = 0; x < 256; x++)
            {
                ulong entry = 0;
                for (int r = 0; r < 8; r++)
                {
                    entry |= (ulong)GfMul(invBase[(c - r + 8) & 7], (byte)x) << (r * 8);
                }

                table[x] = entry;
            }
        }
    }

    /// <summary>
    /// Creates and initializes a new <see cref="KalynaCore"/> with expanded round keys.
    /// </summary>
    /// <param name="key">The cipher key.</param>
    /// <param name="blockSizeBytes">The block size in bytes.</param>
    /// <returns>An initialized <see cref="KalynaCore"/> ready for use.</returns>
    /// <exception cref="ArgumentException">Thrown when the key length is invalid.</exception>
    internal static KalynaCore Create(ReadOnlySpan<byte> key, int blockSizeBytes)
    {
        int blockWords = blockSizeBytes / 8;
        int keyWords = key.Length / 8;

        KalynaCore core = default;
        core._blockWords = blockWords;
        core._keyWords = keyWords;

        int nr;
        if (blockWords == 2)
        {
            Span<byte> rkBytes = stackalloc byte[15 * 16];
            nr = ExpandKey(key, rkBytes);

            core._rounds = nr;

            KalynaCore* pCore128 = &core;
            ulong* rk128 = pCore128->_roundKeys;
            for (int i = 0; i <= nr; i++)
            {
                rk128[i * 2] = BinaryPrimitives.ReadUInt64LittleEndian(rkBytes.Slice(i * 16));
                rk128[i * 2 + 1] = BinaryPrimitives.ReadUInt64LittleEndian(rkBytes.Slice(i * 16 + 8));
            }

            return core;
        }

        Span<ulong> roundKeyWords = stackalloc ulong[MaxRoundKeyWords];
        nr = ExpandKeyGeneric(key, blockWords, roundKeyWords);
        core._rounds = nr;

        KalynaCore* pCoreGeneric = &core;
        ulong* rkGeneric = pCoreGeneric->_roundKeys;
        int roundKeyWordsCount = (nr + 1) * blockWords;
        for (int i = 0; i < roundKeyWordsCount; i++)
        {
            rkGeneric[i] = roundKeyWords[i];
        }

        return core;
    }

    /// <summary>
    /// Encrypts a single Kalyna block.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_blockWords != 2)
        {
            EncryptBlockGeneric(input, output);
            return;
        }

        ulong w0 = BinaryPrimitives.ReadUInt64LittleEndian(input);
        ulong w1 = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(8));
        EncryptBlock(ref w0, ref w1);
        BinaryPrimitives.WriteUInt64LittleEndian(output, w0);
        BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(8), w1);
    }

    /// <summary>
    /// Encrypts a block given as a ulong pair (little-endian), updating the values in-place.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal void EncryptBlock(ref ulong w0, ref ulong w1)
    {
        fixed (KalynaCore* pCore = &this)
        {
            ulong* rk = pCore->_roundKeys;
            int nr = _rounds;

#if NET5_0_OR_GREATER
            ref ulong rf0 = ref MemoryMarshal.GetArrayDataReference(TF0);
            ref ulong rf1 = ref MemoryMarshal.GetArrayDataReference(TF1);
            ref ulong rf2 = ref MemoryMarshal.GetArrayDataReference(TF2);
            ref ulong rf3 = ref MemoryMarshal.GetArrayDataReference(TF3);
            ref ulong rf4 = ref MemoryMarshal.GetArrayDataReference(TF4);
            ref ulong rf5 = ref MemoryMarshal.GetArrayDataReference(TF5);
            ref ulong rf6 = ref MemoryMarshal.GetArrayDataReference(TF6);
            ref ulong rf7 = ref MemoryMarshal.GetArrayDataReference(TF7);
#else
            ref ulong rf0 = ref MemoryMarshal.GetReference(TF0);
            ref ulong rf1 = ref MemoryMarshal.GetReference(TF1);
            ref ulong rf2 = ref MemoryMarshal.GetReference(TF2);
            ref ulong rf3 = ref MemoryMarshal.GetReference(TF3);
            ref ulong rf4 = ref MemoryMarshal.GetReference(TF4);
            ref ulong rf5 = ref MemoryMarshal.GetReference(TF5);
            ref ulong rf6 = ref MemoryMarshal.GetReference(TF6);
            ref ulong rf7 = ref MemoryMarshal.GetReference(TF7);
#endif

            // Pre-whitening: modular addition with round key 0
            ulong s0 = w0 + rk[0];
            ulong s1 = w1 + rk[1];

            for (int r = 1; r < nr; r++)
            {
                ulong n0 = Unsafe.Add(ref rf0, (byte)s0)
                         ^ Unsafe.Add(ref rf1, (byte)(s0 >> 8))
                         ^ Unsafe.Add(ref rf2, (byte)(s0 >> 16))
                         ^ Unsafe.Add(ref rf3, (byte)(s0 >> 24))
                         ^ Unsafe.Add(ref rf4, (byte)(s1 >> 32))
                         ^ Unsafe.Add(ref rf5, (byte)(s1 >> 40))
                         ^ Unsafe.Add(ref rf6, (byte)(s1 >> 48))
                         ^ Unsafe.Add(ref rf7, (byte)(s1 >> 56));
                ulong n1 = Unsafe.Add(ref rf0, (byte)s1)
                         ^ Unsafe.Add(ref rf1, (byte)(s1 >> 8))
                         ^ Unsafe.Add(ref rf2, (byte)(s1 >> 16))
                         ^ Unsafe.Add(ref rf3, (byte)(s1 >> 24))
                         ^ Unsafe.Add(ref rf4, (byte)(s0 >> 32))
                         ^ Unsafe.Add(ref rf5, (byte)(s0 >> 40))
                         ^ Unsafe.Add(ref rf6, (byte)(s0 >> 48))
                         ^ Unsafe.Add(ref rf7, (byte)(s0 >> 56));
                s0 = n0 ^ rk[r * 2];
                s1 = n1 ^ rk[r * 2 + 1];
            }

            // Last round: T-table then post-whitening with modular addition
            ulong m0 = Unsafe.Add(ref rf0, (byte)s0)
                     ^ Unsafe.Add(ref rf1, (byte)(s0 >> 8))
                     ^ Unsafe.Add(ref rf2, (byte)(s0 >> 16))
                     ^ Unsafe.Add(ref rf3, (byte)(s0 >> 24))
                     ^ Unsafe.Add(ref rf4, (byte)(s1 >> 32))
                     ^ Unsafe.Add(ref rf5, (byte)(s1 >> 40))
                     ^ Unsafe.Add(ref rf6, (byte)(s1 >> 48))
                     ^ Unsafe.Add(ref rf7, (byte)(s1 >> 56));
            ulong m1 = Unsafe.Add(ref rf0, (byte)s1)
                     ^ Unsafe.Add(ref rf1, (byte)(s1 >> 8))
                     ^ Unsafe.Add(ref rf2, (byte)(s1 >> 16))
                     ^ Unsafe.Add(ref rf3, (byte)(s1 >> 24))
                     ^ Unsafe.Add(ref rf4, (byte)(s0 >> 32))
                     ^ Unsafe.Add(ref rf5, (byte)(s0 >> 40))
                     ^ Unsafe.Add(ref rf6, (byte)(s0 >> 48))
                     ^ Unsafe.Add(ref rf7, (byte)(s0 >> 56));
            w0 = m0 + rk[nr * 2];
            w1 = m1 + rk[nr * 2 + 1];
        }
    }

    /// <summary>
    /// Decrypts a single Kalyna block.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_blockWords != 2)
        {
            DecryptBlockGeneric(input, output);
            return;
        }

        ulong w0 = BinaryPrimitives.ReadUInt64LittleEndian(input);
        ulong w1 = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(8));
        DecryptBlock(ref w0, ref w1);
        BinaryPrimitives.WriteUInt64LittleEndian(output, w0);
        BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(8), w1);
    }

    /// <summary>
    /// Decrypts a block given as a ulong pair (little-endian), updating the values in-place.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The full inverse round is: XorKey → InvMixColumns → InvShiftRows → InvSubBytes.
    /// InvSubBytes cannot be folded into the InvMixColumns T-tables because IS0(0) ≠ 0,
    /// so contributions do not superpose linearly after InvMixColumns. The partial TI tables
    /// handle only InvMixColumns; InvShiftRows and InvSubBytes are applied separately.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal void DecryptBlock(ref ulong w0, ref ulong w1)
    {
        fixed (KalynaCore* pCore = &this)
        {
            ulong* rk = pCore->_roundKeys;
            int nr = _rounds;

#if NET5_0_OR_GREATER
            ref ulong ri0 = ref MemoryMarshal.GetArrayDataReference(TI0);
            ref ulong ri1 = ref MemoryMarshal.GetArrayDataReference(TI1);
            ref ulong ri2 = ref MemoryMarshal.GetArrayDataReference(TI2);
            ref ulong ri3 = ref MemoryMarshal.GetArrayDataReference(TI3);
            ref ulong ri4 = ref MemoryMarshal.GetArrayDataReference(TI4);
            ref ulong ri5 = ref MemoryMarshal.GetArrayDataReference(TI5);
            ref ulong ri6 = ref MemoryMarshal.GetArrayDataReference(TI6);
            ref ulong ri7 = ref MemoryMarshal.GetArrayDataReference(TI7);

            ref byte pIs0 = ref MemoryMarshal.GetArrayDataReference(IS0);
            ref byte pIs1 = ref MemoryMarshal.GetArrayDataReference(IS1);
            ref byte pIs2 = ref MemoryMarshal.GetArrayDataReference(IS2);
            ref byte pIs3 = ref MemoryMarshal.GetArrayDataReference(IS3);
#else
            ref ulong ri0 = ref MemoryMarshal.GetReference(TI0);
            ref ulong ri1 = ref MemoryMarshal.GetReference(TI1);
            ref ulong ri2 = ref MemoryMarshal.GetReference(TI2);
            ref ulong ri3 = ref MemoryMarshal.GetReference(TI3);
            ref ulong ri4 = ref MemoryMarshal.GetReference(TI4);
            ref ulong ri5 = ref MemoryMarshal.GetReference(TI5);
            ref ulong ri6 = ref MemoryMarshal.GetReference(TI6);
            ref ulong ri7 = ref MemoryMarshal.GetReference(TI7);

            ref byte pIs0 = ref MemoryMarshal.GetReference(IS0);
            ref byte pIs1 = ref MemoryMarshal.GetReference(IS1);
            ref byte pIs2 = ref MemoryMarshal.GetReference(IS2);
            ref byte pIs3 = ref MemoryMarshal.GetReference(IS3);
#endif
            // Pre-whitening: modular subtraction with round key nr
            ulong s0 = w0 - rk[nr * 2];
            ulong s1 = w1 - rk[nr * 2 + 1];

            // First round: InvMixColumns + InvShiftRows + InvSubBytes (no XOR key)
            {
                ulong imc0 = Unsafe.Add(ref ri0, (byte)s0) ^ Unsafe.Add(ref ri1, (byte)(s0 >> 8))
                           ^ Unsafe.Add(ref ri2, (byte)(s0 >> 16)) ^ Unsafe.Add(ref ri3, (byte)(s0 >> 24))
                           ^ Unsafe.Add(ref ri4, (byte)(s0 >> 32)) ^ Unsafe.Add(ref ri5, (byte)(s0 >> 40))
                           ^ Unsafe.Add(ref ri6, (byte)(s0 >> 48)) ^ Unsafe.Add(ref ri7, (byte)(s0 >> 56));
                ulong imc1 = Unsafe.Add(ref ri0, (byte)s1) ^ Unsafe.Add(ref ri1, (byte)(s1 >> 8))
                           ^ Unsafe.Add(ref ri2, (byte)(s1 >> 16)) ^ Unsafe.Add(ref ri3, (byte)(s1 >> 24))
                           ^ Unsafe.Add(ref ri4, (byte)(s1 >> 32)) ^ Unsafe.Add(ref ri5, (byte)(s1 >> 40))
                           ^ Unsafe.Add(ref ri6, (byte)(s1 >> 48)) ^ Unsafe.Add(ref ri7, (byte)(s1 >> 56));
                // InvShiftRows: swap bits 32-63 (rows 4-7) between columns
                ulong isr0 = (imc0 & 0x00000000_FFFFFFFFul) | (imc1 & 0xFFFFFFFF_00000000ul);
                ulong isr1 = (imc1 & 0x00000000_FFFFFFFFul) | (imc0 & 0xFFFFFFFF_00000000ul);
                // InvSubBytes: IS0/IS1/IS2/IS3 cycle per byte (rows 0,4 → IS0; 1,5 → IS1; 2,6 → IS2; 3,7 → IS3)
                s0 = (ulong)Unsafe.Add(ref pIs0, (byte)isr0)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr0 >> 8)) << 8)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr0 >> 16)) << 16)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr0 >> 24)) << 24)
                   | ((ulong)Unsafe.Add(ref pIs0, (byte)(isr0 >> 32)) << 32)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr0 >> 40)) << 40)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr0 >> 48)) << 48)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr0 >> 56)) << 56);
                s1 = (ulong)Unsafe.Add(ref pIs0, (byte)isr1)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr1 >> 8)) << 8)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr1 >> 16)) << 16)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr1 >> 24)) << 24)
                   | ((ulong)Unsafe.Add(ref pIs0, (byte)(isr1 >> 32)) << 32)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr1 >> 40)) << 40)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr1 >> 48)) << 48)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr1 >> 56)) << 56);
            }

            // Remaining rounds: XOR key, then InvMixColumns + InvShiftRows + InvSubBytes
            for (int r = nr - 1; r > 0; r--)
            {
                s0 ^= rk[r * 2];
                s1 ^= rk[r * 2 + 1];
                ulong imc0 = Unsafe.Add(ref ri0, (byte)s0) ^ Unsafe.Add(ref ri1, (byte)(s0 >> 8))
                           ^ Unsafe.Add(ref ri2, (byte)(s0 >> 16)) ^ Unsafe.Add(ref ri3, (byte)(s0 >> 24))
                           ^ Unsafe.Add(ref ri4, (byte)(s0 >> 32)) ^ Unsafe.Add(ref ri5, (byte)(s0 >> 40))
                           ^ Unsafe.Add(ref ri6, (byte)(s0 >> 48)) ^ Unsafe.Add(ref ri7, (byte)(s0 >> 56));
                ulong imc1 = Unsafe.Add(ref ri0, (byte)s1) ^ Unsafe.Add(ref ri1, (byte)(s1 >> 8))
                           ^ Unsafe.Add(ref ri2, (byte)(s1 >> 16)) ^ Unsafe.Add(ref ri3, (byte)(s1 >> 24))
                           ^ Unsafe.Add(ref ri4, (byte)(s1 >> 32)) ^ Unsafe.Add(ref ri5, (byte)(s1 >> 40))
                           ^ Unsafe.Add(ref ri6, (byte)(s1 >> 48)) ^ Unsafe.Add(ref ri7, (byte)(s1 >> 56));
                ulong isr0 = (imc0 & 0x00000000_FFFFFFFFul) | (imc1 & 0xFFFFFFFF_00000000ul);
                ulong isr1 = (imc1 & 0x00000000_FFFFFFFFul) | (imc0 & 0xFFFFFFFF_00000000ul);
                s0 = (ulong)Unsafe.Add(ref pIs0, (byte)isr0)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr0 >> 8)) << 8)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr0 >> 16)) << 16)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr0 >> 24)) << 24)
                   | ((ulong)Unsafe.Add(ref pIs0, (byte)(isr0 >> 32)) << 32)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr0 >> 40)) << 40)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr0 >> 48)) << 48)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr0 >> 56)) << 56);
                s1 = (ulong)Unsafe.Add(ref pIs0, (byte)isr1)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr1 >> 8)) << 8)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr1 >> 16)) << 16)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr1 >> 24)) << 24)
                   | ((ulong)Unsafe.Add(ref pIs0, (byte)(isr1 >> 32)) << 32)
                   | ((ulong)Unsafe.Add(ref pIs1, (byte)(isr1 >> 40)) << 40)
                   | ((ulong)Unsafe.Add(ref pIs2, (byte)(isr1 >> 48)) << 48)
                   | ((ulong)Unsafe.Add(ref pIs3, (byte)(isr1 >> 56)) << 56);
            }

            // Post-whitening: modular subtraction with round key 0
            w0 = s0 - rk[0];
            w1 = s1 - rk[1];
        }
    }

    private void EncryptBlockGeneric(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<ulong> state = stackalloc ulong[MaxRoundKeyWords / 19];
        Span<ulong> blockState = state.Slice(0, _blockWords);

        for (int i = 0; i < _blockWords; i++)
        {
            blockState[i] = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(i * 8));
        }

        fixed (KalynaCore* pCore = &this)
        {
            ulong* rk = pCore->_roundKeys;
            AddRoundKey(blockState, rk, 0);

            for (int round = 0;;)
            {
                SubBytes(blockState);
                ShiftRows(blockState);
                MixColumns(blockState);

                if (++round == _rounds)
                {
                    break;
                }

                XorRoundKey(blockState, rk, round);
            }

            AddRoundKey(blockState, rk, _rounds);
        }

        for (int i = 0; i < _blockWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(i * 8), blockState[i]);
        }
    }

    private void DecryptBlockGeneric(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<ulong> state = stackalloc ulong[MaxRoundKeyWords / 19];
        Span<ulong> blockState = state.Slice(0, _blockWords);

        for (int i = 0; i < _blockWords; i++)
        {
            blockState[i] = BinaryPrimitives.ReadUInt64LittleEndian(input.Slice(i * 8));
        }

        fixed (KalynaCore* pCore = &this)
        {
            ulong* rk = pCore->_roundKeys;
            SubRoundKey(blockState, rk, _rounds);

            for (int round = _rounds;;)
            {
                MixColumnsInv(blockState);
                InvShiftRows(blockState);
                InvSubBytes(blockState);

                if (--round == 0)
                {
                    break;
                }

                XorRoundKey(blockState, rk, round);
            }

            SubRoundKey(blockState, rk, 0);
        }

        for (int i = 0; i < _blockWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(i * 8), blockState[i]);
        }
    }

    private static int ExpandKey(ReadOnlySpan<byte> key, Span<byte> roundKeys)
    {
        int nr = key.Length switch {
            16 => 10,
            32 => 14,
            _ => throw new ArgumentException("Key must be 16 or 32 bytes for 128-bit block.", nameof(key))
        };

        // Generate intermediate key Kt
        Span<byte> kt = stackalloc byte[16];
        KeyExpandKt(key, kt);

        // Generate round keys
        if (key.Length == 16)
        {
            KeyExpandEvenOdd128(key, kt, roundKeys, nr);
        }
        else
        {
            KeyExpandEvenOdd256(key, kt, roundKeys, nr);
        }

        return nr;
    }

    private static int ExpandKeyGeneric(ReadOnlySpan<byte> key, int blockWords, Span<ulong> roundKeys)
    {
        int keyWords = key.Length / 8;
        int nr = key.Length switch
        {
            32 => 14,
            64 => 18,
            _ => throw new ArgumentException("Key must be 32 or 64 bytes for the selected Kalyna block size.", nameof(key))
        };

        if (blockWords != 4 && blockWords != 8)
            throw new ArgumentException("Block size must be 256 or 512 bits for the Kalyna-512 family.", nameof(blockWords));

        if (keyWords != blockWords && keyWords != blockWords * 2)
            throw new ArgumentException("Unsupported key length for the selected Kalyna block size.", nameof(key));

        Span<ulong> workingKey = stackalloc ulong[keyWords];
        for (int i = 0; i < keyWords; i++)
        {
            workingKey[i] = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(i * 8));
        }

        Span<ulong> tempKeys = stackalloc ulong[8];
        WorkingKeyExpandKt(workingKey, blockWords, keyWords, tempKeys);
        WorkingKeyExpandEven(workingKey, blockWords, keyWords, tempKeys, roundKeys, nr);
        WorkingKeyExpandOdd(roundKeys, blockWords, nr);

        return nr;
    }

    private static void WorkingKeyExpandKt(ReadOnlySpan<ulong> workingKey, int blockWords, int keyWords, Span<ulong> tempKeys)
    {
        Span<ulong> state = stackalloc ulong[8];
        state.Clear();
        Span<ulong> k0 = stackalloc ulong[8];
        Span<ulong> k1 = stackalloc ulong[8];
        Span<ulong> blockState = state.Slice(0, blockWords);

        state[0] = (ulong)(blockWords + keyWords + 1);

        if (keyWords == blockWords)
        {
            workingKey.Slice(0, blockWords).CopyTo(k0);
            workingKey.Slice(0, blockWords).CopyTo(k1);
        }
        else
        {
            workingKey.Slice(0, blockWords).CopyTo(k0);
            workingKey.Slice(blockWords, blockWords).CopyTo(k1);
        }

        for (int i = 0; i < blockWords; i++)
        {
            blockState[i] += k0[i];
        }

        SubBytes(blockState);
        ShiftRows(blockState);
        MixColumns(blockState);

        for (int i = 0; i < blockWords; i++)
        {
            blockState[i] ^= k1[i];
        }

        SubBytes(blockState);
        ShiftRows(blockState);
        MixColumns(blockState);

        for (int i = 0; i < blockWords; i++)
        {
            blockState[i] += k0[i];
        }

        SubBytes(blockState);
        ShiftRows(blockState);
        MixColumns(blockState);

        blockState.CopyTo(tempKeys);
    }

    private static void WorkingKeyExpandEven(ReadOnlySpan<ulong> workingKey, int blockWords, int keyWords, ReadOnlySpan<ulong> tempKey, Span<ulong> roundKeys, int nr)
    {
        Span<ulong> state = stackalloc ulong[8];
        Span<ulong> tmpRoundKey = stackalloc ulong[8];
        Span<ulong> initialData = stackalloc ulong[8];
        workingKey.CopyTo(initialData);

        ulong tmv = 0x0001000100010001UL;
        int round = 0;

        while (true)
        {
            for (int i = 0; i < blockWords; i++)
            {
                tmpRoundKey[i] = tempKey[i] + tmv;
            }

            for (int i = 0; i < blockWords; i++)
            {
                state[i] = initialData[i] + tmpRoundKey[i];
            }

            SubBytes(state.Slice(0, blockWords));
            ShiftRows(state.Slice(0, blockWords));
            MixColumns(state.Slice(0, blockWords));

            for (int i = 0; i < blockWords; i++)
            {
                state[i] ^= tmpRoundKey[i];
            }

            SubBytes(state.Slice(0, blockWords));
            ShiftRows(state.Slice(0, blockWords));
            MixColumns(state.Slice(0, blockWords));

            for (int i = 0; i < blockWords; i++)
            {
                state[i] += tmpRoundKey[i];
            }

            state.Slice(0, blockWords).CopyTo(roundKeys.Slice(round * blockWords, blockWords));

            if (round == nr)
            {
                break;
            }

            if (keyWords != blockWords)
            {
                round += 2;
                tmv <<= 1;

                for (int i = 0; i < blockWords; i++)
                {
                    tmpRoundKey[i] = tempKey[i] + tmv;
                }

                for (int i = 0; i < blockWords; i++)
                {
                    state[i] = initialData[blockWords + i] + tmpRoundKey[i];
                }

                SubBytes(state.Slice(0, blockWords));
                ShiftRows(state.Slice(0, blockWords));
                MixColumns(state.Slice(0, blockWords));

                for (int i = 0; i < blockWords; i++)
                {
                    state[i] ^= tmpRoundKey[i];
                }

                SubBytes(state.Slice(0, blockWords));
                ShiftRows(state.Slice(0, blockWords));
                MixColumns(state.Slice(0, blockWords));

                for (int i = 0; i < blockWords; i++)
                {
                    state[i] += tmpRoundKey[i];
                }

                state.Slice(0, blockWords).CopyTo(roundKeys.Slice(round * blockWords, blockWords));

                if (round == nr)
                {
                    break;
                }
            }

            round += 2;
            tmv <<= 1;
            RotateLeftWords(initialData.Slice(0, keyWords));
        }
    }

    private static void WorkingKeyExpandOdd(Span<ulong> roundKeys, int blockWords, int nr)
    {
        for (int roundIndex = 1; roundIndex < nr; roundIndex += 2)
        {
            RotateRoundKey(roundKeys.Slice((roundIndex - 1) * blockWords, blockWords), roundKeys.Slice(roundIndex * blockWords, blockWords), blockWords);
        }
    }

    private static void RotateLeftWords(Span<ulong> words)
    {
        ulong temp = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            words[i - 1] = words[i];
        }

        words[^1] = temp;
    }

    private static void RotateRoundKey(ReadOnlySpan<ulong> src, Span<ulong> dst, int blockWords)
    {
        switch (blockWords)
        {
            case 2:
            {
                ulong x0 = src[0], x1 = src[1];
                dst[0] = (x0 >> 56) | (x1 << 8);
                dst[1] = (x1 >> 56) | (x0 << 8);
                break;
            }
            case 4:
            {
                ulong x0 = src[0], x1 = src[1], x2 = src[2], x3 = src[3];
                dst[0] = (x1 >> 24) | (x2 << 40);
                dst[1] = (x2 >> 24) | (x3 << 40);
                dst[2] = (x3 >> 24) | (x0 << 40);
                dst[3] = (x0 >> 24) | (x1 << 40);
                break;
            }
            case 8:
            {
                ulong x0 = src[0], x1 = src[1], x2 = src[2], x3 = src[3];
                ulong x4 = src[4], x5 = src[5], x6 = src[6], x7 = src[7];
                dst[0] = (x2 >> 24) | (x3 << 40);
                dst[1] = (x3 >> 24) | (x4 << 40);
                dst[2] = (x4 >> 24) | (x5 << 40);
                dst[3] = (x5 >> 24) | (x6 << 40);
                dst[4] = (x6 >> 24) | (x7 << 40);
                dst[5] = (x7 >> 24) | (x0 << 40);
                dst[6] = (x0 >> 24) | (x1 << 40);
                dst[7] = (x1 >> 24) | (x2 << 40);
                break;
            }
            default:
            {
                throw new InvalidOperationException("Unsupported Kalyna block length.");
            }
        }
    }

    private void AddRoundKey(Span<ulong> state, ulong* roundKeys, int round)
    {
        int offset = round * _blockWords;
        for (int i = 0; i < _blockWords; i++)
        {
            state[i] += roundKeys[offset + i];
        }
    }

    private void SubRoundKey(Span<ulong> state, ulong* roundKeys, int round)
    {
        int offset = round * _blockWords;
        for (int i = 0; i < _blockWords; i++)
        {
            state[i] -= roundKeys[offset + i];
        }
    }

    private void XorRoundKey(Span<ulong> state, ulong* roundKeys, int round)
    {
        int offset = round * _blockWords;
        for (int i = 0; i < _blockWords; i++)
        {
            state[i] ^= roundKeys[offset + i];
        }
    }

    private static void SubBytes(Span<ulong> state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            state[i] = SubstituteWord(state[i]);
        }
    }

    private static void InvSubBytes(Span<ulong> state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            state[i] = InverseSubstituteWord(state[i]);
        }
    }

    private static void ShiftRows(Span<ulong> state)
    {
        switch (state.Length)
        {
            case 2:
            {
                ulong c0 = state[0], c1 = state[1];
                ulong d = (c0 ^ c1) & 0xFFFFFFFF00000000UL;
                c0 ^= d;
                c1 ^= d;
                state[0] = c0;
                state[1] = c1;
                break;
            }
            case 4:
            {
                ulong c0 = state[0], c1 = state[1], c2 = state[2], c3 = state[3];
                ulong d;

                d = (c0 ^ c2) & 0xFFFFFFFF00000000UL; c0 ^= d; c2 ^= d;
                d = (c1 ^ c3) & 0x0000FFFFFFFF0000UL; c1 ^= d; c3 ^= d;

                d = (c0 ^ c1) & 0xFFFF0000FFFF0000UL; c0 ^= d; c1 ^= d;
                d = (c2 ^ c3) & 0xFFFF0000FFFF0000UL; c2 ^= d; c3 ^= d;

                state[0] = c0;
                state[1] = c1;
                state[2] = c2;
                state[3] = c3;
                break;
            }
            case 8:
            {
                ulong c0 = state[0], c1 = state[1], c2 = state[2], c3 = state[3];
                ulong c4 = state[4], c5 = state[5], c6 = state[6], c7 = state[7];
                ulong d;

                d = (c0 ^ c4) & 0xFFFFFFFF00000000UL; c0 ^= d; c4 ^= d;
                d = (c1 ^ c5) & 0x00FFFFFFFF000000UL; c1 ^= d; c5 ^= d;
                d = (c2 ^ c6) & 0x0000FFFFFFFF0000UL; c2 ^= d; c6 ^= d;
                d = (c3 ^ c7) & 0x000000FFFFFFFF00UL; c3 ^= d; c7 ^= d;

                d = (c0 ^ c2) & 0xFFFF0000FFFF0000UL; c0 ^= d; c2 ^= d;
                d = (c1 ^ c3) & 0x00FFFF0000FFFF00UL; c1 ^= d; c3 ^= d;
                d = (c4 ^ c6) & 0xFFFF0000FFFF0000UL; c4 ^= d; c6 ^= d;
                d = (c5 ^ c7) & 0x00FFFF0000FFFF00UL; c5 ^= d; c7 ^= d;

                d = (c0 ^ c1) & 0xFF00FF00FF00FF00UL; c0 ^= d; c1 ^= d;
                d = (c2 ^ c3) & 0xFF00FF00FF00FF00UL; c2 ^= d; c3 ^= d;
                d = (c4 ^ c5) & 0xFF00FF00FF00FF00UL; c4 ^= d; c5 ^= d;
                d = (c6 ^ c7) & 0xFF00FF00FF00FF00UL; c6 ^= d; c7 ^= d;

                state[0] = c0;
                state[1] = c1;
                state[2] = c2;
                state[3] = c3;
                state[4] = c4;
                state[5] = c5;
                state[6] = c6;
                state[7] = c7;
                break;
            }
            default:
            {
                throw new InvalidOperationException("Unsupported Kalyna block length.");
            }
        }
    }

    private static void InvShiftRows(Span<ulong> state)
    {
        switch (state.Length)
        {
            case 2:
            {
                ulong c0 = state[0], c1 = state[1];
                ulong d = (c0 ^ c1) & 0xFFFFFFFF00000000UL;
                c0 ^= d;
                c1 ^= d;
                state[0] = c0;
                state[1] = c1;
                break;
            }
            case 4:
            {
                ulong c0 = state[0], c1 = state[1], c2 = state[2], c3 = state[3];
                ulong d;

                d = (c0 ^ c1) & 0xFFFF0000FFFF0000UL; c0 ^= d; c1 ^= d;
                d = (c2 ^ c3) & 0xFFFF0000FFFF0000UL; c2 ^= d; c3 ^= d;

                d = (c0 ^ c2) & 0xFFFFFFFF00000000UL; c0 ^= d; c2 ^= d;
                d = (c1 ^ c3) & 0x0000FFFFFFFF0000UL; c1 ^= d; c3 ^= d;

                state[0] = c0;
                state[1] = c1;
                state[2] = c2;
                state[3] = c3;
                break;
            }
            case 8:
            {
                ulong c0 = state[0], c1 = state[1], c2 = state[2], c3 = state[3];
                ulong c4 = state[4], c5 = state[5], c6 = state[6], c7 = state[7];
                ulong d;

                d = (c0 ^ c1) & 0xFF00FF00FF00FF00UL; c0 ^= d; c1 ^= d;
                d = (c2 ^ c3) & 0xFF00FF00FF00FF00UL; c2 ^= d; c3 ^= d;
                d = (c4 ^ c5) & 0xFF00FF00FF00FF00UL; c4 ^= d; c5 ^= d;
                d = (c6 ^ c7) & 0xFF00FF00FF00FF00UL; c6 ^= d; c7 ^= d;

                d = (c0 ^ c2) & 0xFFFF0000FFFF0000UL; c0 ^= d; c2 ^= d;
                d = (c1 ^ c3) & 0x00FFFF0000FFFF00UL; c1 ^= d; c3 ^= d;
                d = (c4 ^ c6) & 0xFFFF0000FFFF0000UL; c4 ^= d; c6 ^= d;
                d = (c5 ^ c7) & 0x00FFFF0000FFFF00UL; c5 ^= d; c7 ^= d;

                d = (c0 ^ c4) & 0xFFFFFFFF00000000UL; c0 ^= d; c4 ^= d;
                d = (c1 ^ c5) & 0x00FFFFFFFF000000UL; c1 ^= d; c5 ^= d;
                d = (c2 ^ c6) & 0x0000FFFFFFFF0000UL; c2 ^= d; c6 ^= d;
                d = (c3 ^ c7) & 0x000000FFFFFFFF00UL; c3 ^= d; c7 ^= d;

                state[0] = c0;
                state[1] = c1;
                state[2] = c2;
                state[3] = c3;
                state[4] = c4;
                state[5] = c5;
                state[6] = c6;
                state[7] = c7;
                break;
            }
            default:
            {
                throw new InvalidOperationException("Unsupported Kalyna block length.");
            }
        }
    }

    private static void MixColumns(Span<ulong> state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            state[i] = MixColumn(state[i]);
        }
    }

    private static void MixColumnsInv(Span<ulong> state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            state[i] = MixColumnInv(state[i]);
        }
    }

    private static ulong SubstituteWord(ulong value)
    {
        int lo = (int)value;
        int hi = (int)(value >> 32);

        byte t0 = S0[lo & 0xFF];
        byte t1 = S1[(lo >> 8) & 0xFF];
        byte t2 = S2[(lo >> 16) & 0xFF];
        byte t3 = S3[(lo >> 24) & 0xFF];
        lo = t0 | (t1 << 8) | (t2 << 16) | (t3 << 24);

        byte t4 = S0[hi & 0xFF];
        byte t5 = S1[(hi >> 8) & 0xFF];
        byte t6 = S2[(hi >> 16) & 0xFF];
        byte t7 = S3[(hi >> 24) & 0xFF];
        hi = t4 | (t5 << 8) | (t6 << 16) | (t7 << 24);

        return (uint)lo | ((ulong)(uint)hi << 32);
    }

    private static ulong InverseSubstituteWord(ulong value)
    {
        int lo = (int)value;
        int hi = (int)(value >> 32);

        byte t0 = IS0[lo & 0xFF];
        byte t1 = IS1[(lo >> 8) & 0xFF];
        byte t2 = IS2[(lo >> 16) & 0xFF];
        byte t3 = IS3[(lo >> 24) & 0xFF];
        lo = t0 | (t1 << 8) | (t2 << 16) | (t3 << 24);

        byte t4 = IS0[hi & 0xFF];
        byte t5 = IS1[(hi >> 8) & 0xFF];
        byte t6 = IS2[(hi >> 16) & 0xFF];
        byte t7 = IS3[(hi >> 24) & 0xFF];
        hi = t4 | (t5 << 8) | (t6 << 16) | (t7 << 24);

        return (uint)lo | ((ulong)(uint)hi << 32);
    }

    private static ulong MixColumn(ulong value)
    {
        ulong x1 = MulX(value);
        ulong u = Rotate(8, value) ^ value;
        u ^= Rotate(16, u);
        u ^= Rotate(48, value);

        ulong v = MulX2(u ^ value ^ x1);
        return u ^ Rotate(32, v) ^ Rotate(40, x1) ^ Rotate(48, x1);
    }

    private static ulong MixColumnInv(ulong value)
    {
        ulong u0 = value;
        u0 ^= Rotate(8, u0);
        u0 ^= Rotate(32, u0);
        u0 ^= Rotate(48, value);

        ulong t = u0 ^ value;

        ulong c48 = Rotate(48, value);
        ulong c56 = Rotate(56, value);

        ulong u7 = t ^ c56;
        ulong u6 = Rotate(56, t);
        u6 ^= MulX(u7);
        ulong u5 = Rotate(16, t) ^ value;
        u5 ^= Rotate(40, MulX(u6) ^ value);
        ulong u4 = t ^ c48;
        u4 ^= MulX(u5);
        ulong u3 = Rotate(16, u0);
        u3 ^= MulX(u4);
        ulong u2 = t ^ Rotate(24, value) ^ c48 ^ c56;
        u2 ^= MulX(u3);
        ulong u1 = Rotate(32, t) ^ value ^ c56;
        u1 ^= MulX(u2);
        u0 ^= MulX(Rotate(40, u1));

        return u0;
    }

    private static ulong MulX(ulong value)
    {
        return ((value & 0x7F7F7F7F7F7F7F7FUL) << 1)
             ^ (((value & 0x8080808080808080UL) >> 7) * 0x1DUL);
    }

    private static ulong MulX2(ulong value)
    {
        return ((value & 0x3F3F3F3F3F3F3F3FUL) << 2)
             ^ (((value & 0x8080808080808080UL) >> 6) * 0x1DUL)
             ^ (((value & 0x4040404040404040UL) >> 6) * 0x1DUL);
    }

    private static ulong Rotate(int n, ulong value)
    {
        return (value >> n) | (value << (64 - n));
    }

    private static void SubBytes(Span<byte> state)
    {
        // For 128-bit block (2 columns of 8 bytes):
        // Column 0: S0, S1, S2, S3, S0, S1, S2, S3
        // Column 1: S0, S1, S2, S3, S0, S1, S2, S3
        for (int col = 0; col < NumWords; col++)
        {
            int off = col * 8;
            state[off + 0] = S0[state[off + 0]];
            state[off + 1] = S1[state[off + 1]];
            state[off + 2] = S2[state[off + 2]];
            state[off + 3] = S3[state[off + 3]];
            state[off + 4] = S0[state[off + 4]];
            state[off + 5] = S1[state[off + 5]];
            state[off + 6] = S2[state[off + 6]];
            state[off + 7] = S3[state[off + 7]];
        }
    }

    private static void ShiftRows(Span<byte> state)
    {
        // For 128-bit block (2 columns): swap rows 4-7 between columns
        for (int row = 4; row < 8; row++)
        {
            (state[row], state[8 + row]) = (state[8 + row], state[row]);
        }
    }

    private static void MixColumns(Span<byte> state)
    {
        // Unrolled MDS matrix multiply using precomputed GF(2^8) lookup tables.
        // MDS row pattern (circulant): 01, 01, 05, 01, 08, 06, 07, 04
        for (int col = 0; col < NumWords; col++)
        {
            int off = col * 8;
            byte b0 = state[off], b1 = state[off + 1], b2 = state[off + 2], b3 = state[off + 3];
            byte b4 = state[off + 4], b5 = state[off + 5], b6 = state[off + 6], b7 = state[off + 7];

            state[off + 0] = (byte)(b0 ^ b1 ^ Gf05[b2] ^ b3 ^ Gf08[b4] ^ Gf06[b5] ^ Gf07[b6] ^ Gf04[b7]);
            state[off + 1] = (byte)(Gf04[b0] ^ b1 ^ b2 ^ Gf05[b3] ^ b4 ^ Gf08[b5] ^ Gf06[b6] ^ Gf07[b7]);
            state[off + 2] = (byte)(Gf07[b0] ^ Gf04[b1] ^ b2 ^ b3 ^ Gf05[b4] ^ b5 ^ Gf08[b6] ^ Gf06[b7]);
            state[off + 3] = (byte)(Gf06[b0] ^ Gf07[b1] ^ Gf04[b2] ^ b3 ^ b4 ^ Gf05[b5] ^ b6 ^ Gf08[b7]);
            state[off + 4] = (byte)(Gf08[b0] ^ Gf06[b1] ^ Gf07[b2] ^ Gf04[b3] ^ b4 ^ b5 ^ Gf05[b6] ^ b7);
            state[off + 5] = (byte)(b0 ^ Gf08[b1] ^ Gf06[b2] ^ Gf07[b3] ^ Gf04[b4] ^ b5 ^ b6 ^ Gf05[b7]);
            state[off + 6] = (byte)(Gf05[b0] ^ b1 ^ Gf08[b2] ^ Gf06[b3] ^ Gf07[b4] ^ Gf04[b5] ^ b6 ^ b7);
            state[off + 7] = (byte)(b0 ^ Gf05[b1] ^ b2 ^ Gf08[b3] ^ Gf06[b4] ^ Gf07[b5] ^ Gf04[b6] ^ b7);
        }
    }

    private static byte GfMul(byte a, byte b)
    {
        byte result = 0;
        byte temp = b;
        for (int i = 0; i < 8; i++)
        {
            if ((a & (1 << i)) != 0)
            {
                result ^= temp;
            }

            bool carry = (temp & 0x80) != 0;
            temp <<= 1;
            if (carry)
            {
                temp ^= 0x1D; // Low 8 bits of 0x11D
            }
        }
        return result;
    }

    private static void AddRoundKeyMod(Span<byte> state, ReadOnlySpan<byte> roundKey)
    {
        // Modular addition on 64-bit words
        for (int i = 0; i < NumWords; i++)
        {
            ulong s = BinaryPrimitives.ReadUInt64LittleEndian(state.Slice(i * 8));
            ulong k = BinaryPrimitives.ReadUInt64LittleEndian(roundKey.Slice(i * 8));
            BinaryPrimitives.WriteUInt64LittleEndian(state.Slice(i * 8), s + k);
        }
    }

    private static void XorRoundKey(Span<byte> state, ReadOnlySpan<byte> roundKey)
    {
        for (int i = 0; i < 16; i++)
        {
            state[i] ^= roundKey[i];
        }
    }

    private static byte[] ComputeInverse(ReadOnlySpan<byte> sbox)
    {
        byte[] inv = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            inv[sbox[i]] = (byte)i;
        }

        return inv;
    }

    private static byte[] ComputeGfMulTable(byte a)
    {
        byte[] table = new byte[256];
        for (int b = 0; b < 256; b++)
        {
            table[b] = GfMul(a, (byte)b);
        }

        return table;
    }

    // Key expansion: compute intermediate key Kt
    [SkipLocalsInit]
    private static void KeyExpandKt(ReadOnlySpan<byte> key, Span<byte> kt)
    {
        Span<byte> state = stackalloc byte[16];
        state.Clear();

        // Initialize state with block size indicator
        int keyLen = key.Length;
        state[0] = (byte)(BlockSizeBytes / 8 + keyLen / 8 + 1);

        // Round 1: AddKey(state, key[0..15]) + SubBytes + ShiftRows + MixColumns
        AddRoundKeyMod(state, key.Slice(0, 16));
        SubBytes(state);
        ShiftRows(state);
        MixColumns(state);

        // Round 2: XOR with key part
        if (keyLen == 32)
        {
            XorRoundKey(state, key.Slice(16, 16));
        }
        else
        {
            XorRoundKey(state, key.Slice(0, 16));
        }

        SubBytes(state);
        ShiftRows(state);
        MixColumns(state);

        // Round 3
        AddRoundKeyMod(state, key.Slice(0, 16));
        SubBytes(state);
        ShiftRows(state);
        MixColumns(state);

        state.CopyTo(kt);
    }

    // Key expansion for 128-bit key
    [SkipLocalsInit]
    private static void KeyExpandEvenOdd128(ReadOnlySpan<byte> key, ReadOnlySpan<byte> kt, Span<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
        state.Clear();
        Span<byte> tmpRK = stackalloc byte[16];
        Span<byte> initialData = stackalloc byte[16];

        key.Slice(0, 16).CopyTo(initialData);

        ulong tmv = 0x0001000100010001UL;

        int round = 0;

        while (true)
        {
            // tmpRK = kt + tmv (add tmv to each word)
            for (int w = 0; w < NumWords; w++)
            {
                ulong ktWord = BinaryPrimitives.ReadUInt64LittleEndian(kt.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(tmpRK.Slice(w * 8), ktWord + tmv);
            }

            // state = initialData + tmpRK
            for (int w = 0; w < NumWords; w++)
            {
                ulong d = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(w * 8));
                ulong r = BinaryPrimitives.ReadUInt64LittleEndian(tmpRK.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(state.Slice(w * 8), d + r);
            }

            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            XorRoundKey(state, tmpRK);
            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            AddRoundKeyMod(state, tmpRK);

            state.CopyTo(roundKeys.Slice(round * 16, 16));

            if (round == nr)
            {
                break;
            }

            round += 2;
            tmv <<= 1;

            // Rotate initialData left by 1 word (swap the two 64-bit words)
            ulong w0 = BinaryPrimitives.ReadUInt64LittleEndian(initialData);
            ulong w1 = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(8));
            BinaryPrimitives.WriteUInt64LittleEndian(initialData, w1);
            BinaryPrimitives.WriteUInt64LittleEndian(initialData.Slice(8), w0);
        }

        // Odd round keys via rotation of even keys
        for (int i = 1; i < nr; i += 2)
        {
            RotateBlock(roundKeys.Slice((i - 1) * 16, 16), roundKeys.Slice(i * 16, 16));
        }
    }

    // Key expansion for 256-bit key with 128-bit block
    [SkipLocalsInit]
    private static void KeyExpandEvenOdd256(ReadOnlySpan<byte> key, ReadOnlySpan<byte> kt, Span<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
        state.Clear();
        Span<byte> tmpRK = stackalloc byte[16];
        Span<byte> initialData = stackalloc byte[32];

        key.Slice(0, 32).CopyTo(initialData);

        ulong tmv = 0x0001000100010001UL;

        int round = 0;

        while (true)
        {
            // First even key: uses initialData[0:16]
            for (int w = 0; w < NumWords; w++)
            {
                ulong ktWord = BinaryPrimitives.ReadUInt64LittleEndian(kt.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(tmpRK.Slice(w * 8), ktWord + tmv);
            }

            for (int w = 0; w < NumWords; w++)
            {
                ulong d = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(w * 8));
                ulong r = BinaryPrimitives.ReadUInt64LittleEndian(tmpRK.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(state.Slice(w * 8), d + r);
            }

            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            XorRoundKey(state, tmpRK);
            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            AddRoundKeyMod(state, tmpRK);

            state.CopyTo(roundKeys.Slice(round * 16, 16));

            if (round == nr)
            {
                break;
            }

            // Second even key: uses initialData[16:32]
            round += 2;
            tmv <<= 1;

            for (int w = 0; w < NumWords; w++)
            {
                ulong ktWord = BinaryPrimitives.ReadUInt64LittleEndian(kt.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(tmpRK.Slice(w * 8), ktWord + tmv);
            }

            for (int w = 0; w < NumWords; w++)
            {
                ulong d = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(16 + w * 8));
                ulong r = BinaryPrimitives.ReadUInt64LittleEndian(tmpRK.Slice(w * 8));
                BinaryPrimitives.WriteUInt64LittleEndian(state.Slice(w * 8), d + r);
            }

            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            XorRoundKey(state, tmpRK);
            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            AddRoundKeyMod(state, tmpRK);

            state.CopyTo(roundKeys.Slice(round * 16, 16));

            if (round == nr)
            {
                break;
            }

            round += 2;
            tmv <<= 1;

            // Rotate initialData left by 1 word (8 bytes) in a 4-word array
            ulong d0 = BinaryPrimitives.ReadUInt64LittleEndian(initialData);
            ulong d1 = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(8));
            ulong d2 = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(16));
            ulong d3 = BinaryPrimitives.ReadUInt64LittleEndian(initialData.Slice(24));
            BinaryPrimitives.WriteUInt64LittleEndian(initialData, d1);
            BinaryPrimitives.WriteUInt64LittleEndian(initialData.Slice(8), d2);
            BinaryPrimitives.WriteUInt64LittleEndian(initialData.Slice(16), d3);
            BinaryPrimitives.WriteUInt64LittleEndian(initialData.Slice(24), d0);
        }

        // Odd round keys via rotation of even keys
        for (int i = 1; i < nr; i += 2)
        {
            RotateBlock(roundKeys.Slice((i - 1) * 16, 16), roundKeys.Slice(i * 16, 16));
        }
    }

    // Rotate 128-bit block left by (2*nb+3) bytes = 7 bytes = 56 bits for 128-bit block
    private static void RotateBlock(ReadOnlySpan<byte> src, Span<byte> dst)
    {
        ulong x0 = BinaryPrimitives.ReadUInt64LittleEndian(src);
        ulong x1 = BinaryPrimitives.ReadUInt64LittleEndian(src.Slice(8));
        BinaryPrimitives.WriteUInt64LittleEndian(dst, (x0 >> 56) | (x1 << 8));
        BinaryPrimitives.WriteUInt64LittleEndian(dst.Slice(8), (x1 >> 56) | (x0 << 8));
    }
}
