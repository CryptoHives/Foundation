// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Bcl.Certificates.X509Crl;
using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Supporting functions for X509 extensions.
/// </summary>
public static class X509Extensions
{
    /// <summary>
    /// Find a typed extension in a certificate.
    /// </summary>
    /// <typeparam name="T">The type of the extension.</typeparam>
    /// <param name="certificate">The certificate with extensions.</param>
    public static T? FindExtension<T>(this X509Certificate2 certificate) where T : X509Extension
    {
        return certificate.Extensions.FindExtension<T>();
    }

    /// <summary>
    /// Find a typed extension in a extension collection.
    /// </summary>
    /// <typeparam name="T">The type of the extension.</typeparam>
    /// <param name="extensions">The extensions to search.</param>
    public static T? FindExtension<T>(this X509ExtensionCollection extensions) where T : X509Extension
    {
        if (extensions == null)
        {
            throw new ArgumentNullException(nameof(extensions));
        }

        lock (extensions.SyncRoot)
        {
            // search known custom extensions - avoid LINQ, use manual loop
            if (typeof(T) == typeof(X509AuthorityKeyIdentifierExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    string? oidValue = ext.Oid?.Value;
                    if (oidValue == X509AuthorityKeyIdentifierExtension.AuthorityKeyIdentifierOid ||
                        oidValue == X509AuthorityKeyIdentifierExtension.AuthorityKeyIdentifier2Oid)
                    {
                        return (T)(object)new X509AuthorityKeyIdentifierExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509SubjectAltNameExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    string? oidValue = ext.Oid?.Value;
                    if (oidValue == X509SubjectAltNameExtension.SubjectAltNameOid ||
                        oidValue == X509SubjectAltNameExtension.SubjectAltName2Oid)
                    {
                        return (T)(object)new X509SubjectAltNameExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509CrlNumberExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    string? oidValue = ext.Oid?.Value;
                    if (oidValue == X509CrlNumberExtension.CrlNumberOid)
                    {
                        return (T)(object)new X509CrlNumberExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509AuthorityInformationAccessExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    string? oidValue = ext.Oid?.Value;
                    if (oidValue == X509AuthorityInformationAccessExtension.AuthorityInformationAccessOid)
                    {
                        return (T)(object)new X509AuthorityInformationAccessExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509CrlDistributionPointsExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    string? oidValue = ext.Oid?.Value;
                    if (oidValue == X509CrlDistributionPointsExtension.CrlDistributionPointsOid)
                    {
                        return (T)(object)new X509CrlDistributionPointsExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509CertificatePoliciesExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509CertificatePoliciesExtension.CertificatePoliciesOid)
                    {
                        return (T)(object)new X509CertificatePoliciesExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509NameConstraintsExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509NameConstraintsExtension.NameConstraintsOid)
                    {
                        return (T)(object)new X509NameConstraintsExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509PolicyConstraintsExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509PolicyConstraintsExtension.PolicyConstraintsOid)
                    {
                        return (T)(object)new X509PolicyConstraintsExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509InhibitAnyPolicyExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509InhibitAnyPolicyExtension.InhibitAnyPolicyOid)
                    {
                        return (T)(object)new X509InhibitAnyPolicyExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509IssuingDistributionPointExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509IssuingDistributionPointExtension.IssuingDistributionPointOid)
                    {
                        return (T)(object)new X509IssuingDistributionPointExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509DeltaCrlIndicatorExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509DeltaCrlIndicatorExtension.DeltaCrlIndicatorOid)
                    {
                        return (T)(object)new X509DeltaCrlIndicatorExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509FreshestCrlExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509FreshestCrlExtension.FreshestCrlOid)
                    {
                        return (T)(object)new X509FreshestCrlExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509OcspNoCheckExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509OcspNoCheckExtension.OcspNoCheckOid)
                    {
                        return (T)(object)new X509OcspNoCheckExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509TlsFeatureExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509TlsFeatureExtension.TlsFeatureOid)
                    {
                        return (T)(object)new X509TlsFeatureExtension(ext, ext.Critical);
                    }
                }
            }

            if (typeof(T) == typeof(X509PrivateKeyUsagePeriodExtension))
            {
                foreach (X509Extension ext in extensions)
                {
                    if (ext.Oid?.Value == X509PrivateKeyUsagePeriodExtension.PrivateKeyUsagePeriodOid)
                    {
                        return (T)(object)new X509PrivateKeyUsagePeriodExtension(ext, ext.Critical);
                    }
                }
            }

            // search builtin extension - avoid LINQ OfType<T>().FirstOrDefault()
            foreach (X509Extension ext in extensions)
            {
                if (ext is T typed)
                {
                    return typed;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Build the Authority information Access extension.
    /// </summary>
    /// <param name="caIssuerUrls">Array of CA Issuer Urls</param>
    /// <param name="ocspResponder">optional, the OCSP responder </param>
    public static X509Extension BuildX509AuthorityInformationAccess(
        string[] caIssuerUrls,
        string? ocspResponder = null
        )
    {
        if (string.IsNullOrEmpty(ocspResponder) &&
           (caIssuerUrls == null || caIssuerUrls.Length == 0))
        {
            throw new ArgumentNullException(nameof(caIssuerUrls), "One CA Issuer Url or OCSP responder is required for the extension.");
        }

        var generalNameUriChoice = new Asn1Tag(TagClass.ContextSpecific, 6);
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;
        writer.PushSequence();
        if (caIssuerUrls != null)
        {
            foreach (string caIssuerUrl in caIssuerUrls)
            {
                writer.PushSequence();
                writer.WriteObjectIdentifier(Oids.CertificateAuthorityIssuers);
                writer.WriteCharacterString(
                    UniversalTagNumber.IA5String,
                    caIssuerUrl ?? string.Empty,
                    generalNameUriChoice
                    );
                writer.PopSequence();
            }
        }
        if (!string.IsNullOrEmpty(ocspResponder))
        {
            writer.PushSequence();
            writer.WriteObjectIdentifier(Oids.OnlineCertificateStatusProtocol);
            writer.WriteCharacterString(
                UniversalTagNumber.IA5String,
                ocspResponder!,
                generalNameUriChoice
                );
            writer.PopSequence();
        }
        writer.PopSequence();
        return new X509Extension(Oids.AuthorityInfoAccess, pooledWriter.Encode(), false);
    }

    /// <summary>
    /// Build the CRL Distribution Point extension.
    /// </summary>
    /// <param name="distributionPoint">The CRL distribution point</param>
    public static X509Extension BuildX509CRLDistributionPoints(string distributionPoint)
    {
        return BuildX509CRLDistributionPoints(new string[] { distributionPoint });
    }

    /// <summary>
    /// Build the CRL Distribution Point extension with multiple distribution points.
    /// </summary>
    /// <param name="distributionPoints">The CRL distribution points</param>
    public static X509Extension BuildX509CRLDistributionPoints(IEnumerable<string> distributionPoints)
    {
        var context0 = new Asn1Tag(TagClass.ContextSpecific, 0, true);
        Asn1Tag distributionPointChoice = context0;
        Asn1Tag fullNameChoice = context0;
        var generalNameUriChoice = new Asn1Tag(TagClass.ContextSpecific, 6);
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;
        writer.PushSequence();
        writer.PushSequence();
        writer.PushSequence(distributionPointChoice);
        writer.PushSequence(fullNameChoice);
        foreach (string distributionPoint in distributionPoints)
        {
            writer.WriteCharacterString(
                UniversalTagNumber.IA5String,
                distributionPoint,
                generalNameUriChoice
                );
        }
        writer.PopSequence(fullNameChoice);
        writer.PopSequence(distributionPointChoice);
        writer.PopSequence();
        writer.PopSequence();
        return new X509Extension(Oids.CRLDistributionPoint, pooledWriter.Encode(), false);
    }

    /// <summary>
    /// Read an ASN.1 extension sequence as X509Extension object.
    /// </summary>
    /// <param name="reader">The ASN reader.</param>
    public static X509Extension? ReadExtension(this AsnReader reader)
    {
        if (reader.HasData)
        {
            var boolTag = new Asn1Tag(UniversalTagNumber.Boolean);
            AsnReader extReader = reader.ReadSequence();
            string extOid = extReader.ReadObjectIdentifier();
            bool critical = false;
            Asn1Tag peekTag = extReader.PeekTag();
            if (peekTag == boolTag)
            {
                critical = extReader.ReadBoolean();
            }
            byte[] data = extReader.ReadOctetString();
            extReader.ThrowIfNotEmpty();
            return new X509Extension(new Oid(extOid), data, critical);
        }
        return null;
    }

    /// <summary>
    /// Write an extension object as ASN.1.
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="extension"></param>
    public static void WriteExtension(this AsnWriter writer, X509Extension extension)
    {
        Asn1Tag etag = Asn1Tag.Sequence;
        writer.PushSequence(etag);
        string? oidValue = extension.Oid?.Value;
        if (string.IsNullOrEmpty(oidValue))
        {
            throw new ArgumentException("Extension OID value cannot be null or empty.", nameof(extension));
        }
        writer.WriteObjectIdentifier(oidValue!);
        if (extension.Critical)
        {
            writer.WriteBoolean(extension.Critical);
        }
        writer.WriteOctetString(extension.RawData);
        writer.PopSequence(etag);
    }

    /// <summary>
    /// Build the CRL Reason extension.
    /// </summary>
    public static X509Extension BuildX509CRLReason(CRLReason reason)
    {
        using var pooledWriter = PooledAsnWriterDer.Get();
        pooledWriter.Writer.WriteEnumeratedValue(reason);
        return new X509Extension(Oids.CrlReasonCode, pooledWriter.Encode(), false);
    }

    /// <summary>
    /// Build the Authority Key Identifier from an Issuer CA certificate.
    /// </summary>
    /// <param name="issuerCaCertificate">The issuer CA certificate</param>
    public static X509Extension BuildAuthorityKeyIdentifier(X509Certificate2 issuerCaCertificate)
    {
        // Find the SubjectKeyIdentifier extension
        X509SubjectKeyIdentifierExtension? ski = null;
        foreach (X509Extension ext in issuerCaCertificate.Extensions)
        {
            if (ext is X509SubjectKeyIdentifierExtension skiExt)
            {
                if (ski != null)
                {
                    throw new InvalidOperationException("Multiple SubjectKeyIdentifier extensions found.");
                }
                ski = skiExt;
            }
        }

        if (ski == null)
        {
            throw new InvalidOperationException("SubjectKeyIdentifier extension not found.");
        }

        string skiValue = ski.SubjectKeyIdentifier ?? throw new InvalidOperationException("SubjectKeyIdentifier value is null.");
        return new X509AuthorityKeyIdentifierExtension(
            skiValue.FromHexString(),
            issuerCaCertificate.IssuerName,
            issuerCaCertificate.GetSerialNumber());
    }

    /// <summary>
    /// Build the CRL number.
    /// </summary>
    public static X509Extension BuildCRLNumber(BigInteger crlNumber)
    {
        using var pooledWriter = PooledAsnWriterDer.Get();
        pooledWriter.Writer.WriteInteger(crlNumber);
        return new X509Extension(Oids.CrlNumber, pooledWriter.Encode(), false);
    }
}

