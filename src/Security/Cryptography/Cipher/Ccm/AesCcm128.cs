// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-128-CCM authenticated encryption.
/// </summary>
/// <remarks>
/// AES-128-CCM uses a 128-bit (16-byte) key with CCM mode for authenticated encryption.
/// </remarks>
public sealed class AesCcm128 : AesCcm
{
    /// <summary>
    /// Key size in bytes for AES-128.
    /// </summary>
    public const int KeySizeBytesConst = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm128"/> class.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    public AesCcm128(byte[] key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm128"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 16-byte key.</param>
    internal AesCcm128(SimdSupport simdSupport, byte[] key) : base(simdSupport, key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes for AES-128.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128-CCM";

    /// <inheritdoc/>
    public override int KeySizeBytes => KeySizeBytesConst;

    /// <summary>
    /// Creates a new AES-128-CCM instance.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-CCM instance.</returns>
    public static AesCcm128 Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new AES-128-CCM instance with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-CCM instance.</returns>
    internal static AesCcm128 Create(SimdSupport simdSupport, byte[] key) => new(simdSupport, key);
}
