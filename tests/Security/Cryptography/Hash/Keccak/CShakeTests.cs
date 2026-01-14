// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Digests;

/// <summary>
/// Tests for <see cref="CShake128"/> and <see cref="CShake256"/> hash algorithms.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CShakeTests
{
    /// <summary>
    /// Validate cSHAKE128 produces correct output size.
    /// </summary>
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    public void CShake128ProducesCorrectOutputSize(int outputBytes)
    {
        using var cshake = CShake128.Create(outputBytes);
        Assert.That(cshake.HashSize, Is.EqualTo(outputBytes * 8));
    }

    /// <summary>
    /// Validate cSHAKE256 produces correct output size.
    /// </summary>
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    [TestCase(256)]
    public void CShake256ProducesCorrectOutputSize(int outputBytes)
    {
        using var cshake = CShake256.Create(outputBytes);
        Assert.That(cshake.HashSize, Is.EqualTo(outputBytes * 8));
    }

    /// <summary>
    /// Validate cSHAKE128 algorithm name.
    /// </summary>
    [Test]
    public void CShake128AlgorithmName()
    {
        using var cshake = CShake128.Create();
        Assert.That(cshake.AlgorithmName, Is.EqualTo("cSHAKE128"));
    }

    /// <summary>
    /// Validate cSHAKE256 algorithm name.
    /// </summary>
    [Test]
    public void CShake256AlgorithmName()
    {
        using var cshake = CShake256.Create();
        Assert.That(cshake.AlgorithmName, Is.EqualTo("cSHAKE256"));
    }

    /// <summary>
    /// Test cSHAKE128 with NIST SP 800-185 test vector (Sample #1 with customization).
    /// </summary>
    [Test]
    public void CShake128NistTestVector1()
    {
        byte[] data = TestHelpers.FromHexString("00010203");
        string customization = "Email Signature";
        byte[] expected = TestHelpers.FromHexString("c1c36925b6409a04f1b504fcbca9d82b4017277cb5ed2b2065fc1d3814d5aaf5");

        using var cshake = CShake128.Create(32, "", customization);
        byte[] actual = cshake.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test cSHAKE128 with NIST SP 800-185 test vector (Sample #2 - 200 bytes input).
    /// </summary>
    [Test]
    public void CShake128NistTestVector2()
    {
        // 200 bytes from 0x00 to 0xC7
        byte[] data = new byte[200];
        for (int i = 0; i < 200; i++)
        {
            data[i] = (byte)i;
        }
        string customization = "Email Signature";
        byte[] expected = TestHelpers.FromHexString("c5221d50e4f822d96a2e8881a961420f294b7b24fe3d2094baed2c6524cc166b");

        using var cshake = CShake128.Create(32, "", customization);
        byte[] actual = cshake.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test cSHAKE256 with NIST SP 800-185 test vector.
    /// </summary>
    [Test]
    public void CShake256NistTestVector1()
    {
        byte[] data = TestHelpers.FromHexString("00010203");
        string customization = "Email Signature";
        // Full 64-byte vector from NIST SP 800-185
        byte[] expected = TestHelpers.FromHexString("d008828e2b80ac9d2218ffee1d070c48b8e4c87bff32c9699d5b6896eee0edd164020e2be0560858d9c00c037e34a96937c561a74c412bb4c746469527281c8c");

        using var cshake = CShake256.Create(64, "", customization);
        byte[] actual = cshake.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test cSHAKE128 matches BouncyCastle with empty customization (becomes SHAKE128).
    /// </summary>
    [Test]
    public void CShake128MatchesBouncyCastleEmptyCustomization()
    {
        byte[] input = Encoding.UTF8.GetBytes("test message");

        // BouncyCastle reference
        var bcDigest = new CShakeDigest(128, null, null);
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[32];
        bcDigest.OutputFinal(bcHash, 0, 32);

        // Our implementation
        using var ourDigest = CShake128.Create(32);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    /// <summary>
    /// Test cSHAKE256 matches BouncyCastle with empty customization (becomes SHAKE256).
    /// </summary>
    [Test]
    public void CShake256MatchesBouncyCastleEmptyCustomization()
    {
        byte[] input = Encoding.UTF8.GetBytes("test message");

        // BouncyCastle reference
        var bcDigest = new CShakeDigest(256, null, null);
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcDigest.OutputFinal(bcHash, 0, 64);

        // Our implementation
        using var ourDigest = CShake256.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    /// <summary>
    /// Test cSHAKE128 matches BouncyCastle with customization.
    /// </summary>
    [Test]
    public void CShake128MatchesBouncyCastleWithCustomization()
    {
        byte[] input = Encoding.UTF8.GetBytes("test message");
        string customization = "My App";
        byte[] customizationBytes = Encoding.UTF8.GetBytes(customization);

        // BouncyCastle reference
        var bcDigest = new CShakeDigest(128, null, customizationBytes);
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[32];
        bcDigest.OutputFinal(bcHash, 0, 32);

        // Our implementation
        using var ourDigest = CShake128.Create(32, "", customization);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    /// <summary>
    /// Test cSHAKE256 matches BouncyCastle with customization.
    /// </summary>
    [Test]
    public void CShake256MatchesBouncyCastleWithCustomization()
    {
        byte[] input = Encoding.UTF8.GetBytes("test message");
        string customization = "My App";
        byte[] customizationBytes = Encoding.UTF8.GetBytes(customization);

        // BouncyCastle reference
        var bcDigest = new CShakeDigest(256, null, customizationBytes);
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcDigest.OutputFinal(bcHash, 0, 64);

        // Our implementation
        using var ourDigest = CShake256.Create(64, "", customization);
        byte[] ourHash = ourDigest.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcHash));
    }

    /// <summary>
    /// Test incremental hashing with cSHAKE128.
    /// </summary>
    [Test]
    public void CShake128IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var cshake1 = CShake128.Create(32);
        byte[] hash1 = cshake1.ComputeHash(input);

        using var cshake2 = CShake128.Create(32);
        cshake2.TransformBlock(input, 0, 7, null, 0);
        cshake2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = cshake2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test incremental hashing with cSHAKE256.
    /// </summary>
    [Test]
    public void CShake256IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var cshake1 = CShake256.Create(64);
        byte[] hash1 = cshake1.ComputeHash(input);

        using var cshake2 = CShake256.Create(64);
        cshake2.TransformBlock(input, 0, 7, null, 0);
        cshake2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = cshake2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }
}


