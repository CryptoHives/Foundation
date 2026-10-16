// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache2.0

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Kuznyechik-GCM authenticated encryption (GOST R 34.12-2015).
/// </summary>
public sealed class KuznyechikGcm : GcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KuznyechikGcm"/> class.
    /// </summary>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public KuznyechikGcm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KuznyechikGcm"/> class with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    internal KuznyechikGcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
        : base(BlockCipher128Algorithm.Kuznyechik, simdSupport, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Kuznyechik-GCM";

    /// <summary>
    /// Creates a new Kuznyechik-GCM instance.
    /// </summary>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <returns>A new Kuznyechik-GCM instance.</returns>
    public static KuznyechikGcm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new Kuznyechik-GCM instance with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <returns>A new Kuznyechik-GCM instance.</returns>
    internal static KuznyechikGcm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
