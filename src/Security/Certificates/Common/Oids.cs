// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates;

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

/// <summary>
/// Oid constants defined for ASN encoding/decoding.
/// </summary>
public static class Oids
{
    /// <summary>
    /// The Oid string of the Digital Signature Algorithm (DSA) subject public key.
    /// </summary>
    public const string Dsa = "1.2.840.10040.4.1";
    /// <summary>
    /// The Oid string for the RSA encryption scheme with PKCS#1. 
    /// </summary>
    public const string Rsa = "1.2.840.113549.1.1.1";
    /// <summary>
    /// The Oid string for the RSA encryption scheme with OAEP. 
    /// </summary>
    public const string RsaOaep = "1.2.840.113549.1.1.7";
    /// <summary>
    /// The Oid string for the RSA encryption scheme with PSS. 
    /// </summary>
    public const string RsaPss = "1.2.840.113549.1.1.10";

    /// <summary>
    /// The Oid string for RSA signature, PKCS#1 padding with SHA1 hash.
    /// </summary>
    public const string RsaPkcs1Sha1 = "1.2.840.113549.1.1.5";
    /// <summary>
    /// The Oid string for RSA signature, PKCS#1 padding with SHA256 hash.
    /// </summary>
    public const string RsaPkcs1Sha256 = "1.2.840.113549.1.1.11";
    /// <summary>
    /// The Oid string for RSA signature, PKCS#1 padding with SHA384 hash.
    /// </summary>
    public const string RsaPkcs1Sha384 = "1.2.840.113549.1.1.12";
    /// <summary>
    /// The Oid string for RSA signature, PKCS#1 padding with SHA512 hash.
    /// </summary>
    public const string RsaPkcs1Sha512 = "1.2.840.113549.1.1.13";

    /// <summary>
    /// The Oid string for a EC public key.
    /// </summary>
    public const string ECPublicKey = "1.2.840.10045.2.1";
    /// <summary>
    /// The Oid string for ECDsa signature with SHA1 hash.
    /// </summary>
    public const string ECDsaWithSha1 = "1.2.840.10045.4.1";
    /// <summary>
    /// The Oid string for ECDsa signature with SHA256 hash.
    /// </summary>
    public const string ECDsaWithSha256 = "1.2.840.10045.4.3.2";
    /// <summary>
    /// The Oid string for ECDsa signature with SHA384 hash.
    /// </summary>
    public const string ECDsaWithSha384 = "1.2.840.10045.4.3.3";
    /// <summary>
    /// The Oid string for ECDsa signature with SHA512 hash.
    /// </summary>
    public const string ECDsaWithSha512 = "1.2.840.10045.4.3.4";

    /// <summary>
    /// The Oid string for the CRL extension of a CRL Number.
    /// </summary>
    public const string CrlNumber = "2.5.29.20";
    /// <summary>
    /// The Oid string for the CRL extension of a CRL Reason Code.
    /// </summary>
    public const string CrlReasonCode = "2.5.29.21";

    /// <summary>
    /// The Oid string for Transport Layer Security(TLS) World Wide Web(WWW)
    /// server authentication. 
    /// </summary>
    public const string ServerAuthentication = "1.3.6.1.5.5.7.3.1";
    /// <summary>
    /// The Oid string for Transport Layer Security(TLS) World Wide Web(WWW)
    /// client authentication. 
    /// </summary>
    public const string ClientAuthentication = "1.3.6.1.5.5.7.3.2";

    /// <summary>
    /// The Oid string for Authority Information access.
    /// </summary>
    public const string AuthorityInfoAccess = "1.3.6.1.5.5.7.1.1";
    /// <summary>
    /// The Oid string for Online Certificate Status Protocol.
    /// </summary>
    public const string OnlineCertificateStatusProtocol = "1.3.6.1.5.5.7.48.1";
    /// <summary>
    /// The Oid string for Certificate Authority Issuer.
    /// </summary>
    public const string CertificateAuthorityIssuers = "1.3.6.1.5.5.7.48.2";
    /// <summary>
    /// The Oid string for CRL Distribution Point.
    /// </summary>
    public const string CRLDistributionPoint = "2.5.29.31";

    /// <summary>
    /// The OID string for Certificate Policies extension.
    /// </summary>
    public const string CertificatePolicies = "2.5.29.32";

    /// <summary>
    /// The OID string for Name Constraints extension.
    /// </summary>
    public const string NameConstraints = "2.5.29.30";

    /// <summary>
    /// The OID string for Policy Constraints extension.
    /// </summary>
    public const string PolicyConstraints = "2.5.29.36";

