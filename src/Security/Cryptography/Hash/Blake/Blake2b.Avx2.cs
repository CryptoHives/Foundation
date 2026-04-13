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
using System.Runtime.Intrinsics.X86;

/// <summary>
/// AVX2-accelerated BLAKE2b compression using preloaded message in vectors.
/// </summary>
/// <remarks>
/// All 16 message words are pre-loaded into 8 <see cref="Vector256{T}"/> registers via
/// <c>BroadcastVector128ToVector256</c>, then each of the 12 fully-unrolled rounds builds
/// its four input vectors using 1-cycle <c>UnpackLow/High</c>, <c>Blend</c>,
/// <c>AlignRight</c>, and <c>Shuffle</c> operations.
/// </remarks>
public sealed partial class Blake2b : HashAlgorithm
{
    // Pre-computed IV vectors for AVX2 path
    private static readonly Vector256<ulong> IVLow = Vector256.Create(
        0x6a09e667f3bcc908UL, 0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL, 0xa54ff53a5f1d36f1UL);

    private static readonly Vector256<ulong> IVHigh = Vector256.Create(
        0x510e527fade682d1UL, 0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL, 0x5be0cd19137e2179UL);

    // Finalization mask for inverting element 2 of row3
    private static readonly Vector256<ulong> FinalMask = Vector256.Create(0UL, 0UL, ~0UL, 0UL);

    // Pre-computed shuffle masks for byte-aligned rotations
    private static readonly Vector256<byte> RotateMask24 = Vector256.Create(
        (byte)3, 4, 5, 6, 7, 0, 1, 2,
        11, 12, 13, 14, 15, 8, 9, 10,
        19, 20, 21, 22, 23, 16, 17, 18,
        27, 28, 29, 30, 31, 24, 25, 26);

