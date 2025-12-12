// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable SYSLIB0021 // Derived cryptographic types are obsolete

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Security.Cryptography.Tests;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;
using CHMac = CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Factory for creating hash algorithm instances for benchmarking.
/// </summary>
public sealed class HashAlgorithmType : IFormattable
{
    private readonly Func<HashAlgorithm> _factory;

    public HashAlgorithmType(string name, string category, Func<HashAlgorithm> factory)
    {
        Name = name;
        Category = category;
        _factory = factory;
    }

    public string Name { get; }

    public string Category { get; }

    public HashAlgorithm Create() => _factory();

    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    public override string ToString() => Name;

    #region SHA-2 Family

    public static readonly HashAlgorithmType SHA256_OS = new("SHA256_OS", "SHA-256", SHA256.Create);
    public static readonly HashAlgorithmType SHA256_OSManaged = new("SHA256_OSManaged", "SHA-256", SHA256.Create);
    public static readonly HashAlgorithmType SHA256_Managed = new("SHA256_Managed", "SHA-256", CH.SHA256.Create);
    public static readonly HashAlgorithmType SHA256_Bouncy = new("SHA256_Bouncy", "SHA-256", () => new BouncyCastleHashAdapter(new Sha256Digest()));

    public static readonly HashAlgorithmType SHA384_OS = new("SHA384_OS", "SHA-384", SHA384.Create);
    public static readonly HashAlgorithmType SHA384_OSManaged = new("SHA384_OSManaged", "SHA-384", SHA384.Create);
    public static readonly HashAlgorithmType SHA384_Managed = new("SHA384_Managed", "SHA-384", CH.SHA384.Create);
    public static readonly HashAlgorithmType SHA384_Bouncy = new("SHA384_Bouncy", "SHA-384", () => new BouncyCastleHashAdapter(new Sha384Digest()));

    public static readonly HashAlgorithmType SHA512_OS = new("SHA512_OS", "SHA-512", SHA512.Create);
    public static readonly HashAlgorithmType SHA512_OSManaged = new("SHA512_OSManaged", "SHA-512", SHA512.Create);
    public static readonly HashAlgorithmType SHA512_Managed = new("SHA512_Managed", "SHA-512", CH.SHA512.Create);
    public static readonly HashAlgorithmType SHA512_Bouncy = new("SHA512_Bouncy", "SHA-512", () => new BouncyCastleHashAdapter(new Sha512Digest()));

    public static readonly HashAlgorithmType SHA224_Managed = new("SHA224_Managed", "SHA-224", CH.SHA224.Create);
    public static readonly HashAlgorithmType SHA224_Bouncy = new("SHA224_Bouncy", "SHA-224", () => new BouncyCastleHashAdapter(new Sha224Digest()));

    public static readonly HashAlgorithmType SHA512_224_Managed = new("SHA512_224_Managed", "SHA-512/224", CH.SHA512_224.Create);
    public static readonly HashAlgorithmType SHA512_224_Bouncy = new("SHA512_224_Bouncy", "SHA-512/224", () => new BouncyCastleHashAdapter(new Sha512tDigest(224)));

    public static readonly HashAlgorithmType SHA512_256_Managed = new("SHA512_256_Managed", "SHA-512/256", CH.SHA512_256.Create);
    public static readonly HashAlgorithmType SHA512_256_Bouncy = new("SHA512_256_Bouncy", "SHA-512/256", () => new BouncyCastleHashAdapter(new Sha512tDigest(256)));

    #endregion

