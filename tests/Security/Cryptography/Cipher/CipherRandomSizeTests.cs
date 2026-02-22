// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Tests cipher implementations with random and boundary-case buffer sizes
/// to expose edge cases in block processing, pipeline batching, and partial block handling.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CipherRandomSizeTests
{
    /// <summary>
    /// Sizes chosen to exercise specific pipeline boundaries:
    /// 0=empty, 1=minimal, 15=one byte short of AES block, 16=exact AES block,
    /// 17=one byte past AES block, 31/32/33=two-block boundary, 63/64/65=four-block boundary,
    /// 127/128/129=eight-block pipeline boundary, 255/256/257=sixteen-block boundary,
    /// 1023/1024/1025=large boundary, 4096=sustained.
    /// </summary>
    private static readonly int[] BoundarySizes =
        [0, 1, 2, 15, 16, 17, 31, 32, 33, 47, 48, 49,
         63, 64, 65, 95, 96, 97, 127, 128, 129,
         191, 192, 193, 255, 256, 257, 511, 512, 513,
         1023, 1024, 1025, 4096, 8192];

    private const int RandomIterations = 50;
    private const int MaxRandomSize = 16384;

    // ========================================================================
    // AEAD: Round-trip with boundary sizes
    // ========================================================================

    [TestCaseSource(nameof(GetAllAeadImplementations))]
    public void AeadCipher_BoundarySizeRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(42);
        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        using var cipher = (IAeadCipher)impl.Create(key);

        byte[] aad = GenerateBytes(37, rng); // odd AAD size

        foreach (int size in BoundarySizes)
        {
            // Fresh nonce per encrypt to satisfy BC's nonce-reuse check
            byte[] nonce = GenerateBytes(cipher.NonceSizeBytes, rng);
            AeadRoundTrip(cipher, nonce, aad, size, rng,
                $"{impl.Name} at size {size}");
        }
    }

    [TestCaseSource(nameof(GetAllAeadImplementations))]
    public void AeadCipher_RandomSizeRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(0xDEAD);
        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        using var cipher = (IAeadCipher)impl.Create(key);

        byte[] aad = GenerateBytes(37, rng);

        for (int i = 0; i < RandomIterations; i++)
        {
            byte[] nonce = GenerateBytes(cipher.NonceSizeBytes, rng);
            int size = rng.Next(0, MaxRandomSize + 1);
            AeadRoundTrip(cipher, nonce, aad, size, rng,
                $"{impl.Name} at random size {size} (iteration {i})");
        }
    }

    [TestCaseSource(nameof(GetAllAeadImplementations))]
    public void AeadCipher_RandomSizeAndAadRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(0xBEEF);
        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        using var cipher = (IAeadCipher)impl.Create(key);

        for (int i = 0; i < RandomIterations; i++)
        {
            byte[] nonce = GenerateBytes(cipher.NonceSizeBytes, rng);
            int size = rng.Next(0, MaxRandomSize + 1);
            int aadSize = rng.Next(0, 1024);
            byte[] aad = GenerateBytes(aadSize, rng);
            AeadRoundTrip(cipher, nonce, aad, size, rng,
                $"{impl.Name} at pt={size} aad={aadSize} (iteration {i})");
        }
    }

    [TestCaseSource(nameof(GetAllAeadImplementations))]
    public void AeadCipher_TamperedCiphertextFails(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(0xCAFE);
        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        using var cipher = (IAeadCipher)impl.Create(key);

        byte[] aad = GenerateBytes(16, rng);

        foreach (int size in new[] { 1, 16, 17, 128, 129, 1024 })
        {
            byte[] nonce = GenerateBytes(cipher.NonceSizeBytes, rng);
            byte[] plaintext = GenerateBytes(size, rng);
            byte[] ciphertext = new byte[size];
            byte[] tag = new byte[cipher.TagSizeBytes];
            cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);

            // Tamper with a random byte
            byte[] tampered = (byte[])ciphertext.Clone();
            int pos = rng.Next(tampered.Length);
            tampered[pos] ^= 0xFF;

            byte[] decrypted = new byte[size];
            bool result = cipher.Decrypt(nonce, tampered, tag, decrypted, aad);
            Assert.That(result, Is.False,
                $"{impl.Name} should reject tampered ciphertext at size {size}, pos {pos}");
        }
    }

    // ========================================================================
    // Stream Cipher: Round-trip with boundary sizes
    // ========================================================================

    [TestCaseSource(nameof(GetAllStreamCipherImplementations))]
    public void StreamCipher_BoundarySizeRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(42);
        using var cipher = (SymmetricCipher)impl.Create();

        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        byte[] iv = GenerateBytes(cipher.IVSize, rng);
        cipher.Key = key;
        cipher.IV = iv;

        foreach (int size in BoundarySizes.Where(s => s > 0))
        {
            StreamCipherRoundTrip(cipher, size, rng,
                $"{impl.Name} at size {size}");
        }
    }

    [TestCaseSource(nameof(GetAllStreamCipherImplementations))]
    public void StreamCipher_RandomSizeRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(0xDEAD);
        using var cipher = (SymmetricCipher)impl.Create();

        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        byte[] iv = GenerateBytes(cipher.IVSize, rng);
        cipher.Key = key;
        cipher.IV = iv;

        for (int i = 0; i < RandomIterations; i++)
        {
            int size = 1 + rng.Next(MaxRandomSize);
            StreamCipherRoundTrip(cipher, size, rng,
                $"{impl.Name} at random size {size} (iteration {i})");
        }
    }

    // ========================================================================
    // Block Cipher: Round-trip with boundary sizes
    // ========================================================================

    [TestCaseSource(nameof(GetAllBlockCipherImplementations))]
    public void BlockCipher_BoundarySizeRoundTrip(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        var rng = new Random(42);
        using var cipher = (SymmetricCipher)impl.Create();

        byte[] key = GenerateBytes(impl.KeySizeBits / 8, rng);
        byte[] iv = GenerateBytes(cipher.IVSize, rng);
        cipher.Key = key;
        cipher.IV = iv;

        // Block ciphers require block-aligned sizes
        foreach (int size in BoundarySizes.Where(s => s > 0 && s % 16 == 0))
        {
            BlockCipherRoundTrip(cipher, size, rng,
                $"{impl.Name} at size {size}");
        }
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static void AeadRoundTrip(
        IAeadCipher cipher, byte[] nonce, byte[] aad,
        int plaintextSize, Random rng, string context)
    {
        byte[] plaintext = GenerateBytes(plaintextSize, rng);
        byte[] ciphertext = new byte[plaintextSize];
        byte[] tag = new byte[cipher.TagSizeBytes];

        cipher.Encrypt(nonce, plaintext, ciphertext, tag, aad);

        // Verify ciphertext differs from plaintext (skip for tiny sizes where
        // coincidental equality is possible with a specific random seed)
        if (plaintextSize >= 16)
        {
            Assert.That(ciphertext, Is.Not.EqualTo(plaintext),
                $"Ciphertext equals plaintext: {context}");
        }

        // Decrypt and verify
        byte[] decrypted = new byte[plaintextSize];
        bool result = cipher.Decrypt(nonce, ciphertext, tag, decrypted, aad);
        Assert.That(result, Is.True, $"Decryption auth failed: {context}");
        Assert.That(decrypted, Is.EqualTo(plaintext), $"Decryption mismatch: {context}");
    }

    private static void StreamCipherRoundTrip(
        SymmetricCipher cipher, int size, Random rng, string context)
    {
        byte[] plaintext = GenerateBytes(size, rng);
        byte[] ciphertext = cipher.Encrypt(plaintext);

        Assert.That(ciphertext, Is.Not.EqualTo(plaintext),
            $"Ciphertext equals plaintext: {context}");

        byte[] decrypted = cipher.Decrypt(ciphertext);
        Assert.That(decrypted, Is.EqualTo(plaintext), $"Decryption mismatch: {context}");
    }

    private static void BlockCipherRoundTrip(
        SymmetricCipher cipher, int size, Random rng, string context)
    {
        byte[] plaintext = GenerateBytes(size, rng);
        byte[] ciphertext = cipher.Encrypt(plaintext);
        byte[] decrypted = cipher.Decrypt(ciphertext);
        Assert.That(decrypted, Is.EqualTo(plaintext), $"Decryption mismatch: {context}");
    }

    private static byte[] GenerateBytes(int size, Random rng)
    {
        byte[] bytes = new byte[size];
        rng.NextBytes(bytes);
        return bytes;
    }

    // ========================================================================
    // Test Case Sources
    // ========================================================================

    private static readonly string[] AeadFamilies =
    [
        "AES-128-GCM", "AES-192-GCM", "AES-256-GCM",
        "AES-128-CCM", "AES-192-CCM", "AES-256-CCM",
        "ChaCha20-Poly1305", "XChaCha20-Poly1305"
    ];

    private static readonly string[] StreamFamilies = ["ChaCha20"];
    private static readonly string[] BlockFamilies = ["AES-128-CBC", "AES-256-CBC"];

    private static IEnumerable<TestCaseData> GetAllAeadImplementations()
    {
        return GetSupportedImplementations(AeadFamilies);
    }

    private static IEnumerable<TestCaseData> GetAllStreamCipherImplementations()
    {
        return GetSupportedImplementations(StreamFamilies);
    }

    private static IEnumerable<TestCaseData> GetAllBlockCipherImplementations()
    {
        return GetSupportedImplementations(BlockFamilies);
    }

    private static IEnumerable<TestCaseData> GetSupportedImplementations(string[] families)
    {
        foreach (string family in families)
        {
            foreach (var impl in CipherAlgorithmRegistry.Supported
                         .Where(c => c.AlgorithmFamily == family))
            {
                yield return new TestCaseData(impl)
                    .SetName($"{{m}}({impl.Name})");
            }
        }
    }
}
