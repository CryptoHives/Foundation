// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Sha2;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for SHA-224 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHA-224 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA224Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha224Implementations), nameof(Sha224Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("d14a028c2a3a2bc9476102bb288234c415a2b01f828ea62ac5b3e42f");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha224Implementations), nameof(Sha224Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("23097d223405d8228642a477bda255b32aadbce4bda0b3f7e36c9da7");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: One block message (448 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha224Implementations), nameof(Sha224Implementations.All))]
    public void ComputeHashOneBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("75388b16512776cc5dba5da1fd890150b0c6455cb4f58b1952522525");
        byte[] input = Encoding.ASCII.GetBytes("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Two block message (896 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha224Implementations), nameof(Sha224Implementations.All))]
    public void ComputeHashTwoBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("c97ca9a559850ce97a04a96def6d99a9e0e0e2ab14e6b8df265fc0b3");
        byte[] input = Encoding.ASCII.GetBytes(
            "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var sha224 = SHA224.Create();
        Assert.That(sha224.HashSize, Is.EqualTo(224));
    }

    /// <summary>
    /// Test that block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var sha224 = SHA224.Create();
        Assert.That(sha224.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Test that algorithm name is correct for our managed implementation.
    /// </summary>
    [Test]
    public void AlgorithmNameIsCorrect()
    {
        using var sha224 = SHA224.Create();
        Assert.That(sha224.AlgorithmName, Is.EqualTo("SHA-224"));
    }

    /// <summary>
    /// Test incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesOneShot()
    {
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var sha224OneShot = SHA224.Create();
        byte[] expectedHash = sha224OneShot.ComputeHash(input);

        using var sha224Incremental = SHA224.Create();
        sha224Incremental.TransformBlock(input, 0, 1, null, 0);
        sha224Incremental.TransformBlock(input, 1, 1, null, 0);
        sha224Incremental.TransformFinalBlock(input, 2, 1);

        Assert.That(sha224Incremental.Hash, Is.EqualTo(expectedHash));
    }

    /// <summary>
    /// Test that Initialize resets state properly.
    /// </summary>
    [Test]
    public void InitializeResetsState()
    {
        using var sha224 = SHA224.Create();

        // Compute a hash
        sha224.ComputeHash(Encoding.ASCII.GetBytes("test"));

        // Reset and compute empty hash
        sha224.Initialize();
        byte[] hash = sha224.ComputeHash(Array.Empty<byte>());

        byte[] expected = TestHelpers.FromHexString("d14a028c2a3a2bc9476102bb288234c415a2b01f828ea62ac5b3e42f");
        Assert.That(hash, Is.EqualTo(expected));
    }
}


