// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Buffers;
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
internal static class MLKemCore
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
    [SkipLocalsInit]
    public static void KPkeKeyGen(MLKemParams p, ReadOnlySpan<byte> d, Span<byte> ekPke, Span<byte> dkPke)
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

        // One pooled rental carved into every working vector this algorithm needs, so the
        // whole of K-PKE key generation costs no allocation once the pool is warm.
        short[] rented = ArrayPool<short>.Shared.Rent(PolyVec.MatrixLength(k) + (3 * PolyVec.VectorLength(k)));
        Shake256 prf = HashAlgorithmPool<Shake256>.Shared.Get();
        try
        {
            Span<short> scratch = rented;
            Span<short> aHat = Take(ref scratch, PolyVec.MatrixLength(k));
            Span<short> s = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> e = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> tHat = Take(ref scratch, PolyVec.VectorLength(k));

            // Generate matrix Â in NTT domain
            GenerateMatrix(aHat, k, rho);

            // Sample secret vector s
            byte nonce = 0;
            for (int i = 0; i < k; i++)
            {
                SampleCbd(prf, sigma, nonce++, p.Eta1, PolyVec.Poly(s, i));
            }

            // Sample error vector e
            for (int i = 0; i < k; i++)
            {
                SampleCbd(prf, sigma, nonce++, p.Eta1, PolyVec.Poly(e, i));
            }

            // NTT(s), NTT(e)
            PolyVec.Ntt(s, k);
            PolyVec.Ntt(e, k);
            PolyVec.Reduce(s, k);

            // t̂ = Â ◦ ŝ + ê
            PolyVec.MatrixVectorMultiply(tHat, aHat, s, k, transpose: false);
            PolyVec.ToMontgomery(tHat, k);
            PolyVec.Add(tHat, tHat, e, k);
            PolyVec.Reduce(tHat, k);

            // ekPKE = ByteEncode₁₂(t̂) ‖ ρ
            PolyVec.Normalize(tHat, k);
            PolyVec.ToBytes(tHat, k, ekPke.Slice(0, p.PolyVecEncodedBytes));
            rho.CopyTo(ekPke.Slice(p.PolyVecEncodedBytes));

            // dkPKE = ByteEncode₁₂(ŝ)
            PolyVec.Normalize(s, k);
            PolyVec.ToBytes(s, k, dkPke.Slice(0, p.PolyVecEncodedBytes));

            CryptographicOperations.ZeroMemory(gInput);
            CryptographicOperations.ZeroMemory(gOutput);
        }
        finally
        {
            // clearArray: true wipes s and e — and every other working vector — before the
            // buffer can be handed to an unrelated caller.
            ArrayPool<short>.Shared.Return(rented, clearArray: true);
            HashAlgorithmPool<Shake256>.Shared.Return(prf);
        }
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
    public static void KPkeEncrypt(MLKemParams p, ReadOnlySpan<byte> ekPke, ReadOnlySpan<byte> msg,
                                   ReadOnlySpan<byte> r, Span<byte> ciphertext)
    {
        int k = p.K;

        short[] rented = ArrayPool<short>.Shared.Rent(
            PolyVec.MatrixLength(k) + (4 * PolyVec.VectorLength(k)) + (3 * MLKemParams.N));
        Shake256 prf = HashAlgorithmPool<Shake256>.Shared.Get();
        try
        {
            Span<short> scratch = rented;
            Span<short> tHat = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> aHat = Take(ref scratch, PolyVec.MatrixLength(k));
            Span<short> rv = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> e1 = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> u = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> e2 = Take(ref scratch, MLKemParams.N);
            Span<short> v = Take(ref scratch, MLKemParams.N);
            Span<short> msgPoly = Take(ref scratch, MLKemParams.N);

            // Decode t̂ from ekPKE
            PolyVec.FromBytes(ekPke.Slice(0, p.PolyVecEncodedBytes), tHat, k);
            ReadOnlySpan<byte> rho = ekPke.Slice(p.PolyVecEncodedBytes, 32);

            // Regenerate Â from ρ
            GenerateMatrix(aHat, k, rho);

            // Sample r vector, e1 vector, and e2 polynomial
            byte nonce = 0;
            for (int i = 0; i < k; i++)
            {
                SampleCbd(prf, r, nonce++, p.Eta1, PolyVec.Poly(rv, i));
            }

            for (int i = 0; i < k; i++)
            {
                SampleCbd(prf, r, nonce++, p.Eta2, PolyVec.Poly(e1, i));
            }

            SampleCbd(prf, r, nonce, p.Eta2, e2);

            // NTT(r)
            PolyVec.Ntt(rv, k);

            // u = NTT⁻¹(Âᵀ ◦ r̂) + e₁
            PolyVec.MatrixVectorMultiply(u, aHat, rv, k, transpose: true);
            PolyVec.InverseNtt(u, k);
            PolyVec.Add(u, u, e1, k);
            PolyVec.Reduce(u, k);

            // v = NTT⁻¹(t̂ᵀ ◦ r̂) + e₂ + Decompress₁(ByteDecode₁(m))
            // Rented scratch arrives dirty and InnerProduct accumulates, so the accumulator
            // must start at zero. Every other carved span above is fully written before it is
            // read; these two are the exceptions.
            v.Clear();
            PolyVec.InnerProduct(v, tHat, rv, k);
            Ntt.Inverse(v);

            Poly.FromMessage(msg, msgPoly);

            Poly.Add(v, v, e2);
            Poly.Add(v, v, msgPoly);
            Poly.Reduce(v);

            // c₁ = ByteEncode_du(Compress_du(u))
            PolyVec.Normalize(u, k);
            PolyVec.CompressAndEncode(u, k, p.Du, ciphertext.Slice(0, p.PolyVecCompressedBytes));

            // c₂ = ByteEncode_dv(Compress_dv(v))
            Poly.Normalize(v);
            Compress.CompressPoly(v, p.Dv);
            Encode.ByteEncodeD(v, p.Dv, ciphertext.Slice(p.PolyVecCompressedBytes, p.PolyCompressedBytes));

        }
        finally
        {
            ArrayPool<short>.Shared.Return(rented, clearArray: true);
            HashAlgorithmPool<Shake256>.Shared.Return(prf);
        }
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
    public static void KPkeDecrypt(MLKemParams p, ReadOnlySpan<byte> dkPke, ReadOnlySpan<byte> ciphertext,
                                   Span<byte> msg)
    {
        int k = p.K;

        short[] rented = ArrayPool<short>.Shared.Rent((2 * PolyVec.VectorLength(k)) + (2 * MLKemParams.N));
        try
        {
            Span<short> scratch = rented;
            Span<short> u = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> sHat = Take(ref scratch, PolyVec.VectorLength(k));
            Span<short> v = Take(ref scratch, MLKemParams.N);
            Span<short> w = Take(ref scratch, MLKemParams.N);

            // Decode u from c₁
            PolyVec.DecodeAndDecompress(ciphertext.Slice(0, p.PolyVecCompressedBytes), p.Du, u, k);

            // Decode v from c₂
            Encode.ByteDecodeD(ciphertext.Slice(p.PolyVecCompressedBytes, p.PolyCompressedBytes), p.Dv, v);
            Compress.DecompressPoly(v, p.Dv);

            // Decode ŝ from dkPKE
            PolyVec.FromBytes(dkPke.Slice(0, p.PolyVecEncodedBytes), sHat, k);

            // NTT(u)
            PolyVec.Ntt(u, k);

            // w = NTT⁻¹(ŝᵀ ◦ û)
            // See KPkeEncrypt: accumulator, so it must start zeroed.
            w.Clear();
            PolyVec.InnerProduct(w, sHat, u, k);
            Ntt.Inverse(w);

            // m = ByteEncode₁(Compress₁(v − w))
            Poly.Sub(v, v, w);
            Poly.Reduce(v);
            Poly.Normalize(v);
            Poly.ToMessage(v, msg);

        }
        finally
        {
            ArrayPool<short>.Shared.Return(rented, clearArray: true);
        }
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
    public static void KeyGen(MLKemParams p, ReadOnlySpan<byte> seed, Span<byte> ek, Span<byte> dk)
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
    [SkipLocalsInit]
    private static void PairwiseConsistencyTest(MLKemParams p, ReadOnlySpan<byte> ek, ReadOnlySpan<byte> dk)
    {
        Span<byte> m = stackalloc byte[MLKemParams.EncapsSeedBytes];
        GenerateRandomSeed(m);

        Span<byte> ct = stackalloc byte[MLKemParams.MaxCiphertextBytes];
        ct = ct.Slice(0, p.CiphertextBytes);
        Span<byte> ss1 = stackalloc byte[MLKemParams.SharedSecretBytes];
        Span<byte> ss2 = stackalloc byte[MLKemParams.SharedSecretBytes];

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
    public static bool IsValidEncapsulationKey(MLKemParams p, ReadOnlySpan<byte> ek)
    {
        ReadOnlySpan<byte> encoded = ek.Slice(0, p.PolyVecEncodedBytes);
        for (int i = 0; i < encoded.Length; i += 3)
        {
            int b1 = encoded[i + 1];
            int c0 = (encoded[i] | (b1 << 8)) & 0xFFF;
            int c1 = ((b1 >> 4) | (encoded[i + 2] << 4)) & 0xFFF;
            if (c0 >= MLKemParams.Q || c1 >= MLKemParams.Q)
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
    public static bool IsValidDecapsulationKey(MLKemParams p, ReadOnlySpan<byte> dk)
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
    [SkipLocalsInit]
    public static void Encaps(MLKemParams p, ReadOnlySpan<byte> ek, ReadOnlySpan<byte> m,
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
    [SkipLocalsInit]
    public static void Decaps(MLKemParams p, ReadOnlySpan<byte> dk, ReadOnlySpan<byte> ciphertext,
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
        Span<byte> cPrime = stackalloc byte[MLKemParams.MaxCiphertextBytes];
        cPrime = cPrime.Slice(0, p.CiphertextBytes);
        KPkeEncrypt(p, ekPke, mPrime, rPrime, cPrime);

        // K̄ = J(z ‖ c)
        Span<byte> kBar = stackalloc byte[32];
        HashJ(z, ciphertext.Slice(0, p.CiphertextBytes), kBar);

        // If c == c': return K'; else return K̄ (implicit rejection).
        // The comparison result stays an integer mask end-to-end; converting to bool
        // would reintroduce a secret-dependent branch.
        int mask = CryptographicOperations.FixedTimeEqualsMask(
            ciphertext.Slice(0, p.CiphertextBytes),
            cPrime);

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
        SHA3_256 sha = HashAlgorithmPool<SHA3_256>.Shared.Get();
        try
        {
            sha.TryComputeHash(input, output.Slice(0, 32), out _);
        }
        finally
        {
            HashAlgorithmPool<SHA3_256>.Shared.Return(sha);
        }
    }

    /// <summary>
    /// G(input) = SHA3-512(input), producing 64 bytes.
    /// </summary>
    private static void HashG(ReadOnlySpan<byte> input, Span<byte> output)
    {
        SHA3_512 sha = HashAlgorithmPool<SHA3_512>.Shared.Get();
        try
        {
            sha.TryComputeHash(input, output.Slice(0, 64), out _);
        }
        finally
        {
            HashAlgorithmPool<SHA3_512>.Shared.Return(sha);
        }
    }

    /// <summary>
    /// J(z ‖ c) = SHAKE256(z ‖ c, 32). Implicit rejection PRF.
    /// </summary>
    private static void HashJ(ReadOnlySpan<byte> z, ReadOnlySpan<byte> c, Span<byte> output)
    {
        Shake256 shake = HashAlgorithmPool<Shake256>.Shared.Get();
        try
        {
            shake.Absorb(z);
            shake.Absorb(c);
            shake.Squeeze(output.Slice(0, 32));
        }
        finally
        {
            // Returning resets the sponge, erasing the state derived from z.
            HashAlgorithmPool<Shake256>.Shared.Return(shake);
        }
    }

    /// <summary>
    /// PRF(seed, nonce) = SHAKE256(seed ‖ nonce, len) for CBD sampling.
    /// </summary>
    private static void Prf(Shake256 shake, ReadOnlySpan<byte> seed, byte nonce, Span<byte> output)
    {
        shake.Reset();
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
    /// <remarks>
    /// Internal rather than private for the same reason as <see cref="GenerateMatrix"/>: the
    /// benchmark suite measures it directly. Measuring it against <c>Cbd.Eta2</c> alone is
    /// what separates the PRF cost from the bit-extraction cost, which is the question that
    /// decides whether vectorizing the latter is worth doing.
    /// </remarks>
    [SkipLocalsInit]
    internal static void SampleCbd(Shake256 shake, ReadOnlySpan<byte> seed, byte nonce, int eta, Span<short> coeffs)
    {
        // 64·η is 128 or 192 bytes — small, fixed, and never escapes, so it lives on the stack
        // rather than costing an allocation on every one of the 2k or 2k+1 calls per operation.
        Span<byte> prfOutput = stackalloc byte[64 * MLKemParams.MaxEta];
        prfOutput = prfOutput.Slice(0, 64 * eta);

        Prf(shake, seed, nonce, prfOutput);
        Cbd.Sample(prfOutput, eta, coeffs);
        CryptographicOperations.ZeroMemory(prfOutput);
    }

    /// <summary>
    /// Generates the k × k matrix Â from seed ρ using SHAKE128 (SampleNTT).
    /// </summary>
    /// <remarks>
    /// Internal rather than private so the benchmark suite can measure this directly. It is
    /// a meaningful share of both the time and the allocation of every ML-KEM operation, and
    /// measuring a copy of it in the test project would stop tracking the real thing the
    /// moment either changed.
    /// </remarks>
    [SkipLocalsInit]
    internal static void GenerateMatrix(Span<short> mat, int k, ReadOnlySpan<byte> rho)
    {
        Span<byte> seed = stackalloc byte[34];
        rho.CopyTo(seed);

        // One XOF for the whole matrix. SampleNtt resets it per entry, so the k² entries cost
        // one instance instead of k² — measurably ~20% of an operation's allocation.
        Shake128 xof = HashAlgorithmPool<Shake128>.Shared.Get();
        try
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    seed[32] = (byte)j;
                    seed[33] = (byte)i;
                    Poly.SampleNtt(xof, seed, PolyVec.Poly(mat, (i * k) + j));
                }
            }
        }
        finally
        {
            HashAlgorithmPool<Shake128>.Shared.Return(xof);
        }
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
    /// Carves the next <paramref name="length"/> values off a pooled scratch buffer.
    /// </summary>
    /// <param name="scratch">The remaining scratch, advanced past the returned slice.</param>
    /// <param name="length">The number of values to take.</param>
    /// <returns>The carved slice.</returns>
    /// <remarks>
    /// One pooled rental carved into named pieces, rather than a rental each: fewer pool
    /// round-trips, and returning the single buffer with <c>clearArray: true</c> wipes every
    /// secret it held in one step.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Span<short> Take(ref Span<short> scratch, int length)
    {
        Span<short> taken = scratch.Slice(0, length);
        scratch = scratch.Slice(length);
        return taken;
    }

    /// <summary>
    /// Clears a secret polynomial in a way that's not subject to compiler optimizations.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static void Zero(Span<short> poly)
    {
        poly.Clear();
    }
}
