// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms

namespace Cryptography.Tests.Mac;

using Cryptography.Tests.Adapter.Mac;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BC = Org.BouncyCastle.Crypto.Digests;
using BCEngines = Org.BouncyCastle.Crypto.Engines;
using BCMacs = Org.BouncyCastle.Crypto.Macs;
using CH = CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Central registry of all MAC algorithm implementations for testing and benchmarking.
/// </summary>
/// <remarks>
/// Mirrors <c>HashAlgorithmRegistry</c>: a single source of truth for MAC factories,
/// eliminating duplication between test sources and benchmark configurations.
/// Covers <see cref="IMac"/>-shaped algorithms only (HMAC, AES-CMAC, Poly1305) — AES-GMAC
/// has a fundamentally different one-shot, nonce-per-call API (see <see cref="CH.AesGmac"/>)
/// and is benchmarked separately.
/// </remarks>
public static class MacAlgorithmRegistry
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
    /// Represents a MAC algorithm implementation with metadata.
    /// </summary>
    public sealed class MacImplementation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MacImplementation"/> class.
        /// </summary>
        public MacImplementation(
            string algorithmFamily,
            string variant,
            Func<IMac> factory,
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

        /// <summary>Gets the algorithm family name.</summary>
        public string AlgorithmFamily { get; }

        /// <summary>Gets the implementation variant.</summary>
        public string Variant { get; }

        /// <summary>Gets the factory function.</summary>
        public Func<IMac> Factory { get; }

        /// <summary>Gets the implementation source type.</summary>
        public Source Source { get; }

        /// <summary>Gets the optional support check function.</summary>
        public Func<bool>? SupportCheck { get; }

        /// <summary>Gets whether this implementation should be excluded from benchmarks.</summary>
        public bool ExcludeFromBenchmark { get; }

        /// <summary>Gets the display name combining family and variant.</summary>
        public string Name => string.IsNullOrEmpty(Variant)
            ? AlgorithmFamily
            : $"{AlgorithmFamily} ({Variant})";

        /// <summary>Gets whether this implementation is supported on the current platform.</summary>
        public bool IsSupported => SupportCheck?.Invoke() ?? true;

        /// <summary>Creates a new instance of the MAC algorithm.</summary>
        public IMac Create() => Factory();

        /// <inheritdoc/>
        public override string ToString() => Name;
    }

    private static readonly Lazy<List<MacImplementation>> _allImplementations = new(BuildRegistry);

    /// <summary>Gets all registered MAC algorithm implementations.</summary>
    public static IReadOnlyList<MacImplementation> All => _allImplementations.Value;

    /// <summary>Gets all supported implementations (filters out unsupported at runtime).</summary>
    public static IEnumerable<MacImplementation> Supported => All.Where(m => m.IsSupported);

    /// <summary>Gets all supported implementations that are suitable for benchmarking.</summary>
    public static IEnumerable<MacImplementation> Benchmarkable
        => All.Where(m => m.IsSupported && !m.ExcludeFromBenchmark);

    /// <summary>Gets implementations for a specific algorithm family.</summary>
    public static IEnumerable<MacImplementation> ByFamily(string family)
        => All.Where(m => m.AlgorithmFamily.Equals(family, StringComparison.OrdinalIgnoreCase));

    /// <summary>Gets only CryptoHives implementations.</summary>
    public static IEnumerable<MacImplementation> CryptoHivesOnly
        => All.Where(m => m.Source == Source.Managed);

    // Shared 32-byte key, reused across every family so results are directly comparable.
    private static readonly byte[] SharedKey =
    [
        0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
        0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
        0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
        0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f
    ];

    // AES-128 key for AES-CMAC (block cipher key, distinct size from the HMAC/Poly1305 key above).
    private static readonly byte[] Aes128Key = SharedKey[..16];

    private static List<MacImplementation> BuildRegistry()
    {
        var list = new List<MacImplementation>();

        AddHmac(list);
        AddCmac(list);
        AddPoly1305(list);

        return list;
    }

    #region HMAC

    private static void AddHmac(List<MacImplementation> list)
    {
        list.Add(new("HMAC-MD5", "CryptoHives-Scalar", () => CH.HmacMd5.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-MD5", "OS", () => new SystemHmacAdapter(new HMACMD5(SharedKey)), Source.OS));
        list.Add(new("HMAC-MD5", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.MD5Digest()), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA1", "CryptoHives-Scalar", () => CH.HmacSha1.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA1", "OS", () => new SystemHmacAdapter(new HMACSHA1(SharedKey)), Source.OS));
        list.Add(new("HMAC-SHA1", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha1Digest()), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA256", "CryptoHives-Scalar", () => CH.HmacSha256.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA256", "OS", () => new SystemHmacAdapter(new HMACSHA256(SharedKey)), Source.OS));
        list.Add(new("HMAC-SHA256", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha256Digest()), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA384", "CryptoHives-Scalar", () => CH.HmacSha384.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA384", "OS", () => new SystemHmacAdapter(new HMACSHA384(SharedKey)), Source.OS));
        list.Add(new("HMAC-SHA384", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha384Digest()), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA512", "CryptoHives-Scalar", () => CH.HmacSha512.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA512", "OS", () => new SystemHmacAdapter(new HMACSHA512(SharedKey)), Source.OS));
        list.Add(new("HMAC-SHA512", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha512Digest()), SharedKey), Source.BouncyCastle));

        // SHA-3 HMAC: no OS comparison — matches HmacTests.cs precedent (System.Security.Cryptography's
        // HMACSHA3_* availability isn't reliable across this repo's TFM matrix, so only BouncyCastle is used).
        list.Add(new("HMAC-SHA3-256", "CryptoHives-Scalar", () => CH.HmacSha3_256.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA3-256", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha3Digest(256)), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA3-384", "CryptoHives-Scalar", () => CH.HmacSha3_384.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA3-384", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha3Digest(384)), SharedKey), Source.BouncyCastle));

        list.Add(new("HMAC-SHA3-512", "CryptoHives-Scalar", () => CH.HmacSha3_512.Create(SharedKey), Source.Managed));
        list.Add(new("HMAC-SHA3-512", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.HMac(new BC.Sha3Digest(512)), SharedKey), Source.BouncyCastle));
    }

    #endregion

    #region CMAC

    private static void AddCmac(List<MacImplementation> list)
    {
        list.Add(new("AES-CMAC", "CryptoHives-Scalar", () => CH.AesCmac.Create(Aes128Key), Source.Managed));
        list.Add(new("AES-CMAC", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.CMac(new BCEngines.AesEngine(), 128), Aes128Key),
            Source.BouncyCastle));
    }

    #endregion

    #region Poly1305

    private static void AddPoly1305(List<MacImplementation> list)
    {
        list.Add(new("Poly1305", "CryptoHives-Scalar", () => CH.Poly1305Mac.Create(SharedKey), Source.Managed));
        list.Add(new("Poly1305", "BouncyCastle",
            () => new BouncyCastleMacAdapter(new BCMacs.Poly1305(), SharedKey), Source.BouncyCastle));
    }

    #endregion
}