    #region SHA-3 Family

#if NET8_0_OR_GREATER
    // .NET 8+ OS-supported SHA-3 (requires OS support - Windows 11+, modern Linux)
    public static readonly HashAlgorithmType SHA3_256_OS = new("SHA3_256_OS", "SHA3-256", () => SHA3_256.Create());
    public static readonly HashAlgorithmType SHA3_384_OS = new("SHA3_384_OS", "SHA3-384", () => SHA3_384.Create());
    public static readonly HashAlgorithmType SHA3_512_OS = new("SHA3_512_OS", "SHA3-512", () => SHA3_512.Create());
    public static readonly HashAlgorithmType Shake128_OS = new("Shake128_OS", "SHAKE128", () => new Shake128HashAdapter(32));
    public static readonly HashAlgorithmType Shake256_OS = new("Shake256_OS", "SHAKE256", () => new Shake256HashAdapter(64));
#endif

    public static readonly HashAlgorithmType SHA3_224_Managed = new("SHA3_224_Managed", "SHA3-224", CH.SHA3_224.Create);
    public static readonly HashAlgorithmType SHA3_224_Bouncy = new("SHA3_224_Bouncy", "SHA3-224", () => new BouncyCastleHashAdapter(new Sha3Digest(224)));

    public static readonly HashAlgorithmType SHA3_256_Managed = new("SHA3_256_Managed", "SHA3-256", CH.SHA3_256.Create);
    public static readonly HashAlgorithmType SHA3_256_Bouncy = new("SHA3_256_Bouncy", "SHA3-256", () => new BouncyCastleHashAdapter(new Sha3Digest(256)));

    public static readonly HashAlgorithmType SHA3_384_Managed = new("SHA3_384_Managed", "SHA3-384", CH.SHA3_384.Create);
    public static readonly HashAlgorithmType SHA3_384_Bouncy = new("SHA3_384_Bouncy", "SHA3-384", () => new BouncyCastleHashAdapter(new Sha3Digest(384)));

    public static readonly HashAlgorithmType SHA3_512_Managed = new("SHA3_512_Managed", "SHA3-512", CH.SHA3_512.Create);
    public static readonly HashAlgorithmType SHA3_512_Bouncy = new("SHA3_512_Bouncy", "SHA3-512", () => new BouncyCastleHashAdapter(new Sha3Digest(512)));

    public static readonly HashAlgorithmType Keccak256_Managed = new("Keccak256_Managed", "Keccak-256", CH.Keccak256.Create);
    public static readonly HashAlgorithmType Keccak256_Bouncy = new("Keccak256_Bouncy", "Keccak-256", () => new BouncyCastleHashAdapter(new KeccakDigest(256)));

    public static readonly HashAlgorithmType Shake128_Managed = new("Shake128_Managed", "SHAKE128", () => CH.Shake128.Create(32));
    public static readonly HashAlgorithmType Shake128_Bouncy = new("Shake128_Bouncy", "SHAKE128", () => new BouncyCastleXofAdapter(new ShakeDigest(128), 32));

    public static readonly HashAlgorithmType Shake256_Managed = new("Shake256_Managed", "SHAKE256", () => CH.Shake256.Create(64));
    public static readonly HashAlgorithmType Shake256_Bouncy = new("Shake256_Bouncy", "SHAKE256", () => new BouncyCastleXofAdapter(new ShakeDigest(256), 64));

#if NET8_0_OR_GREATER
    public static readonly HashAlgorithmType CShake128_Managed = new("CShake128_Managed", "CSHAKE128", () => CH.CShake128.Create(32));
    public static readonly HashAlgorithmType CShake256_Managed = new("CShake256_Managed", "CSHAKE256", () => CH.CShake256.Create(64));
#endif

    #endregion

    #region BLAKE Family

    public static readonly HashAlgorithmType Blake2b_Managed = new("Blake2b_Managed", "BLAKE2b-512", () => CH.Blake2b.Create(64));
    public static readonly HashAlgorithmType Blake2b_Bouncy = new("Blake2b_Bouncy", "BLAKE2b-512", () => new BouncyCastleHashAdapter(new Blake2bDigest(512)));

    public static readonly HashAlgorithmType Blake2s_Managed = new("Blake2s_Managed", "BLAKE2s-256", () => CH.Blake2s.Create(32));
    public static readonly HashAlgorithmType Blake2s_Bouncy = new("Blake2s_Bouncy", "BLAKE2s-256", () => new BouncyCastleHashAdapter(new Blake2sDigest(256)));

