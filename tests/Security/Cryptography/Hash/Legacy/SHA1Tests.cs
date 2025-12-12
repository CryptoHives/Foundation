// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for SHA-1 implementations.
/// </summary>
/// <remarks>
/// <para>
/// SHA-1 is deprecated but these tests ensure backward compatibility
/// for legacy data verification.
/// </para>
/// <para>
/// These tests verify that all SHA-1 implementations (OS, Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA1Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("da39a3ee5e6b4b0d3255bfef95601890afd80709");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("a9993e364706816aba3e25717850c26c9cd0d89d");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: One block message (448 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashOneBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("84983e441c3bd26ebaae4aa1f95129e5e54670f1");
        byte[] input = Encoding.ASCII.GetBytes("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Two block message (896 bits).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashTwoBlockMessage(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("a49b2446a02c645bf419f995b67091253a04a259");
        byte[] input = Encoding.ASCII.GetBytes(
            "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn" +
            "hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "The quick brown fox jumps over the lazy dog"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashQuickBrownFox(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("2fd4e1c67a2d28fced849ee1bb76e7391b93eb12");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "The quick brown fox jumps over the lazy cog" (different ending).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashQuickBrownFoxCog(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("de9f2c7fd25e1b3afad3e85a0bd17d9b100db4b3");
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy cog");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: Long message (1,000,000 'a' characters).
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha1Implementations), nameof(Sha1Implementations.All))]
    public void ComputeHashMillionAs(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString("34aa973cd4c4daa4f61eeb2bdbad27316534016f");
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
#pragma warning disable CS0618 // Type or member is obsolete
        using var sha1 = SHA1.Create();
#pragma warning restore CS0618
        Assert.That(sha1.HashSize, Is.EqualTo(160));
    }

    /// <summary>
    /// Test that block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        using var sha1 = SHA1.Create();
#pragma warning restore CS0618
        Assert.That(sha1.BlockSize, Is.EqualTo(64));
    }
}


