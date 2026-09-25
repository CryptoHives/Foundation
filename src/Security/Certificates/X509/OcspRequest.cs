// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;

/// <summary>
/// Identifies a certificate in an OCSP request per RFC 6960 §4.1.1.
/// </summary>
/// <remarks>
/// <para>
/// A <see cref="OcspCertId"/> contains the hash algorithm used, a hash of the
/// issuer's distinguished name, a hash of the issuer's public key, and the
/// certificate serial number. Together these fields uniquely identify a
/// certificate without transmitting the full issuer name or key.
/// </para>
/// </remarks>
public sealed class OcspCertId
{
    /// <summary>OID for SHA-1 (1.3.14.3.2.26).</summary>
    public const string OidSha1 = "1.3.14.3.2.26";

    /// <summary>OID for SHA-256 (2.16.840.1.101.3.4.2.1).</summary>
    public const string OidSha256 = "2.16.840.1.101.3.4.2.1";

    /// <summary>
    /// Gets the hash algorithm OID used to compute the issuer hashes.
    /// </summary>
    public string HashAlgorithmOid { get; }

    /// <summary>
    /// Gets the hash of the issuer's DER-encoded distinguished name.
    /// </summary>
    public byte[] IssuerNameHash { get; }

    /// <summary>
    /// Gets the hash of the issuer's public key (BIT STRING value from SPKI).
    /// </summary>
    public byte[] IssuerKeyHash { get; }

    /// <summary>
    /// Gets the serial number of the certificate being checked.
    /// </summary>
    public byte[] SerialNumber { get; }

    /// <summary>
    /// Initializes a new <see cref="OcspCertId"/> with pre-computed values.
    /// </summary>
    /// <param name="hashAlgorithmOid">The hash algorithm OID.</param>
    /// <param name="issuerNameHash">The hash of the issuer's DER-encoded name.</param>
    /// <param name="issuerKeyHash">The hash of the issuer's public key bytes.</param>
    /// <param name="serialNumber">The certificate serial number.</param>
    /// <exception cref="ArgumentNullException">Any parameter is <c>null</c>.</exception>
    public OcspCertId(string hashAlgorithmOid, byte[] issuerNameHash, byte[] issuerKeyHash, byte[] serialNumber)
    {
        if (hashAlgorithmOid is null) throw new ArgumentNullException(nameof(hashAlgorithmOid));
        if (issuerNameHash is null) throw new ArgumentNullException(nameof(issuerNameHash));
        if (issuerKeyHash is null) throw new ArgumentNullException(nameof(issuerKeyHash));
        if (serialNumber is null) throw new ArgumentNullException(nameof(serialNumber));

        HashAlgorithmOid = hashAlgorithmOid;
        IssuerNameHash = (byte[])issuerNameHash.Clone();
        IssuerKeyHash = (byte[])issuerKeyHash.Clone();
        SerialNumber = (byte[])serialNumber.Clone();
    }

    /// <summary>
    /// Creates a <see cref="OcspCertId"/> from a certificate and its issuer.
    /// </summary>
    /// <param name="certificate">The certificate to identify.</param>
    /// <param name="issuer">The issuer certificate.</param>
    /// <param name="hashAlgorithm">
    /// The hash algorithm name (<c>"SHA1"</c> or <c>"SHA256"</c>). Defaults to <c>"SHA1"</c>.
    /// </param>
    /// <returns>A new <see cref="OcspCertId"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="certificate"/> or <paramref name="issuer"/> is <c>null</c>.</exception>
    /// <exception cref="CryptographicException">The hash algorithm is not supported.</exception>
    public static OcspCertId Create(X509Certificate certificate, X509Certificate issuer, string hashAlgorithm = "SHA1")
    {
        if (certificate is null) throw new ArgumentNullException(nameof(certificate));
        if (issuer is null) throw new ArgumentNullException(nameof(issuer));

        string oid = ResolveHashOid(hashAlgorithm);
        HashAlgorithmName hashName = ResolveHashName(hashAlgorithm);

        // Hash the issuer's DER-encoded distinguished name
        byte[] issuerNameDer = ExtractIssuerNameDer(certificate.TbsCertificateDer);
        byte[] issuerNameHash = CryptoHelper.HashData(hashName, issuerNameDer);

        // Hash the issuer's public key (BIT STRING value from SPKI, without unused-bits byte)
        byte[] issuerKeyBytes = ExtractPublicKeyBitStringValue(issuer.SubjectPublicKeyInfoDer);
        byte[] issuerKeyHash = CryptoHelper.HashData(hashName, issuerKeyBytes);

        return new OcspCertId(oid, issuerNameHash, issuerKeyHash, certificate.SerialNumber);
    }

