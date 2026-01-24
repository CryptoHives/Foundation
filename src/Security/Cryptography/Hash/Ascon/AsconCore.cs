// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides the Ascon permutation for NIST SP 800-232 (Ascon-Hash256 and Ascon-XOF128).
/// </summary>
/// <remarks>
/// <para>
/// This implementation follows NIST SP 800-232.
/// See: <see href="https://csrc.nist.gov/pubs/sp/800/232/final"/>
/// </para>
/// <para>
/// Reference implementation: <see href="https://github.com/ascon/ascon-c"/>
/// </para>
/// </remarks>
internal static class Ascon800232Core
{
    /// <summary>
    /// Applies the Ascon permutation p^12.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void P12(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4)
    {
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xf0UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xe1UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xd2UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xc3UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xb4UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xa5UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x96UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x87UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x78UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x69UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x5aUL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x4bUL);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Round(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4, ulong c)
    {
        ulong sx = s2 ^ c;
        ulong t0 = s0 ^ s1 ^ sx ^ s3 ^ (s1 & (s0 ^ sx ^ s4));
        ulong t1 = s0 ^ sx ^ s3 ^ s4 ^ ((s1 ^ sx) & (s1 ^ s3));
        ulong t2 = s1 ^ sx ^ s4 ^ (s3 & s4);
        ulong t3 = s0 ^ s1 ^ sx ^ (~s0 & (s3 ^ s4));
        ulong t4 = s1 ^ s3 ^ s4 ^ ((s0 ^ s4) & s1);
        s0 = t0 ^ RotateRight(t0, 19) ^ RotateRight(t0, 28);
        s1 = t1 ^ RotateRight(t1, 39) ^ RotateRight(t1, 61);
        s2 = ~(t2 ^ RotateRight(t2, 1) ^ RotateRight(t2, 6));
        s3 = t3 ^ RotateRight(t3, 10) ^ RotateRight(t3, 17);
        s4 = t4 ^ RotateRight(t4, 7) ^ RotateRight(t4, 41);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateRight(ulong value, int offset)
    {
#if NET6_0_OR_GREATER
        return ulong.RotateRight(value, offset);
#else
        return (value >> offset) | (value << (64 - offset));
#endif
    }
}

/// <summary>
/// Provides the Ascon permutation used by Ascon v1.2 (legacy).
/// </summary>
/// <remarks>
/// <para>
/// This is the original Ascon v1.2 specification permutation.
/// For NIST SP 800-232, use <see cref="Ascon800232Core"/> instead.
/// </para>
/// </remarks>
internal static class AsconCore
{
    /// <summary>
    /// Applies the Ascon permutation p^r with the specified number of rounds.
    /// </summary>
    /// <param name="x0">State word 0.</param>
    /// <param name="x1">State word 1.</param>
    /// <param name="x2">State word 2.</param>
    /// <param name="x3">State word 3.</param>
    /// <param name="x4">State word 4.</param>
    /// <param name="rounds">The number of rounds to apply (8 or 12).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Permutation(ref ulong x0, ref ulong x1, ref ulong x2, ref ulong x3, ref ulong x4, int rounds)
    {
        unchecked
        {
            // Round constants: c_i = (0xf - i) << 4 | i for rounds 0-11
            // For 12 rounds, start at round 0; for 8 rounds, start at round 4
            int startRound = 12 - rounds;
            for (int i = startRound; i < 12; i++)
            {
                // Addition of round constant to x2
                // Round constants: 0xf0, 0xe1, 0xd2, 0xc3, 0xb4, 0xa5, 0x96, 0x87, 0x78, 0x69, 0x5a, 0x4b
                x2 ^= (ulong)(((0xF - i) << 4) | i);

                // Substitution layer (5-bit S-box applied to each bit slice)
                x0 ^= x4;
                x4 ^= x3;
                x2 ^= x1;

                ulong t0 = x0 & (~x1);
                ulong t1 = x1 & (~x2);
                ulong t2 = x2 & (~x3);
                ulong t3 = x3 & (~x4);
                ulong t4 = x4 & (~x0);

                x0 ^= t1;
                x1 ^= t2;
                x2 ^= t3;
                x3 ^= t4;
                x4 ^= t0;

                x1 ^= x0;
                x0 ^= x4;
                x3 ^= x2;
                x2 = ~x2;

                // Linear diffusion layer
                x0 ^= RotateRight(x0, 19) ^ RotateRight(x0, 28);
                x1 ^= RotateRight(x1, 61) ^ RotateRight(x1, 39);
                x2 ^= RotateRight(x2, 1) ^ RotateRight(x2, 6);
                x3 ^= RotateRight(x3, 10) ^ RotateRight(x3, 17);
                x4 ^= RotateRight(x4, 7) ^ RotateRight(x4, 41);
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateRight(ulong value, int offset)
    {
#if NET6_0_OR_GREATER
        return ulong.RotateRight(value, offset);
#else
        return (value >> offset) | (value << (64 - offset));
#endif
    }
}
