// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Cmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;
using Cmac = CryptoHives.Foundation.Security.Cryptography.Mac.Cmac;

/// <summary>
/// Tests for <see cref="Cmac"/> MAC algorithm.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 4493 (AES-CMAC) and NIST SP 800-38B.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CmacTests
{
    #region Factory Method Tests

    /// <summary>
    /// Validate AES-128-CMAC produces correct output size.
    /// </summary>
    [Test]
    public void CmacAes128ProducesCorrectOutputSize()
    {
        byte[] key = new byte[16];
        using var cmac = Cmac.CreateAes128(key);
        Assert.That(cmac.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate AES-192-CMAC produces correct output size.
    /// </summary>
    [Test]
    public void CmacAes192ProducesCorrectOutputSize()
    {
        byte[] key = new byte[24];
        using var cmac = Cmac.CreateAes192(key);
        Assert.That(cmac.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate AES-256-CMAC produces correct output size.
    /// </summary>
    [Test]
    public void CmacAes256ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        using var cmac = Cmac.CreateAes256(key);
        Assert.That(cmac.HashSize, Is.EqualTo(128));
    }

    #endregion

    #region Algorithm Name Tests

    /// <summary>
    /// Validate AES-128-CMAC algorithm name.
    /// </summary>
    [Test]
    public void CmacAes128AlgorithmName()
    {
        byte[] key = new byte[16];
        using var cmac = Cmac.CreateAes128(key);
        Assert.That(cmac.AlgorithmName, Is.EqualTo("AES-128-CMAC"));
    }

    /// <summary>
    /// Validate AES-192-CMAC algorithm name.
    /// </summary>
    [Test]
    public void CmacAes192AlgorithmName()
    {
        byte[] key = new byte[24];
        using var cmac = Cmac.CreateAes192(key);
        Assert.That(cmac.AlgorithmName, Is.EqualTo("AES-192-CMAC"));
    }

    /// <summary>
    /// Validate AES-256-CMAC algorithm name.
    /// </summary>
    [Test]
    public void CmacAes256AlgorithmName()
    {
        byte[] key = new byte[32];
        using var cmac = Cmac.CreateAes256(key);
        Assert.That(cmac.AlgorithmName, Is.EqualTo("AES-256-CMAC"));
    }

    #endregion

    #region RFC 4493 Test Vectors - AES-128-CMAC

    // RFC 4493 test key
    private static readonly byte[] Rfc4493Key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");

    /// <summary>
    /// RFC 4493 Example 1 - Empty message.
    /// Mlen = 0
    /// </summary>
    [Test]
    public void CmacAes128Rfc4493Example1Empty()
    {
        byte[] data = [];
        byte[] expected = TestHelpers.FromHexString("bb1d6929e95937287fa37d129b756746");

        using var cmac = Cmac.CreateAes128(Rfc4493Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4493 Example 2 - 16-byte message (exactly one block).
    /// Mlen = 128 bits
    /// </summary>
    [Test]
    public void CmacAes128Rfc4493Example2OneBlock()
    {
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172a");
        byte[] expected = TestHelpers.FromHexString("070a16b46b4d4144f79bdd9dd04a287c");

        using var cmac = Cmac.CreateAes128(Rfc4493Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4493 Example 3 - 40-byte message (2.5 blocks).
    /// Mlen = 320 bits
    /// </summary>
    [Test]
    public void CmacAes128Rfc4493Example3PartialBlock()
    {
        byte[] data = TestHelpers.FromHexString(
            "6bc1bee22e409f96e93d7e117393172a" +
            "ae2d8a571e03ac9c9eb76fac45af8e51" +
            "30c81c46a35ce411");
        byte[] expected = TestHelpers.FromHexString("dfa66747de9ae63030ca32611497c827");

        using var cmac = Cmac.CreateAes128(Rfc4493Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4493 Example 4 - 64-byte message (exactly 4 blocks).
    /// Mlen = 512 bits
    /// </summary>
    [Test]
    public void CmacAes128Rfc4493Example4FourBlocks()
    {
        byte[] data = TestHelpers.FromHexString(
            "6bc1bee22e409f96e93d7e117393172a" +
            "ae2d8a571e03ac9c9eb76fac45af8e51" +
            "30c81c46a35ce411e5fbc1191a0a52ef" +
            "f69f2445df4f9b17ad2b417be66c3710");
        byte[] expected = TestHelpers.FromHexString("51f0bebf7e3b9d92fc49741779363cfe");

        using var cmac = Cmac.CreateAes128(Rfc4493Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region NIST SP 800-38B Test Vectors - AES-256-CMAC

    // NIST SP 800-38B AES-256 test key
    private static readonly byte[] NistAes256Key = TestHelpers.FromHexString(
        "603deb1015ca71be2b73aef0857d7781" +
        "1f352c073b6108d72d9810a30914dff4");

    /// <summary>
    /// NIST SP 800-38B AES-256 Example - Empty message.
    /// </summary>
    [Test]
    public void CmacAes256NistEmpty()
    {
        byte[] data = [];
        byte[] expected = TestHelpers.FromHexString("028962f61b7bf89efc6b551f4667d983");

        using var cmac = Cmac.CreateAes256(NistAes256Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B AES-256 Example - 16-byte message.
    /// </summary>
    [Test]
    public void CmacAes256NistOneBlock()
    {
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172a");
        byte[] expected = TestHelpers.FromHexString("28a7023f452e8f82bd4bf28d8c37c35c");

        using var cmac = Cmac.CreateAes256(NistAes256Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B AES-256 Example - 64-byte message.
    /// </summary>
    [Test]
    public void CmacAes256NistFourBlocks()
    {
        byte[] data = TestHelpers.FromHexString(
            "6bc1bee22e409f96e93d7e117393172a" +
            "ae2d8a571e03ac9c9eb76fac45af8e51" +
            "30c81c46a35ce411e5fbc1191a0a52ef" +
            "f69f2445df4f9b17ad2b417be66c3710");
        byte[] expected = TestHelpers.FromHexString("e1992190549f6ed5696a2c056c315410");

        using var cmac = Cmac.CreateAes256(NistAes256Key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Validation Tests

    /// <summary>
    /// Validate null key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullKeyThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => Cmac.Create(null!));
    }

    /// <summary>
    /// Validate empty key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void EmptyKeyThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => Cmac.Create([]));
    }

    /// <summary>
    /// Validate invalid key length throws ArgumentException.
    /// </summary>
    [TestCase(8)]
    [TestCase(15)]
    [TestCase(17)]
    [TestCase(20)]
    [TestCase(31)]
    [TestCase(33)]
    public void InvalidKeyLengthThrowsException(int keyLength)
    {
        byte[] key = new byte[keyLength];
        Assert.Throws<ArgumentException>(() => Cmac.Create(key));
    }

    /// <summary>
    /// Validate AES-128 factory rejects wrong key size.
    /// </summary>
    [Test]
    public void Aes128FactoryRejectsWrongKeySize()
    {
        byte[] key = new byte[32];
        Assert.Throws<ArgumentException>(() => Cmac.CreateAes128(key));
    }

    /// <summary>
    /// Validate AES-256 factory rejects wrong key size.
    /// </summary>
    [Test]
    public void Aes256FactoryRejectsWrongKeySize()
    {
        byte[] key = new byte[16];
        Assert.Throws<ArgumentException>(() => Cmac.CreateAes256(key));
    }

    #endregion

    #region Incremental Hashing Tests

    /// <summary>
    /// Validate incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesOneShot()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = TestHelpers.FromHexString(
            "6bc1bee22e409f96e93d7e117393172a" +
            "ae2d8a571e03ac9c9eb76fac45af8e51" +
            "30c81c46a35ce411e5fbc1191a0a52ef" +
            "f69f2445df4f9b17ad2b417be66c3710");

        // One-shot
        byte[] expected;
        using (var cmac1 = Cmac.CreateAes128(key))
        {
            expected = cmac1.ComputeHash(data);
        }

        // Incremental
        byte[] actual;
        using (var cmac2 = Cmac.CreateAes128(key))
        {
            cmac2.TransformBlock(data, 0, 16, null, 0);
            cmac2.TransformBlock(data, 16, 16, null, 0);
            cmac2.TransformBlock(data, 32, 16, null, 0);
            cmac2.TransformFinalBlock(data, 48, 16);
            actual = cmac2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Validate incremental hashing with partial blocks.
    /// </summary>
    [Test]
    public void IncrementalHashingWithPartialBlocks()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = TestHelpers.FromHexString(
            "6bc1bee22e409f96e93d7e117393172a" +
            "ae2d8a571e03ac9c9eb76fac45af8e51" +
            "30c81c46a35ce411");

        // One-shot
        byte[] expected;
        using (var cmac1 = Cmac.CreateAes128(key))
        {
            expected = cmac1.ComputeHash(data);
        }

        // Incremental with odd-sized chunks
        byte[] actual;
        using (var cmac2 = Cmac.CreateAes128(key))
        {
            cmac2.TransformBlock(data, 0, 10, null, 0);
            cmac2.TransformBlock(data, 10, 20, null, 0);
            cmac2.TransformFinalBlock(data, 30, data.Length - 30);
            actual = cmac2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Key Property Tests

    /// <summary>
    /// Validate Key property returns a copy of the key.
    /// </summary>
    [Test]
    public void KeyPropertyReturnsCopy()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        using var cmac = Cmac.CreateAes128(key);

        byte[] retrievedKey = cmac.Key;

        Assert.That(retrievedKey, Is.EqualTo(key));
        Assert.That(retrievedKey, Is.Not.SameAs(key));
    }

    #endregion
}
