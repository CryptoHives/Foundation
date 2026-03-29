// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides the Ascon permutation primitives shared by Ascon-AEAD-128, Ascon-Hash256 and Ascon-XOF128.
/// </summary>
/// <remarks>
/// <para>
/// The Ascon permutation operates on a 320-bit state represented as five 64-bit words.
/// It is defined in NIST SP 800-232 and is the foundation of the NIST Lightweight
/// Cryptography standard.
/// </para>
/// <para>
/// References:
/// <list type="bullet">
/// <item><see href="https://csrc.nist.gov/pubs/sp/800/232/final">NIST SP 800-232</see></item>
/// <item><see href="https://ascon.iaik.tugraz.at/">Ascon Homepage</see></item>
/// </list>
/// </para>
/// </remarks>
internal static class AsconCore
{
    /// <summary>
    /// Applies the Ascon permutation p^8 (rounds 4–11).
    /// </summary>
    /// <param name="s0">State word 0.</param>
    /// <param name="s1">State word 1.</param>
    /// <param name="s2">State word 2.</param>
    /// <param name="s3">State word 3.</param>
    /// <param name="s4">State word 4.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void P8(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4)
    {
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xb4UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0xa5UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x96UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x87UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x78UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x69UL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x5aUL);
        Round(ref s0, ref s1, ref s2, ref s3, ref s4, 0x4bUL);
    }

    /// <summary>
    /// Applies the Ascon permutation p^12 (rounds 0–11).
    /// </summary>
    /// <param name="s0">State word 0.</param>
    /// <param name="s1">State word 1.</param>
    /// <param name="s2">State word 2.</param>
    /// <param name="s3">State word 3.</param>
    /// <param name="s4">State word 4.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
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

    /// <summary>
    /// Applies a single Ascon round with the specified round constant.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Round(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4, ulong c)
    {
        // Addition of constants
        ulong sx = s2 ^ c;

        // Pre-compute common subexpressions
        ulong s1_x_sx = s1 ^ sx;
        ulong s1_x_s3 = s1 ^ s3;
        ulong s0_x_sx = s0 ^ sx;
        ulong s3_x_s4 = s3 ^ s4;

        // Interleaved substitution layer with precomputed operations
        ulong t0 = s0_x_sx ^ s1_x_s3 ^ (s1 & (s0_x_sx ^ s4));
        ulong t1 = s0_x_sx ^ s3_x_s4 ^ (s1_x_sx & s1_x_s3);
        ulong t2 = s1_x_sx ^ s4 ^ (s3 & s4);
        ulong t3 = s0_x_sx ^ s1 ^ (~s0 & s3_x_s4);
        ulong t4 = s1_x_s3 ^ s4 ^ ((s0 ^ s4) & s1);

        // Linear diffusion layer
        s0 = t0 ^ BitOperations.RotateRight(t0, 19) ^ BitOperations.RotateRight(t0, 28);
        s1 = t1 ^ BitOperations.RotateRight(t1, 39) ^ BitOperations.RotateRight(t1, 61);
        s2 = ~(t2 ^ BitOperations.RotateRight(t2, 1) ^ BitOperations.RotateRight(t2, 6));
        s3 = t3 ^ BitOperations.RotateRight(t3, 10) ^ BitOperations.RotateRight(t3, 17);
        s4 = t4 ^ BitOperations.RotateRight(t4, 7) ^ BitOperations.RotateRight(t4, 41);
    }
}
