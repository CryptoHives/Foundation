// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;

/// <summary>
/// Defines a platform-independent ECDH key agreement cipher.
/// </summary>
/// <remarks>
/// <para>
/// Implementations derive a shared secret from a local private key and a remote public key
/// using elliptic curve Diffie-Hellman on short Weierstrass curves.
/// </para>
/// </remarks>
public interface IEcDh : IDisposable
{
    /// <summary>
    /// Gets the curve name (e.g., "P-256").
    /// </summary>
    string CurveName { get; }

    /// <summary>
    /// Generates a new ephemeral key pair for the specified curve.
    /// </summary>
    /// <param name="curveName">The curve name or OID (e.g., "nistP256").</param>
    void GenerateKeyPair(string curveName);

    /// <summary>
    /// Exports the public key coordinates.
    /// </summary>
    /// <returns>A tuple of the X and Y coordinates as big-endian byte arrays.</returns>
    (byte[] x, byte[] y) ExportPublicKey();

    /// <summary>
    /// Derives the raw shared secret from the local private key and the other party's public key.
    /// </summary>
    /// <param name="otherPublicKeyX">The other party's public key X coordinate (big-endian).</param>
    /// <param name="otherPublicKeyY">The other party's public key Y coordinate (big-endian).</param>
    /// <returns>The shared secret X coordinate as big-endian bytes.</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">
    /// No private key is available, or the public key is not on the curve.
    /// </exception>
    byte[] DeriveSharedSecret(byte[] otherPublicKeyX, byte[] otherPublicKeyY);
}
