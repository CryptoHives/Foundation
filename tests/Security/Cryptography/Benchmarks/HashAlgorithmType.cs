// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable IDE0011 // Add braces

using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.X86;
#endif
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;
using CHMac = CryptoHives.Foundation.Security.Cryptography.Mac;
using System.Runtime.CompilerServices;
using Cryptography.Tests.Adapter;

/// <summary>
/// Factory for creating hash algorithm instances for benchmarking.
/// </summary>
public sealed class HashAlgorithmType : IFormattable
{
    private readonly Func<HashAlgorithm> _factory;
    private readonly Func<bool>? _isSupported;

    public HashAlgorithmType(string category, Func<HashAlgorithm> factory, Func<bool>? isSupported = null, [CallerMemberName] string? name = null)
    {
        Category = category;
        _factory = factory;
        _isSupported = isSupported;
        Name = name!;
    }

    public string Name { get; }

    public string Category { get; }

    public bool IsSupported => _isSupported?.Invoke() ?? true;

    /// <summary>
    /// Creates an instance of the hash algorithm.
    /// </summary>
    /// <returns>The hash algorithm instance, or null if not supported.</returns>
    /// <exception cref="PlatformNotSupportedException">Thrown if the algorithm is not supported on this platform.</exception>
    public HashAlgorithm Create()
    {
        if (!IsSupported)
        {
            throw new PlatformNotSupportedException($"Hash algorithm '{Name}' is not supported on this platform.");
        }
        return _factory();
    }

    /// <summary>
    /// Tries to create an instance of the hash algorithm.
    /// </summary>
    /// <param name="algorithm">The created algorithm, or null if not supported.</param>
    /// <returns>True if the algorithm was created successfully.</returns>
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

    public string ToString(string? format, IFormatProvider? formatProvider) => Name;

    public override string ToString() => Name;

    #region SHA-2 Family

    public static readonly HashAlgorithmType SHA256_OS = new("SHA-256", SHA256.Create);
    public static readonly HashAlgorithmType SHA256_Managed = new("SHA-256", CH.SHA256.Create);
    public static readonly HashAlgorithmType SHA256_Bouncy = new("SHA-256", () => new BouncyCastleHashAdapter(new Sha256Digest()));

    public static readonly HashAlgorithmType SHA384_OS = new("SHA-384", SHA384.Create);
    public static readonly HashAlgorithmType SHA384_Managed = new("SHA-384", CH.SHA384.Create);
    public static readonly HashAlgorithmType SHA384_Bouncy = new("SHA-384", () => new BouncyCastleHashAdapter(new Sha384Digest()));

    public static readonly HashAlgorithmType SHA512_OS = new("SHA-512", SHA512.Create);
    public static readonly HashAlgorithmType SHA512_Managed = new("SHA-512", CH.SHA512.Create);
    public static readonly HashAlgorithmType SHA512_Bouncy = new("SHA-512", () => new BouncyCastleHashAdapter(new Sha512Digest()));

    public static readonly HashAlgorithmType SHA224_Managed = new("SHA-224", CH.SHA224.Create);
    public static readonly HashAlgorithmType SHA224_Bouncy = new("SHA-224", () => new BouncyCastleHashAdapter(new Sha224Digest()));

    public static readonly HashAlgorithmType SHA512_224_Managed = new("SHA-512/224", CH.SHA512_224.Create);
    public static readonly HashAlgorithmType SHA512_224_Bouncy = new("SHA-512/224", () => new BouncyCastleHashAdapter(new Sha512tDigest(224)));

    public static readonly HashAlgorithmType SHA512_256_Managed = new("SHA-512/256", CH.SHA512_256.Create);
    public static readonly HashAlgorithmType SHA512_256_Bouncy = new("SHA-512/256", () => new BouncyCastleHashAdapter(new Sha512tDigest(256)));

    #endregion

    #region SHA-3 Family

#if NET8_0_OR_GREATER
    // .NET 8+ OS-supported SHA-3 (requires OS support - Windows 11+, modern Linux)
    public static readonly HashAlgorithmType SHA3_256_OS = new("SHA3-256", () => SHA3_256.Create(), () => SHA3_256.IsSupported);
    public static readonly HashAlgorithmType SHA3_384_OS = new("SHA3-384", () => SHA3_384.Create(), () => SHA3_384.IsSupported);
    public static readonly HashAlgorithmType SHA3_512_OS = new("SHA3-512", () => SHA3_512.Create(), () => SHA3_512.IsSupported);
    public static readonly HashAlgorithmType Shake128_OS = new("SHAKE128", () => new Shake128HashAdapter(32), () => Shake128.IsSupported);
    public static readonly HashAlgorithmType Shake256_OS = new("SHAKE256", () => new Shake256HashAdapter(64), () => Shake256.IsSupported);
#endif

    public static readonly HashAlgorithmType SHA3_224_Managed = new("SHA3-224", CH.SHA3_224.Create);
    public static readonly HashAlgorithmType SHA3_224_Bouncy = new("SHA3-224", () => new BouncyCastleHashAdapter(new Sha3Digest(224)));

    public static readonly HashAlgorithmType SHA3_256_Managed = new("SHA3-256", CH.SHA3_256.Create);
    public static readonly HashAlgorithmType SHA3_256_Bouncy = new("SHA3-256", () => new BouncyCastleHashAdapter(new Sha3Digest(256)));

