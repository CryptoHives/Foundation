// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Known-answer tests for SLH-DSA (FIPS 205) using official NIST ACVP test vectors.
/// </summary>
/// <remarks>
/// <para>
/// Vectors come from the NIST ACVP-Server validation files (gen-val/json-files/
/// SLH-DSA-keyGen-FIPS205, SLH-DSA-sigGen-FIPS205 and SLH-DSA-sigVer-FIPS205,
/// https://github.com/usnistgov/ACVP-Server) and are loaded by <see cref="SlhDsaAcvpVectors"/>
/// from a gzip-compressed data file. Every test case is named after the parameter set and the
/// original <c>tcId</c>, so a failure points straight back at the NIST source.
/// </para>
/// <para>
/// Covers key generation, deterministic and hedged signing (byte-exact signatures), and
/// verification including the modified R/SIGFORS/SIGHT/message and wrong-length rejection
/// cases — external interface, pure SLH-DSA (no pre-hash, no internal interface).
/// </para>
/// <para>
/// Each operation is exercised twice where the API allows it: once through the internal
/// <see cref="SlhDsaCore"/> for byte-exactness, and once through the key-holding
/// <see cref="CH.SlhDsa"/> API that mirrors <c>System.Security.Cryptography.SlhDsa</c>. The one
/// asymmetry is deliberate and called out on <see cref="SigGen_AcvpSignatureVerifies_SlhDsaApi"/>.
/// </para>
/// <para>
/// The embedded set is stratified; see <see cref="SlhDsaAcvpVectors"/> for why, and for how to
/// run the complete set instead.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaAcvpTests
{
    // ========================================================================
    // Key generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector(string parameterSet, int tcId, string skSeedHex, string skPrfHex,
        string pkSeedHex, string pkHex, string skHex)
    {
        SlhDsaParams p = ParamsFor(parameterSet);

        byte[] pk = new byte[p.PublicKeyBytes];
        byte[] sk = new byte[p.SecretKeyBytes];
        SlhDsaCore.KeyGenFromSeeds(p, FromHex(skSeedHex), FromHex(skPrfHex), FromHex(pkSeedHex), pk, sk);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(pk, Is.EqualTo(FromHex(pkHex)), $"{parameterSet} tcId {tcId}: public key mismatch.");
            Assert.That(sk, Is.EqualTo(FromHex(skHex)), $"{parameterSet} tcId {tcId}: private key mismatch.");
        }
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector_SlhDsaApi(string parameterSet, int tcId, string skSeedHex, string skPrfHex,
        string pkSeedHex, string pkHex, string skHex)
    {
        // SLH-DSA has no seed-expanding import — the 4n-byte private key is the storage form —
        // so what the key-holding API adds here is that importing the ACVP private key exposes
        // the embedded public key, and that both export byte-exactly.
        using var dsa = CH.SlhDsa.ImportSlhDsaPrivateKey(AlgorithmFor(parameterSet), FromHex(skHex));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.ExportSlhDsaPublicKey(), Is.EqualTo(FromHex(pkHex)),
                $"{parameterSet} tcId {tcId}: public key mismatch.");
            Assert.That(dsa.ExportSlhDsaPrivateKey(), Is.EqualTo(FromHex(skHex)),
                $"{parameterSet} tcId {tcId}: private key must survive the round trip.");
        }
    }

    // ========================================================================
    // Signature generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.SigGenDeterministic))]
    public void SigGenDeterministic_MatchesAcvpVector(string parameterSet, int tcId, string skHex,
        string messageHex, string contextHex, string signatureHex)
    {
        SlhDsaParams p = ParamsFor(parameterSet);
        byte[] sk = FromHex(skHex);

        byte[] context = FromHex(contextHex);
        byte[] prefix = new byte[2 + context.Length];
        MLDsaCore.BuildExternalPrefix(context, prefix);

        // Deterministic signing uses opt_rand = PK.seed (embedded in sk at offset 2n).
        byte[] signature = new byte[p.SignatureBytes];
        SlhDsaCore.Sign(p, sk, prefix, FromHex(messageHex), sk.AsSpan(2 * p.N, p.N), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)), $"{parameterSet} tcId {tcId}: signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.SigGenHedged))]
    public void SigGenHedged_MatchesAcvpVector(string parameterSet, int tcId, string skHex,
        string messageHex, string contextHex, string additionalRandomnessHex, string signatureHex)
    {
        // The hedged variant is exercised through the internal interface so the
        // ACVP-provided opt_rand can be injected.
        SlhDsaParams p = ParamsFor(parameterSet);

        byte[] context = FromHex(contextHex);
        byte[] prefix = new byte[2 + context.Length];
        MLDsaCore.BuildExternalPrefix(context, prefix);

        byte[] signature = new byte[p.SignatureBytes];
        SlhDsaCore.Sign(p, FromHex(skHex), prefix, FromHex(messageHex), FromHex(additionalRandomnessHex), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)), $"{parameterSet} tcId {tcId}: signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.SigGen))]
    public void SigGen_AcvpSignatureVerifies_SlhDsaApi(string parameterSet, int tcId, string skHex,
        string messageHex, string contextHex, string signatureHex)
    {
        // This test verifies the ACVP signature rather than reproducing it, and that is a
        // deliberate limit rather than a gap in coverage. Reproducing a sigGen vector byte for
        // byte needs either deterministic signing (opt_rand = PK.seed) or an injected opt_rand,
        // and SlhDsa signs hedged-only — matching System.Security.Cryptography.SlhDsa, which
        // exposes no deterministic mode either. Byte-exactness therefore lives on the
        // SlhDsaCore path above; what this adds is that the key-holding API agrees with NIST
        // about which signatures are valid.
        byte[] message = FromHex(messageHex);
        byte[] context = FromHex(contextHex);

        using var dsa = CH.SlhDsa.ImportSlhDsaPrivateKey(AlgorithmFor(parameterSet), FromHex(skHex));

        Assert.That(dsa.VerifyData(message, FromHex(signatureHex), context), Is.True,
            $"{parameterSet} tcId {tcId}: the ACVP signature must verify.");
    }

    // ========================================================================
    // Signature verification
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.SigVer))]
    public void SigVer_MatchesAcvpVector(string parameterSet, int tcId, string reason, bool expectedValid,
        string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        SlhDsaParams p = ParamsFor(parameterSet);
        byte[] signature = FromHex(signatureHex);

        byte[] context = FromHex(contextHex);
        byte[] prefix = new byte[2 + context.Length];
        MLDsaCore.BuildExternalPrefix(context, prefix);

        // The core takes the signature as-is, so the wrong-length ACVP cases have to be
        // rejected here rather than inside it — that length check is the public API's job,
        // and SigVer_MatchesAcvpVector_SlhDsaApi below is what covers it.
        bool valid = signature.Length == p.SignatureBytes
            && SlhDsaCore.Verify(p, FromHex(pkHex), prefix, FromHex(messageHex), signature);

        Assert.That(valid, Is.EqualTo(expectedValid), $"{parameterSet} tcId {tcId} ({reason}): verification result mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaAcvpVectors), nameof(SlhDsaAcvpVectors.SigVer))]
    public void SigVer_MatchesAcvpVector_SlhDsaApi(string parameterSet, int tcId, string reason, bool expectedValid,
        string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        using var verifier = CH.SlhDsa.ImportSlhDsaPublicKey(AlgorithmFor(parameterSet), FromHex(pkHex));

        bool valid = verifier.VerifyData(FromHex(messageHex), FromHex(signatureHex), FromHex(contextHex));

        Assert.That(valid, Is.EqualTo(expectedValid), $"{parameterSet} tcId {tcId} ({reason}): verification result mismatch.");
    }

    // ========================================================================
    // Vector file
    // ========================================================================

    [Test]
    public void VectorFile_CoversAtLeastTheStratifiedSelection()
    {
        // An override is meant to add coverage. A truncated or half-written full file would
        // otherwise silently shrink the suite, and every ACVP test above would still pass.
        Assert.That(SlhDsaAcvpVectors.CaseCount, Is.GreaterThanOrEqualTo(SlhDsaAcvpVectors.StratifiedCaseCount),
            $"Loaded {SlhDsaAcvpVectors.CaseCount} cases from {SlhDsaAcvpVectors.Source}, fewer than the "
            + $"{SlhDsaAcvpVectors.StratifiedCaseCount} the embedded file carries.");
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static SlhDsaAlgorithm AlgorithmFor(string parameterSet)
        => SlhDsaAcvpVectors.AlgorithmFor(parameterSet);

    private static SlhDsaParams ParamsFor(string parameterSet)
        => SlhDsaAcvpVectors.AlgorithmFor(parameterSet).Parameters;

    private static byte[] FromHex(string hex) => SlhDsaAcvpVectors.FromHex(hex);
}
