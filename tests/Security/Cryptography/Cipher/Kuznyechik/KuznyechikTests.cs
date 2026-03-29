// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Kuznyechik;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for Kuznyechik (GOST R 34.12-2015) using RFC 7801 test vectors.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 7801, Sections 5.4, 5.5, and 5.6.
/// See: https://www.rfc-editor.org/rfc/rfc7801
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KuznyechikTests
{
    // RFC 7801 test key
    private static readonly byte[] TestKey = FromHex(
        "8899aabbccddeeff0011223344556677fedcba98765432100123456789abcdef");

    // ========================================================================
    // RFC 7801 Section 5.5 - Encryption
    // ========================================================================

    /// <summary>
    /// RFC 7801 Section 5.5: single block encryption.
    /// </summary>
    [Test]
    public void Rfc7801_Encrypt()
    {
        byte[] plaintext = FromHex("1122334455667700ffeeddccbbaa9988");
        byte[] expected = FromHex("7f679d90bebc24305a468d42b9d4edcd");

        using var kuz = Kuznyechik.Create();
        kuz.Mode = CipherMode.ECB;
        kuz.Padding = PaddingMode.None;
        kuz.Key = TestKey;
        kuz.IV = new byte[16];

        byte[] ciphertext = kuz.Encrypt(plaintext);

        Assert.That(ciphertext, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 7801 Section 5.6 - Decryption
    // ========================================================================

    /// <summary>
    /// RFC 7801 Section 5.6: single block decryption.
    /// </summary>
    [Test]
    public void Rfc7801_Decrypt()
    {
        byte[] ciphertext = FromHex("7f679d90bebc24305a468d42b9d4edcd");
        byte[] expected = FromHex("1122334455667700ffeeddccbbaa9988");

        using var kuz = Kuznyechik.Create();
        kuz.Mode = CipherMode.ECB;
        kuz.Padding = PaddingMode.None;
        kuz.Key = TestKey;
        kuz.IV = new byte[16];

        byte[] plaintext = kuz.Decrypt(ciphertext);

        Assert.That(plaintext, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip tests
    // ========================================================================

    /// <summary>
    /// Verifies that encrypting and then decrypting returns the original plaintext.
    /// </summary>
    [Test]
    public void RoundTripEcb()
    {
        byte[] plaintext = FromHex("00112233445566778899aabbccddeeff");

        using var encKuz = Kuznyechik.Create();
        encKuz.Mode = CipherMode.ECB;
        encKuz.Padding = PaddingMode.None;
        encKuz.Key = TestKey;
        encKuz.IV = new byte[16];

        byte[] ciphertext = encKuz.Encrypt(plaintext);

        using var decKuz = Kuznyechik.Create();
        decKuz.Mode = CipherMode.ECB;
        decKuz.Padding = PaddingMode.None;
        decKuz.Key = TestKey;
        decKuz.IV = new byte[16];

        byte[] decrypted = decKuz.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies CBC mode round-trip with padding on multi-block data.
    /// </summary>
    [Test]
    public void RoundTripCbc()
    {
        byte[] plaintext = FromHex(
            "1122334455667700ffeeddccbbaa99880011223344556677fedcba9876543210");
        byte[] iv = FromHex("00112233445566778899aabbccddeeff");

        using var encKuz = Kuznyechik.Create();
        encKuz.Mode = CipherMode.CBC;
        encKuz.Padding = PaddingMode.PKCS7;
        encKuz.Key = TestKey;
        encKuz.IV = iv;

        byte[] ciphertext = encKuz.Encrypt(plaintext);

        using var decKuz = Kuznyechik.Create();
        decKuz.Mode = CipherMode.CBC;
        decKuz.Padding = PaddingMode.PKCS7;
        decKuz.Key = TestKey;
        decKuz.IV = iv;

        byte[] decrypted = decKuz.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    /// <summary>
    /// Verifies CTR mode round-trip with non-block-aligned data.
    /// </summary>
    [Test]
    public void RoundTripCtr()
    {
        byte[] plaintext = FromHex("0102030405060708090a0b0c0d0e0f101112131415");
        byte[] nonce = FromHex("fedcba98765432100123456789abcdef");

        using var encKuz = Kuznyechik.Create();
        encKuz.Mode = CipherMode.CTR;
        encKuz.Padding = PaddingMode.None;
        encKuz.Key = TestKey;
        encKuz.IV = nonce;

        byte[] ciphertext = encKuz.Encrypt(plaintext);

        using var decKuz = Kuznyechik.Create();
        decKuz.Mode = CipherMode.CTR;
        decKuz.Padding = PaddingMode.None;
        decKuz.Key = TestKey;
        decKuz.IV = nonce;

        byte[] decrypted = decKuz.Decrypt(ciphertext);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // RFC 7801 Section 5.4 - Key Schedule
    // ========================================================================

    /// <summary>
    /// RFC 7801 Section 5.4: verifies round key derivation.
    /// </summary>
    [Test]
    public void Rfc7801_KeySchedule()
    {
        string[] expectedRoundKeys =
        [
            "8899aabbccddeeff0011223344556677",
            "fedcba98765432100123456789abcdef",
            "db31485315694343228d6aef8cc78c44",
            "3d4553d8e9cfec6815ebadc40a9ffd04",
            "57646468c44a5e28d3e59246f429f1ac",
            "bd079435165c6432b532e82834da581b",
            "51e640757e8745de705727265a0098b1",
            "5a7925017b9fdd3ed72a91a22286f984",
            "bb44e25378c73123a5f32f73cdb6e517",
            "72e9dd7416bcf45b755dbaa88e4a4043",
        ];

        byte[] roundKeys = new byte[160];
        KuznyechikCore.ExpandKey(TestKey, roundKeys);

        for (int i = 0; i < 10; i++)
        {
            byte[] expected = FromHex(expectedRoundKeys[i]);
            byte[] actual = new byte[16];
            Array.Copy(roundKeys, i * 16, actual, 0, 16);

            Assert.That(actual, Is.EqualTo(expected),
                $"Round key K_{i + 1} mismatch");
        }
    }

    // ========================================================================
    // Property tests
    // ========================================================================

    /// <summary>
    /// Verifies the algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNameIsKuznyechik()
    {
        using var kuz = Kuznyechik.Create();
        Assert.That(kuz.AlgorithmName, Is.EqualTo("Kuznyechik"));
    }

    /// <summary>
    /// Verifies that only 256-bit keys are accepted.
    /// </summary>
    [Test]
    public void RejectsInvalidKeySize()
    {
        using var kuz = Kuznyechik.Create();
        Assert.Throws<System.Security.Cryptography.CryptographicException>(
            () => kuz.Key = new byte[16]);
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
