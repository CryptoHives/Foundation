// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE3 AVX-512 accelerated multi-chunk (chunk-parallel) compression.
/// </summary>
/// <remarks>
/// <para>
/// The 16-lane analogue of the AVX2 8-way kernel in
/// <c>Blake3State.Avx2.cs</c>: each of the 16 compression state words becomes
/// a <see cref="Vector512{UInt32}"/> where lane <c>j</c> holds that word's
/// value for chunk <c>j</c>, compressing 16 independent chunks (16 KB) per
/// batch. See the AVX2 file for the layout rationale; this file differs only
/// in width-specific details:
/// </para>
/// <para>
/// A 512-bit vector spans a full 64-byte block, so each chunk's block is a
/// single load and one 16×16 dword transpose replaces the two 8×8 passes.
/// Rotates use the native <see cref="Avx512F.RotateRight(Vector512{uint}, byte)"/>
/// (<c>vprord</c>) directly — no fallback needed since this path is only
/// dispatched when <see cref="Avx512F.IsSupported"/>.
/// </para>
/// </remarks>
internal unsafe partial struct Blake3State
{
    internal const int Avx512CounterVectors = 2;
    internal const int Avx512ChunksPerBatch = 16;
    internal const int Avx512BatchSizeBytes = Avx512ChunksPerBatch * ChunkSizeBytes;

    /// <summary>
    /// Tree level of one aligned 16-chunk batch: a subtree of 2^level chunks, which is what
    /// <see cref="PushSubtreeCv"/> takes. Must stay log2(<see cref="Avx512ChunksPerBatch"/>).
    /// </summary>
    internal const int Avx512BatchLevel = 4;

    // Lane i carries counter baseCounter + i, split into low and high halves. The high half comes
    // from the low half's carry rather than a branch, so no lane count appears in the arithmetic.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CounterVectors512(ulong baseCounter, out Vector512<uint> low, out Vector512<uint> high)
    {
#if NET10_0_OR_GREATER
        var lowBase = Vector512.Create((uint)baseCounter);
        low = lowBase + Vector512<uint>.Indices;
        high = Vector512.Create((uint)(baseCounter >> 32)) - Vector512.LessThan(low, lowBase);
#else
        low = Vector512.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3),
            (uint)(baseCounter + 4), (uint)(baseCounter + 5), (uint)(baseCounter + 6), (uint)(baseCounter + 7),
            (uint)(baseCounter + 8), (uint)(baseCounter + 9), (uint)(baseCounter + 10), (uint)(baseCounter + 11),
            (uint)(baseCounter + 12), (uint)(baseCounter + 13), (uint)(baseCounter + 14), (uint)(baseCounter + 15));
        high = Vector512.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32),
            (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32),
            (uint)((baseCounter + 4) >> 32), (uint)((baseCounter + 5) >> 32),
            (uint)((baseCounter + 6) >> 32), (uint)((baseCounter + 7) >> 32),
            (uint)((baseCounter + 8) >> 32), (uint)((baseCounter + 9) >> 32),
            (uint)((baseCounter + 10) >> 32), (uint)((baseCounter + 11) >> 32),
            (uint)((baseCounter + 12) >> 32), (uint)((baseCounter + 13) >> 32),
            (uint)((baseCounter + 14) >> 32), (uint)((baseCounter + 15) >> 32));
