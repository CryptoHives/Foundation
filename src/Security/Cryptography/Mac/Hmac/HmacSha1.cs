// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Computes the HMAC-SHA-1 message authentication code.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of HMAC-SHA-1 as defined in RFC 2104,
/// using the CryptoHives SHA-1 implementation. It does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// HMAC-SHA-1 produces a 160-bit (20-byte) authentication tag.
/// </para>
/// <para>
/// <b>Security warning:</b> SHA-1 is considered weak for collision resistance.
/// While HMAC-SHA-1 remains secure for authentication, prefer HMAC-SHA-256 or
/// stronger variants for new applications.
/// </para>
/// </remarks>
[Obsolete("HMAC-SHA-1 is provided for legacy compatibility. Prefer HmacSha256 or stronger.")]
public sealed class HmacSha1 : HmacCore
{
    /// <summary>
    /// The MAC output size in bits.
    /// </summary>
    public const int MacSizeBits = 160;

    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int MacSizeBytes = MacSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="HmacSha1"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
#pragma warning disable CS0618 // SHA1 obsolete warning - intentionally supported for legacy compatibility
    public HmacSha1(byte[] key)
        : base("HMAC-SHA1", SHA1.Create(), SHA1.Create(), key)
    {
    }
#pragma warning restore CS0618

    /// <summary>
    /// Creates a new instance of the <see cref="HmacSha1"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA-1 instance.</returns>
    public static HmacSha1 Create(byte[] key) => new(key);

    /// <summary>
    /// Computes the HMAC-SHA-1 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 20-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var hmac = new HmacSha1(key);
        return hmac.ComputeHash(data);
    }
}
