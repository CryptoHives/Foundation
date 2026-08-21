// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem;

using Cryptography.Tests.Adapter.Kem;
using System;
using System.Collections.Generic;
using System.Linq;
using BC = Org.BouncyCastle.Crypto.Parameters;
using CH = CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Central registry of all KEM implementations for testing and benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// Mirrors <c>MacAlgorithmRegistry</c> and <c>HashAlgorithmRegistry</c>: a single source of
/// truth for KEM factories, so test sources and benchmark configurations do not each carry
/// their own list.
/// </para>
/// <para>
/// The family axis here is the FIPS 203 parameter set (ML-KEM-512/768/1024) rather than an
/// algorithm name, since one algorithm with three parameter sets is the whole of ML-KEM
/// today. A second KEM would add families alongside these.
/// </para>
/// <para>
/// Note the two CryptoHives entries per family. They are not redundant: the package exposes
/// a key-holding API that mirrors the in-box <c>MLKem</c> and a stateless span-based
/// <see cref="CH.IKem"/> for callers that own their key bytes, and they have different
/// per-call work — most visibly, the stateless path re-validates the decapsulation key on
/// every call. Measuring both is the point.
/// </para>
/// </remarks>
public static class KemAlgorithmRegistry
{
    /// <summary>
    /// Implementation source type.
    /// </summary>
    public enum Source
    {
        /// <summary>Operating system provided implementation.</summary>
        OS,

        /// <summary>CryptoHives managed implementation.</summary>
        Managed,

        /// <summary>BouncyCastle implementation.</summary>
        BouncyCastle
    }

    /// <summary>
    /// Represents a KEM implementation with metadata.
    /// </summary>
    public sealed class KemImplementation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KemImplementation"/> class.
        /// </summary>
        /// <param name="algorithmFamily">The parameter set, e.g. <c>ML-KEM-768</c>.</param>
        /// <param name="variant">The implementation variant, e.g. <c>BouncyCastle</c>.</param>
        /// <param name="factory">Creates a runner over this implementation.</param>
        /// <param name="source">Where the implementation comes from.</param>
        /// <param name="supportCheck">Optional platform gate.</param>
        /// <param name="excludeFromBenchmark">Whether to keep this out of benchmark runs.</param>
        public KemImplementation(
            string algorithmFamily,
            string variant,
            Func<IKemRunner> factory,
            Source source,
            Func<bool>? supportCheck = null,
            bool excludeFromBenchmark = false)
        {
            AlgorithmFamily = algorithmFamily;
            Variant = variant;
            Factory = factory;
            Source = source;
            SupportCheck = supportCheck;
            ExcludeFromBenchmark = excludeFromBenchmark;
        }

        /// <summary>Gets the parameter set name.</summary>
        public string AlgorithmFamily { get; }

        /// <summary>Gets the implementation variant.</summary>
        public string Variant { get; }

        /// <summary>Gets the factory function.</summary>
        public Func<IKemRunner> Factory { get; }

        /// <summary>Gets the implementation source type.</summary>
        public Source Source { get; }

        /// <summary>Gets the optional support check function.</summary>
        public Func<bool>? SupportCheck { get; }

        /// <summary>Gets a value indicating whether this implementation is excluded from benchmarks.</summary>
        public bool ExcludeFromBenchmark { get; }

        /// <summary>Gets the display name combining family and variant.</summary>
        public string Name => string.IsNullOrEmpty(Variant)
            ? AlgorithmFamily
            : $"{AlgorithmFamily} ({Variant})";

        /// <summary>Gets a value indicating whether this implementation is supported on the current platform.</summary>
        public bool IsSupported => SupportCheck?.Invoke() ?? true;

        /// <summary>Creates a runner over this KEM implementation.</summary>
        /// <returns>The runner.</returns>
        public IKemRunner Create() => Factory();

        /// <inheritdoc/>
        public override string ToString() => Name;
    }

    /// <summary>
    /// The parameter sets, in security-category order rather than alphabetical.
    /// </summary>
    public static readonly string[] Families = ["ML-KEM-512", "ML-KEM-768", "ML-KEM-1024"];

    private static readonly Lazy<List<KemImplementation>> AllImplementations = new(BuildRegistry);

    /// <summary>Gets all registered KEM implementations.</summary>
    public static IReadOnlyList<KemImplementation> All => AllImplementations.Value;

    /// <summary>Gets all supported implementations (filters out unsupported at runtime).</summary>
    public static IEnumerable<KemImplementation> Supported => All.Where(k => k.IsSupported);

    /// <summary>Gets all supported implementations that are suitable for benchmarking.</summary>
    public static IEnumerable<KemImplementation> Benchmarkable
        => All.Where(k => k.IsSupported && !k.ExcludeFromBenchmark);

    /// <summary>Gets implementations for a specific parameter set.</summary>
    /// <param name="family">The parameter set, e.g. <c>ML-KEM-768</c>.</param>
    /// <returns>The matching implementations.</returns>
    public static IEnumerable<KemImplementation> ByFamily(string family)
        => All.Where(k => k.AlgorithmFamily.Equals(family, StringComparison.OrdinalIgnoreCase));

    /// <summary>Gets only CryptoHives implementations.</summary>
    public static IEnumerable<KemImplementation> CryptoHivesOnly
        => All.Where(k => k.Source == Source.Managed);

    private static List<KemImplementation> BuildRegistry()
    {
        var list = new List<KemImplementation>();

        foreach (string family in Families)
        {
            AddFamily(list, family);
        }

        return list;
    }

    private static void AddFamily(List<KemImplementation> list, string family)
    {
        CH.MLKemAlgorithm managed = ManagedAlgorithm(family);
        BC.MLKemParameters bouncyCastle = BouncyCastleParameters(family);

        list.Add(new(family, "CryptoHives",
            () => new MLKemAdapter(managed), Source.Managed));

        list.Add(new(family, "CryptoHives-Stateless",
            () => new MLKemStatelessAdapter(StatelessKem(family)), Source.Managed));

        list.Add(new(family, "BouncyCastle",
            () => new BouncyCastleKemAdapter(bouncyCastle), Source.BouncyCastle));

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
        System.Security.Cryptography.MLKemAlgorithm os = OSAlgorithm(family);
        list.Add(new(family, "OS",
            () => new OSKemAdapter(os),
            Source.OS,
            supportCheck: () => System.Security.Cryptography.MLKem.IsSupported));
#pragma warning restore SYSLIB5006
#endif
    }

    private static CH.MLKemAlgorithm ManagedAlgorithm(string family) => family switch {
        "ML-KEM-512" => CH.MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => CH.MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => CH.MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static CH.IKem StatelessKem(string family) => family switch {
        "ML-KEM-512" => CH.MLKem512.Create(),
        "ML-KEM-768" => CH.MLKem768.Create(),
        "ML-KEM-1024" => CH.MLKem1024.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static BC.MLKemParameters BouncyCastleParameters(string family) => family switch {
        "ML-KEM-512" => BC.MLKemParameters.ml_kem_512,
        "ML-KEM-768" => BC.MLKemParameters.ml_kem_768,
        "ML-KEM-1024" => BC.MLKemParameters.ml_kem_1024,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
    private static System.Security.Cryptography.MLKemAlgorithm OSAlgorithm(string family) => family switch
    {
        "ML-KEM-512" => System.Security.Cryptography.MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => System.Security.Cryptography.MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => System.Security.Cryptography.MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };
#pragma warning restore SYSLIB5006
#endif
}
