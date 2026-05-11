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
/// The Issuing Distribution Point extension.
/// </summary>
public sealed class X509IssuingDistributionPointExtension : X509Extension
{
    private const string kFriendlyName = "Issuing Distribution Point";

    /// <summary>
    /// The OID for Issuing Distribution Point extension.
    /// </summary>
    public const string IssuingDistributionPointOid = Oids.IssuingDistributionPoint;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509IssuingDistributionPointExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)),
              encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509IssuingDistributionPointExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509IssuingDistributionPointExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds an Issuing Distribution Point extension.
    /// </summary>
    /// <param name="distributionPointUris">The distribution point URIs.</param>
    /// <param name="indirectCrl">Whether this is an indirect CRL.</param>
    public X509IssuingDistributionPointExtension(IEnumerable<string>? distributionPointUris = null, bool indirectCrl = false)
    {
        Oid = new Oid(IssuingDistributionPointOid, kFriendlyName);
        Critical = true;

        if (distributionPointUris != null)
        {
            foreach (string uri in distributionPointUris)
            {
                if (!string.IsNullOrWhiteSpace(uri))
                {
                    _distributionPointUris.Add(uri);
                }
            }
        }

        IndirectCrl = indirectCrl;

        if (_distributionPointUris.Count == 0 && !IndirectCrl)
        {
            throw new ArgumentException("At least one distribution point URI or indirectCRL flag is required.");
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets the distribution point URIs.
    /// </summary>
    public IReadOnlyList<string> DistributionPointUris => _distributionPointUris.AsReadOnly();

    /// <summary>
    /// Gets a value indicating whether this issuing distribution point is indirect.
    /// </summary>
    public bool IndirectCrl { get; private set; }

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

        buffer.Append("IndirectCRL=");
        buffer.Append(IndirectCrl);
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
        var context0 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        var context4 = new Asn1Tag(TagClass.ContextSpecific, 4);
        var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);

        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        writer.PushSequence();

        if (_distributionPointUris.Count > 0)
        {
            writer.PushSequence(context0);
            writer.PushSequence(context0);
            foreach (string uri in _distributionPointUris)
            {
                writer.WriteCharacterString(UniversalTagNumber.IA5String, uri, uriTag);
            }
            writer.PopSequence(context0);
            writer.PopSequence(context0);
        }

        if (IndirectCrl)
        {
            writer.WriteBoolean(true, context4);
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != IssuingDistributionPointOid)
        {
            throw new CryptographicException("Invalid IssuingDistributionPointOid.");
        }

        _distributionPointUris.Clear();
        IndirectCrl = false;

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            AsnReader sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            while (sequence.HasData)
            {
                Asn1Tag tag = sequence.PeekTag();
                if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 0)
                {
                    AsnReader dpName = sequence.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
                    if (dpName.HasData && dpName.PeekTag().HasSameClassAndValue(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true)))
                    {
                        AsnReader fullName = dpName.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
                        while (fullName.HasData)
                        {
                            Asn1Tag innerTag = fullName.PeekTag();
                            if (innerTag.TagClass == TagClass.ContextSpecific && innerTag.TagValue == 6)
                            {
                                _distributionPointUris.Add(fullName.ReadCharacterString(UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 6)));
                            }
                            else
                            {
                                fullName.ReadEncodedValue();
                            }
                        }
                    }
                }
                else if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 4)
                {
                    IndirectCrl = sequence.ReadBoolean(new Asn1Tag(TagClass.ContextSpecific, 4));
                }
                else
                {
                    sequence.ReadEncodedValue();
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Issuing Distribution Point extension.", ace);
        }
    }

    private readonly List<string> _distributionPointUris = [];
}
