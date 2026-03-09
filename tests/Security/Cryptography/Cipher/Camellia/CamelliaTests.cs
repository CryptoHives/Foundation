// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Camellia;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for Camellia cipher using RFC 3713 test vectors.
/// </summary>
/// <remarks>
/// Test vectors from RFC 3713, Appendix A.
/// See: https://www.rfc-editor.org/rfc/rfc3713
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CamelliaTests
{
    // ========================================================================
    // RFC 3713 Appendix A - 128-bit key
    // ========================================================================

    /// <summary>
    /// RFC 3713 Appendix A.1: Camellia-128 encryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia128Encrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba9876543210");
        byte[] plaintext = FromHex("0123456789abcdeffedcba9876543210");
        byte[] expected = FromHex("67673138549669730857065648eabe43");

        using var cam = Camellia128.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] ciphertext = cam.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3713 Appendix A.1: Camellia-128 decryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia128Decrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba9876543210");
        byte[] ciphertext = FromHex("67673138549669730857065648eabe43");
        byte[] expected = FromHex("0123456789abcdeffedcba9876543210");

        using var cam = Camellia128.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] plaintext = cam.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 3713 Appendix A - 192-bit key
    // ========================================================================

    /// <summary>
    /// RFC 3713 Appendix A.2: Camellia-192 encryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia192Encrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba98765432100011223344556677");
        byte[] plaintext = FromHex("0123456789abcdeffedcba9876543210");
        byte[] expected = FromHex("b4993401b3e996f84ee5cee7d79b09b9");

        using var cam = Camellia192.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] ciphertext = cam.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3713 Appendix A.2: Camellia-192 decryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia192Decrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba98765432100011223344556677");
        byte[] ciphertext = FromHex("b4993401b3e996f84ee5cee7d79b09b9");
        byte[] expected = FromHex("0123456789abcdeffedcba9876543210");

        using var cam = Camellia192.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] plaintext = cam.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 3713 Appendix A - 256-bit key
    // ========================================================================

    /// <summary>
    /// RFC 3713 Appendix A.3: Camellia-256 encryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia256Encrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba987654321000112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex("0123456789abcdeffedcba9876543210");
        byte[] expected = FromHex("9acc237dff16d76c20ef7c919e3a7509");

        using var cam = Camellia256.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] ciphertext = cam.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3713 Appendix A.3: Camellia-256 decryption.
    /// </summary>
    [Test]
    public void Rfc3713Camellia256Decrypt()
    {
        byte[] key = FromHex("0123456789abcdeffedcba987654321000112233445566778899aabbccddeeff");
        byte[] ciphertext = FromHex("9acc237dff16d76c20ef7c919e3a7509");
        byte[] expected = FromHex("0123456789abcdeffedcba9876543210");

        using var cam = Camellia256.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];

        byte[] plaintext = cam.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip tests
    // ========================================================================

    /// <summary>
    /// Verifies Camellia-128 ECB round-trip.
    /// </summary>
    [Test]
    public void RoundTripEcb128()
    {
        byte[] key = FromHex("0123456789abcdeffedcba9876543210");
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");

        using var enc = Camellia128.Create();
        enc.Mode = CipherMode.ECB;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = new byte[16];
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Camellia128.Create();
        dec.Mode = CipherMode.ECB;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = new byte[16];
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies Camellia-256 CBC round-trip with padding.
    /// </summary>
    [Test]
    public void RoundTripCbc256()
    {
        byte[] key = FromHex("0123456789abcdeffedcba987654321000112233445566778899aabbccddeeff");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex(
            "0123456789abcdeffedcba98765432100011223344556677fedcba9876543210");

        using var enc = Camellia256.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Camellia256.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies Camellia-128 CTR round-trip with non-block-aligned data.
    /// </summary>
    [Test]
    public void RoundTripCtr128()
    {
        byte[] key = FromHex("0123456789abcdeffedcba9876543210");
        byte[] nonce = FromHex("fedcba98765432100123456789abcdef");
        byte[] plaintext = FromHex("0102030405060708090a0b0c0d0e0f101112131415");

        using var enc = Camellia128.Create();
        enc.Mode = CipherMode.CTR;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = nonce;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Camellia128.Create();
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
    /// Cross-validates Camellia-128 ECB encryption with BouncyCastle CamelliaEngine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle128()
    {
        byte[] key = FromHex("0123456789abcdeffedcba9876543210");
        byte[] plaintext = FromHex("0123456789abcdeffedcba9876543210");

        using var cam = Camellia128.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];
        byte[] managed = cam.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.CamelliaEngine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "Camellia-128 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Cross-validates Camellia-256 ECB encryption with BouncyCastle CamelliaEngine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle256()
    {
        byte[] key = FromHex("0123456789abcdeffedcba987654321000112233445566778899aabbccddeeff");
        byte[] plaintext = FromHex("0123456789abcdeffedcba9876543210");

        using var cam = Camellia256.Create();
        cam.Mode = CipherMode.ECB;
        cam.Padding = PaddingMode.None;
        cam.Key = key;
        cam.IV = new byte[16];
        byte[] managed = cam.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.CamelliaEngine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "Camellia-256 output mismatch with BouncyCastle");
    }

    // ========================================================================
    // Property tests
    // ========================================================================

    [Test]
    public void AlgorithmNameIsCamellia128()
    {
        using var cam = Camellia128.Create();
        Assert.That(cam.AlgorithmName, Is.EqualTo("Camellia-128"));
    }

    [Test]
    public void AlgorithmNameIsCamellia256()
    {
        using var cam = Camellia256.Create();
        Assert.That(cam.AlgorithmName, Is.EqualTo("Camellia-256"));
    }

    [Test]
    public void RejectsInvalidKeySize128()
    {
        using var cam = Camellia128.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => cam.Key = new byte[32]);
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
