// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using Cryptography.Tests.Adapter;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using CH = CryptoHives.Foundation.Security.Cryptography.Cipher;

/// <summary>
/// Central registry of all cipher algorithm implementations for testing and benchmarking.
/// </summary>
/// <remarks>
/// <para>
/// This registry provides a single source of truth for all cipher algorithm factories,
/// mirroring the pattern established by HashAlgorithmRegistry.
/// </para>
/// <para>
/// Supports multiple implementation sources: OS, Managed, BouncyCastle, Regional, etc.
/// </para>
/// </remarks>
public static class CipherAlgorithmRegistry
{
    /// <summary>
    /// Implementation source type.
    /// </summary>
    public enum Source
    {
        /// <summary>Operating system provided implementation (.NET System.Security.Cryptography).</summary>
        OS,
        /// <summary>CryptoHives managed implementation.</summary>
        Managed,
        /// <summary>BouncyCastle implementation.</summary>
        BouncyCastle,
        /// <summary>Regional implementation (e.g., OpenGost SM4).</summary>
        Regional
    }

    /// <summary>
    /// Cipher mode type.
    /// </summary>
    public enum Mode
    {
        /// <summary>Electronic Codebook mode.</summary>
        ECB,
        /// <summary>Cipher Block Chaining mode.</summary>
        CBC,
        /// <summary>Counter mode.</summary>
        CTR,
        /// <summary>Galois/Counter Mode (AEAD).</summary>
        GCM,
        /// <summary>Counter with CBC-MAC (AEAD).</summary>
        CCM,
        /// <summary>ChaCha20-Poly1305 (AEAD).</summary>
        ChaCha20Poly1305,
        /// <summary>XChaCha20-Poly1305 (AEAD).</summary>
        XChaCha20Poly1305,
        /// <summary>Stream cipher.</summary>
        Stream
    }

    /// <summary>
    /// Represents a cipher algorithm implementation with metadata.
    /// </summary>
    public sealed class CipherImplementation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CipherImplementation"/> class.
        /// </summary>
        /// <param name="algorithmFamily">Algorithm family name (e.g., "AES-128-GCM", "ChaCha20-Poly1305").</param>
        /// <param name="variant">Implementation variant (e.g., "Managed", "BouncyCastle", "OS").</param>
        /// <param name="keySizeBits">Key size in bits.</param>
        /// <param name="mode">Cipher mode.</param>
        /// <param name="factory">Factory function to create the cipher.</param>
        /// <param name="source">Implementation source type.</param>
        /// <param name="supportCheck">Optional function to check if implementation is supported at runtime.</param>
        /// <param name="excludeFromBenchmark">Whether to exclude this implementation from benchmarks.</param>
        public CipherImplementation(
            string algorithmFamily,
            string variant,
            int keySizeBits,
            Mode mode,
            Func<object> factory,
            Source source,
            Func<bool>? supportCheck = null,
            bool excludeFromBenchmark = false)
        {
            AlgorithmFamily = algorithmFamily;
            Variant = variant;
            KeySizeBits = keySizeBits;
            CipherMode = mode;
            Factory = factory;
            Source = source;
            SupportCheck = supportCheck;
            ExcludeFromBenchmark = excludeFromBenchmark;
        }

        /// <summary>
        /// Gets the algorithm family name.
        /// </summary>
        public string AlgorithmFamily { get; }

        /// <summary>
        /// Gets the implementation variant.
        /// </summary>
        public string Variant { get; }

        /// <summary>
        /// Gets the key size in bits.
        /// </summary>
        public int KeySizeBits { get; }

        /// <summary>
        /// Gets the cipher mode.
        /// </summary>
        public Mode CipherMode { get; }

        /// <summary>
        /// Gets the factory function.
        /// </summary>
        public Func<object> Factory { get; }

        /// <summary>
        /// Gets the implementation source type.
        /// </summary>
        public Source Source { get; }

        /// <summary>
        /// Gets the optional support check function.
        /// </summary>
        public Func<bool>? SupportCheck { get; }

        /// <summary>
        /// Gets whether this implementation should be excluded from benchmarks.
        /// </summary>
        public bool ExcludeFromBenchmark { get; }

        /// <summary>
        /// Gets the display name combining family and variant.
        /// </summary>
        public string Name => string.IsNullOrEmpty(Variant)
            ? AlgorithmFamily
            : $"{AlgorithmFamily} ({Variant})";

        /// <summary>
        /// Gets whether this implementation is supported on the current platform.
        /// </summary>
        public bool IsSupported => SupportCheck?.Invoke() ?? true;

        /// <summary>
        /// Creates a new instance of the cipher.
        /// </summary>
        public object Create() => Factory();

