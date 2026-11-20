// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Cipher.Aes;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using OS = System.Security.Cryptography;

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
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

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
        byte[] unwrapped = kwp.DecryptKeyWrapPadded(wrapped);

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
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

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
        byte[] unwrapped = kwp.DecryptKeyWrapPadded(wrapped);

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
        byte[] wrapped = kwp.EncryptKeyWrap(key);

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
        byte[] unwrapped = kwp.DecryptKeyWrap(wrapped);

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
        byte[] wrapped = kwp.EncryptKeyWrap(key);

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
        byte[] unwrapped = kwp.DecryptKeyWrap(wrapped);

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
    [TestCase(504, Description = "504 bytes — largest wrapped key unwrapped on the stack")]
    [TestCase(505, Description = "505 bytes — first wrapped key unwrapped in a pooled buffer")]
    [TestCase(4000, Description = "4000 bytes — pooled buffer")]
    public void KwpRoundTrip(int keyLength)
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F");
        byte[] keyData = new byte[keyLength];
        for (int i = 0; i < keyLength; i++)
            keyData[i] = (byte)(i & 0xFF);

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.EncryptKeyWrapPadded(keyData);
        byte[] unwrapped = kwp.DecryptKeyWrapPadded(wrapped);

        Assert.That(unwrapped, Is.EqualTo(keyData));
    }

    [TestCase(16, Description = "16 bytes — minimum for KW")]
    [TestCase(24, Description = "24 bytes — three semiblocks")]
    [TestCase(32, Description = "32 bytes — four semiblocks")]
    [TestCase(256, Description = "256 bytes — large key")]
    [TestCase(504, Description = "504 bytes — largest wrapped key unwrapped on the stack")]
    [TestCase(512, Description = "512 bytes — first wrapped key unwrapped in a pooled buffer")]
    [TestCase(4000, Description = "4000 bytes — pooled buffer")]
    public void KwRoundTrip(int keyLength)
    {
        byte[] kek = FromHex("000102030405060708090A0B0C0D0E0F1011121314151617");
        byte[] keyData = new byte[keyLength];
        for (int i = 0; i < keyLength; i++)
            keyData[i] = (byte)(i & 0xFF);

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.EncryptKeyWrap(keyData);
        byte[] unwrapped = kwp.DecryptKeyWrap(wrapped);

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
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);
        byte[] unwrapped = kwp.DecryptKeyWrapPadded(wrapped);
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
    public void EncryptKeyWrapPaddedRejectsEmptyInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrapPadded(ReadOnlySpan<byte>.Empty));
    }

    [Test]
    public void DecryptKeyWrapPaddedRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.DecryptKeyWrapPadded(new byte[8]));
    }

    [Test]
    public void DecryptKeyWrapPaddedRejectsNonMultipleOf8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.DecryptKeyWrapPadded(new byte[17]));
    }

    [Test]
    public void EncryptKeyWrapRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrap(new byte[8]));
    }

    [Test]
    public void EncryptKeyWrapRejectsNonMultipleOf8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrap(new byte[17]));
    }

    [Test]
    public void DecryptKeyWrapRejectsTooShortInput()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        Assert.Throws<ArgumentException>(() => kwp.DecryptKeyWrap(new byte[16]));
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
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

        // Corrupt a byte
        wrapped[wrapped.Length / 2] ^= 0xFF;

        Assert.Throws<OS.CryptographicException>(() => kwp.DecryptKeyWrapPadded(wrapped));
    }

    [Test]
    public void KwUnwrapDetectsCorruptedCiphertext()
    {
        byte[] kek = new byte[16];
        byte[] key = new byte[16];

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.EncryptKeyWrap(key);

        // Corrupt a byte
        wrapped[0] ^= 0xFF;

        Assert.Throws<OS.CryptographicException>(() => kwp.DecryptKeyWrap(wrapped));
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

        byte[] wrapped = kwp1.EncryptKeyWrapPadded(key);

        Assert.Throws<OS.CryptographicException>(() => kwp2.DecryptKeyWrapPadded(wrapped));
    }

    [Test]
    public void KwpSingleSemiblockUnwrapDetectsCorruption()
    {
        byte[] kek = new byte[16];
        byte[] key = new byte[5];

        using var kwp = new AesKeyWrapPad(kek);
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

        Assert.That(wrapped, Has.Length.EqualTo(16), "Single semiblock case produces 16-byte output");

        wrapped[0] ^= 0xFF;
        Assert.Throws<OS.CryptographicException>(() => kwp.DecryptKeyWrapPadded(wrapped));
    }

    // ========================================================================
    // Dispose tests
    // ========================================================================

    [Test]
    public void DisposedInstanceThrows()
    {
        var kwp = new AesKeyWrapPad(new byte[16]);
        kwp.Dispose();

        Assert.Throws<ObjectDisposedException>(() => kwp.EncryptKeyWrapPadded(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.DecryptKeyWrapPadded(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.EncryptKeyWrap(new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => kwp.DecryptKeyWrap(new byte[24]));
    }

    // ========================================================================
    // Output size validation
    // ========================================================================

    [Test]
    public void KwpOutputSizeIsCorrect()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        // 1-8 bytes → 16 bytes (single semiblock: AIV + padded data)
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[1]), Has.Length.EqualTo(16));
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[8]), Has.Length.EqualTo(16));

        // 9-16 bytes → 24 bytes (AIV + 2 semiblocks)
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[9]), Has.Length.EqualTo(24));
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[16]), Has.Length.EqualTo(24));

        // 17-24 bytes → 32 bytes (AIV + 3 semiblocks)
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[17]), Has.Length.EqualTo(32));
        Assert.That(kwp.EncryptKeyWrapPadded(new byte[24]), Has.Length.EqualTo(32));
    }

    [Test]
    public void KwOutputSizeIsInputPlus8()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        Assert.That(kwp.EncryptKeyWrap(new byte[16]), Has.Length.EqualTo(24));
        Assert.That(kwp.EncryptKeyWrap(new byte[24]), Has.Length.EqualTo(32));
        Assert.That(kwp.EncryptKeyWrap(new byte[32]), Has.Length.EqualTo(40));
    }

    [TestCase(1, 16)]
    [TestCase(8, 16)]
    [TestCase(9, 24)]
    [TestCase(37, 48)]
    [TestCase(0x7FFF_FFF0, 0x7FFF_FFF8)]
    public void GetKeyWrapPaddedLengthRoundsUpAndAddsSemiblock(int plaintextLength, int expected)
    {
        Assert.That(AesKeyWrapPad.GetKeyWrapPaddedLength(plaintextLength), Is.EqualTo(expected));
    }

    [TestCase(0)]
    [TestCase(-1)]
    [TestCase(0x7FFF_FFF1)]
    public void GetKeyWrapPaddedLengthRejectsOutOfRange(int plaintextLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => AesKeyWrapPad.GetKeyWrapPaddedLength(plaintextLength));
    }

    [TestCase(16, 24)]
    [TestCase(40, 48)]
    [TestCase(0x7FFF_FFF0, 0x7FFF_FFF8)]
    public void GetKeyWrapLengthAddsSemiblock(int plaintextLength, int expected)
    {
        Assert.That(AesKeyWrapPad.GetKeyWrapLength(plaintextLength), Is.EqualTo(expected));
    }

    [TestCase(0)]
    [TestCase(8)]
    [TestCase(17)]
    [TestCase(0x7FFF_FFF8)]
    public void GetKeyWrapLengthRejectsOutOfRange(int plaintextLength)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => AesKeyWrapPad.GetKeyWrapLength(plaintextLength));
    }

    // ========================================================================
    // Caller-provided buffers
    // ========================================================================

    [TestCase(1)]
    [TestCase(8)]
    [TestCase(20)]
    [TestCase(505)]
    public void KwpSpanOverloadsMatchArrayOverloads(int keyLength)
    {
        byte[] key = CreateSequence(keyLength, seed: 0x01);
        using var kwp = new AesKeyWrapPad(CreateSequence(32, seed: 0x40));

        byte[] wrapped = new byte[AesKeyWrapPad.GetKeyWrapPaddedLength(keyLength)];
        kwp.EncryptKeyWrapPadded(key, wrapped);
        Assert.That(wrapped, Is.EqualTo(kwp.EncryptKeyWrapPadded(key)));

        byte[] unwrapped = new byte[wrapped.Length - 8];
        Assert.That(kwp.TryDecryptKeyWrapPadded(wrapped, unwrapped, out int written), Is.True);
        Assert.That(unwrapped.AsSpan(0, written).ToArray(), Is.EqualTo(key));
        Assert.That(kwp.DecryptKeyWrapPadded(wrapped, unwrapped), Is.EqualTo(keyLength));
    }

    [TestCase(1, Description = "Destination 7 bytes short of the maximum - fits")]
    [TestCase(20, Description = "Destination exactly the key length - goes through the scratch buffer")]
    [TestCase(505, Description = "Pooled scratch buffer")]
    public void KwpTryDecryptAcceptsDestinationOfExactKeyLength(int keyLength)
    {
        byte[] key = CreateSequence(keyLength, seed: 0x01);
        using var kwp = new AesKeyWrapPad(CreateSequence(16, seed: 0x40));
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

        byte[] unwrapped = new byte[keyLength];
        Assert.That(kwp.TryDecryptKeyWrapPadded(wrapped, unwrapped, out int written), Is.True);
        Assert.That(written, Is.EqualTo(keyLength));
        Assert.That(unwrapped, Is.EqualTo(key));
    }

    [Test]
    public void KwpTryDecryptReturnsFalseWhenKeyDoesNotFit()
    {
        byte[] key = CreateSequence(20, seed: 0x01);
        using var kwp = new AesKeyWrapPad(CreateSequence(16, seed: 0x40));
        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

        byte[] tooShortToTry = new byte[16];
        Assert.That(kwp.TryDecryptKeyWrapPadded(wrapped, tooShortToTry, out int written), Is.False);
        Assert.That(written, Is.Zero);

        byte[] tooShortForKey = new byte[19];
        Assert.That(kwp.TryDecryptKeyWrapPadded(wrapped, tooShortForKey, out written), Is.False);
        Assert.That(written, Is.Zero);
        Assert.That(tooShortForKey, Is.All.Zero);

        Assert.Throws<ArgumentException>(() => kwp.DecryptKeyWrapPadded(wrapped, tooShortForKey));
    }

    [TestCase(16)]
    [TestCase(512)]
    public void KwSpanOverloadsMatchArrayOverloads(int keyLength)
    {
        byte[] key = CreateSequence(keyLength, seed: 0x01);
        using var kw = new AesKeyWrapPad(CreateSequence(24, seed: 0x40));

        byte[] wrapped = new byte[AesKeyWrapPad.GetKeyWrapLength(keyLength)];
        kw.EncryptKeyWrap(key, wrapped);
        Assert.That(wrapped, Is.EqualTo(kw.EncryptKeyWrap(key)));

        byte[] unwrapped = new byte[keyLength];
        Assert.That(kw.TryDecryptKeyWrap(wrapped, unwrapped, out int written), Is.True);
        Assert.That(written, Is.EqualTo(keyLength));
        Assert.That(unwrapped, Is.EqualTo(key));
        Assert.That(kw.DecryptKeyWrap(wrapped, unwrapped), Is.EqualTo(keyLength));

        Assert.That(kw.TryDecryptKeyWrap(wrapped, new byte[keyLength - 1], out written), Is.False);
        Assert.That(written, Is.Zero);
    }

    [Test]
    public void EncryptOverloadsRejectDestinationOfWrongLength()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrapPadded(new byte[20], new byte[31]));
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrapPadded(new byte[20], new byte[33]));
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrap(new byte[16], new byte[25]));
    }

    [Test]
    public void SpanOverloadsRejectOverlappingBuffers()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        byte[] buffer = new byte[64];
        kwp.EncryptKeyWrapPadded(buffer.AsSpan(0, 20), buffer.AsSpan(32, 32));

        Assert.Throws<OS.CryptographicException>(() => kwp.EncryptKeyWrapPadded(buffer.AsSpan(0, 20), buffer.AsSpan(8, 32)));
        Assert.Throws<OS.CryptographicException>(() => kwp.EncryptKeyWrap(buffer.AsSpan(0, 16), buffer.AsSpan(8, 24)));
        Assert.Throws<OS.CryptographicException>(() => kwp.TryDecryptKeyWrapPadded(buffer.AsSpan(32, 32), buffer.AsSpan(40, 24), out _));
        Assert.Throws<OS.CryptographicException>(() => kwp.TryDecryptKeyWrap(buffer.AsSpan(32, 32), buffer.AsSpan(40, 24), out _));
    }

    [Test]
    public void FailedUnwrapClearsDestination()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        byte[] padded = kwp.EncryptKeyWrapPadded(CreateSequence(20, seed: 0x01));
        byte[] unpadded = kwp.EncryptKeyWrap(CreateSequence(24, seed: 0x01));
        padded[^1] ^= 0x01;
        unpadded[^1] ^= 0x01;

        byte[] destination = new byte[padded.Length - 8];
        Assert.Throws<OS.CryptographicException>(() => kwp.TryDecryptKeyWrapPadded(padded, destination, out _));
        Assert.That(destination, Is.All.Zero);

        destination = new byte[unpadded.Length - 8];
        Assert.Throws<OS.CryptographicException>(() => kwp.TryDecryptKeyWrap(unpadded, destination, out _));
        Assert.That(destination, Is.All.Zero);
    }

    [Test]
    public void ArrayOverloadsRejectNull()
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);

        Assert.Throws<ArgumentNullException>(() => kwp.EncryptKeyWrap((byte[])null!));
        Assert.Throws<ArgumentNullException>(() => kwp.DecryptKeyWrap((byte[])null!));
        Assert.Throws<ArgumentNullException>(() => kwp.DecryptKeyWrapPadded((byte[])null!));
        Assert.Throws<ArgumentException>(() => kwp.EncryptKeyWrapPadded((byte[])null!));
    }

