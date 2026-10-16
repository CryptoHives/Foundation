// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Cipher.Ccm;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Linq;
using CryptographicException = System.Security.Cryptography.CryptographicException;
using IAeadCipher = CryptoHives.Foundation.Security.Cryptography.Cipher.IAeadCipher;

/// <summary>
/// Tests for AES-CCM implementation using RFC 3610 test vectors.
/// </summary>
/// <remarks>
/// Test vectors from RFC 3610 Section 8.
/// See: https://www.rfc-editor.org/rfc/rfc3610
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AesCcmTests
{
    // ========================================================================
    // RFC 3610 Section 8 - Test Vectors
    // ========================================================================

    /// <summary>
    /// RFC 3610 Packet Vector #1: 8 cleartext header octets, 8-byte tag.
    /// </summary>
    [Test]
    public void AesCcm_Rfc3610_PacketVector1()
    {
        byte[] key = FromHex("C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF");
        byte[] nonce = FromHex("00000003020100A0A1A2A3A4A5");
        byte[] aad = FromHex("0001020304050607");
        byte[] plaintext = FromHex("08090A0B0C0D0E0F101112131415161718191A1B1C1D1E");
        byte[] expectedCiphertext = FromHex("588C979A61C663D2F066D0C2C0F989806D5F6B61DAC384");
        byte[] expectedTag = FromHex("17E8D12CFDF926E0");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[8];

        ccm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), "Ciphertext mismatch");
        Assert.That(tag, Is.EqualTo(expectedTag), "Tag mismatch");
    }

    /// <summary>
    /// RFC 3610 Packet Vector #2: 8 cleartext header octets, 8-byte tag.
    /// </summary>
    [Test]
    public void AesCcm_Rfc3610_PacketVector2()
    {
        byte[] key = FromHex("C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF");
        byte[] nonce = FromHex("00000004030201A0A1A2A3A4A5");
        byte[] aad = FromHex("0001020304050607");
        byte[] plaintext = FromHex("08090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F");
        byte[] expectedCiphertext = FromHex("72C91A36E135F8CF291CA894085C87E3CC15C439C9E43A3B");
        byte[] expectedTag = FromHex("A091D56E10400916");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[8];

        ccm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), "Ciphertext mismatch");
        Assert.That(tag, Is.EqualTo(expectedTag), "Tag mismatch");
    }

    /// <summary>
    /// RFC 3610 Packet Vector #3: 8 cleartext header octets, 8-byte tag.
    /// </summary>
    [Test]
    public void AesCcm_Rfc3610_PacketVector3()
    {
        byte[] key = FromHex("C0C1C2C3C4C5C6C7C8C9CACBCCCDCECF");
        byte[] nonce = FromHex("00000005040302A0A1A2A3A4A5");
        byte[] aad = FromHex("0001020304050607");
        byte[] plaintext = FromHex("08090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F20");
        byte[] expectedCiphertext = FromHex("51B1E5F44A197D1DA46B0F8E2D282AE871E838BB64DA859657");
        byte[] expectedTag = FromHex("4ADAA76FBD9FB0C5");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[8];

        ccm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), "Ciphertext mismatch");
        Assert.That(tag, Is.EqualTo(expectedTag), "Tag mismatch");
    }

    /// <summary>
    /// Every nonce length CCM allows, on every tier, against BouncyCastle. A nonce shorter than
    /// 11 bytes leaves a length field wider than 32 bits.
    /// </summary>
    [Test]
    public void AesCcm_EveryNonceLength_MatchesBouncyCastle(
        [Values("AES-128-CCM", "AES-192-CCM", "AES-256-CCM")] string family,
        [Values(7, 8, 9, 10, 11, 12, 13)] int nonceLength)
    {
        var rng = new Random(nonceLength);

        foreach (CipherAlgorithmRegistry.CipherImplementation impl in CipherAlgorithmRegistry.ByFamily(family).Where(impl => impl.Source is CipherAlgorithmRegistry.Source.Simd or CipherAlgorithmRegistry.Source.Managed))
        {
            byte[] key = RandomBytes(rng, impl.KeySizeBits / 8);
            byte[] nonce = RandomBytes(rng, nonceLength);
            byte[] aad = RandomBytes(rng, 20);
            byte[] plaintext = RandomBytes(rng, 45);

            using var ccm = (IAeadCipher)impl.Create(key);
            byte[] ciphertext = new byte[plaintext.Length];
            byte[] tag = new byte[16];
            ccm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

            var reference = new CcmBlockCipher(new AesEngine());
            reference.Init(true, new AeadParameters(new KeyParameter(key), 128, nonce, aad));
            byte[] expected = new byte[reference.GetOutputSize(plaintext.Length)];
            int written = reference.ProcessBytes(plaintext, 0, plaintext.Length, expected, 0);
            reference.DoFinal(expected, written);

            Assert.That(ciphertext, Is.EqualTo(expected.AsSpan(0, plaintext.Length).ToArray()), $"{impl.Name} ciphertext");
            Assert.That(tag, Is.EqualTo(expected.AsSpan(plaintext.Length).ToArray()), $"{impl.Name} tag");

            byte[] decrypted = new byte[plaintext.Length];
            Assert.That(ccm.Decrypt(nonce, ciphertext, tag, decrypted, aad), Is.True, impl.Name);
            Assert.That(decrypted, Is.EqualTo(plaintext), impl.Name);
        }
    }

    private static byte[] RandomBytes(Random rng, int length)
    {
        byte[] bytes = new byte[length];
        rng.NextBytes(bytes);
        return bytes;
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void AesCcm128_RoundTrip_SmallMessage()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)(0x20 + i);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, AES-CCM!");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext);
        byte[] decrypted = ccm.Decrypt(nonce, ciphertextWithTag);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AesCcm128_RoundTrip_WithAad()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message with AAD");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Additional authenticated data");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = ccm.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AesCcm256_RoundTrip_LargeMessage()
    {
        byte[] key = new byte[32];
        byte[] nonce = new byte[12];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // 4KB message
        byte[] plaintext = new byte[4096];
        random.NextBytes(plaintext);

        byte[] aad = new byte[128];
        random.NextBytes(aad);

        using var ccm = AesCcm256.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = ccm.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AesCcm128_RoundTrip_EmptyPlaintext()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;
        for (int i = 0; i < 12; i++) nonce[i] = (byte)i;

        byte[] plaintext = Array.Empty<byte>();
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Some AAD");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext, aad);

        // Should be just the tag (16 bytes)
        Assert.That(ciphertextWithTag.Length, Is.EqualTo(16));

        byte[] decrypted = ccm.Decrypt(nonce, ciphertextWithTag, aad);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Authentication Failure Tests
    // ========================================================================

    [Test]
    public void AesCcm_TamperedCiphertext_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext);

        // Tamper with ciphertext
        ciphertextWithTag[0] ^= 0x01;

        Assert.Throws<CryptographicException>(() => ccm.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AesCcm_TamperedTag_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext);

        // Tamper with tag
        ciphertextWithTag[^1] ^= 0x01;

        Assert.Throws<CryptographicException>(() => ccm.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AesCcm_WrongAad_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Correct AAD");
        byte[] wrongAad = System.Text.Encoding.UTF8.GetBytes("Wrong AAD");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertextWithTag = ccm.Encrypt(nonce, plaintext, aad);

        Assert.Throws<CryptographicException>(() => ccm.Decrypt(nonce, ciphertextWithTag, wrongAad));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void AesCcm_InvalidKeySize_Throws()
    {
        byte[] shortKey = new byte[8];
        Assert.Throws<ArgumentException>(() => AesCcm128.Create(shortKey));
    }

    [Test]
    public void AesCcm_InvalidNonceSize_Throws()
    {
        byte[] key = new byte[16];
        byte[] shortNonce = new byte[6]; // Too short
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test");

        using var ccm = AesCcm128.Create(key);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];

        Assert.Throws<ArgumentException>(() => ccm.Encrypt(shortNonce, plaintext, ciphertext, tag));
    }

    [Test]
    public void AesCcm_DisposedInstance_Throws()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test");

        var ccm = AesCcm128.Create(key);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];
        ccm.Encrypt(nonce, plaintext, ciphertext, tag);

        ccm.Dispose();

        byte[] decrypted = new byte[plaintext.Length];
        Assert.Throws<ObjectDisposedException>(() => ccm.Encrypt(nonce, plaintext, ciphertext, tag));
        Assert.Throws<ObjectDisposedException>(() => ccm.Decrypt(nonce, ciphertext, tag, decrypted));
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
