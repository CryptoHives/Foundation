// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates.X509Crl;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Security.Cryptography;
using System.Formats.Asn1;
using System.Runtime.Serialization;

/// <summary>
/// Decodes a X509 CRL and provides access to information.
/// </summary>
public class X509CRL : IX509CRL
{
    #region Constructors
    /// <summary>
    /// Loads a CRL from a file.
    /// </summary>
    public X509CRL(string filePath) : this()
    {
        RawData = File.ReadAllBytes(filePath);
        EnsureDecoded();
    }

    /// <summary>
    /// Loads a CRL from a memory buffer.
    /// </summary>
    public X509CRL(byte[] crl) : this()
    {
        RawData = crl;
        EnsureDecoded();
    }

    /// <summary>
    /// Create CRL from IX509CRL interface.
    /// </summary>
    /// <param name="crl"></param>
    public X509CRL(IX509CRL crl)
    {
        _decoded = true;
        _issuerName = crl.IssuerName;
        _hashAlgorithmName = crl.HashAlgorithmName;
        _thisUpdate = crl.ThisUpdate;
        _nextUpdate = crl.NextUpdate;
        _revokedCertificates = new List<RevokedCertificate>(crl.RevokedCertificates);
        _crlExtensions = new X509ExtensionCollection();
        foreach (X509Extension extension in crl.CrlExtensions)
        {
            _crlExtensions.Add(extension);
        }
        RawData = crl.RawData;
        EnsureDecoded();
    }

    /// <summary>
    /// Default constructor, also internal test hook.
    /// </summary>
    internal X509CRL()
    {
        _decoded = false;
        _thisUpdate = DateTime.MinValue;
        _nextUpdate = DateTime.MinValue;
        _revokedCertificates = new List<RevokedCertificate>();
        _crlExtensions = new X509ExtensionCollection();
    }

    /// <summary>
    /// Loads a CRL from a memory buffer, ignores the signature for fuzz testing of the ASN.1 decoder.
    /// </summary>
    internal X509CRL(byte[] crl, bool ignoreSignature) : this()
    {
        RawData = crl;
        if (!ignoreSignature)
        {
            EnsureDecoded();
        }
        else
        {
            _decoded = true;
            DecodeCrl(crl);
        }
    }
    #endregion

    #region IX509CRL Interface
    /// <inheritdoc/>
    public X500DistinguishedName IssuerName
    {
        get
        {
            return _issuerName;
        }
    }

    /// <inheritdoc/>
    public string Issuer => IssuerName.Name;

    /// <inheritdoc/>
    public DateTime ThisUpdate
    {
        get
        {
            return _thisUpdate;
        }
    }

    /// <inheritdoc/>
    public DateTime NextUpdate
    {
        get
        {
            return _nextUpdate;
        }
    }

    /// <inheritdoc/>
    public HashAlgorithmName HashAlgorithmName
    {
        get
        {
            return _hashAlgorithmName;
        }
    }

    /// <inheritdoc/>
    public IList<RevokedCertificate> RevokedCertificates
    {
        get
        {
            return _revokedCertificates.AsReadOnly();
        }
    }

    /// <inheritdoc/>
    public X509ExtensionCollection CrlExtensions
    {
        get
        {
            return _crlExtensions;
        }
    }

    /// <inheritdoc/>
    public byte[] RawData { get; private set; }
    #endregion

    #region Public Methods
    /// <summary>
    /// Verifies the signature on the CRL.
    /// </summary>
    public bool VerifySignature(X509Certificate2 issuer, bool throwOnError)
    {
        bool result;
        try
        {
            var signature = new X509Signature(RawData);
            result = signature.Verify(issuer);
        }
        catch (Exception)
        {
            result = false;
        }
        if (!result && throwOnError)
        {
            throw new CryptographicException("Could not verify signature on CRL.");
        }
        return result;
    }

