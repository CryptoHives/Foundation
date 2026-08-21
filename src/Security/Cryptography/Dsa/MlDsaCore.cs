// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Runtime.CompilerServices;
using OS = System.Security.Cryptography;

/// <summary>
/// Core ML-DSA operations implementing FIPS 204 algorithms.
/// </summary>
/// <remarks>
/// <para>
/// Implements ML-DSA.KeyGen_internal (Algorithm 6), ML-DSA.Sign_internal (Algorithm 7),
/// and ML-DSA.Verify_internal (Algorithm 8). The external interface (Algorithms 2/3)
/// is obtained by passing the message prefix 0x00 ‖ |ctx| ‖ ctx; the internal test
/// interface passes an empty prefix.
/// </para>
/// <para>
/// All hashing uses SHAKE256 (H) and SHAKE128 (matrix expansion) per FIPS 204 §3.7.
/// </para>
/// </remarks>
internal static class MlDsaCore
{
    /// <summary>
    /// ML-DSA.KeyGen_internal (FIPS 204 Algorithm 6): expands the 32-byte seed ξ into a key pair.
    /// </summary>
    /// <param name="p">The ML-DSA parameter set.</param>
    /// <param name="xi">The 32-byte key generation seed ξ.</param>
    /// <param name="pk">Output: the public key.</param>
    /// <param name="sk">Output: the secret key.</param>
    public static void KeyGen(MlDsaParams p, ReadOnlySpan<byte> xi, Span<byte> pk, Span<byte> sk)
    {
        // (ρ, ρ′, K) = H(ξ ‖ k ‖ ℓ, 128)
        Span<byte> expanded = stackalloc byte[128];
        Span<byte> domain = stackalloc byte[2];
        domain[0] = (byte)p.K;
        domain[1] = (byte)p.L;
        using (var shake = Shake256.Create(128))
        {
            shake.Absorb(xi.Slice(0, MlDsaParams.KeyGenSeedBytes));
            shake.Absorb(domain);
            shake.Squeeze(expanded);
        }

        ReadOnlySpan<byte> rho = expanded.Slice(0, 32);
        ReadOnlySpan<byte> rhoPrime = expanded.Slice(32, 64);
        ReadOnlySpan<byte> key = expanded.Slice(96, 32);

        int[][][] matrix = Sampling.ExpandA(p, rho);

        int[][] s1 = PolyVec.Create(p.L);
        int[][] s2 = PolyVec.Create(p.K);
        Sampling.ExpandS(p, rhoPrime, s1, s2);

        // t = NTT⁻¹(Â ∘ NTT(s1)) + s2
        int[][] s1Hat = PolyVec.Create(p.L);
        PolyVec.Copy(s1Hat, s1);
        PolyVec.Ntt(s1Hat);

        int[][] t = PolyVec.Create(p.K);
        PolyVec.MatrixPointwiseMontgomery(t, matrix, s1Hat);
        PolyVec.Reduce(t);
        PolyVec.InverseNtt(t);
        PolyVec.Add(t, t, s2);
        PolyVec.ConditionalAddQ(t);

        // (t1, t0) = Power2Round(t)
        int[][] t1 = PolyVec.Create(p.K);
        int[][] t0 = PolyVec.Create(p.K);
        for (int i = 0; i < p.K; i++)
        {
            Poly.Power2Round(t1[i], t0[i], t[i]);
        }

        Encode.PkEncode(p, rho, t1, pk);

        // tr = H(pk, 64)
        Span<byte> tr = stackalloc byte[64];
        using (var shake = Shake256.Create(64))
        {
            shake.Absorb(pk.Slice(0, p.PublicKeyBytes));
            shake.Squeeze(tr);
        }

        Encode.SkEncode(p, rho, key, tr, s1, s2, t0, sk);

        CryptographicOperations.ZeroMemory(expanded);
        Zero(s1);
        Zero(s2);
        Zero(s1Hat);
        Zero(t0);
        Zero(t);

        PairwiseConsistencyTest(p, pk, sk);
    }

