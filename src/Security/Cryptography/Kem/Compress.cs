// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System.Runtime.CompilerServices;

/// <summary>
/// Compression and decompression of ML-KEM polynomial coefficients.
/// </summary>
/// <remarks>
/// Implements FIPS 203 §4.2.1 Compress and Decompress operations. These map coefficients
/// between the full modulus range [0, q) and a reduced d-bit representation [0, 2^d).
/// </remarks>
internal static class Compress
{
    /// <summary>
    /// Compresses a coefficient from [0, q) to [0, 2^d).
    /// </summary>
    /// <remarks>
    /// FIPS 203 §4.2.1: Compress_d(x) = ⌈(2^d / q) · x⌋ mod 2^d.
    /// </remarks>
    /// <param name="x">The coefficient in [0, q).</param>
    /// <param name="d">The target bit width.</param>
    /// <returns>The compressed value in [0, 2^d).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ushort CompressD(ushort x, int d)
    {
        // ⌈(2^d / q) · x⌋ = ⌊(2^d · x + q/2) / q⌋
        uint t = ((uint)x << d) + (MlKemParams.Q >> 1);
        // Division by q = 3329 using multiply-shift:
        // q^(-1) approx = ceil(2^36 / 3329) = 20642680
        // This gives exact results for all x < q and d ≤ 12.
        t = (uint)((ulong)t * 20642680UL >> 36);
        return (ushort)(t & ((1u << d) - 1));
    }

    /// <summary>
    /// Decompresses a coefficient from [0, 2^d) to [0, q).
    /// </summary>
    /// <remarks>
    /// FIPS 203 §4.2.1: Decompress_d(y) = ⌈(q / 2^d) · y⌋.
    /// </remarks>
    /// <param name="y">The compressed value in [0, 2^d).</param>
    /// <param name="d">The bit width of the compressed representation.</param>
    /// <returns>The decompressed coefficient in [0, q).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ushort DecompressD(ushort y, int d)
    {
        // ⌈(q / 2^d) · y⌋ = ⌊(q · y + 2^(d-1)) / 2^d⌋
        return (ushort)(((uint)y * MlKemParams.Q + (1u << (d - 1))) >> d);
    }

    /// <summary>
    /// Compresses all 256 coefficients of a polynomial in-place.
    /// </summary>
    /// <param name="coeffs">The polynomial coefficients (modified in-place).</param>
    /// <param name="d">The target bit width.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void CompressPoly(short[] coeffs, int d)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            coeffs[i] = (short)CompressD((ushort)coeffs[i], d);
        }
    }

    /// <summary>
    /// Decompresses all 256 coefficients of a polynomial in-place.
    /// </summary>
    /// <param name="coeffs">The polynomial coefficients (modified in-place).</param>
    /// <param name="d">The bit width of the compressed representation.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void DecompressPoly(short[] coeffs, int d)
    {
        for (int i = 0; i < MlKemParams.N; i++)
        {
            coeffs[i] = (short)DecompressD((ushort)coeffs[i], d);
        }
    }
}
