// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Polynomial operations over ℤ_q[X]/(X²⁵⁶ + 1) for ML-KEM.
/// </summary>
/// <remarks>
/// Provides operations on polynomials with 256 coefficients modulo q = 3329,
/// including NTT-domain arithmetic, encoding, and sampling from FIPS 203.
/// </remarks>
internal static class Poly
{
    /// <summary>
    /// Adds two polynomials coefficient-wise: r[i] = a[i] + b[i].
    /// </summary>
    /// <param name="r">The output polynomial.</param>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Add(short[] r, short[] a, short[] b)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            r[i] = (short)(a[i] + b[i]);
        }
    }

    /// <summary>
    /// Subtracts two polynomials coefficient-wise: r[i] = a[i] − b[i].
    /// </summary>
    /// <param name="r">The output polynomial.</param>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Sub(short[] r, short[] a, short[] b)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            r[i] = (short)(a[i] - b[i]);
        }
    }

    /// <summary>
    /// Reduces all coefficients of a polynomial modulo q using Barrett reduction.
    /// </summary>
    /// <param name="r">The polynomial to reduce in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Reduce(short[] r)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            r[i] = Ntt.BarrettReduce(r[i]);
        }
    }

    /// <summary>
    /// Normalizes all coefficients to canonical form [0, q) using conditional subtraction.
    /// </summary>
    /// <param name="r">The polynomial to normalize in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Normalize(short[] r)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            r[i] = Ntt.ConditionalSubQ(r[i]);
        }
    }

    /// <summary>
    /// Converts all coefficients to Montgomery form: r[i] = r[i] · R mod q.
    /// </summary>
    /// <param name="r">The polynomial to convert in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ToMontgomery(short[] r)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            r[i] = Ntt.ToMontgomery(r[i]);
        }
    }

    /// <summary>
    /// Pointwise multiplication of two polynomials in NTT domain with accumulation.
    /// </summary>
    /// <remarks>
    /// Computes r += NTT⁻¹(a ◦ b) in the NTT domain using base-case multiplications.
    /// The polynomials must already be in NTT domain.
    /// </remarks>
    /// <param name="r">The accumulator polynomial (NTT domain).</param>
    /// <param name="a">First operand (NTT domain).</param>
    /// <param name="b">Second operand (NTT domain).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void PointwiseMultiplyAccumulate(short[] r, short[] a, short[] b)
    {
        for (int i = 0; i < MlKemParams.N / 4; i++)
        {
            int offset = 4 * i;
            Ntt.BaseCaseMultiply(r, offset, a, offset, b, offset, Ntt.GetZeta(64 + i));
            Ntt.BaseCaseMultiply(r, offset + 2, a, offset + 2, b, offset + 2, (short)-Ntt.GetZeta(64 + i));
        }
    }

    /// <summary>
    /// Converts a polynomial from bytes (12-bit encoding).
    /// </summary>
    /// <param name="input">The 384-byte input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    public static void FromBytes(ReadOnlySpan<byte> input, short[] coeffs)
    {
        Encode.ByteDecode12(input, coeffs);
    }

    /// <summary>
    /// Converts a polynomial to bytes (12-bit encoding).
    /// </summary>
    /// <param name="coeffs">The 256-element polynomial.</param>
    /// <param name="output">The 384-byte output buffer.</param>
    public static void ToBytes(short[] coeffs, Span<byte> output)
    {
        Encode.ByteEncode12(coeffs, output);
    }

    /// <summary>
    /// Converts a 32-byte message to a polynomial.
    /// </summary>
    /// <remarks>
    /// Each bit of the message is mapped to q/2 (1665) or 0,
    /// representing the Decompress₁ operation.
    /// </remarks>
    /// <param name="msg">The 32-byte message.</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    public static void FromMessage(ReadOnlySpan<byte> msg, short[] coeffs)
    {
        Encode.ByteDecode1(msg, coeffs);
        Compress.DecompressPoly(coeffs, 1);
    }

    /// <summary>
    /// Converts a polynomial to a 32-byte message.
    /// </summary>
    /// <remarks>
    /// Each coefficient is compressed to 1 bit via Compress₁,
    /// then packed into bytes.
    /// </remarks>
    /// <param name="coeffs">The 256-element polynomial (will be modified).</param>
    /// <param name="msg">The 32-byte output message buffer.</param>
    public static void ToMessage(short[] coeffs, Span<byte> msg)
    {
        var temp = new short[MlKemParams.N];
        Array.Copy(coeffs, temp, MlKemParams.N);
        Compress.CompressPoly(temp, 1);
        Encode.ByteEncode1(temp, msg);
    }

    /// <summary>
    /// Samples a polynomial from a seed using SHAKE128 (XOF) rejection sampling.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 6 (SampleNTT). Produces a polynomial in NTT domain
    /// with coefficients uniformly distributed in [0, q).
    /// </remarks>
    /// <param name="seed">The 34-byte seed (ρ ‖ i ‖ j).</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void SampleNtt(ReadOnlySpan<byte> seed, short[] coeffs)
    {
        using var xof = Hash.Shake128.Create(504);
        xof.Absorb(seed);

        int count = 0;
        Span<byte> buf = stackalloc byte[504];

        while (count < MlKemParams.N)
        {
            xof.Squeeze(buf);
            for (int i = 0; i + 2 < buf.Length && count < MlKemParams.N; i += 3)
            {
                ushort d1 = (ushort)(((ushort)buf[i] | ((ushort)buf[i + 1] << 8)) & 0x0FFF);
                ushort d2 = (ushort)((((ushort)buf[i + 1] >> 4) | ((ushort)buf[i + 2] << 4)) & 0x0FFF);

                if (d1 < MlKemParams.Q)
                    coeffs[count++] = (short)d1;
                if (count < MlKemParams.N && d2 < MlKemParams.Q)
                    coeffs[count++] = (short)d2;
            }
        }
    }
}
