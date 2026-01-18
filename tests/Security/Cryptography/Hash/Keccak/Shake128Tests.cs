// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for SHAKE128 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHAKE128 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Shake128Tests
{
    /// <summary>
    /// NIST test vector: Empty string with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Shake128Implementations), nameof(Shake128Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "7f9c2ba4e88f827d616045507605853ed73b8093f6efbc88eb1a6eacfa66ef26");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc" with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Shake128Implementations), nameof(Shake128Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "5881092dd818bf5cf8a3ddb793fbcba74097d5c526a6d35f97b83351940f2cc8");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test variable output length for our managed implementation.
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var shake16 = Shake128.Create(16);
        using var shake64 = Shake128.Create(64);

        byte[] hash16 = shake16.ComputeHash(input);
        byte[] hash64 = shake64.ComputeHash(input);

        Assert.That(hash16, Has.Length.EqualTo(16));
        Assert.That(hash64, Has.Length.EqualTo(64));
        // First 16 bytes of 64-byte output should match 16-byte output
        Assert.That(hash64.AsSpan(0, 16).ToArray(), Is.EqualTo(hash16));
    }

    /// <summary>
    /// Test that invalid output size throws for our managed implementation.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Shake128.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Shake128.Create(-1));
    }
}


