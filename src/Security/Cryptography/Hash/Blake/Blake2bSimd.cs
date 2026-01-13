// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// SIMD-optimized BLAKE2b compression function using hardware intrinsics.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses SSE2/SSSE3/AVX2 intrinsics for vectorized processing
/// of the BLAKE2b G function, providing significant performance improvements
/// on modern x86/x64 processors.
/// </para>
/// <para>
/// The optimization approach is inspired by the SauceControl.Blake2Fast library
/// and the official BLAKE2 reference implementations.
/// </para>
/// </remarks>
internal static class Blake2bSimd
{
    /// <summary>
    /// Gets a value indicating whether SIMD-optimized BLAKE2b is supported on this platform.
    /// </summary>
    public static bool IsSupported => Sse2.IsSupported;

    /// <summary>
    /// Gets a value indicating whether AVX2 optimizations are available.
    /// </summary>
    public static bool IsAvx2Supported => Avx2.IsSupported;

    // BLAKE2b IV constants
    private static readonly Vector128<ulong> IV0 = Vector128.Create(0x6a09e667f3bcc908UL, 0xbb67ae8584caa73bUL);
    private static readonly Vector128<ulong> IV1 = Vector128.Create(0x3c6ef372fe94f82bUL, 0xa54ff53a5f1d36f1UL);
    private static readonly Vector128<ulong> IV2 = Vector128.Create(0x510e527fade682d1UL, 0x9b05688c2b3e6c1fUL);
    private static readonly Vector128<ulong> IV3 = Vector128.Create(0x5be0cd19137e2179UL, 0x1f83d9abfb41bd6bUL);

    // Rotation constants for SSSE3 byte shuffle
    private static readonly Vector128<byte> Rot24Shuffle = Vector128.Create(
        (byte)3, 4, 5, 6, 7, 0, 1, 2,
        11, 12, 13, 14, 15, 8, 9, 10);

    private static readonly Vector128<byte> Rot16Shuffle = Vector128.Create(
        (byte)2, 3, 4, 5, 6, 7, 0, 1,
        10, 11, 12, 13, 14, 15, 8, 9);

