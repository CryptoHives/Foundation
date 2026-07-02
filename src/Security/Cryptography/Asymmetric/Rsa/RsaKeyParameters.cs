// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;

/// <summary>
/// Represents an RSA key pair containing both public and private key components.
/// </summary>
/// <remarks>
/// <para>
/// All parameters are stored as big-endian byte arrays, consistent with standard
/// RSA key encoding formats (PKCS#1, PKCS#8, X.509 SPKI).
/// </para>
/// <para>
/// Private keys include the CRT (Chinese Remainder Theorem) parameters
/// <see cref="Dp"/>, <see cref="Dq"/>, and <see cref="QInv"/> for efficient
/// decryption and signing.
/// </para>
/// </remarks>
public sealed class RsaKeyParameters : IDisposable
{
    private bool _disposed;

    /// <summary>
    /// Gets the RSA modulus n = p · q.
    /// </summary>
    public byte[] Modulus { get; }

    /// <summary>
    /// Gets the public exponent e (typically 65537).
    /// </summary>
    public byte[] PublicExponent { get; }

    /// <summary>
    /// Gets the private exponent d, or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? PrivateExponent { get; }

    /// <summary>
    /// Gets the first prime factor p, or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? P { get; }

    /// <summary>
    /// Gets the second prime factor q, or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? Q { get; }

    /// <summary>
    /// Gets the CRT exponent dp = d mod (p-1), or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? Dp { get; }

    /// <summary>
    /// Gets the CRT exponent dq = d mod (q-1), or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? Dq { get; }

    /// <summary>
    /// Gets the CRT coefficient qInv = q⁻¹ mod p, or <c>null</c> for public-only keys.
    /// </summary>
    public byte[]? QInv { get; }

    /// <summary>
    /// Gets a value indicating whether this key contains private key material.
    /// </summary>
    public bool HasPrivateKey => PrivateExponent is not null;

    /// <summary>
    /// Gets the key size in bits (the bit length of the modulus).
    /// </summary>
    public int KeySizeBits => Modulus.Length * 8;

    /// <summary>
    /// Initializes a new <see cref="RsaKeyParameters"/> with public key components only.
    /// </summary>
    /// <param name="modulus">The RSA modulus n (big-endian).</param>
    /// <param name="publicExponent">The public exponent e (big-endian).</param>
    public RsaKeyParameters(byte[] modulus, byte[] publicExponent)
    {
        Modulus = modulus ?? throw new ArgumentNullException(nameof(modulus));
        PublicExponent = publicExponent ?? throw new ArgumentNullException(nameof(publicExponent));
    }

    /// <summary>
    /// Initializes a new <see cref="RsaKeyParameters"/> with full private key components.
    /// </summary>
    /// <param name="modulus">The RSA modulus n (big-endian).</param>
    /// <param name="publicExponent">The public exponent e (big-endian).</param>
    /// <param name="privateExponent">The private exponent d (big-endian).</param>
    /// <param name="p">The first prime factor (big-endian).</param>
    /// <param name="q">The second prime factor (big-endian).</param>
    /// <param name="dp">The CRT exponent dp (big-endian).</param>
    /// <param name="dq">The CRT exponent dq (big-endian).</param>
    /// <param name="qInv">The CRT coefficient qInv (big-endian).</param>
    public RsaKeyParameters(
        byte[] modulus,
        byte[] publicExponent,
        byte[] privateExponent,
        byte[] p,
        byte[] q,
        byte[] dp,
        byte[] dq,
        byte[] qInv)
    {
        Modulus = modulus ?? throw new ArgumentNullException(nameof(modulus));
        PublicExponent = publicExponent ?? throw new ArgumentNullException(nameof(publicExponent));
        PrivateExponent = privateExponent ?? throw new ArgumentNullException(nameof(privateExponent));
        P = p ?? throw new ArgumentNullException(nameof(p));
        Q = q ?? throw new ArgumentNullException(nameof(q));
        Dp = dp ?? throw new ArgumentNullException(nameof(dp));
        Dq = dq ?? throw new ArgumentNullException(nameof(dq));
        QInv = qInv ?? throw new ArgumentNullException(nameof(qInv));
    }

    /// <summary>
    /// Creates a public-only copy of this key, stripping private components.
    /// </summary>
    /// <returns>A new <see cref="RsaKeyParameters"/> containing only the modulus and public exponent.</returns>
    public RsaKeyParameters ToPublicKey() => new(
        (byte[])Modulus.Clone(),
        (byte[])PublicExponent.Clone());

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        // Zeroize private key material
        if (PrivateExponent is not null) Array.Clear(PrivateExponent, 0, PrivateExponent.Length);
        if (P is not null) Array.Clear(P, 0, P.Length);
        if (Q is not null) Array.Clear(Q, 0, Q.Length);
        if (Dp is not null) Array.Clear(Dp, 0, Dp.Length);
        if (Dq is not null) Array.Clear(Dq, 0, Dq.Length);
        if (QInv is not null) Array.Clear(QInv, 0, QInv.Length);
    }
}
