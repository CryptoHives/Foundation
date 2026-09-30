// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AEAD_AES_256_GCM_SIV nonce-misuse-resistant authenticated encryption (RFC 8452).
/// </summary>
public sealed class AesGcmSiv256 : AesGcmSiv
{
    /// <summary>
    /// Key size in bytes for AES-256-GCM-SIV.
    /// </summary>
    public const int KeySize = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcmSiv256"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    public AesGcmSiv256(ReadOnlySpan<byte> key) : this(AesCore.AesDefault, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcmSiv256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 32-byte key.</param>
    internal AesGcmSiv256(SimdSupport simdSupport, ReadOnlySpan<byte> key) : base(simdSupport, RequireKeySize(key))
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-256-GCM-SIV";

    /// <summary>
    /// Creates a new AES-256-GCM-SIV instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-GCM-SIV instance.</returns>
    public static AesGcmSiv256 Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new AES-256-GCM-SIV instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-GCM-SIV instance.</returns>
    internal static AesGcmSiv256 Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);

    private static ReadOnlySpan<byte> RequireKeySize(ReadOnlySpan<byte> key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
        return key;
    }
}
