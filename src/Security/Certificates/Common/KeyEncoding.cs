// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates;

#if !BCL_CERTIFICATES || (BCL_CERTIFICATES && NET472_OR_GREATER)

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
#if !BCL_CERTIFICATES
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using CH = CryptoHives.Foundation.Security.Cryptography;
#endif

/// <summary>
/// Provides ASN.1 DER encoding and decoding for asymmetric key types
/// including RSA (PKCS#1 RFC 8017, SPKI RFC 5280, PKCS#8 RFC 5958),
/// EC Weierstrass (RFC 5915), and Edwards/Montgomery curves (RFC 8410).
/// </summary>
internal static class KeyEncoding
{
    internal const string OidRsa = "1.2.840.113549.1.1.1";
    internal const string OidEcPublicKey = "1.2.840.10045.2.1";
    internal const string OidP256 = "1.2.840.10045.3.1.7";
    internal const string OidP384 = "1.3.132.0.34";
    internal const string OidP521 = "1.3.132.0.35";
    internal const string OidSecp256k1 = "1.3.132.0.10";
    internal const string OidBrainpoolP256r1 = "1.3.36.3.3.2.8.1.1.7";
    internal const string OidBrainpoolP384r1 = "1.3.36.3.3.2.8.1.1.11";
    internal const string OidBrainpoolP512r1 = "1.3.36.3.3.2.8.1.1.13";
    internal const string OidEd25519 = "1.3.101.112";
    internal const string OidEd448 = "1.3.101.113";
    internal const string OidX25519 = "1.3.101.110";
    internal const string OidX448 = "1.3.101.111";

#if !BCL_CERTIFICATES
    // ========================================================================
    // RSA PKCS#1 (RFC 8017)
    // ========================================================================

    /// <summary>
    /// Exports an RSA public key in PKCS#1 RSAPublicKey DER format.
    /// </summary>
    /// <param name="key">The RSA key parameters containing at least the modulus and public exponent.</param>
    /// <returns>The DER-encoded PKCS#1 RSAPublicKey structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
    public static byte[] ExportRsaPublicKey(RsaKeyParameters key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteIntegerUnsigned(key.Modulus);
        writer.WriteIntegerUnsigned(key.PublicExponent);
        writer.PopSequence();
        return writer.Encode();
    }

    /// <summary>
    /// Imports an RSA public key from PKCS#1 RSAPublicKey DER format.
    /// </summary>
    /// <param name="source">The DER-encoded PKCS#1 RSAPublicKey bytes.</param>
    /// <returns>The imported <see cref="RsaKeyParameters"/> containing the modulus and public exponent.</returns>
    /// <exception cref="CryptographicException">The data is not valid DER or does not represent a valid RSA public key.</exception>
    public static RsaKeyParameters ImportRsaPublicKey(ReadOnlySpan<byte> source)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        byte[] modulus = ReadUnsignedInteger(seq);
        byte[] publicExponent = ReadUnsignedInteger(seq);
        seq.ThrowIfNotEmpty();
        return new RsaKeyParameters(modulus, publicExponent);
    }

    /// <summary>
    /// Exports an RSA private key in PKCS#1 RSAPrivateKey DER format.
    /// </summary>
    /// <param name="key">The RSA key parameters containing all private key components.</param>
    /// <returns>The DER-encoded PKCS#1 RSAPrivateKey structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">The key does not contain private key material.</exception>
    public static byte[] ExportRsaPrivateKey(RsaKeyParameters key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (!key.HasPrivateKey) throw new InvalidOperationException("Key does not contain private key material.");

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteInteger(0);
        writer.WriteIntegerUnsigned(key.Modulus);
        writer.WriteIntegerUnsigned(key.PublicExponent);
        writer.WriteIntegerUnsigned(key.PrivateExponent!);
        writer.WriteIntegerUnsigned(key.P!);
        writer.WriteIntegerUnsigned(key.Q!);
        writer.WriteIntegerUnsigned(key.Dp!);
        writer.WriteIntegerUnsigned(key.Dq!);
        writer.WriteIntegerUnsigned(key.QInv!);
        writer.PopSequence();
        return writer.Encode();
    }

    /// <summary>
    /// Imports an RSA private key from PKCS#1 RSAPrivateKey DER format.
    /// </summary>
    /// <param name="source">The DER-encoded PKCS#1 RSAPrivateKey bytes.</param>
    /// <returns>The imported <see cref="RsaKeyParameters"/> containing all RSA components.</returns>
    /// <exception cref="CryptographicException">The data is not valid DER or does not represent a valid RSA private key.</exception>
    public static RsaKeyParameters ImportRsaPrivateKey(ReadOnlySpan<byte> source)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        seq.ReadInteger(); // version
        byte[] modulus = ReadUnsignedInteger(seq);
        byte[] publicExponent = ReadUnsignedInteger(seq);
        byte[] privateExponent = ReadUnsignedInteger(seq);
        byte[] p = ReadUnsignedInteger(seq);
        byte[] q = ReadUnsignedInteger(seq);
        byte[] dp = ReadUnsignedInteger(seq);
        byte[] dq = ReadUnsignedInteger(seq);
        byte[] qInv = ReadUnsignedInteger(seq);
        seq.ThrowIfNotEmpty();
        return new RsaKeyParameters(modulus, publicExponent, privateExponent, p, q, dp, dq, qInv);
    }
