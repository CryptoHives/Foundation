// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Security.Cryptography;

/// <summary>
/// Represents a single X.509 certificate extension per RFC 5280 §4.2.
/// </summary>
/// <remarks>
/// Each extension contains an OID, a criticality flag, and the raw DER value
/// of the extension's OCTET STRING content.
/// </remarks>
public sealed class X509Extension
{
    /// <summary>
    /// Gets the extension OID.
    /// </summary>
    public string Oid { get; }

    /// <summary>
    /// Gets a value indicating whether this extension is critical.
    /// </summary>
    public bool Critical { get; }

    /// <summary>
    /// Gets the raw DER value of the extension content.
    /// </summary>
    public byte[] Value { get; }

    /// <summary>
    /// Initializes a new <see cref="X509Extension"/>.
    /// </summary>
    /// <param name="oid">The extension OID.</param>
    /// <param name="critical">Whether the extension is critical.</param>
    /// <param name="value">The raw DER value of the extension content.</param>
    public X509Extension(string oid, bool critical, byte[] value)
    {
        Oid = oid ?? throw new ArgumentNullException(nameof(oid));
        Value = value ?? throw new ArgumentNullException(nameof(value));
        Critical = critical;
    }
}

/// <summary>
/// A read-only collection of <see cref="X509Extension"/> instances with lookup helpers.
/// </summary>
public sealed class X509ExtensionCollection : IReadOnlyList<X509Extension>
{
    /// <summary>OID for Basic Constraints extension.</summary>
    public const string OidBasicConstraints = "2.5.29.19";

    /// <summary>OID for Key Usage extension.</summary>
    public const string OidKeyUsage = "2.5.29.15";

    /// <summary>OID for Extended Key Usage extension.</summary>
    public const string OidExtendedKeyUsage = "2.5.29.37";

    /// <summary>OID for Subject Alternative Name extension.</summary>
    public const string OidSubjectAlternativeName = "2.5.29.17";

    /// <summary>OID for Subject Key Identifier extension.</summary>
    public const string OidSubjectKeyIdentifier = "2.5.29.14";

    /// <summary>OID for Authority Key Identifier extension.</summary>
    public const string OidAuthorityKeyIdentifier = "2.5.29.35";

    /// <summary>OID for CRL Distribution Points extension.</summary>
    public const string OidCrlDistributionPoints = "2.5.29.31";

    /// <summary>OID for Authority Information Access extension.</summary>
    public const string OidAuthorityInfoAccess = "1.3.6.1.5.5.7.1.1";

    /// <summary>
    /// An empty extension collection.
    /// </summary>
    public static readonly X509ExtensionCollection Empty = new([]);

    private readonly IReadOnlyList<X509Extension> _extensions;

    /// <summary>
    /// Initializes a new <see cref="X509ExtensionCollection"/>.
    /// </summary>
    /// <param name="extensions">The extensions to wrap.</param>
    public X509ExtensionCollection(IReadOnlyList<X509Extension> extensions)
    {
        _extensions = extensions ?? throw new ArgumentNullException(nameof(extensions));
    }

    /// <inheritdoc />
    public int Count => _extensions.Count;

    /// <inheritdoc />
    public X509Extension this[int index] => _extensions[index];

    /// <summary>
    /// Gets the first extension matching the specified OID, or <c>null</c> if not found.
    /// </summary>
    /// <param name="oid">The extension OID to search for.</param>
    /// <returns>The matching extension, or <c>null</c>.</returns>
    public X509Extension? GetExtension(string oid)
    {
        foreach (var ext in _extensions)
        {
            if (ext.Oid == oid) return ext;
        }
        return null;
    }

    /// <summary>
    /// Determines whether an extension with the specified OID exists.
    /// </summary>
    /// <param name="oid">The extension OID to search for.</param>
    /// <returns><c>true</c> if the extension exists; otherwise, <c>false</c>.</returns>
    public bool HasExtension(string oid) => GetExtension(oid) is not null;

    /// <inheritdoc />
    public IEnumerator<X509Extension> GetEnumerator() => _extensions.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Parses the extensions block from the [3] EXPLICIT tag of a TBS certificate.
    /// </summary>
    /// <param name="reader">The ASN.1 reader positioned at the [3] EXPLICIT tag.</param>
    /// <returns>The parsed extension collection.</returns>
    internal static X509ExtensionCollection ParseExtensions(AsnReader reader)
    {
        var ctx3 = new Asn1Tag(TagClass.ContextSpecific, 3, isConstructed: true);
        var explicitReader = reader.ReadSequence(ctx3);
        var extSeq = explicitReader.ReadSequence();
        explicitReader.ThrowIfNotEmpty();

        var extensions = new List<X509Extension>();
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
            extensions.Add(new X509Extension(oid, critical, value));
        }

        return new X509ExtensionCollection(extensions.AsReadOnly());
    }
}

/// <summary>
/// Specifies the key usage flags per RFC 5280 §4.2.1.3.
/// </summary>
[Flags]
public enum KeyUsageFlags
{
    /// <summary>No usage specified.</summary>
    None = 0,

