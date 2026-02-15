// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - K is a standard cryptographic constant name per FIPS 180-4

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Shared compression function and constants for SHA-256 family algorithms.
/// </summary>
/// <remarks>
/// <para>
/// This internal class provides the core cryptographic operations shared by
/// SHA-256 and SHA-224. Both algorithms use identical compression functions
/// and round constants, differing only in their initial hash values and
/// output truncation.
/// </para>
/// </remarks>
internal static class SHA256Core
{
    /// <summary>
    /// The number of rounds in the SHA-256 compression function.
    /// </summary>
    public const int Rounds = 64;

    /// <summary>
    /// The block size in bytes for all SHA-256 family algorithms.
    /// </summary>
    public const int BlockSizeBytes = 64;

    /// <summary>
    /// SHA-256 round constants (first 32 bits of the fractional parts of the cube roots of the first 64 primes).
    /// </summary>
    /// <remarks>
    /// These constants are shared by SHA-256 and SHA-224.
    /// </remarks>
    public static readonly uint[] K =
    [
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
    ];

    /// <summary>
    /// Processes a single 64-byte block, updating the state.
    /// </summary>
    /// <param name="block">The 64-byte block to process.</param>
    /// <param name="state">The 8-element state array to update.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ProcessBlock(ReadOnlySpan<byte> block, Span<uint> state)
    {
        Span<uint> w = stackalloc uint[64];

        unchecked
        {
            // Prepare message schedule - first 16 words from input
            for (int i = 0; i < 16; i++)
            {
                w[i] = BinaryPrimitives.ReadUInt32BigEndian(block.Slice(i * sizeof(UInt32)));
            }

            // Extend message schedule W[16..63]
            for (int i = 16; i < 64; i++)
            {
                uint w15 = w[i - 15];
                uint w2 = w[i - 2];
                uint s0 = BitOperations.RotateRight(w15, 7) ^ BitOperations.RotateRight(w15, 18) ^ (w15 >> 3);
                uint s1 = BitOperations.RotateRight(w2, 17) ^ BitOperations.RotateRight(w2, 19) ^ (w2 >> 10);
                w[i] = w[i - 16] + s0 + w[i - 7] + s1;
            }

            // Initialize working variables
            uint a = state[0];
            uint b = state[1];
            uint c = state[2];
            uint d = state[3];
            uint e = state[4];
            uint f = state[5];
            uint g = state[6];
            uint h = state[7];

            // 8 Unrolled compression rounds with implicit variable rotation
#if NET8_0_OR_GREATER
            ref uint kPtr = ref MemoryMarshal.GetArrayDataReference(K);
            ref uint wPtr = ref MemoryMarshal.GetReference(w);

            // notes: unroll only a single round of variable rotation to improve IL generation and cache locality
            for (int i = 0; i < Rounds; i += 8)
            {
                Round(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h, Unsafe.Add(ref kPtr, i + 0), Unsafe.Add(ref wPtr, i + 0));
                Round(ref h, ref a, ref b, ref c, ref d, ref e, ref f, ref g, Unsafe.Add(ref kPtr, i + 1), Unsafe.Add(ref wPtr, i + 1));
                Round(ref g, ref h, ref a, ref b, ref c, ref d, ref e, ref f, Unsafe.Add(ref kPtr, i + 2), Unsafe.Add(ref wPtr, i + 2));
                Round(ref f, ref g, ref h, ref a, ref b, ref c, ref d, ref e, Unsafe.Add(ref kPtr, i + 3), Unsafe.Add(ref wPtr, i + 3));
                Round(ref e, ref f, ref g, ref h, ref a, ref b, ref c, ref d, Unsafe.Add(ref kPtr, i + 4), Unsafe.Add(ref wPtr, i + 4));
                Round(ref d, ref e, ref f, ref g, ref h, ref a, ref b, ref c, Unsafe.Add(ref kPtr, i + 5), Unsafe.Add(ref wPtr, i + 5));
                Round(ref c, ref d, ref e, ref f, ref g, ref h, ref a, ref b, Unsafe.Add(ref kPtr, i + 6), Unsafe.Add(ref wPtr, i + 6));
                Round(ref b, ref c, ref d, ref e, ref f, ref g, ref h, ref a, Unsafe.Add(ref kPtr, i + 7), Unsafe.Add(ref wPtr, i + 7));
            }
#else
            for (int i = 0; i < Rounds; i += 8)
            {
                Round(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h, K[i + 0], w[i + 0]);
                Round(ref h, ref a, ref b, ref c, ref d, ref e, ref f, ref g, K[i + 1], w[i + 1]);
                Round(ref g, ref h, ref a, ref b, ref c, ref d, ref e, ref f, K[i + 2], w[i + 2]);
                Round(ref f, ref g, ref h, ref a, ref b, ref c, ref d, ref e, K[i + 3], w[i + 3]);
                Round(ref e, ref f, ref g, ref h, ref a, ref b, ref c, ref d, K[i + 4], w[i + 4]);
                Round(ref d, ref e, ref f, ref g, ref h, ref a, ref b, ref c, K[i + 5], w[i + 5]);
                Round(ref c, ref d, ref e, ref f, ref g, ref h, ref a, ref b, K[i + 6], w[i + 6]);
                Round(ref b, ref c, ref d, ref e, ref f, ref g, ref h, ref a, K[i + 7], w[i + 7]);
            }
#endif

            // Add compressed chunk to current hash value
            state[0] += a;
            state[1] += b;
            state[2] += c;
            state[3] += d;
            state[4] += e;
            state[5] += f;
            state[6] += g;
            state[7] += h;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Round(
        ref uint a, ref uint b, ref uint c, ref uint d,
        ref uint e, ref uint f, ref uint g, ref uint h,
        uint k, uint w)
    {
        unchecked
        {
            // h = h + Σ1(e) + Ch(e,f,g) + Kt + Wt
            h += k + w;

            // Σ1(e) = ROTR^6(e) XOR ROTR^11(e) XOR ROTR^25(e)
            h += BitOperations.RotateRight(e, 6) ^ BitOperations.RotateRight(e, 11) ^ BitOperations.RotateRight(e, 25);

            // Ch(e,f,g) = (e AND f) XOR (NOT e AND g)
            h += (e & f) ^ (~e & g);

            d += h;

            // h = h + Σ0(a) + Ma(a,b,c)
            // Σ0(a) = ROTR^2(a) XOR ROTR^13(a) XOR ROTR^22(a)
            h += BitOperations.RotateRight(a, 2) ^ BitOperations.RotateRight(a, 13) ^ BitOperations.RotateRight(a, 22);

            // Ma(a,b,c) = (a AND b) XOR (a AND c) XOR (b AND c)
            h += (a & b) ^ (a & c) ^ (b & c);
        }
    }

    /// <summary>
    /// Applies SHA-256/SHA-224 padding and finalizes the hash.
    /// </summary>
    /// <param name="buffer">The message buffer (must be at least 64 bytes).</param>
    /// <param name="bufferLength">Current position in the buffer.</param>
    /// <param name="bytesProcessed">Total bytes processed before this buffer.</param>
    /// <param name="state">The state array to update.</param>
    public static void PadAndFinalize(Span<byte> buffer, int bufferLength, long bytesProcessed, Span<uint> state)
    {
        unchecked
        {
            long totalBits = (bytesProcessed + bufferLength) * 8;

            // Add padding bit
            buffer[bufferLength++] = 0x80;

            // Pad to 56 bytes (448 bits) mod 64
            if (bufferLength > 56)
            {
                while (bufferLength < BlockSizeBytes)
                {
                    buffer[bufferLength++] = 0x00;
                }
                ProcessBlock(buffer, state);
                bufferLength = 0;
            }

            if (bufferLength < 56)
            {
                buffer.Slice(bufferLength, 56 - bufferLength).Clear();
            }

            // Append length in bits (big-endian)
            BinaryPrimitives.WriteInt64BigEndian(buffer.Slice(56), totalBits);

            ProcessBlock(buffer, state);
        }
    }
}
