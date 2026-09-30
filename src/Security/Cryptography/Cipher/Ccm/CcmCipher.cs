// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// CCM (RFC 3610, NIST SP 800-38C) authenticated encryption over a 128-bit block cipher other than AES.
/// </summary>
/// <remarks>
/// <para>
/// The mode is the one <see cref="AesCcm"/> runs: 7–13 byte nonce, and a tag of 4–16 bytes
/// (even) chosen by the length of the tag buffer passed to the span overloads. The
/// <c>byte[]</c> overloads use a 16-byte tag.
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair.
/// </para>
/// </remarks>
public abstract class CcmCipher : IAeadCipher
{
    // CcmCore is a struct and shall not be readonly to avoid defensive copies
    private CcmCore _core;
    private readonly int _keySizeBytes;
    private bool _disposed;

    private protected CcmCipher(BlockCipher128Algorithm algorithm, ReadOnlySpan<byte> key)
    {
        _keySizeBytes = key.Length;
        _core = new CcmCore(BlockCipher128.Create(algorithm, key));
    }

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public int KeySizeBytes => _keySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => 12;

    /// <inheritdoc/>
    public int TagSizeBytes => CcmCore.MaxTagSizeBytes;

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));

        _core.Encrypt(nonce, plaintext, associatedData, ciphertext.Slice(0, plaintext.Length), tag);
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        bool success = _core.Decrypt(nonce, ciphertext, tag, associatedData, plaintext.Slice(0, ciphertext.Length));

        if (!success)
        {
            CryptographicOperations.ZeroMemory(plaintext.Slice(0, ciphertext.Length));
        }

        return success;
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
            throw new OS.CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                     ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes),
                     plaintext, associatedData))
        {
            throw new OS.CryptographicException("Authentication tag mismatch.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases resources used by this instance.
    /// </summary>
    /// <param name="disposing">True if called from <see cref="Dispose()"/>, false if from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _core.Clear();
            }

            _disposed = true;
        }
    }
}
