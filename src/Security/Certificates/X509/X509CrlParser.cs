// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;

/// <summary>
/// Provides static methods for parsing X.509 CRLs from DER and PEM formats.
/// </summary>
/// <remarks>
/// The parser reads the ASN.1 DER structure per RFC 5280 §5.1 and produces
/// an immutable <see cref="X509Crl"/> instance retaining raw TBS bytes
/// for subsequent signature verification.
/// </remarks>
public static class X509CrlParser
{
    /// <summary>
    /// OID for the CRLReason entry extension.
    /// </summary>
    internal const string OidCrlReason = "2.5.29.21";

    /// <summary>
    /// Parses an X.509 CRL from DER-encoded bytes.
    /// </summary>
    /// <param name="der">The complete DER-encoded CRL.</param>
    /// <returns>The parsed <see cref="X509Crl"/>.</returns>
    /// <exception cref="CryptographicException">The data is not a valid X.509 CRL.</exception>
    public static X509Crl ParseDer(ReadOnlySpan<byte> der)
    {
        byte[] rawDer = der.ToArray();

        var reader = new AsnReader(rawDer, AsnEncodingRules.DER);
        var crlSeq = reader.ReadSequence();
        reader.ThrowIfNotEmpty();

        // Capture raw TBS bytes before parsing
        ReadOnlyMemory<byte> tbsRaw = crlSeq.PeekEncodedValue();
        byte[] tbsCertListDer = tbsRaw.ToArray();

        var tbsReader = crlSeq.ReadSequence();

        // Version INTEGER OPTIONAL (default v1)
        int version = 1;
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(
            new Asn1Tag(UniversalTagNumber.Integer)))
        {
            // Peek ahead to see if this is the version or the start of signature AlgId
            // Version is a bare INTEGER; signature is a SEQUENCE (AlgorithmIdentifier).
            // We need to check if the next-next element is also a SEQUENCE to determine
            // if this INTEGER is the version.
            // Per RFC 5280 §5.1.2.1: version is present only if v2.
            // Strategy: try reading as version. If value is 1 (v2), accept it.
            // If value is something else, it might still be version or serial.
            // Actually, TBSCertList starts with optional version INTEGER then
            // signature AlgorithmIdentifier (SEQUENCE). So if the first element
            // is an INTEGER, it must be the version field since AlgId is a SEQUENCE.
            version = (int)tbsReader.ReadInteger() + 1;
        }

        // Signature AlgorithmIdentifier
        ReadAlgorithmIdentifier(tbsReader, out string tbsSigAlgOid);

        // Issuer Name
        X509Name issuer = X509Name.ParseDer(tbsReader);

        // thisUpdate Time
        DateTimeOffset thisUpdate = ReadTime(tbsReader);

        // nextUpdate Time OPTIONAL
        DateTimeOffset? nextUpdate = null;
        if (tbsReader.HasData)
        {
            Asn1Tag nextTag = tbsReader.PeekTag();
            if (nextTag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.UtcTime)) ||
                nextTag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.GeneralizedTime)))
            {
                nextUpdate = ReadTime(tbsReader);
            }
        }

        // revokedCertificates SEQUENCE OF SEQUENCE OPTIONAL
        var revokedCerts = new List<RevokedCertificate>();
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(
            new Asn1Tag(UniversalTagNumber.Sequence, isConstructed: true)))
        {
            // Could be revokedCertificates or crlExtensions [0] EXPLICIT
            // revokedCertificates is a plain SEQUENCE; crlExtensions is [0] EXPLICIT
            var revokedSeq = tbsReader.ReadSequence();
            while (revokedSeq.HasData)
            {
                var entrySeq = revokedSeq.ReadSequence();

                // userCertificate CertificateSerialNumber (INTEGER)
                ReadOnlyMemory<byte> serialBytes = entrySeq.ReadIntegerBytes();
                byte[] serial = serialBytes.ToArray();

                // revocationDate Time
                DateTimeOffset revDate = ReadTime(entrySeq);

                // crlEntryExtensions Extensions OPTIONAL
                CrlReason reason = CrlReason.Unspecified;
                if (entrySeq.HasData)
                {
                    var entryExtSeq = entrySeq.ReadSequence();
                    while (entryExtSeq.HasData)
                    {
                        var extEntry = entryExtSeq.ReadSequence();
                        string extOid = extEntry.ReadObjectIdentifier();

                        // Skip critical flag if present
                        if (extEntry.HasData && extEntry.PeekTag().HasSameClassAndValue(
                            new Asn1Tag(UniversalTagNumber.Boolean)))
                        {
                            extEntry.ReadBoolean();
                        }

                        byte[] extValue = extEntry.ReadOctetString();
                        extEntry.ThrowIfNotEmpty();

                        if (extOid == OidCrlReason)
                        {
                            var reasonReader = new AsnReader(extValue, AsnEncodingRules.DER);
                            reason = (CrlReason)(int)reasonReader.ReadEnumeratedValue<CrlReason>();
                            reasonReader.ThrowIfNotEmpty();
                        }
                    }
                }

                entrySeq.ThrowIfNotEmpty();
                revokedCerts.Add(new RevokedCertificate(serial, revDate, reason));
            }
        }

        // crlExtensions [0] EXPLICIT Extensions OPTIONAL
        X509ExtensionCollection extensions = X509ExtensionCollection.Empty;
        var ctx0 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        if (tbsReader.HasData && tbsReader.PeekTag().HasSameClassAndValue(ctx0))
        {
            var explicitReader = tbsReader.ReadSequence(ctx0);
            var extSeq = explicitReader.ReadSequence();
            explicitReader.ThrowIfNotEmpty();

            var extList = new List<X509Extension>();
            while (extSeq.HasData)
            {
                var extEntry = extSeq.ReadSequence();
                string oid = extEntry.ReadObjectIdentifier();

                bool critical = false;
                if (extEntry.HasData && extEntry.PeekTag().HasSameClassAndValue(
                    new Asn1Tag(UniversalTagNumber.Boolean)))
                {
                    critical = extEntry.ReadBoolean();
                }

                byte[] value = extEntry.ReadOctetString();
                extEntry.ThrowIfNotEmpty();
                extList.Add(new X509Extension(oid, critical, value));
            }

            extensions = new X509ExtensionCollection(extList.AsReadOnly());
        }

        tbsReader.ThrowIfNotEmpty();

        // Outer: signatureAlgorithm
        ReadAlgorithmIdentifier(crlSeq, out string sigAlgOid);

        // Outer: signatureValue BIT STRING
        byte[] signatureValue = crlSeq.ReadBitString(out int unusedBits);
        crlSeq.ThrowIfNotEmpty();

        return new X509Crl(
            version,
            issuer,
            thisUpdate,
            nextUpdate,
            revokedCerts.AsReadOnly(),
            extensions,
            sigAlgOid,
            signatureValue,
            tbsCertListDer,
            rawDer);
    }

    /// <summary>
    /// Parses an X.509 CRL from a PEM-encoded string.
    /// </summary>
    /// <param name="pem">The PEM-encoded CRL string.</param>
    /// <returns>The parsed <see cref="X509Crl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pem"/> is <c>null</c>.</exception>
    /// <exception cref="CryptographicException">The PEM data is not a valid CRL.</exception>
    public static X509Crl ParsePem(string pem)
    {
        if (pem is null) throw new ArgumentNullException(nameof(pem));

        byte[] der = PemHelper.Decode(pem, out string label);
        return ParseDer(der);
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
        throw new CryptographicException("Invalid time encoding in CRL.");
    }
}
