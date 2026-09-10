// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Collections.Generic;

/// <summary>
/// Cross-checks the SLH-DSA key encodings against BouncyCastle.
/// </summary>
/// <remarks>
/// The in-box <c>SlhDsa</c> needs CNG or OpenSSL 3.5+ and is unavailable on current Windows, so
/// BouncyCastle 2.7.0 is the independent implementation these encodings are checked against. It
/// covers the part a round-trip test cannot: that the OID and the raw-OCTET-STRING private key
/// layout are what the rest of the world expects, not merely what we also read back.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaKeyFormatInteropTests
{
    /// <summary>
    /// Gets a representative slice of the twelve parameter sets, paired with BouncyCastle's.
    /// </summary>
    /// <remarks>
    /// Four rather than twelve: both hash instantiations, both speed variants and all three
    /// security categories are represented, and the exhaustive OID check already runs in
    /// <see cref="SlhDsaKeyFormatTests"/>. Key generation for the <c>s</c> sets is slow enough
    /// that running all twelve here would not pay for itself.
    /// </remarks>
    public static IEnumerable<TestCaseData> Algorithms()
    {
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_128s, SlhDsaParameters.slh_dsa_sha2_128s);
        yield return Case(SlhDsaAlgorithm.SlhDsaShake128f, SlhDsaParameters.slh_dsa_shake_128f);
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_192f, SlhDsaParameters.slh_dsa_sha2_192f);
        yield return Case(SlhDsaAlgorithm.SlhDsaShake256f, SlhDsaParameters.slh_dsa_shake_256f);

        static TestCaseData Case(SlhDsaAlgorithm ours, SlhDsaParameters theirs)
            => new TestCaseData(ours, theirs).SetName(ours.Name);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void BouncyCastleReadsOurEncodings(SlhDsaAlgorithm ours, SlhDsaParameters theirs)
    {
        _ = theirs;
        using var key = SlhDsa.GenerateKey(ours, pairwiseConsistencyTest: false);

        var publicKey = (SlhDsaPublicKeyParameters)PublicKeyFactory.CreateKey(
            key.ExportSubjectPublicKeyInfo());
        var privateKey = (SlhDsaPrivateKeyParameters)PrivateKeyFactory.CreateKey(
            key.ExportPkcs8PrivateKey());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(publicKey.GetEncoded(), Is.EqualTo(key.ExportSlhDsaPublicKey()),
                "BouncyCastle must recover our public key from our SubjectPublicKeyInfo");
            Assert.That(privateKey.GetEncoded(), Is.EqualTo(key.ExportSlhDsaPrivateKey()),
                "BouncyCastle must recover our private key from our PKCS#8");
        }
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void WeReadBouncyCastlesEncodings(SlhDsaAlgorithm ours, SlhDsaParameters theirs)
    {
        var generator = new SlhDsaKeyPairGenerator();
        generator.Init(new SlhDsaKeyGenerationParameters(new SecureRandom(), theirs));
        AsymmetricCipherKeyPair pair = generator.GenerateKeyPair();

        byte[] spki = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pair.Public).GetDerEncoded();
        byte[] pkcs8 = PrivateKeyInfoFactory.CreatePrivateKeyInfo(pair.Private).GetDerEncoded();

        using var fromSpki = SlhDsa.ImportSubjectPublicKeyInfo(spki);
        using var fromPkcs8 = SlhDsa.ImportPkcs8PrivateKey(pkcs8);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromSpki.Algorithm, Is.EqualTo(ours), "the OID must select the right parameter set");
            Assert.That(fromSpki.ExportSlhDsaPublicKey(),
                Is.EqualTo(((SlhDsaPublicKeyParameters)pair.Public).GetEncoded()));
            Assert.That(fromPkcs8.ExportSlhDsaPrivateKey(),
                Is.EqualTo(((SlhDsaPrivateKeyParameters)pair.Private).GetEncoded()));
        }
    }

    [Test]
    public void ASignatureSurvivesTheRoundTripThroughBouncyCastle()
    {
        // End to end: our key, encoded by us, parsed by BouncyCastle, used to verify a signature
        // our key produced. An OID or layout mistake that both of our own paths shared would still
        // fail here.
        using var key = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f, pairwiseConsistencyTest: false);
        byte[] message = [4, 8, 15, 16, 23, 42];
        byte[] signature = key.SignData(message);

        var publicKey = (SlhDsaPublicKeyParameters)PublicKeyFactory.CreateKey(
            key.ExportSubjectPublicKeyInfo());

        var verifier = new Org.BouncyCastle.Crypto.Signers.SlhDsaSigner(
            SlhDsaParameters.slh_dsa_shake_128f, deterministic: false);
        verifier.Init(forSigning: false, publicKey);
        verifier.BlockUpdate(message, 0, message.Length);

        Assert.That(verifier.VerifySignature(signature), Is.True);
    }
}
