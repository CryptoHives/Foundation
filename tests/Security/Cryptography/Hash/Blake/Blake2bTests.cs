// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using System;
using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for BLAKE2b implementations.
/// </summary>
/// <remarks>
/// These tests verify that all BLAKE2b implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using official test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Blake2bTests
{
    /// <summary>
    /// Test vector: Empty string with 64-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b512Implementations), nameof(Blake2b512Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "786a02f742015903c6c6fd852552d272912f4740e15847618a86e217f71f5419" +
            "d25e1031afee585313896444934eb04b903a685b1448b755d56f701afe9be2ce");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 64-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b512Implementations), nameof(Blake2b512Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "ba80a53f981c4d0d6a2797b69f12f6e94c212f14685ac4b74b12bb6fdbffa2d1" +
            "7d87c5392aab792dc252d5de4533cc9518d38aa8dbf1925ab92386edd4009923");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: Long message "The quick brown fox jumps over the lazy dog".
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b512Implementations), nameof(Blake2b512Implementations.All))]
    public void ComputeHashQuickBrownFox(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "a8add4bdddfd93e4877d2746e62817b116364a1fa7bc148d95090bc7333b3673" +
            "f82401cf7aa2e4cb1ecd90296e3f14cb5413f8ed77be73045b13914cdcd6a918");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 32-byte output (BLAKE2b-256).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b256Implementations), nameof(Blake2b256Implementations.All))]
    public void ComputeHashAbc256Bit(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "bddd813c634239723171ef3fee98579b94964e3bb1cb3e427262c8c068d52319");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test variable output size for our managed implementation.
    /// </summary>
    [Test]
    public void VariableOutputSize()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var blake32 = Blake2b.Create(32);
        using var blake64 = Blake2b.Create(64);

        byte[] hash32 = blake32.ComputeHash(input);
        byte[] hash64 = blake64.ComputeHash(input);

        Assert.That(hash32, Has.Length.EqualTo(32));
        Assert.That(hash64, Has.Length.EqualTo(64));
    }

    /// <summary>
    /// Test that invalid output size throws for our managed implementation.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake2b.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake2b.Create(65));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var blake2b = Blake2b.Create();
        Assert.That(blake2b.HashSize, Is.EqualTo(512));

        using var blake32 = Blake2b.Create(32);
        Assert.That(blake32.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Test algorithm name is correct for our managed implementation.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var blake2b = Blake2b.Create();
        Assert.That(blake2b.AlgorithmName, Is.EqualTo("BLAKE2b"));
    }

    /// <summary>
    /// Test block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var blake2b = Blake2b.Create();
        Assert.That(blake2b.BlockSize, Is.EqualTo(128));
    }
}


