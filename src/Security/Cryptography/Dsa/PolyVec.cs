// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Operations on vectors of ML-DSA polynomials.
/// </summary>
/// <remarks>
/// A polynomial vector contains k or ℓ polynomials depending on its role. This class
/// lifts the <see cref="Poly"/> operations to vectors and provides the matrix product
/// used in KeyGen, Sign, and Verify.
/// </remarks>
internal static class PolyVec
{
    /// <summary>
    /// Allocates a new polynomial vector with <paramref name="length"/> polynomials.
    /// </summary>
    public static int[][] Create(int length)
    {
        var vec = new int[length][];
        for (int i = 0; i < length; i++)
        {
            vec[i] = new int[MlDsaParams.N];
        }

        return vec;
    }

    /// <summary>
    /// Applies the forward NTT to each polynomial in the vector.
    /// </summary>
    public static void Ntt(int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Dsa.Ntt.Forward(vec[i]);
        }
    }

    /// <summary>
    /// Applies the inverse NTT to each polynomial in the vector.
    /// </summary>
    public static void InverseNtt(int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Dsa.Ntt.Inverse(vec[i]);
        }
    }

    /// <summary>
    /// Reduces all coefficients in each polynomial of the vector.
    /// </summary>
    public static void Reduce(int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.Reduce(vec[i]);
        }
    }

    /// <summary>
    /// Adds q to all negative coefficients in each polynomial of the vector.
    /// </summary>
    public static void ConditionalAddQ(int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.ConditionalAddQ(vec[i]);
        }
    }

    /// <summary>
    /// Adds two polynomial vectors coefficient-wise.
    /// </summary>
    public static void Add(int[][] r, int[][] a, int[][] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Poly.Add(r[i], a[i], b[i]);
        }
    }

    /// <summary>
    /// Subtracts two polynomial vectors coefficient-wise.
    /// </summary>
    public static void Sub(int[][] r, int[][] a, int[][] b)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Poly.Sub(r[i], a[i], b[i]);
        }
    }

    /// <summary>
    /// Copies a polynomial vector.
    /// </summary>
    public static void Copy(int[][] destination, int[][] source)
    {
        for (int i = 0; i < source.Length; i++)
        {
            Poly.Copy(destination[i], source[i]);
        }
    }

    /// <summary>
    /// Computes the matrix product r = Â ∘ v̂ in the NTT domain with Montgomery reduction.
    /// </summary>
    /// <param name="r">The output vector of k polynomials.</param>
    /// <param name="matrix">The k × ℓ matrix Â in NTT domain.</param>
    /// <param name="vec">The ℓ-element input vector in NTT domain.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void MatrixPointwiseMontgomery(int[][] r, int[][][] matrix, int[][] vec)
    {
        var t = new int[MlDsaParams.N];
        for (int i = 0; i < matrix.Length; i++)
        {
            Array.Clear(r[i], 0, MlDsaParams.N);
            for (int j = 0; j < vec.Length; j++)
            {
                Poly.PointwiseMontgomery(t, matrix[i][j], vec[j]);
                Poly.Add(r[i], r[i], t);
            }
        }

        MlDsaCore.Zero(t);
    }

    /// <summary>
    /// Multiplies each polynomial of the vector by a single NTT-domain polynomial.
    /// </summary>
    public static void PointwiseMontgomery(int[][] r, int[] poly, int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Poly.PointwiseMontgomery(r[i], poly, vec[i]);
        }
    }

    /// <summary>
    /// Checks the infinity norm of all polynomials in the vector in constant time.
    /// </summary>
    /// <returns>True if any coefficient's absolute value reaches the bound.</returns>
    public static bool NormExceeds(int[][] vec, int bound)
    {
        bool violated = false;
        for (int i = 0; i < vec.Length; i++)
        {
            violated |= Poly.NormExceeds(vec[i], bound);
        }

        return violated;
    }
}
