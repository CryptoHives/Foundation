// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MlKem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Tests for the key-holding <see cref="MlKem"/> class, whose API mirrors
/// <c>System.Security.Cryptography.MLKem</c> from .NET 10.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MlKemApiTests
{
    private static readonly MlKemAlgorithm[] Algorithms =
    [
        MlKemAlgorithm.MlKem512,
        MlKemAlgorithm.MlKem768,
        MlKemAlgorithm.MlKem1024
    ];

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void GenerateKey_EncapsulateDecapsulate_RoundTrips(MlKemAlgorithm algorithm)
    {
        using var kem = MlKem.GenerateKey(algorithm);
        Assert.That(kem.Algorithm, Is.SameAs(algorithm));

        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        kem.Encapsulate(ct, ss1);

        byte[] ss2 = new byte[algorithm.SharedSecretSizeInBytes];
        kem.Decapsulate(ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1), "Decapsulated shared secret must match.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportPrivateSeed_ReproducesGeneratedKey(MlKemAlgorithm algorithm)
    {
        using var original = MlKem.GenerateKey(algorithm);
        byte[] seed = original.ExportPrivateSeed();
        Assert.That(seed, Has.Length.EqualTo(algorithm.PrivateSeedSizeInBytes));

        using var restored = MlKem.ImportPrivateSeed(algorithm, seed);
        Assert.That(restored.ExportPrivateSeed(), Is.EqualTo(seed));
        Assert.That(restored.ExportEncapsulationKey(), Is.EqualTo(original.ExportEncapsulationKey()));
        Assert.That(restored.ExportDecapsulationKey(), Is.EqualTo(original.ExportDecapsulationKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportEncapsulationKey_CanEncapsulateForOriginal(MlKemAlgorithm algorithm)
    {
        using var receiver = MlKem.GenerateKey(algorithm);

        using var sender = MlKem.ImportEncapsulationKey(algorithm, receiver.ExportEncapsulationKey());
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        sender.Encapsulate(ct, ss1);

        byte[] ss2 = new byte[algorithm.SharedSecretSizeInBytes];
        receiver.Decapsulate(ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportDecapsulationKey_CanDecapsulate_ButHasNoSeed(MlKemAlgorithm algorithm)
    {
        using var original = MlKem.GenerateKey(algorithm);
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        original.Encapsulate(ct, ss1);

        using var imported = MlKem.ImportDecapsulationKey(algorithm, original.ExportDecapsulationKey());
        byte[] ss2 = new byte[algorithm.SharedSecretSizeInBytes];
        imported.Decapsulate(ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
        Assert.That(imported.ExportEncapsulationKey(), Is.EqualTo(original.ExportEncapsulationKey()),
            "Embedded encapsulation key must be extracted on import.");
        Assert.That(() => imported.ExportPrivateSeed(), Throws.InstanceOf<CryptographicException>(),
            "A key imported from an expanded decapsulation key has no seed.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportDecapsulationKey_TamperedHash_Throws(MlKemAlgorithm algorithm)
    {
        using var original = MlKem.GenerateKey(algorithm);
        byte[] dk = original.ExportDecapsulationKey();

        // Corrupt the stored H(ekPKE): dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z.
        dk[dk.Length - 64] ^= 0x01;

        Assert.That(() => MlKem.ImportDecapsulationKey(algorithm, dk),
            Throws.InstanceOf<CryptographicException>(),
            "FIPS 203 §7.3 hash check must reject a tampered decapsulation key.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportEncapsulationKey_CoefficientOutOfRange_Throws(MlKemAlgorithm algorithm)
    {
        using var original = MlKem.GenerateKey(algorithm);
        byte[] ek = original.ExportEncapsulationKey();

        // Force the first 12-bit coefficient to 0xFFF (≥ q = 3329).
        ek[0] = 0xFF;
        ek[1] |= 0x0F;

        Assert.That(() => MlKem.ImportEncapsulationKey(algorithm, ek),
            Throws.InstanceOf<CryptographicException>(),
            "FIPS 203 §7.2 modulus check must reject an out-of-range coefficient.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncapsulationOnlyKey_CannotDecapsulateOrExportPrivate(MlKemAlgorithm algorithm)
    {
        using var original = MlKem.GenerateKey(algorithm);
        using var publicOnly = MlKem.ImportEncapsulationKey(algorithm, original.ExportEncapsulationKey());

        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss = new byte[algorithm.SharedSecretSizeInBytes];

        Assert.That(() => publicOnly.Decapsulate(ct, ss), Throws.InstanceOf<CryptographicException>());
        Assert.That(() => publicOnly.ExportDecapsulationKey(), Throws.InstanceOf<CryptographicException>());
        Assert.That(() => publicOnly.ExportPrivateSeed(), Throws.InstanceOf<CryptographicException>());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void InvalidBufferSizes_Throw(MlKemAlgorithm algorithm)
    {
        using var kem = MlKem.GenerateKey(algorithm);

        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss = new byte[algorithm.SharedSecretSizeInBytes];

        Assert.That(() => kem.Encapsulate(new byte[ct.Length - 1], ss), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.Encapsulate(ct, new byte[ss.Length + 1]), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.Decapsulate(new byte[ct.Length + 1], ss), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.ExportEncapsulationKey(new byte[algorithm.EncapsulationKeySizeInBytes - 1]),
            Throws.InstanceOf<ArgumentException>());
        Assert.That(() => MlKem.ImportPrivateSeed(algorithm, new byte[32]), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Dispose_BlocksFurtherUse()
    {
        var kem = MlKem.GenerateKey(MlKemAlgorithm.MlKem512);
        byte[] ct = new byte[kem.Algorithm.CiphertextSizeInBytes];
        byte[] ss = new byte[kem.Algorithm.SharedSecretSizeInBytes];

        kem.Dispose();
        kem.Dispose(); // Double dispose must be harmless.

        Assert.That(() => kem.Encapsulate(ct, ss), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => kem.Decapsulate(ct, ss), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => kem.ExportPrivateSeed(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => kem.ExportEncapsulationKey(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => kem.ExportDecapsulationKey(), Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void AlgorithmDescriptors_ReportFips203Sizes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MlKemAlgorithm.MlKem512.EncapsulationKeySizeInBytes, Is.EqualTo(800));
            Assert.That(MlKemAlgorithm.MlKem512.DecapsulationKeySizeInBytes, Is.EqualTo(1632));
            Assert.That(MlKemAlgorithm.MlKem512.CiphertextSizeInBytes, Is.EqualTo(768));
            Assert.That(MlKemAlgorithm.MlKem768.EncapsulationKeySizeInBytes, Is.EqualTo(1184));
            Assert.That(MlKemAlgorithm.MlKem768.DecapsulationKeySizeInBytes, Is.EqualTo(2400));
            Assert.That(MlKemAlgorithm.MlKem768.CiphertextSizeInBytes, Is.EqualTo(1088));
            Assert.That(MlKemAlgorithm.MlKem1024.EncapsulationKeySizeInBytes, Is.EqualTo(1568));
            Assert.That(MlKemAlgorithm.MlKem1024.DecapsulationKeySizeInBytes, Is.EqualTo(3168));
            Assert.That(MlKemAlgorithm.MlKem1024.CiphertextSizeInBytes, Is.EqualTo(1568));
            Assert.That(MlKemAlgorithm.MlKem768.SharedSecretSizeInBytes, Is.EqualTo(32));
            Assert.That(MlKemAlgorithm.MlKem768.PrivateSeedSizeInBytes, Is.EqualTo(64));
            Assert.That(MlKemAlgorithm.MlKem768.Name, Is.EqualTo("ML-KEM-768"));
            Assert.That(MlKemAlgorithm.MlKem768.ToString(), Is.EqualTo("ML-KEM-768"));
        });
    }
}
