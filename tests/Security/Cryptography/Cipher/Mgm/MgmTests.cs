// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Cipher.Mgm;

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
/// Kuznyechik-MGM and Magma-MGM (RFC 9058) on every SIMD tier of the field multiply.
/// </summary>
/// <remarks>
/// No .NET library implements MGM. Besides the four RFC 9058 Appendix A examples, the reference
/// is the <c>mgm-*.json.gz</c> vectors written by <c>scripts/generate-mgm-vectors.py</c> from an
/// independent Python MGM that reproduces all four RFC examples before it writes anything.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MgmTests
{
    private static readonly MgmFamily Kuznyechik = new(
        "Kuznyechik-MGM", blockSize: 16, "Cryptography.Tests.TestData.mgm-kuznyechik.json.gz",
        key => KuznyechikMgm.Create(key),
        [
            new Vector(
                key: "8899AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF",
                nonce: "1122334455667700FFEEDDCCBBAA9988",
                aad: "0202020202020202010101010101010104040404040404040303030303030303EA0505050505050505",
                plaintext: "1122334455667700FFEEDDCCBBAA998800112233445566778899AABBCCEEFF0A" +
                           "112233445566778899AABBCCEEFF0A002233445566778899AABBCCEEFF0A0011AABBCC",
                ciphertext: "A9757B8147956E9055B8A33DE89F42FC8075D2212BF9FD5BD3F7069AADC16B39" +
                            "497AB15915A6BA85936B5D0EA9F6851CC60C14D4D3F883D0AB94420695C76DEB2C7552",
                tag: "CF5D656F40C34F5C46E8BB0E29FCDB4C"),
            new Vector(
                key: "99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88",
                nonce: "1122334455667700FFEEDDCCBBAA9988",
                aad: "01010101010101010101010101010101",
                plaintext: "",
                ciphertext: "",
                tag: "7901E9EA2085CD247ED249695F9F8A85"),
        ]);

    private static readonly MgmFamily Magma = new(
        "Magma-MGM", blockSize: 8, "Cryptography.Tests.TestData.mgm-magma.json.gz",
        key => MagmaMgm.Create(key),
        [
            new Vector(
                key: "FFEEDDCCBBAA99887766554433221100F0F1F2F3F4F5F6F7F8F9FAFBFCFDFEFF",
                nonce: "12DEF06B3C130A59",
                aad: "01010101010101010202020202020202030303030303030304040404040404040505050505050505EA",
                plaintext: "FFEEDDCCBBAA998811223344556677008899AABBCCEEFF0A0011223344556677" +
                           "99AABBCCEEFF0A001122334455667788AABBCCEEFF0A00112233445566778899AABBCC",
                ciphertext: "C795066C5F9EA03B85113342459185AE1F2E00D6BF2B785D940470B8BB9C8E7D" +
                            "9A5DD3731F7DDC70EC27CB0ACE6FA57670F65C646ABB75D547AA37C3BCB5C34E03BB9C",
                tag: "A7928069AA10FD10"),
            new Vector(
                key: "99AABBCCDDEEFF0011223344556677FEDCBA98765432100123456789ABCDEF88",
                nonce: "0077665544332211",
                aad: "",
                plaintext: "22334455667700FF",
                ciphertext: "6A95E1426B259D4E",
                tag: "334EE270450BEC9E"),
        ]);

    private static readonly MgmFamily[] Families = [Kuznyechik, Magma];

    public static IEnumerable<MgmCase> Cases()
        => Families.SelectMany(family => CipherAlgorithmRegistry.ByFamily(family.Name).Select(impl => new MgmCase(family, impl)));

    public static IEnumerable<MgmFamily> AllFamilies() => Families;

    [TestCaseSource(nameof(Cases))]
    public void Rfc9058AppendixA_Examples(MgmCase mgmCase)
    {
        foreach (Vector vector in mgmCase.Family.RfcExamples)
        {
            AssertVector(mgmCase, vector);
        }
    }

    [TestCaseSource(nameof(Cases))]
    public void GeneratedVectors(MgmCase mgmCase)
    {
        foreach (Vector vector in mgmCase.Family.GeneratedVectors)
        {
            AssertVector(mgmCase, vector);
        }
    }

    [TestCaseSource(nameof(Cases))]
    public void TruncatedTagIsPrefixOfFullTag(MgmCase mgmCase)
    {
        int block = mgmCase.Family.BlockSize;
        byte[] nonce = Nonce(block, 2);
        byte[] plaintext = Bytes(40, 3);
        using IAeadCipher cipher = mgmCase.Create(Bytes(32, 1));

        byte[] full = new byte[block];
        cipher.Encrypt(nonce, plaintext, new byte[plaintext.Length], full);

        for (int tagLength = 4; tagLength < block; tagLength++)
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

    [TestCaseSource(nameof(Cases))]
    public void TamperedInputFailsAndClearsPlaintext(MgmCase mgmCase)
    {
        int block = mgmCase.Family.BlockSize;
        byte[] nonce = Nonce(block, 5);
        byte[] aad = Bytes(19, 6);
        byte[] plaintext = Bytes(33, 7);
        using IAeadCipher cipher = mgmCase.Create(Bytes(32, 4));

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[block];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        void AssertRejected(byte[] n, byte[] c, byte[] t, byte[] a, string what)
        {
            byte[] decrypted = Bytes(c.Length, 8);
            Assert.That(cipher.Decrypt(n, c, t, decrypted, a), Is.False, what);
            Assert.That(decrypted, Is.All.EqualTo(0), what);
        }

        AssertRejected(nonce, ciphertext, Flip(tag, block - 1), aad, "tag");
        AssertRejected(nonce, Flip(ciphertext, 32), tag, aad, "ciphertext");
        AssertRejected(nonce, ciphertext, tag, Flip(aad, 0), "associated data");
        AssertRejected(Flip(nonce, block - 1), ciphertext, tag, aad, "nonce");
        Assert.Throws<OS.CryptographicException>(() => cipher.Decrypt(nonce, [.. ciphertext, .. Flip(tag, 0)], aad));
    }

    [TestCaseSource(nameof(AllFamilies))]
    public void InPlaceEncryptAndDecrypt(MgmFamily family)
    {
        byte[] nonce = Nonce(family.BlockSize, 9);
        byte[] plaintext = Bytes(50, 10);
        using IAeadCipher cipher = family.Create(Bytes(32, 11));

        byte[] expected = cipher.Encrypt(nonce, plaintext);

        byte[] buffer = (byte[])plaintext.Clone();
        byte[] tag = new byte[family.BlockSize];
        cipher.Encrypt(nonce, buffer, buffer, tag);
        Assert.That(buffer.Concat(tag), Is.EqualTo(expected));

        Assert.That(cipher.Decrypt(nonce, buffer, tag, buffer), Is.True);
        Assert.That(buffer, Is.EqualTo(plaintext));
    }

    [TestCaseSource(nameof(AllFamilies))]
    public void InvalidParametersThrow(MgmFamily family)
    {
        int block = family.BlockSize;
        using IAeadCipher cipher = family.Create(Bytes(32, 12));
        byte[] data = Bytes(16, 13);
        byte[] output = new byte[16];
        byte[] tag = new byte[block];

        byte[] topBitSet = Nonce(block, 14);
        topBitSet[0] |= 0x80;
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(topBitSet, data, output, tag));
        Assert.Throws<ArgumentException>(() => cipher.Decrypt(topBitSet, data, tag, output));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(new byte[12], data, output, tag));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(block, 15), data, output, new byte[3]));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(block, 15), data, output, new byte[block + 1]));
        Assert.Throws<ArgumentException>(() => cipher.Encrypt(Nonce(block, 15), [], [], tag));
        Assert.Throws<ArgumentException>(() => cipher.Decrypt(Nonce(block, 15), [], tag, []));
    }

    [Test]
    public void WrongKeySizeThrows([ValueSource(nameof(AllFamilies))] MgmFamily family, [Values(0, 16, 31, 33)] int keyLength)
    {
        Assert.Throws<ArgumentException>(() => family.Create(new byte[keyLength]));
    }

    [TestCaseSource(nameof(AllFamilies))]
    public void DisposedCipherThrows(MgmFamily family)
    {
        IAeadCipher cipher = family.Create(new byte[32]);
        cipher.Dispose();

        Assert.Throws<ObjectDisposedException>(() => cipher.Encrypt(Nonce(family.BlockSize, 16), new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => cipher.Decrypt(Nonce(family.BlockSize, 16), new byte[32]));
    }

    [TestCaseSource(nameof(AllFamilies))]
    public void AlgorithmNameAndSizes(MgmFamily family)
    {
        using IAeadCipher cipher = family.Create(new byte[32]);

        Assert.That(cipher.AlgorithmName, Is.EqualTo(family.Name));
        Assert.That(cipher.KeySizeBytes, Is.EqualTo(32));
        Assert.That(cipher.NonceSizeBytes, Is.EqualTo(family.BlockSize));
        Assert.That(cipher.TagSizeBytes, Is.EqualTo(family.BlockSize));
    }

    private static void AssertVector(MgmCase mgmCase, Vector vector)
    {
        byte[] nonce = FromHex(vector.Nonce);
        byte[] aad = FromHex(vector.Aad);
        byte[] plaintext = FromHex(vector.Plaintext);
        byte[] expectedCiphertext = FromHex(vector.Ciphertext);
        byte[] expectedTag = FromHex(vector.Tag);
        using IAeadCipher cipher = mgmCase.Create(FromHex(vector.Key));

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[expectedTag.Length];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);
        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), $"{mgmCase} ciphertext, nonce {vector.Nonce}");
        Assert.That(tag, Is.EqualTo(expectedTag), $"{mgmCase} tag, nonce {vector.Nonce}");

        byte[] decrypted = new byte[plaintext.Length];
        Assert.That(cipher.Decrypt(nonce, expectedCiphertext, expectedTag, decrypted, aad), Is.True, $"{mgmCase} decrypt, nonce {vector.Nonce}");
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    private static byte[] Flip(byte[] data, int index)
    {
        byte[] copy = (byte[])data.Clone();
        copy[index] ^= 1;
        return copy;
    }

    private static byte[] Nonce(int length, int seed)
    {
        byte[] nonce = Bytes(length, seed);
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

    public sealed class MgmFamily(string name, int blockSize, string vectorResource, Func<byte[], IAeadCipher> create, Vector[] rfcExamples)
    {
        private readonly Lazy<Vector[]> _generatedVectors = new(() => LoadVectors(vectorResource));

        public string Name { get; } = name;

        public int BlockSize { get; } = blockSize;

        public IReadOnlyList<Vector> RfcExamples { get; } = rfcExamples;

        public IReadOnlyList<Vector> GeneratedVectors => _generatedVectors.Value;

        public IAeadCipher Create(byte[] key) => create(key);

        public override string ToString() => Name;

        private static Vector[] LoadVectors(string resource)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)
                ?? throw new InvalidOperationException($"Embedded resource {resource} not found.");
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
    }

    public sealed class MgmCase(MgmFamily family, CipherAlgorithmRegistry.CipherImplementation implementation)
    {
        public MgmFamily Family { get; } = family;

        public IAeadCipher Create(byte[] key) => (IAeadCipher)implementation.Create(key);

        public override string ToString() => implementation.Name;
    }

    public sealed class Vector(string key, string nonce, string aad, string plaintext, string ciphertext, string tag)
    {
        public string Key { get; } = key;

        public string Nonce { get; } = nonce;

        public string Aad { get; } = aad;

        public string Plaintext { get; } = plaintext;

        public string Ciphertext { get; } = ciphertext;

        public string Tag { get; } = tag;
    }
}
