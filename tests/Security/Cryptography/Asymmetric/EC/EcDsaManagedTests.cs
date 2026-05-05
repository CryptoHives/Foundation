// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class EcDsaManagedTests
{
    // ========================================================================
    // ECDSA Sign / Verify Round-Trip
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void SignVerifyRoundTrip(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Test ECDSA sign/verify"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        byte[] signature = managed.SignHash(hash);
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Cross-Validation: Managed signs, BCL verifies
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void ManagedSignBclVerify(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross-validation managed→BCL"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        byte[] signature = managed.SignHash(hash);

        // BCL verification (IEEE P1363 format)
        bool valid = bclEcdsa.VerifyHash(hash, signature, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Cross-Validation: BCL signs, Managed verifies
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void BclSignManagedVerify(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross-validation BCL→managed"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        // BCL signs in IEEE P1363 format
        byte[] signature = bclEcdsa.SignHash(hash, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);

        bool valid = managed.VerifyHash(hash, signature);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Tampered signature fails
    // ========================================================================

    [Test]
    public void TamperedSignatureFails()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = SHA256.HashData("Original"u8.ToArray());
        byte[] signature = managed.SignHash(hash);

        // Tamper with signature
        signature[0] ^= 1;
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.False);
    }

    [Test]
    public void WrongHashFails()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash1 = SHA256.HashData("Message 1"u8.ToArray());
        byte[] hash2 = SHA256.HashData("Message 2"u8.ToArray());

        byte[] signature = managed.SignHash(hash1);
        bool valid = managed.VerifyHash(hash2, signature);

        Assert.That(valid, Is.False);
    }

    // ========================================================================
    // Key Import/Export
    // ========================================================================

    [Test]
    public void ExportImportRoundTrip()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var original = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(original);
        var exported = managed.ExportParameters(true);

        Assert.That(exported.Q.X, Is.EqualTo(original.Q.X));
        Assert.That(exported.Q.Y, Is.EqualTo(original.Q.Y));
        Assert.That(exported.D, Is.EqualTo(original.D));
    }
    // ========================================================================
    // Brainpool Curves
    // ========================================================================

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolSignVerifyRoundTrip(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = SHA256.HashData("Brainpool test"u8.ToArray());
        byte[] signature = managed.SignHash(hash);
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.True, $"Round-trip failed for {name}");
    }

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolManagedSignBclVerify(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = SHA256.HashData("Brainpool cross-validation"u8.ToArray());
        byte[] signature = managed.SignHash(hash);

        bool valid = bclEcdsa.VerifyHash(hash, signature, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
        Assert.That(valid, Is.True, $"Managed→BCL failed for {name}");
    }

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolBclSignManagedVerify(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = SHA256.HashData("Brainpool cross-validation BCL→managed"u8.ToArray());
        byte[] signature = bclEcdsa.SignHash(hash, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);

        bool valid = managed.VerifyHash(hash, signature);
        Assert.That(valid, Is.True, $"BCL→Managed failed for {name}");
    }
}

#endif
