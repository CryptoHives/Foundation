// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="Keccak384"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Keccak384Tests
{
    /// <summary>
    /// Validate Keccak-384 produces 384-bit (48-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs384Bits()
    {
        using var keccak = Keccak384.Create();
        Assert.That(keccak.HashSize, Is.EqualTo(384));
    }

    /// <summary>
    /// Validate Keccak-384 block size is 104 bytes (832 bits).
    /// </summary>
    [Test]
    public void BlockSizeIs104Bytes()
    {
        using var keccak = Keccak384.Create();
        Assert.That(keccak.BlockSize, Is.EqualTo(104));
    }

    /// <summary>
    /// Validate Keccak-384 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsKeccak384()
    {
        using var keccak = Keccak384.Create();
        Assert.That(keccak.AlgorithmName, Is.EqualTo("Keccak-384"));
    }

    /// <summary>
    /// Test Keccak-384 with known test vectors.
    /// </summary>
    /// <remarks>
    /// Keccak-384 uses original Keccak padding (0x01) different from SHA-3 (0x06).
    /// These vectors are generated using BouncyCastle KeccakDigest(384).
    /// </remarks>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCase("", "2c23146a63a29acf99e73b88f8c24eaa7dc60aa771780ccc006afbfa8fe2479b2dd2b21362337441ac12b515911957ff")]
    [TestCase("abc", "f7df1165f033337be098e7d288ad6a2f74409d7a60b49c36642218de161b1f99f8c681e4afaf31a34db29fb763e3c28e")]
    [TestCase("The quick brown fox jumps over the lazy dog", "283990fa9d5fb731d786c5bbee94ea4db4910f18c62c03d173fc0a5e494422e8a0b3da7574dae7fa0baf005e504063b3")]
    public void KnownTestVectors(string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        foreach (HashAlgorithmFactory hashFactory in Keccak384Implementations.All)
        {
            using var impl = hashFactory.Create();
            byte[] implHash = impl.ComputeHash(data);
            Assert.That(implHash, Is.EqualTo(expected), $"{hashFactory.Name} Keccak-384 mismatch for: \"{input}\"");
        }
    }

    /// <summary>
    /// Test that Keccak-384 differs from SHA3-384 due to different padding.
    /// </summary>
    [Test]
    public void Keccak384DiffersFromSha3384()
    {
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var keccak = Keccak384.Create();
        using var sha3 = SHA3_384.Create();

        byte[] keccakHash = keccak.ComputeHash(input);
        byte[] sha3Hash = sha3.ComputeHash(input);

        Assert.That(keccakHash, Is.Not.EqualTo(sha3Hash), "Keccak-384 and SHA3-384 should produce different hashes");
    }

    /// <summary>
    /// Test incremental hashing with Keccak-384.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var keccak1 = Keccak384.Create();
        byte[] hash1 = keccak1.ComputeHash(input);

        using var keccak2 = Keccak384.Create();
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

        using var keccak = Keccak384.Create();
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
    [TestCaseSource(typeof(Keccak384Implementations), nameof(Keccak384Implementations.All))]
    public void AllImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(48), $"{factory.Name} should produce 48-byte hash");
    }
}
