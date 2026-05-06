// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

/// <summary>
/// Represents the overall status of an OCSP response per RFC 6960 §4.2.1.
/// </summary>
public enum OcspResponseStatus
{
    /// <summary>The response contains a valid confirmation.</summary>
    Successful = 0,

    /// <summary>The request was malformed.</summary>
    MalformedRequest = 1,

    /// <summary>An internal server error occurred.</summary>
    InternalError = 2,

    /// <summary>The responder is busy; try again later.</summary>
    TryLater = 3,

    /// <summary>The request must be signed.</summary>
    SignatureRequired = 5,

    /// <summary>The client is not authorized to make this request.</summary>
    Unauthorized = 6,
}

/// <summary>
/// Represents the revocation status of a single certificate in an OCSP response.
/// </summary>
public enum OcspCertStatus
{
    /// <summary>The certificate is not revoked.</summary>
    Good,

    /// <summary>The certificate has been revoked.</summary>
    Revoked,

    /// <summary>The responder does not know about the certificate.</summary>
    Unknown,
}

/// <summary>
/// Represents a single response for one certificate within a <see cref="OcspResponse"/>.
/// </summary>
/// <remarks>
/// Corresponds to the SingleResponse ASN.1 type defined in RFC 6960 §4.2.1.
/// </remarks>
public sealed class OcspSingleResponse
{
    /// <summary>
    /// Gets the certificate identifier for this response.
    /// </summary>
    public OcspCertId CertId { get; }

    /// <summary>
    /// Gets the revocation status of the certificate.
    /// </summary>
    public OcspCertStatus Status { get; }

    /// <summary>
    /// Gets the time at which the status was known to be correct.
    /// </summary>
    public DateTimeOffset ThisUpdate { get; }

    /// <summary>
    /// Gets the time at or before which newer information will be available, or <c>null</c>.
    /// </summary>
    public DateTimeOffset? NextUpdate { get; }

    /// <summary>
    /// Gets the revocation time if the certificate is revoked; otherwise <c>null</c>.
    /// </summary>
    public DateTimeOffset? RevocationTime { get; }

    /// <summary>
    /// Gets the CRL reason code if the certificate is revoked and a reason was provided; otherwise <c>null</c>.
    /// </summary>
    public int? RevocationReason { get; }

    internal OcspSingleResponse(
        OcspCertId certId,
        OcspCertStatus status,
        DateTimeOffset thisUpdate,
        DateTimeOffset? nextUpdate,
        DateTimeOffset? revocationTime,
        int? revocationReason)
    {
        CertId = certId;
        Status = status;
        ThisUpdate = thisUpdate;
        NextUpdate = nextUpdate;
        RevocationTime = revocationTime;
        RevocationReason = revocationReason;
    }
}

/// <summary>
/// Represents a parsed OCSP response per RFC 6960 §4.2.
/// </summary>
/// <remarks>
/// <para>
/// Use <see cref="Decode"/> to parse a DER-encoded OCSP response received from an
/// OCSP responder. The <see cref="VerifySignature"/> method validates the response
/// signature using the issuer certificate or an embedded responder certificate.
/// </para>
/// </remarks>
public sealed class OcspResponse
{
    private const string OidBasicOcspResponse = "1.3.6.1.5.5.7.48.1.1";

    /// <summary>
    /// Gets the overall response status.
    /// </summary>
    public OcspResponseStatus ResponseStatus { get; }

    /// <summary>
    /// Gets the individual certificate responses, or <c>null</c> if the response is not successful.
    /// </summary>
    public IReadOnlyList<OcspSingleResponse>? Responses { get; }

    /// <summary>
    /// Gets the time the response was produced, or <c>null</c> if the response is not successful.
    /// </summary>
    public DateTimeOffset? ProducedAt { get; }

    /// <summary>
    /// Gets the signature algorithm OID, or <c>null</c> if the response is not successful.
    /// </summary>
    public string? SignatureAlgorithmOid { get; }

    /// <summary>
    /// Gets the raw signature value bytes, or <c>null</c> if the response is not successful.
    /// </summary>
    public byte[]? SignatureValue { get; }

    /// <summary>
    /// Gets the raw DER-encoded ResponseData for signature verification, or <c>null</c> if the response is not successful.
    /// </summary>
    public byte[]? TbsResponseDataDer { get; }