    public static readonly HashAlgorithmType Blake3_Managed = new("Blake3_Managed", "BLAKE3", () => CH.Blake3.Create(32));
    public static readonly HashAlgorithmType Blake3_Bouncy = new("Blake3_Bouncy", "BLAKE3", () => new BouncyCastleHashAdapter(new Blake3Digest(256)));
#if BLAKE3_NATIVE
    public static readonly HashAlgorithmType Blake3_Native = new("Blake3_Native", "BLAKE3", () => new Blake3NativeAdapter(32));
#endif

    #endregion

    #region Legacy

#pragma warning disable CA5350, CA5351, CS0618
    public static readonly HashAlgorithmType MD5_OS = new("MD5_OS", "MD5", MD5.Create);
    public static readonly HashAlgorithmType MD5_Managed = new("MD5_Managed", "MD5", CH.MD5.Create);
    public static readonly HashAlgorithmType MD5_Bouncy = new("MD5_Bouncy", "MD5", () => new BouncyCastleHashAdapter(new MD5Digest()));

    public static readonly HashAlgorithmType SHA1_OS = new("SHA1_OS", "SHA-1", SHA1.Create);
    public static readonly HashAlgorithmType SHA1_Managed = new("SHA1_Managed", "SHA-1", CH.SHA1.Create);
    public static readonly HashAlgorithmType SHA1_Bouncy = new("SHA1_Bouncy", "SHA-1", () => new BouncyCastleHashAdapter(new Sha1Digest()));
#pragma warning restore CA5350, CA5351, CS0618

    #endregion

    #region Regional/Specialty

    public static readonly HashAlgorithmType Ripemd160_Managed = new("Ripemd160_Managed", "RIPEMD-160", CH.Ripemd160.Create);
    public static readonly HashAlgorithmType Ripemd160_Bouncy = new("Ripemd160_Bouncy", "RIPEMD-160", () => new BouncyCastleHashAdapter(new RipeMD160Digest()));

    public static readonly HashAlgorithmType SM3_Managed = new("SM3_Managed", "SM3", CH.SM3.Create);
    public static readonly HashAlgorithmType SM3_Bouncy = new("SM3_Bouncy", "SM3", () => new BouncyCastleHashAdapter(new SM3Digest()));

    public static readonly HashAlgorithmType Whirlpool_Managed = new("Whirlpool_Managed", "Whirlpool", CH.Whirlpool.Create);
    public static readonly HashAlgorithmType Whirlpool_Bouncy = new("Whirlpool_Bouncy", "Whirlpool", () => new BouncyCastleHashAdapter(new WhirlpoolDigest()));

    public static readonly HashAlgorithmType Streebog256_Managed = new("Streebog256_Managed", "Streebog-256", () => CH.Streebog.Create(32));
    public static readonly HashAlgorithmType Streebog256_Bouncy = new("Streebog256_Bouncy", "Streebog-256", () => new BouncyCastleHashAdapter(new Gost3411_2012_256Digest()));

    public static readonly HashAlgorithmType Streebog512_Managed = new("Streebog512_Managed", "Streebog-512", () => CH.Streebog.Create(64));
    public static readonly HashAlgorithmType Streebog512_Bouncy = new("Streebog512_Bouncy", "Streebog-512", () => new BouncyCastleHashAdapter(new Gost3411_2012_512Digest()));

    #endregion

    #region KMAC (Keyed Message Authentication Code)

    // Shared key for KMAC benchmarks (32 bytes)
    private static readonly byte[] SharedKmacKey = new byte[]
    {
        0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
        0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
        0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
        0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f
    };

    private static readonly byte[] SharedKmacCustomization = Encoding.UTF8.GetBytes("Benchmark");

