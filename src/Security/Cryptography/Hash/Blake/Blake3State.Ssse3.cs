// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1857 // A constant is expected for the parameter — false positive due to .NET 8 runtime metadata bug.

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE3 SSSE3-accelerated compression.
/// </summary>
internal unsafe partial struct Blake3State
{
    // Expression-bodied rather than static readonly fields: an all-const vector
    // materialises from the constant pool, where a static field costs a class-init test
    // and an indirect load through the GC static base on every use.

    // Rotate right by 16 bits
    private static Vector128<byte> RotateMask16
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create((byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);
    }

    // Rotate right by 8 bits
    private static Vector128<byte> RotateMask8
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create((byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);
    }

    // Pre-computed IV low vector. 
    private static Vector128<uint> IVLow
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create(IV0, IV1, IV2, IV3);
    }

    // Pre-computed IV high vector.
    private static Vector128<uint> IVHigh
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create(IV4, IV5, IV6, IV7);
    }


    // Lane i carries counter baseCounter + i, split into low and high halves. The high half comes
    // from the low half's carry rather than a branch, so no lane count appears in the arithmetic.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void CounterVectors128(ulong baseCounter, out Vector128<uint> low, out Vector128<uint> high)
    {
#if NET10_0_OR_GREATER
        var lowBase = Vector128.Create((uint)baseCounter);
        low = lowBase + Vector128<uint>.Indices;
        high = Vector128.Create((uint)(baseCounter >> 32)) - Vector128.LessThan(low, lowBase);
#else
        low = Vector128.Create(
            (uint)(baseCounter + 0), (uint)(baseCounter + 1), (uint)(baseCounter + 2), (uint)(baseCounter + 3));
        high = Vector128.Create(
            (uint)((baseCounter + 0) >> 32), (uint)((baseCounter + 1) >> 32),
            (uint)((baseCounter + 2) >> 32), (uint)((baseCounter + 3) >> 32));
#endif
    }

    // Selects dwords 1 and 3 from the second operand, 0 and 2 from the first.
    private static Vector128<uint> BlendMask0101
    {
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        get => Vector128.Create(0u, uint.MaxValue, 0u, uint.MaxValue);
    }

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
    internal const int Ssse3ChunksPerBatch = 4;

    /// <summary>
    /// Bytes consumed by one <see cref="Ssse3ChunksPerBatch"/>-wide batch.
    /// </summary>
    internal const int Ssse3BatchSizeBytes = Ssse3ChunksPerBatch * ChunkSizeBytes;

    /// <summary>
    /// Tree level of one aligned 4-chunk batch: a subtree of 2^level chunks, which is what
    /// <see cref="PushSubtreeCv"/> takes. Must stay log2(<see cref="Ssse3ChunksPerBatch"/>).
    /// </summary>
    internal const int Ssse3BatchLevel = 2;


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
            if (AdvSimd.Arm64.IsSupported && BitConverter.IsLittleEndian) support |= SimdSupport.Neon;
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
    /// Hashes a complete unkeyed message of at most one chunk straight into
    /// <paramref name="destination"/>, which must hold at least
    /// <see cref="DefaultHashSizeBytes"/> bytes.
    /// </summary>
    /// <remarks>
    /// Unkeyed-only counterpart of <see cref="HashChunkRoot32"/>: IV chaining value, zero
    /// counter and literal flags, so rows 0-2 come from the constant pool rather than the
    /// state; CV stays in registers across the chunk; the padded last block is assembled in
    /// registers (<c>BinaryLoad.LoadPaddedTailBlock128x4</c>) because on a path this short the
    /// per-call cost is the whole cost. Touches no instance state.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void HashRootIv32Ssse3(byte* src, int length, byte* destination)
    {
        if (length <= BlockSizeBytes)
        {
            CompressRootIvSingleBlock(src, length, destination);
        }
        else
        {
            HashChunkRootIv32Ssse3(src, length, destination);
        }
    }

    /// <summary>
    /// The 0..64-byte case: one compression, every input to it except the message and the
    /// block length a compile-time constant.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressRootIvSingleBlock(byte* src, int length, byte* destination)
    {
        var row0 = IVLow;
        var row1 = IVHigh;
        var row2 = IVLow;
        var row3 = Vector128.Create(0u, 0u, (uint)length, FlagChunkStart | FlagChunkEnd | FlagRoot);

        BinaryLoad.LoadPaddedTailBlock128x4(src, length, 0, out var m0, out var m1, out var m2, out var m3);

        GRounds128(m0, m1, m2, m3, ref row0, ref row1, ref row2, ref row3);

        StoreRootFold(destination, row0, row1, row2, row3);
    }

    /// <summary>
    /// The 129..1024-byte case: the chunk's whole block loop fused, with the chaining
    /// value living in two registers from the IV to the root fold.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void HashChunkRootIv32Ssse3(byte* src, int length, byte* destination)
    {
        Vector128<uint> cv0 = IVLow;
        Vector128<uint> cv1 = IVHigh;
        Vector128<uint> row2;
        Vector128<uint> row3;

        int pos = 0;
        uint startFlag = FlagChunkStart;

        // Strictly greater: the last block is handled after the loop, so an exact multiple
        // of 64 ends on a full block and needs no padding.
        Vector128<uint> m0, m1, m2, m3;
        while (length - pos > BlockSizeBytes)
        {
            row2 = IVLow;
            row3 = Vector128.Create(0u, 0u, (uint)BlockSizeBytes, startFlag);

            uint* b = (uint*)(src + pos);
            m0 = Sse2.LoadVector128(b);
            m1 = Sse2.LoadVector128(b + 4);
            m2 = Sse2.LoadVector128(b + 8);
            m3 = Sse2.LoadVector128(b + 12);

            GRounds128(m0, m1, m2, m3, ref cv0, ref cv1, ref row2, ref row3);

            cv0 = Sse2.Xor(cv0, row2);
            cv1 = Sse2.Xor(cv1, row3);

            pos += BlockSizeBytes;

            // Doubles as the "is first block" carrier for the tail's flags.
            startFlag = 0;
        }

        int lastLen = length - pos;
        byte* last = src + pos;

        if (lastLen == BlockSizeBytes)
        {
            uint* b = (uint*)last;
            m0 = Sse2.LoadVector128(b);
            m1 = Sse2.LoadVector128(b + 4);
            m2 = Sse2.LoadVector128(b + 8);
            m3 = Sse2.LoadVector128(b + 12);
        }
        else
        {
            BinaryLoad.LoadPaddedTailBlock128x4(src, length, pos, out m0, out m1, out m2, out m3);
        }

        row2 = IVLow;
        row3 = Vector128.Create(0u, 0u, (uint)lastLen, startFlag | FlagChunkEnd | FlagRoot);
        GRounds128(m0, m1, m2, m3, ref cv0, ref cv1, ref row2, ref row3);

        StoreRootFold(destination, cv0, cv1, row2, row3);
    }

    /// <summary>
    /// Stores the root fold <c>v[i] ^ v[i+8]</c> — the whole 32-byte digest, so the output
    /// block's high half is never computed.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void StoreRootFold(
        byte* destination,
        Vector128<uint> row0,
        Vector128<uint> row1,
        Vector128<uint> row2,
        Vector128<uint> row3)
    {
        Sse2.Store((uint*)destination, Sse2.Xor(row0, row2));
        Sse2.Store((uint*)(destination + 16), Sse2.Xor(row1, row3));
    }

    /// <summary>
    /// Compresses <paramref name="chunkCount"/> (2..4) independent, full (1024-byte) chunks
    /// with a 4-lane kernel. Lane <c>j</c> reads chunk <c>j</c> mod
    /// <paramref name="chunkCount"/>, so nothing outside the input is touched; surplus
    /// lanes' outputs are wrong and must be ignored.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunksPartial4Ssse3(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Debug.Assert(chunkCount >= 2 && chunkCount <= 4);
        CounterVectors128(baseCounter, out var counterLow, out var counterHigh);
        var blockLenVec = Vector128.Create((uint)BlockSizeBytes);

        // v0..v7 *are* the running chaining value — see CompressChunks8Avx2 for
        // why the separate cv bank is pure shuttling. It matters most here: with
        // only 16 XMM registers the bank was spilled and reloaded every block.
        var v0 = Vector128.Create(key[0]);
        var v1 = Vector128.Create(key[1]);
        var v2 = Vector128.Create(key[2]);
        var v3 = Vector128.Create(key[3]);
        var v4 = Vector128.Create(key[4]);
        var v5 = Vector128.Create(key[5]);
        var v6 = Vector128.Create(key[6]);
        var v7 = Vector128.Create(key[7]);

        uint flags = baseFlags | FlagChunkStart;
        var m = stackalloc Vector128<uint>[BlockSizeWords];
        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            {
                byte* blockBase = source + blockIdx * BlockSizeBytes;
                for (int j = 0; j < chunkCount; j++)
                {
                    m[j] = Sse2.LoadVector128((uint*)(blockBase));
                    m[j + 4] = Sse2.LoadVector128((uint*)(blockBase + 16));
                    m[j + 8] = Sse2.LoadVector128((uint*)(blockBase + 32));
                    m[j + 12] = Sse2.LoadVector128((uint*)(blockBase + 48));
                    blockBase += ChunkSizeBytes;
                }
            }

            Transpose4x4(m);
            Transpose4x4(m + 4);
            Transpose4x4(m + 8);
            Transpose4x4(m + 12);

            var v8 = Vector128.Create(IV0); var v9 = Vector128.Create(IV1);
            var v10 = Vector128.Create(IV2); var v11 = Vector128.Create(IV3);
            var v12 = counterLow;
            var v13 = counterHigh;
            var v14 = blockLenVec;
            var v15 = Vector128.Create(flags);

            flags = blockIdx == BlocksPerChunk - 2 ? baseFlags | FlagChunkEnd : baseFlags;

            CompressVector128ChunkParallel(
                ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
                ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
                m);

            v0 = Sse2.Xor(v0, v8); v1 = Sse2.Xor(v1, v9);
            v2 = Sse2.Xor(v2, v10); v3 = Sse2.Xor(v3, v11);
            v4 = Sse2.Xor(v4, v12); v5 = Sse2.Xor(v5, v13);
            v6 = Sse2.Xor(v6, v14); v7 = Sse2.Xor(v7, v15);
        }

        // Transpose is its own inverse for a square arrangement, so the same function
        // restores chunk-major order here, in two 4-word halves.
        Transpose4x4(ref v0, ref v1, ref v2, ref v3);
        Transpose4x4(ref v4, ref v5, ref v6, ref v7);

        // minimum 2
        Sse2.Store(outCvs, v0);
        Sse2.Store(outCvs + 4, v4);

        Sse2.Store(outCvs + KeySizeWords, v1);
        Sse2.Store(outCvs + KeySizeWords + 4, v5);

        if (chunkCount > 2)
        {
            Sse2.Store(outCvs + 2 * KeySizeWords, v2);
            Sse2.Store(outCvs + 2 * KeySizeWords + 4, v6);

            if (chunkCount > 3)
            {
                Sse2.Store(outCvs + 3 * KeySizeWords, v3);
                Sse2.Store(outCvs + 3 * KeySizeWords + 4, v7);
            }
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
        byte* blockDest = dst;
        for (int i = 0; i < blocks; i++)
        {
            var row0 = cvLow;
            var row1 = cvHigh;
            var row2 = IVLow;
            var row3 = Vector128.Create((uint)startCounter, (uint)(startCounter >> 32), blockLen, flags);
            startCounter++;

            GRounds128(m, ref row0, ref row1, ref row2, ref row3);

            Sse2.Store(blockDest, Sse2.Xor(row0, row2).AsByte());
            Sse2.Store(blockDest + 16, Sse2.Xor(row1, row3).AsByte());
            Sse2.Store(blockDest + 32, Sse2.Xor(row2, cvLow).AsByte());
            Sse2.Store(blockDest + 48, Sse2.Xor(row3, cvHigh).AsByte());
            blockDest += BlockSizeBytes;
        }
    }

    // Extracts 4 message words from up to 4 source vectors in a single
    // shuffle_ps/shuffle_ps/blend sequence, avoiding scalar loads and
    // GPR-to-XMM inserts.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> Gather128(
        Vector128<uint> leftA, Vector128<uint> leftB, byte leftControl,
        Vector128<uint> rightA, Vector128<uint> rightB, byte rightControl)
    {
        var left = Sse.Shuffle(leftA.AsSingle(), leftB.AsSingle(), leftControl).AsUInt32();
        var right = Sse.Shuffle(rightA.AsSingle(), rightB.AsSingle(), rightControl).AsUInt32();

        // Latency-bound on the G-function's serial chain rather than shuffle-port
        // throughput, so the choice of blend instruction makes no measurable difference.
        if (Sse41.IsSupported)
        {
            // 0xCC selects words 2,3,6,7 (uint lanes 1 and 3) from the second
            // operand, matching BlendMask0101's lane selection in one PBLENDW.
            return Sse41.Blend(left.AsInt16(), right.AsInt16(), 0xCC).AsUInt32();
        }
        return Sse2.Or(Sse2.And(right, BlendMask0101), Sse2.AndNot(BlendMask0101, left));
    }

    // The four gathers below replace the general Gather128 in the round schedule. Each names
    // one of the four message vectors the permutation produces and picks the cheapest sequence
    // for that vector's own lane pattern, rather than paying the general shuffle/shuffle/blend
    // form four times. Lane comments read as indices into the four inputs.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> GatherColX128(Vector128<uint> colX, Vector128<uint> colY)
    {
        // colX1 colY1 colY3 colX2
        var lo = Sse2.UnpackLow(colX, colY);
        var hi = Sse2.UnpackHigh(colY, colX);
        return Sse.Shuffle(lo.AsSingle(), hi.AsSingle(), 0x6E).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> GatherColY128(Vector128<uint> colX, Vector128<uint> diagX, Vector128<uint> diagY)
    {
        // colX3 diagX1 colX0 diagY2
        var lo = Sse.Shuffle(colX.AsSingle(), diagX.AsSingle(), 0x13).AsUInt32();
        var hi = Sse.Shuffle(colX.AsSingle(), diagY.AsSingle(), 0x20).AsUInt32();
        return Sse.Shuffle(lo.AsSingle(), hi.AsSingle(), 0x88).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> GatherDiagX128(Vector128<uint> colY, Vector128<uint> diagX, Vector128<uint> diagY)
    {
        // colY0 diagX2 diagY0 diagY3 - the upper half is single sourced, so one merge is enough.
        var lo = Sse.Shuffle(colY.AsSingle(), diagX.AsSingle(), 0x20).AsUInt32();
        return Sse.Shuffle(lo.AsSingle(), diagY.AsSingle(), 0xC8).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> GatherDiagY128(Vector128<uint> colY, Vector128<uint> diagX, Vector128<uint> diagY)
    {
        // diagY1 colY2 diagX3 diagX0 - the upper half is single sourced, so one merge is enough.
        var lo = Sse.Shuffle(diagY.AsSingle(), colY.AsSingle(), 0x21).AsUInt32();
        return Sse.Shuffle(lo.AsSingle(), diagX.AsSingle(), 0x38).AsUInt32();
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
        GRounds128(
            Sse2.LoadVector128(m),
            Sse2.LoadVector128(m + 4),
            Sse2.LoadVector128(m + 8),
            Sse2.LoadVector128(m + 12),
            ref row0, ref row1, ref row2, ref row3);
    }

    /// <summary>
    /// The round schedule itself, taking the message block as four vectors already in
    /// registers rather than a pointer to load it from.
    /// </summary>
    /// <remarks>
    /// Split out of the pointer overload for the root kernels below: they assemble a
    /// zero-padded final block in registers (see <c>BinaryLoad.LoadPaddedTailBlock128x4</c>)
    /// instead of staging it through a <c>stackalloc</c>, so there is no memory for a
    /// pointer to point at.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRounds128(
        Vector128<uint> q0,
        Vector128<uint> q1,
        Vector128<uint> q2,
        Vector128<uint> q3,
        ref Vector128<uint> row0,
        ref Vector128<uint> row1,
        ref Vector128<uint> row2,
        ref Vector128<uint> row3)
    {
        Vector128<uint> colX, colY, diagX, diagY;

        // Round 1: 0,2,4,6 | 1,3,5,7 (columns), 8,10,12,14 | 9,11,13,15 (diagonals).
        colX = Sse.Shuffle(q0.AsSingle(), q1.AsSingle(), 0x88).AsUInt32();   // 0,2,4,6
        colY = Sse.Shuffle(q0.AsSingle(), q1.AsSingle(), 0xDD).AsUInt32();   // 1,3,5,7
        diagX = Sse.Shuffle(q2.AsSingle(), q3.AsSingle(), 0x88).AsUInt32();  // 8,10,12,14
        diagY = Sse.Shuffle(q2.AsSingle(), q3.AsSingle(), 0xDD).AsUInt32();  // 9,11,13,15

        GRound128(ref row0, ref row1, ref row2, ref row3, colX, colY);
        DiagPermute128(ref row0, ref row2, ref row3);
        GRound128(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
        DiagPermute128(ref row2, ref row0, ref row3);

        // Rounds 2-7 apply the same fixed permutation to the previous round's own output
        // vectors, so they are textually identical. Kept as a twin loop to save register moves.
        for (int i = 1; i < 7; i += 2)
        {
            // round 2 + i
            q0 = GatherColX128(colX, colY);
            GRoundX128(ref row0, ref row1, ref row2, ref row3, q0);
            q1 = GatherColY128(colX, diagX, diagY);
            GRoundY128(ref row0, ref row1, ref row2, ref row3, q1);
            DiagPermute128(ref row0, ref row2, ref row3);

            q2 = GatherDiagX128(colY, diagX, diagY);
            GRoundX128(ref row0, ref row1, ref row2, ref row3, q2);
            q3 = GatherDiagY128(colY, diagX, diagY);
            GRoundY128(ref row0, ref row1, ref row2, ref row3, q3);
            DiagPermute128(ref row2, ref row0, ref row3);

            // round 3 + i
            colX = GatherColX128(q0, q1);
            GRoundX128(ref row0, ref row1, ref row2, ref row3, colX);
            colY = GatherColY128(q0, q2, q3);
            GRoundY128(ref row0, ref row1, ref row2, ref row3, colY);
            DiagPermute128(ref row0, ref row2, ref row3);

            diagX = GatherDiagX128(q1, q2, q3);
            GRoundX128(ref row0, ref row1, ref row2, ref row3, diagX);
            diagY = GatherDiagY128(q1, q2, q3);
            GRoundY128(ref row0, ref row1, ref row2, ref row3, diagY);
            DiagPermute128(ref row2, ref row0, ref row3);
        }
    }

    /// <summary>
    /// Rotates three of the four state rows into, or back out of, diagonal alignment.
    /// </summary>
    /// <remarks>
    /// Only the rows' relative offsets matter, so which row is left untouched is free. row1 is
    /// chosen: it is written last in a half-round and read first by the next, so a shuffle on it
    /// would sit on the dependency chain with no slack to hide in. Arguments are passed in
    /// rotation order, which differs between the two directions.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermute128(ref Vector128<uint> by3, ref Vector128<uint> by1, ref Vector128<uint> by2)
    {
        by3 = Sse2.Shuffle(by3, 0b10_01_00_11); // 3,0,1,2
        by1 = Sse2.Shuffle(by1, 0b00_11_10_01); // 1,2,3,0
        by2 = Sse2.Shuffle(by2, 0b01_00_11_10); // 2,3,0,1
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundX128(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x)
    {
        // a = a + b + x
        a = Sse2.Add(Sse2.Add(a, x), b);
        // d = ror(d ^ a, 16)
        d = RotateRight16(Sse2.Xor(d, a));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        b = RotateRight12(Sse2.Xor(b, c));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundY128(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> y)
    {
        // a = a + b + y
        a = Sse2.Add(Sse2.Add(a, y), b);
        // d = ror(d ^ a, 8)
        d = RotateRight8(Sse2.Xor(d, a));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        b = RotateRight7(Sse2.Xor(b, c));
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
        a = Sse2.Add(Sse2.Add(a, x), b);
        // d = ror(d ^ a, 16)
        d = RotateRight16(Sse2.Xor(d, a));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        b = RotateRight12(Sse2.Xor(b, c));
        // a = a + b + y
        a = Sse2.Add(Sse2.Add(a, y), b);
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
    /// One state word per lane across four independent parent compressions; parents always
    /// carry counter 0 and a full block length, so only the flags word varies. Fewer than
    /// four live parents is allowed, but <paramref name="childCvs"/> must still be readable
    /// for all eight CVs.
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
        var m = stackalloc Vector128<uint>[BlockSizeWords];
        for (int j = 0; j < Ssse3ChunksPerBatch; j++)
        {
            m[j] = Sse2.LoadVector128(childCvs + j * ParentStrideWords);
            m[j + 4] = Sse2.LoadVector128(childCvs + j * ParentStrideWords + 4);
            m[j + 8] = Sse2.LoadVector128(childCvs + j * ParentStrideWords + 8);
            m[j + 12] = Sse2.LoadVector128(childCvs + j * ParentStrideWords + 12);
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
    /// Runs every complete 64-chunk subtree group the remaining input allows, using this
    /// tier's 4-wide chunk kernel and 4-lane parent reduction, and returns the advanced
    /// offset. See <see cref="CompressSubtreeGroupsAvx2"/> for why this is specialised per
    /// tier and why the loop tests length alone.
    /// </summary>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the first group starts.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer, at least 64 CVs (512 words) long.</param>
    /// <returns><paramref name="offset"/> advanced past every group compressed.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CompressSubtreeGroupsSsse3(Blake3State* core, byte* srcPtr, int offset, int length, uint* batchCvs)
    {
        do
        {
            for (int b = 0; b < ChunksPerSubtreeGroup / Ssse3ChunksPerBatch; b++)
            {
                CompressChunksPartial4Ssse3(
                    srcPtr + offset,
                    Ssse3ChunksPerBatch,
                    core->_keyWords,
                    batchCvs + b * Ssse3ChunksPerBatch * KeySizeWords,
                    _chunkCounter + (ulong)(b * Ssse3ChunksPerBatch),
                    _baseFlags);
                offset += Ssse3BatchSizeBytes;
            }

            ReduceChunkCvsToSubtreeCvSsse3(core, batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
            PushSubtreeCv(core, batchCvs, SubtreeGroupLevel);
            _chunkCounter += ChunksPerSubtreeGroup;
        }
        while (length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes);

        return offset;
    }

    /// <summary>
    /// Compresses the exactly-3-chunk tail this tier can still batch, and commits its CVs.
    /// </summary>
    /// <remarks>
    /// The count is passed as a literal, not computed: a constant width folds the kernel's
    /// lane-offset table and per-lane store guards, which a runtime count cannot.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the tail starts.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer for the kernel's output CVs.</param>
    /// <returns>The number of bytes consumed (three chunks).</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int CommitPartialBatch3Ssse3(Blake3State* core, byte* srcPtr, int offset, int length, uint* batchCvs)
    {
        const int FullChunks = 3;
        Debug.Assert((length - offset) / ChunkSizeBytes == FullChunks, "exactly three chunks remain here");
        bool drainsRemainingInput = offset + (FullChunks * ChunkSizeBytes) == length;

        CompressChunksPartial4Ssse3(
            srcPtr + offset, FullChunks, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);

        CommitBatchChunks(core, batchCvs, 0, drainsRemainingInput ? FullChunks - 1 : FullChunks, drainsRemainingInput);
        return FullChunks * ChunkSizeBytes;
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

    /// <param name="core">Pointer to the instance; only the final 2 → 1 merge needs it.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ReduceChunkCvsToSubtreeCvSsse3(Blake3State* core, uint* cvs, uint* key, int chunkCount, uint baseFlags)
    {
        // Full-width levels: every 4-parent group is fully populated.
        while (chunkCount >= 8)
        {
            int parents = chunkCount >> 1;
            for (int g = 0; g < parents; g += Ssse3ChunksPerBatch)
            {
                CompressParents4Ssse3(cvs + g * ParentStrideWords, key, cvs + g * KeySizeWords, baseFlags);
            }

            chunkCount = parents;
        }

        CompressParents4Ssse3(cvs, key, cvs, baseFlags);   // 4 -> 2 (upper 2 lanes ignored)
        core->ComputeParentCv(cvs, key, cvs);              // 2 -> 1
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
        // Round 1
        GRound128(ref v0, ref v4, ref v8, ref v12, m[0], m[1]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[2], m[3]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[4], m[5]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[6], m[7]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[8], m[9]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[10], m[11]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[12], m[13]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[14], m[15]);

        // Round 2
        GRound128(ref v0, ref v4, ref v8, ref v12, m[2], m[6]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[3], m[10]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[7], m[0]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[4], m[13]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[1], m[11]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[12], m[5]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[9], m[14]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[15], m[8]);

        // Round 3
        GRound128(ref v0, ref v4, ref v8, ref v12, m[3], m[4]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[10], m[12]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[13], m[2]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[7], m[14]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[6], m[5]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[9], m[0]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[11], m[15]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[8], m[1]);

        // Round 4
        GRound128(ref v0, ref v4, ref v8, ref v12, m[10], m[7]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[12], m[9]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[14], m[3]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[13], m[15]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[4], m[0]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[11], m[2]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[5], m[8]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[1], m[6]);

        // Round 5
        GRound128(ref v0, ref v4, ref v8, ref v12, m[12], m[13]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[9], m[11]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[15], m[10]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[14], m[8]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[7], m[2]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[5], m[3]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[0], m[1]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[6], m[4]);

        // Round 6
        GRound128(ref v0, ref v4, ref v8, ref v12, m[9], m[14]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[11], m[5]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[8], m[12]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[15], m[1]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[13], m[3]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[0], m[10]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[2], m[6]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[4], m[7]);

        // Round 7
        GRound128(ref v0, ref v4, ref v8, ref v12, m[11], m[15]);
        GRound128(ref v1, ref v5, ref v9, ref v13, m[5], m[0]);
        GRound128(ref v2, ref v6, ref v10, ref v14, m[1], m[9]);
        GRound128(ref v3, ref v7, ref v11, ref v15, m[8], m[6]);
        GRound128(ref v0, ref v5, ref v10, ref v15, m[14], m[10]);
        GRound128(ref v1, ref v6, ref v11, ref v12, m[2], m[12]);
        GRound128(ref v2, ref v7, ref v8, ref v13, m[3], m[4]);
        GRound128(ref v3, ref v4, ref v9, ref v14, m[7], m[13]);
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
