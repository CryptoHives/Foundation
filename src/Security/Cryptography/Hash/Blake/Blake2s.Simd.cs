// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// BLAKE2s SIMD-accelerated compression using SSE2, SSSE3 and AVX2 intrinsics.
/// </summary>
public sealed partial class Blake2s
{
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // BLAKE2s rotations: 16, 12, 8, 7 bits

    // Rotate right by 16 bits (swap high/low 16-bit halves within each 32-bit word)
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vectors for SSE/AVX path (Vector128<uint> holds 4 elements = 1 row)
    private static readonly Vector128<uint> IVLow = Vector128.Create(
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU);

    private static readonly Vector128<uint> IVHigh = Vector128.Create(
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U);

    // Finalization mask for inverting element 2 of row3 (v[14])
    private static readonly Vector128<uint> FinalMask = Vector128.Create(0U, 0U, ~0U, 0U);

    // Pre-computed Vector128<int> indices for gather operations (scaled by 4 for uint stride)
    private static readonly Vector128<int>[] GatherIndicesX = new Vector128<int>[Rounds * 2];
    private static readonly Vector128<int>[] GatherIndicesY = new Vector128<int>[Rounds * 2];

    // Vector state for SSE path (2 x Vector128<uint> = 8 elements = full state)
    private Vector128<uint> _stateVec0;
    private Vector128<uint> _stateVec1;

