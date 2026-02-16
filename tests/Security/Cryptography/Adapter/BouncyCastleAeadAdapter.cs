// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using BC = Org.BouncyCastle.Crypto;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Wraps a BouncyCastle AEAD cipher as a CryptoHives <see cref="IAeadCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows BouncyCastle AEAD cipher implementations (GCM, CCM, ChaCha20-Poly1305)
/// to be used interchangeably with CryptoHives implementations in tests and benchmarks.
/// </para>
/// <para>
/// On .NET 8+, uses BouncyCastle's span-based <c>ProcessBytes</c> and <c>DoFinal</c>
/// overloads so input spans are passed directly — no intermediate input copies.
/// A single reusable output buffer is still needed because BouncyCastle writes
/// ciphertext + tag contiguously, but callers provide separate spans.
/// </para>
/// <para>
/// On .NET Framework, falls back to pre-allocated reusable byte arrays.
/// The <see cref="AeadParameters"/> allocation per call is unavoidable because
/// BouncyCastle requires re-initialization after each <c>DoFinal()</c>.
/// </para>
/// </remarks>
internal sealed class BouncyCastleAeadAdapter : CH.Cipher.IAeadCipher
{
    private readonly BC.Modes.IAeadCipher _cipher;
    private readonly KeyParameter _keyParameter;
    private readonly byte[] _key;
    private readonly int _keySizeBits;
    private readonly int _tagSizeBits;
    private readonly int _nonceSizeBytes;
    private byte[] _nonceBuffer;
    private byte[] _aadBuffer;
    private byte[] _outputBuffer;
#if !NET8_0_OR_GREATER
    private byte[] _inputBuffer;
#endif
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleAeadAdapter"/> class.
    /// </summary>
    /// <param name="cipher">The BouncyCastle AEAD cipher to wrap.</param>
    /// <param name="key">The cipher key.</param>
    /// <param name="tagSizeBits">Tag size in bits (default: 128).</param>
    /// <param name="nonceSizeBytes">Nonce size in bytes (default: 12).</param>
    public BouncyCastleAeadAdapter(
        BC.Modes.IAeadCipher cipher,
        byte[] key,
        int tagSizeBits = 128,
        int nonceSizeBytes = 12)
    {
        _cipher = cipher ?? throw new ArgumentNullException(nameof(cipher));
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _keyParameter = new KeyParameter(_key);
        _keySizeBits = key.Length * 8;
        _tagSizeBits = tagSizeBits;
        _nonceSizeBytes = nonceSizeBytes;
        _nonceBuffer = new byte[nonceSizeBytes];
        _aadBuffer = Array.Empty<byte>();
        _outputBuffer = Array.Empty<byte>();
#if !NET8_0_OR_GREATER
        _inputBuffer = Array.Empty<byte>();
#endif
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

        InitCipher(true, nonce, associatedData);

        // BC writes ciphertext + tag contiguously; need combined output buffer
        int outputSize = _cipher.GetOutputSize(plaintext.Length);
        EnsureBufferSize(ref _outputBuffer, outputSize);

#if NET8_0_OR_GREATER
        int len = _cipher.ProcessBytes(plaintext, _outputBuffer);
        len += _cipher.DoFinal(_outputBuffer.AsSpan(len));
#else
        EnsureBufferSize(ref _inputBuffer, plaintext.Length);
        plaintext.CopyTo(_inputBuffer);
        int len = _cipher.ProcessBytes(_inputBuffer, 0, plaintext.Length, _outputBuffer, 0);
        len += _cipher.DoFinal(_outputBuffer, len);
#endif

        // Split into ciphertext and tag
        int ciphertextLength = plaintext.Length;
        _outputBuffer.AsSpan(0, ciphertextLength).CopyTo(ciphertext);
        _outputBuffer.AsSpan(ciphertextLength, TagSizeBytes).CopyTo(tag);
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
            InitCipher(false, nonce, associatedData);

#if NET8_0_OR_GREATER
            // Decrypt: pass ciphertext then tag via span overloads
            int outputSize = _cipher.GetOutputSize(ciphertext.Length + tag.Length);
            EnsureBufferSize(ref _outputBuffer, outputSize);

            int len = _cipher.ProcessBytes(ciphertext, _outputBuffer);
            len += _cipher.ProcessBytes(tag, _outputBuffer.AsSpan(len));
            len += _cipher.DoFinal(_outputBuffer.AsSpan(len));

            _outputBuffer.AsSpan(0, len).CopyTo(plaintext);
#else
            // Combine ciphertext and tag into reusable input buffer
            int combinedLength = ciphertext.Length + tag.Length;
            EnsureBufferSize(ref _inputBuffer, combinedLength);
            ciphertext.CopyTo(_inputBuffer);
            tag.CopyTo(_inputBuffer.AsSpan(ciphertext.Length));

            int outputSize = _cipher.GetOutputSize(combinedLength);
            EnsureBufferSize(ref _outputBuffer, outputSize);

            int len = _cipher.ProcessBytes(_inputBuffer, 0, combinedLength, _outputBuffer, 0);
            len += _cipher.DoFinal(_outputBuffer, len);

            _outputBuffer.AsSpan(0, len).CopyTo(plaintext);
#endif
            return true;
        }
        catch (InvalidCipherTextException)
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
            _cipher.Reset();
            Array.Clear(_key, 0, _key.Length);
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }

    private void InitCipher(bool forEncryption, ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> associatedData)
    {
        EnsureBufferSize(ref _nonceBuffer, nonce.Length);
        nonce.CopyTo(_nonceBuffer);

        byte[]? aadArray = null;
        if (associatedData.Length > 0)
        {
            EnsureBufferSize(ref _aadBuffer, associatedData.Length);
            associatedData.CopyTo(_aadBuffer);
            aadArray = _aadBuffer;
        }

        var parameters = new AeadParameters(_keyParameter, _tagSizeBits, _nonceBuffer, aadArray);
        _cipher.Init(forEncryption, parameters);
    }

    private static void EnsureBufferSize(ref byte[] buffer, int requiredSize)
    {
        if (buffer.Length < requiredSize)
            buffer = new byte[requiredSize];
    }
}
