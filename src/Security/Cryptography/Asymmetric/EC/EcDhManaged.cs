// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NET462 && !NETSTANDARD2_0
namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// A fully managed ECDH implementation that inherits from <see cref="ECDiffieHellman"/>
/// for drop-in compatibility with the .NET BCL cryptography API.
/// </summary>
public sealed class EcDhManaged : ECDiffieHellman
{
    private ECParameters? _params;
    private WeierstrassCurve? _curve;

    /// <summary>
    /// Initializes a new <see cref="EcDhManaged"/> with P-256.
    /// </summary>
    public EcDhManaged() : this(ECCurve.NamedCurves.nistP256)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="EcDhManaged"/> with the specified curve.
    /// </summary>
    /// <param name="curve">The elliptic curve to use.</param>
    public EcDhManaged(ECCurve curve)
    {
        _curve = ResolveCurve(curve);
        KeySizeValue = _curve.FieldBits;
    }

    /// <inheritdoc />
    public override ECParameters ExportParameters(bool includePrivateParameters)
    {
        if (_params is null)
            throw new CryptographicException("No key has been imported.");

        var result = new ECParameters
        {
            Curve = _params.Value.Curve,
            Q = new ECPoint
            {
                X = (byte[])_params.Value.Q.X!.Clone(),
                Y = (byte[])_params.Value.Q.Y!.Clone()
            }
        };

        if (includePrivateParameters && _params.Value.D is not null)
            result.D = (byte[])_params.Value.D.Clone();

        return result;
    }

    /// <inheritdoc />
    public override void ImportParameters(ECParameters parameters)
    {
        _curve = ResolveCurve(parameters.Curve);
        _params = parameters;
        KeySizeValue = _curve.FieldBits;
    }

    /// <inheritdoc />
    public override void GenerateKey(ECCurve curve)
    {
        _curve = ResolveCurve(curve);
        using var tmp = ECDiffieHellman.Create(curve);
        _params = tmp.ExportParameters(true);
        KeySizeValue = _curve.FieldBits;
    }

    /// <inheritdoc />
    public override ECDiffieHellmanPublicKey PublicKey =>
        throw new NotSupportedException("Use ExportParameters(false) instead.");

    /// <summary>
    /// Derives the raw shared secret from the private key and the other party's public key.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party's public key parameters.</param>
    /// <returns>The shared secret X coordinate (big-endian bytes).</returns>
    /// <exception cref="CryptographicException">Thrown if the private key is not available or the public key is invalid.</exception>
    public byte[] DeriveRawSecretAgreement(ECParameters otherPartyPublicKey)
    {
        if (_params is null || _params.Value.D is null)
            throw new CryptographicException("Private key required.");

        var ec = new EcMath(_curve!);
        int n = _curve!.LimbCount;
        int fs = _curve.FieldSize;

        // Validate the other party's public key is on the curve
        byte[] qx = PadLeft(otherPartyPublicKey.Q.X!, fs);
        byte[] qy = PadLeft(otherPartyPublicKey.Q.Y!, fs);

        if (!ec.IsOnCurve(qx, qy))
            throw new CryptographicException("Other party's public key is not on the curve.");

        // Compute shared secret: S = d · Q
        Span<ulong> d = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(_params.Value.D, d);

        Span<ulong> qxMont = stackalloc ulong[n];
        Span<ulong> qyMont = stackalloc ulong[n];
        Span<ulong> qxLimbs = stackalloc ulong[n];
        Span<ulong> qyLimbs = stackalloc ulong[n];

        BigUInt.FromBigEndianBytes(qx, qxLimbs);
        BigUInt.FromBigEndianBytes(qy, qyLimbs);
        ec.Field.ToMontgomery(qxLimbs, qxMont);
        ec.Field.ToMontgomery(qyLimbs, qyMont);

        Span<ulong> sxMont = stackalloc ulong[n];
        Span<ulong> syMont = stackalloc ulong[n];
        ec.ScalarMul(d, qxMont, qyMont, sxMont, syMont);

        Span<ulong> sx = stackalloc ulong[n];
        ec.Field.FromMontgomery(sxMont, sx);

        byte[] secret = new byte[fs];
        BigUInt.ToBigEndianBytes(sx, secret);
        return secret;
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static WeierstrassCurve ResolveCurve(ECCurve curve)
    {
        string? oid = curve.Oid?.Value;
        return oid switch
        {
            "1.2.840.10045.3.1.7" => WeierstrassCurve.P256,
            "1.3.132.0.34" => WeierstrassCurve.P384,
            "1.3.132.0.35" => WeierstrassCurve.P521,
            "1.3.132.0.10" => WeierstrassCurve.Secp256k1,
            "1.3.36.3.3.2.8.1.1.7" => WeierstrassCurve.BrainpoolP256r1,
            "1.3.36.3.3.2.8.1.1.11" => WeierstrassCurve.BrainpoolP384r1,
            "1.3.36.3.3.2.8.1.1.13" => WeierstrassCurve.BrainpoolP512r1,
            _ => ResolveCurveByName(curve)
        };
    }

    private static WeierstrassCurve ResolveCurveByName(ECCurve curve)
    {
        string? name = curve.Oid?.FriendlyName;
        return name switch
        {
            "nistP256" or "ECDSA_P256" => WeierstrassCurve.P256,
            "nistP384" or "ECDSA_P384" => WeierstrassCurve.P384,
            "nistP521" or "ECDSA_P521" => WeierstrassCurve.P521,
            "secP256k1" => WeierstrassCurve.Secp256k1,
            "brainpoolP256r1" => WeierstrassCurve.BrainpoolP256r1,
            "brainpoolP384r1" => WeierstrassCurve.BrainpoolP384r1,
            "brainpoolP512r1" => WeierstrassCurve.BrainpoolP512r1,
            _ => throw new CryptographicException($"Unsupported curve: {name}")
        };
    }

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }
}
#endif
