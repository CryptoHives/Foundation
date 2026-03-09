// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Seed;

using System;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using Cryptography.Tests.Adapter.Cipher;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;

/// <summary>
/// Tests for the SEED block cipher (KISA, RFC 4269).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SeedTests
{
    // ========================================================================
    // RFC 4269 Appendix B Test Vectors
    // ========================================================================

    [Test]
    public void Rfc4269Vector1Encrypt()
    {
        // B.1: Key = all zeros, Plaintext = 00 01 02 ... 0F
        byte[] key = new byte[16];
        byte[] plaintext = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] expected = FromHex("5EBAC6E0054E166819AFF1CC6D346CDB");

        byte[] actual = new byte[16];
        uint[] roundKeys = new uint[32];
        SeedCore.ExpandKey(key, roundKeys);
        SeedCore.EncryptBlock(plaintext, actual, roundKeys);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc4269Vector1Decrypt()
    {
        byte[] key = new byte[16];
        byte[] ciphertext = FromHex("5EBAC6E0054E166819AFF1CC6D346CDB");
        byte[] expected = FromHex("000102030405060708090A0B0C0D0E0F");

        byte[] actual = new byte[16];
        uint[] roundKeys = new uint[32];
        SeedCore.ExpandKey(key, roundKeys);
        SeedCore.DecryptBlock(ciphertext, actual, roundKeys);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc4269Vector2Encrypt()
    {
        // B.2: Key = 00 01 02 ... 0F, Plaintext = all zeros
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] plaintext = new byte[16];
        byte[] expected = FromHex("C11F22F20140505084483597E4370F43");

        byte[] actual = new byte[16];
        uint[] roundKeys = new uint[32];
        SeedCore.ExpandKey(key, roundKeys);
        SeedCore.EncryptBlock(plaintext, actual, roundKeys);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Rfc4269Vector2Decrypt()
    {
        byte[] key = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] ciphertext = FromHex("C11F22F20140505084483597E4370F43");
        byte[] expected = new byte[16];

        byte[] actual = new byte[16];
        uint[] roundKeys = new uint[32];
        SeedCore.ExpandKey(key, roundKeys);
        SeedCore.DecryptBlock(ciphertext, actual, roundKeys);

        Assert.That(actual, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip Tests
    // ========================================================================

    [Test]
    public void RoundTripEcb()
    {
        using var seed = Seed.Create();
        seed.Mode = CipherMode.ECB;
        seed.Padding = PaddingMode.None;
        seed.Key = FromHex("0123456789ABCDEF0123456789ABCDEF");
        seed.IV = new byte[16];

        byte[] plaintext = FromHex("00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF00112233445566778899AABBCCDDEEFF");
        byte[] ciphertext = seed.Encrypt(plaintext);
        byte[] decrypted = seed.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void RoundTripCbc()
    {
        using var seed = Seed.Create();
        seed.Mode = CipherMode.CBC;
        seed.Padding = PaddingMode.PKCS7;
        seed.Key = FromHex("0123456789ABCDEF0123456789ABCDEF");
        seed.GenerateIV();

        byte[] plaintext = FromHex("00112233445566778899AABBCCDDEEFF0011223344556677");
        byte[] ciphertext = seed.Encrypt(plaintext);
        byte[] decrypted = seed.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void RoundTripCtr()
    {
        using var seed = Seed.Create();
        seed.Mode = CipherMode.CTR;
        seed.Padding = PaddingMode.None;
        seed.Key = FromHex("0123456789ABCDEF0123456789ABCDEF");
        seed.GenerateIV();

        byte[] plaintext = FromHex("00112233445566778899AABBCCDDEEFF0011223344556677");
        byte[] ciphertext = seed.Encrypt(plaintext);
        byte[] decrypted = seed.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Property Tests
    // ========================================================================

    [Test]
    public void AlgorithmNameIsSeed()
    {
        using var seed = Seed.Create();
        Assert.That(seed.AlgorithmName, Is.EqualTo("SEED"));
    }

    [Test]
    public void RejectsInvalidKeySize()
    {
        using var seed = Seed.Create();
        seed.Mode = CipherMode.ECB;
        seed.Padding = PaddingMode.None;

        Assert.Throws<System.Security.Cryptography.CryptographicException>(() => seed.Key = new byte[24]);
    }

    // ========================================================================
    // BouncyCastle Cross-Validation
    // ========================================================================

    [Test]
    public void CrossValidateWithBouncyCastle()
    {
        byte[] key = FromHex("DEADBEEFCAFEBABE0123456789ABCDEF");
        byte[] plaintext = FromHex("FEDCBA9876543210FEDCBA9876543210");

        // Our implementation
        byte[] ourCiphertext = new byte[16];
        uint[] roundKeys = new uint[32];
        SeedCore.ExpandKey(key, roundKeys);
        SeedCore.EncryptBlock(plaintext, ourCiphertext, roundKeys);

        // BouncyCastle
        var bcEngine = new SeedEngine();
        bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        byte[] bcCiphertext = new byte[16];
        bcEngine.ProcessBlock(plaintext, 0, bcCiphertext, 0);

        Assert.That(ourCiphertext, Is.EqualTo(bcCiphertext),
            "SEED encrypt mismatch with BouncyCastle");

        // Cross-decrypt: BC ciphertext with our implementation
        byte[] ourDecrypted = new byte[16];
        SeedCore.DecryptBlock(bcCiphertext, ourDecrypted, roundKeys);
        Assert.That(ourDecrypted, Is.EqualTo(plaintext),
            "SEED decrypt mismatch with BouncyCastle");
    }

    [Test]
    public void CrossValidateWithBouncyCastleMultipleBlocks()
    {
        byte[][] keys = new[]
        {
            FromHex("00000000000000000000000000000000"),
            FromHex("000102030405060708090A0B0C0D0E0F"),
            FromHex("FEDCBA9876543210FEDCBA9876543210"),
            FromHex("DEADBEEFCAFEBABE0123456789ABCDEF"),
            FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
        };

        byte[][] plaintexts = new[]
        {
            FromHex("000102030405060708090A0B0C0D0E0F"),
            FromHex("00000000000000000000000000000000"),
            FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
            FromHex("0123456789ABCDEF0123456789ABCDEF"),
            FromHex("A5A5A5A5A5A5A5A5A5A5A5A5A5A5A5A5"),
        };

        for (int trial = 0; trial < keys.Length; trial++)
        {
            byte[] ourCiphertext = new byte[16];
            uint[] roundKeys = new uint[32];
            SeedCore.ExpandKey(keys[trial], roundKeys);
            SeedCore.EncryptBlock(plaintexts[trial], ourCiphertext, roundKeys);

            var bcEngine = new SeedEngine();
            bcEngine.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(keys[trial]));
            byte[] bcCiphertext = new byte[16];
            bcEngine.ProcessBlock(plaintexts[trial], 0, bcCiphertext, 0);

            Assert.That(ourCiphertext, Is.EqualTo(bcCiphertext),
                $"SEED encrypt mismatch on trial {trial}");
        }
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

