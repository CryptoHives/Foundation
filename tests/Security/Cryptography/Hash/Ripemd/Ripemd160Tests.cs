// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Ripemd;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

/// <summary>
/// Tests for <see cref="Ripemd160"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Ripemd160Tests
{
    /// <summary>
    /// Validate RIPEMD-160 produces 160-bit (20-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs160Bits()
    {
        using var ripemd = Ripemd160.Create();
        Assert.That(ripemd.HashSize, Is.EqualTo(160));
    }

    /// <summary>
    /// Validate RIPEMD-160 block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
        using var ripemd = Ripemd160.Create();
        Assert.That(ripemd.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate RIPEMD-160 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsRipemd160()
    {
        using var ripemd = Ripemd160.Create();
        Assert.That(ripemd.AlgorithmName, Is.EqualTo("RIPEMD-160"));
    }

    /// <summary>
    /// Test RIPEMD-160 with official test vectors across all implementations.
    /// </summary>
    /// <remarks>
    /// Test vectors from: https://homes.esat.kuleuven.be/~bosselae/ripemd160.html
    /// </remarks>
    /// <param name="factory">The hash algorithm factory.</param>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCaseSource(nameof(OfficialTestVectorData))]
    public void OfficialTestVectors(HashAlgorithmFactory factory, string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var impl = factory.Create();
        byte[] actual = impl.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Provides test data combining RIPEMD-160 implementations with official test vectors.
    /// </summary>
    public static System.Collections.IEnumerable OfficialTestVectorData
    {
        get
        {
            var testVectors = new (string input, string hash)[]
            {
                ("", "9c1185a5c5e9fc54612808977ee8f548b2258d31"),
                ("a", "0bdc9d2d256b3ee9daae347be6f4dc835a467ffe"),
                ("abc", "8eb208f7e05d987a9b044a8e98c6b087f15a0bfc"),
                ("message digest", "5d0689ef49d2fae572b881b123a85ffa21595f36"),
                ("abcdefghijklmnopqrstuvwxyz", "f71c27109c692c1b56bbdceb5b9d2865b3708dbc"),
                ("abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq", "12a053384a9c0c88e405a06c27dcf49ada62eb2b"),
                ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", "b0e20b6e3116640286ed3a87a5713079b21f5189"),
                ("12345678901234567890123456789012345678901234567890123456789012345678901234567890", "9b752e45573d4b39f4dbd3323cab82bf63326bfb"),
                ("The quick brown fox jumps over the lazy dog", "37f332f68db77bd9d7edd4969571ad671cf9dd3b"),
            };

            foreach (HashAlgorithmFactory factory in Ripemd160Implementations.All)
            {
                foreach (var (input, hash) in testVectors)
                {
                    string label = input.Length > 20 ? input[..20] + "..." : input;
                    yield return new TestCaseData(factory, input, hash)
                        .SetName($"OfficialTestVectors({factory.Name}, \"{label}\")");
                }
            }
        }
    }

    /// <summary>
    /// Test incremental hashing with RIPEMD-160.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var ripemd1 = Ripemd160.Create();
        byte[] hash1 = ripemd1.ComputeHash(input);

        using var ripemd2 = Ripemd160.Create();
        ripemd2.TransformBlock(input, 0, 7, null, 0);
        ripemd2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = ripemd2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test Bitcoin-style Hash160 (SHA-256 followed by RIPEMD-160).
    /// </summary>
    [Test]
    public void BitcoinHash160Pattern()
    {
        byte[] publicKey = TestHelpers.FromHexString("0250863ad64a87ae8a2fe83c1af1a8403cb53f53e486d8511dad8a04887e5b2352");

        using var sha256 = SHA256.Create();
        byte[] sha256Hash = sha256.ComputeHash(publicKey);

        using var ripemd = Ripemd160.Create();
        byte[] hash160 = ripemd.ComputeHash(sha256Hash);

        Assert.That(hash160, Has.Length.EqualTo(20));
    }
}


