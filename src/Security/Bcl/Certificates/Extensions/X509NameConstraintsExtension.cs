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
/// The Name Constraints extension.
/// </summary>
public sealed class X509NameConstraintsExtension : X509Extension
{
    private const string kFriendlyName = "Name Constraints";

    /// <summary>
    /// The OID for Name Constraints extension.
    /// </summary>
    public const string NameConstraintsOid = Oids.NameConstraints;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509NameConstraintsExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.",
            nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509NameConstraintsExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509NameConstraintsExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Name Constraints extension for DNS constraints.
    /// </summary>
    /// <param name="permittedDnsDomains">Permitted DNS subtrees.</param>
    /// <param name="excludedDnsDomains">Excluded DNS subtrees.</param>
    public X509NameConstraintsExtension(IEnumerable<string>? permittedDnsDomains = null, IEnumerable<string>? excludedDnsDomains = null)
    {
        Oid = new Oid(NameConstraintsOid, kFriendlyName);
        Critical = true;

        if (permittedDnsDomains != null)
        {
            foreach (string domain in permittedDnsDomains)
            {
                if (!string.IsNullOrWhiteSpace(domain))
                {
                    _permittedDnsDomains.Add(domain);
                }
            }
        }

        if (excludedDnsDomains != null)
        {
            foreach (string domain in excludedDnsDomains)
            {
                if (!string.IsNullOrWhiteSpace(domain))
                {
                    _excludedDnsDomains.Add(domain);
                }
            }
        }

        if (_permittedDnsDomains.Count == 0 && _excludedDnsDomains.Count == 0)
        {
            throw new ArgumentException("At least one permitted or excluded DNS subtree is required.");
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets permitted DNS domains.
    /// </summary>
    public IReadOnlyList<string> PermittedDnsDomains => _permittedDnsDomains.AsReadOnly();

    /// <summary>
    /// Gets excluded DNS domains.
    /// </summary>
    public IReadOnlyList<string> ExcludedDnsDomains => _excludedDnsDomains.AsReadOnly();

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();

        foreach (string domain in _permittedDnsDomains)
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
            buffer.Append("PermittedDNS=");
            buffer.Append(domain);
        }

        foreach (string domain in _excludedDnsDomains)
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
            buffer.Append("ExcludedDNS=");
            buffer.Append(domain);
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
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        var context0 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true);
        var context1 = new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true);
        var dnsTag = new Asn1Tag(TagClass.ContextSpecific, 2);

        writer.PushSequence();

        if (_permittedDnsDomains.Count > 0)
        {
            writer.PushSequence(context0);
            foreach (string domain in _permittedDnsDomains)
            {
                writer.PushSequence();
                writer.WriteCharacterString(UniversalTagNumber.IA5String, domain, dnsTag);
                writer.PopSequence();
            }
            writer.PopSequence(context0);
        }

        if (_excludedDnsDomains.Count > 0)
        {
            writer.PushSequence(context1);
            foreach (string domain in _excludedDnsDomains)
            {
                writer.PushSequence();
                writer.WriteCharacterString(UniversalTagNumber.IA5String, domain, dnsTag);
                writer.PopSequence();
            }
            writer.PopSequence(context1);
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != NameConstraintsOid)
        {
            throw new CryptographicException("Invalid NameConstraintsOid.");
        }

        _permittedDnsDomains.Clear();
        _excludedDnsDomains.Clear();

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            while (sequence.HasData)
            {
                Asn1Tag tag = sequence.PeekTag();
                if (tag.TagClass == TagClass.ContextSpecific && (tag.TagValue == 0 || tag.TagValue == 1))
                {
                    AsnReader subtrees = sequence.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, tag.TagValue, isConstructed: true));
                    while (subtrees.HasData)
                    {
                        AsnReader subtree = subtrees.ReadSequence();
                        if (subtree.HasData)
                        {
                            Asn1Tag baseTag = subtree.PeekTag();
                            if (baseTag.TagClass == TagClass.ContextSpecific && baseTag.TagValue == 2)
                            {
                                string dns = subtree.ReadCharacterString(UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 2));
                                if (tag.TagValue == 0)
                                {
                                    _permittedDnsDomains.Add(dns);
                                }
                                else
                                {
                                    _excludedDnsDomains.Add(dns);
                                }
                            }
                        }

                        while (subtree.HasData)
                        {
                            subtree.ReadEncodedValue();
                        }
                    }
                }
                else
                {
                    sequence.ReadEncodedValue();
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Name Constraints extension.", ace);
        }
    }

    private readonly List<string> _permittedDnsDomains = [];
    private readonly List<string> _excludedDnsDomains = [];
}
