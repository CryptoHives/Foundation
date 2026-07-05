// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Sampling routines for ML-DSA (FIPS 204 §7.3, Algorithms 29–34).
/// </summary>
internal static class Sampling
{
    /// <summary>
    /// ExpandA (FIPS 204 Algorithm 32): generates the k × ℓ matrix Â in NTT domain from seed ρ.
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="rho">The 32-byte public seed ρ.</param>
    /// <returns>The matrix Â.</returns>
    public static int[][][] ExpandA(MlDsaParams p, ReadOnlySpan<byte> rho)
    {
        var matrix = new int[p.K][][];
        Span<byte> seed = stackalloc byte[34];
        rho.Slice(0, 32).CopyTo(seed);

        for (int r = 0; r < p.K; r++)
        {
            matrix[r] = new int[p.L][];
            for (int s = 0; s < p.L; s++)
            {
                matrix[r][s] = new int[MlDsaParams.N];
                seed[32] = (byte)s;
                seed[33] = (byte)r;
                RejNttPoly(seed, matrix[r][s]);
            }
        }

        return matrix;
    }

    /// <summary>
    /// RejNTTPoly (FIPS 204 Algorithm 30): samples a polynomial in NTT domain with
    /// coefficients uniform in [0, q) by rejection sampling from SHAKE128.
    /// </summary>
    /// <param name="seed">The 34-byte seed (ρ ‖ s ‖ r).</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void RejNttPoly(ReadOnlySpan<byte> seed, int[] coeffs)
    {
        using var xof = Shake128.Create(504);
        xof.Absorb(seed);

        int count = 0;
        Span<byte> buf = stackalloc byte[504];

        while (count < MlDsaParams.N)
        {
            xof.Squeeze(buf);
            for (int i = 0; i + 2 < buf.Length && count < MlDsaParams.N; i += 3)
            {
                int d = (buf[i] | (buf[i + 1] << 8) | (buf[i + 2] << 16)) & 0x7FFFFF;
                if (d < MlDsaParams.Q)
                {
                    coeffs[count++] = d;
                }
            }
        }
    }

    /// <summary>
    /// ExpandS (FIPS 204 Algorithm 33): samples the secret vectors s1 (ℓ polys) and s2 (k polys).
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="rhoPrime">The 64-byte private seed ρ′.</param>
    /// <param name="s1">Output: ℓ polynomials with coefficients in [−η, η].</param>
    /// <param name="s2">Output: k polynomials with coefficients in [−η, η].</param>
    public static void ExpandS(MlDsaParams p, ReadOnlySpan<byte> rhoPrime, int[][] s1, int[][] s2)
    {
        for (int r = 0; r < p.L; r++)
        {
            RejBoundedPoly(rhoPrime, (ushort)r, p.Eta, s1[r]);
        }

        for (int r = 0; r < p.K; r++)
        {
            RejBoundedPoly(rhoPrime, (ushort)(p.L + r), p.Eta, s2[r]);
        }
    }

    /// <summary>
    /// RejBoundedPoly (FIPS 204 Algorithm 31): samples a polynomial with coefficients
    /// in [−η, η] by rejection sampling half-bytes from SHAKE256.
    /// </summary>
    /// <param name="rhoPrime">The 64-byte seed ρ′.</param>
    /// <param name="nonce">The 16-bit little-endian domain-separation index.</param>
    /// <param name="eta">The parameter η ∈ {2, 4}.</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void RejBoundedPoly(ReadOnlySpan<byte> rhoPrime, ushort nonce, int eta, int[] coeffs)
    {
        using var xof = Shake256.Create(136);
        xof.Absorb(rhoPrime);
        Span<byte> n = stackalloc byte[2];
        n[0] = (byte)nonce;
        n[1] = (byte)(nonce >> 8);
        xof.Absorb(n);

        int count = 0;
        Span<byte> buf = stackalloc byte[136];

        while (count < MlDsaParams.N)
        {
            xof.Squeeze(buf);
            for (int i = 0; i < buf.Length && count < MlDsaParams.N; i++)
            {
                int z0 = buf[i] & 0x0F;
                int z1 = buf[i] >> 4;

                count = TryAcceptEta(z0, eta, coeffs, count);
                if (count < MlDsaParams.N)
                {
                    count = TryAcceptEta(z1, eta, coeffs, count);
                }
            }
        }

        CryptographicOperations.ZeroMemory(buf);
    }

    /// <summary>
    /// ExpandMask (FIPS 204 Algorithm 34): samples the mask vector y with coefficients
    /// in [−γ₁ + 1, γ₁].
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="rhoDoublePrime">The 64-byte per-message seed ρ″.</param>
    /// <param name="kappa">The rejection-loop counter κ.</param>
    /// <param name="y">Output: ℓ polynomials.</param>
    public static void ExpandMask(MlDsaParams p, ReadOnlySpan<byte> rhoDoublePrime, int kappa, int[][] y)
    {
        int bytes = 32 * p.ZBits;
        byte[] v = new byte[bytes];
        Span<byte> n = stackalloc byte[2];

        for (int r = 0; r < p.L; r++)
        {
            int nonce = kappa + r;
            n[0] = (byte)nonce;
            n[1] = (byte)(nonce >> 8);

            using var xof = Shake256.Create(bytes);
            xof.Absorb(rhoDoublePrime);
            xof.Absorb(n);
            xof.Squeeze(v);

            Encode.BitUnpackSigned(v, p.ZBits, p.Gamma1, y[r]);
        }

        CryptographicOperations.ZeroMemory(v);
    }

    /// <summary>
    /// SampleInBall (FIPS 204 Algorithm 29): derives the sparse challenge polynomial c
    /// with exactly τ coefficients in {−1, 1} from the commitment hash c̃.
    /// </summary>
    /// <param name="p">The parameter set.</param>
    /// <param name="cTilde">The commitment hash c̃ (λ/4 bytes).</param>
    /// <param name="c">The 256-element output polynomial.</param>
    public static void SampleInBall(MlDsaParams p, ReadOnlySpan<byte> cTilde, int[] c)
    {
        Array.Clear(c, 0, MlDsaParams.N);

        using var xof = Shake256.Create(136);
        xof.Absorb(cTilde.Slice(0, p.CTildeBytes));

        Span<byte> signs = stackalloc byte[8];
        xof.Squeeze(signs);
        ulong signBits = 0;
        for (int i = 0; i < 8; i++)
        {
            signBits |= (ulong)signs[i] << (8 * i);
        }

        Span<byte> one = stackalloc byte[1];
        for (int i = MlDsaParams.N - p.Tau; i < MlDsaParams.N; i++)
        {
            int j;
            do
            {
                xof.Squeeze(one);
                j = one[0];
            }
            while (j > i);

            c[i] = c[j];
            c[j] = 1 - 2 * (int)(signBits & 1);
            signBits >>= 1;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static int TryAcceptEta(int z, int eta, int[] coeffs, int count)
    {
        if (eta == 2)
        {
            if (z < 15)
            {
                coeffs[count++] = 2 - z % 5;
            }
        }
        else if (z < 9)
        {
            coeffs[count++] = 4 - z;
        }

        return count;
    }
}
