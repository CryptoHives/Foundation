// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

/// <summary>
/// Represents a PKCS#10 Certificate Signing Request per RFC 2986.
/// </summary>
/// <remarks>
/// <para>
/// Instances are immutable and created by <see cref="CsrParser"/>
/// or <see cref="CsrBuilder"/>.
/// </para>
/// <para>
/// The raw CertificationRequestInfo bytes are retained for
/// signature verification via <see cref="VerifySignature"/>.
/// </para>
/// </remarks>
public sealed class X509CertificateSigningRequest
{
    /// <summary>
    /// Gets the CSR version (1 = v1).
    /// </summary>
    public int Version { get; }

    /// <summary>
    /// Gets the subject distinguished name.
    /// </summary>
    public X509Name Subject { get; }

    /// <summary>
    /// Gets the raw DER-encoded SubjectPublicKeyInfo structure.
    /// </summary>
    public byte[] SubjectPublicKeyInfoDer { get; }

    /// <summary>
    /// Gets the OID of the public key algorithm from the SubjectPublicKeyInfo.
    /// </summary>
    public string SubjectPublicKeyAlgorithmOid { get; }

    /// <summary>
    /// Gets the requested extensions (from the extensionRequest attribute).
    /// </summary>
    public X509ExtensionCollection Extensions { get; }

    /// <summary>
    /// Gets the signature algorithm OID.
    /// </summary>
    public string SignatureAlgorithmOid { get; }

    /// <summary>
    /// Gets the raw signature value bytes.
    /// </summary>
    public byte[] SignatureValue { get; }

    /// <summary>
    /// Gets the raw DER-encoded CertificationRequestInfo.
    /// </summary>
    public byte[] CertificationRequestInfoDer { get; }

    /// <summary>
    /// Gets the complete raw DER-encoded CSR.
    /// </summary>
    public byte[] RawDer { get; }

    internal X509CertificateSigningRequest(
        int version,
        X509Name subject,
        byte[] subjectPublicKeyInfoDer,
        string subjectPublicKeyAlgorithmOid,
        X509ExtensionCollection extensions,
        string signatureAlgorithmOid,
        byte[] signatureValue,
        byte[] certificationRequestInfoDer,
        byte[] rawDer)
    {
        Version = version;
        Subject = subject;
        SubjectPublicKeyInfoDer = subjectPublicKeyInfoDer;
        SubjectPublicKeyAlgorithmOid = subjectPublicKeyAlgorithmOid;
        Extensions = extensions;
        SignatureAlgorithmOid = signatureAlgorithmOid;
        SignatureValue = signatureValue;
        CertificationRequestInfoDer = certificationRequestInfoDer;
        RawDer = rawDer;
    }

    /// <summary>
    /// Exports the CSR as a DER-encoded byte array.
    /// </summary>
    /// <returns>A copy of the raw DER-encoded CSR.</returns>
    public byte[] ExportDer() => (byte[])RawDer.Clone();

    /// <summary>
    /// Exports the CSR as a PEM-encoded string with the "CERTIFICATE REQUEST" label.
    /// </summary>
    /// <returns>The PEM-encoded CSR string.</returns>
    public string ExportPem() => PemHelper.Encode(RawDer, "CERTIFICATE REQUEST");

    /// <summary>
    /// Extracts the raw public key bytes from the SubjectPublicKeyInfo structure.
    /// </summary>
    /// <returns>The raw public key bytes.</returns>
    public byte[] GetPublicKey()
    {
        return KeyEncoding.ImportSubjectPublicKeyInfo(SubjectPublicKeyInfoDer, out _, out _);
    }

    /// <summary>
    /// Gets the public key algorithm name (e.g., "RSA", "ECDSA", "Ed25519").
    /// </summary>
    /// <returns>The algorithm name string.</returns>
    public string GetPublicKeyAlgorithm()
    {
        return SignatureAlgorithm.GetKeyAlgorithm(SubjectPublicKeyAlgorithmOid) switch
        {
            "Unknown" => MapSpkiOidToKeyType(SubjectPublicKeyAlgorithmOid),
            string name => name,
        };
    }

