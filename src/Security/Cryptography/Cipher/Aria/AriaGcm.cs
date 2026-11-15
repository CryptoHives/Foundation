// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// ARIA-GCM authenticated encryption (ARIA per RFC 5794; used in TLS by RFC 6209).
/// </summary>
public sealed class AriaGcm : GcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AriaGcm"/> class.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public AriaGcm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AriaGcm"/> class with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    internal AriaGcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
        : base(BlockCipher128Algorithm.Aria, simdSupport, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"ARIA-{KeySizeBytes * 8}-GCM";

    /// <summary>
    /// Creates a new ARIA-GCM instance.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    /// <returns>A new ARIA-GCM instance.</returns>
    public static AriaGcm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new ARIA-GCM instance with specified SIMD support for GHASH.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use for GHASH.</param>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    /// <returns>A new ARIA-GCM instance.</returns>
    internal static AriaGcm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
