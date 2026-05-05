// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;

/// <summary>
/// Provides static methods for parsing PKCS#10 Certificate Signing Requests from DER and PEM formats.
/// </summary>
/// <remarks>
/// The parser reads the ASN.1 DER structure per RFC 2986 and produces
/// an immutable <see cref="X509CertificateSigningRequest"/> instance retaining raw
/// CertificationRequestInfo bytes for subsequent signature verification.
/// </remarks>
public static class CsrParser
{
    /// <summary>
    /// OID for the extensionRequest attribute (1.2.840.113549.1.9.14).
    /// </summary>
    internal const string OidExtensionRequest = "1.2.840.113549.1.9.14";

    /// <summary>
    /// Parses a PKCS#10 CSR from DER-encoded bytes.
    /// </summary>
    /// <param name="der">The complete DER-encoded CSR.</param>
    /// <returns>The parsed <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="CryptographicException">The data is not a valid CSR.</exception>
    public static X509CertificateSigningRequest ParseDer(ReadOnlySpan<byte> der)
    {
        byte[] rawDer = der.ToArray();

        var reader = new AsnReader(rawDer, AsnEncodingRules.DER);
        var csrSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // Capture raw CertificationRequestInfo bytes before parsing
        ReadOnlyMemory<byte> criRaw = csrSeq.PeekEncodedValue();
        byte[] certificationRequestInfoDer = criRaw.ToArray();

        var criReader = csrSeq.ReadSequence();

        // Version INTEGER
        int version = (int)criReader.ReadInteger() + 1; // v1 = 0 in encoding

        // Subject Name
        X509Name subject = X509Name.ParseDer(criReader);

        // SubjectPublicKeyInfo — capture raw SPKI bytes
        ReadOnlyMemory<byte> spkiRaw = criReader.PeekEncodedValue();
        byte[] spkiDer = spkiRaw.ToArray();

        // Parse the SPKI to get the algorithm OID
        var spkiReader = criReader.ReadSequence();
        var spkiAlgSeq = spkiReader.ReadSequence();
        string spkiAlgOid = spkiAlgSeq.ReadObjectIdentifier();
        while (spkiAlgSeq.HasData) spkiAlgSeq.ReadEncodedValue(); // skip parameters
        spkiReader.ReadBitString(out _); // public key bits
        spkiReader.ThrowIfNotEmpty();

        // Attributes [0] IMPLICIT SET OF Attribute
        X509ExtensionCollection extensions = X509ExtensionCollection.Empty;
        var attrsTag = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (criReader.HasData && criReader.PeekTag().HasSameClassAndValue(attrsTag))
        {
            var attrsReader = criReader.ReadSequence(attrsTag);
            while (attrsReader.HasData)
            {
                var attrSeq = attrsReader.ReadSequence();
                string attrOid = attrSeq.ReadObjectIdentifier();

                if (attrOid == OidExtensionRequest)
                {
                    // values SET OF Extensions
                    var valuesSet = attrSeq.ReadSetOf();
                    if (valuesSet.HasData)
                    {
                        // Extensions ::= SEQUENCE OF Extension
                        var extsSeq = valuesSet.ReadSequence();
                        var extList = new List<X509Extension>();
                        while (extsSeq.HasData)
                        {
                            var extSeq = extsSeq.ReadSequence();
                            string extOid = extSeq.ReadObjectIdentifier();
                            bool critical = false;
                            if (extSeq.HasData && extSeq.PeekTag().HasSameClassAndValue(
                                new Asn1Tag(UniversalTagNumber.Boolean)))
                            {
                                critical = extSeq.ReadBoolean();
                            }
                            byte[] extValue = extSeq.ReadOctetString();
                            extSeq.ThrowIfNotEmpty();
                            extList.Add(new X509Extension(extOid, critical, extValue));
                        }
                        extensions = new X509ExtensionCollection(extList);
                    }
                }
                else
                {
                    // Skip unknown attributes
                    while (attrSeq.HasData) attrSeq.ReadEncodedValue();
                }
            }
        }

        // Outer: signatureAlgorithm
        var sigAlgSeq = csrSeq.ReadSequence();
        string sigAlgOid = sigAlgSeq.ReadObjectIdentifier();
        while (sigAlgSeq.HasData) sigAlgSeq.ReadEncodedValue();

        // Outer: signature BIT STRING
        byte[] signatureValue = csrSeq.ReadBitString(out _);
        csrSeq.ThrowIfNotEmpty();

        return new X509CertificateSigningRequest(
            version,
            subject,
            spkiDer,
            spkiAlgOid,
            extensions,
            sigAlgOid,
            signatureValue,
            certificationRequestInfoDer,
            rawDer);
    }

    /// <summary>
    /// Parses a PKCS#10 CSR from a PEM-encoded string.
    /// </summary>
    /// <param name="pem">The PEM-encoded CSR string.</param>
    /// <returns>The parsed <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pem"/> is <c>null</c>.</exception>
    /// <exception cref="CryptographicException">The PEM data is not a valid CSR.</exception>
    public static X509CertificateSigningRequest ParsePem(string pem)
    {
        if (pem is null) throw new ArgumentNullException(nameof(pem));
        byte[] der = PemHelper.Decode(pem, out string label);
        if (!label.Equals("CERTIFICATE REQUEST", StringComparison.OrdinalIgnoreCase) &&
            !label.Equals("NEW CERTIFICATE REQUEST", StringComparison.OrdinalIgnoreCase))
            throw new CryptographicException($"Unexpected PEM label: {label}");
        return ParseDer(der);
    }
}
