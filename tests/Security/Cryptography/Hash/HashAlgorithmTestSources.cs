// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// Represents a factory for creating hash algorithm instances for testing.
/// </summary>
/// <remarks>
/// This class provides a descriptive name for test output and a factory function
/// to create the hash algorithm instance.
/// </remarks>
public sealed class HashAlgorithmFactory
{
    private readonly Func<HashAlgorithm> _factory;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashAlgorithmFactory"/> class.
    /// </summary>
    /// <param name="name">A descriptive name for the implementation.</param>
    /// <param name="factory">A factory function that creates the hash algorithm.</param>
    public HashAlgorithmFactory(string name, Func<HashAlgorithm> factory)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    /// <summary>
    /// Gets the descriptive name of this implementation.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates a new instance of the hash algorithm.
    /// </summary>
    /// <returns>A new hash algorithm instance.</returns>
    public HashAlgorithm Create() => _factory();

    /// <inheritdoc/>
    public override string ToString() => Name;

    /// <summary>
    /// Creates a factory from a registry implementation.
    /// </summary>
    internal static HashAlgorithmFactory FromImplementation(HashAlgorithmRegistry.HashImplementation impl)
        => new(impl.Name, impl.Create);
}

#region SHA-1

/// <summary>
/// Provides test case sources for SHA-1 implementations.
/// </summary>
public static class Sha1Implementations
{
    /// <summary>
    /// Gets all available SHA-1 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-1")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region SHA-2

/// <summary>
/// Provides test case sources for SHA-224 implementations.
/// </summary>
public static class Sha224Implementations
{
    /// <summary>
    /// Gets all available SHA-224 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-224")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA-256 implementations.
/// </summary>
public static class Sha256Implementations
{
    /// <summary>
    /// Gets all available SHA-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA-384 implementations.
/// </summary>
public static class Sha384Implementations
{
    /// <summary>
    /// Gets all available SHA-384 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-384")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA-512 implementations.
/// </summary>
public static class Sha512Implementations
{
    /// <summary>
    /// Gets all available SHA-512 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-512")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA-512/224 implementations.
/// </summary>
public static class Sha512T224Implementations
{
    /// <summary>
    /// Gets all available SHA-512/224 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-512/224")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA-512/256 implementations.
/// </summary>
public static class Sha512T256Implementations
{
    /// <summary>
    /// Gets all available SHA-512/256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA-512/256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region SHA-3

/// <summary>
/// Provides test case sources for SHA3-224 implementations.
/// </summary>
public static class Sha3224Implementations
{
    /// <summary>
    /// Gets all available SHA3-224 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA3-224")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA3-256 implementations.
/// </summary>
public static class Sha3256Implementations
{
    /// <summary>
    /// Gets all available SHA3-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA3-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA3-384 implementations.
/// </summary>
public static class Sha3384Implementations
{
    /// <summary>
    /// Gets all available SHA3-384 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA3-384")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for SHA3-512 implementations.
/// </summary>
public static class Sha3512Implementations
{
    /// <summary>
    /// Gets all available SHA3-512 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHA3-512")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region SHAKE

/// <summary>
/// Provides test case sources for Shake128 implementations (32-byte output).
/// </summary>
public static class Shake128Implementations
{
    /// <summary>
    /// Gets all available Shake128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHAKE128")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for Shake256 implementations (64-byte output).
/// </summary>
public static class Shake256Implementations
{
    /// <summary>
    /// Gets all available Shake256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SHAKE256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region cSHAKE

/// <summary>
/// Provides test case sources for cShake128 implementations (32-byte output).
/// </summary>
public static class CShake128Implementations
{
    /// <summary>
    /// Gets all available cShake128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("cSHAKE128")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for cShake256 implementations (64-byte output).
/// </summary>
public static class CShake256Implementations
{
    /// <summary>
    /// Gets all available cShake256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("cSHAKE256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region BLAKE2

/// <summary>
/// Provides test case sources for BLAKE2b-512 implementations.
/// </summary>
public static class Blake2b512Implementations
{
    /// <summary>
    /// Gets all available BLAKE2b-512 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("BLAKE2b-512")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for BLAKE2b-256 implementations.
/// </summary>
public static class Blake2b256Implementations
{
    /// <summary>
    /// Gets all available BLAKE2b-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("BLAKE2b-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for BLAKE2s-256 implementations.
/// </summary>
public static class Blake2s256Implementations
{
    /// <summary>
    /// Gets all available BLAKE2s-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("BLAKE2s-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for BLAKE2s-128 implementations.
/// </summary>
public static class Blake2s128Implementations
{
    /// <summary>
    /// Gets all available BLAKE2s-128 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("BLAKE2s-128")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region BLAKE3

/// <summary>
/// Provides test case sources for BLAKE3 implementations (32-byte output).
/// </summary>
public static class Blake3Implementations
{
    /// <summary>
    /// Gets all available BLAKE3 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("BLAKE3")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region Keccak

/// <summary>
/// Provides test case sources for Keccak-256 implementations.
/// </summary>
public static class Keccak256Implementations
{
    /// <summary>
    /// Gets all available Keccak-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Keccak-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for Keccak-384 implementations.
/// </summary>
public static class Keccak384Implementations
{
    /// <summary>
    /// Gets all available Keccak-384 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Keccak-384")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for Keccak-512 implementations.
/// </summary>
public static class Keccak512Implementations
{
    /// <summary>
    /// Gets all available Keccak-512 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Keccak-512")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region MD5

/// <summary>
/// Provides test case sources for MD5 implementations.
/// </summary>
public static class Md5Implementations
{
    /// <summary>
    /// Gets all available MD5 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("MD5")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region RIPEMD-160

/// <summary>
/// Provides test case sources for RIPEMD-160 implementations.
/// </summary>
public static class Ripemd160Implementations
{
    /// <summary>
    /// Gets all available RIPEMD-160 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("RIPEMD-160")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region SM3

/// <summary>
/// Provides test case sources for SM3 implementations.
/// </summary>
public static class Sm3Implementations
{
    /// <summary>
    /// Gets all available SM3 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("SM3")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region Whirlpool

/// <summary>
/// Provides test case sources for Whirlpool implementations.
/// </summary>
public static class WhirlpoolImplementations
{
    /// <summary>
    /// Gets all available Whirlpool implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Whirlpool")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region Streebog

/// <summary>
/// Provides test case sources for Streebog-256 implementations.
/// </summary>
public static class Streebog256Implementations
{
    /// <summary>
    /// Gets all available Streebog-256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Streebog-256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for Streebog-512 implementations.
/// </summary>
public static class Streebog512Implementations
{
    /// <summary>
    /// Gets all available Streebog-512 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Streebog-512")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region KangarooTwelve / TurboSHAKE

/// <summary>
/// Provides test case sources for KT128 implementations (32-byte output).
/// </summary>
public static class KT128Implementations
{
    /// <summary>
    /// Gets all available KT128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("KT128")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for KT256 implementations (64-byte output).
/// </summary>
public static class KT256Implementations
{
    /// <summary>
    /// Gets all available KT256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("KT256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for TurboShake128 implementations.
/// </summary>
public static class TurboShake128Implementations
{
    /// <summary>
    /// Gets all available TurboShake128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All32 => HashAlgorithmRegistry
        .ByFamily("TurboSHAKE128-32")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);

    /// <summary>
    /// Gets all available TurboShake128 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All64 => HashAlgorithmRegistry
        .ByFamily("TurboSHAKE128-64")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for TurboShake256 implementations.
/// </summary>
public static class TurboShake256Implementations
{
    /// <summary>
    /// Gets all available TurboShake256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("TurboSHAKE256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion

#region Ascon (NIST SP 800-232)

/// <summary>
/// Provides test case sources for Ascon-Hash256 implementations.
/// </summary>
public static class AsconHash256Implementations
{
    /// <summary>
    /// Gets all available Ascon-Hash256 implementations for testing.
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Ascon-Hash256")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

/// <summary>
/// Provides test case sources for Ascon-XOF128 implementations (32-byte output).
/// </summary>
public static class AsconXof128Implementations
{
    /// <summary>
    /// Gets all available Ascon-XOF128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All => HashAlgorithmRegistry
        .ByFamily("Ascon-XOF128")
        .Where(h => h.IsSupported)
        .Select(HashAlgorithmFactory.FromImplementation);
}

#endregion
