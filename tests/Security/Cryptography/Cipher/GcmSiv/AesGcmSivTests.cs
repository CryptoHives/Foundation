// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.GcmSiv;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using CryptographicException = System.Security.Cryptography.CryptographicException;

/// <summary>
/// AES-GCM-SIV (RFC 8452): known answers on every SIMD tier, POLYVAL on its own, agreement with
/// BouncyCastle, and the nonce-misuse behaviour the mode exists for.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AesGcmSivTests
{
    // key, nonce, aad, plaintext, ciphertext ‖ tag. RFC 8452 Appendix C, the counter-wrap cases of
    // C.3 included; each was reproduced with an independent implementation before being added.
    private static readonly string[][] Rfc8452Vectors =
    [
        ["01000000000000000000000000000000", "030000000000000000000000", "", "",
            "dc20e2d83f25705bb49e439eca56de25"],
        ["01000000000000000000000000000000", "030000000000000000000000", "", "0100000000000000",
            "b5d839330ac7b786578782fff6013b815b287c22493a364c"],
        ["01000000000000000000000000000000", "030000000000000000000000", "", "010000000000000000000000",
            "7323ea61d05932260047d942a4978db357391a0bc4fdec8b0d106639"],
        ["ee8e1ed9ff2540ae8f2ba9f50bc2f27c", "752abad3e0afb5f434dc4310", "6578616d706c65", "48656c6c6f20776f726c64",
            "5d349ead175ef6b1def6fd4fbcdeb7e4793f4a1d7e4faa70100af1"],
        ["0100000000000000000000000000000000000000000000000000000000000000", "030000000000000000000000", "", "",
            "07f5f4169bbf55a8400cd47ea6fd400f"],
        ["e66021d5eb8e4f4066d4adb9c33560e4f46e44bb3da0015c94f7088736864200", "752abad3e0afb5f434dc4310", "6578616d706c65", "48656c6c6f20776f726c64",
            "d24443c4f329028931c5db297d5d43d04af0a0b808b337c4053dee"],
        ["0000000000000000000000000000000000000000000000000000000000000000", "000000000000000000000000", "",
            "000000000000000000000000000000004db923dc793ee6497c76dcc03a98e108",
            "f3f80f2cf0cb2dd9c5984fcda908456cc537703b5ba70324a6793a7bf218d3eaffffffff000000000000000000000000"],
        ["0000000000000000000000000000000000000000000000000000000000000000", "000000000000000000000000", "",
            "eb3640277c7ffd1303c7a542d02d3e4c0000000000000000",
            "18ce4f0b8cb4d0cac65fea8f79257b20888e53e72299e56dffffffff000000000000000000000000"],
    ];

    /// <summary>Every SIMD combination this machine supports, scalar included.</summary>
    private static IEnumerable<SimdSupport> Tiers()
    {
        SimdSupport supported = AesGcmSiv.SimdSupport;
        foreach (SimdSupport tier in new[]
        {
            SimdSupport.None, SimdSupport.AesNi, SimdSupport.PClMul,
            SimdSupport.AesNi | SimdSupport.PClMul, SimdSupport.ArmAes,
        })
        {
            if ((tier & supported) == tier)
                yield return tier;
        }
    }

    [Test]
    public void Rfc8452_KnownAnswers_EveryTier()
    {
        foreach (SimdSupport tier in Tiers())
        {
            foreach (string[] v in Rfc8452Vectors)
            {
                byte[] key = FromHex(v[0]), nonce = FromHex(v[1]), aad = FromHex(v[2]), plaintext = FromHex(v[3]);
                byte[] expected = FromHex(v[4]);

                using AesGcmSiv siv = Create(tier, key);
                Assert.That(siv.Encrypt(nonce, plaintext, aad), Is.EqualTo(expected), $"{siv.AlgorithmName} {tier} encrypt {v[3]}");
                Assert.That(siv.Decrypt(nonce, expected, aad), Is.EqualTo(plaintext), $"{siv.AlgorithmName} {tier} decrypt {v[3]}");
            }
        }
    }

    /// <summary>RFC 8452 Appendix A, on both the PCLMULQDQ and the scalar path.</summary>
    [TestCase(false)]
    [TestCase(true)]
    public void Polyval_Rfc8452AppendixA(bool usePclmul)
    {
        byte[] h = FromHex("25629347589242761d31f826ba4b757b");
        byte[] x = FromHex("4f4f95668c83dfb6401762bb2d01a262d1a24ddd2721d006bbe45f20d3c9f362");
        byte[] output = new byte[16];

        Polyval.Compute(h, x, output, usePclmul);

        Assert.That(output, Is.EqualTo(FromHex("f7a3b47b846119fae5b7866cf5e5b77e")));
    }

    [Test]
    public void MatchesBouncyCastle_AcrossLengths([Values(16, 32)] int keySize)
    {
        var rng = new Random(8452 + keySize);
        int[] lengths = [0, 1, 15, 16, 17, 31, 32, 33, 63, 64, 65, 127, 128, 129, 1000, 4096];

        foreach (SimdSupport tier in Tiers())
        {
            foreach (int length in lengths)
            {
                byte[] key = RandomBytes(rng, keySize);
                byte[] nonce = RandomBytes(rng, 12);
                byte[] aad = RandomBytes(rng, rng.Next(0, 70));
                byte[] plaintext = RandomBytes(rng, length);

                using AesGcmSiv siv = Create(tier, key);
                byte[] ours = siv.Encrypt(nonce, plaintext, aad);

                Assert.That(ours, Is.EqualTo(BouncyCastleEncrypt(key, nonce, aad, plaintext)),
                    $"{siv.AlgorithmName} {tier} length {length} aad {aad.Length}");
                Assert.That(siv.Decrypt(nonce, ours, aad), Is.EqualTo(plaintext));
            }
        }
    }

    /// <summary>
    /// A repeated nonce reveals only whether the same (associated data, plaintext) was sealed
    /// twice: equal inputs give equal outputs, and any difference changes the whole output.
    /// </summary>
    [Test]
    public void RepeatedNonce_RevealsOnlyEquality()
    {
        byte[] key = new byte[16];
        byte[] nonce = new byte[12];
        byte[] a = new byte[64];
        byte[] b = new byte[64];
        b[63] = 1;

        using var siv = AesGcmSiv128.Create(key);
        byte[] sealedA = siv.Encrypt(nonce, a);
        byte[] sealedAAgain = siv.Encrypt(nonce, a);
        byte[] sealedB = siv.Encrypt(nonce, b);

        Assert.That(sealedAAgain, Is.EqualTo(sealedA), "deterministic for equal inputs");

        // Under AES-GCM the first block would match, since the keystream depends only on the
        // nonce. Here the tag, and so the keystream, depends on the whole plaintext.
        Assert.That(sealedB.AsSpan(0, 16).SequenceEqual(sealedA.AsSpan(0, 16)), Is.False);
        Assert.That(sealedB.AsSpan(64, 16).SequenceEqual(sealedA.AsSpan(64, 16)), Is.False);
    }

    [Test]
    public void InPlace_EncryptAndDecrypt([Values(0, 5, 16, 100)] int length)
    {
        var rng = new Random(length);
        byte[] key = RandomBytes(rng, 32);
        byte[] nonce = RandomBytes(rng, 12);
        byte[] aad = RandomBytes(rng, 9);
        byte[] plaintext = RandomBytes(rng, length);

        using var siv = AesGcmSiv256.Create(key);
        byte[] expected = siv.Encrypt(nonce, plaintext, aad);

        byte[] buffer = (byte[])plaintext.Clone();
        byte[] tag = new byte[16];
        siv.Encrypt(nonce, buffer, buffer, tag, aad);
        Assert.That(Concat(buffer, tag), Is.EqualTo(expected));

        Assert.That(siv.Decrypt(nonce, buffer, tag, buffer, aad), Is.True);
        Assert.That(buffer, Is.EqualTo(plaintext));
    }

    [TestCase(0, TestName = "Tampered_Ciphertext")]
    [TestCase(1, TestName = "Tampered_Tag")]
    [TestCase(2, TestName = "Tampered_AssociatedData")]
    public void Tampering_FailsAndClearsPlaintext(int what)
    {
        var rng = new Random(what);
        byte[] key = RandomBytes(rng, 16);
        byte[] nonce = RandomBytes(rng, 12);
        byte[] aad = RandomBytes(rng, 20);
        byte[] plaintext = RandomBytes(rng, 48);

        using var siv = AesGcmSiv128.Create(key);
        byte[] ciphertext = new byte[plaintext.Length];
        byte[] tag = new byte[16];
        siv.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        switch (what)
        {
            case 0: ciphertext[7] ^= 1; break;
            case 1: tag[15] ^= 0x80; break;
            default: aad[0] ^= 1; break;
        }

        byte[] decrypted = RandomBytes(rng, plaintext.Length);
        Assert.That(siv.Decrypt(nonce, ciphertext, tag, decrypted, aad), Is.False);
        Assert.That(decrypted, Is.All.EqualTo(0));
        Assert.Throws<CryptographicException>(() => siv.Decrypt(nonce, Concat(ciphertext, tag), aad));
    }

    [Test]
    public void ArgumentChecks()
    {
        Assert.Throws<ArgumentException>(() => AesGcmSiv128.Create(new byte[32]));
        Assert.Throws<ArgumentException>(() => AesGcmSiv256.Create(new byte[16]));
        Assert.Throws<ArgumentException>(() => AesGcmSiv128.Create(new byte[24]));

        using var siv = AesGcmSiv128.Create(new byte[16]);
        Assert.Throws<ArgumentException>(() => siv.Encrypt(new byte[16], new byte[4]));
        Assert.Throws<ArgumentException>(() => siv.Encrypt(new byte[12], new byte[4], new byte[4], new byte[15]));
        Assert.Throws<ArgumentException>(() => siv.Decrypt(new byte[12], new byte[4], new byte[12], new byte[4]));

        Assert.That(siv.AlgorithmName, Is.EqualTo("AES-128-GCM-SIV"));
        Assert.That(siv.KeySizeBytes, Is.EqualTo(16));
        Assert.That(siv.NonceSizeBytes, Is.EqualTo(12));
        Assert.That(siv.TagSizeBytes, Is.EqualTo(16));
    }

    [Test]
    public void Disposed_Throws()
    {
        var siv = AesGcmSiv256.Create(new byte[32]);
        siv.Dispose();

        Assert.Throws<ObjectDisposedException>(() => siv.Encrypt(new byte[12], new byte[1]));
        Assert.Throws<ObjectDisposedException>(() => siv.Decrypt(new byte[12], new byte[16]));
    }

    private static AesGcmSiv Create(SimdSupport tier, byte[] key) => key.Length == 16
        ? AesGcmSiv128.Create(tier, key)
        : AesGcmSiv256.Create(tier, key);

    private static byte[] BouncyCastleEncrypt(byte[] key, byte[] nonce, byte[] aad, byte[] plaintext)
    {
        var cipher = new GcmSivBlockCipher(new AesEngine());
        cipher.Init(true, new AeadParameters(new KeyParameter(key), 128, nonce, aad));
        byte[] output = new byte[cipher.GetOutputSize(plaintext.Length)];
        int written = cipher.ProcessBytes(plaintext, 0, plaintext.Length, output, 0);
        written += cipher.DoFinal(output, written);
        Array.Resize(ref output, written);
        return output;
    }

    private static byte[] Concat(byte[] a, byte[] b)
    {
        byte[] result = new byte[a.Length + b.Length];
        a.CopyTo(result, 0);
        b.CopyTo(result, a.Length);
        return result;
    }

    private static byte[] RandomBytes(Random rng, int length)
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
