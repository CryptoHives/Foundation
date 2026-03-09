// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Core Kuznyechik (GOST R 34.12-2015) block cipher operations.
/// </summary>
/// <remarks>
/// <para>
/// This class implements the Kuznyechik block cipher as specified in
/// GOST R 34.12-2015 and RFC 7801. It provides the core operations
/// for encryption, decryption, and key expansion.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>128-bit block size, 256-bit key size, 10 rounds.</description></item>
///   <item><description>SPN (Substitution-Permutation Network) structure.</description></item>
///   <item><description>GF(2^8) arithmetic with irreducible polynomial p(x) = x^8 + x^7 + x^6 + x + 1 (0x1C3).</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class KuznyechikCore
{
    /// <summary>
    /// Block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// Block size in bits.
    /// </summary>
    public const int BlockSizeBits = 128;

    /// <summary>
    /// Key size in bytes.
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// Number of encryption rounds.
    /// </summary>
    public const int Rounds = 10;

    /// <summary>
    /// Total size of all round keys in bytes (10 × 16 = 160).
    /// </summary>
    public const int RoundKeysTotalBytes = Rounds * BlockSizeBytes;

    private const int IterationConstantCount = 32;

    /// <summary>
    /// π (Pi) nonlinear bijection S-box from GOST R 34.12-2015 / RFC 7801.
    /// </summary>
    private static readonly byte[] Pi =
    [
        0xFC, 0xEE, 0xDD, 0x11, 0xCF, 0x6E, 0x31, 0x16, 0xFB, 0xC4, 0xFA, 0xDA, 0x23, 0xC5, 0x04, 0x4D,
        0xE9, 0x77, 0xF0, 0xDB, 0x93, 0x2E, 0x99, 0xBA, 0x17, 0x36, 0xF1, 0xBB, 0x14, 0xCD, 0x5F, 0xC1,
        0xF9, 0x18, 0x65, 0x5A, 0xE2, 0x5C, 0xEF, 0x21, 0x81, 0x1C, 0x3C, 0x42, 0x8B, 0x01, 0x8E, 0x4F,
        0x05, 0x84, 0x02, 0xAE, 0xE3, 0x6A, 0x8F, 0xA0, 0x06, 0x0B, 0xED, 0x98, 0x7F, 0xD4, 0xD3, 0x1F,
        0xEB, 0x34, 0x2C, 0x51, 0xEA, 0xC8, 0x48, 0xAB, 0xF2, 0x2A, 0x68, 0xA2, 0xFD, 0x3A, 0xCE, 0xCC,
        0xB5, 0x70, 0x0E, 0x56, 0x08, 0x0C, 0x76, 0x12, 0xBF, 0x72, 0x13, 0x47, 0x9C, 0xB7, 0x5D, 0x87,
        0x15, 0xA1, 0x96, 0x29, 0x10, 0x7B, 0x9A, 0xC7, 0xF3, 0x91, 0x78, 0x6F, 0x9D, 0x9E, 0xB2, 0xB1,
        0x32, 0x75, 0x19, 0x3D, 0xFF, 0x35, 0x8A, 0x7E, 0x6D, 0x54, 0xC6, 0x80, 0xC3, 0xBD, 0x0D, 0x57,
        0xDF, 0xF5, 0x24, 0xA9, 0x3E, 0xA8, 0x43, 0xC9, 0xD7, 0x79, 0xD6, 0xF6, 0x7C, 0x22, 0xB9, 0x03,
        0xE0, 0x0F, 0xEC, 0xDE, 0x7A, 0x94, 0xB0, 0xBC, 0xDC, 0xE8, 0x28, 0x50, 0x4E, 0x33, 0x0A, 0x4A,
        0xA7, 0x97, 0x60, 0x73, 0x1E, 0x00, 0x62, 0x44, 0x1A, 0xB8, 0x38, 0x82, 0x64, 0x9F, 0x26, 0x41,
        0xAD, 0x45, 0x46, 0x92, 0x27, 0x5E, 0x55, 0x2F, 0x8C, 0xA3, 0xA5, 0x7D, 0x69, 0xD5, 0x95, 0x3B,
        0x07, 0x58, 0xB3, 0x40, 0x86, 0xAC, 0x1D, 0xF7, 0x30, 0x37, 0x6B, 0xE4, 0x88, 0xD9, 0xE7, 0x89,
        0xE1, 0x1B, 0x83, 0x49, 0x4C, 0x3F, 0xF8, 0xFE, 0x8D, 0x53, 0xAA, 0x90, 0xCA, 0xD8, 0x85, 0x61,
        0x20, 0x71, 0x67, 0xA4, 0x2D, 0x2B, 0x09, 0x5B, 0xCB, 0x9B, 0x25, 0xD0, 0xBE, 0xE5, 0x6C, 0x52,
        0x59, 0xA6, 0x74, 0xD2, 0xE6, 0xF4, 0xB4, 0xC0, 0xD1, 0x66, 0xAF, 0xC2, 0x39, 0x4B, 0x63, 0xB6,
    ];

    /// <summary>
    /// π^(-1) (Pi inverse) S-box from GOST R 34.12-2015 / RFC 7801.
    /// </summary>
    private static readonly byte[] PiInverse =
    [
        0xA5, 0x2D, 0x32, 0x8F, 0x0E, 0x30, 0x38, 0xC0, 0x54, 0xE6, 0x9E, 0x39, 0x55, 0x7E, 0x52, 0x91,
        0x64, 0x03, 0x57, 0x5A, 0x1C, 0x60, 0x07, 0x18, 0x21, 0x72, 0xA8, 0xD1, 0x29, 0xC6, 0xA4, 0x3F,
        0xE0, 0x27, 0x8D, 0x0C, 0x82, 0xEA, 0xAE, 0xB4, 0x9A, 0x63, 0x49, 0xE5, 0x42, 0xE4, 0x15, 0xB7,
        0xC8, 0x06, 0x70, 0x9D, 0x41, 0x75, 0x19, 0xC9, 0xAA, 0xFC, 0x4D, 0xBF, 0x2A, 0x73, 0x84, 0xD5,
        0xC3, 0xAF, 0x2B, 0x86, 0xA7, 0xB1, 0xB2, 0x5B, 0x46, 0xD3, 0x9F, 0xFD, 0xD4, 0x0F, 0x9C, 0x2F,
        0x9B, 0x43, 0xEF, 0xD9, 0x79, 0xB6, 0x53, 0x7F, 0xC1, 0xF0, 0x23, 0xE7, 0x25, 0x5E, 0xB5, 0x1E,
        0xA2, 0xDF, 0xA6, 0xFE, 0xAC, 0x22, 0xF9, 0xE2, 0x4A, 0xBC, 0x35, 0xCA, 0xEE, 0x78, 0x05, 0x6B,
        0x51, 0xE1, 0x59, 0xA3, 0xF2, 0x71, 0x56, 0x11, 0x6A, 0x89, 0x94, 0x65, 0x8C, 0xBB, 0x77, 0x3C,
        0x7B, 0x28, 0xAB, 0xD2, 0x31, 0xDE, 0xC4, 0x5F, 0xCC, 0xCF, 0x76, 0x2C, 0xB8, 0xD8, 0x2E, 0x36,
        0xDB, 0x69, 0xB3, 0x14, 0x95, 0xBE, 0x62, 0xA1, 0x3B, 0x16, 0x66, 0xE9, 0x5C, 0x6C, 0x6D, 0xAD,
        0x37, 0x61, 0x4B, 0xB9, 0xE3, 0xBA, 0xF1, 0xA0, 0x85, 0x83, 0xDA, 0x47, 0xC5, 0xB0, 0x33, 0xFA,
        0x96, 0x6F, 0x6E, 0xC2, 0xF6, 0x50, 0xFF, 0x5D, 0xA9, 0x8E, 0x17, 0x1B, 0x97, 0x7D, 0xEC, 0x58,
        0xF7, 0x1F, 0xFB, 0x7C, 0x09, 0x0D, 0x7A, 0x67, 0x45, 0x87, 0xDC, 0xE8, 0x4F, 0x1D, 0x4E, 0x04,
        0xEB, 0xF8, 0xF3, 0x3E, 0x3D, 0xBD, 0x8A, 0x88, 0xDD, 0xCD, 0x0B, 0x13, 0x98, 0x02, 0x93, 0x80,
        0x90, 0xD0, 0x24, 0x34, 0xCB, 0xED, 0xF4, 0xCE, 0x99, 0x10, 0x44, 0x40, 0x92, 0x3A, 0x01, 0x26,
        0x12, 0x1A, 0x48, 0x68, 0xF5, 0x81, 0x8B, 0xC7, 0xD6, 0x20, 0x0A, 0x08, 0x00, 0x4C, 0xD7, 0x74,
    ];

    /// <summary>
    /// Coefficients for the linear feedback function l(a_15,...,a_0).
    /// Indexed by byte position: Coefficients[0] corresponds to a_15 (byte[0]).
    /// </summary>
    private static readonly byte[] Coefficients =
    [
        148, 32, 133, 16, 194, 192, 1, 251, 1, 192, 194, 16, 133, 32, 148, 1,
    ];

    /// <summary>
    /// Pre-computed iteration constants C_1 through C_32 for key schedule.
    /// </summary>
    private static readonly byte[] IterationConstants = ComputeIterationConstants();

    /// <summary>
    /// Multiplies two elements in GF(2^8) with irreducible polynomial
    /// p(x) = x^8 + x^7 + x^6 + x + 1 (0x1C3).
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>The product a × b in GF(2^8).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte GFMul(byte a, byte b)
    {
        uint result = 0;
        uint temp = a;
        uint multiplier = b;

        while (multiplier != 0)
        {
            if ((multiplier & 1) != 0)
                result ^= temp;

            temp <<= 1;
            if ((temp & 0x100) != 0)
                temp ^= 0x1C3;

            multiplier >>= 1;
        }

        return (byte)result;
    }

    /// <summary>
    /// Computes the linear feedback value l(block[0],...,block[15]) using GF(2^8) arithmetic.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte LinearFeedback(ReadOnlySpan<byte> block)
    {
        byte result = 0;
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            result ^= GFMul(Coefficients[i], block[i]);
        }

        return result;
    }

    /// <summary>
    /// R-transform: shifts bytes right and prepends linear feedback value.
    /// R(a_15||...||a_0) = l(a_15,...,a_0)||a_15||...||a_1.
    /// </summary>
    private static void R(Span<byte> block)
    {
        byte val = LinearFeedback(block);
        for (int i = BlockSizeBytes - 1; i > 0; i--)
            block[i] = block[i - 1];
        block[0] = val;
    }

    /// <summary>
    /// R^(-1) inverse transform: shifts bytes left and appends computed value.
    /// </summary>
    private static void RInverse(Span<byte> block)
    {
        byte saved = block[0];
        for (int i = 0; i < BlockSizeBytes - 1; i++)
            block[i] = block[i + 1];
        block[BlockSizeBytes - 1] = saved;
        block[BlockSizeBytes - 1] = LinearFeedback(block);
    }

    /// <summary>
    /// L-transform: 16 iterations of R-transform.
    /// L(a) = R^16(a).
    /// </summary>
    private static void L(Span<byte> block)
    {
        for (int i = 0; i < BlockSizeBytes; i++)
            R(block);
    }

    /// <summary>
    /// L^(-1) inverse transform: 16 iterations of R^(-1).
    /// </summary>
    private static void LInverse(Span<byte> block)
    {
        for (int i = 0; i < BlockSizeBytes; i++)
            RInverse(block);
    }

    /// <summary>
    /// S-transform: applies the π S-box to each byte.
    /// </summary>
    private static void S(Span<byte> block)
    {
        for (int i = 0; i < BlockSizeBytes; i++)
            block[i] = Pi[block[i]];
    }

    /// <summary>
    /// S^(-1) inverse transform: applies the π^(-1) inverse S-box to each byte.
    /// </summary>
    private static void SInverse(Span<byte> block)
    {
        for (int i = 0; i < BlockSizeBytes; i++)
            block[i] = PiInverse[block[i]];
    }

    /// <summary>
    /// Expands a 256-bit key into 10 round keys (160 bytes total).
    /// </summary>
    /// <param name="key">The 32-byte cipher key.</param>
    /// <param name="roundKeys">Output buffer for 160 bytes of round keys.</param>
    public static void ExpandKey(ReadOnlySpan<byte> key, Span<byte> roundKeys)
    {
        key.Slice(0, BlockSizeBytes).CopyTo(roundKeys);
        key.Slice(BlockSizeBytes, BlockSizeBytes).CopyTo(roundKeys.Slice(BlockSizeBytes));

        Span<byte> k1 = stackalloc byte[BlockSizeBytes];
        Span<byte> k2 = stackalloc byte[BlockSizeBytes];
        Span<byte> temp = stackalloc byte[BlockSizeBytes];

        key.Slice(0, BlockSizeBytes).CopyTo(k1);
        key.Slice(BlockSizeBytes, BlockSizeBytes).CopyTo(k2);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int cIndex = (8 * i + j) * BlockSizeBytes;
                var c = IterationConstants.AsSpan(cIndex, BlockSizeBytes);

                // F[c](k1, k2) = (L(S(k1 ⊕ c)) ⊕ k2, k1)
                for (int b = 0; b < BlockSizeBytes; b++)
                    temp[b] = (byte)(k1[b] ^ c[b]);

                S(temp);
                L(temp);

                for (int b = 0; b < BlockSizeBytes; b++)
                    temp[b] ^= k2[b];

                k1.CopyTo(k2);
                temp.CopyTo(k1);
            }

            k1.CopyTo(roundKeys.Slice((2 * i + 2) * BlockSizeBytes, BlockSizeBytes));
            k2.CopyTo(roundKeys.Slice((2 * i + 3) * BlockSizeBytes, BlockSizeBytes));
        }
    }

    /// <summary>
    /// Encrypts a single 16-byte block using Kuznyechik.
    /// </summary>
    /// <remarks>
    /// Implements E(a) = X[K_10] ∘ L ∘ S ∘ X[K_9] ∘ ... ∘ L ∘ S ∘ X[K_1](a).
    /// </remarks>
    /// <param name="input">The 16-byte plaintext block.</param>
    /// <param name="output">The 16-byte ciphertext output.</param>
    /// <param name="roundKeys">The 160 bytes of expanded round keys.</param>
    public static void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<byte> roundKeys)
    {
        input.Slice(0, BlockSizeBytes).CopyTo(output);

        for (int i = 0; i < Rounds - 1; i++)
        {
            var rk = roundKeys.Slice(i * BlockSizeBytes, BlockSizeBytes);
            for (int j = 0; j < BlockSizeBytes; j++)
                output[j] ^= rk[j];

            S(output);
            L(output);
        }

        var lastRk = roundKeys.Slice((Rounds - 1) * BlockSizeBytes, BlockSizeBytes);
        for (int j = 0; j < BlockSizeBytes; j++)
            output[j] ^= lastRk[j];
    }

    /// <summary>
    /// Decrypts a single 16-byte block using Kuznyechik.
    /// </summary>
    /// <remarks>
    /// Reverses the encryption by applying inverse transforms in reverse order.
    /// </remarks>
    /// <param name="input">The 16-byte ciphertext block.</param>
    /// <param name="output">The 16-byte plaintext output.</param>
    /// <param name="roundKeys">The 160 bytes of expanded round keys.</param>
    public static void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output, ReadOnlySpan<byte> roundKeys)
    {
        input.Slice(0, BlockSizeBytes).CopyTo(output);

        for (int i = Rounds - 1; i >= 1; i--)
        {
            var rk = roundKeys.Slice(i * BlockSizeBytes, BlockSizeBytes);
            for (int j = 0; j < BlockSizeBytes; j++)
                output[j] ^= rk[j];

            LInverse(output);
            SInverse(output);
        }

        var firstRk = roundKeys.Slice(0, BlockSizeBytes);
        for (int j = 0; j < BlockSizeBytes; j++)
            output[j] ^= firstRk[j];
    }

    /// <summary>
    /// Pre-computes the 32 iteration constants C_1 through C_32.
    /// C_i = L(Vec_128(i)).
    /// </summary>
    private static byte[] ComputeIterationConstants()
    {
        byte[] result = new byte[IterationConstantCount * BlockSizeBytes];
        byte[] block = new byte[BlockSizeBytes];

        for (int i = 1; i <= IterationConstantCount; i++)
        {
            Array.Clear(block, 0, BlockSizeBytes);
            block[BlockSizeBytes - 1] = (byte)i;
            L(block);
            Array.Copy(block, 0, result, (i - 1) * BlockSizeBytes, BlockSizeBytes);
        }

        return result;
    }
}
