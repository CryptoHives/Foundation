// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Computes the HMAC-SHA-512 message authentication code.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of HMAC-SHA-512 as defined in RFC 2104,
/// using the CryptoHives SHA-512 implementation. It does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// HMAC-SHA-512 produces a 512-bit (64-byte) authentication tag.
/// </para>
/// </remarks>
public sealed class HmacSha512 : HmacCore
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
    /// Initializes a new instance of the <see cref="HmacSha512"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    public HmacSha512(byte[] key)
        : base("HMAC-SHA512", SHA512.Create(), SHA512.Create(), key)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="HmacSha512"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA-512 instance.</returns>
    public static HmacSha512 Create(byte[] key) => new(key);

    /// <summary>
    /// Computes the HMAC-SHA-512 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 64-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var hmac = new HmacSha512(key);
        return hmac.ComputeHash(data);
    }
}
