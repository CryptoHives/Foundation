// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// SM4-GCM authenticated encryption (SM4 per GB/T 32907-2016; the TLS 1.3 suite TLS_SM4_GCM_SM3 of RFC 8998).
/// </summary>
public sealed class Sm4Gcm : GcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4Gcm"/> class.
    /// </summary>
    /// <param name="key">The 16-byte SM4 key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public Sm4Gcm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4Gcm"/> class with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16-byte SM4 key.</param>
    internal Sm4Gcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
        : base(BlockCipher128Algorithm.Sm4, simdSupport, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SM4-GCM";

    /// <summary>
    /// Creates a new SM4-GCM instance.
    /// </summary>
    /// <param name="key">The 16-byte SM4 key.</param>
    /// <returns>A new SM4-GCM instance.</returns>
    public static Sm4Gcm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new SM4-GCM instance with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16-byte SM4 key.</param>
    /// <returns>A new SM4-GCM instance.</returns>
    internal static Sm4Gcm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
