// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Digests;

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
    [SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms", Justification = "Testing")]
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA1 (OS)",
                () => SHA1.Create());

#pragma warning disable CS0618 // Type or member is obsolete
            yield return new HashAlgorithmFactory(
                "SHA1",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA1.Create());
#pragma warning restore CS0618

            yield return new HashAlgorithmFactory(
                "SHA1 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha1Digest()));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            // No OS implementation for SHA-224 on older .NET

            yield return new HashAlgorithmFactory(
                "SHA224",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA224.Create());

            yield return new HashAlgorithmFactory(
                "SHA224 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha224Digest()));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA-256 implementations.
/// </summary>
public static class Sha256Implementations
{
    /// <summary>
    /// Gets all available SHA-256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA256 (OS)",
                () => SHA256.Create());

            yield return new HashAlgorithmFactory(
                "SHA256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA256.Create());

            yield return new HashAlgorithmFactory(
                "SHA256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha256Digest()));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA-384 implementations.
/// </summary>
public static class Sha384Implementations
{
    /// <summary>
    /// Gets all available SHA-384 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA384 (OS)",
                () => SHA384.Create());

            yield return new HashAlgorithmFactory(
                "SHA384",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA384.Create());

            yield return new HashAlgorithmFactory(
                "SHA384 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha384Digest()));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA-512 implementations.
/// </summary>
public static class Sha512Implementations
{
    /// <summary>
    /// Gets all available SHA-512 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA512 (OS)",
                () => SHA512.Create());

            yield return new HashAlgorithmFactory(
                "SHA512",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA512.Create());

            yield return new HashAlgorithmFactory(
                "SHA512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha512Digest()));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA-512/224 implementations.
/// </summary>
public static class Sha512T224Implementations
{
    /// <summary>
    /// Gets all available SHA-512/224 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA512_224",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA512_224.Create());

            yield return new HashAlgorithmFactory(
                "SHA512/224 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha512tDigest(224)));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA-512/256 implementations.
/// </summary>
public static class Sha512T256Implementations
{
    /// <summary>
    /// Gets all available SHA-512/256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SHA512_256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA512_256.Create());

            yield return new HashAlgorithmFactory(
                "SHA512/256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha512tDigest(256)));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            // No OS implementation for SHA3-224 on .NET 8+

            yield return new HashAlgorithmFactory(
                "SHA3_224",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA3_224.Create());

            yield return new HashAlgorithmFactory(
                "SHA3-224 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha3Digest(224)));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA3-256 implementations.
/// </summary>
public static class Sha3256Implementations
{
    /// <summary>
    /// Gets all available SHA3-256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
#if NET8_0_OR_GREATER
            if (SHA3_256.IsSupported)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3-256 (OS)",
                    () => SHA3_256.Create());
            }
#endif

            yield return new HashAlgorithmFactory(
                "SHA3_256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA3_256.Create());

            yield return new HashAlgorithmFactory(
                "SHA3-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha3Digest(256)));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA3-384 implementations.
/// </summary>
public static class Sha3384Implementations
{
    /// <summary>
    /// Gets all available SHA3-384 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
#if NET8_0_OR_GREATER
            if (SHA3_384.IsSupported)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3-384 (OS)",
                    () => SHA3_384.Create());
            }
#endif

            yield return new HashAlgorithmFactory(
                "SHA3_384",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA3_384.Create());

            yield return new HashAlgorithmFactory(
                "SHA3-384 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha3Digest(384)));
        }
    }
}

/// <summary>
/// Provides test case sources for SHA3-512 implementations.
/// </summary>
public static class Sha3512Implementations
{
    /// <summary>
    /// Gets all available SHA3-512 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
#if NET8_0_OR_GREATER
            if (SHA3_512.IsSupported)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3-512 (OS)",
                    () => SHA3_512.Create());
            }
#endif

            yield return new HashAlgorithmFactory(
                "SHA3_512",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SHA3_512.Create());

            yield return new HashAlgorithmFactory(
                "SHA3-512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Sha3Digest(512)));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
#if NET8_0_OR_GREATER
            if (Shake128.IsSupported)
            {
                yield return new HashAlgorithmFactory(
                    "Shake128 (OS)",
                    () => new Shake128HashAdapter(32));
            }
#endif

            yield return new HashAlgorithmFactory(
                "Shake128",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Shake128.Create(32));

            yield return new HashAlgorithmFactory(
                "Shake128 (BouncyCastle)",
                () => new BouncyCastleXofAdapter(new ShakeDigest(128), 32));
        }
    }
}

/// <summary>
/// Provides test case sources for Shake256 implementations (64-byte output).
/// </summary>
public static class Shake256Implementations
{
    /// <summary>
    /// Gets all available Shake256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All
    {
        get
        {
#if NET8_0_OR_GREATER
            if (Shake256.IsSupported)
            {
                yield return new HashAlgorithmFactory(
                    "Shake256 (OS)",
                    () => new Shake256HashAdapter(64));
            }
#endif

            yield return new HashAlgorithmFactory(
                "Shake256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Shake256.Create(64));

            yield return new HashAlgorithmFactory(
                "Shake256 (BouncyCastle)",
                () => new BouncyCastleXofAdapter(new ShakeDigest(256), 64));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Blake2b",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Blake2b.Create(64));

            yield return new HashAlgorithmFactory(
                "BLAKE2b-512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Blake2bDigest(512)));

            yield return new HashAlgorithmFactory(
                "BLAKE2b-512 (HashifyNET)",
                () => new HashifyNetBlake2bAdapter(512));
        }
    }
}

/// <summary>
/// Provides test case sources for BLAKE2b-256 implementations.
/// </summary>
public static class Blake2b256Implementations
{
    /// <summary>
    /// Gets all available BLAKE2b-256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Blake2b-256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Blake2b.Create(32));

            yield return new HashAlgorithmFactory(
                "BLAKE2b-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Blake2bDigest(256)));

            yield return new HashAlgorithmFactory(
                "BLAKE2b-256 (HashifyNET)",
                () => new HashifyNetBlake2bAdapter(256));
        }
    }
}

/// <summary>
/// Provides test case sources for BLAKE2s-256 implementations.
/// </summary>
public static class Blake2s256Implementations
{
    /// <summary>
    /// Gets all available BLAKE2s-256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Blake2s",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Blake2s.Create(32));

            yield return new HashAlgorithmFactory(
                "BLAKE2s-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Blake2sDigest(256)));
        }
    }
}

/// <summary>
/// Provides test case sources for BLAKE2s-128 implementations.
/// </summary>
public static class Blake2s128Implementations
{
    /// <summary>
    /// Gets all available BLAKE2s-128 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Blake2s-128",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Blake2s.Create(16));

            yield return new HashAlgorithmFactory(
                "BLAKE2s-128 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Blake2sDigest(128)));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Blake3",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Blake3.Create(32));

            yield return new HashAlgorithmFactory(
                "BLAKE3 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Blake3Digest(256)));

            // Note: HashifyNET Blake3 has a known bug at the 1024-byte chunk boundary
            // and is excluded from tests. Use BouncyCastle and Native as references.

#if BLAKE3_NATIVE
            yield return new HashAlgorithmFactory(
                "BLAKE3 (Native)",
                () => new Blake3NativeAdapter(32));
#endif
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Keccak256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Keccak256.Create());

            yield return new HashAlgorithmFactory(
                "Keccak-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new KeccakDigest(256)));
        }
    }
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
    [SuppressMessage("Security", "CA5351:Do Not Use Broken Cryptographic Algorithms", Justification = "Testing legacy algorithm")]
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "MD5 (OS)",
                () => MD5.Create());

#pragma warning disable CS0618 // Type or member is obsolete
            yield return new HashAlgorithmFactory(
                "MD5",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.MD5.Create());
#pragma warning restore CS0618

            yield return new HashAlgorithmFactory(
                "MD5 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new MD5Digest()));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Ripemd160",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Ripemd160.Create());

            yield return new HashAlgorithmFactory(
                "RIPEMD-160 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new RipeMD160Digest()));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "SM3",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.SM3.Create());

            yield return new HashAlgorithmFactory(
                "SM3 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new SM3Digest()));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Whirlpool",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Whirlpool.Create());

            yield return new HashAlgorithmFactory(
                "Whirlpool (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new WhirlpoolDigest()));

            yield return new HashAlgorithmFactory(
                "Whirlpool (HashifyNET)",
                () => new HashifyNetWhirlpoolAdapter());
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "CShake128",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.CShake128.Create(32));

            yield return new HashAlgorithmFactory(
                "cShake128 (BouncyCastle)",
                () => new BouncyCastleCShakeAdapter(128, null, null, 32));
        }
    }
}

/// <summary>
/// Provides test case sources for cShake256 implementations (64-byte output).
/// </summary>
public static class CShake256Implementations
{
    /// <summary>
    /// Gets all available cShake256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "CShake256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.CShake256.Create(64));

            yield return new HashAlgorithmFactory(
                "cShake256 (BouncyCastle)",
                () => new BouncyCastleCShakeAdapter(256, null, null, 64));
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Streebog-256",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Streebog.Create(32));

            yield return new HashAlgorithmFactory(
                "Streebog-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Gost3411_2012_256Digest()));
        }
    }
}

/// <summary>
/// Provides test case sources for Streebog-512 implementations.
/// </summary>
public static class Streebog512Implementations
{
    /// <summary>
    /// Gets all available Streebog-512 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Streebog-512",
                () => CryptoHives.Foundation.Security.Cryptography.Hash.Streebog.Create(64));

            yield return new HashAlgorithmFactory(
                "Streebog-512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Gost3411_2012_512Digest()));
        }
    }
}

#endregion



