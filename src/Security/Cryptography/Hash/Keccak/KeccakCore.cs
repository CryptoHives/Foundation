// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Provides the core Keccak-f[1600] permutation and sponge construction primitives.
/// </summary>
/// <remarks>
/// <para>
/// This class implements the Keccak permutation used by SHA-3, SHAKE, cSHAKE, KMAC,
/// and related algorithms. It is designed as a shared primitive to reduce code
/// duplication across Keccak-based implementations.
/// </para>
/// <para>
/// The Keccak state is a 5×5×64 = 1600-bit array organized as 25 64-bit lanes.
/// </para>
/// <para>
/// On platforms with AVX2 support (.NET 8+), an optimized SIMD implementation is used.
/// </para>
/// </remarks>
internal static class KeccakCore
{
    /// <summary>
    /// The state size in 64-bit words (25 lanes × 64 bits = 1600 bits).
    /// </summary>
    public const int StateSize = 25;

    /// <summary>
    /// The number of rounds in the Keccak-f[1600] permutation.
    /// </summary>
    public const int Rounds = 24;

    /// <summary>
    /// Round constants for the iota step of Keccak-f[1600].
    /// </summary>
    /// <remarks>
    /// These constants are derived from the output of a linear feedback shift register.
    /// </remarks>
    public static ReadOnlySpan<ulong> RoundConstants =>
    [
        0x0000000000000001UL, 0x0000000000008082UL, 0x800000000000808aUL, 0x8000000080008000UL,
        0x000000000000808bUL, 0x0000000080000001UL, 0x8000000080008081UL, 0x8000000000008009UL,
        0x000000000000008aUL, 0x0000000000000088UL, 0x0000000080008009UL, 0x000000008000000aUL,
        0x000000008000808bUL, 0x800000000000008bUL, 0x8000000000008089UL, 0x8000000000008003UL,
        0x8000000000008002UL, 0x8000000000000080UL, 0x000000000000800aUL, 0x800000008000000aUL,
        0x8000000080008081UL, 0x8000000000008080UL, 0x0000000080000001UL, 0x8000000080008008UL
    ];

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets a value indicating whether hardware-accelerated Keccak permutation is available.
    /// </summary>
    public static bool IsAccelerated => Avx2.IsSupported;
#endif

    /// <summary>
    /// Performs the Keccak-f[1600] permutation on the given state.
    /// </summary>
    /// <param name="state">The 25-element state array to permute in place.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Permute(ulong[] state)
    {
#if NET8_0_OR_GREATER
        if (IsAccelerated)
        {
            PermuteAvx2(state);
            return;
        }
#endif
        PermuteScalar(state);
    }

