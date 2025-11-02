// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates;

#if NETSTANDARD2_1 || NET472_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Builds a Certificate.
/// </summary>
public class CertificateBuilder : CertificateBuilderBase
{
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
    /// Constructor of a Certificate builder.
    /// </summary>
    private CertificateBuilder(X500DistinguishedName subjectName)
        : base(subjectName)
    {
    }

    /// <summary>
    /// Constructor of a Certificate builder.
    /// </summary>
    private CertificateBuilder(string subjectName)
        : base(subjectName)
    {
    }

    /// <inheritdoc/>
    public override X509Certificate2 CreateForRSA()
    {
        CreateDefaults();

        if (_rsaPublicKey != null &&
           (IssuerCAKeyCert == null || !IssuerCAKeyCert.HasPrivateKey))
        {
            throw new NotSupportedException("Cannot use a public key without an issuer certificate with a private key.");
        }

        RSA rsaKeyPair = null;
        RSA rsaPublicKey = _rsaPublicKey;
        if (rsaPublicKey == null)
        {
            rsaKeyPair = RSA.Create(_keySize == 0 ? X509Defaults.RSAKeySize : _keySize);
            rsaPublicKey = rsaKeyPair;
        }

        RSASignaturePadding padding = RSASignaturePadding.Pkcs1;
        var request = new CertificateRequest(SubjectName, rsaPublicKey, HashAlgorithmName, padding);

        CreateX509Extensions(request, false);

        X509Certificate2 signedCert;
        byte[] serialNumber = _serialNumber.Reverse().ToArray();
        if (IssuerCAKeyCert != null)
        {
            using RSA rsaIssuerKey = IssuerCAKeyCert.GetRSAPrivateKey();
            signedCert = request.Create(
                IssuerCAKeyCert.SubjectName,
                X509SignatureGenerator.CreateForRSA(rsaIssuerKey, padding),
                NotBefore,
                NotAfter,
                serialNumber
                );
        }
        else
        {
            signedCert = request.Create(
                SubjectName,
                X509SignatureGenerator.CreateForRSA(rsaKeyPair, padding),
                NotBefore,
                NotAfter,
                serialNumber
                );
        }

        return rsaKeyPair == null ? signedCert : signedCert.CopyWithPrivateKey(rsaKeyPair);
    }

    /// <inheritdoc/>
    public override X509Certificate2 CreateForRSA(X509SignatureGenerator generator)
    {
        CreateDefaults();

        if (_rsaPublicKey == null && IssuerCAKeyCert == null)
        {
            throw new NotSupportedException("Need an issuer certificate or a public key for a signature generator.");
        }

        X500DistinguishedName issuerSubjectName = SubjectName;
        if (IssuerCAKeyCert != null)
        {
            issuerSubjectName = IssuerCAKeyCert.SubjectName;
        }

        RSA rsaKeyPair = null;
        RSA rsaPublicKey = _rsaPublicKey;
        if (rsaPublicKey == null)
        {
            rsaKeyPair = RSA.Create(_keySize == 0 ? X509Defaults.RSAKeySize : _keySize);
            rsaPublicKey = rsaKeyPair;
        }

        var request = new CertificateRequest(SubjectName, rsaPublicKey, HashAlgorithmName, RSASignaturePadding.Pkcs1);

        CreateX509Extensions(request, false);

        X509Certificate2 signedCert = request.Create(
            issuerSubjectName,
            generator,
            NotBefore,
            NotAfter,
            _serialNumber.Reverse().ToArray()
            );

        return rsaKeyPair == null ? signedCert : signedCert.CopyWithPrivateKey(rsaKeyPair);
    }

#if ECC_SUPPORT
    /// <inheritdoc/>
    public override X509Certificate2 CreateForECDsa()
    {
        if (_ecdsaPublicKey != null && IssuerCAKeyCert == null)
        {
            throw new NotSupportedException("Cannot use a public key without an issuer certificate with a private key.");
        }

        if (_ecdsaPublicKey == null && _curve == null)
        {
            throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
        }

        CreateDefaults();

        ECDsa key = null;
        ECDsa publicKey = _ecdsaPublicKey;
        if (publicKey == null)
        {
            key = ECDsa.Create((ECCurve)_curve);
            publicKey = key;
        }

        var request = new CertificateRequest(SubjectName, publicKey, HashAlgorithmName);

        CreateX509Extensions(request, true);

        byte[] serialNumber = _serialNumber.Reverse().ToArray();
        if (IssuerCAKeyCert != null)
        {
            using ECDsa issuerKey = IssuerCAKeyCert.GetECDsaPrivateKey();
            return request.Create(
                IssuerCAKeyCert.SubjectName,
                X509SignatureGenerator.CreateForECDsa(issuerKey),
                NotBefore,
                NotAfter,
                serialNumber
                );
        }
        else
        {
            return request.Create(
                SubjectName,
                X509SignatureGenerator.CreateForECDsa(key),
                NotBefore,
                NotAfter,
                serialNumber
                )
                .CopyWithPrivateKey(key);
        }
    }

    /// <inheritdoc/>
    public override X509Certificate2 CreateForECDsa(X509SignatureGenerator generator)
    {
        if (IssuerCAKeyCert == null)
        {
            throw new NotSupportedException("X509 Signature generator requires an issuer certificate.");
        }

        if (_ecdsaPublicKey == null && _curve == null)
        {
            throw new NotSupportedException("Need a public key or a ECCurve to create the certificate.");
        }

        CreateDefaults();

        ECDsa key = null;
        ECDsa publicKey = _ecdsaPublicKey;
        if (publicKey == null)
        {
            key = ECDsa.Create((ECCurve)_curve);
            publicKey = key;
        }

        var request = new CertificateRequest(SubjectName, publicKey, HashAlgorithmName);

        CreateX509Extensions(request, true);

        X509Certificate2 signedCert = request.Create(
            IssuerCAKeyCert.SubjectName,
            generator,
            NotBefore,
            NotAfter,
            _serialNumber.Reverse().ToArray()
            );

        // return a X509Certificate2
        return key == null ? signedCert : signedCert.CopyWithPrivateKey(key);
    }

