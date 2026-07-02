// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;

/// <summary>
/// Defines a platform-independent ECDSA cipher for signing and verification.
/// </summary>
/// <remarks>
/// <para>
/// Implementations use IEEE P1363 signature format (r || s) with fixed-size coordinates.
/// The curve is specified by name (e.g., "nistP256", "secp256k1") or by OID.
/// </para>
/// </remarks>
public interface IEcDsa : IDisposable
{
    /// <summary>
    /// Gets the curve name (e.g., "P-256").
    /// </summary>
    string CurveName { get; } 

    /// <summary>
    /// Gets the key size in bits.
    /// </summary>
    int KeySizeBits { get; }

    /// <summary>
    /// Gets a value indicating whether this instance contains a private key.
    /// </summary>
    bool HasPrivateKey { get; }

    /// <summary>
    /// Imports a full key pair (private and public).
    /// </summary>
    /// <param name="privateKey">The private key scalar d (big-endian).</param>
    /// <param name="publicKeyX">The public key X coordinate (big-endian).</param>
    /// <param name="publicKeyY">The public key Y coordinate (big-endian).</param>
    /// <param name="curveName">The curve name or OID.</param>
    void ImportKey(byte[] privateKey, byte[] publicKeyX, byte[] publicKeyY, string curveName);

    /// <summary>
    /// Imports a public key only.
    /// </summary>
    /// <param name="publicKeyX">The public key X coordinate (big-endian).</param>
    /// <param name="publicKeyY">The public key Y coordinate (big-endian).</param>
    /// <param name="curveName">The curve name or OID.</param>
    void ImportPublicKey(byte[] publicKeyX, byte[] publicKeyY, string curveName);

    /// <summary>
    /// Exports the public key coordinates.
    /// </summary>
    /// <returns>A tuple of the X and Y coordinates as big-endian byte arrays.</returns>
    (byte[] x, byte[] y) ExportPublicKey();

    /// <summary>
    /// Exports the private key scalar, or <c>null</c> if no private key is available.
    /// </summary>
    /// <returns>The private key d as a big-endian byte array, or <c>null</c>.</returns>
    byte[]? ExportPrivateKey();

    /// <summary>
    /// Signs a hash using ECDSA.
    /// </summary>
    /// <param name="hash">The hash value to sign.</param>
    /// <returns>The signature in IEEE P1363 format (r || s).</returns>
    /// <exception cref="System.Security.Cryptography.CryptographicException">No private key is available.</exception>
    byte[] SignHash(ReadOnlySpan<byte> hash);

    /// <summary>
    /// Verifies an ECDSA signature against a hash.
    /// </summary>
    /// <param name="hash">The hash value to verify.</param>
    /// <param name="signature">The signature in IEEE P1363 format (r || s).</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    bool VerifyHash(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature);
}