    /// <summary>
    /// Verifies a freshly generated key pair by signing and verifying a random message,
    /// as expected by FIPS 140-3 for signature key generation.
    /// </summary>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    private static void PairwiseConsistencyTest(MlDsaParams p, ReadOnlySpan<byte> pk, ReadOnlySpan<byte> sk)
    {
        Span<byte> message = stackalloc byte[32];
        GenerateRandomSeed(message);
        Span<byte> rnd = stackalloc byte[MlDsaParams.SignSeedBytes];

        byte[] signature = new byte[p.SignatureBytes];
        Sign(p, sk, ReadOnlySpan<byte>.Empty, message, rnd, signature);
        bool consistent = Verify(p, pk, ReadOnlySpan<byte>.Empty, message, signature);

        CryptographicOperations.ZeroMemory(message);

        if (!consistent)
        {
            throw new OS.CryptographicException("ML-DSA key generation failed the pairwise consistency test.");
        }
    }

    /// <summary>
    /// ML-DSA.Sign_internal (FIPS 204 Algorithm 7).
    /// </summary>
    /// <param name="p">The ML-DSA parameter set.</param>
    /// <param name="sk">The secret key.</param>
    /// <param name="prefix">The message prefix (0x00 ‖ |ctx| ‖ ctx for the external interface, empty for the internal interface).</param>
    /// <param name="message">The message M.</param>
    /// <param name="rnd">The 32-byte signing randomness (all-zero for deterministic signing).</param>
    /// <param name="signature">Output: the signature.</param>
    public static void Sign(MlDsaParams p, ReadOnlySpan<byte> sk, ReadOnlySpan<byte> prefix,
                            ReadOnlySpan<byte> message, ReadOnlySpan<byte> rnd, Span<byte> signature)
    {
        Span<byte> rho = stackalloc byte[32];
        Span<byte> key = stackalloc byte[32];
        Span<byte> tr = stackalloc byte[64];
        int[][] s1 = PolyVec.Create(p.L);
        int[][] s2 = PolyVec.Create(p.K);
        int[][] t0 = PolyVec.Create(p.K);
        Encode.SkDecode(p, sk, rho, key, tr, s1, s2, t0);

        // μ = H(tr ‖ M′, 64)
        Span<byte> mu = stackalloc byte[64];
        using (var shake = Shake256.Create(64))
        {
            shake.Absorb(tr);
            shake.Absorb(prefix);
            shake.Absorb(message);
            shake.Squeeze(mu);
        }

        // ρ″ = H(K ‖ rnd ‖ μ, 64)
        Span<byte> rhoDoublePrime = stackalloc byte[64];
        using (var shake = Shake256.Create(64))
        {
            shake.Absorb(key);
            shake.Absorb(rnd.Slice(0, MlDsaParams.SignSeedBytes));
            shake.Absorb(mu);
            shake.Squeeze(rhoDoublePrime);
        }

        int[][][] matrix = Sampling.ExpandA(p, rho);

        PolyVec.Ntt(s1);
        PolyVec.Ntt(s2);
        PolyVec.Ntt(t0);

        int[][] y = PolyVec.Create(p.L);
        int[][] yHat = PolyVec.Create(p.L);
        int[][] z = PolyVec.Create(p.L);
        int[][] w = PolyVec.Create(p.K);
        int[][] w0 = PolyVec.Create(p.K);
        int[][] w1 = PolyVec.Create(p.K);
        int[][] tmp = PolyVec.Create(p.K);
        int[][] hint = PolyVec.Create(p.K);
        int[] c = new int[MlDsaParams.N];
        Span<byte> cTilde = stackalloc byte[p.CTildeBytes];
        byte[] w1Encoded = new byte[p.K * 32 * p.W1Bits];

        int kappa = 0;
        while (true)
        {
            // y = ExpandMask(ρ″, κ); w = NTT⁻¹(Â ∘ NTT(y))
            Sampling.ExpandMask(p, rhoDoublePrime, kappa, y);
            kappa += p.L;

            PolyVec.Copy(yHat, y);
            PolyVec.Ntt(yHat);
            PolyVec.MatrixPointwiseMontgomery(w, matrix, yHat);
            PolyVec.Reduce(w);
            PolyVec.InverseNtt(w);
            PolyVec.ConditionalAddQ(w);

            // (w1, w0) = Decompose(w); c̃ = H(μ ‖ w1Encode(w1))
            for (int i = 0; i < p.K; i++)
            {
                Poly.Decompose(w1[i], w0[i], w[i], p.Gamma2);
            }

            Encode.W1Encode(p, w1, w1Encoded);
            using (var shake = Shake256.Create(p.CTildeBytes))
            {
                shake.Absorb(mu);
                shake.Absorb(w1Encoded);
                shake.Squeeze(cTilde);
            }

            Sampling.SampleInBall(p, cTilde, c);
            Ntt.Forward(c);

            // z = y + NTT⁻¹(ĉ ∘ ŝ1)
            PolyVec.PointwiseMontgomery(z, c, s1);
            PolyVec.InverseNtt(z);
            PolyVec.Add(z, z, y);
            PolyVec.Reduce(z);
            if (PolyVec.NormExceeds(z, p.Gamma1 - p.Beta))
            {
                continue;
            }

            // r0 = LowBits(w − NTT⁻¹(ĉ ∘ ŝ2))
            PolyVec.PointwiseMontgomery(tmp, c, s2);
            PolyVec.InverseNtt(tmp);
            PolyVec.Sub(w0, w0, tmp);
            PolyVec.Reduce(w0);
            if (PolyVec.NormExceeds(w0, p.Gamma2 - p.Beta))
            {
                continue;
            }

            // ⟨⟨c·t0⟩⟩ hint computation
            PolyVec.PointwiseMontgomery(tmp, c, t0);
            PolyVec.InverseNtt(tmp);
            PolyVec.Reduce(tmp);
            if (PolyVec.NormExceeds(tmp, p.Gamma2))
            {
                continue;
            }

            PolyVec.Add(w0, w0, tmp);
            int hintCount = 0;
            for (int i = 0; i < p.K; i++)
            {
                hintCount += Poly.MakeHint(hint[i], w0[i], w1[i], p.Gamma2);
            }

            if (hintCount > p.Omega)
            {
                continue;
            }

            Encode.SigEncode(p, cTilde, z, hint, signature);
            break;
        }

        CryptographicOperations.ZeroMemory(key);
        CryptographicOperations.ZeroMemory(rhoDoublePrime);
        Zero(s1);
        Zero(s2);
        Zero(t0);
        Zero(y);
        Zero(yHat);
        Zero(z);
        Zero(w0);
        Zero(tmp);
        Zero(c);
    }

