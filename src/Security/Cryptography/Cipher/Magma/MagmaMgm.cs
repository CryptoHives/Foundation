// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Magma-MGM authenticated encryption: the Multilinear Galois Mode of RFC 9058
/// (R 1323565.1.026-2019) over GOST R 34.12-2015 Magma, as used by GOST TLS 1.3 (RFC 9367).
/// </summary>
/// <remarks>
/// <para>
/// The nonce is 8 bytes with the most significant bit clear (a 63-bit ICN). The tag is 4 to 8
/// bytes, chosen by the length of the tag buffer passed to the span overloads; the <c>byte[]</c>
/// overloads use an 8-byte tag. At least one of the plaintext and the associated data must be
/// non-empty, and together they must stay below 2^32 bits (512 MiB).
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair.
/// </para>
/// </remarks>
public sealed class MagmaMgm : IAeadCipher
{
    // MagmaMgmCore is a struct and shall not be readonly to avoid defensive copies
    private MagmaMgmCore _core;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MagmaMgm"/> class.
    /// </summary>
    /// <param name="key">The 32-byte Magma key.</param>
    /// <exception cref="ArgumentException">The key has the wrong length.</exception>
    public MagmaMgm(ReadOnlySpan<byte> key) : this(SimdSupport, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MagmaMgm"/> class with specified SIMD support for the field multiply.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="key">The 32-byte Magma key.</param>
    internal MagmaMgm(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        if (key.Length != MagmaCore.KeySizeBytes) throw new ArgumentException($"Key must be {MagmaCore.KeySizeBytes} bytes.", nameof(key));
        _core = new MagmaMgmCore(simdSupport, key);
    }

    /// <summary>
    /// Gets the carry-less multiply instructions MGM can use on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => CarrylessMultiplier.SimdSupport;

    /// <inheritdoc/>
    public string AlgorithmName => "Magma-MGM";

    /// <inheritdoc/>
    public int KeySizeBytes => MagmaCore.KeySizeBytes;

    /// <inheritdoc/>
    public int NonceSizeBytes => MagmaMgmCore.NonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => MagmaMgmCore.MaxTagSizeBytes;

    /// <summary>
    /// Creates a new Magma-MGM instance.
    /// </summary>
    /// <param name="key">The 32-byte Magma key.</param>
    /// <returns>A new Magma-MGM instance.</returns>
    public static MagmaMgm Create(ReadOnlySpan<byte> key) => new(key);

    /// <summary>
    /// Creates a new Magma-MGM instance with specified SIMD support for the field multiply.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="key">The 32-byte Magma key.</param>
    /// <returns>A new Magma-MGM instance.</returns>
    internal static MagmaMgm Create(SimdSupport simdSupport, ReadOnlySpan<byte> key) => new(simdSupport, key);

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
        if (tag.Length < MagmaMgmCore.MinTagSizeBytes || tag.Length > MagmaMgmCore.MaxTagSizeBytes)
            throw new ArgumentException($"Tag must be {MagmaMgmCore.MinTagSizeBytes} to {MagmaMgmCore.MaxTagSizeBytes} bytes.", nameof(tag));
        if (plaintext.IsEmpty && associatedData.IsEmpty)
            throw new ArgumentException("MGM requires a non-empty plaintext or associated data.", nameof(plaintext));
        if ((long)plaintext.Length + associatedData.Length > MagmaMgmCore.MaxTotalBytes)
            throw new ArgumentException("Plaintext and associated data together must stay below 2^32 bits.", nameof(plaintext));
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
        if (tag.Length < MagmaMgmCore.MinTagSizeBytes || tag.Length > MagmaMgmCore.MaxTagSizeBytes)
            throw new ArgumentException($"Tag must be {MagmaMgmCore.MinTagSizeBytes} to {MagmaMgmCore.MaxTagSizeBytes} bytes.", nameof(tag));
        if (ciphertext.IsEmpty && associatedData.IsEmpty)
            throw new ArgumentException("MGM requires a non-empty ciphertext or associated data.", nameof(ciphertext));
        if ((long)ciphertext.Length + associatedData.Length > MagmaMgmCore.MaxTotalBytes)
            throw new ArgumentException("Ciphertext and associated data together must stay below 2^32 bits.", nameof(ciphertext));
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
        if (nonce.Length != MagmaMgmCore.NonceSizeBytes || (nonce[0] & 0x80) != 0)
            throw new ArgumentException("Nonce must be 8 bytes with the most significant bit clear.", nameof(nonce));
    }
}