    /// <summary>
    /// Scalar implementation of the Keccak-f[1600] permutation.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void PermuteScalar(ulong[] state)
    {
        Span<ulong> c = stackalloc ulong[5];
        Span<ulong> d = stackalloc ulong[5];
        Span<ulong> b = stackalloc ulong[25];

        unchecked
        {
            for (int round = 0; round < Rounds; round++)
            {
                // Theta step: compute column parities
                c[0] = state[0] ^ state[5] ^ state[10] ^ state[15] ^ state[20];
                c[1] = state[1] ^ state[6] ^ state[11] ^ state[16] ^ state[21];
                c[2] = state[2] ^ state[7] ^ state[12] ^ state[17] ^ state[22];
                c[3] = state[3] ^ state[8] ^ state[13] ^ state[18] ^ state[23];
                c[4] = state[4] ^ state[9] ^ state[14] ^ state[19] ^ state[24];

                d[0] = c[4] ^ RotateLeft(c[1], 1);
                d[1] = c[0] ^ RotateLeft(c[2], 1);
                d[2] = c[1] ^ RotateLeft(c[3], 1);
                d[3] = c[2] ^ RotateLeft(c[4], 1);
                d[4] = c[3] ^ RotateLeft(c[0], 1);

                state[0] ^= d[0];
                state[1] ^= d[1];
                state[2] ^= d[2];
                state[3] ^= d[3];
                state[4] ^= d[4];
                state[5] ^= d[0];
                state[6] ^= d[1];
                state[7] ^= d[2];
                state[8] ^= d[3];
                state[9] ^= d[4];
                state[10] ^= d[0];
                state[11] ^= d[1];
                state[12] ^= d[2];
                state[13] ^= d[3];
                state[14] ^= d[4];
                state[15] ^= d[0];
                state[16] ^= d[1];
                state[17] ^= d[2];
                state[18] ^= d[3];
                state[19] ^= d[4];
                state[20] ^= d[0];
                state[21] ^= d[1];
                state[22] ^= d[2];
                state[23] ^= d[3];
                state[24] ^= d[4];

                // Rho and Pi steps combined: rotate and reorder lanes
                b[0] = state[0];
                b[1] = RotateLeft(state[6], 44);
                b[2] = RotateLeft(state[12], 43);
                b[3] = RotateLeft(state[18], 21);
                b[4] = RotateLeft(state[24], 14);
                b[5] = RotateLeft(state[3], 28);
                b[6] = RotateLeft(state[9], 20);
                b[7] = RotateLeft(state[10], 3);
                b[8] = RotateLeft(state[16], 45);
                b[9] = RotateLeft(state[22], 61);
                b[10] = RotateLeft(state[1], 1);
                b[11] = RotateLeft(state[7], 6);
                b[12] = RotateLeft(state[13], 25);
                b[13] = RotateLeft(state[19], 8);
                b[14] = RotateLeft(state[20], 18);
                b[15] = RotateLeft(state[4], 27);
                b[16] = RotateLeft(state[5], 36);
                b[17] = RotateLeft(state[11], 10);
                b[18] = RotateLeft(state[17], 15);
                b[19] = RotateLeft(state[23], 56);
                b[20] = RotateLeft(state[2], 62);
                b[21] = RotateLeft(state[8], 55);
                b[22] = RotateLeft(state[14], 39);
                b[23] = RotateLeft(state[15], 41);
                b[24] = RotateLeft(state[21], 2);

                // Chi step: non-linear mixing
                for (int y = 0; y < 5; y++)
                {
                    int offset = y * 5;
                    state[offset] = b[offset] ^ (~b[offset + 1] & b[offset + 2]);
                    state[offset + 1] = b[offset + 1] ^ (~b[offset + 2] & b[offset + 3]);
                    state[offset + 2] = b[offset + 2] ^ (~b[offset + 3] & b[offset + 4]);
                    state[offset + 3] = b[offset + 3] ^ (~b[offset + 4] & b[offset]);
                    state[offset + 4] = b[offset + 4] ^ (~b[offset] & b[offset + 1]);
                }

                // Iota step: break symmetry with round constant
                state[0] ^= RoundConstants[round];
            }
        }
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// AVX2-optimized implementation of the Keccak-f[1600] permutation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This implementation uses AVX2 256-bit vectors to accelerate the Theta and Chi steps.
    /// The 25-lane state is processed in groups of 4 lanes where possible.
    /// </para>
    /// <para>
    /// Key optimizations:
    /// - Theta step: parallel XOR and rotate operations on 4 lanes at once
    /// - Chi step: parallel AND-NOT and XOR operations on 4 lanes at once
    /// - Uses BMI2 RORX instruction via BitOperations.RotateLeft for rotations
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void PermuteAvx2(ulong[] state)
    {
        // Load state into local variables for better register allocation
        ulong s00 = state[0], s01 = state[1], s02 = state[2], s03 = state[3], s04 = state[4];
        ulong s05 = state[5], s06 = state[6], s07 = state[7], s08 = state[8], s09 = state[9];
        ulong s10 = state[10], s11 = state[11], s12 = state[12], s13 = state[13], s14 = state[14];
        ulong s15 = state[15], s16 = state[16], s17 = state[17], s18 = state[18], s19 = state[19];
        ulong s20 = state[20], s21 = state[21], s22 = state[22], s23 = state[23], s24 = state[24];

        for (int round = 0; round < Rounds; round++)
        {
            // ========== Theta step ==========
            // Compute column parities: C[x] = state[x] ^ state[x+5] ^ state[x+10] ^ state[x+15] ^ state[x+20]
            ulong c0 = s00 ^ s05 ^ s10 ^ s15 ^ s20;
            ulong c1 = s01 ^ s06 ^ s11 ^ s16 ^ s21;
            ulong c2 = s02 ^ s07 ^ s12 ^ s17 ^ s22;
            ulong c3 = s03 ^ s08 ^ s13 ^ s18 ^ s23;
            ulong c4 = s04 ^ s09 ^ s14 ^ s19 ^ s24;

            // Compute D[x] = C[x-1] ^ ROL(C[x+1], 1)
            ulong d0 = c4 ^ BitOperations.RotateLeft(c1, 1);
            ulong d1 = c0 ^ BitOperations.RotateLeft(c2, 1);
            ulong d2 = c1 ^ BitOperations.RotateLeft(c3, 1);
            ulong d3 = c2 ^ BitOperations.RotateLeft(c4, 1);
            ulong d4 = c3 ^ BitOperations.RotateLeft(c0, 1);

            // Apply Theta: state[x,y] ^= D[x] - use AVX2 for parallel XOR
            // Process rows 0-3 (16 lanes) with AVX2, then row 4 (5 lanes) scalar
            Vector256<ulong> dv0 = Vector256.Create(d0, d1, d2, d3);
            Vector256<ulong> dv1 = Vector256.Create(d4, d0, d1, d2);

            // Row 0: lanes 0-3
            Vector256<ulong> row0 = Vector256.Create(s00, s01, s02, s03);
            row0 = Avx2.Xor(row0, dv0);
            s00 = row0.GetElement(0); s01 = row0.GetElement(1); s02 = row0.GetElement(2); s03 = row0.GetElement(3);
            s04 ^= d4;

            // Row 1: lanes 5-8
            Vector256<ulong> row1 = Vector256.Create(s05, s06, s07, s08);
            row1 = Avx2.Xor(row1, dv0);
            s05 = row1.GetElement(0); s06 = row1.GetElement(1); s07 = row1.GetElement(2); s08 = row1.GetElement(3);
            s09 ^= d4;

            // Row 2: lanes 10-13
            Vector256<ulong> row2 = Vector256.Create(s10, s11, s12, s13);
            row2 = Avx2.Xor(row2, dv0);
            s10 = row2.GetElement(0); s11 = row2.GetElement(1); s12 = row2.GetElement(2); s13 = row2.GetElement(3);
            s14 ^= d4;

            // Row 3: lanes 15-18
            Vector256<ulong> row3 = Vector256.Create(s15, s16, s17, s18);
            row3 = Avx2.Xor(row3, dv0);
            s15 = row3.GetElement(0); s16 = row3.GetElement(1); s17 = row3.GetElement(2); s18 = row3.GetElement(3);
            s19 ^= d4;

            // Row 4: lanes 20-23
            Vector256<ulong> row4 = Vector256.Create(s20, s21, s22, s23);
            row4 = Avx2.Xor(row4, dv0);
            s20 = row4.GetElement(0); s21 = row4.GetElement(1); s22 = row4.GetElement(2); s23 = row4.GetElement(3);
            s24 ^= d4;

            // ========== Rho and Pi steps combined ==========
            // Each b[i] = ROL(state[pi[i]], rho[i])
            // Pi permutation indices and Rho rotation amounts are pre-computed
            ulong b00 = s00;
            ulong b01 = BitOperations.RotateLeft(s06, 44);
            ulong b02 = BitOperations.RotateLeft(s12, 43);
            ulong b03 = BitOperations.RotateLeft(s18, 21);
            ulong b04 = BitOperations.RotateLeft(s24, 14);
            ulong b05 = BitOperations.RotateLeft(s03, 28);
            ulong b06 = BitOperations.RotateLeft(s09, 20);
            ulong b07 = BitOperations.RotateLeft(s10, 3);
            ulong b08 = BitOperations.RotateLeft(s16, 45);
            ulong b09 = BitOperations.RotateLeft(s22, 61);
            ulong b10 = BitOperations.RotateLeft(s01, 1);
            ulong b11 = BitOperations.RotateLeft(s07, 6);
            ulong b12 = BitOperations.RotateLeft(s13, 25);
            ulong b13 = BitOperations.RotateLeft(s19, 8);
            ulong b14 = BitOperations.RotateLeft(s20, 18);
            ulong b15 = BitOperations.RotateLeft(s04, 27);
            ulong b16 = BitOperations.RotateLeft(s05, 36);
            ulong b17 = BitOperations.RotateLeft(s11, 10);
            ulong b18 = BitOperations.RotateLeft(s17, 15);
            ulong b19 = BitOperations.RotateLeft(s23, 56);
            ulong b20 = BitOperations.RotateLeft(s02, 62);
            ulong b21 = BitOperations.RotateLeft(s08, 55);
            ulong b22 = BitOperations.RotateLeft(s14, 39);
            ulong b23 = BitOperations.RotateLeft(s15, 41);
            ulong b24 = BitOperations.RotateLeft(s21, 2);

            // ========== Chi step with AVX2 ==========
            // Chi: state[x] = b[x] ^ (~b[x+1] & b[x+2])
            // Process each row of 5 elements using AVX2 where beneficial

            // Row 0: b00-b04
            Vector256<ulong> bv0_01 = Vector256.Create(b00, b01, b02, b03);
            Vector256<ulong> bv0_12 = Vector256.Create(b01, b02, b03, b04);
            Vector256<ulong> bv0_23 = Vector256.Create(b02, b03, b04, b00);
            Vector256<ulong> chi0 = Avx2.Xor(bv0_01, Avx2.AndNot(bv0_12, bv0_23));
            s00 = chi0.GetElement(0); s01 = chi0.GetElement(1); s02 = chi0.GetElement(2); s03 = chi0.GetElement(3);
            s04 = b04 ^ (~b00 & b01);

            // Row 1: b05-b09
            Vector256<ulong> bv1_01 = Vector256.Create(b05, b06, b07, b08);
            Vector256<ulong> bv1_12 = Vector256.Create(b06, b07, b08, b09);
            Vector256<ulong> bv1_23 = Vector256.Create(b07, b08, b09, b05);
            Vector256<ulong> chi1 = Avx2.Xor(bv1_01, Avx2.AndNot(bv1_12, bv1_23));
            s05 = chi1.GetElement(0); s06 = chi1.GetElement(1); s07 = chi1.GetElement(2); s08 = chi1.GetElement(3);
            s09 = b09 ^ (~b05 & b06);

            // Row 2: b10-b14
            Vector256<ulong> bv2_01 = Vector256.Create(b10, b11, b12, b13);
            Vector256<ulong> bv2_12 = Vector256.Create(b11, b12, b13, b14);
            Vector256<ulong> bv2_23 = Vector256.Create(b12, b13, b14, b10);
            Vector256<ulong> chi2 = Avx2.Xor(bv2_01, Avx2.AndNot(bv2_12, bv2_23));
            s10 = chi2.GetElement(0); s11 = chi2.GetElement(1); s12 = chi2.GetElement(2); s13 = chi2.GetElement(3);
            s14 = b14 ^ (~b10 & b11);

            // Row 3: b15-b19
            Vector256<ulong> bv3_01 = Vector256.Create(b15, b16, b17, b18);
            Vector256<ulong> bv3_12 = Vector256.Create(b16, b17, b18, b19);
            Vector256<ulong> bv3_23 = Vector256.Create(b17, b18, b19, b15);
            Vector256<ulong> chi3 = Avx2.Xor(bv3_01, Avx2.AndNot(bv3_12, bv3_23));
            s15 = chi3.GetElement(0); s16 = chi3.GetElement(1); s17 = chi3.GetElement(2); s18 = chi3.GetElement(3);
            s19 = b19 ^ (~b15 & b16);

            // Row 4: b20-b24
            Vector256<ulong> bv4_01 = Vector256.Create(b20, b21, b22, b23);
            Vector256<ulong> bv4_12 = Vector256.Create(b21, b22, b23, b24);
            Vector256<ulong> bv4_23 = Vector256.Create(b22, b23, b24, b20);
            Vector256<ulong> chi4 = Avx2.Xor(bv4_01, Avx2.AndNot(bv4_12, bv4_23));
            s20 = chi4.GetElement(0); s21 = chi4.GetElement(1); s22 = chi4.GetElement(2); s23 = chi4.GetElement(3);
            s24 = b24 ^ (~b20 & b21);

            // ========== Iota step ==========
            s00 ^= RoundConstants[round];
        }

        // Store state back
        state[0] = s00; state[1] = s01; state[2] = s02; state[3] = s03; state[4] = s04;
        state[5] = s05; state[6] = s06; state[7] = s07; state[8] = s08; state[9] = s09;
        state[10] = s10; state[11] = s11; state[12] = s12; state[13] = s13; state[14] = s14;
        state[15] = s15; state[16] = s16; state[17] = s17; state[18] = s18; state[19] = s19;
        state[20] = s20; state[21] = s21; state[22] = s22; state[23] = s23; state[24] = s24;
    }
#endif

    /// <summary>
    /// Absorbs a block of data into the Keccak state by XORing it with the rate portion.
    /// </summary>
    /// <param name="state">The 25-element state array.</param>
    /// <param name="block">The block to absorb (must be exactly rateBytes long).</param>
    /// <param name="rateBytes">The rate in bytes (determines how many bytes to XOR).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Absorb(ulong[] state, ReadOnlySpan<byte> block, int rateBytes)
    {
        int rateLanes = rateBytes / 8;

        for (int i = 0; i < rateLanes; i++)
        {
            state[i] ^= BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * 8));
        }

