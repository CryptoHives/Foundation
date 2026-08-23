// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Operations on vectors of ML-KEM polynomials.
/// </summary>
/// <remarks>
/// <para>
/// A polynomial vector is k polynomials of <see cref="MLKemParams.N"/> coefficients, held in
/// one flat <see cref="Span{T}"/> of k·N, sliced per polynomial by
/// <see cref="Poly(Span{short}, int)"/>.
/// A k × k matrix is the same idea at k² · N, indexed row-major.
/// </para>
/// <para>
/// Flat rather than jagged (<c>short[][]</c>) so the caller owns a single allocation it can
/// pool, stack-allocate or reuse, instead of this layer minting k or k² arrays per call. It
/// also means the vector helpers below impose no allocation of their own.
/// </para>
/// </remarks>
internal static class PolyVec
{
    /// <summary>
    /// Returns the number of <see cref="short"/> values backing a k-element vector.
    /// </summary>
    /// <param name="k">The module rank.</param>
    /// <returns>k · N.</returns>
    public static int VectorLength(int k) => k * MLKemParams.N;

    /// <summary>
    /// Returns the number of <see cref="short"/> values backing a k × k matrix.
    /// </summary>
    /// <param name="k">The module rank.</param>
    /// <returns>k² · N.</returns>
    public static int MatrixLength(int k) => k * k * MLKemParams.N;

    /// <summary>
    /// Gets the polynomial at <paramref name="index"/> within a vector.
    /// </summary>
    /// <param name="vec">The flat vector.</param>
    /// <param name="index">The polynomial index.</param>
    /// <returns>The polynomial's N coefficients.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static Span<short> Poly(Span<short> vec, int index)
        => vec.Slice(index * MLKemParams.N, MLKemParams.N);

    /// <summary>
    /// Gets the polynomial at <paramref name="index"/> within a read-only vector.
    /// </summary>
    /// <remarks>
    /// Named apart from <see cref="Poly(Span{short}, int)"/> on purpose: <c>short[]</c>
    /// converts to both <c>Span</c> and <c>ReadOnlySpan</c>, so a single overloaded name
    /// would silently pick the read-only one at call sites that need to write.
    /// </remarks>
    /// <param name="vec">The flat vector.</param>
    /// <param name="index">The polynomial index.</param>
    /// <returns>The polynomial's N coefficients.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ReadOnlySpan<short> ReadPoly(ReadOnlySpan<short> vec, int index)
        => vec.Slice(index * MLKemParams.N, MLKemParams.N);

    /// <summary>
    /// Gets the matrix entry Â[row][col] from a row-major k × k matrix.
    /// </summary>
    /// <param name="mat">The flat matrix.</param>
    /// <param name="k">The module rank.</param>
    /// <param name="row">The row index.</param>
    /// <param name="col">The column index.</param>
    /// <returns>The entry's N coefficients.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ReadOnlySpan<short> Entry(ReadOnlySpan<short> mat, int k, int row, int col)
        => mat.Slice(((row * k) + col) * MLKemParams.N, MLKemParams.N);

