// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using CHD = CryptoHives.Foundation.Security.Cryptography.Dsa;
using CHK = CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Cross-checks the key encodings against independent implementations.
/// </summary>
/// <remarks>
/// <para>
/// The round-trip fixtures prove we can read what we write, which a consistently wrong OID or
/// CHOICE tag would also pass. These tests are the ones that catch that, by requiring another
/// implementation to agree.
/// </para>
/// <para>
/// The in-box types are the reference where the platform provides them: <c>MLKem</c> and
/// <c>MLDsa</c> resolve through CNG on Windows 11 25H2, while <c>SlhDsa</c> does not, so SLH-DSA is
/// covered against BouncyCastle in <c>SlhDsaKeyFormatInteropTests</c> instead. Each test skips
/// rather than fails where the platform has no implementation to compare with.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KeyFormatInteropTests
{
#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    private static readonly System.Security.Cryptography.PbeParameters Pbe =
        new(System.Security.Cryptography.PbeEncryptionAlgorithm.Aes256Cbc,
            System.Security.Cryptography.HashAlgorithmName.SHA256,
            2048);

    /// <summary>Gets the ML-DSA parameter sets paired with their in-box counterparts.</summary>
    public static IEnumerable<TestCaseData> MLDsaAlgorithms()
    {
        yield return new TestCaseData(
            CHD.MLDsaAlgorithm.MLDsa44, System.Security.Cryptography.MLDsaAlgorithm.MLDsa44).SetName("ML-DSA-44");
        yield return new TestCaseData(
            CHD.MLDsaAlgorithm.MLDsa65, System.Security.Cryptography.MLDsaAlgorithm.MLDsa65).SetName("ML-DSA-65");
        yield return new TestCaseData(
            CHD.MLDsaAlgorithm.MLDsa87, System.Security.Cryptography.MLDsaAlgorithm.MLDsa87).SetName("ML-DSA-87");
    }

    /// <summary>Gets the ML-KEM parameter sets paired with their in-box counterparts.</summary>
    public static IEnumerable<TestCaseData> MLKemAlgorithms()
    {
        yield return new TestCaseData(
            CHK.MLKemAlgorithm.MLKem512, System.Security.Cryptography.MLKemAlgorithm.MLKem512).SetName("ML-KEM-512");
        yield return new TestCaseData(
            CHK.MLKemAlgorithm.MLKem768, System.Security.Cryptography.MLKemAlgorithm.MLKem768).SetName("ML-KEM-768");
        yield return new TestCaseData(
            CHK.MLKemAlgorithm.MLKem1024, System.Security.Cryptography.MLKemAlgorithm.MLKem1024).SetName("ML-KEM-1024");
    }

    // ========================================================================
    // ML-DSA
    // ========================================================================

    [Test]
    [TestCaseSource(nameof(MLDsaAlgorithms))]
    public void MLDsa_EncodingsAreByteIdenticalToTheInBoxType(
        CHD.MLDsaAlgorithm ours,
        System.Security.Cryptography.MLDsaAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLDsa.IsSupported, "MLDsa");

        using var key = CHD.MLDsa.GenerateKey(ours);

        // Hand the in-box type the same key material, then compare what each writes. Anything but
        // an exact match is a difference in the encoding, not in the key.
        using var reference = System.Security.Cryptography.MLDsa.ImportMLDsaPrivateSeed(
            theirs, key.ExportMLDsaPrivateSeed());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.ExportSubjectPublicKeyInfo(),
                Is.EqualTo(reference.ExportSubjectPublicKeyInfo()), "SubjectPublicKeyInfo");
            Assert.That(key.ExportPkcs8PrivateKey(),
                Is.EqualTo(reference.ExportPkcs8PrivateKey()), "PKCS#8, seed arm");
            Assert.That(key.ExportSubjectPublicKeyInfoPem(),
                Is.EqualTo(reference.ExportSubjectPublicKeyInfoPem()), "SubjectPublicKeyInfo PEM");
            Assert.That(key.ExportPkcs8PrivateKeyPem(),
                Is.EqualTo(reference.ExportPkcs8PrivateKeyPem()), "PKCS#8 PEM");
        }
    }

    [Test]
    [TestCaseSource(nameof(MLDsaAlgorithms))]
    public void MLDsa_ExpandedKeyEncodingIsByteIdenticalToTheInBoxType(
        CHD.MLDsaAlgorithm ours,
        System.Security.Cryptography.MLDsaAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLDsa.IsSupported, "MLDsa");

        using var generated = CHD.MLDsa.GenerateKey(ours);
        byte[] expanded = generated.ExportMLDsaPrivateKey();

        using var key = CHD.MLDsa.ImportMLDsaPrivateKey(ours, expanded);
        using var reference = System.Security.Cryptography.MLDsa.ImportMLDsaPrivateKey(theirs, expanded);

        Assert.That(key.ExportPkcs8PrivateKey(), Is.EqualTo(reference.ExportPkcs8PrivateKey()),
            "a key with no seed must write the expandedKey arm, exactly as the in-box type does");
    }

    [Test]
    [TestCaseSource(nameof(MLDsaAlgorithms))]
    public void MLDsa_EachSideReadsTheOthersEncodings(
        CHD.MLDsaAlgorithm ours,
        System.Security.Cryptography.MLDsaAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLDsa.IsSupported, "MLDsa");

        using var mine = CHD.MLDsa.GenerateKey(ours);
        using var reference = System.Security.Cryptography.MLDsa.GenerateKey(theirs);

        using var theirsFromMine = System.Security.Cryptography.MLDsa.ImportPkcs8PrivateKey(
            mine.ExportPkcs8PrivateKey());
        using var mineFromTheirs = CHD.MLDsa.ImportPkcs8PrivateKey(reference.ExportPkcs8PrivateKey());
        using var mineFromTheirSpki = CHD.MLDsa.ImportSubjectPublicKeyInfo(
            reference.ExportSubjectPublicKeyInfo());
        using var mineFromTheirPem = CHD.MLDsa.ImportFromPem(reference.ExportPkcs8PrivateKeyPem());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(theirsFromMine.ExportMLDsaPublicKey(),
                Is.EqualTo(mine.ExportMLDsaPublicKey()), "in-box reads our PKCS#8");
            Assert.That(mineFromTheirs.ExportMLDsaPublicKey(),
                Is.EqualTo(reference.ExportMLDsaPublicKey()), "we read the in-box PKCS#8");
            Assert.That(mineFromTheirSpki.ExportMLDsaPublicKey(),
                Is.EqualTo(reference.ExportMLDsaPublicKey()), "we read the in-box SubjectPublicKeyInfo");
            Assert.That(mineFromTheirPem.ExportMLDsaPublicKey(),
                Is.EqualTo(reference.ExportMLDsaPublicKey()), "we read the in-box PEM");
        }
    }

    [Test]
    [TestCaseSource(nameof(MLDsaAlgorithms))]
    public void MLDsa_EncryptedKeysCrossDecrypt(
        CHD.MLDsaAlgorithm ours,
        System.Security.Cryptography.MLDsaAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLDsa.IsSupported, "MLDsa");

        using var mine = CHD.MLDsa.GenerateKey(ours);
        using var reference = System.Security.Cryptography.MLDsa.GenerateKey(theirs);

        using var theirsFromMine = System.Security.Cryptography.MLDsa.ImportEncryptedPkcs8PrivateKey(
            "pw", mine.ExportEncryptedPkcs8PrivateKey("pw", Pbe));
        using var mineFromTheirs = CHD.MLDsa.ImportFromEncryptedPem(
            reference.ExportEncryptedPkcs8PrivateKeyPem("pw", Pbe), "pw");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(theirsFromMine.ExportMLDsaPublicKey(), Is.EqualTo(mine.ExportMLDsaPublicKey()),
                "the in-box type decrypts our PBES2 output");
            Assert.That(mineFromTheirs.ExportMLDsaPublicKey(), Is.EqualTo(reference.ExportMLDsaPublicKey()),
                "we decrypt the in-box PBES2 output");
        }
    }

    // ========================================================================
    // ML-KEM
    // ========================================================================

    [Test]
    [TestCaseSource(nameof(MLKemAlgorithms))]
    public void MLKem_EncodingsAreByteIdenticalToTheInBoxType(
        CHK.MLKemAlgorithm ours,
        System.Security.Cryptography.MLKemAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLKem.IsSupported, "MLKem");

        using var key = CHK.MLKem.GenerateKey(ours);
        using var reference = System.Security.Cryptography.MLKem.ImportPrivateSeed(
            theirs, key.ExportPrivateSeed());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(key.ExportSubjectPublicKeyInfo(),
                Is.EqualTo(reference.ExportSubjectPublicKeyInfo()), "SubjectPublicKeyInfo");
            Assert.That(key.ExportPkcs8PrivateKey(),
                Is.EqualTo(reference.ExportPkcs8PrivateKey()), "PKCS#8, seed arm");
            Assert.That(key.ExportSubjectPublicKeyInfoPem(),
                Is.EqualTo(reference.ExportSubjectPublicKeyInfoPem()), "SubjectPublicKeyInfo PEM");
            Assert.That(key.ExportPkcs8PrivateKeyPem(),
                Is.EqualTo(reference.ExportPkcs8PrivateKeyPem()), "PKCS#8 PEM");
        }
    }

    [Test]
    [TestCaseSource(nameof(MLKemAlgorithms))]
    public void MLKem_DecapsulationKeyEncodingIsByteIdenticalToTheInBoxType(
        CHK.MLKemAlgorithm ours,
        System.Security.Cryptography.MLKemAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLKem.IsSupported, "MLKem");

        using var generated = CHK.MLKem.GenerateKey(ours);
        byte[] decapsulationKey = generated.ExportDecapsulationKey();

        using var key = CHK.MLKem.ImportDecapsulationKey(ours, decapsulationKey);
        using var reference = System.Security.Cryptography.MLKem.ImportDecapsulationKey(
            theirs, decapsulationKey);

        Assert.That(key.ExportPkcs8PrivateKey(), Is.EqualTo(reference.ExportPkcs8PrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(MLKemAlgorithms))]
    public void MLKem_EachSideReadsTheOthersEncodings(
        CHK.MLKemAlgorithm ours,
        System.Security.Cryptography.MLKemAlgorithm theirs)
    {
        SkipIfUnsupported(System.Security.Cryptography.MLKem.IsSupported, "MLKem");

        using var mine = CHK.MLKem.GenerateKey(ours);
        using var reference = System.Security.Cryptography.MLKem.GenerateKey(theirs);

        using var theirsFromMine = System.Security.Cryptography.MLKem.ImportPkcs8PrivateKey(
            mine.ExportPkcs8PrivateKey());
        using var mineFromTheirs = CHK.MLKem.ImportPkcs8PrivateKey(reference.ExportPkcs8PrivateKey());

        using (Assert.EnterMultipleScope())
        {
            Assert.That(theirsFromMine.ExportEncapsulationKey(),
                Is.EqualTo(mine.ExportEncapsulationKey()), "in-box reads our PKCS#8");
            Assert.That(mineFromTheirs.ExportEncapsulationKey(),
                Is.EqualTo(reference.ExportEncapsulationKey()), "we read the in-box PKCS#8");
        }

        // The encoding is only useful if the key still works: encapsulate against the in-box key
        // we imported, and decapsulate with the original.
        theirsFromMine.Encapsulate(out byte[] ciphertext, out byte[] sharedSecret);
        Assert.That(mine.Decapsulate(ciphertext), Is.EqualTo(sharedSecret));
    }

    private static void SkipIfUnsupported(bool supported, string name)
    {
        if (!supported)
        {
            Assert.Ignore($"System.Security.Cryptography.{name} is not supported on this platform.");
        }
    }

#pragma warning restore SYSLIB5006
#endif
}
