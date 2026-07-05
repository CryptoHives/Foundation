// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using SlhDsa = CryptoHives.Foundation.Security.Cryptography.Dsa.SlhDsa;
using SlhDsaAlgorithm = CryptoHives.Foundation.Security.Cryptography.Dsa.SlhDsaAlgorithm;

/// <summary>
/// Tests for the key-holding <see cref="SlhDsa"/> class (FIPS 205), whose API mirrors
/// <c>System.Security.Cryptography.SlhDsa</c> from .NET 10.
/// </summary>
/// <remarks>
/// The default suite exercises the fast (f) parameter sets; the slow full-matrix
/// round-trip over all 12 sets is opt-in via the "Slow" category.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaTests
{
    private static readonly SlhDsaAlgorithm[] FastAlgorithms =
    [
        SlhDsaAlgorithm.SlhDsaSha2_128f,
        SlhDsaAlgorithm.SlhDsaShake128f,
        SlhDsaAlgorithm.SlhDsaSha2_192f,
        SlhDsaAlgorithm.SlhDsaShake192f
    ];

    private static readonly SlhDsaAlgorithm[] AllAlgorithms =
    [
        SlhDsaAlgorithm.SlhDsaSha2_128s, SlhDsaAlgorithm.SlhDsaShake128s,
        SlhDsaAlgorithm.SlhDsaSha2_128f, SlhDsaAlgorithm.SlhDsaShake128f,
        SlhDsaAlgorithm.SlhDsaSha2_192s, SlhDsaAlgorithm.SlhDsaShake192s,
        SlhDsaAlgorithm.SlhDsaSha2_192f, SlhDsaAlgorithm.SlhDsaShake192f,
        SlhDsaAlgorithm.SlhDsaSha2_256s, SlhDsaAlgorithm.SlhDsaShake256s,
        SlhDsaAlgorithm.SlhDsaSha2_256f, SlhDsaAlgorithm.SlhDsaShake256f
    ];

    [Test]
    [TestCaseSource(nameof(FastAlgorithms))]
    public void GenerateKey_SignVerify_RoundTrips(SlhDsaAlgorithm algorithm)
    {
        using var dsa = SlhDsa.GenerateKey(algorithm);
        Assert.That(dsa.Algorithm, Is.SameAs(algorithm));

        byte[] message = new byte[80];
        byte[] signature = dsa.SignData(message);
        Assert.That(signature, Has.Length.EqualTo(algorithm.SignatureSizeInBytes));

        Assert.That(dsa.VerifyData(message, signature), Is.True);
        Assert.That(dsa.VerifyData(message, signature, "other"u8), Is.False,
            "A signature must be bound to its context.");
    }

    [Test]
    [TestCaseSource(nameof(FastAlgorithms))]
    public void ImportSecretKey_CanSign(SlhDsaAlgorithm algorithm)
    {
        using var original = SlhDsa.GenerateKey(algorithm);
        byte[] message = new byte[33];

        using var imported = SlhDsa.ImportSecretKey(algorithm, original.ExportSecretKey());
        byte[] signature = imported.SignData(message);

        Assert.That(original.VerifyData(message, signature), Is.True);
        Assert.That(imported.ExportPublicKey(), Is.EqualTo(original.ExportPublicKey()),
            "The embedded public key must be extracted on import.");
    }

    [Test]
    [TestCaseSource(nameof(FastAlgorithms))]
    public void TamperedSignatureOrMessage_FailsVerification(SlhDsaAlgorithm algorithm)
    {
        using var dsa = SlhDsa.GenerateKey(algorithm);

        byte[] message = new byte[50];
        byte[] signature = dsa.SignData(message);

        byte[] tamperedSig = (byte[])signature.Clone();
        tamperedSig[0] ^= 0x01;
        Assert.That(dsa.VerifyData(message, tamperedSig), Is.False, "A tampered signature must not verify.");

        byte[] tamperedMsg = (byte[])message.Clone();
        tamperedMsg[0] ^= 0x01;
        Assert.That(dsa.VerifyData(tamperedMsg, signature), Is.False, "A tampered message must not verify.");
    }

    [Test]
    public void PublicOnlyKey_CannotSignOrExportSecret()
    {
        using var signer = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] message = new byte[16];
        byte[] signature = signer.SignData(message);

        using var verifier = SlhDsa.ImportPublicKey(SlhDsaAlgorithm.SlhDsaShake128f, signer.ExportPublicKey());
        Assert.That(verifier.VerifyData(message, signature), Is.True);
        Assert.That(() => verifier.SignData(message), Throws.InstanceOf<CryptographicException>());
        Assert.That(() => verifier.ExportSecretKey(), Throws.InstanceOf<CryptographicException>());
    }

    [Test]
    public void VerifyData_WrongSignatureLength_ReturnsFalse()
    {
        using var dsa = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] message = new byte[16];

        Assert.That(dsa.VerifyData(message, new byte[100]), Is.False,
            "A signature of the wrong length is invalid, not an error.");
    }

    [Test]
    public void InvalidSizes_Throw()
    {
        using var dsa = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] message = new byte[8];

        Assert.That(() => SlhDsa.ImportPublicKey(SlhDsaAlgorithm.SlhDsaShake128f, new byte[16]),
            Throws.InstanceOf<ArgumentException>());
        Assert.That(() => SlhDsa.ImportSecretKey(SlhDsaAlgorithm.SlhDsaShake128f, new byte[16]),
            Throws.InstanceOf<ArgumentException>());
        Assert.That(() => dsa.SignData(message, new byte[256]), Throws.InstanceOf<ArgumentException>(),
            "Context longer than 255 bytes must be rejected.");
    }

    [Test]
    public void Dispose_BlocksFurtherUse()
    {
        var dsa = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] message = new byte[8];
        byte[] signature = dsa.SignData(message);

        dsa.Dispose();
        dsa.Dispose(); // Double dispose must be harmless.

        Assert.That(() => dsa.SignData(message), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.VerifyData(message, signature), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportPublicKey(), Throws.InstanceOf<ObjectDisposedException>());
        Assert.That(() => dsa.ExportSecretKey(), Throws.InstanceOf<ObjectDisposedException>());
    }

    [Test]
    public void AlgorithmDescriptors_ReportFips205Sizes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(SlhDsaAlgorithm.SlhDsaSha2_128s.PublicKeySizeInBytes, Is.EqualTo(32));
            Assert.That(SlhDsaAlgorithm.SlhDsaSha2_128s.SecretKeySizeInBytes, Is.EqualTo(64));
            Assert.That(SlhDsaAlgorithm.SlhDsaSha2_128s.SignatureSizeInBytes, Is.EqualTo(7856));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake128f.SignatureSizeInBytes, Is.EqualTo(17088));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake192s.SignatureSizeInBytes, Is.EqualTo(16224));
            Assert.That(SlhDsaAlgorithm.SlhDsaSha2_192f.SignatureSizeInBytes, Is.EqualTo(35664));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake256s.SignatureSizeInBytes, Is.EqualTo(29792));
            Assert.That(SlhDsaAlgorithm.SlhDsaSha2_256f.SignatureSizeInBytes, Is.EqualTo(49856));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake256f.PublicKeySizeInBytes, Is.EqualTo(64));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake256f.SecretKeySizeInBytes, Is.EqualTo(128));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake128f.Name, Is.EqualTo("SLH-DSA-SHAKE-128f"));
            Assert.That(SlhDsaAlgorithm.SlhDsaShake128f.ToString(), Is.EqualTo("SLH-DSA-SHAKE-128f"));
        });
    }

    [Test]
    [Explicit("Slow: signs with every parameter set including the s (small) variants.")]
    [Category("Slow")]
    [TestCaseSource(nameof(AllAlgorithms))]
    public void FullMatrix_SignVerify_RoundTrips(SlhDsaAlgorithm algorithm)
    {
        using var dsa = SlhDsa.GenerateKey(algorithm);

        byte[] message = new byte[64];
        byte[] signature = dsa.SignData(message);

        Assert.That(dsa.VerifyData(message, signature), Is.True);
    }
}
