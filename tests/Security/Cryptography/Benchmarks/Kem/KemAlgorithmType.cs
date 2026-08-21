// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using CryptoHives.Foundation.Security.Cryptography.Kem;
using System;
using System.Collections.Generic;

/// <summary>
/// Factory for creating ML-KEM implementations for benchmarking, one entry per
/// (parameter set, implementation) pair.
/// </summary>
/// <remarks>
/// Mirrors <c>HashAlgorithmType</c> and <c>MacAlgorithmType</c>, but is written directly
/// rather than driven by a registry: there are only three parameter sets and four
/// implementations, and no KEM registry exists in the test project.
/// <para>
/// <see cref="Category"/> is the parameter set (the axis results are grouped by) and
/// <see cref="Name"/> carries the implementation suffix that <c>KemConfig</c> renders in
/// the Description column.
/// </para>
/// </remarks>
public sealed class KemAlgorithmType : IFormattable
{
    private readonly Func<IKemRunner> _factory;
    private readonly Func<bool>? _isSupported;

    /// <summary>
    /// Initializes a new instance of the <see cref="KemAlgorithmType"/> class.
    /// </summary>
    /// <param name="category">The parameter set, e.g. <c>ML-KEM-768</c>.</param>
    /// <param name="name">The display name including the implementation suffix.</param>
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
    // Factory Methods
    // ========================================================================

    /// <summary>Returns every ML-KEM-512 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem512() => ForParameterSet("ML-KEM-512");

    /// <summary>Returns every ML-KEM-768 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem768() => ForParameterSet("ML-KEM-768");

    /// <summary>Returns every ML-KEM-1024 implementation.</summary>
    public static IEnumerable<KemAlgorithmType> MLKem1024() => ForParameterSet("ML-KEM-1024");

    /// <summary>Returns every implementation of every parameter set.</summary>
    public static IEnumerable<KemAlgorithmType> All()
    {
        foreach (var alg in MLKem512()) yield return alg;
        foreach (var alg in MLKem768()) yield return alg;
        foreach (var alg in MLKem1024()) yield return alg;
    }

    private static IEnumerable<KemAlgorithmType> ForParameterSet(string category)
    {
        MLKemAlgorithm managed = ManagedAlgorithm(category);

        yield return new KemAlgorithmType(
            category, $"{category} (CryptoHives)", () => new MLKemKeyHoldingRunner(managed));

        yield return new KemAlgorithmType(
            category, $"{category} (CryptoHives-Stateless)", () => new MLKemStatelessRunner(StatelessKem(category)));

        yield return new KemAlgorithmType(
            category, $"{category} (BouncyCastle)", () => new BouncyCastleKemRunner(BouncyCastleParameters(category)));

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
        var dotnet = DotnetAlgorithm(category);
        yield return new KemAlgorithmType(
            category,
            $"{category} (OS)",
            () => new DotnetKemRunner(dotnet),
            () => System.Security.Cryptography.MLKem.IsSupported);
#pragma warning restore SYSLIB5006
#endif
    }

    private static MLKemAlgorithm ManagedAlgorithm(string category) => category switch {
        "ML-KEM-512" => MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };

    private static IKem StatelessKem(string category) => category switch {
        "ML-KEM-512" => CryptoHives.Foundation.Security.Cryptography.Kem.MLKem512.Create(),
        "ML-KEM-768" => CryptoHives.Foundation.Security.Cryptography.Kem.MLKem768.Create(),
        "ML-KEM-1024" => CryptoHives.Foundation.Security.Cryptography.Kem.MLKem1024.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };

    private static Org.BouncyCastle.Crypto.Parameters.MLKemParameters BouncyCastleParameters(string category) => category switch {
        "ML-KEM-512" => Org.BouncyCastle.Crypto.Parameters.MLKemParameters.ml_kem_512,
        "ML-KEM-768" => Org.BouncyCastle.Crypto.Parameters.MLKemParameters.ml_kem_768,
        "ML-KEM-1024" => Org.BouncyCastle.Crypto.Parameters.MLKemParameters.ml_kem_1024,
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
    private static System.Security.Cryptography.MLKemAlgorithm DotnetAlgorithm(string category) => category switch
    {
        "ML-KEM-512" => System.Security.Cryptography.MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => System.Security.Cryptography.MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => System.Security.Cryptography.MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };
#pragma warning restore SYSLIB5006
#endif
}