    /// <summary>
    /// Verifies the CSR self-signature (proof of possession) using the embedded public key.
    /// </summary>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    public bool VerifySignature()
    {
        string keyAlg = SignatureAlgorithm.GetKeyAlgorithm(SignatureAlgorithmOid);
        if (keyAlg == "Unknown")
            keyAlg = MapSpkiOidToKeyType(SubjectPublicKeyAlgorithmOid);

        string? hashAlg = SignatureAlgorithm.GetHashAlgorithm(SignatureAlgorithmOid);

        try
        {
            return keyAlg switch
            {
                "RSA" => VerifyRsa(hashAlg!),
                "ECDSA" => VerifyEcdsa(hashAlg!),
                "Ed25519" => VerifyEd25519(),
                "Ed448" => VerifyEd448(),
                _ => false,
            };
        }
        catch
        {
            return false;
        }
    }

    private bool VerifyRsa(string hashAlg)
    {
        byte[] pubKeyBytes = KeyEncoding.ImportSubjectPublicKeyInfo(SubjectPublicKeyInfoDer, out _, out _);
        using var rsaKey = KeyEncoding.ImportRsaPublicKey(pubKeyBytes);
        byte[] hash = CryptoHelper.HashData(ToHashAlgorithmName(hashAlg), CertificationRequestInfoDer);
        using var rsa = new RsaCipher(rsaKey);
        if (SignatureAlgorithmOid == SignatureAlgorithm.OidRsaPss)
            return rsa.VerifyPss(hash, SignatureValue, hashAlg);
        return rsa.VerifyPkcs1(hash, SignatureValue, hashAlg);
    }

    private bool VerifyEcdsa(string hashAlg)
    {
        byte[] pubPoint = KeyEncoding.ImportSubjectPublicKeyInfo(SubjectPublicKeyInfoDer, out _, out string? curveOid);
        if (pubPoint.Length < 3 || pubPoint[0] != 0x04)
            return false;

        int coordLen = (pubPoint.Length - 1) / 2;
        byte[] qx = new byte[coordLen];
        byte[] qy = new byte[coordLen];
        Buffer.BlockCopy(pubPoint, 1, qx, 0, coordLen);
        Buffer.BlockCopy(pubPoint, 1 + coordLen, qy, 0, coordLen);

        string curveName = curveOid ?? throw new CryptographicException("Missing curve OID in SPKI.");

        var sigReader = new AsnReader(SignatureValue, AsnEncodingRules.DER);
        var sigSeq = sigReader.ReadSequence();
        byte[] r = ReadUnsignedInteger(sigSeq);
        byte[] s = ReadUnsignedInteger(sigSeq);
        sigSeq.ThrowIfNotEmpty();

        byte[] hash = CryptoHelper.HashData(ToHashAlgorithmName(hashAlg), CertificationRequestInfoDer);
        var curve = EcDsaCipher.ResolveCurve(curveName);
        int fs = curve.FieldSize;

        return EcDsaCore.Verify(hash, PadLeft(r, fs), PadLeft(s, fs), PadLeft(qx, fs), PadLeft(qy, fs), curve);
    }

    private bool VerifyEd25519()
    {
        byte[] pubKey = KeyEncoding.ImportSubjectPublicKeyInfo(SubjectPublicKeyInfoDer, out _, out _);
        return Ed25519.Verify(pubKey, CertificationRequestInfoDer, SignatureValue);
    }

    private bool VerifyEd448()
    {
        byte[] pubKey = KeyEncoding.ImportSubjectPublicKeyInfo(SubjectPublicKeyInfoDer, out _, out _);
        return Ed448.Verify(pubKey, CertificationRequestInfoDer, SignatureValue);
    }

    private static HashAlgorithmName ToHashAlgorithmName(string name) => name.ToUpperInvariant() switch
    {
        "SHA1" => HashAlgorithmName.SHA1,
        "SHA256" => HashAlgorithmName.SHA256,
        "SHA384" => HashAlgorithmName.SHA384,
        "SHA512" => HashAlgorithmName.SHA512,
        _ => throw new ArgumentException($"Unsupported hash: {name}"),
    };

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

    private static string MapSpkiOidToKeyType(string oid) => oid switch
    {
        "1.2.840.113549.1.1.1" => "RSA",
        "1.2.840.10045.2.1" => "ECDSA",
        "1.3.101.112" => "Ed25519",
        "1.3.101.113" => "Ed448",
        _ => "Unknown",
    };
}
