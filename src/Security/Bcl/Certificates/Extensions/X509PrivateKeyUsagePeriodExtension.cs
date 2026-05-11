// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The Private Key Usage Period extension.
/// </summary>
public sealed class X509PrivateKeyUsagePeriodExtension : X509Extension
{
    private const string kFriendlyName = "Private Key Usage Period";

    /// <summary>
    /// The OID for Private Key Usage Period extension.
    /// </summary>
    public const string PrivateKeyUsagePeriodOid = Oids.PrivateKeyUsagePeriod;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509PrivateKeyUsagePeriodExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)),
              encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509PrivateKeyUsagePeriodExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509PrivateKeyUsagePeriodExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Private Key Usage Period extension.
    /// </summary>
    /// <param name="notBefore">Optional private key usage start.</param>
    /// <param name="notAfter">Optional private key usage end.</param>
    public X509PrivateKeyUsagePeriodExtension(DateTimeOffset? notBefore = null, DateTimeOffset? notAfter = null)
    {
        if (!notBefore.HasValue && !notAfter.HasValue)
        {
            throw new ArgumentException("At least one of notBefore or notAfter must be provided.");
        }

        Oid = new Oid(PrivateKeyUsagePeriodOid, kFriendlyName);
        Critical = false;
        NotBefore = notBefore;
        NotAfter = notAfter;
        RawData = Encode();
    }

    /// <summary>
    /// Gets private key usage start.
    /// </summary>
    public DateTimeOffset? NotBefore { get; private set; }

    /// <summary>
    /// Gets private key usage end.
    /// </summary>
    public DateTimeOffset? NotAfter { get; private set; }

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();

        if (NotBefore.HasValue)
        {
            buffer.Append("NotBefore=");
            buffer.Append(NotBefore.Value.ToString("O"));
        }

        if (NotAfter.HasValue)
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

            buffer.Append("NotAfter=");
            buffer.Append(NotAfter.Value.ToString("O"));
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

        writer.PushSequence();

        if (NotBefore.HasValue)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.WriteGeneralizedTime(NotBefore.Value, true);
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }

        if (NotAfter.HasValue)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
            writer.WriteGeneralizedTime(NotAfter.Value, true);
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != PrivateKeyUsagePeriodOid)
        {
            throw new CryptographicException("Invalid PrivateKeyUsagePeriodOid.");
        }

        NotBefore = null;
        NotAfter = null;

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            while (sequence.HasData)
            {
                Asn1Tag tag = sequence.PeekTag();
                if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 0)
                {
                    var encoded = sequence.ReadEncodedValue();
                    var tagged = new AsnReader(encoded.ToArray(), AsnEncodingRules.DER);
                    var inner = tagged.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
                    NotBefore = inner.ReadGeneralizedTime();
                    inner.ThrowIfNotEmpty();
                    tagged.ThrowIfNotEmpty();
                }
                else if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 1)
                {
                    var encoded = sequence.ReadEncodedValue();
                    var tagged = new AsnReader(encoded.ToArray(), AsnEncodingRules.DER);
                    var inner = tagged.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
                    NotAfter = inner.ReadGeneralizedTime();
                    inner.ThrowIfNotEmpty();
                    tagged.ThrowIfNotEmpty();
                }
                else
                {
                    sequence.ReadEncodedValue();
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Private Key Usage Period extension.", ace);
        }
    }
}
