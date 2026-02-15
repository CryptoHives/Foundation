// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// Tests that validate CryptoHives cipher implementations against reference implementations.
/// </summary>
/// <remarks>
/// <para>
/// These tests compare CryptoHives implementations against:
/// - BouncyCastle (primary reference for AES-GCM, AES-CCM, ChaCha20-Poly1305)
/// - System.Security.Cryptography (OS implementations when available)
/// </para>
/// <para>
/// Pattern mirrors HashReferenceImplementationTests for consistency.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CipherReferenceImplementationTests
{
    private const int TestDataSize = 1024;

    // ========================================================================
    // AES-GCM Tests
    // ========================================================================

    [Test]
    [TestCaseSource(nameof(GetAesGcmManagedImplementations))]
    public void AesGcm_Managed_MatchesBouncyCastle(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        // Find corresponding BC implementation
        var bcImpl = CipherAlgorithmRegistry
            .ByFamily(impl.AlgorithmFamily)
            .First(c => c.Source == CipherAlgorithmRegistry.Source.BouncyCastle);

        CompareAeadImplementations(impl, bcImpl);
    }

#if NET8_0_OR_GREATER
    [Test]
    [TestCaseSource(nameof(GetAesGcmManagedImplementations))]
    public void AesGcm_Managed_MatchesOS(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        // Find corresponding OS implementation
        var osImpl = CipherAlgorithmRegistry
            .ByFamily(impl.AlgorithmFamily)
            .FirstOrDefault(c => c.Source == CipherAlgorithmRegistry.Source.OS);

        if (osImpl == null || !osImpl.IsSupported)
        {
            Assert.Ignore($"No OS implementation available for {impl.AlgorithmFamily}");
            return;
        }

        CompareAeadImplementations(impl, osImpl);
    }
#endif

    // ========================================================================
    // AES-CCM Tests
    // ========================================================================

    [Test]
    [TestCaseSource(nameof(GetAesCcmManagedImplementations))]
    public void AesCcm_Managed_MatchesBouncyCastle(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        // Find corresponding BC implementation
        var bcImpl = CipherAlgorithmRegistry
            .ByFamily(impl.AlgorithmFamily)
            .First(c => c.Source == CipherAlgorithmRegistry.Source.BouncyCastle);

        CompareAeadImplementations(impl, bcImpl);
    }

    // ========================================================================
    // ChaCha20-Poly1305 Tests
    // ========================================================================

    [Test]
    [TestCaseSource(nameof(GetChaCha20Poly1305ManagedImplementations))]
    public void ChaCha20Poly1305_Managed_MatchesBouncyCastle(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        // Find corresponding BC implementation (if it exists)
        var bcImpl = CipherAlgorithmRegistry
            .ByFamily(impl.AlgorithmFamily)
            .FirstOrDefault(c => c.Source == CipherAlgorithmRegistry.Source.BouncyCastle);

        if (bcImpl == null)
        {
            Assert.Ignore($"No BouncyCastle implementation found for {impl.AlgorithmFamily}");
            return;
        }

        CompareAeadImplementations(impl, bcImpl);
    }

#if NET9_0_OR_GREATER
    [Test]
    [TestCaseSource(nameof(GetChaCha20Poly1305ManagedImplementations))]
    public void ChaCha20Poly1305_Managed_MatchesOS(CipherAlgorithmRegistry.CipherImplementation impl)
    {
        // XChaCha20-Poly1305 not supported by OS
        if (impl.AlgorithmFamily.Contains("XChaCha"))
        {
            Assert.Ignore($"OS does not support {impl.AlgorithmFamily}");
            return;
        }

        // Find corresponding OS implementation
        var osImpl = CipherAlgorithmRegistry
            .ByFamily(impl.AlgorithmFamily)
            .FirstOrDefault(c => c.Source == CipherAlgorithmRegistry.Source.OS);

        if (osImpl == null || !osImpl.IsSupported)
        {
            Assert.Ignore($"No OS implementation available for {impl.AlgorithmFamily}");
            return;
        }

        CompareAeadImplementations(impl, osImpl);
    }
#endif

    // ========================================================================
    // Helper Methods
    // ========================================================================

    private static void CompareAeadImplementations(
        CipherAlgorithmRegistry.CipherImplementation impl1,
        CipherAlgorithmRegistry.CipherImplementation impl2)
    {
        // Generate deterministic test data
        byte[] key = GenerateBytes(impl1.KeySizeBits / 8, seed: 0x01);
        byte[] nonce = GenerateBytes(12, seed: 0x02);
        byte[] plaintext = GenerateBytes(TestDataSize, seed: 0x03);
        byte[] aad = GenerateBytes(64, seed: 0x04);

        using var cipher1 = (IAeadCipher)impl1.Create();
        using var cipher2 = (IAeadCipher)impl2.Create();

        // Encrypt with both implementations
        byte[] ciphertext1 = new byte[plaintext.Length];
        byte[] tag1 = new byte[16];
        cipher1.Encrypt(nonce, plaintext, ciphertext1, tag1, aad);

        byte[] ciphertext2 = new byte[plaintext.Length];
        byte[] tag2 = new byte[16];
        cipher2.Encrypt(nonce, plaintext, ciphertext2, tag2, aad);

        // Compare results
        Assert.That(ciphertext1, Is.EqualTo(ciphertext2),
            $"{impl1.Name} ciphertext does not match {impl2.Name}");
        Assert.That(tag1, Is.EqualTo(tag2),
            $"{impl1.Name} tag does not match {impl2.Name}");

        // Verify both can decrypt each other's output
        byte[] decrypted1 = new byte[plaintext.Length];
        byte[] decrypted2 = new byte[plaintext.Length];

        bool result1 = cipher1.Decrypt(nonce, ciphertext2, tag2, decrypted1, aad);
        bool result2 = cipher2.Decrypt(nonce, ciphertext1, tag1, decrypted2, aad);

        Assert.That(result1, Is.True, $"{impl1.Name} failed to decrypt {impl2.Name} output");
        Assert.That(result2, Is.True, $"{impl2.Name} failed to decrypt {impl1.Name} output");

        Assert.That(decrypted1, Is.EqualTo(plaintext),
            $"{impl1.Name} decryption mismatch");
        Assert.That(decrypted2, Is.EqualTo(plaintext),
            $"{impl2.Name} decryption mismatch");
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

    private static System.Collections.IEnumerable GetAesGcmManagedImplementations()
    {
        return CipherAlgorithmRegistry.Supported
            .Where(c => c.AlgorithmFamily.Contains("GCM") &&
                       c.Source == CipherAlgorithmRegistry.Source.Managed)
            .Select(c => new TestCaseData(c).SetName($"{{m}}({c.Name})"));
    }

    private static System.Collections.IEnumerable GetAesCcmManagedImplementations()
    {
        return CipherAlgorithmRegistry.Supported
            .Where(c => c.AlgorithmFamily.Contains("CCM") &&
                       c.Source == CipherAlgorithmRegistry.Source.Managed)
            .Select(c => new TestCaseData(c).SetName($"{{m}}({c.Name})"));
    }

    private static System.Collections.IEnumerable GetChaCha20Poly1305ManagedImplementations()
    {
        return CipherAlgorithmRegistry.Supported
            .Where(c => c.AlgorithmFamily.Contains("ChaCha20-Poly1305") &&
                       c.Source == CipherAlgorithmRegistry.Source.Managed)
            .Select(c => new TestCaseData(c).SetName($"{{m}}({c.Name})"));
    }
}
