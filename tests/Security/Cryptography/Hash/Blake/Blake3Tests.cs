// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using System;
using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for BLAKE3 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all BLAKE3 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using official test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Blake3Tests
{
    /// <summary>
    /// Test vector: Empty string with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake3Implementations), nameof(Blake3Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "af1349b9f5f9a1a6a0404dea36dcc9499bcb25c9adc112b7cc9a93cae41f3262");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test vector: "abc" with 32-byte output.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Blake3Implementations), nameof(Blake3Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "6437b3ac38465133ffb63b75273a8db548c558465d79db03fd359c6cd5bd9d85");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official test vectors using deterministic input pattern (index mod 251).
    /// Verified against BouncyCastle reference implementation.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    /// <param name="inputLength">The length of the input.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCaseSource(nameof(OfficialTestVectorData))]
    public void OfficialTestVectors(HashAlgorithmFactory factory, int inputLength, string expectedHex)
    {
        byte[] input = GenerateTestInput(inputLength);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test variable output length (XOF capability) for our managed implementation.
    /// </summary>
    [Test]
    public void VariableOutputLength()
    {
        byte[] input = Encoding.ASCII.GetBytes("test");

        using var blake32 = Blake3.Create(32);
        using var blake64 = Blake3.Create(64);

        byte[] hash32 = blake32.ComputeHash(input);
        byte[] hash64 = blake64.ComputeHash(input);

        Assert.That(hash32.Length, Is.EqualTo(32));
        Assert.That(hash64.Length, Is.EqualTo(64));

        // First 32 bytes of 64-byte output should match 32-byte output
        Assert.That(hash64.AsSpan(0, 32).ToArray(), Is.EqualTo(hash32));
    }

    /// <summary>
    /// Test that invalid output size throws for our managed implementation.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.Create(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.Create(-1));
    }

    /// <summary>
    /// Test that hash size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void HashSizeIsCorrect()
    {
        using var blake3 = Blake3.Create();
        Assert.That(blake3.HashSize, Is.EqualTo(256));

        using var blake64 = Blake3.Create(64);
        Assert.That(blake64.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Test block size is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var blake3 = Blake3.Create();
        Assert.That(blake3.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Provides test data combining implementations with test vectors.
    /// </summary>
    public static System.Collections.IEnumerable OfficialTestVectorData
    {
        get
        {
            var testVectors = new (int length, string hash)[]
            {
                (0, "af1349b9f5f9a1a6a0404dea36dcc9499bcb25c9adc112b7cc9a93cae41f3262"),
                (1, "2d3adedff11b61f14c886e35afa036736dcd87a74d27b5c1510225d0f592e213"),
                (2, "7b7015bb92cf0b318037702a6cdd81dee41224f734684c2c122cd6359cb1ee63"),
                (3, "e1be4d7a8ab5560aa4199eea339849ba8e293d55ca0a81006726d184519e647f"),
                (4, "f30f5ab28fe047904037f77b6da4fea1e27241c5d132638d8bedce9d40494f32"),
                (5, "b40b44dfd97e7a84a996a91af8b85188c66c126940ba7aad2e7ae6b385402aa2"),
                (6, "06c4e8ffb6872fad96f9aaca5eee1553eb62aed0ad7198cef42e87f6a616c844"),
                (7, "3f8770f387faad08faa9d8414e9f449ac68e6ff0417f673f602a646a891419fe"),
                (8, "2351207d04fc16ade43ccab08600939c7c1fa70a5c0aaca76063d04c3228eaeb"),
                (63, "e9bc37a594daad83be9470df7f7b3798297c3d834ce80ba85d6e207627b7db7b"),
                (64, "4eed7141ea4a5cd4b788606bd23f46e212af9cacebacdc7d1f4c6dc7f2511b98"),
                (65, "de1e5fa0be70df6d2be8fffd0e99ceaa8eb6e8c93a63f2d8d1c30ecb6b263dee"),
                (127, "d81293fda863f008c09e92fc382a81f5a0b4a1251cba1634016a0f86a6bd640d"),
                (128, "f17e570564b26578c33bb7f44643f539624b05df1a76c81f30acd548c44b45ef"),
                (129, "683aaae9f3c5ba37eaaf072aed0f9e30bac0865137bae68b1fde4ca2aebdcb12"),
                (1023, "10108970eeda3eb932baac1428c7a2163b0e924c9a9e25b35bba72b28f70bd11"),
                (1024, "42214739f095a406f3fc83deb889744ac00df831c10daa55189b5d121c855af7"),
                // Multi-chunk test vectors (> 1024 bytes)
                (1025, "d00278ae47eb27b34faecf67b4fe263f82d5412916c1ffd97c8cb7fb814b8444"),
                (2048, "e776b6028c7cd22a4d0ba182a8bf62205d2ef576467e838ed6f2529b85fba24a"),
                (2049, "5f4d72f40d7a5f82b15ca2b2e44b1de3c2ef86c426c95c1af0b6879522563030"),
            };

            foreach (HashAlgorithmFactory factory in Blake3Implementations.All)
            {
                foreach (var (length, hash) in testVectors)
                {
                    yield return new TestCaseData(factory, length, hash)
                        .SetName($"OfficialTestVectors({factory.Name}, {length})");
                }
            }
        }
    }

    /// <summary>
    /// Generates test input using the official BLAKE3 pattern (index mod 251).
    /// </summary>
    private static byte[] GenerateTestInput(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++)
        {
            input[i] = (byte)(i % 251);
        }
        return input;
    }
}


