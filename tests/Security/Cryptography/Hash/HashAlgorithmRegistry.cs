// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0618
#pragma warning disable CA5350
#pragma warning disable CA5351

namespace Cryptography.Tests.Hash;

using Cryptography.Tests.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BC = Org.BouncyCastle.Crypto.Digests;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Central registry of all hash algorithm implementations for testing and benchmarking.
/// </summary>
/// <remarks>
/// This registry provides a single source of truth for all hash algorithm factories,
/// eliminating duplication between test sources and benchmark configurations.
/// </remarks>
public static class HashAlgorithmRegistry
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
        /// <summary>CryptoHives SIMD-optimized implementation.</summary>
        Simd,
        /// <summary>BouncyCastle implementation.</summary>
        BouncyCastle,
        /// <summary>HashifyNET implementation.</summary>
        HashifyNet,
        /// <summary>OpenGost implementation.</summary>
        OpenGost,
        /// <summary>Native implementation.</summary>
        Native
    }

    /// <summary>
    /// Represents a hash algorithm implementation with metadata.
    /// </summary>
    public sealed class HashImplementation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HashImplementation"/> class.
        /// </summary>
        /// <param name="algorithmFamily">Algorithm family name (e.g., "SHA-256", "BLAKE2b-512").</param>
        /// <param name="variant">Implementation variant (e.g., "Managed", "AVX2", "BouncyCastle").</param>
        /// <param name="hashSizeBits">Hash output size in bits.</param>
        /// <param name="factory">Factory function to create the hash algorithm.</param>
        /// <param name="source">Implementation source type.</param>
        /// <param name="supportCheck">Optional function to check if implementation is supported at runtime.</param>
        /// <param name="excludeFromBenchmark">Whether to exclude this implementation from benchmarks.</param>
        public HashImplementation(
            string algorithmFamily,
            string variant,
            int hashSizeBits,
            Func<HashAlgorithm> factory,
            Source source,
            Func<bool>? supportCheck = null,
            bool excludeFromBenchmark = false)
        {
            AlgorithmFamily = algorithmFamily;
            Variant = variant;
            HashSizeBits = hashSizeBits;
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
        /// Gets the hash output size in bits.
        /// </summary>
        public int HashSizeBits { get; }

        /// <summary>
        /// Gets the factory function.
        /// </summary>
        public Func<HashAlgorithm> Factory { get; }

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
        /// <remarks>
        /// Some implementations have design limitations that make them unsuitable for benchmarking,
        /// such as requiring new instance allocation per hash operation due to non-resettable state.
        /// </remarks>
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
        /// Creates a new instance of the hash algorithm.
        /// </summary>
        public HashAlgorithm Create() => Factory();

        /// <inheritdoc/>
        public override string ToString() => Name;
    }

    private static readonly Lazy<List<HashImplementation>> _allImplementations = new(BuildRegistry);

    /// <summary>
    /// Gets all registered hash algorithm implementations.
    /// </summary>
    public static IReadOnlyList<HashImplementation> All => _allImplementations.Value;

    /// <summary>
    /// Gets all supported implementations (filters out unsupported at runtime).
    /// </summary>
    public static IEnumerable<HashImplementation> Supported => All.Where(h => h.IsSupported);

    /// <summary>
    /// Gets all supported implementations that are suitable for benchmarking.
    /// </summary>
    public static IEnumerable<HashImplementation> Benchmarkable
        => All.Where(h => h.IsSupported && !h.ExcludeFromBenchmark);

    /// <summary>
    /// Gets implementations for a specific algorithm family.
    /// </summary>
    public static IEnumerable<HashImplementation> ByFamily(string family)
        => All.Where(h => h.AlgorithmFamily.Equals(family, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Gets only managed (non-SIMD) CryptoHives implementations.
    /// </summary>
    public static IEnumerable<HashImplementation> ManagedOnly
        => All.Where(h => h.Source == Source.Managed);

    /// <summary>
    /// Gets only CryptoHives implementations (managed + SIMD).
    /// </summary>
    public static IEnumerable<HashImplementation> CryptoHivesOnly
        => All.Where(h => h.Source is Source.Managed or Source.Simd);

    /// <summary>
    /// Gets a specific implementation by family and variant.
    /// </summary>
    public static HashImplementation? Get(string family, string variant)
        => All.FirstOrDefault(h =>
            h.AlgorithmFamily.Equals(family, StringComparison.OrdinalIgnoreCase) &&
            h.Variant.Equals(variant, StringComparison.OrdinalIgnoreCase));

    private static List<HashImplementation> BuildRegistry()
    {
        var list = new List<HashImplementation>();

        // SHA-1 (Legacy)
        AddSha1(list);

        // SHA-2 Family
        AddSha2(list);

        // SHA-3 Family
        AddSha3(list);

        // SHAKE XOF
        AddShake(list);

        // cSHAKE
        AddCShake(list);

        // BLAKE2
        AddBlake2(list);

        // BLAKE3
        AddBlake3(list);

        // Keccak (Ethereum)
        AddKeccak(list);

        // MD5 (Legacy)
        AddMd5(list);

        // RIPEMD-160
        AddRipemd160(list);

        // SM3
        AddSm3(list);

        // Whirlpool
        AddWhirlpool(list);

        // Streebog (GOST)
        AddStreebog(list);

        // Kupyna (DSTU 7564 - Ukrainian)
        AddKupyna(list);

        // KangarooTwelve / TurboSHAKE
        AddKangarooTwelve(list);
        AddTurboShake(list);

        // Ascon (NIST SP 800-232)
        AddAscon(list);

        return list;
    }

    #region SHA-1

    private static void AddSha1(List<HashImplementation> list)
    {
        list.Add(new HashImplementation("SHA-1", "OS", 160, SHA1.Create, Source.OS));
        list.Add(new HashImplementation("SHA-1", "Managed", 160, CH.SHA1.Create, Source.Managed));
        list.Add(new("SHA-1", "BouncyCastle", 160,
            () => new BouncyCastleHashAdapter(new BC.Sha1Digest()), Source.BouncyCastle));
    }

    #endregion

    #region SHA-2

    private static void AddSha2(List<HashImplementation> list)
    {
        // SHA-224
        list.Add(new HashImplementation("SHA-224", "Managed", 224, CH.SHA224.Create, Source.Managed));
        list.Add(new("SHA-224", "BouncyCastle", 224,
            () => new BouncyCastleHashAdapter(new BC.Sha224Digest()), Source.BouncyCastle));

        // SHA-256
        list.Add(new HashImplementation("SHA-256", "OS", 256, SHA256.Create, Source.OS));
        list.Add(new HashImplementation("SHA-256", "Managed", 256, CH.SHA256.Create, Source.Managed));
        list.Add(new("SHA-256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Sha256Digest()), Source.BouncyCastle));

        // SHA-384
        list.Add(new HashImplementation("SHA-384", "OS", 384, SHA384.Create, Source.OS));
        list.Add(new("SHA-384", "Managed", 384, () => CH.SHA384.Create(), Source.Managed));
        list.Add(new("SHA-384", "BouncyCastle", 384,
            () => new BouncyCastleHashAdapter(new BC.Sha384Digest()), Source.BouncyCastle));

        // SHA-512
        list.Add(new HashImplementation("SHA-512", "OS", 512, SHA512.Create, Source.OS));
        list.Add(new("SHA-512", "Managed", 512,
            () => CH.SHA512.Create(), Source.Managed));
        list.Add(new("SHA-512", "BouncyCastle", 512,
            () => new BouncyCastleHashAdapter(new BC.Sha512Digest()), Source.BouncyCastle));

        // SHA-512/224
        list.Add(new("SHA-512/224", "Managed", 224,
            () => CH.SHA512_224.Create(), Source.Managed));
        list.Add(new("SHA-512/224", "BouncyCastle", 224,
            () => new BouncyCastleHashAdapter(new BC.Sha512tDigest(224)), Source.BouncyCastle));

        // SHA-512/256
        list.Add(new("SHA-512/256", "Managed", 256,
            () => CH.SHA512_256.Create(), Source.Managed));
        list.Add(new("SHA-512/256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Sha512tDigest(256)), Source.BouncyCastle));
    }

    #endregion

    #region SHA-3

    private static void AddSha3(List<HashImplementation> list)
    {
        AddSha3Variant(list, "SHA3-224", 224, CH.SHA3_224.SimdSupport,
            simd => CH.SHA3_224.Create(simd), () => new BC.Sha3Digest(224));

        AddSha3Variant(list, "SHA3-256", 256, CH.SHA3_256.SimdSupport,
            simd => CH.SHA3_256.Create(simd), () => new BC.Sha3Digest(256),
#if NET8_0_OR_GREATER
            () => SHA3_256.IsSupported ? SHA3_256.Create() : null
#else
            null
#endif
        );

        AddSha3Variant(list, "SHA3-384", 384, CH.SHA3_384.SimdSupport,
            simd => CH.SHA3_384.Create(simd), () => new BC.Sha3Digest(384),
#if NET8_0_OR_GREATER
            () => SHA3_384.IsSupported ? SHA3_384.Create() : null
#else
            null
#endif
        );

        AddSha3Variant(list, "SHA3-512", 512, CH.SHA3_512.SimdSupport,
            simd => CH.SHA3_512.Create(simd), () => new BC.Sha3Digest(512),
#if NET8_0_OR_GREATER
            () => SHA3_512.IsSupported ? SHA3_512.Create() : null
#else
            null
#endif
        );
    }

    private static void AddSha3Variant(
        List<HashImplementation> list,
        string family,
        int hashSizeBits,
        CH.SimdSupport simdSupport,
        Func<CH.SimdSupport, HashAlgorithm> factory,
        Func<Org.BouncyCastle.Crypto.IDigest> bcFactory,
        Func<HashAlgorithm?>? osFactory = null)
    {
#if NET8_0_OR_GREATER
        if (osFactory != null)
        {
            var osCheck = osFactory;
            list.Add(new(family, "OS", hashSizeBits, () => osCheck()!, Source.OS,
                () => osCheck() != null));
        }
#endif

        if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
        {
            list.Add(new(family, "AVX512F", hashSizeBits,
                () => factory(CH.SimdSupport.Avx512F), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx512F) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new(family, "AVX2", hashSizeBits,
                () => factory(CH.SimdSupport.Avx2), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx2) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new(family, "SSSE3", hashSizeBits,
                () => factory(CH.SimdSupport.Ssse3), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Ssse3) != 0));
        }

        list.Add(new(family, "Managed", hashSizeBits,
            () => factory(CH.SimdSupport.None), Source.Managed));

        list.Add(new(family, "BouncyCastle", hashSizeBits,
            () => new BouncyCastleHashAdapter(bcFactory()), Source.BouncyCastle));
    }

    #endregion

    #region SHAKE

    private static void AddShake(List<HashImplementation> list)
    {
        var simdSupport = CH.KeccakCore.SimdSupport;

#if NET8_0_OR_GREATER
        list.Add(new("SHAKE128", "OS", 256,
            () => new Shake128HashAdapter(32), Source.OS,
            () => Shake128.IsSupported));

        list.Add(new("SHAKE256", "OS", 512,
            () => new Shake256HashAdapter(64), Source.OS,
            () => Shake256.IsSupported));
#endif

        AddKeccakSimdVariants(list, "SHAKE128", 256, simdSupport,
            s => CH.Shake128.Create(s, 32));
        list.Add(new("SHAKE128", "BouncyCastle", 256,
            () => new BouncyCastleXofAdapter(new BC.ShakeDigest(128), 32), Source.BouncyCastle));

        AddKeccakSimdVariants(list, "SHAKE256", 512, simdSupport,
            s => CH.Shake256.Create(s, 64));
        list.Add(new("SHAKE256", "BouncyCastle", 512,
            () => new BouncyCastleXofAdapter(new BC.ShakeDigest(256), 64), Source.BouncyCastle));
    }

    #endregion

    #region cSHAKE

    private static void AddCShake(List<HashImplementation> list)
    {
        var simdSupport = CH.KeccakCore.SimdSupport;

        AddKeccakSimdVariants(list, "cSHAKE128", 256, simdSupport,
            s => CH.CShake128.Create(s, 32));
        list.Add(new("cSHAKE128", "BouncyCastle", 256,
            () => new BouncyCastleCShakeAdapter(128, null, null, 32), Source.BouncyCastle));

        AddKeccakSimdVariants(list, "cSHAKE256", 512, simdSupport,
            s => CH.CShake256.Create(s, 64));
        list.Add(new("cSHAKE256", "BouncyCastle", 512,
            () => new BouncyCastleCShakeAdapter(256, null, null, 64), Source.BouncyCastle));
    }

    #endregion

    #region BLAKE2

    private static void AddBlake2(List<HashImplementation> list)
    {
        // BLAKE2b-512
        var blake2bSimd = CH.Blake2b.SimdSupport;
        if ((blake2bSimd & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new("BLAKE2b-512", "AVX2", 512,
                () => CH.Blake2b.Create(64, CH.SimdSupport.Avx2), Source.Simd,
                () => (CH.Blake2b.SimdSupport & CH.SimdSupport.Avx2) != 0));
        }
        list.Add(new("BLAKE2b-512", "Managed", 512,
            () => CH.Blake2b.Create(64, CH.SimdSupport.None), Source.Managed));
        list.Add(new("BLAKE2b-512", "BouncyCastle", 512,
            () => new BouncyCastleHashAdapter(new BC.Blake2bDigest(512)), Source.BouncyCastle));
        list.Add(new("BLAKE2b-512", "HashifyNET", 512,
            () => new HashifyNetBlake2bAdapter(512), Source.HashifyNet,
            excludeFromBenchmark: true));

        // BLAKE2b-256
        if ((blake2bSimd & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new("BLAKE2b-256", "AVX2", 256,
                () => CH.Blake2b.Create(32, CH.SimdSupport.Avx2), Source.Simd,
                () => (CH.Blake2b.SimdSupport & CH.SimdSupport.Avx2) != 0));
        }
        list.Add(new("BLAKE2b-256", "Managed", 256,
            () => CH.Blake2b.Create(32, CH.SimdSupport.None), Source.Managed));
        list.Add(new("BLAKE2b-256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Blake2bDigest(256)), Source.BouncyCastle));
        list.Add(new("BLAKE2b-256", "HashifyNET", 256,
            () => new HashifyNetBlake2bAdapter(256), Source.HashifyNet,
            excludeFromBenchmark: true));

        // BLAKE2s-256
        var blake2sSimd = CH.Blake2s.SimdSupport;
        if ((blake2sSimd & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new("BLAKE2s-256", "AVX2", 256,
                () => CH.Blake2s.Create(32, CH.SimdSupport.Avx2), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Avx2) != 0));
        }
        if ((blake2sSimd & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new("BLAKE2s-256", "SSSE3", 256,
                () => CH.Blake2s.Create(32, CH.SimdSupport.Ssse3), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Ssse3) != 0));
        }
        if ((blake2sSimd & CH.SimdSupport.Sse2) != 0)
        {
            list.Add(new("BLAKE2s-256", "SSE2", 256,
                () => CH.Blake2s.Create(32, CH.SimdSupport.Sse2), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Sse2) != 0));
        }
        list.Add(new("BLAKE2s-256", "Managed", 256,
            () => CH.Blake2s.Create(32, CH.SimdSupport.None), Source.Managed));
        list.Add(new("BLAKE2s-256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Blake2sDigest(256)), Source.BouncyCastle));

        // BLAKE2s-128
        if ((blake2sSimd & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new("BLAKE2s-128", "AVX2", 128,
                () => CH.Blake2s.Create(16, CH.SimdSupport.Avx2), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Avx2) != 0));
        }
        if ((blake2sSimd & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new("BLAKE2s-128", "SSSE3", 128,
                () => CH.Blake2s.Create(16, CH.SimdSupport.Ssse3), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Ssse3) != 0));
        }
        if ((blake2sSimd & CH.SimdSupport.Sse2) != 0)
        {
            list.Add(new("BLAKE2s-128", "SSE2", 128,
                () => CH.Blake2s.Create(16, CH.SimdSupport.Sse2), Source.Simd,
                () => (CH.Blake2s.SimdSupport & CH.SimdSupport.Sse2) != 0));
        }
        list.Add(new("BLAKE2s-128", "Managed", 128,
            () => CH.Blake2s.Create(16, CH.SimdSupport.None), Source.Managed));
        list.Add(new("BLAKE2s-128", "BouncyCastle", 128,
            () => new BouncyCastleHashAdapter(new BC.Blake2sDigest(128)), Source.BouncyCastle));
    }

    #endregion

    #region BLAKE3

    private static void AddBlake3(List<HashImplementation> list)
    {
        var blake3Simd = CH.Blake3.SimdSupport;
        if ((blake3Simd & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new HashImplementation("BLAKE3", "SSSE3", 256,
                () => CH.Blake3.Create(32, CH.SimdSupport.Ssse3), Source.Simd,
                () => (CH.Blake3.SimdSupport & CH.SimdSupport.Ssse3) != 0));
        }
        list.Add(new HashImplementation("BLAKE3", "Managed", 256, () => CH.Blake3.Create(32, CH.SimdSupport.None), Source.Managed));
        list.Add(new("BLAKE3", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Blake3Digest(256)), Source.BouncyCastle));

#if BLAKE3_NATIVE
        list.Add(new("BLAKE3", "Native", 256,
            () => new Blake3NativeAdapter(32), Source.Native));
#endif
    }

    #endregion

    #region Keccak

    private static void AddKeccak(List<HashImplementation> list)
    {
        AddKeccakVariant(list, "Keccak-256", 256, CH.Keccak256.SimdSupport,
            s => CH.Keccak256.Create(s), () => new BC.KeccakDigest(256));

        AddKeccakVariant(list, "Keccak-384", 384, CH.Keccak384.SimdSupport,
            s => CH.Keccak384.Create(s), () => new BC.KeccakDigest(384));

        AddKeccakVariant(list, "Keccak-512", 512, CH.Keccak512.SimdSupport,
            s => CH.Keccak512.Create(s), () => new BC.KeccakDigest(512));
    }

    private static void AddKeccakVariant(
        List<HashImplementation> list,
        string family,
        int hashSizeBits,
        CH.SimdSupport simdSupport,
        Func<CH.SimdSupport, HashAlgorithm> factory,
        Func<Org.BouncyCastle.Crypto.IDigest> bcFactory)
    {
        if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
        {
            list.Add(new(family, "AVX512F", hashSizeBits,
                () => factory(CH.SimdSupport.Avx512F), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx512F) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new(family, "AVX2", hashSizeBits,
                () => factory(CH.SimdSupport.Avx2), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx2) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new(family, "SSSE3", hashSizeBits,
                () => factory(CH.SimdSupport.Ssse3), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Ssse3) != 0));
        }

        list.Add(new(family, "Managed", hashSizeBits,
            () => factory(CH.SimdSupport.None), Source.Managed));

        list.Add(new(family, "BouncyCastle", hashSizeBits,
            () => new BouncyCastleHashAdapter(bcFactory()), Source.BouncyCastle));
    }

    private static void AddKeccakSimdVariants(
        List<HashImplementation> list,
        string family,
        int hashSizeBits,
        CH.SimdSupport simdSupport,
        Func<CH.SimdSupport, HashAlgorithm> factory)
    {
        if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
        {
            list.Add(new(family, "AVX512F", hashSizeBits,
                () => factory(CH.SimdSupport.Avx512F), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx512F) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Avx2) != 0)
        {
            list.Add(new(family, "AVX2", hashSizeBits,
                () => factory(CH.SimdSupport.Avx2), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Avx2) != 0));
        }

        if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
        {
            list.Add(new(family, "SSSE3", hashSizeBits,
                () => factory(CH.SimdSupport.Ssse3), Source.Simd,
                () => (simdSupport & CH.SimdSupport.Ssse3) != 0));
        }

        list.Add(new(family, "Managed", hashSizeBits,
            () => factory(CH.SimdSupport.None), Source.Managed));
    }

    #endregion

    #region MD5

    private static void AddMd5(List<HashImplementation> list)
    {
        list.Add(new HashImplementation("MD5", "OS", 128, MD5.Create, Source.OS));
        list.Add(new HashImplementation("MD5", "Managed", 128, CH.MD5.Create, Source.Managed));
        list.Add(new("MD5", "BouncyCastle", 128,
            () => new BouncyCastleHashAdapter(new BC.MD5Digest()), Source.BouncyCastle));
    }

    #endregion

    #region RIPEMD-160

    private static void AddRipemd160(List<HashImplementation> list)
    {
        list.Add(new HashImplementation("RIPEMD-160", "Managed", 160, CH.Ripemd160.Create, Source.Managed));
        list.Add(new("RIPEMD-160", "BouncyCastle", 160,
            () => new BouncyCastleHashAdapter(new BC.RipeMD160Digest()), Source.BouncyCastle));
    }

    #endregion

    #region SM3

    private static void AddSm3(List<HashImplementation> list)
    {
        list.Add(new HashImplementation("SM3", "Managed", 256, CH.SM3.Create, Source.Managed));
        list.Add(new("SM3", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.SM3Digest()), Source.BouncyCastle));
    }

    #endregion

    #region Whirlpool

    private static void AddWhirlpool(List<HashImplementation> list)
    {
        list.Add(new HashImplementation("Whirlpool", "Managed", 512, CH.Whirlpool.Create, Source.Managed));
        list.Add(new("Whirlpool", "BouncyCastle", 512,
            () => new BouncyCastleHashAdapter(new BC.WhirlpoolDigest()), Source.BouncyCastle));
        list.Add(new("Whirlpool", "HashifyNET", 512,
            () => new HashifyNetWhirlpoolAdapter(), Source.HashifyNet));
    }

    #endregion

    #region Streebog

    private static void AddStreebog(List<HashImplementation> list)
    {
        // Streebog-256
        list.Add(new("Streebog-256", "Managed", 256,
            () => CH.Streebog.Create(32), Source.Managed));
        list.Add(new("Streebog-256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Gost3411_2012_256Digest()), Source.BouncyCastle));
        list.Add(new("Streebog-256", "OpenGost", 256,
            () => OpenGost.Security.Cryptography.Streebog256.Create(), Source.OpenGost));

        // Streebog-512
        list.Add(new("Streebog-512", "Managed", 512,
            () => CH.Streebog.Create(64), Source.Managed));
        list.Add(new("Streebog-512", "BouncyCastle", 512,
            () => new BouncyCastleHashAdapter(new BC.Gost3411_2012_512Digest()), Source.BouncyCastle));
        list.Add(new("Streebog-512", "OpenGost", 512,
            () => OpenGost.Security.Cryptography.Streebog512.Create(), Source.OpenGost));
    }

    #endregion

    #region Kupyna

    private static void AddKupyna(List<HashImplementation> list)
    {
        // Kupyna-256
        list.Add(new("Kupyna-256", "Managed", 256,
            () => CH.Kupyna.Create(32), Source.Managed));
        list.Add(new("Kupyna-256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.Dstu7564Digest(256)), Source.BouncyCastle));

        // Kupyna-384
        list.Add(new("Kupyna-384", "Managed", 384,
            () => CH.Kupyna.Create(48), Source.Managed));
        list.Add(new("Kupyna-384", "BouncyCastle", 384,
            () => new BouncyCastleHashAdapter(new BC.Dstu7564Digest(384)), Source.BouncyCastle));

        // Kupyna-512
        list.Add(new("Kupyna-512", "Managed", 512,
            () => CH.Kupyna.Create(64), Source.Managed));
        list.Add(new("Kupyna-512", "BouncyCastle", 512,
            () => new BouncyCastleHashAdapter(new BC.Dstu7564Digest(512)), Source.BouncyCastle));
    }

    #endregion

    #region KangarooTwelve

    private static void AddKangarooTwelve(List<HashImplementation> list)
    {
        var simdSupport = CH.KeccakCore.SimdSupport;

        // KT128 (32-byte output)
        AddKeccakSimdVariants(list, "KT128", 256, simdSupport,
            s => CH.KT128.Create(s, 32));

        // KT256 (64-byte output)
        AddKeccakSimdVariants(list, "KT256", 512, simdSupport,
            s => CH.KT256.Create(s, 64));
    }

    #endregion

    #region TurboSHAKE

    private static void AddTurboShake(List<HashImplementation> list)
    {
        var simdSupport = CH.KeccakCore.SimdSupport;

        // TurboShake128 (32-byte output)
        AddKeccakSimdVariants(list, "TurboSHAKE128-32", 256, simdSupport,
            s => CH.TurboShake128.Create(s, 32));

        // TurboShake128 (64-byte output)
        AddKeccakSimdVariants(list, "TurboSHAKE128-64", 512, simdSupport,
            s => CH.TurboShake128.Create(s, 64));

        // TurboShake256 (64-byte output)
        AddKeccakSimdVariants(list, "TurboSHAKE256", 512, simdSupport,
            s => CH.TurboShake256.Create(s, 64));
    }

    #endregion

    #region Ascon

    private static void AddAscon(List<HashImplementation> list)
    {
        // Ascon-Hash256
        list.Add(new("Ascon-Hash256", "Managed", 256,
            CH.AsconHash256.Create, Source.Managed));
        list.Add(new("Ascon-Hash256", "BouncyCastle", 256,
            () => new BouncyCastleHashAdapter(new BC.AsconHash256()), Source.BouncyCastle));

        // Ascon-XOF128 (32-byte output)
        list.Add(new("Ascon-XOF128", "Managed", 256,
            () => CH.AsconXof128.Create(32), Source.Managed));
        list.Add(new("Ascon-XOF128", "BouncyCastle", 256,
            () => new BouncyCastleGenericXofAdapter(new BC.AsconXof128(), 32), Source.BouncyCastle));
    }

    #endregion
}
