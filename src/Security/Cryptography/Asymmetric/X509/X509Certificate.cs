// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;

using ManagedHash = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Represents an X.509 v1/v2/v3 certificate per RFC 5280.
/// </summary>
/// <remarks>
/// <para>
/// Instances are immutable and created by <see cref="X509CertificateParser"/>
/// or <see cref="X509CertificateBuilder"/>.
/// </para>
/// <para>
/// The raw DER bytes and TBS certificate bytes are retained for
/// signature verification via <see cref="X509CertificateValidator"/>.
/// </para>
/// </remarks>
public sealed class X509Certificate
{
    /// <summary>
    /// Gets the certificate version (1, 2, or 3).
    /// </summary>
    public int Version { get; }

    /// <summary>
    /// Gets the certificate serial number as a big-endian byte array.
    /// </summary>
    public byte[] SerialNumber { get; }

    /// <summary>
    /// Gets the signature algorithm OID.
    /// </summary>
    public string SignatureAlgorithmOid { get; }

    /// <summary>
    /// Gets the certificate issuer name.
    /// </summary>
    public X509Name Issuer { get; }

    /// <summary>
    /// Gets the earliest time at which the certificate is valid.
    /// </summary>
    public DateTimeOffset NotBefore { get; }

    /// <summary>
    /// Gets the latest time at which the certificate is valid.
    /// </summary>
    public DateTimeOffset NotAfter { get; }

    /// <summary>
    /// Gets the certificate subject name.
    /// </summary>
    public X509Name Subject { get; }

    /// <summary>
    /// Gets the raw DER-encoded SubjectPublicKeyInfo structure.
    /// </summary>
    public byte[] SubjectPublicKeyInfoDer { get; }

    /// <summary>
    /// Gets the certificate extensions collection.
    /// </summary>
    public X509ExtensionCollection Extensions { get; }

    /// <summary>
    /// Gets the raw signature value bytes.
    /// </summary>
    public byte[] SignatureValue { get; }

    /// <summary>
    /// Gets the raw DER-encoded TBS (To Be Signed) certificate.
    /// </summary>
    public byte[] TbsCertificateDer { get; }

    /// <summary>
    /// Gets the complete raw DER-encoded certificate.
    /// </summary>
    public byte[] RawDer { get; }

    /// <summary>
    /// Gets the OID of the public key algorithm from the SubjectPublicKeyInfo.
    /// </summary>
    public string SubjectPublicKeyAlgorithmOid { get; }

    /// <summary>
    /// Gets a value indicating whether this certificate is self-signed
    /// (issuer equals subject).
    /// </summary>
    public bool IsSelfSigned => Issuer.Equals(Subject);

    /// <summary>
    /// Gets a value indicating whether this certificate is currently valid
    /// based on NotBefore and NotAfter.
    /// </summary>
    public bool IsValid
    {
        get
        {
            var now = DateTimeOffset.UtcNow;
            return now >= NotBefore && now <= NotAfter;
        }
    }

    /// <summary>
    /// Gets the SHA-256 thumbprint of the certificate as a lowercase hex string.
    /// </summary>
    public string Thumbprint
    {
        get
        {
            using var sha = ManagedHash.SHA256.Create();
            byte[] hash = new byte[32];
            sha.TryComputeHash(RawDer, hash, out _);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }

    internal X509Certificate(
        int version,
        byte[] serialNumber,
        string signatureAlgorithmOid,
        X509Name issuer,
        DateTimeOffset notBefore,
        DateTimeOffset notAfter,
        X509Name subject,
        byte[] subjectPublicKeyInfoDer,
        X509ExtensionCollection extensions,
        byte[] signatureValue,
        byte[] tbsCertificateDer,
        byte[] rawDer,
        string subjectPublicKeyAlgorithmOid)
    {
        Version = version;
        SerialNumber = serialNumber;
        SignatureAlgorithmOid = signatureAlgorithmOid;
        Issuer = issuer;
        NotBefore = notBefore;
        NotAfter = notAfter;
        Subject = subject;
        SubjectPublicKeyInfoDer = subjectPublicKeyInfoDer;
        Extensions = extensions;
        SignatureValue = signatureValue;
        TbsCertificateDer = tbsCertificateDer;
        RawDer = rawDer;
        SubjectPublicKeyAlgorithmOid = subjectPublicKeyAlgorithmOid;
    }

    /// <summary>
    /// Exports the certificate as a DER-encoded byte array.
    /// </summary>
    /// <returns>A copy of the raw DER-encoded certificate.</returns>
    public byte[] ExportDer() => (byte[])RawDer.Clone();

    /// <summary>
    /// Exports the certificate as a PEM-encoded string with the "CERTIFICATE" label.
    /// </summary>
    /// <returns>The PEM-encoded certificate string.</returns>
    public string ExportPem() => CryptoHives.Foundation.Security.Cryptography.Asymmetric.PemHelper.Encode(RawDer, "CERTIFICATE");

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

    private static string MapSpkiOidToKeyType(string oid) => oid switch
    {
        "1.2.840.113549.1.1.1" => "RSA",
        "1.2.840.10045.2.1" => "ECDSA",
        "1.3.101.112" => "Ed25519",
        "1.3.101.113" => "Ed448",
        _ => "Unknown",
    };
}
