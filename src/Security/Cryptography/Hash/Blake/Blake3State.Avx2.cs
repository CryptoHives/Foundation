// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics;
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
    internal const int Avx2ChunksPerBatch = 8;
    internal const int Avx2BatchSizeBytes = Avx2ChunksPerBatch * ChunkSizeBytes;

    /// <summary>
    /// Tree level of one aligned 8-chunk batch: a subtree of 2^level chunks, which is what
    /// <see cref="PushSubtreeCv"/> takes. Must stay log2(<see cref="Avx2ChunksPerBatch"/>).
    /// </summary>
    internal const int Avx2BatchLevel = 3;

    // Lane i carries counter baseCounter + i, split into low and high halves. The high half comes
    // from the low half's carry rather than a branch, so no lane count appears in the arithmetic.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CounterVectors256(ulong baseCounter, out Vector256<uint> low, out Vector256<uint> high)
    {
#if NET10_0_OR_GREATER
        var lowBase = Vector256.Create((uint)baseCounter);
        low = lowBase + Vector256<uint>.Indices;
        high = Vector256.Create((uint)(baseCounter >> 32)) - Vector256.LessThan(low, lowBase);
#else
        low = Vector256.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3),
            (uint)(baseCounter + 4), (uint)(baseCounter + 5), (uint)(baseCounter + 6), (uint)(baseCounter + 7));
        high = Vector256.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32),
            (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32),
            (uint)((baseCounter + 4) >> 32), (uint)((baseCounter + 5) >> 32),
            (uint)((baseCounter + 6) >> 32), (uint)((baseCounter + 7) >> 32));
