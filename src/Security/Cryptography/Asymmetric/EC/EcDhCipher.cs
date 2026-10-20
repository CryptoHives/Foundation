// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// A fully managed, cross-platform ECDH implementation.
/// </summary>
/// <remarks>
/// <para>
/// Delegates to <see cref="EcMath"/> for elliptic curve arithmetic.
/// Key generation uses <see cref="RandomNumberGenerator"/> to produce a random scalar d
/// in [1, n-1], then computes the public key Q = d · G via <see cref="EcMath.ScalarMulBase"/>.
/// </para>
/// <para>
/// The shared secret is the X coordinate of the point S = d · Q, where d is the local
/// private key and Q is the remote public key.
/// </para>
/// </remarks>
public sealed class EcDhCipher : IEcDh
{
    private WeierstrassCurve? _curve;
    private byte[]? _privateKey;
    private byte[]? _publicKeyX;
    private byte[]? _publicKeyY;

    /// <inheritdoc />
    public string CurveName => _curve?.Name ?? string.Empty;

    /// <summary>
    /// Initializes a new <see cref="EcDhCipher"/> with no key.
    /// </summary>
    public EcDhCipher()
    {
    }

    /// <inheritdoc />
    public void GenerateKeyPair(string curveName)
    {
        if (curveName is null) throw new ArgumentNullException(nameof(curveName));

        var curve = EcDsaCipher.ResolveCurve(curveName);
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        Span<ulong> order = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.N, order);
        int orderBits = BigUInt.BitLength(order);

        byte[] dBytes = new byte[fs];
        Span<ulong> dLimbs = stackalloc ulong[n];

        using var rng = RandomNumberGenerator.Create();
        do
        {
            rng.GetBytes(dBytes);
            int excessBits = fs * 8 - orderBits;
            if (excessBits > 0)
                dBytes[0] &= (byte)(0xFF >> excessBits);
            BigUInt.FromBigEndianBytes(dBytes, dLimbs);
        }
        while (BigUInt.IsZero(dLimbs) || BigUInt.Compare(dLimbs, order) >= 0);

        byte[] qx = new byte[fs];
        byte[] qy = new byte[fs];
        ec.ScalarMulBase(dLimbs, qx, qy);

        _curve = curve;
        _privateKey = dBytes;
        _publicKeyX = qx;
        _publicKeyY = qy;
    }

    /// <inheritdoc />
    /// <exception cref="CryptographicException">No key has been generated.</exception>
    public (byte[] x, byte[] y) ExportPublicKey()
    {
        if (_publicKeyX is null || _publicKeyY is null)
            throw new CryptographicException("No key generated.");
        return ((byte[])_publicKeyX.Clone(), (byte[])_publicKeyY.Clone());
    }

    /// <inheritdoc />
    public byte[] DeriveSharedSecret(byte[] otherPublicKeyX, byte[] otherPublicKeyY)
    {
        if (otherPublicKeyX is null) throw new ArgumentNullException(nameof(otherPublicKeyX));
        if (otherPublicKeyY is null) throw new ArgumentNullException(nameof(otherPublicKeyY));
        if (_privateKey is null || _curve is null)
            throw new CryptographicException("Private key required.");

        var ec = new EcMath(_curve);
        int n = _curve.LimbCount;
        int fs = _curve.FieldSize;

        byte[] qx = PadLeft(otherPublicKeyX, fs);
        byte[] qy = PadLeft(otherPublicKeyY, fs);

        if (!ec.IsOnCurve(qx, qy))
            throw new CryptographicException("Other party's public key is not on the curve.");

        Span<ulong> d = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(_privateKey, d);

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

    /// <inheritdoc />
    public void Dispose()
    {
        if (_privateKey is not null)
        {
            Array.Clear(_privateKey, 0, _privateKey.Length);
            _privateKey = null;
        }
    }

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }
}
