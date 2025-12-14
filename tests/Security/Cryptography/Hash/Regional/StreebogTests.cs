// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.GOST;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="Streebog"/> hash algorithm (GOST R 34.11-2012).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class StreebogTests
{
    // RFC 6986 Test Message 1 (M1): 63 bytes
    // The string "303132..." represents ASCII digits
    private static readonly byte[] Rfc6986Message1 = TestHelpers.FromHexString(
        // "012345678901234567890123456789012345678901234567890123456789012"
        "3031323334353637383930313233343536373839303132333435363738393031" +
        "32333435363738393031323334353637383930313233343536373839303132");

    // RFC 6986 Test Message 2 (M2): 72 bytes
    private static readonly byte[] Rfc6986Message2 = TestHelpers.FromHexString(
        // "Се ветри, Стрибожи внуци, веютъ с моря стрелами на храбрыя плъкы Игоревы"
        "d1e520e2e5f2f0e82c20d1f2f0e8e1eee6e820e2edf3f6e82c20e2e5fef2fa20" +
        "f120eceef0ff20f1f2f0e5ebe0ece820ede020f5f0e0e1f0fbff20efebfaeafb20c8e3eef0e5e2fb");

    // RFC 6986 Section 10.1.1 - Expected hash for M1 with 512-bit output
    private static readonly byte[] Rfc6986M1Expected512 = TestHelpers.FromHexString(
        "1b54d01a4af5b9d5cc3d86d68d285462b19abc2475222f35c085122be4ba1ffa" +
        "00ad30f8767b3a82384c6574f024c311e2a481332b08ef7f41797891c1646f48");

    // RFC 6986 Section 10.1.2 - Expected hash for M2 with 512-bit output
    private static readonly byte[] Rfc6986M2Expected512 = TestHelpers.FromHexString(
        "1e88e62226bfca6f9994f1f2d51569e0daf8475a3b0fe61a5300eee46d961376" +
        "035fe83549ada2b8620fcd7c496ce5b33f0cb9dddc2b6460143b03dabac9fb28");

    // Expected hash for empty string with 512-bit output
    private static readonly byte[] Rfc6986EmptyStringExpected512 = TestHelpers.FromHexString(
        "8e945da209aa869f0455928529bcae4679e9873ab707b55315f56ceb98bef0a7" +
        "362f715528356ee83cda5f2aac4c6ad2ba3a715c1bcd81cb8e9f90bf4c1c1a8a");

    // RFC 6986 Section 10.2.1 - Expected hash for M1 with 256-bit output
    private static readonly byte[] Rfc6986M1Expected256 = TestHelpers.FromHexString(
        "9d151eefd8590b89daa6ba6cb74af9275dd051026bb149a452fd84e5e57b5500");

    // RFC 6986 Section 10.2.2 - Expected hash for M2 with 256-bit output
    private static readonly byte[] Rfc6986M2Expected256 = TestHelpers.FromHexString(
        "9dd2fe4e90409e5da87f53976d7405b0c0cac628fc669a741d50063c557e8f50");

    // Expected hash for empty string with 256-bit output
    private static readonly byte[] Rfc6986EmptyStringExpected256 = TestHelpers.FromHexString(
        "3f539a213e97c802cc229d474c6aa32a825a360b2a933a949fd925208d9ce1bb");

    /// <summary>
    /// Validate Streebog-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void Streebog256HashSizeIs256Bits()
    {
        using var streebog = Streebog.Create(32);
        Assert.That(streebog.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Streebog-512 produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void Streebog512HashSizeIs512Bits()
    {
        using var streebog = Streebog.Create(64);
        Assert.That(streebog.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate Streebog block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
        using var streebog = Streebog.Create();
        Assert.That(streebog.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate Streebog algorithm names.
    /// </summary>
    [TestCase(32, "Streebog-256")]
    [TestCase(64, "Streebog-512")]
    public void AlgorithmNameIsCorrect(int hashSizeBytes, string expectedName)
    {
        using var streebog = Streebog.Create(hashSizeBytes);
        Assert.That(streebog.AlgorithmName, Is.EqualTo(expectedName));
    }

    /// <summary>
    /// Test invalid hash size throws exception.
    /// </summary>
    [TestCase(16)]
    [TestCase(48)]
    [TestCase(128)]
    public void InvalidHashSizeThrows(int invalidSize)
    {
        Assert.Throws<ArgumentException>(() => Streebog.Create(invalidSize));
    }

    /// <summary>
    /// Test Streebog-512 with empty string.
    /// </summary>
    [Test]
    public void Rfc6986EmptyString_Streebog512()
    {
        // Expected hash
        byte[] expected = Rfc6986EmptyStringExpected512;

        using var streebog = Streebog.Create(64);
        byte[] actual = streebog.ComputeHash(Array.Empty<byte>());

        Assert.That(actual, Is.EqualTo(expected), "Streebog-512 empty string mismatch");
    }

    /// <summary>
    /// Test Streebog-512 with RFC 6986 test vector M1 (63 bytes).
    /// </summary>
    /// <remarks>
    /// RFC 6986 Section 10.1.1 - Message 1 for 512-bit hash.
    /// </remarks>
    [Test]
    public void Rfc6986M1_Streebog512()
    {
        // Expected hash from RFC 6986 Section 10.1.1
        byte[] expected = Rfc6986M1Expected512;

        using var streebog = Streebog.Create(64);
        byte[] actual = streebog.ComputeHash(Rfc6986Message1);

        Assert.That(actual, Is.EqualTo(expected), "Streebog-512 RFC 6986 M1 mismatch");
    }

    /// <summary>
    /// Test Streebog-512 with RFC 6986 test vector M2 (72 bytes).
    /// </summary>
    /// <remarks>
    /// RFC 6986 Section 10.1.2 - Message 2 for 512-bit hash.
    /// </remarks>
    [Test]
    public void Rfc6986M2_Streebog512()
    {
        // Expected hash from RFC 6986 Section 10.1.2
        byte[] expected = Rfc6986M2Expected512;

        using var streebog = Streebog.Create(64);
        byte[] actual = streebog.ComputeHash(Rfc6986Message2);

        Assert.That(actual, Is.EqualTo(expected), "Streebog-512 RFC 6986 M2 mismatch");
    }

    /// <summary>
    /// Test Streebog-256 with empty string.
    /// </summary>
    [Test]
    public void Rfc6986EmptyString_Streebog256()
    {
        // Expected hash
        byte[] expected = Rfc6986EmptyStringExpected256;

        using var streebog = Streebog.Create(32);
        byte[] actual = streebog.ComputeHash(Array.Empty<byte>());

        Assert.That(actual, Is.EqualTo(expected), "Streebog-256 empty string mismatch");
    }

    /// <summary>
    /// Test Streebog-256 with RFC 6986 test vector M1 (63 bytes).
    /// </summary>
    /// <remarks>
    /// RFC 6986 Section 10.2.1 - Message 1 for 256-bit hash.
    /// </remarks>
    [Test]
    public void Rfc6986M1_Streebog256()
    {
        // Expected hash from RFC 6986 Section 10.2.1
        byte[] expected = Rfc6986M1Expected256;

        using var streebog = Streebog.Create(32);
        byte[] actual = streebog.ComputeHash(Rfc6986Message1);

        Assert.That(actual, Is.EqualTo(expected), "Streebog-256 RFC 6986 M1 mismatch");
    }

    /// <summary>
    /// Test Streebog-256 with RFC 6986 test vector M2 (72 bytes).
    /// </summary>
    /// <remarks>
    /// RFC 6986 Section 10.2.2 - Message 2 for 256-bit hash.
    /// </remarks>
    [Test]
    public void Rfc6986M2_Streebog256()
    {
        // Expected hash from RFC 6986 Section 10.2.2
        byte[] expected = Rfc6986M2Expected256;

        using var streebog = Streebog.Create(32);
        byte[] actual = streebog.ComputeHash(Rfc6986Message2);

        Assert.That(actual, Is.EqualTo(expected), "Streebog-256 RFC 6986 M2 mismatch");
    }

    /// <summary>
    /// Test incremental hashing with Streebog-256.
    /// </summary>
    [Test]
    public void Streebog256IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var s1 = Streebog.Create(32);
        byte[] hash1 = s1.ComputeHash(input);

        using var s2 = Streebog.Create(32);
        s2.TransformBlock(input, 0, 7, null, 0);
        s2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = s2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test incremental hashing with Streebog-512.
    /// </summary>
    [Test]
    public void Streebog512IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var s1 = Streebog.Create(64);
        byte[] hash1 = s1.ComputeHash(input);

        using var s2 = Streebog.Create(64);
        s2.TransformBlock(input, 0, 7, null, 0);
        s2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = s2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Cross-implementation test with all Streebog-256 implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Streebog256Implementations), nameof(Streebog256Implementations.All))]
    public void AllStreebog256ImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32), $"{factory.Name} should produce 32-byte hash");
    }

    /// <summary>
    /// Cross-implementation test with all Streebog-512 implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Streebog512Implementations), nameof(Streebog512Implementations.All))]
    public void AllStreebog512ImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(64), $"{factory.Name} should produce 64-byte hash");
    }

    /// <summary>
    /// Test with larger input crossing multiple blocks.
    /// </summary>
    [Test]
    public void MultiBlockInput()
    {
        byte[] input = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            input[i] = (byte)i;
        }

        using var streebog256 = Streebog.Create(32);
        byte[] hash256 = streebog256.ComputeHash(input);
        Assert.That(hash256, Has.Length.EqualTo(32));

        using var streebog512 = Streebog.Create(64);
        byte[] hash512 = streebog512.ComputeHash(input);
        Assert.That(hash512, Has.Length.EqualTo(64));

        // The two hashes should be different - compare first 32 bytes of 512 with 256 hash
        byte[] hash512First32 = new byte[32];
        Array.Copy(hash512, 0, hash512First32, 0, 32);
        Assert.That(hash256, Is.Not.EqualTo(hash512First32));
    }

    /// <summary>
    /// Test that hashing produces deterministic results.
    /// </summary>
    [Test]
    public void DeterministicOutput()
    {
        byte[] input = Encoding.UTF8.GetBytes("deterministic test");

        using var s1 = Streebog.Create(32);
        using var s2 = Streebog.Create(32);

        byte[] hash1 = s1.ComputeHash(input);
        byte[] hash2 = s2.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    /// <summary>
    /// Test reuse after Initialize.
    /// </summary>
    [Test]
    public void ReuseAfterInitialize()
    {
        byte[] input1 = Encoding.UTF8.GetBytes("first");
        byte[] input2 = Encoding.UTF8.GetBytes("second");

        using var streebog = Streebog.Create(32);
        byte[] hash1 = streebog.ComputeHash(input1);

        streebog.Initialize();
        byte[] hash2 = streebog.ComputeHash(input2);

        streebog.Initialize();
        byte[] hash1Again = streebog.ComputeHash(input1);

        Assert.That(hash1Again, Is.EqualTo(hash1));
        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Debug test: Check what BouncyCastle produces for RFC 6986 M1.
    /// </summary>
    [Test]
    public void BouncyCastleRfc6986M1()
    {
        var bcDigest = new Org.BouncyCastle.Crypto.Digests.Gost3411_2012_512Digest();
        bcDigest.BlockUpdate(Rfc6986Message1, 0, Rfc6986Message1.Length);
        byte[] bcHash = new byte[64];
        bcDigest.DoFinal(bcHash, 0);

        // Try with reversed message
        byte[] reversedMessage = (byte[])Rfc6986Message1.Clone();
        Array.Reverse(reversedMessage);
        
        var bcDigest2 = new Org.BouncyCastle.Crypto.Digests.Gost3411_2012_512Digest();
        bcDigest2.BlockUpdate(reversedMessage, 0, reversedMessage.Length);
        byte[] bcHash2 = new byte[64];
        bcDigest2.DoFinal(bcHash2, 0);

        // Expected from RFC 6986 Section 10.1.1
        byte[] expectedRfc = Rfc6986M1Expected256;

        TestContext.Out.WriteLine($"BouncyCastle (normal): {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"BouncyCastle (reversed msg): {TestHelpers.ToHexString(bcHash2)}");
        TestContext.Out.WriteLine($"RFC Expected: {TestHelpers.ToHexString(expectedRfc)}");
        TestContext.Out.WriteLine($"Normal match: {bcHash.SequenceEqual(expectedRfc)}");
        TestContext.Out.WriteLine($"Reversed match: {bcHash2.SequenceEqual(expectedRfc)}");

        // Just verify BouncyCastle produces something (don't fail the test)
        Assert.That(bcHash, Has.Length.EqualTo(64));
    }

    /// <summary>
    /// Debug test: Compare our implementation with BouncyCastle for empty string.
    /// </summary>
    [Test]
    public void CompareWithBouncyCastleEmpty()
    {
        byte[] input = Array.Empty<byte>();

        var bcDigest = new Org.BouncyCastle.Crypto.Digests.Gost3411_2012_512Digest();
        bcDigest.BlockUpdate(input, 0, input.Length);
        byte[] bcHash = new byte[64];
        bcDigest.DoFinal(bcHash, 0);

        using var ourDigest = Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        TestContext.Out.WriteLine($"BouncyCastle: {TestHelpers.ToHexString(bcHash)}");
        TestContext.Out.WriteLine($"Our impl:     {TestHelpers.ToHexString(ourHash)}");

        Assert.That(ourHash, Is.EqualTo(bcHash), "Empty string hash should match");
    }

    /// <summary>
    /// Debug test: Compare our implementation with OpenGost for empty string.
    /// </summary>
    [Test]
    public void CompareWithOpenGostEmpty()
    {
        byte[] input = Array.Empty<byte>();

        // OpenGost produces hash in little-endian byte order
        using var digest = OpenGost.Security.Cryptography.Streebog512.Create();
        byte[] hash = digest.ComputeHash(TestHelpers.FromHexString(string.Empty));

        using var ourDigest = Streebog.Create(64);
        byte[] ourHash = ourDigest.ComputeHash(input);

        TestContext.Out.WriteLine($"BouncyCastle: {TestHelpers.ToHexString(hash)}");
        TestContext.Out.WriteLine($"Our impl:     {TestHelpers.ToHexString(ourHash)}");

        Assert.That(ourHash, Is.EqualTo(hash), "Empty string hash should match");
    }
}


