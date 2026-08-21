// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Tests for the key-holding <see cref="MLKem"/> class, whose API mirrors
/// <c>System.Security.Cryptography.MLKem</c> from .NET 10.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLKemApiTests
{
    private static readonly MLKemAlgorithm[] Algorithms =
    [
        MLKemAlgorithm.MLKem512,
        MLKemAlgorithm.MLKem768,
        MLKemAlgorithm.MLKem1024
    ];

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void GenerateKey_EncapsulateDecapsulate_RoundTrips(MLKemAlgorithm algorithm)
    {
        using var kem = MLKem.GenerateKey(algorithm);
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
    public void ImportPrivateSeed_ReproducesGeneratedKey(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        byte[] seed = original.ExportPrivateSeed();
        Assert.That(seed, Has.Length.EqualTo(algorithm.PrivateSeedSizeInBytes));

        using var restored = MLKem.ImportPrivateSeed(algorithm, seed);
        Assert.That(restored.ExportPrivateSeed(), Is.EqualTo(seed));
        Assert.That(restored.ExportEncapsulationKey(), Is.EqualTo(original.ExportEncapsulationKey()));
        Assert.That(restored.ExportDecapsulationKey(), Is.EqualTo(original.ExportDecapsulationKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportEncapsulationKey_CanEncapsulateForOriginal(MLKemAlgorithm algorithm)
    {
        using var receiver = MLKem.GenerateKey(algorithm);

        using var sender = MLKem.ImportEncapsulationKey(algorithm, receiver.ExportEncapsulationKey());
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        sender.Encapsulate(ct, ss1);

        byte[] ss2 = new byte[algorithm.SharedSecretSizeInBytes];
        receiver.Decapsulate(ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportDecapsulationKey_CanDecapsulate_ButHasNoSeed(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        original.Encapsulate(ct, ss1);

        using var imported = MLKem.ImportDecapsulationKey(algorithm, original.ExportDecapsulationKey());
        byte[] ss2 = new byte[algorithm.SharedSecretSizeInBytes];
        imported.Decapsulate(ct, ss2);

        Assert.That(ss2, Is.EqualTo(ss1));
        Assert.That(imported.ExportEncapsulationKey(), Is.EqualTo(original.ExportEncapsulationKey()),
            "Embedded encapsulation key must be extracted on import.");
        Assert.That(() => imported.ExportPrivateSeed(), Throws.InstanceOf<OS.CryptographicException>(),
            "A key imported from an expanded decapsulation key has no seed.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportDecapsulationKey_TamperedHash_Throws(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        byte[] dk = original.ExportDecapsulationKey();

        // Corrupt the stored H(ekPKE): dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z.
        dk[^64] ^= 0x01;

        Assert.That(() => MLKem.ImportDecapsulationKey(algorithm, dk),
            Throws.InstanceOf<OS.CryptographicException>(),
            "FIPS 203 §7.3 hash check must reject a tampered decapsulation key.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportEncapsulationKey_CoefficientOutOfRange_Throws(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        byte[] ek = original.ExportEncapsulationKey();

        // Force the first 12-bit coefficient to 0xFFF (≥ q = 3329).
        ek[0] = 0xFF;
        ek[1] |= 0x0F;

        Assert.That(() => MLKem.ImportEncapsulationKey(algorithm, ek),
            Throws.InstanceOf<OS.CryptographicException>(),
            "FIPS 203 §7.2 modulus check must reject an out-of-range coefficient.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EncapsulationOnlyKey_CannotDecapsulateOrExportPrivate(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        using var publicOnly = MLKem.ImportEncapsulationKey(algorithm, original.ExportEncapsulationKey());

        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss = new byte[algorithm.SharedSecretSizeInBytes];

        Assert.That(() => publicOnly.Decapsulate(ct, ss), Throws.InstanceOf<OS.CryptographicException>());
        Assert.That(() => publicOnly.ExportDecapsulationKey(), Throws.InstanceOf<OS.CryptographicException>());
        Assert.That(() => publicOnly.ExportPrivateSeed(), Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void InvalidBufferSizes_Throw(MLKemAlgorithm algorithm)
    {
        using var kem = MLKem.GenerateKey(algorithm);

        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss = new byte[algorithm.SharedSecretSizeInBytes];

        Assert.That(() => kem.Encapsulate(new byte[ct.Length - 1], ss), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.Encapsulate(ct, new byte[ss.Length + 1]), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.Decapsulate(new byte[ct.Length + 1], ss), Throws.InstanceOf<ArgumentException>());
        Assert.That(() => kem.ExportEncapsulationKey(new byte[algorithm.EncapsulationKeySizeInBytes - 1]),
            Throws.InstanceOf<ArgumentException>());
        Assert.That(() => MLKem.ImportPrivateSeed(algorithm, new byte[32]), Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Dispose_BlocksFurtherUse()
    {
        var kem = MLKem.GenerateKey(MLKemAlgorithm.MLKem512);
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
        Assert.Multiple(() => {
            Assert.That(MLKemAlgorithm.MLKem512.EncapsulationKeySizeInBytes, Is.EqualTo(800));
            Assert.That(MLKemAlgorithm.MLKem512.DecapsulationKeySizeInBytes, Is.EqualTo(1632));
            Assert.That(MLKemAlgorithm.MLKem512.CiphertextSizeInBytes, Is.EqualTo(768));
            Assert.That(MLKemAlgorithm.MLKem768.EncapsulationKeySizeInBytes, Is.EqualTo(1184));
            Assert.That(MLKemAlgorithm.MLKem768.DecapsulationKeySizeInBytes, Is.EqualTo(2400));
            Assert.That(MLKemAlgorithm.MLKem768.CiphertextSizeInBytes, Is.EqualTo(1088));
            Assert.That(MLKemAlgorithm.MLKem1024.EncapsulationKeySizeInBytes, Is.EqualTo(1568));
            Assert.That(MLKemAlgorithm.MLKem1024.DecapsulationKeySizeInBytes, Is.EqualTo(3168));
            Assert.That(MLKemAlgorithm.MLKem1024.CiphertextSizeInBytes, Is.EqualTo(1568));
            Assert.That(MLKemAlgorithm.MLKem768.SharedSecretSizeInBytes, Is.EqualTo(32));
            Assert.That(MLKemAlgorithm.MLKem768.PrivateSeedSizeInBytes, Is.EqualTo(64));
            Assert.That(MLKemAlgorithm.MLKem768.Name, Is.EqualTo("ML-KEM-768"));
            Assert.That(MLKemAlgorithm.MLKem768.ToString(), Is.EqualTo("ML-KEM-768"));
        });
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportPrivateSeed_IsDeterministic_AndMatchesPctFreeExpansion(MLKemAlgorithm algorithm)
    {
        byte[] seed = new byte[algorithm.PrivateSeedSizeInBytes];
        for (int i = 0; i < seed.Length; i++)
        {
            seed[i] = (byte)((i * 31 + 13) & 0xFF);
        }

        using var withCheck = MLKem.ImportPrivateSeed(algorithm, seed);
        using var withoutCheck = MLKem.ImportPrivateSeed(algorithm, seed, performPairwiseConsistencyTest: false);

        // Skipping the consistency test must not change the key it produces, and expanding
        // the same seed twice must be bit-identical — the test message is derived from the
        // seed, so no randomness enters key expansion at all.
        Assert.Multiple(() => {
            Assert.That(withoutCheck.ExportEncapsulationKey(), Is.EqualTo(withCheck.ExportEncapsulationKey()));
            Assert.That(withoutCheck.ExportDecapsulationKey(), Is.EqualTo(withCheck.ExportDecapsulationKey()));
            Assert.That(withoutCheck.ExportPrivateSeed(), Is.EqualTo(seed));
        });

        // And the key still works with the check disabled.
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] ss1 = new byte[algorithm.SharedSecretSizeInBytes];
        withoutCheck.Encapsulate(ct, ss1);
        Assert.That(withCheck.Decapsulate(ct), Is.EqualTo(ss1));
    }

    [Test]
    public void GenerateKey_PctOptOut_ProducesUsableKeys()
    {
        using var kem = MLKem.GenerateKey(MLKemAlgorithm.MLKem768, performPairwiseConsistencyTest: false);

        kem.Encapsulate(out byte[] ciphertext, out byte[] senderSecret);
        Assert.That(kem.Decapsulate(ciphertext), Is.EqualTo(senderSecret));
    }

    [Test]
    public void IsSupported_IsAlwaysTrue()
    {
        // Unlike the in-box MLKem, the managed implementation never depends on OS support.
        Assert.That(MLKem.IsSupported, Is.True);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ByteArrayOverloads_RoundTrip(MLKemAlgorithm algorithm)
    {
        using var receiver = MLKem.GenerateKey(algorithm);
        using var sender = MLKem.ImportEncapsulationKey(algorithm, receiver.ExportEncapsulationKey());

        sender.Encapsulate(out byte[] ciphertext, out byte[] senderSecret);

        Assert.Multiple(() => {
            Assert.That(ciphertext, Has.Length.EqualTo(algorithm.CiphertextSizeInBytes));
            Assert.That(senderSecret, Has.Length.EqualTo(algorithm.SharedSecretSizeInBytes));
        });

        Assert.That(receiver.Decapsulate(ciphertext), Is.EqualTo(senderSecret),
            "The byte[] overloads must agree with each other.");

        // ...and with the span overloads.
        byte[] viaSpan = new byte[algorithm.SharedSecretSizeInBytes];
        receiver.Decapsulate(ciphertext, viaSpan);
        Assert.That(viaSpan, Is.EqualTo(senderSecret));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ByteArrayImporters_MatchSpanImporters(MLKemAlgorithm algorithm)
    {
        using var original = MLKem.GenerateKey(algorithm);
        byte[] seed = original.ExportPrivateSeed();
        byte[] dk = original.ExportDecapsulationKey();
        byte[] ek = original.ExportEncapsulationKey();

        using var fromSeed = MLKem.ImportPrivateSeed(algorithm, seed);
        using var fromDk = MLKem.ImportDecapsulationKey(algorithm, dk);
        using var fromEk = MLKem.ImportEncapsulationKey(algorithm, ek);

        Assert.Multiple(() => {
            Assert.That(fromSeed.ExportDecapsulationKey(), Is.EqualTo(dk));
            Assert.That(fromDk.ExportEncapsulationKey(), Is.EqualTo(ek));
            Assert.That(fromEk.ExportEncapsulationKey(), Is.EqualTo(ek));
        });
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ByteArrayImporters_NullSource_Throws(MLKemAlgorithm algorithm)
    {
        Assert.Multiple(() => {
            Assert.That(() => MLKem.ImportPrivateSeed(algorithm, (byte[])null!),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => MLKem.ImportDecapsulationKey(algorithm, (byte[])null!),
                Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => MLKem.ImportEncapsulationKey(algorithm, (byte[])null!),
                Throws.InstanceOf<ArgumentNullException>());
        });
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void Decapsulate_ByteArray_ValidatesLengthAndNull(MLKemAlgorithm algorithm)
    {
        using var kem = MLKem.GenerateKey(algorithm);

        Assert.Multiple(() => {
            Assert.That(() => kem.Decapsulate((byte[])null!), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => kem.Decapsulate(new byte[algorithm.CiphertextSizeInBytes + 1]),
                Throws.InstanceOf<ArgumentException>());
        });
    }

    [Test]
    public void Encapsulate_OverlappingBuffers_Throws()
    {
        MLKemAlgorithm algorithm = MLKemAlgorithm.MLKem768;
        using var kem = MLKem.GenerateKey(algorithm);

        // One backing array carrying both buffers, deliberately overlapping.
        byte[] buffer = new byte[algorithm.CiphertextSizeInBytes + algorithm.SharedSecretSizeInBytes];

        Assert.That(
            () => kem.Encapsulate(
                buffer.AsSpan(0, algorithm.CiphertextSizeInBytes),
                buffer.AsSpan(algorithm.CiphertextSizeInBytes - 1, algorithm.SharedSecretSizeInBytes)),
            Throws.InstanceOf<OS.CryptographicException>(),
            "Overlapping buffers must be rejected, as the in-box MLKem does.");
    }

    [Test]
    public void AlgorithmDescriptors_HaveValueEquality()
    {
        MLKemAlgorithm mlKem768 = MLKemAlgorithm.MLKem768;
        MLKemAlgorithm mlKem512 = MLKemAlgorithm.MLKem512;
        MLKemAlgorithm mlKem1024 = MLKemAlgorithm.MLKem1024;
        MLKemAlgorithm? nothing = null;
        object foreignType = "ML-KEM-768";

        Assert.Multiple(() => {
            Assert.That(mlKem768 == MLKemAlgorithm.MLKem768, Is.True);
            Assert.That(mlKem768 != mlKem512, Is.True);
            Assert.That(mlKem768.Equals(MLKemAlgorithm.MLKem768), Is.True);
            Assert.That(mlKem768.Equals((object)MLKemAlgorithm.MLKem768), Is.True);
            Assert.That(mlKem768.Equals(mlKem1024), Is.False);
            Assert.That(mlKem768.Equals(nothing), Is.False);
            Assert.That(mlKem768.Equals(foreignType), Is.False, "Equals(object) must reject other types.");

            // Null handling must not throw and must not report a match.
            Assert.That(nothing == mlKem512, Is.False);
            Assert.That(mlKem512 == nothing, Is.False);
            Assert.That(nothing == null, Is.True);
        });

        // The behavioural point of GetHashCode: the singletons work as dictionary keys.
        var seen = new System.Collections.Generic.HashSet<MLKemAlgorithm>(Algorithms);
        Assert.Multiple(() => {
            Assert.That(seen, Has.Count.EqualTo(3), "The three parameter sets must be distinct.");
            Assert.That(seen.Contains(MLKemAlgorithm.MLKem768), Is.True);
        });
    }
}
