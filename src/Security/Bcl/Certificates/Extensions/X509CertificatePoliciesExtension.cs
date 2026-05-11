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
/// The Certificate Policies extension.
/// </summary>
public sealed class X509CertificatePoliciesExtension : X509Extension
{
    private const string kFriendlyName = "Certificate Policies";

    /// <summary>
    /// The OID for Certificate Policies extension.
    /// </summary>
    public const string CertificatePoliciesOid = Oids.CertificatePolicies;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CertificatePoliciesExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.",
            nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509CertificatePoliciesExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CertificatePoliciesExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Certificate Policies extension.
    /// </summary>
    /// <param name="policyOids">Policy OIDs.</param>
    public X509CertificatePoliciesExtension(IEnumerable<string> policyOids)
    {
        if (policyOids == null)
        {
            throw new ArgumentNullException(nameof(policyOids));
        }

        Oid = new Oid(CertificatePoliciesOid, kFriendlyName);
        Critical = false;

        foreach (string policyOid in policyOids)
        {
            if (!string.IsNullOrWhiteSpace(policyOid))
            {
                _policyOids.Add(policyOid);
            }
        }

        if (_policyOids.Count == 0)
        {
            throw new ArgumentException("At least one policy OID is required.", nameof(policyOids));
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets the policy OIDs.
    /// </summary>
    public IReadOnlyList<string> PolicyOids => _policyOids.AsReadOnly();

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();
        for (int i = 0; i < _policyOids.Count; i++)
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

            buffer.Append("Policy=");
            buffer.Append(_policyOids[i]);
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
        foreach (string oid in _policyOids)
        {
            writer.PushSequence();
            writer.WriteObjectIdentifier(oid);
            writer.PopSequence();
        }
        writer.PopSequence();

        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != CertificatePoliciesOid)
        {
            throw new CryptographicException("Invalid CertificatePoliciesOid.");
        }

        _policyOids.Clear();

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            while (sequence.HasData)
            {
                AsnReader policyInfo = sequence.ReadSequence();
                _policyOids.Add(policyInfo.ReadObjectIdentifier());
                while (policyInfo.HasData)
                {
                    policyInfo.ReadEncodedValue();
                }
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Certificate Policies extension.", ace);
        }
    }

    private readonly List<string> _policyOids = [];
}
