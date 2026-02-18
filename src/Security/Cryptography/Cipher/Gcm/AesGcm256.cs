// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-256-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm256 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-256-GCM.
    /// </summary>
    public const int KeySize = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm256"/> class.
    /// </summary>
    /// <param name="key">The 32-byte AES key.</param>
    public AesGcm256(byte[] key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 32-byte AES key.</param>
    internal AesGcm256(SimdSupport simdSupport, byte[] key) : base(simdSupport, key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-256-GCM";

    /// <summary>
    /// Creates a new AES-256-GCM instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-GCM instance.</returns>
    public static AesGcm256 Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new AES-256-GCM instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-GCM instance.</returns>
    internal static AesGcm256 Create(SimdSupport simdSupport, byte[] key) => new(simdSupport, key);
}
