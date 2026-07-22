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
internal unsafe partial struct Blake3State
{
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlocksNeon(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
        var row0 = AdvSimd.LoadVector128(cv);
        var row1 = AdvSimd.LoadVector128(cv + 4);
        var row2Seed = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);
        var row3Seed = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags & ~FlagChunkStart);

        while (blocks-- > 0)
        {
            var row2 = row2Seed;

            uint* m = (uint*)block;
            GRoundsNeon(m, ref row0, ref row1, ref row2, ref row3);

            row0 ^= row2;
            row1 ^= row3;

            block += blockLen;
            flags &= ~FlagChunkStart;
            
            row3 = row3Seed;
        }

        AdvSimd.Store(cv, row0);
        AdvSimd.Store(cv + 4, row1);
    }

    /// <summary>
    /// Squeezes one or more independent, consecutive output blocks directly into
    /// <paramref name="dst"/> in one call — <paramref name="blocks"/> = 1
    /// serves the single-block callers (initial priming, look-ahead), since
    /// <c>_rootCv</c> is loaded once regardless of the batch size.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocksNeon(Blake3State* core, ulong startCounter, int blocks, byte* dst)
    {
        uint* m = core->_rootBlock;
        // _rootCv is invariant across every block in the batch — load once
        // and reuse both as the row0/row1 seed and the final-xor operand,
        // instead of reloading it from memory on every iteration.
        var cvLow = AdvSimd.LoadVector128(core->_rootCv);
        var cvHigh = AdvSimd.LoadVector128(core->_rootCv + 4);
        uint blockLen = _rootBlockLen;
        uint flags = _rootFlags;

        // Raw pointer stores instead of Span.Slice/CopyTo: the caller always
        // sizes destination to exactly blocks * BlockSizeBytes, but that
        // guarantee isn't visible across the call boundary, so Slice would
        // otherwise re-check bounds on every store of every block.
        for (int i = 0; i < blocks; i++)
        {
            ulong counter = startCounter + (ulong)i;
            var row0 = cvLow;
            var row1 = cvHigh;
            var row2 = IVLow;
            var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);

            GRoundsNeon(m, ref row0, ref row1, ref row2, ref row3);

            byte* blockDest = dst + i * BlockSizeBytes;
            AdvSimd.Store(blockDest, (row0 ^ row2).AsByte());
            AdvSimd.Store(blockDest + 16, (row1 ^ row3).AsByte());
            AdvSimd.Store(blockDest + 32, (row2 ^ cvLow).AsByte());
            AdvSimd.Store(blockDest + 48, (row3 ^ cvHigh).AsByte());
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundsNeon(
        uint* m,
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
