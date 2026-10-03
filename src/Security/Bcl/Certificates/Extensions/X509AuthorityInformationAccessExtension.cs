// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The Authority Information Access extension.
/// </summary>
/// <remarks>
/// <para>
/// id-pe-authorityInfoAccess OBJECT IDENTIFIER ::= { id-pe 1 }
/// </para>
/// <para>
/// AuthorityInfoAccessSyntax ::= SEQUENCE SIZE (1..MAX) OF AccessDescription
/// </para>
/// <para>
/// AccessDescription  ::=  SEQUENCE {
///     accessMethod          OBJECT IDENTIFIER,
///     accessLocation        GeneralName  }
/// </para>
/// </remarks>
public sealed class X509AuthorityInformationAccessExtension : X509Extension
{
    private const string kFriendlyName = "Authority Information Access";

    /// <summary>
    /// The OID for Authority Information Access extension.
    /// </summary>
    public const string AuthorityInformationAccessOid = Oids.AuthorityInfoAccess;

    /// <summary>
    /// The access method OID for OCSP responder.
    /// </summary>
    public const string OcspResponderOid = Oids.OnlineCertificateStatusProtocol;

    /// <summary>
    /// The access method OID for CA Issuers endpoint.
    /// </summary>
    public const string CaIssuersOid = Oids.CertificateAuthorityIssuers;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509AuthorityInformationAccessExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.",
            nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509AuthorityInformationAccessExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509AuthorityInformationAccessExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds an Authority Information Access extension.
    /// </summary>
    /// <param name="caIssuerUris">The CA Issuers URI endpoints.</param>
    /// <param name="ocspResponderUri">The OCSP responder URI endpoint.</param>
    public X509AuthorityInformationAccessExtension(IEnumerable<string> caIssuerUris, string? ocspResponderUri = null)
    {
        if (caIssuerUris == null)
        {
            throw new ArgumentNullException(nameof(caIssuerUris));
        }

        Oid = new Oid(AuthorityInformationAccessOid, kFriendlyName);
        Critical = false;

        foreach (string uri in caIssuerUris)
        {
            if (!string.IsNullOrWhiteSpace(uri))
            {
                _caIssuersUris.Add(uri);
            }
        }

        if (!string.IsNullOrWhiteSpace(ocspResponderUri))
        {
            _ocspResponderUris.Add(ocspResponderUri!);
        }

        if (_caIssuersUris.Count == 0 && _ocspResponderUris.Count == 0)
        {
            throw new ArgumentException("At least one CA Issuers or OCSP URI must be provided.", nameof(caIssuerUris));
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets the OCSP responder URIs.
    /// </summary>
    public IReadOnlyList<string> OcspResponderUris => _ocspResponderUris.AsReadOnly();

    /// <summary>
    /// Gets the CA issuers URIs.
    /// </summary>
    public IReadOnlyList<string> CaIssuersUris => _caIssuersUris.AsReadOnly();

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();

        for (int i = 0; i < _ocspResponderUris.Count; i++)
        {
            if (buffer.Length > 0)
            {
                if (multiLine)
                {
                    buffer.AppendLine();
                }
                else
                {
                    buffer.Append(", ");
                }
            }

            buffer.Append("OCSP=");
            buffer.Append(_ocspResponderUris[i]);
        }

        for (int i = 0; i < _caIssuersUris.Count; i++)
        {
            if (buffer.Length > 0)
            {
                if (multiLine)
                {
                    buffer.AppendLine();
                }
                else
                {
                    buffer.Append(", ");
                }
            }

            buffer.Append("CA Issuers=");
            buffer.Append(_caIssuersUris[i]);
        }

        return buffer.ToString();
    }

    /// <inheritdoc />
    public override void CopyFrom(AsnEncodedData asnEncodedData)
    {
        if (asnEncodedData == null)
        {
            throw new ArgumentNullException(nameof(asnEncodedData));
        }

        Oid = asnEncodedData.Oid;
        RawData = asnEncodedData.RawData;
        Decode(RawData);
    }

    private byte[] Encode()
    {
        var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        writer.PushSequence();

        foreach (string uri in _ocspResponderUris)
        {
            writer.PushSequence();
            writer.WriteObjectIdentifier(OcspResponderOid);
            writer.WriteCharacterString(UniversalTagNumber.IA5String, uri, uriTag);
            writer.PopSequence();
        }

        foreach (string uri in _caIssuersUris)
        {
            writer.PushSequence();
            writer.WriteObjectIdentifier(CaIssuersOid);
            writer.WriteCharacterString(UniversalTagNumber.IA5String, uri, uriTag);
            writer.PopSequence();
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != AuthorityInformationAccessOid)
        {
            throw new CryptographicException("Invalid AuthorityInformationAccessOid.");
        }

        _caIssuersUris.Clear();
        _ocspResponderUris.Clear();

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);

            while (seq.HasData)
            {
                var accessDescription = seq.ReadSequence();
                string method = accessDescription.ReadObjectIdentifier();
                string uri = accessDescription.ReadCharacterString(UniversalTagNumber.IA5String, uriTag);
                accessDescription.ThrowIfNotEmpty();

                if (method == OcspResponderOid)
                {
                    _ocspResponderUris.Add(uri);
                }
                else if (method == CaIssuersOid)
                {
                    _caIssuersUris.Add(uri);
                }
            }

            seq.ThrowIfNotEmpty();
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the AuthorityInformationAccess extension.", ace);
        }
    }

    private readonly List<string> _ocspResponderUris = [];
    private readonly List<string> _caIssuersUris = [];
}
