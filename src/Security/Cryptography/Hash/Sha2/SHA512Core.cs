// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - K is a standard cryptographic constant name per FIPS 180-4

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Shared compression function and constants for SHA-512 family algorithms.
/// </summary>
/// <remarks>
/// <para>
/// This internal class provides the core cryptographic operations shared by
/// SHA-512, SHA-384, SHA-512/224, and SHA-512/256. All these algorithms use
/// identical compression functions and round constants, differing only in
/// their initial hash values and output truncation.
/// </para>
/// <para>
/// On .NET 8+, AVX2 optimizations are available for improved message loading
/// performance using VPSHUFB for byte-swapping.
/// </para>
/// </remarks>
internal static class SHA512Core
{
    /// <summary>
    /// The block size in bytes for all SHA-512 family algorithms.
    /// </summary>
    public const int BlockSizeBytes = 128;

    /// <summary>
    /// SHA-512 round constants (first 64 bits of the fractional parts of the cube roots of the first 80 primes).
    /// </summary>
    /// <remarks>
    /// These constants are shared by SHA-512, SHA-384, SHA-512/224, and SHA-512/256.
    /// </remarks>
    public static readonly ulong[] K =
    [
        0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc,
        0x3956c25bf348b538, 0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118,
        0xd807aa98a3030242, 0x12835b0145706fbe, 0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2,
        0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235, 0xc19bf174cf692694,
        0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
        0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5,
        0x983e5152ee66dfab, 0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4,
        0xc6e00bf33da88fc2, 0xd5a79147930aa725, 0x06ca6351e003826f, 0x142929670a0e6e70,
        0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed, 0x53380d139d95b3df,
        0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
        0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30,
        0xd192e819d6ef5218, 0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8,
        0x19a4c116b8d2d0c8, 0x1e376c085141ab53, 0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8,
        0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373, 0x682e6ff3d6b2b8a3,
        0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
        0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b,
        0xca273eceea26619c, 0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178,
        0x06f067aa72176fba, 0x0a637dc5a2c898a6, 0x113f9804bef90dae, 0x1b710b35131c471b,
        0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc, 0x431d67c49c100d4c,
        0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
    ];

    /// <summary>
    /// Processes a single 128-byte block, updating the state.
    /// </summary>
    /// <param name="block">The 128-byte block to process.</param>
    /// <param name="state">The 8-element state array to update.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ProcessBlock(ReadOnlySpan<byte> block, ulong[] state)
    {
        Span<ulong> w = stackalloc ulong[80];

        unchecked
        {
            // Prepare message schedule - load first 16 words from block
            for (int i = 0; i < 16; i++)
            {
                w[i] = BinaryPrimitives.ReadUInt64BigEndian(block.Slice(i * 8));
            }

            // Extend message schedule W[16..79]
            for (int i = 16; i < 80; i++)
            {
                ulong w15 = w[i - 15];
                ulong w2 = w[i - 2];

                // σ0(x) = ROTR^1(x) XOR ROTR^8(x) XOR SHR^7(x)
                ulong s0 = BitOperations.RotateRight(w15, 1) ^ BitOperations.RotateRight(w15, 8) ^ (w15 >> 7);

                // σ1(x) = ROTR^19(x) XOR ROTR^61(x) XOR SHR^6(x)
                ulong s1 = BitOperations.RotateRight(w2, 19) ^ BitOperations.RotateRight(w2, 61) ^ (w2 >> 6);

                w[i] = w[i - 16] + s0 + w[i - 7] + s1;
            }

            // Initialize working variables
            ulong a = state[0];
            ulong b = state[1];
            ulong c = state[2];
            ulong d = state[3];
            ulong e = state[4];
            ulong f = state[5];
            ulong g = state[6];
            ulong h = state[7];

#if NET8_0_OR_GREATER
            // Unrolled compression rounds for better instruction-level parallelism
            for (int i = 0; i < 80; i += 8)
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
#else
            // Standard compression loop
            for (int i = 0; i < 80; i++)
            {
                ulong S1 = BitOperations.RotateRight(e, 14) ^ BitOperations.RotateRight(e, 18) ^ BitOperations.RotateRight(e, 41);
                ulong ch = (e & f) ^ (~e & g);
                ulong temp1 = h + S1 + ch + K[i] + w[i];
                ulong S0 = BitOperations.RotateRight(a, 28) ^ BitOperations.RotateRight(a, 34) ^ BitOperations.RotateRight(a, 39);
                ulong maj = (a & b) ^ (a & c) ^ (b & c);
                ulong temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
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

    /// <summary>
    /// Performs a single SHA-512 round with optimized rotation.
    /// </summary>
    /// <remarks>
    /// BitOperations.RotateRight compiles to RORX on CPUs with BMI2 support,
    /// which is a single-cycle non-destructive rotate instruction.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Round(ref ulong a, ref ulong b, ref ulong c, ref ulong d,
                              ref ulong e, ref ulong f, ref ulong g, ref ulong h,
                              ulong k, ulong w)
    {
        unchecked
        {
            // Σ1(e) = ROTR^14(e) XOR ROTR^18(e) XOR ROTR^41(e)
            ulong S1 = BitOperations.RotateRight(e, 14) ^
                       BitOperations.RotateRight(e, 18) ^
                       BitOperations.RotateRight(e, 41);

            // Ch(e,f,g) = (e AND f) XOR (NOT e AND g)
            ulong ch = (e & f) ^ (~e & g);

            ulong temp1 = h + S1 + ch + k + w;

            // Σ0(a) = ROTR^28(a) XOR ROTR^34(a) XOR ROTR^39(a)
            ulong S0 = BitOperations.RotateRight(a, 28) ^
                       BitOperations.RotateRight(a, 34) ^
                       BitOperations.RotateRight(a, 39);

            // Maj(a,b,c) = (a AND b) XOR (a AND c) XOR (b AND c)
            ulong maj = (a & b) ^ (a & c) ^ (b & c);

            ulong temp2 = S0 + maj;

            d += temp1;
            h = temp1 + temp2;
        }
    }

    /// <summary>
    /// Pads the buffer and finalizes the hash computation.
    /// </summary>
    /// <param name="buffer">The buffer containing remaining unprocessed bytes.</param>
    /// <param name="bufferLength">The number of valid bytes in the buffer.</param>
    /// <param name="bytesProcessed">Total bytes processed before this finalization.</param>
    /// <param name="state">The state array to update.</param>
    public static void PadAndFinalize(byte[] buffer, int bufferLength, long bytesProcessed, ulong[] state)
    {
        unchecked
        {
            long totalBits = (bytesProcessed + bufferLength) * 8;

            buffer[bufferLength++] = 0x80;

            // Pad to 112 bytes (896 bits) mod 128
            if (bufferLength > 112)
            {
                while (bufferLength < BlockSizeBytes)
                {
                    buffer[bufferLength++] = 0x00;
                }
                ProcessBlock(buffer, state);
                bufferLength = 0;
            }

            while (bufferLength < 112)
            {
                buffer[bufferLength++] = 0x00;
            }

            // Append length in bits (big-endian, 128-bit)
            // High 64 bits are zero for our implementation
            BinaryPrimitives.WriteInt64BigEndian(buffer.AsSpan(112), 0L);
            BinaryPrimitives.WriteInt64BigEndian(buffer.AsSpan(120), totalBits);

            ProcessBlock(buffer, state);
        }
    }
}
