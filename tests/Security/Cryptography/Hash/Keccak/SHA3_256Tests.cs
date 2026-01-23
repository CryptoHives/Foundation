// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for SHA3-256 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHA3-256 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA3_256Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3256Implementations), nameof(Sha3256Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3256Implementations), nameof(Sha3256Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "3a985da74fe225b2045c172d6bd390bd855f086e3e9d525b46bfe24511431532");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Two block message.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3256Implementations), nameof(Sha3256Implementations.All))]
    public void ComputeHashTwoBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "916f6061fe879741ca6469b43971dfdb28b1a32dc36cb3254e812be27aad1d18");
        byte[] input = Encoding.ASCII.GetBytes(
            "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn" +
            "hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: 200 bytes of 0xa3.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3256Implementations), nameof(Sha3256Implementations.All))]
    public void ComputeHash200BytesA3(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "79f38adec5c20307a98ef76e8324afbfd46cfd81b22e3973c65fa1bd9de31787");
        byte[] input = new byte[200];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = 0xa3;
        }

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Long message (1,000,000 'a' characters).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3256Implementations), nameof(Sha3256Implementations.All))]
    public void ComputeHashMillionAs(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "5c8875ae474a3634ba4fd55ec85bffd661f32aca75c6d699d0cdcb6c115891c1");
        byte[] input = new byte[1_000_000];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = (byte)'a';
        }

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var sha3 = SHA3_256.Create();
        Assert.That(sha3.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Test that block size (rate) is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var sha3 = SHA3_256.Create();
        Assert.That(sha3.BlockSize, Is.EqualTo(136)); // 1088 bits = 136 bytes
    }
}


