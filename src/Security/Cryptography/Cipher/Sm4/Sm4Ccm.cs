// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// SM4-CCM authenticated encryption (SM4 per GB/T 32907-2016; the TLS 1.3 suite TLS_SM4_CCM_SM3 of RFC 8998).
/// </summary>
public sealed class Sm4Ccm : CcmCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4Ccm"/> class.
    /// </summary>
    /// <param name="key">The 16-byte SM4 key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public Sm4Ccm(ReadOnlySpan<byte> key) : base(BlockCipher128Algorithm.Sm4, key)
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SM4-CCM";

    /// <summary>
    /// Creates a new SM4-CCM instance.
    /// </summary>
    /// <param name="key">The 16-byte SM4 key.</param>
    /// <returns>A new SM4-CCM instance.</returns>
    public static Sm4Ccm Create(ReadOnlySpan<byte> key) => new(key);
}
