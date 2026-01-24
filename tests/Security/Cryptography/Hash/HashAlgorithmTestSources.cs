// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0618

namespace Cryptography.Tests.Hash;

using Cryptography.Tests.Adapter;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;
using BCAsconHash256 = Org.BouncyCastle.Crypto.Digests.AsconHash256;
using BCAsconXof128 = Org.BouncyCastle.Crypto.Digests.AsconXof128;

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
                () => CH.SHA1.Create());
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
                () => CH.SHA224.Create());

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
                () => CH.SHA256.Create());

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
                () => CH.SHA384.Create());

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

            var simdSupport = CH.SHA512.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA512 (AVX2)",
                    () => CH.SHA512.Create(CH.SimdSupport.Avx2));
            }

            yield return new HashAlgorithmFactory(
                "SHA512 (Managed)",
                () => CH.SHA512.Create(CH.SimdSupport.None));

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
                () => CH.SHA512_224.Create());

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
                () => CH.SHA512_256.Create());

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

            var simdSupport = CH.SHA3_224.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_224 (AVX512F)",
                    () => CH.SHA3_224.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_224 (AVX2)",
                    () => CH.SHA3_224.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_224 (SSSE3)",
                    () => CH.SHA3_224.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "SHA3_224 (Managed)",
                () => CH.SHA3_224.Create(CH.SimdSupport.None));

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

            var simdSupport = CH.SHA3_256.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_256 (AVX512F)",
                    () => CH.SHA3_256.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_256 (AVX2)",
                    () => CH.SHA3_256.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_256 (SSSE3)",
                    () => CH.SHA3_256.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "SHA3_256 (Managed)",
                () => CH.SHA3_256.Create(CH.SimdSupport.None));

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

            var simdSupport = CH.SHA3_384.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_384 (AVX512F)",
                    () => CH.SHA3_384.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_384 (AVX2)",
                    () => CH.SHA3_384.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_384 (SSSE3)",
                    () => CH.SHA3_384.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "SHA3_384 (Managed)",
                () => CH.SHA3_384.Create(CH.SimdSupport.None));

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

            var simdSupport = CH.SHA3_512.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_512 (AVX512F)",
                    () => CH.SHA3_512.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_512 (AVX2)",
                    () => CH.SHA3_512.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "SHA3_512 (SSSE3)",
                    () => CH.SHA3_512.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "SHA3_512 (Managed)",
                () => CH.SHA3_512.Create(CH.SimdSupport.None));

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

            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake128 (AVX512F)",
                    () => CH.Shake128.Create(CH.SimdSupport.Avx512F, 32));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake128 (AVX2)",
                    () => CH.Shake128.Create(CH.SimdSupport.Avx2, 32));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake128 (SSSE3)",
                    () => CH.Shake128.Create(CH.SimdSupport.Ssse3, 32));
            }

            yield return new HashAlgorithmFactory(
                "Shake128 (Managed)",
                () => CH.Shake128.Create(CH.SimdSupport.None, 32));

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

            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake256 (AVX512F)",
                    () => CH.Shake256.Create(CH.SimdSupport.Avx512F, 64));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake256 (AVX2)",
                    () => CH.Shake256.Create(CH.SimdSupport.Avx2, 64));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Shake256 (SSSE3)",
                    () => CH.Shake256.Create(CH.SimdSupport.Ssse3, 64));
            }

            yield return new HashAlgorithmFactory(
                "Shake256 (Managed)",
                () => CH.Shake256.Create(CH.SimdSupport.None, 64));

            yield return new HashAlgorithmFactory(
                "Shake256 (BouncyCastle)",
                () => new BouncyCastleXofAdapter(new ShakeDigest(256), 64));
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
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake128 (AVX512F)",
                    () => CH.CShake128.Create(CH.SimdSupport.Avx512F, 32));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake128 (AVX2)",
                    () => CH.CShake128.Create(CH.SimdSupport.Avx2, 32));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake128 (SSSE3)",
                    () => CH.CShake128.Create(CH.SimdSupport.Ssse3, 32));
            }

            yield return new HashAlgorithmFactory(
                "CShake128 (Managed)",
                () => CH.CShake128.Create(CH.SimdSupport.None, 32));

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
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake256 (AVX512F)",
                    () => CH.CShake256.Create(CH.SimdSupport.Avx512F, 64));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake256 (AVX2)",
                    () => CH.CShake256.Create(CH.SimdSupport.Avx2, 64));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "CShake256 (SSSE3)",
                    () => CH.CShake256.Create(CH.SimdSupport.Ssse3, 64));
            }

            yield return new HashAlgorithmFactory(
                "CShake256 (Managed)",
                () => CH.CShake256.Create(CH.SimdSupport.None, 64));

            yield return new HashAlgorithmFactory(
                "cShake256 (BouncyCastle)",
                () => new BouncyCastleCShakeAdapter(256, null, null, 64));
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
            var simdSupport = CH.Blake2b.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2b-512 (AVX2)",
                    () => CH.Blake2b.Create(64, CH.SimdSupport.Avx2));
            }

            yield return new HashAlgorithmFactory(
                "Blake2b-512 (Managed)",
                () => CH.Blake2b.Create(64, CH.SimdSupport.None));

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
            var simdSupport = CH.Blake2b.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2b-256 (AVX2)",
                    () => CH.Blake2b.Create(32, CH.SimdSupport.Avx2));
            }

            yield return new HashAlgorithmFactory(
                "Blake2b-256 (Managed)",
                () => CH.Blake2b.Create(32, CH.SimdSupport.None));

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
            var simdSupport = CH.Blake2s.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-256 (AVX2)",
                    () => CH.Blake2s.Create(32, CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-256 (SSSE3)",
                    () => CH.Blake2s.Create(32, CH.SimdSupport.Ssse3));
            }

            if ((simdSupport & CH.SimdSupport.Sse2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-256 (SSE2)",
                    () => CH.Blake2s.Create(32, CH.SimdSupport.Sse2));
            }

            yield return new HashAlgorithmFactory(
                "Blake2s-256 (Managed)",
                () => CH.Blake2s.Create(32, CH.SimdSupport.None));

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
            var simdSupport = CH.Blake2s.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-128 (AVX2)",
                    () => CH.Blake2s.Create(16, CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-128 (SSSE3)",
                    () => CH.Blake2s.Create(16, CH.SimdSupport.Ssse3));
            }

            if ((simdSupport & CH.SimdSupport.Sse2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Blake2s-128 (SSE2)",
                    () => CH.Blake2s.Create(16, CH.SimdSupport.Sse2));
            }

            yield return new HashAlgorithmFactory(
                "Blake2s-128 (Managed)",
                () => CH.Blake2s.Create(16, CH.SimdSupport.None));

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
                () => CH.Blake3.Create(32));

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
            var simdSupport = CH.Keccak256.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak256 (AVX512F)",
                    () => CH.Keccak256.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak256 (AVX2)",
                    () => CH.Keccak256.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak256 (SSSE3)",
                    () => CH.Keccak256.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "Keccak256 (Managed)",
                () => CH.Keccak256.Create(CH.SimdSupport.None));

            yield return new HashAlgorithmFactory(
                "Keccak-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new KeccakDigest(256)));
        }
    }
}