#if NET10_0_OR_GREATER
    // ========================================================================
    // Interop with the in-box Aes key wrap (KWP since .NET 10, KW since .NET 11)
    // ========================================================================

    private static readonly int[] KekBits = [128, 192, 256];

    private static readonly int[] KwpKeyLengths = [1, 7, 8, 9, 20, 255, 505];

    public static System.Collections.Generic.IEnumerable<TestCaseData> KwpInteropCases()
    {
        foreach (int kekBits in KekBits)
        {
            foreach (int keyLength in KwpKeyLengths)
            {
                yield return new TestCaseData(kekBits, keyLength);
            }
        }
    }

    [TestCaseSource(nameof(KwpInteropCases))]
    public void KwpWrapMatchesOS(int kekBits, int keyLength)
    {
        byte[] kek = CreateSequence(kekBits / 8, seed: 0x40);
        byte[] key = CreateSequence(keyLength, seed: 0x01);

        using var kwp = new AesKeyWrapPad(kek);
        using var os = CreateOSAes(kek);

        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);

        Assert.That(wrapped, Is.EqualTo(os.EncryptKeyWrapPadded(key)));
        Assert.That(os.DecryptKeyWrapPadded(wrapped), Is.EqualTo(key));
        Assert.That(kwp.DecryptKeyWrapPadded(os.EncryptKeyWrapPadded(key)), Is.EqualTo(key));
    }

    [TestCaseSource(nameof(KwpInteropCases))]
    public void KwpCorruptionIsRejectedLikeOS(int kekBits, int keyLength)
    {
        byte[] kek = CreateSequence(kekBits / 8, seed: 0x40);
        byte[] key = CreateSequence(keyLength, seed: 0x01);

        using var kwp = new AesKeyWrapPad(kek);
        using var os = CreateOSAes(kek);

        byte[] wrapped = kwp.EncryptKeyWrapPadded(key);
        wrapped[^1] ^= 0x01;

        Assert.Throws<OS.CryptographicException>(() => kwp.DecryptKeyWrapPadded(wrapped));
        Assert.That(() => os.DecryptKeyWrapPadded(wrapped), Throws.InstanceOf<OS.CryptographicException>());
    }

