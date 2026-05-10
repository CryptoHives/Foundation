// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class X448Tests
{
    // ========================================================================
    // RFC 7748 §6.2 Test Vectors
    // ========================================================================

    [Test]
    public void Rfc7748ScalarMult1()
    {
        byte[] scalar = TestHelpers.FromHexString(
            "3d262fddf9ec8e88495266fea19a34d28882acef045104d0d1aae121" +
            "700a779c984c24f8cdd78fbff44943eba368f54b29259a4f1c600ad3");
        byte[] u = TestHelpers.FromHexString(
            "06fce640fa3487bfda5f6cf2d5263f8aad88334cbd07437f020f08f9" +
            "814dc031ddbdc38c19c6da2583fa5429db94ada18aa7a7fb4ef8a086");
        byte[] expected = TestHelpers.FromHexString(
            "ce3e4ff95a60dc6697da1db1d85e6afbdf79b50a2412d7546d5f239f" +
            "e14fbaadeb445fc66a01b0779d98223961111e21766282f73dd96b6f");

        byte[] result = new byte[56];
        X448.ScalarMult(scalar, u, result);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc7748ScalarMult2()
    {
        byte[] scalar = TestHelpers.FromHexString(
            "203d494428b8399352665ddca42f9de8fef600908e0d461cb021f8c5" +
            "38345dd77c3e4806e25f46d3315c44e0a5b4371282dd2c8d5be3095f");
        byte[] u = TestHelpers.FromHexString(
            "0fbcc2f993cd56d3305b0b7d9e55d4c1a8fb5dbb52f8e9a1e9b6201b" +
            "165d015894e56c4d3570bee52fe205e28a78b91cdfbde71ce8d157db");
        byte[] expected = TestHelpers.FromHexString(
            "884a02576239ff7a2f2f63b2db6a9ff37047ac13568e1e30fe63c4a7" +
            "ad1b3ee3a5700df34321d62077e63633c575c1c954514e99da7c179d");

        byte[] result = new byte[56];
        X448.ScalarMult(scalar, u, result);

        Assert.That(result, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 7748 §6.2 ECDH Test Vector
    // ========================================================================

    [Test]
    public void Rfc7748DiffieHellman()
    {
        byte[] alicePriv = TestHelpers.FromHexString(
            "9a8f4925d1519f5775cf46b04b5800d4ee9ee8bae8bc5565d498c28d" +
            "d9c9baf574a9419744897391006382a6f127ab1d9ac2d8c0a598726b");
        byte[] alicePub = TestHelpers.FromHexString(
            "9b08f7cc31b7e3e67d22d5aea121074a273bd2b83de09c63faa73d2c" +
            "22c5d9bbc836647241d953d40c5b12da88120d53177f80e532c41fa0");
        byte[] bobPriv = TestHelpers.FromHexString(
            "1c306a7ac2a0e2e0990b294470cba339e6453772b075811d8fad0d1d" +
            "6927c120bb5ee8972b0d3e21374c9c921b09d1b0366f10b65173992d");
        byte[] bobPub = TestHelpers.FromHexString(
            "3eb7a829b0cd20f5bcfc0b599b6feccf6da4627107bdb0d4f345b430" +
            "27d8b972fc3e34fb4232a13ca706dcb57aec3dae07bdc1c67bf33609");
        byte[] expectedShared = TestHelpers.FromHexString(
            "07fff4181ac6cc95ec1c16a94a0f74d12da232ce40a77552281d282b" +
            "b60c0b56fd2464c335543936521c24403085d59a449a5037514a879d");

        // Verify Alice's public key
        byte[] alicePubComputed = new byte[56];
        X448.ScalarMultBase(alicePriv, alicePubComputed);
        Assert.That(alicePubComputed, Is.EqualTo(alicePub), "Alice public key mismatch");

        // Verify Bob's public key
        byte[] bobPubComputed = new byte[56];
        X448.ScalarMultBase(bobPriv, bobPubComputed);
        Assert.That(bobPubComputed, Is.EqualTo(bobPub), "Bob public key mismatch");

        // Alice computes shared secret
        byte[] aliceShared = new byte[56];
        X448.ScalarMult(alicePriv, bobPub, aliceShared);
        Assert.That(aliceShared, Is.EqualTo(expectedShared), "Alice shared secret mismatch");

        // Bob computes shared secret
        byte[] bobShared = new byte[56];
        X448.ScalarMult(bobPriv, alicePub, bobShared);
        Assert.That(bobShared, Is.EqualTo(expectedShared), "Bob shared secret mismatch");
    }

    // ========================================================================
    // RFC 7748 Iterated Test
    // ========================================================================

    [Test]
    public void Rfc7748IteratedOneStep()
    {
        // k = u = 5 (base point). After one iteration, k = X448(old_k, old_u), u = old_k.
        byte[] k = new byte[56];
        k[0] = 5;
        byte[] u = new byte[56];
        u[0] = 5;

        byte[] result = new byte[56];
        X448.ScalarMult(k, u, result);

        byte[] expected = TestHelpers.FromHexString(
            "3f482c8a9f19b01e6c46ee9711d9dc14fd4bf67af30765c2ae2b846a" +
            "4d23a8cd0db897086239492caf350b51f833868b9bc2b3bca9cf4113");

        Assert.That(result, Is.EqualTo(expected));
    }

    // ========================================================================
    // BouncyCastle Cross-Validation
    // ========================================================================

    [Test]
    public void CrossValidateWithBouncyCastle()
    {
        byte[] privateKey = new byte[56];
        new Random(42).NextBytes(privateKey);

        // Our implementation
        byte[] ourPub = new byte[56];
        X448.ScalarMultBase(privateKey, ourPub);

        // BouncyCastle
        var bcPriv = new Org.BouncyCastle.Crypto.Parameters.X448PrivateKeyParameters(privateKey);
        byte[] bcPub = bcPriv.GeneratePublicKey().GetEncoded();

        Assert.That(ourPub, Is.EqualTo(bcPub),
            $"Mismatch!\nOurs: {BitConverter.ToString(ourPub).Replace("-","")}\n" +
            $"BC:   {BitConverter.ToString(bcPub).Replace("-","")}");
    }
}

