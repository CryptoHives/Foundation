// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates;

using System;
using System.Formats.Asn1;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The CRL Number extension.
/// </summary>
/// <remarks>
///    id-ce-cRLNumber OBJECT IDENTIFIER::= { id-ce 20 }
///         CRLNumber::= INTEGER(0..MAX)
/// </remarks>
public class X509CrlNumberExtension : X509Extension
{
    #region Constructors
    /// <summary>
    /// Creates an empty extension.
    /// </summary>
    protected X509CrlNumberExtension()
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CrlNumberExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid, encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an Oid and ASN.1 encoded raw data.
    /// </summary>
    public X509CrlNumberExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509CrlNumberExtension(Oid oid, byte[] rawData, bool critical)
    :
        base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Build the CRL Number extension (for CRL extensions).
    /// </summary>
    public X509CrlNumberExtension(BigInteger crlNumber)
    {
        Oid = new Oid(CrlNumberOid, kFriendlyName);
        Critical = false;
        CrlNumber = crlNumber;
        RawData = Encode();
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Returns a formatted version of the Abstract Syntax Notation One (ASN.1)-encoded data as a string.
    /// </summary>
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();
        buffer.Append(kFriendlyName);
        buffer.Append('=');
        buffer.Append(CrlNumber);

        return buffer.ToString();
    }

    /// <summary>
    /// Initializes the extension from ASN.1 encoded data.
    /// </summary>
    public override void CopyFrom(AsnEncodedData asnEncodedData)
    {
        if (asnEncodedData == null) throw new ArgumentNullException(nameof(asnEncodedData));
        Oid = asnEncodedData.Oid;
        RawData = asnEncodedData.RawData;
        Decode(RawData);
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// The OID for a CRL Number extension.
    /// </summary>
    public const string CrlNumberOid = "2.5.29.20";

    /// <summary>
    /// Gets the CRL Number.
    /// </summary>
    /// <value>The uris.</value>
    public BigInteger CrlNumber { get; private set; }
    #endregion

    #region Private Methods
    /// <summary>
    /// Encode the CRL Number extension.
    /// </summary>
    private byte[] Encode()
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteInteger(CrlNumber);
        return writer.Encode();
    }

    /// <summary>
    /// Decode CRL Number.
    /// </summary>
    private void Decode(byte[] data)
    {
            if (base.Oid.Value == CrlNumberOid)
        {
            try
            {
                var dataReader = new AsnReader(data, AsnEncodingRules.DER);
                CrlNumber = dataReader.ReadInteger();
                dataReader.ThrowIfNotEmpty();
            }
            catch (AsnContentException ace)
            {
                throw new CryptographicException("Failed to decode the CRL Number extension.", ace);
            }
        }
        else
        {
            throw new CryptographicException("Invalid CrlNumberOid.");
        }
    }
    #endregion

    #region Private Fields
    /// <summary>
    /// CRL Number extension string
    /// definitions see RFC 5280 5.2.3
    /// </summary>
    private const string kFriendlyName = "CRL Number";
    #endregion
}