/// <summary>
/// Provides test case sources for Keccak-384 implementations.
/// </summary>
public static class Keccak384Implementations
{
    /// <summary>
    /// Gets all available Keccak-384 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            var simdSupport = CH.Keccak384.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak384 (AVX512F)",
                    () => CH.Keccak384.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak384 (AVX2)",
                    () => CH.Keccak384.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak384 (SSSE3)",
                    () => CH.Keccak384.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "Keccak384 (Managed)",
                () => CH.Keccak384.Create(CH.SimdSupport.None));

            yield return new HashAlgorithmFactory(
                "Keccak-384 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new KeccakDigest(384)));
        }
    }
}

/// <summary>
/// Provides test case sources for Keccak-512 implementations.
/// </summary>
public static class Keccak512Implementations
{
    /// <summary>
    /// Gets all available Keccak-512 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            var simdSupport = CH.Keccak512.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak512 (AVX512F)",
                    () => CH.Keccak512.Create(CH.SimdSupport.Avx512F));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak512 (AVX2)",
                    () => CH.Keccak512.Create(CH.SimdSupport.Avx2));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "Keccak512 (SSSE3)",
                    () => CH.Keccak512.Create(CH.SimdSupport.Ssse3));
            }

            yield return new HashAlgorithmFactory(
                "Keccak512 (Managed)",
                () => CH.Keccak512.Create(CH.SimdSupport.None));

            yield return new HashAlgorithmFactory(
                "Keccak-512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new KeccakDigest(512)));
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
                () => CH.MD5.Create());
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
                () => CH.Ripemd160.Create());

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
                () => CH.SM3.Create());

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
                () => CH.Whirlpool.Create());

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
                () => CH.Streebog.Create(32));

            yield return new HashAlgorithmFactory(
                "Streebog-256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Gost3411_2012_256Digest()));

            yield return new HashAlgorithmFactory(
                "Streebog-256 (OpenGost)",
                () => OpenGost.Security.Cryptography.Streebog256.Create());
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
                () => CH.Streebog.Create(64));

            yield return new HashAlgorithmFactory(
                "Streebog-512 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new Gost3411_2012_512Digest()));

            yield return new HashAlgorithmFactory(
                "Streebog-512 (OpenGost)",
                () => OpenGost.Security.Cryptography.Streebog512.Create());
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT128 (AVX512F)",
                    () => CH.KT128.Create(CH.SimdSupport.Avx512F, 32));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT128 (AVX2)",
                    () => CH.KT128.Create(CH.SimdSupport.Avx2, 32));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT128 (SSSE3)",
                    () => CH.KT128.Create(CH.SimdSupport.Ssse3, 32));
            }

            yield return new HashAlgorithmFactory(
                "KT128 (Managed)",
                () => CH.KT128.Create(CH.SimdSupport.None, 32));

            // Note: BouncyCastle 2.6.2 does not include KT128/KangarooTwelve
        }
    }
}

