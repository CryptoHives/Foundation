// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The subject alternate name extension.
/// </summary>
/// <remarks>
/// 
/// id-ce-subjectAltName OBJECT IDENTIFIER::=  { id-ce 17 }
/// 
/// SubjectAltName::= GeneralNames
/// 
///    GeneralNames::= SEQUENCE SIZE(1..MAX) OF GeneralName
/// 
///    GeneralName ::= CHOICE {
///        otherName                       [0] OtherName,
///        rfc822Name[1]                   IA5String,
///        dNSName[2]                      IA5String,
///        x400Address[3]                  ORAddress,
///        directoryName[4]                Name,
///        ediPartyName[5]                 EDIPartyName,
///        uniformResourceIdentifier[6]    IA5String,
///        iPAddress[7]                    OCTET STRING,
///        registeredID[8]                 OBJECT IDENTIFIER
///        }
/// 
///    OtherName::= SEQUENCE {
///        type-id                         OBJECT IDENTIFIER,
///        value[0] EXPLICIT ANY DEFINED BY type - id
///        }
/// 
///    EDIPartyName::= SEQUENCE {
///        nameAssigner[0]                 DirectoryString OPTIONAL,
///        partyName[1]                    DirectoryString
///        }
/// 
/// </remarks>
public class X509SubjectAltNameExtension : X509Extension
{
    #region Constructors
    /// <summary>
    /// Creates an empty extension.
    /// </summary>
    protected X509SubjectAltNameExtension()
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509SubjectAltNameExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid, encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an Oid and ASN.1 encoded raw data.
    /// </summary>
    public X509SubjectAltNameExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509SubjectAltNameExtension(Oid oid, byte[] rawData, bool critical)
    :
        base(oid, rawData, critical)
    {
        _decoded = false;
    }

    /// <summary>
    /// Build the Subject Alternative name extension (for OPC UA application certs).
    /// </summary>
    /// <param name="applicationUri">The application Uri</param>
    /// <param name="domainNames">The domain names. DNS Hostnames, IPv4 or IPv6 addresses</param>
    public X509SubjectAltNameExtension(
        string applicationUri,
        IEnumerable<string> domainNames)
    {
        Oid = new Oid(SubjectAltName2Oid, kFriendlyName);
        Critical = false;
        Initialize(applicationUri, domainNames);
        RawData = Encode();
        _decoded = true;
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Returns a formatted version of the Abstract Syntax Notation One (ASN.1)-encoded data as a string.
    /// </summary>
    public override string Format(bool multiLine)
    {
        EnsureDecoded();
        var buffer = new StringBuilder();
        for (int ii = 0; ii < _uris.Count; ii++)
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

            buffer.Append(kUniformResourceIdentifier);
            buffer.Append('=');
            buffer.Append(_uris[ii]);
        }

        for (int ii = 0; ii < _domainNames.Count; ii++)
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

            buffer.Append(kDnsName);
            buffer.Append('=');
            buffer.Append(_domainNames[ii]);
        }

        for (int ii = 0; ii < _ipAddresses.Count; ii++)
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

