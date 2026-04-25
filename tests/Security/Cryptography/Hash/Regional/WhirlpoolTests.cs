// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Regional;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

/// <summary>
/// Tests for <see cref="Whirlpool"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class WhirlpoolTests
{
    /// <summary>
    /// Validate Whirlpool produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs512Bits()
    {
        using var whirlpool = Whirlpool.Create();
        Assert.That(whirlpool.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate Whirlpool block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
        using var whirlpool = Whirlpool.Create();
        Assert.That(whirlpool.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate Whirlpool algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsWhirlpool()
    {
        using var whirlpool = Whirlpool.Create();
        Assert.That(whirlpool.AlgorithmName, Is.EqualTo("Whirlpool"));
    }

    /// <summary>
    /// Test Whirlpool with ISO/IEC 10118-3:2004 test vectors across all implementations.
    /// </summary>
    /// <remarks>
    /// Test vectors from ISO standard and NESSIE project.
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
    /// Provides test data combining Whirlpool implementations with official test vectors.
    /// </summary>
    public static System.Collections.IEnumerable OfficialTestVectorData
    {
        get
        {
            var testVectors = new (string input, string hash)[]
            {
                ("", "19fa61d75522a4669b44e39c1d2e1726c530232130d407f89afee0964997f7a7" +
                     "3e83be698b288febcf88e3e03c4f0757ea8964e59b63d93708b138cc42a66eb3"),
                ("a", "8aca2602792aec6f11a67206531fb7d7f0dff59413145e6973c45001d0087b42" +
                      "d11bc645413aeff63a42391a39145a591a92200d560195e53b478584fdae231a"),
                ("abc", "4e2448a4c6f486bb16b6562c73b4020bf3043e3a731bce721ae1b303d97e6d4c" +
                        "7181eebdb6c57e277d0e34957114cbd6c797fc9d95d8b582d225292076d4eef5"),
                ("message digest", "378c84a4126e2dc6e56dcc7458377aac838d00032230f53ce1f5700c0ffb4d3b" +
                                   "8421557659ef55c106b4b52ac5a4aaa692ed920052838f3362e86dbd37a8903e"),
                ("The quick brown fox jumps over the lazy dog", "b97de512e91e3828b40d2b0fdce9ceb3c4a71f9bea8d88e75c4fa854df36725f" +
                                                                "d2b52eb6544edcacd6f8beddfea403cb55ae31f03ad62a5ef54e42ee82c3fb35"),
            };

            foreach (HashAlgorithmFactory factory in WhirlpoolImplementations.All)
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
    /// Test incremental hashing with Whirlpool.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var wp1 = Whirlpool.Create();
        byte[] hash1 = wp1.ComputeHash(input);

        using var wp2 = Whirlpool.Create();
        wp2.TransformBlock(input, 0, 7, null, 0);
        wp2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = wp2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
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

        using var whirlpool = Whirlpool.Create();
        byte[] hash = whirlpool.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(64));
    }
}


