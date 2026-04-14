// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER && EXPERIMENTAL

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE2b ARM NEON-accelerated compression.
/// </summary>
/// <remarks>
/// <para>
/// All 16 message words are pre-loaded as 8 <see cref="Vector128{T}"/> pairs via
/// <c>AdvSimd.LoadVector128</c>, then each of the 12 fully-unrolled rounds builds
/// its message input vectors using single-cycle <c>ZipLow</c>, <c>ZipHigh</c>,
/// <c>ExtractVector128</c>, and <c>InsertSelectedScalar</c> operations.
/// </para>
/// </remarks>
public sealed partial class Blake2b : HashAlgorithm
{
    // Byte-shuffle masks for 64-bit word rotations within a 128-bit register (2 × ulong).
    // ror64(v, 24): for each 8-byte group: [b3,b4,b5,b6,b7,b0,b1,b2]
    private static readonly Vector128<byte> s_neonRotMask24 = Vector128.Create(
        (byte)3, 4, 5, 6, 7, 0, 1, 2, 11, 12, 13, 14, 15, 8, 9, 10);

    // ror64(v, 16): for each 8-byte group: [b2,b3,b4,b5,b6,b7,b0,b1]
    private static readonly Vector128<byte> s_neonRotMask16 = Vector128.Create(
        (byte)2, 3, 4, 5, 6, 7, 0, 1, 10, 11, 12, 13, 14, 15, 8, 9);

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressNeon(byte* bp, ulong* state, ulong bytesCompressed, bool isFinal)
    {
        // Load state from the shared _state[] array (same layout as AVX2 path)
        var r0L = AdvSimd.LoadVector128(state);
        var r0H = AdvSimd.LoadVector128(state + 2);
        var r1L = AdvSimd.LoadVector128(state + 4);
        var r1H = AdvSimd.LoadVector128(state + 6);

        var r2L = Vector128.Create(IV[0], IV[1]);
        var r2H = Vector128.Create(IV[2], IV[3]);
        var r3L = Vector128.Create(IV[4] ^ bytesCompressed, IV[5]);
        var r3H = Vector128.Create(isFinal ? IV[6] ^ ~0UL : IV[6], IV[7]);

        // Save original state for finalization
        var orig0L = r0L;
        var orig0H = r0H;
        var orig1L = r1L;
        var orig1H = r1H;

        // Pre-load all 16 message words as 8 vector pairs via direct 128-bit loads.
        // m_i = [w_{2i}, w_{2i+1}] — ARM64 .NET is always little-endian.
        ulong* mp = (ulong*)bp;
        var m0 = AdvSimd.LoadVector128(mp);
        var m1 = AdvSimd.LoadVector128(mp + 2);
        var m2 = AdvSimd.LoadVector128(mp + 4);
        var m3 = AdvSimd.LoadVector128(mp + 6);
        var m4 = AdvSimd.LoadVector128(mp + 8);
        var m5 = AdvSimd.LoadVector128(mp + 10);
        var m6 = AdvSimd.LoadVector128(mp + 12);
        var m7 = AdvSimd.LoadVector128(mp + 14);

        // 12 rounds, fully unrolled. Rounds 11/12 reuse rounds 1/2 via loop.
        // Message scheduling uses single-cycle NEON shuffles:
        //   ZipLow(a,b)  → [a0, b0]    ZipHigh(a,b)       → [a1, b1]
        //   Ext(a,b,#8)  → [a1, b0]    Ins(a,1,b,1)       → [a0, b1]
        bool step11and12 = false;
        while (true)
        {
            // Round 1/11 — sigma: 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m0, m1), AdvSimd.Arm64.ZipLow(m2, m3));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m0, m1), AdvSimd.Arm64.ZipHigh(m2, m3));
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m4, m5), AdvSimd.Arm64.ZipLow(m6, m7));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m4, m5), AdvSimd.Arm64.ZipHigh(m6, m7));
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 2/12 — sigma: 14,10,4,8,9,15,13,6,1,12,0,2,11,7,5,3
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m7, m2), AdvSimd.Arm64.ZipHigh(m4, m6));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m5, m4),
                AdvSimd.ExtractVector128(m7.AsByte(), m3.AsByte(), 8).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.ExtractVector128(m0.AsByte(), m0.AsByte(), 8).AsUInt64(),
                AdvSimd.Arm64.ZipHigh(m5, m2));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m6, m1), AdvSimd.Arm64.ZipHigh(m3, m1));
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // exit if second round processed step 11 and 12
            if (step11and12)
            {
                break;
            }

            // Round 3 — sigma: 11,8,12,0,5,2,15,13,10,14,3,6,7,1,9,4
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.ExtractVector128(m5.AsByte(), m6.AsByte(), 8).AsUInt64(),
                AdvSimd.Arm64.ZipHigh(m2, m7));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m4, m0),
                AdvSimd.Arm64.InsertSelectedScalar(m1.AsInt64(), 1, m6.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m5.AsInt64(), 1, m1.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.ZipHigh(m3, m4));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m7, m3),
                AdvSimd.ExtractVector128(m0.AsByte(), m2.AsByte(), 8).AsUInt64());
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 4 — sigma: 7,9,3,1,13,12,11,14,2,6,5,10,4,0,15,8
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m3, m1), AdvSimd.Arm64.ZipHigh(m6, m5));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m4, m0), AdvSimd.Arm64.ZipLow(m6, m7));
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m1.AsInt64(), 1, m2.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.InsertSelectedScalar(m2.AsInt64(), 1, m7.AsInt64(), 1).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m3, m5), AdvSimd.Arm64.ZipLow(m0, m4));
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 5 — sigma: 9,0,5,7,2,4,10,15,14,1,11,12,6,8,3,13
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m4, m2), AdvSimd.Arm64.ZipLow(m1, m5));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m0.AsInt64(), 1, m3.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.InsertSelectedScalar(m2.AsInt64(), 1, m7.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m7.AsInt64(), 1, m5.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.InsertSelectedScalar(m3.AsInt64(), 1, m1.AsInt64(), 1).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.ExtractVector128(m0.AsByte(), m6.AsByte(), 8).AsUInt64(),
                AdvSimd.Arm64.InsertSelectedScalar(m4.AsInt64(), 1, m6.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 6 — sigma: 2,12,6,10,0,11,8,3,4,13,7,5,15,14,1,9
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m1, m3), AdvSimd.Arm64.ZipLow(m0, m4));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m6, m5), AdvSimd.Arm64.ZipHigh(m5, m1));
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m2.AsInt64(), 1, m3.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.ZipHigh(m7, m0));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m6, m2),
                AdvSimd.Arm64.InsertSelectedScalar(m7.AsInt64(), 1, m4.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 7 — sigma: 12,5,1,15,14,13,4,10,0,7,6,3,9,2,8,11
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m6.AsInt64(), 1, m0.AsInt64(), 1).AsUInt64(),
                AdvSimd.Arm64.ZipLow(m7, m2));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m2, m7),
                AdvSimd.ExtractVector128(m6.AsByte(), m5.AsByte(), 8).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m0, m3),
                AdvSimd.ExtractVector128(m4.AsByte(), m4.AsByte(), 8).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m3, m1),
                AdvSimd.Arm64.InsertSelectedScalar(m1.AsInt64(), 1, m5.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 8 — sigma: 13,11,7,14,12,1,3,9,5,0,15,4,8,6,2,10
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m6, m3),
                AdvSimd.Arm64.InsertSelectedScalar(m6.AsInt64(), 1, m1.AsInt64(), 1).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.ExtractVector128(m5.AsByte(), m7.AsByte(), 8).AsUInt64(),
                AdvSimd.Arm64.ZipHigh(m0, m4));
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m2, m7), AdvSimd.Arm64.ZipLow(m4, m1));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m0, m2), AdvSimd.Arm64.ZipLow(m3, m5));
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 9 — sigma: 6,15,14,9,11,3,0,8,12,2,13,7,1,4,10,5
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m3, m7),
                AdvSimd.ExtractVector128(m5.AsByte(), m0.AsByte(), 8).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m7, m4),
                AdvSimd.ExtractVector128(m1.AsByte(), m4.AsByte(), 8).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                m6,
                AdvSimd.ExtractVector128(m0.AsByte(), m5.AsByte(), 8).AsUInt64());
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.InsertSelectedScalar(m1.AsInt64(), 1, m3.AsInt64(), 1).AsUInt64(),
                m2);
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            // Round 10 — sigma: 10,2,8,4,7,6,1,5,15,11,9,14,3,12,13,0
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m5, m4), AdvSimd.Arm64.ZipHigh(m3, m0));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipLow(m1, m2),
                AdvSimd.Arm64.InsertSelectedScalar(m3.AsInt64(), 1, m2.AsInt64(), 1).AsUInt64());
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.Arm64.ZipHigh(m7, m4), AdvSimd.Arm64.ZipHigh(m1, m6));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H,
                AdvSimd.ExtractVector128(m5.AsByte(), m7.AsByte(), 8).AsUInt64(),
                AdvSimd.Arm64.ZipLow(m6, m0));
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);

            step11and12 = true;
        }

        // Finalize: state[i] ^= v[i] ^ v[i+8]
        r0L = AdvSimd.Xor(AdvSimd.Xor(r0L, r2L), orig0L);
        r0H = AdvSimd.Xor(AdvSimd.Xor(r0H, r2H), orig0H);
        r1L = AdvSimd.Xor(AdvSimd.Xor(r1L, r3L), orig1L);
        r1H = AdvSimd.Xor(AdvSimd.Xor(r1H, r3H), orig1H);

        AdvSimd.Store(state, r0L);
        AdvSimd.Store(state + 2, r0H);
        AdvSimd.Store(state + 4, r1L);
        AdvSimd.Store(state + 6, r1H);
    }

    /// <summary>
    /// Performs one Gx half-round: <c>a += b + x; d = ror(d^a, 32); c += d; b = ror(b^c, 24)</c>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundXNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH,
        ref Vector128<ulong> dL, ref Vector128<ulong> dH,
        Vector128<ulong> xL, Vector128<ulong> xH)
    {
        aL = AdvSimd.Add(aL, AdvSimd.Add(bL, xL));
        aH = AdvSimd.Add(aH, AdvSimd.Add(bH, xH));
        // ror64(d ^ a, 32) — single REV64.4S instruction
        dL = AdvSimd.ReverseElement32((dL ^ aL).AsInt64()).AsUInt64();
        dH = AdvSimd.ReverseElement32((dH ^ aH).AsInt64()).AsUInt64();
        cL = AdvSimd.Add(cL, dL);
        cH = AdvSimd.Add(cH, dH);
        // ror64(b ^ c, 24) — TBL byte shuffle
        bL = AdvSimd.Arm64.VectorTableLookup((bL ^ cL).AsByte(), s_neonRotMask24).AsUInt64();
        bH = AdvSimd.Arm64.VectorTableLookup((bH ^ cH).AsByte(), s_neonRotMask24).AsUInt64();
    }

    /// <summary>
    /// Performs one Gy half-round: <c>a += b + y; d = ror(d^a, 16); c += d; b = ror(b^c, 63)</c>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    [SuppressMessage("Performance", "CA1857:A constant is expected for the parameter", Justification = "False negative due to bug in .NET 8 runtime metadata.")]
    private static void GRoundYNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH,
        ref Vector128<ulong> dL, ref Vector128<ulong> dH,
        Vector128<ulong> yL, Vector128<ulong> yH)
    {
        aL = AdvSimd.Add(aL, AdvSimd.Add(bL, yL));
        aH = AdvSimd.Add(aH, AdvSimd.Add(bH, yH));
        // ror64(d ^ a, 16) — TBL byte shuffle
        dL = AdvSimd.Arm64.VectorTableLookup((dL ^ aL).AsByte(), s_neonRotMask16).AsUInt64();
        dH = AdvSimd.Arm64.VectorTableLookup((dH ^ aH).AsByte(), s_neonRotMask16).AsUInt64();
        cL = AdvSimd.Add(cL, dL);
        cH = AdvSimd.Add(cH, dH);
        // ror64(b ^ c, 63) — shift + add (add(t,t) == shl(t,1))
        var tL = bL ^ cL;
        var tH = bH ^ cH;
        bL = AdvSimd.Or(AdvSimd.ShiftRightLogical(tL, 63), AdvSimd.Add(tL, tL));
        bH = AdvSimd.Or(AdvSimd.ShiftRightLogical(tH, 63), AdvSimd.Add(tH, tH));
    }

    /// <summary>
    /// Performs the BLAKE2b diagonal permutation on three rows, each split into lo/hi halves.
    /// </summary>
    /// <remarks>
    /// Given a logical row <c>[e0, e1, e2, e3]</c> with lo=<c>[e0,e1]</c> and hi=<c>[e2,e3]</c>:
    /// <list type="bullet">
    ///   <item><description>a: rotate left 1 → <c>[e1, e2, e3, e0]</c></description></item>
    ///   <item><description>b: swap halves → <c>[e2, e3, e0, e1]</c></description></item>
    ///   <item><description>c: rotate right 1 → <c>[e3, e0, e1, e2]</c></description></item>
    /// </list>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PermuteNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH)
    {
        var newAL = AdvSimd.ExtractVector128(aL.AsByte(), aH.AsByte(), 8).AsUInt64();
        var newAH = AdvSimd.ExtractVector128(aH.AsByte(), aL.AsByte(), 8).AsUInt64();
        aL = newAL;
        aH = newAH;

        (bL, bH) = (bH, bL);

        var newCL = AdvSimd.ExtractVector128(cH.AsByte(), cL.AsByte(), 8).AsUInt64();
        var newCH = AdvSimd.ExtractVector128(cL.AsByte(), cH.AsByte(), 8).AsUInt64();
        cL = newCL;
        cH = newCH;
    }
}

#endif