            buffer.Append(kIpAddress);
            buffer.Append('=');
            buffer.Append(_ipAddresses[ii]);
        }

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
        _decoded = false;
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// The OID for a Subject Alternate Name extension.
    /// </summary>
    public const string SubjectAltNameOid = "2.5.29.7";

    /// <summary>
    /// The OID for a Subject Alternate Name 2 extension.
    /// </summary>
    public const string SubjectAltName2Oid = "2.5.29.17";

    /// <summary>
    /// Gets the uris.
    /// </summary>
    /// <value>The uris.</value>
    public IReadOnlyList<string> Uris
    {
        get
        {
            EnsureDecoded();
            return _uris.AsReadOnly();
        }
    }

    /// <summary>
    /// Gets the domain names.
    /// </summary>
    /// <value>The domain names.</value>
    public IReadOnlyList<string> DomainNames
    {
        get
        {
            EnsureDecoded();
            return _domainNames.AsReadOnly();
        }
    }

    /// <summary>
    /// Gets the IP addresses.
    /// </summary>
    /// <value>The IP addresses.</value>
    public IReadOnlyList<string> IPAddresses
    {
        get
        {
            EnsureDecoded();
            return _ipAddresses.AsReadOnly();
        }
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Create a normalized IPv4 or IPv6 address from a 4 byte or 16 byte array.
    /// </summary>
    private static string IPAddressToString(byte[] encodedIPAddress)
    {
        try
        {
            var address = new IPAddress(encodedIPAddress);
            return address.ToString();
        }
        catch
        {
            throw new CryptographicException("Certificate contains invalid IP address.");
        }
    }

#if NETSTANDARD2_1 || NET472_OR_GREATER || NET5_0_OR_GREATER
    /// <summary>
    /// Encode the Subject Alternative name extension.
    /// </summary>
    private byte[] Encode()
    {
        var sanBuilder = new SubjectAlternativeNameBuilder();
        foreach (string uri in _uris)
        {
            sanBuilder.AddUri(new Uri(uri));
        }
            X509SubjectAltNameExtension.EncodeGeneralNames(sanBuilder, _domainNames);
            X509SubjectAltNameExtension.EncodeGeneralNames(sanBuilder, _ipAddresses);
        X509Extension extension = sanBuilder.Build();
        return extension.RawData;
    }

    /// <summary>
    /// Encode a list of general Names in a SAN builder.
    /// </summary>
    /// <param name="sanBuilder">The subject alternative name builder</param>
    /// <param name="generalNames">The general Names to add</param>
    private static void EncodeGeneralNames(SubjectAlternativeNameBuilder sanBuilder, IList<string> generalNames)
    {
        foreach (string generalName in generalNames)
        {
            IPAddress ipAddr;
                if (string.IsNullOrWhiteSpace(generalName))
                {
                continue;
                }
            if (IPAddress.TryParse(generalName, out ipAddr))
            {
                sanBuilder.AddIpAddress(ipAddr);
            }
            else
            {
                sanBuilder.AddDnsName(generalName);
            }
        }
    }
#else  
    /// <summary>
    /// Encode the Subject Alternative name extension.
    /// </summary>
    private byte[] Encode()
    {
        return BouncyCastle.X509Extensions.BuildSubjectAltNameExtension(_uris, _domainNames, _ipAddresses).RawData;
    }
#endif

    /// <summary>
    /// Decode if RawData is yet undecoded.
    /// </summary>
    private void EnsureDecoded()
    {
        if (!_decoded)
            {
            Decode(RawData);
    }
        }

    /// <summary>
    /// Decode URI, DNS and IP from Subject Alternative Name.
    /// </summary>
    /// <remarks>
    /// Only general names relevant for Opc.Ua are decoded.
    /// </remarks>
    private void Decode(byte[] data)
    {
            if (base.Oid.Value == SubjectAltNameOid ||
                base.Oid.Value == SubjectAltName2Oid)
        {
            try
            {
                var uris = new List<string>();
                var domainNames = new List<string>();
                var ipAddresses = new List<string>();
                var dataReader = new AsnReader(data, AsnEncodingRules.DER);
                AsnReader akiReader = dataReader.ReadSequence();
                dataReader.ThrowIfNotEmpty();
                if (akiReader != null)
                {
                    var uriTag = new Asn1Tag(TagClass.ContextSpecific, 6);
                    var dnsTag = new Asn1Tag(TagClass.ContextSpecific, 2);
                    var ipTag = new Asn1Tag(TagClass.ContextSpecific, 7);

                    while (akiReader.HasData)
                    {
                        Asn1Tag peekTag = akiReader.PeekTag();
                        if (peekTag == uriTag)
                        {
                            string uri = akiReader.ReadCharacterString(UniversalTagNumber.IA5String, uriTag);
                            uris.Add(uri);
                        }
                        else if (peekTag == dnsTag)
                        {
                            string dnsName = akiReader.ReadCharacterString(UniversalTagNumber.IA5String, dnsTag);
                            domainNames.Add(dnsName);
                        }
                        else if (peekTag == ipTag)
                        {
                            byte[] ip = akiReader.ReadOctetString(ipTag);
                                ipAddresses.Add(X509SubjectAltNameExtension.IPAddressToString(ip));
                        }
                        else  // skip over
                        {
                            akiReader.ReadEncodedValue();
                        }
                    }
                    akiReader.ThrowIfNotEmpty();
                    _uris = uris;
                    _domainNames = domainNames;
                    _ipAddresses = ipAddresses;
                    _decoded = true;
                    return;
                }
                throw new CryptographicException("No valid data in the X509 signature.");
            }
            catch (AsnContentException ace)
            {
                throw new CryptographicException("Failed to decode the SubjectAltName extension.", ace);
            }
        }
        throw new CryptographicException("Invalid SubjectAltNameOid.");
    }

    /// <summary>
    /// Initialize the Subject Alternative name extension.
    /// </summary>
    /// <param name="applicationUri">The application Uri</param>
    /// <param name="generalNames">The general names. DNS Hostnames, IPv4 or IPv6 addresses</param>
    private void Initialize(string applicationUri, IEnumerable<string> generalNames)
    {
        var uris = new List<string>();
        var domainNames = new List<string>();
        var ipAddresses = new List<string>();
        uris.Add(applicationUri);
        foreach (string generalName in generalNames)
        {
            switch (Uri.CheckHostName(generalName))
            {
                case UriHostNameType.Dns:
                    domainNames.Add(generalName); break;
                case UriHostNameType.IPv4:
                case UriHostNameType.IPv6:
                    ipAddresses.Add(generalName); break;
                case UriHostNameType.Unknown:
                case UriHostNameType.Basic:
                default: continue;
            }
        }
        _uris = uris;
        _domainNames = domainNames;
        _ipAddresses = ipAddresses;
    }
    #endregion

    #region Private Fields
    /// <summary>
    /// Subject Alternate Name extension string
    /// definitions see RFC 5280 4.2.1.7
    /// </summary>
    private const string kUniformResourceIdentifier = "URL";
    private const string kDnsName = "DNS Name";
    private const string kIpAddress = "IP Address";
    private const string kFriendlyName = "Subject Alternative Name";
    private List<string> _uris;
    private List<string> _domainNames;
    private List<string> _ipAddresses;
    private bool _decoded;
    #endregion
}
