// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE3 ARM NEON-accelerated compression using AdvSimd intrinsics.
/// </summary>
public sealed partial class Blake3 : HashAlgorithm
{
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void CompressBlockNeon(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags)
    {
        // ARM64 is always little-endian; cast directly — no copy needed
        ReadOnlySpan<uint> m = MemoryMarshal.Cast<byte, uint>(block);

        var row0 = Vector128.Create<uint>(_cv.AsSpan(0, 4));
        var row1 = Vector128.Create<uint>(_cv.AsSpan(4, 4));
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);

        GRoundsNeon(m, ref row0, ref row1, ref row2, ref row3);

        (row0 ^ row2).CopyTo(_cv.AsSpan(0, 4));
        (row1 ^ row3).CopyTo(_cv.AsSpan(4, 4));
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlockNeon(ulong counter, Span<byte> destination)
    {
        ReadOnlySpan<uint> m = _rootBlock;
        var row0 = Vector128.Create<uint>(_rootCv.AsSpan(0, 4));
        var row1 = Vector128.Create<uint>(_rootCv.AsSpan(4, 4));
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), _rootBlockLen, _rootFlags);

        GRoundsNeon(m, ref row0, ref row1, ref row2, ref row3);

        // Full 16-word output (ARM64 is always little-endian)
        (row0 ^ row2).AsByte().CopyTo(destination);
        (row1 ^ row3).AsByte().CopyTo(destination.Slice(16));
        (row2 ^ Vector128.Create<uint>(_rootCv.AsSpan(0, 4))).AsByte().CopyTo(destination.Slice(32));
        (row3 ^ Vector128.Create<uint>(_rootCv.AsSpan(4, 4))).AsByte().CopyTo(destination.Slice(48));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void GRoundsNeon(
        ReadOnlySpan<uint> m,
        ref Vector128<uint> row0,
        ref Vector128<uint> row1,
        ref Vector128<uint> row2,
        ref Vector128<uint> row3)
    {
        // 7 rounds of mixing with BLAKE3's fixed message schedule
        // Round 1: 0,1,2,3,4,5,6,7 | 8,9,10,11,12,13,14,15
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[0], m[2], m[4], m[6]),
            Vector128.Create(m[1], m[3], m[5], m[7]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[8], m[10], m[12], m[14]),
            Vector128.Create(m[9], m[11], m[13], m[15]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 2: 2,6,3,10,7,0,4,13 | 1,11,12,5,9,14,15,8
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[2], m[3], m[7], m[4]),
            Vector128.Create(m[6], m[10], m[0], m[13]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[1], m[12], m[9], m[15]),
            Vector128.Create(m[11], m[5], m[14], m[8]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 3: 3,4,10,12,13,2,7,14 | 6,5,9,0,11,15,8,1
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[3], m[10], m[13], m[7]),
            Vector128.Create(m[4], m[12], m[2], m[14]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[6], m[9], m[11], m[8]),
            Vector128.Create(m[5], m[0], m[15], m[1]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 4: 10,7,12,9,14,3,13,15 | 4,0,11,2,5,8,1,6
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[10], m[12], m[14], m[13]),
            Vector128.Create(m[7], m[9], m[3], m[15]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[4], m[11], m[5], m[1]),
            Vector128.Create(m[0], m[2], m[8], m[6]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 5: 12,13,9,11,15,10,14,8 | 7,2,5,3,0,1,6,4
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[12], m[9], m[15], m[14]),
            Vector128.Create(m[13], m[11], m[10], m[8]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[7], m[5], m[0], m[6]),
            Vector128.Create(m[2], m[3], m[1], m[4]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 6: 9,14,11,5,8,12,15,1 | 13,3,0,10,2,6,4,7
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[9], m[11], m[8], m[15]),
            Vector128.Create(m[14], m[5], m[12], m[1]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[13], m[0], m[2], m[4]),
            Vector128.Create(m[3], m[10], m[6], m[7]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);

        // Round 7: 11,15,5,0,1,9,8,6 | 14,10,2,12,3,4,7,13
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[11], m[5], m[1], m[8]),
            Vector128.Create(m[15], m[0], m[9], m[6]));
        DiagPermuteNeon(ref row1, ref row2, ref row3);
        GRoundNeon(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[14], m[2], m[3], m[7]),
            Vector128.Create(m[10], m[12], m[4], m[13]));
        DiagPermuteNeon(ref row3, ref row2, ref row1);
    }

    /// <summary>
    /// Performs diagonal permutations using ARM NEON ExtractVector128 in place of Sse2.Shuffle.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermuteNeon(ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        // ExtractVector128(v, v, n) extracts bytes[n..n+15] from concat([v,v]),
        // giving element rotation by (n/4) positions.
        row1 = AdvSimd.ExtractVector128(row1.AsByte(), row1.AsByte(), 4).AsUInt32();   // rotate left 1
        row2 = AdvSimd.ExtractVector128(row2.AsByte(), row2.AsByte(), 8).AsUInt32();   // swap halves
        row3 = AdvSimd.ExtractVector128(row3.AsByte(), row3.AsByte(), 12).AsUInt32();  // rotate right 1
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using ARM NEON intrinsics.
    /// </summary>
    /// <remarks>
    /// Uses NEON TBL (VectorTableLookup) for byte-aligned rotations (16, 8) and
    /// shift+or for non-byte-aligned rotations (12, 7). The shuffle masks
    /// <see cref="RotateMask16"/> and <see cref="RotateMask8"/> are shared with the
    /// SSSE3 path; they have identical semantics for PSHUFB and TBL on little-endian.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundNeon(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = AdvSimd.Add(a, AdvSimd.Add(b, x));
        // d = ror(d ^ a, 16) — TBL byte shuffle
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 12) — shift+or (not byte-aligned)
        var t1 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t1, 12), AdvSimd.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = AdvSimd.Add(a, AdvSimd.Add(b, y));
        // d = ror(d ^ a, 8) — TBL byte shuffle
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 7) — shift+or (not byte-aligned)
        var t2 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t2, 7), AdvSimd.ShiftLeftLogical(t2, 25));
    }
}

#endif
