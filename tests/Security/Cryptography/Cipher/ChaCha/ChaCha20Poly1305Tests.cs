// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.ChaCha;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using CryptographicException = System.Security.Cryptography.CryptographicException;

// Alias to avoid conflict with System.Security.Cryptography.ChaCha20Poly1305
using ChaCha20Poly1305 = CryptoHives.Foundation.Security.Cryptography.Cipher.ChaCha20Poly1305;

/// <summary>
/// Tests for ChaCha20-Poly1305 implementation using RFC 8439 test vectors.
/// </summary>
/// <remarks>
/// Test vectors from RFC 8439 Section 2.8.2.
/// See: https://datatracker.ietf.org/doc/html/rfc8439
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ChaCha20Poly1305Tests
{
    // ========================================================================
    // RFC 8439 Section 2.8.2 - AEAD Test Vector
    // ========================================================================

    [Test]
    public void ChaCha20Poly1305_Rfc8439_Section282_Encryption()
    {
        byte[] key = FromHex(
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f");
        byte[] nonce = FromHex("070000004041424344454647");
        byte[] aad = FromHex("50515253c0c1c2c3c4c5c6c7");
        byte[] plaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a20496620492063" +
            "6f756c64206f6666657220796f75206f" +
            "6e6c79206f6e652074697020666f7220" +
            "746865206675747572652c2073756e73" +
            "637265656e20776f756c642062652069" +
            "742e");
        byte[] expectedCiphertext = FromHex(
            "d31a8d34648e60db7b86afbc53ef7ec2" +
            "a4aded51296e08fea9e2b5a736ee62d6" +
            "3dbea45e8ca9671282fafb69da92728b" +
            "1a71de0a9e060b2905d6a5b67ecd3b36" +
            "92ddbd7f2d778b8c9803aee328091b58" +
            "fab324e4fad675945585808b4831d7bc" +
            "3ff4def08e4b7a9de576d26586cec64b" +
            "6116");
        byte[] expectedTag = FromHex("1ae10b594f09e26a7e902ecbd0600691");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        aead.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    [Test]
    public void ChaCha20Poly1305_Rfc8439_Section282_Decryption()
    {
        byte[] key = FromHex(
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f");
        byte[] nonce = FromHex("070000004041424344454647");
        byte[] aad = FromHex("50515253c0c1c2c3c4c5c6c7");
        byte[] ciphertext = FromHex(
            "d31a8d34648e60db7b86afbc53ef7ec2" +
            "a4aded51296e08fea9e2b5a736ee62d6" +
            "3dbea45e8ca9671282fafb69da92728b" +
            "1a71de0a9e060b2905d6a5b67ecd3b36" +
            "92ddbd7f2d778b8c9803aee328091b58" +
            "fab324e4fad675945585808b4831d7bc" +
            "3ff4def08e4b7a9de576d26586cec64b" +
            "6116");
        byte[] tag = FromHex("1ae10b594f09e26a7e902ecbd0600691");
        byte[] expectedPlaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a20496620492063" +
            "6f756c64206f6666657220796f75206f" +
            "6e6c79206f6e652074697020666f7220" +
            "746865206675747572652c2073756e73" +
            "637265656e20776f756c642062652069" +
            "742e");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] plaintext = new byte[ciphertext.Length];
        bool success = aead.Decrypt(nonce, ciphertext, tag, plaintext, aad);

        Assert.That(success, Is.True);
        Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
    }

    // ========================================================================
    // RFC 8439 Appendix A.5 - Poly1305 Test Vector
    // ========================================================================

    [Test]
    public void Poly1305_Rfc8439_AppendixA5()
    {
        // This tests the underlying Poly1305 implementation
        byte[] key = FromHex(
            "7bac2b252db447af09b67a55a4e95584" +
            "0ae1d6731075d9eb2a9375783ed553ff");
        byte[] message = System.Text.Encoding.ASCII.GetBytes(
            "Cryptographic Forum Research Group");
        byte[] expectedTag = FromHex("a8061dc1305136c6c22b8baf0c0127a9");

        byte[] tag = new byte[16];
        Poly1305.ComputeTag(key, message, tag);

        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void ChaCha20Poly1305_RoundTrip_SmallMessage()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x20 + i);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, ChaCha20-Poly1305!");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20Poly1305_RoundTrip_WithAad()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message with AAD");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Additional authenticated data");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20Poly1305_RoundTrip_LargeMessage()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // 10KB message
        byte[] plaintext = new byte[10240];
        random.NextBytes(plaintext);

        byte[] aad = new byte[256];
        random.NextBytes(aad);

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20Poly1305_RoundTrip_EmptyPlaintext()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)i;

        byte[] plaintext = Array.Empty<byte>();
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Some AAD");

        using var aead = ChaCha20Poly1305.Create(key);

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
    public void ChaCha20Poly1305_TamperedCiphertext_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        // Tamper with ciphertext
        ciphertextWithTag[0] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void ChaCha20Poly1305_TamperedTag_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        // Tamper with tag (last 16 bytes)
        ciphertextWithTag[^1] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void ChaCha20Poly1305_WrongAad_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Correct AAD");
        byte[] wrongAad = System.Text.Encoding.UTF8.GetBytes("Wrong AAD");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag, wrongAad));
    }

    [Test]
    public void ChaCha20Poly1305_WrongNonce_Fails()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        byte[] wrongNonce = new byte[12];
        wrongNonce[0] = 0x01;
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = ChaCha20Poly1305.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(wrongNonce, ciphertextWithTag));
    }

    [Test]
    public void ChaCha20Poly1305_WrongKey_Fails()
    {
        byte[] key = new byte[32];
        byte[] wrongKey = new byte[32];
        wrongKey[0] = 0x01;
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = ChaCha20Poly1305.Create(key);
        using var wrongAead = ChaCha20Poly1305.Create(wrongKey);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => wrongAead.Decrypt(nonce, ciphertextWithTag));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void ChaCha20Poly1305_InvalidKeySize_Throws()
    {
        byte[] shortKey = new byte[16];
        Assert.Throws<ArgumentException>(() => ChaCha20Poly1305.Create(shortKey));
    }

    [Test]
    public void ChaCha20Poly1305_InvalidNonceSize_Throws()
    {
        byte[] key = new byte[32];
        byte[] shortNonce = new byte[8];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test");

        using var aead = ChaCha20Poly1305.Create(key);

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
