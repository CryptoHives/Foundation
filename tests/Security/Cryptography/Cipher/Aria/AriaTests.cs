// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Aria;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for ARIA cipher (KS X 1213 / RFC 5794) using RFC 5794 test vectors.
/// </summary>
/// <remarks>
/// Test vectors from RFC 5794, Appendix A.
/// See: https://www.rfc-editor.org/rfc/rfc5794
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AriaTests
{
    // ========================================================================
    // RFC 5794 Appendix A - 128-bit key
    // ========================================================================

    /// <summary>
    /// RFC 5794 Appendix A.1: ARIA-128 encryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria128Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("d718fbd6ab644c739da95f3be6451778");

        using var aria = Aria128.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] ciphertext = aria.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5794 Appendix A.1: ARIA-128 decryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria128Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] ciphertext = FromHex("d718fbd6ab644c739da95f3be6451778");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aria = Aria128.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] plaintext = aria.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 5794 Appendix A - 192-bit key
    // ========================================================================

    /// <summary>
    /// RFC 5794 Appendix A.2: ARIA-192 encryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria192Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f1011121314151617");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("26449c1805dbe7aa25a468ce263a9e79");

        using var aria = Aria192.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] ciphertext = aria.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5794 Appendix A.2: ARIA-192 decryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria192Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f1011121314151617");
        byte[] ciphertext = FromHex("26449c1805dbe7aa25a468ce263a9e79");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aria = Aria192.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] plaintext = aria.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 5794 Appendix A - 256-bit key
    // ========================================================================

    /// <summary>
    /// RFC 5794 Appendix A.3: ARIA-256 encryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria256Encrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");
        byte[] expected = FromHex("f92bd7c79fb72e2f2b8f80c1972d24fc");

        using var aria = Aria256.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] ciphertext = aria.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5794 Appendix A.3: ARIA-256 decryption.
    /// </summary>
    [Test]
    public void Rfc5794Aria256Decrypt()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] ciphertext = FromHex("f92bd7c79fb72e2f2b8f80c1972d24fc");
        byte[] expected = FromHex("00112233445566778899aabbccddeeff");

        using var aria = Aria256.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];

        byte[] plaintext = aria.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip tests
    // ========================================================================

    /// <summary>
    /// Verifies ARIA-128 ECB round-trip.
    /// </summary>
    [Test]
    public void RoundTripEcb128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");

        using var enc = Aria128.Create();
        enc.Mode = CipherMode.ECB;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = new byte[16];
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Aria128.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies ARIA-256 CBC round-trip with PKCS7 padding.
    /// </summary>
    [Test]
    public void RoundTripCbc256()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex(
            "0123456789abcdeffedcba98765432100011223344556677fedcba9876543210");

        using var enc = Aria256.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Aria256.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies ARIA-128 CTR round-trip with non-block-aligned data.
    /// </summary>
    [Test]
    public void RoundTripCtr128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] nonce = FromHex("fedcba98765432100123456789abcdef");
        byte[] plaintext = FromHex("0102030405060708090a0b0c0d0e0f101112131415");

        using var enc = Aria128.Create();
        enc.Mode = CipherMode.CTR;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = nonce;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Aria128.Create();
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
    /// Cross-validates ARIA-128 ECB encryption with BouncyCastle AriaEngine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle128()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");

        using var aria = Aria128.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];
        byte[] managed = aria.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.AriaEngine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "ARIA-128 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates ARIA-256 ECB encryption with BouncyCastle AriaEngine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle256()
    {
        byte[] key = FromHex("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");

        using var aria = Aria256.Create();
        aria.Mode = CipherMode.ECB;
        aria.Padding = PaddingMode.None;
        aria.Key = key;
        aria.IV = new byte[16];
        byte[] managed = aria.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.AriaEngine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "ARIA-256 output mismatch with BouncyCastle");
    }

    // ========================================================================
    // Property tests
    // ========================================================================

    [Test]
    public void AlgorithmNameIsAria128()
    {
        using var aria = Aria128.Create();
        Assert.That(aria.AlgorithmName, Is.EqualTo("ARIA-128"));
    }

    [Test]
    public void AlgorithmNameIsAria256()
    {
        using var aria = Aria256.Create();
        Assert.That(aria.AlgorithmName, Is.EqualTo("ARIA-256"));
    }

    [Test]
    public void RejectsInvalidKeySize128()
    {
        using var aria = Aria128.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => aria.Key = new byte[32]);
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
