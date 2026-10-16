// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// GCM (NIST SP 800-38D) authenticated encryption over a 128-bit block cipher other than AES.
/// </summary>
/// <remarks>
/// <para>
/// The mode is the one <see cref="AesGcm"/> runs: 16-byte tag, 12-byte nonce recommended, any
/// non-empty nonce accepted. GHASH uses carry-less multiply hardware where available; the block
/// cipher itself runs its managed implementation.
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. For random nonces, use 12 bytes.
/// </para>
/// </remarks>
public abstract class GcmCipher : IAeadCipher
{
    // GcmCore is a struct and shall not be readonly to avoid defensive copies
    private GcmCore _gcmCore;
    private readonly int _keySizeBytes;
    private bool _disposed;

    private protected GcmCipher(BlockCipher128Algorithm algorithm, SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        _keySizeBytes = key.Length;
        _gcmCore = new GcmCore(simdSupport, BlockCipher128.Create(algorithm, key));
    }

    /// <summary>
    /// Gets the SIMD instruction sets GHASH can use on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => GcmCore.SimdSupport & ~(SimdSupport.AesNi | SimdSupport.ArmAes);

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public int KeySizeBytes => _keySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => GcmCore.NonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => GcmCore.TagSizeBytes;

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public void Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext, Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException("Tag buffer too small.", nameof(tag));

        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.ComputeJ0(nonce, j0);

        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GEncryptDispatch(icb, associatedData, plaintext, ciphertext, ghash);

        // T = GCTR(J0, GHASH(H, A, C))
        _gcmCore.GctrDispatch(j0, ghash, tag.Slice(0, TagSizeBytes));
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag, Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (tag.Length != TagSizeBytes)
            throw new ArgumentException($"Tag must be {TagSizeBytes} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.ComputeJ0(nonce, j0);

        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GDecryptDispatch(icb, associatedData, ciphertext, plaintext, ghash);

        Span<byte> expectedTag = stackalloc byte[GcmCore.BlockSizeBytes];
        _gcmCore.GctrDispatch(j0, ghash, expectedTag);

        if (!CryptographicOperations.FixedTimeEquals(tag, expectedTag))
        {
            CryptographicOperations.ZeroMemory(plaintext.Slice(0, ciphertext.Length));
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
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length),
                result.AsSpan(plaintext.Length, TagSizeBytes), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
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
            throw new OS.CryptographicException("Authentication failed.");
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
                _gcmCore.Clear();
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
