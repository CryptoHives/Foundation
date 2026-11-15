// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
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
    private const int Q = MLDsaParams.Q;

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
        if (a.Length < MLDsaParams.N) throw new ArgumentException("A full polynomial is required.", nameof(a));

        ref int ar = ref MemoryMarshalEx.GetArrayDataReference(a);
        ref int zr = ref MemoryMarshalEx.GetArrayDataReference(Zetas);
        nuint k = 0;
        for (nuint len = 128; len > 0; len >>= 1)
        {
            for (nuint start = 0; start < MLDsaParams.N; start += 2 * len)
            {
                int zeta = Unsafe.Add(ref zr, ++k);
                for (nuint j = start; j < start + len; j++)
                {
                    ref int lo = ref Unsafe.Add(ref ar, j);
                    ref int hi = ref Unsafe.Add(ref ar, j + len);
                    int t = MontgomeryMultiply(zeta, hi);
                    hi = lo - t;
                    lo += t;
                }
            }
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Inverse(int[] a)
    {
        if (a.Length < MLDsaParams.N) throw new ArgumentException("A full polynomial is required.", nameof(a));

        ref int ar = ref MemoryMarshalEx.GetArrayDataReference(a);
        ref int zr = ref MemoryMarshalEx.GetArrayDataReference(Zetas);
        nuint k = MLDsaParams.N;
        for (nuint len = 1; len < MLDsaParams.N; len <<= 1)
        {
            for (nuint start = 0; start < MLDsaParams.N; start += 2 * len)
            {
                int zeta = -Unsafe.Add(ref zr, --k);
                for (nuint j = start; j < start + len; j++)
                {
                    ref int lo = ref Unsafe.Add(ref ar, j);
                    ref int hi = ref Unsafe.Add(ref ar, j + len);
                    int t = lo;
                    int h = hi;
                    lo = t + h;
                    hi = MontgomeryMultiply(zeta, t - h);
                }
            }
        }

        int scale = InverseScale;
        for (nuint j = 0; j < MLDsaParams.N; j++)
        {
            ref int c = ref Unsafe.Add(ref ar, j);
            c = MontgomeryMultiply(scale, c);
        }
    }

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
        var zetas = new int[MLDsaParams.N];
        for (int i = 0; i < MLDsaParams.N; i++)
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
