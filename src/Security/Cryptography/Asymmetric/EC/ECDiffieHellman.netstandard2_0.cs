// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NETSTANDARD2_0
namespace System.Security.Cryptography;

using System;

/// <summary>
/// Provides a minimal <see cref="ECDiffieHellman"/> abstraction for targets where it is unavailable.
/// </summary>
public abstract class ECDiffieHellman : AsymmetricAlgorithm
{
    /// <summary>
    /// Gets the local public key.
    /// </summary>
    public abstract ECDiffieHellmanPublicKey PublicKey { get; }

    /// <summary>
    /// Generates a new key for the specified elliptic curve.
    /// </summary>
    /// <param name="curve">The elliptic curve to use.</param>
    public abstract void GenerateKey(ECCurve curve);

    /// <summary>
    /// Derives key material from the specified other party public key.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party public key.</param>
    /// <returns>The derived key bytes.</returns>
    public abstract byte[] DeriveKeyMaterial(ECDiffieHellmanPublicKey otherPartyPublicKey);

    /// <summary>
    /// Derives key material and hashes the secret.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party public key.</param>
    /// <param name="hashAlgorithm">The hash algorithm.</param>
    /// <param name="secretPrepend">Optional bytes to prepend.</param>
    /// <param name="secretAppend">Optional bytes to append.</param>
    /// <returns>The derived key bytes.</returns>
    public abstract byte[] DeriveKeyFromHash(
        ECDiffieHellmanPublicKey otherPartyPublicKey,
        HashAlgorithmName hashAlgorithm,
        byte[]? secretPrepend,
        byte[]? secretAppend);

    /// <summary>
    /// Derives key material and computes HMAC over the secret.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party public key.</param>
    /// <param name="hashAlgorithm">The hash algorithm.</param>
    /// <param name="hmacKey">The HMAC key.</param>
    /// <param name="secretPrepend">Optional bytes to prepend.</param>
    /// <param name="secretAppend">Optional bytes to append.</param>
    /// <returns>The derived key bytes.</returns>
    public abstract byte[] DeriveKeyFromHmac(
        ECDiffieHellmanPublicKey otherPartyPublicKey,
        HashAlgorithmName hashAlgorithm,
        byte[]? hmacKey,
        byte[]? secretPrepend,
        byte[]? secretAppend);

    /// <summary>
    /// Derives key material using TLS PRF semantics.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party public key.</param>
    /// <param name="prfLabel">The PRF label.</param>
    /// <param name="prfSeed">The PRF seed.</param>
    /// <returns>The derived key bytes.</returns>
    public abstract byte[] DeriveKeyTls(ECDiffieHellmanPublicKey otherPartyPublicKey, byte[] prfLabel, byte[] prfSeed);
}
#endif
