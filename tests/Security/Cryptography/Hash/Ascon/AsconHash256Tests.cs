// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Ascon;

using NUnit.Framework;
using System.Text;
using BCAsconHash256 = Org.BouncyCastle.Crypto.Digests.AsconHash256;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Tests for <see cref="CH.AsconHash256"/> algorithm.
/// </summary>
/// <remarks>
/// Tests verify compatibility with BouncyCastle's NIST SP 800-232 implementation.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsconHash256Tests
{
    /// <summary>
    /// Validate Ascon-Hash256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs256Bits()
    {
        using var hash = CH.AsconHash256.Create();
        Assert.That(hash.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Ascon-Hash256 block size is 8 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs8Bytes()
    {
        using var hash = CH.AsconHash256.Create();
        Assert.That(hash.BlockSize, Is.EqualTo(8));
    }

    /// <summary>
    /// Validate Ascon-Hash256 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsAsconHash256()
    {
        using var hash = CH.AsconHash256.Create();
        Assert.That(hash.AlgorithmName, Is.EqualTo("Ascon-Hash256"));
    }

    /// <summary>
    /// Test Ascon-Hash256 matches BouncyCastle for various input sizes.
    /// </summary>
    /// <param name="length">The input length.</param>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(100)]
    [TestCase(1000)]
    public void MatchesBouncyCastle(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++) input[i] = (byte)(i & 0xFF);

        // BouncyCastle reference (NIST SP 800-232)
        var bc = new BCAsconHash256();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.DoFinal(expected, 0);

        // CryptoHives implementation
        using var ch = CH.AsconHash256.Create();
        byte[] actual = ch.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"Mismatch for input length {length}");
    }

    /// <summary>
    /// Test incremental hashing with Ascon-Hash256.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var hash1 = CH.AsconHash256.Create();
        byte[] result1 = hash1.ComputeHash(input);

        using var hash2 = CH.AsconHash256.Create();
        hash2.TransformBlock(input, 0, 7, null, 0);
        hash2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] result2 = hash2.Hash!;

        Assert.That(result2, Is.EqualTo(result1));
    }

    /// <summary>
    /// Test that Initialize resets state correctly.
    /// </summary>
    [Test]
    public void InitializeResetsState()
    {
        byte[] input1 = Encoding.UTF8.GetBytes("first");
        byte[] input2 = Encoding.UTF8.GetBytes("second");

        using var hash = CH.AsconHash256.Create();
        byte[] result1 = hash.ComputeHash(input2);

        hash.Initialize();
        hash.TransformBlock(input1, 0, input1.Length, null, 0);
        hash.Initialize();
        hash.TransformFinalBlock(input2, 0, input2.Length);
        byte[] result2 = hash.Hash!;

        Assert.That(result2, Is.EqualTo(result1));
    }

    /// <summary>
    /// Test padding boundary (7 bytes - last byte before padding needs extra block).
    /// </summary>
    [Test]
    public void PaddingBoundary7Bytes()
    {
        byte[] input = [0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06];

        // Verify against BouncyCastle
        var bc = new BCAsconHash256();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.DoFinal(expected, 0);

        using var hash = CH.AsconHash256.Create();
        byte[] result = hash.ComputeHash(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test padding boundary (8 bytes - requires extra block for padding).
    /// </summary>
    [Test]
    public void PaddingBoundary8Bytes()
    {
        byte[] input = [0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07];

        // Verify against BouncyCastle
        var bc = new BCAsconHash256();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.DoFinal(expected, 0);

        using var hash = CH.AsconHash256.Create();
        byte[] result = hash.ComputeHash(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test large input (multiple blocks).
    /// </summary>
    [Test]
    public void LargeInputMultipleBlocks()
    {
        byte[] input = new byte[1024];
        for (int i = 0; i < input.Length; i++) input[i] = (byte)(i & 0xFF);

        // Verify against BouncyCastle
        var bc = new BCAsconHash256();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.DoFinal(expected, 0);

        using var hash = CH.AsconHash256.Create();
        byte[] result = hash.ComputeHash(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
