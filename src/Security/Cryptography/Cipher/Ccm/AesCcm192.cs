// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// AES-192-CCM authenticated encryption.
/// </summary>
/// <remarks>
/// AES-192-CCM uses a 192-bit (24-byte) key with CCM mode for authenticated encryption.
/// </remarks>
public sealed class AesCcm192 : AesCcm
{
    /// <summary>
    /// Key size in bytes for AES-192.
    /// </summary>
    public const int KeySizeBytesConst = 24;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm192"/> class.
    /// </summary>
    /// <param name="key">The 24-byte key.</param>
    public AesCcm192(byte[] key) : base(key)
    {
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes for AES-192.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-192-CCM";

    /// <inheritdoc/>
    public override int KeySizeBytes => KeySizeBytesConst;

    /// <summary>
    /// Creates a new AES-192-CCM instance.
    /// </summary>
    /// <param name="key">The 24-byte key.</param>
    /// <returns>A new AES-192-CCM instance.</returns>
    public static AesCcm192 Create(byte[] key) => new(key);
}
