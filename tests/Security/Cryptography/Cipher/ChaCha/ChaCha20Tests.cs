// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.ChaCha;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for ChaCha20 implementation using RFC 8439 test vectors.
/// </summary>
/// <remarks>
/// Test vectors from RFC 8439 Section 2.4.2 (ChaCha20 Encryption).
/// See: https://datatracker.ietf.org/doc/html/rfc8439
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ChaCha20Tests
{
    // ========================================================================
    // RFC 8439 Section 2.3.2 - ChaCha20 Block Function Test Vector
    // ========================================================================

    /// <summary>
    /// RFC 8439 Section 2.3.2: ChaCha20 block function test.
    /// </summary>
    [Test]
    public void ChaCha20_Rfc8439_Section232_BlockFunction()
    {
        // Key: 00:01:02:03:04:05:06:07:08:09:0a:0b:0c:0d:0e:0f:10:11:12:13:14:15:16:17:18:19:1a:1b:1c:1d:1e:1f
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        // Nonce: 00:00:00:09:00:00:00:4a:00:00:00:00
        byte[] nonce = FromHex("000000090000004a00000000");
        // Counter: 1
        uint counter = 1;

        // Expected keystream block
        byte[] expected = FromHex(
            "10f1e7e4d13b5915500fdd1fa32071c4" +
            "c7d1f4c733c068030422aa9ac3d46c4e" +
            "d2826446079faa0914c2d705d98b02a2" +
            "b5129cd1de164eb9cbd083e8a2503c4e");

        byte[] output = new byte[64];
        ChaChaCore.Block(key, nonce, counter, output);

        Assert.That(output, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 8439 Section 2.4.2 - ChaCha20 Encryption Test Vector
    // ========================================================================

    /// <summary>
    /// RFC 8439 Section 2.4.2: ChaCha20 encryption test.
    /// </summary>
    [Test]
    public void ChaCha20_Rfc8439_Section242_Encryption()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] nonce = FromHex("000000000000004a00000000");

        // Plaintext: "Ladies and Gentlemen of the class of '99: If I could offer you only one tip for the future, sunscreen would be it."
        byte[] plaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a20496620492063" +
            "6f756c64206f6666657220796f75206f" +
            "6e6c79206f6e652074697020666f7220" +
            "746865206675747572652c2073756e73" +
            "637265656e20776f756c642062652069" +
            "742e");

        byte[] expected = FromHex(
            "6e2e359a2568f98041ba0728dd0d6981" +
            "e97e7aec1d4360c20a27afccfd9fae0b" +
            "f91b65c5524733ab8f593dabcd62b357" +
            "1639d624e65152ab8f530c359f0861d8" +
            "07ca0dbf500d6a6156a38e088a22b65e" +
            "52bc514d16ccf806818ce91ab7793736" +
            "5af90bbf74a35be6b40b8eedf2785e42" +
            "874d");

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;
        chacha.InitialCounter = 1;

        byte[] ciphertext = chacha.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 8439 Section 2.4.2: ChaCha20 decryption test (reverse of encryption).
    /// </summary>
    [Test]
    public void ChaCha20_Rfc8439_Section242_Decryption()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] nonce = FromHex("000000000000004a00000000");

        byte[] ciphertext = FromHex(
            "6e2e359a2568f98041ba0728dd0d6981" +
            "e97e7aec1d4360c20a27afccfd9fae0b" +
            "f91b65c5524733ab8f593dabcd62b357" +
            "1639d624e65152ab8f530c359f0861d8" +
            "07ca0dbf500d6a6156a38e088a22b65e" +
            "52bc514d16ccf806818ce91ab7793736" +
            "5af90bbf74a35be6b40b8eedf2785e42" +
            "874d");

        byte[] expectedPlaintext = FromHex(
            "4c616469657320616e642047656e746c" +
            "656d656e206f662074686520636c6173" +
            "73206f66202739393a20496620492063" +
            "6f756c64206f6666657220796f75206f" +
            "6e6c79206f6e652074697020666f7220" +
            "746865206675747572652c2073756e73" +
            "637265656e20776f756c642062652069" +
            "742e");

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;
        chacha.InitialCounter = 1;

        byte[] plaintext = chacha.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
    }

    // ========================================================================
    // RFC 8439 Appendix A.1 - Quarter Round Test
    // ========================================================================

    /// <summary>
    /// Tests the quarter round operation indirectly through block function.
    /// </summary>
    [Test]
    public void ChaCha20_QuarterRound_ThroughBlock()
    {
        // Use all-zero key and nonce with counter 0 to test basic functionality
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        byte[] output = new byte[64];

        // This should produce deterministic output based on the constants
        ChaChaCore.Block(key, nonce, 0, output);

        // The output should not be all zeros (proves rounds are working)
        bool allZero = true;
        for (int i = 0; i < output.Length; i++)
        {
            if (output[i] != 0)
            {
                allZero = false;
                break;
            }
        }
        Assert.That(allZero, Is.False, "Quarter rounds should transform the state");
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void ChaCha20_RoundTrip_SmallMessage()
    {
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, ChaCha20!");
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];

        // Use deterministic key/nonce for reproducibility
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x20 + i);

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;

        byte[] ciphertext = chacha.Encrypt(plaintext);

        // Ciphertext should be different from plaintext
        Assert.That(ciphertext, Is.Not.EqualTo(plaintext));

        // Reset for decryption
        chacha.IV = nonce;
        byte[] decrypted = chacha.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20_RoundTrip_ExactlyOneBlock()
    {
        // Exactly 64 bytes (one ChaCha20 block)
        byte[] plaintext = new byte[64];
        for (int i = 0; i < 64; i++) plaintext[i] = (byte)i;

        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)(0x40 + i);
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x50 + i);

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;

        byte[] ciphertext = chacha.Encrypt(plaintext);
        chacha.IV = nonce;
        byte[] decrypted = chacha.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20_RoundTrip_MultipleBlocks()
    {
        // 200 bytes (spans multiple blocks)
        byte[] plaintext = new byte[200];
        for (int i = 0; i < plaintext.Length; i++) plaintext[i] = (byte)(i % 256);

        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)(0x60 + i);
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x70 + i);

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;

        byte[] ciphertext = chacha.Encrypt(plaintext);
        chacha.IV = nonce;
        byte[] decrypted = chacha.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void ChaCha20_RoundTrip_LargeMessage()
    {
        // 10KB message
        byte[] plaintext = new byte[10240];
        var random = new Random(42);
        random.NextBytes(plaintext);

        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        random.NextBytes(key);
        random.NextBytes(nonce);

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;

        byte[] ciphertext = chacha.Encrypt(plaintext);
        chacha.IV = nonce;
        byte[] decrypted = chacha.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Counter Tests
    // ========================================================================

    [Test]
    public void ChaCha20_InitialCounter_AffectsOutput()
    {
        byte[] plaintext = new byte[64];
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)i;

        using var chacha0 = ChaCha20.Create();
        chacha0.Key = key;
        chacha0.IV = nonce;
        chacha0.InitialCounter = 0;
        byte[] ciphertext0 = chacha0.Encrypt(plaintext);

        using var chacha1 = ChaCha20.Create();
        chacha1.Key = key;
        chacha1.IV = nonce;
        chacha1.InitialCounter = 1;
        byte[] ciphertext1 = chacha1.Encrypt(plaintext);

        // Different initial counters should produce different ciphertext
        Assert.That(ciphertext0, Is.Not.EqualTo(ciphertext1));
    }

    // ========================================================================
    // Transform Reuse Tests
    // ========================================================================

    [Test]
    public void ChaCha20_Transform_Reset()
    {
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test message");
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)i;

        using var chacha = ChaCha20.Create();
        chacha.Key = key;
        chacha.IV = nonce;

        // First encryption
        byte[] ciphertext1 = chacha.Encrypt(plaintext);

        // Reset and encrypt again
        chacha.IV = nonce;
        byte[] ciphertext2 = chacha.Encrypt(plaintext);

        // Should produce identical ciphertext
        Assert.That(ciphertext1, Is.EqualTo(ciphertext2));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void ChaCha20_InvalidKeySize_Throws()
    {
        using var chacha = ChaCha20.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => {
            chacha.Key = new byte[16]; // Wrong size
        });
    }

    [Test]
    public void ChaCha20_InvalidNonceSize_Throws()
    {
        using var chacha = ChaCha20.Create();
        chacha.Key = new byte[32];
        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => {
            chacha.IV = new byte[8]; // Wrong size (should be 12)
        });
    }

    [Test]
    public void ChaCha20_GenerateKeyAndNonce()
    {
        using var chacha = ChaCha20.Create();
        chacha.GenerateKey();
        chacha.GenerateIV();

        Assert.That(chacha.Key, Is.Not.Null);
        Assert.That(chacha.Key!.Length, Is.EqualTo(32));
        Assert.That(chacha.IV, Is.Not.Null);
        Assert.That(chacha.IV!.Length, Is.EqualTo(12));
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
