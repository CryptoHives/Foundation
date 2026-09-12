// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using OS = System.Security.Cryptography;

/// <summary>
/// PKCS#8, SubjectPublicKeyInfo and PEM tests for <see cref="MLKem"/>.
/// </summary>
/// <remarks>
/// The same battery as <see cref="MLDsaKeyFormatTests"/> - the two algorithms share the CHOICE and
/// the whole format layer - in ML-KEM's vocabulary: an encapsulation key rather than a public key,
/// a decapsulation key rather than an expanded private key, and a 64-byte seed rather than 32.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLKemKeyFormatTests
{
    private static readonly PbeOptions Pbe =
        new(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 2048);

    /// <summary>Gets the parameter sets with their CSOR object identifiers.</summary>
    public static IEnumerable<TestCaseData> Algorithms()
    {
        yield return new TestCaseData(MLKemAlgorithm.MLKem512, "2.16.840.1.101.3.4.4.1").SetName("ML-KEM-512");
        yield return new TestCaseData(MLKemAlgorithm.MLKem768, "2.16.840.1.101.3.4.4.2").SetName("ML-KEM-768");
        yield return new TestCaseData(MLKemAlgorithm.MLKem1024, "2.16.840.1.101.3.4.4.3").SetName("ML-KEM-1024");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Spki_RoundTrips(MLKemAlgorithm algorithm, string oid)
    {
        using var key = MLKem.GenerateKey(algorithm);
        byte[] spki = key.ExportSubjectPublicKeyInfo();

        KeyFormatAssert.IsSpki(spki, oid, key.ExportEncapsulationKey());

        using var imported = MLKem.ImportSubjectPublicKeyInfo(spki);
        Assert.That(imported.ExportEncapsulationKey(), Is.EqualTo(key.ExportEncapsulationKey()));
        Assert.That(imported.Algorithm, Is.EqualTo(algorithm));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_FromGeneratedKey_WritesTheSeedArm(MLKemAlgorithm algorithm, string oid)
    {
        using var key = MLKem.GenerateKey(algorithm);

        byte[] blob = KeyFormatAssert.IsPkcs8(key.ExportPkcs8PrivateKey(), oid);
        KeyFormatAssert.IsSeedChoice(blob, key.ExportPrivateSeed());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_FromDecapsulationKey_WritesTheExpandedArm(MLKemAlgorithm algorithm, string oid)
    {
        using var generated = MLKem.GenerateKey(algorithm);
        using var key = MLKem.ImportDecapsulationKey(algorithm, generated.ExportDecapsulationKey());

        byte[] blob = KeyFormatAssert.IsPkcs8(key.ExportPkcs8PrivateKey(), oid);
        KeyFormatAssert.IsExpandedKeyChoice(blob, generated.ExportDecapsulationKey());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_RoundTripPreservesTheSeed(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);

        using var imported = MLKem.ImportPkcs8PrivateKey(key.ExportPkcs8PrivateKey());

        Assert.That(imported.ExportPrivateSeed(), Is.EqualTo(key.ExportPrivateSeed()));
        Assert.That(imported.ExportDecapsulationKey(), Is.EqualTo(key.ExportDecapsulationKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pkcs8_RoundTrippedKeyStillDecapsulates(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);
        using var imported = MLKem.ImportPkcs8PrivateKey(key.ExportPkcs8PrivateKey());

        key.Encapsulate(out byte[] ciphertext, out byte[] sharedSecret);

        Assert.That(imported.Decapsulate(ciphertext), Is.EqualTo(sharedSecret),
            "a key that has been through PKCS#8 must still recover the same shared secret");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Pem_RoundTrips(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);

        string publicPem = key.ExportSubjectPublicKeyInfoPem();
        string privatePem = KeyFormatAssert.PrivateKeyPem(
            key.GetPkcs8PrivateKeyPemSize(), key.TryExportPkcs8PrivateKeyPem);

        KeyFormatAssert.IsPem(publicPem, "PUBLIC KEY");
        KeyFormatAssert.IsPem(privatePem, "PRIVATE KEY");

        using var fromPublic = MLKem.ImportFromPem(publicPem);
        using var fromPrivate = MLKem.ImportFromPem(privatePem);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromPublic.ExportEncapsulationKey(), Is.EqualTo(key.ExportEncapsulationKey()));
            Assert.That(fromPrivate.ExportPrivateSeed(), Is.EqualTo(key.ExportPrivateSeed()));
        }
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPkcs8_RoundTrips(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("hunter2".AsSpan(), Pbe);
        KeyFormatAssert.IsPbes2(encrypted);

        using var imported = MLKem.ImportEncryptedPkcs8PrivateKey("hunter2".AsSpan(), encrypted);
        Assert.That(imported.ExportPrivateSeed(), Is.EqualTo(key.ExportPrivateSeed()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncryptedPem_RoundTrips(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);

        string pem = key.ExportEncryptedPkcs8PrivateKeyPem("hunter2".AsSpan(), Pbe);
        KeyFormatAssert.IsPem(pem, "ENCRYPTED PRIVATE KEY");

        using var imported = MLKem.ImportFromEncryptedPem(pem.AsSpan(), "hunter2".AsSpan());
        Assert.That(imported.ExportPrivateSeed(), Is.EqualTo(key.ExportPrivateSeed()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void TryExport_ReportsShortBuffersWithoutWriting(MLKemAlgorithm algorithm, string oid)
    {
        _ = oid;
        using var key = MLKem.GenerateKey(algorithm);
        byte[] spki = key.ExportSubjectPublicKeyInfo();
        byte[] tooSmall = new byte[spki.Length - 1];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.TryExportSubjectPublicKeyInfo(tooSmall, out int written), Is.False);
            Assert.That(written, Is.Zero);
            Assert.That(tooSmall, Is.All.Zero);
        }

        byte[] exact = new byte[spki.Length];
        Assert.That(key.TryExportSubjectPublicKeyInfo(exact, out _), Is.True);
        Assert.That(exact, Is.EqualTo(spki));
    }

    [Test]
    public void EncapsulationKeyOnlyInstance_CannotExportPrivateKey()
    {
        using var key = MLKem.GenerateKey(MLKemAlgorithm.MLKem512);
        using var publicOnly = MLKem.ImportEncapsulationKey(
            MLKemAlgorithm.MLKem512, key.ExportEncapsulationKey());

        Assert.That(publicOnly.ExportPkcs8PrivateKey, Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void ImportSubjectPublicKeyInfo_RejectsAnotherAlgorithmsOid()
    {
        using var dsa = CryptoHives.Foundation.Security.Cryptography.Dsa.MLDsa.GenerateKey(
            CryptoHives.Foundation.Security.Cryptography.Dsa.MLDsaAlgorithm.MLDsa65);

        Assert.That(
            () => MLKem.ImportSubjectPublicKeyInfo(dsa.ExportSubjectPublicKeyInfo()),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void WrongPassword_Throws()
    {
        using var key = MLKem.GenerateKey(MLKemAlgorithm.MLKem512);
        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("right".AsSpan(), Pbe);

        Assert.That(
            () => MLKem.ImportEncryptedPkcs8PrivateKey("wrong".AsSpan(), encrypted),
            Throws.InstanceOf<OS.CryptographicException>());
    }
}