/// <summary>
/// Provides test case sources for KT256 implementations (64-byte output).
/// </summary>
public static class KT256Implementations
{
    /// <summary>
    /// Gets all available KT256 implementations for testing (64-byte output).
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT256 (AVX512F)",
                    () => CH.KT256.Create(CH.SimdSupport.Avx512F, 64));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT256 (AVX2)",
                    () => CH.KT256.Create(CH.SimdSupport.Avx2, 64));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "KT256 (SSSE3)",
                    () => CH.KT256.Create(CH.SimdSupport.Ssse3, 64));
            }

            yield return new HashAlgorithmFactory(
                "KT256 (Managed)",
                () => CH.KT256.Create(CH.SimdSupport.None, 64));

            // Note: BouncyCastle 2.6.2 does not include KT256
        }
    }
}

/// <summary>
/// Provides test case sources for TurboShake128 implementations.
/// </summary>
public static class TurboShake128Implementations
{
    /// <summary>
    /// Gets all available TurboShake128 implementations for testing.
    /// </summary>
    public static IEnumerable All32
    {
        get
        {
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (AVX512F)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Avx512F, 32));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (AVX2)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Avx2, 32));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (SSSE3)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Ssse3, 32));
            }

            yield return new HashAlgorithmFactory(
                "TurboShake128 (Managed)",
                () => CH.TurboShake128.Create(CH.SimdSupport.None, 32));

            // Note: BouncyCastle 2.6.2 does not include TurboSHAKE
        }
    }

    /// <summary>
    /// Gets all available TurboShake128 implementations for testing.
    /// </summary>
    public static IEnumerable All64
    {
        get
        {
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (AVX512F)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Avx512F, 64));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (AVX2)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Avx2, 64));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake128 (SSSE3)",
                    () => CH.TurboShake128.Create(CH.SimdSupport.Ssse3, 64));
            }

            yield return new HashAlgorithmFactory(
                "TurboShake128 (Managed)",
                () => CH.TurboShake128.Create(CH.SimdSupport.None, 64));

            // Note: BouncyCastle 2.6.2 does not include TurboSHAKE
        }
    }
}

/// <summary>
/// Provides test case sources for TurboShake256 implementations.
/// </summary>
public static class TurboShake256Implementations
{
    /// <summary>
    /// Gets all available TurboShake256 implementations for testing.
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            var simdSupport = CH.KeccakCore.SimdSupport;
            if ((simdSupport & CH.SimdSupport.Avx512F) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake256 (AVX512F)",
                    () => CH.TurboShake256.Create(CH.SimdSupport.Avx512F, 64));
            }

            if ((simdSupport & CH.SimdSupport.Avx2) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake256 (AVX2)",
                    () => CH.TurboShake256.Create(CH.SimdSupport.Avx2, 64));
            }

            if ((simdSupport & CH.SimdSupport.Ssse3) != 0)
            {
                yield return new HashAlgorithmFactory(
                    "TurboShake256 (SSSE3)",
                    () => CH.TurboShake256.Create(CH.SimdSupport.Ssse3, 64));
            }

            yield return new HashAlgorithmFactory(
                "TurboShake256 (Managed)",
                () => CH.TurboShake256.Create(CH.SimdSupport.None, 64));

            // Note: BouncyCastle 2.6.2 does not include TurboSHAKE
        }
    }
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
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Ascon-Hash256",
                () => CH.AsconHash256.Create());

            yield return new HashAlgorithmFactory(
                "Ascon-Hash256 (BouncyCastle)",
                () => new BouncyCastleHashAdapter(new BCAsconHash256()));
        }
    }
}

/// <summary>
/// Provides test case sources for Ascon-XOF128 implementations (32-byte output).
/// </summary>
public static class AsconXof128Implementations
{
    /// <summary>
    /// Gets all available Ascon-XOF128 implementations for testing (32-byte output).
    /// </summary>
    public static IEnumerable All
    {
        get
        {
            yield return new HashAlgorithmFactory(
                "Ascon-XOF128",
                () => CH.AsconXof128.Create(32));

            yield return new HashAlgorithmFactory(
                "Ascon-XOF128 (BouncyCastle)",
                () => new BouncyCastleGenericXofAdapter(new BCAsconXof128(), 32));
        }
    }
}

#endregion








