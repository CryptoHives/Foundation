// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// Computes the BLAKE2b hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE2b that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE2b is optimized for 64-bit platforms and produces digests from 1 to 64 bytes.
/// The default output size is 64 bytes (512 bits).
/// </para>
/// <para>
/// BLAKE2b supports an optional key for keyed hashing (MAC mode) with keys up to 64 bytes.
/// </para>
/// </remarks>
public sealed partial class Blake2b : HashAlgorithm
{
    // Pre-computed shuffle masks for byte-aligned rotations (static to avoid recreation)
    private static readonly Vector256<byte> RotateMask24 = Vector256.Create(
        (byte)3, 4, 5, 6, 7, 0, 1, 2,
        11, 12, 13, 14, 15, 8, 9, 10,
        19, 20, 21, 22, 23, 16, 17, 18,
        27, 28, 29, 30, 31, 24, 25, 26);

    private static readonly Vector256<byte> RotateMask16 = Vector256.Create(
        (byte)2, 3, 4, 5, 6, 7, 0, 1,
        10, 11, 12, 13, 14, 15, 8, 9,
        18, 19, 20, 21, 22, 23, 16, 17,
        26, 27, 28, 29, 30, 31, 24, 25);

    // Pre-computed IV vectors for AVX2 path
    private static readonly Vector256<ulong> IVLow = Vector256.Create(
        0x6a09e667f3bcc908UL, 0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL, 0xa54ff53a5f1d36f1UL);

    private static readonly Vector256<ulong> IVHigh = Vector256.Create(
        0x510e527fade682d1UL, 0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL, 0x5be0cd19137e2179UL);

    // Finalization mask for inverting element 2 of row3
    private static readonly Vector256<ulong> FinalMask = Vector256.Create(0UL, 0UL, ~0UL, 0UL);

    // Pre-computed Vector128<int> indices for gather operations (scaled by 8 for ulong stride)
    private static readonly Vector128<int>[] GatherIndicesX = new Vector128<int>[Rounds * 2];
    private static readonly Vector128<int>[] GatherIndicesY = new Vector128<int>[Rounds * 2];

    // Vector state for AVX2 path
    private Vector256<ulong> _stateVec0;
    private Vector256<ulong> _stateVec1;

