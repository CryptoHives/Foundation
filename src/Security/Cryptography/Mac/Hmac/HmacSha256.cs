// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Computes the HMAC-SHA-256 message authentication code.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of HMAC-SHA-256 as defined in RFC 2104,
/// using the CryptoHives SHA-256 implementation. It does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// HMAC-SHA-256 produces a 256-bit (32-byte) authentication tag.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// byte[] key = new byte[32]; // your secret key
/// byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
///
/// using var hmac = HmacSha256.Create(key);
/// byte[] tag = hmac.ComputeHash(data);
/// </code>
/// </example>
public sealed class HmacSha256 : HmacCore
{
    /// <summary>
    /// The MAC output size in bits.
    /// </summary>
    public const int MacSizeBits = 256;

    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int MacSizeBytes = MacSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="HmacSha256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    public HmacSha256(byte[] key)
        : base("HMAC-SHA256", SHA256.Create(), SHA256.Create(), key)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="HmacSha256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA-256 instance.</returns>
    public static HmacSha256 Create(byte[] key) => new(key);

    /// <summary>
    /// Computes the HMAC-SHA-256 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 32-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var hmac = new HmacSha256(key);
        return hmac.ComputeHash(data);
    }
}
