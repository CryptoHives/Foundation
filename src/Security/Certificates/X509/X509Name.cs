// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

/// <summary>
/// Represents an X.500 Distinguished Name (DN) per RFC 5280 §4.1.2.4.
/// </summary>
/// <remarks>
/// <para>
/// A Distinguished Name is an ordered sequence of Relative Distinguished Name (RDN)
/// attribute type-value pairs such as CN, O, OU, C, ST, and L.
/// </para>
/// <para>
/// This class stores the attributes in DER encoding order and renders
/// <see cref="ToString()"/> in RFC 2253 reverse order.
/// </para>
/// </remarks>
public sealed class X509Name : IEquatable<X509Name>
{
    /// <summary>OID for Common Name (CN).</summary>
    public const string OidCN = "2.5.4.3";

    /// <summary>OID for Organization (O).</summary>
    public const string OidO = "2.5.4.10";

    /// <summary>OID for Organizational Unit (OU).</summary>
    public const string OidOU = "2.5.4.11";

    /// <summary>OID for Country (C).</summary>
    public const string OidC = "2.5.4.6";

    /// <summary>OID for State or Province (ST).</summary>
    public const string OidST = "2.5.4.8";

    /// <summary>OID for Locality (L).</summary>
    public const string OidL = "2.5.4.7";

    /// <summary>OID for Email Address (E).</summary>
    public const string OidE = "1.2.840.113549.1.9.1";

    /// <summary>OID for Serial Number.</summary>
    public const string OidSerialNumber = "2.5.4.5";

    private static readonly Dictionary<string, string> OidToShortName = new()
    {
        [OidCN] = "CN",
        [OidO] = "O",
        [OidOU] = "OU",
        [OidC] = "C",
        [OidST] = "ST",
        [OidL] = "L",
        [OidE] = "E",
        [OidSerialNumber] = "SERIALNUMBER",
    };

    private static readonly Dictionary<string, string> ShortNameToOid = new(StringComparer.OrdinalIgnoreCase)
    {
        ["CN"] = OidCN,
        ["O"] = OidO,
        ["OU"] = OidOU,
        ["C"] = OidC,
        ["ST"] = OidST,
        ["L"] = OidL,
        ["E"] = OidE,
        ["SERIALNUMBER"] = OidSerialNumber,
    };

    private readonly IReadOnlyList<(string Oid, string Value)> _attributes;

    /// <summary>
    /// Gets the ordered list of RDN attribute type-value pairs in DER encoding order.
    /// </summary>
    public IReadOnlyList<(string Oid, string Value)> Attributes => _attributes;

    /// <summary>
    /// Initializes a new <see cref="X509Name"/> with the given attributes.
    /// </summary>
    /// <param name="attributes">The ordered RDN attribute type-value pairs.</param>
    /// <exception cref="ArgumentNullException"><paramref name="attributes"/> is <c>null</c>.</exception>
    public X509Name(IReadOnlyList<(string Oid, string Value)> attributes)
    {
        if (attributes is null) throw new ArgumentNullException(nameof(attributes));
        _attributes = new List<(string, string)>(attributes).AsReadOnly();
    }

    /// <summary>
    /// Parses a Distinguished Name from DER-encoded bytes.
    /// </summary>
    /// <param name="data">The DER-encoded Name structure.</param>
    /// <returns>The parsed <see cref="X509Name"/>.</returns>
    public static X509Name ParseDer(ReadOnlySpan<byte> data)
    {
        var reader = new AsnReader(data.ToArray(), AsnEncodingRules.DER);
        return ParseDer(reader);
    }

    /// <summary>
    /// Parses a Distinguished Name from an <see cref="AsnReader"/> positioned at a Name SEQUENCE.
    /// </summary>
    /// <param name="reader">The ASN.1 reader positioned at the Name SEQUENCE.</param>
    /// <returns>The parsed <see cref="X509Name"/>.</returns>
    internal static X509Name ParseDer(AsnReader reader)
    {
        var nameSeq = reader.ReadSequence();
        var attributes = new List<(string, string)>();

        while (nameSeq.HasData)
        {
            var rdnSet = nameSeq.ReadSetOf();
            while (rdnSet.HasData)
            {
                var attrSeq = rdnSet.ReadSequence();
                string oid = attrSeq.ReadObjectIdentifier();
                string value = ReadDirectoryString(attrSeq);
                attrSeq.ThrowIfNotEmpty();
                attributes.Add((oid, value));
            }
        }

        return new X509Name(attributes);
    }

