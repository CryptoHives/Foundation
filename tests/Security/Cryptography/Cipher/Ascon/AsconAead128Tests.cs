// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Ascon;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Linq;
using static Cryptography.Tests.Cipher.CipherAlgorithmRegistry;
using CryptographicException = System.Security.Cryptography.CryptographicException;

/// <summary>
/// Tests for the Ascon-AEAD128 implementation using NIST LWC KAT vectors.
/// </summary>
/// <remarks>
/// Test vectors from the official Ascon LWC_AEAD_KAT_128_128.txt
/// (NIST SP 800-232 / <see href="https://github.com/ascon/ascon-c"/>).
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(CipherImplementationArgs))]
[Parallelizable(ParallelScope.All)]
public class AsconAead128Tests
{
    /// <summary>
    /// Gets the collection of cipher implementations that support the Ascon-AEAD128 algorithm family.
    /// </summary>
    public static readonly CipherImplementation[] AsconAead128All = CipherAlgorithmRegistry.ByFamily("Ascon-AEAD128").ToArray();

    /// <summary>
    /// Cipher implementations to test.
    /// </summary>
    public static readonly object[] CipherImplementationArgs = AsconAead128All.Select(impl => new object[] { impl.Name }).ToArray();

    private readonly CipherImplementation _implementation;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconAead128Tests"/> class.
    /// </summary>
    public AsconAead128Tests(string name)
    {
        _implementation = AsconAead128All!.Where(impl => impl.Name == name).FirstOrDefault() ?? throw new ArgumentNullException(name);
    }

    // ========================================================================
    // NIST LWC KAT Vectors (LWC_AEAD_KAT_128_128.txt)
    // ========================================================================