    public static readonly HashAlgorithmType SHA3_384_Managed = new("SHA3-384", CH.SHA3_384.Create);
    public static readonly HashAlgorithmType SHA3_384_Bouncy = new("SHA3-384", () => new BouncyCastleHashAdapter(new Sha3Digest(384)));

    public static readonly HashAlgorithmType SHA3_512_Managed = new("SHA3-512", CH.SHA3_512.Create);
    public static readonly HashAlgorithmType SHA3_512_Bouncy = new("SHA3-512", () => new BouncyCastleHashAdapter(new Sha3Digest(512)));

    public static readonly HashAlgorithmType Keccak256_Managed = new("Keccak-256", CH.Keccak256.Create);
    public static readonly HashAlgorithmType Keccak256_Bouncy = new("Keccak-256", () => new BouncyCastleHashAdapter(new KeccakDigest(256)));

    public static readonly HashAlgorithmType Shake128_Managed = new("SHAKE128", () => CH.Shake128.Create(32));
    public static readonly HashAlgorithmType Shake128_Bouncy = new("SHAKE128", () => new BouncyCastleXofAdapter(new ShakeDigest(128), 32));

    public static readonly HashAlgorithmType Shake256_Managed = new("SHAKE256", () => CH.Shake256.Create(64));
    public static readonly HashAlgorithmType Shake256_Bouncy = new("SHAKE256", () => new BouncyCastleXofAdapter(new ShakeDigest(256), 64));

    public static readonly HashAlgorithmType CShake128_Managed = new("CSHAKE128", () => CH.CShake128.Create(32));
    public static readonly HashAlgorithmType CShake128_Bouncy = new("CSHAKE128", () => new BouncyCastleCShakeAdapter(128, null, null, 32));

    public static readonly HashAlgorithmType CShake256_Managed = new("CSHAKE256", () => CH.CShake256.Create(64));
    public static readonly HashAlgorithmType CShake256_Bouncy = new("CSHAKE256", () => new BouncyCastleCShakeAdapter(256, null, null, 64));

