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
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words.

    // Rotate right by 16 bits
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vector. An expression-bodied property, not a static
    // readonly field: every operand is a const, so each use site materialises the
    // vector from the constant pool in one RIP-relative load. 
    private static Vector128<uint> IVLow
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create(IV0, IV1, IV2, IV3);
    }

    // Selects dwords 1 and 3 from the second operand, 0 and 2 from the first.
    private static readonly Vector128<uint> BlendMask0101 = Vector128.Create(
        0u, uint.MaxValue, 0u, uint.MaxValue);

    /// <summary>
    /// Number of chunks the SSSE3 tier compresses in parallel.
    /// </summary>
    /// <remarks>
    /// Four, matching the NEON tier: both are 128-bit, so both hold one BLAKE3
    /// state word across four independent chunks per vector. The kernel itself is
    /// <see cref="CompressChunksPartial4Ssse3"/> — pure
    /// <c>Vector128</c> code, also used by the AVX2 tier as its partial-batch
    /// handler, and requires nothing beyond SSSE3.
    /// </remarks>
    internal const int ChunksPerSsse3Batch = 4;

    /// <summary>
    /// Bytes consumed by one <see cref="ChunksPerSsse3Batch"/>-wide batch.
    /// </summary>
    internal const int Ssse3BatchSizeBytes = ChunksPerSsse3Batch * ChunkSizeBytes;

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
    /// Compresses <paramref name="chunkCount"/> (2..4) independent, full
    /// (1024-byte) chunks with a genuine 4-lane kernel, for the low end of the
    /// partial-batch range where <see cref="CompressChunksPartialAvx2"/>'s
    /// 8-lane kernel wastes the most register pressure and transpose work on
    /// unused lanes. Lane <c>j</c> reads chunk <c>j</c> mod
    /// <paramref name="chunkCount"/> (same surplus-lane-duplication strategy
    /// as the 8-lane kernel), so no memory outside the
    /// <paramref name="chunkCount"/>*1024 input bytes is touched; surplus
    /// lanes' outputs are wrong and must be ignored.
    /// </summary>
    /// <remarks>
    /// Reuses <see cref="GRound128"/> and the SSSE3-tier rotate helpers
    /// directly: the G-function is a pure elementwise operation (add/xor/
    /// rotate), so it is correct regardless of what each lane represents —
    /// here, one word broadcast across 4 independent chunks, rather than the
    /// SSSE3 path's 4 state words of a single chunk. Only the data layout
    /// (via <see cref="Transpose4x4(Vector128{uint}*)"/>) differs from the SSSE3 usage; the
    /// round schedule mirrors <see cref="CompressVector256"/>'s exactly.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartial4Ssse3(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        int* laneOffsets = stackalloc int[4];
        for (int j = 0; j < 4; j++)
        {
            laneOffsets[j] = (j % chunkCount) * ChunkSizeBytes;
        }

        var counterLow = Vector128.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3));
        var counterHigh = Vector128.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32),
            (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32));
        var blockLenVec = Vector128.Create((uint)BlockSizeBytes);

        Vector128<uint> cv0, cv1, cv2, cv3, cv4, cv5, cv6, cv7;
        cv0 = Vector128.Create(key[0]);
        cv1 = Vector128.Create(key[1]);
        cv2 = Vector128.Create(key[2]);
        cv3 = Vector128.Create(key[3]);
        cv4 = Vector128.Create(key[4]);
        cv5 = Vector128.Create(key[5]);
        cv6 = Vector128.Create(key[6]);
        cv7 = Vector128.Create(key[7]);

        var m = stackalloc Vector128<uint>[16];
        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            byte* blockBase = source + blockIdx * BlockSizeBytes;

            for (int j = 0; j < 4; j++)
            {
                m[j] = Sse2.LoadVector128((uint*)(blockBase + laneOffsets[j]));
                m[j + 4] = Sse2.LoadVector128((uint*)(blockBase + laneOffsets[j] + 16));
                m[j + 8] = Sse2.LoadVector128((uint*)(blockBase + laneOffsets[j] + 32));
                m[j + 12] = Sse2.LoadVector128((uint*)(blockBase + laneOffsets[j] + 48));
            }

            Transpose4x4(m);
            Transpose4x4(m + 4);
            Transpose4x4(m + 8);
            Transpose4x4(m + 12);

            uint flags = blockIdx == 0 ? baseFlags | FlagChunkStart : (blockIdx == 15 ? baseFlags | FlagChunkEnd : baseFlags);

            var v0 = cv0; var v1 = cv1; var v2 = cv2; var v3 = cv3;
            var v4 = cv4; var v5 = cv5; var v6 = cv6; var v7 = cv7;
            var v8 = Vector128.Create(IV0); var v9 = Vector128.Create(IV1);
            var v10 = Vector128.Create(IV2); var v11 = Vector128.Create(IV3);
            var v12 = counterLow;
            var v13 = counterHigh;
            var v14 = blockLenVec;
            var v15 = Vector128.Create(flags);

            CompressVector128ChunkParallel(
                ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
                ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
                m);

            cv0 = Sse2.Xor(v0, v8);
            cv1 = Sse2.Xor(v1, v9);
            cv2 = Sse2.Xor(v2, v10);
            cv3 = Sse2.Xor(v3, v11);
            cv4 = Sse2.Xor(v4, v12);
            cv5 = Sse2.Xor(v5, v13);
            cv6 = Sse2.Xor(v6, v14);
            cv7 = Sse2.Xor(v7, v15);
        }

        // Un-transpose the CVs (word-major -> chunk-major); transpose is its
        // own inverse for a square arrangement, so the same function that
        // converted the message loads to word-major restores chunk-major
        // here, in two 4-word halves (cv0-3, cv4-7) instead of the 8-lane
        // kernel's single 8-word transpose.
        m[0] = cv0; m[1] = cv1; m[2] = cv2; m[3] = cv3;
        Transpose4x4(m);
        m[4] = cv4; m[5] = cv5; m[6] = cv6; m[7] = cv7;
        Transpose4x4(m + 4);
        for (int chunkIdx = 0; chunkIdx < chunkCount; chunkIdx++)
        {
            Sse2.Store(outCvs + chunkIdx * 8, m[chunkIdx]);
            Sse2.Store(outCvs + chunkIdx * 8 + 4, m[4 + chunkIdx]);
        }
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

    /// <summary>
    /// In-place 4x4 transpose of 32-bit words held in four registers, the
    /// register-argument form of <see cref="Transpose4x4(Vector128{uint}*)"/>.
    /// </summary>
    /// <remarks>
    /// Used for the output side of <see cref="CompressParents4Ssse3"/>, where the
    /// four state words live in registers rather than a buffer, so the pointer
    /// form would force a needless spill and reload.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose4x4(
        ref Vector128<uint> v0, ref Vector128<uint> v1, ref Vector128<uint> v2, ref Vector128<uint> v3)
    {
        var t0 = Sse2.UnpackLow(v0, v1);
        var t1 = Sse2.UnpackHigh(v0, v1);
        var t2 = Sse2.UnpackLow(v2, v3);
        var t3 = Sse2.UnpackHigh(v2, v3);

        v0 = Sse2.UnpackLow(t0.AsUInt64(), t2.AsUInt64()).AsUInt32();
        v1 = Sse2.UnpackHigh(t0.AsUInt64(), t2.AsUInt64()).AsUInt32();
        v2 = Sse2.UnpackLow(t1.AsUInt64(), t3.AsUInt64()).AsUInt32();
        v3 = Sse2.UnpackHigh(t1.AsUInt64(), t3.AsUInt64()).AsUInt32();
    }

    /// <summary>
    /// Compresses four parent nodes at once: reads eight child CVs from
    /// <paramref name="childCvs"/> and writes four parent CVs to
    /// <paramref name="outCvs"/>.
    /// </summary>
    /// <remarks>
    /// The 128-bit counterpart of <see cref="CompressParents8Avx2"/> and the x86
    /// mirror of <c>CompressParents4Neon</c>: one BLAKE3 state word per lane
    /// across four independent parent compressions. Parent nodes always carry
    /// counter 0 and a full 64-byte block length, so only the flags word varies.
    /// <para>
    /// Fewer than four live parents is allowed — the surplus lanes compress
    /// whatever the buffer holds and their outputs are ignored — but
    /// <paramref name="childCvs"/> must still be readable for the full eight CVs
    /// (64 words), which every caller satisfies via the shared batch scratch.
    /// </para>
    /// </remarks>
    /// <param name="childCvs">Eight child CVs, laid out contiguously.</param>
    /// <param name="key">The 8-word key/IV words for this hash.</param>
    /// <param name="outCvs">Receives four parent CVs. May alias <paramref name="childCvs"/>.</param>
    /// <param name="baseFlags">Mode flags; <c>FlagParent</c> is added here.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressParents4Ssse3(uint* childCvs, uint* key, uint* outCvs, uint baseFlags)
    {
        Vector128<uint> v0 = Vector128.Create(key[0]);
        Vector128<uint> v1 = Vector128.Create(key[1]);
        Vector128<uint> v2 = Vector128.Create(key[2]);
        Vector128<uint> v3 = Vector128.Create(key[3]);
        Vector128<uint> v4 = Vector128.Create(key[4]);
        Vector128<uint> v5 = Vector128.Create(key[5]);
        Vector128<uint> v6 = Vector128.Create(key[6]);
        Vector128<uint> v7 = Vector128.Create(key[7]);

        // Each parent's 64-byte block is its two child CVs, so the eight child
        // CVs transpose into the 16 message words exactly as chunk blocks do.
        var m = stackalloc Vector128<uint>[16];
        for (int j = 0; j < ChunksPerSsse3Batch; j++)
        {
            m[j] = Sse2.LoadVector128(childCvs + j * 16);
            m[j + 4] = Sse2.LoadVector128(childCvs + j * 16 + 4);
            m[j + 8] = Sse2.LoadVector128(childCvs + j * 16 + 8);
            m[j + 12] = Sse2.LoadVector128(childCvs + j * 16 + 12);
        }

        Transpose4x4(m);
        Transpose4x4(m + 4);
        Transpose4x4(m + 8);
        Transpose4x4(m + 12);

        Vector128<uint> v8 = Vector128.Create(IV0);
        Vector128<uint> v9 = Vector128.Create(IV1);
        Vector128<uint> v10 = Vector128.Create(IV2);
        Vector128<uint> v11 = Vector128.Create(IV3);
        Vector128<uint> v12 = Vector128<uint>.Zero;   // parent counter is always 0
        Vector128<uint> v13 = Vector128<uint>.Zero;
        Vector128<uint> v14 = Vector128.Create((uint)BlockSizeBytes);
        Vector128<uint> v15 = Vector128.Create(baseFlags | FlagParent);

        CompressVector128ChunkParallel(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        v0 ^= v8; v1 ^= v9; v2 ^= v10; v3 ^= v11;
        v4 ^= v12; v5 ^= v13; v6 ^= v14; v7 ^= v15;

        Transpose4x4(ref v0, ref v1, ref v2, ref v3);
        Transpose4x4(ref v4, ref v5, ref v6, ref v7);

        Sse2.Store(outCvs, v0); Sse2.Store(outCvs + 4, v4);
        Sse2.Store(outCvs + 8, v1); Sse2.Store(outCvs + 12, v5);
        Sse2.Store(outCvs + 16, v2); Sse2.Store(outCvs + 20, v6);
        Sse2.Store(outCvs + 24, v3); Sse2.Store(outCvs + 28, v7);
    }

    /// <summary>
    /// Reduces <paramref name="chunkCount"/> (a power of two) contiguous chunk CVs
    /// to a single subtree CV at <paramref name="cvs"/>[0..8).
    /// </summary>
    /// <remarks>
    /// Mirrors <c>ReduceChunkCvsToSubtreeCvNeon</c>, the other 4-lane tier: levels
    /// with at least four parents run fully populated, then the final 4-to-2 level
    /// runs with two surplus lanes and one scalar merge finishes the pair.
    /// </remarks>
    /// <param name="cvs">The chunk CVs, reduced in place.</param>
    /// <param name="key">The 8-word key/IV words for this hash.</param>
    /// <param name="chunkCount">Number of chunk CVs to reduce; a power of two.</param>
    /// <param name="baseFlags">Mode flags for the parent compressions.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ReduceChunkCvsToSubtreeCvSsse3(uint* cvs, uint* key, int chunkCount, uint baseFlags)
    {
        // Full-width levels: every 4-parent group is fully populated.
        while (chunkCount >= 8)
        {
            int parents = chunkCount >> 1;
            for (int g = 0; g < parents; g += ChunksPerSsse3Batch)
            {
                CompressParents4Ssse3(cvs + g * 16, key, cvs + g * 8, baseFlags);
            }

            chunkCount = parents;
        }

        CompressParents4Ssse3(cvs, key, cvs, baseFlags);   // 4 -> 2 (upper 2 lanes ignored)
        ComputeParentCv(cvs, key, cvs);                     // 2 -> 1
    }

    // Mirrors CompressVector256 exactly (same message schedule, same
    // G-function groupings) at half the lane width, reusing GRound128 and
    // the SSSE3-tier rotate helpers from Blake3State.Ssse3.cs — the
    // G-function is a pure elementwise add/xor/rotate, so it is correct
    // regardless of what each lane represents (there: 4 state words of one
    // chunk; here: one word broadcast across 4 independent chunks).
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CompressVector128ChunkParallel(
        ref Vector128<uint> v0, ref Vector128<uint> v1, ref Vector128<uint> v2, ref Vector128<uint> v3,
        ref Vector128<uint> v4, ref Vector128<uint> v5, ref Vector128<uint> v6, ref Vector128<uint> v7,
        ref Vector128<uint> v8, ref Vector128<uint> v9, ref Vector128<uint> v10, ref Vector128<uint> v11,
        ref Vector128<uint> v12, ref Vector128<uint> v13, ref Vector128<uint> v14, ref Vector128<uint> v15,
        Vector128<uint>* m)
    {
        var m0 = m[0]; var m1 = m[1]; var m2 = m[2]; var m3 = m[3];
        var m4 = m[4]; var m5 = m[5]; var m6 = m[6]; var m7 = m[7];
        var m8 = m[8]; var m9 = m[9]; var m10 = m[10]; var m11 = m[11];
        var m12 = m[12]; var m13 = m[13]; var m14 = m[14]; var m15 = m[15];

        // Round 1
        GRound128(ref v0, ref v4, ref v8, ref v12, m0, m1);
        GRound128(ref v1, ref v5, ref v9, ref v13, m2, m3);
        GRound128(ref v2, ref v6, ref v10, ref v14, m4, m5);
        GRound128(ref v3, ref v7, ref v11, ref v15, m6, m7);
        GRound128(ref v0, ref v5, ref v10, ref v15, m8, m9);
        GRound128(ref v1, ref v6, ref v11, ref v12, m10, m11);
        GRound128(ref v2, ref v7, ref v8, ref v13, m12, m13);
        GRound128(ref v3, ref v4, ref v9, ref v14, m14, m15);

        // Round 2
        GRound128(ref v0, ref v4, ref v8, ref v12, m2, m6);
        GRound128(ref v1, ref v5, ref v9, ref v13, m3, m10);
        GRound128(ref v2, ref v6, ref v10, ref v14, m7, m0);
        GRound128(ref v3, ref v7, ref v11, ref v15, m4, m13);
        GRound128(ref v0, ref v5, ref v10, ref v15, m1, m11);
        GRound128(ref v1, ref v6, ref v11, ref v12, m12, m5);
        GRound128(ref v2, ref v7, ref v8, ref v13, m9, m14);
        GRound128(ref v3, ref v4, ref v9, ref v14, m15, m8);

        // Round 3
        GRound128(ref v0, ref v4, ref v8, ref v12, m3, m4);
        GRound128(ref v1, ref v5, ref v9, ref v13, m10, m12);
        GRound128(ref v2, ref v6, ref v10, ref v14, m13, m2);
        GRound128(ref v3, ref v7, ref v11, ref v15, m7, m14);
        GRound128(ref v0, ref v5, ref v10, ref v15, m6, m5);
        GRound128(ref v1, ref v6, ref v11, ref v12, m9, m0);
        GRound128(ref v2, ref v7, ref v8, ref v13, m11, m15);
        GRound128(ref v3, ref v4, ref v9, ref v14, m8, m1);

        // Round 4
        GRound128(ref v0, ref v4, ref v8, ref v12, m10, m7);
        GRound128(ref v1, ref v5, ref v9, ref v13, m12, m9);
        GRound128(ref v2, ref v6, ref v10, ref v14, m14, m3);
        GRound128(ref v3, ref v7, ref v11, ref v15, m13, m15);
        GRound128(ref v0, ref v5, ref v10, ref v15, m4, m0);
        GRound128(ref v1, ref v6, ref v11, ref v12, m11, m2);
        GRound128(ref v2, ref v7, ref v8, ref v13, m5, m8);
        GRound128(ref v3, ref v4, ref v9, ref v14, m1, m6);

        // Round 5
        GRound128(ref v0, ref v4, ref v8, ref v12, m12, m13);
        GRound128(ref v1, ref v5, ref v9, ref v13, m9, m11);
        GRound128(ref v2, ref v6, ref v10, ref v14, m15, m10);
        GRound128(ref v3, ref v7, ref v11, ref v15, m14, m8);
        GRound128(ref v0, ref v5, ref v10, ref v15, m7, m2);
        GRound128(ref v1, ref v6, ref v11, ref v12, m5, m3);
        GRound128(ref v2, ref v7, ref v8, ref v13, m0, m1);
        GRound128(ref v3, ref v4, ref v9, ref v14, m6, m4);

        // Round 6
        GRound128(ref v0, ref v4, ref v8, ref v12, m9, m14);
        GRound128(ref v1, ref v5, ref v9, ref v13, m11, m5);
        GRound128(ref v2, ref v6, ref v10, ref v14, m8, m12);
        GRound128(ref v3, ref v7, ref v11, ref v15, m15, m1);
        GRound128(ref v0, ref v5, ref v10, ref v15, m13, m3);
        GRound128(ref v1, ref v6, ref v11, ref v12, m0, m10);
        GRound128(ref v2, ref v7, ref v8, ref v13, m2, m6);
        GRound128(ref v3, ref v4, ref v9, ref v14, m4, m7);

        // Round 7
        GRound128(ref v0, ref v4, ref v8, ref v12, m11, m15);
        GRound128(ref v1, ref v5, ref v9, ref v13, m5, m0);
        GRound128(ref v2, ref v6, ref v10, ref v14, m1, m9);
        GRound128(ref v3, ref v7, ref v11, ref v15, m8, m6);
        GRound128(ref v0, ref v5, ref v10, ref v15, m14, m10);
        GRound128(ref v1, ref v6, ref v11, ref v12, m2, m12);
        GRound128(ref v2, ref v7, ref v8, ref v13, m3, m4);
        GRound128(ref v3, ref v4, ref v9, ref v14, m7, m13);
    }

    /// <summary>
    /// In-place 4x4 transpose of 32-bit words: on input <c>vecs[j]</c> holds
    /// 4 consecutive words of chunk <c>j</c>; on output <c>vecs[w]</c> holds
    /// word <c>w</c> of all 4 chunks (lane <c>j</c> = chunk <c>j</c>). Same
    /// self-inverse structure as <see cref="Transpose8x8"/>, at half the width.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose4x4(Vector128<uint>* vecs)
    {
        var v0 = vecs[0];
        var v1 = vecs[1];
        var v2 = vecs[2];
        var v3 = vecs[3];

        var t0 = Sse2.UnpackLow(v0, v1);
        var t1 = Sse2.UnpackHigh(v0, v1);
        var t2 = Sse2.UnpackLow(v2, v3);
        var t3 = Sse2.UnpackHigh(v2, v3);

        vecs[0] = Sse2.UnpackLow(t0.AsUInt64(), t2.AsUInt64()).AsUInt32();
        vecs[1] = Sse2.UnpackHigh(t0.AsUInt64(), t2.AsUInt64()).AsUInt32();
        vecs[2] = Sse2.UnpackLow(t1.AsUInt64(), t3.AsUInt64()).AsUInt32();
        vecs[3] = Sse2.UnpackHigh(t1.AsUInt64(), t3.AsUInt64()).AsUInt32();
    }
}
#endif