#endif

    // ========================================================================
    // EC Weierstrass (RFC 5915)
    // ========================================================================

    /// <summary>
    /// Exports an EC private key in SEC 1 ECPrivateKey DER format (RFC 5915).
    /// </summary>
    /// <param name="d">The private key scalar as big-endian bytes.</param>
    /// <param name="qx">The public key x-coordinate as big-endian bytes.</param>
    /// <param name="qy">The public key y-coordinate as big-endian bytes.</param>
    /// <param name="oid">The named curve OID (e.g., "1.2.840.10045.3.1.7" for P-256).</param>
    /// <returns>The DER-encoded ECPrivateKey structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oid"/> is <c>null</c>.</exception>
    public static byte[] ExportEcPrivateKey(
        ReadOnlySpan<byte> d,
        ReadOnlySpan<byte> qx,
        ReadOnlySpan<byte> qy,
        string oid)
    {
        if (oid is null) throw new ArgumentNullException(nameof(oid));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteInteger(1);
        writer.WriteOctetString(d);

        // [0] EXPLICIT parameters
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.WriteObjectIdentifier(oid);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));

        // [1] EXPLICIT publicKey
        WriteEcPublicKeyBitString(writer, qx, qy);

        writer.PopSequence();
        return writer.Encode();
    }

    /// <summary>
    /// Imports an EC private key from SEC 1 ECPrivateKey DER format (RFC 5915).
    /// </summary>
    /// <param name="source">The DER-encoded ECPrivateKey bytes.</param>
    /// <param name="oid">When this method returns, contains the named curve OID, or an empty string if absent.</param>
    /// <returns>A tuple of the private key scalar <c>d</c> and optional public key coordinates <c>qx</c>, <c>qy</c>.</returns>
    /// <exception cref="CryptographicException">The data is not valid DER or does not represent a valid EC private key.</exception>
    public static (byte[] d, byte[]? qx, byte[]? qy) ImportEcPrivateKey(
        ReadOnlySpan<byte> source,
        out string oid)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        seq.ReadInteger(); // version (1)
        byte[] d = seq.ReadOctetString();

        oid = string.Empty;
        byte[]? qx = null;
        byte[]? qy = null;

        var ctxTag0 = new Asn1Tag(TagClass.ContextSpecific, 0);
        if (seq.HasData && seq.PeekTag().HasSameClassAndValue(ctxTag0))
        {
            var paramsReader = seq.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
            oid = paramsReader.ReadObjectIdentifier();
            paramsReader.ThrowIfNotEmpty();
        }

        var ctxTag1 = new Asn1Tag(TagClass.ContextSpecific, 1);
        if (seq.HasData && seq.PeekTag().HasSameClassAndValue(ctxTag1))
        {
            var pubReader = seq.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
            byte[] pubPoint = pubReader.ReadBitString(out int unusedBits);
            if (unusedBits != 0 || pubPoint.Length < 3 || pubPoint[0] != 0x04)
                throw new CryptographicException("Invalid or unsupported EC public key format.");
            int coordLen = (pubPoint.Length - 1) / 2;
            qx = new byte[coordLen];
            Buffer.BlockCopy(pubPoint, 1, qx, 0, coordLen);
            qy = new byte[pubPoint.Length - 1 - coordLen];
            Buffer.BlockCopy(pubPoint, 1 + coordLen, qy, 0, qy.Length);
            pubReader.ThrowIfNotEmpty();
        }

        return (d, qx, qy);
    }

    // ========================================================================
    // Edwards / Montgomery Curves (RFC 8410)
    // ========================================================================

    /// <summary>
    /// Exports an EdDSA or Montgomery curve public key as SPKI DER (RFC 8410).
    /// </summary>
    /// <param name="publicKey">The raw public key bytes.</param>
    /// <param name="oid">The algorithm OID (e.g., "1.3.101.112" for Ed25519).</param>
    /// <returns>The DER-encoded SubjectPublicKeyInfo structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oid"/> is <c>null</c>.</exception>
    public static byte[] ExportEdPublicKey(ReadOnlySpan<byte> publicKey, string oid)
    {
        if (oid is null) throw new ArgumentNullException(nameof(oid));
        return ExportSubjectPublicKeyInfo(oid, null, publicKey);
    }

    /// <summary>
    /// Imports an EdDSA or Montgomery curve public key from SPKI DER (RFC 8410).
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo bytes.</param>
    /// <param name="oid">When this method returns, contains the algorithm OID.</param>
    /// <returns>The raw public key bytes.</returns>
    /// <exception cref="CryptographicException">The data is not valid SPKI DER.</exception>
    public static byte[] ImportEdPublicKey(ReadOnlySpan<byte> source, out string oid)
    {
        byte[] publicKey = ImportSubjectPublicKeyInfo(source, out string algorithmOid, out _);
        oid = algorithmOid;
        return publicKey;
    }

    /// <summary>
    /// Exports an EdDSA or Montgomery curve private key as PKCS#8 DER (RFC 8410).
    /// </summary>
    /// <remarks>
    /// The private key is encoded as a PKCS#8 PrivateKeyInfo where the
    /// <c>privateKey</c> OCTET STRING contains a nested OCTET STRING holding the raw seed.
    /// </remarks>
    /// <param name="seed">The raw private key seed bytes.</param>
    /// <param name="oid">The algorithm OID (e.g., "1.3.101.112" for Ed25519).</param>
    /// <returns>The DER-encoded PKCS#8 PrivateKeyInfo structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oid"/> is <c>null</c>.</exception>
    public static byte[] ExportEdPrivateKey(ReadOnlySpan<byte> seed, string oid)
    {
        if (oid is null) throw new ArgumentNullException(nameof(oid));

        var innerWriter = new AsnWriter(AsnEncodingRules.DER);
        innerWriter.WriteOctetString(seed);
        return ExportPkcs8PrivateKey(oid, null, innerWriter.Encode());
    }

    /// <summary>
    /// Imports an EdDSA or Montgomery curve private key from PKCS#8 DER (RFC 8410).
    /// </summary>
    /// <param name="source">The DER-encoded PKCS#8 PrivateKeyInfo bytes.</param>
    /// <param name="oid">When this method returns, contains the algorithm OID.</param>
    /// <returns>The raw private key seed bytes.</returns>
    /// <exception cref="CryptographicException">The data is not valid PKCS#8 DER.</exception>
    public static byte[] ImportEdPrivateKey(ReadOnlySpan<byte> source, out string oid)
    {
        byte[] privateKeyDer = ImportPkcs8PrivateKey(source, out string algorithmOid, out _);
        oid = algorithmOid;

        var reader = new AsnReader(privateKeyDer, AsnEncodingRules.DER);
        byte[] seed = reader.ReadOctetString();
        reader.ThrowIfNotEmpty();
        return seed;
    }

    // ========================================================================
    // Generic SPKI / PKCS#8
    // ========================================================================

    /// <summary>
    /// Exports a SubjectPublicKeyInfo (SPKI) DER structure (RFC 5280).
    /// </summary>
    /// <remarks>
    /// The AlgorithmIdentifier is constructed as follows:
    /// RSA — OID + NULL; EC — OID + curve OID; EdDSA/X25519/X448 — OID only (no parameters).
    /// </remarks>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="curveOid">The named curve OID for EC keys, or <c>null</c>.</param>
    /// <param name="publicKeyBytes">The algorithm-specific public key bytes.</param>
    /// <returns>The DER-encoded SubjectPublicKeyInfo structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithmOid"/> is <c>null</c>.</exception>
    public static byte[] ExportSubjectPublicKeyInfo(
        string algorithmOid,
        string? curveOid,
        ReadOnlySpan<byte> publicKeyBytes)
    {
        if (algorithmOid is null) throw new ArgumentNullException(nameof(algorithmOid));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        WriteAlgorithmIdentifier(writer, algorithmOid, curveOid);
        writer.WriteBitString(publicKeyBytes);
        writer.PopSequence();
        return writer.Encode();
    }

    /// <summary>
    /// Imports a SubjectPublicKeyInfo (SPKI) DER structure (RFC 5280).
    /// </summary>
    /// <param name="source">The DER-encoded SubjectPublicKeyInfo bytes.</param>
    /// <param name="algorithmOid">When this method returns, contains the algorithm OID.</param>
    /// <param name="curveOid">When this method returns, contains the named curve OID, or <c>null</c>.</param>
    /// <returns>The algorithm-specific public key bytes.</returns>
    /// <exception cref="CryptographicException">The data is not valid SPKI DER.</exception>
    public static byte[] ImportSubjectPublicKeyInfo(
        ReadOnlySpan<byte> source,
        out string algorithmOid,
        out string? curveOid)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        ReadAlgorithmIdentifier(seq, out algorithmOid, out curveOid);
        byte[] publicKeyBytes = seq.ReadBitString(out int unusedBits);
        if (unusedBits != 0)
            throw new CryptographicException("Invalid public key bit string: non-zero unused bits.");
        seq.ThrowIfNotEmpty();
        return publicKeyBytes;
    }

    /// <summary>
    /// Exports a PKCS#8 PrivateKeyInfo DER structure (RFC 5958).
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="curveOid">The named curve OID for EC keys, or <c>null</c>.</param>
    /// <param name="privateKeyDer">The algorithm-specific private key DER bytes.</param>
    /// <returns>The DER-encoded PKCS#8 PrivateKeyInfo structure.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithmOid"/> is <c>null</c>.</exception>
    public static byte[] ExportPkcs8PrivateKey(
        string algorithmOid,
        string? curveOid,
        ReadOnlySpan<byte> privateKeyDer)
    {
        if (algorithmOid is null) throw new ArgumentNullException(nameof(algorithmOid));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteInteger(0);
        WriteAlgorithmIdentifier(writer, algorithmOid, curveOid);
        writer.WriteOctetString(privateKeyDer);
        writer.PopSequence();
        return writer.Encode();
    }

    /// <summary>
    /// Imports a PKCS#8 PrivateKeyInfo DER structure (RFC 5958).
    /// </summary>
    /// <param name="source">The DER-encoded PKCS#8 PrivateKeyInfo bytes.</param>
    /// <param name="algorithmOid">When this method returns, contains the algorithm OID.</param>
    /// <param name="curveOid">When this method returns, contains the named curve OID, or <c>null</c>.</param>
    /// <returns>The algorithm-specific private key DER bytes.</returns>
    /// <exception cref="CryptographicException">The data is not valid PKCS#8 DER.</exception>
    public static byte[] ImportPkcs8PrivateKey(
        ReadOnlySpan<byte> source,
        out string algorithmOid,
        out string? curveOid)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        seq.ReadInteger(); // version
        ReadAlgorithmIdentifier(seq, out algorithmOid, out curveOid);
        byte[] privateKeyDer = seq.ReadOctetString();
        seq.ThrowIfNotEmpty();
        return privateKeyDer;
    }

    // ========================================================================
    // PEM (RFC 7468)
    // ========================================================================

    /// <summary>
    /// Exports DER-encoded data as a PEM string with the specified label.
    /// </summary>
    /// <param name="der">The DER-encoded data to wrap.</param>
    /// <param name="label">The PEM label (e.g., "PUBLIC KEY", "PRIVATE KEY", "RSA PUBLIC KEY").</param>
    /// <returns>The PEM-encoded string.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="label"/> is <c>null</c>.</exception>
    public static string ExportPem(ReadOnlySpan<byte> der, string label)
    {
        if (label is null) throw new ArgumentNullException(nameof(label));
        return PemHelper.Encode(der, label);
    }

    /// <summary>
    /// Imports a PEM-encoded string and returns the DER-encoded data.
    /// </summary>
    /// <param name="pem">The PEM-encoded string to parse.</param>
    /// <param name="label">When this method returns, contains the PEM label.</param>
    /// <returns>The DER-encoded data extracted from the PEM block.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pem"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">The string does not contain a valid PEM block.</exception>
    public static byte[] ImportPem(string pem, out string label)
    {
        if (pem is null) throw new ArgumentNullException(nameof(pem));

        return PemHelper.Decode(pem, out label);
    }

    // ========================================================================
    // Encrypted PKCS#8 (RFC 5958 + RFC 8018)
    // ========================================================================

    private const string OidPbes2 = "1.2.840.113549.1.5.13";
    private const string OidPbkdf2 = "1.2.840.113549.1.5.12";
    private const string OidAes256Cbc = "2.16.840.1.101.3.4.1.42";
    private const string OidAes128Cbc = "2.16.840.1.101.3.4.1.2";
    private const string OidHmacWithSha256 = "1.2.840.113549.2.9";
    private const string OidHmacWithSha1 = "1.2.840.113549.2.7";

