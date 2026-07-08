// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MlDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Tests for the key-holding <see cref="MlDsa"/> class, whose API mirrors
/// <c>System.Security.Cryptography.MLDsa</c> from .NET 10.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MlDsaApiTests
{
    private static readonly MlDsaAlgorithm[] Algorithms =
    [
        MlDsaAlgorithm.MlDsa44,
        MlDsaAlgorithm.MlDsa65,
        MlDsaAlgorithm.MlDsa87
    ];

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void GenerateKey_SignVerify_RoundTrips(MlDsaAlgorithm algorithm)
    {
        using var dsa = MlDsa.GenerateKey(algorithm);
        Assert.That(dsa.Algorithm, Is.SameAs(algorithm));

        byte[] message = new byte[100];
        byte[] signature = dsa.SignData(message);
        Assert.That(signature, Has.Length.EqualTo(algorithm.SignatureSizeInBytes));

        Assert.That(dsa.VerifyData(message, signature), Is.True);
        Assert.That(dsa.VerifyData(message, signature, "other"u8), Is.False,
            "A signature must be bound to its context.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportPrivateSeed_ReproducesGeneratedKey(MlDsaAlgorithm algorithm)
    {
        using var original = MlDsa.GenerateKey(algorithm);
        byte[] seed = original.ExportPrivateSeed();
        Assert.That(seed, Has.Length.EqualTo(algorithm.PrivateSeedSizeInBytes));

        using var restored = MlDsa.ImportPrivateSeed(algorithm, seed);
        Assert.That(restored.ExportPrivateSeed(), Is.EqualTo(seed));
        Assert.That(restored.ExportPublicKey(), Is.EqualTo(original.ExportPublicKey()));
        Assert.That(restored.ExportSecretKey(), Is.EqualTo(original.ExportSecretKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportSecretKey_CanSign_ButHasNoSeed(MlDsaAlgorithm algorithm)
    {
        using var original = MlDsa.GenerateKey(algorithm);
        byte[] message = new byte[42];

        using var imported = MlDsa.ImportSecretKey(algorithm, original.ExportSecretKey());
        byte[] signature = imported.SignData(message);

        Assert.That(original.VerifyData(message, signature), Is.True);
        Assert.That(imported.ExportPublicKey(), Is.EqualTo(original.ExportPublicKey()),
            "The public key must be reconstructed from the secret key on import.");
        Assert.That(() => imported.ExportPrivateSeed(), Throws.InstanceOf<CryptographicException>(),
            "A key imported from an expanded secret key has no seed.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportSecretKey_TamperedHash_Throws(MlDsaAlgorithm algorithm)
    {
        using var original = MlDsa.GenerateKey(algorithm);
        byte[] sk = original.ExportSecretKey();

        // Corrupt the embedded tr = H(pk): sk = ρ ‖ K ‖ tr ‖ …
        sk[64] ^= 0x01;

        Assert.That(() => MlDsa.ImportSecretKey(algorithm, sk),
            Throws.InstanceOf<CryptographicException>(),
            "A secret key whose embedded public key hash does not match must be rejected.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportPublicKey_CanVerifyOnly(MlDsaAlgorithm algorithm)
    {
        using var signer = MlDsa.GenerateKey(algorithm);
        byte[] message = new byte[64];
        byte[] signature = signer.SignData(message);

        using var verifier = MlDsa.ImportPublicKey(algorithm, signer.ExportPublicKey());
        Assert.That(verifier.VerifyData(message, signature), Is.True);
        Assert.That(() => verifier.SignData(message), Throws.InstanceOf<CryptographicException>());
        Assert.That(() => verifier.ExportSecretKey(), Throws.InstanceOf<CryptographicException>());
        Assert.That(() => verifier.ExportPrivateSeed(), Throws.InstanceOf<CryptographicException>());
    }

    [Test]
    public void VerifyData_WrongSignatureLength_ReturnsFalse()
    {
        using var dsa = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa44);
        byte[] message = new byte[16];

        Assert.That(dsa.VerifyData(message, new byte[100]), Is.False,
            "A signature of the wrong length is invalid, not an error.");
    }

    [Test]
    public void Dispose_BlocksFurtherUse()
    {
        var dsa = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa44);
        byte[] message = new byte[8];
        byte[] signature = dsa.SignData(message);

        dsa.Dispose();
        dsa.Dispose(); // Double dispose must be harmless.

        Assert.That(() => dsa.SignData(message), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.VerifyData(message, signature), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportPrivateSeed(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportPublicKey(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportSecretKey(), Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void AlgorithmDescriptors_ReportFips204Sizes()
    {
        Assert.Multiple(() => {
            Assert.That(MlDsaAlgorithm.MlDsa44.PublicKeySizeInBytes, Is.EqualTo(1312));
            Assert.That(MlDsaAlgorithm.MlDsa44.SecretKeySizeInBytes, Is.EqualTo(2560));
            Assert.That(MlDsaAlgorithm.MlDsa44.SignatureSizeInBytes, Is.EqualTo(2420));
            Assert.That(MlDsaAlgorithm.MlDsa65.PublicKeySizeInBytes, Is.EqualTo(1952));
            Assert.That(MlDsaAlgorithm.MlDsa65.SecretKeySizeInBytes, Is.EqualTo(4032));
            Assert.That(MlDsaAlgorithm.MlDsa65.SignatureSizeInBytes, Is.EqualTo(3309));
            Assert.That(MlDsaAlgorithm.MlDsa87.PublicKeySizeInBytes, Is.EqualTo(2592));
            Assert.That(MlDsaAlgorithm.MlDsa87.SecretKeySizeInBytes, Is.EqualTo(4896));
            Assert.That(MlDsaAlgorithm.MlDsa87.SignatureSizeInBytes, Is.EqualTo(4627));
            Assert.That(MlDsaAlgorithm.MlDsa65.PrivateSeedSizeInBytes, Is.EqualTo(32));
            Assert.That(MlDsaAlgorithm.MlDsa65.Name, Is.EqualTo("ML-DSA-65"));
            Assert.That(MlDsaAlgorithm.MlDsa65.ToString(), Is.EqualTo("ML-DSA-65"));
        });
    }
}
