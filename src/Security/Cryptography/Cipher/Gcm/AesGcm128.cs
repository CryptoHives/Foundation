// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-128-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm128 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-128-GCM.
    /// </summary>
    public const int KeySize = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm128"/> class.
    /// </summary>
    /// <param name="key">The 16-byte AES key.</param>
    public AesGcm128(byte[] key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm128"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 16-byte AES key.</param>
    internal AesGcm128(SimdSupport simdSupport, byte[] key) : base(simdSupport, key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128-GCM";

    /// <summary>
    /// Creates a new AES-128-GCM instance.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-GCM instance.</returns>
    public static AesGcm128 Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new AES-128-GCM instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-GCM instance.</returns>
    internal static AesGcm128 Create(SimdSupport simdSupport, byte[] key) => new(simdSupport, key);
}

