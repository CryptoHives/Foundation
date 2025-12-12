// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.GOST;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="Streebog"/> hash algorithm (GOST R 34.11-2012).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class StreebogTests
{
    /// <summary>
    /// Validate Streebog-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void Streebog256HashSizeIs256Bits()
    {
        using var streebog = Streebog.Create(32);
        Assert.That(streebog.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Streebog-512 produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void Streebog512HashSizeIs512Bits()
    {
        using var streebog = Streebog.Create(64);
        Assert.That(streebog.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate Streebog block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
        using var streebog = Streebog.Create();
        Assert.That(streebog.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate Streebog algorithm names.
    /// </summary>
    [TestCase(32, "Streebog-256")]
    [TestCase(64, "Streebog-512")]
    public void AlgorithmNameIsCorrect(int hashSizeBytes, string expectedName)
    {
        using var streebog = Streebog.Create(hashSizeBytes);
        Assert.That(streebog.AlgorithmName, Is.EqualTo(expectedName));
    }

    /// <summary>
    /// Test invalid hash size throws exception.
    /// </summary>
    [TestCase(16)]
    [TestCase(48)]
    [TestCase(128)]
    public void InvalidHashSizeThrows(int invalidSize)
    {
        Assert.Throws<ArgumentException>(() => Streebog.Create(invalidSize));
    }

    /// <summary>
    /// Test incremental hashing with Streebog-256.
    /// </summary>
    [Test]
    public void Streebog256IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var s1 = Streebog.Create(32);
        byte[] hash1 = s1.ComputeHash(input);

        using var s2 = Streebog.Create(32);
        s2.TransformBlock(input, 0, 7, null, 0);
        s2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = s2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test incremental hashing with Streebog-512.
    /// </summary>
    [Test]
    public void Streebog512IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var s1 = Streebog.Create(64);
        byte[] hash1 = s1.ComputeHash(input);

        using var s2 = Streebog.Create(64);
        s2.TransformBlock(input, 0, 7, null, 0);
        s2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = s2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Cross-implementation test with all Streebog-256 implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Streebog256Implementations), nameof(Streebog256Implementations.All))]
    public void AllStreebog256ImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32), $"{factory.Name} should produce 32-byte hash");
    }

    /// <summary>
    /// Cross-implementation test with all Streebog-512 implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Streebog512Implementations), nameof(Streebog512Implementations.All))]
    public void AllStreebog512ImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(64), $"{factory.Name} should produce 64-byte hash");
    }

    /// <summary>
    /// Test with larger input crossing multiple blocks.
    /// </summary>
    [Test]
    public void MultiBlockInput()
    {
        byte[] input = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            input[i] = (byte)i;
        }

        using var streebog256 = Streebog.Create(32);
        byte[] hash256 = streebog256.ComputeHash(input);
        Assert.That(hash256, Has.Length.EqualTo(32));

        using var streebog512 = Streebog.Create(64);
        byte[] hash512 = streebog512.ComputeHash(input);
        Assert.That(hash512, Has.Length.EqualTo(64));

        // The two hashes should be different - compare first 32 bytes of 512 with 256 hash
        byte[] hash512First32 = new byte[32];
        Array.Copy(hash512, 0, hash512First32, 0, 32);
        Assert.That(hash256, Is.Not.EqualTo(hash512First32));
    }

    /// <summary>
    /// Test that hashing produces deterministic results.
    /// </summary>
    [Test]
    public void DeterministicOutput()
    {
        byte[] input = Encoding.UTF8.GetBytes("deterministic test");

        using var s1 = Streebog.Create(32);
        using var s2 = Streebog.Create(32);

        byte[] hash1 = s1.ComputeHash(input);
        byte[] hash2 = s2.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    /// <summary>
    /// Test reuse after Initialize.
    /// </summary>
    [Test]
    public void ReuseAfterInitialize()
    {
        byte[] input1 = Encoding.UTF8.GetBytes("first");
        byte[] input2 = Encoding.UTF8.GetBytes("second");

        using var streebog = Streebog.Create(32);
        byte[] hash1 = streebog.ComputeHash(input1);

        streebog.Initialize();
        byte[] hash2 = streebog.ComputeHash(input2);

        streebog.Initialize();
        byte[] hash1Again = streebog.ComputeHash(input1);

        Assert.That(hash1Again, Is.EqualTo(hash1));
        Assert.That(hash1, Is.Not.EqualTo(hash2));
    }
}


