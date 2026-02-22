// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Gcm;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Tests for AES-GCM implementation using NIST test vectors.
/// </summary>
/// <remarks>
/// Test vectors from NIST SP 800-38D and GCM specification.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AesGcmTests
{
    // ========================================================================
    // NIST GCM Test Vectors - Test Case 1: Empty plaintext
    // ========================================================================

    [Test]
    public void AesGcm128_TestCase1_EmptyPlaintext()
    {
        // Test Case 1 from NIST GCM spec
        byte[] key = FromHex("00000000000000000000000000000000");
        byte[] nonce = FromHex("000000000000000000000000");
        byte[] plaintext = Array.Empty<byte>();
        byte[] aad = Array.Empty<byte>();
        byte[] expectedCiphertext = Array.Empty<byte>();
        byte[] expectedTag = FromHex("58e2fccefa7e3061367f1d57a4e7455a");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    // ========================================================================
    // NIST GCM Test Vectors - Test Case 2: Simple encryption
    // ========================================================================

    [Test]
    public void AesGcm128_TestCase2_SimpleEncryption()
    {
        // Test Case 2 from NIST GCM spec
        byte[] key = FromHex("00000000000000000000000000000000");
        byte[] nonce = FromHex("000000000000000000000000");
        byte[] plaintext = FromHex("00000000000000000000000000000000");
        byte[] aad = Array.Empty<byte>();
        byte[] expectedCiphertext = FromHex("0388dace60b6a392f328c2b971b2fe78");
        byte[] expectedTag = FromHex("ab6e47d42cec13bdf53a67b21257bddf");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    // ========================================================================
    // NIST GCM Test Vectors - Test Case 3
    // ========================================================================

    [Test]
    public void AesGcm128_TestCase3()
    {
        byte[] key = FromHex("feffe9928665731c6d6a8f9467308308");
        byte[] nonce = FromHex("cafebabefacedbaddecaf888");
        byte[] plaintext = FromHex(
            "d9313225f88406e5a55909c5aff5269a" +
            "86a7a9531534f7da2e4c303d8a318a72" +
            "1c3c0c95956809532fcf0e2449a6b525" +
            "b16aedf5aa0de657ba637b391aafd255");
        byte[] aad = Array.Empty<byte>();
        byte[] expectedCiphertext = FromHex(
            "42831ec2217774244b7221b784d0d49c" +
            "e3aa212f2c02a4e035c17e2329aca12e" +
            "21d514b25466931c7d8f6a5aac84aa05" +
            "1ba30b396a0aac973d58e091473f5985");
        byte[] expectedTag = FromHex("4d5c2af327cd64a62cf35abd2ba6fab4");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    // ========================================================================
    // NIST GCM Test Vectors - Test Case 4 (with AAD)
    // ========================================================================

    [Test]
    public void AesGcm128_TestCase4_WithAad()
    {
        byte[] key = FromHex("feffe9928665731c6d6a8f9467308308");
        byte[] nonce = FromHex("cafebabefacedbaddecaf888");
        byte[] plaintext = FromHex(
            "d9313225f88406e5a55909c5aff5269a" +
            "86a7a9531534f7da2e4c303d8a318a72" +
            "1c3c0c95956809532fcf0e2449a6b525" +
            "b16aedf5aa0de657ba637b39");
        byte[] aad = FromHex(
            "feedfacedeadbeeffeedfacedeadbeef" +
            "abaddad2");
        byte[] expectedCiphertext = FromHex(
            "42831ec2217774244b7221b784d0d49c" +
            "e3aa212f2c02a4e035c17e2329aca12e" +
            "21d514b25466931c7d8f6a5aac84aa05" +
            "1ba30b396a0aac973d58e091");
        byte[] expectedTag = FromHex("5bc94fbc3221a5db94fae95ae7121a47");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    [TestCase(16, Description = "AES-128-GCM")]
    [TestCase(24, Description = "AES-192-GCM")]
    [TestCase(32, Description = "AES-256-GCM")]
    public void AesGcm_RoundTrip(int keyLength)
    {
        byte[] key = new byte[keyLength];
        byte[] nonce = new byte[12];
        for (int i = 0; i < keyLength; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x10 + i);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, AES-GCM!");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Additional Data");

        using var aesGcm = CreateAesGcm(keyLength, key);

        // Encrypt
        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext, aad);

        // Decrypt
        byte[] decrypted = aesGcm.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    [TestCase(16, Description = "AES-128-GCM")]
    [TestCase(24, Description = "AES-192-GCM")]
    [TestCase(32, Description = "AES-256-GCM")]
    public void AesGcm_RoundTrip_LargeMessage(int keyLength)
    {
        byte[] key = new byte[keyLength];
        byte[] nonce = new byte[12];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // 10KB message
        byte[] plaintext = new byte[10240];
        random.NextBytes(plaintext);

        byte[] aad = new byte[256];
        random.NextBytes(aad);

        using var aesGcm = CreateAesGcm(keyLength, key);

        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aesGcm.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Authentication Failure Tests
    // ========================================================================

    [Test]
    public void AesGcm_TamperedCiphertext_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext);

        // Tamper with ciphertext
        ciphertextWithTag[0] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aesGcm.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AesGcm_TamperedTag_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext);

        // Tamper with tag (last 16 bytes)
        ciphertextWithTag[^1] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aesGcm.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AesGcm_WrongAad_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Correct AAD");
        byte[] wrongAad = System.Text.Encoding.UTF8.GetBytes("Wrong AAD");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext, aad);

        Assert.Throws<CryptographicException>(() => aesGcm.Decrypt(nonce, ciphertextWithTag, wrongAad));
    }

    [Test]
    public void AesGcm_WrongNonce_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] wrongNonce = new byte[12];
        wrongNonce[0] = 0x01;
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aesGcm = AesGcm128.Create(key);

        byte[] ciphertextWithTag = aesGcm.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => aesGcm.Decrypt(wrongNonce, ciphertextWithTag));
    }

    // ========================================================================
    // AES-256-GCM Specific Tests
    // ========================================================================

    [Test]
    public void AesGcm256_RoundTrip()
    {
        byte[] key = FromHex("0000000000000000000000000000000000000000000000000000000000000000");
        byte[] nonce = FromHex("000000000000000000000000");
        byte[] plaintext = FromHex("00000000000000000000000000000000");

        using var aesGcm = AesGcm256.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];
        aesGcm.Encrypt(nonce, plaintext, ciphertext, tag);

        byte[] decrypted = new byte[ciphertext.Length];
        bool success = aesGcm.Decrypt(nonce, ciphertext, tag, decrypted);

        Assert.That(success, Is.True);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static IAeadCipher CreateAesGcm(int keyLength, byte[] key)
    {
        return keyLength switch {
            16 => AesGcm128.Create(key),
            24 => AesGcm192.Create(key),
            32 => AesGcm256.Create(key),
            _ => throw new ArgumentException($"Invalid key length: {keyLength}")
        };
    }

    private static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }
}