    /// <summary>
    /// The OID string for Inhibit AnyPolicy extension.
    /// </summary>
    public const string InhibitAnyPolicy = "2.5.29.54";

    /// <summary>
    /// The OID string for Issuing Distribution Point extension.
    /// </summary>
    public const string IssuingDistributionPoint = "2.5.29.28";

    /// <summary>
    /// The OID string for Delta CRL Indicator extension.
    /// </summary>
    public const string DeltaCrlIndicator = "2.5.29.27";

    /// <summary>
    /// The OID string for Freshest CRL extension.
    /// </summary>
    public const string FreshestCrl = "2.5.29.46";

    /// <summary>
    /// The OID string for Private Key Usage Period extension.
    /// </summary>
    public const string PrivateKeyUsagePeriod = "2.5.29.16";

    /// <summary>
    /// The OID string for OCSP No Check extension.
    /// </summary>
    public const string OcspNoCheck = "1.3.6.1.5.5.7.48.1.5";

    /// <summary>
    /// The OID string for TLS Feature extension.
    /// </summary>
    public const string TlsFeature = "1.3.6.1.5.5.7.1.24";

    #region OID Lookup Dictionaries
    /// <summary>
    /// Maps signature algorithm OIDs to their corresponding hash algorithm names.
    /// </summary>
    private static readonly Dictionary<string, HashAlgorithmName> s_oidToHashAlgorithm = new Dictionary<string, HashAlgorithmName>(StringComparer.Ordinal)
    {
        [RsaPkcs1Sha1] = HashAlgorithmName.SHA1,
        [RsaPkcs1Sha256] = HashAlgorithmName.SHA256,
        [RsaPkcs1Sha384] = HashAlgorithmName.SHA384,
        [RsaPkcs1Sha512] = HashAlgorithmName.SHA512,
        [ECDsaWithSha1] = HashAlgorithmName.SHA1,
        [ECDsaWithSha256] = HashAlgorithmName.SHA256,
        [ECDsaWithSha384] = HashAlgorithmName.SHA384,
        [ECDsaWithSha512] = HashAlgorithmName.SHA512
    };

    /// <summary>
    /// Maps hash algorithm names to their corresponding RSA signature OIDs.
    /// </summary>
    private static readonly Dictionary<HashAlgorithmName, string> s_hashAlgorithmToRsaOid = new Dictionary<HashAlgorithmName, string>()
    {
        [HashAlgorithmName.SHA1] = RsaPkcs1Sha1,
        [HashAlgorithmName.SHA256] = RsaPkcs1Sha256,
        [HashAlgorithmName.SHA384] = RsaPkcs1Sha384,
        [HashAlgorithmName.SHA512] = RsaPkcs1Sha512
    };

    /// <summary>
    /// Maps hash algorithm names to their corresponding ECDsa signature OIDs.
    /// </summary>
    private static readonly Dictionary<HashAlgorithmName, string> s_hashAlgorithmToEcdsaOid = new Dictionary<HashAlgorithmName, string>()
    {
        [HashAlgorithmName.SHA1] = ECDsaWithSha1,
        [HashAlgorithmName.SHA256] = ECDsaWithSha256,
        [HashAlgorithmName.SHA384] = ECDsaWithSha384,
        [HashAlgorithmName.SHA512] = ECDsaWithSha512
    };
    #endregion

    /// <summary>
    /// Get the RSA oid for a hash algorithm signature.
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm name.</param>
    public static string GetRSAOid(HashAlgorithmName hashAlgorithm)
    {
        if (s_hashAlgorithmToRsaOid.TryGetValue(hashAlgorithm, out string? oid))
        {
            return oid;
        }
        throw new CryptographicException("Signing RSA with hash {0} is not supported. ", hashAlgorithm.Name);
    }

    /// <summary>
    /// Get the ECDsa oid for a hash algorithm signature.
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm name.</param>
    public static string GetECDsaOid(HashAlgorithmName hashAlgorithm)
    {
        if (s_hashAlgorithmToEcdsaOid.TryGetValue(hashAlgorithm, out string? oid))
        {
            return oid;
        }
        throw new CryptographicException("Signing ECDsa with hash {0} is not supported. ", hashAlgorithm.Name);
    }

    /// <summary>
    /// Get the hash algorithm used to sign a certificate.
    /// </summary>
    /// <param name="oid">The signature algorithm oid.</param>
    public static HashAlgorithmName GetHashAlgorithmName(string oid)
    {
        if (s_oidToHashAlgorithm.TryGetValue(oid, out HashAlgorithmName hashAlgorithm))
        {
            return hashAlgorithm;
        }
        throw new CryptographicException($"Hash algorithm {0} is not supported. ", oid);
    }
}

