// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// The OCSP No Check extension.
/// </summary>
public sealed class X509OcspNoCheckExtension : X509Extension
{
    private const string kFriendlyName = "OCSP No Check";

    /// <summary>
    /// The OID for OCSP No Check extension.
    /// </summary>
    public const string OcspNoCheckOid = Oids.OcspNoCheck;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509OcspNoCheckExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension?.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)),
            encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509OcspNoCheckExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509OcspNoCheckExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds an OCSP No Check extension.
    /// </summary>
    public X509OcspNoCheckExtension()
    {
        Oid = new Oid(OcspNoCheckOid, kFriendlyName);
        Critical = false;
        RawData = Encode();
    }

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        return kFriendlyName;
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

    private static byte[] Encode()
    {
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;
        writer.WriteNull();
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != OcspNoCheckOid)
        {
            throw new CryptographicException("Invalid OcspNoCheckOid.");
        }

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            reader.ReadNull();
            reader.ThrowIfNotEmpty();
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the OCSP No Check extension.", ace);
        }
    }
}
