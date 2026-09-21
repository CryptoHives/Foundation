// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1857 // A constant is expected for the parameter — false positive due to .NET 8 runtime metadata bug.

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE3 AVX2 two-chunk compression: one chunk per 128-bit half of a
/// <see cref="Vector256{UInt32}"/>.
/// </summary>
/// <remarks>
/// <para>
/// This is the row-oriented SSSE3 kernel (<see cref="CompressBlocksSsse3"/>) widened to
/// 256 bits, not a third chunk-parallel tier. Each register still holds four state words
/// of one compression in each half — chunk A in the low lane, chunk B in the high lane —
/// so two chunks cost one chunk's instruction count and there is no transpose at all.
/// Every shuffle the Samuel Neves schedule uses (<c>vshufps</c>, <c>vpshufd</c>,
/// <c>vpblendw</c>) is lane-local on AVX2, so widening is a one-for-one substitution.
/// </para>
/// <para>
/// A transposed kernel is the wrong shape below five chunks: it spends a full vector's
/// worth of rounds plus a transpose whatever the count, so three chunks cost what seven do.
/// Two chunks run one chain here and three or four run two chains side by side.
/// </para>
/// </remarks>
internal unsafe partial struct Blake3State
{
    /// <summary>
    /// Number of chunks the AVX2 pair kernel compresses together.
    /// </summary>
    internal const int Avx2PairChunksPerBatch = 2;

    /// <summary>
    /// Bytes consumed by one <see cref="Avx2PairChunksPerBatch"/>-wide batch.
    /// </summary>
    internal const int Avx2PairBatchSizeBytes = Avx2PairChunksPerBatch * ChunkSizeBytes;

    /// <summary>
    /// Chunks the two-chain kernel below compresses: two pair chains side by side.
    /// </summary>
    internal const int Avx2PairX2ChunksPerBatch = 2 * Avx2PairChunksPerBatch;

    /// <summary>
    /// Compresses exactly two independent, full (1024-byte) chunks, writing their two
    /// chaining values to <paramref name="outCvs"/> (16 words, chunk-major).
    /// </summary>
    /// <param name="source">The two chunks, contiguous: chunk A at offset 0, chunk B at 1024.</param>
    /// <param name="chunkCount">Always 2; present so this matches the tier-kernel function-pointer
    /// signature the per-tier <c>CommitPartialBatch*</c> helpers and each tier's <c>CompressSubtreeGroups*</c> dispatch through.</param>
    /// <param name="key">The 8-word key/IV words for this hash.</param>
    /// <param name="outCvs">Receives two 8-word CVs, chunk-major.</param>
    /// <param name="baseCounter">Chunk counter of chunk A; chunk B is <paramref name="baseCounter"/> + 1.</param>
    /// <param name="baseFlags">Mode flags; the per-block chunk-start/chunk-end flags are added here.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunks2Avx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Debug.Assert(chunkCount == Avx2PairChunksPerBatch, "the pair kernel compresses exactly two chunks");

        // Both chunks start from the same key, so one 128-bit load broadcast to both
        // halves seeds rows 0 and 1.
        var keyLow = Sse2.LoadVector128(key);
        var keyHigh = Sse2.LoadVector128(key + 4);
        var row0 = Vector256.Create(keyLow, keyLow);
        var row1 = Vector256.Create(keyHigh, keyHigh);

        var row2Seed = Vector256.Create(IVLow, IVLow);

        // counter and block length are fixed for the whole chunk and differ only between
        // the two halves; flags take one of three values across the 16 blocks. Build all
        // three row3 seeds once rather than reassembling the vector per block.
        ulong counterB = baseCounter + 1;
        var row3Start = Row3Pair(baseCounter, counterB, baseFlags | FlagChunkStart);
        var row3Mid = Row3Pair(baseCounter, counterB, baseFlags);
        var row3End = Row3Pair(baseCounter, counterB, baseFlags | FlagChunkEnd);

        byte* blockA = source;
        byte* blockB = source + ChunkSizeBytes;

        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            var row2 = row2Seed;
            var row3 = blockIdx == 0 ? row3Start : (blockIdx == BlocksPerChunk - 1 ? row3End : row3Mid);

            GRounds256Pair(blockA, blockB, ref row0, ref row1, ref row2, ref row3);

            row0 = Avx2.Xor(row0, row2);
            row1 = Avx2.Xor(row1, row3);