    public static readonly HashAlgorithmType Kmac128_Managed = new("Kmac128_Managed", "KMAC-128",
        () => CHMac.Kmac128.Create(SharedKmacKey, 32, "Benchmark"));

    public static readonly HashAlgorithmType Kmac128_Bouncy = new("Kmac128_Bouncy", "KMAC-128",
        () => new BouncyCastleKmacAdapter(128, SharedKmacKey, SharedKmacCustomization, 32));

    public static readonly HashAlgorithmType Kmac256_Managed = new("Kmac256_Managed", "KMAC-256",
        () => CHMac.Kmac256.Create(SharedKmacKey, 64, "Benchmark"));

    public static readonly HashAlgorithmType Kmac256_Bouncy = new("Kmac256_Bouncy", "KMAC-256",
        () => new BouncyCastleKmacAdapter(256, SharedKmacKey, SharedKmacCustomization, 64));

#if NET9_0_OR_GREATER
    public static readonly HashAlgorithmType Kmac128_OS = new("Kmac128_OS", "KMAC-128",
        () => new Kmac128HashAdapter(SharedKmacKey, 32, SharedKmacCustomization));

    public static readonly HashAlgorithmType Kmac256_OS = new("Kmac256_OS", "KMAC-256",
        () => new Kmac256HashAdapter(SharedKmacKey, 64, SharedKmacCustomization));
#endif

    #endregion

    #region Collections

    /// <summary>All CryptoHives managed implementations.</summary>
    public static IEnumerable<HashAlgorithmType> AllManaged()
    {
        yield return SHA256_Managed;
        yield return SHA384_Managed;
        yield return SHA512_Managed;
        yield return SHA224_Managed;
        yield return SHA512_224_Managed;
        yield return SHA512_256_Managed;
        yield return SHA3_224_Managed;
        yield return SHA3_256_Managed;
        yield return SHA3_384_Managed;
        yield return SHA3_512_Managed;
        yield return Keccak256_Managed;
        yield return Shake128_Managed;
        yield return Shake256_Managed;
#if NET8_0_OR_GREATER
        yield return CShake128_Managed;
        yield return CShake256_Managed;
#endif
        yield return Blake2b_Managed;
        yield return Blake2s_Managed;
        yield return Blake3_Managed;
        yield return MD5_Managed;
        yield return SHA1_Managed;
        yield return Ripemd160_Managed;
        yield return SM3_Managed;
        yield return Whirlpool_Managed;
        yield return Streebog256_Managed;
        yield return Streebog512_Managed;
        yield return Kmac128_Managed;
        yield return Kmac256_Managed;
    }

    /// <summary>Core algorithms for comparison benchmarks.</summary>
    public static IEnumerable<HashAlgorithmType> CoreComparison()
    {
        yield return SHA256_OS;
        yield return SHA256_Managed;
        yield return SHA256_Bouncy;
        yield return SHA512_OS;
        yield return SHA512_Managed;
        yield return SHA512_Bouncy;
#if NET8_0_OR_GREATER
        yield return SHA3_256_OS;
#endif
        yield return SHA3_256_Managed;
        yield return SHA3_256_Bouncy;
        yield return Blake2b_Managed;
        yield return Blake2b_Bouncy;
        yield return Blake3_Managed;
        yield return Blake3_Bouncy;
    }

