// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.X509Crl;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Builds a CRL.
/// </summary>
public sealed class CrlBuilder : IX509CRL
{
    #region Constructors
    /// <summary>
    /// Create a CRL builder initialized with a decoded CRL.
    /// </summary>
    /// <param name="crl">The decoded CRL</param>
    public static CrlBuilder Create(IX509CRL crl)
    {
        return new CrlBuilder(crl);
    }

    /// <summary>
    /// Initialize the CRL builder with Issuer.
    /// </summary>
    /// <param name="issuerSubjectName">Issuer name</param>
    public static CrlBuilder Create(X500DistinguishedName issuerSubjectName)
    {
        return new CrlBuilder(issuerSubjectName);
    }

    /// <summary>
    /// Initialize the CRL builder with Issuer and hash algorithm.
    /// </summary>
    /// <param name="issuerSubjectName">Issuer distinguished name</param>
    /// <param name="hashAlgorithmName">The signing algorithm to use.</param>
    public static CrlBuilder Create(X500DistinguishedName issuerSubjectName, HashAlgorithmName hashAlgorithmName)
    {
        return new CrlBuilder(issuerSubjectName, hashAlgorithmName);
    }

    /// <summary>
    /// Create a CRL builder initialized with a decoded CRL.
    /// </summary>
    /// <param name="crl">The decoded CRL</param>
    private CrlBuilder(IX509CRL crl)
    {
        IssuerName = crl.IssuerName;
        HashAlgorithmName = crl.HashAlgorithmName;
        ThisUpdate = crl.ThisUpdate;
        NextUpdate = crl.NextUpdate;
        RawData = crl.RawData;
        _revokedCertificates = new List<RevokedCertificate>(crl.RevokedCertificates);
        _crlExtensions = new X509ExtensionCollection();
        foreach (X509Extension extension in crl.CrlExtensions)
        {
            _crlExtensions.Add(extension);
        }
    }

    /// <summary>
    /// Initialize the CRL builder with Issuer.
    /// </summary>
    /// <param name="issuerSubjectName">Issuer name</param>
    private CrlBuilder(X500DistinguishedName issuerSubjectName)
        : this(issuerSubjectName, X509Defaults.HashAlgorithmName)
    {
    }