    /// <summary>
    /// Applies the forward NTT to each polynomial in the vector.
    /// </summary>
    /// <param name="vec">The flat polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void Ntt(Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Ntt.Forward(Poly(vec, i));
        }
    }

    /// <summary>
    /// Applies the inverse NTT to each polynomial in the vector.
    /// </summary>
    /// <param name="vec">The flat polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void InverseNtt(Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Ntt.Inverse(Poly(vec, i));
        }
    }

    /// <summary>
    /// Reduces all coefficients in each polynomial of the vector via Barrett reduction.
    /// </summary>
    /// <param name="vec">The flat polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void Reduce(Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.Reduce(Poly(vec, i));
        }
    }

    /// <summary>
    /// Normalizes all coefficients in each polynomial of the vector to [0, q).
    /// </summary>
    /// <param name="vec">The flat polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void Normalize(Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.Normalize(Poly(vec, i));
        }
    }

    /// <summary>
    /// Converts all coefficients to Montgomery form: vec[i] = vec[i] · R mod q.
    /// </summary>
    /// <param name="vec">The flat polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void ToMontgomery(Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.ToMontgomery(Poly(vec, i));
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
    /// <param name="k">The module rank.</param>
    public static void InnerProduct(Span<short> r, ReadOnlySpan<short> a, ReadOnlySpan<short> b, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.PointwiseMultiplyAccumulate(r, ReadPoly(a, i), ReadPoly(b, i));
        }
    }

    /// <summary>
    /// Computes a matrix-vector product in NTT domain: r[i] = Σ_j(mat[i][j] ◦ vec[j]).
    /// </summary>
    /// <remarks>
    /// The matrix is k × k polynomials stored row-major. Both matrix and vector must be in
    /// NTT domain.
    /// </remarks>
    /// <param name="r">The output vector (k polynomials).</param>
    /// <param name="mat">The flat k × k matrix (NTT domain).</param>
    /// <param name="vec">The flat k-element input vector (NTT domain).</param>
    /// <param name="k">The module rank.</param>
    /// <param name="transpose">If true, uses mat[j][i] instead of mat[i][j] (transpose multiply).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void MatrixVectorMultiply(Span<short> r, ReadOnlySpan<short> mat, ReadOnlySpan<short> vec, int k, bool transpose)
    {
        for (int i = 0; i < k; i++)
        {
            Span<short> ri = Poly(r, i);
            ri.Clear();
            for (int j = 0; j < k; j++)
            {
                ReadOnlySpan<short> entry = transpose ? Entry(mat, k, j, i) : Entry(mat, k, i, j);
                Kem.Poly.PointwiseMultiplyAccumulate(ri, entry, ReadPoly(vec, j));
            }

            Kem.Poly.Reduce(ri);
        }
    }

    /// <summary>
    /// Adds two polynomial vectors coefficient-wise: r[i] = a[i] + b[i].
    /// </summary>
    /// <remarks>
    /// Operates on the flat buffers directly — the vector is contiguous, so the per-polynomial
    /// split adds nothing here.
    /// </remarks>
    /// <param name="r">The output vector.</param>
    /// <param name="a">First operand vector.</param>
    /// <param name="b">Second operand vector.</param>
    /// <param name="k">The module rank.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Add(Span<short> r, ReadOnlySpan<short> a, ReadOnlySpan<short> b, int k)
    {
        int length = VectorLength(k);
        for (int i = 0; i < length; i++)
        {
            r[i] = (short)(a[i] + b[i]);
        }
    }

    /// <summary>
    /// Encodes a polynomial vector to bytes (12-bit per coefficient).
    /// </summary>
    /// <param name="vec">The polynomial vector (must be normalized to [0, q)).</param>
    /// <param name="k">The module rank.</param>
    /// <param name="output">The output buffer (384·k bytes).</param>
    public static void ToBytes(ReadOnlySpan<short> vec, int k, Span<byte> output)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.ToBytes(ReadPoly(vec, i), output.Slice(i * 384, 384));
        }
    }

    /// <summary>
    /// Decodes a polynomial vector from bytes (12-bit per coefficient).
    /// </summary>
    /// <param name="input">The input buffer (384·k bytes).</param>
    /// <param name="vec">The output polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void FromBytes(ReadOnlySpan<byte> input, Span<short> vec, int k)
    {
        for (int i = 0; i < k; i++)
        {
            Kem.Poly.FromBytes(input.Slice(i * 384, 384), Poly(vec, i));
        }
    }

    /// <summary>
    /// Compresses and encodes a polynomial vector.
    /// </summary>
    /// <param name="vec">The polynomial vector (modified in-place by compression).</param>
    /// <param name="k">The module rank.</param>
    /// <param name="d">The compression bit width.</param>
    /// <param name="output">The output buffer (32·d·k bytes).</param>
    public static void CompressAndEncode(Span<short> vec, int k, int d, Span<byte> output)
    {
        int polySize = 32 * d;
        for (int i = 0; i < k; i++)
        {
            Span<short> poly = Poly(vec, i);
            Compress.CompressPoly(poly, d);
            Encode.ByteEncodeD(poly, d, output.Slice(i * polySize, polySize));
        }
    }

    /// <summary>
    /// Decodes and decompresses a polynomial vector.
    /// </summary>
    /// <param name="input">The input buffer (32·d·k bytes).</param>
    /// <param name="d">The compression bit width.</param>
    /// <param name="vec">The output polynomial vector.</param>
    /// <param name="k">The module rank.</param>
    public static void DecodeAndDecompress(ReadOnlySpan<byte> input, int d, Span<short> vec, int k)
    {
        int polySize = 32 * d;
        for (int i = 0; i < k; i++)
        {
            Span<short> poly = Poly(vec, i);
            Encode.ByteDecodeD(input.Slice(i * polySize, polySize), d, poly);
            Compress.DecompressPoly(poly, d);
        }
    }
}
