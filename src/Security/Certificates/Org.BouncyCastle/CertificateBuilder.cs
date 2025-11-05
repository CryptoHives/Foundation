// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETSTANDARD2_1 && !NET472_OR_GREATER && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CryptoHives.Security.Certificates.BouncyCastle;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509.Extension;

/// <summary>
/// Builds a Certificate.
/// </summary>
public class CertificateBuilder : CertificateBuilderBase
{
    #region Constructors
    /// <summary>
    /// Create a Certificate builder.
    /// </summary>
    public static ICertificateBuilder Create(X500DistinguishedName subjectName)
    {
        return new CertificateBuilder(subjectName);
    }

    /// <summary>
    /// Create a Certificate builder.
    /// </summary>
    public static ICertificateBuilder Create(string subjectName)
    {
        return new CertificateBuilder(subjectName);
    }

    /// <summary>
    /// Initialize a Certificate builder.
    /// </summary>
    private CertificateBuilder(X500DistinguishedName subjectName)
        : base(subjectName)
    {
    }

    /// <summary>
    /// Initialize a Certificate builder.
    /// </summary>
    private CertificateBuilder(string subjectName)
        : base(subjectName)
    {
    }
    #endregion

    #region Public Methods
    /// <inheritdoc/>
    public override X509Certificate2 CreateForRSA()
    {
        if (_rsaPublicKey != null)
        {
            return CreateForRSAWithPublicKey();
        }
        else
        {
            char[] passcode = X509Utils.GeneratePasscode();
            try
            {
                return X509PfxUtils.CreateCertificateFromPKCS12(CreatePfxForRSA(passcode), passcode);
            }
            finally
            {
                Array.Clear(passcode, 0, passcode.Length);
            }
        }
    }

    /// <inheritdoc/>
    public override X509Certificate2 CreateForRSA(X509SignatureGenerator generator)
    {
        if (generator == null) throw new ArgumentNullException(nameof(generator));
        ISignatureFactory signatureFactory = new X509SignatureFactory(HashAlgorithmName, generator);
        if (_rsaPublicKey != null)
        {
            return CreateForRSAWithPublicKey(signatureFactory);
        }
        else
        {
            char[] passcode = X509Utils.GeneratePasscode();
            try
            {
                return X509PfxUtils.CreateCertificateFromPKCS12(CreatePfxForRSA(passcode, signatureFactory), passcode);
            }
            finally
            {
                Array.Clear(passcode, 0, passcode.Length);
            }
        }
    }

