// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Cipher;

using Cryptography.Tests.Adapter.Cipher;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using CH = CryptoHives.Foundation.Security.Cryptography;
using OS = System.Security.Cryptography;

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
        /// <summary>CryptoHives SIMD-optimized implementation.</summary>
        Simd,
        /// <summary>BouncyCastle implementation.</summary>
        BouncyCastle,
        /// <summary>NaCl.Core implementation.</summary>
        NaClCore,
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
        /// <summary>Ascon-AEAD128 (AEAD).</summary>
        AsconAead128,
        /// <summary>Stream cipher.</summary>
        Stream
    }

    /// <summary>
    /// Represents a cipher algorithm implementation with metadata.
    /// </summary>
    public sealed class CipherImplementation
    {
        private readonly Func<byte[], object> _keyedFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CipherImplementation"/> class.
        /// </summary>
        /// <param name="algorithmFamily">Algorithm family name (e.g., "AES-128-GCM", "ChaCha20-Poly1305").</param>
        /// <param name="variant">Implementation variant (e.g., "CryptoHives-Scalar", "BouncyCastle", "OS").</param>
        /// <param name="keySizeBits">Key size in bits.</param>
        /// <param name="mode">Cipher mode.</param>
        /// <param name="factory">Factory function to create the cipher (uses a default zero key).</param>
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
            : this(algorithmFamily, variant, keySizeBits, mode, _ => factory(), source, supportCheck, excludeFromBenchmark)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CipherImplementation"/> class
        /// with a key-parameterized factory.
        /// </summary>
        /// <param name="algorithmFamily">Algorithm family name (e.g., "AES-128-GCM", "ChaCha20-Poly1305").</param>
        /// <param name="variant">Implementation variant (e.g., "CryptoHives-Scalar", "BouncyCastle", "OS").</param>
        /// <param name="keySizeBits">Key size in bits.</param>
        /// <param name="mode">Cipher mode.</param>
        /// <param name="keyedFactory">Factory function that accepts a key to create the cipher.</param>
        /// <param name="source">Implementation source type.</param>
        /// <param name="supportCheck">Optional function to check if implementation is supported at runtime.</param>
        /// <param name="excludeFromBenchmark">Whether to exclude this implementation from benchmarks.</param>
        public CipherImplementation(
            string algorithmFamily,
            string variant,
            int keySizeBits,
            Mode mode,
            Func<byte[], object> keyedFactory,
            Source source,
            Func<bool>? supportCheck = null,
            bool excludeFromBenchmark = false)
        {
            AlgorithmFamily = algorithmFamily;
            Variant = variant;
            KeySizeBits = keySizeBits;
            CipherMode = mode;
            _keyedFactory = keyedFactory;
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
        /// Gets the factory function that creates a cipher with a default zero key.
        /// </summary>
        public Func<object> Factory => () => _keyedFactory(new byte[KeySizeBits / 8]);

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
        /// Creates a new instance of the cipher with a default zero key.
        /// </summary>
        public object Create() => _keyedFactory(new byte[KeySizeBits / 8]);

        /// <summary>
        /// Creates a new instance of the cipher with the specified key.
        /// </summary>
        /// <param name="key">The encryption key.</param>
        public object Create(byte[] key) => _keyedFactory(key);

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
        Supported.Where(impl => impl.Source is Source.Managed or Source.Simd or Source.OS);

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

        // AES AEAD Implementations
        AddAesImplementations(implementations);

        // AES-CBC Implementations
        AddAesCbcImplementations(implementations);

        // ChaCha Implementations
        AddChaChaImplementations(implementations);

        // Ascon Implementations
        AddAsconImplementations(implementations);

        // OS Implementations (.NET 8.0+)
        AddOSImplementations(implementations);

        // Regional Cipher Implementations
        AddRegionalImplementations(implementations);

        return implementations;
    }

    private static void AddSimdAndManagedVariants(
        List<CipherImplementation> implementations,
        string family,
        int keySizeBits,
        Mode mode,
        CH.SimdSupport simdSupport,
        Func<CH.SimdSupport, object> factory,
        Func<CH.SimdSupport, CH.SimdSupport>? simdMaskSelector = null)
    {
        foreach (var flag in AlgorithmRegistry.GetSimdVariantFlags(simdSupport))
        {
            var selectedMask = simdMaskSelector?.Invoke(flag) ?? flag;
            implementations.Add(new CipherImplementation(
                family,
                AlgorithmRegistry.GetSimdVariantName(flag),
                keySizeBits,
                mode,
                () => factory(selectedMask),
                Source.Simd));
        }

        implementations.Add(new CipherImplementation(
            family,
            "CryptoHives-Scalar",
            keySizeBits,
            mode,
            () => factory(CH.SimdSupport.None),
            Source.Managed));
    }

    private static void AddSimdAndManagedVariants(
        List<CipherImplementation> implementations,
        string family,
        int keySizeBits,
        Mode mode,
        CH.SimdSupport simdSupport,
        Func<byte[], CH.SimdSupport, object> factory,
        Func<CH.SimdSupport, CH.SimdSupport>? simdMaskSelector = null)
    {
        foreach (var flag in AlgorithmRegistry.GetSimdVariantFlags(simdSupport))
        {
            var selectedMask = simdMaskSelector?.Invoke(flag) ?? flag;
            implementations.Add(new CipherImplementation(
                family,
                AlgorithmRegistry.GetSimdVariantName(flag),
                keySizeBits,
                mode,
                (byte[] key) => factory(key, selectedMask),
                Source.Simd));
        }

        implementations.Add(new CipherImplementation(
            family,
            "CryptoHives-Scalar",
            keySizeBits,
            mode,
            (byte[] key) => factory(key, CH.SimdSupport.None),
            Source.Managed));
    }

    private static void AddAesImplementations(List<CipherImplementation> implementations)
    {
        var aesSimd = CH.Cipher.AesGcm128.SimdSupport;

        // AES-128-GCM - AES-NI (AES-NI + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.AesNi) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-AES-NI",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.AesNi, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-128-GCM - PClMul (T-table AES + CLMUL GHASH, serial)
        if ((aesSimd & CH.SimdSupport.PClMul) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-PClMul",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.PClMul, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-128-GCM - AES-NI+PClMul (AES-NI + PCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul))
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-AES-NI+PClMul",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul, key),
                Source.Simd));
        }

        // AES-128-GCM - AES-NI+PClMulV256 (AES-NI + VPCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256))
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-AES-NI+PClMulV256",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul | CH.SimdSupport.PClMulV256, key),
                Source.Simd));
        }

        // AES-128-GCM - ArmAes (ARM AES + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.ArmAes) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-ARM-AES",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.ArmAes, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-128-GCM - ArmAes+ArmPmull (ARM AES + PMULL GHASH)
        if ((aesSimd & (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull)) == (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull))
        {
            implementations.Add(new CipherImplementation(
                "AES-128-GCM",
                "CryptoHives-ARM-AES+PMULL",
                128,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull, key),
                Source.Simd));
        }

        // AES-128-GCM - Managed (scalar)
        implementations.Add(new CipherImplementation(
            "AES-128-GCM",
            "CryptoHives-Scalar",
            128,
            Mode.GCM,
            (byte[] key) => CH.Cipher.AesGcm128.Create(CH.SimdSupport.None, key),
            Source.Managed));

        // AES-128-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-128-GCM",
            "BouncyCastle",
            128,
            Mode.GCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-192-GCM - AES-NI (AES-NI + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.AesNi) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-AES-NI",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.AesNi, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-192-GCM - PClMul (T-table AES + CLMUL GHASH, serial)
        if ((aesSimd & CH.SimdSupport.PClMul) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-PClMul",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.PClMul, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-192-GCM - AES-NI+PClMul (AES-NI + PCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul))
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-AES-NI+PClMul",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul, key),
                Source.Simd));
        }

        // AES-192-GCM - AES-NI+PClMulV256 (AES-NI + VPCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256))
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-AES-NI+PClMulV256",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul | CH.SimdSupport.PClMulV256, key),
                Source.Simd));
        }

        // AES-192-GCM - ArmAes (ARM AES + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.ArmAes) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-ARM-AES",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.ArmAes, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-192-GCM - ArmAes+ArmPmull (ARM AES + PMULL GHASH)
        if ((aesSimd & (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull)) == (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull))
        {
            implementations.Add(new CipherImplementation(
                "AES-192-GCM",
                "CryptoHives-ARM-AES+PMULL",
                192,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull, key),
                Source.Simd));
        }

        // AES-192-GCM - Managed (scalar)
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "CryptoHives-Scalar",
            192,
            Mode.GCM,
            (byte[] key) => CH.Cipher.AesGcm192.Create(CH.SimdSupport.None, key),
            Source.Managed));

        // AES-192-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "BouncyCastle",
            192,
            Mode.GCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // AES-256-GCM - AES-NI (AES-NI + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.AesNi) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-AES-NI",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.AesNi, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-256-GCM - PClMul (T-table AES + CLMUL GHASH, serial)
        if ((aesSimd & CH.SimdSupport.PClMul) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-PClMul",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.PClMul, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-256-GCM - AES-NI+PClMul (AES-NI + PCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMul))
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-AES-NI+PClMul",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul, key),
                Source.Simd));
        }

        // AES-256-GCM - AES-NI+PClMulV256 (AES-NI + VPCLMULQDQ, stitched)
        if ((aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256)) == (CH.SimdSupport.AesNi | CH.SimdSupport.PClMulV256))
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-AES-NI+PClMulV256",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.AesNi | CH.SimdSupport.PClMul | CH.SimdSupport.PClMulV256, key),
                Source.Simd));
        }

        // AES-256-GCM - ArmAes (ARM AES + Shoup GHASH, serial)
        if ((aesSimd & CH.SimdSupport.ArmAes) != 0)
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-ARM-AES",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.ArmAes, key),
                Source.Simd,
                null,
                excludeFromBenchmark: true
                ));
        }

        // AES-256-GCM - ArmAes+ArmPmull (ARM AES + PMULL GHASH)
        if ((aesSimd & (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull)) == (CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull))
        {
            implementations.Add(new CipherImplementation(
                "AES-256-GCM",
                "CryptoHives-ARM-AES+PMULL",
                256,
                Mode.GCM,
                (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.ArmAes | CH.SimdSupport.ArmPmull, key),
                Source.Simd));
        }

        // AES-256-GCM - Managed (scalar)
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "CryptoHives-Scalar",
            256,
            Mode.GCM,
            (byte[] key) => CH.Cipher.AesGcm256.Create(CH.SimdSupport.None, key),
            Source.Managed));

        // AES-256-GCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "BouncyCastle",
            256,
            Mode.GCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new GcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));


        var ccmSimd = CH.Cipher.AesCcm128.SimdSupport;
        AddSimdAndManagedVariants(
            implementations,
            "AES-128-CCM",
            128,
            Mode.CCM,
            ccmSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.ArmAes),
            (key, support) => CH.Cipher.AesCcm128.Create(support, key));

        // AES-128-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-128-CCM",
            "BouncyCastle",
            128,
            Mode.CCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        AddSimdAndManagedVariants(
            implementations,
            "AES-192-CCM",
            192,
            Mode.CCM,
            ccmSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.ArmAes),
            (key, support) => CH.Cipher.AesCcm192.Create(support, key));

        // AES-192-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-192-CCM",
            "BouncyCastle",
            192,
            Mode.CCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        AddSimdAndManagedVariants(
            implementations,
            "AES-256-CCM",
            256,
            Mode.CCM,
            ccmSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.ArmAes),
            (key, support) => CH.Cipher.AesCcm256.Create(support, key));

        // AES-256-CCM - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-256-CCM",
            "BouncyCastle",
            256,
            Mode.CCM,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new CcmBlockCipher(new AesEngine()),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));
    }

    private static void AddAesCbcImplementations(List<CipherImplementation> implementations)
    {
        var aesSimd = CH.Cipher.Aes128.SimdSupport;

        AddSimdAndManagedVariants(
            implementations,
            "AES-128-CBC",
            128,
            Mode.CBC,
            aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.ArmAes),
            support => {
                var aes = CH.Cipher.Aes128.Create(support);
                aes.Mode = CH.Cipher.CipherMode.CBC;
                aes.Padding = CH.Cipher.PaddingMode.PKCS7;
                return aes;
            });

        // AES-128-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-128-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateAesCbc(16),
            Source.BouncyCastle));

        AddSimdAndManagedVariants(
            implementations,
            "AES-256-CBC",
            256,
            Mode.CBC,
            aesSimd & (CH.SimdSupport.AesNi | CH.SimdSupport.ArmAes),
            support => {
                var aes = CH.Cipher.Aes256.Create(support);
                aes.Mode = CH.Cipher.CipherMode.CBC;
                aes.Padding = CH.Cipher.PaddingMode.PKCS7;
                return aes;
            });

        // AES-256-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "AES-256-CBC",
            "BouncyCastle",
            256,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateAesCbc(32),
            Source.BouncyCastle));
    }

    private static void AddChaChaImplementations(List<CipherImplementation> implementations)
    {
        var chachaSimd = CH.Cipher.ChaCha20.SimdSupport;

        static CH.SimdSupport SelectChaChaMask(CH.SimdSupport flag)
            => flag == CH.SimdSupport.Avx2 ? CH.SimdSupport.Avx2 | CH.SimdSupport.Ssse3 : flag;

        AddSimdAndManagedVariants(
            implementations,
            "ChaCha20",
            256,
            Mode.Stream,
            chachaSimd,
            support => CH.Cipher.ChaCha20.Create(support),
            SelectChaChaMask);

        // ChaCha20 (stream) - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ChaCha20",
            "BouncyCastle",
            256,
            Mode.Stream,
            () => BouncyCastleCipherAdapter.CreateChaCha20(),
            Source.BouncyCastle));

        // ChaCha20 (stream) - NaCl.Core
        implementations.Add(new CipherImplementation(
            "ChaCha20",
            "NaCl.Core",
            256,
            Mode.Stream,
            () => new NaClCoreStreamCipherAdapter(),
            Source.NaClCore));

        AddSimdAndManagedVariants(
            implementations,
            "ChaCha20-Poly1305",
            256,
            Mode.ChaCha20Poly1305,
            chachaSimd,
            (key, support) => CH.Cipher.ChaCha20Poly1305.Create(support, key),
            SelectChaChaMask);

        // ChaCha20-Poly1305 - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "BouncyCastle",
            256,
            Mode.ChaCha20Poly1305,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new ChaCha20Poly1305(),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 12),
            Source.BouncyCastle));

        // ChaCha20-Poly1305 - NaCl.Core
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "NaCl.Core",
            256,
            Mode.ChaCha20Poly1305,
            (byte[] key) => new NaClCoreAeadAdapter(key, useXChaCha: false),
            Source.NaClCore));

        AddSimdAndManagedVariants(
            implementations,
            "XChaCha20-Poly1305",
            256,
            Mode.XChaCha20Poly1305,
            chachaSimd,
            (key, support) => CH.Cipher.XChaCha20Poly1305.Create(support, key),
            SelectChaChaMask);

        // XChaCha20-Poly1305 - NaCl.Core
        implementations.Add(new CipherImplementation(
            "XChaCha20-Poly1305",
            "NaCl.Core",
            256,
            Mode.XChaCha20Poly1305,
            (byte[] key) => new NaClCoreAeadAdapter(key, useXChaCha: true),
            Source.NaClCore));
    }

    private static void AddAsconImplementations(List<CipherImplementation> implementations)
    {
        // Ascon-AEAD128 - Managed
        implementations.Add(new CipherImplementation(
            "Ascon-AEAD128",
            "CryptoHives-Scalar",
            128,
            Mode.AsconAead128,
            (byte[] key) => CH.Cipher.AsconAead128.Create(key),
            Source.Managed));

        // Ascon-AEAD128 - BouncyCastle
        implementations.Add(new CipherImplementation(
            "Ascon-AEAD128",
            "BouncyCastle",
            128,
            Mode.AsconAead128,
            (byte[] key) => new BouncyCastleAeadAdapter(
                new AsconAead128(),
                key,
                tagSizeBits: 128,
                nonceSizeBytes: 16),
            Source.BouncyCastle));
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
            (byte[] key) => new OSAesGcmAdapter(key),
            Source.OS,
            supportCheck: static () => OS.AesGcm.IsSupported));

        // AES-192-GCM - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-192-GCM",
            "OS",
            192,
            Mode.GCM,
            (byte[] key) => new OSAesGcmAdapter(key),
            Source.OS,
            supportCheck: static () => OS.AesGcm.IsSupported));

        // AES-256-GCM - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-256-GCM",
            "OS",
            256,
            Mode.GCM,
            (byte[] key) => new OSAesGcmAdapter(key),
            Source.OS,
            supportCheck: static () => OS.AesGcm.IsSupported));

        // AES-128-CBC - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-128-CBC",
            "OS",
            128,
            Mode.CBC,
            () => new OSAesCbcAdapter(16),
            Source.OS));

        // AES-256-CBC - OS (.NET 8.0+)
        implementations.Add(new CipherImplementation(
            "AES-256-CBC",
            "OS",
            256,
            Mode.CBC,
            () => new OSAesCbcAdapter(32),
            Source.OS));
