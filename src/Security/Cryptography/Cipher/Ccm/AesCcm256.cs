// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-256-CCM authenticated encryption.
/// </summary>
/// <remarks>
/// AES-256-CCM uses a 256-bit (32-byte) key with CCM mode for authenticated encryption.
/// </remarks>
public sealed class AesCcm256 : AesCcm
{
    /// <summary>
    /// Key size in bytes for AES-256.
    /// </summary>
    public const int KeySizeBytesConst = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm256"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    public AesCcm256(ReadOnlySpan<byte> key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 32-byte key.</param>
    internal AesCcm256(SimdSupport simdSupport, ReadOnlySpan<byte> key) : base(simdSupport, key)
    {
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes for AES-256.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-256-CCM";

    /// <inheritdoc/>
    public override int KeySizeBytes => KeySizeBytesConst;

    /// <summary>
    /// Creates a new AES-256-CCM instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-CCM instance.</returns>
    public static AesCcm256 Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new AES-256-CCM instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-CCM instance.</returns>
    internal static AesCcm256 Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
