// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Camellia-GCM authenticated encryption (Camellia per RFC 3713; used in TLS by RFC 6367).
/// </summary>
public sealed class CamelliaGcm : GcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CamelliaGcm"/> class.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public CamelliaGcm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CamelliaGcm"/> class with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    internal CamelliaGcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
        : base(BlockCipher128Algorithm.Camellia, simdSupport, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"Camellia-{KeySizeBytes * 8}-GCM";

    /// <summary>
    /// Creates a new Camellia-GCM instance.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    /// <returns>A new Camellia-GCM instance.</returns>
    public static CamelliaGcm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new Camellia-GCM instance with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    /// <returns>A new Camellia-GCM instance.</returns>
    internal static CamelliaGcm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
