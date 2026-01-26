// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0011 // Add braces

using System;
using System.Collections.Generic;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CHCipher = CryptoHives.Foundation.Security.Cryptography.Cipher;

/// <summary>
/// Factory for creating cipher algorithm instances for benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// This class provides a BenchmarkDotNet-friendly wrapper for cipher implementations.
/// Each method returns implementations for a single algorithm family only,
/// ensuring no overlap between benchmark classes.
/// </para>
/// <para>
/// Similar to <see cref="HashAlgorithmType"/>, this supports multiple implementations
/// of the same algorithm (OS, Managed, BouncyCastle) for comparison benchmarks.
/// </para>
/// </remarks>
public sealed class CipherAlgorithmType : IFormattable
{
    private readonly Func<CHCipher.SymmetricCipher> _factory;
    private readonly Func<bool>? _isSupported;

    /// <summary>
    /// Initializes a new instance of the <see cref="CipherAlgorithmType"/> class.
    /// </summary>
    /// <param name="category">The algorithm category (e.g., "AES", "ChaCha").</param>
    /// <param name="name">The display name for this implementation.</param>
    /// <param name="factory">Factory function to create cipher instances.</param>
    /// <param name="isSupported">Optional function to check platform support.</param>
    public CipherAlgorithmType(string category, string name, Func<CHCipher.SymmetricCipher> factory, Func<bool>? isSupported = null)
    {
        Category = category;
        Name = name;
        _factory = factory;
        _isSupported = isSupported;
    }

    /// <summary>
    /// Gets the display name for this implementation.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the algorithm category/family.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets whether this implementation is supported on the current platform.
    /// </summary>
    public bool IsSupported => _isSupported?.Invoke() ?? true;

    /// <summary>
    /// Creates an instance of the cipher algorithm.
    /// </summary>
    /// <exception cref="PlatformNotSupportedException">Thrown if the algorithm is not supported.</exception>
    public CHCipher.SymmetricCipher Create()
    {
        if (!IsSupported)
            throw new PlatformNotSupportedException($"Cipher algorithm '{Name}' is not supported on this platform.");
        return _factory();
    }

    /// <summary>
    /// Tries to create an instance of the cipher algorithm.
    /// </summary>
    /// <param name="algorithm">The created cipher, or null if not supported.</param>
    /// <returns>True if the cipher was created successfully.</returns>
    public bool TryCreate(out CHCipher.SymmetricCipher? algorithm)
    {
        if (!IsSupported)
        {
            algorithm = null;
            return false;
        }

        try
        {
            algorithm = _factory();
            return true;
        }
        catch
        {
            algorithm = null;
            return false;
        }
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    /// <inheritdoc/>
    public override string ToString() => Name;

    // ========================================================================
    // AES Family
    // ========================================================================

    /// <summary>
    /// Returns AES-128 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AES128()
    {
        // CryptoHives managed implementation
        yield return new CipherAlgorithmType("AES", "AES-128 (Managed)", () => Aes128.Create());
    }

    /// <summary>
    /// Returns AES-192 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AES192()
    {
        // CryptoHives managed implementation
        yield return new CipherAlgorithmType("AES", "AES-192 (Managed)", () => Aes192.Create());
    }

    /// <summary>
    /// Returns AES-256 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AES256()
    {
        // CryptoHives managed implementation
        yield return new CipherAlgorithmType("AES", "AES-256 (Managed)", () => Aes256.Create());
    }

    /// <summary>
    /// Returns all AES implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AES()
    {
        foreach (var alg in AES128()) yield return alg;
        foreach (var alg in AES192()) yield return alg;
        foreach (var alg in AES256()) yield return alg;
    }

    // ========================================================================
    // ChaCha Family
    // ========================================================================

    /// <summary>
    /// Returns ChaCha20 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> ChaCha20()
    {
        // CryptoHives managed implementation (to be added in Phase 3)
        // yield return new CipherAlgorithmType("ChaCha", "ChaCha20 (Managed)", () => ChaCha20.Create());

        yield break;
    }

    /// <summary>
    /// Returns XChaCha20 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> XChaCha20()
    {
        yield break;
    }

    /// <summary>
    /// Returns all ChaCha implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> ChaCha()
    {
        foreach (var alg in ChaCha20()) yield return alg;
        foreach (var alg in XChaCha20()) yield return alg;
    }

    // ========================================================================
    // AEAD Family
    // ========================================================================

    /// <summary>
    /// Returns AES-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesGcm()
    {
        yield break;
    }

    /// <summary>
    /// Returns ChaCha20-Poly1305 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> ChaCha20Poly1305()
    {
        yield break;
    }

    /// <summary>
    /// Returns all AEAD cipher implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AEAD()
    {
        foreach (var alg in AesGcm()) yield return alg;
        foreach (var alg in ChaCha20Poly1305()) yield return alg;
    }

    // ========================================================================
    // Regional Standards
    // ========================================================================

    /// <summary>
    /// Returns SM4 implementations for benchmarking (Chinese standard).
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> SM4()
    {
        yield break;
    }

    /// <summary>
    /// Returns Camellia implementations for benchmarking (Japanese/EU standard).
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Camellia()
    {
        yield break;
    }

    // ========================================================================
    // All Ciphers
    // ========================================================================

    /// <summary>
    /// Returns all cipher implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> All()
    {
        foreach (var alg in AES()) yield return alg;
        foreach (var alg in ChaCha()) yield return alg;
        foreach (var alg in AEAD()) yield return alg;
        foreach (var alg in SM4()) yield return alg;
        foreach (var alg in Camellia()) yield return alg;
    }
}
