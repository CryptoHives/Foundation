// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.Blake;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for BLAKE2s implementations.
/// </summary>
/// <remarks>
/// These tests verify that all BLAKE2s implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using official test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Blake2sTests
{
    /// <summary>
    /// Test vector: Empty string with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2s256Implementations), nameof(Blake2s256Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "69217a3079908094e11121d042354a7c1f55b6482ca1a51e1b250dfd1ed0eef9");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2s256Implementations), nameof(Blake2s256Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "508c5e8c327c14e2e1a72ba34eeb452f37458b209ed63a294d999b4c86675982");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: Long message "The quick brown fox jumps over the lazy dog".
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2s256Implementations), nameof(Blake2s256Implementations.All))]
    public void ComputeHashQuickBrownFox(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "606beeec743ccbeff6cbcdf5d5302aa855c256c29b88c8ed331ea1a6bf3c8812");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 16-byte output (BLAKE2s-128).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2s128Implementations), nameof(Blake2s128Implementations.All))]
    public void ComputeHashAbc128Bit(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "aa4938119b1dc7b87cbad0ffd200d0ae");
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

        using var blake16 = Blake2s.Create(16);
        using var blake32 = Blake2s.Create(32);

        byte[] hash16 = blake16.ComputeHash(input);
        byte[] hash32 = blake32.ComputeHash(input);

        Assert.That(hash16.Length, Is.EqualTo(16));
        Assert.That(hash32.Length, Is.EqualTo(32));
    }

    /// <summary>
    /// Test that invalid output size throws for our managed implementation.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake2s.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake2s.Create(33));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var blake2s = Blake2s.Create();
        Assert.That(blake2s.HashSize, Is.EqualTo(256));

        using var blake16 = Blake2s.Create(16);
        Assert.That(blake16.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Test algorithm name is correct for our managed implementation.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var blake2s = Blake2s.Create();
        Assert.That(blake2s.AlgorithmName, Is.EqualTo("BLAKE2s"));
    }

    /// <summary>
    /// Test block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var blake2s = Blake2s.Create();
        Assert.That(blake2s.BlockSize, Is.EqualTo(64));
    }
}