    /// <summary>
    /// Writes this <see cref="OcspCertId"/> to an <see cref="AsnWriter"/> as a CertID SEQUENCE.
    /// </summary>
    /// <param name="writer">The ASN.1 writer.</param>
    internal void WriteTo(AsnWriter writer)
    {
        // CertID ::= SEQUENCE { hashAlgorithm, issuerNameHash, issuerKeyHash, serialNumber }
        writer.PushSequence();

        // AlgorithmIdentifier ::= SEQUENCE { algorithm OID, parameters ANY OPTIONAL }
        writer.PushSequence();
        writer.WriteObjectIdentifier(HashAlgorithmOid);
        writer.WriteNull();
        writer.PopSequence();

        writer.WriteOctetString(IssuerNameHash);
        writer.WriteOctetString(IssuerKeyHash);
        writer.WriteInteger(SerialNumber);

        writer.PopSequence();
    }

    /// <summary>
    /// Parses a CertID from an <see cref="AsnReader"/> positioned at the CertID SEQUENCE.
    /// </summary>
    /// <param name="reader">The ASN.1 reader.</param>
    /// <returns>The parsed <see cref="OcspCertId"/>.</returns>
    internal static OcspCertId ParseDer(AsnReader reader)
    {
        var seq = reader.ReadSequence();

        // AlgorithmIdentifier
        var algSeq = seq.ReadSequence();
        string hashOid = algSeq.ReadObjectIdentifier();
        while (algSeq.HasData)
            algSeq.ReadEncodedValue(); // skip optional parameters (e.g. NULL)

        byte[] issuerNameHash = seq.ReadOctetString();
        byte[] issuerKeyHash = seq.ReadOctetString();
        byte[] serialNumber = seq.ReadIntegerBytes().ToArray();

        seq.ThrowIfNotEmpty();
        return new OcspCertId(hashOid, issuerNameHash, issuerKeyHash, serialNumber);
    }

    /// <summary>
    /// Extracts the raw DER encoding of the Issuer Name field from a TBSCertificate.
    /// </summary>
    private static byte[] ExtractIssuerNameDer(byte[] tbsCertificateDer)
    {
        var reader = new AsnReader(tbsCertificateDer, AsnEncodingRules.DER);
        var tbsSeq = reader.ReadSequence();

        // version [0] EXPLICIT INTEGER DEFAULT v1
        var versionTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (tbsSeq.HasData && tbsSeq.PeekTag().HasSameClassAndValue(versionTag))
            tbsSeq.ReadSequence(versionTag); // skip version

        // serialNumber INTEGER
        tbsSeq.ReadIntegerBytes(); // skip

        // signature AlgorithmIdentifier
        tbsSeq.ReadSequence(); // skip

        // issuer Name — capture raw DER
        return tbsSeq.PeekEncodedValue().ToArray();
    }

