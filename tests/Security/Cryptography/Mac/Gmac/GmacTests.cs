// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Gmac;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="AesGmac"/> using cross-validation against the underlying
/// AES-GCM with empty plaintext.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class GmacTests
{
    #region Basic Tests

    /// <summary>
    /// GMAC produces a 16-byte tag.
    /// </summary>
    [Test]
    public void TagIs16Bytes()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] data = Encoding.UTF8.GetBytes("test");

        using var gmac = AesGmac.Create(key);
        byte[] tag = gmac.ComputeTag(nonce, data);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Algorithm name is correct.
    /// </summary>
    [Test]
    public void AlgorithmName()
    {
        byte[] key = new byte[16];
        using var gmac = AesGmac.Create(key);
        Assert.That(gmac.AlgorithmName, Is.EqualTo("AES-GMAC"));
    }

    #endregion

    #region Cross-Validation with AES-GCM

    /// <summary>
    /// GMAC matches AES-GCM with empty plaintext (AES-128).
    /// </summary>
    [Test]
    public void Gmac128MatchesAesGcmEmptyPlaintext()
    {
        byte[] key = TestHelpers.FromHexString("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] nonce = TestHelpers.FromHexString("000102030405060708090a0b");
        byte[] aad = Encoding.UTF8.GetBytes("authenticated data");

        // AES-GCM with empty plaintext
        using var gcm = new AesGcm128(key);
        byte[] gcmTag = new byte[16];
        gcm.Encrypt(nonce, [], [], gcmTag, aad);

        // GMAC
        using var gmac = AesGmac.Create(key);
        byte[] gmacTag = gmac.ComputeTag(nonce, aad);

        Assert.That(gmacTag, Is.EqualTo(gcmTag));
    }

    /// <summary>
    /// GMAC matches AES-GCM with empty plaintext (AES-256).
    /// </summary>
    [Test]
    public void Gmac256MatchesAesGcmEmptyPlaintext()
    {
        byte[] key = TestHelpers.FromHexString("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4");
        byte[] nonce = TestHelpers.FromHexString("000102030405060708090a0b");
        byte[] aad = Encoding.UTF8.GetBytes("authenticated data");

        // AES-GCM with empty plaintext
        using var gcm = new AesGcm256(key);
        byte[] gcmTag = new byte[16];
        gcm.Encrypt(nonce, [], [], gcmTag, aad);

        // GMAC
        using var gmac = AesGmac.Create(key);
        byte[] gmacTag = gmac.ComputeTag(nonce, aad);

        Assert.That(gmacTag, Is.EqualTo(gcmTag));
    }

    /// <summary>
    /// GMAC with empty AAD matches AES-GCM with empty plaintext and AAD.
    /// </summary>
    [Test]
    public void GmacEmptyAadMatchesAesGcm()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];

        using var gcm = new AesGcm128(key);
        byte[] gcmTag = new byte[16];
        gcm.Encrypt(nonce, [], [], gcmTag);

        using var gmac = AesGmac.Create(key);
        byte[] gmacTag = gmac.ComputeTag(nonce, []);

        Assert.That(gmacTag, Is.EqualTo(gcmTag));
    }

    #endregion

    #region Tag Verification

    /// <summary>
    /// VerifyTag returns true for correct tag.
    /// </summary>
    [Test]
    public void VerifyTagReturnsTrueForCorrectTag()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = Encoding.UTF8.GetBytes("test data");

        using var gmac = AesGmac.Create(key);
        byte[] tag = gmac.ComputeTag(nonce, aad);

        Assert.That(gmac.VerifyTag(nonce, aad, tag), Is.True);
    }

    /// <summary>
    /// VerifyTag returns false for incorrect tag.
    /// </summary>
    [Test]
    public void VerifyTagReturnsFalseForIncorrectTag()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = Encoding.UTF8.GetBytes("test data");

        using var gmac = AesGmac.Create(key);
        byte[] tag = gmac.ComputeTag(nonce, aad);
        tag[0] ^= 0xFF; // corrupt tag

        Assert.That(gmac.VerifyTag(nonce, aad, tag), Is.False);
    }

    /// <summary>
    /// VerifyTag returns false for modified AAD.
    /// </summary>
    [Test]
    public void VerifyTagReturnsFalseForModifiedAad()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = Encoding.UTF8.GetBytes("test data");

        using var gmac = AesGmac.Create(key);
        byte[] tag = gmac.ComputeTag(nonce, aad);

        byte[] modifiedAad = Encoding.UTF8.GetBytes("test datb");
        Assert.That(gmac.VerifyTag(nonce, modifiedAad, tag), Is.False);
    }

    #endregion

    #region Key Size Tests

    /// <summary>
    /// All valid AES key sizes work.
    /// </summary>
    [TestCase(16)]
    [TestCase(24)]
    [TestCase(32)]
    public void ValidKeySizesWork(int keySize)
    {
        byte[] key = new byte[keySize];
        byte[] nonce = new byte[12];
        byte[] data = Encoding.UTF8.GetBytes("test");

        using var gmac = AesGmac.Create(key);
        byte[] tag = gmac.ComputeTag(nonce, data);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Invalid key sizes throw.
    /// </summary>
    [TestCase(8)]
    [TestCase(15)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(33)]
    public void InvalidKeySizeThrows(int keyLength)
    {
        byte[] key = new byte[keyLength];
        Assert.That(() => new AesGmac(key), Throws.TypeOf<ArgumentException>());
    }

    #endregion

    #region Different Keys and Nonces

    /// <summary>
    /// Different keys produce different tags.
    /// </summary>
    [Test]
    public void DifferentKeysProduceDifferentTags()
    {
        byte[] key1 = new byte[16];
        byte[] key2 = new byte[16];
        key2[0] = 1;
        byte[] nonce = new byte[12];
        byte[] aad = Encoding.UTF8.GetBytes("test");

        using var gmac1 = AesGmac.Create(key1);
        using var gmac2 = AesGmac.Create(key2);

        Assert.That(gmac1.ComputeTag(nonce, aad), Is.Not.EqualTo(gmac2.ComputeTag(nonce, aad)));
    }

    /// <summary>
    /// Different nonces produce different tags.
    /// </summary>
    [Test]
    public void DifferentNoncesProduceDifferentTags()
    {
        byte[] key = new byte[16];
        byte[] nonce1 = new byte[12];
        byte[] nonce2 = new byte[12];
        nonce2[0] = 1;
        byte[] aad = Encoding.UTF8.GetBytes("test");

        using var gmac = AesGmac.Create(key);

        Assert.That(gmac.ComputeTag(nonce1, aad), Is.Not.EqualTo(gmac.ComputeTag(nonce2, aad)));
    }

    #endregion
}
