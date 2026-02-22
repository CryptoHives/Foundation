// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Defines an Authenticated Encryption with Associated Data (AEAD) cipher.
/// </summary>
/// <remarks>
/// <para>
/// AEAD ciphers provide both confidentiality (encryption) and authenticity
/// (integrity verification) in a single operation. They also support
/// authenticating additional data that is not encrypted.
/// </para>
/// <para>
/// <b>Common AEAD algorithms:</b>
/// <list type="bullet">
///   <item><description>AES-GCM (Galois/Counter Mode)</description></item>
///   <item><description>ChaCha20-Poly1305</description></item>
///   <item><description>AES-CCM (Counter with CBC-MAC)</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IAeadCipher : IDisposable
{
    /// <summary>
    /// Gets the algorithm name.
    /// </summary>
    string AlgorithmName { get; }

    /// <summary>
    /// Gets the key size in bytes.
    /// </summary>
    int KeySizeBytes { get; }

    /// <summary>
    /// Gets the nonce size in bytes.
    /// </summary>
    int NonceSizeBytes { get; }

    /// <summary>
    /// Gets the authentication tag size in bytes.
    /// </summary>
    int TagSizeBytes { get; }

    /// <summary>
    /// Encrypts the plaintext and computes the authentication tag.
    /// </summary>
    /// <param name="nonce">The unique nonce for this encryption.</param>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <param name="ciphertext">The output buffer for ciphertext (same size as plaintext).</param>
    /// <param name="tag">The output buffer for the authentication tag.</param>
    /// <param name="associatedData">Additional data to authenticate (optional).</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="nonce"/> is not the correct size, or
    /// <paramref name="ciphertext"/> or <paramref name="tag"/> buffers are too small.
    /// </exception>
    void Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                 Span<byte> ciphertext, Span<byte> tag,
                 ReadOnlySpan<byte> associatedData = default);

    /// <summary>
    /// Decrypts the ciphertext and verifies the authentication tag.
    /// </summary>
    /// <param name="nonce">The nonce used during encryption.</param>
    /// <param name="ciphertext">The encrypted data.</param>
    /// <param name="tag">The authentication tag to verify.</param>
    /// <param name="plaintext">The output buffer for decrypted data (same size as ciphertext).</param>
    /// <param name="associatedData">Additional authenticated data (must match encryption).</param>
    /// <returns>True if decryption and authentication succeeded; false if authentication failed.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="nonce"/> or <paramref name="tag"/> is not the correct size, or
    /// <paramref name="plaintext"/> buffer is too small.
    /// </exception>
    bool Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
                 ReadOnlySpan<byte> tag, Span<byte> plaintext,
                 ReadOnlySpan<byte> associatedData = default);

    /// <summary>
    /// Encrypts the plaintext and returns ciphertext with appended tag.
    /// </summary>
    /// <param name="nonce">The unique nonce for this encryption.</param>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <param name="associatedData">Additional data to authenticate (optional).</param>
    /// <returns>The ciphertext with authentication tag appended.</returns>
    byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                   ReadOnlySpan<byte> associatedData = default);

    /// <summary>
    /// Decrypts the ciphertext (with appended tag) and verifies authenticity.
    /// </summary>
    /// <param name="nonce">The nonce used during encryption.</param>
    /// <param name="ciphertextWithTag">The ciphertext with appended authentication tag.</param>
    /// <param name="associatedData">Additional authenticated data (must match encryption).</param>
    /// <returns>The decrypted plaintext.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">
    /// Authentication failed - the data has been tampered with or the wrong key/nonce was used.
    /// </exception>
    byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
                   ReadOnlySpan<byte> associatedData = default);
}
