// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Polynomial operations over ℤ_q[X]/(X²⁵⁶ + 1) for ML-DSA.
/// </summary>
/// <remarks>
/// Provides ring arithmetic, the FIPS 204 rounding functions (Power2Round, Decompose,
/// MakeHint, UseHint — Algorithms 35–40), and constant-time infinity-norm checks.
/// </remarks>
internal static class Poly
{
    /// <summary>
    /// Adds two polynomials coefficient-wise: r[i] = a[i] + b[i].
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Add(int[] r, int[] a, int[] b)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] = a[i] + b[i];
        }
    }

    /// <summary>
    /// Subtracts two polynomials coefficient-wise: r[i] = a[i] − b[i].
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Sub(int[] r, int[] a, int[] b)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] = a[i] - b[i];
        }
    }

    /// <summary>
    /// Reduces all coefficients to the range (−6283009, 6283008].
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Reduce(int[] r)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] = Ntt.Reduce32(r[i]);
        }
    }

    /// <summary>
    /// Adds q to all negative coefficients, mapping into [0, q).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ConditionalAddQ(int[] r)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] = Ntt.ConditionalAddQ(r[i]);
        }
    }

    /// <summary>
    /// Multiplies all coefficients by 2^d (used to reconstruct t1·2^d during verification).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ShiftLeftD(int[] r)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] <<= MlDsaParams.D;
        }
    }

    /// <summary>
    /// Pointwise multiplication in the NTT domain with Montgomery reduction: r[i] = a[i]·b[i]·R⁻¹.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void PointwiseMontgomery(int[] r, int[] a, int[] b)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            r[i] = Ntt.MontgomeryMultiply(a[i], b[i]);
        }
    }

    /// <summary>
    /// Power2Round (FIPS 204 Algorithm 35): splits r = r1·2^d + r0 with r0 ∈ (−2^(d−1), 2^(d−1)].
    /// </summary>
    /// <param name="r1">Output: the high parts. Input coefficients must be in [0, q).</param>
    /// <param name="r0">Output: the low parts.</param>
    /// <param name="a">The input polynomial with coefficients in [0, q).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Power2Round(int[] r1, int[] r0, int[] a)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int v = a[i];
            int high = (v + (1 << (MlDsaParams.D - 1)) - 1) >> MlDsaParams.D;
            r0[i] = v - (high << MlDsaParams.D);
            r1[i] = high;
        }
    }

    /// <summary>
    /// Decompose (FIPS 204 Algorithm 36): splits r = r1·2γ₂ + r0 with the q−1 corner case folded.
    /// </summary>
    /// <param name="r1">Output: the high parts.</param>
    /// <param name="r0">Output: the centered low parts.</param>
    /// <param name="a">The input polynomial with coefficients in [0, q).</param>
    /// <param name="gamma2">The parameter set's γ₂ value.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Decompose(int[] r1, int[] r0, int[] a, int gamma2)
    {
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int v = a[i];
            int high = DecomposeHigh(v, gamma2);
            int low = v - high * 2 * gamma2;
            low -= (((MlDsaParams.Q - 1) / 2 - low) >> 31) & MlDsaParams.Q;
            r1[i] = high;
            r0[i] = low;
        }
    }

    /// <summary>
    /// Computes the high part of Decompose for a single coefficient in [0, q).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static int DecomposeHigh(int a, int gamma2)
    {
        int a1 = (a + 127) >> 7;
        if (gamma2 == (MlDsaParams.Q - 1) / 32)
        {
            a1 = (a1 * 1025 + (1 << 21)) >> 22;
            a1 &= 15;
        }
        else
        {
            // γ₂ = (q − 1) / 88
            a1 = (a1 * 11275 + (1 << 23)) >> 24;
            a1 ^= ((43 - a1) >> 31) & a1;
        }

        return a1;
    }

    /// <summary>
    /// MakeHint (FIPS 204 Algorithm 39) over full polynomials using the centered low value.
    /// </summary>
    /// <param name="hint">Output: hint bits (0/1 per coefficient).</param>
    /// <param name="low">The centered low value w₀ − ⟨⟨c·s₂⟩⟩ + ⟨⟨c·t₀⟩⟩.</param>
    /// <param name="high">The high bits w₁ of the commitment.</param>
    /// <param name="gamma2">The parameter set's γ₂ value.</param>
    /// <returns>The number of hint bits set.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static int MakeHint(int[] hint, int[] low, int[] high, int gamma2)
    {
        int count = 0;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int a0 = low[i];
            int a1 = high[i];
            // Branch-free evaluation of: a0 > γ₂ || a0 < −γ₂ || (a0 == −γ₂ && a1 != 0)
            int gt = (gamma2 - a0) >> 31;                       // -1 if a0 > γ₂
            int lt = (a0 + gamma2) >> 31;                       // -1 if a0 < −γ₂
            int eq = EqualsMask(a0, -gamma2) & NonZeroMask(a1); // -1 if a0 == −γ₂ && a1 != 0
            int h = (gt | lt | eq) & 1;
            hint[i] = h;
            count += h;
        }

        return count;
    }

    /// <summary>
    /// UseHint (FIPS 204 Algorithm 40): recovers the corrected high bits during verification.
    /// </summary>
    /// <param name="r">The commitment polynomial with coefficients in [0, q); replaced by the corrected high bits.</param>
    /// <param name="hint">The hint bits from the signature.</param>
    /// <param name="gamma2">The parameter set's γ₂ value.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void UseHint(int[] r, int[] hint, int gamma2)
    {
        int m = (MlDsaParams.Q - 1) / (2 * gamma2);
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int v = r[i];
            int a1 = DecomposeHigh(v, gamma2);
            int a0 = v - a1 * 2 * gamma2;
            a0 -= (((MlDsaParams.Q - 1) / 2 - a0) >> 31) & MlDsaParams.Q;

            if (hint[i] == 0)
            {
                r[i] = a1;
            }
            else if (a0 > 0)
            {
                r[i] = a1 == m - 1 ? 0 : a1 + 1;
            }
            else
            {
                r[i] = a1 == 0 ? m - 1 : a1 - 1;
            }
        }
    }

    /// <summary>
    /// Constant-time infinity-norm check: returns true when any |coefficient| ≥ bound.
    /// </summary>
    /// <remarks>
    /// Scans all coefficients without early exit so that the position of an offending
    /// coefficient in a rejected signing candidate is not leaked through timing.
    /// </remarks>
    /// <param name="a">The polynomial to check (coefficients in (−q, q)).</param>
    /// <param name="bound">The exclusive bound B ≤ (q − 1)/8.</param>
    /// <returns>True if the norm bound is violated.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static bool NormExceeds(int[] a, int bound)
    {
        int violated = 0;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            int v = a[i];
            int mask = v >> 31;
            int abs = (v ^ mask) - mask;
            violated |= (bound - 1 - abs) >> 31;
        }

        return violated != 0;
    }

    /// <summary>
    /// Copies a polynomial.
    /// </summary>
    public static void Copy(int[] destination, int[] source)
    {
        Array.Copy(source, destination, MlDsaParams.N);
    }

    /// <summary>Returns -1 when a == b, else 0, without branching.</summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static int EqualsMask(int a, int b)
    {
        return ~NonZeroMask(a ^ b);
    }

    /// <summary>Returns -1 when a != 0, else 0, without branching.</summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static int NonZeroMask(int a)
    {
        return (a | -a) >> 31;
    }
}
