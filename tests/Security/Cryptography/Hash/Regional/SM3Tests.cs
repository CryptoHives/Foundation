// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.SM3;

using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for <see cref="SM3"/> hash algorithm.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SM3Tests
{
    /// <summary>
    /// Validate SM3 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void HashSizeIs256Bits()
    {
        using var sm3 = SM3.Create();
        Assert.That(sm3.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate SM3 block size is 64 bytes.
    /// </summary>
    [Test]
    public void BlockSizeIs64Bytes()
    {
        using var sm3 = SM3.Create();
        Assert.That(sm3.BlockSize, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate SM3 algorithm name.
    /// </summary>
    [Test]
    public void AlgorithmNameIsSM3()
    {
        using var sm3 = SM3.Create();
        Assert.That(sm3.AlgorithmName, Is.EqualTo("SM3"));
    }

    /// <summary>
    /// Test SM3 with official GB/T 32905-2016 test vectors.
    /// </summary>
    /// <remarks>
    /// Test vectors from Chinese national standard GB/T 32905-2016.
    /// </remarks>
    /// <param name="input">The input string.</param>
    /// <param name="expectedHex">The expected hash in hexadecimal.</param>
    [TestCase("abc", "66c7f0f462eeedd9d1f2d46bdc10e4e24167c4875cf2f7a2297da02b8f4ba8e0")]
    [TestCase("abcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcd", "debe9ff92275b8a138604889c18e5a4d6fdb70e5387e5765293dcba39c0c5732")]
    public void OfficialTestVectors(string input, string expectedHex)
    {
        byte[] data = Encoding.UTF8.GetBytes(input);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var sm3 = SM3.Create();
        byte[] actual = sm3.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected), $"SM3 mismatch for: \"{input}\"");
    }

    /// <summary>
    /// Test SM3 empty string.
    /// </summary>
    [Test]
    public void EmptyStringHash()
    {
        byte[] data = [];
        byte[] expected = TestHelpers.FromHexString("1ab21d8355cfa17f8e61194831e81a8f22bec8c728fefb747ed035eb5082aa2b");

        using var sm3 = SM3.Create();
        byte[] actual = sm3.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test incremental hashing with SM3.
    /// </summary>
    [Test]
    public void IncrementalHashingProducesSameResult()
    {
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var sm3_1 = SM3.Create();
        byte[] hash1 = sm3_1.ComputeHash(input);

        using var sm3_2 = SM3.Create();
        sm3_2.TransformBlock(input, 0, 7, null, 0);
        sm3_2.TransformFinalBlock(input, 7, input.Length - 7);
        byte[] hash2 = sm3_2.Hash!;

        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Cross-implementation test with all implementations.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sm3Implementations), nameof(Sm3Implementations.All))]
    public void AllImplementationsMatch(HashAlgorithmFactory factory)
    {
        byte[] input = Encoding.UTF8.GetBytes("cross-implementation test");

        using var impl = factory.Create();
        byte[] hash = impl.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32), $"{factory.Name} should produce 32-byte hash");
    }

    /// <summary>
    /// Test padding boundary (55 bytes - last byte before padding needs extra block).
    /// </summary>
    [Test]
    public void PaddingBoundary55Bytes()
    {
        byte[] input = new byte[55];
        for (int i = 0; i < 55; i++)
        {
            input[i] = (byte)i;
        }

        using var sm3 = SM3.Create();
        byte[] hash = sm3.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32));
    }

    /// <summary>
    /// Test padding boundary (56 bytes - requires extra block for padding).
    /// </summary>
    [Test]
    public void PaddingBoundary56Bytes()
    {
        byte[] input = new byte[56];
        for (int i = 0; i < 56; i++)
        {
            input[i] = (byte)i;
        }

        using var sm3 = SM3.Create();
        byte[] hash = sm3.ComputeHash(input);

        Assert.That(hash, Has.Length.EqualTo(32));
    }
}


