// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// Cross-validates all cipher implementations against each other.
/// </summary>
/// <remarks>
/// <para>
/// Every supported implementation of an algorithm family (Managed, AVX2, SSSE3,
/// BouncyCastle, NaCl.Core, OS) is tested pairwise. This ensures that SIMD variants
/// produce identical output to the scalar path and to external reference libraries.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CipherReferenceImplementationTests
{
    private static readonly int[] TestDataSizes = [0, 1, 15, 16, 63, 64, 65, 127, 128, 129, 256, 1024, 4096];

    // ========================================================================
    // AEAD Cross-Validation: All implementations pairwise
    // ========================================================================

    [TestCaseSource(nameof(GetAllAeadImplementationPairs))]
    public void AeadCipher_CrossValidation(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2)
    {
        foreach (int size in TestDataSizes)
        {
            CompareAeadImplementations(impl1, impl2, size);
        }
    }

    // ========================================================================
    // Stream Cipher Cross-Validation: All implementations pairwise
    // ========================================================================

    [TestCaseSource(nameof(GetAllStreamCipherImplementationPairs))]
    public void StreamCipher_CrossValidation(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2)
    {
        foreach (int size in TestDataSizes)
        {
            CompareStreamCipherImplementations(impl1, impl2, size);
        }
    }

    // ========================================================================
    // Block Cipher Cross-Validation: All implementations pairwise
    // ========================================================================

    [TestCaseSource(nameof(GetAllBlockCipherImplementationPairs))]
    public void BlockCipher_CrossValidation(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2)
    {
        foreach (int blockAlignedSize in new[] { 16, 32, 64, 128, 256, 1024 })
        {
            CompareBlockCipherImplementations(impl1, impl2, blockAlignedSize);
        }
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static void CompareAeadImplementations(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2,
        int plaintextSize)
    {
        using var cipher1 = (IAeadCipher)impl1.Create();
        using var cipher2 = (IAeadCipher)impl2.Create();

        byte[] key = GenerateBytes(impl1.KeySizeBits / 8, seed: 0x01);
        byte[] nonce = GenerateBytes(cipher1.NonceSizeBytes, seed: 0x02);
        byte[] plaintext = GenerateBytes(plaintextSize, seed: 0x03 + plaintextSize);
        byte[] aad = GenerateBytes(64, seed: 0x04);

        // Encrypt with impl1
        byte[] ciphertext1 = new byte[plaintext.Length];
        byte[] tag1 = new byte[cipher1.TagSizeBytes];
        cipher1.Encrypt(nonce, plaintext, ciphertext1, tag1, aad);

        // Encrypt with impl2
        byte[] ciphertext2 = new byte[plaintext.Length];
        byte[] tag2 = new byte[cipher2.TagSizeBytes];
        cipher2.Encrypt(nonce, plaintext, ciphertext2, tag2, aad);

        // Compare
        Assert.That(ciphertext1, Is.EqualTo(ciphertext2),
            $"Ciphertext mismatch at size {plaintextSize}: {impl1.Name} vs {impl2.Name}");
        Assert.That(tag1, Is.EqualTo(tag2),
            $"Tag mismatch at size {plaintextSize}: {impl1.Name} vs {impl2.Name}");

        // Cross-decrypt
        byte[] decrypted = new byte[plaintext.Length];
        bool result = cipher2.Decrypt(nonce, ciphertext1, tag1, decrypted, aad);
        Assert.That(result, Is.True,
            $"{impl2.Name} failed to decrypt {impl1.Name} output at size {plaintextSize}");
        Assert.That(decrypted, Is.EqualTo(plaintext),
            $"Decryption mismatch at size {plaintextSize}: {impl2.Name} decrypting {impl1.Name}");
    }

    private static void CompareStreamCipherImplementations(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2,
        int plaintextSize)
    {
        using var cipher1 = (SymmetricCipher)impl1.Create();
        using var cipher2 = (SymmetricCipher)impl2.Create();

        byte[] key = GenerateBytes(impl1.KeySizeBits / 8, seed: 0x11);
        byte[] nonce = GenerateBytes(cipher1.IVSize, seed: 0x12);
        byte[] plaintext = GenerateBytes(plaintextSize, seed: 0x13 + plaintextSize);

        cipher1.Key = key;
        cipher1.IV = nonce;
        cipher2.Key = key;
        cipher2.IV = nonce;

        byte[] ciphertext1 = cipher1.Encrypt(plaintext);
        byte[] ciphertext2 = cipher2.Encrypt(plaintext);

        Assert.That(ciphertext1, Is.EqualTo(ciphertext2),
            $"Stream cipher mismatch at size {plaintextSize}: {impl1.Name} vs {impl2.Name}");

        // Cross-decrypt
        byte[] decrypted = cipher2.Decrypt(ciphertext1);
        Assert.That(decrypted, Is.EqualTo(plaintext),
            $"Decryption mismatch at size {plaintextSize}: {impl2.Name} decrypting {impl1.Name}");
    }

    private static void CompareBlockCipherImplementations(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2,
        int plaintextSize)
    {
        using var cipher1 = (SymmetricCipher)impl1.Create();
        using var cipher2 = (SymmetricCipher)impl2.Create();

        byte[] key = GenerateBytes(impl1.KeySizeBits / 8, seed: 0x21);
        byte[] iv = GenerateBytes(cipher1.IVSize, seed: 0x22);
        byte[] plaintext = GenerateBytes(plaintextSize, seed: 0x23 + plaintextSize);

        cipher1.Key = key;
        cipher1.IV = iv;
        cipher2.Key = key;
        cipher2.IV = iv;

        byte[] ciphertext1 = cipher1.Encrypt(plaintext);
        byte[] ciphertext2 = cipher2.Encrypt(plaintext);

        Assert.That(ciphertext1, Is.EqualTo(ciphertext2),
            $"Block cipher mismatch at size {plaintextSize}: {impl1.Name} vs {impl2.Name}");

        // Cross-decrypt
        byte[] decrypted = cipher2.Decrypt(ciphertext1);
        Assert.That(decrypted, Is.EqualTo(plaintext),
            $"Decryption mismatch at size {plaintextSize}: {impl2.Name} decrypting {impl1.Name}");
    }

    private static byte[] GenerateBytes(int size, int seed)
    {
        var random = new Random(seed);
        byte[] bytes = new byte[size];
        random.NextBytes(bytes);
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

    private static System.Collections.IEnumerable GetAllAeadImplementationPairs()
    {
        return GetImplementationPairs(AeadFamilies);
    }

    private static System.Collections.IEnumerable GetAllStreamCipherImplementationPairs()
    {
        return GetImplementationPairs(StreamFamilies);
    }

    private static System.Collections.IEnumerable GetAllBlockCipherImplementationPairs()
    {
        return GetImplementationPairs(BlockFamilies);
    }

    private static IEnumerable<TestCaseData> GetImplementationPairs(string[] families)
    {
        foreach (string family in families)
        {
            var impls = CipherAlgorithmRegistry.Supported
                .Where(c => c.AlgorithmFamily == family)
                .ToList();

            // Generate all unique ordered pairs (impl1, impl2) where impl1 != impl2
            for (int i = 0; i < impls.Count; i++)
            {
                for (int j = i + 1; j < impls.Count; j++)
                {
                    yield return new TestCaseData(impls[i], impls[j])
                        .SetName($"{{m}}({impls[i].Name} vs {impls[j].Name})");
                }
            }
        }
    }
}
