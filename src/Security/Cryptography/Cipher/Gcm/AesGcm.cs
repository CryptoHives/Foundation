// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
#endif

/// <summary>
/// AES-GCM (Galois/Counter Mode) authenticated encryption implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-GCM provides authenticated encryption with associated data (AEAD).
/// It is widely used in TLS 1.3, IPsec, and other security protocols.
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>Confidentiality via AES-CTR mode</description></item>
///   <item><description>Authenticity via GHASH universal hash</description></item>
///   <item><description>Support for additional authenticated data (AAD)</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique nonce. For random nonces, 96-bit (12-byte) nonces are recommended.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aesGcm = AesGcm256.Create(key);
///
/// // Encrypt
/// byte[] ciphertext = aesGcm.Encrypt(nonce, plaintext, associatedData);
///
/// // Decrypt
/// byte[] plaintext = aesGcm.Decrypt(nonce, ciphertext, associatedData);
/// </code>
/// </para>
/// </remarks>
public abstract class AesGcm : IAeadCipher
{
    // GcmCore is a struct and shall not be readonly to avoid defensive copies
    private GcmCore _gcmCore;
    private readonly int _keySizeBytes;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm"/> class.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    protected AesGcm(ReadOnlySpan<byte> key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    internal AesGcm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(key));

        _keySizeBytes = key.Length;
        _gcmCore = new GcmCore(simdSupport, key);
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES-GCM on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => GcmCore.SimdSupport;

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public int KeySizeBytes => _keySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => GcmCore.NonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => GcmCore.TagSizeBytes;

    /// <inheritdoc/>
    public void Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext, Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException("Tag buffer too small.", nameof(tag));

        // Compute J0 (initial counter block)
        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.ComputeJ0(nonce, j0);

        // Compute initial counter for encryption (J0 + 1)
        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GEncryptDispatch(icb, associatedData, plaintext, ciphertext, ghash);

        // Compute tag: T = GCTR(J0, GHASH(H, A, C))
        Span<byte> fullTag = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GctrDispatch(j0, ghash, fullTag);

        // Copy tag to output (truncate if necessary)
        fullTag.Slice(0, tag.Length).CopyTo(tag);
    }

    /// <inheritdoc/>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag, Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (tag.Length != TagSizeBytes)
            throw new ArgumentException($"Tag must be {TagSizeBytes} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        // Compute J0
        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.ComputeJ0(nonce, j0);

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

        _gcmCore.GDecryptDispatch(icb, associatedData, ciphertext, plaintext, ghash);

        Span<byte> expectedTag = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GctrDispatch(j0, ghash, expectedTag);

        if (!CryptoUtils.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length)))
        {
            plaintext.Slice(0, ciphertext.Length).Clear();
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytes];
        Span<byte> ciphertext = result.AsSpan(0, plaintext.Length);
        Span<byte> tag = result.AsSpan(plaintext.Length, TagSizeBytes);

        Encrypt(nonce, plaintext, ciphertext, tag, associatedData);

        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytes)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        ReadOnlySpan<byte> ciphertext = ciphertextWithTag.Slice(0, ciphertextLength);
        ReadOnlySpan<byte> tag = ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes);

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
                _gcmCore = default;
            }

            _disposed = true;
        }
    }

    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = 15; i >= 12; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }

}
