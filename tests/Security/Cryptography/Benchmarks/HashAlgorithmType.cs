// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0011 // Add braces

using Cryptography.Tests.Adapter;
using Cryptography.Tests.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CHMac = CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Factory for creating hash algorithm instances for benchmarking.
/// </summary>
/// <remarks>
/// This class provides a BenchmarkDotNet-friendly wrapper around the central
/// <see cref="HashAlgorithmRegistry"/> for benchmark scenarios.
/// Each method returns implementations for a single algorithm family only,
/// ensuring no overlap between benchmark classes.
/// </remarks>
public sealed class HashAlgorithmType : IFormattable
{
    private readonly Func<HashAlgorithm> _factory;
    private readonly Func<bool>? _isSupported;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashAlgorithmType"/> class.
    /// </summary>
    public HashAlgorithmType(string category, string name, Func<HashAlgorithm> factory, Func<bool>? isSupported = null)
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
    /// Creates an instance of the hash algorithm.
    /// </summary>
    /// <exception cref="PlatformNotSupportedException">Thrown if the algorithm is not supported.</exception>
    public HashAlgorithm Create()
    {
        if (!IsSupported)
            throw new PlatformNotSupportedException($"Hash algorithm '{Name}' is not supported on this platform.");
        return _factory();
    }

    /// <summary>
    /// Tries to create an instance of the hash algorithm.
    /// </summary>
    public bool TryCreate(out HashAlgorithm? algorithm)
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
        catch (PlatformNotSupportedException)
        {
            algorithm = null;
            return false;
        }
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    /// <inheritdoc/>
    public override string ToString() => Name;

    #region Registry Bridge

    /// <summary>
    /// Creates a <see cref="HashAlgorithmType"/> from a registry implementation.
    /// </summary>
    public static HashAlgorithmType FromImplementation(HashAlgorithmRegistry.HashImplementation impl)
        => new(impl.AlgorithmFamily, impl.Name, impl.Create, () => impl.IsSupported);

    private static IEnumerable<HashAlgorithmType> FromFamily(string family)
        => HashAlgorithmRegistry.ByFamily(family)
            .Where(h => h.IsSupported && !h.ExcludeFromBenchmark)
            .Select(FromImplementation);

    #endregion

    #region SHA-2 Individual Algorithms

    /// <summary>SHA-224 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA224() => FromFamily("SHA-224");

    /// <summary>SHA-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA256() => FromFamily("SHA-256");

    /// <summary>SHA-384 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA384() => FromFamily("SHA-384");

    /// <summary>SHA-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA512() => FromFamily("SHA-512");

    /// <summary>SHA-512/224 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA512_224() => FromFamily("SHA-512/224");

    /// <summary>SHA-512/256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA512_256() => FromFamily("SHA-512/256");

    #endregion

    #region SHA-3 Individual Algorithms

    /// <summary>SHA3-224 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA3_224() => FromFamily("SHA3-224");

    /// <summary>SHA3-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA3_256() => FromFamily("SHA3-256");

    /// <summary>SHA3-384 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA3_384() => FromFamily("SHA3-384");

    /// <summary>SHA3-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA3_512() => FromFamily("SHA3-512");

    #endregion

    #region Keccak Individual Algorithms

    /// <summary>Keccak-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Keccak256() => FromFamily("Keccak-256");

    /// <summary>Keccak-384 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Keccak384() => FromFamily("Keccak-384");

    /// <summary>Keccak-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Keccak512() => FromFamily("Keccak-512");

    #endregion

    #region SHAKE Individual Algorithms

    /// <summary>SHAKE128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Shake128() => FromFamily("SHAKE128");

    /// <summary>SHAKE256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Shake256() => FromFamily("SHAKE256");

    #endregion

    #region cSHAKE Individual Algorithms

    /// <summary>cSHAKE128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> CShake128() => FromFamily("cSHAKE128");

    /// <summary>cSHAKE256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> CShake256() => FromFamily("cSHAKE256");

    #endregion

    #region KangarooTwelve Individual Algorithms

    /// <summary>KT128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> KT128() => FromFamily("KT128");

    /// <summary>KT256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> KT256() => FromFamily("KT256");

    #endregion

    #region TurboSHAKE Individual Algorithms

    /// <summary>TurboSHAKE128 implementations (combines 32 and 64 byte variants).</summary>
    public static IEnumerable<HashAlgorithmType> TurboShake128()
        => HashAlgorithmRegistry.ByFamily("TurboSHAKE128-32")
            .Concat(HashAlgorithmRegistry.ByFamily("TurboSHAKE128-64"))
            .Where(h => h.IsSupported)
            .Select(FromImplementation);

