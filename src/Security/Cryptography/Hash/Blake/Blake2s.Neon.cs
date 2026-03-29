// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE2s ARM NEON-accelerated compression using AdvSimd intrinsics.
/// </summary>
public sealed partial class Blake2s
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void InitializeStateNeon(uint paramBlock)
    {
        // Reuses Vector128<uint> state fields declared in Blake2s.Simd.cs.
        _stateVec0 = IVLow ^ Vector128.Create(paramBlock, 0U, 0U, 0U);
        _stateVec1 = IVHigh;
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void CompressNeon(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // row0 = v[0..3] = state[0..3], row1 = v[4..7] = state[4..7]
        // row2 = v[8..11] = IV[0..3],   row3 = v[12..15] = IV[4..7] + counter
        var row0 = _stateVec0;
        var row1 = _stateVec1;
        var row2 = IVLow;

        var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
        var row3 = IVHigh ^ counterVec;
        if (isFinal)
            row3 ^= FinalMask;

        // Parse message block into 16 little-endian 32-bit words
        // (ARM64 is always little-endian, so no byte-swapping needed)
        Span<uint> m = stackalloc uint[ScratchSize];
        BinarySpans.ReadUInt32LittleEndian(block, m);

        ref byte sigmaBase = ref MemoryMarshal.GetArrayDataReference(Sigma);
        ref uint mBase = ref MemoryMarshal.GetReference(m);

        // 10 rounds of mixing
        for (int sigmaIdx = 0; sigmaIdx < Rounds * ScratchSize; sigmaIdx += ScratchSize)
        {
            // Column step
            var mx0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 0)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 2)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 4)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 6)));
            var my0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 1)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 3)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 5)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 7)));

            GRoundNeon(ref row0, ref row1, ref row2, ref row3, mx0, my0);

            // Diagonal step: rotate rows to align diagonals.
            // AdvSimd.ExtractVector128(v, v, n) extracts 16 bytes starting at byte-offset n
            // from the 32-byte concatenation [v, v], equivalent to Sse2.Shuffle with element rotation.
            row1 = AdvSimd.ExtractVector128(row1.AsByte(), row1.AsByte(), 4).AsUInt32();   // rotate left 1
            row2 = AdvSimd.ExtractVector128(row2.AsByte(), row2.AsByte(), 8).AsUInt32();   // swap halves
            row3 = AdvSimd.ExtractVector128(row3.AsByte(), row3.AsByte(), 12).AsUInt32();  // rotate right 1

            var mx1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 8)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 10)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 12)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 14)));
            var my1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 9)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 11)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 13)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 15)));

            GRoundNeon(ref row0, ref row1, ref row2, ref row3, mx1, my1);

            // Un-rotate rows to restore column order
            row1 = AdvSimd.ExtractVector128(row1.AsByte(), row1.AsByte(), 12).AsUInt32();  // rotate right 1
            row2 = AdvSimd.ExtractVector128(row2.AsByte(), row2.AsByte(), 8).AsUInt32();   // swap halves
            row3 = AdvSimd.ExtractVector128(row3.AsByte(), row3.AsByte(), 4).AsUInt32();   // rotate left 1
        }

        // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
        _stateVec0 ^= row0 ^ row2;
        _stateVec1 ^= row1 ^ row3;
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using ARM NEON intrinsics.
    /// </summary>
    /// <remarks>
    /// Uses NEON TBL (VectorTableLookup) for byte-aligned rotations (16, 8) and
    /// shift+or for non-byte-aligned rotations (12, 7). The shuffle masks
    /// <see cref="RotateMask16"/> and <see cref="RotateMask8"/> are identical for
    /// both PSHUFB (x86 SSSE3) and TBL (ARM NEON) on little-endian systems.
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
        // d = ror(d ^ a, 16) — TBL byte shuffle (same semantics as PSHUFB on little-endian)
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 12) — shift+or (12 is not byte-aligned)
        var t1 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t1, 12), AdvSimd.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = AdvSimd.Add(a, AdvSimd.Add(b, y));
        // d = ror(d ^ a, 8) — TBL byte shuffle
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 7) — shift+or (7 is not byte-aligned)
        var t2 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t2, 7), AdvSimd.ShiftLeftLogical(t2, 25));
    }
}

#endif
