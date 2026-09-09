// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Known-answer tests for HashSLH-DSA (FIPS 205 §10.2) using official NIST ACVP test vectors.
/// </summary>
/// <remarks>
/// <para>
/// Vectors come from the NIST ACVP-Server validation files (gen-val/json-files/
/// SLH-DSA-sigGen-FIPS205 and SLH-DSA-sigVer-FIPS205,
/// https://github.com/usnistgov/ACVP-Server), external interface, <c>preHash</c> groups, and are
/// loaded by <see cref="SlhDsaPreHashAcvpVectors"/> from a gzip-compressed data file. Every case
/// is named after its parameter set, pre-hash function and original <c>tcId</c>, so a failure
/// points straight back at the NIST source.
/// </para>
/// <para>
/// The digest PH(M) is recomputed from the vector's message with this library's own hash
/// implementations rather than taken from the file, so these tests also cross-check the
/// OID-to-hash binding end to end — a wrong OID table entry or a wrong SHAKE output length
/// fails here rather than silently signing the wrong prefix.
/// </para>
/// <para>
/// Each operation is exercised twice where the API allows it: once through the internal
/// <see cref="SlhDsaCore"/> for byte-exactness, and once through the key-holding
/// <see cref="CH.SlhDsa"/> API that mirrors <c>System.Security.Cryptography.SlhDsa</c>. The one
/// asymmetry is deliberate and called out on <see cref="SigGenPreHash_AcvpSignatureVerifies_SlhDsaApi"/>.
/// </para>
/// <para>
/// Cases for the <c>s</c> parameter sets are categorized <c>Slow</c> — signing with one is on the
/// order of a million hash invocations. They still run by default.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaPreHashAcvpTests
{
    // ========================================================================
    // Signature generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(SlhDsaPreHashAcvpVectors), nameof(SlhDsaPreHashAcvpVectors.SigGenDeterministic))]
    public void SigGenPreHashDeterministic_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string signatureHex)
    {
        SlhDsaParams p = PreHashTestUtil.SlhDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        // FIPS 205 fixes opt_rand to PK.seed for the deterministic variant, which sits at
        // offset 2n in the private key SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root.
        byte[] sk = FromHex(skHex);
        byte[] signature = new byte[p.SignatureBytes];
        SlhDsaCore.Sign(p, sk, prefix.AsSpan(0, prefixLength), digest, sk.AsSpan(2 * p.N, p.N), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}): signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaPreHashAcvpVectors), nameof(SlhDsaPreHashAcvpVectors.SigGenHedged))]
    public void SigGenPreHashHedged_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string additionalRandomnessHex, string signatureHex)
    {
        SlhDsaParams p = PreHashTestUtil.SlhDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        // The hedged variant draws opt_rand from the RNG, so the vector supplies it: only with
        // the ACVP randomness injected is a hedged signature reproducible byte for byte.
        byte[] signature = new byte[p.SignatureBytes];
        SlhDsaCore.Sign(p, FromHex(skHex), prefix.AsSpan(0, prefixLength), digest,
                        FromHex(additionalRandomnessHex), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}): signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaPreHashAcvpVectors), nameof(SlhDsaPreHashAcvpVectors.SigGen))]
    public void SigGenPreHash_AcvpSignatureVerifies_SlhDsaApi(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string signatureHex)
    {
        // The key-holding API signs hedged-only and draws its own randomness, so it cannot
        // reproduce a byte-exact ACVP signature. What it can do — and what matters for the
        // public surface — is verify the ACVP one, which is what this checks. Byte-exactness is
        // covered by the two tests above. Signing again here would double the cost of the
        // already-slow s sets for no extra coverage.
        using var dsa = CH.SlhDsa.ImportSlhDsaPrivateKey(
            PreHashTestUtil.SlhDsaAlgorithmFor(parameterSet), FromHex(skHex));

        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        Assert.That(dsa.VerifyPreHash(digest, FromHex(signatureHex), oid, FromHex(contextHex)), Is.True,
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}): the ACVP signature must verify.");
    }

    // ========================================================================
    // Signature verification
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(SlhDsaPreHashAcvpVectors), nameof(SlhDsaPreHashAcvpVectors.SigVer))]
    public void SigVerPreHash_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg, string reason,
        bool expectedValid, string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        SlhDsaParams p = PreHashTestUtil.SlhDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        byte[] signature = FromHex(signatureHex);

        // SlhDsaCore.Verify takes the signature as-is, so the length check that the public API
        // performs has to be spelled out here — two of the ACVP failure reasons are precisely a
        // signature that is too large or too small.
        bool valid = signature.Length == p.SignatureBytes
            && SlhDsaCore.Verify(p, FromHex(pkHex), prefix.AsSpan(0, prefixLength), digest, signature);

        Assert.That(valid, Is.EqualTo(expectedValid),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}, {reason}): verification result mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(SlhDsaPreHashAcvpVectors), nameof(SlhDsaPreHashAcvpVectors.SigVer))]
    public void SigVerPreHash_MatchesAcvpVector_SlhDsaApi(string parameterSet, int tcId, string hashAlg, string reason,
        bool expectedValid, string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        using var dsa = CH.SlhDsa.ImportSlhDsaPublicKey(
            PreHashTestUtil.SlhDsaAlgorithmFor(parameterSet), FromHex(pkHex));

        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        bool valid = dsa.VerifyPreHash(digest, FromHex(signatureHex), oid, FromHex(contextHex));

        Assert.That(valid, Is.EqualTo(expectedValid),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}, {reason}): verification result mismatch.");
    }

    // ========================================================================
    // Vector file
    // ========================================================================

    [Test]
    public void VectorFile_CoversAtLeastTheCommittedSelection()
    {
        // An override is meant to add coverage, never to remove it: a truncated or half-written
        // download must fail loudly here rather than quietly shrinking the suite.
        Assert.That(SlhDsaPreHashAcvpVectors.CaseCount,
            Is.GreaterThanOrEqualTo(SlhDsaPreHashAcvpVectors.StratifiedCaseCount),
            $"Loaded {SlhDsaPreHashAcvpVectors.CaseCount} cases from {SlhDsaPreHashAcvpVectors.Source}, "
            + $"fewer than the {SlhDsaPreHashAcvpVectors.StratifiedCaseCount} committed ones.");
    }

    private static byte[] FromHex(string hex) => PreHashTestUtil.FromHex(hex);
}
