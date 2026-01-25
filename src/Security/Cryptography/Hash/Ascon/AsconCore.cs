// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System.Numerics;
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
internal static class AsconCore
{
    /// <summary>
    /// Applies the Ascon permutation p^12.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
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
        s0 = t0 ^ BitOperations.RotateRight(t0, 19) ^ BitOperations.RotateRight(t0, 28);
        s1 = t1 ^ BitOperations.RotateRight(t1, 39) ^ BitOperations.RotateRight(t1, 61);
        s2 = ~(t2 ^ BitOperations.RotateRight(t2, 1) ^ BitOperations.RotateRight(t2, 6));
        s3 = t3 ^ BitOperations.RotateRight(t3, 10) ^ BitOperations.RotateRight(t3, 17);
        s4 = t4 ^ BitOperations.RotateRight(t4, 7) ^ BitOperations.RotateRight(t4, 41);
    }
}
