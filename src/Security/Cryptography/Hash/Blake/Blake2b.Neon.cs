// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE2b ARM NEON-accelerated compression using AdvSimd intrinsics.
/// </summary>
/// <remarks>
/// NEON provides only 128-bit registers, so each logical row is split into a lo half
/// (elements 0–1) and a hi half (elements 2–3).
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

    // IV split into four 128-bit halves (lo = elements 0–1, hi = elements 2–3 of each 256-bit row)
    private static readonly Vector128<ulong> s_ivNeon0 = Vector128.Create(   // IVLow[0..1]
        0x6a09e667f3bcc908UL, 0xbb67ae8584caa73bUL);

    private static readonly Vector128<ulong> s_ivNeon1 = Vector128.Create(   // IVLow[2..3]
        0x3c6ef372fe94f82bUL, 0xa54ff53a5f1d36f1UL);

    private static readonly Vector128<ulong> s_ivNeon2 = Vector128.Create(   // IVHigh[0..1]
        0x510e527fade682d1UL, 0x9b05688c2b3e6c1fUL);

    private static readonly Vector128<ulong> s_ivNeon3 = Vector128.Create(   // IVHigh[2..3]
        0x1f83d9abfb41bd6bUL, 0x5be0cd19137e2179UL);

    // Finalization mask: inverts element 0 of s_ivNeon3 (corresponds to v[14] = ~IV[6])
    private static readonly Vector128<ulong> s_neonFinalMask = Vector128.Create(~0UL, 0UL);

    // NEON vector state: 8 ulong words split as four 128-bit pairs
    private Vector128<ulong> _neonState0;  // state[0..1]
    private Vector128<ulong> _neonState1;  // state[2..3]
    private Vector128<ulong> _neonState2;  // state[4..5]
    private Vector128<ulong> _neonState3;  // state[6..7]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void InitializeStateNeon(ulong paramBlock)
    {
        _neonState0 = s_ivNeon0 ^ Vector128.Create(paramBlock, 0UL);
        _neonState1 = s_ivNeon1;
        _neonState2 = s_ivNeon2;
        _neonState3 = s_ivNeon3;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ExtractOutputNeon(Span<byte> destination)
    {
        // Store NEON vector state to a stack buffer, then copy required bytes.
        Span<ulong> temp = stackalloc ulong[8];
        _neonState0.CopyTo(temp[..2]);
        _neonState1.CopyTo(temp[2..4]);
        _neonState2.CopyTo(temp[4..6]);
        _neonState3.CopyTo(temp[6..]);

        int fullWords = _outputBytes / 8;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * sizeof(UInt64)), temp[i]);
        }

        int remainingBytes = _outputBytes & 7;
        if (remainingBytes > 0)
        {
            Span<byte> tempBytes = stackalloc byte[sizeof(UInt64)];
            BinaryPrimitives.WriteUInt64LittleEndian(tempBytes, temp[fullWords]);
            tempBytes.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(UInt64)));
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void CompressNeon(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Each logical 256-bit row is split into lo (elements 0–1) and hi (elements 2–3).
        // row0 = v[0..3] = state[0..7], row2 = v[8..11] = IV[0..3], row3 = v[12..15] = IV[4..7] + counter
        Vector128<ulong> r0L = _neonState0;
        Vector128<ulong> r0H = _neonState1;
        Vector128<ulong> r1L = _neonState2;
        Vector128<ulong> r1H = _neonState3;
        Vector128<ulong> r2L = s_ivNeon0;
        Vector128<ulong> r2H = s_ivNeon1;
        Vector128<ulong> r3L = s_ivNeon2 ^ Vector128.Create(_bytesCompressed, 0UL);
        Vector128<ulong> r3H = isFinal ? s_ivNeon3 ^ s_neonFinalMask : s_ivNeon3;

        // Parse message block into 16 little-endian 64-bit words
        Span<ulong> m = stackalloc ulong[ScratchSize];
        BinarySpans.ReadUInt64LittleEndian(block, m);

        ref byte sigmaBase = ref MemoryMarshal.GetArrayDataReference(Sigma);
        ref ulong mBase = ref MemoryMarshal.GetReference(m);

        // 12 rounds of mixing
        for (int sigmaIdx = 0; sigmaIdx < Rounds * ScratchSize; sigmaIdx += ScratchSize)
        {
            // Column X step: load m[sigma[0]], m[sigma[2]], m[sigma[4]], m[sigma[6]]
            var mxL = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 0)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 2)));
            var mxH = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 4)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 6)));
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H, mxL, mxH);

            // Column Y step: load m[sigma[1]], m[sigma[3]], m[sigma[5]], m[sigma[7]]
            var myL = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 1)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 3)));
            var myH = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 5)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 7)));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H, myL, myH);

            // Diagonal permutation: Permute(row1, row2, row3)
            PermuteNeon(ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H);

            // Diagonal X step: load m[sigma[8]], m[sigma[10]], m[sigma[12]], m[sigma[14]]
            mxL = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 8)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 10)));
            mxH = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 12)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 14)));
            GRoundXNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H, mxL, mxH);

            // Diagonal Y step: load m[sigma[9]], m[sigma[11]], m[sigma[13]], m[sigma[15]]
            myL = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 9)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 11)));
            myH = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 13)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 15)));
            GRoundYNeon(ref r0L, ref r0H, ref r1L, ref r1H, ref r2L, ref r2H, ref r3L, ref r3H, myL, myH);

            // Un-permute: Permute(row3, row2, row1)
            PermuteNeon(ref r3L, ref r3H, ref r2L, ref r2H, ref r1L, ref r1H);
        }

        // Finalize: state[i] ^= v[i] ^ v[i+8]
        _neonState0 ^= r0L ^ r2L;
        _neonState1 ^= r0H ^ r2H;
        _neonState2 ^= r1L ^ r3L;
        _neonState3 ^= r1H ^ r3H;
    }

    /// <summary>
    /// Performs one Gx half-round on 4 parallel 64-bit lanes split across 128-bit NEON registers.
    /// </summary>
    /// <remarks>
    /// Each logical 256-bit row is represented as (L, H): two <see cref="Vector128{T}"/> holding
    /// elements 0–1 and 2–3 respectively.
    /// <list type="bullet">
    ///   <item><description><c>a += b + x; d = ror64(d^a, 32)</c></description></item>
    ///   <item><description><c>c += d; b = ror64(b^c, 24)</c></description></item>
    /// </list>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    [SuppressMessage("Performance", "CA1857:A constant is expected for the parameter", Justification = "False negative, false constant provided in .NET 8.0 runtime")]
    private static void GRoundXNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH,
        ref Vector128<ulong> dL, ref Vector128<ulong> dH,
        Vector128<ulong> xL, Vector128<ulong> xH)
    {
        // a += b + x
        aL = AdvSimd.Add(aL, AdvSimd.Add(bL, xL));
        aH = AdvSimd.Add(aH, AdvSimd.Add(bH, xH));
        // d = ror64(d ^ a, 32) — shift+or (32-bit swap within each 64-bit element)
        Vector128<ulong> dxL = dL ^ aL;
        Vector128<ulong> dxH = dH ^ aH;
        dL = AdvSimd.Or(AdvSimd.ShiftRightLogical(dxL, 32), AdvSimd.ShiftLeftLogical(dxL, 32));
        dH = AdvSimd.Or(AdvSimd.ShiftRightLogical(dxH, 32), AdvSimd.ShiftLeftLogical(dxH, 32));
        // c += d
        cL = AdvSimd.Add(cL, dL);
        cH = AdvSimd.Add(cH, dH);
        // b = ror64(b ^ c, 24) — TBL byte shuffle
        Vector128<ulong> bxL = bL ^ cL;
        Vector128<ulong> bxH = bH ^ cH;
        bL = AdvSimd.Arm64.VectorTableLookup(bxL.AsByte(), s_neonRotMask24).AsUInt64();
        bH = AdvSimd.Arm64.VectorTableLookup(bxH.AsByte(), s_neonRotMask24).AsUInt64();
    }

    /// <summary>
    /// Performs one Gy half-round on 4 parallel 64-bit lanes split across 128-bit NEON registers.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    ///   <item><description><c>a += b + y; d = ror64(d^a, 16)</c></description></item>
    ///   <item><description><c>c += d; b = ror64(b^c, 63)</c></description></item>
    /// </list>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    [SuppressMessage("Performance", "CA1857:A constant is expected for the parameter", Justification = "False negative, false constant provided in .NET 8.0 runtime")]
    private static void GRoundYNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH,
        ref Vector128<ulong> dL, ref Vector128<ulong> dH,
        Vector128<ulong> yL, Vector128<ulong> yH)
    {
        // a += b + y
        aL = AdvSimd.Add(aL, AdvSimd.Add(bL, yL));
        aH = AdvSimd.Add(aH, AdvSimd.Add(bH, yH));
        // d = ror64(d ^ a, 16) — TBL byte shuffle
        Vector128<ulong> dxL = dL ^ aL;
        Vector128<ulong> dxH = dH ^ aH;
        dL = AdvSimd.Arm64.VectorTableLookup(dxL.AsByte(), s_neonRotMask16).AsUInt64();
        dH = AdvSimd.Arm64.VectorTableLookup(dxH.AsByte(), s_neonRotMask16).AsUInt64();
        // c += d
        cL = AdvSimd.Add(cL, dL);
        cH = AdvSimd.Add(cH, dH);
        // b = ror64(b ^ c, 63) — shift+or; Add(t,t) == ShiftLeft(t,1)
        Vector128<ulong> tL = bL ^ cL;
        Vector128<ulong> tH = bH ^ cH;
        bL = AdvSimd.Or(AdvSimd.ShiftRightLogical(tL, 63), AdvSimd.Add(tL, tL));
        bH = AdvSimd.Or(AdvSimd.ShiftRightLogical(tH, 63), AdvSimd.Add(tH, tH));
    }

    /// <summary>
    /// Performs the BLAKE2b diagonal permutation on three rows, each split into lo/hi halves.
    /// </summary>
    /// <remarks>
    /// Equivalent to <c>Avx2.Permute4x64</c> with imm8 values 0b00_11_10_01, 0b01_00_11_10,
    /// 0b10_01_00_11 on rows <paramref name="aL"/>/<paramref name="aH"/>,
    /// <paramref name="bL"/>/<paramref name="bH"/>, <paramref name="cL"/>/<paramref name="cH"/>
    /// respectively.
    /// <para>
    /// Given a logical row <c>[e0, e1, e2, e3]</c> with lo=<c>[e0,e1]</c> and hi=<c>[e2,e3]</c>:
    /// </para>
    /// <list type="bullet">
    ///   <item><description>a: rotate left 1 → <c>[e1, e2, e3, e0]</c></description></item>
    ///   <item><description>b: swap halves → <c>[e2, e3, e0, e1]</c></description></item>
    ///   <item><description>c: rotate right 1 → <c>[e3, e0, e1, e2]</c></description></item>
    /// </list>
    /// <para>
    /// <c>ExtractVector128(x, y, 8)</c> extracts bytes[8..23] from the 32-byte concatenation [x, y],
    /// which is the equivalent of picking the second 8-byte element from x followed by the first
    /// 8-byte element from y.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PermuteNeon(
        ref Vector128<ulong> aL, ref Vector128<ulong> aH,
        ref Vector128<ulong> bL, ref Vector128<ulong> bH,
        ref Vector128<ulong> cL, ref Vector128<ulong> cH)
    {
        // a: rotate left 1 → [a1, a2, a3, a0]
        Vector128<ulong> newAL = AdvSimd.ExtractVector128(aL.AsByte(), aH.AsByte(), 8).AsUInt64();
        Vector128<ulong> newAH = AdvSimd.ExtractVector128(aH.AsByte(), aL.AsByte(), 8).AsUInt64();
        aL = newAL;
        aH = newAH;

        // b: swap halves → [b2, b3, b0, b1]
        (bL, bH) = (bH, bL);

        // c: rotate right 1 → [c3, c0, c1, c2]
        Vector128<ulong> newCL = AdvSimd.ExtractVector128(cH.AsByte(), cL.AsByte(), 8).AsUInt64();
        Vector128<ulong> newCH = AdvSimd.ExtractVector128(cL.AsByte(), cH.AsByte(), 8).AsUInt64();
        cL = newCL;
        cH = newCH;
    }
}

#endif