    /// <summary>
    /// Encodes this Distinguished Name as DER.
    /// </summary>
    /// <returns>The DER-encoded Name structure.</returns>
    public byte[] EncodeDer()
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        WriteTo(writer);
        return writer.Encode();
    }

    /// <summary>
    /// Writes this Distinguished Name to an <see cref="AsnWriter"/>.
    /// </summary>
    /// <param name="writer">The ASN.1 writer to write to.</param>
    internal void WriteTo(AsnWriter writer)
    {
        writer.PushSequence();
        foreach (var (oid, value) in _attributes)
        {
            writer.PushSetOf();
            writer.PushSequence();
            writer.WriteObjectIdentifier(oid);

            if (oid == OidC)
                writer.WriteCharacterString(UniversalTagNumber.PrintableString, value);
            else if (oid == OidE)
                writer.WriteCharacterString(UniversalTagNumber.IA5String, value);
            else
                writer.WriteCharacterString(UniversalTagNumber.UTF8String, value);

            writer.PopSequence();
            writer.PopSetOf();
        }
        writer.PopSequence();
    }

    /// <summary>
    /// Creates an <see cref="X509Name"/> from an RFC 2253 DN string.
    /// </summary>
    /// <param name="dn">The DN string (e.g., "CN=example.com, O=Example Inc, C=US").</param>
    /// <returns>The parsed <see cref="X509Name"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dn"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">The DN string is malformed.</exception>
    public static X509Name FromString(string dn)
    {
        if (dn is null) throw new ArgumentNullException(nameof(dn));

        var attributes = new List<(string, string)>();
        string[] parts = dn.Split(',');

        for (int i = parts.Length - 1; i >= 0; i--)
        {
            string part = parts[i].Trim();
            int eqIdx = part.IndexOf('=');
            if (eqIdx < 0) throw new ArgumentException($"Invalid DN component: '{part}'");

            string shortName = part[..eqIdx].Trim();
            string value = part[(eqIdx + 1)..].Trim();

            if (!ShortNameToOid.TryGetValue(shortName, out string? oid))
                throw new ArgumentException($"Unknown attribute: '{shortName}'");

            attributes.Add((oid, value));
        }

        return new X509Name(attributes);
    }

    /// <summary>
    /// Returns the RFC 2253 string representation of this Distinguished Name.
    /// </summary>
    /// <returns>A string such as "CN=example.com, O=Example Inc, C=US".</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = _attributes.Count - 1; i >= 0; i--)
        {
            if (sb.Length > 0) sb.Append(", ");
            var (oid, value) = _attributes[i];
            string name = OidToShortName.TryGetValue(oid, out string? shortName) ? shortName : oid;
            sb.Append(name).Append('=').Append(value);
        }
        return sb.ToString();
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) => Equals(obj as X509Name);

    /// <summary>
    /// Determines whether this name is equal to another name by comparing all attributes.
    /// </summary>
    /// <param name="other">The other name to compare.</param>
    /// <returns><c>true</c> if the names are equal; otherwise, <c>false</c>.</returns>
    public bool Equals(X509Name? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (_attributes.Count != other._attributes.Count) return false;

        for (int i = 0; i < _attributes.Count; i++)
        {
            if (_attributes[i].Oid != other._attributes[i].Oid) return false;
            if (!string.Equals(_attributes[i].Value, other._attributes[i].Value, StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var (oid, value) in _attributes)
        {
            hash = hash * 31 + oid.GetHashCode();
            hash = hash * 31 + StringComparer.OrdinalIgnoreCase.GetHashCode(value);
        }
        return hash;
    }

    private static string ReadDirectoryString(AsnReader reader)
    {
        Asn1Tag tag = reader.PeekTag();
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.UTF8String)))
            return reader.ReadCharacterString(UniversalTagNumber.UTF8String);
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.PrintableString)))
            return reader.ReadCharacterString(UniversalTagNumber.PrintableString);
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.IA5String)))
            return reader.ReadCharacterString(UniversalTagNumber.IA5String);
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.T61String)))
            return reader.ReadCharacterString(UniversalTagNumber.T61String);
        if (tag.HasSameClassAndValue(new Asn1Tag(UniversalTagNumber.BMPString)))
            return reader.ReadCharacterString(UniversalTagNumber.BMPString);
        throw new System.Security.Cryptography.CryptographicException(
            $"Unsupported DirectoryString tag: {tag}");
    }
}
