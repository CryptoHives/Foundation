// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class X25519Tests
{
    // ========================================================================
    // RFC 7748 §6.1 Test Vectors
    // ========================================================================

    [Test]
    public void Rfc7748Vector1()
    {
        byte[] scalarAlice = TestHelpers.FromHexString(
            "77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a");
        byte[] basePoint = new byte[32];
        basePoint[0] = 9;

        byte[] result = new byte[32];
        X25519.ScalarMult(scalarAlice, basePoint, result);

        byte[] expected = TestHelpers.FromHexString(
            "8520f0098930a754748b7ddcb43ef75a0dbf3a0d26381af4eba4a98eaa9b4e6a");
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc7748Vector2()
    {
        byte[] scalarBob = TestHelpers.FromHexString(
            "5dab087e624a8a4b79e17f8b83800ee66f3bb1292618b6fd1c2f8b27ff88e0eb");
        byte[] basePoint = new byte[32];
        basePoint[0] = 9;

        byte[] result = new byte[32];
        X25519.ScalarMult(scalarBob, basePoint, result);

        byte[] expected = TestHelpers.FromHexString(
            "de9edb7d7b7dc1b4d35b61c2ece435373f8343c85b78674dadfc7e146f882b4f");
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc7748SharedSecret()
    {
        // Alice's scalar * Bob's public key should equal Bob's scalar * Alice's public key
        byte[] scalarAlice = TestHelpers.FromHexString(
            "77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a");
        byte[] scalarBob = TestHelpers.FromHexString(
            "5dab087e624a8a4b79e17f8b83800ee66f3bb1292618b6fd1c2f8b27ff88e0eb");

        byte[] basePoint = new byte[32];
        basePoint[0] = 9;

        byte[] pubAlice = new byte[32];
        byte[] pubBob = new byte[32];
        X25519.ScalarMult(scalarAlice, basePoint, pubAlice);
        X25519.ScalarMult(scalarBob, basePoint, pubBob);

        byte[] secretAlice = new byte[32];
        byte[] secretBob = new byte[32];
        X25519.ScalarMult(scalarAlice, pubBob, secretAlice);
        X25519.ScalarMult(scalarBob, pubAlice, secretBob);

        byte[] expected = TestHelpers.FromHexString(
            "4a5d9d5ba4ce2de1728e3bf480350f25e07e21c947d19e3376f09b3c1e161742");
        Assert.That(secretAlice, Is.EqualTo(expected));
        Assert.That(secretBob, Is.EqualTo(expected));
    }

    // ========================================================================
    // Key Generation
    // ========================================================================

    [Test]
    public void ScalarMultBaseReturnsPublicKey()
    {
        byte[] privKey = TestHelpers.FromHexString(
            "77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a");
        byte[] pubKey = new byte[32];
        X25519.ScalarMultBase(privKey, pubKey);

        byte[] expected = TestHelpers.FromHexString(
            "8520f0098930a754748b7ddcb43ef75a0dbf3a0d26381af4eba4a98eaa9b4e6a");
        Assert.That(pubKey, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 7748 §5.2 Iterated Test (1 iteration)
    // ========================================================================

    [Test]
    public void IteratedTestOneIteration()
    {
        // Starting values per RFC 7748 §5.2
        byte[] k = new byte[32];
        k[0] = 9;
        byte[] u = new byte[32];
        u[0] = 9;

        byte[] output = new byte[32];
        X25519.ScalarMult(k, u, output);

        byte[] expected = TestHelpers.FromHexString(
            "422c8e7a6227d7bca1350b3e2bb7279f7897b87bb6854b783c60e80311ae3079");
        Assert.That(output, Is.EqualTo(expected));
    }
}