#endif
    }


    /// <summary>
    /// Runs every complete 64-chunk subtree group the remaining input allows, using this
    /// tier's 16-wide chunk kernel, and returns the advanced offset. See
    /// <see cref="CompressSubtreeGroupsAvx2"/> for why this is specialised per tier and
    /// why the loop tests length alone.
    /// </summary>
    /// <remarks>
    /// The reduction is the <em>8</em>-lane <see cref="ReduceChunkCvsToSubtreeCvAvx2"/>,
    /// not a 16-lane one: reduction width follows the widest available *parent* kernel,
    /// and there is no <c>CompressParents16Avx512</c>. The two widths are independent.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the first group starts.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer, at least 64 CVs (512 words) long.</param>
    /// <returns><paramref name="offset"/> advanced past every group compressed.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CompressSubtreeGroupsAvx512(Blake3State* core, byte* srcPtr, int offset, int length, uint* batchCvs)
    {
        do
        {
            for (int b = 0; b < ChunksPerSubtreeGroup / Avx512ChunksPerBatch; b++)
            {
                CompressChunksPartialAvx512(
                    srcPtr + offset,
                    Avx512ChunksPerBatch,
                    core->_keyWords,
                    batchCvs + b * Avx512ChunksPerBatch * KeySizeWords,
                    _chunkCounter + (ulong)(b * Avx512ChunksPerBatch),
                    _baseFlags);
                offset += Avx512BatchSizeBytes;
            }

            ReduceChunkCvsToSubtreeCvAvx2(core, batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
            PushSubtreeCv(core, batchCvs, SubtreeGroupLevel);
            _chunkCounter += ChunksPerSubtreeGroup;
        }
        while (length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes);

        return offset;
    }

    /// <summary>
    /// Compresses <paramref name="chunkCount"/> independent, full (1024-byte) chunks
    /// with the 16-way kernel by ignoring the surplus lanes (lane <c>j</c> is only
    /// loaded, and its output only stored, when <c>j &lt; chunkCount</c>). Only
    /// <paramref name="chunkCount"/> chaining values in <paramref name="outCvs"/> are
    /// valid.
    /// </summary>
    /// <remarks>
    /// Mirrors <see cref="CompressChunksPartialAvx2"/> one level wider. Every caller now
    /// passes exactly <see cref="Avx512ChunksPerBatch"/>; the lane masking is kept for the
    /// partial tail that <c>Append</c> currently declines to route here.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartialAvx512(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Vector512<uint>* m = stackalloc Vector512<uint>[BlockSizeWords];
        Vector512<uint>* cv = stackalloc Vector512<uint>[KeySizeWords];
        Vector512<uint>* counters = stackalloc Vector512<uint>[Avx512CounterVectors];

        CounterVectors512(baseCounter, out var counterLow, out var counterHigh);
        counters[0] = counterLow;
        counters[1] = counterHigh;

        for (int i = 0; i < KeySizeWords; i++)
        {
            cv[i] = Vector512.Create(key[i]);
        }

        uint middleFlags = baseFlags;
        uint endFlags = baseFlags | FlagChunkEnd;
        uint flags = baseFlags | FlagChunkStart;
        byte* blockBase = source;

        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            for (int j = 0; j < chunkCount; j++)
            {
                m[j] = Avx512F.LoadVector512((uint*)(blockBase + j * ChunkSizeBytes));
            }

            Transpose16x16(m);

            CompressVector512(cv, m, counters, flags);

            flags = (blockIdx >= BlocksPerChunk - 2) ? endFlags : middleFlags;
            blockBase += BlockSizeBytes;
        }

        for (int i = 0; i < KeySizeWords; i++)
        {
            m[i] = cv[i];
        }

        Transpose16x16(m);
        for (int chunkIdx = 0; chunkIdx < chunkCount; chunkIdx++)
        {
            Avx.Store(outCvs, m[chunkIdx].GetLower());
            outCvs += KeySizeWords;
        }
    }

    // Mirrors Blake3State.Compress with each uint word replaced by a Vector512<uint>
    // across 16 chunks, folding one block position back into cv[0..7]. NoInlining is
    // deliberate: standalone, only the 16 state locals compete for the 32 ZMM registers,
    // so the rounds run spill-free.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CompressVector512(
        Vector512<uint>* cv, Vector512<uint>* m, Vector512<uint>* counters, uint flags)
    {
        var v0 = cv[0];
        var v1 = cv[1];
        var v2 = cv[2];
        var v3 = cv[3];
        var v4 = cv[4];
        var v5 = cv[5];
        var v6 = cv[6];
        var v7 = cv[7];
        var v8 = Vector512.Create(IV0);
        var v9 = Vector512.Create(IV1);
        var v10 = Vector512.Create(IV2);
        var v11 = Vector512.Create(IV3);
        var v12 = counters[0];
        var v13 = counters[1];
        var v14 = Vector512.Create((uint)BlockSizeBytes);
        var v15 = Vector512.Create(flags);

        // Round 1
        GVec(ref v0, ref v4, ref v8, ref v12, m, 0, 1);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 2, 3);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 4, 5);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 6, 7);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 8, 9);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 10, 11);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 12, 13);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 14, 15);

        // Round 2
        GVec(ref v0, ref v4, ref v8, ref v12, m, 2, 6);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 3, 10);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 7, 0);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 4, 13);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 1, 11);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 12, 5);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 9, 14);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 15, 8);

        // Round 3
        GVec(ref v0, ref v4, ref v8, ref v12, m, 3, 4);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 10, 12);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 13, 2);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 7, 14);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 6, 5);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 9, 0);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 11, 15);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 8, 1);

        // Round 4
        GVec(ref v0, ref v4, ref v8, ref v12, m, 10, 7);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 12, 9);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 14, 3);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 13, 15);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 4, 0);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 11, 2);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 5, 8);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 1, 6);

        // Round 5
        GVec(ref v0, ref v4, ref v8, ref v12, m, 12, 13);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 9, 11);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 15, 10);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 14, 8);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 7, 2);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 5, 3);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 0, 1);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 6, 4);

        // Round 6
        GVec(ref v0, ref v4, ref v8, ref v12, m, 9, 14);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 11, 5);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 8, 12);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 15, 1);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 13, 3);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 0, 10);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 2, 6);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 4, 7);

        // Round 7
        GVec(ref v0, ref v4, ref v8, ref v12, m, 11, 15);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 5, 0);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 1, 9);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 8, 6);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 14, 10);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 2, 12);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 3, 4);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 7, 13);

        cv[0] = Avx512F.Xor(v0, v8);
        cv[1] = Avx512F.Xor(v1, v9);
        cv[2] = Avx512F.Xor(v2, v10);
        cv[3] = Avx512F.Xor(v3, v11);
        cv[4] = Avx512F.Xor(v4, v12);
        cv[5] = Avx512F.Xor(v5, v13);
        cv[6] = Avx512F.Xor(v6, v14);
        cv[7] = Avx512F.Xor(v7, v15);
    }

    // Squeeze twin of CompressVector512, differing only in what an XOF output block needs:
    // blockLen is a parameter (the root block is whatever the final input block was), and
    // both folds are emitted, since a squeeze block is the full 16 words. cv is left
    // untouched so the caller's root CV survives the second fold and the next call.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CompressVector512Squeeze(
        Vector512<uint>* cv, Vector512<uint>* m, Vector512<uint>* counters,
        uint blockLen, uint flags)
    {
        var v0 = cv[0];
        var v1 = cv[1];
        var v2 = cv[2];
        var v3 = cv[3];
        var v4 = cv[4];
        var v5 = cv[5];
        var v6 = cv[6];
        var v7 = cv[7];
        var v8 = Vector512.Create(IV0);
        var v9 = Vector512.Create(IV1);
        var v10 = Vector512.Create(IV2);
        var v11 = Vector512.Create(IV3);
        var v12 = counters[0];
        var v13 = counters[1];
        var v14 = Vector512.Create(blockLen);
        var v15 = Vector512.Create(flags);

        // Round 1
        GVec(ref v0, ref v4, ref v8, ref v12, m, 0, 1);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 2, 3);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 4, 5);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 6, 7);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 8, 9);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 10, 11);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 12, 13);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 14, 15);

        // Round 2
        GVec(ref v0, ref v4, ref v8, ref v12, m, 2, 6);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 3, 10);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 7, 0);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 4, 13);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 1, 11);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 12, 5);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 9, 14);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 15, 8);

        // Round 3
        GVec(ref v0, ref v4, ref v8, ref v12, m, 3, 4);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 10, 12);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 13, 2);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 7, 14);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 6, 5);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 9, 0);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 11, 15);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 8, 1);

        // Round 4
        GVec(ref v0, ref v4, ref v8, ref v12, m, 10, 7);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 12, 9);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 14, 3);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 13, 15);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 4, 0);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 11, 2);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 5, 8);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 1, 6);

        // Round 5
        GVec(ref v0, ref v4, ref v8, ref v12, m, 12, 13);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 9, 11);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 15, 10);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 14, 8);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 7, 2);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 5, 3);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 0, 1);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 6, 4);

        // Round 6
        GVec(ref v0, ref v4, ref v8, ref v12, m, 9, 14);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 11, 5);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 8, 12);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 15, 1);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 13, 3);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 0, 10);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 2, 6);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 4, 7);

        // Round 7
        GVec(ref v0, ref v4, ref v8, ref v12, m, 11, 15);
        GVec(ref v1, ref v5, ref v9, ref v13, m, 5, 0);
        GVec(ref v2, ref v6, ref v10, ref v14, m, 1, 9);
        GVec(ref v3, ref v7, ref v11, ref v15, m, 8, 6);
        GVec(ref v0, ref v5, ref v10, ref v15, m, 14, 10);
        GVec(ref v1, ref v6, ref v11, ref v12, m, 2, 12);
        GVec(ref v2, ref v7, ref v8, ref v13, m, 3, 4);
        GVec(ref v3, ref v4, ref v9, ref v14, m, 7, 13);

        m[0] = Avx512F.Xor(v0, v8); m[8] = Avx512F.Xor(v8, cv[0]);
        m[1] = Avx512F.Xor(v1, v9); m[9] = Avx512F.Xor(v9, cv[1]);
        m[2] = Avx512F.Xor(v2, v10); m[10] = Avx512F.Xor(v10, cv[2]);
        m[3] = Avx512F.Xor(v3, v11); m[11] = Avx512F.Xor(v11, cv[3]);
        m[4] = Avx512F.Xor(v4, v12); m[12] = Avx512F.Xor(v12, cv[4]);
        m[5] = Avx512F.Xor(v5, v13); m[13] = Avx512F.Xor(v13, cv[5]);
        m[6] = Avx512F.Xor(v6, v14); m[14] = Avx512F.Xor(v14, cv[6]);
        m[7] = Avx512F.Xor(v7, v15); m[15] = Avx512F.Xor(v15, cv[7]);
    }

    /// <summary>
    /// Squeezes <see cref="Avx512ChunksPerBatch"/> consecutive output blocks
    /// (counters <paramref name="startCounter"/> .. +15) into
    /// <paramref name="dst"/>, which must have room for all of them.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The 16-wide counterpart of <c>SqueezeRootBlocks8Avx2</c>. Squeeze blocks are
    /// independent - every lane compresses the same root block and chaining value and
    /// only the counter differs - so there is nothing to transpose in: each message
    /// and CV word is broadcast to all 16 lanes.
    /// </para>
    /// <para>
    /// The un-transpose is where the 512-bit width pays twice. 16 lanes by 16 output
    /// words is exactly square, so one <see cref="Transpose16x16"/> puts whole blocks
    /// in <c>halves[j]</c> and each block leaves in a single 64-byte store - where the
    /// 8-wide kernel needs two 8x8 transposes and two half-block stores per block.
    /// </para>
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocks16Avx512(Blake3State* core, ulong startCounter, byte* dst)
    {
        uint* rootCv = core->_rootCv;
        uint* rootBlock = core->_rootBlock;

        Vector512<uint>* m = stackalloc Vector512<uint>[BlockSizeWords];
        Vector512<uint>* cv = stackalloc Vector512<uint>[KeySizeWords];
        Vector512<uint>* counters = stackalloc Vector512<uint>[Avx512CounterVectors];

        for (int w = 0; w < BlockSizeWords; w++)
        {
            m[w] = Vector512.Create(rootBlock[w]);
        }

        for (int i = 0; i < KeySizeWords; i++)
        {
            cv[i] = Vector512.Create(rootCv[i]);
        }

        CounterVectors512(startCounter, out var counterLow, out var counterHigh);
        counters[0] = counterLow;
        counters[1] = counterHigh;

        CompressVector512Squeeze(cv, m, counters, _rootBlockLen, _rootFlags);

        // m[w] holds word w of all 16 blocks; transposing leaves m[j]
        // holding all 16 words of block j - a whole 64-byte output block.
        Transpose16x16(m);

        for (int j = 0; j < Avx512ChunksPerBatch; j++)
        {
            Avx512F.Store((uint*)(dst + j * BlockSizeBytes), m[j]);
        }
    }



    /// <summary>
    /// In-place 16×16 transpose of 32-bit words: on input <c>vecs[j]</c> holds
    /// 16 consecutive words of chunk <c>j</c>; on output <c>vecs[w]</c> holds
    /// word <c>w</c> of all 16 chunks (lane <c>j</c> = chunk <c>j</c>).
    /// </summary>
    /// <remarks>
    /// Same structure as the AVX2 <c>Transpose8x8</c> with one extra level:
    /// dword unpacks, qword unpacks, then two rounds of
    /// <see cref="Avx512F.Shuffle4x128(Vector512{uint}, Vector512{uint}, byte)"/>
    /// (0x88 = even 128-bit lanes, 0xDD = odd lanes) to recombine lanes across
    /// the 4-lane 512-bit registers. Intermediate names track source rows
    /// (letters a–p) and the column each lane group carries.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void Transpose16x16(Vector512<uint>* vecs)
    {
        // NoInlining: the flat single-assignment body needs ~48 vector locals, past the
        // inliner's cap, and the caller keeps no ZMM state live across the call. A staged
        // variant would inline but chains through memory, which stalls on hardware that
        // cannot store-forward split 512-bit stores. Here the intermediates stay in
        // registers: 16 loads in, 16 stores out.

        // Interleave 32-bit words of row pairs: lane L of ab0 carries
        // [a,b][col 4L..4L+1], of ab2 carries [a,b][col 4L+2..4L+3].
        var ab0 = Avx512F.UnpackLow(vecs[0], vecs[1]);
        var ab2 = Avx512F.UnpackHigh(vecs[0], vecs[1]);
        var cd0 = Avx512F.UnpackLow(vecs[2], vecs[3]);
        var cd2 = Avx512F.UnpackHigh(vecs[2], vecs[3]);
        var ef0 = Avx512F.UnpackLow(vecs[4], vecs[5]);
        var ef2 = Avx512F.UnpackHigh(vecs[4], vecs[5]);
        var gh0 = Avx512F.UnpackLow(vecs[6], vecs[7]);
        var gh2 = Avx512F.UnpackHigh(vecs[6], vecs[7]);
        var ij0 = Avx512F.UnpackLow(vecs[8], vecs[9]);
        var ij2 = Avx512F.UnpackHigh(vecs[8], vecs[9]);
        var kl0 = Avx512F.UnpackLow(vecs[10], vecs[11]);
        var kl2 = Avx512F.UnpackHigh(vecs[10], vecs[11]);
        var mn0 = Avx512F.UnpackLow(vecs[12], vecs[13]);
        var mn2 = Avx512F.UnpackHigh(vecs[12], vecs[13]);
        var op0 = Avx512F.UnpackLow(vecs[14], vecs[15]);
        var op2 = Avx512F.UnpackHigh(vecs[14], vecs[15]);

        // Interleave 64-bit pairs: lane L of abcdN carries [a,b,c,d][col 4L+N].
        var abcd0 = Avx512F.UnpackLow(ab0.AsUInt64(), cd0.AsUInt64()).AsUInt32();
        var abcd1 = Avx512F.UnpackHigh(ab0.AsUInt64(), cd0.AsUInt64()).AsUInt32();
        var abcd2 = Avx512F.UnpackLow(ab2.AsUInt64(), cd2.AsUInt64()).AsUInt32();
        var abcd3 = Avx512F.UnpackHigh(ab2.AsUInt64(), cd2.AsUInt64()).AsUInt32();
        var efgh0 = Avx512F.UnpackLow(ef0.AsUInt64(), gh0.AsUInt64()).AsUInt32();
        var efgh1 = Avx512F.UnpackHigh(ef0.AsUInt64(), gh0.AsUInt64()).AsUInt32();
        var efgh2 = Avx512F.UnpackLow(ef2.AsUInt64(), gh2.AsUInt64()).AsUInt32();
        var efgh3 = Avx512F.UnpackHigh(ef2.AsUInt64(), gh2.AsUInt64()).AsUInt32();
        var ijkl0 = Avx512F.UnpackLow(ij0.AsUInt64(), kl0.AsUInt64()).AsUInt32();
        var ijkl1 = Avx512F.UnpackHigh(ij0.AsUInt64(), kl0.AsUInt64()).AsUInt32();
        var ijkl2 = Avx512F.UnpackLow(ij2.AsUInt64(), kl2.AsUInt64()).AsUInt32();
        var ijkl3 = Avx512F.UnpackHigh(ij2.AsUInt64(), kl2.AsUInt64()).AsUInt32();
        var mnop0 = Avx512F.UnpackLow(mn0.AsUInt64(), op0.AsUInt64()).AsUInt32();
        var mnop1 = Avx512F.UnpackHigh(mn0.AsUInt64(), op0.AsUInt64()).AsUInt32();
        var mnop2 = Avx512F.UnpackLow(mn2.AsUInt64(), op2.AsUInt64()).AsUInt32();
        var mnop3 = Avx512F.UnpackHigh(mn2.AsUInt64(), op2.AsUInt64()).AsUInt32();

        // First 128-bit lane recombine: lane L of abcdefghN carries
        // [a..h][col 8L+N] (0x88 keeps even source lanes, 0xDD odd).
        var abcdefgh0 = Avx512F.Shuffle4x128(abcd0, efgh0, 0x88);
        var abcdefgh1 = Avx512F.Shuffle4x128(abcd1, efgh1, 0x88);
        var abcdefgh2 = Avx512F.Shuffle4x128(abcd2, efgh2, 0x88);
        var abcdefgh3 = Avx512F.Shuffle4x128(abcd3, efgh3, 0x88);
        var abcdefgh4 = Avx512F.Shuffle4x128(abcd0, efgh0, 0xDD);
        var abcdefgh5 = Avx512F.Shuffle4x128(abcd1, efgh1, 0xDD);
        var abcdefgh6 = Avx512F.Shuffle4x128(abcd2, efgh2, 0xDD);
        var abcdefgh7 = Avx512F.Shuffle4x128(abcd3, efgh3, 0xDD);
        var ijklmnop0 = Avx512F.Shuffle4x128(ijkl0, mnop0, 0x88);
        var ijklmnop1 = Avx512F.Shuffle4x128(ijkl1, mnop1, 0x88);
        var ijklmnop2 = Avx512F.Shuffle4x128(ijkl2, mnop2, 0x88);
        var ijklmnop3 = Avx512F.Shuffle4x128(ijkl3, mnop3, 0x88);
        var ijklmnop4 = Avx512F.Shuffle4x128(ijkl0, mnop0, 0xDD);
        var ijklmnop5 = Avx512F.Shuffle4x128(ijkl1, mnop1, 0xDD);
        var ijklmnop6 = Avx512F.Shuffle4x128(ijkl2, mnop2, 0xDD);
        var ijklmnop7 = Avx512F.Shuffle4x128(ijkl3, mnop3, 0xDD);

        // Second recombine: row N of the result holds column N of all 16 rows.
        vecs[0] = Avx512F.Shuffle4x128(abcdefgh0, ijklmnop0, 0x88);
        vecs[1] = Avx512F.Shuffle4x128(abcdefgh1, ijklmnop1, 0x88);
        vecs[2] = Avx512F.Shuffle4x128(abcdefgh2, ijklmnop2, 0x88);
        vecs[3] = Avx512F.Shuffle4x128(abcdefgh3, ijklmnop3, 0x88);
        vecs[4] = Avx512F.Shuffle4x128(abcdefgh4, ijklmnop4, 0x88);
        vecs[5] = Avx512F.Shuffle4x128(abcdefgh5, ijklmnop5, 0x88);
        vecs[6] = Avx512F.Shuffle4x128(abcdefgh6, ijklmnop6, 0x88);
        vecs[7] = Avx512F.Shuffle4x128(abcdefgh7, ijklmnop7, 0x88);
        vecs[8] = Avx512F.Shuffle4x128(abcdefgh0, ijklmnop0, 0xDD);
        vecs[9] = Avx512F.Shuffle4x128(abcdefgh1, ijklmnop1, 0xDD);
        vecs[10] = Avx512F.Shuffle4x128(abcdefgh2, ijklmnop2, 0xDD);
        vecs[11] = Avx512F.Shuffle4x128(abcdefgh3, ijklmnop3, 0xDD);
        vecs[12] = Avx512F.Shuffle4x128(abcdefgh4, ijklmnop4, 0xDD);
        vecs[13] = Avx512F.Shuffle4x128(abcdefgh5, ijklmnop5, 0xDD);
        vecs[14] = Avx512F.Shuffle4x128(abcdefgh6, ijklmnop6, 0xDD);
        vecs[15] = Avx512F.Shuffle4x128(abcdefgh7, ijklmnop7, 0xDD);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GVec(
        ref Vector512<uint> a, ref Vector512<uint> b,
        ref Vector512<uint> c, ref Vector512<uint> d,
        Vector512<uint>* m,
        int mx, int my)
    {
        a = Avx512F.Add(Avx512F.Add(a, m[mx]), b);
        d = Avx512F.RotateRight(Avx512F.Xor(d, a), 16);
        c = Avx512F.Add(c, d);
        b = Avx512F.RotateRight(Avx512F.Xor(b, c), 12);
        a = Avx512F.Add(Avx512F.Add(a, m[my]), b);
        d = Avx512F.RotateRight(Avx512F.Xor(d, a), 8);
        c = Avx512F.Add(c, d);
        b = Avx512F.RotateRight(Avx512F.Xor(b, c), 7);
    }
}
#endif