    /// <summary>
    /// Extracts the public key BIT STRING value from a SubjectPublicKeyInfo DER structure.
    /// </summary>
    private static byte[] ExtractPublicKeyBitStringValue(byte[] spkiDer)
    {
        var reader = new AsnReader(spkiDer, AsnEncodingRules.DER);
        var seq = reader.ReadSequence();
        seq.ReadSequence(); // skip AlgorithmIdentifier
        byte[] bitString = seq.ReadBitString(out _);
        return bitString;
    }

    private static string ResolveHashOid(string hashAlgorithm) =>
        hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA1" => OidSha1,
            "SHA256" => OidSha256,
            _ => throw new CryptographicException($"Unsupported OCSP hash algorithm: {hashAlgorithm}"),
        };

    private static HashAlgorithmName ResolveHashName(string hashAlgorithm) =>
        hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA1" => HashAlgorithmName.SHA1,
            "SHA256" => HashAlgorithmName.SHA256,
            _ => throw new CryptographicException($"Unsupported OCSP hash algorithm: {hashAlgorithm}"),
        };
}

/// <summary>
/// Represents an OCSP request per RFC 6960 §4.1.
/// </summary>
/// <remarks>
/// <para>
/// An OCSP request contains one or more <see cref="OcspCertId"/> entries
/// identifying certificates whose revocation status is being queried.
/// </para>
/// <para>
/// Use <see cref="Encode"/> to produce a DER-encoded request suitable for
/// an HTTP POST body (Content-Type: application/ocsp-request).
/// </para>
/// </remarks>
public sealed class OcspRequest
{
    /// <summary>
    /// Gets the list of certificate identifiers in this request.
    /// </summary>
    public IReadOnlyList<OcspCertId> CertIds { get; }

    /// <summary>
    /// Initializes a new <see cref="OcspRequest"/> with multiple certificate identifiers.
    /// </summary>
    /// <param name="certIds">The certificate identifiers to include.</param>
    /// <exception cref="ArgumentNullException"><paramref name="certIds"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="certIds"/> is empty.</exception>
    public OcspRequest(IReadOnlyList<OcspCertId> certIds)
    {
        if (certIds is null) throw new ArgumentNullException(nameof(certIds));
        if (certIds.Count == 0) throw new ArgumentException("At least one CertId is required.", nameof(certIds));
        CertIds = certIds;
    }

    /// <summary>
    /// Initializes a new <see cref="OcspRequest"/> for a single certificate identifier.
    /// </summary>
    /// <param name="certId">The certificate identifier.</param>
    /// <exception cref="ArgumentNullException"><paramref name="certId"/> is <c>null</c>.</exception>
    public OcspRequest(OcspCertId certId)
    {
        if (certId is null) throw new ArgumentNullException(nameof(certId));
        CertIds = [certId];
    }

    /// <summary>
    /// Encodes this OCSP request as DER bytes.
    /// </summary>
    /// <returns>The DER-encoded OCSP request.</returns>
    /// <remarks>
    /// <para>
    /// The returned bytes follow the OCSPRequest structure defined in RFC 6960 §4.1:
    /// </para>
    /// <code>
    /// OCSPRequest ::= SEQUENCE {
    ///     tbsRequest TBSRequest
    /// }
    /// TBSRequest ::= SEQUENCE {
    ///     version [0] EXPLICIT Version DEFAULT v1,
    ///     requestList SEQUENCE OF Request
    /// }
    /// </code>
    /// </remarks>
    public byte[] Encode()
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);

        // OCSPRequest SEQUENCE
        writer.PushSequence();

        // TBSRequest SEQUENCE
        writer.PushSequence();

        // version is DEFAULT v1 so we omit it

        // requestList SEQUENCE OF Request
        writer.PushSequence();
        foreach (var certId in CertIds)
        {
            // Request ::= SEQUENCE { reqCert CertID }
            writer.PushSequence();
            certId.WriteTo(writer);
            writer.PopSequence();
        }
        writer.PopSequence();

        writer.PopSequence(); // TBSRequest
        writer.PopSequence(); // OCSPRequest

        return writer.Encode();
    }
}