    /// <summary>Digital signature.</summary>
    DigitalSignature = 1 << 0,

    /// <summary>Non-repudiation / content commitment.</summary>
    NonRepudiation = 1 << 1,

    /// <summary>Key encipherment.</summary>
    KeyEncipherment = 1 << 2,

    /// <summary>Data encipherment.</summary>
    DataEncipherment = 1 << 3,

    /// <summary>Key agreement.</summary>
    KeyAgreement = 1 << 4,

    /// <summary>Certificate signing.</summary>
    KeyCertSign = 1 << 5,

    /// <summary>CRL signing.</summary>
    CrlSign = 1 << 6,
}

/// <summary>
/// Specifies the type of a Subject Alternative Name entry.
/// </summary>
public enum SanType
{
    /// <summary>DNS name.</summary>
    DnsName,

    /// <summary>Email (rfc822Name).</summary>
    Email,

    /// <summary>IP address.</summary>
    IpAddress,

    /// <summary>URI.</summary>
    Uri,
}

/// <summary>
/// Provides parsers for well-known X.509 extensions.
/// </summary>
public static class ExtensionParsers
{
    /// <summary>
    /// Provides parsing for the Basic Constraints extension (OID 2.5.29.19).
    /// </summary>
    public static class BasicConstraints
    {
        /// <summary>
        /// Parses a Basic Constraints extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>A tuple of isCA flag and optional path length constraint.</returns>
        public static (bool IsCA, int? PathLenConstraint) Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            bool isCA = false;
            int? pathLen = null;

            if (seq.HasData && seq.PeekTag().HasSameClassAndValue(
                new Asn1Tag(UniversalTagNumber.Boolean)))
            {
                isCA = seq.ReadBoolean();
            }

            if (seq.HasData && seq.PeekTag().HasSameClassAndValue(
                new Asn1Tag(UniversalTagNumber.Integer)))
            {
                pathLen = (int)seq.ReadInteger();
            }

