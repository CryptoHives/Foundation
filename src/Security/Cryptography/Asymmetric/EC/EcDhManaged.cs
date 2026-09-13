// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET462 || NETSTANDARD2_0
namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// A fully managed ECDH implementation that inherits from <see cref="ECDiffieHellman"/>
/// for drop-in compatibility with the .NET BCL cryptography API.
/// </summary>
public sealed class EcDhManaged : ECDiffieHellman
{
    private WeierstrassCurve? _curve;
    private byte[]? _privateKey;
    private byte[]? _publicKeyX;
    private byte[]? _publicKeyY;

    /// <summary>
    /// Initializes a new <see cref="EcDhManaged"/> with P-256.
    /// </summary>
    public EcDhManaged()
    {
        GenerateKeyPair(WeierstrassCurve.P256);
    }

#if NETSTANDARD2_0
    /// <summary>
    /// Initializes a new <see cref="EcDhManaged"/> with the specified curve.
    /// </summary>
    /// <param name="curve">The elliptic curve to use.</param>
    public EcDhManaged(ECCurve curve)
    {
        GenerateKey(curve);
    }
#endif

    /// <inheritdoc />
    public override string KeyExchangeAlgorithm => "ECDH";

    /// <inheritdoc />
    public override string SignatureAlgorithm => "ECDH";

    /// <inheritdoc />
    public override ECDiffieHellmanPublicKey PublicKey
    {
        get
        {
            EnsurePublicKey();
            return new EcDhManagedPublicKey((byte[])_publicKeyX!.Clone(), (byte[])_publicKeyY!.Clone(), _curve!.Name);
        }
    }

#if NETSTANDARD2_0
    /// <inheritdoc />
    public override void GenerateKey(ECCurve curve)
    {
        GenerateKeyPair(ResolveCurve(curve));
    }
#endif

    /// <inheritdoc />
    public override byte[] DeriveKeyMaterial(ECDiffieHellmanPublicKey otherPartyPublicKey)
    {
        return DeriveSharedSecret(otherPartyPublicKey);
    }

    /// <inheritdoc />
    public override byte[] DeriveKeyFromHash(
        ECDiffieHellmanPublicKey otherPartyPublicKey,
        HashAlgorithmName hashAlgorithm,
        byte[]? secretPrepend,
        byte[]? secretAppend)
    {
        byte[] secret = DeriveSharedSecret(otherPartyPublicKey);
        byte[] data = Concat(secretPrepend, secret, secretAppend);

        using HashAlgorithm hasher = CreateHashAlgorithm(hashAlgorithm);
        return hasher.ComputeHash(data);
    }

    /// <inheritdoc />
    public override byte[] DeriveKeyFromHmac(
        ECDiffieHellmanPublicKey otherPartyPublicKey,
        HashAlgorithmName hashAlgorithm,
        byte[]? hmacKey,
        byte[]? secretPrepend,
        byte[]? secretAppend)
    {
        byte[] secret = DeriveSharedSecret(otherPartyPublicKey);
        byte[] data = Concat(secretPrepend, secret, secretAppend);

        using HMAC hmac = CreateHmac(hashAlgorithm, hmacKey ?? Array.Empty<byte>());
        return hmac.ComputeHash(data);
    }

    /// <inheritdoc />
    public override byte[] DeriveKeyTls(ECDiffieHellmanPublicKey otherPartyPublicKey, byte[] prfLabel, byte[] prfSeed)
    {
        if (prfLabel is null) throw new ArgumentNullException(nameof(prfLabel));
        if (prfSeed is null) throw new ArgumentNullException(nameof(prfSeed));

        byte[] secret = DeriveSharedSecret(otherPartyPublicKey);
        return PHash(secret, Concat(prfLabel, prfSeed), 48);
    }

#if NETSTANDARD2_0
    /// <summary>
    /// Derives the raw shared secret from the private key and the other party's public key.
    /// </summary>
    /// <param name="otherPartyPublicKey">The other party's public key parameters.</param>
    /// <returns>The shared secret X coordinate (big-endian bytes).</returns>
    public byte[] DeriveRawSecretAgreement(ECParameters otherPartyPublicKey)
    {
        return DeriveRawSecretAgreement(otherPartyPublicKey.Q.X!, otherPartyPublicKey.Q.Y!);
    }
#endif

    /// <summary>
    /// Derives the raw shared secret from the private key and the other party's public key coordinates.
    /// </summary>
    /// <param name="otherPublicKeyX">The other party's public key X coordinate.</param>
    /// <param name="otherPublicKeyY">The other party's public key Y coordinate.</param>
    /// <returns>The shared secret X coordinate (big-endian bytes).</returns>
    public byte[] DeriveRawSecretAgreement(byte[] otherPublicKeyX, byte[] otherPublicKeyY)
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
    protected override void Dispose(bool disposing)
    {
        if (disposing && _privateKey is not null)
        {
            Array.Clear(_privateKey, 0, _privateKey.Length);
            _privateKey = null;
        }

        base.Dispose(disposing);
    }

    private void GenerateKeyPair(WeierstrassCurve curve)
    {
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        var ec = new EcMath(curve);

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
        KeySizeValue = curve.FieldBits;
    }