    /// <summary>
    /// Gets the optional certificates included in the response, or <c>null</c> if none are present.
    /// </summary>
    public IReadOnlyList<X509Certificate>? ResponderCerts { get; }

    private OcspResponse(
        OcspResponseStatus responseStatus,
        IReadOnlyList<OcspSingleResponse>? responses,
        DateTimeOffset? producedAt,
        string? signatureAlgorithmOid,
        byte[]? signatureValue,
        byte[]? tbsResponseDataDer,
        IReadOnlyList<X509Certificate>? responderCerts)
    {
        ResponseStatus = responseStatus;
        Responses = responses;
        ProducedAt = producedAt;
        SignatureAlgorithmOid = signatureAlgorithmOid;
        SignatureValue = signatureValue;
        TbsResponseDataDer = tbsResponseDataDer;
        ResponderCerts = responderCerts;
    }

    /// <summary>
    /// Decodes an OCSP response from DER-encoded bytes.
    /// </summary>
    /// <param name="data">The DER-encoded OCSP response.</param>
    /// <returns>The parsed <see cref="OcspResponse"/>.</returns>
    /// <exception cref="CryptographicException">The data is not a valid OCSP response.</exception>
    public static OcspResponse Decode(ReadOnlySpan<byte> data)
    {
        var reader = new AsnReader(data.ToArray(), AsnEncodingRules.DER);
        var outerSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // responseStatus ENUMERATED
        var statusValue = outerSeq.ReadEnumeratedValue<OcspResponseStatus>();

        if (statusValue != OcspResponseStatus.Successful)
        {
            // Non-successful responses have no responseBytes
            if (outerSeq.HasData)
            {
                outerSeq.ReadEncodedValue(); // skip optional responseBytes if present
            }

            return new OcspResponse(statusValue, null, null, null, null, null, null);
        }

        // responseBytes [0] EXPLICIT ResponseBytes
        var ctx0 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (!outerSeq.HasData || !outerSeq.PeekTag().HasSameClassAndValue(ctx0))
        {
            throw new CryptographicException("Successful OCSP response missing responseBytes.");
        }

        var responseBytesWrapper = outerSeq.ReadSequence(ctx0);
        var responseBytesSeq = responseBytesWrapper.ReadSequence();
        responseBytesWrapper.ThrowIfNotEmpty();

        // responseType OID
        string responseType = responseBytesSeq.ReadObjectIdentifier();
        if (responseType != OidBasicOcspResponse)
        {
            throw new CryptographicException($"Unsupported OCSP response type: {responseType}");
        }

        // response OCTET STRING — contains DER-encoded BasicOCSPResponse
        byte[] basicResponseDer = responseBytesSeq.ReadOctetString();
        responseBytesSeq.ThrowIfNotEmpty();

        return DecodeBasicOcspResponse(basicResponseDer, statusValue);
    }

    /// <summary>
    /// Finds the response for a specific certificate identifier.
    /// </summary>
    /// <param name="certId">The certificate identifier to search for.</param>
    /// <returns>The matching <see cref="OcspSingleResponse"/>, or <c>null</c> if not found.</returns>
    public OcspSingleResponse? FindResponse(OcspCertId certId)
    {
        if (certId is null || Responses is null)
        {
            return null;
        }

        return Responses.FirstOrDefault(r =>
            r.CertId.HashAlgorithmOid == certId.HashAlgorithmOid &&
            r.CertId.IssuerNameHash.AsSpan().SequenceEqual(certId.IssuerNameHash) &&
            r.CertId.IssuerKeyHash.AsSpan().SequenceEqual(certId.IssuerKeyHash) &&
            r.CertId.SerialNumber.AsSpan().SequenceEqual(certId.SerialNumber));
    }