            seq.ThrowIfNotEmpty();
            return (isCA, pathLen);
        }
    }

    /// <summary>
    /// Provides parsing for the Key Usage extension (OID 2.5.29.15).
    /// </summary>
    public static class KeyUsage
    {
        /// <summary>
        /// Parses a Key Usage extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>The key usage flags.</returns>
        public static KeyUsageFlags Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            byte[] bits = reader.ReadBitString(out int unusedBits);
            reader.ThrowIfNotEmpty();

            if (bits.Length == 0) return KeyUsageFlags.None;

            int raw = bits[0];
            var flags = KeyUsageFlags.None;
            if ((raw & 0x80) != 0) flags |= KeyUsageFlags.DigitalSignature;
            if ((raw & 0x40) != 0) flags |= KeyUsageFlags.NonRepudiation;
            if ((raw & 0x20) != 0) flags |= KeyUsageFlags.KeyEncipherment;
            if ((raw & 0x10) != 0) flags |= KeyUsageFlags.DataEncipherment;
            if ((raw & 0x08) != 0) flags |= KeyUsageFlags.KeyAgreement;
            if ((raw & 0x04) != 0) flags |= KeyUsageFlags.KeyCertSign;
            if ((raw & 0x02) != 0) flags |= KeyUsageFlags.CrlSign;

            return flags;
        }
    }

    /// <summary>
    /// Provides parsing for the Extended Key Usage extension (OID 2.5.29.37).
    /// </summary>
    public static class ExtendedKeyUsage
    {
        /// <summary>OID for server authentication.</summary>
        public const string OidServerAuth = "1.3.6.1.5.5.7.3.1";

        /// <summary>OID for client authentication.</summary>
        public const string OidClientAuth = "1.3.6.1.5.5.7.3.2";

        /// <summary>OID for code signing.</summary>
        public const string OidCodeSigning = "1.3.6.1.5.5.7.3.3";

        /// <summary>OID for email protection.</summary>
        public const string OidEmailProtection = "1.3.6.1.5.5.7.3.4";

        /// <summary>OID for time stamping.</summary>
        public const string OidTimeStamping = "1.3.6.1.5.5.7.3.8";

        /// <summary>
        /// Parses an Extended Key Usage extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>The list of EKU OIDs.</returns>
        public static IReadOnlyList<string> Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var oids = new List<string>();
            while (seq.HasData)
                oids.Add(seq.ReadObjectIdentifier());
            return oids.AsReadOnly();
        }
    }

    /// <summary>
    /// Provides parsing for the Subject Alternative Name extension (OID 2.5.29.17).
    /// </summary>
    public static class SubjectAlternativeName
    {
        /// <summary>
        /// Parses a Subject Alternative Name extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>A list of SAN entries.</returns>
        public static IReadOnlyList<(SanType Type, string Value)> Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var entries = new List<(SanType, string)>();
            while (seq.HasData)
            {
                Asn1Tag tag = seq.PeekTag();
                if (tag.TagClass != TagClass.ContextSpecific)
                {
                    seq.ReadEncodedValue();
                    continue;
                }

                switch (tag.TagValue)
                {
                    case 1: // rfc822Name
                        entries.Add((SanType.Email, seq.ReadCharacterString(
                            UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 1))));
                        break;
                    case 2: // dNSName
                        entries.Add((SanType.DnsName, seq.ReadCharacterString(
                            UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 2))));
                        break;
                    case 6: // uniformResourceIdentifier
                        entries.Add((SanType.Uri, seq.ReadCharacterString(
                            UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 6))));
                        break;
                    case 7: // iPAddress
                        byte[] ipBytes = seq.ReadOctetString(new Asn1Tag(TagClass.ContextSpecific, 7));
                        entries.Add((SanType.IpAddress, new IPAddress(ipBytes).ToString()));
                        break;
                    default:
                        seq.ReadEncodedValue();
                        break;
                }
            }

            return entries.AsReadOnly();
        }
    }

    /// <summary>
    /// Provides parsing for the Subject Key Identifier extension (OID 2.5.29.14).
    /// </summary>
    public static class SubjectKeyIdentifier
    {
        /// <summary>
        /// Parses a Subject Key Identifier extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>The key identifier bytes.</returns>
        public static byte[] Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            byte[] ski = reader.ReadOctetString();
            reader.ThrowIfNotEmpty();
            return ski;
        }
    }

    /// <summary>
    /// Provides parsing for the Authority Key Identifier extension (OID 2.5.29.35).
    /// </summary>
    public static class AuthorityKeyIdentifier
    {
        /// <summary>
        /// Parses an Authority Key Identifier extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>A tuple of optional key identifier, issuer name, and serial number.</returns>
        public static (byte[]? KeyId, X509Name? Issuer, byte[]? SerialNumber) Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            byte[]? keyId = null;
            X509Name? issuer = null;
            byte[]? serialNumber = null;

            while (seq.HasData)
            {
                Asn1Tag tag = seq.PeekTag();
                if (tag.TagClass != TagClass.ContextSpecific)
                {
                    seq.ReadEncodedValue();
                    continue;
                }

                switch (tag.TagValue)
                {
                    case 0:
                        keyId = seq.ReadOctetString(new Asn1Tag(TagClass.ContextSpecific, 0));
                        break;
                    default:
                        seq.ReadEncodedValue();
                        break;
                }
            }

            return (keyId, issuer, serialNumber);
        }
    }

    /// <summary>
    /// Provides parsing for the CRL Distribution Points extension (OID 2.5.29.31).
    /// </summary>
    public static class CrlDistributionPoints
    {
        /// <summary>
        /// Parses a CRL Distribution Points extension value, extracting URI distribution points.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>A list of distribution point URIs.</returns>
        public static IReadOnlyList<string> Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var uris = new List<string>();
            while (seq.HasData)
            {
                var dp = seq.ReadSequence(); // DistributionPoint
                if (dp.HasData && dp.PeekTag().HasSameClassAndValue(
                    new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true)))
                {
                    var dpName = dp.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
                    if (dpName.HasData && dpName.PeekTag().HasSameClassAndValue(
                        new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true)))
                    {
                        var fullName = dpName.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
                        while (fullName.HasData)
                        {
                            Asn1Tag tag = fullName.PeekTag();
                            if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 6)
                            {
                                uris.Add(fullName.ReadCharacterString(
                                    UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 6)));
                            }
                            else
                            {
                                fullName.ReadEncodedValue();
                            }
                        }
                    }
                }
                // Skip remaining fields (reasons, cRLIssuer)
            }

            return uris.AsReadOnly();
        }
    }

    /// <summary>
    /// Provides parsing for the Authority Information Access extension (OID 1.3.6.1.5.5.7.1.1).
    /// </summary>
    public static class AuthorityInfoAccess
    {
        /// <summary>OID for OCSP access method.</summary>
        public const string OidOcsp = "1.3.6.1.5.5.7.48.1";

        /// <summary>OID for CA Issuers access method.</summary>
        public const string OidCaIssuers = "1.3.6.1.5.5.7.48.2";

        /// <summary>
        /// Parses an Authority Information Access extension value.
        /// </summary>
        /// <param name="value">The raw extension value bytes.</param>
        /// <returns>A list of (accessMethod OID, accessLocation URI) tuples.</returns>
        public static IReadOnlyList<(string Method, string Location)> Parse(byte[] value)
        {
            var reader = new AsnReader(value, AsnEncodingRules.DER);
            var seq = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            var entries = new List<(string, string)>();
            while (seq.HasData)
            {
                var desc = seq.ReadSequence(); // AccessDescription
                string method = desc.ReadObjectIdentifier();
                Asn1Tag tag = desc.PeekTag();
                if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 6)
                {
                    string uri = desc.ReadCharacterString(
                        UniversalTagNumber.IA5String, new Asn1Tag(TagClass.ContextSpecific, 6));
                    entries.Add((method, uri));
                }
                else
                {
                    desc.ReadEncodedValue(); // skip non-URI forms
                }
                desc.ThrowIfNotEmpty();
            }

            return entries.AsReadOnly();
        }
    }
}
