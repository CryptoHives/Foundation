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
/// The CRL Distribution Points extension.
/// </summary>
/// <remarks>
/// <para>
/// id-ce-cRLDistributionPoints OBJECT IDENTIFIER ::= { id-ce 31 }
/// </para>
/// <para>
/// CRLDistributionPoints ::= SEQUENCE SIZE (1..MAX) OF DistributionPoint
/// </para>
/// </remarks>
public sealed class X509CrlDistributionPointsExtension : X509Extension
{
    private const string kFriendlyName = "CRL Distribution Points";

    /// <summary>
    /// The OID for CRL Distribution Points extension.
    /// </summary>
    public const string CrlDistributionPointsOid = Oids.CRLDistributionPoint;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CrlDistributionPointsExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)),
            encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509CrlDistributionPointsExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CrlDistributionPointsExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a CRL Distribution Points extension.
    /// </summary>
    /// <param name="distributionPointUris">The distribution point URIs.</param>
    public X509CrlDistributionPointsExtension(IEnumerable<string> distributionPointUris)
    {
        if (distributionPointUris == null)
        {
            throw new ArgumentNullException(nameof(distributionPointUris));
        }

        Oid = new Oid(CrlDistributionPointsOid, kFriendlyName);
        Critical = false;

        foreach (string uri in distributionPointUris)
        {
            if (!string.IsNullOrWhiteSpace(uri))
            {
                _distributionPointUris.Add(uri);
            }
        }

        if (_distributionPointUris.Count == 0)
        {
            throw new ArgumentException("At least one distribution point URI must be provided.", nameof(distributionPointUris));
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets the distribution point URIs.
    /// </summary>
    public IReadOnlyList<string> DistributionPointUris => _distributionPointUris.AsReadOnly();

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();

        for (int i = 0; i < _distributionPointUris.Count; i++)
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

            buffer.Append("URI=");
            buffer.Append(_distributionPointUris[i]);
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
        var context0 = new Asn1Tag(TagClass.ContextSpecific, 0, true);
        var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);

        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        writer.PushSequence();

        foreach (string uri in _distributionPointUris)
        {
            writer.PushSequence();
            writer.PushSequence(context0); // distributionPoint [0]
            writer.PushSequence(context0); // fullName [0]
            writer.WriteCharacterString(UniversalTagNumber.IA5String, uri, uriTag);
            writer.PopSequence(context0);
            writer.PopSequence(context0);
            writer.PopSequence();
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != CrlDistributionPointsOid)
        {
            throw new CryptographicException("Invalid CrlDistributionPointsOid.");
        }

        _distributionPointUris.Clear();

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var distributionPointTag = new Asn1Tag(TagClass.ContextSpecific, 0, true);
            var fullNameTag = new Asn1Tag(TagClass.ContextSpecific, 0, true);
            var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);

            while (sequence.HasData)
            {
                var distributionPoint = sequence.ReadSequence();

                if (distributionPoint.HasData && distributionPoint.PeekTag() == distributionPointTag)
                {
                    var distributionPointName = distributionPoint.ReadSequence(distributionPointTag);
                    if (distributionPointName.HasData && distributionPointName.PeekTag() == fullNameTag)
                    {
                        var fullName = distributionPointName.ReadSequence(fullNameTag);
                        while (fullName.HasData)
                        {
                            Asn1Tag tag = fullName.PeekTag();
                            if (tag == uriTag)
                            {
                                string uri = fullName.ReadCharacterString(UniversalTagNumber.IA5String, uriTag);
                                _distributionPointUris.Add(uri);
                            }
                            else
                            {
                                fullName.ReadEncodedValue();
                            }
                        }
                    }
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the CrlDistributionPoints extension.", ace);
        }
    }

    private readonly List<string> _distributionPointUris = [];
}