#if NET11_0_OR_GREATER
    private static readonly int[] KwKeyLengths = [16, 24, 32, 256, 512];

    public static System.Collections.Generic.IEnumerable<TestCaseData> KwInteropCases()
    {
        foreach (int kekBits in KekBits)
        {
            foreach (int keyLength in KwKeyLengths)
            {
                yield return new TestCaseData(kekBits, keyLength);
            }
        }
    }

    [TestCaseSource(nameof(KwInteropCases))]
    public void KwWrapMatchesOS(int kekBits, int keyLength)
    {
        byte[] kek = CreateSequence(kekBits / 8, seed: 0x40);
        byte[] key = CreateSequence(keyLength, seed: 0x01);

        using var kwp = new AesKeyWrapPad(kek);
        using var os = CreateOSAes(kek);

        byte[] wrapped = kwp.EncryptKeyWrap(key);

        Assert.That(wrapped, Is.EqualTo(os.EncryptKeyWrap(key)));
        Assert.That(os.DecryptKeyWrap(wrapped), Is.EqualTo(key));
        Assert.That(kwp.DecryptKeyWrap(os.EncryptKeyWrap(key)), Is.EqualTo(key));
    }

    [TestCaseSource(nameof(KwInteropCases))]
    public void KwCorruptionIsRejectedLikeOS(int kekBits, int keyLength)
    {
        byte[] kek = CreateSequence(kekBits / 8, seed: 0x40);
        byte[] key = CreateSequence(keyLength, seed: 0x01);

        using var kwp = new AesKeyWrapPad(kek);
        using var os = CreateOSAes(kek);

        byte[] wrapped = kwp.EncryptKeyWrap(key);
        wrapped[^1] ^= 0x01;

        Assert.Throws<OS.CryptographicException>(() => kwp.DecryptKeyWrap(wrapped));
        Assert.That(() => os.DecryptKeyWrap(wrapped), Throws.InstanceOf<OS.CryptographicException>());
    }

    [TestCase(16)]
    [TestCase(24)]
    [TestCase(4096)]
    public void GetKeyWrapLengthMatchesOS(int plaintextLength)
    {
        Assert.That(AesKeyWrapPad.GetKeyWrapLength(plaintextLength), Is.EqualTo(OS.Aes.GetKeyWrapLength(plaintextLength)));
    }

    [TestCase(16, Description = "One semiblock of key: valid for KWP, too short for KW")]
    [TestCase(8)]
    [TestCase(25)]
    public void KwRejectsInvalidCiphertextLengthLikeOS(int ciphertextLength)
    {
        using var kwp = new AesKeyWrapPad(new byte[16]);
        using var os = CreateOSAes(new byte[16]);

        Assert.Throws<ArgumentException>(() => kwp.DecryptKeyWrap(new byte[ciphertextLength]));
        Assert.Throws<ArgumentException>(() => os.DecryptKeyWrap(new byte[ciphertextLength]));
    }
