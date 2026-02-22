// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Aes;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for AES implementations using NIST FIPS 197 test vectors.
/// </summary>
/// <remarks>
/// Test vectors are from FIPS 197 Appendix B and C.
/// See: https://csrc.nist.gov/publications/detail/fips/197/final
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AesTests
{
    // ========================================================================
    // FIPS 197 Appendix B - AES-128 Example
    // ========================================================================

    /// <summary>
    /// FIPS 197 Appendix B: AES-128 single block encryption.
    /// </summary>
    [Test]
    public void Aes128_Fips197AppendixB_Encrypt()
    {
        // Key: 2b7e1516 28aed2a6 abf71588 09cf4f3c
        byte[] key = FromHex("2b7e151628aed2a6abf7158809cf4f3c");
        // Plaintext: 3243f6a8 885a308d 313198a2 e0370734
        byte[] plaintext = FromHex("3243f6a8885a308d313198a2e0370734");
        // Ciphertext: 3925841d 02dc09fb dc118597 196a0b32
        byte[] expected = FromHex("3925841d02dc09fbdc118597196a0b32");

        using var aes = Aes128.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] ciphertext = aes.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// FIPS 197 Appendix B: AES-128 single block decryption.
    /// </summary>
    [Test]
    public void Aes128_Fips197AppendixB_Decrypt()
    {
        byte[] key = FromHex("2b7e151628aed2a6abf7158809cf4f3c");
        byte[] ciphertext = FromHex("3925841d02dc09fbdc118597196a0b32");
        byte[] expected = FromHex("3243f6a8885a308d313198a2e0370734");

        using var aes = Aes128.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] plaintext = aes.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // FIPS 197 Appendix C.1 - AES-128 Example Vector
    // ========================================================================

    /// <summary>
    /// FIPS 197 Appendix C.1: AES-128 test vector.
    /// </summary>
    [Test]
    public void Aes128_Fips197AppendixC1_Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("69c4e0d86a7b0430d8cdb78070b4c55a");

        using var aes = Aes128.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] ciphertext = aes.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    [Test]
    public void Aes128_Fips197AppendixC1_Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] ciphertext = FromHex("69c4e0d86a7b0430d8cdb78070b4c55a");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aes = Aes128.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] plaintext = aes.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // FIPS 197 Appendix C.2 - AES-192 Example Vector
    // ========================================================================

    /// <summary>
    /// FIPS 197 Appendix C.2: AES-192 test vector.
    /// </summary>
    [Test]
    public void Aes192_Fips197AppendixC2_Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f1011121314151617");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("dda97ca4864cdfe06eaf70a0ec0d7191");

        using var aes = Aes192.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] ciphertext = aes.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    [Test]
    public void Aes192_Fips197AppendixC2_Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f1011121314151617");
        byte[] ciphertext = FromHex("dda97ca4864cdfe06eaf70a0ec0d7191");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aes = Aes192.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] plaintext = aes.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // FIPS 197 Appendix C.3 - AES-256 Example Vector
    // ========================================================================

    /// <summary>
    /// FIPS 197 Appendix C.3: AES-256 test vector.
    /// </summary>
    [Test]
    public void Aes256_Fips197AppendixC3_Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("8ea2b7ca516745bfeafc49904b496089");

        using var aes = Aes256.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] ciphertext = aes.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    [Test]
    public void Aes256_Fips197AppendixC3_Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] ciphertext = FromHex("8ea2b7ca516745bfeafc49904b496089");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aes = Aes256.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] plaintext = aes.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    [TestCase(16, Description = "AES-128")]
    [TestCase(24, Description = "AES-192")]
    [TestCase(32, Description = "AES-256")]
    public void Aes_RoundTrip_Ecb(int keyLength)
    {
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] key = new byte[keyLength];
        for (int i = 0; i < keyLength; i++) key[i] = (byte)i;

        using var aes = CreateAes(keyLength);
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = new byte[16];

        byte[] ciphertext = aes.Encrypt(plaintext);
        byte[] decrypted = aes.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    [TestCase(16, Description = "AES-128")]
    [TestCase(24, Description = "AES-192")]
    [TestCase(32, Description = "AES-256")]
    public void Aes_RoundTrip_Cbc(int keyLength)
    {
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff00112233445566778899aabbccddeeff");
        byte[] key = new byte[keyLength];
        byte[] iv = new byte[16];
        for (int i = 0; i < keyLength; i++) key[i] = (byte)i;
        for (int i = 0; i < 16; i++) iv[i] = (byte)(0x10 + i);

        using var aes = CreateAes(keyLength);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = iv;

        byte[] ciphertext = aes.Encrypt(plaintext);
        byte[] decrypted = aes.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    [TestCase(16, Description = "AES-128")]
    [TestCase(24, Description = "AES-192")]
    [TestCase(32, Description = "AES-256")]
    public void Aes_RoundTrip_Ctr(int keyLength)
    {
        // CTR mode can handle any length
        byte[] plaintext = FromHex("00112233445566778899aabbccdd");
        byte[] key = new byte[keyLength];
        byte[] iv = new byte[16];
        for (int i = 0; i < keyLength; i++) key[i] = (byte)i;
        for (int i = 0; i < 16; i++) iv[i] = (byte)(0x20 + i);

        using var aes = CreateAes(keyLength);
        aes.Mode = CipherMode.CTR;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = iv;

        byte[] ciphertext = aes.Encrypt(plaintext);

        // Reset for decryption
        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    [TestCase(16, Description = "AES-128")]
    [TestCase(24, Description = "AES-192")]
    [TestCase(32, Description = "AES-256")]
    public void Aes_RoundTrip_CbcWithPadding(int keyLength)
    {
        // Test with plaintext that requires padding
        byte[] plaintext = FromHex("00112233445566778899aabbccdd"); // 14 bytes - needs 2 bytes padding
        byte[] key = new byte[keyLength];
        byte[] iv = new byte[16];
        for (int i = 0; i < keyLength; i++) key[i] = (byte)i;
        for (int i = 0; i < 16; i++) iv[i] = (byte)(0x30 + i);

        using var aes = CreateAes(keyLength);
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = key;
        aes.IV = iv;

        byte[] ciphertext = aes.Encrypt(plaintext);

        // Reset for decryption
        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Multi-block Tests
    // ========================================================================

    [Test]
    public void Aes256_MultiBlock_Cbc()
    {
        // Multiple blocks to test CBC chaining
        byte[] plaintext = new byte[64]; // 4 blocks
        for (int i = 0; i < plaintext.Length; i++) plaintext[i] = (byte)i;

        byte[] key = new byte[32];
        byte[] iv = new byte[16];
        for (int i = 0; i < 32; i++) key[i] = (byte)(0x40 + i);
        for (int i = 0; i < 16; i++) iv[i] = (byte)(0x60 + i);

        using var aes = Aes256.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.None;
        aes.Key = key;
        aes.IV = iv;

        byte[] ciphertext = aes.Encrypt(plaintext);

        // Verify ciphertext is different from plaintext
        Assert.That(ciphertext, Is.Not.EqualTo(plaintext));

        // Verify each block is different (CBC should produce different blocks)
        byte[] block1 = new byte[16];
        byte[] block2 = new byte[16];
        Buffer.BlockCopy(ciphertext, 0, block1, 0, 16);
        Buffer.BlockCopy(ciphertext, 16, block2, 0, 16);
        Assert.That(block1, Is.Not.EqualTo(block2));

        // Round-trip
        aes.IV = iv;
        byte[] decrypted = aes.Decrypt(ciphertext);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Key Validation Tests
    // ========================================================================

    [Test]
    public void Aes128_InvalidKeySize_Throws()
    {
        using var aes = Aes128.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => {
            aes.Key = new byte[24]; // Wrong size for AES-128
        });
    }

    [Test]
    public void Aes256_InvalidKeySize_Throws()
    {
        using var aes = Aes256.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => {
            aes.Key = new byte[16]; // Wrong size for AES-256
        });
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static SymmetricCipher CreateAes(int keyLength)
    {
        return keyLength switch {
            16 => Aes128.Create(),
            24 => Aes192.Create(),
            32 => Aes256.Create(),
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