        Permute(state);
    }

    /// <summary>
    /// Extracts output bytes from the Keccak state (single squeeze, no additional permutations).
    /// </summary>
    /// <param name="state">The 25-element state array.</param>
    /// <param name="output">The buffer to receive the output.</param>
    /// <param name="length">The number of bytes to extract (must be ≤ rate).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Squeeze(ulong[] state, Span<byte> output, int length)
    {
        const int uInt64Size = sizeof(ulong);
        int offset = 0;
        int stateIndex = 0;

        int bytesToCopy = length - offset;
        while (bytesToCopy >= uInt64Size)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(offset), state[stateIndex]);
            offset += uInt64Size;
            bytesToCopy -= uInt64Size;
            stateIndex++;
        }

        if (bytesToCopy > 0)
        {
            Span<byte> temp = stackalloc byte[uInt64Size];
            BinaryPrimitives.WriteUInt64LittleEndian(temp, state[stateIndex]);
            temp.Slice(0, bytesToCopy).CopyTo(output.Slice(offset));
        }
    }

    /// <summary>
    /// Performs an extended squeeze operation for XOF (extendable-output function) algorithms.
    /// </summary>
    /// <param name="state">The 25-element state array.</param>
    /// <param name="output">The buffer to receive the output.</param>
    /// <param name="rateBytes">The rate in bytes.</param>
    /// <param name="squeezeOffset">
    /// The current offset within the rate portion. Updated after the operation.
    /// </param>
    public static void SqueezeXof(ulong[] state, Span<byte> output, int rateBytes, ref int squeezeOffset)
    {
        int outputOffset = 0;

        while (outputOffset < output.Length)
        {
            if (squeezeOffset >= rateBytes)
            {
                Permute(state);
                squeezeOffset = 0;
            }

            int stateIndex = squeezeOffset / 8;
            int byteIndex = squeezeOffset % 8;

            unchecked
            {
                while (outputOffset < output.Length && squeezeOffset < rateBytes)
                {
                    output[outputOffset++] = (byte)(state[stateIndex] >> (byteIndex * 8));
                    byteIndex++;
                    squeezeOffset++;

                    if (byteIndex >= 8)
                    {
                        byteIndex = 0;
                        stateIndex++;
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong RotateLeft(ulong x, int n) => BitOperations.RotateLeft(x, n);
}
