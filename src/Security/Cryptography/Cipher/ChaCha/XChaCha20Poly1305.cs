// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// XChaCha20-Poly1305 authenticated encryption with extended nonce.
/// </summary>
/// <remarks>
/// <para>
/// XChaCha20-Poly1305 extends ChaCha20-Poly1305 with a 192-bit (24-byte) nonce,
/// providing better resistance to nonce misuse. It uses HChaCha20 to derive a subkey
/// from the key and first 16 bytes of the nonce, then uses standard ChaCha20-Poly1305
/// with the subkey and remaining 8 bytes of the nonce.
/// </para>
/// <para>
/// <b>Specification:</b> draft-irtf-cfrg-xchacha-03
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>256-bit security level</description></item>
///   <item><description>192-bit nonce (safe for random nonces)</description></item>
///   <item><description>128-bit authentication tag</description></item>
///   <item><description>Resistant to timing attacks</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Nonce generation:</b> The 24-byte nonce can be randomly generated for each
/// message. The probability of collision is negligible (2^-32 after 2^80 messages).
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aead = XChaCha20Poly1305.Create(key);
///
/// // Generate random 24-byte nonce
/// byte[] nonce = new byte[24];
/// RandomNumberGenerator.Fill(nonce);
///
/// // Encrypt with associated data
/// byte[] ciphertext = aead.Encrypt(nonce, plaintext, associatedData);
///
/// // Decrypt and verify
/// byte[] plaintext = aead.Decrypt(nonce, ciphertext, associatedData);
/// </code>
/// </para>
/// </remarks>
public sealed class XChaCha20Poly1305 : IAeadCipher
{
    /// <summary>
    /// Key size in bytes (256 bits).
    /// </summary>
    public const int KeySizeBytesConst = 32;

    /// <summary>
    /// Nonce size in bytes (192 bits = 24 bytes).
    /// </summary>
    public const int NonceSizeBytesConst = 24;

    /// <summary>
    /// Tag size in bytes (128 bits).
    /// </summary>
    public const int TagSizeBytesConst = 16;

    private readonly byte[] _key;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="XChaCha20Poly1305"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    public XChaCha20Poly1305(byte[] key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes.", nameof(key));

        _key = new byte[KeySizeBytesConst];
        Buffer.BlockCopy(key, 0, _key, 0, KeySizeBytesConst);
    }

    /// <inheritdoc/>
    public string AlgorithmName => "XChaCha20-Poly1305";

    /// <inheritdoc/>
    public int KeySizeBytes => KeySizeBytesConst;

    /// <inheritdoc/>
    public int NonceSizeBytes => NonceSizeBytesConst;

    /// <inheritdoc/>
    public int TagSizeBytes => TagSizeBytesConst;

    /// <summary>
    /// Creates a new XChaCha20-Poly1305 instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new XChaCha20-Poly1305 instance.</returns>
    public static XChaCha20Poly1305 Create(byte[] key) => new(key);

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

        // Derive subkey using HChaCha20
        Span<byte> subkey = stackalloc byte[ChaChaCore.KeySizeBytes];
        ChaChaCore.HChaCha20(_key, nonce.Slice(0, ChaChaCore.HNonceSizeBytes), subkey);

        // Construct ChaCha20 nonce: 4 zero bytes + last 8 bytes of XChaCha20 nonce
        Span<byte> chacha20Nonce = stackalloc byte[ChaChaCore.NonceSizeBytes];
        chacha20Nonce.Clear();
        nonce.Slice(ChaChaCore.HNonceSizeBytes, 8).CopyTo(chacha20Nonce.Slice(4));

        // Generate Poly1305 key using first ChaCha20 block (counter = 0)
        Span<byte> poly1305Key = stackalloc byte[ChaChaCore.BlockSizeBytes];
        ChaChaCore.Block(subkey, chacha20Nonce, 0, poly1305Key);

        // Encrypt plaintext with ChaCha20 (starting from counter = 1)
        ChaChaCore.Transform(subkey, chacha20Nonce, 1, plaintext, ciphertext);

        // Compute Poly1305 MAC over AAD and ciphertext
        Poly1305.ComputeAeadTag(poly1305Key.Slice(0, Poly1305.KeySizeBytes),
                                associatedData, ciphertext.Slice(0, plaintext.Length), tag);
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

        // Derive subkey using HChaCha20
        Span<byte> subkey = stackalloc byte[ChaChaCore.KeySizeBytes];
        ChaChaCore.HChaCha20(_key, nonce.Slice(0, ChaChaCore.HNonceSizeBytes), subkey);

        // Construct ChaCha20 nonce: 4 zero bytes + last 8 bytes of XChaCha20 nonce
        Span<byte> chacha20Nonce = stackalloc byte[ChaChaCore.NonceSizeBytes];
        chacha20Nonce.Clear();
        nonce.Slice(ChaChaCore.HNonceSizeBytes, 8).CopyTo(chacha20Nonce.Slice(4));

        // Generate Poly1305 key using first ChaCha20 block (counter = 0)
        Span<byte> poly1305Key = stackalloc byte[ChaChaCore.BlockSizeBytes];
        ChaChaCore.Block(subkey, chacha20Nonce, 0, poly1305Key);

        // Verify Poly1305 MAC
        Span<byte> computedTag = stackalloc byte[TagSizeBytesConst];
        Poly1305.ComputeAeadTag(poly1305Key.Slice(0, Poly1305.KeySizeBytes),
                                associatedData, ciphertext, computedTag);

        // Constant-time comparison
        if (!CryptoUtils.FixedTimeEquals(tag, computedTag))
        {
            plaintext.Clear();
            return false;
        }

        // Decrypt ciphertext with ChaCha20 (starting from counter = 1)
        ChaChaCore.Transform(subkey, chacha20Nonce, 1, ciphertext, plaintext);
        return true;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                          ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytesConst];
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length),
                result.AsSpan(plaintext.Length, TagSizeBytesConst), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextAndTag,
                          ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextAndTag.Length < TagSizeBytesConst)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextAndTag.Length - TagSizeBytesConst;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextAndTag.Slice(0, ciphertextLength),
                    ciphertextAndTag.Slice(ciphertextLength, TagSizeBytesConst),
                    plaintext, associatedData))
        {
            throw new CryptographicException("Authentication tag mismatch.");
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
