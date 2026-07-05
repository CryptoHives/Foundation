// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System.Runtime.CompilerServices;

/// <summary>
/// Number Theoretic Transform (NTT) operations over ℤ_8380417 for ML-DSA.
/// </summary>
/// <remarks>
/// Implements the forward and inverse NTT as specified in FIPS 204 §7.5 (Algorithms 41/42),
/// using Montgomery multiplication with R = 2³² for efficient modular arithmetic.
/// The twiddle-factor table is derived at type initialization from ζ = 1753, the primitive
/// 512th root of unity modulo q, avoiding a large hard-coded constant table.
/// </remarks>
internal static class Ntt
{
    /// <summary>q = 8380417.</summary>
    private const int Q = MlDsaParams.Q;

    /// <summary>q⁻¹ mod 2³². Used in Montgomery reduction.</summary>
    private const uint QInv = 58728449;

    /// <summary>
    /// Precomputed zeta values ζ^BitRev₈(i) · R mod± q in signed Montgomery form.
    /// </summary>
    private static readonly int[] Zetas = ComputeZetas();

    /// <summary>
    /// Scaling factor R²/256 mod q applied by the inverse NTT so that
    /// NTT⁻¹(â ∘ b̂) with Montgomery pointwise multiplication yields a·b in standard form.
    /// </summary>
    private static readonly int InverseScale = ComputeInverseScale();

    /// <summary>
    /// Performs the forward NTT in-place (FIPS 204 Algorithm 41).
    /// </summary>
    /// <param name="a">The 256 coefficients of the polynomial, modified in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Forward(int[] a)
    {
        int k = 0;
        for (int len = 128; len > 0; len >>= 1)
        {
            for (int start = 0; start < MlDsaParams.N; start += 2 * len)
            {
                int zeta = Zetas[++k];
                for (int j = start; j < start + len; j++)
                {
                    int t = MontgomeryMultiply(zeta, a[j + len]);
                    a[j + len] = a[j] - t;
                    a[j] = a[j] + t;
                }
            }
        }
    }

    /// <summary>
    /// Performs the inverse NTT in-place (FIPS 204 Algorithm 42).
    /// </summary>
    /// <remarks>
    /// The output carries an extra Montgomery factor R that cancels the R⁻¹ introduced by
    /// <see cref="MontgomeryMultiply"/> in the preceding pointwise multiplication, so the
    /// composition InverseNTT(â ∘ᵐ b̂) yields the standard-domain product.
    /// </remarks>
    /// <param name="a">The 256 coefficients of the polynomial, modified in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Inverse(int[] a)
    {
        int k = MlDsaParams.N;
        for (int len = 1; len < MlDsaParams.N; len <<= 1)
        {
            for (int start = 0; start < MlDsaParams.N; start += 2 * len)
            {
                int zeta = -Zetas[--k];
                for (int j = start; j < start + len; j++)
                {
                    int t = a[j];
                    a[j] = t + a[j + len];
                    a[j + len] = t - a[j + len];
                    a[j + len] = MontgomeryMultiply(zeta, a[j + len]);
                }
            }
        }

        for (int j = 0; j < MlDsaParams.N; j++)
        {
            a[j] = MontgomeryMultiply(InverseScale, a[j]);
        }
    }

    /// <summary>
    /// Montgomery reduction: given a 64-bit value a with |a| ≤ 2³¹·q, computes a · R⁻¹ mod± q.
    /// </summary>
    /// <param name="a">The value to reduce.</param>
    /// <returns>The Montgomery-reduced value in (−q, q).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static int MontgomeryReduce(long a)
    {
        unchecked
        {
            int t = (int)((uint)a * QInv);
            return (int)((a - (long)t * Q) >> 32);
        }
    }

    /// <summary>
    /// Montgomery multiplication: a · b · R⁻¹ mod± q.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static int MontgomeryMultiply(int a, int b)
    {
        return MontgomeryReduce((long)a * b);
    }

    /// <summary>
    /// Reduces a coefficient with |a| ≤ 2³¹ − 2²² to a representative in (−6283009, 6283008].
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static int Reduce32(int a)
    {
        int t = (a + (1 << 22)) >> 23;
        return a - t * Q;
    }

    /// <summary>
    /// Conditionally adds q so that a negative coefficient becomes non-negative.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static int ConditionalAddQ(int a)
    {
        return a + ((a >> 31) & Q);
    }

    private static int[] ComputeZetas()
    {
        // ζ = 1753 is a primitive 512th root of unity mod q (FIPS 204 §7.5).
        // Zetas[i] = ζ^BitRev₈(i) · R mod q, normalized to the signed range (−q/2, q/2].
        long r = (1L << 32) % Q;
        var zetas = new int[MlDsaParams.N];
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int exp = BitReverse8(i);
            long value = ModPow(1753, exp) * r % Q;
            if (value > Q / 2)
            {
                value -= Q;
            }

            zetas[i] = (int)value;
        }

        return zetas;
    }

    private static int ComputeInverseScale()
    {
        // R² · 256⁻¹ mod q: cancels both the 1/256 of the inverse butterfly network and
        // the R⁻¹ of the Montgomery pointwise multiplication that preceded it.
        long r = (1L << 32) % Q;
        long r2 = r * r % Q;
        long inv256 = ModPow(256, Q - 2);
        long value = r2 * inv256 % Q;
        return (int)value;
    }

    private static long ModPow(long value, int exponent)
    {
        long result = 1;
        long b = value % Q;
        int e = exponent;
        while (e > 0)
        {
            if ((e & 1) != 0)
            {
                result = result * b % Q;
            }

            b = b * b % Q;
            e >>= 1;
        }

        return result;
    }

    private static int BitReverse8(int value)
    {
        int result = 0;
        for (int bit = 0; bit < 8; bit++)
        {
            result = (result << 1) | ((value >> bit) & 1);
        }

        return result;
    }
}
