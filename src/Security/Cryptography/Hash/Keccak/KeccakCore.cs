// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

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

    /// <summary>
    /// Performs the Keccak-f[1600] permutation on the given state.
    /// </summary>
    /// <param name="state">The 25-element state array to permute in place.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Permute(ulong[] state)
    {
        // Thread-local scratch arrays to avoid allocations
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

    /// <summary>
    /// Rotates the bits of a 64-bit unsigned integer to the left by the specified number of positions.
    /// </summary>
    /// <param name="x">The value to rotate.</param>
    /// <param name="n">The number of positions to rotate.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong RotateLeft(ulong x, int n) => BitOperations.RotateLeft(x, n);
}
