// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MLDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Known-answer tests for HashML-DSA (FIPS 204 §5.4) using official NIST ACVP test vectors.
/// </summary>
/// <remarks>
/// <para>
/// Vectors come from the NIST ACVP-Server validation files (gen-val/json-files/
/// ML-DSA-sigGen-FIPS204 and ML-DSA-sigVer-FIPS204,
/// https://github.com/usnistgov/ACVP-Server), external interface, <c>preHash</c> groups, and are
/// loaded by <see cref="MLDsaPreHashAcvpVectors"/> from a gzip-compressed data file. Every case
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
/// <see cref="MLDsaCore"/> for byte-exactness, and once through the key-holding
/// <see cref="CH.MLDsa"/> API that mirrors <c>System.Security.Cryptography.MLDsa</c>. The one
/// asymmetry is deliberate and called out on <see cref="SigGenPreHash_AcvpSignatureVerifies_MLDsaApi"/>.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLDsaPreHashAcvpTests
{
    // ========================================================================
    // Signature generation
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(MLDsaPreHashAcvpVectors), nameof(MLDsaPreHashAcvpVectors.SigGenDeterministic))]
    public void SigGenPreHashDeterministic_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string signatureHex)
    {
        MLDsaParams p = PreHashTestUtil.MLDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        // FIPS 204 fixes rnd to zero for the deterministic variant.
        byte[] rnd = new byte[MLDsaParams.SignSeedBytes];
        byte[] signature = new byte[p.SignatureBytes];
        MLDsaCore.Sign(p, FromHex(skHex), prefix.AsSpan(0, prefixLength), digest, rnd, signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}): signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaPreHashAcvpVectors), nameof(MLDsaPreHashAcvpVectors.SigGenHedged))]
    public void SigGenPreHashHedged_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string rndHex, string signatureHex)
    {
        MLDsaParams p = PreHashTestUtil.MLDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        // The hedged variant draws rnd from the RNG, so the vector supplies it: only with the
        // ACVP randomness injected is a hedged signature reproducible byte for byte.
        byte[] signature = new byte[p.SignatureBytes];
        MLDsaCore.Sign(p, FromHex(skHex), prefix.AsSpan(0, prefixLength), digest, FromHex(rndHex), signature);

        Assert.That(signature, Is.EqualTo(FromHex(signatureHex)),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}): signature mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaPreHashAcvpVectors), nameof(MLDsaPreHashAcvpVectors.SigGen))]
    public void SigGenPreHash_AcvpSignatureVerifies_MLDsaApi(string parameterSet, int tcId, string hashAlg,
        string skHex, string messageHex, string contextHex, string signatureHex)
    {
        // The key-holding API signs hedged-only and draws its own randomness, so it cannot
        // reproduce a byte-exact ACVP signature. What it can do — and what matters for the
        // public surface — is verify the ACVP one and round-trip its own, which is what the two
        // assertions below check. Byte-exactness is covered by the two tests above.
        using var dsa = CH.MLDsa.ImportMLDsaPrivateKey(
            PreHashTestUtil.MLDsaAlgorithmFor(parameterSet), FromHex(skHex));

        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));
        byte[] context = FromHex(contextHex);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.VerifyPreHash(digest, FromHex(signatureHex), oid, context), Is.True,
                $"{parameterSet} tcId {tcId} (PH = {hashAlg}): the ACVP signature must verify.");

            byte[] ours = dsa.SignPreHash(digest, oid, context);
            Assert.That(dsa.VerifyPreHash(digest, ours, oid, context), Is.True,
                $"{parameterSet} tcId {tcId} (PH = {hashAlg}): our own signature must verify.");
        }
    }

    // ========================================================================
    // Signature verification
    // ========================================================================

    [Test]
    [TestCaseSource(typeof(MLDsaPreHashAcvpVectors), nameof(MLDsaPreHashAcvpVectors.SigVer))]
    public void SigVerPreHash_MatchesAcvpVector(string parameterSet, int tcId, string hashAlg, string reason,
        bool expectedValid, string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        MLDsaParams p = PreHashTestUtil.MLDsaParamsFor(parameterSet);
        (byte[] digest, string oid) = PreHashTestUtil.ComputeDigest(hashAlg, FromHex(messageHex));

        byte[] prefix = new byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(FromHex(contextHex), oid, prefix);

        byte[] signature = FromHex(signatureHex);

        // MLDsaCore.Verify takes the signature as-is, so the length check that the public API
        // performs has to be spelled out here.
        bool valid = signature.Length == p.SignatureBytes
            && MLDsaCore.Verify(p, FromHex(pkHex), prefix.AsSpan(0, prefixLength), digest, signature);

        Assert.That(valid, Is.EqualTo(expectedValid),
            $"{parameterSet} tcId {tcId} (PH = {hashAlg}, {reason}): verification result mismatch.");
    }

    [Test]
    [TestCaseSource(typeof(MLDsaPreHashAcvpVectors), nameof(MLDsaPreHashAcvpVectors.SigVer))]
    public void SigVerPreHash_MatchesAcvpVector_MLDsaApi(string parameterSet, int tcId, string hashAlg, string reason,
        bool expectedValid, string pkHex, string messageHex, string contextHex, string signatureHex)
    {
        using var dsa = CH.MLDsa.ImportMLDsaPublicKey(
            PreHashTestUtil.MLDsaAlgorithmFor(parameterSet), FromHex(pkHex));

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
        Assert.That(MLDsaPreHashAcvpVectors.CaseCount,
            Is.GreaterThanOrEqualTo(MLDsaPreHashAcvpVectors.StratifiedCaseCount),
            $"Loaded {MLDsaPreHashAcvpVectors.CaseCount} cases from {MLDsaPreHashAcvpVectors.Source}, "
            + $"fewer than the {MLDsaPreHashAcvpVectors.StratifiedCaseCount} committed ones.");
    }

    private static byte[] FromHex(string hex) => PreHashTestUtil.FromHex(hex);
}
