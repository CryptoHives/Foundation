// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

/// <summary>
/// Tests for <see cref="Keccak512"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Keccak512Tests
{
    /// <summary>
    /// Validate Keccak-512 produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs512Bits()
    {
        using var keccak = Keccak512.Create();
        Assert.That(keccak.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate Keccak-512 block size is 72 bytes (576 bits).
    /// </summary>
    [Test]
    public void BlockSizeIs72Bytes()
    {
        using var keccak = Keccak512.Create();
        Assert.That(keccak.BlockSize, Is.EqualTo(72));
    }

    /// <summary>
    /// Validate Keccak-512 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsKeccak512()
    {
        using var keccak = Keccak512.Create();
        Assert.That(keccak.AlgorithmName, Is.EqualTo("Keccak-512"));
    }

    /// <summary>
    /// Test Keccak-512 with known test vectors.
    /// </summary>
    /// <remarks>
    /// Keccak-512 uses original Keccak padding (0x01) different from SHA-3 (0x06).
    /// These vectors are generated using BouncyCastle KeccakDigest(512).
    /// </remarks>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCase("", "0eab42de4c3ceb9235fc91acffe746b29c29a8c366b7c60e4e67c466f36a4304c00fa9caf9d87976ba469bcbe06713b435f091ef2769fb160cdab33d3670680e")]
    [TestCase("abc", "18587dc2ea106b9a1563e32b3312421ca164c7f1f07bc922a9c83d77cea3a1e5d0c69910739025372dc14ac9642629379540c17e2a65b19d77aa511a9d00bb96")]
    [TestCase("The quick brown fox jumps over the lazy dog", "d135bb84d0439dbac432247ee573a23ea7d3c9deb2a968eb31d47c4fb45f1ef4422d6c531b5b9bd6f449ebcc449ea94d0a8f05f62130fda612da53c79659f609")]
    public void KnownTestVectors(string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        foreach (HashAlgorithmFactory hashFactory in Keccak512Implementations.All)
        {
            using var impl = hashFactory.Create();
            byte[] implHash = impl.ComputeHash(data);
            Assert.That(implHash, Is.EqualTo(expected), $"{hashFactory.Name} Keccak-512 mismatch for: \"{input}\"");
        }
    }

    /// <summary>
    /// Test that Keccak-512 differs from SHA3-512 due to different padding.
    /// </summary>
    [Test]
    public void Keccak512DiffersFromSha3512()
    {
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var keccak = Keccak512.Create();
        using var sha3 = SHA3_512.Create();

        byte[] keccakHash = keccak.ComputeHash(input);
        byte[] sha3Hash = sha3.ComputeHash(input);

        Assert.That(keccakHash, Is.Not.EqualTo(sha3Hash), "Keccak-512 and SHA3-512 should produce different hashes");
    }

    /// <summary>
    /// Test incremental hashing with Keccak-512.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var keccak1 = Keccak512.Create();
        byte[] hash1 = keccak1.ComputeHash(input);

        using var keccak2 = Keccak512.Create();
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

        using var keccak = Keccak512.Create();
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
    [TestCaseSource(typeof(Keccak512Implementations), nameof(Keccak512Implementations.All))]
    public void AllImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(64), $"{factory.Name} should produce 64-byte hash");
    }
}
