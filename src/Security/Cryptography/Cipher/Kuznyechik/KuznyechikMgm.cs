// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Kuznyechik-MGM authenticated encryption: the Multilinear Galois Mode of RFC 9058
/// (R 1323565.1.026-2019) over GOST R 34.12-2015 Kuznyechik, as used by GOST TLS 1.3 (RFC 9367).
/// </summary>
/// <remarks>
/// <para>
/// The nonce is 16 bytes with the most significant bit clear (a 127-bit ICN). The tag is
/// 4 to 16 bytes, chosen by the length of the tag buffer passed to the span overloads; the
/// <c>byte[]</c> overloads use a 16-byte tag. At least one of the plaintext and the associated
/// data must be non-empty.
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair.
/// </para>
/// </remarks>
public sealed class KuznyechikMgm : IAeadCipher
{
    // MgmCore is a struct and shall not be readonly to avoid defensive copies
    private MgmCore _core;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="KuznyechikMgm"/> class.
    /// </summary>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public KuznyechikMgm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KuznyechikMgm"/> class with specified SIMD support for the field multiply.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    internal KuznyechikMgm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        _core = new MgmCore(simdSupport, BlockCipher128.Create(BlockCipher128Algorithm.Kuznyechik, key));
    }

    /// <summary>
    /// Gets the carry-less multiply instructions MGM can use on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => MgmCore.SimdSupport;

    /// <inheritdoc/>
    public string AlgorithmName => "Kuznyechik-MGM";

    /// <inheritdoc/>
    public int KeySizeBytes => KuznyechikCore.KeySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => MgmCore.NonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => MgmCore.MaxTagSizeBytes;

    /// <summary>
    /// Creates a new Kuznyechik-MGM instance.
    /// </summary>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <returns>A new Kuznyechik-MGM instance.</returns>
    public static KuznyechikMgm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new Kuznyechik-MGM instance with specified SIMD support for the field multiply.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="key">The 32-byte Kuznyechik key.</param>
    /// <returns>A new Kuznyechik-MGM instance.</returns>
    internal static KuznyechikMgm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);

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
        ValidateNonce(nonce);
        if (tag.Length < MgmCore.MinTagSizeBytes || tag.Length > MgmCore.MaxTagSizeBytes)
            throw new ArgumentException($"Tag must be {MgmCore.MinTagSizeBytes} to {MgmCore.MaxTagSizeBytes} bytes.", nameof(tag));
        if (plaintext.IsEmpty && associatedData.IsEmpty)
            throw new ArgumentException("MGM requires a non-empty plaintext or associated data.", nameof(plaintext));
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
        ValidateNonce(nonce);
        if (tag.Length < MgmCore.MinTagSizeBytes || tag.Length > MgmCore.MaxTagSizeBytes)
            throw new ArgumentException($"Tag must be {MgmCore.MinTagSizeBytes} to {MgmCore.MaxTagSizeBytes} bytes.", nameof(tag));
        if (ciphertext.IsEmpty && associatedData.IsEmpty)
            throw new ArgumentException("MGM requires a non-empty ciphertext or associated data.", nameof(ciphertext));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        Span<byte> output = plaintext.Slice(0, ciphertext.Length);
        if (!_core.Decrypt(nonce, ciphertext, tag, associatedData, output))
        {
            CryptographicOperations.ZeroMemory(output);
            return false;
        }

        return true;
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
        if (!_disposed)
        {
            _core.Clear();
            _disposed = true;
        }
    }

    private static void ValidateNonce(ReadOnlySpan<byte> nonce)
    {
        if (nonce.Length != MgmCore.NonceSizeBytes || (nonce[0] & 0x80) != 0)
            throw new ArgumentException("Nonce must be 16 bytes with the most significant bit clear.", nameof(nonce));
    }
}