#if !BCL_CERTIFICATES
    /// <summary>
    /// Exports a PKCS#8 PrivateKeyInfo as an EncryptedPrivateKeyInfo DER structure (RFC 5958).
    /// </summary>
    /// <remarks>
    /// Uses PBES2 with PBKDF2-HMAC-SHA256 key derivation and AES-256-CBC encryption.
    /// </remarks>
    /// <param name="pkcs8Der">The unencrypted PKCS#8 PrivateKeyInfo DER bytes.</param>
    /// <param name="password">The password used for key derivation.</param>
    /// <param name="iterations">The PBKDF2 iteration count (default 600,000).</param>
    /// <returns>The DER-encoded EncryptedPrivateKeyInfo structure.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="iterations"/> is less than 1.</exception>
    public static byte[] ExportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> pkcs8Der,
        ReadOnlySpan<byte> password,
        int iterations = 600_000)
    {
        if (iterations < 1) throw new ArgumentOutOfRangeException(nameof(iterations));

        byte[] salt = new byte[16];
        byte[] iv = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
            rng.GetBytes(iv);
        }

        byte[] derivedKey = new byte[32];
        Pbkdf2.DeriveKey(key => new HmacSha256(key), password, salt, iterations, derivedKey);

        byte[] encrypted;
        using (var aes = Aes256.Create())
        {
            aes.Key = derivedKey;
            aes.IV = iv;
            aes.Mode = CH.Cipher.CipherMode.CBC;
            aes.Padding = CH.Cipher.PaddingMode.PKCS7;
            encrypted = aes.Encrypt(pkcs8Der);
        }

        return EncodeEncryptedPrivateKeyInfo(salt, iterations, iv, encrypted);
    }

    /// <summary>
    /// Imports an EncryptedPrivateKeyInfo DER structure and decrypts the contained PKCS#8 private key.
    /// </summary>
    /// <param name="source">The DER-encoded EncryptedPrivateKeyInfo bytes.</param>
    /// <param name="password">The password used for key derivation.</param>
    /// <param name="algorithmOid">When this method returns, contains the algorithm OID of the decrypted key.</param>
    /// <param name="curveOid">When this method returns, contains the named curve OID, or <c>null</c>.</param>
    /// <returns>The algorithm-specific private key DER bytes.</returns>
    /// <exception cref="CryptographicException">
    /// The data is not valid EncryptedPrivateKeyInfo DER, the encryption scheme is not supported,
    /// or the password is incorrect.
    /// </exception>
    public static byte[] ImportEncryptedPkcs8PrivateKey(
        ReadOnlySpan<byte> source,
        ReadOnlySpan<byte> password,
        out string algorithmOid,
        out string? curveOid)
    {
        DecodeEncryptedPrivateKeyInfo(source, out byte[] salt, out int iterations,
            out string prfOid, out int keyLength, out string encOid, out byte[] iv, out byte[] encryptedData);

        HmacFactory hmacFactory = prfOid switch
        {
            OidHmacWithSha256 => key => new HmacSha256(key),
#pragma warning disable CS0618 // HmacSha1 is obsolete but needed for legacy PKCS#8 import
            OidHmacWithSha1 => key => new HmacSha1(key),
#pragma warning restore CS0618
            _ => throw new CryptographicException($"Unsupported PRF OID: {prfOid}"),
        };

        int derivedKeyLen = encOid switch
        {
            OidAes256Cbc => 32,
            OidAes128Cbc => 16,
            _ => throw new CryptographicException($"Unsupported encryption OID: {encOid}"),
        };

        if (keyLength > 0 && keyLength != derivedKeyLen)
            throw new CryptographicException("PBKDF2 key length does not match cipher requirement.");

        byte[] derivedKey = new byte[derivedKeyLen];
        Pbkdf2.DeriveKey(hmacFactory, password, salt, iterations, derivedKey);

        byte[] pkcs8Der;
        try
        {
            using var aes = derivedKeyLen == 32 ? (SymmetricCipher)Aes256.Create() : Aes128.Create();
            aes.Key = derivedKey;
            aes.IV = iv;
            aes.Mode = CH.Cipher.CipherMode.CBC;
            aes.Padding = CH.Cipher.PaddingMode.PKCS7;
            pkcs8Der = aes.Decrypt(encryptedData);
        }
        catch (Exception ex) when (ex is not CryptographicException)
        {
            throw new CryptographicException("Failed to decrypt private key. The password may be incorrect.", ex);
        }

        return ImportPkcs8PrivateKey(pkcs8Der, out algorithmOid, out curveOid);
    }

    // ========================================================================
    // Encrypted PEM (RFC 7468)
    // ========================================================================

    /// <summary>
    /// Exports a PKCS#8 PrivateKeyInfo as an encrypted PEM string with the
    /// "ENCRYPTED PRIVATE KEY" label.
    /// </summary>
    /// <param name="pkcs8Der">The unencrypted PKCS#8 PrivateKeyInfo DER bytes.</param>
    /// <param name="password">The password used for key derivation.</param>
    /// <param name="iterations">The PBKDF2 iteration count (default 600,000).</param>
    /// <returns>The PEM-encoded encrypted private key string.</returns>
    public static string ExportEncryptedPem(
        ReadOnlySpan<byte> pkcs8Der,
        ReadOnlySpan<byte> password,
        int iterations = 600_000)
    {
        byte[] encryptedDer = ExportEncryptedPkcs8PrivateKey(pkcs8Der, password, iterations);
        return PemHelper.Encode(encryptedDer, "ENCRYPTED PRIVATE KEY");
    }

    /// <summary>
    /// Imports an encrypted PEM string with the "ENCRYPTED PRIVATE KEY" label
    /// and decrypts the contained PKCS#8 private key.
    /// </summary>
    /// <param name="pem">The PEM-encoded encrypted private key string.</param>
    /// <param name="password">The password used for key derivation.</param>
    /// <param name="algorithmOid">When this method returns, contains the algorithm OID of the decrypted key.</param>
    /// <param name="curveOid">When this method returns, contains the named curve OID, or <c>null</c>.</param>
    /// <returns>The algorithm-specific private key DER bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pem"/> is <c>null</c>.</exception>
    /// <exception cref="CryptographicException">
    /// The PEM label is not "ENCRYPTED PRIVATE KEY" or decryption fails.
    /// </exception>
    public static byte[] ImportEncryptedPem(
        string pem,
        ReadOnlySpan<byte> password,
        out string algorithmOid,
        out string? curveOid)
    {
        if (pem is null) throw new ArgumentNullException(nameof(pem));

        byte[] der = PemHelper.Decode(pem, out string label);
        if (!string.Equals(label, "ENCRYPTED PRIVATE KEY", StringComparison.Ordinal))
            throw new CryptographicException($"Expected PEM label 'ENCRYPTED PRIVATE KEY', got '{label}'.");

        return ImportEncryptedPkcs8PrivateKey(der, password, out algorithmOid, out curveOid);
    }
