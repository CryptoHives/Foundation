// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE3 ARM NEON-accelerated compression using AdvSimd intrinsics.
/// </summary>
internal unsafe partial struct Blake3State
{
    /// <summary>
    /// Performs one G round on 4 parallel lanes using ARM NEON intrinsics.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundNeon(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = AdvSimd.Add(a, AdvSimd.Add(b, x));
        // d = ror(d ^ a, 16) — TBL byte shuffle
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 12) — shift+or (not byte-aligned)
        var t1 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t1, 12), AdvSimd.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = AdvSimd.Add(a, AdvSimd.Add(b, y));
        // d = ror(d ^ a, 8) — TBL byte shuffle
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = AdvSimd.Add(c, d);
        // b = ror(b ^ c, 7) — shift+or (not byte-aligned)
        var t2 = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t2, 7), AdvSimd.ShiftLeftLogical(t2, 25));
    }

    // ------------------------------------------------------------------
    // Chunk-parallel (4-wide) NEON compression.
    //
    // Mirrors Blake3State.Avx2.cs exactly, one register width down: NEON's
    // Vector128<uint> holds 4 lanes instead of AVX2's 8, so every chunk batch,
    // parent-reduction, and squeeze kernel here processes 4 independent chunks
    // (or output blocks) at once instead of 8. See the AVX2 file's remarks for
    // the rationale (each of the 16 compression state words becomes its own
    // vector, lane j = chunk j; no diagonalize/permute needed since chunks are
    // independent tree leaves).
    // ------------------------------------------------------------------

    internal const int ChunksPerNeonBatch = 4;
    internal const int NeonBatchSizeBytes = ChunksPerNeonBatch * ChunkSizeBytes;

    /// <summary>
    /// Compresses <paramref name="chunkCount"/> (2..4) independent, full
    /// (1024-byte) chunks with the 4-way kernel by pointing the surplus lanes
    /// back at the real chunks (lane <c>j</c> reads chunk <c>j</c> mod
    /// <paramref name="chunkCount"/>, so no memory outside the
    /// <paramref name="chunkCount"/>·1024 input bytes is touched); the surplus
    /// lanes' outputs are wrong (their counters don't match the duplicated
    /// data) and must be ignored. Only <paramref name="chunkCount"/> chaining
    /// values in <paramref name="outCvs"/> are valid. At <paramref name="chunkCount"/>
    /// == 4, <c>j % chunkCount == j</c> for every lane, so the lane-offset table
    /// degenerates to the same direct addressing the exact 4-chunk case would
    /// use — this single kernel serves both the exact-batch and partial-tail
    /// call sites, mirroring <see cref="CompressChunksPartialAvx2"/>.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartialNeon(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        int* laneOffsets = stackalloc int[ChunksPerNeonBatch];
        for (int j = 0; j < ChunksPerNeonBatch; j++)
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
        cv0 = Vector128.Create(key[0]); cv1 = Vector128.Create(key[1]);
        cv2 = Vector128.Create(key[2]); cv3 = Vector128.Create(key[3]);
        cv4 = Vector128.Create(key[4]); cv5 = Vector128.Create(key[5]);
        cv6 = Vector128.Create(key[6]); cv7 = Vector128.Create(key[7]);

        var m = stackalloc Vector128<uint>[16];
        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            byte* blockBase = source + blockIdx * BlockSizeBytes;

            for (int g = 0; g < 4; g++)
            {
                for (int j = 0; j < ChunksPerNeonBatch; j++)
                {
                    m[g * 4 + j] = AdvSimd.LoadVector128((uint*)(blockBase + laneOffsets[j] + g * 16));
                }

                Transpose4x4Neon(m + g * 4);
            }

            uint flags = blockIdx == 0 ? baseFlags | FlagChunkStart : (blockIdx == 15 ? baseFlags | FlagChunkEnd : baseFlags);

            var v0 = cv0; var v1 = cv1; var v2 = cv2; var v3 = cv3;
            var v4 = cv4; var v5 = cv5; var v6 = cv6; var v7 = cv7;
            var v8 = Vector128.Create(IV0); var v9 = Vector128.Create(IV1);
            var v10 = Vector128.Create(IV2); var v11 = Vector128.Create(IV3);
            var v12 = counterLow;
            var v13 = counterHigh;
            var v14 = blockLenVec;
            var v15 = Vector128.Create(flags);

            CompressVector128(
                ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
                ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
                m);

            cv0 = v0 ^ v8;
            cv1 = v1 ^ v9;
            cv2 = v2 ^ v10;
            cv3 = v3 ^ v11;
            cv4 = v4 ^ v12;
            cv5 = v5 ^ v13;
            cv6 = v6 ^ v14;
            cv7 = v7 ^ v15;
        }

        // Un-transpose the CVs (word-major → chunk-major) with the same 4×4 network —
        // both groups must be transposed before any store. Only chunkCount (2..4)
        // chunks are valid/requested here; a surplus lane's slot (whenever
        // chunkCount < 4) is never written, since the caller's outCvs buffer is
        // only sized for chunkCount chunks.
        Transpose4x4Neon(ref cv0, ref cv1, ref cv2, ref cv3);
        Transpose4x4Neon(ref cv4, ref cv5, ref cv6, ref cv7);

        AdvSimd.Store(outCvs, cv0); AdvSimd.Store(outCvs + 4, cv4);
        AdvSimd.Store(outCvs + 8, cv1); AdvSimd.Store(outCvs + 12, cv5);
        if (chunkCount > 2)
        {
            AdvSimd.Store(outCvs + 16, cv2); AdvSimd.Store(outCvs + 20, cv6);
            if (chunkCount > 3)
            {
                AdvSimd.Store(outCvs + 24, cv3); AdvSimd.Store(outCvs + 28, cv7);
            }
        }
    }

    /// <summary>
    /// Squeezes 4 independent, consecutive output blocks (counters
    /// <paramref name="startCounter"/>..+3) into <paramref name="dst"/>
    /// (256 bytes) in one call, reusing the same transpose kernel as chunk
    /// compression.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocks4Neon(Blake3State* core, ulong startCounter, byte* dst)
    {
        uint* rootCv = core->_rootCv;
        uint* rootBlock = core->_rootBlock;
        uint blockLen = _rootBlockLen;
        uint flags = _rootFlags;

        var counterLow = Vector128.Create(
            (uint)(startCounter + 0), (uint)(startCounter + 1),
            (uint)(startCounter + 2), (uint)(startCounter + 3));
        var counterHigh = Vector128.Create(
            (uint)((startCounter + 0) >> 32), (uint)((startCounter + 1) >> 32),
            (uint)((startCounter + 2) >> 32), (uint)((startCounter + 3) >> 32));

        var cv0 = Vector128.Create(rootCv[0]); var cv1 = Vector128.Create(rootCv[1]);
        var cv2 = Vector128.Create(rootCv[2]); var cv3 = Vector128.Create(rootCv[3]);
        var cv4 = Vector128.Create(rootCv[4]); var cv5 = Vector128.Create(rootCv[5]);
        var cv6 = Vector128.Create(rootCv[6]); var cv7 = Vector128.Create(rootCv[7]);

        var v0 = cv0; var v1 = cv1; var v2 = cv2; var v3 = cv3;
        var v4 = cv4; var v5 = cv5; var v6 = cv6; var v7 = cv7;
        var v8 = Vector128.Create(IV0); var v9 = Vector128.Create(IV1);
        var v10 = Vector128.Create(IV2); var v11 = Vector128.Create(IV3);
        var v12 = counterLow;
        var v13 = counterHigh;
        var v14 = Vector128.Create(blockLen);
        var v15 = Vector128.Create(flags);

        // No transpose-in: every lane compresses the same message, so each of
        // the 16 words is simply broadcast rather than gathered per-lane.
        var m = stackalloc Vector128<uint>[16];
        for (int w = 0; w < 16; w++)
        {
            m[w] = Vector128.Create(rootBlock[w]);
        }

        CompressVector128(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        v0 = v0 ^ v8; v1 = v1 ^ v9; v2 = v2 ^ v10; v3 = v3 ^ v11;
        v4 = v4 ^ v12; v5 = v5 ^ v13; v6 = v6 ^ v14; v7 = v7 ^ v15;
        v8 = v8 ^ cv0; v9 = v9 ^ cv1; v10 = v10 ^ cv2; v11 = v11 ^ cv3;
        v12 = v12 ^ cv4; v13 = v13 ^ cv5; v14 = v14 ^ cv6; v15 = v15 ^ cv7;

        Transpose4x4Neon(ref v0, ref v1, ref v2, ref v3);
        Transpose4x4Neon(ref v4, ref v5, ref v6, ref v7);
        Transpose4x4Neon(ref v8, ref v9, ref v10, ref v11);
        Transpose4x4Neon(ref v12, ref v13, ref v14, ref v15);

        AdvSimd.Store((uint*)(dst), v0);
        AdvSimd.Store((uint*)(dst + 16), v4);
        AdvSimd.Store((uint*)(dst + 32), v8);
        AdvSimd.Store((uint*)(dst + 48), v12);

        dst += BlockSizeBytes;
        AdvSimd.Store((uint*)(dst), v1);
        AdvSimd.Store((uint*)(dst + 16), v5);
        AdvSimd.Store((uint*)(dst + 32), v9);
        AdvSimd.Store((uint*)(dst + 48), v13);

        dst += BlockSizeBytes;
        AdvSimd.Store((uint*)(dst), v2);
        AdvSimd.Store((uint*)(dst + 16), v6);
        AdvSimd.Store((uint*)(dst + 32), v10);
        AdvSimd.Store((uint*)(dst + 48), v14);

        dst += BlockSizeBytes;
        AdvSimd.Store((uint*)(dst), v3);
        AdvSimd.Store((uint*)(dst + 16), v7);
        AdvSimd.Store((uint*)(dst + 32), v11);
        AdvSimd.Store((uint*)(dst + 48), v15);
    }

    /// <summary>
    /// Compresses 4 independent parent nodes in parallel: parent <c>j</c>'s
    /// 64-byte message block is the two contiguous child CVs at
    /// <paramref name="childCvs"/> + j·16 words, writing each parent's 8-word
    /// CV contiguously into <paramref name="outCvs"/> (32 words total).
    /// </summary>
    /// <remarks>
    /// All child blocks are loaded before any output is stored, so in-place
    /// reduction (<paramref name="outCvs"/> == <paramref name="childCvs"/>) is
    /// safe. When fewer than 4 parents are needed, the surplus lanes compress
    /// whatever the buffer holds and their outputs are simply ignored — the
    /// caller must guarantee the buffer is at least 4 parent blocks
    /// (256 bytes) long so the loads stay in bounds.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressParents4Neon(uint* childCvs, uint* key, uint* outCvs, uint baseFlags)
    {
        var blockLenVec = Vector128.Create((uint)BlockSizeBytes);
        var iv0 = Vector128.Create(IV0); var iv1 = Vector128.Create(IV1);
        var iv2 = Vector128.Create(IV2); var iv3 = Vector128.Create(IV3);
        var flagsVec = Vector128.Create(baseFlags | FlagParent);

        Vector128<uint> v0, v1, v2, v3, v4, v5, v6, v7;
        v0 = Vector128.Create(key[0]); v1 = Vector128.Create(key[1]);
        v2 = Vector128.Create(key[2]); v3 = Vector128.Create(key[3]);
        v4 = Vector128.Create(key[4]); v5 = Vector128.Create(key[5]);
        v6 = Vector128.Create(key[6]); v7 = Vector128.Create(key[7]);

        var m = stackalloc Vector128<uint>[16];
        for (int j = 0; j < ChunksPerNeonBatch; j++)
        {
            m[j] = AdvSimd.LoadVector128(childCvs + j * 16);
            m[j + 4] = AdvSimd.LoadVector128(childCvs + j * 16 + 4);
            m[j + 8] = AdvSimd.LoadVector128(childCvs + j * 16 + 8);
            m[j + 12] = AdvSimd.LoadVector128(childCvs + j * 16 + 12);
        }

        Transpose4x4Neon(m);
        Transpose4x4Neon(m + 4);
        Transpose4x4Neon(m + 8);
        Transpose4x4Neon(m + 12);

        var v8 = iv0; var v9 = iv1; var v10 = iv2; var v11 = iv3;
        var v12 = Vector128<uint>.Zero;   // parent counter is always 0
        var v13 = Vector128<uint>.Zero;
        var v14 = blockLenVec;
        var v15 = flagsVec;

        CompressVector128(
            ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
            ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
            m);

        v0 = v0 ^ v8; v1 = v1 ^ v9;
        v2 = v2 ^ v10; v3 = v3 ^ v11;
        v4 = v4 ^ v12; v5 = v5 ^ v13;
        v6 = v6 ^ v14; v7 = v7 ^ v15;

        Transpose4x4Neon(ref v0, ref v1, ref v2, ref v3);
        Transpose4x4Neon(ref v4, ref v5, ref v6, ref v7);

        AdvSimd.Store(outCvs, v0); AdvSimd.Store(outCvs + 4, v4);
        AdvSimd.Store(outCvs + 8, v1); AdvSimd.Store(outCvs + 12, v5);
        AdvSimd.Store(outCvs + 16, v2); AdvSimd.Store(outCvs + 20, v6);
        AdvSimd.Store(outCvs + 24, v3); AdvSimd.Store(outCvs + 28, v7);
    }

    /// <summary>
    /// Reduces <paramref name="chunkCount"/> (a power of two: 4, 16 or 64)
    /// contiguous chunk CVs to a single subtree CV at <paramref name="cvs"/>[0..8)
    /// using wide parent compressions, at NEON's 4-lane width. Mirrors
    /// <see cref="ReduceChunkCvsToSubtreeCvAvx2"/> (AVX2, 8-lane) one register width down.
    /// </summary>
    /// <remarks>
    /// The buffer must be at least 8 CVs (256 bytes) long regardless of
    /// <paramref name="chunkCount"/> — see <see cref="CompressParents4Neon"/>
    /// on surplus lanes.
    /// </remarks>
    private void ReduceChunkCvsToSubtreeCvNeon(uint* cvs, uint* key, int chunkCount, uint baseFlags)
    {
        // Full-width levels: every 4-parent group is fully populated.
        while (chunkCount >= 8)
        {
            int parents = chunkCount >> 1;
            for (int g = 0; g < parents; g += ChunksPerNeonBatch)
            {
                CompressParents4Neon(cvs + g * 16, key, cvs + g * 8, baseFlags);
            }

            chunkCount = parents;
        }

        CompressParents4Neon(cvs, key, cvs, baseFlags);   // 4 -> 2 (upper 2 lanes ignored)
        ComputeParentCv(cvs, key, cvs);                    // 2 -> 1
    }

    // Mirrors Blake3State.Compress(uint*, uint*) exactly (same message schedule,
    // same G-function groupings), with every uint word replaced by a
    // Vector128<uint> holding that word's value for 4 independent chunks.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CompressVector128(
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
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m0, m1);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m2, m3);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m4, m5);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m6, m7);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m8, m9);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m10, m11);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m12, m13);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m14, m15);

        // Round 2
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m2, m6);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m3, m10);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m7, m0);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m4, m13);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m1, m11);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m12, m5);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m9, m14);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m15, m8);

        // Round 3
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m3, m4);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m10, m12);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m13, m2);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m7, m14);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m6, m5);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m9, m0);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m11, m15);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m8, m1);

        // Round 4
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m10, m7);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m12, m9);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m14, m3);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m13, m15);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m4, m0);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m11, m2);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m5, m8);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m1, m6);

        // Round 5
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m12, m13);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m9, m11);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m15, m10);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m14, m8);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m7, m2);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m5, m3);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m0, m1);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m6, m4);

        // Round 6
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m9, m14);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m11, m5);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m8, m12);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m15, m1);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m13, m3);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m0, m10);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m2, m6);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m4, m7);

        // Round 7
        GRoundNeon(ref v0, ref v4, ref v8, ref v12, m11, m15);
        GRoundNeon(ref v1, ref v5, ref v9, ref v13, m5, m0);
        GRoundNeon(ref v2, ref v6, ref v10, ref v14, m1, m9);
        GRoundNeon(ref v3, ref v7, ref v11, ref v15, m8, m6);
        GRoundNeon(ref v0, ref v5, ref v10, ref v15, m14, m10);
        GRoundNeon(ref v1, ref v6, ref v11, ref v12, m2, m12);
        GRoundNeon(ref v2, ref v7, ref v8, ref v13, m3, m4);
        GRoundNeon(ref v3, ref v4, ref v9, ref v14, m7, m13);
    }

    /// <summary>
    /// In-place 4×4 transpose of 32-bit words: on input <c>vecs[j]</c> holds
    /// 4 consecutive words of chunk <c>j</c>; on output <c>vecs[w]</c> holds
    /// word <c>w</c> of all 4 chunks (lane <c>j</c> = chunk <c>j</c>).
    /// </summary>
     [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose4x4Neon(ref Vector128<uint> v0, ref Vector128<uint> v1, ref Vector128<uint> v2, ref Vector128<uint> v3)
    {
        // Interleave 32-bit words of row pairs.
        var ab01 = AdvSimd.Arm64.ZipLow(v0, v1);    // a0,b0,a1,b1
        var ab23 = AdvSimd.Arm64.ZipHigh(v0, v1);   // a2,b2,a3,b3
        var cd01 = AdvSimd.Arm64.ZipLow(v2, v3);    // c0,d0,c1,d1
        var cd23 = AdvSimd.Arm64.ZipHigh(v2, v3);   // c2,d2,c3,d3

        // Interleave 64-bit halves to complete the transpose.
        v0 = AdvSimd.Arm64.ZipLow(ab01.AsUInt64(), cd01.AsUInt64()).AsUInt32();    // a0,b0,c0,d0
        v1 = AdvSimd.Arm64.ZipHigh(ab01.AsUInt64(), cd01.AsUInt64()).AsUInt32();   // a1,b1,c1,d1
        v2 = AdvSimd.Arm64.ZipLow(ab23.AsUInt64(), cd23.AsUInt64()).AsUInt32();    // a2,b2,c2,d2
        v3 = AdvSimd.Arm64.ZipHigh(ab23.AsUInt64(), cd23.AsUInt64()).AsUInt32();   // a3,b3,c3,d3
    }

    /// <summary>
    /// In-place 4×4 transpose of 32-bit words: on input <c>vecs[j]</c> holds
    /// 4 consecutive words of chunk <c>j</c>; on output <c>vecs[w]</c> holds
    /// word <c>w</c> of all 4 chunks (lane <c>j</c> = chunk <c>j</c>).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Transpose4x4Neon(Vector128<uint>* vecs)
    {
        var v0 = vecs[0];
        var v1 = vecs[1];
        var v2 = vecs[2];
        var v3 = vecs[3];

        // Interleave 32-bit words of row pairs.
        var ab01 = AdvSimd.Arm64.ZipLow(v0, v1);    // a0,b0,a1,b1
        var ab23 = AdvSimd.Arm64.ZipHigh(v0, v1);   // a2,b2,a3,b3
        var cd01 = AdvSimd.Arm64.ZipLow(v2, v3);    // c0,d0,c1,d1
        var cd23 = AdvSimd.Arm64.ZipHigh(v2, v3);   // c2,d2,c3,d3

        // Interleave 64-bit halves to complete the transpose.
        vecs[0] = AdvSimd.Arm64.ZipLow(ab01.AsUInt64(), cd01.AsUInt64()).AsUInt32();    // a0,b0,c0,d0
        vecs[1] = AdvSimd.Arm64.ZipHigh(ab01.AsUInt64(), cd01.AsUInt64()).AsUInt32();   // a1,b1,c1,d1
        vecs[2] = AdvSimd.Arm64.ZipLow(ab23.AsUInt64(), cd23.AsUInt64()).AsUInt32();    // a2,b2,c2,d2
        vecs[3] = AdvSimd.Arm64.ZipHigh(ab23.AsUInt64(), cd23.AsUInt64()).AsUInt32();   // a3,b3,c3,d3
    }
}

#endif
