// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// The Freshest CRL extension.
/// </summary>
public sealed class X509FreshestCrlExtension : X509Extension
{
    private const string kFriendlyName = "Freshest CRL";

    /// <summary>
    /// The OID for Freshest CRL extension.
    /// </summary>
    public const string FreshestCrlOid = Oids.FreshestCrl;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509FreshestCrlExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)),
            encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509FreshestCrlExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509FreshestCrlExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Freshest CRL extension.
    /// </summary>
    /// <param name="distributionPointUris">The distribution point URIs.</param>
    public X509FreshestCrlExtension(IEnumerable<string> distributionPointUris)
    {
        if (distributionPointUris == null)
        {
            throw new ArgumentNullException(nameof(distributionPointUris));
        }

        Oid = new Oid(FreshestCrlOid, kFriendlyName);
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
        return string.Join(multiLine ? Environment.NewLine : ", ", _distributionPointUris);
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
            writer.PushSequence(context0);
            writer.PushSequence(context0);
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
        if (oidValue != FreshestCrlOid)
        {
            throw new CryptographicException("Invalid FreshestCrlOid.");
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
                                _distributionPointUris.Add(fullName.ReadCharacterString(UniversalTagNumber.IA5String, uriTag));
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
            throw new CryptographicException("Failed to decode the Freshest CRL extension.", ace);
        }
    }

    private readonly List<string> _distributionPointUris = [];
}
