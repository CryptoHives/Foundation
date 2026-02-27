// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Core Kalyna (DSTU 7624:2014) block cipher operations for 128-bit block size.
/// </summary>
/// <remarks>
/// Kalyna is the Ukrainian national standard block cipher. This implementation
/// supports 128-bit blocks with 128-bit or 256-bit keys (10 or 14 rounds).
/// </remarks>
internal static class KalynaCore
{
    public const int BlockSizeBytes = 16;

    // Number of 64-bit words in a 128-bit block
    private const int NumWords = 2;

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

    // Inverse S-boxes (computed from S0-S3)
    private static readonly byte[] IS0 = ComputeInverse(S0);
    private static readonly byte[] IS1 = ComputeInverse(S1);
    private static readonly byte[] IS2 = ComputeInverse(S2);
    private static readonly byte[] IS3 = ComputeInverse(S3);

    // MDS matrix for MixColumns (8x8 matrix over GF(2^8))
#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional
    private static readonly byte[,] MdsMatrix =
    {
        { 0x01, 0x01, 0x05, 0x01, 0x08, 0x06, 0x07, 0x04 },
        { 0x04, 0x01, 0x01, 0x05, 0x01, 0x08, 0x06, 0x07 },
        { 0x07, 0x04, 0x01, 0x01, 0x05, 0x01, 0x08, 0x06 },
        { 0x06, 0x07, 0x04, 0x01, 0x01, 0x05, 0x01, 0x08 },
        { 0x08, 0x06, 0x07, 0x04, 0x01, 0x01, 0x05, 0x01 },
        { 0x01, 0x08, 0x06, 0x07, 0x04, 0x01, 0x01, 0x05 },
        { 0x05, 0x01, 0x08, 0x06, 0x07, 0x04, 0x01, 0x01 },
        { 0x01, 0x05, 0x01, 0x08, 0x06, 0x07, 0x04, 0x01 },
    };

    private static readonly byte[,] InvMdsMatrix =
    {
        { 0xAD, 0x95, 0x76, 0xA8, 0x2F, 0x49, 0xD7, 0xCA },
        { 0xCA, 0xAD, 0x95, 0x76, 0xA8, 0x2F, 0x49, 0xD7 },
        { 0xD7, 0xCA, 0xAD, 0x95, 0x76, 0xA8, 0x2F, 0x49 },
        { 0x49, 0xD7, 0xCA, 0xAD, 0x95, 0x76, 0xA8, 0x2F },
        { 0x2F, 0x49, 0xD7, 0xCA, 0xAD, 0x95, 0x76, 0xA8 },
        { 0xA8, 0x2F, 0x49, 0xD7, 0xCA, 0xAD, 0x95, 0x76 },
        { 0x76, 0xA8, 0x2F, 0x49, 0xD7, 0xCA, 0xAD, 0x95 },
        { 0x95, 0x76, 0xA8, 0x2F, 0x49, 0xD7, 0xCA, 0xAD },
    };
#pragma warning restore CA1814

    /// <summary>
    /// Expands a Kalyna cipher key into round keys.
    /// </summary>
    /// <param name="key">The cipher key (16 or 32 bytes for 128-bit block).</param>
    /// <param name="roundKeys">Output buffer for round keys.</param>
    /// <returns>Number of rounds (10 for 128-bit key, 14 for 256-bit key).</returns>
    public static int ExpandKey(ReadOnlySpan<byte> key, Span<byte> roundKeys)
    {
        int nr = key.Length switch
        {
            16 => 10,
            32 => 14,
            _ => throw new ArgumentException("Key must be 16 or 32 bytes for 128-bit block.", nameof(key))
        };

        // Generate intermediate key Kt
        Span<byte> kt = stackalloc byte[16];
        KeyExpandKt(key, kt);

        // Generate round keys
        if (key.Length == 16)
            KeyExpandEvenOdd128(key, kt, roundKeys, nr);
        else
            KeyExpandEvenOdd256(key, kt, roundKeys, nr);

        return nr;
    }

    /// <summary>
    /// Encrypts a single 16-byte block using Kalyna.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
        input.Slice(0, 16).CopyTo(state);

        // Pre-whitening: AddRoundKey (modular addition)
        AddRoundKeyMod(state, roundKeys.Slice(0, 16));

        for (int r = 1; r < nr; r++)
        {
            SubBytes(state);
            ShiftRows(state);
            MixColumns(state);
            XorRoundKey(state, roundKeys.Slice(r * 16, 16));
        }

        // Last round
        SubBytes(state);
        ShiftRows(state);
        MixColumns(state);

        // Post-whitening: AddRoundKey (modular addition)
        AddRoundKeyMod(state, roundKeys.Slice(nr * 16, 16));