    /// <summary>
    /// KAT Count 1: Empty plaintext, empty AD — tag-only.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count1_EmptyPtEmptyAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = Array.Empty<byte>();
        byte[] ad = Array.Empty<byte>();
        // CT = tag only (16 bytes)
        byte[] expectedTag = FromHex("4F9C278211BEC9316BF68F46EE8B2EC6");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = Array.Empty<byte>();
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 2: Empty plaintext, 1 byte AD.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count2_EmptyPt_1ByteAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = Array.Empty<byte>();
        byte[] ad = FromHex("30");
        byte[] expectedTag = FromHex("CCCB674FE18A09A285D6AB11B35675C0");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = Array.Empty<byte>();
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 17: Empty plaintext, 16 bytes AD (exactly one rate block).
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count17_EmptyPt_16ByteAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = Array.Empty<byte>();
        byte[] ad = FromHex("303132333435363738393A3B3C3D3E3F");
        byte[] expectedTag = FromHex("E4230CDB8330EE9DC0CFD7C7B346E6DC");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = Array.Empty<byte>();
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 33: Empty plaintext, 32 bytes AD (two full rate blocks).
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count33_EmptyPt_32ByteAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = Array.Empty<byte>();
        byte[] ad = FromHex("303132333435363738393A3B3C3D3E3F404142434445464748494A4B4C4D4E4F");
        byte[] expectedTag = FromHex("EFC3E78B02AD9A80A6F0548C5B0BB5BA");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = Array.Empty<byte>();
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 34: 1 byte plaintext, empty AD.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count34_1BytePt_EmptyAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = FromHex("20");
        byte[] ad = Array.Empty<byte>();
        // CT includes 1 byte ciphertext + 16 byte tag
        byte[] expectedCt = FromHex("E8");
        byte[] expectedTag = FromHex("DD576ABA1CD3E6FC704DE02AEDB79588");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = new byte[1];
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(ciphertext, Is.EqualTo(expectedCt));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 35: 1 byte plaintext, 1 byte AD.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count35_1BytePt_1ByteAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = FromHex("20");
        byte[] ad = FromHex("30");
        byte[] expectedCt = FromHex("96");
        byte[] expectedTag = FromHex("2B8016836C75A7D86866588CA245D886");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = new byte[1];
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(ciphertext, Is.EqualTo(expectedCt));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT Count 67: 2 byte plaintext, empty AD.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count67_2BytePt_EmptyAd()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] plaintext = FromHex("2021");
        byte[] ad = Array.Empty<byte>();
        byte[] expectedCt = FromHex("E8C3");
        byte[] expectedTag = FromHex("5A12D2A396E76224F6EE5418F6465197");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertext = new byte[2];
        byte[] tag = new byte[16];
        aead.Encrypt(nonce, plaintext, ciphertext, tag, ad);

        Assert.That(ciphertext, Is.EqualTo(expectedCt));
        Assert.That(tag, Is.EqualTo(expectedTag));
    }

    /// <summary>
    /// KAT decryption: verifies Count 34 decrypts correctly.
    /// </summary>
    [Test]
    public void AsconAead128_KAT_Count34_Decryption()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] nonce = FromHex("101112131415161718191A1B1C1D1E1F");
        byte[] ciphertext = FromHex("E8");
        byte[] tag = FromHex("DD576ABA1CD3E6FC704DE02AEDB79588");
        byte[] expectedPlaintext = FromHex("20");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] plaintext = new byte[1];
        bool success = aead.Decrypt(nonce, ciphertext, tag, plaintext);

        Assert.That(success, Is.True);
        Assert.That(plaintext, Is.EqualTo(expectedPlaintext));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void AsconAead128_RoundTrip_SmallMessage()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;
        for (int i = 0; i < 16; i++) nonce[i] = (byte)(0x10 + i);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Hello, Ascon-AEAD128!");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AsconAead128_RoundTrip_WithAad()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message with AAD");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Additional authenticated data");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AsconAead128_RoundTrip_LargeMessage()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        var random = new Random(42);
        random.NextBytes(key);
        random.NextBytes(nonce);

        byte[] plaintext = new byte[10240];
        random.NextBytes(plaintext);

        byte[] aad = new byte[256];
        random.NextBytes(aad);

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AsconAead128_RoundTrip_EmptyPlaintext()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        for (int i = 0; i < 16; i++) key[i] = (byte)i;
        for (int i = 0; i < 16; i++) nonce[i] = (byte)i;

        byte[] plaintext = Array.Empty<byte>();
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Some AAD");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);

        // Should be just the tag (16 bytes)
        Assert.That(ciphertextWithTag.Length, Is.EqualTo(16));

        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AsconAead128_RoundTrip_ExactlyOneRateBlock()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        var random = new Random(99);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // Exactly 16 bytes = 1 rate block
        byte[] plaintext = new byte[16];
        random.NextBytes(plaintext);

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void AsconAead128_RoundTrip_MultipleRateBlocks()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        var random = new Random(77);
        random.NextBytes(key);
        random.NextBytes(nonce);

        // 48 bytes = 3 rate blocks
        byte[] plaintext = new byte[48];
        random.NextBytes(plaintext);

        byte[] aad = new byte[48];
        random.NextBytes(aad);

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);
        byte[] decrypted = aead.Decrypt(nonce, ciphertextWithTag, aad);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Authentication Failure Tests
    // ========================================================================

    [Test]
    public void AsconAead128_TamperedCiphertext_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        ciphertextWithTag[0] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AsconAead128_TamperedTag_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        ciphertextWithTag[^1] ^= 0x01;

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag));
    }

    [Test]
    public void AsconAead128_WrongAad_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");
        byte[] aad = System.Text.Encoding.UTF8.GetBytes("Correct AAD");
        byte[] wrongAad = System.Text.Encoding.UTF8.GetBytes("Wrong AAD");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext, aad);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(nonce, ciphertextWithTag, wrongAad));
    }

    [Test]
    public void AsconAead128_WrongNonce_Fails()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[16];
        byte[] wrongNonce = new byte[16];
        wrongNonce[0] = 0x01;
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = (IAeadCipher)_implementation.Create(key);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => aead.Decrypt(wrongNonce, ciphertextWithTag));
    }

    [Test]
    public void AsconAead128_WrongKey_Fails()
    {
        byte[] key = new byte[16];
        byte[] wrongKey = new byte[16];
        wrongKey[0] = 0x01;
        byte[] nonce = new byte[16];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Secret message");

        using var aead = (IAeadCipher)_implementation.Create(key);
        using var wrongAead = (IAeadCipher)_implementation.Create(wrongKey);

        byte[] ciphertextWithTag = aead.Encrypt(nonce, plaintext);

        Assert.Throws<CryptographicException>(() => wrongAead.Decrypt(nonce, ciphertextWithTag));
    }

    // ========================================================================
    // Validation Tests
    // ========================================================================

    [Test]
    public void AsconAead128_InvalidKeySize_Throws()
    {
        if (_implementation.Source != Source.Managed)
            Assert.Ignore("Key validation is implementation-specific.");

        byte[] shortKey = new byte[8];
        Assert.That(() => _implementation.Create(shortKey),
            Throws.InstanceOf<ArgumentException>().Or.InstanceOf<CryptographicException>());
    }

    [Test]
    public void AsconAead128_InvalidNonceSize_Throws()
    {
        if (_implementation.Source != Source.Managed)
            Assert.Ignore("Nonce validation is implementation-specific.");

        byte[] key = new byte[16];
        byte[] shortNonce = new byte[8];
        byte[] plaintext = System.Text.Encoding.UTF8.GetBytes("Test");

        using var aead = (IAeadCipher)_implementation.Create(key);

        Assert.That(() => aead.Encrypt(shortNonce, plaintext),
            Throws.InstanceOf<ArgumentException>().Or.InstanceOf<CryptographicException>());
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
