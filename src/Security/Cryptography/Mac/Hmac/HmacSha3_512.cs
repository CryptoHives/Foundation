// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Type name matches .NET convention (HMACSHA3_512)

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Computes the HMAC-SHA3-512 message authentication code.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of HMAC-SHA3-512 as defined in RFC 2104,
/// using the CryptoHives SHA3-512 implementation based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms.
/// </para>
/// <para>
/// HMAC-SHA3-512 produces a 512-bit (64-byte) authentication tag.
/// </para>
/// <para>
/// While SHA-3 already provides keyed hashing via KMAC, HMAC-SHA3 is useful for
/// protocol compatibility with systems that standardize on the HMAC construction.
/// </para>
/// </remarks>
public sealed class HmacSha3_512 : HmacCore
{
    /// <summary>
    /// The MAC output size in bits.
    /// </summary>
    public const int MacSizeBits = 512;

    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int MacSizeBytes = MacSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="HmacSha3_512"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    public HmacSha3_512(byte[] key)
        : base("HMAC-SHA3-512", SHA3_512.Create(), SHA3_512.Create(), key)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="HmacSha3_512"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA3-512 instance.</returns>
    public static HmacSha3_512 Create(byte[] key) => new(key);

    /// <summary>
    /// Computes the HMAC-SHA3-512 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 64-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var hmac = new HmacSha3_512(key);
        return hmac.ComputeHash(data);
    }
}
