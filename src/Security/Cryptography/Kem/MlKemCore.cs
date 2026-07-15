// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Runtime.CompilerServices;
using OS = System.Security.Cryptography;

/// <summary>
/// Core ML-KEM operations implementing FIPS 203 algorithms.
/// </summary>
/// <remarks>
/// <para>
/// Implements the K-PKE (inner PKE scheme) and the full ML-KEM key generation,
/// encapsulation, and decapsulation algorithms as specified in FIPS 203 §§6–7.
/// </para>
/// <para>
/// Hash functions mapping per FIPS 203 §4.1:
/// <list type="bullet">
///   <item><description>H = SHA3-256</description></item>
///   <item><description>G = SHA3-512</description></item>
///   <item><description>J = SHAKE256 (first 32 bytes)</description></item>
///   <item><description>PRF = SHAKE256 (η·64 bytes)</description></item>
///   <item><description>XOF = SHAKE128 (for SampleNTT)</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class MlKemCore
{
    // ========================================================================
    // K-PKE (Inner PKE Scheme) — FIPS 203 §6
    // ========================================================================

    /// <summary>
    /// K-PKE.KeyGen: Generates an encryption key pair.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 13. Produces an encryption key (ekPKE) and a decryption key (dkPKE).
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="d">The 32-byte random seed d.</param>
    /// <param name="ekPke">Output: encryption key (384·k + 32 bytes).</param>
    /// <param name="dkPke">Output: decryption key (384·k bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void KPkeKeyGen(MlKemParams p, ReadOnlySpan<byte> d, Span<byte> ekPke, Span<byte> dkPke)
    {
        int k = p.K;

        // (ρ, σ) = G(d ‖ k)
        Span<byte> gInput = stackalloc byte[33];
        d.Slice(0, 32).CopyTo(gInput);
        gInput[32] = (byte)k;

        Span<byte> gOutput = stackalloc byte[64];
        HashG(gInput, gOutput);
        ReadOnlySpan<byte> rho = gOutput.Slice(0, 32);
        ReadOnlySpan<byte> sigma = gOutput.Slice(32, 32);

        // Generate matrix Â in NTT domain
        short[][][] aHat = GenerateMatrix(k, rho);

        // Sample secret vector s
        byte nonce = 0;
        short[][] s = PolyVec.Create(k);
        for (int i = 0; i < k; i++)
        {
            SampleCbd(sigma, nonce++, p.Eta1, s[i]);
        }

        // Sample error vector e
        short[][] e = PolyVec.Create(k);
        for (int i = 0; i < k; i++)
        {
            SampleCbd(sigma, nonce++, p.Eta1, e[i]);
        }

        // NTT(s), NTT(e)
        PolyVec.Ntt(s);
        PolyVec.Ntt(e);
        PolyVec.Reduce(s);

        // t̂ = Â ◦ ŝ + ê
        short[][] tHat = PolyVec.Create(k);
        PolyVec.MatrixVectorMultiply(tHat, aHat, s, transpose: false);
        PolyVec.ToMontgomery(tHat);
        PolyVec.Add(tHat, tHat, e);
        PolyVec.Reduce(tHat);

        // ekPKE = ByteEncode₁₂(t̂) ‖ ρ
        PolyVec.Normalize(tHat);
        PolyVec.ToBytes(tHat, ekPke.Slice(0, p.PolyVecEncodedBytes));
        rho.CopyTo(ekPke.Slice(p.PolyVecEncodedBytes));

        // dkPKE = ByteEncode₁₂(ŝ)
        PolyVec.Normalize(s);
        PolyVec.ToBytes(s, dkPke.Slice(0, p.PolyVecEncodedBytes));

        CryptographicOperations.ZeroMemory(gInput);
        CryptographicOperations.ZeroMemory(gOutput);
        Zero(s);
        Zero(e);
    }

    /// <summary>
    /// K-PKE.Encrypt: Encrypts a message under an encryption key.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 14. Takes the encryption key, a 32-byte message, and
    /// a 32-byte random seed r, and produces a ciphertext.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="ekPke">The encryption key (384·k + 32 bytes).</param>
    /// <param name="msg">The 32-byte message to encrypt.</param>
    /// <param name="r">The 32-byte randomness seed.</param>
    /// <param name="ciphertext">Output: the ciphertext.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void KPkeEncrypt(MlKemParams p, ReadOnlySpan<byte> ekPke, ReadOnlySpan<byte> msg,
                                   ReadOnlySpan<byte> r, Span<byte> ciphertext)
    {
        int k = p.K;

        // Decode t̂ from ekPKE
        short[][] tHat = PolyVec.Create(k);
        PolyVec.FromBytes(ekPke.Slice(0, p.PolyVecEncodedBytes), tHat);
        ReadOnlySpan<byte> rho = ekPke.Slice(p.PolyVecEncodedBytes, 32);

        // Regenerate Â from ρ
        short[][][] aHat = GenerateMatrix(k, rho);

        // Sample r vector, e1 vector, and e2 polynomial
        byte nonce = 0;
        short[][] rv = PolyVec.Create(k);
        for (int i = 0; i < k; i++)
        {
            SampleCbd(r, nonce++, p.Eta1, rv[i]);
        }

        short[][] e1 = PolyVec.Create(k);
        for (int i = 0; i < k; i++)
        {
            SampleCbd(r, nonce++, p.Eta2, e1[i]);
        }

        short[] e2 = new short[MlKemParams.N];
        SampleCbd(r, nonce, p.Eta2, e2);

        // NTT(r)
        PolyVec.Ntt(rv);

        // u = NTT⁻¹(Âᵀ ◦ r̂) + e₁
        short[][] u = PolyVec.Create(k);
        PolyVec.MatrixVectorMultiply(u, aHat, rv, transpose: true);
        PolyVec.InverseNtt(u);
        PolyVec.Add(u, u, e1);
        PolyVec.Reduce(u);

        // v = NTT⁻¹(t̂ᵀ ◦ r̂) + e₂ + Decompress₁(ByteDecode₁(m))
        short[] v = new short[MlKemParams.N];
        PolyVec.InnerProduct(v, tHat, rv);
        Ntt.Inverse(v);

        short[] msgPoly = new short[MlKemParams.N];
        Poly.FromMessage(msg, msgPoly);

        Poly.Add(v, v, e2);
        Poly.Add(v, v, msgPoly);
        Poly.Reduce(v);

        // c₁ = ByteEncode_du(Compress_du(u))
        PolyVec.Normalize(u);
        PolyVec.CompressAndEncode(u, p.Du, ciphertext.Slice(0, p.PolyVecCompressedBytes));

        // c₂ = ByteEncode_dv(Compress_dv(v))
        Poly.Normalize(v);
        Compress.CompressPoly(v, p.Dv);
        Encode.ByteEncodeD(v, p.Dv, ciphertext.Slice(p.PolyVecCompressedBytes, p.PolyCompressedBytes));

        Zero(rv);
        Zero(e1);
        Zero(e2);
        Zero(msgPoly);
    }

    /// <summary>
    /// K-PKE.Decrypt: Decrypts a ciphertext using the decryption key.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 15. Recovers the 32-byte message from the ciphertext.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="dkPke">The decryption key (384·k bytes).</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="msg">Output: the 32-byte decrypted message.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void KPkeDecrypt(MlKemParams p, ReadOnlySpan<byte> dkPke, ReadOnlySpan<byte> ciphertext,
                                   Span<byte> msg)
    {
        int k = p.K;

        // Decode u from c₁
        short[][] u = PolyVec.Create(k);
        PolyVec.DecodeAndDecompress(ciphertext.Slice(0, p.PolyVecCompressedBytes), p.Du, u);

        // Decode v from c₂
        short[] v = new short[MlKemParams.N];
        Encode.ByteDecodeD(ciphertext.Slice(p.PolyVecCompressedBytes, p.PolyCompressedBytes), p.Dv, v);
        Compress.DecompressPoly(v, p.Dv);

        // Decode ŝ from dkPKE
        short[][] sHat = PolyVec.Create(k);
        PolyVec.FromBytes(dkPke.Slice(0, p.PolyVecEncodedBytes), sHat);

        // NTT(u)
        PolyVec.Ntt(u);

        // w = NTT⁻¹(ŝᵀ ◦ û)
        short[] w = new short[MlKemParams.N];
        PolyVec.InnerProduct(w, sHat, u);
        Ntt.Inverse(w);

        // m = ByteEncode₁(Compress₁(v − w))
        Poly.Sub(v, v, w);
        Poly.Reduce(v);
        Poly.Normalize(v);
        Poly.ToMessage(v, msg);

        Zero(sHat);
        Zero(w);
        Zero(v);
    }

    // ========================================================================
    // ML-KEM (Full KEM) — FIPS 203 §7
    // ========================================================================

    /// <summary>
    /// ML-KEM.KeyGen: Generates an ML-KEM key pair.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 16. Generates a (encapsulationKey, decapsulationKey) pair.
    /// The decapsulation key includes the encryption key, the decryption key,
    /// H(ek), and the implicit rejection seed z.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="seed">The 64-byte seed (d ‖ z).</param>
    /// <param name="ek">Output: encapsulation key (384·k + 32 bytes).</param>
    /// <param name="dk">Output: decapsulation key (768·k + 96 bytes).</param>
    public static void KeyGen(MlKemParams p, ReadOnlySpan<byte> seed, Span<byte> ek, Span<byte> dk)
    {
        ReadOnlySpan<byte> d = seed.Slice(0, 32);
        ReadOnlySpan<byte> z = seed.Slice(32, 32);

        // Generate K-PKE keys
        Span<byte> dkPke = dk.Slice(0, p.PolyVecEncodedBytes);
        KPkeKeyGen(p, d, ek, dkPke);

        // dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z
        int offset = p.PolyVecEncodedBytes;
        ek.Slice(0, p.EncapsulationKeyBytes).CopyTo(dk.Slice(offset));
        offset += p.EncapsulationKeyBytes;

        HashH(ek.Slice(0, p.EncapsulationKeyBytes), dk.Slice(offset, 32));
        offset += 32;

        z.CopyTo(dk.Slice(offset, 32));

        PairwiseConsistencyTest(p, ek, dk);
    }

    /// <summary>
    /// Verifies a freshly generated key pair by running one encapsulation/decapsulation
    /// round-trip, as expected by FIPS 140-3 for key generation.
    /// </summary>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    private static void PairwiseConsistencyTest(MlKemParams p, ReadOnlySpan<byte> ek, ReadOnlySpan<byte> dk)
    {
        Span<byte> m = stackalloc byte[MlKemParams.EncapsSeedBytes];
        GenerateRandomSeed(m);

        byte[] ct = new byte[p.CiphertextBytes];
        Span<byte> ss1 = stackalloc byte[MlKemParams.SharedSecretBytes];
        Span<byte> ss2 = stackalloc byte[MlKemParams.SharedSecretBytes];

        Encaps(p, ek, m, ct, ss1);
        Decaps(p, dk, ct, ss2);

        bool consistent = CryptographicOperations.FixedTimeEquals(ss1, ss2);

        CryptographicOperations.ZeroMemory(m);
        CryptographicOperations.ZeroMemory(ss1);
        CryptographicOperations.ZeroMemory(ss2);

        if (!consistent)
        {
            throw new OS.CryptographicException("ML-KEM key generation failed the pairwise consistency test.");
        }
    }

    /// <summary>
    /// Performs the FIPS 203 §7.2 encapsulation key check (modulus check).
    /// </summary>
    /// <remarks>
    /// Every 12-bit coefficient of ByteDecode₁₂(ek) must be less than q, i.e. the key
    /// must round-trip through ByteDecode₁₂ ∘ ByteEncode₁₂ unchanged.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="ek">The encapsulation key (must already be length-checked).</param>
    /// <returns>True if the key passes the modulus check.</returns>
    public static bool IsValidEncapsulationKey(MlKemParams p, ReadOnlySpan<byte> ek)
    {
        ReadOnlySpan<byte> encoded = ek.Slice(0, p.PolyVecEncodedBytes);
        for (int i = 0; i < encoded.Length; i += 3)
        {
            int b1 = encoded[i + 1];
            int c0 = (encoded[i] | (b1 << 8)) & 0xFFF;
            int c1 = ((b1 >> 4) | (encoded[i + 2] << 4)) & 0xFFF;
            if (c0 >= MlKemParams.Q || c1 >= MlKemParams.Q)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Performs the FIPS 203 §7.3 decapsulation key hash check.
    /// </summary>
    /// <remarks>
    /// The hash H(ekPKE) stored in the decapsulation key must match a freshly
    /// computed hash of the embedded encapsulation key.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="dk">The decapsulation key (must already be length-checked).</param>
    /// <returns>True if the key passes the hash check.</returns>
    public static bool IsValidDecapsulationKey(MlKemParams p, ReadOnlySpan<byte> dk)
    {
        ReadOnlySpan<byte> ekPke = dk.Slice(p.PolyVecEncodedBytes, p.EncapsulationKeyBytes);
        ReadOnlySpan<byte> h = dk.Slice(p.PolyVecEncodedBytes + p.EncapsulationKeyBytes, 32);

        Span<byte> computed = stackalloc byte[32];
        HashH(ekPke, computed);
        return CryptographicOperations.FixedTimeEquals(computed, h);
    }

    /// <summary>
    /// ML-KEM.Encaps: Encapsulates a shared secret.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 17. Given the encapsulation key and a random message m,
    /// produces a ciphertext and shared secret.
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="ek">The encapsulation key (384·k + 32 bytes).</param>
    /// <param name="m">The 32-byte random message seed.</param>
    /// <param name="ciphertext">Output: the ciphertext.</param>
    /// <param name="sharedSecret">Output: the 32-byte shared secret.</param>
    public static void Encaps(MlKemParams p, ReadOnlySpan<byte> ek, ReadOnlySpan<byte> m,
                              Span<byte> ciphertext, Span<byte> sharedSecret)
    {
        // (K, r) = G(m ‖ H(ek))
        Span<byte> hEk = stackalloc byte[32];
        HashH(ek.Slice(0, p.EncapsulationKeyBytes), hEk);

        Span<byte> gInput = stackalloc byte[64];
        m.Slice(0, 32).CopyTo(gInput);
        hEk.CopyTo(gInput.Slice(32));

        Span<byte> gOutput = stackalloc byte[64];
        HashG(gInput, gOutput);
        ReadOnlySpan<byte> K = gOutput.Slice(0, 32);
        ReadOnlySpan<byte> r = gOutput.Slice(32, 32);

        // c = K-PKE.Encrypt(ek, m, r)
        KPkeEncrypt(p, ek, m, r, ciphertext);

        // Return K
        K.CopyTo(sharedSecret);

        CryptographicOperations.ZeroMemory(gInput);
        CryptographicOperations.ZeroMemory(gOutput);
    }

    /// <summary>
    /// ML-KEM.Decaps: Decapsulates a shared secret with implicit rejection.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 18. Given the decapsulation key and ciphertext, recovers
    /// the shared secret. If decapsulation fails, returns a pseudorandom value
    /// derived from the ciphertext and secret seed z (implicit rejection).
    /// </remarks>
    /// <param name="p">The ML-KEM parameter set.</param>
    /// <param name="dk">The decapsulation key (768·k + 96 bytes).</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="sharedSecret">Output: the 32-byte shared secret.</param>
    public static void Decaps(MlKemParams p, ReadOnlySpan<byte> dk, ReadOnlySpan<byte> ciphertext,
                              Span<byte> sharedSecret)
    {
        // Parse dk = dkPKE ‖ ekPKE ‖ h ‖ z
        ReadOnlySpan<byte> dkPke = dk.Slice(0, p.PolyVecEncodedBytes);
        int offset = p.PolyVecEncodedBytes;
        ReadOnlySpan<byte> ekPke = dk.Slice(offset, p.EncapsulationKeyBytes);
        offset += p.EncapsulationKeyBytes;
        ReadOnlySpan<byte> h = dk.Slice(offset, 32);
        offset += 32;
        ReadOnlySpan<byte> z = dk.Slice(offset, 32);

        // m' = K-PKE.Decrypt(dkPKE, c)
        Span<byte> mPrime = stackalloc byte[32];
        KPkeDecrypt(p, dkPke, ciphertext, mPrime);

        // (K', r') = G(m' ‖ h)
        Span<byte> gInput = stackalloc byte[64];
        mPrime.CopyTo(gInput);
        h.CopyTo(gInput.Slice(32));

        Span<byte> gOutput = stackalloc byte[64];
        HashG(gInput, gOutput);
        ReadOnlySpan<byte> kPrime = gOutput.Slice(0, 32);
        ReadOnlySpan<byte> rPrime = gOutput.Slice(32, 32);

        // c' = K-PKE.Encrypt(ekPKE, m', r')
        byte[] cPrime = new byte[p.CiphertextBytes];
        KPkeEncrypt(p, ekPke, mPrime, rPrime, cPrime);

        // K̄ = J(z ‖ c)
        Span<byte> kBar = stackalloc byte[32];
        HashJ(z, ciphertext.Slice(0, p.CiphertextBytes), kBar);

        // If c == c': return K'; else return K̄ (implicit rejection).
        // The comparison result stays an integer mask end-to-end; converting to bool
        // would reintroduce a secret-dependent branch.
        int mask = CryptographicOperations.FixedTimeEqualsMask(
            ciphertext.Slice(0, p.CiphertextBytes),
            cPrime.AsSpan(0, p.CiphertextBytes));

        // Constant-time select: K = mask all-ones ? K' : K̄
        ConstantTimeSelect(sharedSecret, kPrime, kBar, mask);

        CryptographicOperations.ZeroMemory(mPrime);
        CryptographicOperations.ZeroMemory(gInput);
        CryptographicOperations.ZeroMemory(gOutput);
        CryptographicOperations.ZeroMemory(kBar);
        CryptographicOperations.ZeroMemory(cPrime);
    }

    // ========================================================================
    // Hash Helper Functions — FIPS 203 §4.1
    // ========================================================================

    /// <summary>
    /// H(input) = SHA3-256(input).
    /// </summary>
    private static void HashH(ReadOnlySpan<byte> input, Span<byte> output)
    {
        using var sha = SHA3_256.Create();
        sha.TryComputeHash(input, output.Slice(0, 32), out _);
    }

    /// <summary>
    /// G(input) = SHA3-512(input), producing 64 bytes.
    /// </summary>
    private static void HashG(ReadOnlySpan<byte> input, Span<byte> output)
    {
        using var sha = SHA3_512.Create();
        sha.TryComputeHash(input, output.Slice(0, 64), out _);
    }

    /// <summary>
    /// J(z ‖ c) = SHAKE256(z ‖ c, 32). Implicit rejection PRF.
    /// </summary>
    private static void HashJ(ReadOnlySpan<byte> z, ReadOnlySpan<byte> c, Span<byte> output)
    {
        using var shake = Shake256.Create(32);
        shake.Absorb(z);
        shake.Absorb(c);
        shake.Squeeze(output.Slice(0, 32));
    }

    /// <summary>
    /// PRF(seed, nonce) = SHAKE256(seed ‖ nonce, len) for CBD sampling.
    /// </summary>
    private static void Prf(ReadOnlySpan<byte> seed, byte nonce, Span<byte> output)
    {
        using var shake = Shake256.Create(output.Length);
        shake.Absorb(seed);
        ReadOnlySpan<byte> n = stackalloc byte[] { nonce };
        shake.Absorb(n);
        shake.Squeeze(output);
    }

    // ========================================================================
    // Internal Helpers
    // ========================================================================

    /// <summary>
    /// Samples a polynomial using CBD from PRF output.
    /// </summary>
    private static void SampleCbd(ReadOnlySpan<byte> seed, byte nonce, int eta, short[] coeffs)
    {
        int prfBytes = 64 * eta;
        byte[] prfOutput = new byte[prfBytes];
        Prf(seed, nonce, prfOutput);
        Cbd.Sample(prfOutput, eta, coeffs);
        CryptographicOperations.ZeroMemory(prfOutput);
    }

    /// <summary>
    /// Generates the k × k matrix Â from seed ρ using SHAKE128 (SampleNTT).
    /// </summary>
    private static short[][][] GenerateMatrix(int k, ReadOnlySpan<byte> rho)
    {
        var mat = new short[k][][];
        Span<byte> seed = stackalloc byte[34];
        rho.CopyTo(seed);

        for (int i = 0; i < k; i++)
        {
            mat[i] = new short[k][];
            for (int j = 0; j < k; j++)
            {
                mat[i][j] = new short[MlKemParams.N];
                seed[32] = (byte)j;
                seed[33] = (byte)i;
                Poly.SampleNtt(seed, mat[i][j]);
            }
        }

        return mat;
    }

    /// <summary>
    /// Constant-time conditional select: output = mask all-ones ? a : b.
    /// </summary>
    /// <param name="output">The destination buffer.</param>
    /// <param name="a">Value selected when <paramref name="mask"/> is -1.</param>
    /// <param name="b">Value selected when <paramref name="mask"/> is 0.</param>
    /// <param name="mask">-1 (all bits set) or 0, e.g. from <see cref="CryptographicOperations.FixedTimeEqualsMask"/>.</param>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private static void ConstantTimeSelect(Span<byte> output, ReadOnlySpan<byte> a, ReadOnlySpan<byte> b, int mask)
    {
        byte m = unchecked((byte)mask);
        for (int i = 0; i < output.Length; i++)
        {
            output[i] = (byte)((a[i] & m) | (b[i] & ~m));
        }
    }

    /// <summary>
    /// Generates a random seed using the OS cryptographic random number generator.
    /// </summary>
    /// <param name="output">The buffer to fill with random bytes.</param>
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
    internal static void Zero(short[] poly)
    {
        Array.Clear(poly, 0, poly.Length);
    }

    /// <summary>
    /// Clears a secret polynomial vector in a way that's not subject to compiler optimizations.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Zero(short[][] vec)
    {
        for (int i = 0; i < vec.Length; i++)
        {
            Array.Clear(vec[i], 0, vec[i].Length);
        }
    }
}
