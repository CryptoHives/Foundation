// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0011 // Add braces

using Cryptography.Tests.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using CHCipher = CryptoHives.Foundation.Security.Cryptography.Cipher;

/// <summary>
/// Factory for creating cipher algorithm instances for benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// This class provides a BenchmarkDotNet-friendly wrapper for cipher implementations
/// from <see cref="CipherAlgorithmRegistry"/>.
/// </para>
/// <para>
/// Similar to <see cref="HashAlgorithmType"/>, this supports multiple implementations
/// of the same algorithm (OS, Managed, BouncyCastle) for comparison benchmarks.
/// </para>
/// </remarks>
public sealed class CipherAlgorithmType : IFormattable
{
    private readonly Func<object> _factory;
    private readonly Func<bool>? _isSupported;
    private readonly bool _isAead;

    /// <summary>
    /// Initializes a new instance of the <see cref="CipherAlgorithmType"/> class.
    /// </summary>
    /// <param name="category">The algorithm category (e.g., "AES-GCM", "ChaCha20-Poly1305").</param>
    /// <param name="name">The display name for this implementation.</param>
    /// <param name="factory">Factory function to create cipher instances.</param>
    /// <param name="isAead">Whether this is an AEAD cipher (vs traditional block cipher).</param>
    /// <param name="isSupported">Optional function to check platform support.</param>
    public CipherAlgorithmType(string category, string name, Func<object> factory, bool isAead, Func<bool>? isSupported = null)
    {
        Category = category;
        Name = name;
        _factory = factory;
        _isAead = isAead;
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
    /// Gets whether this is an AEAD cipher.
    /// </summary>
    public bool IsAead => _isAead;

    /// <summary>
    /// Gets whether this implementation is supported on the current platform.
    /// </summary>
    public bool IsSupported => _isSupported?.Invoke() ?? true;

    /// <summary>
    /// Creates an instance of the cipher algorithm.
    /// </summary>
    /// <exception cref="PlatformNotSupportedException">Thrown if the algorithm is not supported.</exception>
    public object Create()
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
    public bool TryCreate(out object? algorithm)
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
    // Factory Methods Using CipherAlgorithmRegistry
    // ========================================================================

    /// <summary>
    /// Returns AES-128-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesGcm128()
    {
        return FromRegistry("AES-128-GCM", CipherAlgorithmRegistry.Mode.GCM, 128);
    }

    /// <summary>
    /// Returns AES-192-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesGcm192()
    {
        return FromRegistry("AES-192-GCM", CipherAlgorithmRegistry.Mode.GCM, 192);
    }

    /// <summary>
    /// Returns AES-256-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesGcm256()
    {
        return FromRegistry("AES-256-GCM", CipherAlgorithmRegistry.Mode.GCM, 256);
    }

    /// <summary>
    /// Returns all AES-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesGcm()
    {
        foreach (var alg in AesGcm128()) yield return alg;
        foreach (var alg in AesGcm192()) yield return alg;
        foreach (var alg in AesGcm256()) yield return alg;
    }

    /// <summary>
    /// Returns AES-128-CCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesCcm128()
    {
        return FromRegistry("AES-128-CCM", CipherAlgorithmRegistry.Mode.CCM, 128);
    }

    /// <summary>
    /// Returns AES-192-CCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesCcm192()
    {
        return FromRegistry("AES-192-CCM", CipherAlgorithmRegistry.Mode.CCM, 192);
    }

    /// <summary>
    /// Returns AES-256-CCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesCcm256()
    {
        return FromRegistry("AES-256-CCM", CipherAlgorithmRegistry.Mode.CCM, 256);
    }

    /// <summary>
    /// Returns all AES-CCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AesCcm()
    {
        foreach (var alg in AesCcm128()) yield return alg;
        foreach (var alg in AesCcm192()) yield return alg;
        foreach (var alg in AesCcm256()) yield return alg;
    }

    /// <summary>
    /// Returns ChaCha20-Poly1305 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> ChaCha20Poly1305()
    {
        return FromRegistry("ChaCha20-Poly1305", CipherAlgorithmRegistry.Mode.ChaCha20Poly1305, 256);
    }

    /// <summary>
    /// Returns XChaCha20-Poly1305 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> XChaCha20Poly1305()
    {
        return FromRegistry("XChaCha20-Poly1305", CipherAlgorithmRegistry.Mode.XChaCha20Poly1305, 256);
    }

    /// <summary>
    /// Returns all AEAD cipher implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> AEAD()
    {
        foreach (var alg in AesGcm()) yield return alg;
        foreach (var alg in AesCcm()) yield return alg;
        foreach (var alg in ChaCha20Poly1305()) yield return alg;
        foreach (var alg in XChaCha20Poly1305()) yield return alg;
    }

    // ========================================================================
    // Helper Methods
    // ========================================================================

    /// <summary>
    /// Creates cipher algorithm types from the registry.
    /// </summary>
    private static IEnumerable<CipherAlgorithmType> FromRegistry(
        string familyName,
        CipherAlgorithmRegistry.Mode mode,
        int keySizeBits)
    {
        var implementations = CipherAlgorithmRegistry.All
            .Where(impl =>
                impl.AlgorithmFamily == familyName &&
                impl.CipherMode == mode &&
                impl.KeySizeBits == keySizeBits &&
                impl.IsSupported &&
                !impl.ExcludeFromBenchmark)
            .ToList();

        foreach (var impl in implementations)
        {
            string displayName = $"{familyName} ({SourceToString(impl.Source)})";
            bool isAead = IsAeadMode(mode);

            yield return new CipherAlgorithmType(
                familyName,
                displayName,
                impl.Factory,
                isAead,
                impl.SupportCheck
            );
        }
    }

    /// <summary>
    /// Converts source enum to display string.
    /// </summary>
    private static string SourceToString(CipherAlgorithmRegistry.Source source)
    {
        return source switch {
            CipherAlgorithmRegistry.Source.Managed => "Managed",
            CipherAlgorithmRegistry.Source.OS => "OS",
            CipherAlgorithmRegistry.Source.BouncyCastle => "BouncyCastle",
            CipherAlgorithmRegistry.Source.Regional => "Regional",
            _ => "Unknown"
        };
    }

    /// <summary>
    /// Checks if a mode is AEAD.
    /// </summary>
    private static bool IsAeadMode(CipherAlgorithmRegistry.Mode mode)
    {
        return mode == CipherAlgorithmRegistry.Mode.GCM ||
               mode == CipherAlgorithmRegistry.Mode.CCM ||
               mode == CipherAlgorithmRegistry.Mode.ChaCha20Poly1305 ||
               mode == CipherAlgorithmRegistry.Mode.XChaCha20Poly1305;
    }
}
