// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE3 AVX2-accelerated multi-chunk (chunk-parallel) compression.
/// </summary>
/// <remarks>
/// <para>
/// Unlike the SSSE3 path, which vectorizes the four words of a
/// *single* chunk's compression state across one 128-bit register, this file
/// vectorizes *across 8 independent chunks* at once: each of the 16 compression
/// state words becomes its own <see cref="Vector256{UInt32}"/>, where lane <c>j</c>
/// holds that word's value for chunk <c>j</c>. Because chunks are independent
/// Merkle tree leaves, no diagonalize/permute is needed — the column and
/// diagonal G-function groupings are the same fixed indices as the scalar
/// <see cref="Blake3State.Compress"/> reference implementation, just applied
/// element-wise across 8 lanes instead of one word at a time.
/// </para>
/// <para>
/// Message words are transposed from row-major (8 chunks × 16 words) to
/// column-major (16 vectors of 8 lanes) via two 8×8 unpack/permute transposes
/// per block. Plain unaligned loads plus ~40 single-cycle shuffles are far
/// cheaper than 16 <c>vpgatherdd</c> instructions per block, which are
/// microcoded (~1 element/cycle) on AMD Zen and dominated the kernel cost.
/// </para>
/// </remarks>
internal unsafe partial struct Blake3State
{
    internal const int ChunksPerAvx2Batch = 8;
    internal const int Avx2BatchSizeBytes = ChunksPerAvx2Batch * ChunkSizeBytes;

    private static readonly Vector256<byte> RotateRight8Mask256 =
        Vector256.Create(RotateMask8, RotateMask8);

    private static readonly Vector256<byte> RotateRight16Mask256 =
        Vector256.Create(RotateMask16, RotateMask16);


