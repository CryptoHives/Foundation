// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Cmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="AesCmac"/> using NIST SP 800-38B test vectors and
/// cross-validation against BouncyCastle.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CmacTests
{
    #region NIST SP 800-38B Test Vectors — AES-128

    /// <summary>
    /// NIST SP 800-38B Example 1: AES-128, empty message.
    /// </summary>
    [Test]
    public void AesCmac128NistEmptyMessage()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = [];
        byte[] expected = TestHelpers.FromHexString("bb1d6929e95937287fa37d129b756746");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B Example 2: AES-128, 16-byte message.
    /// </summary>
    [Test]
    public void AesCmac128Nist16ByteMessage()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172a");
        byte[] expected = TestHelpers.FromHexString("070a16b46b4d4144f79bdd9dd04a287c");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B Example 3: AES-128, 40-byte message.
    /// </summary>
    [Test]
    public void AesCmac128Nist40ByteMessage()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172aae2d8a571e03ac9c9eb76fac45af8e5130c81c46a35ce411");
        byte[] expected = TestHelpers.FromHexString("dfa66747de9ae63030ca32611497c827");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B Example 4: AES-128, 64-byte message.
    /// </summary>
    [Test]
    public void AesCmac128Nist64ByteMessage()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172aae2d8a571e03ac9c9eb76fac45af8e5130c81c46a35ce411e5fbc1191a0a52eff69f2445df4f9b17ad2b417be66c3710");
        byte[] expected = TestHelpers.FromHexString("51f0bebf7e3b9d92fc49741779363cfe");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region NIST SP 800-38B Test Vectors — AES-256

    /// <summary>
    /// NIST SP 800-38B AES-256: empty message.
    /// </summary>
    [Test]
    public void AesCmac256NistEmptyMessage()
    {
        byte[] key = TestHelpers.FromHexString("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4");
        byte[] data = [];
        byte[] expected = TestHelpers.FromHexString("028962f61b7bf89efc6b551f4667d983");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B AES-256: 16-byte message.
    /// </summary>
    [Test]
    public void AesCmac256Nist16ByteMessage()
    {
        byte[] key = TestHelpers.FromHexString("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4");
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172a");
        byte[] expected = TestHelpers.FromHexString("28a7023f452e8f82bd4bf28d8c37c35c");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// NIST SP 800-38B AES-256: 64-byte message.
    /// </summary>
    [Test]
    public void AesCmac256Nist64ByteMessage()
    {
        byte[] key = TestHelpers.FromHexString("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4");
        byte[] data = TestHelpers.FromHexString("6bc1bee22e409f96e93d7e117393172aae2d8a571e03ac9c9eb76fac45af8e5130c81c46a35ce411e5fbc1191a0a52eff69f2445df4f9b17ad2b417be66c3710");
        byte[] expected = TestHelpers.FromHexString("e1992190549f6ed5696a2c056c315410");

        using var cmac = AesCmac.Create(key);
        byte[] actual = cmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region BouncyCastle Cross-Validation

    /// <summary>
    /// Validate AES-CMAC-128 against BouncyCastle.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void AesCmac128MatchesBouncyCastle(string message)
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] input = Encoding.UTF8.GetBytes(message);

        // BouncyCastle reference
        var bcCmac = new CMac(new AesEngine(), 128);
        bcCmac.Init(new KeyParameter(key));
        bcCmac.BlockUpdate(input, 0, input.Length);
        byte[] bcResult = new byte[bcCmac.GetMacSize()];
        bcCmac.DoFinal(bcResult, 0);

        using var ours = AesCmac.Create(key);
        byte[] ourResult = ours.ComputeHash(input);

        Assert.That(ourResult, Is.EqualTo(bcResult), $"AES-CMAC-128 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate AES-CMAC-256 against BouncyCastle.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void AesCmac256MatchesBouncyCastle(string message)
    {
        byte[] key = TestHelpers.FromHexString("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4");
        byte[] input = Encoding.UTF8.GetBytes(message);

        // BouncyCastle reference
        var bcCmac = new CMac(new AesEngine(), 128);
        bcCmac.Init(new KeyParameter(key));
        bcCmac.BlockUpdate(input, 0, input.Length);
        byte[] bcResult = new byte[bcCmac.GetMacSize()];
        bcCmac.DoFinal(bcResult, 0);

        using var ours = AesCmac.Create(key);
        byte[] ourResult = ours.ComputeHash(input);

        Assert.That(ourResult, Is.EqualTo(bcResult), $"AES-CMAC-256 mismatch for: \"{message}\"");
    }

    #endregion

    #region Behavioral Tests

    /// <summary>
    /// Test algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmName()
    {
        byte[] key = new byte[16];
        using var cmac = AesCmac.Create(key);
        Assert.That(cmac.AlgorithmName, Is.EqualTo("AES-CMAC"));
    }

    /// <summary>
    /// Test MacSize property.
    /// </summary>
    [Test]
    public void MacSizeIs16()
    {
        byte[] key = new byte[16];
        using var cmac = AesCmac.Create(key);
        Assert.That(cmac.MacSize, Is.EqualTo(16));
    }

    /// <summary>
    /// Reset allows reuse.
    /// </summary>
    [Test]
    public void ResetAllowsReuse()
    {
        byte[] key = new byte[16];
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var cmac = AesCmac.Create(key);
        byte[] hash1 = cmac.ComputeHash(input);
        byte[] hash2 = cmac.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    /// <summary>
    /// Different keys produce different outputs.
    /// </summary>
    [Test]
    public void DifferentKeysProduceDifferentOutputs()
    {
        byte[] key1 = new byte[16];
        byte[] key2 = new byte[16];
        key2[0] = 1;
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var cmac1 = AesCmac.Create(key1);
        using var cmac2 = AesCmac.Create(key2);

        Assert.That(cmac1.ComputeHash(input), Is.Not.EqualTo(cmac2.ComputeHash(input)));
    }

    /// <summary>
    /// Incremental updates produce same result as single call.
    /// </summary>
    [Test]
    public void IncrementalUpdateProducesSameResult()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var cmac1 = AesCmac.Create(key);
        byte[] hash1 = cmac1.ComputeHash(input);

        using var cmac2 = AesCmac.Create(key);
        cmac2.Update(input.AsSpan(0, 7));
        cmac2.Update(input.AsSpan(7));
        byte[] result = new byte[cmac2.MacSize];
        cmac2.Finalize(result);

        Assert.That(result, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Invalid key sizes throw ArgumentException.
    /// </summary>
    [TestCase(8)]
    [TestCase(15)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(33)]
    public void InvalidKeySizeThrows(int keyLength)
    {
        byte[] key = new byte[keyLength];
        Assert.That(() => new AesCmac(key), Throws.TypeOf<ArgumentException>());
    }

    /// <summary>
    /// Static Hash convenience method works.
    /// </summary>
    [Test]
    public void StaticHashMethod()
    {
        byte[] key = new byte[16];
        byte[] input = Encoding.UTF8.GetBytes("test");

        byte[] hash1 = AesCmac.Hash(key, input);

        using var cmac = AesCmac.Create(key);
        byte[] hash2 = cmac.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    #endregion
}