        /// <inheritdoc/>
        public override string ToString() => Name;
    }

    private static readonly Lazy<List<CipherImplementation>> _allImplementations = new(BuildRegistry);

    /// <summary>
    /// Gets all registered cipher algorithm implementations.
    /// </summary>
    public static IReadOnlyList<CipherImplementation> All => _allImplementations.Value;

    /// <summary>
    /// Gets all supported implementations (filters out unsupported at runtime).
    /// </summary>
    public static IEnumerable<CipherImplementation> Supported =>
        All.Where(impl => impl.IsSupported);

    /// <summary>
    /// Gets implementations suitable for benchmarking.
    /// </summary>
    public static IEnumerable<CipherImplementation> Benchmarkable =>
        Supported.Where(impl => !impl.ExcludeFromBenchmark);

    /// <summary>
    /// Gets implementations from CryptoHives only (excludes external libraries).
    /// </summary>
    public static IEnumerable<CipherImplementation> CryptoHivesOnly =>
        Supported.Where(impl => impl.Source is Source.Managed or Source.OS);

    /// <summary>
    /// Gets implementations by algorithm family.
    /// </summary>
    /// <param name="familyName">Algorithm family name (case-insensitive).</param>
    public static IEnumerable<CipherImplementation> ByFamily(string familyName) =>
        Supported.Where(impl => impl.AlgorithmFamily.Equals(familyName, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Gets implementations by source.
    /// </summary>
    public static IEnumerable<CipherImplementation> BySource(Source source) =>
        Supported.Where(impl => impl.Source == source);

    /// <summary>
    /// Gets implementations by mode.
    /// </summary>
    public static IEnumerable<CipherImplementation> ByMode(Mode mode) =>
        Supported.Where(impl => impl.CipherMode == mode);

    private static List<CipherImplementation> BuildRegistry()
    {
        var implementations = new List<CipherImplementation>();

        // AES Implementations
        AddAesImplementations(implementations);

        // ChaCha Implementations
        AddChaChaImplementations(implementations);

        // OS Implementations (.NET 8.0+)
        AddOSImplementations(implementations);

        return implementations;
    }

    private static void AddAesImplementations(List<CipherImplementation> implementations)
    {
        // AES-128-GCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-128-GCM",
            "Managed",
            128,
            Mode.GCM,
            () => CH.AesGcm128.Create(new byte[16]),
            Source.Managed));

        // AES-128-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-128-GCM",
            "BouncyCastle",
            128,
            Mode.GCM,
            () => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                new byte[16],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-192-GCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "Managed",
            192,
            Mode.GCM,
            () => CH.AesGcm192.Create(new byte[24]),
            Source.Managed));

        // AES-192-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "BouncyCastle",
            192,
            Mode.GCM,
            () => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                new byte[24],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-256-GCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "Managed",
            256,
            Mode.GCM,
            () => CH.AesGcm256.Create(new byte[32]),
            Source.Managed));

        // AES-256-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "BouncyCastle",
            256,
            Mode.GCM,
            () => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                new byte[32],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-128-CCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-128-CCM",
            "Managed",
            128,
            Mode.CCM,
            () => CH.AesCcm128.Create(new byte[16]),
            Source.Managed));

        // AES-128-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-128-CCM",
            "BouncyCastle",
            128,
            Mode.CCM,
            () => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                new byte[16],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-192-CCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-192-CCM",
            "Managed",
            192,
            Mode.CCM,
            () => CH.AesCcm192.Create(new byte[24]),
            Source.Managed));

        // AES-192-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-192-CCM",
            "BouncyCastle",
            192,
            Mode.CCM,
            () => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                new byte[24],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-256-CCM - Managed
        implementations.Add(new CipherImplementation(
            "AES-256-CCM",
            "Managed",
            256,
            Mode.CCM,
            () => CH.AesCcm256.Create(new byte[32]),
            Source.Managed));

        // AES-256-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-256-CCM",
            "BouncyCastle",
            256,
            Mode.CCM,
            () => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                new byte[32],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));
    }

    private static void AddChaChaImplementations(List<CipherImplementation> implementations)
    {
        // ChaCha20-Poly1305 - Managed
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "Managed",
            256,
            Mode.ChaCha20Poly1305,
            () => CH.ChaCha20Poly1305.Create(new byte[32]),
            Source.Managed));

        // ChaCha20-Poly1305 - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "BouncyCastle",
            256,
            Mode.ChaCha20Poly1305,
            () => new BouncyCastleAeadAdapter(
                new ChaCha20Poly1305(),
                new byte[32],
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // XChaCha20-Poly1305 - Managed
        implementations.Add(new CipherImplementation(
            "XChaCha20-Poly1305",
            "Managed",
            256,
            Mode.XChaCha20Poly1305,
            () => CH.XChaCha20Poly1305.Create(new byte[32]),
            Source.Managed));
    }

    private static void AddOSImplementations(List<CipherImplementation> implementations)
    {
#if NET8_0_OR_GREATER
        // AES-128-GCM - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-128-GCM",
            "OS",
            128,
            Mode.GCM,
            () => new OSAesGcmAdapter(new byte[16]),
            Source.OS,
            supportCheck: () => OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS()));

        // AES-192-GCM - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "OS",
            192,
            Mode.GCM,
            () => new OSAesGcmAdapter(new byte[24]),
            Source.OS,
            supportCheck: () => OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS()));

        // AES-256-GCM - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "OS",
            256,
            Mode.GCM,
            () => new OSAesGcmAdapter(new byte[32]),
            Source.OS,
            supportCheck: () => OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS()));
#endif

#if NET9_0_OR_GREATER
        // ChaCha20-Poly1305 - OS (.NET 9.0+)
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "OS",
            256,
            Mode.ChaCha20Poly1305,
            () => new OSChaCha20Poly1305Adapter(new byte[32]),
            Source.OS,
            supportCheck: () => OperatingSystem.IsWindows() || OperatingSystem.IsLinux() || OperatingSystem.IsMacOS()));
#endif
    }
}
