// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using BCCipher = Org.BouncyCastle.Crypto.Modes.IAeadCipher;
using CHCipher = CryptoHives.Foundation.Security.Cryptography.Cipher.IAeadCipher;

/// <summary>
/// Wraps a BouncyCastle AEAD cipher as a CryptoHives <see cref="IAeadCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows BouncyCastle AEAD cipher implementations (GCM, CCM, ChaCha20-Poly1305)
/// to be used interchangeably with CryptoHives implementations in tests and benchmarks.
/// </para>
/// <para>
/// Supports: GcmBlockCipher, CcmBlockCipher, ChaCha20Poly1305.
/// </para>
/// </remarks>
internal sealed class BouncyCastleAeadAdapter : CHCipher
{
    private readonly BCCipher _cipher;
    private readonly byte[] _key;
    private readonly int _keySizeBits;
    private readonly int _tagSizeBits;
    private readonly int _nonceSizeBytes;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleAeadAdapter"/> class.
    /// </summary>
    /// <param name="cipher">The BouncyCastle AEAD cipher to wrap.</param>
    /// <param name="key">The cipher key.</param>
    /// <param name="tagSizeBits">Tag size in bits (default: 128).</param>
    /// <param name="nonceSizeBytes">Nonce size in bytes (default: 12).</param>
    public BouncyCastleAeadAdapter(
        BCCipher cipher,
        byte[] key,
        int tagSizeBits = 128,
        int nonceSizeBytes = 12)
    {
        _cipher = cipher ?? throw new ArgumentNullException(nameof(cipher));
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _keySizeBits = key.Length * 8;
        _tagSizeBits = tagSizeBits;
        _nonceSizeBytes = nonceSizeBytes;
    }

    /// <inheritdoc/>
    public string AlgorithmName => _cipher.AlgorithmName;

    /// <inheritdoc/>
    public int KeySizeBytes => _key.Length;

    /// <inheritdoc/>
    public int NonceSizeBytes => _nonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => _tagSizeBits / 8;

    /// <inheritdoc/>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException("Tag buffer too small.", nameof(tag));

        // Initialize for encryption
        var parameters = new AeadParameters(
            new KeyParameter(_key),
            _tagSizeBits,
            nonce.ToArray(),
            associatedData.Length > 0 ? associatedData.ToArray() : null);

        _cipher.Init(true, parameters);

        // Encrypt and get ciphertext + tag
        byte[] output = new byte[_cipher.GetOutputSize(plaintext.Length)];
        int len = _cipher.ProcessBytes(plaintext.ToArray(), 0, plaintext.Length, output, 0);
        len += _cipher.DoFinal(output, len);

        // Split into ciphertext and tag
        int ciphertextLength = plaintext.Length;
        output.AsSpan(0, ciphertextLength).CopyTo(ciphertext);
        output.AsSpan(ciphertextLength, TagSizeBytes).CopyTo(tag);
    }

    /// <inheritdoc/>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        try
        {
            // Initialize for decryption
            var parameters = new AeadParameters(
                new KeyParameter(_key),
                _tagSizeBits,
                nonce.ToArray(),
                associatedData.Length > 0 ? associatedData.ToArray() : null);

            _cipher.Init(false, parameters);

            // Combine ciphertext and tag for BC
            byte[] input = new byte[ciphertext.Length + tag.Length];
            ciphertext.CopyTo(input.AsSpan(0, ciphertext.Length));
            tag.CopyTo(input.AsSpan(ciphertext.Length, tag.Length));

            // Decrypt and verify
            byte[] output = new byte[_cipher.GetOutputSize(input.Length)];
            int len = _cipher.ProcessBytes(input, 0, input.Length, output, 0);
            len += _cipher.DoFinal(output, len);

            // Copy to plaintext
            output.AsSpan(0, len).CopyTo(plaintext);
            return true;
        }
        catch (InvalidCipherTextException)
        {
            // Authentication failed
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
            _cipher.Reset();
            Array.Clear(_key, 0, _key.Length);
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}
