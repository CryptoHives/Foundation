// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;

/// <summary>
/// A fully managed RSA implementation that inherits from <see cref="RSA"/>
/// for drop-in compatibility with the .NET BCL cryptography API.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses constant-time Montgomery arithmetic, CRT optimization,
/// and RSA blinding to prevent timing side-channel attacks.
/// </para>
/// <para>
/// Unlike the default <see cref="RSA.Create()"/> which delegates to the OS
/// (CNG on Windows, OpenSSL on Linux), this implementation is fully managed
/// and works identically across all platforms.
/// </para>
/// </remarks>
public sealed class RsaManaged : RSA
{
    private RsaKeyParameters? _key;

    /// <summary>
    /// Initializes a new <see cref="RsaManaged"/> instance with a 2048-bit key.
    /// </summary>
    public RsaManaged() : this(2048)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="RsaManaged"/> instance with the specified key size.
    /// </summary>
    /// <param name="keySizeInBits">The key size in bits (2048, 3072, or 4096).</param>
    public RsaManaged(int keySizeInBits)
    {
        LegalKeySizesValue = [new KeySizes(2048, 4096, 1024)];
        KeySizeValue = keySizeInBits;
    }

    /// <inheritdoc />
    public override RSAParameters ExportParameters(bool includePrivateParameters)
    {
        if (_key is null)
            throw new CryptographicException("No key has been imported.");

        var p = new RSAParameters
        {
            Modulus = (byte[])_key.Modulus.Clone(),
            Exponent = (byte[])_key.PublicExponent.Clone()
        };

        if (includePrivateParameters && _key.HasPrivateKey)
        {
            p.D = (byte[])_key.PrivateExponent!.Clone();
            p.P = (byte[])_key.P!.Clone();
            p.Q = (byte[])_key.Q!.Clone();
            p.DP = (byte[])_key.Dp!.Clone();
            p.DQ = (byte[])_key.Dq!.Clone();
            p.InverseQ = (byte[])_key.QInv!.Clone();
        }

        return p;
    }

    /// <inheritdoc />
    public override void ImportParameters(RSAParameters parameters)
    {
        if (parameters.Modulus is null || parameters.Exponent is null)
            throw new CryptographicException("Invalid RSA parameters.");

        _key?.Dispose();

        if (parameters.D is not null)
        {
            _key = new RsaKeyParameters(
                parameters.Modulus,
                parameters.Exponent,
                parameters.D,
                parameters.P ?? throw new CryptographicException("Missing P."),
                parameters.Q ?? throw new CryptographicException("Missing Q."),
                parameters.DP ?? throw new CryptographicException("Missing DP."),
                parameters.DQ ?? throw new CryptographicException("Missing DQ."),
                parameters.InverseQ ?? throw new CryptographicException("Missing InverseQ."));
        }
        else
        {
            _key = new RsaKeyParameters(parameters.Modulus, parameters.Exponent);
        }

        KeySizeValue = parameters.Modulus.Length * 8;
    }

    /// <inheritdoc />
    public override byte[] SignHash(byte[] hash, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
    {
        if (_key is null || !_key.HasPrivateKey)
            throw new CryptographicException("Private key required for signing.");

        if (padding == RSASignaturePadding.Pkcs1)
            return RsaPkcs1.Sign(hash, hashAlgorithm, _key);

        if (padding == RSASignaturePadding.Pss)
            return RsaPss.Sign(hash, hashAlgorithm, _key);

        throw new CryptographicException($"Unsupported padding mode: {padding}");
    }

    /// <inheritdoc />
    public override bool VerifyHash(byte[] hash, byte[] signature, HashAlgorithmName hashAlgorithm, RSASignaturePadding padding)
    {
        if (_key is null)
            throw new CryptographicException("Key required for verification.");

        if (padding == RSASignaturePadding.Pkcs1)
            return RsaPkcs1.Verify(hash, signature, hashAlgorithm, _key);

        if (padding == RSASignaturePadding.Pss)
            return RsaPss.Verify(hash, signature, hashAlgorithm, _key);

        throw new CryptographicException($"Unsupported padding mode: {padding}");
    }

    /// <inheritdoc />
    public override byte[] Encrypt(byte[] data, RSAEncryptionPadding padding)
    {
        if (_key is null)
            throw new CryptographicException("Key required for encryption.");

        if (padding == RSAEncryptionPadding.Pkcs1)
            return RsaPkcs1.Encrypt(data, _key);

        if (padding == RSAEncryptionPadding.OaepSHA1)
            return RsaOaep.Encrypt(data, _key, HashAlgorithmName.SHA1);

        if (padding == RSAEncryptionPadding.OaepSHA256)
            return RsaOaep.Encrypt(data, _key, HashAlgorithmName.SHA256);

        if (padding == RSAEncryptionPadding.OaepSHA384)
            return RsaOaep.Encrypt(data, _key, HashAlgorithmName.SHA384);

        if (padding == RSAEncryptionPadding.OaepSHA512)
            return RsaOaep.Encrypt(data, _key, HashAlgorithmName.SHA512);

        throw new CryptographicException($"Unsupported encryption padding: {padding}");
    }

    /// <inheritdoc />
    public override byte[] Decrypt(byte[] data, RSAEncryptionPadding padding)
    {
        if (_key is null || !_key.HasPrivateKey)
            throw new CryptographicException("Private key required for decryption.");

        if (padding == RSAEncryptionPadding.Pkcs1)
            return RsaPkcs1.Decrypt(data, _key);

        if (padding == RSAEncryptionPadding.OaepSHA1)
            return RsaOaep.Decrypt(data, _key, HashAlgorithmName.SHA1);

        if (padding == RSAEncryptionPadding.OaepSHA256)
            return RsaOaep.Decrypt(data, _key, HashAlgorithmName.SHA256);

        if (padding == RSAEncryptionPadding.OaepSHA384)
            return RsaOaep.Decrypt(data, _key, HashAlgorithmName.SHA384);

        if (padding == RSAEncryptionPadding.OaepSHA512)
            return RsaOaep.Decrypt(data, _key, HashAlgorithmName.SHA512);

        throw new CryptographicException($"Unsupported encryption padding: {padding}");
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _key?.Dispose();
            _key = null;
        }

        base.Dispose(disposing);
    }
}

#endif
