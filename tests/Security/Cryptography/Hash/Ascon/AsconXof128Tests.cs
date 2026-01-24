// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Ascon;

using NUnit.Framework;
using System;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;
using BCAsconXof128 = Org.BouncyCastle.Crypto.Digests.AsconXof128;

/// <summary>
/// Tests for <see cref="CH.AsconXof128"/> algorithm.
/// </summary>
/// <remarks>
/// Tests verify compatibility with BouncyCastle's NIST SP 800-232 implementation.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsconXof128Tests
{
    /// <summary>
    /// Validate Ascon-XOF128 produces default 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void DefaultHashSizeIs256Bits()
    {
        using var xof = CH.AsconXof128.Create();
        Assert.That(xof.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Ascon-XOF128 block size is 8 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs8Bytes()
    {
        using var xof = CH.AsconXof128.Create();
        Assert.That(xof.BlockSize, Is.EqualTo(8));
    }

    /// <summary>
    /// Validate Ascon-XOF128 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsAsconXof128()
    {
        using var xof = CH.AsconXof128.Create();
        Assert.That(xof.AlgorithmName, Is.EqualTo("Ascon-XOF128"));
    }

    /// <summary>
    /// Test Ascon-XOF128 matches BouncyCastle for various input sizes.
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
        var bc = new BCAsconXof128();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.OutputFinal(expected, 0, 32);

        // CryptoHives implementation
        using var ch = CH.AsconXof128.Create(32);
        byte[] actual = ch.ComputeHash(input);

        Assert.That(actual, Is.EqualTo(expected), $"Mismatch for input length {length}");
    }

    /// <summary>
    /// Test Ascon-XOF128 with variable output sizes.
    /// </summary>
    /// <param name="outputSize">The desired output size in bytes.</param>
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(64)]
    [TestCase(128)]
    public void VariableOutputSize(int outputSize)
    {
        byte[] input = Encoding.UTF8.GetBytes("test");

        // BouncyCastle reference
        var bc = new BCAsconXof128();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[outputSize];
        bc.OutputFinal(expected, 0, outputSize);

        // CryptoHives implementation
        using var xof = CH.AsconXof128.Create(outputSize);
        byte[] result = xof.ComputeHash(input);

        Assert.That(result, Has.Length.EqualTo(outputSize));
        Assert.That(xof.HashSize, Is.EqualTo(outputSize * 8));
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that different output sizes produce prefix-compatible outputs.
    /// </summary>
    [Test]
    public void OutputsArePrefixCompatible()
    {
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var xof32 = CH.AsconXof128.Create(32);
        using var xof64 = CH.AsconXof128.Create(64);

        byte[] result32 = xof32.ComputeHash(input);
        byte[] result64 = xof64.ComputeHash(input);

        Assert.That(result64.AsSpan(0, 32).ToArray(), Is.EqualTo(result32),
            "First 32 bytes of 64-byte output should match 32-byte output");
    }

    /// <summary>
    /// Test incremental hashing with Ascon-XOF128.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var xof1 = CH.AsconXof128.Create();
        byte[] result1 = xof1.ComputeHash(input);

        using var xof2 = CH.AsconXof128.Create();
        xof2.TransformBlock(input, 0, 7, null, 0);
        xof2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] result2 = xof2.Hash!;

        Assert.That(result2, Is.EqualTo(result1));
    }

    /// <summary>
    /// Test that output size must be at least 1 byte.
    /// </summary>
    [Test]
    public void OutputSizeMustBePositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.AsconXof128.Create(0));
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
        var bc = new BCAsconXof128();
        bc.BlockUpdate(input, 0, input.Length);
        byte[] expected = new byte[32];
        bc.OutputFinal(expected, 0, 32);

        using var xof = CH.AsconXof128.Create(32);
        byte[] result = xof.ComputeHash(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}
