// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Cipher.Kuznyechik;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using IAeadCipher = CryptoHives.Foundation.Security.Cryptography.Cipher.IAeadCipher;
using OS = System.Security.Cryptography;

/// <summary>
/// Kuznyechik-MGM (RFC 9058) on every SIMD tier of the field multiply.
/// </summary>
/// <remarks>
/// No .NET library implements MGM. Besides the two RFC 9058 Appendix A.1 examples, the
/// reference is <c>mgm-kuznyechik.json.gz</c>, written by <c>scripts/generate-mgm-vectors.py</c>
/// from an independent Python MGM that reproduces both RFC examples before it writes anything.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KuznyechikMgmTests
{
    private const string VectorResource = "Cryptography.Tests.TestData.mgm-kuznyechik.json.gz";

    private static readonly Lazy<Vector[]> Vectors = new(LoadVectors);

    public static IEnumerable<CipherAlgorithmRegistry.CipherImplementation> Implementations()
        => CipherAlgorithmRegistry.ByFamily("Kuznyechik-MGM");

    [TestCaseSource(nameof(Implementations))]
    public void KuznyechikMgm_Rfc9058AppendixA1_Example1(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        AssertVector(impl, new Vector(
            key: "8899AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF",
            nonce: "1122334455667700FFEEDDCCBBAA9988",
            aad: "0202020202020202010101010101010104040404040404040303030303030303EA0505050505050505",
            plaintext: "1122334455667700FFEEDDCCBBAA998800112233445566778899AABBCCEEFF0A" +
                       "112233445566778899AABBCCEEFF0A002233445566778899AABBCCEEFF0A0011AABBCC",
            ciphertext: "A9757B8147956E9055B8A33DE89F42FC8075D2212BF9FD5BD3F7069AADC16B39" +
                        "497AB15915A6BA85936B5D0EA9F6851CC60C14D4D3F883D0AB94420695C76DEB2C7552",
            tag: "CF5D656F40C34F5C46E8BB0E29FCDB4C"));
    }

    [TestCaseSource(nameof(Implementations))]
    public void KuznyechikMgm_Rfc9058AppendixA1_Example2(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        AssertVector(impl, new Vector(
            key: "99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88",
            nonce: "1122334455667700FFEEDDCCBBAA9988",
            aad: "01010101010101010101010101010101",
            plaintext: "",
            ciphertext: "",
            tag: "7901E9EA2085CD247ED249695F9F8A85"));
    }

    [TestCaseSource(nameof(Implementations))]
    public void KuznyechikMgm_GeneratedVectors(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        foreach (Vector vector in Vectors.Value)
        {
            AssertVector(impl, vector);
        }
    }

    [TestCaseSource(nameof(Implementations))]
    public void TruncatedTagIsPrefixOfFullTag(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        byte[] key = Bytes(32, 1);
        byte[] nonce = Nonce(2);
        byte[] plaintext = Bytes(40, 3);
        using var cipher = (IAeadCipher)impl.Create(key);

        byte[] full = new byte[16];
        cipher.Encrypt(nonce, plaintext, new byte[plaintext.Length], full);

        for (int tagLength = 4; tagLength < 16; tagLength++)
        {
            byte[] ciphertext = new byte[plaintext.Length];
            byte[] tag = new byte[tagLength];
            cipher.Encrypt(nonce, plaintext, ciphertext, tag);
            Assert.That(tag, Is.EqualTo(full.Take(tagLength).ToArray()), $"tag length {tagLength}");

            byte[] decrypted = new byte[plaintext.Length];
            Assert.That(cipher.Decrypt(nonce, ciphertext, tag, decrypted), Is.True, $"tag length {tagLength}");
            Assert.That(decrypted, Is.EqualTo(plaintext));
        }
    }

    [TestCaseSource(nameof(Implementations))]
    public void TamperedInputFailsAndClearsPlaintext(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        byte[] nonce = Nonce(5);
        byte[] aad = Bytes(19, 6);
        byte[] plaintext = Bytes(33, 7);
        using var cipher = (IAeadCipher)impl.Create(Bytes(32, 4));

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        void AssertRejected(byte[] n, byte[] c, byte[] t, byte[] a, string what)
        {
            byte[] decrypted = Bytes(c.Length, 8);
            Assert.That(cipher.Decrypt(n, c, t, decrypted, a), Is.False, what);
            Assert.That(decrypted, Is.All.EqualTo(0), what);
        }

        AssertRejected(nonce, ciphertext, Flip(tag, 15), aad, "tag");
        AssertRejected(nonce, Flip(ciphertext, 32), tag, aad, "ciphertext");
        AssertRejected(nonce, ciphertext, tag, Flip(aad, 0), "associated data");
        AssertRejected(Flip(nonce, 15), ciphertext, tag, aad, "nonce");
        Assert.Throws<OS.CryptographicException>(() => cipher.Decrypt(nonce, [.. ciphertext, .. Flip(tag, 0)], aad));
    }

    [Test]
    public void InPlaceEncryptAndDecrypt()
    {
        byte[] nonce = Nonce(9);
        byte[] plaintext = Bytes(50, 10);
        using var cipher = KuznyechikMgm.Create(Bytes(32, 11));

        byte[] expected = cipher.Encrypt(nonce, plaintext);

        byte[] buffer = (byte[])plaintext.Clone();
        byte[] tag = new byte[16];
        cipher.Encrypt(nonce, buffer, buffer, tag);
        Assert.That(buffer.Concat(tag), Is.EqualTo(expected));

        Assert.That(cipher.Decrypt(nonce, buffer, tag, buffer), Is.True);
        Assert.That(buffer, Is.EqualTo(plaintext));
    }

    [Test]
    public void InvalidParametersThrow()
    {
        using var cipher = KuznyechikMgm.Create(Bytes(32, 12));
        byte[] data = Bytes(16, 13);
        byte[] output = new byte[16];

        byte[] topBitSet = Nonce(14);
        topBitSet[0] |= 0x80;
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(topBitSet, data, output, new byte[16]));
        Assert.Throws<ArgumentException>(() => cipher.Decrypt(topBitSet, data, new byte[16], output));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(new byte[12], data, output, new byte[16]));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(15), data, output, new byte[3]));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(15), data, output, new byte[17]));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(15), [], [], new byte[16]));
        Assert.Throws<ArgumentException>(() => cipher.Decrypt(Nonce(15), [], new byte[16], []));
    }

    [TestCase(0)]
    [TestCase(16)]
    [TestCase(31)]
    [TestCase(33)]
    public void WrongKeySizeThrows(int keyLength)
    {
        Assert.Throws<ArgumentException>(() => KuznyechikMgm.Create(new byte[keyLength]));
    }

    [Test]
    public void DisposedCipherThrows()
    {
        var cipher = KuznyechikMgm.Create(new byte[32]);
        cipher.Dispose();

        Assert.Throws<ObjectDisposedException>(() => cipher.Encrypt(Nonce(16), new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => cipher.Decrypt(Nonce(16), new byte[32]));
    }

    [Test]
    public void AlgorithmNameAndSizes()
    {
        using var cipher = KuznyechikMgm.Create(new byte[32]);

        Assert.That(cipher.AlgorithmName, Is.EqualTo("Kuznyechik-MGM"));
        Assert.That(cipher.KeySizeBytes, Is.EqualTo(32));
        Assert.That(cipher.NonceSizeBytes, Is.EqualTo(16));
        Assert.That(cipher.TagSizeBytes, Is.EqualTo(16));
    }

    private static void AssertVector(CipherAlgorithmRegistry.CipherImplementation impl, Vector vector)
    {
        byte[] nonce = FromHex(vector.Nonce);
        byte[] aad = FromHex(vector.Aad);
        byte[] plaintext = FromHex(vector.Plaintext);
        byte[] expectedCiphertext = FromHex(vector.Ciphertext);
        byte[] expectedTag = FromHex(vector.Tag);
        using var cipher = (IAeadCipher)impl.Create(FromHex(vector.Key));

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[expectedTag.Length];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);
        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), $"{impl.Name} ciphertext, nonce {vector.Nonce}");
        Assert.That(tag, Is.EqualTo(expectedTag), $"{impl.Name} tag, nonce {vector.Nonce}");

        byte[] decrypted = new byte[plaintext.Length];
        Assert.That(cipher.Decrypt(nonce, expectedCiphertext, expectedTag, decrypted, aad), Is.True, $"{impl.Name} decrypt, nonce {vector.Nonce}");
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    private static Vector[] LoadVectors()
    {
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(VectorResource)
            ?? throw new InvalidOperationException($"Embedded resource {VectorResource} not found.");
        using var gzip = new GZipStream(stream, CompressionMode.Decompress);
        using JsonDocument document = JsonDocument.Parse(gzip);

        return [.. document.RootElement.GetProperty("tests").EnumerateArray().Select(test => new Vector(
            test.GetProperty("key").GetString()!,
            test.GetProperty("nonce").GetString()!,
            test.GetProperty("aad").GetString()!,
            test.GetProperty("pt").GetString()!,
            test.GetProperty("ct").GetString()!,
            test.GetProperty("tag").GetString()!))];
    }

    private static byte[] Flip(byte[] data, int index)
    {
        byte[] copy = (byte[])data.Clone();
        copy[index] ^= 1;
        return copy;
    }

    private static byte[] Nonce(int seed)
    {
        byte[] nonce = Bytes(16, seed);
        nonce[0] &= 0x7F;
        return nonce;
    }

    private static byte[] Bytes(int length, int seed)
    {
        byte[] bytes = new byte[length];
        new Random(seed).NextBytes(bytes);
        return bytes;
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

    private sealed class Vector(string key, string nonce, string aad, string plaintext, string ciphertext, string tag)
    {
        public string Key { get; } = key;

        public string Nonce { get; } = nonce;

        public string Aad { get; } = aad;

        public string Plaintext { get; } = plaintext;

        public string Ciphertext { get; } = ciphertext;

        public string Tag { get; } = tag;
    }
}