    /// <summary>
    /// Compresses a block using SIMD intrinsics.
    /// </summary>
    /// <param name="state">The current hash state (8 ulongs).</param>
    /// <param name="block">The 128-byte block to compress.</param>
    /// <param name="bytesCompressed">Total bytes compressed so far.</param>
    /// <param name="isFinal">Whether this is the final block.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Compress(Span<ulong> state, ReadOnlySpan<byte> block, ulong bytesCompressed, bool isFinal)
    {
        if (Avx2.IsSupported)
        {
            CompressAvx2(state, block, bytesCompressed, isFinal);
        }
        else if (Sse2.IsSupported)
        {
            CompressSse2(state, block, bytesCompressed, isFinal);
        }
        else
        {
            ThrowNotSupported();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowNotSupported() =>
        throw new PlatformNotSupportedException("SIMD BLAKE2b requires SSE2 support.");

    /// <summary>
    /// SSE2-optimized compression function.
    /// </summary>
    private static void CompressSse2(Span<ulong> state, ReadOnlySpan<byte> block, ulong bytesCompressed, bool isFinal)
    {
        // Load message block as 16 64-bit words
        Span<ulong> m = stackalloc ulong[16];
        for (int i = 0; i < 16; i++)
        {
            m[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * 8));
        }

        // Load state into vectors: v0-v3 = state, v4-v7 = IV with counter/flags
        Vector128<ulong> row1a = Vector128.Create(state[0], state[1]);
        Vector128<ulong> row1b = Vector128.Create(state[2], state[3]);
        Vector128<ulong> row2a = Vector128.Create(state[4], state[5]);
        Vector128<ulong> row2b = Vector128.Create(state[6], state[7]);

        Vector128<ulong> row3a = IV0;
        Vector128<ulong> row3b = IV1;

        // row4a = IV[4] ^ counter_low, IV[5] ^ counter_high (counter_high = 0)
        Vector128<ulong> row4a = Sse2.Xor(IV2, Vector128.Create(bytesCompressed, 0UL));

        // row4b = IV[6] ^ (isFinal ? ~0 : 0), IV[7]
        Vector128<ulong> row4b = isFinal
            ? Sse2.Xor(IV3, Vector128.Create(~0UL, 0UL))
            : IV3;

        // 12 rounds of mixing
        // Round 0: sigma[0] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[0], m[1]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[2], m[3]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[4], m[5]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[6], m[7]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[8], m[9]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[10], m[11]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[12], m[13]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[14], m[15]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 1: sigma[1] = { 14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[14], m[10]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[4], m[8]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[9], m[15]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[13], m[6]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[1], m[12]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[0], m[2]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[11], m[7]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[5], m[3]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 2: sigma[2] = { 11, 8, 12, 0, 5, 2, 15, 13, 10, 14, 3, 6, 7, 1, 9, 4 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[11], m[8]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[12], m[0]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[5], m[2]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[15], m[13]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[10], m[14]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[3], m[6]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[7], m[1]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[9], m[4]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 3: sigma[3] = { 7, 9, 3, 1, 13, 12, 11, 14, 2, 6, 5, 10, 4, 0, 15, 8 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[7], m[9]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[3], m[1]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[13], m[12]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[11], m[14]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[2], m[6]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[5], m[10]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[4], m[0]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[15], m[8]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 4: sigma[4] = { 9, 0, 5, 7, 2, 4, 10, 15, 14, 1, 11, 12, 6, 8, 3, 13 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[9], m[0]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[5], m[7]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[2], m[4]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[10], m[15]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[14], m[1]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[11], m[12]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[6], m[8]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[3], m[13]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 5: sigma[5] = { 2, 12, 6, 10, 0, 11, 8, 3, 4, 13, 7, 5, 15, 14, 1, 9 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[2], m[12]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[6], m[10]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[0], m[11]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[8], m[3]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[4], m[13]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[7], m[5]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[15], m[14]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[1], m[9]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 6: sigma[6] = { 12, 5, 1, 15, 14, 13, 4, 10, 0, 7, 6, 3, 9, 2, 8, 11 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[12], m[5]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[1], m[15]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[14], m[13]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[4], m[10]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[0], m[7]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[6], m[3]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[9], m[2]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[8], m[11]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 7: sigma[7] = { 13, 11, 7, 14, 12, 1, 3, 9, 5, 0, 15, 4, 8, 6, 2, 10 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[13], m[11]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[7], m[14]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[12], m[1]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[3], m[9]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[5], m[0]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[15], m[4]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[8], m[6]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[2], m[10]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 8: sigma[8] = { 6, 15, 14, 9, 11, 3, 0, 8, 12, 2, 13, 7, 1, 4, 10, 5 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[6], m[15]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[14], m[9]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[11], m[3]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[0], m[8]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[12], m[2]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[13], m[7]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[1], m[4]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[10], m[5]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 9: sigma[9] = { 10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0 }
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[10], m[2]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[8], m[4]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[7], m[6]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[1], m[5]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[15], m[11]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[9], m[14]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[3], m[12]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[13], m[0]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 10: sigma[10] = sigma[0]
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[0], m[1]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[2], m[3]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[4], m[5]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[6], m[7]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[8], m[9]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[10], m[11]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[12], m[13]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[14], m[15]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Round 11: sigma[11] = sigma[1]
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[14], m[10]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[4], m[8]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[9], m[15]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[13], m[6]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[1], m[12]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[0], m[2]);
        Diagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);
        G2Sse2(ref row1a, ref row2a, ref row3a, ref row4a, m[11], m[7]);
        G2Sse2(ref row1b, ref row2b, ref row3b, ref row4b, m[5], m[3]);
        Undiagonalize(ref row1a, ref row1b, ref row2a, ref row2b, ref row3a, ref row3b, ref row4a, ref row4b);

        // Finalize: state[i] ^= v[i] ^ v[i+8]
        Vector128<ulong> s0 = Vector128.Create(state[0], state[1]);
        Vector128<ulong> s1 = Vector128.Create(state[2], state[3]);
        Vector128<ulong> s2 = Vector128.Create(state[4], state[5]);
        Vector128<ulong> s3 = Vector128.Create(state[6], state[7]);

        s0 = Sse2.Xor(s0, Sse2.Xor(row1a, row3a));
        s1 = Sse2.Xor(s1, Sse2.Xor(row1b, row3b));
        s2 = Sse2.Xor(s2, Sse2.Xor(row2a, row4a));
        s3 = Sse2.Xor(s3, Sse2.Xor(row2b, row4b));

