// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using CryptoHives.Foundation.Security.Cryptography;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using OS = System.Security.Cryptography;

/// <summary>
/// PKCS#8, SubjectPublicKeyInfo and PEM tests for <see cref="SlhDsa"/>.
/// </summary>
/// <remarks>
/// <para>
/// SLH-DSA is the one family whose PKCS#8 body is not the ML-KEM/ML-DSA CHOICE: FIPS 205 private
/// keys have no seed, so the <c>privateKey</c> OCTET STRING carries the raw 4n bytes directly.
/// <see cref="Pkcs8_PrivateKeyIsRawBytesWithNoChoice"/> is the test that pins that difference.
/// </para>
/// <para>
/// Key generation runs with the pairwise consistency test disabled throughout. It costs a full
/// signature, which for the <c>s</c> sets is seconds, and these tests are about encodings rather
/// than key generation - the ACVP suite covers correctness of the keys themselves.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaKeyFormatTests
{
    private static readonly PbeOptions Pbe =
        new(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 2048);

    /// <summary>
    /// Gets every parameter set with its CSOR object identifier.
    /// </summary>
    /// <remarks>
    /// All twelve: the OID arc is not ordered the way the sets usually are - SHA2 takes 20-25 and
    /// SHAKE 26-31 - so a transposed entry is exactly the kind of mistake worth covering
    /// exhaustively rather than by sampling.
    /// </remarks>
    public static IEnumerable<TestCaseData> Algorithms()
    {
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_128s, "2.16.840.1.101.3.4.3.20");
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_128f, "2.16.840.1.101.3.4.3.21");
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_192s, "2.16.840.1.101.3.4.3.22");
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_192f, "2.16.840.1.101.3.4.3.23");
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_256s, "2.16.840.1.101.3.4.3.24");
        yield return Case(SlhDsaAlgorithm.SlhDsaSha2_256f, "2.16.840.1.101.3.4.3.25");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake128s, "2.16.840.1.101.3.4.3.26");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake128f, "2.16.840.1.101.3.4.3.27");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake192s, "2.16.840.1.101.3.4.3.28");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake192f, "2.16.840.1.101.3.4.3.29");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake256s, "2.16.840.1.101.3.4.3.30");
        yield return Case(SlhDsaAlgorithm.SlhDsaShake256f, "2.16.840.1.101.3.4.3.31");

        static TestCaseData Case(SlhDsaAlgorithm algorithm, string oid)
            => new TestCaseData(algorithm, oid).SetName(algorithm.Name);
    }

    private static SlhDsa Generate(SlhDsaAlgorithm algorithm)
        => SlhDsa.GenerateKey(algorithm, pairwiseConsistencyTest: false);

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Spki_RoundTrips(SlhDsaAlgorithm algorithm, string oid)
    {
        using var key = Generate(algorithm);
        byte[] spki = key.ExportSubjectPublicKeyInfo();

        KeyFormatAssert.IsSpki(spki, oid, key.ExportSlhDsaPublicKey());

        using var imported = SlhDsa.ImportSubjectPublicKeyInfo(spki);
        Assert.That(imported.ExportSlhDsaPublicKey(), Is.EqualTo(key.ExportSlhDsaPublicKey()));
        Assert.That(imported.Algorithm, Is.EqualTo(algorithm));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_PrivateKeyIsRawBytesWithNoChoice(SlhDsaAlgorithm algorithm, string oid)
    {
        using var key = Generate(algorithm);

        byte[] blob = KeyFormatAssert.IsPkcs8(key.ExportPkcs8PrivateKey(), oid);

        // Not a nested CHOICE, unlike ML-KEM and ML-DSA: the OCTET STRING contents are the key.
        Assert.That(blob, Is.EqualTo(key.ExportSlhDsaPrivateKey()));
        Assert.That(blob, Has.Length.EqualTo(algorithm.PrivateKeySizeInBytes));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_RoundTrips(SlhDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = Generate(algorithm);

        using var imported = SlhDsa.ImportPkcs8PrivateKey(key.ExportPkcs8PrivateKey());
        Assert.That(imported.ExportSlhDsaPrivateKey(), Is.EqualTo(key.ExportSlhDsaPrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pem_RoundTrips(SlhDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = Generate(algorithm);

        string publicPem = key.ExportSubjectPublicKeyInfoPem();
        string privatePem = key.ExportPkcs8PrivateKeyPem();

        KeyFormatAssert.IsPem(publicPem, "PUBLIC KEY");
        KeyFormatAssert.IsPem(privatePem, "PRIVATE KEY");

        using var fromPublic = SlhDsa.ImportFromPem(publicPem);
        using var fromPrivate = SlhDsa.ImportFromPem(privatePem);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromPublic.ExportSlhDsaPublicKey(), Is.EqualTo(key.ExportSlhDsaPublicKey()));
            Assert.That(fromPrivate.ExportSlhDsaPrivateKey(), Is.EqualTo(key.ExportSlhDsaPrivateKey()));
        }
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPkcs8_RoundTrips(SlhDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = Generate(algorithm);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("hunter2", Pbe);
        KeyFormatAssert.IsPbes2(encrypted);

        using var imported = SlhDsa.ImportEncryptedPkcs8PrivateKey("hunter2".AsSpan(), encrypted);
        Assert.That(imported.ExportSlhDsaPrivateKey(), Is.EqualTo(key.ExportSlhDsaPrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPem_RoundTrips(SlhDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = Generate(algorithm);

        string pem = key.ExportEncryptedPkcs8PrivateKeyPem("hunter2", Pbe);
        KeyFormatAssert.IsPem(pem, "ENCRYPTED PRIVATE KEY");

        using var imported = SlhDsa.ImportFromEncryptedPem(pem, "hunter2");
        Assert.That(imported.ExportSlhDsaPrivateKey(), Is.EqualTo(key.ExportSlhDsaPrivateKey()));
    }

    [Test]
    [Category("Slow")]
    public void RoundTrippedKey_StillSigns()
    {
        // One f set is enough: this is about the key surviving the encoding, not about signing,
        // and an s-set signature would dominate the run for no extra coverage.
        using var key = Generate(SlhDsaAlgorithm.SlhDsaShake128f);
        using var imported = SlhDsa.ImportFromPem(key.ExportPkcs8PrivateKeyPem());

        byte[] message = [4, 8, 15, 16, 23, 42];
        Assert.That(key.VerifyData(message, imported.SignData(message)), Is.True);
    }

    [Test]
    public void PublicKeyOnlyInstance_CannotExportPrivateKey()
    {
        using var key = Generate(SlhDsaAlgorithm.SlhDsaShake128f);
        using var verifier = SlhDsa.ImportSlhDsaPublicKey(
            SlhDsaAlgorithm.SlhDsaShake128f, key.ExportSlhDsaPublicKey());

        Assert.That(verifier.ExportPkcs8PrivateKey, Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportSubjectPublicKeyInfo_RejectsAnotherAlgorithmsOid()
    {
        using var dsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);

        Assert.That(
            () => SlhDsa.ImportSubjectPublicKeyInfo(dsa.ExportSubjectPublicKeyInfo()),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportPkcs8_RejectsAWrongLengthKey()
    {
        using var key = Generate(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] pkcs8 = key.ExportPkcs8PrivateKey();

        // Re-encode with one byte lopped off the private key.
        // Not a range expression: net48 has no RuntimeHelpers.GetSubArray.
        byte[] full = key.ExportSlhDsaPrivateKey();
        byte[] truncated = new byte[full.Length - 1];
        System.Array.Copy(full, truncated, truncated.Length);
        var writer = new System.Formats.Asn1.AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
        using (writer.PushSequence())
        {
            writer.WriteInteger(0);
            using (writer.PushSequence())
            {
                writer.WriteObjectIdentifier("2.16.840.1.101.3.4.3.27");
            }

            writer.WriteOctetString(truncated);
        }

        Assert.That(pkcs8, Is.Not.EqualTo(writer.Encode()));
        Assert.That(
            () => SlhDsa.ImportPkcs8PrivateKey(writer.Encode()),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void WrongPassword_Throws()
    {
        using var key = Generate(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("right", Pbe);

        Assert.That(
            () => SlhDsa.ImportEncryptedPkcs8PrivateKey("wrong".AsSpan(), encrypted),
            Throws.InstanceOf<OS.CryptographicException>());
    }
}