#endif

    [TestCase(1)]
    [TestCase(9)]
    [TestCase(4096)]
    public void GetKeyWrapPaddedLengthMatchesOS(int plaintextLength)
    {
        Assert.That(
            AesKeyWrapPad.GetKeyWrapPaddedLength(plaintextLength),
            Is.EqualTo(OS.Aes.GetKeyWrapPaddedLength(plaintextLength)));
    }

    [Test]
    public void KwpTryDecryptAgreesWithOSOnShortDestination()
    {
        byte[] kek = CreateSequence(16, seed: 0x40);
        using var kwp = new AesKeyWrapPad(kek);
        using var os = CreateOSAes(kek);
        byte[] wrapped = kwp.EncryptKeyWrapPadded(CreateSequence(20, seed: 0x01));

        foreach (int length in new[] { 16, 19, 20, 24 })
        {
            bool ours = kwp.TryDecryptKeyWrapPadded(wrapped, new byte[length], out int oursWritten);
            bool theirs = os.TryDecryptKeyWrapPadded(wrapped, new byte[length], out int theirsWritten);
            Assert.That((ours, oursWritten), Is.EqualTo((theirs, theirsWritten)), $"destination of {length} bytes");
        }
    }

    private static OS.Aes CreateOSAes(byte[] kek)
    {
        var aes = OS.Aes.Create();
        aes.Key = kek;
        return aes;
    }
#endif

    private static byte[] CreateSequence(int length, byte seed)
    {
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
            bytes[i] = unchecked((byte)(seed + i));
        return bytes;
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
