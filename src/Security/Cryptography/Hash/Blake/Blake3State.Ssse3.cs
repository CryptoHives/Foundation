// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE3 SSSE3-accelerated compression.
/// </summary>
internal unsafe partial struct Blake3State
{
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // Rotate right by 16 bits
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vectors
    private static readonly Vector128<uint> IVLow = Vector128.Create(
        IV0, IV1, IV2, IV3);

    // Selects dwords 1 and 3 from the second operand, 0 and 2 from the first.
    private static readonly Vector128<uint> BlendMask0101 = Vector128.Create(
        0u, uint.MaxValue, 0u, uint.MaxValue);

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
            if (Ssse3.IsSupported) support |= SimdSupport.Ssse3;
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
            if (Avx512F.IsSupported) support |= SimdSupport.Avx512F;
            if (AdvSimd.Arm64.IsSupported) support |= SimdSupport.Neon;
            return support;
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlockSsse3(uint* cv, byte* block, uint blockLen, ulong counter, uint flags)
    {
        // Initialize rows
        var row0 = Sse2.LoadVector128(cv);
        var row1 = Sse2.LoadVector128(cv + 4);

        // counter/blockLen never change across blocks within a chunk, and
        // flags only changes once (FlagChunkStart clears after the first
        // block) — build these seeds at most twice total instead of
        // reconstructing them from scalars on every block iteration.
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);

        // On x86 (always little-endian), cast directly — no copy needed
        uint* m = (uint*)block;
        GRounds128(m, ref row0, ref row1, ref row2, ref row3);

        row0 = Sse2.Xor(row0, row2);
        row1 = Sse2.Xor(row1, row3);

