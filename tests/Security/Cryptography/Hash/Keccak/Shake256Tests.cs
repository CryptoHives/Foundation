// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for SHAKE256 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHAKE256 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Shake256Tests
{
    /// <summary>
    /// NIST test vector: Empty string with 64-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Shake256Implementations), nameof(Shake256Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "46b9dd2b0ba88d13233b3feb743eeb243fcd52ea62b81b82b50c27646ed5762f" +
            "d75dc4ddd8c0f200cb05019d67b592f6fc821c49479ab48640292eacb3b7c4be");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc" with 64-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Shake256Implementations), nameof(Shake256Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "483366601360a8771c6863080cc4114d8db44530f8f1e1ee4f94ea37e78b5739" +
            "d5a15bef186a5386c75744c0527e1faa9f8726e462a12a4feb06bd8801e751e4");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that hash size matches output bytes for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeMatchesOutputBytes()
    {
        using var shake32 = Shake256.Create(32);
        using var shake128 = Shake256.Create(128);

        Assert.That(shake32.HashSize, Is.EqualTo(256)); // 32 * 8
        Assert.That(shake128.HashSize, Is.EqualTo(1024)); // 128 * 8
    }
}


