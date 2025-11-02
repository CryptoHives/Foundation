// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates;

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Builds a Certificate.
/// </summary>
public abstract class CertificateBuilderBase
    : IX509Certificate
    , ICertificateBuilder
    , ICertificateBuilderConfig
    , ICertificateBuilderSetIssuer
    , ICertificateBuilderParameter
    , ICertificateBuilderIssuer
    , ICertificateBuilderRSAParameter
    , ICertificateBuilderPublicKey
    , ICertificateBuilderRSAPublicKey
    , ICertificateBuilderCreateForRSA
    , ICertificateBuilderCreateForRSAAny
#if ECC_SUPPORT
    , ICertificateBuilderCreateForECDsa
    , ICertificateBuilderECDsaPublicKey
    , ICertificateBuilderECCParameter
    , ICertificateBuilderCreateForECDsaAny
#endif
{
    #region Constructors
    /// <summary>
    /// Initialize a Certificate builder.
    /// </summary>
    protected CertificateBuilderBase(X500DistinguishedName subjectName)
    {
        _issuerName = _subjectName = subjectName;
        Initialize();
    }

    /// <summary>
    /// Initialize a Certificate builder.
    /// </summary>
    protected CertificateBuilderBase(string subjectName)
    {
        _issuerName = _subjectName = new X500DistinguishedName(subjectName);
        Initialize();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    protected virtual void Initialize()
    {
        _notBefore = DateTime.UtcNow.AddDays(-1).Date;
        _notAfter = NotBefore.AddMonths(X509Defaults.LifeTime);
        _hashAlgorithmName = X509Defaults.HashAlgorithmName;
        _serialNumberLength = X509Defaults.SerialNumberLengthMin;
        _extensions = new X509ExtensionCollection();
    }
    #endregion

    #region IX509Certificate Interface
    /// <inheritdoc/>
    public X500DistinguishedName SubjectName => _subjectName;

    /// <inheritdoc/>
    public X500DistinguishedName IssuerName => _issuerName;

    /// <inheritdoc/>
    public DateTime NotBefore => _notBefore;

    /// <inheritdoc/>
    public DateTime NotAfter => _notAfter;

    /// <inheritdoc/>
    public string SerialNumber => _serialNumber.ToHexString(true);

    /// <inheritdoc/>
    public byte[] GetSerialNumber() { return _serialNumber; }

    /// <inheritdoc/>
    public HashAlgorithmName HashAlgorithmName => _hashAlgorithmName;

    /// <inheritdoc/>
    public X509ExtensionCollection Extensions => _extensions;
    #endregion

    #region Public Methods
    /// <inheritdoc/>
    public abstract X509Certificate2 CreateForRSA();

    /// <inheritdoc/>
    public abstract X509Certificate2 CreateForRSA(X509SignatureGenerator generator);

#if ECC_SUPPORT
    /// <inheritdoc/>
    public abstract X509Certificate2 CreateForECDsa();

    /// <inheritdoc/>
    public abstract X509Certificate2 CreateForECDsa(X509SignatureGenerator generator);
#endif
    /// <inheritdoc/>
    public ICertificateBuilder SetSerialNumberLength(int length)
    {
        if (length > X509Defaults.SerialNumberLengthMax || length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "SerialNumber length out of Range");
        }
        _serialNumberLength = length;
        _presetSerial = false;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetSerialNumber(byte[] serialNumber)
    {
        if (serialNumber.Length > X509Defaults.SerialNumberLengthMax ||
            serialNumber.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(serialNumber), "SerialNumber array exceeds supported length.");
        }
        _serialNumberLength = serialNumber.Length;
        _serialNumber = new byte[serialNumber.Length];
        Array.Copy(serialNumber, _serialNumber, serialNumber.Length);
        _serialNumber[_serialNumberLength - 1] &= 0x7f;
        _presetSerial = true;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder CreateSerialNumber()
    {
        NewSerialNumber();
        _presetSerial = true;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetNotBefore(DateTime notBefore)
    {
        _notBefore = notBefore;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetNotAfter(DateTime notAfter)
    {
        _notAfter = notAfter;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetLifeTime(TimeSpan lifeTime)
    {
        _notAfter = _notBefore.Add(lifeTime);
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetLifeTime(ushort months)
    {
        _notAfter = _notBefore.AddMonths(months == 0 ? X509Defaults.LifeTime : months);
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName)
    {
        _hashAlgorithmName = hashAlgorithmName;
        return this;
    }

    /// <inheritdoc/>
    public ICertificateBuilder SetCAConstraint(int pathLengthConstraint = -1)
    {
        _isCA = true;
        _pathLengthConstraint = pathLengthConstraint;
        _serialNumberLength = X509Defaults.SerialNumberLengthMax;
        return this;
    }

    /// <inheritdoc/>
    public virtual ICertificateBuilderCreateForRSAAny SetRSAKeySize(ushort keySize)
    {
        if (keySize == 0)
        {
            keySize = X509Defaults.RSAKeySize;
        }

        if (keySize % 1024 != 0 || keySize < X509Defaults.RSAKeySizeMin || keySize > X509Defaults.RSAKeySizeMax)
        {
            throw new ArgumentException("KeySize must be a multiple of 1024 or is not in the allowed range.", nameof(keySize));
        }

        _keySize = keySize;
        return this;
    }

    /// <inheritdoc/>
    public virtual ICertificateBuilder AddExtension(X509Extension extension)
    {
        if (extension == null) throw new ArgumentNullException(nameof(extension));
        _extensions.Add(extension);
        return this;
    }

#if ECC_SUPPORT
    /// <inheritdoc/>
    public virtual ICertificateBuilderCreateForECDsaAny SetECCurve(ECCurve curve)
    {
        _curve = curve;
        return this;
    }

    /// <inheritdoc/>
    public abstract ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey);

    /// <inheritdoc/>
    public virtual ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(ECDsa publicKey)
    {
        if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
        _ecdsaPublicKey = publicKey;
        return this;
    }
#endif

    /// <inheritdoc/>
    public abstract ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey);

    /// <inheritdoc/>
    public virtual ICertificateBuilderCreateForRSAAny SetRSAPublicKey(RSA publicKey)
    {
        if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
        _rsaPublicKey = publicKey;
        return this;
    }

    /// <inheritdoc/>
    public virtual ICertificateBuilderIssuer SetIssuer(X509Certificate2 issuerCertificate)
    {
        if (issuerCertificate == null) throw new ArgumentNullException(nameof(issuerCertificate));
        _issuerCAKeyCert = issuerCertificate;
        _issuerName = issuerCertificate.SubjectName;
        return this;
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// The issuer CA certificate.
    /// </summary>
    protected X509Certificate2 IssuerCAKeyCert => _issuerCAKeyCert;

    /// <summary>
    /// Validate and adjust settings to avoid creation of invalid certificates.
    /// </summary>
    protected void ValidateSettings()
    {
        // lifetime must be in range of issuer
        if (_issuerCAKeyCert != null)
        {
            if (NotAfter.ToUniversalTime() > _issuerCAKeyCert.NotAfter.ToUniversalTime())
            {
                _notAfter = _issuerCAKeyCert.NotAfter.ToUniversalTime();
            }
            if (NotBefore.ToUniversalTime() < _issuerCAKeyCert.NotBefore.ToUniversalTime())
            {
                _notBefore = _issuerCAKeyCert.NotBefore.ToUniversalTime();
            }
        }
    }

    /// <summary>
    /// Create a new cryptographic random serial number.
    /// </summary>
    protected virtual void NewSerialNumber()
    {
        // new serial number
        using (var rnd = RandomNumberGenerator.Create())
        {
            _serialNumber = new byte[_serialNumberLength];
            rnd.GetBytes(_serialNumber);
        }
        // A compliant certificate uses a positive serial number.
        _serialNumber[_serialNumberLength - 1] &= 0x7F;
    }
    #endregion

    #region Protected Fields
    /// <summary>
    /// If the certificate is a CA.
    /// </summary>
    private protected bool _isCA;
    /// <summary>
    /// The path length constraint to sue for a CA.
    /// </summary>
    private protected int _pathLengthConstraint;
    /// <summary>
    /// The serial number length in octets.
    /// </summary>
    private protected int _serialNumberLength;
    /// <summary>
    /// If the serial number is preset by the user.
    /// </summary>
    private protected bool _presetSerial;
    /// <summary>
    /// The serial number as a little endian byte array.
    /// </summary>
    private protected byte[] _serialNumber;
    /// <summary>
    /// The collection of X509Extension to add to the certificate.
    /// </summary>
    private protected X509ExtensionCollection _extensions;
    /// <summary>
    /// The RSA public to use when if a certificate is signed.
    /// </summary>
    private protected RSA _rsaPublicKey;
    /// <summary>
    /// The size of a RSA key pair to create.
    /// </summary>
    private protected int _keySize;
#if ECC_SUPPORT
    /// <summary>
    /// The ECDsa public to use when if a certificate is signed.
    /// </summary>
    private protected ECDsa _ecdsaPublicKey;
    /// <summary>
    /// The ECCurve to use.
    /// </summary>
    private protected ECCurve? _curve;
#endif
    #endregion

    #region Private Fields
    private X509Certificate2 _issuerCAKeyCert;
    private DateTime _notBefore;
    private DateTime _notAfter;
    private HashAlgorithmName _hashAlgorithmName;
    private X500DistinguishedName _subjectName;
    private X500DistinguishedName _issuerName;
    #endregion
}

