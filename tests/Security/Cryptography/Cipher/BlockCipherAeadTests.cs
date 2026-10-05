// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Cipher;

using Cryptography.Tests.Adapter.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using BC = Org.BouncyCastle.Crypto;
using OS = System.Security.Cryptography;
using IAeadCipher = CryptoHives.Foundation.Security.Cryptography.Cipher.IAeadCipher;

/// <summary>
/// GCM and CCM over the non-AES 128-bit block ciphers: known answers, and the parameter ranges
/// the registry-driven cross-validation does not reach (it runs 12-byte nonces and 16-byte tags only).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BlockCipherAeadTests
{
    // RFC 8998 Appendix A.1 and A.2 share key, IV, associated data and plaintext.
    private const string Rfc8998Key = "0123456789ABCDEFFEDCBA9876543210";
    private const string Rfc8998Iv = "00001234567800000000ABCD";
    private const string Rfc8998Aad = "FEEDFACEDEADBEEFFEEDFACEDEADBEEFABADDAD2";
    private const string Rfc8998Plaintext =
        "AAAAAAAAAAAAAAAABBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCDDDDDDDDDDDDDDDD" +
        "EEEEEEEEEEEEEEEEFFFFFFFFFFFFFFFFEEEEEEEEEEEEEEEEAAAAAAAAAAAAAAAA";

    [Test]
    public void Sm4Gcm_Rfc8998_EveryImplementation()
    {
        byte[] expectedCiphertext = FromHex(
            "17F399F08C67D5EE19D0DC9969C4BB7D5FD46FD3756489069157B282BB200735" +
            "D82710CA5C22F0CCFA7CBF93D496AC15A56834CBCF98C397B4024A2691233B8D");
        byte[] expectedTag = FromHex("83DE3541E4C2B58177E065A9BF7B62EC");

        foreach (CipherAlgorithmRegistry.CipherImplementation impl in CipherAlgorithmRegistry.ByFamily("SM4-GCM"))
        {
            using var gcm = (IAeadCipher)impl.Create(FromHex(Rfc8998Key));
            AssertKnownAnswer(gcm, expectedCiphertext, expectedTag, impl.Name);
        }
    }

    [Test]
    public void Sm4Ccm_Rfc8998()
    {
        byte[] expectedCiphertext = FromHex(
            "48AF93501FA62ADBCD414CCE6034D895DDA1BF8F132F042098661572E7483094" +
            "FD12E518CE062C98ACEE28D95DF4416BED31A2F04476C18BB40C84A74B97DC5B");
        byte[] expectedTag = FromHex("16842D4FA186F56AB33256971FA110F4");

        using var ccm = Sm4Ccm.Create(FromHex(Rfc8998Key));
        AssertKnownAnswer(ccm, expectedCiphertext, expectedTag);
    }

    /// <summary>
    /// A nonce other than 96 bits takes the GHASH-derived J0 path.
    /// </summary>
    [Test]
    public void Gcm_NonStandardNonceLengths_MatchReference(
        [ValueSource(nameof(GcmCases))] AeadCase gcmCase,
        [Values(1, 8, 16, 60)] int nonceLength)
    {
        var rng = new Random(nonceLength * 31 + gcmCase.KeySizeBytes);
        byte[] key = Random(rng, gcmCase.KeySizeBytes);
        byte[] nonce = Random(rng, nonceLength);
        byte[] aad = Random(rng, 21);
        byte[] plaintext = Random(rng, 77);

        using IAeadCipher ours = gcmCase.Create(key);
        byte[] actual = ours.Encrypt(nonce, plaintext, aad);
        byte[] expected = ReferenceEncrypt(new GcmBlockCipher(gcmCase.Engine()), key, nonce, aad, plaintext, 128);

        Assert.That(actual, Is.EqualTo(expected), $"{ours.AlgorithmName} nonce length {nonceLength}");
        Assert.That(ours.Decrypt(nonce, actual, aad), Is.EqualTo(plaintext));
    }

    [Test]
    public void Ccm_AllNonceAndTagLengths_MatchReference(
        [ValueSource(nameof(CcmCases))] AeadCase ccmCase,
        [Values(7, 8, 10, 12, 13)] int nonceLength,
        [Values(4, 6, 8, 10, 12, 14, 16)] int tagLength)
    {
        var rng = new Random(nonceLength * 97 + tagLength);
        byte[] key = Random(rng, ccmCase.KeySizeBytes);
        byte[] nonce = Random(rng, nonceLength);
        byte[] aad = Random(rng, 300); // past the two-byte AAD length encoding's first block
        byte[] plaintext = Random(rng, 45);

        using IAeadCipher ours = ccmCase.Create(key);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[tagLength];
        ours.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        byte[] expected = ReferenceEncrypt(new CcmBlockCipher(ccmCase.Engine()), key, nonce, aad, plaintext, tagLength * 8);
        Assert.That(Concat(ciphertext, tag), Is.EqualTo(expected), $"{ours.AlgorithmName} nonce {nonceLength} tag {tagLength}");

        byte[] decrypted = new byte[plaintext.Length];
        Assert.That(ours.Decrypt(nonce, ciphertext, tag, decrypted, aad), Is.True);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void TamperedTag_FailsAndClearsPlaintext(
        [ValueSource(nameof(AllCases))] AeadCase aeadCase)
    {
        var rng = new Random(7);
        byte[] key = Random(rng, aeadCase.KeySizeBytes);
        byte[] nonce = Random(rng, 12);
        byte[] plaintext = Random(rng, 40);

        using IAeadCipher cipher = aeadCase.Create(key);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[cipher.TagSizeBytes];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag);
        tag[0] ^= 1;

        byte[] decrypted = Random(rng, plaintext.Length);
        Assert.That(cipher.Decrypt(nonce, ciphertext, tag, decrypted), Is.False);
        Assert.That(decrypted, Is.All.EqualTo(0));

        byte[] withTag = Concat(ciphertext, tag);
        Assert.Throws<OS.CryptographicException>(() => cipher.Decrypt(nonce, withTag));
    }

    [Test]
    public void DisposedCipher_Throws([ValueSource(nameof(AllCases))] AeadCase aeadCase)
    {
        IAeadCipher cipher = aeadCase.Create(new byte[aeadCase.KeySizeBytes]);
        cipher.Dispose();

        Assert.Throws<ObjectDisposedException>(() => cipher.Encrypt(new byte[12], new byte[16]));
        Assert.Throws<ObjectDisposedException>(() => cipher.Decrypt(new byte[12], new byte[32]));
    }

    [Test]
    public void AlgorithmNameAndKeySize([ValueSource(nameof(AllCases))] AeadCase aeadCase)
    {
        using IAeadCipher cipher = aeadCase.Create(new byte[aeadCase.KeySizeBytes]);

        Assert.That(cipher.AlgorithmName, Is.EqualTo(aeadCase.Family));
        Assert.That(cipher.KeySizeBytes, Is.EqualTo(aeadCase.KeySizeBytes));
        Assert.That(cipher.TagSizeBytes, Is.EqualTo(16));
        Assert.That(cipher.NonceSizeBytes, Is.EqualTo(12));
    }

    [TestCase(0)]
    [TestCase(15)]
    [TestCase(17)]
    [TestCase(20)]
    [TestCase(64)]
    public void WrongKeySize_Throws(int keyLength)
    {
        byte[] key = new byte[keyLength];

        Assert.Throws<ArgumentException>(() => Sm4Gcm.Create(key));
        Assert.Throws<ArgumentException>(() => Sm4Ccm.Create(key));
        Assert.Throws<ArgumentException>(() => SeedGcm.Create(key));
        Assert.Throws<ArgumentException>(() => KuznyechikGcm.Create(key));
        Assert.Throws<ArgumentException>(() => AriaGcm.Create(key));
        Assert.Throws<ArgumentException>(() => AriaCcm.Create(key));
        Assert.Throws<ArgumentException>(() => CamelliaGcm.Create(key));
        Assert.Throws<ArgumentException>(() => CamelliaCcm.Create(key));
    }

    public sealed class AeadCase(CipherAlgorithmRegistry.CipherImplementation implementation, Func<BC.IBlockCipher> engine)
    {
        public string Name => implementation.Name;

        public string Family => implementation.AlgorithmFamily;

        public int KeySizeBytes => implementation.KeySizeBits / 8;

        public IAeadCipher Create(byte[] key) => (IAeadCipher)implementation.Create(key);

        public Func<BC.IBlockCipher> Engine { get; } = engine;

        public override string ToString() => Name;
    }

    // BouncyCastle engines for the reference side, keyed by the cipher name that prefixes each
    // registry family; they take nonce and tag lengths the registry's own references do not.
    private static readonly Dictionary<string, Func<BC.IBlockCipher>> ReferenceEngines = new(StringComparer.Ordinal)
    {
        ["ARIA"] = () => new AriaEngine(),
        ["Camellia"] = () => new CamelliaEngine(),
        ["SM4"] = () => new SM4Engine(),
        ["SEED"] = () => new SeedEngine(),
        ["Kuznyechik"] = () => new OpenGostKuznyechikEngine(),
    };

    public static IEnumerable<AeadCase> GcmCases() => RegistryCases(CipherAlgorithmRegistry.Mode.GCM);

    public static IEnumerable<AeadCase> CcmCases() => RegistryCases(CipherAlgorithmRegistry.Mode.CCM);

    private static IEnumerable<AeadCase> RegistryCases(CipherAlgorithmRegistry.Mode mode)
    {
        return CipherAlgorithmRegistry.ByMode(mode)
            .Select(impl => new
            {
                impl,
                found = ReferenceEngines.TryGetValue(impl.AlgorithmFamily.Split('-')[0], out Func<BC.IBlockCipher>? engine),
                engine,
            })
            .Where(x => x.impl.SimdSupport is not null && x.found)
            .Select(x => new AeadCase(x.impl, x.engine!));
    }

    public static IEnumerable<AeadCase> AllCases()
    {
        foreach (AeadCase c in GcmCases())
            yield return c;
        foreach (AeadCase c in CcmCases())
            yield return c;
    }

    private static void AssertKnownAnswer(IAeadCipher cipher, byte[] expectedCiphertext, byte[] expectedTag, string name = "")
    {
        byte[] nonce = FromHex(Rfc8998Iv);
        byte[] aad = FromHex(Rfc8998Aad);
        byte[] plaintext = FromHex(Rfc8998Plaintext);

        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];
        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        Assert.That(ciphertext, Is.EqualTo(expectedCiphertext), $"{name} ciphertext mismatch");
        Assert.That(tag, Is.EqualTo(expectedTag), $"{name} tag mismatch");

        byte[] decrypted = new byte[plaintext.Length];
        Assert.That(cipher.Decrypt(nonce, expectedCiphertext, expectedTag, decrypted, aad), Is.True);
        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    private static byte[] ReferenceEncrypt(
        IAeadBlockCipher cipher, byte[] key, byte[] nonce, byte[] aad, byte[] plaintext, int macSizeBits)
    {
        cipher.Init(true, new AeadParameters(new KeyParameter(key), macSizeBits, nonce, aad));
        byte[] output = new byte[cipher.GetOutputSize(plaintext.Length)];
        int written = cipher.ProcessBytes(plaintext, 0, plaintext.Length, output, 0);
        written += cipher.DoFinal(output, written);
        Array.Resize(ref output, written);
        (cipher.UnderlyingCipher as IDisposable)?.Dispose();
        return output;
    }

    private static byte[] Concat(byte[] a, byte[] b)
    {
        byte[] result = new byte[a.Length + b.Length];
        a.CopyTo(result, 0);
        b.CopyTo(result, a.Length);
        return result;
    }

    private static byte[] Random(Random rng, int length)
    {
        byte[] bytes = new byte[length];
        rng.NextBytes(bytes);
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
}
