// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;

/// <summary>
/// Computes AES-GMAC (Galois Message Authentication Code) as defined in
/// NIST SP 800-38D, Section 4.
/// </summary>
/// <remarks>
/// <para>
/// GMAC is a special case of GCM where the plaintext is empty. It produces
/// a 128-bit (16-byte) authentication tag over the associated data (AAD).
/// </para>
/// <para>
/// This implementation wraps the CryptoHives AES-GCM implementation, benefiting
/// from its hardware-accelerated AES-NI and PCLMULQDQ GHASH when available.
/// </para>
/// <para>
/// <b>Important:</b> GMAC requires a unique nonce for every invocation with the same key.
/// Nonce reuse completely compromises authenticity. The nonce is 12 bytes (96 bits).
/// </para>
/// </remarks>
/// <example>
/// <code>
/// byte[] key = new byte[16]; // AES-128 key
/// byte[] nonce = new byte[12]; // unique 96-bit nonce
/// byte[] data = Encoding.UTF8.GetBytes("authenticated data");
///
/// using var gmac = AesGmac.Create(key);
/// byte[] tag = gmac.ComputeTag(nonce, data);
/// </code>
/// </example>
public sealed class AesGmac : IDisposable
{
    /// <summary>
    /// The MAC output size in bytes.
    /// </summary>
    public const int TagSizeBytes = 16;

    /// <summary>
    /// The required nonce size in bytes.
    /// </summary>
    public const int NonceSizeBytes = 12;

    private readonly AesGcm _gcm;
    private bool _disposed;

    /// <summary>
    /// Gets the name of the MAC algorithm.
    /// </summary>
    public string AlgorithmName => "AES-GMAC";

    /// <summary>
    /// Gets the MAC output size in bytes.
    /// </summary>
    public int MacSize => TagSizeBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGmac"/> class.
    /// </summary>
    /// <param name="key">The secret key. Must be 16, 24, or 32 bytes.</param>
    /// <exception cref="ArgumentException">The key length is invalid.</exception>
    public AesGmac(ReadOnlySpan<byte> key)
    {
        _gcm = key.Length switch {
            16 => new AesGcm128(key),
            24 => new AesGcm192(key),
            32 => new AesGcm256(key),
            _ => throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(key))
        };
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AesGmac"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new AES-GMAC instance.</returns>
    public static AesGmac Create(byte[] key) => new(key);

    /// <summary>
    /// Creates a new instance of the <see cref="AesGmac"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new AES-GMAC instance.</returns>
    public static AesGmac Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Computes the GMAC authentication tag for the specified nonce and data.
    /// </summary>
    /// <param name="nonce">The 12-byte nonce. Must be unique per invocation.</param>
    /// <param name="associatedData">The data to authenticate.</param>
    /// <returns>The 16-byte authentication tag.</returns>
    /// <exception cref="ArgumentException"><paramref name="nonce"/> is not 12 bytes.</exception>
    public byte[] ComputeTag(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> associatedData)
    {
        byte[] tag = new byte[TagSizeBytes];
        ComputeTag(nonce, associatedData, tag);
        return tag;
    }

    /// <summary>
    /// Computes the GMAC authentication tag for the specified nonce and data.
    /// </summary>
    /// <param name="nonce">The 12-byte nonce. Must be unique per invocation.</param>
    /// <param name="associatedData">The data to authenticate.</param>
    /// <param name="tag">The buffer to receive the 16-byte authentication tag.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="nonce"/> is not 12 bytes, or <paramref name="tag"/> is too small.
    /// </exception>
    public void ComputeTag(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> associatedData, Span<byte> tag)
    {
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytes} bytes.", nameof(tag));

        // GMAC = AES-GCM with empty plaintext
        _gcm.Encrypt(nonce, [], [], tag.Slice(0, TagSizeBytes), associatedData);
    }

    /// <summary>
    /// Verifies a GMAC authentication tag.
    /// </summary>
    /// <param name="nonce">The 12-byte nonce used to produce the tag.</param>
    /// <param name="associatedData">The data to verify.</param>
    /// <param name="expectedTag">The expected authentication tag.</param>
    /// <returns>True if the tag is valid; otherwise false.</returns>
    public bool VerifyTag(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> associatedData, ReadOnlySpan<byte> expectedTag)
    {
        Span<byte> computedTag = stackalloc byte[TagSizeBytes];
        ComputeTag(nonce, associatedData, computedTag);

        return CryptographicEquals(computedTag, expectedTag);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            _gcm.Dispose();
            _disposed = true;
        }
    }

    /// <summary>
    /// Constant-time comparison to prevent timing attacks.
    /// </summary>
    private static bool CryptographicEquals(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
    {
        if (a.Length != b.Length) return false;

        int diff = 0;
        for (int i = 0; i < a.Length; i++)
        {
            diff |= a[i] ^ b[i];
        }

        return diff == 0;
    }
}
