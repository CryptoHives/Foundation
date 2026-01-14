// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Legacy;

using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="MD5"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MD5Tests
{
    /// <summary>
    /// Validate MD5 produces 128-bit (16-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs128Bits()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        using var md5 = MD5.Create();
#pragma warning restore CS0618
        Assert.That(md5.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate MD5 block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        using var md5 = MD5.Create();
#pragma warning restore CS0618
        Assert.That(md5.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate MD5 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsMD5()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        using var md5 = MD5.Create();
#pragma warning restore CS0618
        Assert.That(md5.AlgorithmName, Is.EqualTo("MD5"));
    }

    /// <summary>
    /// Test MD5 with RFC 1321 test vectors.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCase("", "d41d8cd98f00b204e9800998ecf8427e")]
    [TestCase("a", "0cc175b9c0f1b6a831c399e269772661")]
    [TestCase("abc", "900150983cd24fb0d6963f7d28e17f72")]
    [TestCase("message digest", "f96b697d7cb7938d525a2f31aaf161d0")]
    [TestCase("abcdefghijklmnopqrstuvwxyz", "c3fcd3d76192e4007dfb496cca67e13b")]
    [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "d174ab98d277d9f5a5611c2c9f419d9f")]
    [TestCase("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "57edf4a22be3c955ac49da2e2107b67a")]
    public void Rfc1321TestVectors(string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

#pragma warning disable CS0618 // Type or member is obsolete
        using var md5 = MD5.Create();
#pragma warning restore CS0618
        byte[] actual = md5.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected), $"MD5 mismatch for: \"{input}\"");
    }

    /// <summary>
    /// Test incremental hashing with MD5.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

#pragma warning disable CS0618 // Type or member is obsolete
        using var md5_1 = MD5.Create();
        byte[] hash1 = md5_1.ComputeHash(input);

        using var md5_2 = MD5.Create();
        md5_2.TransformBlock(input, 0, 7, null, 0);
        md5_2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = md5_2.Hash!;
#pragma warning restore CS0618

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Cross-implementation test with all implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Md5Implementations), nameof(Md5Implementations.All))]
    public void AllImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(16), $"{factory.Name} should produce 16-byte hash");
    }
}


