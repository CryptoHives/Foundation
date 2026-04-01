// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Operations on vectors of ML-KEM polynomials.
/// </summary>
/// <remarks>
/// A polynomial vector contains k polynomials (where k = 2, 3, or 4 depending on the
/// parameter set). This class provides NTT, encoding, compression, and matrix-vector
/// multiplication operations used in K-PKE.
/// </remarks>
internal static class PolyVec
{
    /// <summary>
    /// Applies the forward NTT to each polynomial in the vector.
    /// </summary>
    /// <param name="vec">The polynomial vector (k arrays of 256 coefficients).</param>
    public static void Ntt(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Kem.Ntt.Forward(vec[i]);
        }
    }

    /// <summary>
    /// Applies the inverse NTT to each polynomial in the vector.
    /// </summary>
    /// <param name="vec">The polynomial vector (k arrays of 256 coefficients).</param>
    public static void InverseNtt(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Kem.Ntt.Inverse(vec[i]);
        }
    }

    /// <summary>
    /// Reduces all coefficients in each polynomial of the vector via Barrett reduction.
    /// </summary>
    /// <param name="vec">The polynomial vector.</param>
    public static void Reduce(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.Reduce(vec[i]);
        }
    }

    /// <summary>
    /// Normalizes all coefficients in each polynomial of the vector to [0, q).
    /// </summary>
    /// <param name="vec">The polynomial vector.</param>
    public static void Normalize(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.Normalize(vec[i]);
        }
    }

    /// <summary>
    /// Converts all coefficients to Montgomery form: vec[i] = vec[i] · R mod q.
    /// </summary>
    /// <param name="vec">The polynomial vector.</param>
    public static void ToMontgomery(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.ToMontgomery(vec[i]);
        }
    }

    /// <summary>
    /// Computes the inner product of two polynomial vectors in NTT domain.
    /// </summary>
    /// <remarks>
    /// Computes r = Σ(a[i] ◦ b[i]) in the NTT domain using pointwise multiplication.
    /// Both vectors must be in NTT domain.
    /// </remarks>
    /// <param name="r">The output polynomial (NTT domain). Must be zeroed before call.</param>
    /// <param name="a">First vector (NTT domain).</param>
    /// <param name="b">Second vector (NTT domain).</param>
    public static void InnerProduct(short[] r, short[][] a, short[][] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Poly.PointwiseMultiplyAccumulate(r, a[i], b[i]);
        }
    }

    /// <summary>
    /// Computes a matrix-vector product in NTT domain: r[i] = Σ_j(mat[i][j] ◦ vec[j]).
    /// </summary>
    /// <remarks>
    /// The matrix is k × k polynomials, stored as mat[i][j]. Both matrix and vector
    /// must be in NTT domain.
    /// </remarks>
    /// <param name="r">The output vector (k polynomials). Must be zeroed before call.</param>
    /// <param name="mat">The k × k matrix of polynomials (NTT domain).</param>
    /// <param name="vec">The k-element input vector (NTT domain).</param>
    /// <param name="transpose">If true, uses mat[j][i] instead of mat[i][j] (transpose multiply).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void MatrixVectorMultiply(short[][] r, short[][][] mat, short[][] vec, bool transpose)
    {
        int k = vec.Length;
        for (int i = 0; i < k; i++)
        {
            Array.Clear(r[i], 0, MlKemParams.N);
            for (int j = 0; j < k; j++)
            {
                short[] matEntry = transpose ? mat[j][i] : mat[i][j];
                Poly.PointwiseMultiplyAccumulate(r[i], matEntry, vec[j]);
            }

            Poly.Reduce(r[i]);
        }
    }

    /// <summary>
    /// Adds two polynomial vectors coefficient-wise: r[i] = a[i] + b[i].
    /// </summary>
    /// <param name="r">The output vector.</param>
    /// <param name="a">First operand vector.</param>
    /// <param name="b">Second operand vector.</param>
    public static void Add(short[][] r, short[][] a, short[][] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Poly.Add(r[i], a[i], b[i]);
        }
    }

    /// <summary>
    /// Encodes a polynomial vector to bytes (12-bit per coefficient).
    /// </summary>
    /// <param name="vec">The polynomial vector (must be normalized to [0, q)).</param>
    /// <param name="output">The output buffer (384·k bytes).</param>
    public static void ToBytes(short[][] vec, Span<byte> output)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.ToBytes(vec[i], output.Slice(i * 384));
        }
    }

    /// <summary>
    /// Decodes a polynomial vector from bytes (12-bit per coefficient).
    /// </summary>
    /// <param name="input">The input buffer (384·k bytes).</param>
    /// <param name="vec">The output polynomial vector.</param>
    public static void FromBytes(ReadOnlySpan<byte> input, short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.FromBytes(input.Slice(i * 384), vec[i]);
        }
    }

    /// <summary>
    /// Compresses and encodes a polynomial vector.
    /// </summary>
    /// <param name="vec">The polynomial vector (modified in-place by compression).</param>
    /// <param name="d">The compression bit width.</param>
    /// <param name="output">The output buffer (32·d·k bytes).</param>
    public static void CompressAndEncode(short[][] vec, int d, Span<byte> output)
    {
        int polySize = 32 * d;
        for (int i = 0; i < vec.Length; i++)
        {
            Compress.CompressPoly(vec[i], d);
            Encode.ByteEncodeD(vec[i], d, output.Slice(i * polySize));
        }
    }

    /// <summary>
    /// Decodes and decompresses a polynomial vector.
    /// </summary>
    /// <param name="input">The input buffer (32·d·k bytes).</param>
    /// <param name="d">The compression bit width.</param>
    /// <param name="vec">The output polynomial vector.</param>
    public static void DecodeAndDecompress(ReadOnlySpan<byte> input, int d, short[][] vec)
    {
        int polySize = 32 * d;
        for (int i = 0; i < vec.Length; i++)
        {
            Encode.ByteDecodeD(input.Slice(i * polySize), d, vec[i]);
            Compress.DecompressPoly(vec[i], d);
        }
    }

    /// <summary>
    /// Allocates a new polynomial vector with k polynomials.
    /// </summary>
    /// <param name="k">The number of polynomials.</param>
    /// <returns>A new polynomial vector.</returns>
    public static short[][] Create(int k)
    {
        var vec = new short[k][];
        for (int i = 0; i < k; i++)
        {
            vec[i] = new short[MlKemParams.N];
        }

        return vec;
    }
}
