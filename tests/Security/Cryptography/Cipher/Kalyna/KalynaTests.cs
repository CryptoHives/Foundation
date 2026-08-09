// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Kalyna;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for Kalyna cipher (DSTU 7624:2014) using DSTU test vectors
/// and BouncyCastle (Dstu7624Engine) cross-validation.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KalynaTests
{
    // ========================================================================
    // Kalyna-128/128 (10 rounds)
    // ========================================================================

    /// <summary>
    /// DSTU 7624:2014 test vector: Kalyna-128/128 ECB encryption.
    /// </summary>
    [Test]
    public void Kalyna128Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("101112131415161718191a1b1c1d1e1f");
        // Expected ciphertext will be validated against BouncyCastle

        using var kalyna = Kalyna128.Create();
        kalyna.Mode = CipherMode.ECB;
        kalyna.Padding = PaddingMode.None;
        kalyna.Key = key;
        kalyna.IV = new byte[16];

        byte[] ciphertext = kalyna.Encrypt(plaintext);

        Assert.That(ciphertext.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Verifies Kalyna-128 ECB round-trip.
    /// </summary>
    [Test]
    public void RoundTripEcb128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("101112131415161718191a1b1c1d1e1f");

        using var enc = Kalyna128.Create();
        enc.Mode = CipherMode.ECB;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = new byte[16];
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna128.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Kalyna-128/256 (14 rounds)
    // ========================================================================

    /// <summary>
    /// Verifies Kalyna-256 ECB round-trip with 256-bit key.
    /// </summary>
    [Test]
    public void RoundTripEcb256()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("202122232425262728292a2b2c2d2e2f");

        using var enc = Kalyna256.Create();
        enc.Mode = CipherMode.ECB;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = new byte[16];
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna256.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Kalyna-512/256 (18 rounds)
    // ========================================================================

    /// <summary>
    /// Verifies Kalyna-512 ECB round-trip with a 512-bit key.
    /// </summary>
    [Test]
    public void RoundTripEcb512()
    {
        byte[] key = FromHex(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f");
        byte[] plaintext = FromHex("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");

        using var enc = Kalyna512.Create();
        enc.Mode = CipherMode.ECB;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = new byte[32];
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna512.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[32];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies Kalyna-512 CBC round-trip with PKCS7 padding.
    /// </summary>
    [Test]
    public void RoundTripCbc512()
    {
        byte[] key = FromHex(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex(
            "0123456789abcdeffedcba98765432100011223344556677fedcba9876543210" +
            "8899aabbccddeeff0011223344556677");

        using var enc = Kalyna512.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna512.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// PKCS#7 padding must be rejected regardless of which byte in the pad is corrupted -
    /// covers the constant-time padding check in the shared <c>BlockCipherTransform</c> base
    /// at Kalyna-512's 32-byte block size (the other covering test, in Sm4Tests, only
    /// exercises the common 16-byte block size). Uses a full block of plaintext so PKCS#7
    /// adds a full 32-byte padding block; flipping a byte of the first ciphertext block
    /// corrupts exactly the corresponding byte of the decrypted padding block via CBC's
    /// XOR chaining, without touching the rest.
    /// </summary>
    [Test]
    [TestCase(0, Description = "First byte of the pad block corrupted")]
    [TestCase(16, Description = "Middle byte of the pad block corrupted")]
    [TestCase(31, Description = "Pad-length byte itself corrupted")]
    public void Kalyna512CbcCorruptedPadding_AnyPosition_Throws(int corruptIndexInPadBlock)
    {
        byte[] key = FromHex(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff00112233445566778899aabbccddeeff");
        byte[] plaintext = new byte[32]; // exactly one block -> PKCS7 adds a full padding block

        using var enc = Kalyna512.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);
        Assert.That(ciphertext, Has.Length.EqualTo(64), "Expected two ciphertext blocks (data + full pad block).");

        ciphertext[corruptIndexInPadBlock] ^= 0xFF;

        using var dec = Kalyna512.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;

        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => dec.Decrypt(ciphertext));
    }

    // ========================================================================
    // CBC and CTR round-trips
    // ========================================================================

    /// <summary>
    /// Verifies Kalyna-128 CBC round-trip with PKCS7 padding.
    /// </summary>
    [Test]
    public void RoundTripCbc128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex(
            "0123456789abcdeffedcba98765432100011223344556677fedcba9876543210");

        using var enc = Kalyna128.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna128.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies Kalyna-128 CTR round-trip with non-block-aligned data.
    /// </summary>
    [Test]
    public void RoundTripCtr128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] nonce = FromHex("fedcba98765432100123456789abcdef");
        byte[] plaintext = FromHex("0102030405060708090a0b0c0d0e0f101112131415");

        using var enc = Kalyna128.Create();
        enc.Mode = CipherMode.CTR;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = nonce;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Kalyna128.Create();
        dec.Mode = CipherMode.CTR;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = nonce;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // BouncyCastle cross-validation
    // ========================================================================

    /// <summary>
    /// Cross-validates Kalyna-128/128 ECB with BouncyCastle Dstu7624Engine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("101112131415161718191a1b1c1d1e1f");

        using var kalyna = Kalyna128.Create();
        kalyna.Mode = CipherMode.ECB;
        kalyna.Padding = PaddingMode.None;
        kalyna.Key = key;
        kalyna.IV = new byte[16];
        byte[] managed = kalyna.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128);
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "Kalyna-128 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-128/128 ECB decryption with BouncyCastle Dstu7624Engine.
    /// </summary>
    [Test]
    public void CrossValidateDecryptWithBouncyCastle128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("101112131415161718191a1b1c1d1e1f");

        // Use BC to encrypt
        var bcEnc = new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128);
        bcEnc.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] ciphertext = new byte[16];
        bcEnc.ProcessBlock(plaintext, 0, ciphertext, 0);

        // Our implementation decrypts
        using var dec = Kalyna128.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext), "Kalyna-128 decrypt mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-128/256 ECB with BouncyCastle Dstu7624Engine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle256()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("202122232425262728292a2b2c2d2e2f");

        using var kalyna = Kalyna256.Create();
        kalyna.Mode = CipherMode.ECB;
        kalyna.Padding = PaddingMode.None;
        kalyna.Key = key;
        kalyna.IV = new byte[16];
        byte[] managed = kalyna.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128);
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "Kalyna-256 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-512 ECB with BouncyCastle Dstu7624Engine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle512()
    {
        byte[] key = FromHex(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f");
        byte[] plaintext = FromHex("404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f");

        using var kalyna = Kalyna512.Create();
        kalyna.Mode = CipherMode.ECB;
        kalyna.Padding = PaddingMode.None;
        kalyna.Key = key;
        kalyna.IV = new byte[32];
        byte[] managed = kalyna.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(256);
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[32];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "Kalyna-512 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-128/256 ECB decryption with BouncyCastle Dstu7624Engine.
    /// </summary>
    [Test]
    public void CrossValidateDecryptWithBouncyCastle256()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("202122232425262728292a2b2c2d2e2f");

        var bcEnc = new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128);
        bcEnc.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] ciphertext = new byte[16];
        bcEnc.ProcessBlock(plaintext, 0, ciphertext, 0);

        using var dec = Kalyna256.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext), "Kalyna-256 decrypt mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-128/128 CBC encryption with BouncyCastle.
    /// </summary>
    [Test]
    public void CrossValidateCbcEncryptWithBouncyCastle128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex("0123456789abcdeffedcba98765432100011223344556677fedcba9876543210");

        using var enc = Kalyna128.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = iv;
        byte[] managed = enc.Encrypt(plaintext);

        var bcCbc = new Org.BouncyCastle.Crypto.Modes.CbcBlockCipher(new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128));
        bcCbc.Init(true, new Org.BouncyCastle.Crypto.Parameters.ParametersWithIV(
            new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key), iv));
        byte[] bcOutput = new byte[plaintext.Length];
        for (int i = 0; i < plaintext.Length / 16; i++)
            bcCbc.ProcessBlock(plaintext, i * 16, bcOutput, i * 16);

        Assert.That(managed, Is.EqualTo(bcOutput), "Kalyna-128 CBC encrypt mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Kalyna-128/128 CBC decryption with BouncyCastle.
    /// </summary>
    [Test]
    public void CrossValidateCbcDecryptWithBouncyCastle128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex("0123456789abcdeffedcba98765432100011223344556677fedcba9876543210");

        // Encrypt with BC to generate ciphertext
        var bcEnc = new Org.BouncyCastle.Crypto.Modes.CbcBlockCipher(new Org.BouncyCastle.Crypto.Engines.Dstu7624Engine(128));
        bcEnc.Init(true, new Org.BouncyCastle.Crypto.Parameters.ParametersWithIV(
            new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key), iv));
        byte[] ciphertext = new byte[plaintext.Length];
        for (int i = 0; i < plaintext.Length / 16; i++)
            bcEnc.ProcessBlock(plaintext, i * 16, ciphertext, i * 16);

        // Our implementation decrypts
        using var dec = Kalyna128.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = iv;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext), "Kalyna-128 CBC decrypt mismatch with BouncyCastle");
    }

    /// <summary>
    /// Randomized round-trip: verifies encrypt(decrypt(x)) == x for many random keys and plaintexts.
    /// </summary>
    [Test]
    public void RandomizedRoundTrip128()
    {
        var rng = new System.Random(42);
        byte[] key = new byte[16];
        byte[] plaintext = new byte[64];
        for (int i = 0; i < 200; i++)
        {
            rng.NextBytes(key);
            rng.NextBytes(plaintext);

            using var enc = Kalyna128.Create();
            enc.Mode = CipherMode.ECB;
            enc.Padding = PaddingMode.None;
            enc.Key = key;
            enc.IV = new byte[16];
            byte[] ciphertext = enc.Encrypt(plaintext);

            using var dec = Kalyna128.Create();
            dec.Mode = CipherMode.ECB;
            dec.Padding = PaddingMode.None;
            dec.Key = key;
            dec.IV = new byte[16];
            byte[] decrypted = dec.Decrypt(ciphertext);

            Assert.That(decrypted, Is.EqualTo(plaintext), $"Round-trip failed at iteration {i}");
        }
    }

    // ========================================================================
    // Property tests
    // ========================================================================

    [Test]
    public void AlgorithmNameIsKalyna128()
    {
        using var kalyna = Kalyna128.Create();
        Assert.That(kalyna.AlgorithmName, Is.EqualTo("Kalyna-128"));
    }

    [Test]
    public void AlgorithmNameIsKalyna256()
    {
        using var kalyna = Kalyna256.Create();
        Assert.That(kalyna.AlgorithmName, Is.EqualTo("Kalyna-256"));
    }

    [Test]
    public void AlgorithmNameIsKalyna512()
    {
        using var kalyna = Kalyna512.Create();
        Assert.That(kalyna.AlgorithmName, Is.EqualTo("Kalyna-512"));
    }

    [Test]
    public void RejectsInvalidKeySize128()
    {
        using var kalyna = Kalyna128.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => kalyna.Key = new byte[24]);
    }

    [Test]
    public void RejectsInvalidKeySize512()
    {
        using var kalyna = Kalyna512.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => kalyna.Key = new byte[48]);
    }

    // ========================================================================
    // Helper
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
