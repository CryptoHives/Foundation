// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CA5401 // Test vectors and cross-checks use explicit fixed IVs.

namespace Cryptography.Tests.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography.Cipher;
using OS = System.Security.Cryptography;

/// <summary>
/// Tests for the OFB, CFB and CTS modes and for every <see cref="PaddingMode"/>.
/// </summary>
/// <remarks>
/// AES is pinned to NIST SP 800-38A and RFC 3962 vectors, BouncyCastle and the in-box
/// <see cref="OS.Aes"/>. The other ciphers are checked against a reference built here from their
/// ECB mode, which the AES checks validate.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
internal class BlockCipherModeTests
{
    private const string Sp80038aKey128 = "2b7e151628aed2a6abf7158809cf4f3c";
    private const string Sp80038aIv = "000102030405060708090a0b0c0d0e0f";
    private const string Sp80038aPlaintext =
        "6bc1bee22e409f96e93d7e117393172a" +
        "ae2d8a571e03ac9c9eb76fac45af8e51" +
        "30c81c46a35ce411e5fbc1191a0a52ef" +
        "f69f2445df4f9b17ad2b417be66c3710";

    private const string Rfc3962Key = "636869636b656e207465726979616b69";
    private const string Rfc3962Plaintext = "I would like the General Gau's Chicken, please, and wonton soup.";

    private static readonly PaddingMode[] DeterministicPaddings =
        [PaddingMode.None, PaddingMode.PKCS7, PaddingMode.Zeros, PaddingMode.ANSIX923];

    public sealed class CipherCase(string name, Func<SymmetricCipher> create, int keyBytes)
    {
        public Func<SymmetricCipher> Create { get; } = create;

        public int KeyBytes { get; } = keyBytes;

        public override string ToString() => name;
    }

    private static IEnumerable<CipherCase> Ciphers()
    {
        yield return new CipherCase("AES-128", () => Aes128.Create(), 16);
        yield return new CipherCase("AES-256", () => Aes256.Create(), 32);
        yield return new CipherCase("ARIA-128", () => Aria128.Create(), 16);
        yield return new CipherCase("Camellia-128", () => Camellia128.Create(), 16);
        yield return new CipherCase("Kalyna-512", () => Kalyna512.Create(), 64);
        yield return new CipherCase("Kuznyechik", () => CH.Kuznyechik.Create(), 32);
        yield return new CipherCase("SEED", () => CH.Seed.Create(), 16);
        yield return new CipherCase("SM4", () => CH.Sm4.Create(), 16);
    }

    // ========================================================================
    // Known-answer vectors
    // ========================================================================

    [Test]
    public void Sp80038aCfb8Aes128()
    {
        // F.3.7 CFB8-AES128.Encrypt
        using var aes = CreateAes(CipherMode.CFB, PaddingMode.None, Sp80038aKey128, Sp80038aIv);
        aes.FeedbackSize = 8;

        byte[] pt = FromHex("6bc1bee22e409f96e93d7e117393172aae2d");
        byte[] ct = aes.Encrypt(pt);

        Assert.That(ct, Is.EqualTo(FromHex("3b79424c9c0dd436bace9e0ed4586a4f32b9")));
        Assert.That(aes.Decrypt(ct), Is.EqualTo(pt));
    }

    [Test]
    public void Sp80038aCfb128Aes128()
    {
        // F.3.13 CFB128-AES128.Encrypt
        using var aes = CreateAes(CipherMode.CFB, PaddingMode.None, Sp80038aKey128, Sp80038aIv);
        aes.FeedbackSize = 128;

        byte[] ct = aes.Encrypt(FromHex(Sp80038aPlaintext));

        Assert.That(ct, Is.EqualTo(FromHex(
            "3b3fd92eb72dad20333449f8e83cfb4a" +
            "c8a64537a0b3a93fcde3cdad9f1ce58b" +
            "26751f67a3cbb140b1808cf187a4f4df" +
            "c04b05357c5d1c0eeac4c66f9ff7f2e6")));
        Assert.That(aes.Decrypt(ct), Is.EqualTo(FromHex(Sp80038aPlaintext)));
    }

