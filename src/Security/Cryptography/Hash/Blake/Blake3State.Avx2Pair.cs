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
/// It exists because a *transposed* kernel is the wrong shape for exactly two chunks.
/// <see cref="CompressChunksPartial4Ssse3"/> spends four lanes' worth of rounds plus a
/// transpose to produce two useful CVs, which measured at no gain over compressing the
/// two chunks one after another (2 KB cost 1.47x what 1 KB did). Two chunks is a common
/// size — it is every 2-chunk message, and every 2-chunk tail left by the 4-, 8- and
/// 16-wide batch loops — so the range gets its own kernel rather than a wasteful lane
/// assignment. Three and four chunks stay on the 4-lane transposed kernel, where the
/// transpose does pay.
/// </para>
/// </remarks>
internal unsafe partial struct Blake3State
{
    /// <summary>
    /// Number of chunks the AVX2 pair kernel compresses together.
    /// </summary>
    internal const int ChunksPerAvx2PairBatch = 2;

    /// <summary>
    /// Bytes consumed by one <see cref="ChunksPerAvx2PairBatch"/>-wide batch.
    /// </summary>
    internal const int Avx2PairBatchSizeBytes = ChunksPerAvx2PairBatch * ChunkSizeBytes;

    /// <summary>
    /// Compresses exactly two independent, full (1024-byte) chunks, writing their two
    /// chaining values to <paramref name="outCvs"/> (16 words, chunk-major).
    /// </summary>
    /// <param name="source">The two chunks, contiguous: chunk A at offset 0, chunk B at 1024.</param>
    /// <param name="chunkCount">Always 2; present so this matches the tier-kernel function-pointer
    /// signature <see cref="CommitPartialBatch"/> and <see cref="CompressSubtreeGroup"/> dispatch through.</param>
    /// <param name="key">The 8-word key/IV words for this hash.</param>
    /// <param name="outCvs">Receives two 8-word CVs, chunk-major.</param>
    /// <param name="baseCounter">Chunk counter of chunk A; chunk B is <paramref name="baseCounter"/> + 1.</param>
    /// <param name="baseFlags">Mode flags; the per-block chunk-start/chunk-end flags are added here.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressChunks2Avx2(byte* source, int chunkCount, uint* key, uint* outCvs, ulong baseCounter, uint baseFlags)
    {
        Debug.Assert(chunkCount == ChunksPerAvx2PairBatch, "the pair kernel compresses exactly two chunks");

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

        for (int blockIdx = 0; blockIdx < 16; blockIdx++)
        {
            var row2 = row2Seed;
            var row3 = blockIdx == 0 ? row3Start : (blockIdx == 15 ? row3End : row3Mid);

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

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector256<uint> Row3Pair(ulong counterA, ulong counterB, uint flags) =>
        Vector256.Create(
            (uint)counterA, (uint)(counterA >> 32), BlockSizeBytes, flags,
            (uint)counterB, (uint)(counterB >> 32), BlockSizeBytes, flags);

    /// <summary>
    /// The seven-round Samuel Neves schedule over a pair of independent blocks, one per
    /// 128-bit half. Mirrors <see cref="GRounds128"/> exactly; only the register width
    /// and the message load differ.
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
        DiagPermute256Pair(ref row1, ref row2, ref row3);
        GRound256Pair(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
        DiagPermute256Pair(ref row3, ref row2, ref row1);

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
            DiagPermute256Pair(ref row1, ref row2, ref row3);
            GRound256Pair(ref row0, ref row1, ref row2, ref row3, diagX, diagY);
            DiagPermute256Pair(ref row3, ref row2, ref row1);
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

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermute256Pair(ref Vector256<uint> row1, ref Vector256<uint> row2, ref Vector256<uint> row3)
    {
        row1 = Avx2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
        row2 = Avx2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
        row3 = Avx2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2
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
        a = Avx2.Add(a, Avx2.Add(b, x));
        // d = ror(d ^ a, 16)
        d = RotateRight16(Avx2.Xor(d, a));
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 12)
        b = RotateRight12(Avx2.Xor(b, c));
        // a = a + b + y
        a = Avx2.Add(a, Avx2.Add(b, y));
        // d = ror(d ^ a, 8)
        d = RotateRight8(Avx2.Xor(d, a));
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 7)
        b = RotateRight7(Avx2.Xor(b, c));
    }
}

#endif
