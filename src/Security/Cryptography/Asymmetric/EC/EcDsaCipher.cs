// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// A fully managed, cross-platform ECDSA implementation.
/// </summary>
/// <remarks>
/// <para>
/// Delegates to <see cref="EcDsaCore"/> for signature generation and verification,
/// and to <see cref="EcMath"/> for elliptic curve arithmetic.
/// </para>
/// <para>
/// Key generation uses <see cref="RandomNumberGenerator"/> to produce a random scalar d
/// in [1, n-1], then computes the public key Q = d · G via <see cref="EcMath.ScalarMulBase"/>.
/// </para>
/// <para>
/// Supported curves: nistP256, nistP384, nistP521, secp256k1,
/// brainpoolP256r1, brainpoolP384r1, brainpoolP512r1, and their OID forms.
/// </para>
/// </remarks>
public sealed class EcDsaCipher : IEcDsa
{
    private WeierstrassCurve? _curve;
    private byte[]? _privateKey;
    private byte[]? _publicKeyX;
    private byte[]? _publicKeyY;

    /// <inheritdoc />
    public string CurveName => _curve?.Name ?? string.Empty;

    /// <inheritdoc />
    public int KeySizeBits => _curve?.FieldBits ?? 0;

    /// <inheritdoc />
    public bool HasPrivateKey => _privateKey is not null;

    /// <summary>
    /// Initializes a new <see cref="EcDsaCipher"/> with no key.
    /// </summary>
    public EcDsaCipher()
    {
    }

    /// <summary>
    /// Initializes a new <see cref="EcDsaCipher"/> and generates a key pair for the specified curve.
    /// </summary>
    /// <param name="curveName">The curve name or OID (e.g., "nistP256").</param>
    /// <exception cref="CryptographicException">The curve is not supported.</exception>
    public EcDsaCipher(string curveName)
    {
        GenerateKey(curveName);
    }

    /// <inheritdoc />
    public void ImportKey(byte[] privateKey, byte[] publicKeyX, byte[] publicKeyY, string curveName)
    {
        if (privateKey is null) throw new ArgumentNullException(nameof(privateKey));
        if (publicKeyX is null) throw new ArgumentNullException(nameof(publicKeyX));
        if (publicKeyY is null) throw new ArgumentNullException(nameof(publicKeyY));
        if (curveName is null) throw new ArgumentNullException(nameof(curveName));

        _curve = ResolveCurve(curveName);
        _privateKey = (byte[])privateKey.Clone();
        _publicKeyX = (byte[])publicKeyX.Clone();
        _publicKeyY = (byte[])publicKeyY.Clone();
    }

    /// <inheritdoc />
    public void ImportPublicKey(byte[] publicKeyX, byte[] publicKeyY, string curveName)
    {
        if (publicKeyX is null) throw new ArgumentNullException(nameof(publicKeyX));
        if (publicKeyY is null) throw new ArgumentNullException(nameof(publicKeyY));
        if (curveName is null) throw new ArgumentNullException(nameof(curveName));

        _curve = ResolveCurve(curveName);
        _privateKey = null;
        _publicKeyX = (byte[])publicKeyX.Clone();
        _publicKeyY = (byte[])publicKeyY.Clone();
    }

    /// <inheritdoc />
    /// <exception cref="CryptographicException">No key has been imported.</exception>
    public (byte[] x, byte[] y) ExportPublicKey()
    {
        if (_publicKeyX is null || _publicKeyY is null)
            throw new CryptographicException("No key imported.");
        return ((byte[])_publicKeyX.Clone(), (byte[])_publicKeyY.Clone());
    }

    /// <inheritdoc />
    public byte[]? ExportPrivateKey() =>
        _privateKey is not null ? (byte[])_privateKey.Clone() : null;

    /// <inheritdoc />
    public byte[] SignHash(ReadOnlySpan<byte> hash)
    {
        if (_privateKey is null) throw new CryptographicException("Private key required for signing.");
        if (_curve is null) throw new CryptographicException("No key imported.");

        HashAlgorithmName hashAlg = GetDefaultHashAlgorithm(_curve);
        var (r, s) = EcDsaCore.Sign(hash, _privateKey, _curve, hashAlg);

        int fs = _curve.FieldSize;
        byte[] signature = new byte[fs * 2];
        PadCopyTo(r, signature.AsSpan(0, fs));
        PadCopyTo(s, signature.AsSpan(fs, fs));
        return signature;
    }

    /// <inheritdoc />
    public bool VerifyHash(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature)
    {
        if (_publicKeyX is null || _publicKeyY is null || _curve is null)
            throw new CryptographicException("No key imported.");

        int fs = _curve.FieldSize;
        if (signature.Length != fs * 2) return false;

        byte[] r = signature[..fs].ToArray();
        byte[] s = signature[fs..].ToArray();

        return EcDsaCore.Verify(
            hash, r, s,
            PadLeft(_publicKeyX, fs),
            PadLeft(_publicKeyY, fs),
            _curve);
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

    /// <summary>
    /// Resolves a curve name or OID to a <see cref="WeierstrassCurve"/> instance.
    /// </summary>
    /// <param name="curveName">The curve name or OID.</param>
    /// <returns>The resolved curve.</returns>
    /// <exception cref="CryptographicException">The curve is not supported.</exception>
    internal static WeierstrassCurve ResolveCurve(string curveName) => curveName switch
    {
        "nistP256" or "P-256" or "secp256r1" or "prime256v1" or "ECDSA_P256"
            or "1.2.840.10045.3.1.7" => WeierstrassCurve.P256,
        "nistP384" or "P-384" or "secp384r1" or "ECDSA_P384"
            or "1.3.132.0.34" => WeierstrassCurve.P384,
        "nistP521" or "P-521" or "secp521r1" or "ECDSA_P521"
            or "1.3.132.0.35" => WeierstrassCurve.P521,
        "secp256k1" or "secP256k1"
            or "1.3.132.0.10" => WeierstrassCurve.Secp256k1,
        "brainpoolP256r1"
            or "1.3.36.3.3.2.8.1.1.7" => WeierstrassCurve.BrainpoolP256r1,
        "brainpoolP384r1"
            or "1.3.36.3.3.2.8.1.1.11" => WeierstrassCurve.BrainpoolP384r1,
        "brainpoolP512r1"
            or "1.3.36.3.3.2.8.1.1.13" => WeierstrassCurve.BrainpoolP512r1,
        _ => throw new CryptographicException($"Unsupported curve: {curveName}")
    };

    private void GenerateKey(string curveName)
    {
        var curve = ResolveCurve(curveName);
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

    private static HashAlgorithmName GetDefaultHashAlgorithm(WeierstrassCurve curve) => curve.FieldBits switch
    {
        <= 256 => HashAlgorithmName.SHA256,
        <= 384 => HashAlgorithmName.SHA384,
        _ => HashAlgorithmName.SHA512
    };

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }

    private static void PadCopyTo(byte[] src, Span<byte> dst)
    {
        if (src.Length >= dst.Length)
        {
            src.AsSpan(src.Length - dst.Length).CopyTo(dst);
        }
        else
        {
            dst.Clear();
            src.CopyTo(dst[(dst.Length - src.Length)..]);
        }
    }
}