    static Blake2b()
    {
        for (int round = 0; round < Rounds; round++)
        {
            int offset = round * ScratchSize;

            // Column step indices (multiply by 8 for byte offset of ulong)
            GatherIndicesX[round * 2] = Vector128.Create(
                Sigma[offset + 0] * 8, Sigma[offset + 2] * 8,
                Sigma[offset + 4] * 8, Sigma[offset + 6] * 8);
            GatherIndicesY[round * 2] = Vector128.Create(
                Sigma[offset + 1] * 8, Sigma[offset + 3] * 8,
                Sigma[offset + 5] * 8, Sigma[offset + 7] * 8);

            // Diagonal step indices
            GatherIndicesX[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 8] * 8, Sigma[offset + 10] * 8,
                Sigma[offset + 12] * 8, Sigma[offset + 14] * 8);
            GatherIndicesY[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 9] * 8, Sigma[offset + 11] * 8,
                Sigma[offset + 13] * 8, Sigma[offset + 15] * 8);
        }
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
            return support;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void InitializeStateAvx2(ulong paramBlock)
    {
        _stateVec0 = Avx2.Xor(IVLow, Vector256.Create(paramBlock, 0UL, 0UL, 0UL));
        _stateVec1 = IVHigh;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ExtractOutputAvx2(Span<byte> destination)
    {
        // Store vectors to stack, then copy required bytes
        Span<ulong> temp = stackalloc ulong[8];
        _stateVec0.CopyTo(temp[..4]);
        _stateVec1.CopyTo(temp[4..]);

        int fullWords = _outputBytes / 8;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * sizeof(UInt64)), temp[i]);
        }

        int remainingBytes = _outputBytes & 7;
        if (remainingBytes > 0)
        {
            Span<byte> tempBytes = stackalloc byte[sizeof(UInt64)];
            BinaryPrimitives.WriteUInt64LittleEndian(tempBytes, temp[fullWords]);
            tempBytes.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(UInt64)));
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressAvx2(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

        // Pin the message block for gather operations
        fixed (byte* mPtr = block)
        {
            // Initialize rows from vector state
            var row0 = _stateVec0;
            var row1 = _stateVec1;
            var row2 = IVLow;

            // row3 = IVHigh with counter/finalization applied
            var counterVec = Vector256.Create(_bytesCompressed, 0UL, 0UL, 0UL);
            var row3 = Avx2.Xor(IVHigh, counterVec);

            if (isFinal)
            {
                // Invert element 2 (the finalization flag)
                row3 = Avx2.Xor(row3, FinalMask);
            }

            // 12 rounds
            for (int round = 0; round < Rounds; round++)
            {
                int gatherIndex = round * 2;

                // Column step - use gather for message words
                var mx = Avx2.GatherVector256((long*)mPtr, GatherIndicesX[gatherIndex], 1).AsUInt64();
                GRoundX(ref row0, ref row1, ref row2, ref row3, mx);

                var my = Avx2.GatherVector256((long*)mPtr, GatherIndicesY[gatherIndex], 1).AsUInt64();
                GRoundY(ref row0, ref row1, ref row2, ref row3, my);

                // Diagonal permutations
                Permute(ref row1, ref row2, ref row3);

                // Diagonal step
                mx = Avx2.GatherVector256((long*)mPtr, GatherIndicesX[gatherIndex + 1], 1).AsUInt64();
                GRoundX(ref row0, ref row1, ref row2, ref row3, mx);

                my = Avx2.GatherVector256((long*)mPtr, GatherIndicesY[gatherIndex + 1], 1).AsUInt64();
                GRoundY(ref row0, ref row1, ref row2, ref row3, my);

                // Un-rotate
                Permute(ref row3, ref row2, ref row1);
            }

            // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
            _stateVec0 = Avx2.Xor(_stateVec0, Avx2.Xor(row0, row2));
            _stateVec1 = Avx2.Xor(_stateVec1, Avx2.Xor(row1, row3));
        }
    }

    /// <summary>
    /// Performs one Gx round on 4 parallel lanes using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundX(
        ref Vector256<ulong> a,
        ref Vector256<ulong> b,
        ref Vector256<ulong> c,
        ref Vector256<ulong> d,
        Vector256<ulong> x)
    {
        // a = a + b + x
        a = Avx2.Add(a, Avx2.Add(b, x));
        // d = ror(d ^ a, 32)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsUInt32(), 0b_10_11_00_01).AsUInt64();

        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 24)
        b = Avx2.Shuffle(Avx2.Xor(b, c).AsByte(), RotateMask24).AsUInt64();
    }

    /// <summary>
    /// Performs one Gy round on 4 parallel lanes using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundY(
        ref Vector256<ulong> a,
        ref Vector256<ulong> b,
        ref Vector256<ulong> c,
        ref Vector256<ulong> d,
        Vector256<ulong> y)
    {
        // a = a + b + y
        a = Avx2.Add(a, Avx2.Add(b, y));
        // d = ror(d ^ a, 16)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), RotateMask16).AsUInt64();

        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 63) - must use shift+or
        var t = Avx2.Xor(b, c);
        b = Avx2.Or(Avx2.ShiftRightLogical(t, 63), Avx2.Add(t, t));
    }

    /// <summary>
    /// Performs diagonal permutations.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Permute(ref Vector256<ulong> a, ref Vector256<ulong> b, ref Vector256<ulong> c)
    {
        a = Avx2.Permute4x64(a, 0b00_11_10_01);
        b = Avx2.Permute4x64(b, 0b01_00_11_10);
        c = Avx2.Permute4x64(c, 0b10_01_00_11);
    }
}
#endif
