// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MLDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Tests for the key-holding <see cref="MLDsa"/> class, whose API mirrors
/// <c>System.Security.Cryptography.MLDsa</c> from .NET 10.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLDsaApiTests
{
    private static readonly MLDsaAlgorithm[] Algorithms =
    [
        MLDsaAlgorithm.MLDsa44,
        MLDsaAlgorithm.MLDsa65,
        MLDsaAlgorithm.MLDsa87
    ];

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void GenerateKey_SignVerify_RoundTrips(MLDsaAlgorithm algorithm)
    {
        using var dsa = MLDsa.GenerateKey(algorithm);
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
    public void ImportPrivateSeed_ReproducesGeneratedKey(MLDsaAlgorithm algorithm)
    {
        using var original = MLDsa.GenerateKey(algorithm);
        byte[] seed = original.ExportMLDsaPrivateSeed();
        Assert.That(seed, Has.Length.EqualTo(algorithm.PrivateSeedSizeInBytes));

        using var restored = MLDsa.ImportMLDsaPrivateSeed(algorithm, seed);
        Assert.That(restored.ExportMLDsaPrivateSeed(), Is.EqualTo(seed));
        Assert.That(restored.ExportMLDsaPublicKey(), Is.EqualTo(original.ExportMLDsaPublicKey()));
        Assert.That(restored.ExportMLDsaPrivateKey(), Is.EqualTo(original.ExportMLDsaPrivateKey()));
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportSecretKey_CanSign_ButHasNoSeed(MLDsaAlgorithm algorithm)
    {
        using var original = MLDsa.GenerateKey(algorithm);
        byte[] message = new byte[42];

        using var imported = MLDsa.ImportMLDsaPrivateKey(algorithm, original.ExportMLDsaPrivateKey());
        byte[] signature = imported.SignData(message);

        Assert.That(original.VerifyData(message, signature), Is.True);
        Assert.That(imported.ExportMLDsaPublicKey(), Is.EqualTo(original.ExportMLDsaPublicKey()),
            "The public key must be reconstructed from the secret key on import.");
        Assert.That(() => imported.ExportMLDsaPrivateSeed(), Throws.InstanceOf<OS.CryptographicException>(),
            "A key imported from an expanded secret key has no seed.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportSecretKey_TamperedHash_Throws(MLDsaAlgorithm algorithm)
    {
        using var original = MLDsa.GenerateKey(algorithm);
        byte[] sk = original.ExportMLDsaPrivateKey();

        // Corrupt the embedded tr = H(pk): sk = ρ ‖ K ‖ tr ‖ …
        sk[64] ^= 0x01;

        Assert.That(() => MLDsa.ImportMLDsaPrivateKey(algorithm, sk),
            Throws.InstanceOf<OS.CryptographicException>(),
            "A secret key whose embedded public key hash does not match must be rejected.");
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportPublicKey_CanVerifyOnly(MLDsaAlgorithm algorithm)
    {
        using var signer = MLDsa.GenerateKey(algorithm);
        byte[] message = new byte[64];
        byte[] signature = signer.SignData(message);

        using var verifier = MLDsa.ImportMLDsaPublicKey(algorithm, signer.ExportMLDsaPublicKey());
        Assert.That(verifier.VerifyData(message, signature), Is.True);
        Assert.That(() => verifier.SignData(message), Throws.InstanceOf<OS.CryptographicException>());
        Assert.That(() => verifier.ExportMLDsaPrivateKey(), Throws.InstanceOf<OS.CryptographicException>());
        Assert.That(() => verifier.ExportMLDsaPrivateSeed(), Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void VerifyData_WrongSignatureLength_ReturnsFalse()
    {
        using var dsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] message = new byte[16];

        Assert.That(dsa.VerifyData(message, new byte[100]), Is.False,
            "A signature of the wrong length is invalid, not an error.");
    }

    [Test]
    public void Dispose_BlocksFurtherUse()
    {
        var dsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] message = new byte[8];
        byte[] signature = dsa.SignData(message);

        dsa.Dispose();
        dsa.Dispose(); // Double dispose must be harmless.

        Assert.That(() => dsa.SignData(message), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.VerifyData(message, signature), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportMLDsaPrivateSeed(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportMLDsaPublicKey(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportMLDsaPrivateKey(), Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void AlgorithmDescriptors_ReportFips204Sizes()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(MLDsaAlgorithm.MLDsa44.PublicKeySizeInBytes, Is.EqualTo(1312));
            Assert.That(MLDsaAlgorithm.MLDsa44.PrivateKeySizeInBytes, Is.EqualTo(2560));
            Assert.That(MLDsaAlgorithm.MLDsa44.SignatureSizeInBytes, Is.EqualTo(2420));
            Assert.That(MLDsaAlgorithm.MLDsa65.PublicKeySizeInBytes, Is.EqualTo(1952));
            Assert.That(MLDsaAlgorithm.MLDsa65.PrivateKeySizeInBytes, Is.EqualTo(4032));
            Assert.That(MLDsaAlgorithm.MLDsa65.SignatureSizeInBytes, Is.EqualTo(3309));
            Assert.That(MLDsaAlgorithm.MLDsa87.PublicKeySizeInBytes, Is.EqualTo(2592));
            Assert.That(MLDsaAlgorithm.MLDsa87.PrivateKeySizeInBytes, Is.EqualTo(4896));
            Assert.That(MLDsaAlgorithm.MLDsa87.SignatureSizeInBytes, Is.EqualTo(4627));
            Assert.That(MLDsaAlgorithm.MLDsa65.PrivateSeedSizeInBytes, Is.EqualTo(32));
            Assert.That(MLDsaAlgorithm.MLDsa65.MuSizeInBytes, Is.EqualTo(64));
            Assert.That(MLDsaAlgorithm.MLDsa65.Name, Is.EqualTo("ML-DSA-65"));
            Assert.That(MLDsaAlgorithm.MLDsa65.ToString(), Is.EqualTo("ML-DSA-65"));
        }
    }

    [Test]
    public void IsSupported_IsAlwaysTrue()
    {
        // Unlike the in-box MLDsa, the managed implementation never depends on OS support.
        Assert.That(MLDsa.IsSupported, Is.True);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ImportMLDsaPrivateSeed_IsDeterministic_AndMatchesPctFreeExpansion(MLDsaAlgorithm algorithm)
    {
        byte[] seed = new byte[algorithm.PrivateSeedSizeInBytes];
        for (int i = 0; i < seed.Length; i++)
        {
            seed[i] = (byte)((i * 31 + 13) & 0xFF);
        }

        using var withCheck = MLDsa.ImportMLDsaPrivateSeed(algorithm, seed);
        using var withoutCheck = MLDsa.ImportMLDsaPrivateSeed(algorithm, seed, pairwiseConsistencyTest: false);

        // Skipping the consistency test must not change the key it produces, and expanding
        // the same seed twice must be bit-identical — the test message is derived from the
        // seed, so no randomness enters key expansion at all.
        using (Assert.EnterMultipleScope())
        {
            Assert.That(withoutCheck.ExportMLDsaPublicKey(), Is.EqualTo(withCheck.ExportMLDsaPublicKey()));
            Assert.That(withoutCheck.ExportMLDsaPrivateKey(), Is.EqualTo(withCheck.ExportMLDsaPrivateKey()));
            Assert.That(withoutCheck.ExportMLDsaPrivateSeed(), Is.EqualTo(seed));
        }

        // And the key still works with the check disabled.
        byte[] message = new byte[24];
        Assert.That(withCheck.VerifyData(message, withoutCheck.SignData(message)), Is.True);
    }

    [Test]
    public void GenerateKey_PctOptOut_ProducesUsableKeys()
    {
        using var dsa = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65, pairwiseConsistencyTest: false);

        byte[] message = new byte[32];
        Assert.That(dsa.VerifyData(message, dsa.SignData(message)), Is.True);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ByteArrayOverloads_BehaveLikeTheSpanOverloads(MLDsaAlgorithm algorithm)
    {
        using var original = MLDsa.GenerateKey(algorithm);
        byte[] seed = original.ExportMLDsaPrivateSeed();
        byte[] message = [1, 2, 3, 4, 5];
        byte[] context = "ctx"u8.ToArray();

        // Every import has a byte[] overload alongside the span one, as the in-box type has.
        using var fromSeed = MLDsa.ImportMLDsaPrivateSeed(algorithm, seed);
        using var fromPrivateKey = MLDsa.ImportMLDsaPrivateKey(algorithm, original.ExportMLDsaPrivateKey());
        using var fromPublicKey = MLDsa.ImportMLDsaPublicKey(algorithm, original.ExportMLDsaPublicKey());

        byte[] signature = fromSeed.SignData(message, context);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromSeed.ExportMLDsaPublicKey(), Is.EqualTo(original.ExportMLDsaPublicKey()));
            Assert.That(fromPrivateKey.ExportMLDsaPublicKey(), Is.EqualTo(original.ExportMLDsaPublicKey()));
            Assert.That(fromPublicKey.VerifyData(message, signature, context), Is.True);
            Assert.That(fromPublicKey.VerifyData(message, signature), Is.False,
                "The byte[] overload must bind the context just as the span overload does.");
        }

        Assert.That(() => MLDsa.ImportMLDsaPrivateSeed(algorithm, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => MLDsa.ImportMLDsaPrivateKey(algorithm, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => MLDsa.ImportMLDsaPublicKey(algorithm, (byte[])null!),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void AlgorithmDescriptors_HaveValueEquality()
    {
        MLDsaAlgorithm mlDsa65 = MLDsaAlgorithm.MLDsa65;
        MLDsaAlgorithm mlDsa44 = MLDsaAlgorithm.MLDsa44;
        MLDsaAlgorithm mlDsa87 = MLDsaAlgorithm.MLDsa87;
        MLDsaAlgorithm? nothing = null;
        object foreignType = "ML-DSA-65";

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mlDsa65 == MLDsaAlgorithm.MLDsa65, Is.True);
            Assert.That(mlDsa65 != mlDsa44, Is.True);
            Assert.That(mlDsa65.Equals(MLDsaAlgorithm.MLDsa65), Is.True);
            Assert.That(mlDsa65.Equals((object)MLDsaAlgorithm.MLDsa65), Is.True);
            Assert.That(mlDsa65.Equals(mlDsa87), Is.False);
            Assert.That(mlDsa65.Equals(nothing), Is.False);
            Assert.That(mlDsa65.Equals(foreignType), Is.False, "Equals(object) must reject other types.");

            // Null handling must not throw and must not report a match.
            Assert.That(nothing == mlDsa44, Is.False);
            Assert.That(mlDsa44 == nothing, Is.False);
            Assert.That(nothing == null, Is.True);
        }

        // The behavioural point of GetHashCode: the singletons work as dictionary keys.
        var seen = new System.Collections.Generic.HashSet<MLDsaAlgorithm>(Algorithms);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(seen, Has.Count.EqualTo(3), "The three parameter sets must be distinct.");
            Assert.That(seen.Contains(MLDsaAlgorithm.MLDsa65), Is.True);
        }
    }
}
