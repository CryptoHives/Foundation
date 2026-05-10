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
/// The Delta CRL Indicator extension.
/// </summary>
public sealed class X509DeltaCrlIndicatorExtension : X509Extension
{
    private const string kFriendlyName = "Delta CRL Indicator";

    /// <summary>
    /// The OID for Delta CRL Indicator extension.
    /// </summary>
    public const string DeltaCrlIndicatorOid = Oids.DeltaCrlIndicator;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509DeltaCrlIndicatorExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509DeltaCrlIndicatorExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509DeltaCrlIndicatorExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a Delta CRL Indicator extension.
    /// </summary>
    /// <param name="baseCrlNumber">The base CRL number.</param>
    public X509DeltaCrlIndicatorExtension(BigInteger baseCrlNumber)
    {
        if (baseCrlNumber.Sign < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(baseCrlNumber));
        }

        Oid = new Oid(DeltaCrlIndicatorOid, kFriendlyName);
        Critical = true;
        BaseCrlNumber = baseCrlNumber;
        RawData = Encode();
    }

    /// <summary>
    /// Gets the base CRL number.
    /// </summary>
    public BigInteger BaseCrlNumber { get; private set; }

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();
        buffer.Append("BaseCRL=");
        buffer.Append(BaseCrlNumber);
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
        writer.WriteInteger(BaseCrlNumber);
        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != DeltaCrlIndicatorOid)
        {
            throw new CryptographicException("Invalid DeltaCrlIndicatorOid.");
        }

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            BaseCrlNumber = reader.ReadInteger();
            reader.ThrowIfNotEmpty();
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the Delta CRL Indicator extension.", ace);
        }
    }
}