#endif

#if NET9_0_OR_GREATER
        // ChaCha20-Poly1305 - OS (.NET 9.0+)
        implementations.Add(new CipherImplementation(
            "ChaCha20-Poly1305",
            "OS",
            256,
            Mode.ChaCha20Poly1305,
            (byte[] key) => new OSChaCha20Poly1305Adapter(key),
            Source.OS,
            supportCheck: static () => OS.ChaCha20Poly1305.IsSupported));
#endif
    }

    private static void AddRegionalImplementations(List<CipherImplementation> implementations)
    {
        AddSimdAndManagedVariants(
            implementations,
            "SM4-CBC",
            128,
            Mode.CBC,
            CH.Cipher.Sm4.SimdSupport,
            support => {
                var sm4 = CH.Cipher.Sm4.Create(support);
                sm4.Mode = CH.Cipher.CipherMode.CBC;
                sm4.Padding = CH.Cipher.PaddingMode.PKCS7;
                return sm4;
            });

        // SM4-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "SM4-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new SM4Engine(), 16, "SM4-CBC"),
            Source.BouncyCastle));

        // ARIA-128-CBC - Managed
        implementations.Add(new CipherImplementation(
            "ARIA-128-CBC",
            "CryptoHives-Scalar",
            128,
            Mode.CBC,
            () => {
                var aria = CH.Cipher.Aria128.Create();
                aria.Mode = CH.Cipher.CipherMode.CBC;
                aria.Padding = CH.Cipher.PaddingMode.PKCS7;
                return aria;
            },
            Source.Managed));

        // ARIA-128-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ARIA-128-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new AriaEngine(), 16, "ARIA-128-CBC"),
            Source.BouncyCastle));

        // ARIA-256-CBC - Managed
        implementations.Add(new CipherImplementation(
            "ARIA-256-CBC",
            "CryptoHives-Scalar",
            256,
            Mode.CBC,
            () => {
                var aria = CH.Cipher.Aria256.Create();
                aria.Mode = CH.Cipher.CipherMode.CBC;
                aria.Padding = CH.Cipher.PaddingMode.PKCS7;
                return aria;
            },
            Source.Managed));

        // ARIA-256-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ARIA-256-CBC",
            "BouncyCastle",
            256,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new AriaEngine(), 32, "ARIA-256-CBC"),
            Source.BouncyCastle));

        // Camellia-128-CBC - Managed
        implementations.Add(new CipherImplementation(
            "Camellia-128-CBC",
            "CryptoHives-Scalar",
            128,
            Mode.CBC,
            () => {
                var cam = CH.Cipher.Camellia128.Create();
                cam.Mode = CH.Cipher.CipherMode.CBC;
                cam.Padding = CH.Cipher.PaddingMode.PKCS7;
                return cam;
            },
            Source.Managed));

        // Camellia-128-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "Camellia-128-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new CamelliaEngine(), 16, "Camellia-128-CBC"),
            Source.BouncyCastle));

        // Camellia-192-CBC - Managed
        implementations.Add(new CipherImplementation(
            "Camellia-192-CBC",
            "CryptoHives-Scalar",
            192,
            Mode.CBC,
            () => {
                var cam = CH.Cipher.Camellia192.Create();
                cam.Mode = CH.Cipher.CipherMode.CBC;
                cam.Padding = CH.Cipher.PaddingMode.PKCS7;
                return cam;
            },
            Source.Managed));

        // Camellia-192-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "Camellia-192-CBC",
            "BouncyCastle",
            192,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new CamelliaEngine(), 24, "Camellia-192-CBC"),
            Source.BouncyCastle));

        // Camellia-256-CBC - Managed
        implementations.Add(new CipherImplementation(
            "Camellia-256-CBC",
            "CryptoHives-Scalar",
            256,
            Mode.CBC,
            () => {
                var cam = CH.Cipher.Camellia256.Create();
                cam.Mode = CH.Cipher.CipherMode.CBC;
                cam.Padding = CH.Cipher.PaddingMode.PKCS7;
                return cam;
            },
            Source.Managed));

        // Camellia-256-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "Camellia-256-CBC",
            "BouncyCastle",
            256,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new CamelliaEngine(), 32, "Camellia-256-CBC"),
            Source.BouncyCastle));

        // Kalyna-128-CBC - Managed
        implementations.Add(new CipherImplementation(
            "Kalyna-128-CBC",
            "CryptoHives-Scalar",
            128,
            Mode.CBC,
            () => {
                var kal = CH.Cipher.Kalyna128.Create();
                kal.Mode = CH.Cipher.CipherMode.CBC;
                kal.Padding = CH.Cipher.PaddingMode.PKCS7;
                return kal;
            },
            Source.Managed));

        // Kalyna-128-CBC - BouncyCastle (Dstu7624Engine)
        implementations.Add(new CipherImplementation(
            "Kalyna-128-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new Dstu7624Engine(128), 16, "Kalyna-128-CBC"),
            Source.BouncyCastle));

        // Kalyna-256-CBC - Managed
        implementations.Add(new CipherImplementation(
            "Kalyna-256-CBC",
            "CryptoHives-Scalar",
            256,
            Mode.CBC,
            () => {
                var kal = CH.Cipher.Kalyna256.Create();
                kal.Mode = CH.Cipher.CipherMode.CBC;
                kal.Padding = CH.Cipher.PaddingMode.PKCS7;
                return kal;
            },
            Source.Managed));

        // Kalyna-256-CBC - BouncyCastle (Dstu7624Engine)
        implementations.Add(new CipherImplementation(
            "Kalyna-256-CBC",
            "BouncyCastle",
            256,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new Dstu7624Engine(128), 32, "Kalyna-256-CBC"),
            Source.BouncyCastle));

        // Kuznyechik-CBC - Managed (no BouncyCastle engine available)
        implementations.Add(new CipherImplementation(
            "Kuznyechik-CBC",
            "CryptoHives-Scalar",
            256,
            Mode.CBC,
            () => {
                var kuz = CH.Cipher.Kuznyechik.Create();
                kuz.Mode = CH.Cipher.CipherMode.CBC;
                kuz.Padding = CH.Cipher.PaddingMode.PKCS7;
                return kuz;
            },
            Source.Managed));

        // SEED-CBC - Managed
        implementations.Add(new CipherImplementation(
            "SEED-CBC",
            "CryptoHives-Scalar",
            128,
            Mode.CBC,
            () => {
                var seed = CH.Cipher.Seed.Create();
                seed.Mode = CH.Cipher.CipherMode.CBC;
                seed.Padding = CH.Cipher.PaddingMode.PKCS7;
                return seed;
            },
            Source.Managed));

        // SEED-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "SEED-CBC",
            "BouncyCastle",
            128,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new SeedEngine(), 16, "SEED-CBC"),
            Source.BouncyCastle));

        // ARIA-192-CBC - Managed
        implementations.Add(new CipherImplementation(
            "ARIA-192-CBC",
            "CryptoHives-Scalar",
            192,
            Mode.CBC,
            () => {
                var aria = CH.Cipher.Aria192.Create();
                aria.Mode = CH.Cipher.CipherMode.CBC;
                aria.Padding = CH.Cipher.PaddingMode.PKCS7;
                return aria;
            },
            Source.Managed));

        // ARIA-192-CBC - BouncyCastle
        implementations.Add(new CipherImplementation(
            "ARIA-192-CBC",
            "BouncyCastle",
            192,
            Mode.CBC,
            () => BouncyCastleCipherAdapter.CreateCbc(new AriaEngine(), 24, "ARIA-192-CBC"),
            Source.BouncyCastle));

    }
}
