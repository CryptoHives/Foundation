// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Byte encoding and decoding of ML-KEM polynomials.
/// </summary>
/// <remarks>
/// Implements FIPS 203 §4.2.1 ByteEncode and ByteDecode functions for
/// packing/unpacking polynomial coefficients into byte arrays with a given bit width d.
/// </remarks>
internal static class Encode
{
    /// <summary>
    /// Encodes a polynomial with 12-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode₁₂. Packs 256 coefficients of 12 bits each into 384 bytes.
    /// Used for encoding the public key polynomial vector in NTT domain.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients (each in [0, q)).</param>
    /// <param name="output">The 384-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode12(short[] coeffs, Span<byte> output)
    {
        for (int i = 0; i < MlKemParams.N / 2; i++)
        {
            ushort a = (ushort)coeffs[2 * i];
            ushort b = (ushort)coeffs[2 * i + 1];
            output[3 * i] = (byte)a;
            output[3 * i + 1] = (byte)((a >> 8) | (b << 4));
            output[3 * i + 2] = (byte)(b >> 4);
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with 12-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode₁₂. Unpacks 384 bytes into 256 coefficients of 12 bits each.
    /// Output coefficients are reduced modulo q = 3329.
    /// </remarks>
    /// <param name="input">The 384-byte input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode12(ReadOnlySpan<byte> input, short[] coeffs)
    {
        for (int i = 0; i < MlKemParams.N / 2; i++)
        {
            int b0 = input[3 * i];
            int b1 = input[3 * i + 1];
            int b2 = input[3 * i + 2];
            coeffs[2 * i] = (short)((b0 | (b1 << 8)) & 0xFFF);
            coeffs[2 * i + 1] = (short)(((b1 >> 4) | (b2 << 4)) & 0xFFF);
        }
    }

    /// <summary>
    /// Encodes a polynomial with 1-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode₁. Packs 256 single-bit coefficients into 32 bytes.
    /// Used for encoding the message polynomial in K-PKE.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients (each 0 or 1).</param>
    /// <param name="output">The 32-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode1(short[] coeffs, Span<byte> output)
    {
        for (int i = 0; i < MlKemParams.N / 8; i++)
        {
            byte val = 0;
            for (int j = 0; j < 8; j++)
            {
                val |= (byte)((coeffs[8 * i + j] & 1) << j);
            }

            output[i] = val;
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with 1-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode₁. Unpacks 32 bytes into 256 single-bit coefficients.
    /// </remarks>
    /// <param name="input">The 32-byte input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode1(ReadOnlySpan<byte> input, short[] coeffs)
    {
        for (int i = 0; i < MlKemParams.N / 8; i++)
        {
            byte val = input[i];
            for (int j = 0; j < 8; j++)
            {
                coeffs[8 * i + j] = (short)((val >> j) & 1);
            }
        }
    }

    /// <summary>
    /// Encodes a polynomial with d-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode_d for arbitrary d ∈ {1, ..., 12}.
    /// Packs 256 coefficients with d bits each into 32·d bytes.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients.</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="output">The output buffer (32·d bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncodeD(short[] coeffs, int d, Span<byte> output)
    {
        if (d == 12)
        {
            ByteEncode12(coeffs, output);
            return;
        }

        if (d == 1)
        {
            ByteEncode1(coeffs, output);
            return;
        }

        int bitPos = 0;
        output.Clear();
        for (int i = 0; i < MlKemParams.N; i++)
        {
            uint val = (uint)(ushort)coeffs[i];
            for (int b = 0; b < d; b++)
            {
                int byteIdx = bitPos >> 3;
                int bitIdx = bitPos & 7;
                output[byteIdx] |= (byte)(((val >> b) & 1) << bitIdx);
                bitPos++;
            }
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with d-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode_d for arbitrary d ∈ {1, ..., 12}.
    /// Unpacks 32·d bytes into 256 coefficients with d bits each.
    /// </remarks>
    /// <param name="input">The input buffer (32·d bytes).</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecodeD(ReadOnlySpan<byte> input, int d, short[] coeffs)
    {
        if (d == 12)
        {
            ByteDecode12(input, coeffs);
            return;
        }

        if (d == 1)
        {
            ByteDecode1(input, coeffs);
            return;
        }

        int mask = (1 << d) - 1;
        int bitPos = 0;
        for (int i = 0; i < MlKemParams.N; i++)
        {
            uint val = 0;
            for (int b = 0; b < d; b++)
            {
                int byteIdx = bitPos >> 3;
                int bitIdx = bitPos & 7;
                val |= (uint)(((input[byteIdx] >> bitIdx) & 1) << b);
                bitPos++;
            }

            coeffs[i] = (short)(val & mask);
        }
    }
}
