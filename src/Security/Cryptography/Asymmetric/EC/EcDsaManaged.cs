// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// A fully managed ECDSA implementation that inherits from <see cref="ECDsa"/>
/// for drop-in compatibility with the .NET BCL cryptography API.
/// </summary>
/// <remarks>
/// <para>
/// Unlike the default <see cref="ECDsa.Create()"/> which delegates to the OS,
/// this implementation is fully managed and works identically across all platforms.
/// </para>
/// <para>
/// Supports NIST P-256, P-384, P-521 and secp256k1.
/// Uses RFC 6979 deterministic nonce generation for signing.
/// </para>
/// </remarks>
public sealed class EcDsaManaged : ECDsa
{
    private ECParameters? _params;
    private WeierstrassCurve? _curve;

    /// <summary>
    /// Initializes a new <see cref="EcDsaManaged"/> with P-256.
    /// </summary>
    public EcDsaManaged() : this(ECCurve.NamedCurves.nistP256)
    {
    }

    /// <summary>
    /// Initializes a new <see cref="EcDsaManaged"/> with the specified curve.
    /// </summary>
    /// <param name="curve">The elliptic curve to use.</param>
    public EcDsaManaged(ECCurve curve)
    {
        KeySizeValue = GetKeySize(curve);
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
        {
            result.D = (byte[])_params.Value.D.Clone();
        }

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
        var resolved = ResolveCurve(curve);
        using var tmp = ECDsa.Create(curve);
        var p = tmp.ExportParameters(true);
        _curve = resolved;
        _params = p;
        KeySizeValue = resolved.FieldBits;
    }

    /// <inheritdoc />
    public override byte[] SignHash(byte[] hash)
    {
        if (_params is null || _params.Value.D is null)
            throw new CryptographicException("Private key required for signing.");

        var hashAlg = KeySizeValue switch
        {
            256 => HashAlgorithmName.SHA256,
            384 => HashAlgorithmName.SHA384,
            >= 512 => HashAlgorithmName.SHA512,
            _ => HashAlgorithmName.SHA256
        };

        var (r, s) = EcDsaCore.Sign(hash, _params.Value.D, _curve!, hashAlg);

        // Encode as IEEE P1363 format: r || s (fixed-size)
        int fs = _curve!.FieldSize;
        byte[] signature = new byte[fs * 2];
        PadCopyTo(r, signature.AsSpan(0, fs));
        PadCopyTo(s, signature.AsSpan(fs, fs));
        return signature;
    }

    /// <inheritdoc />
    public override bool VerifyHash(byte[] hash, byte[] signature)
    {
        if (_params is null)
            throw new CryptographicException("Key required for verification.");

        int fs = _curve!.FieldSize;
        if (signature.Length != fs * 2)
            return false;

        byte[] r = signature[..fs];
        byte[] s = signature[fs..];

        return EcDsaCore.Verify(
            hash, r, s,
            PadLeft(_params.Value.Q.X!, fs),
            PadLeft(_params.Value.Q.Y!, fs),
            _curve!);
    }

    /// <inheritdoc />
    protected override byte[] HashData(byte[] data, int offset, int count, HashAlgorithmName hashAlgorithm)
    {
        using var hasher = IncrementalHash.CreateHash(hashAlgorithm);
        hasher.AppendData(data, offset, count);
        return hasher.GetHashAndReset();
    }

    /// <inheritdoc />
    protected override byte[] HashData(System.IO.Stream data, HashAlgorithmName hashAlgorithm)
    {
        using var hasher = IncrementalHash.CreateHash(hashAlgorithm);
        byte[] buffer = new byte[4096];
        int read;
        while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
        {
            hasher.AppendData(buffer, 0, read);
        }

        return hasher.GetHashAndReset();
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static WeierstrassCurve ResolveCurve(ECCurve curve)
    {
        string? oid = curve.Oid?.Value;
        return oid switch
        {
            "1.2.840.10045.3.1.7" => WeierstrassCurve.P256,  // P-256
            "1.3.132.0.34" => WeierstrassCurve.P384,         // P-384
            "1.3.132.0.35" => WeierstrassCurve.P521,         // P-521
            "1.3.132.0.10" => WeierstrassCurve.Secp256k1,    // secp256k1
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

    private static int GetKeySize(ECCurve curve)
    {
        try
        {
            return ResolveCurve(curve).FieldBits;
        }
        catch
        {
            return 256;
        }
    }

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

#endif
