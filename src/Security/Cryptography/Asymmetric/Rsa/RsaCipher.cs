// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;

/// <summary>
/// A fully managed, cross-platform RSA implementation.
/// </summary>
/// <remarks>
/// <para>
/// Delegates to <see cref="RsaPkcs1"/>, <see cref="RsaPss"/>, and <see cref="RsaOaep"/>
/// for all padding operations, and to <see cref="RsaCore"/> for raw RSA primitives.
/// </para>
/// <para>
/// This implementation works identically on all .NET platforms without OS-specific dependencies.
/// </para>
/// </remarks>
public sealed class RsaCipher : IRsaCipher
{
    private RsaKeyParameters? _key;

    /// <inheritdoc />
    public int KeySizeBits => _key?.KeySizeBits ?? 0;

    /// <inheritdoc />
    public bool HasPrivateKey => _key?.HasPrivateKey ?? false;

    /// <summary>
    /// Initializes a new <see cref="RsaCipher"/> with no key.
    /// </summary>
    public RsaCipher()
    {
    }

    /// <summary>
    /// Initializes a new <see cref="RsaCipher"/> with the specified key parameters.
    /// </summary>
    /// <param name="key">The RSA key parameters to use.</param>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
    public RsaCipher(RsaKeyParameters key)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
    }

    /// <inheritdoc />
    public void ImportKey(RsaKeyParameters key)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
    }

    /// <inheritdoc />
    /// <exception cref="CryptographicException">No key has been imported.</exception>
    public RsaKeyParameters ExportKey(bool includePrivateParameters)
    {
        if (_key is null) throw new CryptographicException("No key imported.");
        return includePrivateParameters ? _key : _key.ToPublicKey();
    }

    /// <inheritdoc />
    public byte[] SignPkcs1(ReadOnlySpan<byte> hash, string hashAlgorithm) =>
        RsaPkcs1.Sign(hash, ToHashAlgorithmName(hashAlgorithm), RequirePrivateKey());

    /// <inheritdoc />
    public bool VerifyPkcs1(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, string hashAlgorithm) =>
        RsaPkcs1.Verify(hash, signature, ToHashAlgorithmName(hashAlgorithm), RequireKey());

    /// <inheritdoc />
    public byte[] SignPss(ReadOnlySpan<byte> hash, string hashAlgorithm, int saltLength = -1) =>
        RsaPss.Sign(hash, ToHashAlgorithmName(hashAlgorithm), RequirePrivateKey(), saltLength);

    /// <inheritdoc />
    public bool VerifyPss(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, string hashAlgorithm, int saltLength = -1) =>
        RsaPss.Verify(hash, signature, ToHashAlgorithmName(hashAlgorithm), RequireKey(), saltLength);

    /// <inheritdoc />
    public byte[] EncryptPkcs1(ReadOnlySpan<byte> plaintext) =>
        RsaPkcs1.Encrypt(plaintext, RequireKey());

    /// <inheritdoc />
    public byte[] DecryptPkcs1(ReadOnlySpan<byte> ciphertext) =>
        RsaPkcs1.Decrypt(ciphertext, RequirePrivateKey());

    /// <inheritdoc />
    public byte[] EncryptOaep(ReadOnlySpan<byte> plaintext, string hashAlgorithm) =>
        RsaOaep.Encrypt(plaintext, RequireKey(), ToHashAlgorithmName(hashAlgorithm));

    /// <inheritdoc />
    public byte[] DecryptOaep(ReadOnlySpan<byte> ciphertext, string hashAlgorithm) =>
        RsaOaep.Decrypt(ciphertext, RequirePrivateKey(), ToHashAlgorithmName(hashAlgorithm));

    /// <inheritdoc />
    public void Dispose()
    {
        _key?.Dispose();
    }

    private RsaKeyParameters RequireKey() =>
        _key ?? throw new CryptographicException("No key imported.");

    private RsaKeyParameters RequirePrivateKey()
    {
        if (_key is null) throw new CryptographicException("No key imported.");
        if (!_key.HasPrivateKey) throw new CryptographicException("Private key required.");
        return _key;
    }

    private static HashAlgorithmName ToHashAlgorithmName(string name) => name.ToUpperInvariant() switch
    {
        "SHA1" => HashAlgorithmName.SHA1,
        "SHA256" => HashAlgorithmName.SHA256,
        "SHA384" => HashAlgorithmName.SHA384,
        "SHA512" => HashAlgorithmName.SHA512,
        _ => throw new ArgumentException($"Unsupported hash algorithm: {name}", nameof(name))
    };
}