    /// <summary>
    /// Returns true if the certificate is revoked in the CRL.
    /// </summary>
    public bool IsRevoked(X509Certificate2 certificate)
    {
        if (certificate.IssuerName.Equals(IssuerName))
        {
            throw new CryptographicException("Certificate was not created by the CRL Issuer.");
        }
        EnsureDecoded();
        byte[] serialnumber = certificate.GetSerialNumber();
        foreach (RevokedCertificate revokedCert in RevokedCertificates)
        {
            if (serialnumber.SequenceEqual<byte>(revokedCert.UserCertificate))
            {
                return true;
            }
        }
        return false;
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Decode the complete CRL.
    /// </summary>
    /// <param name="crl">The raw signed CRL</param>
    internal void Decode(byte[] crl)
    {
        // Decode the Tbs and signature
        _signature = new X509Signature(crl);
        // Decode the TbsCertList
        DecodeCrl(_signature.Tbs);
    }

    /// <summary>
    /// Decode the Tbs of the CRL. 
    /// </summary>
    /// <param name="tbs">The raw TbsCertList of the CRL.</param>
    internal void DecodeCrl(byte[] tbs)
    {
        try
        {
            var crlReader = new AsnReader(tbs, AsnEncodingRules.DER);
            AsnReader seqReader = crlReader.ReadSequence(Asn1Tag.Sequence);
            crlReader.ThrowIfNotEmpty();
            if (seqReader != null)
            {
                // Version is OPTIONAL
                uint version = 0;
                var intTag = new Asn1Tag(UniversalTagNumber.Integer);
                Asn1Tag peekTag = seqReader.PeekTag();
                if (peekTag == intTag)
                {
                    if (seqReader.TryReadUInt32(out version))
                    {
                        if (version != 1)
                        {
                            throw new AsnContentException($"The CRL contains an incorrect version {version}");
                        }
                    }
                }

                // Signature Algorithm Identifier
                AsnReader sigReader = seqReader.ReadSequence();
                string oid = sigReader.ReadObjectIdentifier();
                _hashAlgorithmName = Oids.GetHashAlgorithmName(oid);
                if (sigReader.HasData)
                {
                    sigReader.ReadNull();
                }
                sigReader.ThrowIfNotEmpty();

                // Issuer
                _issuerName = new X500DistinguishedName(seqReader.ReadEncodedValue().ToArray());

                // thisUpdate
                _thisUpdate = X509CRL.ReadTime(seqReader, optional: false);

                // nextUpdate is OPTIONAL
                _nextUpdate = X509CRL.ReadTime(seqReader, optional: true);

                // revokedCertificates is OPTIONAL
                if (seqReader.HasData)
                {
                    var seqTag = new Asn1Tag(UniversalTagNumber.Sequence, true);
                    peekTag = seqReader.PeekTag();
                    if (peekTag == seqTag)
                    {
                        // revoked certificates
                        AsnReader revReader = seqReader.ReadSequence(Asn1Tag.Sequence);
                        var revokedCertificates = new List<RevokedCertificate>();
                        while (revReader.HasData)
                        {
                            AsnReader crlEntry = revReader.ReadSequence();
                            System.Numerics.BigInteger serial = crlEntry.ReadInteger();
                            var revokedCertificate = new RevokedCertificate(serial.ToByteArray());
                            revokedCertificate.RevocationDate = X509CRL.ReadTime(crlEntry, optional: false);
                            if (version == 1 &&
                                crlEntry.HasData)
                            {
                                // CRL entry extensions
                                AsnReader crlEntryExtensions = crlEntry.ReadSequence();
                                while (crlEntryExtensions.HasData)
                                {
                                    X509Extension extension = crlEntryExtensions.ReadExtension();
                                    revokedCertificate.CrlEntryExtensions.Add(extension);
                                }
                                crlEntryExtensions.ThrowIfNotEmpty();
                            }
                            crlEntry.ThrowIfNotEmpty();
                            revokedCertificates.Add(revokedCertificate);
                        }
                        revReader.ThrowIfNotEmpty();
                        _revokedCertificates = revokedCertificates;
                    }

                    // CRL extensions OPTIONAL
                    if (version == 1 &&
                        seqReader.HasData)
                    {
                        var extTag = new Asn1Tag(TagClass.ContextSpecific, 0);
                        AsnReader optReader = seqReader.ReadSequence(extTag);
                        var crlExtensionList = new X509ExtensionCollection();
                        AsnReader crlExtensions = optReader.ReadSequence();
                        while (crlExtensions.HasData)
                        {
                            X509Extension extension = crlExtensions.ReadExtension();
                            crlExtensionList.Add(extension);
                        }
                        _crlExtensions = crlExtensionList;
                    }
                }
                seqReader.ThrowIfNotEmpty();
                _decoded = true;
                return;
            }
            throw new CryptographicException("The CRL contains invalid data.");
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the CRL.", ace);
        }
    }

    /// <summary>
    /// Read the time, UTC or local time
    /// </summary>
    /// <param name="asnReader"></param>
    /// <param name="optional"></param>
    /// <returns>The DateTime representing the tag</returns>
    private static DateTime ReadTime(AsnReader asnReader, bool optional)
    {
        // determine if the time is UTC or GeneralizedTime time
        Asn1Tag timeTag = asnReader.PeekTag();
        if (timeTag.TagValue == Asn1Tag.UtcTime.TagValue)
        {
            return asnReader.ReadUtcTime().UtcDateTime;
        }
        else if (timeTag.TagValue == Asn1Tag.GeneralizedTime.TagValue)
        {
            return asnReader.ReadGeneralizedTime().UtcDateTime;
        }
        else if (optional)
        {
            return DateTime.MinValue;
        }
        else
        {
            throw new AsnContentException("The CRL contains an invalid time tag.");
        }
    }

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
    #endregion

    #region Private Fields
    private bool _decoded = false;
    private X509Signature _signature;
    private X500DistinguishedName _issuerName;
    private DateTime _thisUpdate;
    private DateTime _nextUpdate;
    private HashAlgorithmName _hashAlgorithmName;
    private List<RevokedCertificate> _revokedCertificates;
    private X509ExtensionCollection _crlExtensions;
    #endregion
}

/// <summary>
/// A collection of X509CRL.
/// </summary>
[CollectionDataContract(Name = "ListOfX509CRL", ItemName = "X509CRL")]
public class X509CRLCollection : List<X509CRL>
{
    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the element to get or set.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public new X509CRL this[int index]
    {
        get
        {
            return (X509CRL)base[index];
        }
        set
        {
            base[index] = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    /// <summary>
    /// Create an empty X509CRL collection.
    /// </summary>
    public X509CRLCollection()
    {
    }

    /// <summary>
    /// Create a crl collection from a single CRL.
    /// </summary>
    public X509CRLCollection(X509CRL crl)
    {
        Add(crl);
    }

    /// <summary>
    /// Create a crl collection from a CRL collection.
    /// </summary>
    public X509CRLCollection(X509CRLCollection crls)
    {
        AddRange(crls);
    }

    /// <summary>
    /// Create a collection from an array.
    /// </summary>
    public X509CRLCollection(X509CRL[] crls)
    {
        AddRange(crls);
    }

    /// <summary>
    /// Converts an array to a collection.
    /// </summary>
    public static X509CRLCollection ToX509CRLCollection(X509CRL[] crls)
    {
        if (crls != null)
        {
            return new X509CRLCollection(crls);
        }
        return new X509CRLCollection();
    }

    /// <summary>
    /// Converts an array to a collection.
    /// </summary>
    public static implicit operator X509CRLCollection(X509CRL[] crls)
    {
        return ToX509CRLCollection(crls);
    }
}
