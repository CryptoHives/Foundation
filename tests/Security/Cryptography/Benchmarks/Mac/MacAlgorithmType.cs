// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using Cryptography.Tests.Mac;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Factory for creating MAC algorithm instances for benchmarking.
/// </summary>
/// <remarks>
/// This class provides a BenchmarkDotNet-friendly wrapper around the central
/// <see cref="MacAlgorithmRegistry"/> for benchmark scenarios, mirroring <c>HashAlgorithmType</c>.
/// </remarks>
public sealed class MacAlgorithmType : IFormattable
{
    private readonly Func<IMac> _factory;
    private readonly Func<bool>? _isSupported;

    /// <summary>
    /// Initializes a new instance of the <see cref="MacAlgorithmType"/> class.
    /// </summary>
    public MacAlgorithmType(string category, string name, Func<IMac> factory, Func<bool>? isSupported = null)
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
    /// Creates an instance of the MAC algorithm.
    /// </summary>
    /// <exception cref="PlatformNotSupportedException">Thrown if the algorithm is not supported.</exception>
    public IMac Create()
    {
        if (!IsSupported)
            throw new PlatformNotSupportedException($"MAC algorithm '{Name}' is not supported on this platform.");
        return _factory();
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    /// <inheritdoc/>
    public override string ToString() => Name;

    #region Registry Bridge

    /// <summary>
    /// Creates a <see cref="MacAlgorithmType"/> from a registry implementation.
    /// </summary>
    public static MacAlgorithmType FromImplementation(MacAlgorithmRegistry.MacImplementation impl)
        => new(impl.AlgorithmFamily, impl.Name, impl.Create, () => impl.IsSupported);

    private static IEnumerable<MacAlgorithmType> FromFamily(string family)
        => MacAlgorithmRegistry.ByFamily(family)
            .Where(m => m.IsSupported && !m.ExcludeFromBenchmark)
            .Select(FromImplementation);

    #endregion

    #region HMAC Individual Algorithms

    /// <summary>HMAC-MD5 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacMd5() => FromFamily("HMAC-MD5");

    /// <summary>HMAC-SHA1 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha1() => FromFamily("HMAC-SHA1");

    /// <summary>HMAC-SHA256 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha256() => FromFamily("HMAC-SHA256");

    /// <summary>HMAC-SHA384 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha384() => FromFamily("HMAC-SHA384");

    /// <summary>HMAC-SHA512 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha512() => FromFamily("HMAC-SHA512");

    /// <summary>HMAC-SHA3-256 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha3_256() => FromFamily("HMAC-SHA3-256");

    /// <summary>HMAC-SHA3-384 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha3_384() => FromFamily("HMAC-SHA3-384");

    /// <summary>HMAC-SHA3-512 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> HmacSha3_512() => FromFamily("HMAC-SHA3-512");

    #endregion

    #region CMAC / Poly1305

    /// <summary>AES-CMAC implementations.</summary>
    public static IEnumerable<MacAlgorithmType> AesCmac() => FromFamily("AES-CMAC");

    /// <summary>Poly1305 implementations.</summary>
    public static IEnumerable<MacAlgorithmType> Poly1305() => FromFamily("Poly1305");

    #endregion
}