    /// <summary>
    /// ML-DSA.Verify_internal (FIPS 204 Algorithm 8).
    /// </summary>
    /// <param name="p">The ML-DSA parameter set.</param>
    /// <param name="pk">The public key.</param>
    /// <param name="prefix">The message prefix (0x00 ‖ |ctx| ‖ ctx for the external interface, empty for the internal interface).</param>
    /// <param name="message">The message M.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <returns>True when the signature is valid.</returns>
    public static bool Verify(MlDsaParams p, ReadOnlySpan<byte> pk, ReadOnlySpan<byte> prefix,
                              ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
    {
        Span<byte> cTilde = stackalloc byte[p.CTildeBytes];
        int[][] z = PolyVec.Create(p.L);
        int[][] hint = PolyVec.Create(p.K);
        if (!Encode.SigDecode(p, signature, cTilde, z, hint))
        {
            return false;
        }

        if (PolyVec.NormExceeds(z, p.Gamma1 - p.Beta))
        {
            return false;
        }

        Span<byte> rho = stackalloc byte[32];
        int[][] t1 = PolyVec.Create(p.K);
        Encode.PkDecode(p, pk, rho, t1);

        // μ = H(H(pk, 64) ‖ M′, 64)
        Span<byte> tr = stackalloc byte[64];
        using (var shake = Shake256.Create(64))
        {
            shake.Absorb(pk.Slice(0, p.PublicKeyBytes));
            shake.Squeeze(tr);
        }

        Span<byte> mu = stackalloc byte[64];
        using (var shake = Shake256.Create(64))
        {
            shake.Absorb(tr);
            shake.Absorb(prefix);
            shake.Absorb(message);
            shake.Squeeze(mu);
        }

        // w′ = NTT⁻¹(Â ∘ NTT(z) − NTT(c) ∘ NTT(t1 · 2^d))
        int[] c = new int[MlDsaParams.N];
        Sampling.SampleInBall(p, cTilde, c);
        Ntt.Forward(c);

        int[][][] matrix = Sampling.ExpandA(p, rho);
        PolyVec.Ntt(z);

        int[][] w = PolyVec.Create(p.K);
        PolyVec.MatrixPointwiseMontgomery(w, matrix, z);

        for (int i = 0; i < p.K; i++)
        {
            Poly.ShiftLeftD(t1[i]);
        }

        PolyVec.Ntt(t1);
        int[][] ct1 = PolyVec.Create(p.K);
        PolyVec.PointwiseMontgomery(ct1, c, t1);
        PolyVec.Sub(w, w, ct1);
        PolyVec.Reduce(w);
        PolyVec.InverseNtt(w);
        PolyVec.ConditionalAddQ(w);

        // w1′ = UseHint(h, w′); accept iff c̃ = H(μ ‖ w1Encode(w1′))
        for (int i = 0; i < p.K; i++)
        {
            Poly.UseHint(w[i], hint[i], p.Gamma2);
        }

        byte[] w1Encoded = new byte[p.K * 32 * p.W1Bits];
        Encode.W1Encode(p, w, w1Encoded);

        Span<byte> cTilde2 = stackalloc byte[p.CTildeBytes];
        using (var shake = Shake256.Create(p.CTildeBytes))
        {
            shake.Absorb(mu);
            shake.Absorb(w1Encoded);
            shake.Squeeze(cTilde2);
        }

        return CryptographicOperations.FixedTimeEquals(cTilde, cTilde2);
    }

    /// <summary>
    /// Builds the FIPS 204 external-interface message prefix 0x00 ‖ |ctx| ‖ ctx.
    /// </summary>
    /// <param name="context">The context string (at most 255 bytes).</param>
    /// <param name="prefix">Output buffer of at least 2 + context.Length bytes.</param>
    /// <returns>The number of prefix bytes written.</returns>
    public static int BuildExternalPrefix(ReadOnlySpan<byte> context, Span<byte> prefix)
    {
        prefix[0] = 0;
        prefix[1] = (byte)context.Length;
        context.CopyTo(prefix.Slice(2));
        return 2 + context.Length;
    }

    /// <summary>
    /// Generates cryptographically secure random bytes using the OS random number generator.
    /// </summary>
    public static void GenerateRandomSeed(Span<byte> output)
    {
#if NET8_0_OR_GREATER
        OS.RandomNumberGenerator.Fill(output);
#else
        byte[] buf = new byte[output.Length];
        using var rng = OS.RandomNumberGenerator.Create();
        rng.GetBytes(buf);
        buf.AsSpan().CopyTo(output);
        CryptographicOperations.ZeroMemory(buf);
#endif
    }

    /// <summary>
    /// Clears a secret polynomial in a way that's not subject to compiler optimizations.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Zero(int[] poly)
    {
        Array.Clear(poly, 0, poly.Length);
    }

    /// <summary>
    /// Clears a secret polynomial vector in a way that's not subject to compiler optimizations.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Zero(int[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Array.Clear(vec[i], 0, vec[i].Length);
        }
    }
}