    [Test]
    public void Sp80038aOfbAes128()
    {
        // F.4.1 OFB-AES128.Encrypt
        using var aes = CreateAes(CipherMode.OFB, PaddingMode.None, Sp80038aKey128, Sp80038aIv);

        byte[] ct = aes.Encrypt(FromHex(Sp80038aPlaintext));

        Assert.That(ct, Is.EqualTo(FromHex(
            "3b3fd92eb72dad20333449f8e83cfb4a" +
            "7789508d16918f03f53c52dac54ed825" +
            "9740051e9c5fecf64344f7a82260edcc" +
            "304c6528f659c77866a510d9c1d6ae5e")));
        Assert.That(aes.Decrypt(ct), Is.EqualTo(FromHex(Sp80038aPlaintext)));
    }

    [TestCase(17, "c6353568f2bf8cb4d8a580362da7ff7f97")]
    [TestCase(31, "fc00783e0efdb2c1d445d4c8eff7ed2297687268d6ecccc0c07b25e25ecfe5")]
    [TestCase(32, "39312523a78662d5be7fcbcc98ebf5a897687268d6ecccc0c07b25e25ecfe584")]
    [TestCase(47, "97687268d6ecccc0c07b25e25ecfe584b3fffd940c16a18c1b5549d2f838029e39312523a78662d5be7fcbcc98ebf5")]
    [TestCase(48, "97687268d6ecccc0c07b25e25ecfe5849dad8bbb96c4cdc03bc103e1a194bbd839312523a78662d5be7fcbcc98ebf5a8")]
    [TestCase(64, "97687268d6ecccc0c07b25e25ecfe58439312523a78662d5be7fcbcc98ebf5a84807efe836ee89a526730dbc2f7bc8409dad8bbb96c4cdc03bc103e1a194bbd8")]
    public void Rfc3962CtsAes128(int length, string expectedHex)
    {
        using var aes = CreateAes(CipherMode.CTS, PaddingMode.PKCS7, Rfc3962Key, "00000000000000000000000000000000");
        byte[] pt = Encoding.ASCII.GetBytes(Rfc3962Plaintext.Substring(0, length));

        byte[] ct = aes.Encrypt(pt);

        Assert.That(ct, Is.EqualTo(FromHex(expectedHex)));
        Assert.That(aes.Decrypt(ct), Is.EqualTo(pt));
    }

    // ========================================================================
    // BouncyCastle cross-validation (AES)
    // ========================================================================

    private static IEnumerable<TestCaseData> BouncyCastleCases()
    {
        foreach (int length in new[] { 16, 17, 31, 32, 33, 48, 63, 64, 100 })
        {
            yield return new TestCaseData(CipherMode.CFB, 8, length);

            // For a single block CS3 is plain CBC; BouncyCastle's CtsBlockCipher differs there.
            if (length > 16)
                yield return new TestCaseData(CipherMode.CTS, 128, length);

            // BouncyCastle's buffered OFB and full-block CFB do not finish a partial block.
            if (length % 16 == 0)
            {
                yield return new TestCaseData(CipherMode.CFB, 128, length);
                yield return new TestCaseData(CipherMode.OFB, 128, length);
            }
        }
    }

