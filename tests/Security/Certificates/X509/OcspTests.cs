// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class OcspTests
{
    // ========================================================================
    // CertID creation
    // ========================================================================

    [Test]
    public void CertIdCreateProducesCorrectHashes()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        using RSA rsa = RSA.Create(2048);
        using var leafKey = ExportKey(rsa);
        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);

        Assert.That(certId.HashAlgorithmOid, Is.EqualTo(OcspCertId.OidSha1));
        Assert.That(certId.IssuerNameHash, Has.Length.EqualTo(20));
        Assert.That(certId.IssuerKeyHash, Has.Length.EqualTo(20));
        Assert.That(certId.SerialNumber, Is.EqualTo(leaf.SerialNumber));
    }

    [Test]
    public void CertIdSha256()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert, "SHA256");

        Assert.That(certId.HashAlgorithmOid, Is.EqualTo(OcspCertId.OidSha256));
        Assert.That(certId.IssuerNameHash, Has.Length.EqualTo(32));
        Assert.That(certId.IssuerKeyHash, Has.Length.EqualTo(32));
    }

    // ========================================================================
    // Request encoding
    // ========================================================================

    [Test]
    public void RequestEncodeSingleCert()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);
        var request = new OcspRequest(certId);

        byte[] encoded = request.Encode();

        // Verify the DER is valid ASN.1
        var reader = new AsnReader(encoded, AsnEncodingRules.DER);
        var outerSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // TBSRequest SEQUENCE
        var tbsSeq = outerSeq.ReadSequence();
        outerSeq.ThrowIfNotEmpty();

        // requestList SEQUENCE OF Request
        var requestList = tbsSeq.ReadSequence();
        tbsSeq.ThrowIfNotEmpty();

        // One Request entry
        var reqSeq = requestList.ReadSequence();
        requestList.ThrowIfNotEmpty();

        // CertID within Request
        var certIdSeq = reqSeq.ReadSequence();
        reqSeq.ThrowIfNotEmpty();

        // AlgorithmIdentifier
        var algSeq = certIdSeq.ReadSequence();
        string oid = algSeq.ReadObjectIdentifier();
        Assert.That(oid, Is.EqualTo(OcspCertId.OidSha1));
    }

    [Test]
    public void RequestEncodeMultipleCerts()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf1 = CreateLeaf(caRsa, caCert.Subject);
        var leaf2 = CreateLeaf(caRsa, caCert.Subject);

        var certId1 = OcspCertId.Create(leaf1, caCert);
        var certId2 = OcspCertId.Create(leaf2, caCert);

        var request = new OcspRequest([certId1, certId2]);
        byte[] encoded = request.Encode();

        // Parse and count entries
        var reader = new AsnReader(encoded, AsnEncodingRules.DER);
        var outerSeq = reader.ReadSequence();
        var tbsSeq = outerSeq.ReadSequence();
        var requestList = tbsSeq.ReadSequence();

        int count = 0;
        while (requestList.HasData)
        {
            requestList.ReadSequence();
            count++;
        }

        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void RequestEncodeDecodeRoundTrip()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);
        var request = new OcspRequest(certId);

        byte[] encoded = request.Encode();

        // Parse back and verify CertID fields
        var reader = new AsnReader(encoded, AsnEncodingRules.DER);
        var outerSeq = reader.ReadSequence();
        var tbsSeq = outerSeq.ReadSequence();
        var requestList = tbsSeq.ReadSequence();
        var reqSeq = requestList.ReadSequence();
        var parsedCertId = OcspCertId.ParseDer(reqSeq);

        Assert.That(parsedCertId.HashAlgorithmOid, Is.EqualTo(certId.HashAlgorithmOid));
        Assert.That(parsedCertId.IssuerNameHash, Is.EqualTo(certId.IssuerNameHash));
        Assert.That(parsedCertId.IssuerKeyHash, Is.EqualTo(certId.IssuerKeyHash));
        Assert.That(parsedCertId.SerialNumber, Is.EqualTo(certId.SerialNumber));
    }

    // ========================================================================
    // Response decoding — successful good
    // ========================================================================

    [Test]
    public void ResponseDecodeSuccessfulGood()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);

        var now = TruncateToSeconds(DateTimeOffset.UtcNow);

        using var sigKey = ExportKey(caRsa);
        byte[] responseDer = BuildMockOcspResponse(
            sigKey, certId, OcspCertStatus.Good, now, now.AddDays(7));

        var response = OcspResponse.Decode(responseDer);

        Assert.That(response.ResponseStatus, Is.EqualTo(OcspResponseStatus.Successful));
        Assert.That(response.Responses, Is.Not.Null);
        Assert.That(response.Responses!, Has.Count.EqualTo(1));
        Assert.That(response.Responses![0].Status, Is.EqualTo(OcspCertStatus.Good));
        Assert.That(response.ProducedAt, Is.Not.Null);
    }

    // ========================================================================
    // Response decoding — successful revoked
    // ========================================================================

    [Test]
    public void ResponseDecodeSuccessfulRevoked()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);

        var now = TruncateToSeconds(DateTimeOffset.UtcNow);
        var revocationTime = TruncateToSeconds(now.AddDays(-1));

        using var sigKey = ExportKey(caRsa);
        byte[] responseDer = BuildMockOcspResponse(
            sigKey, certId, OcspCertStatus.Revoked, now, now.AddDays(7),
            revocationTime, (int)CrlReason.KeyCompromise);

        var response = OcspResponse.Decode(responseDer);

        Assert.That(response.ResponseStatus, Is.EqualTo(OcspResponseStatus.Successful));
        Assert.That(response.Responses![0].Status, Is.EqualTo(OcspCertStatus.Revoked));
        Assert.That(response.Responses[0].RevocationTime, Is.Not.Null);
        Assert.That(response.Responses[0].RevocationReason, Is.EqualTo((int)CrlReason.KeyCompromise));
    }

    // ========================================================================
    // Response decoding — error statuses
    // ========================================================================

    [Test]
    public void ResponseDecodeErrorStatus()
    {
        // Unauthorized
        byte[] unauthorizedDer = BuildErrorOcspResponse(OcspResponseStatus.Unauthorized);
        var unauthorized = OcspResponse.Decode(unauthorizedDer);
        Assert.That(unauthorized.ResponseStatus, Is.EqualTo(OcspResponseStatus.Unauthorized));
        Assert.That(unauthorized.Responses, Is.Null);

        // TryLater
        byte[] tryLaterDer = BuildErrorOcspResponse(OcspResponseStatus.TryLater);
        var tryLater = OcspResponse.Decode(tryLaterDer);
        Assert.That(tryLater.ResponseStatus, Is.EqualTo(OcspResponseStatus.TryLater));
        Assert.That(tryLater.Responses, Is.Null);
    }

    // ========================================================================
    // Signature verification
    // ========================================================================

    [Test]
    public void ResponseSignatureVerification()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf = CreateLeaf(caRsa, caCert.Subject);
        var certId = OcspCertId.Create(leaf, caCert);

        var now = TruncateToSeconds(DateTimeOffset.UtcNow);

        using var sigKey = ExportKey(caRsa);
        byte[] responseDer = BuildMockOcspResponse(
            sigKey, certId, OcspCertStatus.Good, now, now.AddDays(7));

        var response = OcspResponse.Decode(responseDer);
        Assert.That(response.VerifySignature(caCert), Is.True);

        // Verify with a different key fails
        using var otherRsa = RSA.Create(2048);
        using var otherKey = ExportKey(otherRsa);
        var otherName = X509Name.FromString("CN=Other CA, C=US");
        var otherCert = new X509CertificateBuilder()
            .SetSubject(otherName)
            .SetSerialNumber(99L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5))
            .SetPublicKey(otherKey)
            .AddBasicConstraints(true)
            .BuildSelfSigned(otherKey);

        Assert.That(response.VerifySignature(otherCert), Is.False);
    }

    // ========================================================================
    // FindResponse matches CertId
    // ========================================================================

    [Test]
    public void FindResponseMatchesCertId()
    {
        using var caRsa = RSA.Create(2048);
        var (caCert, _) = CreateCa(caRsa);

        var leaf1 = CreateLeaf(caRsa, caCert.Subject);
        var leaf2 = CreateLeaf(caRsa, caCert.Subject);

        var certId1 = OcspCertId.Create(leaf1, caCert);
        var certId2 = OcspCertId.Create(leaf2, caCert);

        var now = TruncateToSeconds(DateTimeOffset.UtcNow);

        using var sigKey = ExportKey(caRsa);
        byte[] responseDer = BuildMockOcspResponseMulti(
            sigKey, certId1, certId2, now, now.AddDays(7));

        var response = OcspResponse.Decode(responseDer);

        var found1 = response.FindResponse(certId1);
        Assert.That(found1, Is.Not.Null);
        Assert.That(found1!.Status, Is.EqualTo(OcspCertStatus.Good));
        Assert.That(found1.CertId.SerialNumber, Is.EqualTo(certId1.SerialNumber));

        var found2 = response.FindResponse(certId2);
        Assert.That(found2, Is.Not.Null);
        Assert.That(found2!.CertId.SerialNumber, Is.EqualTo(certId2.SerialNumber));
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static RsaKeyParameters ExportKey(RSA rsa)
    {
        var p = rsa.ExportParameters(true);
        return new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);
    }

    private static (X509Certificate cert, X509Name name) CreateCa(RSA caRsa)
    {
        var name = X509Name.FromString("CN=OCSP Test CA, O=CryptoHives, C=US");
        using var key = ExportKey(caRsa);
        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetSerialNumber(1L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(key)
            .AddBasicConstraints(true)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(key);
        return (cert, name);
    }

    private static X509Certificate CreateLeaf(RSA caRsa, X509Name caName)
    {
        using var leafRsa = RSA.Create(2048);
        using var leafKey = ExportKey(leafRsa);
        using var caKey = ExportKey(caRsa);

        return new X509CertificateBuilder()
            .SetSubject(X509Name.FromString($"CN=leaf-{Guid.NewGuid():N}.example.com"))
            .SetSerialNumber(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafKey)
            .AddBasicConstraints(false)
            .BuildSignedRsa(caKey, caName);
    }

    private static DateTimeOffset TruncateToSeconds(DateTimeOffset dt) =>
        new(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Offset);

    /// <summary>
    /// Builds a mock OCSP response with a single SingleResponse, signed with the given RSA key.
    /// </summary>
    private static byte[] BuildMockOcspResponse(
        RsaKeyParameters signingKey,
        OcspCertId certId,
        OcspCertStatus status,
        DateTimeOffset thisUpdate,
        DateTimeOffset? nextUpdate,
        DateTimeOffset? revocationTime = null,
        int? revocationReason = null)
    {
        // Build ResponseData (TBS)
        byte[] tbsResponseData = BuildResponseData(
            thisUpdate, [(certId, status, thisUpdate, nextUpdate, revocationTime, revocationReason)]);

        // Sign
        string sigAlgOid = "1.2.840.113549.1.1.11"; // sha256WithRSAEncryption
        byte[] hash = CryptoHelper.HashData(HashAlgorithmName.SHA256, tbsResponseData);
        using var rsa = new RsaCipher(signingKey);
        byte[] signature = rsa.SignPkcs1(hash, "SHA256");

        return EncodeFullOcspResponse(tbsResponseData, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a mock OCSP response with two SingleResponses (both Good).
    /// </summary>
    private static byte[] BuildMockOcspResponseMulti(
        RsaKeyParameters signingKey,
        OcspCertId certId1,
        OcspCertId certId2,
        DateTimeOffset thisUpdate,
        DateTimeOffset? nextUpdate)
    {
        byte[] tbsResponseData = BuildResponseData(
            thisUpdate,
            [
                (certId1, OcspCertStatus.Good, thisUpdate, nextUpdate, null, null),
                (certId2, OcspCertStatus.Good, thisUpdate, nextUpdate, null, null),
            ]);

        string sigAlgOid = "1.2.840.113549.1.1.11";
        byte[] hash = CryptoHelper.HashData(HashAlgorithmName.SHA256, tbsResponseData);
        using var rsa = new RsaCipher(signingKey);
        byte[] signature = rsa.SignPkcs1(hash, "SHA256");

        return EncodeFullOcspResponse(tbsResponseData, sigAlgOid, signature);
    }

    private static byte[] BuildResponseData(
        DateTimeOffset producedAt,
        List<(OcspCertId certId, OcspCertStatus status, DateTimeOffset thisUpdate, DateTimeOffset? nextUpdate, DateTimeOffset? revocationTime, int? revocationReason)> entries)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // ResponseData

        // responderID — [1] byName (use a dummy name)
        // ResponderID ::= CHOICE { byName [1] Name, byKey [2] KeyHash }
        var byNameTag = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
        writer.PushSequence(byNameTag);
        var responderName = X509Name.FromString("CN=OCSP Responder");
        responderName.WriteTo(writer);
        writer.PopSequence(byNameTag);

        // producedAt GeneralizedTime
        writer.WriteGeneralizedTime(producedAt, omitFractionalSeconds: true);

        // responses SEQUENCE OF SingleResponse
        writer.PushSequence();
        foreach (var entry in entries)
        {
            WriteSingleResponse(writer, entry.certId, entry.status, entry.thisUpdate, entry.nextUpdate, entry.revocationTime, entry.revocationReason);
        }
        writer.PopSequence();

        writer.PopSequence(); // ResponseData
        return writer.Encode();
    }

    private static void WriteSingleResponse(
        AsnWriter writer,
        OcspCertId certId,
        OcspCertStatus status,
        DateTimeOffset thisUpdate,
        DateTimeOffset? nextUpdate,
        DateTimeOffset? revocationTime,
        int? revocationReason)
    {
        writer.PushSequence(); // SingleResponse

        // certID
        certId.WriteTo(writer);

        // certStatus CHOICE
        switch (status)
        {
            case OcspCertStatus.Good:
                // good [0] IMPLICIT NULL
                writer.WriteNull(new Asn1Tag(TagClass.ContextSpecific, 0));
                break;
            case OcspCertStatus.Revoked:
                // revoked [1] IMPLICIT RevokedInfo
                var revokedTag = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
                writer.PushSequence(revokedTag);
                writer.WriteGeneralizedTime(revocationTime!.Value, omitFractionalSeconds: true);
                if (revocationReason.HasValue)
                {
                    var reasonTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
                    writer.PushSequence(reasonTag);
                    writer.WriteEnumeratedValue((CrlReason)revocationReason.Value);
                    writer.PopSequence(reasonTag);
                }
                writer.PopSequence(revokedTag);
                break;
            case OcspCertStatus.Unknown:
                // unknown [2] IMPLICIT NULL
                writer.WriteNull(new Asn1Tag(TagClass.ContextSpecific, 2));
                break;
        }

        // thisUpdate GeneralizedTime
        writer.WriteGeneralizedTime(thisUpdate, omitFractionalSeconds: true);

        // nextUpdate [0] EXPLICIT GeneralizedTime OPTIONAL
        if (nextUpdate.HasValue)
        {
            var nextUpdateTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
            writer.PushSequence(nextUpdateTag);
            writer.WriteGeneralizedTime(nextUpdate.Value, omitFractionalSeconds: true);
            writer.PopSequence(nextUpdateTag);
        }

        writer.PopSequence(); // SingleResponse
    }

    private static byte[] EncodeFullOcspResponse(byte[] tbsResponseData, string sigAlgOid, byte[] signature)
    {
        // BasicOCSPResponse
        var basicWriter = new AsnWriter(AsnEncodingRules.DER);
        basicWriter.PushSequence();
        basicWriter.WriteEncodedValue(tbsResponseData); // tbsResponseData
        // signatureAlgorithm AlgorithmIdentifier
        basicWriter.PushSequence();
        basicWriter.WriteObjectIdentifier(sigAlgOid);
        basicWriter.WriteNull();
        basicWriter.PopSequence();
        // signature BIT STRING
        basicWriter.WriteBitString(signature);
        basicWriter.PopSequence();
        byte[] basicDer = basicWriter.Encode();

        // ResponseBytes
        var responseBytesWriter = new AsnWriter(AsnEncodingRules.DER);
        responseBytesWriter.PushSequence();
        responseBytesWriter.WriteObjectIdentifier("1.3.6.1.5.5.7.48.1.1");
        responseBytesWriter.WriteOctetString(basicDer);
        responseBytesWriter.PopSequence();
        byte[] responseBytesDer = responseBytesWriter.Encode();

        // OCSPResponse
        var outerWriter = new AsnWriter(AsnEncodingRules.DER);
        outerWriter.PushSequence();
        outerWriter.WriteEnumeratedValue(OcspResponseStatus.Successful);
        // responseBytes [0] EXPLICIT
        var ctx0 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        outerWriter.PushSequence(ctx0);
        outerWriter.WriteEncodedValue(responseBytesDer);
        outerWriter.PopSequence(ctx0);
        outerWriter.PopSequence();

        return outerWriter.Encode();
    }

    private static byte[] BuildErrorOcspResponse(OcspResponseStatus status)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteEnumeratedValue(status);
        writer.PopSequence();
        return writer.Encode();
    }
}
