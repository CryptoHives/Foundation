// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Keccak;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for SHA3-384 implementations.
/// </summary>
/// <remarks>
/// These tests verify that all SHA3-384 implementations (Managed, BouncyCastle)
/// produce identical results for the same inputs using NIST test vectors.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SHA3_384Tests
{
    /// <summary>
    /// NIST test vector: Empty string.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3384Implementations), nameof(Sha3384Implementations.All))]
    public void ComputeHashEmptyString(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "0c63a75b845e4f7d01107d852e4c2485c51a50aaaa94fc61995e71bbee983a2a" +
            "c3713831264adb47fb6bd1e058d5f004");

        using var algorithm = factory.Create();
        byte[] hash = algorithm.ComputeHash(Array.Empty<byte>());

        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST test vector: "abc"
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [TestCaseSource(typeof(Sha3384Implementations), nameof(Sha3384Implementations.All))]
    public void ComputeHashAbc(HashAlgorithmFactory factory)
    {
        byte[] expected = TestHelpers.FromHexString(
            "ec01498288516fc926459f58e2c6ad8df9b473cb0fc08c2596da7cf0e49be4b2" +
            "98d88cea927ac7f539f1edf228376d25");
        byte[] input = Encoding.ASCII.GetBytes("abc");

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
        using var sha3 = SHA3_384.Create();
        Assert.That(sha3.HashSize, Is.EqualTo(384));
    }

    /// <summary>
    /// Test that block size (rate) is correct for our managed implementation.
    /// </summary>
    [Test]
    public void BlockSizeIsCorrect()
    {
        using var sha3 = SHA3_384.Create();
        Assert.That(sha3.BlockSize, Is.EqualTo(104)); // 832 bits = 104 bytes
    }
}