    [TestCaseSource(nameof(BouncyCastleCases))]
    public void AesMatchesBouncyCastle(CipherMode mode, int feedbackBits, int length)
    {
        byte[] key = Pattern(16, 0x10);
        byte[] iv = Pattern(16, 0x80);
        byte[] pt = Pattern(length, 0x33);

        using var aes = Aes128.Create();
        aes.Mode = mode;
        aes.Padding = PaddingMode.None;
        aes.FeedbackSize = feedbackBits;
        aes.Key = key;
        aes.IV = iv;

        BufferedBlockCipher bc = mode switch {
            CipherMode.OFB => new BufferedBlockCipher(new OfbBlockCipher(new AesEngine(), 128)),
            CipherMode.CFB => new BufferedBlockCipher(new CfbBlockCipher(new AesEngine(), feedbackBits)),
            _ => new CtsBlockCipher(new CbcBlockCipher(new AesEngine()))
        };
        bc.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

        byte[] ct = aes.Encrypt(pt);

        Assert.That(ct, Is.EqualTo(bc.DoFinal(pt)));
        Assert.That(aes.Decrypt(ct), Is.EqualTo(pt));
    }

    // ========================================================================
    // In-box interoperability (AES)
    // ========================================================================

    private static IEnumerable<TestCaseData> InBoxCases(CipherMode[] modes, int[] feedbackSizes)
    {
        foreach (CipherMode mode in modes)
            foreach (int feedbackBits in feedbackSizes)
                foreach (PaddingMode padding in DeterministicPaddings)
                    foreach (int length in new[] { 0, 1, 15, 16, 17, 31, 32, 40 })
                    {
                        int unit = mode == CipherMode.CFB ? feedbackBits / 8 : 16;
                        if (padding != PaddingMode.None || length % unit == 0)
                            yield return new TestCaseData(mode, padding, feedbackBits, length);
                    }
    }

    private static IEnumerable<TestCaseData> PaddingCases()
        => InBoxCases([CipherMode.ECB, CipherMode.CBC], [128]);

    [TestCaseSource(nameof(PaddingCases))]
    public void PaddingMatchesInBoxAes(CipherMode mode, PaddingMode padding, int feedbackBits, int length)
        => AssertMatchesInBox(mode, padding, feedbackBits, length);

#if NET
    private static IEnumerable<TestCaseData> CfbCases()
        => InBoxCases([CipherMode.CFB], [8, 128]);

    [TestCaseSource(nameof(CfbCases))]
    public void CfbMatchesInBoxAes(CipherMode mode, PaddingMode padding, int feedbackBits, int length)
        => AssertMatchesInBox(mode, padding, feedbackBits, length);
#endif

    [Test]
    public void Iso10126InteropsWithInBoxAes([Values(0, 1, 15, 16, 17, 40)] int length)
    {
        byte[] key = Pattern(16, 0x01);
        byte[] iv = Pattern(16, 0x41);
        byte[] pt = Pattern(length, 0x77);

        using var ours = Aes128.Create();
        ours.Mode = CipherMode.CBC;
        ours.Padding = PaddingMode.ISO10126;
        ours.Key = key;
        ours.IV = iv;

        using OS.Aes inBox = CreateInBoxAes(OS.CipherMode.CBC, OS.PaddingMode.ISO10126, 128, key, iv);

        byte[] ourCt = ours.Encrypt(pt);
        Assert.That(ourCt, Has.Length.EqualTo((length / 16 + 1) * 16));
        using (OS.ICryptoTransform decryptor = inBox.CreateDecryptor())
        {
            Assert.That(decryptor.TransformFinalBlock(ourCt, 0, ourCt.Length), Is.EqualTo(pt));
        }

        byte[] inBoxCt;
        using (OS.ICryptoTransform encryptor = inBox.CreateEncryptor())
        {
            inBoxCt = encryptor.TransformFinalBlock(pt, 0, pt.Length);
        }

        Assert.That(ours.Decrypt(inBoxCt), Is.EqualTo(pt));
    }

    // ========================================================================
    // All ciphers against the ECB-built reference
    // ========================================================================

    [Test]
    public void OfbMatchesReference([ValueSource(nameof(Ciphers))] CipherCase cipher)
    {
        foreach (int length in Lengths(cipher, includeEmpty: true))
        {
            AssertMatchesReference(cipher, CipherMode.OFB, feedbackBits: 0, length);
        }
    }