    /// <inheritdoc/>
    public override ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey)
    {
        if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
        try
        {
            _rsaPublicKey = X509Utils.SetRSAPublicKey(publicKey);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to decode and import the public key.", e);
        }
        return this;
    }

    /// <summary>
    /// Create a Pfx with a private key by combining 
    /// an existing X509Certificate2 and a RSA private key.
    /// </summary>
    public static byte[] CreatePfxWithRSAPrivateKey(
        X509Certificate2 certificate,
        string friendlyName,
        RSA privateKey,
        char[] passcode)
    {
        Org.BouncyCastle.X509.X509Certificate x509 = new X509CertificateParser().ReadCertificate(certificate.RawData);
        using var cfrg = new CryptoApiRandomGenerator();
        return X509Utils.CreatePfxWithPrivateKey(
            x509, friendlyName,
            X509Utils.GetPrivateKeyParameter(privateKey),
            passcode,
            new SecureRandom(cfrg));
    }

    /// <summary>
    /// Creates a certificate signing request from an
    /// existing certificate with a private key.
    /// </summary>
    public static byte[] CreateSigningRequest(
        X509Certificate2 certificate,
        IList<String> domainNames = null
        )
    {
        if (certificate == null) throw new ArgumentNullException(nameof(certificate));
        using var cfrg = new CryptoApiRandomGenerator();
        var random = new SecureRandom(cfrg);

        // try to get signing/private key from certificate passed in
        AsymmetricKeyParameter signingKey = X509Utils.GetPrivateKeyParameter(certificate);
        RsaKeyParameters publicKey = X509Utils.GetPublicKeyParameter(certificate);

        ISignatureFactory signatureFactory =
            new Asn1SignatureFactory(X509Utils.GetRSAHashAlgorithm(X509Defaults.HashAlgorithmName), signingKey, random);

        Asn1Set attributes = null;
        X509SubjectAltNameExtension san = X509Extensions.FindExtension<X509SubjectAltNameExtension>(certificate);
        var alternateName = new X509SubjectAltNameExtension(san, san.Critical);

        string applicationUri = null;
        domainNames = domainNames ?? new List<String>();
        if (alternateName != null)
        {
            if (alternateName.Uris.Count > 0)
            {
                applicationUri = alternateName.Uris[0];
            }
            foreach (string name in alternateName.DomainNames)
            {
                if (!domainNames.Any(s => s.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    domainNames.Add(name);
                }
            }
            foreach (string ipAddress in alternateName.IPAddresses)
            {
                if (!domainNames.Any(s => s.Equals(ipAddress, StringComparison.OrdinalIgnoreCase)))
                {
                    domainNames.Add(ipAddress);
                }
            }
        }

        // build CSR extensions
        var generalNames = new List<GeneralName>();

        if (applicationUri != null)
        {
            generalNames.Add(new GeneralName(GeneralName.UniformResourceIdentifier, applicationUri));
        }

        if (domainNames.Count > 0)
        {
            generalNames.AddRange(BouncyCastle.X509Extensions.CreateSubjectAlternateNameDomains(domainNames));
        }

        if (generalNames.Count > 0)
        {
            IList<DerObjectIdentifier> oids = new List<DerObjectIdentifier>();
            IList<Org.BouncyCastle.Asn1.X509.X509Extension> values
                = new List<Org.BouncyCastle.Asn1.X509.X509Extension>();
            oids.Add(Org.BouncyCastle.Asn1.X509.X509Extensions.SubjectAlternativeName);
            values.Add(new Org.BouncyCastle.Asn1.X509.X509Extension(false,
                new DerOctetString(new GeneralNames(generalNames.ToArray()).GetDerEncoded())));
            var attribute = new Org.BouncyCastle.Asn1.Pkcs.AttributePkcs(Org.BouncyCastle.Asn1.Pkcs.PkcsObjectIdentifiers.Pkcs9AtExtensionRequest,
                new DerSet(new Org.BouncyCastle.Asn1.X509.X509Extensions(oids, values)));
            attributes = new DerSet(attribute);
        }

        var pkcs10CertificationRequest = new Pkcs10CertificationRequest(
            signatureFactory,
            new CertificateFactoryX509Name(certificate.SubjectName),
            publicKey,
            attributes);

        return pkcs10CertificationRequest.GetEncoded();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Create a new serial number and validate lifetime.
    /// </summary>
    /// <param name="random"></param>
    private void CreateDefaults(IRandomGenerator random = null)
    {
        if (!_presetSerial)
        {
            NewSerialNumber(random);
        }
        _presetSerial = false;

        ValidateSettings();
    }

    /// <summary>
    /// Set all mandatory fields.
    /// </summary>
    /// <param name="cg">The cert generator</param>
    private void CreateMandatoryFields(X509V3CertificateGenerator cg)
    {
        _subjectDN = new CertificateFactoryX509Name(SubjectName);
        // subject and issuer DN, issuer of issuer for AKI
        _issuerDN = null;
        _issuerIssuerAKI = null;
        if (IssuerCAKeyCert != null)
        {
            _issuerDN = new CertificateFactoryX509Name(IssuerCAKeyCert.SubjectName);
            _issuerIssuerAKI = new CertificateFactoryX509Name(IssuerCAKeyCert.IssuerName);
        }
        else
        {
            // self signed 
            _issuerDN = _subjectDN;
            _issuerIssuerAKI = _subjectDN;
        }
        cg.SetIssuerDN(_issuerDN);
        cg.SetSubjectDN(_subjectDN);

        // valid for
        cg.SetNotBefore(NotBefore.ToUniversalTime());
        cg.SetNotAfter(NotAfter.ToUniversalTime());

        // serial number
        cg.SetSerialNumber(new BigInteger(1, _serialNumber.Reverse().ToArray()));
    }

    /// <summary>
    /// Create the extensions.
    /// </summary>
    /// <param name="cg">The cert generator.</param>
    /// <param name="subjectPublicKey">The public key to use for the extensions.</param>
    private void CreateExtensions(X509V3CertificateGenerator cg, AsymmetricKeyParameter subjectPublicKey)
    {
        if (X509Extensions.FindExtension<X509SubjectKeyIdentifierExtension>(_extensions) == null)
        {
            // Subject key identifier
            cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.SubjectKeyIdentifier.Id, false,
                X509ExtensionUtilities.CreateSubjectKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(subjectPublicKey)));
        }

        // Basic constraints
        var basicConstraints = new BasicConstraints(_isCA);
        if (_isCA && _pathLengthConstraint >= 0)
        {
            basicConstraints = new BasicConstraints(_pathLengthConstraint);
        }
        else if (!_isCA && IssuerCAKeyCert == null)
        {
            // self signed application certificates shall set the CA bit to false
            basicConstraints = new BasicConstraints(false);
        }

        if (X509Extensions.FindExtension<X509BasicConstraintsExtension>(_extensions) == null)
        {
            cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.BasicConstraints.Id, true, basicConstraints);
        }

        // Authority Key identifier references the issuer cert or itself when self signed
        AsymmetricKeyParameter issuerPublicKey;
        BigInteger issuerSerialNumber;
        if (IssuerCAKeyCert != null)
        {
            issuerPublicKey = X509Utils.GetPublicKeyParameter(IssuerCAKeyCert);
            issuerSerialNumber = X509Utils.GetSerialNumber(IssuerCAKeyCert);
        }
        else
        {
            issuerPublicKey = subjectPublicKey;
            issuerSerialNumber = new BigInteger(1, _serialNumber.Reverse().ToArray());
        }

        // Authority Key Identifier
        if (X509Extensions.FindExtension<X509AuthorityKeyIdentifierExtension>(_extensions) == null)
        {
            cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.AuthorityKeyIdentifier.Id, false,
                X509ExtensionUtilities.CreateAuthorityKeyIdentifier(
                    issuerPublicKey,
                    new GeneralNames(new GeneralName(_issuerIssuerAKI)),
                    issuerSerialNumber));
        }

        if (!_isCA)
        {
            // Key usage 
            int keyUsage = KeyUsage.DataEncipherment | KeyUsage.DigitalSignature |
                    KeyUsage.NonRepudiation | KeyUsage.KeyEncipherment;
            if (IssuerCAKeyCert == null)
            {   // only self signed certs need KeyCertSign flag.
                keyUsage |= KeyUsage.KeyCertSign;
            }

            if (X509Extensions.FindExtension<X509KeyUsageExtension>(_extensions) == null)
            {
                cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.KeyUsage, true,
                    new KeyUsage(keyUsage));
            }

            // Extended Key usage
            if (X509Extensions.FindExtension<X509EnhancedKeyUsageExtension>(_extensions) == null)
            {
                cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.ExtendedKeyUsage, true,
                new ExtendedKeyUsage(new List<DerObjectIdentifier>() {
                    new DerObjectIdentifier(Oids.ServerAuthentication), // server auth
                    new DerObjectIdentifier(Oids.ClientAuthentication), // client auth
                }));
            }
        }
        else
        {
            if (X509Extensions.FindExtension<X509KeyUsageExtension>(_extensions) == null)
            {
                // Key usage CA
                cg.AddExtension(Org.BouncyCastle.Asn1.X509.X509Extensions.KeyUsage, true,
                new KeyUsage(KeyUsage.CrlSign | KeyUsage.DigitalSignature | KeyUsage.KeyCertSign));
            }
        }

        foreach (System.Security.Cryptography.X509Certificates.X509Extension extension in _extensions)
        {
            cg.AddExtension(extension.Oid.Value, extension.Critical, Asn1Object.FromByteArray(extension.RawData));
        }
    }

    /// <summary>
    /// Create the RSA certificate with a given public key.
    /// </summary>
    /// <returns>The signed certificate.</returns>
    private X509Certificate2 CreateForRSAWithPublicKey(ISignatureFactory signatureFactory = null)
    {
        // Cases locked out by API flow
        Debug.Assert(_rsaPublicKey != null, "Need a public key for the certificate.");
        if ((IssuerCAKeyCert == null || !IssuerCAKeyCert.HasPrivateKey) && signatureFactory == null)
        {
            throw new NotSupportedException("Need an issuer certificate with a private key or a signature generator.");
        }

        // cert generators
        CreateDefaults();

        var cg = new X509V3CertificateGenerator();
        CreateMandatoryFields(cg);

        // set public key
        AsymmetricKeyParameter subjectPublicKey = X509Utils.GetPublicKeyParameter(_rsaPublicKey);
        cg.SetPublicKey(subjectPublicKey);

        CreateExtensions(cg, subjectPublicKey);

        // sign certificate by issuer
        if (signatureFactory == null)
        {
            AsymmetricKeyParameter signingKey = X509Utils.GetPrivateKeyParameter(IssuerCAKeyCert);
            signatureFactory = new Asn1SignatureFactory(X509Utils.GetRSAHashAlgorithm(HashAlgorithmName), signingKey);
        }
        Org.BouncyCastle.X509.X509Certificate x509 = cg.Generate(signatureFactory);

        // create the signed cert
        return new X509Certificate2(x509.GetEncoded());
    }

    /// <summary>
    /// Create the RSA certificate as Pfx byte array with a private key.
    /// </summary>
    /// <returns>
    /// Returns the Pfx with certificate and private key.
    /// </returns>
    private byte[] CreatePfxForRSA(char[] passcode, ISignatureFactory signatureFactory = null)
    {
        // Cases locked out by API flow
        Debug.Assert(_rsaPublicKey == null, "A public key is not supported for the certificate.");

        if (signatureFactory != null && IssuerCAKeyCert == null)
        {
            throw new NotSupportedException("Need an issuer certificate for a signature generator.");
        }

        if (IssuerCAKeyCert != null &&
            (!IssuerCAKeyCert.HasPrivateKey && signatureFactory == null))
        {
            throw new NotSupportedException("Need an issuer certificate with a private key or a signature generator.");
        }

        using var cfrg = new CryptoApiRandomGenerator();
        // cert generators
        var random = new SecureRandom(cfrg);

        CreateDefaults(cfrg);

        var cg = new X509V3CertificateGenerator();
        CreateMandatoryFields(cg);

        // create Private/Public Keypair
        AsymmetricKeyParameter subjectPublicKey = null;
        AsymmetricKeyParameter subjectPrivateKey = null;
        using (var rsa = new RSACryptoServiceProvider(_keySize == 0 ? X509Defaults.RSAKeySize : _keySize))
        {
            subjectPublicKey = X509Utils.GetPublicKeyParameter(rsa);
            subjectPrivateKey = X509Utils.GetPrivateKeyParameter(rsa);
        }

        cg.SetPublicKey(subjectPublicKey);
        CreateExtensions(cg, subjectPublicKey);

        // sign certificate
        if (signatureFactory == null)
        {
            AsymmetricKeyParameter signingKey;
            if (IssuerCAKeyCert != null)
            {
                // signed by issuer
                signingKey = X509Utils.GetPrivateKeyParameter(IssuerCAKeyCert);
            }
            else
            {
                // self signed
                signingKey = subjectPrivateKey;
            }
            signatureFactory = new Asn1SignatureFactory(
                X509Utils.GetRSAHashAlgorithm(HashAlgorithmName), signingKey, random);
        }
        Org.BouncyCastle.X509.X509Certificate x509 = cg.Generate(signatureFactory);

        // note: this Pfx has a private key!
        return X509Utils.CreatePfxWithPrivateKey(x509, null, subjectPrivateKey, passcode, random);
    }

    /// <summary>
    /// Create a new random serial number.
    /// </summary>
    private void NewSerialNumber(IRandomGenerator random)
    {
        if (random == null)
        {
            NewSerialNumber();
        }
        else
        {
            _serialNumber = new byte[_serialNumberLength];
            random.NextBytes(_serialNumber);
            _serialNumber[_serialNumberLength - 1] &= 0x7f;
        }
    }
    #endregion

    #region Private Fields
    private X509Name _issuerDN;
    private X509Name _issuerIssuerAKI;
    private X509Name _subjectDN;
    #endregion
}

#endif

