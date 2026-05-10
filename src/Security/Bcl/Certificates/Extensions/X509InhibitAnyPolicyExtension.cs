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
/// The Inhibit AnyPolicy extension.
/// </summary>
public sealed class X509InhibitAnyPolicyExtension : X509Extension
{
    private const string kFriendlyName = "Inhibit AnyPolicy";

    /// <summary>
    /// The OID for Inhibit AnyPolicy extension.
    /// </summary>
    public const string InhibitAnyPolicyOid = Oids.InhibitAnyPolicy;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509InhibitAnyPolicyExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509InhibitAnyPolicyExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509InhibitAnyPolicyExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds an Inhibit AnyPolicy extension.
    /// </summary>
    /// <param name="skipCerts">The skip certs value.</param>
    public X509InhibitAnyPolicyExtension(int skipCerts)
    {
        if (skipCerts < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(skipCerts));
        }

        Oid = new Oid(InhibitAnyPolicyOid, kFriendlyName);
        Critical = true;
        SkipCerts = skipCerts;
        RawData = Encode();
    }

    /// <summary>
    /// Gets the skip certs value.
    /// </summary>
    public int SkipCerts { get; private set; }

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();
        buffer.Append("SkipCerts=");
        buffer.Append(SkipCerts);
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
        writer.WriteInteger(new BigInteger(SkipCerts));
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != InhibitAnyPolicyOid)
        {
            throw new CryptographicException("Invalid InhibitAnyPolicyOid.");
        }

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            SkipCerts = (int)reader.ReadInteger();
            reader.ThrowIfNotEmpty();
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Inhibit AnyPolicy extension.", ace);
        }
    }
}