    [Test]
    public void CfbMatchesReference([ValueSource(nameof(Ciphers))] CipherCase cipher, [Values(8, 0)] int feedbackBits)
    {
        using SymmetricCipher probe = cipher.Create();
        int segmentBits = feedbackBits == 0 ? probe.BlockSize : feedbackBits;

        foreach (int length in Lengths(cipher, includeEmpty: true))
        {
            if (length % (segmentBits / 8) == 0)
                AssertMatchesReference(cipher, CipherMode.CFB, segmentBits, length);
        }
    }

    [Test]
    public void CtsMatchesReference([ValueSource(nameof(Ciphers))] CipherCase cipher)
    {
        using SymmetricCipher probe = cipher.Create();
        int bs = probe.BlockSize / 8;

        foreach (int length in Lengths(cipher, includeEmpty: false))
        {
            if (length >= bs)
                AssertMatchesReference(cipher, CipherMode.CTS, feedbackBits: 0, length);
        }
    }

    // ========================================================================
    // Streaming and edge cases
    // ========================================================================

    [Test]
    public void CtsStreamingMatchesOneShot(
        [ValueSource(nameof(Ciphers))] CipherCase cipher,
        [Values(true, false)] bool inPlace)
    {
        using SymmetricCipher c = CreateKeyed(cipher, CipherMode.CTS, PaddingMode.None, 0);
        int bs = c.BlockSize / 8;
        byte[] pt = Pattern(5 * bs + 3, 0x21);
        byte[] expected = c.Encrypt(pt);

        foreach (int chunkBlocks in new[] { 1, 2, 3 })
        {
            byte[] ct = StreamCts(c.CreateEncryptor(), pt, chunkBlocks * bs, inPlace);
            Assert.That(ct, Is.EqualTo(expected), $"encrypt, {chunkBlocks}-block chunks");

            byte[] decrypted = StreamCts(c.CreateDecryptor(), expected, chunkBlocks * bs, inPlace);
            Assert.That(decrypted, Is.EqualTo(pt), $"decrypt, {chunkBlocks}-block chunks");
        }
    }

    [Test]
    public void CtsRejectsInputShorterThanOneBlock([Values(0, 1, 15)] int length)
    {
        using var aes = CreateAes(CipherMode.CTS, PaddingMode.None, Sp80038aKey128, Sp80038aIv);
        byte[] input = new byte[length];

        Assert.Throws<OS.CryptographicException>(() => aes.Encrypt(input));
        Assert.Throws<OS.CryptographicException>(() => aes.Decrypt(input));
    }

    [Test]
    public void DecryptRejectsIncompleteBlock(
        [ValueSource(nameof(Ciphers))] CipherCase cipher,
        [Values(CipherMode.ECB, CipherMode.CBC)] CipherMode mode)
    {
        using SymmetricCipher c = CreateKeyed(cipher, mode, PaddingMode.PKCS7, 0);
        byte[] ct = c.Encrypt(Pattern(20, 0x05));

        Assert.Throws<OS.CryptographicException>(() => c.Decrypt(ct.AsSpan(0, ct.Length - 1)));
    }

    [Test]
    public void AnsiX923RejectsNonZeroFill()
    {
        using var aes = CreateAes(CipherMode.ECB, PaddingMode.None, Sp80038aKey128, Sp80038aIv);
        byte[] block = new byte[16];
        block[13] = 0x01;
        block[15] = 0x04;
        byte[] ct = aes.Encrypt(block);

        aes.Padding = PaddingMode.ANSIX923;

        Assert.Throws<OS.CryptographicException>(() => aes.Decrypt(ct));
    }

    [Test]
    public void ZerosPaddingAddsNothingToWholeBlocks([ValueSource(nameof(Ciphers))] CipherCase cipher)
    {
        using SymmetricCipher c = CreateKeyed(cipher, CipherMode.CBC, PaddingMode.Zeros, 0);
        int bs = c.BlockSize / 8;

        Assert.That(c.Encrypt(Pattern(2 * bs, 0x09)), Has.Length.EqualTo(2 * bs));
        Assert.That(c.Encrypt(Pattern(2 * bs + 1, 0x09)), Has.Length.EqualTo(3 * bs));
    }

