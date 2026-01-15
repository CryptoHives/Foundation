// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="Keccak256"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Keccak256Tests
{
    /// <summary>
    /// Validate Keccak-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs256Bits()
    {
        using var keccak = Keccak256.Create();
        Assert.That(keccak.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Keccak-256 block size is 136 bytes (1088 bits).
    /// </summary>
    [Test]
    public void BlockSizeIs136Bytes()
    {
        using var keccak = Keccak256.Create();
        Assert.That(keccak.BlockSize, Is.EqualTo(136));
    }

    /// <summary>
    /// Validate Keccak-256 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsKeccak256()
    {
        using var keccak = Keccak256.Create();
        Assert.That(keccak.AlgorithmName, Is.EqualTo("Keccak-256"));
    }

    /// <summary>
    /// Test Keccak-256 with official Ethereum test vectors.
    /// </summary>
    /// <remarks>
    /// Keccak-256 uses original Keccak padding (0x01) different from SHA-3 (0x06).
    /// These are the values used in Ethereum for address generation and signatures.
    /// </remarks>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCase("", "c5d2460186f7233c927e7db2dcc703c0e500b653ca82273b7bfad8045d85a470")]
    [TestCase("abc", "4e03657aea45a94fc7d47ba826c8d667c0d1e6e33a64a036ec44f58fa12d6c45")]
    [TestCase("The quick brown fox jumps over the lazy dog", "4d741b6f1eb29cb2a9b9911c82f56fa8d73b04959d3d9d222895df6c0b28aa15")]
    [TestCase("testing", "5f16f4c7f149ac4f9510d9cf8cf384038ad348b3bcdc01915f95de12df9d1b02")]
    public void KnownTestVectors(string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        foreach (HashAlgorithmFactory hashFactory in Keccak256Implementations.All)
        {
            using var impl = hashFactory.Create();
            byte[] implHash = impl.ComputeHash(data);
            Assert.That(implHash, Is.EqualTo(expected), $"{hashFactory.Name} Keccak-256 mismatch for: \"{input}\"");
        }
    }

    /// <summary>
    /// Test that Keccak-256 differs from SHA3-256 due to different padding.
    /// </summary>
    [Test]
    public void Keccak256DiffersFromSha3256()
    {
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var keccak = Keccak256.Create();
        using var sha3 = SHA3_256.Create();

        byte[] keccakHash = keccak.ComputeHash(input);
        byte[] sha3Hash = sha3.ComputeHash(input);

        Assert.That(keccakHash, Is.Not.EqualTo(sha3Hash), "Keccak-256 and SHA3-256 should produce different hashes");
    }

    /// <summary>
    /// Test incremental hashing with Keccak-256.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var keccak1 = Keccak256.Create();
        byte[] hash1 = keccak1.ComputeHash(input);

        using var keccak2 = Keccak256.Create();
        keccak2.TransformBlock(input, 0, 7, null, 0);
        keccak2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = keccak2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test reuse after Initialize.
    /// </summary>
    [Test]
    public void ReuseAfterInitialize()
    {
        byte[] input1 = Encoding.UTF8.GetBytes("first");
        byte[] input2 = Encoding.UTF8.GetBytes("second");

        using var keccak = Keccak256.Create();
        byte[] hash1 = keccak.ComputeHash(input1);

        keccak.Initialize();
        byte[] hash2 = keccak.ComputeHash(input2);

        keccak.Initialize();
        byte[] hash1Again = keccak.ComputeHash(input1);

        Assert.That(hash1Again, Is.EqualTo(hash1));
        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }

    /// <summary>
    /// Cross-implementation test with all implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Keccak256Implementations), nameof(Keccak256Implementations.All))]
    public void AllImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32), $"{factory.Name} should produce 32-byte hash");
    }
}


