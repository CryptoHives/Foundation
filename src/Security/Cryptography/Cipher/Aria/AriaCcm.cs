// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// ARIA-CCM authenticated encryption (ARIA per RFC 5794, CCM per RFC 3610).
/// </summary>
public sealed class AriaCcm : CcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AriaCcm"/> class.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public AriaCcm(ReadOnlySpan<byte> key) : base(BlockCipher128Algorithm.Aria, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"ARIA-{KeySizeBytes * 8}-CCM";

    /// <summary>
    /// Creates a new ARIA-CCM instance.
    /// </summary>
    /// <param name="key">The 16, 24, or 32-byte ARIA key.</param>
    /// <returns>A new ARIA-CCM instance.</returns>
    public static AriaCcm Create(ReadOnlySpan<byte> key) => new(key);
}