    /// <summary>All implementations for full matrix benchmark.</summary>
    public static IEnumerable<HashAlgorithmType> AllHashers()
    {
        // SHA-2
        yield return SHA256_OS;
        yield return SHA256_OSManaged;
        yield return SHA256_Managed;
        yield return SHA256_Bouncy;
        yield return SHA384_OS;
        yield return SHA384_OSManaged;
        yield return SHA384_Managed;
        yield return SHA384_Bouncy;
        yield return SHA512_OS;
        yield return SHA512_OSManaged;
        yield return SHA512_Managed;
        yield return SHA512_Bouncy;
        yield return SHA224_Managed;
        yield return SHA224_Bouncy;
        yield return SHA512_224_Managed;
        yield return SHA512_224_Bouncy;
        yield return SHA512_256_Managed;
        yield return SHA512_256_Bouncy;

        // SHA-3
#if NET8_0_OR_GREATER
        yield return SHA3_256_OS;
        yield return SHA3_384_OS;
        yield return SHA3_512_OS;
        yield return Shake128_OS;
        yield return Shake256_OS;
#endif
        yield return SHA3_224_Managed;
        yield return SHA3_224_Bouncy;
        yield return SHA3_256_Managed;
        yield return SHA3_256_Bouncy;
        yield return SHA3_384_Managed;
        yield return SHA3_384_Bouncy;
        yield return SHA3_512_Managed;
        yield return SHA3_512_Bouncy;
        yield return Keccak256_Managed;
        yield return Keccak256_Bouncy;
        yield return Shake128_Managed;
        yield return Shake128_Bouncy;
        yield return Shake256_Managed;
        yield return Shake256_Bouncy;
#if NET8_0_OR_GREATER
        yield return CShake128_Managed;
        yield return CShake256_Managed;
#endif

        // BLAKE
        yield return Blake2b_Managed;
        yield return Blake2b_Bouncy;
        yield return Blake2s_Managed;
        yield return Blake2s_Bouncy;
        yield return Blake3_Managed;
        yield return Blake3_Bouncy;
#if BLAKE3_NATIVE
        yield return Blake3_Native;
#endif

        // Legacy
        yield return MD5_OS;
        yield return MD5_Managed;
        yield return MD5_Bouncy;
        yield return SHA1_OS;
        yield return SHA1_Managed;
        yield return SHA1_Bouncy;

        // Regional
        yield return Ripemd160_Managed;
        yield return Ripemd160_Bouncy;
        yield return SM3_Managed;
        yield return SM3_Bouncy;
        yield return Whirlpool_Managed;
        yield return Whirlpool_Bouncy;
        yield return Streebog256_Managed;
        yield return Streebog256_Bouncy;
        yield return Streebog512_Managed;
        yield return Streebog512_Bouncy;

        // KMAC
#if NET9_0_OR_GREATER
        yield return Kmac128_OS;
        yield return Kmac256_OS;
#endif
        yield return Kmac128_Managed;
        yield return Kmac128_Bouncy;
        yield return Kmac256_Managed;
        yield return Kmac256_Bouncy;
    }

    /// <summary>All SHA-3 family implementations for comparison.</summary>
    public static IEnumerable<HashAlgorithmType> AllSHA3()
    {
#if NET8_0_OR_GREATER
        yield return SHA3_256_OS;
        yield return SHA3_384_OS;
        yield return SHA3_512_OS;
        yield return Shake128_OS;
        yield return Shake256_OS;
#endif
        yield return SHA3_224_Managed;
        yield return SHA3_224_Bouncy;
        yield return SHA3_256_Managed;
        yield return SHA3_256_Bouncy;
        yield return SHA3_384_Managed;
        yield return SHA3_384_Bouncy;
        yield return SHA3_512_Managed;
        yield return SHA3_512_Bouncy;
        yield return Keccak256_Managed;
        yield return Keccak256_Bouncy;
        yield return Shake128_Managed;
        yield return Shake128_Bouncy;
        yield return Shake256_Managed;
        yield return Shake256_Bouncy;
#if NET8_0_OR_GREATER
        yield return CShake128_Managed;
        yield return CShake256_Managed;
#endif
    }

    /// <summary>All KMAC implementations for comparison.</summary>
    public static IEnumerable<HashAlgorithmType> AllKmac()
    {
#if NET9_0_OR_GREATER
        yield return Kmac128_OS;
        yield return Kmac256_OS;
#endif
        yield return Kmac128_Managed;
        yield return Kmac128_Bouncy;
        yield return Kmac256_Managed;
        yield return Kmac256_Bouncy;
    }

    #endregion
}


