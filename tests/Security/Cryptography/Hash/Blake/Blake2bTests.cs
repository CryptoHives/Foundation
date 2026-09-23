// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

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
    /// Test vector: "The quick brown fox jumps over the lazy dog" with 32-byte output (BLAKE2b-256).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b256Implementations), nameof(Blake2b256Implementations.All))]
    public void ComputeHashQuickBrownFox256Bit(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "01718cec35cd3d796dd00020e0bfecb473ad23457d063b75eff29c0ffa2e58a9");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "The quick brown fox jumps over the lazy dog." with 64-byte output (BLAKE2b-512).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake2b512Implementations), nameof(Blake2b512Implementations.All))]
    public void ComputeHashQuickBrownFoxDot(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "87af9dc4afe5651b7aa89124b905fd214bf17c79af58610db86a0fb1e0194622" +
            "a4e9d8e395b352223a8183b0d421c0994b98286cbf8c68a495902e0fe6e2bda2");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog.");

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
    /// <summary>
    /// <c>TryComputeHash</c> takes the one-shot path only from a freshly initialized, unkeyed
    /// state. With data already appended it must fall back to the base streaming implementation
    /// and still hash the concatenation.
    /// </summary>
    [TestCase(1, 1)]
    [TestCase(128 - 1, 1)]
    [TestCase(128, 128)]
    [TestCase(128 + 1, 128 * 3)]
    [TestCase(1000, 4000)]
    public void TryComputeHashAfterAppendDataHashesTheConcatenation(int prefixLength, int suffixLength)
    {
        byte[] prefix = SequentialBytes(prefixLength);
        byte[] suffix = SequentialBytes(suffixLength);

        byte[] concatenated = new byte[prefixLength + suffixLength];
        prefix.CopyTo(concatenated, 0);
        suffix.CopyTo(concatenated, prefixLength);

        // ComputeHash drives HashCore/HashFinal, so it is independent of the override.
        using var reference = Blake2b.Create();
        byte[] expected = reference.ComputeHash(concatenated);

        using var hash = Blake2b.Create();
        hash.AppendData(prefix);

        byte[] actual = new byte[64];
        Assert.That(hash.TryComputeHash(suffix, actual, out int bytesWritten), Is.True);
        Assert.That(bytesWritten, Is.EqualTo(64));
        Assert.That(actual, Is.EqualTo(expected),
            "TryComputeHash after AppendData must continue the stream, not restart it");

        using var freshReference = Blake2b.Create();
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
    [TestCase(128 - 1)]
    [TestCase(128)]
    [TestCase(128 + 1)]
    [TestCase(128 * 2)]
    [TestCase(128 * 2 + 1)]
    [TestCase(128 * 5 + 17)]
    public void OneShotAgreesWithStreaming(int length)
    {
        byte[] input = SequentialBytes(length);

        using var streaming = Blake2b.Create();
        byte[] expected = streaming.ComputeHash(input);

        using var oneShot = Blake2b.Create();
        byte[] actual = new byte[64];
        Assert.That(oneShot.TryComputeHash(input, actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(expected), "one-shot and streaming must agree");

        byte[] key = SequentialBytes(16);
        using var keyedStreaming = Blake2b.CreateKeyed(key);
        byte[] keyedExpected = keyedStreaming.ComputeHash(input);

        using var keyedOneShot = Blake2b.CreateKeyed(key);
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