    private static readonly Vector256<byte> RotateMask16 = Vector256.Create(
        (byte)2, 3, 4, 5, 6, 7, 0, 1,
        10, 11, 12, 13, 14, 15, 8, 9,
        18, 19, 20, 21, 22, 23, 16, 17,
        26, 27, 28, 29, 30, 31, 24, 25);

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport
    {
        get
        {
            SimdSupport support = SimdSupport.None;
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
            if (AdvSimd.Arm64.IsSupported) support |= SimdSupport.Neon;
            return support;
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressAvx2(byte* msgPtr, ulong* state, ulong bytesCompressed, bool isFinal)
    {
        // Load state into vector registers
        Vector256<ulong> row1 = Avx.LoadVector256(state);
        Vector256<ulong> row2 = Avx.LoadVector256(state + Vector256<ulong>.Count);
        Vector256<ulong> row3 = IVLow;
        Vector256<ulong> row4 = Avx2.Xor(IVHigh, Vector256.Create(bytesCompressed, 0UL, 0UL, 0UL));

        if (isFinal)
        {
            row4 = Avx2.Xor(row4, FinalMask);
        }

        // Save original state for finalization
        Vector256<ulong> orig1 = row1;
        Vector256<ulong> orig2 = row2;

        // Pre-load all 16 message words as 8 broadcast Vector256<ulong> pairs.
        // Each m_i = [w_{2i}, w_{2i+1}, w_{2i}, w_{2i+1}] via vbroadcasti128.
        Vector256<ulong> m0 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr));
        Vector256<ulong> m1 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 1 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m2 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 2 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m3 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 3 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m4 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 4 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m5 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 5 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m6 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 6 * sizeof(Vector128<ulong>)));
        Vector256<ulong> m7 = Avx2.BroadcastVector128ToVector256((ulong*)(msgPtr + 7 * sizeof(Vector128<ulong>)));

        bool step11and12 = false;
        while (true)
        {
            Vector256<ulong> t0, t1, mx1, my1, mx2, my2;

            // ROUND 1/11 — Sigma: 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
            t0 = Avx2.UnpackLow(m0, m1);
            t1 = Avx2.UnpackLow(m2, m3);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m0, m1);
            t1 = Avx2.UnpackHigh(m2, m3);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m7, m4);
            t1 = Avx2.UnpackLow(m5, m6);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m7, m4);
            t1 = Avx2.UnpackHigh(m5, m6);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 2/12 — Sigma: 14,10,4,8,9,15,13,6,1,12,0,2,11,7,5,3
            t0 = Avx2.UnpackLow(m7, m2);
            t1 = Avx2.UnpackHigh(m4, m6);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m5, m4);
            t1 = Avx2.AlignRight(m3, m7, 8);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m2, m0);
            t1 = Avx2.Blend(m0.AsUInt32(), m5.AsUInt32(), 0xCC).AsUInt64();
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m6, m1, 8);
            t1 = Avx2.Blend(m1.AsUInt32(), m3.AsUInt32(), 0xCC).AsUInt64();
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // exit if second round processed step 11 and 12
            if (step11and12)
            {
                break;
            }

            // ROUND 3 — Sigma: 11,8,12,0,5,2,15,13,10,14,3,6,7,1,9,4
            t0 = Avx2.AlignRight(m6, m5, 8);
            t1 = Avx2.UnpackHigh(m2, m7);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m4, m0);
            t1 = Avx2.Blend(m1.AsUInt32(), m6.AsUInt32(), 0xCC).AsUInt64();
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m5, m4, 8);
            t1 = Avx2.UnpackHigh(m1, m3);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m2, m7);
            t1 = Avx2.Blend(m3.AsUInt32(), m0.AsUInt32(), 0xCC).AsUInt64();
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 4 — Sigma: 7,9,3,1,13,12,11,14,2,6,5,10,4,0,15,8
            t0 = Avx2.UnpackHigh(m3, m1);
            t1 = Avx2.UnpackHigh(m6, m5);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m4, m0);
            t1 = Avx2.UnpackLow(m6, m7);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m1, m7, 8);
            t1 = Avx2.Shuffle(m2.AsUInt32(), 0b_01_00_11_10).AsUInt64();
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m4, m3);
            t1 = Avx2.UnpackLow(m5, m0);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 5 — Sigma: 9,0,5,7,2,4,10,15,14,1,11,12,6,8,3,13
            t0 = Avx2.UnpackHigh(m4, m2);
            t1 = Avx2.UnpackLow(m1, m5);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.Blend(m0.AsUInt32(), m3.AsUInt32(), 0xCC).AsUInt64();
            t1 = Avx2.Blend(m2.AsUInt32(), m7.AsUInt32(), 0xCC).AsUInt64();
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m7, m1, 8);
            t1 = Avx2.AlignRight(m3, m5, 8);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m6, m0);
            t1 = Avx2.UnpackLow(m6, m4);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 6 — Sigma: 2,12,6,10,0,11,8,3,4,13,7,5,15,14,1,9
            t0 = Avx2.UnpackLow(m1, m3);
            t1 = Avx2.UnpackLow(m0, m4);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m6, m5);
            t1 = Avx2.UnpackHigh(m5, m1);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m2, m0, 8);
            t1 = Avx2.UnpackHigh(m3, m7);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m4, m6);
            t1 = Avx2.AlignRight(m7, m2, 8);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 7 — Sigma: 12,5,1,15,14,13,4,10,0,7,6,3,9,2,8,11
            t0 = Avx2.Blend(m6.AsUInt32(), m0.AsUInt32(), 0xCC).AsUInt64();
            t1 = Avx2.UnpackLow(m7, m2);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m2, m7);
            t1 = Avx2.AlignRight(m5, m6, 8);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m4, m0);
            t1 = Avx2.Blend(m3.AsUInt32(), m4.AsUInt32(), 0xCC).AsUInt64();
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m5, m3);
            t1 = Avx2.Shuffle(m1.AsUInt32(), 0b_01_00_11_10).AsUInt64();
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 8 — Sigma: 13,11,7,14,12,1,3,9,5,0,15,4,8,6,2,10
            t0 = Avx2.UnpackHigh(m6, m3);
            t1 = Avx2.Blend(m6.AsUInt32(), m1.AsUInt32(), 0xCC).AsUInt64();
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m7, m5, 8);
            t1 = Avx2.UnpackHigh(m0, m4);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.Blend(m1.AsUInt32(), m2.AsUInt32(), 0xCC).AsUInt64();
            t1 = Avx2.AlignRight(m4, m7, 8);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m5, m0);
            t1 = Avx2.UnpackLow(m2, m3);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 9 — Sigma: 6,15,14,9,11,3,0,8,12,2,13,7,1,4,10,5
            t0 = Avx2.UnpackLow(m3, m7);
            t1 = Avx2.AlignRight(m0, m5, 8);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m7, m4);
            t1 = Avx2.AlignRight(m4, m1, 8);
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m5, m6);
            t1 = Avx2.UnpackHigh(m6, m0);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.AlignRight(m1, m2, 8);
            t1 = Avx2.AlignRight(m2, m3, 8);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            // ROUND 10 — Sigma: 10,2,8,4,7,6,1,5,15,11,9,14,3,12,13,0
            t0 = Avx2.UnpackLow(m5, m4);
            t1 = Avx2.UnpackHigh(m3, m0);
            mx1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackLow(m1, m2);
            t1 = Avx2.Blend(m3.AsUInt32(), m2.AsUInt32(), 0xCC).AsUInt64();
            my1 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.UnpackHigh(m6, m7);
            t1 = Avx2.UnpackHigh(m4, m1);
            mx2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            t0 = Avx2.Blend(m0.AsUInt32(), m5.AsUInt32(), 0xCC).AsUInt64();
            t1 = Avx2.UnpackLow(m7, m6);
            my2 = Avx2.Blend(t0.AsUInt32(), t1.AsUInt32(), 0xF0).AsUInt64();
            GRound(ref row1, ref row2, ref row3, ref row4, mx1, my1, mx2, my2);

            step11and12 = true;
        }

        // Finalize: state ^= rows ^ IV rows
        row1 = Avx2.Xor(row1, row3);
        row2 = Avx2.Xor(row2, row4);
        row1 = Avx2.Xor(row1, orig1);
        row2 = Avx2.Xor(row2, orig2);

        Avx.Store(state, row1);
        Avx.Store(state + Vector256<ulong>.Count, row2);
    }

    /// <summary>
    /// Performs one full BLAKE2b round (column step + diagonal step) using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRound(
        ref Vector256<ulong> row1, ref Vector256<ulong> row2,
        ref Vector256<ulong> row3, ref Vector256<ulong> row4,
        Vector256<ulong> mx1, Vector256<ulong> my1,
        Vector256<ulong> mx2, Vector256<ulong> my2)
    {
        // Column step
        GRoundX(ref row1, ref row2, ref row3, ref row4, mx1);
        GRoundY(ref row1, ref row2, ref row3, ref row4, my1);

        // Diagonalize
        Permute(ref row3, ref row4, ref row1);

        // Diagonal step
        GRoundX(ref row1, ref row2, ref row3, ref row4, mx2);
        GRoundY(ref row1, ref row2, ref row3, ref row4, my2);

        // Un-diagonalize — reverse the shifts
        Permute(ref row1, ref row4, ref row3);
    }

    /// <summary>
    /// Performs one Gx round on 4 parallel lanes using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundX(
        ref Vector256<ulong> a,
        ref Vector256<ulong> b,
        ref Vector256<ulong> c,
        ref Vector256<ulong> d,
        Vector256<ulong> x)
    {
        // a = a + b + x
        a = Avx2.Add(b, Avx2.Add(a, x));
        // d = ror(d ^ a, 32)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsUInt32(), 0b_10_11_00_01).AsUInt64();

        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 24)
        b = Avx2.Shuffle(Avx2.Xor(b, c).AsByte(), RotateMask24).AsUInt64();
    }

    /// <summary>
    /// Performs one Gy round on 4 parallel lanes using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundY(
        ref Vector256<ulong> a,
        ref Vector256<ulong> b,
        ref Vector256<ulong> c,
        ref Vector256<ulong> d,
        Vector256<ulong> y)
    {
        // a = a + b + y
        a = Avx2.Add(b, Avx2.Add(a, y));
        // d = ror(d ^ a, 16)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), RotateMask16).AsUInt64();

        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 63) - must use shift+or
        var t = Avx2.Xor(b, c);
        b = Avx2.Or(Avx2.ShiftRightLogical(t, 63), Avx2.Add(t, t));
    }

    /// <summary>
    /// Performs diagonal permutations.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Permute(ref Vector256<ulong> a, ref Vector256<ulong> b, ref Vector256<ulong> c)
    {
        a = Avx2.Permute4x64(a, 0b00_11_10_01);
        b = Avx2.Permute4x64(b, 0b01_00_11_10);
        c = Avx2.Permute4x64(c, 0b10_01_00_11);
    }
}
#endif