#endif
    }


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
        CounterVectors256(baseCounter, out var counterLow, out var counterHigh);
        var blockLenVec = Vector256.Create((uint)BlockSizeBytes);

        // v0..v7 *are* the running chaining value — see CompressChunks8Avx2 for
        // why the separate cv bank is pure shuttling.
        var v0 = Vector256.Create(key[0]);
        var v1 = Vector256.Create(key[1]);
        var v2 = Vector256.Create(key[2]);
        var v3 = Vector256.Create(key[3]);
        var v4 = Vector256.Create(key[4]);
        var v5 = Vector256.Create(key[5]);
        var v6 = Vector256.Create(key[6]);
        var v7 = Vector256.Create(key[7]);

        uint flags = baseFlags | FlagChunkStart;
        var m = stackalloc Vector256<uint>[BlockSizeWords];
        byte* blockBase = source;
        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            for (int j = 0; j < chunkCount; j++)
            {
                m[j] = Avx.LoadVector256((uint*)(blockBase + j * ChunkSizeBytes));
                m[j + 8] = Avx.LoadVector256((uint*)(blockBase + j * ChunkSizeBytes + (BlockSizeBytes / 2)));
            }

            Transpose8x8(m);
            Transpose8x8(m + 8);

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

            v0 = Avx2.Xor(v0, v8);
            v1 = Avx2.Xor(v1, v9);
            v2 = Avx2.Xor(v2, v10);
            v3 = Avx2.Xor(v3, v11);
            v4 = Avx2.Xor(v4, v12);
            v5 = Avx2.Xor(v5, v13);
            v6 = Avx2.Xor(v6, v14);
            v7 = Avx2.Xor(v7, v15);

            blockBase += BlockSizeBytes;
            flags = blockIdx >= BlocksPerChunk - 2 ? baseFlags | FlagChunkEnd : baseFlags;
        }

        // Un-transpose straight out of the registers. Unlike the fixed-8 kernel
        // this cannot write dst directly: only chunkCount of the eight lanes
        // hold real chunks, so the transposed CVs still land in m and the
        // bounded loop copies out just the live ones.
        Transpose8x8Into(v0, v1, v2, v3, v4, v5, v6, v7, m);
        for (int chunkIdx = 0; chunkIdx < chunkCount; chunkIdx++)
        {
            Avx.Store(outCvs + chunkIdx * KeySizeWords, m[chunkIdx]);
        }
    }

    /// <summary>
    /// Compresses exactly 8 independent, full (1024-byte) chunks with the
    /// 8-way kernel — the fully-unrolled counterpart of
    /// <see cref="CompressChunksPartialAvx2"/> for the always-full-width case.
    /// </summary>
    /// <remarks>
    /// A runtime <c>chunkCount</c> stops the JIT unrolling the load loop or keeping the
    /// pre-transpose vectors in registers, so the always-8 callers get this fixed-width
    /// twin. <paramref name="chunkCount"/> is always 8 and exists only to match the shared
    /// kernel signature.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunks8Avx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Debug.Assert(chunkCount == Avx2ChunksPerBatch, "the fixed-8 kernel compresses exactly eight chunks");

        CounterVectors256(baseCounter, out var counterLow, out var counterHigh);
        var blockLenVec = Vector256.Create((uint)BlockSizeBytes);

        // v0..v7 *are* the running chaining value: a block's output CV is
        // v[i] ^ v[i+8], which is exactly what the next block needs in v0..v7.
        // Keeping them live across the loop instead of shuttling through a
        // separate cv0..cv7 bank saves eight register-to-register moves per
        // block and, more importantly, eight simultaneously-live YMM registers
        // in a kernel whose cost is dominated by register pressure.
        var v0 = Vector256.Create(key[0]);
        var v1 = Vector256.Create(key[1]);
        var v2 = Vector256.Create(key[2]);
        var v3 = Vector256.Create(key[3]);
        var v4 = Vector256.Create(key[4]);
        var v5 = Vector256.Create(key[5]);
        var v6 = Vector256.Create(key[6]);
        var v7 = Vector256.Create(key[7]);

        uint flags = baseFlags | FlagChunkStart;
        var m = stackalloc Vector256<uint>[BlockSizeWords];
        byte* blockBase = source;
        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            // Eight named loads per half, at compile-time-constant offsets —
            // no runtime trip count, so the JIT can keep r0..r7 in registers
            // straight through the inlined transpose below instead of
            // round-tripping them through the m buffer first.
            var r0 = Avx.LoadVector256((uint*)(blockBase + 0 * ChunkSizeBytes));
            var r1 = Avx.LoadVector256((uint*)(blockBase + 1 * ChunkSizeBytes));
            var r2 = Avx.LoadVector256((uint*)(blockBase + 2 * ChunkSizeBytes));
            var r3 = Avx.LoadVector256((uint*)(blockBase + 3 * ChunkSizeBytes));
            var r4 = Avx.LoadVector256((uint*)(blockBase + 4 * ChunkSizeBytes));
            var r5 = Avx.LoadVector256((uint*)(blockBase + 5 * ChunkSizeBytes));
            var r6 = Avx.LoadVector256((uint*)(blockBase + 6 * ChunkSizeBytes));
            var r7 = Avx.LoadVector256((uint*)(blockBase + 7 * ChunkSizeBytes));
            Transpose8x8Into(r0, r1, r2, r3, r4, r5, r6, r7, m);

            r0 = Avx.LoadVector256((uint*)(blockBase + 0 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r1 = Avx.LoadVector256((uint*)(blockBase + 1 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r2 = Avx.LoadVector256((uint*)(blockBase + 2 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r3 = Avx.LoadVector256((uint*)(blockBase + 3 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r4 = Avx.LoadVector256((uint*)(blockBase + 4 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r5 = Avx.LoadVector256((uint*)(blockBase + 5 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r6 = Avx.LoadVector256((uint*)(blockBase + 6 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            r7 = Avx.LoadVector256((uint*)(blockBase + 7 * ChunkSizeBytes + (BlockSizeBytes / 2)));
            Transpose8x8Into(r0, r1, r2, r3, r4, r5, r6, r7, m + 8);

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

            v0 = Avx2.Xor(v0, v8);
            v1 = Avx2.Xor(v1, v9);
            v2 = Avx2.Xor(v2, v10);
            v3 = Avx2.Xor(v3, v11);
            v4 = Avx2.Xor(v4, v12);
            v5 = Avx2.Xor(v5, v13);
            v6 = Avx2.Xor(v6, v14);
            v7 = Avx2.Xor(v7, v15);

            blockBase += BlockSizeBytes;
            flags = blockIdx >= BlocksPerChunk - 2 ? baseFlags | FlagChunkEnd : baseFlags;
        }

        // Un-transpose straight into the caller's buffer: after the transpose
        // element j is chunk j's 8-word CV, and Vector256<uint> is exactly
        // those 8 words, so dst[j] lands at outCvs + j*8 — the same addresses
        // the old per-chunk store loop wrote, without staging through m.
        Transpose8x8Into(v0, v1, v2, v3, v4, v5, v6, v7, (Vector256<uint>*)outCvs);
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

        CounterVectors256(startCounter, out var counterLow, out var counterHigh);

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
        var m = stackalloc Vector256<uint>[BlockSizeWords];
        for (int w = 0; w < BlockSizeWords; w++)
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
        var halves = stackalloc Vector256<uint>[BlockSizeWords];
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
        // sizes destination to exactly Avx2ChunksPerBatch * BlockSizeBytes, but
        // that guarantee isn't visible across the call boundary, so Slice would
        // otherwise re-check bounds on every one of these 16 stores.
        for (int j = 0; j < Avx2ChunksPerBatch; j++)
        {
            Avx.Store((uint*)(dst + j * BlockSizeBytes), halves[j]);
            Avx.Store((uint*)(dst + j * BlockSizeBytes + (BlockSizeBytes / 2)), halves[j + 8]);
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

        // Each parent's 64-byte message block is its two child CVs side by side, so
        // lane j needs childCvs[j*16 .. j*16+15]. The loads feed Transpose8x8Into
        // directly rather than being staged into m and read back: the pointer-form
        // Transpose8x8 would store 8 vectors and immediately reload them, which is
        // 16 memory round-trips this can simply skip.
        var m = stackalloc Vector256<uint>[BlockSizeWords];

        Transpose8x8Into(
            Avx.LoadVector256(childCvs + 0 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 1 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 2 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 3 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 4 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 5 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 6 * ParentStrideWords),
            Avx.LoadVector256(childCvs + 7 * ParentStrideWords),
            m);

        Transpose8x8Into(
            Avx.LoadVector256(childCvs + 0 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 1 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 2 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 3 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 4 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 5 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 6 * ParentStrideWords + KeySizeWords),
            Avx.LoadVector256(childCvs + 7 * ParentStrideWords + KeySizeWords),
            m + 8);

        var v8 = iv0; var v9 = iv1; var v10 = iv2; var v11 = iv3;
        var v12 = Vector256<uint>.Zero;   // parent counter is always 0
        var v13 = Vector256<uint>.Zero;
        var v14 = blockLenVec;
        var v15 = flagsVec;

        CompressVector256(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        // The fold v[i] ^ v[i+8] goes straight through the transpose into outCvs,
        // matching CompressChunks8Avx2. Staging it back through m would cost 8
        // stores, a reload inside the in-place transpose, and a store loop on the
        // way out, for a result the registers already hold.
        Transpose8x8Into(
            Avx2.Xor(v0, v8), Avx2.Xor(v1, v9), Avx2.Xor(v2, v10), Avx2.Xor(v3, v11),
            Avx2.Xor(v4, v12), Avx2.Xor(v5, v13), Avx2.Xor(v6, v14), Avx2.Xor(v7, v15),
            (Vector256<uint>*)outCvs);
    }

    /// <summary>
    /// The preferred subtree granularity for the batched fast paths: chunk CVs
    /// from consecutive kernel batches accumulate until 64 are available, so
    /// the surplus-lane reduction tail (8→4→2) amortizes over 64 KB instead of
    /// being paid per kernel batch.
    /// </summary>
    internal const int ChunksPerSubtreeGroup = 64;

    /// <summary>
    /// Tree level of one 64-chunk subtree group: a subtree of 2^level chunks, which is what
    /// <see cref="PushSubtreeCv"/> takes. Must stay log2(<see cref="ChunksPerSubtreeGroup"/>).
    /// </summary>
    internal const int SubtreeGroupLevel = 6;


    /// <summary>
    /// Runs every complete 64-chunk subtree group the remaining input allows, using this
    /// tier's 8-wide chunk kernel and 8-lane parent reduction, and returns the advanced
    /// offset.
    /// </summary>
    /// <remarks>
    /// The caller's guard tests both 64-chunk counter alignment and remaining length, but
    /// only length can change while looping: adding <see cref="ChunksPerSubtreeGroup"/> to
    /// an already-aligned counter leaves it aligned, so the loop re-tests length alone.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the first group starts.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer, at least 64 CVs (512 words) long.</param>
    /// <returns><paramref name="offset"/> advanced past every group compressed.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CompressSubtreeGroupsAvx2(Blake3State* core, byte* srcPtr, int offset, int length, uint* batchCvs)
    {
        do
        {
            for (int b = 0; b < ChunksPerSubtreeGroup / Avx2ChunksPerBatch; b++)
            {
                CompressChunks8Avx2(
                    srcPtr + offset,
                    Avx2ChunksPerBatch,
                    core->_keyWords,
                    batchCvs + b * Avx2ChunksPerBatch * KeySizeWords,
                    _chunkCounter + (ulong)(b * Avx2ChunksPerBatch),
                    _baseFlags);
                offset += Avx2BatchSizeBytes;
            }

            ReduceChunkCvsToSubtreeCvAvx2(core, batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
            PushSubtreeCv(core, batchCvs, SubtreeGroupLevel);
            _chunkCounter += ChunksPerSubtreeGroup;
        }
        while (length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes);

        return offset;
    }

    /// <summary>
    /// Compresses the 2-7 chunk tail left by the 8-chunk batch loop and commits its CVs,
    /// returning the bytes consumed.
    /// </summary>
    /// <remarks>
    /// Only the loads and stores are bounded by the count: the 8-lane kernel's rounds run
    /// full width whatever it is, and surplus lanes are discarded, so 5 chunks cost the same
    /// as 7. Below that the row-oriented kernels take over - one pair chain at exactly 2, two
    /// chains at 3 or 4 where the wider register file allows it. Narrowing the vector instead
    /// does not help: halving the lanes does not halve the work.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the tail starts.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer for the kernel's output CVs.</param>
    /// <returns>The number of bytes consumed.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CommitPartialBatchAvx2(Blake3State* core, byte* srcPtr, int offset, int length, uint* batchCvs)
    {
        int fullChunks = (length - offset) / ChunkSizeBytes;
        Debug.Assert(fullChunks >= Avx2PairChunksPerBatch && fullChunks < Avx2ChunksPerBatch,
            "the 8-chunk batch loop leaves 2..7 chunks here");
        bool drainsRemainingInput = offset + (fullChunks * ChunkSizeBytes) == length;

        if (fullChunks == Avx2PairChunksPerBatch)
        {
            CompressChunks2Avx2(
                srcPtr + offset, Avx2PairChunksPerBatch, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);
        }
        else if (fullChunks <= Avx2PairX2ChunksPerBatch
            && Avx512F.VL.IsSupported
            && (_simdSupport & SimdSupport.Avx512F) != 0)
        {
            CompressChunks4Avx2(
                srcPtr + offset, fullChunks, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);
        }
        else
        {
            CompressChunksPartialAvx2(
                srcPtr + offset, fullChunks, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);
        }

        CommitBatchChunks(core, batchCvs, 0, drainsRemainingInput ? fullChunks - 1 : fullChunks, drainsRemainingInput);
        return fullChunks * ChunkSizeBytes;
    }

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

    /// <param name="core">Pointer to the instance; only the final 2 → 1 merge needs it.</param>
    /// <param name="cvs">The chunk CVs to reduce, in place; receives the subtree CV at [0..8).</param>
    /// <param name="key">The 8-word key/IV words for this hash.</param>
    /// <param name="chunkCount">Number of chunk CVs to reduce; a power of two.</param>
    /// <param name="baseFlags">Mode flags for the parent compressions.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ReduceChunkCvsToSubtreeCvAvx2(Blake3State* core, uint* cvs, uint* key, int chunkCount, uint baseFlags)
    {
        // Full-width levels: every 8-parent group is fully populated.
        while (chunkCount >= 16)
        {
            int parents = chunkCount >> 1;
            for (int g = 0; g < parents; g += 8)
            {
                CompressParents8Avx2(cvs + g * ParentStrideWords, key, cvs + g * KeySizeWords, baseFlags);
            }

            chunkCount = parents;
        }

        CompressParents8Avx2(cvs, key, cvs, baseFlags);        // 8 -> 4 (upper 4 lanes ignored)
        CompressParents8Avx2(cvs, key, cvs, baseFlags);        // 4 -> 2 (upper 6 lanes ignored)
        core->ComputeParentCv(cvs, key, cvs);                  // 2 -> 1
    }

    // Mirrors Blake3State.Compress(uint*, uint*) exactly (same message schedule,
    // same G-function groupings), with every uint word replaced by a
    // Vector256<uint> holding that word's value for 8 independent chunks.
    // The 16 state words are ref parameters (not an array) and the method is
    // force-inlined so that, after inlining into the caller's block loop, the
    // state maps onto the 16 YMM registers instead of stack slots.
    //
    // Message words are read into locals up front. Reading m[..] at each GVec instead -
    // which is what the 128-bit compressor does - measurably regresses this width on both
    // register files: there are no temporaries competing for the YMM registers here, so it
    // frees nothing and only adds loads.
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
    private static void Transpose8x8(Vector256<uint>* vecs) =>
        Transpose8x8Into(vecs[0], vecs[1], vecs[2], vecs[3], vecs[4], vecs[5], vecs[6], vecs[7], vecs);

    /// <summary>
    /// Same transpose as <see cref="Transpose8x8"/>, but taking the eight
    /// input rows by value instead of reading them from <paramref name="dst"/>
    /// first. Lets a caller that already has <c>v0..v7</c> as named locals —
    /// straight out of eight <c>Avx.LoadVector256</c> calls, say — feed them
    /// in directly, so the JIT never has to prove a stackalloc round-trip is
    /// redundant: there isn't one.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose8x8Into(
        Vector256<uint> v0, Vector256<uint> v1, Vector256<uint> v2, Vector256<uint> v3,
        Vector256<uint> v4, Vector256<uint> v5, Vector256<uint> v6, Vector256<uint> v7,
        Vector256<uint>* dst)
    {
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
        dst[0] = Avx2.Permute2x128(abcd04, efgh04, 0x20).AsUInt32();
        dst[1] = Avx2.Permute2x128(abcd15, efgh15, 0x20).AsUInt32();
        dst[2] = Avx2.Permute2x128(abcd26, efgh26, 0x20).AsUInt32();
        dst[3] = Avx2.Permute2x128(abcd37, efgh37, 0x20).AsUInt32();
        dst[4] = Avx2.Permute2x128(abcd04, efgh04, 0x31).AsUInt32();
        dst[5] = Avx2.Permute2x128(abcd15, efgh15, 0x31).AsUInt32();
        dst[6] = Avx2.Permute2x128(abcd26, efgh26, 0x31).AsUInt32();
        dst[7] = Avx2.Permute2x128(abcd37, efgh37, 0x31).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GVec(
        ref Vector256<uint> a, ref Vector256<uint> b,
        ref Vector256<uint> c, ref Vector256<uint> d,
        Vector256<uint> mx, Vector256<uint> my)
    {
        a = Avx2.Add(Avx2.Add(a, mx), b);
        d = RotateRight16(Avx2.Xor(d, a));
        c = Avx2.Add(c, d);
        b = RotateRight12(Avx2.Xor(b, c));
        a = Avx2.Add(Avx2.Add(a, my), b);
        d = RotateRight8(Avx2.Xor(d, a));
        c = Avx2.Add(c, d);
        b = RotateRight7(Avx2.Xor(b, c));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> RotateRight16(Vector256<uint> value) => Avx512F.VL.IsSupported
       ? Avx512F.VL.RotateRight(value, 16)
       : Avx2.Or(Avx2.ShiftRightLogical(value, 16), Avx2.ShiftLeftLogical(value, 16));

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> RotateRight12(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 12)
        : Avx2.Or(Avx2.ShiftRightLogical(value, 12), Avx2.ShiftLeftLogical(value, 20));

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> RotateRight8(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 8)
        : Avx2.Or(Avx2.ShiftRightLogical(value, 8), Avx2.ShiftLeftLogical(value, 24));

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> RotateRight7(Vector256<uint> value) => Avx512F.VL.IsSupported
        ? Avx512F.VL.RotateRight(value, 7)
        : Avx2.Or(Avx2.ShiftRightLogical(value, 7), Avx2.ShiftLeftLogical(value, 25));
}
#endif