    /// <summary>
    /// Initialize the CRL builder with Issuer and hash algorithm.
    /// </summary>
    /// <param name="issuerSubjectName">Issuer distinguished name</param>
    /// <param name="hashAlgorithmName">The signing algorithm to use.</param>
    private CrlBuilder(X500DistinguishedName issuerSubjectName, HashAlgorithmName hashAlgorithmName)
        : this()
    {
        IssuerName = issuerSubjectName;
        HashAlgorithmName = hashAlgorithmName;
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    private CrlBuilder()
    {
        ThisUpdate = DateTime.UtcNow;
        NextUpdate = DateTime.MinValue;
        _revokedCertificates = new List<RevokedCertificate>();
        _crlExtensions = new X509ExtensionCollection();
    }
    #endregion

    #region IX509CRL Interface
    /// <inheritdoc/>
    public X500DistinguishedName IssuerName { get; }

    /// <inheritdoc/>
    public string Issuer => IssuerName.Name;

    /// <inheritdoc/>
    public DateTime ThisUpdate { get; private set; }

    /// <inheritdoc/>
    public DateTime NextUpdate { get; private set; }

    /// <inheritdoc/>
    public HashAlgorithmName HashAlgorithmName { get; private set; }

    /// <inheritdoc/>
    public IList<RevokedCertificate> RevokedCertificates => _revokedCertificates;

    /// <inheritdoc/>
    public X509ExtensionCollection CrlExtensions => _crlExtensions;

    /// <inheritdoc/>
    public byte[] RawData { get; private set; }
    #endregion

    #region Public Methods
    /// <summary>
    /// Set this update time.
    /// </summary>
    public CrlBuilder SetThisUpdate(DateTime thisUpdate)
    {
        ThisUpdate = thisUpdate;
        return this;
    }

    /// <summary>
    /// Set next update time (optional).
    /// </summary>
    public CrlBuilder SetNextUpdate(DateTime nextUpdate)
    {
        NextUpdate = nextUpdate;
        return this;
    }

    /// <summary>
    /// Set the hash algorithm.
    /// </summary>
    public CrlBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
    {
        HashAlgorithmName = hashAlgorithmName;
        return this;
    }

    /// <summary>
    /// Add array of serialnumbers of revoked certificates.
    /// </summary>
    /// <param name="serialNumbers">The array of serial numbers to revoke.</param>
    /// <param name="crlReason">The revocation reason</param>
    public CrlBuilder AddRevokedSerialNumbers(string[] serialNumbers, CRLReason crlReason = CRLReason.Unspecified)
    {
        if (serialNumbers == null) throw new ArgumentNullException(nameof(serialNumbers));
        _revokedCertificates.AddRange(serialNumbers.Select(s => new RevokedCertificate(s, crlReason)).ToList());
        return this;
    }

    /// <summary>
    /// Add a revoked certificate.
    /// </summary>
    /// <param name="certificate">The certificate to revoke.</param>
    /// <param name="crlReason">The revocation reason</param>
    public CrlBuilder AddRevokedCertificate(X509Certificate2 certificate, CRLReason crlReason = CRLReason.Unspecified)
    {
        if (certificate == null) throw new ArgumentNullException(nameof(certificate));
        _revokedCertificates.Add(new RevokedCertificate(certificate.SerialNumber, crlReason));
        return this;
    }

    /// <summary>
    /// Add a revoked certificate.
    /// </summary>
    public CrlBuilder AddRevokedCertificate(RevokedCertificate revokedCertificate)
    {
        if (revokedCertificate == null) throw new ArgumentNullException(nameof(revokedCertificate));
        _revokedCertificates.Add(revokedCertificate);
        return this;
    }

    /// <summary>
    /// Add a list of revoked certificate.
    /// </summary>
    public CrlBuilder AddRevokedCertificates(IList<RevokedCertificate> revokedCertificates)
    {
        if (revokedCertificates == null) throw new ArgumentNullException(nameof(revokedCertificates));
        _revokedCertificates.AddRange(revokedCertificates);
        return this;
    }

    /// <summary>
    /// Add a revoked certificate.
    /// </summary>
    public CrlBuilder AddCRLExtension(X509Extension extension)
    {
        _crlExtensions.Add(extension);
        return this;
    }

    /// <summary>
    /// Create the CRL with signature generator.
    /// </summary>
    /// <param name="generator">The RSA or ECDsa signature generator to use.</param>
    /// <returns>The signed CRL.</returns>
    public IX509CRL CreateSignature(X509SignatureGenerator generator)
    {
        byte[] tbsRawData = Encode();
        byte[] signatureAlgorithm = generator.GetSignatureAlgorithmIdentifier(HashAlgorithmName);
        byte[] signature = generator.SignData(tbsRawData, HashAlgorithmName);
        var crlSigner = new X509Signature(tbsRawData, signature, signatureAlgorithm);
        RawData = crlSigner.Encode();
        return this;
    }

    /// <summary>
    /// Create the CRL with signature for RSA.
    /// </summary>
    /// <returns>The signed CRL.</returns>
    public IX509CRL CreateForRSA(X509Certificate2 issuerCertificate)
    {
        using RSA rsa = issuerCertificate.GetRSAPrivateKey();
        var generator = X509SignatureGenerator.CreateForRSA(rsa, RSASignaturePadding.Pkcs1);
        return CreateSignature(generator);
    }

#if ECC_SUPPORT
    /// <summary>
    /// Create the CRL with signature for ECDsa.
    /// </summary>
    /// <returns>The signed CRL.</returns>
    public IX509CRL CreateForECDsa(X509Certificate2 issuerCertificate)
    {
        using ECDsa ecdsa = issuerCertificate.GetECDsaPrivateKey();
        var generator = X509SignatureGenerator.CreateForECDsa(ecdsa);
        return CreateSignature(generator);
    }
#endif
    #endregion

    #region Internal Methods
    /// <summary>
    /// Constructs Certificate Revocation List raw data in X509 ASN format.
    /// </summary>
    /// <remarks>
    /// CRL fields -- https://tools.ietf.org/html/rfc5280#section-5.1
    /// 
    /// CertificateList  ::=  SEQUENCE  {
    ///    tbsCertList          TBSCertList,
    ///    signatureAlgorithm   AlgorithmIdentifier,
    ///    signatureValue       BIT STRING
    ///    }
    ///
    /// TBSCertList  ::=  SEQUENCE  {
    ///    version                 Version OPTIONAL,
    ///                            -- if present, MUST be v2
    ///    signature               AlgorithmIdentifier,
    ///    issuer                  Name,
    ///    thisUpdate              Time,
    ///    nextUpdate              Time OPTIONAL,
    ///    revokedCertificates     SEQUENCE OF SEQUENCE  {
    ///        userCertificate         CertificateSerialNumber,
    ///        revocationDate          Time,
    ///        crlEntryExtensions      Extensions OPTIONAL
    ///                              -- if present, version MUST be v2
    ///                            }  OPTIONAL,
    ///    crlExtensions           [0]  EXPLICIT Extensions OPTIONAL
    ///                              -- if present, version MUST be v2
    ///                            }
    /// </remarks>
    internal byte[] Encode()
    {
        var crlWriter = new AsnWriter(AsnEncodingRules.DER);
        {
            // tbsCertList
            crlWriter.PushSequence();

            // version
            crlWriter.WriteInteger(1);

            // Signature Algorithm Identifier
            crlWriter.PushSequence();
            string signatureAlgorithm = Oids.GetRSAOid(HashAlgorithmName);
            crlWriter.WriteObjectIdentifier(signatureAlgorithm);
            crlWriter.WriteNull();

            // pop
            crlWriter.PopSequence();

            // Issuer
            crlWriter.WriteEncodedValue((ReadOnlySpan<byte>)IssuerName.RawData);

            // this update
            WriteTime(crlWriter, ThisUpdate);

            // next update is OPTIONAL
            if (NextUpdate != DateTime.MinValue &&
                NextUpdate > ThisUpdate)
            {
                // next update
                WriteTime(crlWriter, NextUpdate);
            }

            // revocedCertificates is OPTIONAL
            if (RevokedCertificates.Count > 0)
            {
                // sequence to start the revoked certificates.
                crlWriter.PushSequence();

                foreach (RevokedCertificate revokedCert in RevokedCertificates)
                {
                    crlWriter.PushSequence();

                    var srlNumberValue = new BigInteger(revokedCert.UserCertificate);
                    crlWriter.WriteInteger(srlNumberValue);
                    WriteTime(crlWriter, revokedCert.RevocationDate);

                    if (revokedCert.CrlEntryExtensions.Count > 0)
                    {
                        crlWriter.PushSequence();
                        foreach (X509Extension crlEntryExt in revokedCert.CrlEntryExtensions)
                        {
                            crlWriter.WriteExtension(crlEntryExt);
                        }
                        crlWriter.PopSequence();
                    }
                    crlWriter.PopSequence();
                }

                crlWriter.PopSequence();
            }

            // CRL extensions OPTIONAL
            if (CrlExtensions.Count > 0)
            {
                // [0]  EXPLICIT Extensions OPTIONAL
                var tag = new Asn1Tag(TagClass.ContextSpecific, 0);
                crlWriter.PushSequence(tag);

                // CRL extensions
                crlWriter.PushSequence();
                foreach (X509Extension extension in CrlExtensions)
                {
                    crlWriter.WriteExtension(extension);
                }
                crlWriter.PopSequence();

                crlWriter.PopSequence(tag);
            }

            crlWriter.PopSequence();

            return crlWriter.Encode();
        }
    }

    /// <summary>
    /// Write either a UTC time or a Generalized time depending if DataTime is before or after 2050.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="dateTime">The date time to write.</param>
    private static void WriteTime(AsnWriter writer, DateTime dateTime)
    {
        DateTime utcTime = dateTime.ToUniversalTime();
        if (utcTime.Year < 2050)
        {
            writer.WriteUtcTime(utcTime);
        }
        else
        {
            writer.WriteGeneralizedTime(utcTime, true);
        }
    }
    #endregion

    #region Private Fields
    private List<RevokedCertificate> _revokedCertificates;
    private X509ExtensionCollection _crlExtensions;
    #endregion
}

