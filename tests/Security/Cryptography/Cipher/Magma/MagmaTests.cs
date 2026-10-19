// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CA5358 // ECB is the single-block primitive under test, not a mode of use.
#pragma warning disable CA5401 // CBC IV values are explicit test inputs; OpenGost requires IV assignment.

namespace Cryptography.Tests.Cipher.Magma;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using OpenGostMagma = OpenGost.Security.Cryptography.Magma;
using OS = System.Security.Cryptography;

/// <summary>
/// Magma (GOST R 34.12-2015): the RFC 8891 known answers, and random keys and blocks against
/// OpenGost, which RFC 8891's two vectors are too few to replace.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MagmaTests
{
    private const int BlockSize = 8;
    private const int KeySize = 32;

    private static readonly byte[] Rfc8891Key = FromHex("ffeeddccbbaa99887766554433221100f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff");

    [Test]
    public void Magma_Rfc8891AppendixA4_Encrypt()
    {
        Assert.That(EncryptEcb(Rfc8891Key, FromHex("fedcba9876543210")), Is.EqualTo(FromHex("4ee901e5c2d8ca3d")));
    }

    [Test]
    public void Magma_Rfc8891AppendixA5_Decrypt()
    {
        Assert.That(DecryptEcb(Rfc8891Key, FromHex("4ee901e5c2d8ca3d")), Is.EqualTo(FromHex("fedcba9876543210")));
    }

    [Test]
    public void EcbEncryptionMatchesOpenGost()
    {
        var random = new Random(8891);

        for (int iteration = 0; iteration < 256; iteration++)
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] plaintext = RandomBytes(random, BlockSize);

            Assert.That(EncryptEcb(key, plaintext), Is.EqualTo(ReferenceEcb(key, plaintext, encrypt: true)),
                $"ECB encryption disagreed on iteration {iteration}");
        }
    }

    [Test]
    public void EcbDecryptionMatchesOpenGost()
    {
        var random = new Random(8892);

        for (int iteration = 0; iteration < 256; iteration++)
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] ciphertext = RandomBytes(random, BlockSize);

            Assert.That(DecryptEcb(key, ciphertext), Is.EqualTo(ReferenceEcb(key, ciphertext, encrypt: false)),
                $"ECB decryption disagreed on iteration {iteration}");
        }
    }

    [Test]
    public void CbcInteroperatesWithOpenGost()
    {
        var random = new Random(8893);

        foreach (int length in new[] { 1, 7, 8, 9, 63, 64, 255, 1024 })
        {
            byte[] key = RandomBytes(random, KeySize);
            byte[] iv = RandomBytes(random, BlockSize);
            byte[] plaintext = RandomBytes(random, length);

            using var magma = Magma.Create();
            magma.Mode = CipherMode.CBC;
            magma.Padding = PaddingMode.PKCS7;
            magma.Key = key;
            magma.IV = iv;
            byte[] ours = magma.Encrypt(plaintext);

            using var reference = OpenGostMagma.Create();
            reference.Mode = OS.CipherMode.CBC;
            reference.Padding = OS.PaddingMode.PKCS7;
            reference.Key = key;
            reference.IV = iv;

            using (var encryptor = reference.CreateEncryptor())
            {
                Assert.That(ours, Is.EqualTo(encryptor.TransformFinalBlock(plaintext, 0, plaintext.Length)),
                    $"CBC ciphertext disagreed at {length} bytes");
            }

            using var decryptor = reference.CreateDecryptor();
            Assert.That(decryptor.TransformFinalBlock(ours, 0, ours.Length), Is.EqualTo(plaintext),
                $"OpenGost could not recover our CBC ciphertext at {length} bytes");
        }
    }

    [Test]
    public void BlockAndKeySizes()
    {
        using var magma = Magma.Create();

        Assert.That(magma.AlgorithmName, Is.EqualTo("Magma"));
        Assert.That(magma.BlockSize, Is.EqualTo(64));
        Assert.That(magma.KeySize, Is.EqualTo(256));
        Assert.That(magma.IVSize, Is.EqualTo(BlockSize));
        Assert.Throws<OS.CryptographicException>(() => magma.Key = new byte[16]);
    }

    private static byte[] EncryptEcb(byte[] key, byte[] block)
    {
        using var magma = CreateEcb(key);
        return magma.Encrypt(block);
    }

    private static byte[] DecryptEcb(byte[] key, byte[] block)
    {
        using var magma = CreateEcb(key);
        return magma.Decrypt(block);
    }

    private static Magma CreateEcb(byte[] key)
    {
        var magma = Magma.Create();
        magma.Mode = CipherMode.ECB;
        magma.Padding = PaddingMode.None;
        magma.Key = key;
        magma.IV = new byte[BlockSize];
        return magma;
    }

    private static byte[] ReferenceEcb(byte[] key, byte[] block, bool encrypt)
    {
        using var reference = OpenGostMagma.Create();
        reference.Mode = OS.CipherMode.ECB;
        reference.Padding = OS.PaddingMode.None;
        reference.Key = key;
        using OS.ICryptoTransform transform = encrypt ? reference.CreateEncryptor() : reference.CreateDecryptor();
        return transform.TransformFinalBlock(block, 0, block.Length);
    }

    private static byte[] RandomBytes(Random random, int length)
    {
        byte[] bytes = new byte[length];
        random.NextBytes(bytes);
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