#endif

    // ========================================================================
    // Private Helpers
    // ========================================================================

    private static void WriteAlgorithmIdentifier(
        AsnWriter writer, string algorithmOid, string? curveOid)
    {
        writer.PushSequence();
        writer.WriteObjectIdentifier(algorithmOid);

        if (curveOid is not null)
            writer.WriteObjectIdentifier(curveOid);
        else if (algorithmOid == OidRsa)
            writer.WriteNull();

        writer.PopSequence();
    }

    private static void ReadAlgorithmIdentifier(
        AsnReader seq, out string algorithmOid, out string? curveOid)
    {
        var algSeq = seq.ReadSequence();
        algorithmOid = algSeq.ReadObjectIdentifier();
        curveOid = null;

        if (algSeq.HasData)
        {
            Asn1Tag nextTag = algSeq.PeekTag();
            if (nextTag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.Null)))
                algSeq.ReadNull();
            else if (nextTag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.ObjectIdentifier)))
                curveOid = algSeq.ReadObjectIdentifier();
        }

        algSeq.ThrowIfNotEmpty();
    }

    private static byte[] ReadUnsignedInteger(AsnReader reader)
    {
        ReadOnlyMemory<byte> bytes = reader.ReadIntegerBytes();
        ReadOnlySpan<byte> span = bytes.Span;
        if (span.Length > 1 && span[0] == 0)
            return span[1..].ToArray();
        return span.ToArray();
    }

    private static void WriteEcPublicKeyBitString(
        AsnWriter writer, ReadOnlySpan<byte> qx, ReadOnlySpan<byte> qy)
    {
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        qx.CopyTo(pubPoint.AsSpan(1));
        qy.CopyTo(pubPoint.AsSpan(1 + qx.Length));
        writer.WriteBitString(pubPoint);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
    }

    private static byte[] EncodeEncryptedPrivateKeyInfo(
        byte[] salt, int iterations, byte[] iv, byte[] encryptedData)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // EncryptedPrivateKeyInfo

        // encryptionAlgorithm: PBES2
        writer.PushSequence(); // AlgorithmIdentifier
        writer.WriteObjectIdentifier(OidPbes2);
        writer.PushSequence(); // PBES2-params

        // keyDerivationFunc: PBKDF2
        writer.PushSequence(); // AlgorithmIdentifier
        writer.WriteObjectIdentifier(OidPbkdf2);
        writer.PushSequence(); // PBKDF2-params
        writer.WriteOctetString(salt);
        writer.WriteInteger(iterations);
        writer.WriteInteger(32); // keyLength
        writer.PushSequence(); // prf AlgorithmIdentifier
        writer.WriteObjectIdentifier(OidHmacWithSha256);
        writer.WriteNull();
        writer.PopSequence(); // prf
        writer.PopSequence(); // PBKDF2-params
        writer.PopSequence(); // PBKDF2 AlgorithmIdentifier

        // encryptionScheme: AES-256-CBC
        writer.PushSequence(); // AlgorithmIdentifier
        writer.WriteObjectIdentifier(OidAes256Cbc);
        writer.WriteOctetString(iv);
        writer.PopSequence(); // AES-256-CBC AlgorithmIdentifier

        writer.PopSequence(); // PBES2-params
        writer.PopSequence(); // PBES2 AlgorithmIdentifier

        writer.WriteOctetString(encryptedData);
        writer.PopSequence(); // EncryptedPrivateKeyInfo
        return writer.Encode();
    }

    private static void DecodeEncryptedPrivateKeyInfo(
        ReadOnlySpan<byte> source,
        out byte[] salt,
        out int iterations,
        out string prfOid,
        out int keyLength,
        out string encOid,
        out byte[] iv,
        out byte[] encryptedData)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var outer = reader.ReadSequence();

        // encryptionAlgorithm
        var algId = outer.ReadSequence();
        string schemeOid = algId.ReadObjectIdentifier();
        if (schemeOid != OidPbes2)
            throw new CryptographicException($"Unsupported encryption scheme OID: {schemeOid}. Only PBES2 is supported.");

        var pbes2Params = algId.ReadSequence();
        algId.ThrowIfNotEmpty();

        // keyDerivationFunc
        var kdfId = pbes2Params.ReadSequence();
        string kdfOid = kdfId.ReadObjectIdentifier();
        if (kdfOid != OidPbkdf2)
            throw new CryptographicException($"Unsupported KDF OID: {kdfOid}. Only PBKDF2 is supported.");

        var pbkdf2Params = kdfId.ReadSequence();
        kdfId.ThrowIfNotEmpty();

        salt = pbkdf2Params.ReadOctetString();
        iterations = (int)pbkdf2Params.ReadInteger();

        keyLength = 0;
        prfOid = OidHmacWithSha1; // default PRF per RFC 8018

        if (pbkdf2Params.HasData)
        {
            Asn1Tag nextTag = pbkdf2Params.PeekTag();
            if (nextTag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.Integer)))
                keyLength = (int)pbkdf2Params.ReadInteger();
        }

        if (pbkdf2Params.HasData)
        {
            var prfSeq = pbkdf2Params.ReadSequence();
            prfOid = prfSeq.ReadObjectIdentifier();
            if (prfSeq.HasData) prfSeq.ReadNull(); // optional NULL
            prfSeq.ThrowIfNotEmpty();
        }

        pbkdf2Params.ThrowIfNotEmpty();

        // encryptionScheme
        var encScheme = pbes2Params.ReadSequence();
        pbes2Params.ThrowIfNotEmpty();

        encOid = encScheme.ReadObjectIdentifier();
        iv = encScheme.ReadOctetString();
        encScheme.ThrowIfNotEmpty();

        encryptedData = outer.ReadOctetString();
        outer.ThrowIfNotEmpty();
    }
}
#endif