    /// <inheritdoc/>
    public override ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey)
    {
        if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
#if NET472_OR_GREATER
        throw new NotSupportedException("Import a ECDsaPublicKey is not supported on this platform.");
#else
        int bytes = 0;
        try
        {
            _ecdsaPublicKey = ECDsa.Create();
            _ecdsaPublicKey.ImportSubjectPublicKeyInfo(publicKey, out bytes);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to decode the public key.", e);
        }

        if (publicKey.Length != bytes)
        {
            throw new ArgumentException("Decoded the public key but extra bytes were found.");
        }
        return this;
#endif
    }
#endif

    /// <inheritdoc/>
    public override ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey)
    {
        if (publicKey == null) throw new ArgumentNullException(nameof(publicKey));
        int bytes = 0;
        try
        {
#if NET472_OR_GREATER
            _rsaPublicKey = X509Utils.SetRSAPublicKey(publicKey);
            bytes = publicKey.Length;
#else
            _rsaPublicKey = RSA.Create();
            _rsaPublicKey.ImportSubjectPublicKeyInfo(publicKey, out bytes);
#endif
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to decode the public key.", e);
        }

        if (publicKey.Length != bytes)
        {
            throw new ArgumentException("Decoded the public key but extra bytes were found.");
        }
        return this;
    }

    /// <summary>
    /// Create some defaults needed to build the certificate.
    /// </summary>
    private void CreateDefaults()
    {
        if (!_presetSerial)
        {
            NewSerialNumber();
        }
        _presetSerial = false;

        ValidateSettings();
    }

    /// <summary>
    /// Create the X509 extensions to build the certificate.
    /// </summary>
    /// <param name="request">A certificate request.</param>
    /// <param name="forECDsa">If the certificate is for ECDsa, not RSA.</param>
    private void CreateX509Extensions(CertificateRequest request, bool forECDsa)
    {
        // Basic Constraints
        if (_extensions.FindExtension<X509BasicConstraintsExtension>() == null)
        {
            X509BasicConstraintsExtension bc = GetBasicContraints();
            request.CertificateExtensions.Add(bc);
        }

        // Subject Key Identifier
        var ski = new X509SubjectKeyIdentifierExtension(
            request.PublicKey,
            X509SubjectKeyIdentifierHashAlgorithm.Sha1,
            false);
        if (_extensions.FindExtension<X509SubjectKeyIdentifierExtension>() == null)
        {
            request.CertificateExtensions.Add(ski);
        }

        // Authority Key Identifier
        if (_extensions.FindExtension<X509AuthorityKeyIdentifierExtension>() == null)
        {
            X509Extension authorityKeyIdentifier = IssuerCAKeyCert != null
                ? X509Extensions.BuildAuthorityKeyIdentifier(IssuerCAKeyCert)
                : new CryptoHives.Security.Certificates.X509AuthorityKeyIdentifierExtension(
                    ski.SubjectKeyIdentifier.FromHexString(),
                    IssuerName,
                    _serialNumber);
            request.CertificateExtensions.Add(authorityKeyIdentifier);
        }

        // Key usage extensions
        if (_extensions.FindExtension<X509KeyUsageExtension>() == null)
        {
            X509KeyUsageFlags keyUsageFlags;
            if (_isCA)
            {
                keyUsageFlags = X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign;
            }
            else
            {
                if (forECDsa)
                {
                    // Key Usage for ECDsa
                    keyUsageFlags = X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation
                        | X509KeyUsageFlags.KeyAgreement;
                }
                else
                {
                    // Key usage for RSA
                    keyUsageFlags = X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment
                        | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation;
                }
                if (IssuerCAKeyCert == null)
                {
                    // self signed case
                    keyUsageFlags |= X509KeyUsageFlags.KeyCertSign;
                }
            }

            request.CertificateExtensions.Add(
                                new X509KeyUsageExtension(
                                    keyUsageFlags,
                                    true));
        }

        if (!_isCA)
        {
            if (_extensions.FindExtension<X509EnhancedKeyUsageExtension>() == null)
            {
                // Enhanced key usage 
                request.CertificateExtensions.Add(
                new X509EnhancedKeyUsageExtension(
                    new OidCollection {
                        new Oid(Oids.ServerAuthentication),
                        new Oid(Oids.ClientAuthentication)
                    }, true));
            }
        }

        foreach (X509Extension extension in _extensions)
        {
            request.CertificateExtensions.Add(extension);
        }
    }

    /// <summary>
    /// Set the basic constraints for various cases.
    /// </summary>
    private X509BasicConstraintsExtension GetBasicContraints()
    {
        // Basic constraints
        if (!_isCA && IssuerCAKeyCert == null)
        {
            // self signed application certificates shall set the CA bit to false
            return new X509BasicConstraintsExtension(false, false, 0, true);
        }
        else if (_isCA && _pathLengthConstraint >= 0)
        {
            // CA with constraints
            return new X509BasicConstraintsExtension(true, true, _pathLengthConstraint, true);
        }
        else
        {
            return new X509BasicConstraintsExtension(_isCA, false, 0, true);
        }
    }
}
#endif

