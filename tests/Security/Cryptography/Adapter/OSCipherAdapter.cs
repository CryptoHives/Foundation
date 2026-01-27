// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Adapter;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
using System.Security.Cryptography;
using OSAesGcm = System.Security.Cryptography.AesGcm;

/// <summary>
/// Wraps .NET's OS-provided AesGcm as CryptoHives <see cref="IAeadCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// Available in .NET 8.0 and later. Uses OS cryptographic primitives for
/// hardware-accelerated AES-GCM operations.
/// </para>
/// <para>
/// This adapter enables testing CryptoHives managed implementations against
/// OS implementations for validation.
/// </para>
/// </remarks>
internal sealed class OSAesGcmAdapter : IAeadCipher
{
    private readonly OSAesGcm _cipher;
    private readonly int _keySizeBytes;
    private readonly int _nonceSizeBytes;
    private readonly int _tagSizeBytes;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSAesGcmAdapter"/> class.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    /// <param name="nonceSizeBytes">Nonce size in bytes (default: 12).</param>
    /// <param name="tagSizeBytes">Tag size in bytes (default: 16).</param>
    public OSAesGcmAdapter(byte[] key, int nonceSizeBytes = 12, int tagSizeBytes = 16)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        _cipher = new OSAesGcm(key, tagSizeBytes);
        _keySizeBytes = key.Length;
        _nonceSizeBytes = nonceSizeBytes;
        _tagSizeBytes = tagSizeBytes;
    }

    /// <inheritdoc/>
    public string AlgorithmName => $"AES-{KeySizeBytes * 8}-GCM (OS)";

    /// <inheritdoc/>
    public int KeySizeBytes => _keySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => _nonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => _tagSizeBytes;

    /// <inheritdoc/>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        _cipher.Encrypt(nonce, plaintext, ciphertext, tag, associatedData);
    }

    /// <inheritdoc/>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        try
        {
            _cipher.Decrypt(nonce, ciphertext, tag, plaintext, associatedData);
            return true;
        }
        catch (CryptographicException)
        {
            // Authentication failed
            plaintext.Clear();
            return false;
        }
    }

    /// <inheritdoc/>
    public byte[] Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytes];
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length),
                result.AsSpan(plaintext.Length, TagSizeBytes), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertextWithTag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytes)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                    ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes),
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
            _cipher?.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}

#if NET9_0_OR_GREATER

/// <summary>
/// Wraps .NET's OS-provided ChaCha20Poly1305 as CryptoHives <see cref="IAeadCipher"/>.
/// </summary>
/// <remarks>
/// Available in .NET 9.0 and later.
/// </remarks>
internal sealed class OSChaCha20Poly1305Adapter : IAeadCipher
{
    private readonly System.Security.Cryptography.ChaCha20Poly1305 _cipher;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSChaCha20Poly1305Adapter"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    public OSChaCha20Poly1305Adapter(byte[] key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != 32)
            throw new ArgumentException("Key must be 32 bytes.", nameof(key));

        _cipher = new System.Security.Cryptography.ChaCha20Poly1305(key);
    }

    /// <inheritdoc/>
    public string AlgorithmName => "ChaCha20-Poly1305 (OS)";

    /// <inheritdoc/>
    public int KeySizeBytes => 32;

    /// <inheritdoc/>
    public int NonceSizeBytes => 12;

    /// <inheritdoc/>
    public int TagSizeBytes => 16;

    /// <inheritdoc/>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        _cipher.Encrypt(nonce, plaintext, ciphertext, tag, associatedData);
    }

    /// <inheritdoc/>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        try
        {
            _cipher.Decrypt(nonce, ciphertext, tag, plaintext, associatedData);
            return true;
        }
        catch (CryptographicException)
        {
            plaintext.Clear();
            return false;
        }
    }

    /// <inheritdoc/>
    public byte[] Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytes];
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length),
                result.AsSpan(plaintext.Length, TagSizeBytes), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertextWithTag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytes)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                    ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes),
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
            _cipher?.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}

#endif // NET9_0_OR_GREATER

#endif // NET8_0_OR_GREATER
