// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;

/// <summary>
/// Provides static methods for parsing X.509 certificates from DER and PEM formats.
/// </summary>
/// <remarks>
/// The parser reads the ASN.1 DER structure per RFC 5280 §4.1 and produces
/// an immutable <see cref="X509Certificate"/> instance retaining raw TBS bytes
/// for subsequent signature verification.
/// </remarks>
public static class X509CertificateParser
{
    /// <summary>
    /// Parses an X.509 certificate from DER-encoded bytes.
    /// </summary>
    /// <param name="der">The complete DER-encoded certificate.</param>
    /// <returns>The parsed <see cref="X509Certificate"/>.</returns>
    /// <exception cref="CryptographicException">The data is not a valid X.509 certificate.</exception>
    public static X509Certificate ParseDer(ReadOnlySpan<byte> der)
    {
        byte[] rawDer = der.ToArray();

        var reader = new AsnReader(rawDer, AsnEncodingRules.DER);
        var certSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // Capture raw TBS bytes before parsing
        ReadOnlyMemory<byte> tbsRaw = certSeq.PeekEncodedValue();
        byte[] tbsCertificateDer = tbsRaw.ToArray();

        var tbsReader = certSeq.ReadSequence();

        // Version [0] EXPLICIT INTEGER DEFAULT v1
        int version = 1;
        var versionTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(versionTag))
        {
            var versionReader = tbsReader.ReadSequence(versionTag);
            version = (int)versionReader.ReadInteger() + 1;
            versionReader.ThrowIfNotEmpty();
        }

        // SerialNumber INTEGER
        ReadOnlyMemory<byte> serialBytes = tbsReader.ReadIntegerBytes();
        byte[] serialNumber = serialBytes.ToArray();

        // Signature AlgorithmIdentifier
        ReadAlgorithmIdentifier(tbsReader, out string tbsSigAlgOid);

        // Issuer Name
        X509Name issuer = X509Name.ParseDer(tbsReader);

        // Validity SEQUENCE { notBefore, notAfter }
        var validitySeq = tbsReader.ReadSequence();
        DateTimeOffset notBefore = ReadTime(validitySeq);
        DateTimeOffset notAfter = ReadTime(validitySeq);
        validitySeq.ThrowIfNotEmpty();

        // Subject Name
        X509Name subject = X509Name.ParseDer(tbsReader);

        // SubjectPublicKeyInfo — capture raw SPKI bytes
        ReadOnlyMemory<byte> spkiRaw = tbsReader.PeekEncodedValue();
        byte[] spkiDer = spkiRaw.ToArray();

        // Parse the SPKI to get the algorithm OID
        var spkiReader = tbsReader.ReadSequence();
        ReadAlgorithmIdentifier(spkiReader, out string spkiAlgOid);
        spkiReader.ReadBitString(out _);
        spkiReader.ThrowIfNotEmpty();

        // Optional extensions [3] EXPLICIT
        X509ExtensionCollection extensions = X509ExtensionCollection.Empty;
        var ctx3 = new Asn1Tag(TagClass.ContextSpecific, 3, isConstructed: true);
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(ctx3))
        {
            extensions = X509ExtensionCollection.ParseExtensions(tbsReader);
        }

        // Skip any remaining optional fields (issuerUniqueID [1], subjectUniqueID [2])
        // These are rarely used and appear before extensions

        // Outer: signatureAlgorithm
        ReadAlgorithmIdentifier(certSeq, out string sigAlgOid);

        // Outer: signatureValue BIT STRING
        byte[] signatureValue = certSeq.ReadBitString(out int unusedBits);
        certSeq.ThrowIfNotEmpty();

        return new X509Certificate(
            version,
            serialNumber,
            sigAlgOid,
            issuer,
            notBefore,
            notAfter,
            subject,
            spkiDer,
            extensions,
            signatureValue,
            tbsCertificateDer,
            rawDer,
            spkiAlgOid);
    }

    /// <summary>
    /// Parses an X.509 certificate from a PEM-encoded string.
    /// </summary>
    /// <param name="pem">The PEM-encoded certificate string.</param>
    /// <returns>The parsed <see cref="X509Certificate"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pem"/> is <c>null</c>.</exception>
    /// <exception cref="CryptographicException">The PEM data is not a valid certificate.</exception>
    public static X509Certificate ParsePem(string pem)
    {
        if (pem is null) throw new ArgumentNullException(nameof(pem));

        byte[] der = PemHelper.Decode(pem, out string label);
        return ParseDer(der);
    }

    /// <summary>
    /// Parses an X.509 certificate from a PEM-encoded character span.
    /// </summary>
    /// <param name="pem">The PEM-encoded certificate characters.</param>
    /// <returns>The parsed <see cref="X509Certificate"/>.</returns>
    /// <exception cref="CryptographicException">The PEM data is not a valid certificate.</exception>
    public static X509Certificate ParsePem(ReadOnlySpan<char> pem)
    {
        return ParsePem(pem.ToString());
    }

    private static void ReadAlgorithmIdentifier(AsnReader reader, out string algorithmOid)
    {
        var algSeq = reader.ReadSequence();
        algorithmOid = algSeq.ReadObjectIdentifier();

        // Skip optional parameters (NULL, OID, or other)
        while (algSeq.HasData)
            algSeq.ReadEncodedValue();
    }

    private static DateTimeOffset ReadTime(AsnReader reader)
    {
        Asn1Tag tag = reader.PeekTag();
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.UtcTime)))
            return reader.ReadUtcTime();
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.GeneralizedTime)))
            return reader.ReadGeneralizedTime();
        throw new CryptographicException("Invalid time encoding in certificate validity.");
    }
}
