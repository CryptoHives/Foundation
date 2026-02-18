// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Cipher;

using System;
using CH = CryptoHives.Foundation.Security.Cryptography;
using NC = NaCl.Core;

/// <summary>
/// Wraps a NaCl.Core AEAD cipher as a CryptoHives <see cref="CH.Cipher.IAeadCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// NaCl.Core provides managed ChaCha20-Poly1305 and XChaCha20-Poly1305 implementations.
/// This adapter bridges the NaCl.Core <see cref="NCBase.SnufflePoly1305"/> API to the
/// CryptoHives <see cref="CH.Cipher.IAeadCipher"/> interface for cross-validation
/// and benchmark comparison.
/// </para>
/// <para>
/// NaCl.Core already uses span-based APIs, so no intermediate copies are needed.
/// A new <see cref="NCBase.SnufflePoly1305"/> instance is created per call because
/// NaCl.Core does not expose a re-keying or reset mechanism.
/// </para>
/// </remarks>
internal sealed class NaClCoreAeadAdapter : CH.Cipher.IAeadCipher
{
    private readonly byte[] _key;
    private readonly int _nonceSizeBytes;
    private readonly string _algorithmName;
    private readonly NC.Base.SnufflePoly1305 _aead;
    private readonly bool _isXChaCha;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="NaClCoreAeadAdapter"/> class.
    /// </summary>
    /// <param name="key">The cipher key (32 bytes).</param>
    /// <param name="useXChaCha">True for XChaCha20-Poly1305 (24-byte nonce), false for ChaCha20-Poly1305 (12-byte nonce).</param>
    public NaClCoreAeadAdapter(byte[] key, bool useXChaCha)
    {
        _key = (byte[])key.Clone();
        _isXChaCha = useXChaCha;
        _nonceSizeBytes = useXChaCha ? 24 : 12;
        _algorithmName = useXChaCha ? "XChaCha20-Poly1305" : "ChaCha20-Poly1305";
        _aead = CreateCipher();
    }

    /// <inheritdoc/>
    public string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public int KeySizeBytes => _key.Length;

    /// <inheritdoc/>
    public int NonceSizeBytes => _nonceSizeBytes;

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
        _aead.Encrypt(nonce, plaintext, ciphertext, tag, associatedData);
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
            _aead.Decrypt(nonce, ciphertext, tag, plaintext, associatedData);
            return true;
        }
        catch (System.Security.Cryptography.CryptographicException)
        {
            plaintext.Slice(0, ciphertext.Length).Clear();
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
            throw new System.Security.Cryptography.CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                    ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes),
                    plaintext, associatedData))
        {
            throw new System.Security.Cryptography.CryptographicException("Authentication tag mismatch.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_key, 0, _key.Length);
            _aead.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }

    private NC.Base.SnufflePoly1305 CreateCipher() => _isXChaCha
        ? new NC.XChaCha20Poly1305(_key)
        : new NC.ChaCha20Poly1305(_key);
}
