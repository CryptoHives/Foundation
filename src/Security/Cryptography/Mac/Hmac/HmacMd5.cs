// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Computes the HMAC-MD5 message authentication code.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of HMAC-MD5 as defined in RFC 2104,
/// using the CryptoHives MD5 implementation. It does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// HMAC-MD5 produces a 128-bit (16-byte) authentication tag.
/// </para>
/// <para>
/// <b>Security warning:</b> MD5 is considered cryptographically broken.
/// While HMAC-MD5 is still considered secure for authentication in some contexts,
/// prefer HMAC-SHA-256 or stronger variants for new applications.
/// </para>
/// </remarks>
[Obsolete("HMAC-MD5 is provided for legacy compatibility. Prefer HmacSha256 or stronger.")]
public sealed class HmacMd5 : HmacCore
{
    /// <summary>
    /// The MAC output size in bits.
    /// </summary>
    public const int MacSizeBits = 128;

    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int MacSizeBytes = MacSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="HmacMd5"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
#pragma warning disable CS0618 // MD5 obsolete warning - intentionally supported for legacy compatibility
    public HmacMd5(byte[] key)
        : base("HMAC-MD5", MD5.Create(), MD5.Create(), key)
    {
    }
#pragma warning restore CS0618

    /// <summary>
    /// Creates a new instance of the <see cref="HmacMd5"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-MD5 instance.</returns>
    public static HmacMd5 Create(byte[] key) => new(key);

    /// <summary>
    /// Computes the HMAC-MD5 tag for the specified key and data in a single operation.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The 16-byte MAC tag.</returns>
    public static byte[] Hash(byte[] key, byte[] data)
    {
        using var hmac = new HmacMd5(key);
        return hmac.ComputeHash(data);
    }
}
