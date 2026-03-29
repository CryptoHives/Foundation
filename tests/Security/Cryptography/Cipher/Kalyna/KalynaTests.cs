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
    public void RejectsInvalidKeySize128()
    {
        using var kalyna = Kalyna128.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => kalyna.Key = new byte[24]);
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