        state.CopyTo(output);
    }

    /// <summary>
    /// Decrypts a single 16-byte block using Kalyna.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
        input.Slice(0, 16).CopyTo(state);

        // Pre-whitening: SubRoundKey (modular subtraction)
        SubRoundKeyMod(state, roundKeys.Slice(nr * 16, 16));

        InvMixColumns(state);
        InvShiftRows(state);
        InvSubBytes(state);

        for (int r = nr - 1; r > 0; r--)
        {
            XorRoundKey(state, roundKeys.Slice(r * 16, 16));
            InvMixColumns(state);
            InvShiftRows(state);
            InvSubBytes(state);
        }

        // Post-whitening: SubRoundKey (modular subtraction)
        SubRoundKeyMod(state, roundKeys.Slice(0, 16));

        state.CopyTo(output);
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

    private static void InvSubBytes(Span<byte> state)
    {
        for (int col = 0; col < NumWords; col++)
        {
            int off = col * 8;
            state[off + 0] = IS0[state[off + 0]];
            state[off + 1] = IS1[state[off + 1]];
            state[off + 2] = IS2[state[off + 2]];
            state[off + 3] = IS3[state[off + 3]];
            state[off + 4] = IS0[state[off + 4]];
            state[off + 5] = IS1[state[off + 5]];
            state[off + 6] = IS2[state[off + 6]];
            state[off + 7] = IS3[state[off + 7]];
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

    private static void InvShiftRows(Span<byte> state)
    {
        // For 128-bit block: inverse is the same swap
        for (int row = 4; row < 8; row++)
        {
            (state[row], state[8 + row]) = (state[8 + row], state[row]);
        }
    }

    private static void MixColumns(Span<byte> state)
    {
        Span<byte> temp = stackalloc byte[8];

        for (int col = 0; col < NumWords; col++)
        {
            var column = state.Slice(col * 8, 8);
            for (int i = 0; i < 8; i++)
            {
                byte val = 0;
                for (int j = 0; j < 8; j++)
                    val ^= GfMul(MdsMatrix[i, j], column[j]);
                temp[i] = val;
            }
            temp.CopyTo(column);
        }
    }

    private static void InvMixColumns(Span<byte> state)
    {
        Span<byte> temp = stackalloc byte[8];

        for (int col = 0; col < NumWords; col++)
        {
            var column = state.Slice(col * 8, 8);
            for (int i = 0; i < 8; i++)
            {
                byte val = 0;
                for (int j = 0; j < 8; j++)
                    val ^= GfMul(InvMdsMatrix[i, j], column[j]);
                temp[i] = val;
            }
            temp.CopyTo(column);
        }
    }

    // GF(2^8) multiplication with polynomial x^8 + x^4 + x^3 + x^2 + 1 (0x11D)
    private static byte GfMul(byte a, byte b)
    {
        byte result = 0;
        byte temp = b;
        for (int i = 0; i < 8; i++)
        {
            if ((a & (1 << i)) != 0)
                result ^= temp;
            bool carry = (temp & 0x80) != 0;
            temp <<= 1;
            if (carry)
                temp ^= 0x1D; // Low 8 bits of 0x11D
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

    private static void SubRoundKeyMod(Span<byte> state, ReadOnlySpan<byte> roundKey)
    {
        for (int i = 0; i < NumWords; i++)
        {
            ulong s = BinaryPrimitives.ReadUInt64LittleEndian(state.Slice(i * 8));
            ulong k = BinaryPrimitives.ReadUInt64LittleEndian(roundKey.Slice(i * 8));
            BinaryPrimitives.WriteUInt64LittleEndian(state.Slice(i * 8), s - k);
        }
    }

    private static void XorRoundKey(Span<byte> state, ReadOnlySpan<byte> roundKey)
    {
        for (int i = 0; i < 16; i++)
            state[i] ^= roundKey[i];
    }

    private static byte[] ComputeInverse(ReadOnlySpan<byte> sbox)
    {
        byte[] inv = new byte[256];
        for (int i = 0; i < 256; i++)
            inv[sbox[i]] = (byte)i;
        return inv;
    }

    // Key expansion: compute intermediate key Kt
    private static void KeyExpandKt(ReadOnlySpan<byte> key, Span<byte> kt)
    {
        Span<byte> state = stackalloc byte[16];

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
            XorRoundKey(state, key.Slice(16, 16));
        else
            XorRoundKey(state, key.Slice(0, 16));

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
    private static void KeyExpandEvenOdd128(ReadOnlySpan<byte> key, ReadOnlySpan<byte> kt, Span<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
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

            if (round == nr) break;

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
    private static void KeyExpandEvenOdd256(ReadOnlySpan<byte> key, ReadOnlySpan<byte> kt, Span<byte> roundKeys, int nr)
    {
        Span<byte> state = stackalloc byte[16];
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

            if (round == nr) break;

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

            if (round == nr) break;

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
