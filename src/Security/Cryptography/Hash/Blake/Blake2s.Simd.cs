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
/// BLAKE2s x86 SIMD-accelerated compression.
/// </summary>
public sealed partial class Blake2s
{
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // Rotate right by 16 bits (swap high/low 16-bit halves within each 32-bit word)
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    private static readonly Vector128<uint> IVLow = Vector128.Create(
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU);

    private static readonly Vector128<uint> IVHigh = Vector128.Create(
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U);

    private static readonly Vector128<uint> FinalMask = Vector128.Create(0U, 0U, ~0U, 0U);

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
            if (Ssse3.IsSupported) support |= SimdSupport.Ssse3;
#if EXPERIMENTAL
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
            if (Sse2.IsSupported) support |= SimdSupport.Sse2;
            if (AdvSimd.Arm64.IsSupported) support |= SimdSupport.Neon;
#endif
            return support;
        }
    }

#if EXPERIMENTAL
    // Pre-computed Vector128<int> indices for gather operations (scaled by 4 for uint stride)
    private static readonly Vector128<int>[] GatherIndicesX = new Vector128<int>[Rounds * 2];
    private static readonly Vector128<int>[] GatherIndicesY = new Vector128<int>[Rounds * 2];

    static Blake2s()
    {
        for (int round = 0; round < Rounds; round++)
        {
            int offset = round * ScratchSize;

            // Column step indices (multiply by 4 for byte offset of uint)
            GatherIndicesX[round * 2] = Vector128.Create(
                Sigma[offset + 0] * 4, Sigma[offset + 2] * 4,
                Sigma[offset + 4] * 4, Sigma[offset + 6] * 4);
            GatherIndicesY[round * 2] = Vector128.Create(
                Sigma[offset + 1] * 4, Sigma[offset + 3] * 4,
                Sigma[offset + 5] * 4, Sigma[offset + 7] * 4);

            // Diagonal step indices
            GatherIndicesX[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 8] * 4, Sigma[offset + 10] * 4,
                Sigma[offset + 12] * 4, Sigma[offset + 14] * 4);
            GatherIndicesY[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 9] * 4, Sigma[offset + 11] * 4,
                Sigma[offset + 13] * 4, Sigma[offset + 15] * 4);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressSse2(byte* msgPtr, uint* state, ulong bytesCompressed, bool isFinal)
    {
        // Initialize rows from vector state
        // row0 = v[0..3] = state[0..3]
        // row1 = v[4..7] = state[4..7]
        // row2 = v[8..11] = IV[0..3]
        // row3 = v[12..15] = IV[4..7] with counter/finalization
        var row0 = Sse2.LoadVector128(state);
        var row1 = Sse2.LoadVector128(state + 4);
        var row2 = IVLow;
        var counterVec = Vector128.Create((uint)bytesCompressed, (uint)(bytesCompressed >> 32), 0U, 0U);
        var row3 = Sse2.Xor(IVHigh, counterVec);
        if (isFinal) row3 = Sse2.Xor(row3, FinalMask);

        var orig0 = row0;
        var orig1 = row1;
        fixed (byte* sigmaPtr = Sigma)
        {
            uint* m = (uint*)msgPtr;
            byte* s = sigmaPtr;

            // 10 rounds of mixing
            for (int round = 0; round < Rounds; round++)
            {
                // Column step
                var mx0 = Vector128.Create(m[s[0]], m[s[2]], m[s[4]], m[s[6]]);
                var my0 = Vector128.Create(m[s[1]], m[s[3]], m[s[5]], m[s[7]]);

                GRoundSse2(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal step: rotate rows
                Permute(ref row1, ref row2, ref row3);

                var mx1 = Vector128.Create(m[s[8]], m[s[10]], m[s[12]], m[s[14]]);
                var my1 = Vector128.Create(m[s[9]], m[s[11]], m[s[13]], m[s[15]]);

                GRoundSse2(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate rows
                Permute(ref row3, ref row2, ref row1);

                s += ScratchSize;
            }
        }


        row0 = Sse2.Xor(Sse2.Xor(row0, row2), orig0);
        row1 = Sse2.Xor(Sse2.Xor(row1, row3), orig1);

        Sse2.Store(state, row0);
        Sse2.Store(state + 4, row1);
    }
#endif

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressSsse3(byte* msgPtr, uint* state, ulong bytesCompressed, bool isFinal)
    {
        var row0 = Sse2.LoadVector128(state);
        var row1 = Sse2.LoadVector128(state + 4);
        var row2 = IVLow;
        var counterVec = Vector128.Create((uint)bytesCompressed, (uint)(bytesCompressed >> 32), 0U, 0U);
        var row3 = Sse2.Xor(IVHigh, counterVec);
        if (isFinal) row3 = Sse2.Xor(row3, FinalMask);

        var orig0 = row0;
        var orig1 = row1;

        fixed (byte* sigmaPtr = Sigma)
        {
            uint* m = (uint*)msgPtr;
            byte* s = sigmaPtr;

            // 10 rounds of mixing
            for (int round = 0; round < Rounds; round++)
            {
                // Column step
                var mx0 = Vector128.Create(m[s[0]], m[s[2]], m[s[4]], m[s[6]]);
                var my0 = Vector128.Create(m[s[1]], m[s[3]], m[s[5]], m[s[7]]);

                GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal step: rotate rows
                Permute(ref row1, ref row2, ref row3);

                var mx1 = Vector128.Create(m[s[8]], m[s[10]], m[s[12]], m[s[14]]);
                var my1 = Vector128.Create(m[s[9]], m[s[11]], m[s[13]], m[s[15]]);

                GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate rows
                Permute(ref row3, ref row2, ref row1);

                s += ScratchSize;
            }
        }

        row0 = Sse2.Xor(Sse2.Xor(row0, row2), orig0);
        row1 = Sse2.Xor(Sse2.Xor(row1, row3), orig1);

        Sse2.Store(state, row0);
        Sse2.Store(state + 4, row1);
    }

#if EXPERIMENTAL
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressAvx2(byte* mPtr, uint* state, ulong bytesCompressed, bool isFinal)
    {
        // Get base references for gather indices (avoids bounds checking in loop)
        ref Vector128<int> gatherXBase = ref MemoryMarshal.GetArrayDataReference(GatherIndicesX);
        ref Vector128<int> gatherYBase = ref MemoryMarshal.GetArrayDataReference(GatherIndicesY);

        // Initialize rows from vector state
        var row0 = Sse2.LoadVector128(state);
        var row1 = Sse2.LoadVector128(state + 4);
        var row2 = IVLow;

        // row3 = IVHigh with counter/finalization applied
        var counterVec = Vector128.Create((uint)bytesCompressed, (uint)(bytesCompressed >> 32), 0U, 0U);
        var row3 = Sse2.Xor(IVHigh, counterVec);

        if (isFinal)
        {
            row3 = Sse2.Xor(row3, FinalMask);
        }

        var orig0 = row0;
        var orig1 = row1;

        // 10 rounds of mixing
        for (int gatherIdx = 0; gatherIdx < Rounds * 2; gatherIdx += 2)
        {
            // Column step - use AVX2 gather for message words
            var mx0 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherXBase, gatherIdx), 1).AsUInt32();
            var my0 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherYBase, gatherIdx), 1).AsUInt32();

            GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx0, my0);

            // Diagonal step: rotate rows to align diagonals
            Permute(ref row1, ref row2, ref row3);

            // Diagonal step - use AVX2 gather for message words
            var mx1 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherXBase, gatherIdx + 1), 1).AsUInt32();
            var my1 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherYBase, gatherIdx + 1), 1).AsUInt32();

            GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx1, my1);

            // Un-rotate rows to restore column order
            Permute(ref row3, ref row2, ref row1);
        }

        row0 = Sse2.Xor(Sse2.Xor(row0, row2), orig0);
        row1 = Sse2.Xor(Sse2.Xor(row1, row3), orig1);

        Sse2.Store(state, row0);
        Sse2.Store(state + 4, row1);
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using SSE2 only.
    /// </summary>
    /// <remarks>
    /// Uses shift+or for all rotations to avoid SSSE3 dependency.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundSse2(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16) - use SSE2 shift+or (no SSSE3 shuffle)
        var t0 = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(t0, 16), Sse2.ShiftLeftLogical(t0, 16));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8) - use SSE2 shift+or (no SSSE3 shuffle)
        var t2 = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(t2, 8), Sse2.ShiftLeftLogical(t2, 24));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        var t3 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t3, 7), Sse2.ShiftLeftLogical(t3, 25));
    }
#endif

    /// <summary>
    /// Performs one G round on 4 parallel lanes using SSSE3 shuffle for byte-aligned rotations.
    /// </summary>
    /// <remarks>
    /// Uses SSSE3 byte shuffle for 16-bit and 8-bit rotations (faster than shift+or).
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundSsse3(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12) - must use shift+or (not byte-aligned)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7) - must use shift+or (not byte-aligned)
        var t2 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t2, 7), Sse2.ShiftLeftLogical(t2, 25));
    }

    /// <summary>
    /// Diagonal permutation. Call as <c>Permute(ref row1, ref row2, ref row3)</c> to
    /// diagonalize and <c>Permute(ref row3, ref row2, ref row1)</c> to un-diagonalize.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Permute(
        ref Vector128<uint> a, ref Vector128<uint> b, ref Vector128<uint> c)
    {
        a = Sse2.Shuffle(a, 0b00_11_10_01);
        b = Sse2.Shuffle(b, 0b01_00_11_10);
        c = Sse2.Shuffle(c, 0b10_01_00_11);
    }
}

#endif