    public static readonly HashAlgorithmType KT128_Managed = new("KT128", () => CH.KT128.Create(32));
    public static readonly HashAlgorithmType KT256_Managed = new("KT256", () => CH.KT256.Create(64));
    public static readonly HashAlgorithmType TurboShake128_Managed = new("TurboSHAKE128", () => CH.TurboShake128.Create(32));
    public static readonly HashAlgorithmType TurboShake256_Managed = new("TurboSHAKE256", () => CH.TurboShake256.Create(64));

#if NET8_0_OR_GREATER
    // SIMD-accelerated variants (use SIMD when available)
    public static readonly HashAlgorithmType Keccak256_Managed_Avx512F = new("Keccak-256",
        () => CH.Keccak256.Create(CH.SimdSupport.Avx512F), () => (CH.Keccak256.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType Keccak256_Managed_Avx2 = new("Keccak-256",
        () => CH.Keccak256.Create(CH.SimdSupport.Avx2), () => (CH.Keccak256.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType Keccak256_Managed_Ssse3 = new("Keccak-256",
        () => CH.Keccak256.Create(CH.SimdSupport.Ssse3), () => (CH.Keccak256.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType Keccak256_Managed_Scalar = new("Keccak-256",
        () => CH.Keccak256.Create(CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType SHA3_224_Managed_Avx512F = new("SHA3-224",
        () => CH.SHA3_224.Create(CH.SimdSupport.Avx512F), () => (CH.SHA3_224.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType SHA3_224_Managed_Avx2 = new("SHA3-224",
        () => CH.SHA3_224.Create(CH.SimdSupport.Avx2), () => (CH.SHA3_224.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType SHA3_224_Managed_Ssse3 = new("SHA3-224",
        () => CH.SHA3_224.Create(CH.SimdSupport.Ssse3), () => (CH.SHA3_224.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType SHA3_224_Managed_Scalar = new("SHA3-224",
        () => CH.SHA3_224.Create(CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType SHA3_256_Managed_Avx512F = new("SHA3-256",
        () => CH.SHA3_256.Create(CH.SimdSupport.Avx512F), () => (CH.SHA3_256.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType SHA3_256_Managed_Avx2 = new("SHA3-256",
        () => CH.SHA3_256.Create(CH.SimdSupport.Avx2), () => (CH.SHA3_256.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType SHA3_256_Managed_Ssse3 = new("SHA3-256",
        () => CH.SHA3_256.Create(CH.SimdSupport.Ssse3), () => (CH.SHA3_256.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType SHA3_256_Managed_Scalar = new("SHA3-256",
        () => CH.SHA3_256.Create(CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType SHA3_384_Managed_Avx512F = new("SHA3-384",
        () => CH.SHA3_384.Create(CH.SimdSupport.Avx512F), () => (CH.SHA3_384.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType SHA3_384_Managed_Avx2 = new("SHA3-384",
        () => CH.SHA3_384.Create(CH.SimdSupport.Avx2), () => (CH.SHA3_384.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType SHA3_384_Managed_Ssse3 = new("SHA3-384",
        () => CH.SHA3_384.Create(CH.SimdSupport.Ssse3), () => (CH.SHA3_384.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType SHA3_384_Managed_Scalar = new("SHA3-384",
        () => CH.SHA3_384.Create(CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType SHA3_512_Managed_Avx512F = new("SHA3-512",
        () => CH.SHA3_512.Create(CH.SimdSupport.Avx512F), () => (CH.SHA3_512.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType SHA3_512_Managed_Avx2 = new("SHA3-512",
        () => CH.SHA3_512.Create(CH.SimdSupport.Avx2), () => (CH.SHA3_512.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType SHA3_512_Managed_Ssse3 = new("SHA3-512",
        () => CH.SHA3_512.Create(CH.SimdSupport.Ssse3), () => (CH.SHA3_512.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType SHA3_512_Managed_Scalar = new("SHA3-512",
        () => CH.SHA3_512.Create(CH.SimdSupport.None), () => true);

    // SHAKE SIMD variants
    public static readonly HashAlgorithmType Shake128_Managed_Avx512F = new("SHAKE128",
        () => CH.Shake128.Create(CH.SimdSupport.Avx512F, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType Shake128_Managed_Avx2 = new("SHAKE128",
        () => CH.Shake128.Create(CH.SimdSupport.Avx2, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType Shake128_Managed_Ssse3 = new("SHAKE128",
        () => CH.Shake128.Create(CH.SimdSupport.Ssse3, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType Shake128_Managed_Scalar = new("SHAKE128",
        () => CH.Shake128.Create(CH.SimdSupport.None, 32), () => true);

    public static readonly HashAlgorithmType Shake256_Managed_Avx512F = new("SHAKE256",
        () => CH.Shake256.Create(CH.SimdSupport.Avx512F, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType Shake256_Managed_Avx2 = new("SHAKE256",
        () => CH.Shake256.Create(CH.SimdSupport.Avx2, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType Shake256_Managed_Ssse3 = new("SHAKE256",
        () => CH.Shake256.Create(CH.SimdSupport.Ssse3, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType Shake256_Managed_Scalar = new("SHAKE256",
        () => CH.Shake256.Create(CH.SimdSupport.None, 64), () => true);

    // cSHAKE SIMD variants
    public static readonly HashAlgorithmType CShake128_Managed_Avx512F = new("CSHAKE128",
        () => CH.CShake128.Create(CH.SimdSupport.Avx512F, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType CShake128_Managed_Avx2 = new("CSHAKE128",
        () => CH.CShake128.Create(CH.SimdSupport.Avx2, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType CShake128_Managed_Ssse3 = new("CSHAKE128",
        () => CH.CShake128.Create(CH.SimdSupport.Ssse3, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType CShake128_Managed_Scalar = new("CSHAKE128",
        () => CH.CShake128.Create(CH.SimdSupport.None, 32), () => true);

    public static readonly HashAlgorithmType CShake256_Managed_Avx512F = new("CSHAKE256",
        () => CH.CShake256.Create(CH.SimdSupport.Avx512F, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType CShake256_Managed_Avx2 = new("CSHAKE256",
        () => CH.CShake256.Create(CH.SimdSupport.Avx2, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType CShake256_Managed_Ssse3 = new("CSHAKE256",
        () => CH.CShake256.Create(CH.SimdSupport.Ssse3, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType CShake256_Managed_Scalar = new("CSHAKE256",
        () => CH.CShake256.Create(CH.SimdSupport.None, 64), () => true);

    // KT SIMD variants
    public static readonly HashAlgorithmType KT128_Managed_Avx512F = new("KT128",
        () => CH.KT128.Create(CH.SimdSupport.Avx512F, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType KT128_Managed_Avx2 = new("KT128",
        () => CH.KT128.Create(CH.SimdSupport.Avx2, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType KT128_Managed_Ssse3 = new("KT128",
        () => CH.KT128.Create(CH.SimdSupport.Ssse3, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType KT128_Managed_Scalar = new("KT128",
        () => CH.KT128.Create(CH.SimdSupport.None, 32), () => true);

    public static readonly HashAlgorithmType KT256_Managed_Avx512F = new("KT256",
        () => CH.KT256.Create(CH.SimdSupport.Avx512F, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType KT256_Managed_Avx2 = new("KT256",
        () => CH.KT256.Create(CH.SimdSupport.Avx2, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType KT256_Managed_Ssse3 = new("KT256",
        () => CH.KT256.Create(CH.SimdSupport.Ssse3, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType KT256_Managed_Scalar = new("KT256",
        () => CH.KT256.Create(CH.SimdSupport.None, 64), () => true);

    // TurboSHAKE SIMD variants
    public static readonly HashAlgorithmType TurboShake128_Managed_Avx512F = new("TurboSHAKE128",
        () => CH.TurboShake128.Create(CH.SimdSupport.Avx512F, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType TurboShake128_Managed_Avx2 = new("TurboSHAKE128",
        () => CH.TurboShake128.Create(CH.SimdSupport.Avx2, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType TurboShake128_Managed_Ssse3 = new("TurboSHAKE128",
        () => CH.TurboShake128.Create(CH.SimdSupport.Ssse3, 32), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType TurboShake128_Managed_Scalar = new("TurboSHAKE128",
        () => CH.TurboShake128.Create(CH.SimdSupport.None, 32), () => true);

    public static readonly HashAlgorithmType TurboShake256_Managed_Avx512F = new("TurboSHAKE256",
        () => CH.TurboShake256.Create(CH.SimdSupport.Avx512F, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx512F) != 0);

    public static readonly HashAlgorithmType TurboShake256_Managed_Avx2 = new("TurboSHAKE256",
        () => CH.TurboShake256.Create(CH.SimdSupport.Avx2, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Avx2) != 0);

    public static readonly HashAlgorithmType TurboShake256_Managed_Ssse3 = new("TurboSHAKE256",
        () => CH.TurboShake256.Create(CH.SimdSupport.Ssse3, 64), () => (CH.KeccakCore.SimdSupport & CH.SimdSupport.Ssse3) != 0);

    public static readonly HashAlgorithmType TurboShake256_Managed_Scalar = new("TurboSHAKE256",
        () => CH.TurboShake256.Create(CH.SimdSupport.None, 64), () => true);
#endif
    #endregion

    #region BLAKE Family

    public static readonly HashAlgorithmType Blake2b_Managed = new("BLAKE2b-512", () => CH.Blake2b.Create(64));
    public static readonly HashAlgorithmType Blake2b_Bouncy = new("BLAKE2b-512", () => new BouncyCastleHashAdapter(new Blake2bDigest(512)));

    public static readonly HashAlgorithmType Blake2s_Managed = new("BLAKE2s-256", () => CH.Blake2s.Create(32));
    public static readonly HashAlgorithmType Blake2s_Bouncy = new("BLAKE2s-256", () => new BouncyCastleHashAdapter(new Blake2sDigest(256)));

    public static readonly HashAlgorithmType Blake3_Managed = new("BLAKE3", () => CH.Blake3.Create(32));
    public static readonly HashAlgorithmType Blake3_Bouncy = new("BLAKE3", () => new BouncyCastleHashAdapter(new Blake3Digest(256)));

#if NET8_0_OR_GREATER
    // SIMD-accelerated variants (use SIMD when available)
    public static readonly HashAlgorithmType Blake2b_Managed_Avx2 = new("BLAKE2b-512",
        () => CH.Blake2b.Create(64, CH.SimdSupport.Avx2), () => Avx2.IsSupported);

    public static readonly HashAlgorithmType Blake2s_Managed_Sse2 = new("BLAKE2s-256",
        () => CH.Blake2s.Create(32, CH.SimdSupport.Sse2), () => Sse2.IsSupported);

    public static readonly HashAlgorithmType Blake2s_Managed_Avx2 = new("BLAKE2s-256",
        () => CH.Blake2s.Create(32, CH.SimdSupport.Avx2), () => Avx2.IsSupported);

    public static readonly HashAlgorithmType Blake3_Managed_Ssse3 = new("BLAKE3",
        () => CH.Blake3.Create(32, CH.SimdSupport.Ssse3), () => Ssse3.IsSupported);

    // Scalar variants (force scalar path for comparison)
    public static readonly HashAlgorithmType Blake2b_Managed_Scalar = new("BLAKE2b-512",
        () => new CH.Blake2b(64, null, CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType Blake2s_Managed_Scalar = new("BLAKE2s-256",
        () => new CH.Blake2s(32, null, CH.SimdSupport.None), () => true);

    public static readonly HashAlgorithmType Blake3_Managed_Scalar = new("BLAKE3",
        () => new CH.Blake3(32, CH.SimdSupport.None), () => true);
#endif

#if BLAKE3_NATIVE
    public static readonly HashAlgorithmType Blake3_Native = new("BLAKE3", () => new Blake3NativeAdapter(32));
#endif

    #endregion

    #region Legacy

#pragma warning disable CA5350, CA5351, CS0618
    public static readonly HashAlgorithmType MD5_OS = new("MD5", MD5.Create);
    public static readonly HashAlgorithmType MD5_Managed = new("MD5", CH.MD5.Create);
    public static readonly HashAlgorithmType MD5_Bouncy = new("MD5", () => new BouncyCastleHashAdapter(new MD5Digest()));

    public static readonly HashAlgorithmType SHA1_OS = new("SHA-1", SHA1.Create);
    public static readonly HashAlgorithmType SHA1_Managed = new("SHA-1", CH.SHA1.Create);
    public static readonly HashAlgorithmType SHA1_Bouncy = new("SHA-1", () => new BouncyCastleHashAdapter(new Sha1Digest()));
#pragma warning restore CA5350, CA5351, CS0618

    #endregion

    #region Regional/Specialty

    public static readonly HashAlgorithmType Ripemd160_Managed = new("RIPEMD-160", CH.Ripemd160.Create);
    public static readonly HashAlgorithmType Ripemd160_Bouncy = new("RIPEMD-160", () => new BouncyCastleHashAdapter(new RipeMD160Digest()));

    public static readonly HashAlgorithmType SM3_Managed = new("SM3", CH.SM3.Create);
    public static readonly HashAlgorithmType SM3_Bouncy = new("SM3", () => new BouncyCastleHashAdapter(new SM3Digest()));

    public static readonly HashAlgorithmType Whirlpool_Managed = new("Whirlpool", CH.Whirlpool.Create);
    public static readonly HashAlgorithmType Whirlpool_Bouncy = new("Whirlpool", () => new BouncyCastleHashAdapter(new WhirlpoolDigest()));

    public static readonly HashAlgorithmType Streebog256_Managed = new("Streebog-256", () => CH.Streebog.Create(32));
    public static readonly HashAlgorithmType Streebog256_Bouncy = new("Streebog-256", () => new BouncyCastleHashAdapter(new Gost3411_2012_256Digest()));
    public static readonly HashAlgorithmType Streebog256_OpenGost = new("Streebog-256", () => OpenGost.Security.Cryptography.Streebog256.Create());

    public static readonly HashAlgorithmType Streebog512_Managed = new("Streebog-512", () => CH.Streebog.Create(64));
    public static readonly HashAlgorithmType Streebog512_Bouncy = new("Streebog-512", () => new BouncyCastleHashAdapter(new Gost3411_2012_512Digest()));
    public static readonly HashAlgorithmType Streebog512_OpenGost = new("Streebog-512", () => OpenGost.Security.Cryptography.Streebog512.Create());

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

    public static readonly HashAlgorithmType Kmac128_Managed = new("KMAC-128",
        () => CHMac.Kmac128.Create(SharedKmacKey, 32, "Benchmark"));

    public static readonly HashAlgorithmType Kmac128_Bouncy = new("KMAC-128",
        () => new BouncyCastleKmacAdapter(128, SharedKmacKey, SharedKmacCustomization, 32));

    public static readonly HashAlgorithmType Kmac256_Managed = new("KMAC-256",
        () => CHMac.Kmac256.Create(SharedKmacKey, 64, "Benchmark"));

    public static readonly HashAlgorithmType Kmac256_Bouncy = new("KMAC-256",
        () => new BouncyCastleKmacAdapter(256, SharedKmacKey, SharedKmacCustomization, 64));

#if NET9_0_OR_GREATER
    public static readonly HashAlgorithmType Kmac128_OS = new("KMAC-128",
        () => new Kmac128HashAdapter(SharedKmacKey, 32, SharedKmacCustomization),
        () => Kmac128.IsSupported);

    public static readonly HashAlgorithmType Kmac256_OS = new("KMAC-256",
        () => new Kmac256HashAdapter(SharedKmacKey, 64, SharedKmacCustomization),
        () => Kmac256.IsSupported);
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
        yield return CShake128_Managed;
        yield return CShake256_Managed;
        yield return KT128_Managed;
        yield return KT256_Managed;
        yield return TurboShake128_Managed;
        yield return TurboShake256_Managed;
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
        if (SHA3_256_OS.IsSupported) yield return SHA3_256_OS;
#endif
        yield return SHA3_256_Managed;
        yield return SHA3_256_Bouncy;
        yield return Blake2b_Managed;
        yield return Blake2b_Bouncy;
        yield return Blake3_Managed;
        yield return Blake3_Bouncy;
    }

    /// <summary>All implementations for full matrix benchmark, filtered to only supported algorithms.</summary>
    public static IEnumerable<HashAlgorithmType> AllHashers()
    {
        // SHA-2
        yield return SHA256_OS;
        yield return SHA256_Managed;
        yield return SHA256_Bouncy;
        yield return SHA384_OS;
        yield return SHA384_Managed;
        yield return SHA384_Bouncy;
        yield return SHA512_OS;
        yield return SHA512_Managed;
        yield return SHA512_Bouncy;
        yield return SHA224_Managed;
        yield return SHA224_Bouncy;
        yield return SHA512_224_Managed;
        yield return SHA512_224_Bouncy;
        yield return SHA512_256_Managed;
        yield return SHA512_256_Bouncy;

        // SHA-3 (OS-level - only yield if supported)
#if NET8_0_OR_GREATER
        if (SHA3_256_OS.IsSupported) yield return SHA3_256_OS;
        if (SHA3_384_OS.IsSupported) yield return SHA3_384_OS;
        if (SHA3_512_OS.IsSupported) yield return SHA3_512_OS;
        if (Shake128_OS.IsSupported) yield return Shake128_OS;
        if (Shake256_OS.IsSupported) yield return Shake256_OS;

        // SHA3-224 SIMD variants
        if (SHA3_224_Managed_Avx512F.IsSupported) yield return SHA3_224_Managed_Avx512F;
        if (SHA3_224_Managed_Avx2.IsSupported) yield return SHA3_224_Managed_Avx2;
        if (SHA3_224_Managed_Ssse3.IsSupported) yield return SHA3_224_Managed_Ssse3;
        yield return SHA3_224_Managed_Scalar;
        yield return SHA3_224_Bouncy;

        // SHA3-256 SIMD variants
        if (SHA3_256_Managed_Avx512F.IsSupported) yield return SHA3_256_Managed_Avx512F;
        if (SHA3_256_Managed_Avx2.IsSupported) yield return SHA3_256_Managed_Avx2;
        if (SHA3_256_Managed_Ssse3.IsSupported) yield return SHA3_256_Managed_Ssse3;
        yield return SHA3_256_Managed_Scalar;
        yield return SHA3_256_Bouncy;

        // SHA3-384 SIMD variants
        if (SHA3_384_Managed_Avx512F.IsSupported) yield return SHA3_384_Managed_Avx512F;
        if (SHA3_384_Managed_Avx2.IsSupported) yield return SHA3_384_Managed_Avx2;
        if (SHA3_384_Managed_Ssse3.IsSupported) yield return SHA3_384_Managed_Ssse3;
        yield return SHA3_384_Managed_Scalar;
        yield return SHA3_384_Bouncy;

        // SHA3-512 SIMD variants
        if (SHA3_512_Managed_Avx512F.IsSupported) yield return SHA3_512_Managed_Avx512F;
        if (SHA3_512_Managed_Avx2.IsSupported) yield return SHA3_512_Managed_Avx2;
        if (SHA3_512_Managed_Ssse3.IsSupported) yield return SHA3_512_Managed_Ssse3;
        yield return SHA3_512_Managed_Scalar;
        yield return SHA3_512_Bouncy;
#else
        yield return SHA3_224_Managed;
        yield return SHA3_224_Bouncy;
        yield return SHA3_256_Managed;
        yield return SHA3_256_Bouncy;
        yield return SHA3_384_Managed;
        yield return SHA3_384_Bouncy;
        yield return SHA3_512_Managed;
        yield return SHA3_512_Bouncy;
#endif

        // Keccak
#if NET8_0_OR_GREATER
        if (Keccak256_Managed_Avx512F.IsSupported) yield return Keccak256_Managed_Avx512F;
        if (Keccak256_Managed_Avx2.IsSupported) yield return Keccak256_Managed_Avx2;
        if (Keccak256_Managed_Ssse3.IsSupported) yield return Keccak256_Managed_Ssse3;
        yield return Keccak256_Managed_Scalar;
        yield return Keccak256_Bouncy;
#else
        yield return Keccak256_Managed;
        yield return Keccak256_Bouncy;
#endif

        // SHAKE and cSHAKE
#if NET8_0_OR_GREATER
        if (Shake128_Managed_Avx512F.IsSupported) yield return Shake128_Managed_Avx512F;
        if (Shake128_Managed_Avx2.IsSupported) yield return Shake128_Managed_Avx2;
        if (Shake128_Managed_Ssse3.IsSupported) yield return Shake128_Managed_Ssse3;
        yield return Shake128_Managed_Scalar;
        yield return Shake128_Bouncy;

        if (Shake256_Managed_Avx512F.IsSupported) yield return Shake256_Managed_Avx512F;
        if (Shake256_Managed_Avx2.IsSupported) yield return Shake256_Managed_Avx2;
        if (Shake256_Managed_Ssse3.IsSupported) yield return Shake256_Managed_Ssse3;
        yield return Shake256_Managed_Scalar;
        yield return Shake256_Bouncy;

        if (CShake128_Managed_Avx512F.IsSupported) yield return CShake128_Managed_Avx512F;
        if (CShake128_Managed_Avx2.IsSupported) yield return CShake128_Managed_Avx2;
        if (CShake128_Managed_Ssse3.IsSupported) yield return CShake128_Managed_Ssse3;
        yield return CShake128_Managed_Scalar;
        yield return CShake128_Bouncy;

        if (CShake256_Managed_Avx512F.IsSupported) yield return CShake256_Managed_Avx512F;
        if (CShake256_Managed_Avx2.IsSupported) yield return CShake256_Managed_Avx2;
        if (CShake256_Managed_Ssse3.IsSupported) yield return CShake256_Managed_Ssse3;
        yield return CShake256_Managed_Scalar;
        yield return CShake256_Bouncy;

        if (KT128_Managed_Avx512F.IsSupported) yield return KT128_Managed_Avx512F;
        if (KT128_Managed_Avx2.IsSupported) yield return KT128_Managed_Avx2;
        if (KT128_Managed_Ssse3.IsSupported) yield return KT128_Managed_Ssse3;
        yield return KT128_Managed_Scalar;

        if (KT256_Managed_Avx512F.IsSupported) yield return KT256_Managed_Avx512F;
        if (KT256_Managed_Avx2.IsSupported) yield return KT256_Managed_Avx2;
        if (KT256_Managed_Ssse3.IsSupported) yield return KT256_Managed_Ssse3;
        yield return KT256_Managed_Scalar;

        if (TurboShake128_Managed_Avx512F.IsSupported) yield return TurboShake128_Managed_Avx512F;
        if (TurboShake128_Managed_Avx2.IsSupported) yield return TurboShake128_Managed_Avx2;
        if (TurboShake128_Managed_Ssse3.IsSupported) yield return TurboShake128_Managed_Ssse3;
        yield return TurboShake128_Managed_Scalar;

        if (TurboShake256_Managed_Avx512F.IsSupported) yield return TurboShake256_Managed_Avx512F;
        if (TurboShake256_Managed_Avx2.IsSupported) yield return TurboShake256_Managed_Avx2;
        if (TurboShake256_Managed_Ssse3.IsSupported) yield return TurboShake256_Managed_Ssse3;
        yield return TurboShake256_Managed_Scalar;
#else
        yield return Shake128_Managed;
        yield return Shake128_Bouncy;
        yield return Shake256_Managed;
        yield return Shake256_Bouncy;
        yield return CShake128_Managed;
        yield return CShake128_Bouncy;
        yield return CShake256_Managed;
        yield return CShake256_Bouncy;
        yield return KT128_Managed;
        yield return KT256_Managed;
        yield return TurboShake128_Managed;
        yield return TurboShake256_Managed;
#endif

        // BLAKE
#if NET8_0_OR_GREATER
        // BLAKE2b variants
        if (Blake2b_Managed_Avx2.IsSupported) yield return Blake2b_Managed_Avx2;
        yield return Blake2b_Managed_Scalar;
        yield return Blake2b_Bouncy;

        // BLAKE2s variants
        if (Blake2s_Managed_Avx2.IsSupported) yield return Blake2s_Managed_Avx2;
        if (Blake2s_Managed_Sse2.IsSupported) yield return Blake2s_Managed_Sse2;
        yield return Blake2s_Managed_Scalar;
        yield return Blake2s_Bouncy;

        // BLAKE3 variants
        if (Blake3_Managed_Ssse3.IsSupported) yield return Blake3_Managed_Ssse3;
        yield return Blake3_Managed_Scalar;
        yield return Blake3_Bouncy;
#else
        yield return Blake2b_Managed;
        yield return Blake2b_Bouncy;
        yield return Blake2s_Managed;
        yield return Blake2s_Bouncy;
        yield return Blake3_Managed;
        yield return Blake3_Bouncy;
#endif
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
        yield return Streebog256_OpenGost;
        yield return Streebog512_Managed;
        yield return Streebog512_Bouncy;
        yield return Streebog512_OpenGost;

        // KMAC (OS-level - only yield if supported)
#if NET9_0_OR_GREATER
        if (Kmac128_OS.IsSupported) yield return Kmac128_OS;
        if (Kmac256_OS.IsSupported) yield return Kmac256_OS;
#endif
        yield return Kmac128_Managed;
        yield return Kmac128_Bouncy;
        yield return Kmac256_Managed;
        yield return Kmac256_Bouncy;
    }

    /// <summary>All SHA-3 family implementations for comparison, filtered to only supported algorithms.</summary>
    public static IEnumerable<HashAlgorithmType> AllSHA3()
    {
#if NET8_0_OR_GREATER
        if (SHA3_256_OS.IsSupported) yield return SHA3_256_OS;
        if (SHA3_384_OS.IsSupported) yield return SHA3_384_OS;
        if (SHA3_512_OS.IsSupported) yield return SHA3_512_OS;
        if (Shake128_OS.IsSupported) yield return Shake128_OS;
        if (Shake256_OS.IsSupported) yield return Shake256_OS;
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
        yield return CShake128_Managed;
        yield return CShake128_Bouncy;
        yield return CShake256_Managed;
        yield return CShake256_Bouncy;
        yield return KT128_Managed;
        yield return KT256_Managed;
        yield return TurboShake128_Managed;
        yield return TurboShake256_Managed;
    }

    /// <summary>All KMAC implementations for comparison, filtered to only supported algorithms.</summary>
    public static IEnumerable<HashAlgorithmType> AllKmac()
    {
#if NET9_0_OR_GREATER
        if (Kmac128_OS.IsSupported) yield return Kmac128_OS;
        if (Kmac256_OS.IsSupported) yield return Kmac256_OS;
#endif
        yield return Kmac128_Managed;
        yield return Kmac128_Bouncy;
        yield return Kmac256_Managed;
        yield return Kmac256_Bouncy;
    }

#if NET8_0_OR_GREATER
    /// <summary>All BLAKE SIMD variants for comparison benchmarks.</summary>
    public static IEnumerable<HashAlgorithmType> AllBlakeSimdVariants()
    {
        // BLAKE2b variants
        if (Blake2b_Managed_Avx2.IsSupported) yield return Blake2b_Managed_Avx2;
        yield return Blake2b_Managed_Scalar;
        yield return Blake2b_Bouncy;

        // BLAKE2s variants
        if (Blake2s_Managed_Avx2.IsSupported) yield return Blake2s_Managed_Avx2;
        if (Blake2s_Managed_Sse2.IsSupported) yield return Blake2s_Managed_Sse2;
        yield return Blake2s_Managed_Scalar;
        yield return Blake2s_Bouncy;

        // BLAKE3 variants
        if (Blake3_Managed_Ssse3.IsSupported) yield return Blake3_Managed_Ssse3;
        yield return Blake3_Managed_Scalar;
        yield return Blake3_Bouncy;
#if BLAKE3_NATIVE
        yield return Blake3_Native;
#endif
    }

    /// <summary>All Keccak-based SIMD variants for comparison benchmarks.</summary>
    public static IEnumerable<HashAlgorithmType> AllKeccakSimdVariants()
    {
        // SHA3-224 variants
        if (SHA3_224_Managed_Avx512F.IsSupported) yield return SHA3_224_Managed_Avx512F;
        if (SHA3_224_Managed_Avx2.IsSupported) yield return SHA3_224_Managed_Avx2;
        if (SHA3_224_Managed_Ssse3.IsSupported) yield return SHA3_224_Managed_Ssse3;
        yield return SHA3_224_Managed_Scalar;
        yield return SHA3_224_Bouncy;

        // SHA3-256 variants
        if (SHA3_256_Managed_Avx512F.IsSupported) yield return SHA3_256_Managed_Avx512F;
        if (SHA3_256_Managed_Avx2.IsSupported) yield return SHA3_256_Managed_Avx2;
        if (SHA3_256_Managed_Ssse3.IsSupported) yield return SHA3_256_Managed_Ssse3;
        yield return SHA3_256_Managed_Scalar;
        yield return SHA3_256_Bouncy;

        // SHA3-384 variants
        if (SHA3_384_Managed_Avx512F.IsSupported) yield return SHA3_384_Managed_Avx512F;
        if (SHA3_384_Managed_Avx2.IsSupported) yield return SHA3_384_Managed_Avx2;
        if (SHA3_384_Managed_Ssse3.IsSupported) yield return SHA3_384_Managed_Ssse3;
        yield return SHA3_384_Managed_Scalar;
        yield return SHA3_384_Bouncy;

        // SHA3-512 variants
        if (SHA3_512_Managed_Avx512F.IsSupported) yield return SHA3_512_Managed_Avx512F;
        if (SHA3_512_Managed_Avx2.IsSupported) yield return SHA3_512_Managed_Avx2;
        if (SHA3_512_Managed_Ssse3.IsSupported) yield return SHA3_512_Managed_Ssse3;
        yield return SHA3_512_Managed_Scalar;
        yield return SHA3_512_Bouncy;

        // Keccak-256 variants
        if (Keccak256_Managed_Avx512F.IsSupported) yield return Keccak256_Managed_Avx512F;
        if (Keccak256_Managed_Avx2.IsSupported) yield return Keccak256_Managed_Avx2;
        if (Keccak256_Managed_Ssse3.IsSupported) yield return Keccak256_Managed_Ssse3;
        yield return Keccak256_Managed_Scalar;
        yield return Keccak256_Bouncy;

        // SHAKE128 variants
        if (Shake128_Managed_Avx512F.IsSupported) yield return Shake128_Managed_Avx512F;
        if (Shake128_Managed_Avx2.IsSupported) yield return Shake128_Managed_Avx2;
        if (Shake128_Managed_Ssse3.IsSupported) yield return Shake128_Managed_Ssse3;
        yield return Shake128_Managed_Scalar;
        yield return Shake128_Bouncy;

        // SHAKE256 variants
        if (Shake256_Managed_Avx512F.IsSupported) yield return Shake256_Managed_Avx512F;
        if (Shake256_Managed_Avx2.IsSupported) yield return Shake256_Managed_Avx2;
        if (Shake256_Managed_Ssse3.IsSupported) yield return Shake256_Managed_Ssse3;
        yield return Shake256_Managed_Scalar;
        yield return Shake256_Bouncy;

        // cSHAKE128 variants
        if (CShake128_Managed_Avx512F.IsSupported) yield return CShake128_Managed_Avx512F;
        if (CShake128_Managed_Avx2.IsSupported) yield return CShake128_Managed_Avx2;
        if (CShake128_Managed_Ssse3.IsSupported) yield return CShake128_Managed_Ssse3;
        yield return CShake128_Managed_Scalar;
        yield return CShake128_Bouncy;

        // cSHAKE256 variants
        if (CShake256_Managed_Avx512F.IsSupported) yield return CShake256_Managed_Avx512F;
        if (CShake256_Managed_Avx2.IsSupported) yield return CShake256_Managed_Avx2;
        if (CShake256_Managed_Ssse3.IsSupported) yield return CShake256_Managed_Ssse3;
        yield return CShake256_Managed_Scalar;
        yield return CShake256_Bouncy;

        // KT128 variants
        if (KT128_Managed_Avx512F.IsSupported) yield return KT128_Managed_Avx512F;
        if (KT128_Managed_Avx2.IsSupported) yield return KT128_Managed_Avx2;
        if (KT128_Managed_Ssse3.IsSupported) yield return KT128_Managed_Ssse3;
        yield return KT128_Managed_Scalar;

        // KT256 variants
        if (KT256_Managed_Avx512F.IsSupported) yield return KT256_Managed_Avx512F;
        if (KT256_Managed_Avx2.IsSupported) yield return KT256_Managed_Avx2;
        if (KT256_Managed_Ssse3.IsSupported) yield return KT256_Managed_Ssse3;
        yield return KT256_Managed_Scalar;

        // TurboSHAKE128 variants
        if (TurboShake128_Managed_Avx512F.IsSupported) yield return TurboShake128_Managed_Avx512F;
        if (TurboShake128_Managed_Avx2.IsSupported) yield return TurboShake128_Managed_Avx2;
        if (TurboShake128_Managed_Ssse3.IsSupported) yield return TurboShake128_Managed_Ssse3;
        yield return TurboShake128_Managed_Scalar;

        // TurboSHAKE256 variants
        if (TurboShake256_Managed_Avx512F.IsSupported) yield return TurboShake256_Managed_Avx512F;
        if (TurboShake256_Managed_Avx2.IsSupported) yield return TurboShake256_Managed_Avx2;
        if (TurboShake256_Managed_Ssse3.IsSupported) yield return TurboShake256_Managed_Ssse3;
        yield return TurboShake256_Managed_Scalar;
    }
#endif

    #endregion
}


