// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

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
    /// Test vector: "The quick brown fox jumps over the lazy dog" with 16-byte output (BLAKE2s-128).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2s128Implementations), nameof(Blake2s128Implementations.All))]
    public void ComputeHashQuickBrownFox128Bit(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("96fd07258925748a0d2fb1c8a1167a73");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

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

        Assert.That(hash16, Has.Length.EqualTo(16));
        Assert.That(hash32, Has.Length.EqualTo(32));
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
    /// <summary>
    /// <c>TryComputeHash</c> takes the one-shot path only from a freshly initialized, unkeyed
    /// state. With data already appended it must fall back to the base streaming implementation
    /// and still hash the concatenation.
    /// </summary>
    [TestCase(1, 1)]
    [TestCase(64 - 1, 1)]
    [TestCase(64, 64)]
    [TestCase(64 + 1, 64 * 3)]
    [TestCase(1000, 4000)]
    public void TryComputeHashAfterAppendDataHashesTheConcatenation(int prefixLength, int suffixLength)
    {
        byte[] prefix = SequentialBytes(prefixLength);
        byte[] suffix = SequentialBytes(suffixLength);

        byte[] concatenated = new byte[prefixLength + suffixLength];
        prefix.CopyTo(concatenated, 0);
        suffix.CopyTo(concatenated, prefixLength);

        // ComputeHash drives HashCore/HashFinal, so it is independent of the override.
        using var reference = Blake2s.Create();
        byte[] expected = reference.ComputeHash(concatenated);

        using var hash = Blake2s.Create();
        hash.AppendData(prefix);

        byte[] actual = new byte[32];
        Assert.That(hash.TryComputeHash(suffix, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(32));
        Assert.That(actual, Is.EqualTo(expected),
            "TryComputeHash after AppendData must continue the stream, not restart it");

        using var freshReference = Blake2s.Create();
        byte[] suffixOnly = freshReference.ComputeHash(suffix);
        Assert.That(hash.TryComputeHash(suffix, actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(suffixOnly),
            "instance must be freshly initialized after the fallback path");
    }

    /// <summary>
    /// The one-shot path must agree with the streaming path at every length around a block
    /// boundary, and a keyed instance -- which is never fresh, because its first block is the
    /// padded key -- must still produce the keyed digest.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64 - 1)]
    [TestCase(64)]
    [TestCase(64 + 1)]
    [TestCase(64 * 2)]
    [TestCase(64 * 2 + 1)]
    [TestCase(64 * 5 + 17)]
    public void OneShotAgreesWithStreaming(int length)
    {
        byte[] input = SequentialBytes(length);

        using var streaming = Blake2s.Create();
        byte[] expected = streaming.ComputeHash(input);

        using var oneShot = Blake2s.Create();
        byte[] actual = new byte[32];
        Assert.That(oneShot.TryComputeHash(input, actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(expected), "one-shot and streaming must agree");

        byte[] key = SequentialBytes(16);
        using var keyedStreaming = Blake2s.CreateKeyed(key);
        byte[] keyedExpected = keyedStreaming.ComputeHash(input);

        using var keyedOneShot = Blake2s.CreateKeyed(key);
        Assert.That(keyedOneShot.TryComputeHash(input, actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(keyedExpected),
            "a keyed instance must fall back and still key the digest");
    }

    private static byte[] SequentialBytes(int length)
    {
        byte[] data = new byte[length];
        for (int i = 0; i < length; i++)
        {
            data[i] = (byte)(i % 251);
        }

        return data;
    }
}
