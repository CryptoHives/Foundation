// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Legacy;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

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
    /// Test MD5 with RFC 1321 test vectors across all implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCaseSource(nameof(Rfc1321TestVectorData))]
    public void Rfc1321TestVectors(HashAlgorithmFactory factory, string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var actual = factory.Create();
        byte[] hash = actual.ComputeHash(data);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Provides test data combining MD5 implementations with RFC 1321 test vectors.
    /// </summary>
    public static System.Collections.IEnumerable Rfc1321TestVectorData
    {
        get
        {
            var testVectors = new (string input, string hash)[]
            {
                ("", "d41d8cd98f00b204e9800998ecf8427e"),
                ("a", "0cc175b9c0f1b6a831c399e269772661"),
                ("abc", "900150983cd24fb0d6963f7d28e17f72"),
                ("message digest", "f96b697d7cb7938d525a2f31aaf161d0"),
                ("abcdefghijklmnopqrstuvwxyz", "c3fcd3d76192e4007dfb496cca67e13b"),
                ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "d174ab98d277d9f5a5611c2c9f419d9f"),
                ("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "57edf4a22be3c955ac49da2e2107b67a"),
                ("The quick brown fox jumps over the lazy dog", "9e107d9d372bb6826bd81d3542a419d6"),
            };

            foreach (HashAlgorithmFactory factory in Md5Implementations.All)
            {
                foreach (var (input, hash) in testVectors)
                {
                    string label = input.Length > 20 ? input[..20] + "..." : input;
                    yield return new TestCaseData(factory, input, hash)
                        .SetName($"Rfc1321TestVectors({factory.Name}, \"{label}\")");
                }
            }
        }
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

}



