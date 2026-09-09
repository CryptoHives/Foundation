// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa;

using Cryptography.Tests.Adapter.Dsa;
using System;
using System.Collections.Generic;
using System.Linq;
using BC = Org.BouncyCastle.Crypto.Parameters;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Central registry of all signature implementations for testing and benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// Mirrors <c>KemAlgorithmRegistry</c>, <c>MacAlgorithmRegistry</c> and
/// <c>HashAlgorithmRegistry</c>: a single source of truth for signature factories, so test
/// sources and benchmark configurations do not each carry their own list.
/// </para>
/// <para>
/// The family axis here is the parameter set rather than the algorithm name: ML-DSA-44/65/87
/// from FIPS 204, then the twelve FIPS 205 SLH-DSA sets alongside them.
/// </para>
/// <para>
/// Note the two CryptoHives entries per ML-DSA family. They are not redundant: the package
/// exposes a key-holding API that mirrors the in-box <c>MLDsa</c> and a stateless span-based
/// <see cref="CH.IDsa"/> for callers that own their key bytes, and they have different
/// per-call work — most visibly, the stateless path decodes the private key on every call.
/// Measuring both is the point. SLH-DSA has no stateless entry, because it has no per-set
/// <see cref="CH.IDsa"/> wrappers — that interface takes a 32-byte seed ξ, and SLH-DSA key
/// generation consumes three n-byte seeds.
/// </para>
/// <para>
/// There is no independent managed competitor here the way ML-KEM has KyberNET; for the
/// signature schemes everything outside BouncyCastle is the OS or a wrapper over it.
/// </para>
/// </remarks>
public static class DsaAlgorithmRegistry
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
    /// Represents a signature implementation with metadata.
    /// </summary>
    public sealed class DsaImplementation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsaImplementation"/> class.
        /// </summary>
        /// <param name="algorithmFamily">The parameter set, e.g. <c>ML-DSA-65</c>.</param>
        /// <param name="variant">The implementation variant, e.g. <c>BouncyCastle</c>.</param>
        /// <param name="factory">Creates a runner over this implementation.</param>
        /// <param name="source">Where the implementation comes from.</param>
        /// <param name="supportCheck">Optional platform gate.</param>
        /// <param name="excludeFromBenchmark">Whether to keep this out of benchmark runs.</param>
        /// <param name="keyGenOnly">
        /// Whether this variant differs from another entry only in key generation, so it
        /// belongs in the key generation benchmark and nowhere else.
        /// </param>
        public DsaImplementation(
            string algorithmFamily,
            string variant,
            Func<IDsaRunner> factory,
            Source source,
            Func<bool>? supportCheck = null,
            bool excludeFromBenchmark = false,
            bool keyGenOnly = false)
        {
            AlgorithmFamily = algorithmFamily;
            Variant = variant;
            Factory = factory;
            Source = source;
            SupportCheck = supportCheck;
            ExcludeFromBenchmark = excludeFromBenchmark;
            KeyGenOnly = keyGenOnly;
        }

        /// <summary>Gets the parameter set name.</summary>
        public string AlgorithmFamily { get; }

        /// <summary>Gets the implementation variant.</summary>
        public string Variant { get; }

        /// <summary>Gets the factory function.</summary>
        public Func<IDsaRunner> Factory { get; }

        /// <summary>Gets the implementation source type.</summary>
        public Source Source { get; }

        /// <summary>Gets the optional support check function.</summary>
        public Func<bool>? SupportCheck { get; }

        /// <summary>Gets a value indicating whether this implementation is excluded from benchmarks.</summary>
        public bool ExcludeFromBenchmark { get; }

        /// <summary>
        /// Gets a value indicating whether this variant is only meaningful for key generation.
        /// </summary>
        /// <remarks>
        /// Set for variants that differ from a sibling entry solely in how a key pair is
        /// produced. Signing and verification run identical code, so listing them in those
        /// benchmarks would measure the same thing twice under two names.
        /// </remarks>
        public bool KeyGenOnly { get; }

        /// <summary>Gets the display name combining family and variant.</summary>
        public string Name => string.IsNullOrEmpty(Variant)
            ? AlgorithmFamily
            : $"{AlgorithmFamily} ({Variant})";

        /// <summary>Gets a value indicating whether this implementation is supported on the current platform.</summary>
        public bool IsSupported => SupportCheck?.Invoke() ?? true;

        /// <summary>Creates a runner over this signature implementation.</summary>
        /// <returns>The runner.</returns>
        public IDsaRunner Create() => Factory();

        /// <inheritdoc/>
        public override string ToString() => Name;
    }

    /// <summary>
    /// The ML-DSA parameter sets, in security-category order rather than alphabetical.
    /// </summary>
    public static readonly string[] MLDsaFamilies = ["ML-DSA-44", "ML-DSA-65", "ML-DSA-87"];

    /// <summary>
    /// The SLH-DSA parameter sets, in security-category order and then <c>s</c> before <c>f</c>.
    /// </summary>
    public static readonly string[] SlhDsaFamilies =
    [
        "SLH-DSA-SHA2-128s", "SLH-DSA-SHAKE-128s", "SLH-DSA-SHA2-128f", "SLH-DSA-SHAKE-128f",
        "SLH-DSA-SHA2-192s", "SLH-DSA-SHAKE-192s", "SLH-DSA-SHA2-192f", "SLH-DSA-SHAKE-192f",
        "SLH-DSA-SHA2-256s", "SLH-DSA-SHAKE-256s", "SLH-DSA-SHA2-256f", "SLH-DSA-SHAKE-256f",
    ];

    /// <summary>
    /// Every parameter set, ML-DSA first.
    /// </summary>
    public static readonly string[] Families = [.. MLDsaFamilies, .. SlhDsaFamilies];

    private static readonly Lazy<List<DsaImplementation>> AllImplementations = new(BuildRegistry);

    /// <summary>Gets all registered signature implementations.</summary>
    public static IReadOnlyList<DsaImplementation> All => AllImplementations.Value;

    /// <summary>Gets all supported implementations (filters out unsupported at runtime).</summary>
    public static IEnumerable<DsaImplementation> Supported => All.Where(d => d.IsSupported);

    /// <summary>Gets all supported implementations that are suitable for benchmarking.</summary>
    public static IEnumerable<DsaImplementation> Benchmarkable
        => All.Where(d => d.IsSupported && !d.ExcludeFromBenchmark);

    /// <summary>Gets implementations for a specific parameter set.</summary>
    /// <param name="family">The parameter set, e.g. <c>ML-DSA-65</c>.</param>
    /// <returns>The matching implementations.</returns>
    public static IEnumerable<DsaImplementation> ByFamily(string family)
        => All.Where(d => d.AlgorithmFamily.Equals(family, StringComparison.OrdinalIgnoreCase));

    /// <summary>Gets only CryptoHives implementations.</summary>
    public static IEnumerable<DsaImplementation> CryptoHivesOnly
        => All.Where(d => d.Source == Source.Managed);

    private static List<DsaImplementation> BuildRegistry()
    {
        var list = new List<DsaImplementation>();

        foreach (string family in MLDsaFamilies)
        {
            AddFamily(list, family);
        }

        foreach (string family in SlhDsaFamilies)
        {
            AddSlhDsaFamily(list, family);
        }

        return list;
    }

    private static void AddFamily(List<DsaImplementation> list, string family)
    {
        CH.MLDsaAlgorithm managed = ManagedAlgorithm(family);
        BC.MLDsaParameters bouncyCastle = BouncyCastleParameters(family);

        list.Add(new(family, "CryptoHives",
            () => new MLDsaAdapter(managed), Source.Managed));

        // Same implementation with the FIPS 140-3 pairwise consistency test turned off, so the
        // key generation table can show what that check costs against the other libraries. For
        // ML-DSA that is the interesting row: the check performs a full signature, itself a
        // rejection loop, so it dominates key generation rather than merely adding to it.
        // Marked keyGenOnly: signing and verification are byte-identical to the entry above,
        // and listing them again would just measure the same code under a second name.
        list.Add(new(family, "CryptoHives-NoPct",
            () => new MLDsaAdapter(managed, pairwiseConsistencyTest: false), Source.Managed,
            keyGenOnly: true));

        list.Add(new(family, "CryptoHives-Stateless",
            () => new MLDsaStatelessAdapter(StatelessDsa(family)), Source.Managed));

        list.Add(new(family, "BouncyCastle",
            () => new BouncyCastleDsaAdapter(bouncyCastle, managed.PublicKeySizeInBytes,
                managed.PrivateKeySizeInBytes, managed.SignatureSizeInBytes),
            Source.BouncyCastle));

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
        System.Security.Cryptography.MLDsaAlgorithm os = OSAlgorithm(family);
        list.Add(new(family, "OS",
            () => new OSDsaAdapter(os),
            Source.OS,
            supportCheck: () => System.Security.Cryptography.MLDsa.IsSupported));
#pragma warning restore SYSLIB5006
#endif
    }

    private static void AddSlhDsaFamily(List<DsaImplementation> list, string family)
    {
        CH.SlhDsaAlgorithm managed = ManagedSlhDsaAlgorithm(family);
        BC.SlhDsaParameters bouncyCastle = BouncyCastleSlhDsaParameters(family);

        // The 's' (small-signature) sets are correctness-tested but not benchmarked. Signing with
        // one is on the order of 10^6 hash invocations — seconds per operation — so including
        // them would turn a signature benchmark run into an overnight job for rows whose ranking
        // is not in doubt. SlhDsaTests.FullMatrix_SignVerify_RoundTrips covers them instead, and
        // the ACVP suite covers all twelve sets unconditionally.
        bool slowSet = family[^1] == 's';

        list.Add(new(family, "CryptoHives",
            () => new SlhDsaAdapter(managed), Source.Managed,
            excludeFromBenchmark: slowSet));

        // Same implementation with the FIPS 140-3 pairwise consistency test turned off. For
        // ML-DSA that check merely dominates key generation; for SLH-DSA it is a different
        // operation entirely — generating a key builds one XMSS tree, while the check signs,
        // which walks the whole hypertree. The two rows differ by orders of magnitude.
        list.Add(new(family, "CryptoHives-NoPct",
            () => new SlhDsaAdapter(managed, pairwiseConsistencyTest: false), Source.Managed,
            excludeFromBenchmark: slowSet,
            keyGenOnly: true));

        list.Add(new(family, "BouncyCastle",
            () => new BouncyCastleSlhDsaAdapter(bouncyCastle, managed.PublicKeySizeInBytes,
                managed.PrivateKeySizeInBytes, managed.SignatureSizeInBytes),
            Source.BouncyCastle,
            excludeFromBenchmark: slowSet));

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
        System.Security.Cryptography.SlhDsaAlgorithm os = OSSlhDsaAlgorithm(family);
        list.Add(new(family, "OS",
            () => new OSSlhDsaAdapter(os),
            Source.OS,
            supportCheck: () => System.Security.Cryptography.SlhDsa.IsSupported,
            excludeFromBenchmark: slowSet));
#pragma warning restore SYSLIB5006
#endif
    }

    private static CH.MLDsaAlgorithm ManagedAlgorithm(string family) => family switch {
        "ML-DSA-44" => CH.MLDsaAlgorithm.MLDsa44,
        "ML-DSA-65" => CH.MLDsaAlgorithm.MLDsa65,
        "ML-DSA-87" => CH.MLDsaAlgorithm.MLDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static CH.IDsa StatelessDsa(string family) => family switch {
        "ML-DSA-44" => CH.MLDsa44.Create(),
        "ML-DSA-65" => CH.MLDsa65.Create(),
        "ML-DSA-87" => CH.MLDsa87.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static BC.MLDsaParameters BouncyCastleParameters(string family) => family switch {
        "ML-DSA-44" => BC.MLDsaParameters.ml_dsa_44,
        "ML-DSA-65" => BC.MLDsaParameters.ml_dsa_65,
        "ML-DSA-87" => BC.MLDsaParameters.ml_dsa_87,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static CH.SlhDsaAlgorithm ManagedSlhDsaAlgorithm(string family) => family switch {
        "SLH-DSA-SHA2-128s" => CH.SlhDsaAlgorithm.SlhDsaSha2_128s,
        "SLH-DSA-SHAKE-128s" => CH.SlhDsaAlgorithm.SlhDsaShake128s,
        "SLH-DSA-SHA2-128f" => CH.SlhDsaAlgorithm.SlhDsaSha2_128f,
        "SLH-DSA-SHAKE-128f" => CH.SlhDsaAlgorithm.SlhDsaShake128f,
        "SLH-DSA-SHA2-192s" => CH.SlhDsaAlgorithm.SlhDsaSha2_192s,
        "SLH-DSA-SHAKE-192s" => CH.SlhDsaAlgorithm.SlhDsaShake192s,
        "SLH-DSA-SHA2-192f" => CH.SlhDsaAlgorithm.SlhDsaSha2_192f,
        "SLH-DSA-SHAKE-192f" => CH.SlhDsaAlgorithm.SlhDsaShake192f,
        "SLH-DSA-SHA2-256s" => CH.SlhDsaAlgorithm.SlhDsaSha2_256s,
        "SLH-DSA-SHAKE-256s" => CH.SlhDsaAlgorithm.SlhDsaShake256s,
        "SLH-DSA-SHA2-256f" => CH.SlhDsaAlgorithm.SlhDsaSha2_256f,
        "SLH-DSA-SHAKE-256f" => CH.SlhDsaAlgorithm.SlhDsaShake256f,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static BC.SlhDsaParameters BouncyCastleSlhDsaParameters(string family) => family switch {
        "SLH-DSA-SHA2-128s" => BC.SlhDsaParameters.slh_dsa_sha2_128s,
        "SLH-DSA-SHAKE-128s" => BC.SlhDsaParameters.slh_dsa_shake_128s,
        "SLH-DSA-SHA2-128f" => BC.SlhDsaParameters.slh_dsa_sha2_128f,
        "SLH-DSA-SHAKE-128f" => BC.SlhDsaParameters.slh_dsa_shake_128f,
        "SLH-DSA-SHA2-192s" => BC.SlhDsaParameters.slh_dsa_sha2_192s,
        "SLH-DSA-SHAKE-192s" => BC.SlhDsaParameters.slh_dsa_shake_192s,
        "SLH-DSA-SHA2-192f" => BC.SlhDsaParameters.slh_dsa_sha2_192f,
        "SLH-DSA-SHAKE-192f" => BC.SlhDsaParameters.slh_dsa_shake_192f,
        "SLH-DSA-SHA2-256s" => BC.SlhDsaParameters.slh_dsa_sha2_256s,
        "SLH-DSA-SHAKE-256s" => BC.SlhDsaParameters.slh_dsa_shake_256s,
        "SLH-DSA-SHA2-256f" => BC.SlhDsaParameters.slh_dsa_sha2_256f,
        "SLH-DSA-SHAKE-256f" => BC.SlhDsaParameters.slh_dsa_shake_256f,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.
    private static System.Security.Cryptography.MLDsaAlgorithm OSAlgorithm(string family) => family switch
    {
        "ML-DSA-44" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa44,
        "ML-DSA-65" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa65,
        "ML-DSA-87" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };

    private static System.Security.Cryptography.SlhDsaAlgorithm OSSlhDsaAlgorithm(string family) => family switch
    {
        "SLH-DSA-SHA2-128s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_128s,
        "SLH-DSA-SHAKE-128s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake128s,
        "SLH-DSA-SHA2-128f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_128f,
        "SLH-DSA-SHAKE-128f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake128f,
        "SLH-DSA-SHA2-192s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_192s,
        "SLH-DSA-SHAKE-192s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake192s,
        "SLH-DSA-SHA2-192f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_192f,
        "SLH-DSA-SHAKE-192f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake192f,
        "SLH-DSA-SHA2-256s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_256s,
        "SLH-DSA-SHAKE-256s" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake256s,
        "SLH-DSA-SHA2-256f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_256f,
        "SLH-DSA-SHAKE-256f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake256f,
        _ => throw new ArgumentException($"Unknown parameter set: {family}", nameof(family)),
    };
#pragma warning restore SYSLIB5006
#endif
}
