// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

/// <summary>
/// Provides X.509 certificate signature verification.
/// </summary>
public static class X509CertificateValidator
{
    /// <summary>
    /// Verifies that a certificate's signature was created by the specified issuer certificate.
    /// </summary>
    /// <param name="cert">The certificate to verify.</param>
    /// <param name="issuerCert">The issuer certificate containing the signing public key.</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="cert"/> or <paramref name="issuerCert"/> is <c>null</c>.</exception>
    public static bool VerifySignature(X509Certificate cert, X509Certificate issuerCert)
    {
        if (cert is null) throw new ArgumentNullException(nameof(cert));
        if (issuerCert is null) throw new ArgumentNullException(nameof(issuerCert));

        return VerifyWithPublicKey(cert, issuerCert.SubjectPublicKeyInfoDer);
    }

    /// <summary>
    /// Verifies a self-signed certificate's signature using its own public key.
    /// </summary>
    /// <param name="cert">The self-signed certificate to verify.</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="cert"/> is <c>null</c>.</exception>
    public static bool VerifySelfSigned(X509Certificate cert)
    {
        if (cert is null) throw new ArgumentNullException(nameof(cert));

        return VerifyWithPublicKey(cert, cert.SubjectPublicKeyInfoDer);
    }

    private static bool VerifyWithPublicKey(X509Certificate cert, byte[] spkiDer)
    {
        string sigAlgOid = cert.SignatureAlgorithmOid;
        string keyAlg = SignatureAlgorithm.GetKeyAlgorithm(sigAlgOid);
        string? hashAlg = SignatureAlgorithm.GetHashAlgorithm(sigAlgOid);

        try
        {
            return keyAlg switch
            {
                "RSA" => VerifyRsa(cert.TbsCertificateDer, cert.SignatureValue, spkiDer, hashAlg!, sigAlgOid),
                "ECDSA" => VerifyEcdsa(cert.TbsCertificateDer, cert.SignatureValue, spkiDer, hashAlg!),
                "Ed25519" => VerifyEd25519(cert.TbsCertificateDer, cert.SignatureValue, spkiDer),
                "Ed448" => VerifyEd448(cert.TbsCertificateDer, cert.SignatureValue, spkiDer),
                _ => false,
            };
        }
        catch
        {
            return false;
        }
    }

    private static bool VerifyRsa(
        byte[] tbsDer, byte[] signature, byte[] spkiDer, string hashAlg, string sigAlgOid)
    {
        byte[] pubKeyBytes = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out _);
        using var rsaKey = KeyEncoding.ImportRsaPublicKey(pubKeyBytes);

        byte[] hash = ComputeHash(tbsDer, hashAlg);

        using var rsa = new RsaCipher(rsaKey);
        if (sigAlgOid == SignatureAlgorithm.OidRsaPss)
            return rsa.VerifyPss(hash, signature, hashAlg);
        return rsa.VerifyPkcs1(hash, signature, hashAlg);
    }

    private static bool VerifyEcdsa(
        byte[] tbsDer, byte[] signatureDer, byte[] spkiDer, string hashAlg)
    {
        byte[] pubPoint = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out string? curveOid);

        if (pubPoint.Length < 3 || pubPoint[0] != 0x04)
            return false;

        int coordLen = (pubPoint.Length - 1) / 2;
        byte[] qx = new byte[coordLen];
        byte[] qy = new byte[coordLen];
        Buffer.BlockCopy(pubPoint, 1, qx, 0, coordLen);
        Buffer.BlockCopy(pubPoint, 1 + coordLen, qy, 0, qy.Length);

        string curveName = curveOid ?? throw new CryptographicException("Missing curve OID in SPKI.");

        // Parse DER-encoded ECDSA signature: SEQUENCE { INTEGER r, INTEGER s }
        var sigReader = new AsnReader(signatureDer, AsnEncodingRules.DER);
        var sigSeq = sigReader.ReadSequence();
        byte[] r = ReadUnsignedInteger(sigSeq);
        byte[] s = ReadUnsignedInteger(sigSeq);
        sigSeq.ThrowIfNotEmpty();

        byte[] hash = ComputeHash(tbsDer, hashAlg);

        var curve = EcDsaCipher.ResolveCurve(curveName);
        int fs = curve.FieldSize;

        return EcDsaCore.Verify(
            hash,
            PadLeft(r, fs),
            PadLeft(s, fs),
            PadLeft(qx, fs),
            PadLeft(qy, fs),
            curve);
    }

    private static bool VerifyEd25519(byte[] tbsDer, byte[] signature, byte[] spkiDer)
    {
        byte[] pubKey = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out _);
        return Ed25519.Verify(pubKey, tbsDer, signature);
    }

    private static bool VerifyEd448(byte[] tbsDer, byte[] signature, byte[] spkiDer)
    {
        byte[] pubKey = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out _);
        return Ed448.Verify(pubKey, tbsDer, signature);
    }

    private static byte[] ComputeHash(byte[] data, string hashAlgorithm)
    {
        return CryptoHelper.HashData(
            hashAlgorithm.ToUpperInvariant() switch
            {
                "SHA1" => HashAlgorithmName.SHA1,
                "SHA256" => HashAlgorithmName.SHA256,
                "SHA384" => HashAlgorithmName.SHA384,
                "SHA512" => HashAlgorithmName.SHA512,
                _ => throw new CryptographicException($"Unsupported hash: {hashAlgorithm}"),
            },
            data);
    }

    private static byte[] ReadUnsignedInteger(AsnReader reader)
    {
        ReadOnlyMemory<byte> bytes = reader.ReadIntegerBytes();
        ReadOnlySpan<byte> span = bytes.Span;
        if (span.Length > 1 && span[0] == 0)
            return span[1..].ToArray();
        return span.ToArray();
    }

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }
}
