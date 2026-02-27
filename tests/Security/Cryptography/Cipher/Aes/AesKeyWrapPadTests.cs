// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Aes;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Tests for <see cref="AesKeyWrapPad"/> (RFC 5649) and AES Key Wrap (RFC 3394).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AesKeyWrapPadTests
{
    // ========================================================================
    // RFC 5649 Section 6 — KWP Test Vectors (192-bit KEK)
    // ========================================================================

    private static readonly byte[] Rfc5649Kek = FromHex(
        "5840df6e29b02af1ab493b705bf16ea1ae8338f4dcc176a8");

    /// <summary>
    /// RFC 5649 Section 6, Example 1: Wrap 20 octets with 192-bit KEK.
    /// </summary>
    [Test]
    public void Rfc5649WrapPad20BytesWith192BitKek()
    {
        byte[] key = FromHex("c37b7e6492584340bed12207808941155068f738");
        byte[] expected = FromHex(
            "138bdeaa9b8fa7fc61f97742e72248ee5ae6ae5360d1ae6a5f54f373fa543b6a");

        using var kwp = new AesKeyWrapPad(Rfc5649Kek);
        byte[] wrapped = kwp.WrapKey(key);

        Assert.That(wrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5649 Section 6, Example 1: Unwrap 20 octets with 192-bit KEK.
    /// </summary>
    [Test]
    public void Rfc5649UnwrapPad20BytesWith192BitKek()
    {
        byte[] wrapped = FromHex(
            "138bdeaa9b8fa7fc61f97742e72248ee5ae6ae5360d1ae6a5f54f373fa543b6a");
        byte[] expected = FromHex("c37b7e6492584340bed12207808941155068f738");

        using var kwp = new AesKeyWrapPad(Rfc5649Kek);
        byte[] unwrapped = kwp.UnwrapKey(wrapped);

        Assert.That(unwrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5649 Section 6, Example 2: Wrap 7 octets with 192-bit KEK (single semiblock case).
    /// </summary>
    [Test]
    public void Rfc5649WrapPad7BytesWith192BitKek()
    {
        byte[] key = FromHex("466f7250617369");
        byte[] expected = FromHex("afbeb0f07dfbf5419200f2ccb50bb24f");

        using var kwp = new AesKeyWrapPad(Rfc5649Kek);
        byte[] wrapped = kwp.WrapKey(key);

        Assert.That(wrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 5649 Section 6, Example 2: Unwrap 7 octets with 192-bit KEK (single semiblock case).
    /// </summary>
    [Test]
    public void Rfc5649UnwrapPad7BytesWith192BitKek()
    {
        byte[] wrapped = FromHex("afbeb0f07dfbf5419200f2ccb50bb24f");
        byte[] expected = FromHex("466f7250617369");

        using var kwp = new AesKeyWrapPad(Rfc5649Kek);
        byte[] unwrapped = kwp.UnwrapKey(wrapped);

        Assert.That(unwrapped, Is.EqualTo(expected));
    }

    // ========================================================================
    // RFC 3394 Section 4.1 — KW Test Vectors (128-bit KEK wrapping 128-bit key)
    // ========================================================================

    /// <summary>
    /// RFC 3394 Section 4.1: Wrap 128-bit key with 128-bit KEK.
    /// </summary>
    [Test]
    public void Rfc3394Wrap128BitKeyWith128BitKek()
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] key = FromHex("00112233445566778899AABBCCDDEEFF");
        byte[] expected = FromHex(
            "1FA68B0A8112B447AEF34BD8FB5A7B829D3E862371D2CFE5");

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKeyNoPad(key);

        Assert.That(wrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3394 Section 4.1: Unwrap 128-bit key with 128-bit KEK.
    /// </summary>
    [Test]
    public void Rfc3394Unwrap128BitKeyWith128BitKek()
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] wrapped = FromHex(
            "1FA68B0A8112B447AEF34BD8FB5A7B829D3E862371D2CFE5");
        byte[] expected = FromHex("00112233445566778899AABBCCDDEEFF");

        using var kwp = new AesKeyWrapPad(kek);
        byte[] unwrapped = kwp.UnwrapKeyNoPad(wrapped);

        Assert.That(unwrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3394 Section 4.2: Wrap 128-bit key with 192-bit KEK.
    /// </summary>
    [Test]
    public void Rfc3394Wrap128BitKeyWith192BitKek()
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F1011121314151617");
        byte[] key = FromHex("00112233445566778899AABBCCDDEEFF");
        byte[] expected = FromHex(
            "96778B25AE6CA435F92B5B97C050AED2468AB8A17AD84E5D");

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKeyNoPad(key);

        Assert.That(wrapped, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 3394 Section 4.2: Unwrap 128-bit key with 192-bit KEK.
    /// </summary>
    [Test]
    public void Rfc3394Unwrap128BitKeyWith192BitKek()
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F1011121314151617");
        byte[] wrapped = FromHex(
            "96778B25AE6CA435F92B5B97C050AED2468AB8A17AD84E5D");
        byte[] expected = FromHex("00112233445566778899AABBCCDDEEFF");

        using var kwp = new AesKeyWrapPad(kek);
        byte[] unwrapped = kwp.UnwrapKeyNoPad(wrapped);

        Assert.That(unwrapped, Is.EqualTo(expected));
    }

    // ========================================================================
    // Round-trip tests
    // ========================================================================

    [TestCase(1, Description = "Minimum length: 1 byte")]
    [TestCase(7, Description = "7 bytes — single semiblock with padding")]
    [TestCase(8, Description = "8 bytes — exact semiblock, single AES block")]
    [TestCase(9, Description = "9 bytes — two semiblocks with padding")]
    [TestCase(16, Description = "16 bytes — two full semiblocks")]
    [TestCase(20, Description = "20 bytes — three semiblocks with padding")]
    [TestCase(24, Description = "24 bytes — three full semiblocks")]
    [TestCase(32, Description = "32 bytes — four full semiblocks")]
    [TestCase(255, Description = "255 bytes — large key")]
    public void KwpRoundTrip(int keyLength)
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] keyData = new byte[keyLength];
        for (int i = 0; i < keyLength; i++)
            keyData[i] = (byte)(i & 0xFF);

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKey(keyData);
        byte[] unwrapped = kwp.UnwrapKey(wrapped);

        Assert.That(unwrapped, Is.EqualTo(keyData));
    }

    [TestCase(16, Description = "16 bytes — minimum for KW")]
    [TestCase(24, Description = "24 bytes — three semiblocks")]
    [TestCase(32, Description = "32 bytes — four semiblocks")]
    [TestCase(256, Description = "256 bytes — large key")]
    public void KwRoundTrip(int keyLength)
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F1011121314151617");
        byte[] keyData = new byte[keyLength];
        for (int i = 0; i < keyLength; i++)
            keyData[i] = (byte)(i & 0xFF);

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKeyNoPad(keyData);
        byte[] unwrapped = kwp.UnwrapKeyNoPad(wrapped);

        Assert.That(unwrapped, Is.EqualTo(keyData));
    }

    // ========================================================================
    // Key size validation
    // ========================================================================

    [TestCase(128, Description = "128-bit KEK")]
    [TestCase(192, Description = "192-bit KEK")]
    [TestCase(256, Description = "256-bit KEK")]
    public void AcceptsValidKekSizes(int kekBits)
    {
        byte[] kek = new byte[kekBits / 8];
        using var kwp = new AesKeyWrapPad(kek);
        byte[] key = new byte[16];
        byte[] wrapped = kwp.WrapKey(key);
        byte[] unwrapped = kwp.UnwrapKey(wrapped);
        Assert.That(unwrapped, Is.EqualTo(key));
    }

    [Test]
    public void RejectsInvalidKekSize()
    {
        Assert.Throws<ArgumentException>(() => new AesKeyWrapPad(new byte[15]));
        Assert.Throws<ArgumentException>(() => new AesKeyWrapPad(new byte[31]));
    }

    // ========================================================================
    // Input validation
    // ========================================================================

    [Test]
    public void WrapKeyRejectsEmptyInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.WrapKey(ReadOnlySpan<byte>.Empty));
    }

    [Test]
    public void UnwrapKeyRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.UnwrapKey(new byte[8]));
    }

    [Test]
    public void UnwrapKeyRejectsNonMultipleOf8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.UnwrapKey(new byte[17]));
    }

    [Test]
    public void WrapKeyNoPadRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.WrapKeyNoPad(new byte[8]));
    }

    [Test]
    public void WrapKeyNoPadRejectsNonMultipleOf8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.WrapKeyNoPad(new byte[17]));
    }

    [Test]
    public void UnwrapKeyNoPadRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.UnwrapKeyNoPad(new byte[16]));
    }

    // ========================================================================
    // Integrity failure tests
    // ========================================================================

    [Test]
    public void KwpUnwrapDetectsCorruptedCiphertext()
    {
        byte[] kek = new byte[16];
        byte[] key = new byte[20];

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKey(key);

        // Corrupt a byte
        wrapped[wrapped.Length / 2] ^= 0xFF;

        Assert.Throws<CryptographicException>(() => kwp.UnwrapKey(wrapped));
    }

    [Test]
    public void KwUnwrapDetectsCorruptedCiphertext()
    {
        byte[] kek = new byte[16];
        byte[] key = new byte[16];

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKeyNoPad(key);

        // Corrupt a byte
        wrapped[0] ^= 0xFF;

        Assert.Throws<CryptographicException>(() => kwp.UnwrapKeyNoPad(wrapped));
    }

    [Test]
    public void KwpUnwrapDetectsWrongKek()
    {
        byte[] kek1 = new byte[16];
        byte[] kek2 = new byte[16];
        kek2[0] = 0xFF;
        byte[] key = new byte[20];

        using var kwp1 = new AesKeyWrapPad(kek1);
        using var kwp2 = new AesKeyWrapPad(kek2);

        byte[] wrapped = kwp1.WrapKey(key);

        Assert.Throws<CryptographicException>(() => kwp2.UnwrapKey(wrapped));
    }

    [Test]
    public void KwpSingleSemiblockUnwrapDetectsCorruption()
    {
        byte[] kek = new byte[16];
        byte[] key = new byte[5];

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.WrapKey(key);

        Assert.That(wrapped, Has.Length.EqualTo(16), "Single semiblock case produces 16-byte output");

        wrapped[0] ^= 0xFF;
        Assert.Throws<CryptographicException>(() => kwp.UnwrapKey(wrapped));
    }

    // ========================================================================
    // Dispose tests
    // ========================================================================

    [Test]
    public void DisposedInstanceThrows()
    {
        var kwp = new AesKeyWrapPad(new byte[16]);
        kwp.Dispose();

        Assert.Throws<ObjectDisposedException>(() => kwp.WrapKey(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.UnwrapKey(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.WrapKeyNoPad(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.UnwrapKeyNoPad(new byte[24]));
    }

    // ========================================================================
    // Output size validation
    // ========================================================================

    [Test]
    public void KwpOutputSizeIsCorrect()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        // 1-8 bytes → 16 bytes (single semiblock: AIV + padded data)
        Assert.That(kwp.WrapKey(new byte[1]), Has.Length.EqualTo(16));
        Assert.That(kwp.WrapKey(new byte[8]), Has.Length.EqualTo(16));

        // 9-16 bytes → 24 bytes (AIV + 2 semiblocks)
        Assert.That(kwp.WrapKey(new byte[9]), Has.Length.EqualTo(24));
        Assert.That(kwp.WrapKey(new byte[16]), Has.Length.EqualTo(24));

        // 17-24 bytes → 32 bytes (AIV + 3 semiblocks)
        Assert.That(kwp.WrapKey(new byte[17]), Has.Length.EqualTo(32));
        Assert.That(kwp.WrapKey(new byte[24]), Has.Length.EqualTo(32));
    }

    [Test]
    public void KwOutputSizeIsInputPlus8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        Assert.That(kwp.WrapKeyNoPad(new byte[16]), Has.Length.EqualTo(24));
        Assert.That(kwp.WrapKeyNoPad(new byte[24]), Has.Length.EqualTo(32));
        Assert.That(kwp.WrapKeyNoPad(new byte[32]), Has.Length.EqualTo(40));
    }

    // ========================================================================
    // Helpers
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
