// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-192-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm192 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-192-GCM.
    /// </summary>
    public const int KeySize = 24;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm192"/> class.
    /// </summary>
    /// <param name="key">The 24-byte AES key.</param>
    public AesGcm192(ReadOnlySpan<byte> key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm192"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 24-byte AES key.</param>
    internal AesGcm192(SimdSupport simdSupport, ReadOnlySpan<byte> key) : base(simdSupport, key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-192-GCM";

    /// <summary>
    /// Creates a new AES-192-GCM instance.
    /// </summary>
    /// <param name="key">The 24-byte key.</param>
    /// <returns>A new AES-192-GCM instance.</returns>
    public static AesGcm192 Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new AES-192-GCM instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 24-byte key.</param>
    /// <returns>A new AES-192-GCM instance.</returns>
    internal static AesGcm192 Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);
}