    private byte[] DeriveSharedSecret(ECDiffieHellmanPublicKey otherPartyPublicKey)
    {
        if (otherPartyPublicKey is null) throw new ArgumentNullException(nameof(otherPartyPublicKey));
        if (_privateKey is null || _curve is null)
            throw new CryptographicException("Private key required.");

        if (otherPartyPublicKey is not EcDhManagedPublicKey key)
            throw new CryptographicException("Unsupported public key type.");

        if (!string.Equals(key.CurveName, _curve.Name, StringComparison.Ordinal))
            throw new CryptographicException("Curve mismatch.");

        return DeriveRawSecretAgreement(key.X, key.Y);
    }

#if NETSTANDARD2_0
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
            "nistP256" or "ECDH_P256" or "ECDSA_P256" => WeierstrassCurve.P256,
            "nistP384" or "ECDH_P384" or "ECDSA_P384" => WeierstrassCurve.P384,
            "nistP521" or "ECDH_P521" or "ECDSA_P521" => WeierstrassCurve.P521,
            "secP256k1" => WeierstrassCurve.Secp256k1,
            "brainpoolP256r1" => WeierstrassCurve.BrainpoolP256r1,
            "brainpoolP384r1" => WeierstrassCurve.BrainpoolP384r1,
            "brainpoolP512r1" => WeierstrassCurve.BrainpoolP512r1,
            _ => throw new CryptographicException($"Unsupported curve: {name}")
        };
    }
#endif

    private void EnsurePublicKey()
    {
        if (_publicKeyX is null || _publicKeyY is null || _curve is null)
            throw new CryptographicException("No key has been generated.");
    }

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }

    private static byte[] Concat(byte[]? a, byte[] b, byte[]? c = null)
    {
        int al = a?.Length ?? 0;
        int cl = c?.Length ?? 0;
        byte[] result = new byte[al + b.Length + cl];
        if (a is not null) Buffer.BlockCopy(a, 0, result, 0, al);
        Buffer.BlockCopy(b, 0, result, al, b.Length);
        if (c is not null) Buffer.BlockCopy(c, 0, result, al + b.Length, cl);
        return result;
    }

    private static HashAlgorithm CreateHashAlgorithm(HashAlgorithmName hashAlgorithm)
    {
        string? name = hashAlgorithm.Name;
        if (string.IsNullOrEmpty(name)) throw new CryptographicException("Hash algorithm name is required.");

        HashAlgorithm? hash = HashAlgorithm.Create(name);
        if (hash is null) throw new CryptographicException($"Unsupported hash algorithm: {name}");
        return hash;
    }

    private static HMAC CreateHmac(HashAlgorithmName hashAlgorithm, byte[] key)
    {
        string? name = hashAlgorithm.Name;
        if (string.IsNullOrEmpty(name)) throw new CryptographicException("Hash algorithm name is required.");

        return name.ToUpperInvariant() switch
        {
            "SHA1" => new HMACSHA1(key),
            "SHA256" => new HMACSHA256(key),
            "SHA384" => new HMACSHA384(key),
            "SHA512" => new HMACSHA512(key),
            "MD5" => new HMACMD5(key),
            _ => throw new CryptographicException($"Unsupported HMAC algorithm: {name}")
        };
    }

    private static byte[] PHash(byte[] secret, byte[] seed, int outputLength)
    {
        byte[] result = new byte[outputLength];

        using var hmac = new HMACSHA256(secret);
        byte[] a = hmac.ComputeHash(seed);

        int offset = 0;
        while (offset < outputLength)
        {
            byte[] input = Concat(a, seed);
            byte[] block = hmac.ComputeHash(input);
            int toCopy = Math.Min(block.Length, outputLength - offset);
            Buffer.BlockCopy(block, 0, result, offset, toCopy);
            offset += toCopy;
            a = hmac.ComputeHash(a);
        }

        return result;
    }

    private sealed class EcDhManagedPublicKey : ECDiffieHellmanPublicKey
    {
        public EcDhManagedPublicKey(byte[] x, byte[] y, string curveName) : base(EncodeBlob(x, y, curveName))
        {
            X = x;
            Y = y;
            CurveName = curveName;
        }

        public byte[] X { get; }

        public byte[] Y { get; }

        public string CurveName { get; }

        public override byte[] ToByteArray()
        {
            return EncodeBlob(X, Y, CurveName);
        }

        public override string ToXmlString()
        {
            return Convert.ToBase64String(ToByteArray());
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private static byte[] EncodeBlob(byte[] x, byte[] y, string curveName)
        {
            byte[] curveBytes = Encoding.ASCII.GetBytes(curveName);
            byte[] blob = new byte[4 + curveBytes.Length + 4 + x.Length + 4 + y.Length];
            int o = 0;

            WriteInt(blob, ref o, curveBytes.Length);
            Buffer.BlockCopy(curveBytes, 0, blob, o, curveBytes.Length);
            o += curveBytes.Length;

            WriteInt(blob, ref o, x.Length);
            Buffer.BlockCopy(x, 0, blob, o, x.Length);
            o += x.Length;

            WriteInt(blob, ref o, y.Length);
            Buffer.BlockCopy(y, 0, blob, o, y.Length);

            return blob;
        }

        private static void WriteInt(byte[] buffer, ref int offset, int value)
        {
            buffer[offset++] = (byte)(value >> 24);
            buffer[offset++] = (byte)(value >> 16);
            buffer[offset++] = (byte)(value >> 8);
            buffer[offset++] = (byte)value;
        }
    }
}
#else
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
    public byte[] DeriveRawSecretAgreement(ECParameters otherPartyPublicKey)
    {
        if (_params is null || _params.Value.D is null)
            throw new CryptographicException("Private key required.");

        var ec = new EcMath(_curve!);
        int n = _curve!.LimbCount;
        int fs = _curve.FieldSize;

        byte[] qx = PadLeft(otherPartyPublicKey.Q.X!, fs);
        byte[] qy = PadLeft(otherPartyPublicKey.Q.Y!, fs);

        if (!ec.IsOnCurve(qx, qy))
            throw new CryptographicException("Other party's public key is not on the curve.");

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
