// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Hash.Keccak;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Buffers;
using System.Text;

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

    /// <summary>
    /// left_encode and right_encode (SP 800-185 §2.3.1) write the value's significant bytes,
    /// big-endian, behind or ahead of their count, at every width from one to eight bytes.
    /// </summary>
    /// <param name="x">The value to encode.</param>
    [TestCase(0L)]
    [TestCase(1L)]
    [TestCase(0xFFL)]
    [TestCase(0x100L)]
    [TestCase(0x1234_56L)]
    [TestCase(0x1234_5678L)]
    [TestCase(0x12_3456_789AL)]
    [TestCase(0x1234_5678_9ABCL)]
    [TestCase(0x12_3456_789A_BCDEL)]
    [TestCase(0x0123_4567_89AB_CDEFL)]
    [TestCase(long.MaxValue)]
    public void LeftAndRightEncodeMatchTheDefinition(long x)
    {
        var significant = new System.Collections.Generic.List<byte>();
        for (long t = x; t > 0; t >>= 8)
        {
            significant.Insert(0, (byte)(t & 0xFF));
        }

        if (significant.Count == 0)
        {
            significant.Add(0);
        }

        byte n = (byte)significant.Count;
        byte[] left = [n, .. significant];
        byte[] right = [.. significant, n];

        byte[] buffer = new byte[9];
        Assert.That(CShake128.TryLeftEncode(buffer, x, out int leftWritten), Is.True);
        Assert.That(buffer.AsSpan(0, leftWritten).ToArray(), Is.EqualTo(left));

        Assert.That(CShake128.TryRightEncode(buffer, x, out int rightWritten), Is.True);
        Assert.That(buffer.AsSpan(0, rightWritten).ToArray(), Is.EqualTo(right));
    }

    /// <summary>
    /// A customization longer than the rate puts <c>bytepad</c> in a rented buffer, whose padding must not
    /// come from whatever the pool handed back.
    /// </summary>
    [TestCase(128)]
    [TestCase(256)]
    [NonParallelizable]
    public void CShakeMatchesBouncyCastleWhenThePoolHandsBackDirtyBuffers(int bits)
    {
        string customization = new('c', 300);
        byte[] input = Encoding.UTF8.GetBytes("test message");

        var reference = new CShakeDigest(bits, null, Encoding.UTF8.GetBytes(customization));
        reference.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        reference.OutputFinal(expected, 0, expected.Length);

        var rented = new byte[8][];
        for (int i = 0; i < rented.Length; i++)
        {
            rented[i] = ArrayPool<byte>.Shared.Rent(512);
            rented[i].AsSpan().Fill(0xFF);
        }

        foreach (byte[] array in rented)
        {
            ArrayPool<byte>.Shared.Return(array);
        }

        using System.Security.Cryptography.HashAlgorithm cshake = bits == 128
            ? CShake128.Create(32, "", customization)
            : CShake256.Create(32, "", customization);

        Assert.That(cshake.ComputeHash(input), Is.EqualTo(expected));
    }
}