    /// <summary>
    /// Verifies the response signature using the issuer certificate.
    /// </summary>
    /// <param name="issuerCert">The issuer certificate containing the signing public key.</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuerCert"/> is <c>null</c>.</exception>
    /// <remarks>
    /// If the response contains embedded responder certificates, the method first
    /// attempts verification with the issuer certificate directly, then falls back
    /// to trying each embedded certificate.
    /// </remarks>
    public bool VerifySignature(X509Certificate issuerCert)
    {
        if (issuerCert is null) throw new ArgumentNullException(nameof(issuerCert));
        if (TbsResponseDataDer is null || SignatureValue is null || SignatureAlgorithmOid is null)
        {
            return false;
        }

        if (VerifyWithPublicKey(TbsResponseDataDer, SignatureValue, SignatureAlgorithmOid, issuerCert.SubjectPublicKeyInfoDer))
        {
            return true;
        }

        // Try embedded responder certs
        if (ResponderCerts is not null)
        {
            foreach (var cert in ResponderCerts)
            {
                if (VerifyWithPublicKey(TbsResponseDataDer, SignatureValue, SignatureAlgorithmOid, cert.SubjectPublicKeyInfoDer))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static OcspResponse DecodeBasicOcspResponse(byte[] der, OcspResponseStatus status)
    {
        var reader = new AsnReader(der, AsnEncodingRules.DER);
        var basicSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // tbsResponseData — capture raw DER for signature verification
        byte[] tbsResponseDataDer = basicSeq.PeekEncodedValue().ToArray();
        var tbsReader = basicSeq.ReadSequence();

        // signatureAlgorithm AlgorithmIdentifier
        var sigAlgSeq = basicSeq.ReadSequence();
        string sigAlgOid = sigAlgSeq.ReadObjectIdentifier();
        while (sigAlgSeq.HasData)
        {
            sigAlgSeq.ReadEncodedValue(); // skip optional parameters
        }

        // signature BIT STRING
        byte[] signatureValue = basicSeq.ReadBitString(out _);

        // certs [0] EXPLICIT SEQUENCE OF Certificate OPTIONAL
        List<X509Certificate>? responderCerts = null;
        var certsTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (basicSeq.HasData && basicSeq.PeekTag().HasSameClassAndValue(certsTag))
        {
            responderCerts = [];
            var certsWrapper = basicSeq.ReadSequence(certsTag);
            var certsSeq = certsWrapper.ReadSequence();
            while (certsSeq.HasData)
            {
                byte[] certDer = certsSeq.PeekEncodedValue().ToArray();
                certsSeq.ReadEncodedValue(); // advance past the certificate
                responderCerts.Add(X509CertificateParser.ParseDer(certDer));
            }
            certsWrapper.ThrowIfNotEmpty();
        }
        basicSeq.ThrowIfNotEmpty();

        // Parse ResponseData
        var (producedAt, responses) = ParseResponseData(tbsReader);

        return new OcspResponse(
            status,
            responses,
            producedAt,
            sigAlgOid,
            signatureValue,
            tbsResponseDataDer,
            responderCerts);
    }

    private static (DateTimeOffset producedAt, List<OcspSingleResponse> responses) ParseResponseData(AsnReader tbsReader)
    {
        // version [0] EXPLICIT Version DEFAULT v1
        var versionTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(versionTag))
        {
            tbsReader.ReadSequence(versionTag); // skip version
        }

        // responderID — CHOICE: [1] byName or [2] byKeyHash
        var tag = tbsReader.PeekTag();
        if (tag.TagClass == TagClass.ContextSpecific)
        {
            tbsReader.ReadEncodedValue(); // skip responderID (we don't need it for basic verification)
        }
        else
        {
            tbsReader.ReadEncodedValue(); // skip
        }

        // producedAt GeneralizedTime
        DateTimeOffset producedAt = tbsReader.ReadGeneralizedTime();

        // responses SEQUENCE OF SingleResponse
        var responsesSeq = tbsReader.ReadSequence();
        var responses = new List<OcspSingleResponse>();
        while (responsesSeq.HasData)
        {
            responses.Add(ParseSingleResponse(responsesSeq));
        }

        // responseExtensions [1] EXPLICIT Extensions OPTIONAL
        var extTag = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(extTag))
        {
            tbsReader.ReadEncodedValue(); // skip extensions
        }

        tbsReader.ThrowIfNotEmpty();
        return (producedAt, responses);
    }

    private static OcspSingleResponse ParseSingleResponse(AsnReader reader)
    {
        var singleSeq = reader.ReadSequence();

        // certID CertID
        OcspCertId certId = OcspCertId.ParseDer(singleSeq);

        // certStatus CertStatus — CHOICE
        OcspCertStatus status;
        DateTimeOffset? revocationTime = null;
        int? revocationReason = null;

        var statusTag = singleSeq.PeekTag();
        if (statusTag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0)))
        {
            // good [0] IMPLICIT NULL
            singleSeq.ReadEncodedValue();
            status = OcspCertStatus.Good;
        }
        else if (statusTag.HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true)))
        {
            // revoked [1] IMPLICIT RevokedInfo
            status = OcspCertStatus.Revoked;
            var revokedSeq = singleSeq.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
            revocationTime = revokedSeq.ReadGeneralizedTime();

            // revocationReason [0] EXPLICIT CRLReason OPTIONAL
            var reasonTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
            if (revokedSeq.HasData && revokedSeq.PeekTag().HasSameClassAndValue(reasonTag))
            {
                var reasonWrapper = revokedSeq.ReadSequence(reasonTag);
                revocationReason = (int)reasonWrapper.ReadEnumeratedValue<CrlReason>();
                reasonWrapper.ThrowIfNotEmpty();
            }
            revokedSeq.ThrowIfNotEmpty();
        }
        else
        {
            // unknown [2] IMPLICIT NULL
            singleSeq.ReadEncodedValue();
            status = OcspCertStatus.Unknown;
        }

        // thisUpdate GeneralizedTime
        DateTimeOffset thisUpdate = singleSeq.ReadGeneralizedTime();

        // nextUpdate [0] EXPLICIT GeneralizedTime OPTIONAL
        DateTimeOffset? nextUpdate = null;
        var nextUpdateTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (singleSeq.HasData && singleSeq.PeekTag().HasSameClassAndValue(nextUpdateTag))
        {
            var nextUpdateWrapper = singleSeq.ReadSequence(nextUpdateTag);
            nextUpdate = nextUpdateWrapper.ReadGeneralizedTime();
            nextUpdateWrapper.ThrowIfNotEmpty();
        }

        // singleExtensions [1] EXPLICIT Extensions OPTIONAL
        var singleExtTag = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
        if (singleSeq.HasData && singleSeq.PeekTag().HasSameClassAndValue(singleExtTag))
        {
            singleSeq.ReadEncodedValue(); // skip
        }

        singleSeq.ThrowIfNotEmpty();

        return new OcspSingleResponse(certId, status, thisUpdate, nextUpdate, revocationTime, revocationReason);
    }

    private static bool VerifyWithPublicKey(byte[] tbsDer, byte[] signature, string sigAlgOid, byte[] spkiDer)
    {
        string keyAlg = SignatureAlgorithm.GetKeyAlgorithm(sigAlgOid);
        string? hashAlg = SignatureAlgorithm.GetHashAlgorithm(sigAlgOid);

        try
        {
            return keyAlg switch
            {
                "RSA" => VerifyRsa(tbsDer, signature, spkiDer, hashAlg!, sigAlgOid),
                "ECDSA" => VerifyEcdsa(tbsDer, signature, spkiDer, hashAlg!),
                "Ed25519" => VerifyEd25519(tbsDer, signature, spkiDer),
                "Ed448" => VerifyEd448(tbsDer, signature, spkiDer),
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
        {
            return rsa.VerifyPss(hash, signature, hashAlg);
        }

        return rsa.VerifyPkcs1(hash, signature, hashAlg);
    }

    private static bool VerifyEcdsa(
        byte[] tbsDer, byte[] signatureDer, byte[] spkiDer, string hashAlg)
    {
        byte[] pubPoint = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out string? curveOid);

        if (pubPoint.Length < 3 || pubPoint[0] != 0x04)
        {
            return false;
        }

        int coordLen = (pubPoint.Length - 1) / 2;
        byte[] qx = new byte[coordLen];
        byte[] qy = new byte[coordLen];
        Buffer.BlockCopy(pubPoint, 1, qx, 0, coordLen);
        Buffer.BlockCopy(pubPoint, 1 + coordLen, qy, 0, qy.Length);

        string curveName = curveOid ?? throw new CryptographicException("Missing curve OID in SPKI.");

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
        {
            return span[1..].ToArray();
        }

        return span.ToArray();
    }

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length)
        {
            return data;
        }

        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }
}
