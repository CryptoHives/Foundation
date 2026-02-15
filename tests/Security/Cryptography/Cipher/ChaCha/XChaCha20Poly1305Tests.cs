// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.ChaCha;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using CryptographicException = System.Security.Cryptography.CryptographicException;

/// <summary>
/// Tests for XChaCha20-Poly1305 implementation using draft-irtf-cfrg-xchacha test vectors.
/// </summary>
/// <remarks>
/// Test vectors from draft-irtf-cfrg-xchacha-03.
/// See: https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-xchacha
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class XChaCha20Poly1305Tests
{
    // ========================================================================
    // HChaCha20 Test Vector (draft-irtf-cfrg-xchacha Section 2.2.1)
    // ========================================================================

    [Test]
    public void HChaCha20_DraftIrtfCfrgXchacha_Section221()
    {
        byte[] key = FromHex(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f");
        byte[] nonce = FromHex("000000090000004a0000000031415927");
        byte[] expectedSubkey = FromHex(
            "82413b4227b27bfed30e42508a877d73" +
            "a0f9e4d58a74a853c12ec41326d3ecdc");

        byte[] subkey = new byte[32];
        ChaChaCore.HChaCha20(key, nonce, subkey);

        Assert.That(subkey, Is.EqualTo(expectedSubkey));
    }

    // ========================================================================
    // XChaCha20-Poly1305 AEAD Test Vector (draft-irtf-cfrg-xchacha Appendix A.1)
    // ========================================================================

    [Test]
    public void XChaCha20Poly1305_DraftIrtfCfrgXchacha_AppendixA1_Encryption()
    {
        byte[] key = FromHex(
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f");
        byte[] nonce = FromHex(
            "404142434445464748494a4b4c4d4e4f" +
            "5051525354555657");
        byte[] aad = FromHex("50515253c0c1c2c3c4c5c6c7");
        byte[] plaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a204966204920636f" +
            "756c64206f6666657220796f75206f6e" +
            "6c79206f6e652074697020666f722074" +
            "6865206675747572652c2073756e7363" +
            "7265656e20776f756c6420626520" +
            "69742e");
        byte[] expectedCiphertext = FromHex(
            "bd6d179d3e83d43b9576579493c0e939" +
            "572a1700252bfaccbed2902c21396cbb" +
            "731c7f1b0b4aa6440bf3a82f4eda7e39" +
            "ae64c6708c54c216cb96b72e1213b452" +
            "2f8c9ba40db5d945b11b69b982c1bb9e" +
            "3f3fac2bc369488f76b2383565d3fff9" +
            "21f9664c97637da9768812f615c68b13" +
            "b52e");
        byte[] expectedTag = FromHex("c0875924c1c7987947deafd8780acf49");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aead.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    [Test]
    public void XChaCha20Poly1305_DraftIrtfCfrgXchacha_AppendixA1_Decryption()
    {
        byte[] key = FromHex(
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f");
        byte[] nonce = FromHex(
            "404142434445464748494a4b4c4d4e4f" +
            "5051525354555657");
        byte[] aad = FromHex("50515253c0c1c2c3c4c5c6c7");
        byte[] ciphertext = FromHex(
            "bd6d179d3e83d43b9576579493c0e939" +
            "572a1700252bfaccbed2902c21396cbb" +
            "731c7f1b0b4aa6440bf3a82f4eda7e39" +
            "ae64c6708c54c216cb96b72e1213b452" +
            "2f8c9ba40db5d945b11b69b982c1bb9e" +
            "3f3fac2bc369488f76b2383565d3fff9" +
            "21f9664c97637da9768812f615c68b13" +
            "b52e");
        byte[] tag = FromHex("c0875924c1c7987947deafd8780acf49");
        byte[] expectedPlaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a204966204920636f" +
            "756c64206f6666657220796f75206f6e" +
            "6c79206f6e652074697020666f722074" +
            "6865206675747572652c2073756e7363" +
            "7265656e20776f756c6420626520" +
            "69742e");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] plaintext = new byte[ciphertext.Length];
        bool success = aead.Decrypt(nonce, ciphertext, tag, plaintext, aad);

        Assert.That(success, Is.True);
        Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void XChaCha20Poly1305_RoundTrip_SmallMessage()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 24; i++) nonce[i] = (byte)(0x40 + i);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, XChaCha20-Poly1305!");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void XChaCha20Poly1305_RoundTrip_WithAad()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message with AAD");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Additional authenticated data");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void XChaCha20Poly1305_RoundTrip_LargeMessage()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // 10KB message
        byte[] plaintext = new byte[10240];
        random.NextBytes(plaintext);

        byte[] aad = new byte[256];
        random.NextBytes(aad);

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void XChaCha20Poly1305_RoundTrip_EmptyPlaintext()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 24; i++) nonce[i] = (byte)i;

        byte[] plaintext = Array.Empty<byte>();
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Some AAD");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);

        // Should be just the tag (16 bytes)
        Assert.That(ciphertextWithTag.Length, Is.EqualTo(16));

        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Authentication Failure Tests
    // ========================================================================

    [Test]
    public void XChaCha20Poly1305_TamperedCiphertext_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        // Tamper with ciphertext
        ciphertextWithTag[0] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void XChaCha20Poly1305_TamperedTag_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        // Tamper with tag (last 16 bytes)
        ciphertextWithTag[^1] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void XChaCha20Poly1305_WrongAad_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Correct AAD");
        byte[] wrongAad = System.Text.Encoding.UTF8.GetBytes("Wrong AAD");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag, wrongAad));
    }

    [Test]
    public void XChaCha20Poly1305_WrongNonce_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[24];
        byte[] wrongNonce = new byte[24];
        wrongNonce[0] = 0x01;
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = XChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(wrongNonce, ciphertextWithTag));
    }

    [Test]
    public void XChaCha20Poly1305_WrongKey_Fails()
    {
        byte[] key = new byte[32];
        byte[] wrongKey = new byte[32];
        wrongKey[0] = 0x01;
        byte[] nonce = new byte[24];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = XChaCha20Poly1305.Create(key);
        using var wrongAead = XChaCha20Poly1305.Create(wrongKey);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => wrongAead.Decrypt(nonce, ciphertextWithTag));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void XChaCha20Poly1305_InvalidKeySize_Throws()
    {
        byte[] shortKey = new byte[16];
        Assert.Throws<ArgumentException>(() => XChaCha20Poly1305.Create(shortKey));
    }

    [Test]
    public void XChaCha20Poly1305_InvalidNonceSize_Throws()
    {
        byte[] key = new byte[32];
        byte[] shortNonce = new byte[12];  // Should be 24 bytes
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test");

        using var aead = XChaCha20Poly1305.Create(key);

        Assert.Throws<ArgumentException>(() => aead.Encrypt(shortNonce, plaintext));
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

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
