// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using OS = System.Security.Cryptography;

/// <summary>
/// PKCS#8, SubjectPublicKeyInfo and PEM tests for <see cref="MLDsa"/>.
/// </summary>
/// <remarks>
/// The structural checks live in <see cref="KeyFormatAssert"/>; the calls stay here so a failure
/// names the parameter set. <c>MLDsaKeyFormatInteropTests</c> covers the same ground against the
/// in-box type on net10.0.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLDsaKeyFormatTests
{
    private static readonly PbeOptions Pbe =
        new(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 2048);

    /// <summary>Gets the parameter sets with their CSOR object identifiers.</summary>
    public static IEnumerable<TestCaseData> Algorithms()
    {
        yield return new TestCaseData(MLDsaAlgorithm.MLDsa44, "2.16.840.1.101.3.4.3.17").SetName("ML-DSA-44");
        yield return new TestCaseData(MLDsaAlgorithm.MLDsa65, "2.16.840.1.101.3.4.3.18").SetName("ML-DSA-65");
        yield return new TestCaseData(MLDsaAlgorithm.MLDsa87, "2.16.840.1.101.3.4.3.19").SetName("ML-DSA-87");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Spki_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        using var key = MLDsa.GenerateKey(algorithm);
        byte[] spki = key.ExportSubjectPublicKeyInfo();

        KeyFormatAssert.IsSpki(spki, oid, key.ExportMLDsaPublicKey());

        using var imported = MLDsa.ImportSubjectPublicKeyInfo(spki);
        Assert.That(imported.ExportMLDsaPublicKey(), Is.EqualTo(key.ExportMLDsaPublicKey()));
        Assert.That(imported.Algorithm, Is.EqualTo(algorithm));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_FromGeneratedKey_WritesTheSeedArm(MLDsaAlgorithm algorithm, string oid)
    {
        using var key = MLDsa.GenerateKey(algorithm);

        byte[] blob = KeyFormatAssert.IsPkcs8(key.ExportPkcs8PrivateKey(), oid);
        KeyFormatAssert.IsSeedChoice(blob, key.ExportMLDsaPrivateSeed());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_FromExpandedKey_WritesTheExpandedArm(MLDsaAlgorithm algorithm, string oid)
    {
        using var generated = MLDsa.GenerateKey(algorithm);
        using var key = MLDsa.ImportMLDsaPrivateKey(algorithm, generated.ExportMLDsaPrivateKey());

        byte[] blob = KeyFormatAssert.IsPkcs8(key.ExportPkcs8PrivateKey(), oid);
        KeyFormatAssert.IsExpandedKeyChoice(blob, generated.ExportMLDsaPrivateKey());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_RoundTripPreservesTheSeed(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);

        using var imported = MLDsa.ImportPkcs8PrivateKey(key.ExportPkcs8PrivateKey());

        // The point of writing the seed arm: a seeded key survives PKCS#8 as a seeded key rather
        // than being silently downgraded to its expanded form.
        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
        Assert.That(imported.ExportMLDsaPrivateKey(), Is.EqualTo(key.ExportMLDsaPrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_ExpandedRoundTripPreservesTheKey(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var generated = MLDsa.GenerateKey(algorithm);
        using var key = MLDsa.ImportMLDsaPrivateKey(algorithm, generated.ExportMLDsaPrivateKey());

        using var imported = MLDsa.ImportPkcs8PrivateKey(key.ExportPkcs8PrivateKey());
        Assert.That(imported.ExportMLDsaPrivateKey(), Is.EqualTo(generated.ExportMLDsaPrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pem_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);

        string publicPem = key.ExportSubjectPublicKeyInfoPem();
        string privatePem = KeyFormatAssert.PrivateKeyPem(
            key.GetPkcs8PrivateKeyPemSize(), key.TryExportPkcs8PrivateKeyPem);

        KeyFormatAssert.IsPem(publicPem, "PUBLIC KEY");
        KeyFormatAssert.IsPem(privatePem, "PRIVATE KEY");

        using var fromPublic = MLDsa.ImportFromPem(publicPem);
        using var fromPrivate = MLDsa.ImportFromPem(privatePem);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromPublic.ExportMLDsaPublicKey(), Is.EqualTo(key.ExportMLDsaPublicKey()));
            Assert.That(fromPrivate.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
        }
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPkcs8_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("hunter2".AsSpan(), Pbe);
        KeyFormatAssert.IsPbes2(encrypted);

        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey("hunter2".AsSpan(), encrypted);
        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPem_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);

        string pem = key.ExportEncryptedPkcs8PrivateKeyPem("hunter2".AsSpan(), Pbe);
        KeyFormatAssert.IsPem(pem, "ENCRYPTED PRIVATE KEY");

        using var imported = MLDsa.ImportFromEncryptedPem(pem.AsSpan(), "hunter2".AsSpan());
        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void TryExport_ReportsShortBuffersWithoutWriting(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);
        byte[] spki = key.ExportSubjectPublicKeyInfo();

        byte[] tooSmall = new byte[spki.Length - 1];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.TryExportSubjectPublicKeyInfo(tooSmall, out int written), Is.False);
            Assert.That(written, Is.Zero, "a failed TryExport reports nothing written");
            Assert.That(tooSmall, Is.All.Zero, "a failed TryExport must not partially fill the buffer");
        }

        byte[] exact = new byte[spki.Length];
        Assert.That(key.TryExportSubjectPublicKeyInfo(exact, out int exactWritten), Is.True);
        Assert.That(exactWritten, Is.EqualTo(spki.Length));
        Assert.That(exact, Is.EqualTo(spki));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void TryExportPkcs8_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);
        byte[] expected = key.ExportPkcs8PrivateKey();

        byte[] buffer = new byte[expected.Length];
        Assert.That(key.TryExportPkcs8PrivateKey(buffer, out int written), Is.True);
        Assert.That(written, Is.EqualTo(expected.Length));
        Assert.That(buffer, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void TryExportEncryptedPkcs8_RoundTrips(MLDsaAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLDsa.GenerateKey(algorithm);

        // The salt and IV are fresh per call, so the length is stable but the bytes are not;
        // decrypting is the check that the buffer holds a usable structure.
        int length = key.ExportEncryptedPkcs8PrivateKey("pw".AsSpan(), Pbe).Length;
        byte[] buffer = new byte[length];

        Assert.That(key.TryExportEncryptedPkcs8PrivateKey("pw".AsSpan(), Pbe, buffer, out int written), Is.True);
        Assert.That(written, Is.EqualTo(length));

        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey("pw".AsSpan(), buffer);
        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    public void PublicKeyOnlyInstance_CannotExportPrivateKey()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        using var verifier = MLDsa.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa44, key.ExportMLDsaPublicKey());

        Assert.That(verifier.ExportPkcs8PrivateKey, Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void WrongPassword_Throws()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("right".AsSpan(), Pbe);

        Assert.That(
            () => MLDsa.ImportEncryptedPkcs8PrivateKey("wrong".AsSpan(), encrypted),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportSubjectPublicKeyInfo_RejectsAnotherAlgorithmsOid()
    {
        using var kem = CryptoHives.Foundation.Security.Cryptography.Kem.MLKem.GenerateKey(
            CryptoHives.Foundation.Security.Cryptography.Kem.MLKemAlgorithm.MLKem768);

        Assert.That(
            () => MLDsa.ImportSubjectPublicKeyInfo(kem.ExportSubjectPublicKeyInfo()),
            Throws.InstanceOf<OS.CryptographicException>(),
            "an ML-KEM SubjectPublicKeyInfo is well-formed but is not an ML-DSA key");
    }

    [Test]
    public void ImportSubjectPublicKeyInfo_RejectsTrailingData()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] spki = key.ExportSubjectPublicKeyInfo();

        byte[] withTrailer = new byte[spki.Length + 1];
        spki.CopyTo(withTrailer, 0);

        Assert.That(
            () => MLDsa.ImportSubjectPublicKeyInfo(withTrailer),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportPkcs8_RejectsAWrongLengthKey()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        // A structurally valid PrivateKeyInfo whose expandedKey arm is one byte short.
        // Not a range expression: net48 has no RuntimeHelpers.GetSubArray.
        byte[] full = key.ExportMLDsaPrivateKey();
        byte[] truncated = new byte[full.Length - 1];
        Array.Copy(full, truncated, truncated.Length);
        var writer = new System.Formats.Asn1.AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
        using (writer.PushSequence())
        {
            writer.WriteInteger(0);
            using (writer.PushSequence())
            {
                writer.WriteObjectIdentifier("2.16.840.1.101.3.4.3.17");
            }

            var inner = new System.Formats.Asn1.AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
            inner.WriteOctetString(truncated);
            writer.WriteOctetString(inner.Encode());
        }

        Assert.That(
            () => MLDsa.ImportPkcs8PrivateKey(writer.Encode()),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportFromPem_RejectsTwoRecognizedBlocks()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        string doubled = key.ExportSubjectPublicKeyInfoPem() + "\n"
            + KeyFormatAssert.PrivateKeyPem(
                key.GetPkcs8PrivateKeyPemSize(), key.TryExportPkcs8PrivateKeyPem);

        Assert.That(() => MLDsa.ImportFromPem(doubled.AsSpan()), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void ImportFromPem_SkipsUnrecognizedLabels()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        string document =
            "-----BEGIN CERTIFICATE-----\nZm9v\n-----END CERTIFICATE-----\n"
            + key.ExportSubjectPublicKeyInfoPem();

        using var imported = MLDsa.ImportFromPem(document.AsSpan());
        Assert.That(imported.ExportMLDsaPublicKey(), Is.EqualTo(key.ExportMLDsaPublicKey()));
    }

    [Test]
    public void ImportFromPem_RejectsADocumentWithNoRecognizedLabel()
    {
        Assert.That(
            () => MLDsa.ImportFromPem("-----BEGIN CERTIFICATE-----\nZm9v\n-----END CERTIFICATE-----"),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void ImportFromPem_PointsAnEncryptedBlockAtTheRightMethod()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        Assert.That(
            () => MLDsa.ImportFromPem(key.ExportEncryptedPkcs8PrivateKeyPem("pw".AsSpan(), Pbe).AsSpan()),
            Throws.InstanceOf<ArgumentException>().With.Message.Contains("ImportFromEncryptedPem"));
    }

    [Test]
    public void NullArguments_Throw()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => MLDsa.ImportPkcs8PrivateKey((byte[])null!), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => MLDsa.ImportSubjectPublicKeyInfo((byte[])null!), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => MLDsa.ImportFromEncryptedPem("x", (byte[])null!), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => MLDsa.ImportFromEncryptedPem((string)null!, Array.Empty<byte>()), Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