        state[0] = s0.GetElement(0);
        state[1] = s0.GetElement(1);
        state[2] = s1.GetElement(0);
        state[3] = s1.GetElement(1);
        state[4] = s2.GetElement(0);
        state[5] = s2.GetElement(1);
        state[6] = s3.GetElement(0);
        state[7] = s3.GetElement(1);
    }

    /// <summary>
    /// AVX2-optimized compression function (placeholder - falls back to SSE2 for now).
    /// </summary>
    private static void CompressAvx2(Span<ulong> state, ReadOnlySpan<byte> block, ulong bytesCompressed, bool isFinal)
    {
        // For now, use SSE2 implementation. AVX2 would use 256-bit vectors.
        CompressSse2(state, block, bytesCompressed, isFinal);
    }

    /// <summary>
    /// Vectorized G function for two parallel G operations.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void G2Sse2(
        ref Vector128<ulong> a, ref Vector128<ulong> b,
        ref Vector128<ulong> c, ref Vector128<ulong> d,
        ulong mx, ulong my)
    {
        Vector128<ulong> x = Vector128.Create(mx, my);

        // a = a + b + x
        a = Sse2.Add(Sse2.Add(a, b), Vector128.Create(mx, mx));

        // d = ror(d ^ a, 32)
        d = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(d, 32), Sse2.ShiftLeftLogical(d, 32));

        // c = c + d
        c = Sse2.Add(c, d);

        // b = ror(b ^ c, 24)
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(b, 24), Sse2.ShiftLeftLogical(b, 40));

        // a = a + b + y
        a = Sse2.Add(Sse2.Add(a, b), Vector128.Create(my, my));

        // d = ror(d ^ a, 16)
        d = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftRightLogical(d, 16), Sse2.ShiftLeftLogical(d, 48));

        // c = c + d
        c = Sse2.Add(c, d);

        // b = ror(b ^ c, 63)
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(b, 63), Sse2.ShiftLeftLogical(b, 1));
    }

    /// <summary>
    /// Diagonalize the working vectors for diagonal step.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Diagonalize(
        ref Vector128<ulong> row1a, ref Vector128<ulong> row1b,
        ref Vector128<ulong> row2a, ref Vector128<ulong> row2b,
        ref Vector128<ulong> row3a, ref Vector128<ulong> row3b,
        ref Vector128<ulong> row4a, ref Vector128<ulong> row4b)
    {
        // Shuffle elements for diagonal access pattern
        // row2: rotate left by 1 (swap halves between a and b)
        var t = row2a;
        row2a = Sse2.UnpackLow(row2a, row2b);
        row2a = Sse2.Shuffle(row2a.AsDouble(), row2a.AsDouble(), 1).AsUInt64();
        row2b = Sse2.UnpackHigh(t, row2b);
        row2b = Sse2.Shuffle(row2b.AsDouble(), row2b.AsDouble(), 1).AsUInt64();

        // row3: swap a and b
        t = row3a;
        row3a = row3b;
        row3b = t;

        // row4: rotate right by 1
        t = row4b;
        row4b = Sse2.UnpackLow(row4a, row4b);
        row4b = Sse2.Shuffle(row4b.AsDouble(), row4b.AsDouble(), 1).AsUInt64();
        row4a = Sse2.UnpackHigh(row4a, t);
        row4a = Sse2.Shuffle(row4a.AsDouble(), row4a.AsDouble(), 1).AsUInt64();
    }

    /// <summary>
    /// Undiagonalize the working vectors after diagonal step.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Undiagonalize(
        ref Vector128<ulong> row1a, ref Vector128<ulong> row1b,
        ref Vector128<ulong> row2a, ref Vector128<ulong> row2b,
        ref Vector128<ulong> row3a, ref Vector128<ulong> row3b,
        ref Vector128<ulong> row4a, ref Vector128<ulong> row4b)
    {
        // Reverse the diagonalization
        // row2: rotate right by 1
        var t = row2b;
        row2b = Sse2.UnpackLow(row2a, row2b);
        row2b = Sse2.Shuffle(row2b.AsDouble(), row2b.AsDouble(), 1).AsUInt64();
        row2a = Sse2.UnpackHigh(row2a, t);
        row2a = Sse2.Shuffle(row2a.AsDouble(), row2a.AsDouble(), 1).AsUInt64();

        // row3: swap a and b
        t = row3a;
        row3a = row3b;
        row3b = t;

        // row4: rotate left by 1
        t = row4a;
        row4a = Sse2.UnpackLow(row4a, row4b);
        row4a = Sse2.Shuffle(row4a.AsDouble(), row4a.AsDouble(), 1).AsUInt64();
        row4b = Sse2.UnpackHigh(t, row4b);
        row4b = Sse2.Shuffle(row4b.AsDouble(), row4b.AsDouble(), 1).AsUInt64();
    }
}

#endif