    /// <summary>
    /// Compresses <paramref name="chunkCount"/> (2..8) independent, full
    /// (1024-byte) chunks with the 8-way kernel by ignoring the surplus lanes
    /// </summary>
    /// <remarks>
    /// One 8-way pass costs about as much as 1.5 chunks on the single-lane
    /// SSSE3 path, so this wins from 2 real chunks upward — it turns the
    /// 2–8 full-chunk range (which the 8-chunk batch loop can't touch) from
    /// per-chunk serial compression into a single kernel call.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartialAvx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        var counterLow = Vector256.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3),
            (uint)(baseCounter + 4), (uint)(baseCounter + 5), (uint)(baseCounter + 6), (uint)(baseCounter + 7));
        var counterHigh = Vector256.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32),
            (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32),
            (uint)((baseCounter + 4) >> 32), (uint)((baseCounter + 5) >> 32),
            (uint)((baseCounter + 6) >> 32), (uint)((baseCounter + 7) >> 32));
        var blockLenVec = Vector256.Create((uint)BlockSizeBytes);

        Vector256<uint> cv0, cv1, cv2, cv3, cv4, cv5, cv6, cv7;
        cv0 = Vector256.Create(key[0]);
        cv1 = Vector256.Create(key[1]);
        cv2 = Vector256.Create(key[2]);
        cv3 = Vector256.Create(key[3]);
        cv4 = Vector256.Create(key[4]);
        cv5 = Vector256.Create(key[5]);
        cv6 = Vector256.Create(key[6]);
        cv7 = Vector256.Create(key[7]);

        var m = stackalloc Vector256<uint>[16];
        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            byte* blockBase = source + blockIdx * BlockSizeBytes;

            for (int j = 0; j < chunkCount; j++)
            {
                m[j] = Avx.LoadVector256((uint*)(blockBase + j * ChunkSizeBytes));
                m[j + 8] = Avx.LoadVector256((uint*)(blockBase + j * ChunkSizeBytes + (BlockSizeBytes / 2)));
            }

            Transpose8x8(m);
            Transpose8x8(m + 8);
            uint flags = blockIdx == 0 ? baseFlags | FlagChunkStart : (blockIdx == 15 ? baseFlags | FlagChunkEnd : baseFlags);

            var v0 = cv0; var v1 = cv1; var v2 = cv2; var v3 = cv3;
            var v4 = cv4; var v5 = cv5; var v6 = cv6; var v7 = cv7;
            var v8 = Vector256.Create(IV0); var v9 = Vector256.Create(IV1);
            var v10 = Vector256.Create(IV2); var v11 = Vector256.Create(IV3);
            var v12 = counterLow;
            var v13 = counterHigh;
            var v14 = blockLenVec;
            var v15 = Vector256.Create(flags);

            CompressVector256(
                ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
                ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
                m);

            cv0 = Avx2.Xor(v0, v8);
            cv1 = Avx2.Xor(v1, v9);
            cv2 = Avx2.Xor(v2, v10);
            cv3 = Avx2.Xor(v3, v11);
            cv4 = Avx2.Xor(v4, v12);
            cv5 = Avx2.Xor(v5, v13);
            cv6 = Avx2.Xor(v6, v14);
            cv7 = Avx2.Xor(v7, v15);
        }

        m[0] = cv0; m[1] = cv1; m[2] = cv2; m[3] = cv3;
        m[4] = cv4; m[5] = cv5; m[6] = cv6; m[7] = cv7;
        Transpose8x8(m);
        for (int chunkIdx = 0; chunkIdx < chunkCount; chunkIdx++)
        {
            Avx.Store(outCvs + chunkIdx * 8, m[chunkIdx]);
        }
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
    /// (via <see cref="Transpose4x4"/>) differs from the SSSE3 usage; the
    /// round schedule mirrors <see cref="CompressVector256"/>'s exactly.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartial4Avx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
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
    /// Squeezes 8 independent, consecutive output blocks (counters
    /// <paramref name="startCounter"/>..+7) into <paramref name="dst"/>
    /// (512 bytes) in one call, reusing the same transpose kernel as chunk
    /// compression.
    /// </summary>
    /// <remarks>
    /// Unlike chunk compression, every lane compresses the *same* message
    /// (<c>_rootBlock</c>) and chaining value (<c>_rootCv</c>) — only the
    /// counter differs per lane — so there is nothing to transpose in: each of
    /// the 16 message words and 8 chaining-value words is simply broadcast to
    /// all 8 lanes. Only the output needs the usual 8×8 un-transpose back to
    /// block-major order, doubled to cover both output halves (the low
    /// CV-style fold every chunk compression already produces, plus the high
    /// <c>v[i+8]^rootCv[i]</c> fold that only a full squeeze output needs).
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocks8Avx2(Blake3State* core, ulong startCounter, byte* dst)
    {
        uint* rootCv = core->_rootCv;
        uint* rootBlock = core->_rootBlock;
        uint blockLen = _rootBlockLen;
        uint flags = _rootFlags;

        var counterLow = Vector256.Create(
            (uint)(startCounter + 0), (uint)(startCounter + 1), (uint)(startCounter + 2), (uint)(startCounter + 3),
            (uint)(startCounter + 4), (uint)(startCounter + 5), (uint)(startCounter + 6), (uint)(startCounter + 7));
        var counterHigh = Vector256.Create(
            (uint)((startCounter + 0) >> 32), (uint)((startCounter + 1) >> 32),
            (uint)((startCounter + 2) >> 32), (uint)((startCounter + 3) >> 32),
            (uint)((startCounter + 4) >> 32), (uint)((startCounter + 5) >> 32),
            (uint)((startCounter + 6) >> 32), (uint)((startCounter + 7) >> 32));

        var cv0 = Vector256.Create(rootCv[0]); var cv1 = Vector256.Create(rootCv[1]);
        var cv2 = Vector256.Create(rootCv[2]); var cv3 = Vector256.Create(rootCv[3]);
        var cv4 = Vector256.Create(rootCv[4]); var cv5 = Vector256.Create(rootCv[5]);
        var cv6 = Vector256.Create(rootCv[6]); var cv7 = Vector256.Create(rootCv[7]);

        var v0 = cv0; var v1 = cv1; var v2 = cv2; var v3 = cv3;
        var v4 = cv4; var v5 = cv5; var v6 = cv6; var v7 = cv7;
        var v8 = Vector256.Create(IV0); var v9 = Vector256.Create(IV1);
        var v10 = Vector256.Create(IV2); var v11 = Vector256.Create(IV3);
        var v12 = counterLow;
        var v13 = counterHigh;
        var v14 = Vector256.Create(blockLen);
        var v15 = Vector256.Create(flags);

        // No transpose-in: every lane compresses the same message, so each of
        // the 16 words is simply broadcast rather than gathered per-lane.
        var m = stackalloc Vector256<uint>[16];
        for (int w = 0; w < 16; w++)
        {
            m[w] = Vector256.Create(rootBlock[w]);
        }

        CompressVector256(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        // Full 16-word output per block: halves[0..7] = v[i]^v[i+8] (the same
        // fold a chunk CV uses), halves[8..15] = v[i+8]^rootCv[i] (the extra
        // fold only a full squeeze output needs).
        var halves = stackalloc Vector256<uint>[16];
        halves[0] = Avx2.Xor(v0, v8); halves[8] = Avx2.Xor(v8, cv0);
        halves[1] = Avx2.Xor(v1, v9); halves[9] = Avx2.Xor(v9, cv1);
        halves[2] = Avx2.Xor(v2, v10); halves[10] = Avx2.Xor(v10, cv2);
        halves[3] = Avx2.Xor(v3, v11); halves[11] = Avx2.Xor(v11, cv3);
        halves[4] = Avx2.Xor(v4, v12); halves[12] = Avx2.Xor(v12, cv4);
        halves[5] = Avx2.Xor(v5, v13); halves[13] = Avx2.Xor(v13, cv5);
        halves[6] = Avx2.Xor(v6, v14); halves[14] = Avx2.Xor(v14, cv6);
        halves[7] = Avx2.Xor(v7, v15); halves[15] = Avx2.Xor(v15, cv7);

        Transpose8x8(halves);
        Transpose8x8(halves + 8);

        // Raw pointer stores instead of Span.Slice/CopyTo: the caller always
        // sizes destination to exactly ChunksPerAvx2Batch * BlockSizeBytes, but
        // that guarantee isn't visible across the call boundary, so Slice would
        // otherwise re-check bounds on every one of these 16 stores.
        for (int j = 0; j < ChunksPerAvx2Batch; j++)
        {
            Avx.Store((uint*)(dst + j * BlockSizeBytes), halves[j]);
            Avx.Store((uint*)(dst + j * BlockSizeBytes + 32), halves[j + 8]);
        }
    }

    /// <summary>
    /// Compresses 8 independent parent nodes in parallel: parent <c>j</c>'s
    /// 64-byte message block is the two contiguous child CVs at
    /// <paramref name="childCvs"/> + j·16 words, writing each parent's 8-word
    /// CV contiguously into <paramref name="outCvs"/> (64 words total).
    /// </summary>
    /// <remarks>
    /// All child blocks are loaded before any output is stored, so in-place
    /// reduction (<paramref name="outCvs"/> == <paramref name="childCvs"/>) is
    /// safe. When fewer than 8 parents are needed, the surplus lanes compress
    /// whatever the buffer holds and their outputs are simply ignored — the
    /// caller must guarantee the buffer is at least 8 parent blocks
    /// (512 bytes) long so the loads stay in bounds.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressParents8Avx2(uint* childCvs, uint* key, uint* outCvs, uint baseFlags)
    {
        var blockLenVec = Vector256.Create((uint)BlockSizeBytes);
        var iv0 = Vector256.Create(IV0);
        var iv1 = Vector256.Create(IV1);
        var iv2 = Vector256.Create(IV2);
        var iv3 = Vector256.Create(IV3);
        var flagsVec = Vector256.Create(baseFlags | FlagParent);

        Vector256<uint> v0, v1, v2, v3, v4, v5, v6, v7;
        v0 = Vector256.Create(key[0]);
        v1 = Vector256.Create(key[1]);
        v2 = Vector256.Create(key[2]);
        v3 = Vector256.Create(key[3]);
        v4 = Vector256.Create(key[4]);
        v5 = Vector256.Create(key[5]);
        v6 = Vector256.Create(key[6]);
        v7 = Vector256.Create(key[7]);

        var m = stackalloc Vector256<uint>[16];
        for (int j = 0; j < 8; j++)
        {
            m[j] = Avx.LoadVector256(childCvs + j * 16);
            m[j + 8] = Avx.LoadVector256(childCvs + j * 16 + 8);
        }

        Transpose8x8(m);
        Transpose8x8(m + 8);

        var v8 = iv0; var v9 = iv1; var v10 = iv2; var v11 = iv3;
        var v12 = Vector256<uint>.Zero;   // parent counter is always 0
        var v13 = Vector256<uint>.Zero;
        var v14 = blockLenVec;
        var v15 = flagsVec;

        CompressVector256(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        m[0] = Avx2.Xor(v0, v8);
        m[1] = Avx2.Xor(v1, v9);
        m[2] = Avx2.Xor(v2, v10);
        m[3] = Avx2.Xor(v3, v11);
        m[4] = Avx2.Xor(v4, v12);
        m[5] = Avx2.Xor(v5, v13);
        m[6] = Avx2.Xor(v6, v14);
        m[7] = Avx2.Xor(v7, v15);

        Transpose8x8(m);
        for (int parentIdx = 0; parentIdx < 8; parentIdx++)
        {
            Avx.Store(outCvs + parentIdx * 8, m[parentIdx]);
        }
    }

    /// <summary>
    /// The preferred subtree granularity for the batched fast paths: chunk CVs
    /// from consecutive kernel batches accumulate until 64 are available, so
    /// the surplus-lane reduction tail (8→4→2) amortizes over 64 KB instead of
    /// being paid per kernel batch.
    /// </summary>
    internal const int ChunksPerSubtreeGroup = 64;

    /// <summary>
    /// Reduces <paramref name="chunkCount"/> (a power of two: 8, 16 or 64)
    /// contiguous chunk CVs to a single subtree CV at <paramref name="cvs"/>[0..8)
    /// using wide parent compressions. Levels with at least 8 parents use fully
    /// populated 8-way compressions; only the final 8→4→2 levels run with
    /// surplus lanes, plus one single merge.
    /// </summary>
    /// <remarks>
    /// The buffer must be at least 16 CVs (512 bytes) long regardless of
    /// <paramref name="chunkCount"/> — see <see cref="CompressParents8Avx2"/>
    /// on surplus lanes. In-place group reductions are safe: group <c>g</c>
    /// writes CV slots [g·8, g·8+8) while reading child slots [g·16, g·16+16),
    /// which never overlap for g ≥ 1, and g = 0 loads everything before storing.
    /// </remarks>
    private void ReduceChunkCvsToSubtreeCvAvx2(uint* cvs, uint* key, int chunkCount, uint baseFlags)
    {
        // Full-width levels: every 8-parent group is fully populated.
        while (chunkCount >= 16)
        {
            int parents = chunkCount >> 1;
            for (int g = 0; g < parents; g += 8)
            {
                CompressParents8Avx2(cvs + g * 16, key, cvs + g * 8, baseFlags);
            }

            chunkCount = parents;
        }

        CompressParents8Avx2(cvs, key, cvs, baseFlags);        // 8 -> 4 (upper 4 lanes ignored)
        CompressParents8Avx2(cvs, key, cvs, baseFlags);        // 4 -> 2 (upper 6 lanes ignored)
        ComputeParentCv(cvs, key, cvs);                        // 2 -> 1
    }

    // Mirrors Blake3State.Compress(uint*, uint*) exactly (same message schedule,
    // same G-function groupings), with every uint word replaced by a
    // Vector256<uint> holding that word's value for 8 independent chunks.
    // The 16 state words are ref parameters (not an array) and the method is
    // force-inlined so that, after inlining into the caller's block loop, the
    // state maps onto the 16 YMM registers instead of stack slots.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CompressVector256(
        ref Vector256<uint> v0, ref Vector256<uint> v1, ref Vector256<uint> v2, ref Vector256<uint> v3,
        ref Vector256<uint> v4, ref Vector256<uint> v5, ref Vector256<uint> v6, ref Vector256<uint> v7,
        ref Vector256<uint> v8, ref Vector256<uint> v9, ref Vector256<uint> v10, ref Vector256<uint> v11,
        ref Vector256<uint> v12, ref Vector256<uint> v13, ref Vector256<uint> v14, ref Vector256<uint> v15,
        Vector256<uint>* m)
    {
        var m0 = m[0]; var m1 = m[1]; var m2 = m[2]; var m3 = m[3];
        var m4 = m[4]; var m5 = m[5]; var m6 = m[6]; var m7 = m[7];
        var m8 = m[8]; var m9 = m[9]; var m10 = m[10]; var m11 = m[11];
        var m12 = m[12]; var m13 = m[13]; var m14 = m[14]; var m15 = m[15];

        // Round 1
        GVec(ref v0, ref v4, ref v8, ref v12, m0, m1);
        GVec(ref v1, ref v5, ref v9, ref v13, m2, m3);
        GVec(ref v2, ref v6, ref v10, ref v14, m4, m5);
        GVec(ref v3, ref v7, ref v11, ref v15, m6, m7);
        GVec(ref v0, ref v5, ref v10, ref v15, m8, m9);
        GVec(ref v1, ref v6, ref v11, ref v12, m10, m11);
        GVec(ref v2, ref v7, ref v8, ref v13, m12, m13);
        GVec(ref v3, ref v4, ref v9, ref v14, m14, m15);

        // Round 2
        GVec(ref v0, ref v4, ref v8, ref v12, m2, m6);
        GVec(ref v1, ref v5, ref v9, ref v13, m3, m10);
        GVec(ref v2, ref v6, ref v10, ref v14, m7, m0);
        GVec(ref v3, ref v7, ref v11, ref v15, m4, m13);
        GVec(ref v0, ref v5, ref v10, ref v15, m1, m11);
        GVec(ref v1, ref v6, ref v11, ref v12, m12, m5);
        GVec(ref v2, ref v7, ref v8, ref v13, m9, m14);
        GVec(ref v3, ref v4, ref v9, ref v14, m15, m8);

        // Round 3
        GVec(ref v0, ref v4, ref v8, ref v12, m3, m4);
        GVec(ref v1, ref v5, ref v9, ref v13, m10, m12);
        GVec(ref v2, ref v6, ref v10, ref v14, m13, m2);
        GVec(ref v3, ref v7, ref v11, ref v15, m7, m14);
        GVec(ref v0, ref v5, ref v10, ref v15, m6, m5);
        GVec(ref v1, ref v6, ref v11, ref v12, m9, m0);
        GVec(ref v2, ref v7, ref v8, ref v13, m11, m15);
        GVec(ref v3, ref v4, ref v9, ref v14, m8, m1);

        // Round 4
        GVec(ref v0, ref v4, ref v8, ref v12, m10, m7);
        GVec(ref v1, ref v5, ref v9, ref v13, m12, m9);
        GVec(ref v2, ref v6, ref v10, ref v14, m14, m3);
        GVec(ref v3, ref v7, ref v11, ref v15, m13, m15);
        GVec(ref v0, ref v5, ref v10, ref v15, m4, m0);
        GVec(ref v1, ref v6, ref v11, ref v12, m11, m2);
        GVec(ref v2, ref v7, ref v8, ref v13, m5, m8);
        GVec(ref v3, ref v4, ref v9, ref v14, m1, m6);

        // Round 5
        GVec(ref v0, ref v4, ref v8, ref v12, m12, m13);
        GVec(ref v1, ref v5, ref v9, ref v13, m9, m11);
        GVec(ref v2, ref v6, ref v10, ref v14, m15, m10);
        GVec(ref v3, ref v7, ref v11, ref v15, m14, m8);
        GVec(ref v0, ref v5, ref v10, ref v15, m7, m2);
        GVec(ref v1, ref v6, ref v11, ref v12, m5, m3);
        GVec(ref v2, ref v7, ref v8, ref v13, m0, m1);
        GVec(ref v3, ref v4, ref v9, ref v14, m6, m4);

        // Round 6
        GVec(ref v0, ref v4, ref v8, ref v12, m9, m14);
        GVec(ref v1, ref v5, ref v9, ref v13, m11, m5);
        GVec(ref v2, ref v6, ref v10, ref v14, m8, m12);
        GVec(ref v3, ref v7, ref v11, ref v15, m15, m1);
        GVec(ref v0, ref v5, ref v10, ref v15, m13, m3);
        GVec(ref v1, ref v6, ref v11, ref v12, m0, m10);
        GVec(ref v2, ref v7, ref v8, ref v13, m2, m6);
        GVec(ref v3, ref v4, ref v9, ref v14, m4, m7);

        // Round 7
        GVec(ref v0, ref v4, ref v8, ref v12, m11, m15);
        GVec(ref v1, ref v5, ref v9, ref v13, m5, m0);
        GVec(ref v2, ref v6, ref v10, ref v14, m1, m9);
        GVec(ref v3, ref v7, ref v11, ref v15, m8, m6);
        GVec(ref v0, ref v5, ref v10, ref v15, m14, m10);
        GVec(ref v1, ref v6, ref v11, ref v12, m2, m12);
        GVec(ref v2, ref v7, ref v8, ref v13, m3, m4);
        GVec(ref v3, ref v4, ref v9, ref v14, m7, m13);
    }

    /// <summary>
    /// In-place 8×8 transpose of 32-bit words: on input <c>vecs[j]</c> holds
    /// 8 consecutive words of chunk <c>j</c>; on output <c>vecs[w]</c> holds
    /// word <c>w</c> of all 8 chunks (lane <c>j</c> = chunk <c>j</c>).
    /// </summary>
    /// <remarks>
    /// AVX2 dword/qword unpacks interleave within each 128-bit lane, so the
    /// intermediate names track which source rows (letters) and columns
    /// (digits) each vector holds; the final <c>Permute2x128</c> pass
    /// recombines the half-lanes into fully transposed rows.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose8x8(Vector256<uint>* vecs)
    {
        var v0 = vecs[0];
        var v1 = vecs[1];
        var v2 = vecs[2];
        var v3 = vecs[3];
        var v4 = vecs[4];
        var v5 = vecs[5];
        var v6 = vecs[6];
        var v7 = vecs[7];

        // Interleave 32-bit words of row pairs.
        var ab0145 = Avx2.UnpackLow(v0, v1);
        var ab2367 = Avx2.UnpackHigh(v0, v1);
        var cd0145 = Avx2.UnpackLow(v2, v3);
        var cd2367 = Avx2.UnpackHigh(v2, v3);
        var ef0145 = Avx2.UnpackLow(v4, v5);
        var ef2367 = Avx2.UnpackHigh(v4, v5);
        var gh0145 = Avx2.UnpackLow(v6, v7);
        var gh2367 = Avx2.UnpackHigh(v6, v7);

        // Interleave 64-bit pairs.
        var abcd04 = Avx2.UnpackLow(ab0145.AsUInt64(), cd0145.AsUInt64());
        var abcd15 = Avx2.UnpackHigh(ab0145.AsUInt64(), cd0145.AsUInt64());
        var abcd26 = Avx2.UnpackLow(ab2367.AsUInt64(), cd2367.AsUInt64());
        var abcd37 = Avx2.UnpackHigh(ab2367.AsUInt64(), cd2367.AsUInt64());
        var efgh04 = Avx2.UnpackLow(ef0145.AsUInt64(), gh0145.AsUInt64());
        var efgh15 = Avx2.UnpackHigh(ef0145.AsUInt64(), gh0145.AsUInt64());
        var efgh26 = Avx2.UnpackLow(ef2367.AsUInt64(), gh2367.AsUInt64());
        var efgh37 = Avx2.UnpackHigh(ef2367.AsUInt64(), gh2367.AsUInt64());

        // Recombine 128-bit lanes: 0x20 = low halves, 0x31 = high halves.
        vecs[0] = Avx2.Permute2x128(abcd04, efgh04, 0x20).AsUInt32();
        vecs[1] = Avx2.Permute2x128(abcd15, efgh15, 0x20).AsUInt32();
        vecs[2] = Avx2.Permute2x128(abcd26, efgh26, 0x20).AsUInt32();
        vecs[3] = Avx2.Permute2x128(abcd37, efgh37, 0x20).AsUInt32();
        vecs[4] = Avx2.Permute2x128(abcd04, efgh04, 0x31).AsUInt32();
        vecs[5] = Avx2.Permute2x128(abcd15, efgh15, 0x31).AsUInt32();
        vecs[6] = Avx2.Permute2x128(abcd26, efgh26, 0x31).AsUInt32();
        vecs[7] = Avx2.Permute2x128(abcd37, efgh37, 0x31).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GVec(
        ref Vector256<uint> a, ref Vector256<uint> b,
        ref Vector256<uint> c, ref Vector256<uint> d,
        Vector256<uint> mx, Vector256<uint> my)
    {
        a = Avx2.Add(a, Avx2.Add(b, mx));
        d = RotateRight16(Avx2.Xor(d, a));
        c = Avx2.Add(c, d);
        b = RotateRight12(Avx2.Xor(b, c));
        a = Avx2.Add(a, Avx2.Add(b, my));
        d = RotateRight8(Avx2.Xor(d, a));
        c = Avx2.Add(c, d);
        b = RotateRight7(Avx2.Xor(b, c));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<uint> RotateRight16(Vector256<uint> value) => Avx512F.VL.IsSupported
       ? Avx512F.VL.RotateRight(value, 16)
       : Avx2.Shuffle(value.AsByte(), RotateRight16Mask256).AsUInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<uint> RotateRight12(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 12)
        : Avx2.Or(Avx2.ShiftRightLogical(value, 12), Avx2.ShiftLeftLogical(value, 20));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<uint> RotateRight8(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 8)
        : Avx2.Shuffle(value.AsByte(), RotateRight8Mask256).AsUInt32();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<uint> RotateRight7(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 7)
        : Avx2.Or(Avx2.ShiftRightLogical(value, 7), Avx2.ShiftLeftLogical(value, 25));

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