    [Test]
    public void FeedbackSizeDefaultsToEightBits([ValueSource(nameof(Ciphers))] CipherCase cipher)
    {
        using SymmetricCipher c = cipher.Create();

        Assert.That(c.FeedbackSize, Is.EqualTo(8));
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static void AssertMatchesInBox(CipherMode mode, PaddingMode padding, int feedbackBits, int length)
    {
        byte[] key = Pattern(16, 0x01);
        byte[] iv = Pattern(16, 0x41);
        byte[] pt = Pattern(length, 0x77);

        using var ours = Aes128.Create();
        ours.Mode = mode;
        ours.Padding = padding;
        ours.FeedbackSize = feedbackBits;
        ours.Key = key;
        ours.IV = iv;

        using OS.Aes inBox = CreateInBoxAes((OS.CipherMode)(int)mode, (OS.PaddingMode)(int)padding, feedbackBits, key, iv);

        byte[] expectedCt;
        using (OS.ICryptoTransform encryptor = inBox.CreateEncryptor())
        {
            expectedCt = encryptor.TransformFinalBlock(pt, 0, pt.Length);
        }

        byte[] expectedPt;
        using (OS.ICryptoTransform decryptor = inBox.CreateDecryptor())
        {
            expectedPt = decryptor.TransformFinalBlock(expectedCt, 0, expectedCt.Length);
        }

        byte[] ct = ours.Encrypt(pt);

        Assert.That(ct, Is.EqualTo(expectedCt), "ciphertext");
        Assert.That(ours.Decrypt(ct), Is.EqualTo(expectedPt), "plaintext");
    }

    private static OS.Aes CreateInBoxAes(OS.CipherMode mode, OS.PaddingMode padding, int feedbackBits, byte[] key, byte[] iv)
    {
        var aes = OS.Aes.Create();
        aes.Mode = mode;
        aes.Padding = padding;
        aes.FeedbackSize = feedbackBits;
        aes.Key = key;
        aes.IV = iv;
        return aes;
    }

    private static void AssertMatchesReference(CipherCase cipher, CipherMode mode, int feedbackBits, int length)
    {
        using SymmetricCipher c = CreateKeyed(cipher, mode, PaddingMode.None, feedbackBits);
        byte[] pt = Pattern(length, 0x5A);

        byte[] ct = c.Encrypt(pt);
        byte[] expected = ReferenceEncrypt(cipher, c.Key, c.IV, mode, feedbackBits / 8, pt);

        Assert.That(ct, Is.EqualTo(expected), $"{cipher} {mode} length {length}");
        Assert.That(c.Decrypt(ct), Is.EqualTo(pt), $"{cipher} {mode} length {length} round trip");
    }

    /// <summary>
    /// Textbook OFB, CFB-s and CBC-CS3 over the cipher's single-block ECB encryption.
    /// </summary>
    private static byte[] ReferenceEncrypt(CipherCase cipher, byte[] key, byte[] iv, CipherMode mode, int segment, byte[] pt)
    {
        using SymmetricCipher ecb = cipher.Create();
        ecb.Mode = CipherMode.ECB;
        ecb.Padding = PaddingMode.None;
        ecb.Key = key;
        ecb.IV = new byte[ecb.IVSize];
        int bs = ecb.BlockSize / 8;
        Func<byte[], byte[]> e = block => ecb.Encrypt(block);

        byte[] ct = new byte[pt.Length];
        byte[] register = (byte[])iv.Clone();

        switch (mode)
        {
            case CipherMode.OFB:
                for (int offset = 0; offset < pt.Length; offset += bs)
                {
                    register = e(register);
                    for (int i = 0; i < bs && offset + i < pt.Length; i++)
                        ct[offset + i] = (byte)(pt[offset + i] ^ register[i]);
                }
                return ct;

            case CipherMode.CFB:
                for (int offset = 0; offset < pt.Length; offset += segment)
                {
                    byte[] keystream = e(register);
                    for (int i = 0; i < segment; i++)
                        ct[offset + i] = (byte)(pt[offset + i] ^ keystream[i]);

                    byte[] next = new byte[bs];
                    Buffer.BlockCopy(register, segment, next, 0, bs - segment);
                    Buffer.BlockCopy(ct, offset, next, bs - segment, segment);
                    register = next;
                }
                return ct;

            default:
                // CBC over the zero-padded message, then CS3: swap the last two blocks and
                // truncate what becomes the final one.
                int blocks = (pt.Length + bs - 1) / bs;
                byte[] cbc = new byte[blocks * bs];
                for (int b = 0; b < blocks; b++)
                {
                    byte[] x = new byte[bs];
                    for (int i = 0; i < bs; i++)
                    {
                        int p = b * bs + i;
                        x[i] = (byte)((p < pt.Length ? pt[p] : 0) ^ register[i]);
                    }

                    register = e(x);
                    Buffer.BlockCopy(register, 0, cbc, b * bs, bs);
                }

                if (blocks == 1)
                    return cbc;

                int lastLength = pt.Length - (blocks - 1) * bs;
                Buffer.BlockCopy(cbc, 0, ct, 0, (blocks - 2) * bs);
                Buffer.BlockCopy(cbc, (blocks - 1) * bs, ct, (blocks - 2) * bs, bs);
                Buffer.BlockCopy(cbc, (blocks - 2) * bs, ct, (blocks - 1) * bs, lastLength);
                return ct;
        }
    }

    private static byte[] StreamCts(ICipherTransform transform, byte[] input, int chunk, bool inPlace)
    {
        using (transform)
        {
            byte[] buffer = (byte[])input.Clone();
            byte[] output = inPlace ? buffer : new byte[input.Length];
            int read = 0;
            int written = 0;

            while (input.Length - read > chunk)
            {
                written += transform.TransformBlock(buffer, read, chunk, output, written);
                read += chunk;
            }

            written += transform.TransformFinalBlock(buffer.AsSpan(read), output.AsSpan(written));
            Assert.That(written, Is.EqualTo(input.Length));
            return output;
        }
    }

    private static IEnumerable<int> Lengths(CipherCase cipher, bool includeEmpty)
    {
        using SymmetricCipher probe = cipher.Create();
        int bs = probe.BlockSize / 8;

        if (includeEmpty)
            yield return 0;

        foreach (int length in new[] { 1, bs - 1, bs, bs + 1, 2 * bs - 1, 2 * bs, 2 * bs + 1, 3 * bs, 3 * bs + 7, 5 * bs - 1 })
            yield return length;
    }

    private static SymmetricCipher CreateKeyed(CipherCase cipher, CipherMode mode, PaddingMode padding, int feedbackBits)
    {
        SymmetricCipher c = cipher.Create();
        c.Mode = mode;
        c.Padding = padding;
        if (feedbackBits != 0)
            c.FeedbackSize = feedbackBits;
        c.Key = Pattern(cipher.KeyBytes, 0x11);
        c.IV = Pattern(c.IVSize, 0xA0);
        return c;
    }

    private static Aes128 CreateAes(CipherMode mode, PaddingMode padding, string keyHex, string ivHex)
    {
        var aes = Aes128.Create();
        aes.Mode = mode;
        aes.Padding = padding;
        aes.Key = FromHex(keyHex);
        aes.IV = FromHex(ivHex);
        return aes;
    }

    private static byte[] Pattern(int length, byte seed)
    {
        byte[] data = new byte[length];
        for (int i = 0; i < length; i++)
            data[i] = unchecked((byte)(seed + i * 7));
        return data;
    }

    private static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        return bytes;
    }
}
