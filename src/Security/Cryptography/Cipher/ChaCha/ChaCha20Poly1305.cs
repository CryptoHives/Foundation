// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// ChaCha20-Poly1305 authenticated encryption as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// ChaCha20-Poly1305 is an AEAD construction that combines ChaCha20 stream cipher
/// with Poly1305 message authentication code. It is widely used in TLS 1.3,
/// WireGuard, and other modern protocols.
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>256-bit security level</description></item>
///   <item><description>128-bit authentication tag</description></item>
///   <item><description>Resistant to timing attacks</description></item>
///   <item><description>High performance on all platforms</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique 96-bit (12-byte) nonce.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aead = ChaCha20Poly1305.Create(key);
///
/// // Encrypt with associated data
/// byte[] ciphertext = aead.Encrypt(nonce, plaintext, associatedData);
///
/// // Decrypt and verify
/// byte[] plaintext = aead.Decrypt(nonce, ciphertext, associatedData);
/// </code>
/// </para>
/// </remarks>
public sealed class ChaCha20Poly1305 : IAeadCipher
{
    /// <summary>
    /// Key size in bytes (256 bits).
    /// </summary>
    public const int KeySizeBytesConst = 32;

    /// <summary>
    /// Nonce size in bytes (96 bits).
    /// </summary>
    public const int NonceSizeBytesConst = 12;

    /// <summary>
    /// Tag size in bytes (128 bits).
    /// </summary>
    public const int TagSizeBytesConst = 16;

    private readonly byte[] _key;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChaCha20Poly1305"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    public ChaCha20Poly1305(byte[] key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes.", nameof(key));

        _key = new byte[KeySizeBytesConst];
        Buffer.BlockCopy(key, 0, _key, 0, KeySizeBytesConst);
    }

    /// <inheritdoc/>
    public string AlgorithmName => "ChaCha20-Poly1305";

    /// <inheritdoc/>
    public int KeySizeBytes => KeySizeBytesConst;

    /// <inheritdoc/>
    public int NonceSizeBytes => NonceSizeBytesConst;

    /// <inheritdoc/>
    public int TagSizeBytes => TagSizeBytesConst;

    /// <summary>
    /// Creates a new ChaCha20-Poly1305 instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new ChaCha20-Poly1305 instance.</returns>
    public static ChaCha20Poly1305 Create(byte[] key) => new(key);

    /// <inheritdoc/>
    public void Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                        Span<byte> ciphertext, Span<byte> tag,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length != NonceSizeBytesConst)
            throw new ArgumentException($"Nonce must be {NonceSizeBytesConst} bytes.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytesConst)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytesConst} bytes.", nameof(tag));

        // Generate Poly1305 key using ChaCha20 with counter = 0
        Span<byte> polyKey = stackalloc byte[64];
        ChaChaCore.Block(_key, nonce, 0, polyKey);

        // Encrypt plaintext using ChaCha20 with counter = 1
        ChaChaCore.Transform(_key, nonce, 1, plaintext, ciphertext);

        // Compute Poly1305 tag over (AAD || pad || ciphertext || pad || lengths)
        Poly1305.ComputeAeadTag(polyKey.Slice(0, 32), associatedData,
                                 ciphertext.Slice(0, plaintext.Length), tag);
    }

    /// <inheritdoc/>
    public bool Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
                        ReadOnlySpan<byte> tag, Span<byte> plaintext,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length != NonceSizeBytesConst)
            throw new ArgumentException($"Nonce must be {NonceSizeBytesConst} bytes.", nameof(nonce));
        if (tag.Length != TagSizeBytesConst)
            throw new ArgumentException($"Tag must be {TagSizeBytesConst} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        // Generate Poly1305 key
        Span<byte> polyKey = stackalloc byte[64];
        ChaChaCore.Block(_key, nonce, 0, polyKey);

        // Compute expected tag
        Span<byte> expectedTag = stackalloc byte[TagSizeBytesConst];
        Poly1305.ComputeAeadTag(polyKey.Slice(0, 32), associatedData, ciphertext, expectedTag);

        // Verify tag in constant time
        if (!CryptoUtils.FixedTimeEquals(tag, expectedTag))
        {
            plaintext.Slice(0, ciphertext.Length).Clear();
            return false;
        }

        // Decrypt ciphertext
        ChaChaCore.Transform(_key, nonce, 1, ciphertext, plaintext);

        return true;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                          ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytesConst];
        Span<byte> ciphertext = result.AsSpan(0, plaintext.Length);
        Span<byte> tag = result.AsSpan(plaintext.Length, TagSizeBytesConst);

        Encrypt(nonce, plaintext, ciphertext, tag, associatedData);

        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
                          ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytesConst)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytesConst;
        ReadOnlySpan<byte> ciphertext = ciphertextWithTag.Slice(0, ciphertextLength);
        ReadOnlySpan<byte> tag = ciphertextWithTag.Slice(ciphertextLength, TagSizeBytesConst);

        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertext, tag, plaintext, associatedData))
        {
            throw new CryptographicException("Authentication failed.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_key, 0, _key.Length);
            _disposed = true;
        }
    }
}
