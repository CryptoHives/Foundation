// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AEAD_AES_128_GCM_SIV nonce-misuse-resistant authenticated encryption (RFC 8452).
/// </summary>
public sealed class AesGcmSiv128 : AesGcmSiv
{
    /// <summary>
    /// Key size in bytes for AES-128-GCM-SIV.
    /// </summary>
    public const int KeySize = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcmSiv128"/> class.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    public AesGcmSiv128(ReadOnlySpan<byte> key) : this(AesCore.AesDefault, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcmSiv128"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 16-byte key.</param>
    internal AesGcmSiv128(SimdSupport simdSupport, ReadOnlySpan<byte> key) : base(simdSupport, RequireKeySize(key))
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128-GCM-SIV";

    /// <summary>
    /// Creates a new AES-128-GCM-SIV instance.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-GCM-SIV instance.</returns>
    public static AesGcmSiv128 Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new AES-128-GCM-SIV instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-GCM-SIV instance.</returns>
    internal static AesGcmSiv128 Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);

    private static ReadOnlySpan<byte> RequireKeySize(ReadOnlySpan<byte> key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
        return key;
    }
}