        // Finalize: cv = row0 ^ row2, cv = row1 ^ row3
        Sse2.Store(cv, row0);
        Sse2.Store(cv + 4, row1);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlocksSsse3(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
        // Initialize rows
        var row0 = Sse2.LoadVector128(cv);
        var row1 = Sse2.LoadVector128(cv + 4);

        // counter/blockLen never change across blocks within a chunk, and
        // flags only changes once (FlagChunkStart clears after the first
        // block) — build these seeds at most twice total instead of
        // reconstructing them from scalars on every block iteration.
        var row2Seed = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);
        var row3Seed = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags & ~FlagChunkStart);

        while (blocks-- > 0)
        {
            var row2 = row2Seed;

            // On x86 (always little-endian), cast directly — no copy needed
            uint* m = (uint*)block;
            GRounds128(m, ref row0, ref row1, ref row2, ref row3);

            row0 = Sse2.Xor(row0, row2);
            row1 = Sse2.Xor(row1, row3);
            row3 = row3Seed;

            block += blockLen;
        }

        // Finalize: cv = row0 ^ row2, cv = row1 ^ row3
        Sse2.Store(cv, row0);
        Sse2.Store(cv + 4, row1);
    }

    /// <summary>
    /// Squeezes one or more independent, consecutive output blocks directly into
    /// <paramref name="dst"/> in one call — <paramref name="blocks"/> = 1
    /// serves the single-block callers (initial priming, look-ahead), since
    /// <c>_rootCv</c> is loaded once regardless of the batch size.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocksSsse3(Blake3State* core, ulong startCounter, int blocks, byte* dst)
    {
        uint* m = core->_rootBlock;
        // _rootCv is invariant across every block in the batch — load once
        // and reuse both as the row0/row1 seed and the final-xor operand,
        // instead of reloading it from memory on every iteration.
        var cvLow = Sse2.LoadVector128(core->_rootCv);
        var cvHigh = Sse2.LoadVector128(core->_rootCv + 4);
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

            GRounds128(m, ref row0, ref row1, ref row2, ref row3);

            byte* blockDest = dst + i * BlockSizeBytes;
            Sse2.Store(blockDest, Sse2.Xor(row0, row2).AsByte());
            Sse2.Store(blockDest + 16, Sse2.Xor(row1, row3).AsByte());
            Sse2.Store(blockDest + 32, Sse2.Xor(row2, cvLow).AsByte());
            Sse2.Store(blockDest + 48, Sse2.Xor(row3, cvHigh).AsByte());
        }
    }

    // Extracts 4 message words from up to 4 source vectors in a single
    // shuffle_ps/shuffle_ps/blend sequence, avoiding scalar loads and
    // GPR-to-XMM inserts.
    [SuppressMessage("Performance", "CA1857:A constant is expected for the parameter",
        Justification = "False negative due to bug in .NET 8 runtime metadata.")]
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> Gather128(
        Vector128<uint> leftA, Vector128<uint> leftB, byte leftControl,
        Vector128<uint> rightA, Vector128<uint> rightB, byte rightControl)
    {
        var left = Sse.Shuffle(leftA.AsSingle(), leftB.AsSingle(), leftControl).AsUInt32();
        var right = Sse.Shuffle(rightA.AsSingle(), rightB.AsSingle(), rightControl).AsUInt32();
        if (Sse41.IsSupported)
        {
            // 0xCC selects words 2,3,6,7 (uint lanes 1 and 3) from the second
            // operand, matching BlendMask0101's lane selection in one PBLENDW.
            return Sse41.Blend(left.AsInt16(), right.AsInt16(), 0xCC).AsUInt32();
        }
        return Sse2.Or(Sse2.And(right, BlendMask0101), Sse2.AndNot(BlendMask0101, left));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRounds128(
        uint* m,
        ref Vector128<uint> row0,
        ref Vector128<uint> row1,
        ref Vector128<uint> row2,
        ref Vector128<uint> row3)
    {
        // Load the 16-word message block once as four contiguous quads.
        var q0 = Sse2.LoadVector128(m);
        var q1 = Sse2.LoadVector128(m + 4);
        var q2 = Sse2.LoadVector128(m + 8);
        var q3 = Sse2.LoadVector128(m + 12);

        // Round 1: 0,2,4,6 | 1,3,5,7 (columns), 8,10,12,14 | 9,11,13,15 (diagonals)
        var colX = Gather128(q0, q1, 0x00, q0, q1, 0x88);
        var colY = Gather128(q0, q1, 0x11, q0, q1, 0xCC);
        var diagX = Gather128(q2, q3, 0x00, q2, q3, 0x88);
        var diagY = Gather128(q2, q3, 0x11, q2, q3, 0xCC);

        GRound128(ref row0, ref row1, ref row2, ref row3, colX, colY);
        DiagPermute128(ref row1, ref row2, ref row3);
        GRound128(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
        DiagPermute128(ref row3, ref row2, ref row1);

        // Rounds 2-7: BLAKE3's message schedule applies the same fixed
        // permutation every round to the previous round's own output vectors.
        // Fully unrolled (no loop/counter) so the JIT never has to pay a
        // loop-carried register shuffle or branch between rounds — matches
        // the reference managed implementation's approach.
        for (int i = 1; i < 7; i++)
        {
            q0 = colX; q1 = colY; q2 = diagX; q3 = diagY;
            colX = Gather128(q0, q1, 0x31, q1, q0, 0x84);
            colY = Gather128(q0, q0, 0x03, q2, q3, 0x84);
            diagX = Gather128(q1, q3, 0x00, q2, q3, 0xC8);
            diagY = Gather128(q3, q2, 0x31, q1, q2, 0x08);
            GRound128(ref row0, ref row1, ref row2, ref row3, colX, colY);
            DiagPermute128(ref row1, ref row2, ref row3);
            GRound128(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
            DiagPermute128(ref row3, ref row2, ref row1);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermute128(ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
        row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
        row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRound128(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16)
        d = RotateRight16(Sse2.Xor(d, a));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        b = RotateRight12(Sse2.Xor(b, c));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8)
        d = RotateRight8(Sse2.Xor(d, a));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        b = RotateRight7(Sse2.Xor(b, c));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> RotateRight16(Vector128<uint> value) => Avx512F.VL.IsSupported
       ? Avx512F.VL.RotateRight(value, 16)
       : Ssse3.Shuffle(value.AsByte(), RotateMask16).AsUInt32();

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> RotateRight12(Vector128<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 12)
        : Sse2.Or(Sse2.ShiftRightLogical(value, 12), Sse2.ShiftLeftLogical(value, 20));

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> RotateRight8(Vector128<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 8)
        : Ssse3.Shuffle(value.AsByte(), RotateMask8).AsUInt32();

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> RotateRight7(Vector128<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 7)
        : Sse2.Or(Sse2.ShiftRightLogical(value, 7), Sse2.ShiftLeftLogical(value, 25));
}
#endif