            blockA += BlockSizeBytes;
            blockB += BlockSizeBytes;
        }

        // Low half is chunk A's CV, high half is chunk B's — a plain extract each,
        // no transpose.
        Sse2.Store(outCvs, row0.GetLower());
        Sse2.Store(outCvs + 4, row1.GetLower());
        Sse2.Store(outCvs + 8, row0.GetUpper());
        Sse2.Store(outCvs + 12, row1.GetUpper());
    }

    /// <summary>
    /// Compresses three or four independent, full chunks as two pair chains driven side by
    /// side, writing their CVs contiguously to <paramref name="outCvs"/>.
    /// </summary>
    /// <remarks>
    /// One pair chain is latency bound, so a second independent chain fills the gaps the
    /// first leaves. The two together need about twice the live registers of one, which fits
    /// only in the 32-register file, so the caller must have checked <c>Avx512F.VL</c>.
    /// With three chunks the second chain loads chunk 2 into both halves; the duplicate CV
    /// is not stored.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunks4Avx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Debug.Assert(chunkCount is 3 or 4, "the two-chain pair kernel compresses three or four chunks");

        var keyLow = Sse2.LoadVector128(key);
        var keyHigh = Sse2.LoadVector128(key + 4);
        var rowA0 = Vector256.Create(keyLow, keyLow);
        var rowA1 = Vector256.Create(keyHigh, keyHigh);
        var rowB0 = rowA0;
        var rowB1 = rowA1;

        var row2Seed = Vector256.Create(IVLow, IVLow);

        ulong counterA1 = baseCounter + 1;
        ulong counterB0 = baseCounter + 2;
        ulong counterB1 = chunkCount == Avx2PairX2ChunksPerBatch ? baseCounter + 3 : counterB0;

        byte* blockA0 = source;
        byte* blockA1 = source + ChunkSizeBytes;
        byte* blockB0 = source + (2 * ChunkSizeBytes);

        // Three chunks needs no separate shape: a zero stride puts chunk 2 in both of chain
        // B's halves, and the duplicate result is dropped by the store below.
        byte* blockB1 = blockB0 + (chunkCount == Avx2PairX2ChunksPerBatch ? ChunkSizeBytes : 0);

        uint flags = baseFlags | FlagChunkStart;
        for (int blockIdx = 0; blockIdx < BlocksPerChunk; blockIdx++)
        {
            var rowA2 = row2Seed;
            var rowB2 = row2Seed;
            var rowA3 = Row3Pair(baseCounter, counterA1, flags);
            var rowB3 = Row3Pair(counterB0, counterB1, flags);

            GRounds256PairX2(
                blockA0, blockA1, ref rowA0, ref rowA1, ref rowA2, ref rowA3,
                blockB0, blockB1, ref rowB0, ref rowB1, ref rowB2, ref rowB3);

            rowA0 = Avx2.Xor(rowA0, rowA2);
            rowA1 = Avx2.Xor(rowA1, rowA3);
            rowB0 = Avx2.Xor(rowB0, rowB2);
            rowB1 = Avx2.Xor(rowB1, rowB3);

            blockA0 += BlockSizeBytes;
            blockA1 += BlockSizeBytes;
            blockB0 += BlockSizeBytes;
            blockB1 += BlockSizeBytes;
            flags = blockIdx >= BlocksPerChunk - 2 ? baseFlags | FlagChunkEnd : baseFlags;
        }

        Sse2.Store(outCvs, rowA0.GetLower());
        Sse2.Store(outCvs + 4, rowA1.GetLower());
        Sse2.Store(outCvs + 8, rowA0.GetUpper());
        Sse2.Store(outCvs + 12, rowA1.GetUpper());
        Sse2.Store(outCvs + 16, rowB0.GetLower());
        Sse2.Store(outCvs + 20, rowB1.GetLower());

        if (chunkCount == Avx2PairX2ChunksPerBatch)
        {
            Sse2.Store(outCvs + 24, rowB0.GetUpper());
            Sse2.Store(outCvs + 28, rowB1.GetUpper());
        }
    }

    /// <summary>
    /// <see cref="GRounds256Pair"/> for two chains at once. The bodies alternate rather than
    /// running one after the other: each chain's G-round is a serial dependency chain, so
    /// alternating gives the other something to issue while it waits.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRounds256PairX2(
        byte* blockA0, byte* blockA1,
        ref Vector256<uint> a0, ref Vector256<uint> a1, ref Vector256<uint> a2, ref Vector256<uint> a3,
        byte* blockB0, byte* blockB1,
        ref Vector256<uint> b0, ref Vector256<uint> b1, ref Vector256<uint> b2, ref Vector256<uint> b3)
    {
        var qA0 = LoadPair(blockA0, blockA1, 0);
        var qB0 = LoadPair(blockB0, blockB1, 0);
        var qA1 = LoadPair(blockA0, blockA1, 16);
        var qB1 = LoadPair(blockB0, blockB1, 16);
        var qA2 = LoadPair(blockA0, blockA1, 32);
        var qB2 = LoadPair(blockB0, blockB1, 32);
        var qA3 = LoadPair(blockA0, blockA1, 48);
        var qB3 = LoadPair(blockB0, blockB1, 48);

        var colXA = Avx.Shuffle(qA0.AsSingle(), qA1.AsSingle(), 0x88).AsUInt32();
        var colXB = Avx.Shuffle(qB0.AsSingle(), qB1.AsSingle(), 0x88).AsUInt32();
        var colYA = Avx.Shuffle(qA0.AsSingle(), qA1.AsSingle(), 0xDD).AsUInt32();
        var colYB = Avx.Shuffle(qB0.AsSingle(), qB1.AsSingle(), 0xDD).AsUInt32();
        var diagXA = Avx.Shuffle(qA2.AsSingle(), qA3.AsSingle(), 0x88).AsUInt32();
        var diagXB = Avx.Shuffle(qB2.AsSingle(), qB3.AsSingle(), 0x88).AsUInt32();
        var diagYA = Avx.Shuffle(qA2.AsSingle(), qA3.AsSingle(), 0xDD).AsUInt32();
        var diagYB = Avx.Shuffle(qB2.AsSingle(), qB3.AsSingle(), 0xDD).AsUInt32();

        GRound256Pair(ref a0, ref a1, ref a2, ref a3, colXA, colYA);
        GRound256Pair(ref b0, ref b1, ref b2, ref b3, colXB, colYB);
        DiagPermute256Pair(ref a0, ref a2, ref a3);
        DiagPermute256Pair(ref b0, ref b2, ref b3);
        GRound256Pair(ref a0, ref a1, ref a2, ref a3, diagXA, diagYA);
        GRound256Pair(ref b0, ref b1, ref b2, ref b3, diagXB, diagYB);
        DiagPermute256Pair(ref a2, ref a0, ref a3);
        DiagPermute256Pair(ref b2, ref b0, ref b3);

        for (int i = 1; i < 7; i++)
        {
            qA0 = colXA; qA1 = colYA; qA2 = diagXA; qA3 = diagYA;
            qB0 = colXB; qB1 = colYB; qB2 = diagXB; qB3 = diagYB;

            colXA = Gather256(qA0, qA1, 0x31, qA1, qA0, 0x84);
            colXB = Gather256(qB0, qB1, 0x31, qB1, qB0, 0x84);
            colYA = Gather256(qA0, qA0, 0x03, qA2, qA3, 0x84);
            colYB = Gather256(qB0, qB0, 0x03, qB2, qB3, 0x84);
            diagXA = Gather256(qA1, qA3, 0x00, qA2, qA3, 0xC8);
            diagXB = Gather256(qB1, qB3, 0x00, qB2, qB3, 0xC8);
            diagYA = Gather256(qA3, qA2, 0x31, qA1, qA2, 0x08);
            diagYB = Gather256(qB3, qB2, 0x31, qB1, qB2, 0x08);

            GRound256Pair(ref a0, ref a1, ref a2, ref a3, colXA, colYA);
            GRound256Pair(ref b0, ref b1, ref b2, ref b3, colXB, colYB);
            DiagPermute256Pair(ref a0, ref a2, ref a3);
            DiagPermute256Pair(ref b0, ref b2, ref b3);
            GRound256Pair(ref a0, ref a1, ref a2, ref a3, diagXA, diagYA);
            GRound256Pair(ref b0, ref b1, ref b2, ref b3, diagXB, diagYB);
            DiagPermute256Pair(ref a2, ref a0, ref a3);
            DiagPermute256Pair(ref b2, ref b0, ref b3);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> Row3Pair(ulong counterA, ulong counterB, uint flags) =>
        Vector256.Create(
            (uint)counterA, (uint)(counterA >> 32), BlockSizeBytes, flags,
            (uint)counterB, (uint)(counterB >> 32), BlockSizeBytes, flags);

    /// <summary>
    /// The seven-round Samuel Neves schedule over a pair of independent blocks, one per
    /// 128-bit half.
    /// Mirrors <see cref="GRounds128(uint*, ref Vector128{uint}, ref Vector128{uint}, ref Vector128{uint}, ref Vector128{uint})"/>
    /// exactly; only the register width and the message load differ.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRounds256Pair(
        byte* blockA,
        byte* blockB,
        ref Vector256<uint> row0,
        ref Vector256<uint> row1,
        ref Vector256<uint> row2,
        ref Vector256<uint> row3)
    {
        // Load each block's 16 message words as four quads, pairing A's quad with B's
        // in one register. x86 is always little-endian, so the cast is free.
        var q0 = LoadPair(blockA, blockB, 0);
        var q1 = LoadPair(blockA, blockB, 16);
        var q2 = LoadPair(blockA, blockB, 32);
        var q3 = LoadPair(blockA, blockB, 48);

        // Round 1: 0,2,4,6 | 1,3,5,7 (columns), 8,10,12,14 | 9,11,13,15 (diagonals).
        var colX = Avx.Shuffle(q0.AsSingle(), q1.AsSingle(), 0x88).AsUInt32();
        var colY = Avx.Shuffle(q0.AsSingle(), q1.AsSingle(), 0xDD).AsUInt32();
        var diagX = Avx.Shuffle(q2.AsSingle(), q3.AsSingle(), 0x88).AsUInt32();
        var diagY = Avx.Shuffle(q2.AsSingle(), q3.AsSingle(), 0xDD).AsUInt32();

        GRound256Pair(ref row0, ref row1, ref row2, ref row3, colX, colY);
        DiagPermute256Pair(ref row0, ref row2, ref row3);
        GRound256Pair(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
        DiagPermute256Pair(ref row2, ref row0, ref row3);

        // Rounds 2-7: BLAKE3's message schedule applies the same fixed permutation every
        // round to the previous round's own output vectors, so the six remaining rounds
        // are textually identical.
        for (int i = 1; i < 7; i++)
        {
            q0 = colX; q1 = colY; q2 = diagX; q3 = diagY;
            colX = Gather256(q0, q1, 0x31, q1, q0, 0x84);
            colY = Gather256(q0, q0, 0x03, q2, q3, 0x84);
            diagX = Gather256(q1, q3, 0x00, q2, q3, 0xC8);
            diagY = Gather256(q3, q2, 0x31, q1, q2, 0x08);
            GRound256Pair(ref row0, ref row1, ref row2, ref row3, colX, colY);
            DiagPermute256Pair(ref row0, ref row2, ref row3);
            GRound256Pair(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
            DiagPermute256Pair(ref row2, ref row0, ref row3);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> LoadPair(byte* blockA, byte* blockB, int offset) =>
        Vector256.Create(
            Sse2.LoadVector128((uint*)(blockA + offset)),
            Sse2.LoadVector128((uint*)(blockB + offset)));

    /// <summary>
    /// The 256-bit counterpart of <see cref="Gather128"/>: <c>vshufps</c> twice and one
    /// <c>vpblendw</c>, all lane-local, so each half gathers its own block's words.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> Gather256(
        Vector256<uint> leftA, Vector256<uint> leftB, byte leftControl,
        Vector256<uint> rightA, Vector256<uint> rightB, byte rightControl)
    {
        var left = Avx.Shuffle(leftA.AsSingle(), leftB.AsSingle(), leftControl).AsUInt32();
        var right = Avx.Shuffle(rightA.AsSingle(), rightB.AsSingle(), rightControl).AsUInt32();

        // 0xCC selects words 2,3,6,7 (uint lanes 1 and 3) of each 128-bit half from the
        // second operand — the same selection Gather128 makes, applied per half.
        return Avx2.Blend(left.AsInt16(), right.AsInt16(), 0xCC).AsUInt32();
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
    private static void DiagPermute256Pair(ref Vector256<uint> by3, ref Vector256<uint> by1, ref Vector256<uint> by2)
    {
        by3 = Avx2.Shuffle(by3, 0b10_01_00_11); // 3,0,1,2
        by1 = Avx2.Shuffle(by1, 0b00_11_10_01); // 1,2,3,0
        by2 = Avx2.Shuffle(by2, 0b01_00_11_10); // 2,3,0,1
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRound256Pair(
        ref Vector256<uint> a,
        ref Vector256<uint> b,
        ref Vector256<uint> c,
        ref Vector256<uint> d,
        Vector256<uint> x,
        Vector256<uint> y)
    {
        // a = a + b + x
        a = Avx2.Add(Avx2.Add(a, x), b);
        // d = ror(d ^ a, 16)
        d = RotateRight16(Avx2.Xor(d, a));
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 12)
        b = RotateRight12(Avx2.Xor(b, c));
        // a = a + b + y
        a = Avx2.Add(Avx2.Add(a, y), b);
        // d = ror(d ^ a, 8)
        d = RotateRight8(Avx2.Xor(d, a));
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 7)
        b = RotateRight7(Avx2.Xor(b, c));
    }
}

#endif
