// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Core Magma (GOST R 34.12-2015, RFC 8891) block operations: a 32-round Feistel network on a
/// 64-bit block with a 256-bit key and the fixed id-tc26-gost-28147-param-Z S-boxes.
/// </summary>
/// <remarks>
/// Blocks and keys are big-endian integers, as RFC 8891 defines them, which differs from the byte
/// order of the 1989 GOST 28147-89 implementations. The round function looks up byte-indexed
/// tables, so like the other table-driven ciphers here it is not constant-time against cache attacks.
/// </remarks>
internal static class MagmaCore
{
    /// <summary>Block size in bytes.</summary>
    public const int BlockSizeBytes = 8;

    /// <summary>Block size in bits.</summary>
    public const int BlockSizeBits = 64;

    /// <summary>Key size in bytes.</summary>
    public const int KeySizeBytes = 32;

    /// <summary>Number of distinct 32-bit round keys, K_1 to K_8.</summary>
    public const int RoundKeyCount = 8;

    /// <summary>
    /// The four byte-indexed round function tables: S-box pair, byte position and the 11-bit
    /// rotation combined, so that g is four lookups and three XORs.
    /// </summary>
    private static readonly uint[] SubstitutionTables = BuildSubstitutionTables();

    /// <summary>
    /// Splits the key into K_1..K_8; the 32-round schedule reuses them in a fixed order.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="roundKeys">Receives the eight round keys.</param>
    public static void ExpandKey(ReadOnlySpan<byte> key, Span<uint> roundKeys)
    {
        BinarySpans.ReadUInt32BigEndian(key.Slice(0, RoundKeyCount * sizeof(uint)), roundKeys);
    }

    /// <summary>
    /// Encrypts one block held as a big-endian integer.
    /// </summary>
    /// <param name="block">The plaintext block.</param>
    /// <param name="roundKeys">K_1..K_8 from <see cref="ExpandKey"/>.</param>
    /// <returns>The ciphertext block.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong Encrypt(ulong block, ReadOnlySpan<uint> roundKeys)
    {
        uint a1 = (uint)(block >> 32);
        uint a0 = (uint)block;
        ReadOnlySpan<uint> tables = SubstitutionTables;

        // K_1..K_8 three times, then K_8..K_1; the halves swap after every round but the last.
        for (int pass = 0; pass < 3; pass++)
        {
            for (int i = 0; i < RoundKeyCount; i += 2)
            {
                a1 ^= G(tables, a0 + roundKeys[i]);
                a0 ^= G(tables, a1 + roundKeys[i + 1]);
            }
        }

        for (int i = RoundKeyCount - 1; i > 0; i -= 2)
        {
            a1 ^= G(tables, a0 + roundKeys[i]);
            a0 ^= G(tables, a1 + roundKeys[i - 1]);
        }

        return ((ulong)a0 << 32) | a1;
    }

    /// <summary>
    /// Decrypts one block held as a big-endian integer.
    /// </summary>
    /// <param name="block">The ciphertext block.</param>
    /// <param name="roundKeys">K_1..K_8 from <see cref="ExpandKey"/>.</param>
    /// <returns>The plaintext block.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong Decrypt(ulong block, ReadOnlySpan<uint> roundKeys)
    {
        uint a1 = (uint)(block >> 32);
        uint a0 = (uint)block;
        ReadOnlySpan<uint> tables = SubstitutionTables;

        // The encryption schedule reversed: K_1..K_8 once, then K_8..K_1 three times.
        for (int i = 0; i < RoundKeyCount; i += 2)
        {
            a1 ^= G(tables, a0 + roundKeys[i]);
            a0 ^= G(tables, a1 + roundKeys[i + 1]);
        }

        for (int pass = 0; pass < 3; pass++)
        {
            for (int i = RoundKeyCount - 1; i > 0; i -= 2)
            {
                a1 ^= G(tables, a0 + roundKeys[i]);
                a0 ^= G(tables, a1 + roundKeys[i - 1]);
            }
        }

        return ((ulong)a0 << 32) | a1;
    }

    /// <summary>
    /// Encrypts one 8-byte block.
    /// </summary>
    public static void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys)
        => BinaryPrimitives.WriteUInt64BigEndian(output, Encrypt(BinaryPrimitives.ReadUInt64BigEndian(input), roundKeys));

    /// <summary>
    /// Decrypts one 8-byte block.
    /// </summary>
    public static void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<uint> roundKeys)
        => BinaryPrimitives.WriteUInt64BigEndian(output, Decrypt(BinaryPrimitives.ReadUInt64BigEndian(input), roundKeys));

    /// <summary>
    /// The round function g without the key addition: t, then a rotation left by 11.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint G(ReadOnlySpan<uint> tables, uint x)
    {
        return tables[(int)(x & 0xFF)]
            ^ tables[256 + (int)((x >> 8) & 0xFF)]
            ^ tables[512 + (int)((x >> 16) & 0xFF)]
            ^ tables[768 + (int)(x >> 24)];
    }

    private static uint[] BuildSubstitutionTables()
    {
        // Pi'_0 .. Pi'_7 of RFC 8891 section 4.1; Pi'_i substitutes the i-th nibble from the least significant.
        ReadOnlySpan<byte> pi =
        [
            12, 4, 6, 2, 10, 5, 11, 9, 14, 8, 13, 7, 0, 3, 15, 1,
            6, 8, 2, 3, 9, 10, 5, 12, 1, 14, 4, 7, 11, 13, 0, 15,
            11, 3, 5, 8, 2, 15, 10, 13, 14, 1, 7, 4, 12, 9, 6, 0,
            12, 8, 2, 1, 13, 4, 15, 6, 7, 0, 10, 5, 3, 14, 9, 11,
            7, 15, 5, 10, 8, 1, 6, 13, 0, 9, 3, 14, 11, 4, 2, 12,
            5, 13, 15, 6, 9, 2, 12, 10, 11, 7, 8, 1, 4, 3, 14, 0,
            8, 14, 2, 5, 6, 9, 1, 12, 15, 4, 11, 0, 13, 10, 3, 7,
            1, 7, 14, 13, 0, 5, 8, 3, 4, 15, 10, 6, 9, 12, 11, 2,
        ];

        uint[] tables = new uint[4 * 256];
        for (int position = 0; position < 4; position++)
        {
            for (int value = 0; value < 256; value++)
            {
                uint low = pi[(2 * position * 16) + (value & 0xF)];
                uint high = pi[((2 * position + 1) * 16) + (value >> 4)];
                tables[(position * 256) + value] = BitOperations.RotateLeft(((high << 4) | low) << (8 * position), 11);
            }
        }

        return tables;
    }
}
