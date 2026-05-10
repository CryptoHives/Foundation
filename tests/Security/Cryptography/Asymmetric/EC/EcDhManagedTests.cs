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
public class EcDhManagedTests
{
    // ========================================================================
    // ECDH Key Agreement Round-Trip
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void SharedSecretAgreement(string curveName)
    {
        var curve = ECCurve.CreateFromFriendlyName(curveName);

        // Generate two key pairs using BCL
        using var alice = ECDiffieHellman.Create(curve);
        using var bob = ECDiffieHellman.Create(curve);

        var aliceParams = alice.ExportParameters(true);
        var bobParams = bob.ExportParameters(true);

        // Alice computes shared secret with Bob's public key
        using var aliceManaged = new EcDhManaged();
        aliceManaged.ImportParameters(aliceParams);
        byte[] aliceSecret = aliceManaged.DeriveRawSecretAgreement(bob.ExportParameters(false));

        // Bob computes shared secret with Alice's public key
        using var bobManaged = new EcDhManaged();
        bobManaged.ImportParameters(bobParams);
        byte[] bobSecret = bobManaged.DeriveRawSecretAgreement(alice.ExportParameters(false));

        // Both should derive the same shared secret
        Assert.That(aliceSecret, Is.EqualTo(bobSecret));
    }

    // ========================================================================
    // Cross-Validation with BCL
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    public void CrossValidateWithBcl(string curveName)
    {
        var curve = ECCurve.CreateFromFriendlyName(curveName);

        using var alice = ECDiffieHellman.Create(curve);
        using var bob = ECDiffieHellman.Create(curve);

        var aliceParams = alice.ExportParameters(true);
        var bobPubParams = bob.ExportParameters(false);

        // BCL shared secret
        byte[] bclSecret = alice.DeriveRawSecretAgreement(bob.PublicKey);

        // Our managed shared secret
        using var managed = new EcDhManaged();
        managed.ImportParameters(aliceParams);
        byte[] managedSecret = managed.DeriveRawSecretAgreement(bobPubParams);

        Assert.That(managedSecret, Is.EqualTo(bclSecret));
    }

    // ========================================================================
    // Invalid Public Key
    // ========================================================================

    [Test]
    public void InvalidPublicKeyThrows()
    {
        using var alice = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
        var aliceParams = alice.ExportParameters(true);

        using var managed = new EcDhManaged();
        managed.ImportParameters(aliceParams);

        // Create an invalid public key
        var badParams = new ECParameters
        {
            Curve = ECCurve.NamedCurves.nistP256,
            Q = new ECPoint
            {
                X = new byte[32],
                Y = new byte[32]
            }
        };
        badParams.Q.X[^1] = 1;
        badParams.Q.Y[^1] = 1;

        Assert.Throws<CryptographicException>(() => managed.DeriveRawSecretAgreement(badParams));
    }
}

#endif
