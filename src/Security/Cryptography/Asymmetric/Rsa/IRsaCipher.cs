// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;

/// <summary>
/// Defines a platform-independent RSA cipher for signing, verification, encryption, and decryption.
/// </summary>
/// <remarks>
/// <para>
/// Implementations provide both PKCS#1 v1.5 and PSS padding for signatures,
/// and both PKCS#1 v1.5 and OAEP padding for encryption.
/// </para>
/// <para>
/// The hash algorithm string parameter on signing and OAEP methods
/// accepts "SHA1", "SHA256", "SHA384", or "SHA512".
/// </para>
/// </remarks>
public interface IRsaCipher : IDisposable
{
    /// <summary>
    /// Gets the key size in bits (the bit length of the modulus).
    /// </summary>
    int KeySizeBits { get; }

    /// <summary>
    /// Gets a value indicating whether this instance contains a private key.
    /// </summary>
    bool HasPrivateKey { get; }

    /// <summary>
    /// Imports key parameters, replacing any previously imported key.
    /// </summary>
    /// <param name="key">The RSA key parameters to import.</param>
    void ImportKey(RsaKeyParameters key);

    /// <summary>
    /// Exports key parameters.
    /// </summary>
    /// <param name="includePrivateParameters">
    /// <c>true</c> to include private key material; <c>false</c> for public key only.
    /// </param>
    /// <returns>The exported <see cref="RsaKeyParameters"/>.</returns>
    RsaKeyParameters ExportKey(bool includePrivateParameters);

    /// <summary>
    /// Signs a hash using PKCS#1 v1.5 padding.
    /// </summary>
    /// <param name="hash">The hash value to sign.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <returns>The signature as a byte array.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">No private key is available.</exception>
    byte[] SignPkcs1(ReadOnlySpan<byte> hash, string hashAlgorithm);

    /// <summary>
    /// Verifies a PKCS#1 v1.5 signature against a hash.
    /// </summary>
    /// <param name="hash">The hash value to verify.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    bool VerifyPkcs1(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, string hashAlgorithm);

    /// <summary>
    /// Signs a hash using PSS padding.
    /// </summary>
    /// <param name="hash">The hash value to sign.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <param name="saltLength">The salt length in bytes. Use -1 for hash length (default).</param>
    /// <returns>The signature as a byte array.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">No private key is available.</exception>
    byte[] SignPss(ReadOnlySpan<byte> hash, string hashAlgorithm, int saltLength = -1);

    /// <summary>
    /// Verifies a PSS signature against a hash.
    /// </summary>
    /// <param name="hash">The hash value to verify.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <param name="saltLength">The expected salt length in bytes. Use -1 for hash length (default).</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    bool VerifyPss(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, string hashAlgorithm, int saltLength = -1);

    /// <summary>
    /// Encrypts data using PKCS#1 v1.5 padding.
    /// </summary>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <returns>The encrypted ciphertext.</returns>
    byte[] EncryptPkcs1(ReadOnlySpan<byte> plaintext);

    /// <summary>
    /// Decrypts data using PKCS#1 v1.5 padding.
    /// </summary>
    /// <param name="ciphertext">The data to decrypt.</param>
    /// <returns>The decrypted plaintext.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">No private key is available.</exception>
    byte[] DecryptPkcs1(ReadOnlySpan<byte> ciphertext);

    /// <summary>
    /// Encrypts data using OAEP padding.
    /// </summary>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <param name="hashAlgorithm">The hash algorithm name for OAEP (e.g., "SHA256").</param>
    /// <returns>The encrypted ciphertext.</returns>
    byte[] EncryptOaep(ReadOnlySpan<byte> plaintext, string hashAlgorithm);

    /// <summary>
    /// Decrypts data using OAEP padding.
    /// </summary>
    /// <param name="ciphertext">The data to decrypt.</param>
    /// <param name="hashAlgorithm">The hash algorithm name for OAEP (e.g., "SHA256").</param>
    /// <returns>The decrypted plaintext.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">No private key is available.</exception>
    byte[] DecryptOaep(ReadOnlySpan<byte> ciphertext, string hashAlgorithm);
}
