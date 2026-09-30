// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// SEED-GCM authenticated encryption (RFC 4269).
/// </summary>
public sealed class SeedGcm : GcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SeedGcm"/> class.
    /// </summary>
    /// <param name="key">The 16-byte SEED key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public SeedGcm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SeedGcm"/> class with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16-byte SEED key.</param>
    internal SeedGcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
        : base(BlockCipher128Algorithm.Seed, simdSupport, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SEED-GCM";

    /// <summary>
    /// Creates a new SEED-GCM instance.
    /// </summary>
    /// <param name="key">The 16-byte SEED key.</param>
    /// <returns>A new SEED-GCM instance.</returns>
    public static SeedGcm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new SEED-GCM instance with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16-byte SEED key.</param>
    /// <returns>A new SEED-GCM instance.</returns>
    internal static SeedGcm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
