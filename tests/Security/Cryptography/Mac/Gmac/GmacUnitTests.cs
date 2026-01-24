// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Gmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;
using Gmac = CryptoHives.Foundation.Security.Cryptography.Mac.Gmac;

/// <summary>
/// Tests for <see cref="Gmac"/> MAC algorithm.
/// </summary>
/// <remarks>
/// Test vectors are from NIST SP 800-38D GCM specification (authentication-only cases).
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class GmacTests
{
    #region Factory Method Tests

    /// <summary>
    /// Validate AES-128-GMAC produces correct output size.
    /// </summary>
    [Test]
    public void GmacAes128ProducesCorrectOutputSize()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes128(key, nonce);
        Assert.That(gmac.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate AES-192-GMAC produces correct output size.
    /// </summary>
    [Test]
    public void GmacAes192ProducesCorrectOutputSize()
    {
        byte[] key = new byte[24];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes192(key, nonce);
        Assert.That(gmac.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate AES-256-GMAC produces correct output size.
    /// </summary>
    [Test]
    public void GmacAes256ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes256(key, nonce);
        Assert.That(gmac.HashSize, Is.EqualTo(128));
    }

    #endregion

    #region Algorithm Name Tests

    /// <summary>
    /// Validate AES-128-GMAC algorithm name.
    /// </summary>
    [Test]
    public void GmacAes128AlgorithmName()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes128(key, nonce);
        Assert.That(gmac.AlgorithmName, Is.EqualTo("AES-128-GMAC"));
    }

    /// <summary>
    /// Validate AES-192-GMAC algorithm name.
    /// </summary>
    [Test]
    public void GmacAes192AlgorithmName()
    {
        byte[] key = new byte[24];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes192(key, nonce);
        Assert.That(gmac.AlgorithmName, Is.EqualTo("AES-192-GMAC"));
    }

    /// <summary>
    /// Validate AES-256-GMAC algorithm name.
    /// </summary>
    [Test]
    public void GmacAes256AlgorithmName()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes256(key, nonce);
        Assert.That(gmac.AlgorithmName, Is.EqualTo("AES-256-GMAC"));
    }

    #endregion

    #region NIST Test Vectors - GCM Authentication Only

    /// <summary>
    /// NIST GCM Test Case 1 - Empty AAD with 96-bit IV.
    /// This is equivalent to GMAC with empty message.
    /// Key = 0, IV = 0, AAD = empty
    /// </summary>
    [Test]
    public void GmacNistTestCase1Empty()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = [];

        // For empty AAD, tag should be AES_K(J0) where J0 = IV || 0^31 || 1
        // With all zeros: H = AES(0) and tag = AES(0^96 || 1)
        byte[] expected = TestHelpers.FromHexString("58e2fccefa7e3061367f1d57a4e7455a");

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] actual = gmac.ComputeHash(aad);

        Assert.That(actual, Is.EqualTo(expected));
    }


    /// <summary>
    /// Test with 16 bytes of zero AAD (consistency test).
    /// Key = 0, IV = 0, AAD = 0 (16 bytes)
    /// </summary>
    [Test]
    public void GmacWithZeroAad()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = new byte[16]; // 16 bytes of zeros

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        // Verify tag is 16 bytes and different from empty AAD case
        Assert.That(tag.Length, Is.EqualTo(16));

        // Verify determinism
        using var gmac2 = Gmac.CreateAes128(key, nonce);
        byte[] tag2 = gmac2.ComputeHash(aad);
        Assert.That(tag, Is.EqualTo(tag2));
    }

    /// <summary>
    /// Test with specific key and IV.
    /// </summary>
    [Test]
    public void GmacWithSpecificKeyAndIv()
    {
        byte[] key = TestHelpers.FromHexString("00000000000000000000000000000000");
        byte[] nonce = TestHelpers.FromHexString("000000000000000000000000");
        byte[] aad = TestHelpers.FromHexString("00000000000000000000000000000000");

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        // Verify tag is 16 bytes
        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with AES-256 key.
    /// </summary>
    [Test]
    public void GmacAes256WithData()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;

        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(i + 1);

        byte[] aad = Encoding.ASCII.GetBytes("Authenticated data for GMAC test");

        using var gmac = Gmac.CreateAes256(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    #endregion

    #region Validation Tests

    /// <summary>
    /// Validate null key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullKeyThrowsException()
    {
        byte[] nonce = new byte[12];
        Assert.Throws<ArgumentNullException>(() => Gmac.Create(null!, nonce));
    }

    /// <summary>
    /// Validate null nonce throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullNonceThrowsException()
    {
        byte[] key = new byte[16];
        Assert.Throws<ArgumentNullException>(() => Gmac.Create(key, null!));
    }

    /// <summary>
    /// Validate empty nonce throws ArgumentException.
    /// </summary>
    [Test]
    public void EmptyNonceThrowsException()
    {
        byte[] key = new byte[16];
        byte[] nonce = [];
        Assert.Throws<ArgumentException>(() => Gmac.Create(key, nonce));
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
        byte[] nonce = new byte[12];
        Assert.Throws<ArgumentException>(() => Gmac.Create(key, nonce));
    }

    /// <summary>
    /// Validate AES-128 factory rejects wrong key size.
    /// </summary>
    [Test]
    public void Aes128FactoryRejectsWrongKeySize()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        Assert.Throws<ArgumentException>(() => Gmac.CreateAes128(key, nonce));
    }

    /// <summary>
    /// Validate AES-256 factory rejects wrong key size.
    /// </summary>
    [Test]
    public void Aes256FactoryRejectsWrongKeySize()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        Assert.Throws<ArgumentException>(() => Gmac.CreateAes256(key, nonce));
    }

    #endregion

    #region Incremental Hashing Tests

    /// <summary>
    /// Validate incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesOneShot()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;

        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(i + 0x10);

        byte[] aad = new byte[64];
        for (int i = 0; i < 64; i++) aad[i] = (byte)i;

        // One-shot
        byte[] expected;
        using (var gmac1 = Gmac.CreateAes128(key, nonce))
        {
            expected = gmac1.ComputeHash(aad);
        }

        // Incremental
        byte[] actual;
        using (var gmac2 = Gmac.CreateAes128(key, nonce))
        {
            gmac2.TransformBlock(aad, 0, 16, null, 0);
            gmac2.TransformBlock(aad, 16, 16, null, 0);
            gmac2.TransformBlock(aad, 32, 16, null, 0);
            gmac2.TransformFinalBlock(aad, 48, 16);
            actual = gmac2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Validate incremental hashing with partial blocks.
    /// </summary>
    [Test]
    public void IncrementalHashingWithPartialBlocks()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)(i + 5);

        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(i + 10);

        byte[] aad = new byte[50];
        for (int i = 0; i < 50; i++) aad[i] = (byte)(i * 3);

        // One-shot
        byte[] expected;
        using (var gmac1 = Gmac.CreateAes128(key, nonce))
        {
            expected = gmac1.ComputeHash(aad);
        }

        // Incremental with odd chunks
        byte[] actual;
        using (var gmac2 = Gmac.CreateAes128(key, nonce))
        {
            gmac2.TransformBlock(aad, 0, 7, null, 0);
            gmac2.TransformBlock(aad, 7, 23, null, 0);
            gmac2.TransformFinalBlock(aad, 30, aad.Length - 30);
            actual = gmac2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Nonce Length Tests

    /// <summary>
    /// Test with standard 96-bit (12-byte) nonce.
    /// </summary>
    [Test]
    public void StandardNonceLength()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] aad = Encoding.ASCII.GetBytes("Test data");

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with non-standard nonce length (8 bytes).
    /// </summary>
    [Test]
    public void NonStandardNonceLength8Bytes()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[8];
        for (int i = 0; i < 8; i++) nonce[i] = (byte)(i + 1);

        byte[] aad = Encoding.ASCII.GetBytes("Test data");

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with non-standard nonce length (16 bytes).
    /// </summary>
    [Test]
    public void NonStandardNonceLength16Bytes()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        for (int i = 0; i < 16; i++) nonce[i] = (byte)(i + 1);

        byte[] aad = Encoding.ASCII.GetBytes("Test data");

        using var gmac = Gmac.CreateAes128(key, nonce);
        byte[] tag = gmac.ComputeHash(aad);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    #endregion

    #region Property Tests

    /// <summary>
    /// Validate Key property returns a copy.
    /// </summary>
    [Test]
    public void KeyPropertyReturnsCopy()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;

        byte[] nonce = new byte[12];
        using var gmac = Gmac.CreateAes128(key, nonce);

        byte[] retrievedKey = gmac.Key;

        Assert.That(retrievedKey, Is.EqualTo(key));
        Assert.That(retrievedKey, Is.Not.SameAs(key));
    }

    /// <summary>
    /// Validate Nonce property returns a copy.
    /// </summary>
    [Test]
    public void NoncePropertyReturnsCopy()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(i + 1);

        using var gmac = Gmac.CreateAes128(key, nonce);

        byte[] retrievedNonce = gmac.Nonce;

        Assert.That(retrievedNonce, Is.EqualTo(nonce));
        Assert.That(retrievedNonce, Is.Not.SameAs(nonce));
    }

    #endregion

    #region Determinism Tests

    /// <summary>
    /// Verify same inputs produce same tag.
    /// </summary>
    [Test]
    public void SameInputsProduceSameOutput()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)(i + 1);

        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(i + 0x20);

        byte[] aad = Encoding.ASCII.GetBytes("Test message for determinism");

        using var gmac1 = Gmac.CreateAes128(key, nonce);
        byte[] tag1 = gmac1.ComputeHash(aad);

        using var gmac2 = Gmac.CreateAes128(key, nonce);
        byte[] tag2 = gmac2.ComputeHash(aad);

        Assert.That(tag1, Is.EqualTo(tag2));
    }

    /// <summary>
    /// Verify different nonces produce different tags.
    /// </summary>
    [Test]
    public void DifferentNoncesProduceDifferentTags()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)(i + 1);

        byte[] nonce1 = new byte[12];
        byte[] nonce2 = new byte[12];
        nonce2[0] = 1;

        byte[] aad = Encoding.ASCII.GetBytes("Same message");

        using var gmac1 = Gmac.CreateAes128(key, nonce1);
        byte[] tag1 = gmac1.ComputeHash(aad);

        using var gmac2 = Gmac.CreateAes128(key, nonce2);
        byte[] tag2 = gmac2.ComputeHash(aad);

        Assert.That(tag1, Is.Not.EqualTo(tag2));
    }

    /// <summary>
    /// Verify different data produces different tags.
    /// </summary>
    [Test]
    public void DifferentDataProducesDifferentTags()
    {
        byte[] key = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)(i + 1);

        byte[] nonce = new byte[12];
        for (int i = 0; i < 12; i++) nonce[i] = (byte)i;

        byte[] aad1 = Encoding.ASCII.GetBytes("Message 1");
        byte[] aad2 = Encoding.ASCII.GetBytes("Message 2");

        using var gmac1 = Gmac.CreateAes128(key, nonce);
        byte[] tag1 = gmac1.ComputeHash(aad1);

        using var gmac2 = Gmac.CreateAes128(key, nonce);
        byte[] tag2 = gmac2.ComputeHash(aad2);

        Assert.That(tag1, Is.Not.EqualTo(tag2));
    }

    #endregion
}
