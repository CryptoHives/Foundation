// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MLDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;

/// <summary>
/// Known-answer tests for ML-DSA (FIPS 204) using official NIST ACVP test vectors.
/// </summary>
/// <remarks>
/// <para>
/// Vectors come from the NIST ACVP-Server validation files (gen-val/json-files/
/// ML-DSA-keyGen-FIPS204, ML-DSA-sigGen-FIPS204 and ML-DSA-sigVer-FIPS204,
/// https://github.com/usnistgov/ACVP-Server) and are loaded by <see cref="MLDsaAcvpVectors"/>
/// from an embedded, gzip-compressed data file. Every test case is named after the parameter
/// set and the original <c>tcId</c>, so a failure points straight back at the NIST source.
/// </para>
/// <para>
/// Covers key generation, deterministic and hedged signing (byte-exact signatures), and
/// verification including the modified commitment/z/hint/message rejection cases, for all
/// parameter sets — external interface, pure ML-DSA (no pre-hash, no external μ).
/// </para>
/// <para>
/// Each operation is exercised twice where the API allows it: once through the stateless
/// <see cref="IDsa"/> interface and once through the key-holding <see cref="MLDsa"/> API that
/// mirrors <c>System.Security.Cryptography.MLDsa</c>. The one asymmetry is deliberate and
/// called out on <see cref="SigGen_AcvpSignatureVerifies_MLDsaApi"/>.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLDsaAcvpTests
{
    // ========================================================================
    // Key generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector(string parameterSet, int tcId, string seedHex, string pkHex, string skHex)
    {
        using IDsa dsa = CreateDsa(parameterSet);

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(FromHex(seedHex), pk, sk);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(pk, Is.EqualTo(FromHex(pkHex)), $"{parameterSet} tcId {tcId}: public key mismatch.");
            Assert.That(sk, Is.EqualTo(FromHex(skHex)), $"{parameterSet} tcId {tcId}: secret key mismatch.");
        }
    }

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector_MLDsaApi(string parameterSet, int tcId, string seedHex, string pkHex, string skHex)
    {
        // The pairwise consistency test is skipped here: it signs and verifies a message, which
        // for ML-DSA is a rejection loop and by far the dominant cost of expanding a seed. The
        // ACVP vector is a stronger check than the round trip, and the consistency test has its
        // own coverage in MLDsaApiTests.
        using var dsa = MLDsa.ImportMLDsaPrivateSeed(
            AlgorithmFor(parameterSet), FromHex(seedHex), pairwiseConsistencyTest: false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.ExportMLDsaPublicKey(), Is.EqualTo(FromHex(pkHex)),
                $"{parameterSet} tcId {tcId}: public key mismatch.");
            Assert.That(dsa.ExportMLDsaPrivateKey(), Is.EqualTo(FromHex(skHex)),
                $"{parameterSet} tcId {tcId}: private key mismatch.");
            Assert.That(dsa.ExportMLDsaPrivateSeed(), Is.EqualTo(FromHex(seedHex)),
                $"{parameterSet} tcId {tcId}: the seed must survive the round trip.");
        }
    }

    // ========================================================================
    // Signature generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.SigGenDeterministic))]
    public void SigGenDeterministic_MatchesAcvpVector(string parameterSet, int tcId, string skHex, string messageHex, string contextHex, string signatureHex)
    {
        using IDsa dsa = CreateDsa(parameterSet);

        byte[] signature = new byte[dsa.SignatureSizeBytes];
        dsa.SignDeterministic(FromHex(skHex), FromHex(messageHex), FromHex(contextHex), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)), $"{parameterSet} tcId {tcId}: signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.SigGenHedged))]
    public void SigGenHedged_MatchesAcvpVector(string parameterSet, int tcId, string skHex, string messageHex, string contextHex, string rndHex, string signatureHex)
    {
        // The hedged variant is exercised through the internal interface so the
        // ACVP-provided randomness can be injected.
        MLDsaParams p = ParamsFor(parameterSet);

        byte[] context = FromHex(contextHex);
        byte[] prefix = new byte[2 + context.Length];
        MLDsaCore.BuildExternalPrefix(context, prefix);

        byte[] signature = new byte[p.SignatureBytes];
        MLDsaCore.Sign(p, FromHex(skHex), prefix, FromHex(messageHex), FromHex(rndHex), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)), $"{parameterSet} tcId {tcId}: signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.SigGen))]
    public void SigGen_AcvpSignatureVerifies_MLDsaApi(string parameterSet, int tcId, string skHex, string messageHex, string contextHex, string signatureHex)
    {
        // This test verifies the ACVP signature rather than reproducing it, and that is a
        // deliberate limit rather than a gap in coverage. Reproducing a sigGen vector byte for
        // byte needs either deterministic signing (rnd = 0³²) or an injected rnd, and MLDsa
        // signs hedged-only — matching System.Security.Cryptography.MLDsa, which exposes no
        // deterministic mode either. Byte-exactness therefore lives on the IDsa path above;
        // what this adds is that the key-holding API agrees with NIST about which signatures
        // are valid, over a key imported from an expanded private key.
        byte[] message = FromHex(messageHex);
        byte[] context = FromHex(contextHex);

        using var dsa = MLDsa.ImportMLDsaPrivateKey(AlgorithmFor(parameterSet), FromHex(skHex));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.VerifyData(message, FromHex(signatureHex), context), Is.True,
                $"{parameterSet} tcId {tcId}: the ACVP signature must verify.");

            // And a signature this key produces itself round-trips over the same input.
            Assert.That(dsa.VerifyData(message, dsa.SignData(message, context), context), Is.True,
                $"{parameterSet} tcId {tcId}: freshly signed data must verify.");
        }
    }

    // ========================================================================
    // Signature verification
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.SigVer))]
    public void SigVer_MatchesAcvpVector(string parameterSet, int tcId, string reason, bool expectedValid,
        string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        using IDsa dsa = CreateDsa(parameterSet);

        bool valid = dsa.Verify(FromHex(pkHex), FromHex(messageHex), FromHex(contextHex), FromHex(signatureHex));

        Assert.That(valid, Is.EqualTo(expectedValid), $"{parameterSet} tcId {tcId} ({reason}): verification result mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaAcvpVectors), nameof(MLDsaAcvpVectors.SigVer))]
    public void SigVer_MatchesAcvpVector_MLDsaApi(string parameterSet, int tcId, string reason, bool expectedValid,
        string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        using var verifier = MLDsa.ImportMLDsaPublicKey(AlgorithmFor(parameterSet), FromHex(pkHex));

        bool valid = verifier.VerifyData(FromHex(messageHex), FromHex(signatureHex), FromHex(contextHex));

        Assert.That(valid, Is.EqualTo(expectedValid), $"{parameterSet} tcId {tcId} ({reason}): verification result mismatch.");
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static IDsa CreateDsa(string parameterSet) => parameterSet switch {
        "ML-DSA-44" => MLDsa44.Create(),
        "ML-DSA-65" => MLDsa65.Create(),
        "ML-DSA-87" => MLDsa87.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    private static MLDsaAlgorithm AlgorithmFor(string parameterSet) => parameterSet switch {
        "ML-DSA-44" => MLDsaAlgorithm.MLDsa44,
        "ML-DSA-65" => MLDsaAlgorithm.MLDsa65,
        "ML-DSA-87" => MLDsaAlgorithm.MLDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    private static MLDsaParams ParamsFor(string parameterSet) => parameterSet switch {
        "ML-DSA-44" => MLDsaParams.MLDsa44,
        "ML-DSA-65" => MLDsaParams.MLDsa65,
        "ML-DSA-87" => MLDsaParams.MLDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    private static byte[] FromHex(string hex) => MLDsaAcvpVectors.FromHex(hex);
}