    /// <summary>TurboSHAKE256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> TurboShake256() => FromFamily("TurboSHAKE256");

    #endregion

    #region BLAKE2b Individual Algorithms

    /// <summary>BLAKE2b-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Blake2b256() => FromFamily("BLAKE2b-256");

    /// <summary>BLAKE2b-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Blake2b512() => FromFamily("BLAKE2b-512");

    #endregion

    #region BLAKE2s Individual Algorithms

    /// <summary>BLAKE2s-128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Blake2s128() => FromFamily("BLAKE2s-128");

    /// <summary>BLAKE2s-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Blake2s256() => FromFamily("BLAKE2s-256");

    #endregion

    #region BLAKE3 Individual Algorithms

    /// <summary>BLAKE3 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Blake3() => FromFamily("BLAKE3");

    #endregion

    #region Legacy Individual Algorithms

    /// <summary>MD5 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> MD5() => FromFamily("MD5");

    /// <summary>SHA-1 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SHA1() => FromFamily("SHA-1");

    #endregion

    #region Regional Individual Algorithms

    /// <summary>SM3 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> SM3() => FromFamily("SM3");

    /// <summary>Streebog-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Streebog256() => FromFamily("Streebog-256");

    /// <summary>Streebog-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Streebog512() => FromFamily("Streebog-512");

    /// <summary>Kupyna-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Kupyna256() => FromFamily("Kupyna-256");

    /// <summary>Kupyna-384 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Kupyna384() => FromFamily("Kupyna-384");

    /// <summary>Kupyna-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Kupyna512() => FromFamily("Kupyna-512");

    /// <summary>Whirlpool implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Whirlpool() => FromFamily("Whirlpool");

    /// <summary>RIPEMD-160 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Ripemd160() => FromFamily("RIPEMD-160");

    #endregion

    #region LSH Individual Algorithms

    /// <summary>LSH-256-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Lsh256_256() => FromFamily("LSH-256-256");

    /// <summary>LSH-512-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Lsh512_256() => FromFamily("LSH-512-256");

    /// <summary>LSH-512-512 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> Lsh512_512() => FromFamily("LSH-512-512");

    #endregion

    #region Ascon Individual Algorithms

    /// <summary>Ascon-Hash256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> AsconHash256() => FromFamily("Ascon-Hash256");

    /// <summary>Ascon-XOF128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> AsconXof128() => FromFamily("Ascon-XOF128");

    #endregion

    #region KMAC Algorithms

    // Shared key for KMAC benchmarks (32 bytes)
    private static readonly byte[] _sharedKMacKey =
    [
        0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
        0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
        0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
        0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f
    ];

    private static readonly byte[] _sharedKMacCustomization = Encoding.UTF8.GetBytes("Benchmark");

    /// <summary>KMAC-128 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> KMac128()
    {
        yield return new("KMAC-128", "KMAC-128 (Managed)",
            () => CHMac.KMac128.Create(_sharedKMacKey, 32, "Benchmark"));

        yield return new("KMAC-128", "KMAC-128 (BouncyCastle)",
            () => new BouncyCastleKMacAdapter(128, _sharedKMacKey, _sharedKMacCustomization, 32));

#if NET9_0_OR_GREATER
        if (Kmac128.IsSupported)
        {
            yield return new("KMAC-128", "KMAC-128 (OS)",
                () => new KMac128HashAdapter(_sharedKMacKey, 32, _sharedKMacCustomization),
                () => Kmac128.IsSupported);
        }
#endif
    }

    /// <summary>KMAC-256 implementations.</summary>
    public static IEnumerable<HashAlgorithmType> KMac256()
    {
        yield return new("KMAC-256", "KMAC-256 (Managed)",
            () => CHMac.KMac256.Create(_sharedKMacKey, 64, "Benchmark"));

        yield return new("KMAC-256", "KMAC-256 (BouncyCastle)",
            () => new BouncyCastleKMacAdapter(256, _sharedKMacKey, _sharedKMacCustomization, 64));

#if NET9_0_OR_GREATER
        if (System.Security.Cryptography.Kmac256.IsSupported)
        {
            yield return new("KMAC-256", "KMAC-256 (OS)",
                () => new KMac256HashAdapter(_sharedKMacKey, 64, _sharedKMacCustomization),
                () => System.Security.Cryptography.Kmac256.IsSupported);
        }
#endif
    }

    #endregion

}
