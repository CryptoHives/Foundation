// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher.Kuznyechik;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using Grasshopper = OpenGost.Security.Cryptography.Grasshopper;
using OS = System.Security.Cryptography;

/// <summary>
/// Cross-validates Kuznyechik against OpenGost's Grasshopper over randomized inputs.
/// </summary>
/// <remarks>
/// <para>
/// RFC 7801 fixes a single key and a handful of blocks, which leaves most of the S-box and most
/// of the linear layer's input space untouched. The block functions are table-driven, and
/// decryption additionally moves the linear layer onto the round keys, so a construction error
/// can be confined to byte values the published vectors never exercise. Random keys and random
/// data against an independent implementation is what covers that.
/// </para>
/// <para>
/// BouncyCastle's C# port has no GOST R 34.12-2015 engine, so OpenGost - already referenced for
/// Streebog - is the only reference implementation available.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KuznyechikCrossValidationTests
{
    private const int BlockSize = 16;
    private const int KeySize = 32;

    /// <summary>
    /// Every single-block encryption agrees with OpenGost, across random keys and blocks.
    /// </summary>
    [Test]
    public void EcbEncryptionMatchesOpenGost()
    {
        var random = new Random(20260811);

        for (int iteration = 0; iteration < 256; iteration++)
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] plaintext = RandomBytes(random, BlockSize);

            byte[] ours = EncryptEcb(key, plaintext);
            byte[] reference = ReferenceEcb(key, plaintext, encrypt: true);

            Assert.That(ours, Is.EqualTo(reference),
                $"ECB encryption disagreed on iteration {iteration}");
        }
    }

    /// <summary>
    /// Every single-block decryption agrees with OpenGost, across random keys and blocks.
    /// </summary>
    /// <remarks>
    /// The decryption path is the one that rewrites the round structure, so it gets its own
    /// direct comparison rather than only being covered by a round trip.
    /// </remarks>
    [Test]
    public void EcbDecryptionMatchesOpenGost()
    {
        var random = new Random(20260812);

        for (int iteration = 0; iteration < 256; iteration++)
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] ciphertext = RandomBytes(random, BlockSize);

            byte[] ours = DecryptEcb(key, ciphertext);
            byte[] reference = ReferenceEcb(key, ciphertext, encrypt: false);

            Assert.That(ours, Is.EqualTo(reference),
                $"ECB decryption disagreed on iteration {iteration}");
        }
    }

    /// <summary>
    /// Ciphertext this library produces in CBC is plaintext OpenGost recovers, and the reverse.
    /// </summary>
    [Test]
    public void CbcInteroperatesWithOpenGost()
    {
        var random = new Random(20260813);

        foreach (int length in new[] { 1, 15, 16, 17, 63, 64, 255, 1024 })
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] iv = RandomBytes(random, BlockSize);
            byte[] plaintext = RandomBytes(random, length);

            using var kuznyechik = Kuznyechik.Create();
            kuznyechik.Mode = CipherMode.CBC;
            kuznyechik.Padding = PaddingMode.PKCS7;
            kuznyechik.Key = key;
            kuznyechik.IV = iv;

            byte[] ours = kuznyechik.Encrypt(plaintext);

            using var grasshopper = Grasshopper.Create();
            grasshopper.Mode = OS.CipherMode.CBC;
            grasshopper.Padding = OS.PaddingMode.PKCS7;
            grasshopper.Key = key;
            grasshopper.IV = iv;

            using (var encryptor = grasshopper.CreateEncryptor())
            {
                byte[] reference = encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length);
                Assert.That(ours, Is.EqualTo(reference), $"CBC ciphertext disagreed at {length} bytes");
            }

            using (var decryptor = grasshopper.CreateDecryptor())
            {
                byte[] recovered = decryptor.TransformFinalBlock(ours, 0, ours.Length);
                Assert.That(recovered, Is.EqualTo(plaintext),
                    $"OpenGost could not recover our CBC ciphertext at {length} bytes");
            }

            Assert.That(kuznyechik.Decrypt(ours), Is.EqualTo(plaintext),
                $"CBC round trip failed at {length} bytes");
        }
    }

    /// <summary>
    /// Encryption followed by decryption is the identity over random keys and blocks.
    /// </summary>
    [Test]
    public void EcbRoundTripsRandomBlocks()
    {
        var random = new Random(20260814);

        for (int iteration = 0; iteration < 512; iteration++)
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] plaintext = RandomBytes(random, BlockSize);

            byte[] recovered = DecryptEcb(key, EncryptEcb(key, plaintext));

            Assert.That(recovered, Is.EqualTo(plaintext),
                $"round trip failed on iteration {iteration}");
        }
    }

    private static byte[] RandomBytes(Random random, int length)
    {
        byte[] bytes = new byte[length];
        random.NextBytes(bytes);
        return bytes;
    }

    private static byte[] EncryptEcb(byte[] key, byte[] plaintext)
    {
        using var kuznyechik = Kuznyechik.Create();
        kuznyechik.Mode = CipherMode.ECB;
        kuznyechik.Padding = PaddingMode.None;
        kuznyechik.Key = key;
        kuznyechik.IV = new byte[BlockSize];
        return kuznyechik.Encrypt(plaintext);
    }

    private static byte[] DecryptEcb(byte[] key, byte[] ciphertext)
    {
        using var kuznyechik = Kuznyechik.Create();
        kuznyechik.Mode = CipherMode.ECB;
        kuznyechik.Padding = PaddingMode.None;
        kuznyechik.Key = key;
        kuznyechik.IV = new byte[BlockSize];
        return kuznyechik.Decrypt(ciphertext);
    }

    private static byte[] ReferenceEcb(byte[] key, byte[] data, bool encrypt)
    {
        using var grasshopper = Grasshopper.Create();
        grasshopper.Mode = OS.CipherMode.ECB;
        grasshopper.Padding = OS.PaddingMode.None;
        grasshopper.Key = key;

        using OS.ICryptoTransform transform = encrypt
            ? grasshopper.CreateEncryptor()
            : grasshopper.CreateDecryptor();

        return transform.TransformFinalBlock(data, 0, data.Length);
    }
}
