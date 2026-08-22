// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using Cryptography.Tests.Adapter.Kem;
using Cryptography.Tests.Kem;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Factory for creating KEM implementations for benchmarking.
/// </summary>
/// <remarks>
/// A BenchmarkDotNet-friendly wrapper around <see cref="KemAlgorithmRegistry"/>, mirroring
/// <c>CipherAlgorithmType</c> and <c>MacAlgorithmType</c>. <see cref="Category"/> is the
/// parameter set (the axis results group by) and <see cref="Name"/> carries the
/// "family (variant)" display name that <c>KemConfig</c> renders in the Description column.
/// </remarks>
public sealed class KemAlgorithmType : IFormattable
{
    private readonly Func<IKemRunner> _factory;
    private readonly Func<bool>? _isSupported;

    /// <summary>
    /// Initializes a new instance of the <see cref="KemAlgorithmType"/> class.
    /// </summary>
    /// <param name="category">The parameter set, e.g. <c>ML-KEM-768</c>.</param>
    /// <param name="name">The display name including the implementation variant.</param>
    /// <param name="factory">Creates the runner.</param>
    /// <param name="isSupported">Optional platform gate.</param>
    public KemAlgorithmType(string category, string name, Func<IKemRunner> factory, Func<bool>? isSupported = null)
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
    /// Gets the parameter set this entry belongs to.
    /// </summary>
    public string Category { get; }

    /// <summary>
    /// Gets a value indicating whether this implementation is available on the current platform.
    /// </summary>
    public bool IsSupported => _isSupported?.Invoke() ?? true;

    /// <summary>
    /// Creates a runner for this implementation.
    /// </summary>
    /// <returns>The runner.</returns>
    /// <exception cref="PlatformNotSupportedException">The implementation is unavailable here.</exception>
    public IKemRunner Create()
    {
        if (!IsSupported)
            throw new PlatformNotSupportedException($"KEM implementation '{Name}' is not supported on this platform.");
        return _factory();
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    /// <inheritdoc/>
    public override string ToString() => Name;

    // ========================================================================
    // Factory Methods Using KemAlgorithmRegistry
    // ========================================================================

    /// <summary>Returns every ML-KEM-512 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem512() => FromRegistry("ML-KEM-512", includeKeyGenOnly: false);

    /// <summary>Returns every ML-KEM-768 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem768() => FromRegistry("ML-KEM-768", includeKeyGenOnly: false);

    /// <summary>Returns every ML-KEM-1024 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem1024() => FromRegistry("ML-KEM-1024", includeKeyGenOnly: false);

    /// <summary>
    /// Returns the implementations to benchmark for encapsulation and decapsulation.
    /// </summary>
    /// <remarks>
    /// Excludes key-generation-only variants, whose encapsulation and decapsulation code is
    /// identical to a sibling entry — measuring them here would duplicate rows rather than
    /// add information. Use <see cref="MLKemKeyGen"/> for the key generation benchmark.
    /// </remarks>
    public static IEnumerable<KemAlgorithmType> MLKem() => All(includeKeyGenOnly: false);

    /// <summary>
    /// Returns the implementations to benchmark for key generation, including variants that
    /// differ only there — such as the one with the pairwise consistency test disabled.
    /// </summary>
    public static IEnumerable<KemAlgorithmType> MLKemKeyGen() => All(includeKeyGenOnly: true);

    private static IEnumerable<KemAlgorithmType> All(bool includeKeyGenOnly)
    {
        foreach (string family in KemAlgorithmRegistry.Families)
        {
            foreach (var algorithm in FromRegistry(family, includeKeyGenOnly))
            {
                yield return algorithm;
            }
        }
    }

    /// <remarks>
    /// Unsupported implementations are filtered out here rather than skipped later. The
    /// in-box <c>MLKem</c> is absent on platforms without a recent CNG or OpenSSL 3.5+, and
    /// BenchmarkDotNet has no notion of skipping a case at run time — a setup method that
    /// tried to opt out would fail the run instead.
    /// </remarks>
    private static IEnumerable<KemAlgorithmType> FromRegistry(string familyName, bool includeKeyGenOnly)
    {
        var implementations = KemAlgorithmRegistry.All
            .Where(impl =>
                impl.AlgorithmFamily == familyName &&
                impl.IsSupported &&
                !impl.ExcludeFromBenchmark &&
                (includeKeyGenOnly || !impl.KeyGenOnly))
            .ToList();

        foreach (var impl in implementations)
        {
            yield return new KemAlgorithmType(
                impl.AlgorithmFamily,
                impl.Name,
                impl.Factory,
                impl.SupportCheck);
        }
    }
}