    static Blake2s()
    {
        for (int round = 0; round < Rounds; round++)
        {
            int offset = round * ScratchSize;

            // Column step indices (multiply by 4 for byte offset of uint)
            GatherIndicesX[round * 2] = Vector128.Create(
                Sigma[offset + 0] * 4, Sigma[offset + 2] * 4,
                Sigma[offset + 4] * 4, Sigma[offset + 6] * 4);
            GatherIndicesY[round * 2] = Vector128.Create(
                Sigma[offset + 1] * 4, Sigma[offset + 3] * 4,
                Sigma[offset + 5] * 4, Sigma[offset + 7] * 4);

            // Diagonal step indices
            GatherIndicesX[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 8] * 4, Sigma[offset + 10] * 4,
                Sigma[offset + 12] * 4, Sigma[offset + 14] * 4);
            GatherIndicesY[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 9] * 4, Sigma[offset + 11] * 4,
                Sigma[offset + 13] * 4, Sigma[offset + 15] * 4);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void InitializeStateSse2(uint paramBlock)
    {
        _stateVec0 = Sse2.Xor(IVLow, Vector128.Create(paramBlock, 0U, 0U, 0U));
        _stateVec1 = IVHigh;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ExtractOutputSse2(Span<byte> destination)
    {
        // Store vectors to stack, then copy required bytes
        Span<uint> temp = stackalloc uint[8];
        _stateVec0.CopyTo(temp[..4]);
        _stateVec1.CopyTo(temp[4..]);

        int fullWords = _outputBytes / sizeof(UInt32);
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * sizeof(UInt32)), temp[i]);
        }

        int remainingBytes = _outputBytes % sizeof(UInt32);
        if (remainingBytes > 0)
        {
            Span<byte> tempBytes = stackalloc byte[sizeof(UInt32)];
            BinaryPrimitives.WriteUInt32LittleEndian(tempBytes, temp[fullWords]);
            tempBytes.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(UInt32)));
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressSse2(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Initialize rows from vector state
        // row0 = v[0..3] = state[0..3]
        // row1 = v[4..7] = state[4..7]
        // row2 = v[8..11] = IV[0..3]
        // row3 = v[12..15] = IV[4..7] with counter/finalization
        var row0 = _stateVec0;
        var row1 = _stateVec1;
        var row2 = IVLow;

        // row3 = IVHigh with counter/finalization applied
        var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
        var row3 = Sse2.Xor(IVHigh, counterVec);

        if (isFinal)
        {
            row3 = Sse2.Xor(row3, FinalMask);
        }

        // Parse message block into 16 32-bit words (little-endian)
        Span<uint> m = stackalloc uint[ScratchSize];
        CopyBlockUInt32LittleEndian(block, m);

        // Get base references (avoids bounds checking in loop)
        ref byte sigmaBase = ref MemoryMarshal.GetArrayDataReference(Sigma);
        ref uint mBase = ref MemoryMarshal.GetReference(m);

        // 10 rounds of mixing
        for (int sigmaIdx = 0; sigmaIdx < Rounds * ScratchSize; sigmaIdx += ScratchSize)
        {
            // Column step: G on (v[0],v[4],v[8],v[12]), (v[1],v[5],v[9],v[13]), etc.
            var mx0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 0)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 2)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 4)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 6)));
            var my0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 1)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 3)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 5)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 7)));

            GRoundSse2(ref row0, ref row1, ref row2, ref row3, mx0, my0);

            // Diagonal step: rotate rows to align diagonals
            row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
            row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
            row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2

            var mx1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 8)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 10)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 12)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 14)));
            var my1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 9)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 11)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 13)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 15)));

            GRoundSse2(ref row0, ref row1, ref row2, ref row3, mx1, my1);

            // Un-rotate rows to restore column order
            row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
            row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
            row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
        }

        // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
        _stateVec0 = Sse2.Xor(_stateVec0, Sse2.Xor(row0, row2));
        _stateVec1 = Sse2.Xor(_stateVec1, Sse2.Xor(row1, row3));
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressSsse3(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Initialize rows from vector state
        var row0 = _stateVec0;
        var row1 = _stateVec1;
        var row2 = IVLow;

        var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
        var row3 = Sse2.Xor(IVHigh, counterVec);

        if (isFinal)
        {
            row3 = Sse2.Xor(row3, FinalMask);
        }

        // Parse message block into 16 32-bit words (little-endian)
        Span<uint> m = stackalloc uint[ScratchSize];
        CopyBlockUInt32LittleEndian(block, m);

        // Get base references (avoids bounds checking in loop)
        ref byte sigmaBase = ref MemoryMarshal.GetArrayDataReference(Sigma);
        ref uint mBase = ref MemoryMarshal.GetReference(m);

        // 10 rounds of mixing
        for (int sigmaIdx = 0; sigmaIdx < Rounds * ScratchSize; sigmaIdx += ScratchSize)
        {
            // Column step
            var mx0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 0)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 2)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 4)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 6)));
            var my0 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 1)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 3)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 5)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 7)));

            GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx0, my0);

            // Diagonal step: rotate rows
            row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
            row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
            row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2

            var mx1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 8)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 10)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 12)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 14)));
            var my1 = Vector128.Create(
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 9)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 11)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 13)),
                Unsafe.Add(ref mBase, Unsafe.Add(ref sigmaBase, sigmaIdx + 15)));

            GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx1, my1);

            // Un-rotate rows
            row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
            row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
            row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
        }

        _stateVec0 = Sse2.Xor(_stateVec0, Sse2.Xor(row0, row2));
        _stateVec1 = Sse2.Xor(_stateVec1, Sse2.Xor(row1, row3));
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressAvx2(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Pin the message block for gather operations
        fixed (byte* mPtr = block)
        {
            // Get base references for gather indices (avoids bounds checking in loop)
            ref Vector128<int> gatherXBase = ref MemoryMarshal.GetArrayDataReference(GatherIndicesX);
            ref Vector128<int> gatherYBase = ref MemoryMarshal.GetArrayDataReference(GatherIndicesY);

            // Initialize rows from vector state
            var row0 = _stateVec0;
            var row1 = _stateVec1;
            var row2 = IVLow;

            // row3 = IVHigh with counter/finalization applied
            var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
            var row3 = Sse2.Xor(IVHigh, counterVec);

            if (isFinal)
            {
                row3 = Sse2.Xor(row3, FinalMask);
            }

            // 10 rounds of mixing
            for (int gatherIdx = 0; gatherIdx < Rounds * 2; gatherIdx+=2)
            {
                // Column step - use AVX2 gather for message words
                var mx0 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherXBase, gatherIdx), 1).AsUInt32();
                var my0 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherYBase, gatherIdx), 1).AsUInt32();

                GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal step: rotate rows to align diagonals
                row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2

                // Diagonal step - use AVX2 gather for message words
                var mx1 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherXBase, gatherIdx + 1), 1).AsUInt32();
                var my1 = Avx2.GatherVector128((int*)mPtr, Unsafe.Add(ref gatherYBase, gatherIdx + 1), 1).AsUInt32();

                GRoundSsse3(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate rows to restore column order
                row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
            }

            // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
            _stateVec0 = Sse2.Xor(_stateVec0, Sse2.Xor(row0, row2));
            _stateVec1 = Sse2.Xor(_stateVec1, Sse2.Xor(row1, row3));
        }
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using SSE2 only.
    /// </summary>
    /// <remarks>
    /// Uses shift+or for all rotations to avoid SSSE3 dependency.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundSse2(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16) - use SSE2 shift+or (no SSSE3 shuffle)
        var t0 = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(t0, 16), Sse2.ShiftLeftLogical(t0, 16));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8) - use SSE2 shift+or (no SSSE3 shuffle)
        var t2 = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(t2, 8), Sse2.ShiftLeftLogical(t2, 24));
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        var t3 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t3, 7), Sse2.ShiftLeftLogical(t3, 25));
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using SSSE3 shuffle for byte-aligned rotations.
    /// </summary>
    /// <remarks>
    /// Uses SSSE3 byte shuffle for 16-bit and 8-bit rotations (faster than shift+or).
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundSsse3(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12) - must use shift+or (not byte-aligned)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7) - must use shift+or (not byte-aligned)
        var t2 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t2, 7), Sse2.ShiftLeftLogical(t2, 25));
    }
}

#endif
