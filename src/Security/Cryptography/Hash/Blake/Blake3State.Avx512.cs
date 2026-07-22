// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

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
    internal const int ChunksPerAvx512Batch = 16;
    internal const int Avx512BatchSizeBytes = ChunksPerAvx512Batch * ChunkSizeBytes;

    /// <summary>
    /// Compresses 16 independent, full (1024-byte) chunks starting at
    /// <paramref name="source"/> in parallel, writing each chunk's 8-word
    /// chaining value contiguously into <paramref name="outCvs"/> (128 words total).
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunks16Avx512(byte* source, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        // Scratch layout: 16 message vectors, 8 chaining values, counter
        // low/high. Unlike the AVX2 kernel, the chaining values and counters
        // deliberately live in memory rather than named locals: 16 state
        // vectors plus ~18 loop-invariant values exceed the 32 ZMM registers,
        // and force-inlining the compression made the register allocator spill
        // ZMMs throughout the rounds. Keeping the per-block compression
        // out-of-line (see CompressVector512) bounds its pressure to the 16
        // state words plus temporaries.
        var scratch = stackalloc Vector512<uint>[26];
        Vector512<uint>* m = scratch;
        Vector512<uint>* cv = scratch + 16;
        Vector512<uint>* counters = scratch + 24;

        counters[0] = Vector512.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3),
            (uint)(baseCounter + 4), (uint)(baseCounter + 5), (uint)(baseCounter + 6), (uint)(baseCounter + 7),
            (uint)(baseCounter + 8), (uint)(baseCounter + 9), (uint)(baseCounter + 10), (uint)(baseCounter + 11),
            (uint)(baseCounter + 12), (uint)(baseCounter + 13), (uint)(baseCounter + 14), (uint)(baseCounter + 15));
        counters[1] = Vector512.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32), (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32),
            (uint)((baseCounter + 4) >> 32), (uint)((baseCounter + 5) >> 32), (uint)((baseCounter + 6) >> 32), (uint)((baseCounter + 7) >> 32),
            (uint)((baseCounter + 8) >> 32), (uint)((baseCounter + 9) >> 32), (uint)((baseCounter + 10) >> 32), (uint)((baseCounter + 11) >> 32),
            (uint)((baseCounter + 12) >> 32), (uint)((baseCounter + 13) >> 32), (uint)((baseCounter + 14) >> 32), (uint)((baseCounter + 15) >> 32));

        for (int i = 0; i < 8; i++)
        {
            cv[i] = Vector512.Create(key[i]);
        }

        uint middleFlags = baseFlags;
        uint startFlags = baseFlags | FlagChunkStart;
        uint endFlags = baseFlags | FlagChunkEnd;

        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            byte* blockBase = source + blockIdx * BlockSizeBytes;

            // A 512-bit vector holds a chunk's entire 64-byte block, so one
            // load per chunk followed by a single 16×16 transpose puts word w
            // of all 16 chunks into m[w] (lane j = chunk j).
            for (int j = 0; j < ChunksPerAvx512Batch; j++)
            {
                m[j] = Avx512F.LoadVector512((uint*)(blockBase + j * ChunkSizeBytes));
            }

            Transpose16x16(m);

            uint flags = blockIdx == 0 ? startFlags : (blockIdx == 15 ? endFlags : middleFlags);
            CompressVector512(cv, m, counters, flags);
        }

        // Un-transpose the CVs (word-major → chunk-major), reusing the message
        // buffer as scratch. After transposing rows 0–7 (rows 8–15 are don't-care),
        // the low 256 bits of row j hold chunk j's 8-word CV.
        for (int i = 0; i < 8; i++)
        {
            m[i] = cv[i];
        }

        Transpose16x16(m);
        for (int chunkIdx = 0; chunkIdx < ChunksPerAvx512Batch; chunkIdx++)
        {
            Avx.Store(outCvs + chunkIdx * 8, m[chunkIdx].GetLower());
        }
    }

    /// <summary>
    /// Compresses <paramref name="chunkCount"/> (9..15) independent, full
    /// (1024-byte) chunks with the 16-way kernel by pointing the surplus lanes
    /// back at the real chunks (lane <c>j</c> reads chunk <c>j</c> mod
    /// <paramref name="chunkCount"/>, so no memory outside the
    /// <paramref name="chunkCount"/>·1024 input bytes is touched); the surplus
    /// lanes' outputs are wrong (their counters don't match the duplicated
    /// data) and must be ignored. Only <paramref name="chunkCount"/> chaining
    /// values in <paramref name="outCvs"/> are valid.
    /// </summary>
    /// <remarks>
    /// Mirrors <see cref="CompressChunksPartialAvx2"/> one level wider.
    /// Without this, a 9-15 chunk tail on AVX-512F hardware falls through to
    /// one full AVX2 8-chunk batch plus a separate AVX2 partial-batch call for
    /// the remainder — two 8-wide kernel calls (two transposes, two reduction
    /// passes) instead of the one 16-wide call here.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartialAvx512(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        int* laneOffsets = stackalloc int[ChunksPerAvx512Batch];
        for (int j = 0; j < ChunksPerAvx512Batch; j++)
        {
            laneOffsets[j] = (j % chunkCount) * ChunkSizeBytes;
        }

        var scratch = stackalloc Vector512<uint>[26];
        Vector512<uint>* m = scratch;
        Vector512<uint>* cv = scratch + 16;
        Vector512<uint>* counters = scratch + 24;

        counters[0] = Vector512.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3),
            (uint)(baseCounter + 4), (uint)(baseCounter + 5), (uint)(baseCounter + 6), (uint)(baseCounter + 7),
            (uint)(baseCounter + 8), (uint)(baseCounter + 9), (uint)(baseCounter + 10), (uint)(baseCounter + 11),
            (uint)(baseCounter + 12), (uint)(baseCounter + 13), (uint)(baseCounter + 14), (uint)(baseCounter + 15));
        counters[1] = Vector512.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32), (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32),
            (uint)((baseCounter + 4) >> 32), (uint)((baseCounter + 5) >> 32), (uint)((baseCounter + 6) >> 32), (uint)((baseCounter + 7) >> 32),
            (uint)((baseCounter + 8) >> 32), (uint)((baseCounter + 9) >> 32), (uint)((baseCounter + 10) >> 32), (uint)((baseCounter + 11) >> 32),
            (uint)((baseCounter + 12) >> 32), (uint)((baseCounter + 13) >> 32), (uint)((baseCounter + 14) >> 32), (uint)((baseCounter + 15) >> 32));

        for (int i = 0; i < 8; i++)
        {
            cv[i] = Vector512.Create(key[i]);
        }

        uint middleFlags = baseFlags;
        uint startFlags = baseFlags | FlagChunkStart;
        uint endFlags = baseFlags | FlagChunkEnd;

        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            byte* blockBase = source + blockIdx * BlockSizeBytes;

            for (int j = 0; j < ChunksPerAvx512Batch; j++)
            {
                m[j] = Avx512F.LoadVector512((uint*)(blockBase + laneOffsets[j]));
            }

            Transpose16x16(m);

            uint flags = blockIdx == 0 ? startFlags : (blockIdx == 15 ? endFlags : middleFlags);
            CompressVector512(cv, m, counters, flags);
        }

        for (int i = 0; i < 8; i++)
        {
            m[i] = cv[i];
        }

        Transpose16x16(m);
        for (int chunkIdx = 0; chunkIdx < chunkCount; chunkIdx++)
        {
            Avx.Store(outCvs + chunkIdx * 8, m[chunkIdx].GetLower());
        }
    }

    // Mirrors Blake3State.Compress(uint*, uint*) exactly (same message schedule,
    // same G-function groupings), with every uint word replaced by a
    // Vector512<uint> holding that word's value for 16 independent chunks.
    // Compresses one 64-byte block position of all 16 chunks and folds the
    // result back into cv[0..7]. Kept out-of-line (NoInlining) on purpose: as
    // a standalone method only the 16 v-state locals compete for the 32 ZMM
    // registers, so the rounds run spill-free with the message words folding
    // into the adds as memory operands.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
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
        // Deliberately out-of-line (NoInlining): the flat single-assignment
        // body below needs ~48 vector locals, past the inliner's hard cap, and
        // the call is cheap because the caller keeps no ZMM state live across
        // it (chaining values and counters are memory-resident). An in-place
        // staged variant with few locals would inline, but chains all four
        // stages through memory — and Zen 4 cannot store-forward split 512-bit
        // stores, which stalled every reload. Here the three intermediate
        // stages stay entirely in registers: 16 loads in, 16 stores out.

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
        a = Avx512F.Add(a, Avx512F.Add(b, m[mx]));
        d = Avx512F.RotateRight(Avx512F.Xor(d, a), 16);
        c = Avx512F.Add(c, d);
        b = Avx512F.RotateRight(Avx512F.Xor(b, c), 12);
        a = Avx512F.Add(a, Avx512F.Add(b, m[my]));
        d = Avx512F.RotateRight(Avx512F.Xor(d, a), 8);
        c = Avx512F.Add(c, d);
        b = Avx512F.RotateRight(Avx512F.Xor(b, c), 7);
    }
}
#endif
