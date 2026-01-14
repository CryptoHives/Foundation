// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using System;
using System.Text;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;

/// <summary>
/// Tests for SHA3-512 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHA3-512 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA3_512Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3512Implementations), nameof(Sha3512Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a6" +
            "15b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3512Implementations), nameof(Sha3512Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e" +
            "10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0");
        byte[] input = Encoding.ASCII.GetBytes("abc");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(input);

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: 200 bytes of 0xa3.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3512Implementations), nameof(Sha3512Implementations.All))]
    public void ComputeHash200BytesA3(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "e76dfad22084a8b1467fcf2ffa58361bec7628edf5f3fdc0e4805dc48caeeca8" +
            "1b7c13c30adf52a3659584739a2df46be589c51ca1a4a8416df6545a1ce8ba00");
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
    [TestCaseSource(typeof(Sha3512Implementations), nameof(Sha3512Implementations.All))]
    public void ComputeHashMillionAs(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "3c3a876da14034ab60627c077bb98f7e120a2a5370212dffb3385a18d4f38859" +
            "ed311d0a9d5141ce9cc5c66ee689b266a8aa18ace8282a0e0db596c90b0a7b87");
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
        using var sha3 = SHA3_512.Create();
        Assert.That(sha3.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Test that block size (rate) is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var sha3 = SHA3_512.Create();
        Assert.That(sha3.BlockSize, Is.EqualTo(72)); // 576 bits = 72 bytes
    }
}


