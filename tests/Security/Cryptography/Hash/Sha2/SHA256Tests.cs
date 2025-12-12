// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for SHA-256 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHA-256 implementations (OS, Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA256Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha256Implementations), nameof(Sha256Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha256Implementations), nameof(Sha256Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: One block message (448 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha256Implementations), nameof(Sha256Implementations.All))]
    public void ComputeHashOneBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("248d6a61d20638b8e5c026930c3e6039a33ce45964ff2167f6ecedd419db06c1");
        byte[] input = Encoding.ASCII.GetBytes("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Two block message (896 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha256Implementations), nameof(Sha256Implementations.All))]
    public void ComputeHashTwoBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("cf5b16a778af8380036ce59e7b0492370b249b11e8f07a51afac45037afee9d1");
        byte[] input = Encoding.ASCII.GetBytes(
            "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn" +
            "hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Long message (1,000,000 'a' characters).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha256Implementations), nameof(Sha256Implementations.All))]
    public void ComputeHashMillionAs(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("cdc76e5c9914fb9281a1c7e284d73e67f1809a48a497200e046d39ccc7112cd0");
        byte[] input = new byte[1_000_000];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = (byte)'a';
        }

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
        using var sha256 = SHA256.Create();
        Assert.That(sha256.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Test that block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var sha256 = SHA256.Create();
        Assert.That(sha256.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Test incremental hashing for our managed implementation.
    /// </summary>
    [Test]
    public void IncrementalHashing()
    {
        byte[] expected = TestHelpers.FromHexString("ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var sha256 = SHA256.Create();

        // Hash one byte at a time
        sha256.TransformBlock(input, 0, 1, null, 0);
        sha256.TransformBlock(input, 1, 1, null, 0);
        sha256.TransformFinalBlock(input, 2, 1);

        Assert.That(sha256.Hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that Initialize resets state for our managed implementation.
    /// </summary>
    [Test]
    public void InitializeResetsState()
    {
        using var sha256 = SHA256.Create();

        // Compute a hash
        sha256.ComputeHash(Encoding.ASCII.GetBytes("test"));

        // Reset and compute again
        sha256.Initialize();
        byte[] hash = sha256.ComputeHash(Array.Empty<byte>());

        byte[] expected = TestHelpers.FromHexString("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
        Assert.That(hash, Is.EqualTo(expected));
    }
}


