// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA5401 // Symmetric encryption uses non-default initialization vector, which could be potentially repeatable

namespace Cryptography.Tests.Cipher.Sm4;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for SM4 implementation using GB/T 32907-2016 test vectors.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Sm4Tests
{
    /// <summary>
    /// GB/T 32907-2016 Appendix A: SM4 single block encryption.
    /// </summary>
    [Test]
    public void Sm4EcbEncrypt()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] plaintext = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] expected = FromHex("681EDF34D206965E86B3E94F536E4246");

        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = key;
        sm4.IV = new byte[16];

        byte[] ciphertext = sm4.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    /// <summary>
    /// GB/T 32907-2016 Appendix A: SM4 single block decryption.
    /// </summary>
    [Test]
    public void Sm4EcbDecrypt()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] ciphertext = FromHex("681EDF34D206965E86B3E94F536E4246");
        byte[] expected = FromHex("0123456789ABCDEFFEDCBA9876543210");

        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = key;
        sm4.IV = new byte[16];

        byte[] plaintext = sm4.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    /// <summary>
    /// GB/T 32907-2016 Appendix A: SM4 1,000,000 iterations encryption.
    /// </summary>
    [Test]
    [CancelAfter(30000)]
    public void Sm4EcbEncrypt1MIterations()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] data = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] expected = FromHex("595298C7C6FD271F0402F804C33D3F66");

        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = key;
        sm4.IV = new byte[16];

        byte[] buf = (byte[])data.Clone();
        byte[] temp = new byte[16];

        for (int i = 0; i < 1_000_000; i++)
        {
            using var enc = sm4.CreateEncryptor();
            enc.TransformBlock(buf.AsSpan(), temp.AsSpan());
            Buffer.BlockCopy(temp, 0, buf, 0, 16);
        }

        Assert.That(buf, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies that SM4 round-trip encrypt/decrypt produces the original plaintext.
    /// </summary>
    [Test]
    public void Sm4EcbRoundTrip()
    {
        byte[] key = FromHex("FEDCBA98765432100123456789ABCDEF");
        byte[] plaintext = FromHex("000102030405060708090A0B0C0D0E0F");

        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = key;
        sm4.IV = new byte[16];

        byte[] ciphertext = sm4.Encrypt(plaintext);
        byte[] decrypted = sm4.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies SM4 algorithm name.
    /// </summary>
    [Test]
    public void Sm4AlgorithmName()
    {
        using var sm4 = Sm4.Create();
        Assert.That(sm4.AlgorithmName, Is.EqualTo("SM4"));
    }

    /// <summary>
    /// Verifies SM4 IV size is 16 bytes.
    /// </summary>
    [Test]
    public void Sm4IvSize()
    {
        using var sm4 = Sm4.Create();
        Assert.That(sm4.IVSize, Is.EqualTo(16));
    }

    /// <summary>
    /// Verifies CBC mode round-trip with PKCS7 padding.
    /// </summary>
    [Test]
    public void Sm4CbcRoundTrip()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] iv = FromHex("00112233445566778899AABBCCDDEEFF");
        byte[] plaintext = FromHex(
            "0123456789ABCDEFFEDCBA98765432100011223344556677FEDCBA9876543210");

        using var enc = Sm4.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Sm4.Create();
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
    /// (used by SM4, ARIA, Camellia, Kalyna, Kuznyechik, SEED). Uses a full block of
    /// plaintext so PKCS#7 adds a full padding block; flipping a byte of the first
    /// ciphertext block corrupts exactly the corresponding byte of the decrypted padding
    /// block via CBC's XOR chaining, without touching the rest - the same ciphertext
    /// malleability real padding-oracle attacks exploit.
    /// </summary>
    [Test]
    [TestCase(0, Description = "First byte of the pad block corrupted")]
    [TestCase(8, Description = "Middle byte of the pad block corrupted")]
    [TestCase(15, Description = "Pad-length byte itself corrupted")]
    public void Sm4CbcCorruptedPadding_AnyPosition_Throws(int corruptIndexInPadBlock)
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] iv = FromHex("00112233445566778899AABBCCDDEEFF");
        byte[] plaintext = new byte[16]; // exactly one block -> PKCS7 adds a full padding block

        using var enc = Sm4.Create();
        enc.Mode = CipherMode.CBC;
        enc.Padding = PaddingMode.PKCS7;
        enc.Key = key;
        enc.IV = iv;
        byte[] ciphertext = enc.Encrypt(plaintext);
        Assert.That(ciphertext, Has.Length.EqualTo(32), "Expected two ciphertext blocks (data + full pad block).");

        ciphertext[corruptIndexInPadBlock] ^= 0xFF;

        using var dec = Sm4.Create();
        dec.Mode = CipherMode.CBC;
        dec.Padding = PaddingMode.PKCS7;
        dec.Key = key;
        dec.IV = iv;

        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => dec.Decrypt(ciphertext));
    }

    /// <summary>
    /// Verifies CTR mode round-trip with non-block-aligned data.
    /// </summary>
    [Test]
    public void Sm4CtrRoundTrip()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] nonce = FromHex("FEDCBA98765432100123456789ABCDEF");
        byte[] plaintext = FromHex("0102030405060708090A0B0C0D0E0F101112131415");

        using var enc = Sm4.Create();
        enc.Mode = CipherMode.CTR;
        enc.Padding = PaddingMode.None;
        enc.Key = key;
        enc.IV = nonce;
        byte[] ciphertext = enc.Encrypt(plaintext);

        using var dec = Sm4.Create();
        dec.Mode = CipherMode.CTR;
        dec.Padding = PaddingMode.None;
        dec.Key = key;
        dec.IV = nonce;
        byte[] decrypted = dec.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Cross-validates ECB encryption with BouncyCastle SM4Engine.
    /// </summary>
    [Test]
    public void CrossValidateWithBouncyCastle()
    {
        byte[] key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        byte[] plaintext = FromHex("0123456789ABCDEFFEDCBA9876543210");

        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = key;
        sm4.IV = new byte[16];
        byte[] managed = sm4.Encrypt(plaintext);

        var bcEngine = new Org.BouncyCastle.Crypto.Engines.SM4Engine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcOutput = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcOutput, 0);

        Assert.That(managed, Is.EqualTo(bcOutput), "SM4 output mismatch with BouncyCastle");
    }

    /// <summary>
    /// Verifies that only 128-bit keys are accepted.
    /// </summary>
    [Test]
    public void RejectsInvalidKeySize()
    {
        using var sm4 = Sm4.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => sm4.Key = new byte[32]);
    }

    /// <summary>
    /// Verifies that a disposed transform throws instead of silently transforming
    /// with cleared (zeroed) round-key state.
    /// </summary>
    [Test]
    public void BlockCipherTransform_DisposedInstance_Throws()
    {
        using var sm4 = Sm4.Create();
        sm4.Mode = CipherMode.ECB;
        sm4.Padding = PaddingMode.None;
        sm4.Key = FromHex("0123456789ABCDEFFEDCBA9876543210");
        sm4.IV = new byte[16];

        var encryptor = sm4.CreateEncryptor();
        byte[] block = new byte[16];
        byte[] output = new byte[16];
        encryptor.TransformBlock(block, output);

        encryptor.Dispose();

        Assert.Throws<ObjectDisposedException>(() => encryptor.TransformBlock(block, output));
        Assert.Throws<ObjectDisposedException>(() => encryptor.TransformFinalBlock(block, output));
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
