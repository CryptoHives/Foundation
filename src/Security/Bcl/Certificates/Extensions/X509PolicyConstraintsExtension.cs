// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Formats.Asn1;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The Policy Constraints extension.
/// </summary>
public sealed class X509PolicyConstraintsExtension : X509Extension
{
    private const string kFriendlyName = "Policy Constraints";

    /// <summary>
    /// The OID for Policy Constraints extension.
    /// </summary>
    public const string PolicyConstraintsOid = Oids.PolicyConstraints;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509PolicyConstraintsExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509PolicyConstraintsExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509PolicyConstraintsExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Policy Constraints extension.
    /// </summary>
    /// <param name="requireExplicitPolicy">Require explicit policy skip certs.</param>
    /// <param name="inhibitPolicyMapping">Inhibit policy mapping skip certs.</param>
    public X509PolicyConstraintsExtension(int? requireExplicitPolicy = null, int? inhibitPolicyMapping = null)
    {
        if (!requireExplicitPolicy.HasValue && !inhibitPolicyMapping.HasValue)
        {
            throw new ArgumentException("At least one policy constraint value is required.");
        }

        Oid = new Oid(PolicyConstraintsOid, kFriendlyName);
        Critical = true;
        RequireExplicitPolicy = requireExplicitPolicy;
        InhibitPolicyMapping = inhibitPolicyMapping;
        RawData = Encode();
    }

    /// <summary>
    /// Gets require explicit policy skip certs value.
    /// </summary>
    public int? RequireExplicitPolicy { get; private set; }

    /// <summary>
    /// Gets inhibit policy mapping skip certs value.
    /// </summary>
    public int? InhibitPolicyMapping { get; private set; }

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();

        if (RequireExplicitPolicy.HasValue)
        {
            buffer.Append("RequireExplicitPolicy=");
            buffer.Append(RequireExplicitPolicy.Value);
        }

        if (InhibitPolicyMapping.HasValue)
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

            buffer.Append("InhibitPolicyMapping=");
            buffer.Append(InhibitPolicyMapping.Value);
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

        if (RequireExplicitPolicy.HasValue)
        {
            writer.WriteInteger(new BigInteger(RequireExplicitPolicy.Value), new Asn1Tag(TagClass.ContextSpecific, 0));
        }

        if (InhibitPolicyMapping.HasValue)
        {
            writer.WriteInteger(new BigInteger(InhibitPolicyMapping.Value), new Asn1Tag(TagClass.ContextSpecific, 1));
        }

        writer.PopSequence();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != PolicyConstraintsOid)
        {
            throw new CryptographicException("Invalid PolicyConstraintsOid.");
        }

        RequireExplicitPolicy = null;
        InhibitPolicyMapping = null;

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
                    RequireExplicitPolicy = (int)sequence.ReadInteger(new Asn1Tag(TagClass.ContextSpecific, 0));
                }
                else if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 1)
                {
                    InhibitPolicyMapping = (int)sequence.ReadInteger(new Asn1Tag(TagClass.ContextSpecific, 1));
                }
                else
                {
                    sequence.ReadEncodedValue();
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Policy Constraints extension.", ace);
        }
    }
}
