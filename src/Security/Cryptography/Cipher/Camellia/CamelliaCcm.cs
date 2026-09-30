// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Camellia-CCM authenticated encryption (Camellia per RFC 3713; used in IPsec by RFC 5528).
/// </summary>
public sealed class CamelliaCcm : CcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CamelliaCcm"/> class.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public CamelliaCcm(ReadOnlySpan<byte> key) : base(BlockCipher128Algorithm.Camellia, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"Camellia-{KeySizeBytes * 8}-CCM";

    /// <summary>
    /// Creates a new Camellia-CCM instance.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte Camellia key.</param>
    /// <returns>A new Camellia-CCM instance.</returns>
    public static CamelliaCcm Create(ReadOnlySpan<byte> key) => new(key);
}
