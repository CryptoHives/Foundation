// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates.Tests;

using System;
using System.Collections.Generic;
using System.Numerics;
using SysX509 = System.Security.Cryptography.X509Certificates;
using CryptoHives.Foundation.Security.Bcl.Certificates;
using CryptoHives.Foundation.Security.Certificates;
using NUnit.Framework;

/// <summary>
/// Tests for the CertificateFactory class.
/// </summary>
[TestFixture, Category("X509Extensions")]
[Parallelizable]
[SetCulture("en-us")]
public class ExtensionTests
{
    #region DataPointSources
    [DatapointSource]
    public CertificateAsset[] CertificateTestCases = new AssetCollection<CertificateAsset>(TestUtils.EnumerateTestAssets("*.?er")).ToArray();
    #endregion

    #region Test Methods
    [Theory]
    public void DecodeExtensions(CertificateAsset certAsset)
    {
        using var x509Cert = SysX509.X509CertificateLoader.LoadCertificate(certAsset.Cert);
        Assert.That(x509Cert, Is.Not.Null);
        TestContext.Out.WriteLine("CertificateAsset:");
        TestContext.Out.WriteLine(x509Cert);
        var altName = X509Extensions.FindExtension<X509SubjectAltNameExtension>(x509Cert);
        if (altName != null)
        {
            TestContext.Out.WriteLine("X509SubjectAltNameExtension:");
            TestContext.Out.WriteLine(altName.Format(true));
            var ext = new SysX509.X509Extension(altName.Oid, altName.RawData, altName.Critical);
            TestContext.Out.WriteLine(ext.Format(true));
        }

        var authority = X509Extensions.FindExtension<X509AuthorityKeyIdentifierExtension>(x509Cert);
        if (authority != null)
        {
            TestContext.Out.WriteLine("X509AuthorityKeyIdentifierExtension:");
            TestContext.Out.WriteLine(authority.Format(true));
            var ext = new SysX509.X509Extension(authority.Oid, authority.RawData, authority.Critical);
            TestContext.Out.WriteLine(ext.Format(true));
        }

        TestContext.Out.WriteLine("All extensions:");
        foreach (var extension in x509Cert.Extensions)
        {
            TestContext.Out.WriteLine(extension.Format(true));
        }
    }

    /// <summary>
    /// Verify encode and decode of authority key identifier.
    /// </summary>
    [Test]
    public void VerifyX509AuthorityKeyIdentifierExtension()
    {
        var authorityName = new SysX509.X500DistinguishedName("CN=Test, O=CryptoHives, DC=localhost");
        byte[] serialNumber = new byte[] { 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        byte[] subjectKeyIdentifier = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var aki = new X509AuthorityKeyIdentifierExtension(subjectKeyIdentifier, authorityName, serialNumber);
        Assert.That(aki, Is.Not.Null);
        TestContext.Out.WriteLine("Encoded:");
        TestContext.Out.WriteLine(aki.Format(true));
        Assert.That(aki.Issuer, Is.EqualTo(authorityName));
        Assert.That(aki.GetSerialNumber(), Is.EqualTo(serialNumber));
        Assert.That(aki.SerialNumber, Is.EqualTo(AsnUtils.ToHexString(serialNumber, true)));
        Assert.That(aki.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
        var akidecoded = new X509AuthorityKeyIdentifierExtension(aki.Oid, aki.RawData, aki.Critical);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(akidecoded.Format(true));
        Assert.That(akidecoded.RawData, Is.EqualTo(aki.RawData));
        Assert.That(akidecoded.Issuer.Name, Is.EqualTo(authorityName.Name));
        Assert.That(akidecoded.GetSerialNumber(), Is.EqualTo(serialNumber));
        Assert.That(akidecoded.SerialNumber, Is.EqualTo(AsnUtils.ToHexString(serialNumber, true)));
        Assert.That(akidecoded.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
        akidecoded = new X509AuthorityKeyIdentifierExtension(aki.Oid.Value, aki.RawData, aki.Critical);
        TestContext.Out.WriteLine("Decoded2:");
        TestContext.Out.WriteLine(akidecoded.Format(true));
        Assert.That(akidecoded.RawData, Is.EqualTo(aki.RawData));
        Assert.That(akidecoded.Issuer.Name, Is.EqualTo(authorityName.Name));
        Assert.That(akidecoded.GetSerialNumber(), Is.EqualTo(serialNumber));
        Assert.That(akidecoded.SerialNumber, Is.EqualTo(AsnUtils.ToHexString(serialNumber, true)));
        Assert.That(akidecoded.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
    }

    /// <summary>
    /// Verify authority Key Identifier API. Only Key ID.
    /// </summary>
    [Test]
    public void VerifyX509AuthorityKeyIdentifierExtensionOnlyKeyID()
    {
        byte[] subjectKeyIdentifier = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var aki = new X509AuthorityKeyIdentifierExtension(subjectKeyIdentifier);
        Assert.That(aki, Is.Not.Null);
        TestContext.Out.WriteLine("Encoded:");
        TestContext.Out.WriteLine(aki.Format(true));
        Assert.Null(aki.Issuer);
        Assert.Null(aki.GetSerialNumber());
        Assert.That(aki.SerialNumber, Is.Empty);
        Assert.That(aki.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
        var akidecoded = new X509AuthorityKeyIdentifierExtension(aki.Oid, aki.RawData, aki.Critical);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(akidecoded.Format(true));
        Assert.That(akidecoded.RawData, Is.EqualTo(aki.RawData));
        Assert.Null(aki.Issuer);
        Assert.Null(aki.GetSerialNumber());
        Assert.That(aki.SerialNumber, Is.Empty);
        Assert.That(akidecoded.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
        akidecoded = new X509AuthorityKeyIdentifierExtension(aki.Oid.Value, aki.RawData, aki.Critical);
        TestContext.Out.WriteLine("Decoded2:");
        TestContext.Out.WriteLine(akidecoded.Format(true));
        Assert.That(akidecoded.RawData, Is.EqualTo(aki.RawData));
        Assert.Null(aki.Issuer);
        Assert.Null(aki.GetSerialNumber());
        Assert.That(aki.SerialNumber, Is.Empty);
        Assert.That(akidecoded.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
    }

    /// <summary>
    /// Verify encode and decode of authority key identifier.
    /// </summary>
    [Test]
    public void VerifyX509SubjectAlternateNameExtension()
    {
        string applicationUri = "urn:cryptohives.org";
        string[] domainNames = { "mypc.mydomain.com", "192.168.100.100", "1234:5678::1" };
        TestContext.Out.WriteLine("Encoded:");
        var san = new X509SubjectAltNameExtension(applicationUri, domainNames);
        TestContext.Out.WriteLine(san.Format(true));
        var decodedsan = new X509SubjectAltNameExtension(san.Oid.Value, san.RawData, san.Critical);
        Assert.That(decodedsan, Is.Not.Null);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(decodedsan.Format(true));
        Assert.That(decodedsan.DomainNames, Is.Not.Null);
        Assert.That(decodedsan.IPAddresses, Is.Not.Null);
        Assert.That(decodedsan.Uris, Is.Not.Null);
        Assert.That(decodedsan.Uris.Count, Is.EqualTo(1));
        Assert.That(decodedsan.DomainNames.Count, Is.EqualTo(1));
        Assert.That(decodedsan.IPAddresses.Count, Is.EqualTo(2));
        Assert.That(san.Oid.Value, Is.EqualTo(decodedsan.Oid.Value));
        Assert.That(san.Critical, Is.EqualTo(decodedsan.Critical));
        Assert.That(decodedsan.Uris[0], Is.EqualTo(applicationUri));
        Assert.That(decodedsan.DomainNames[0], Is.EqualTo(domainNames[0]));
        Assert.That(decodedsan.IPAddresses[0], Is.EqualTo(domainNames[1]));
        Assert.That(decodedsan.IPAddresses[1], Is.EqualTo(domainNames[2]));
    }

    /// <summary>
    /// Verify encode and decode of CRL Number.
    /// </summary>
    [Test]
    public void VerifyCRLNumberExtension()
    {
        BigInteger crlNumber = 123456789;
        TestContext.Out.WriteLine("Encoded:");
        var number = new X509CrlNumberExtension(crlNumber);
        TestContext.Out.WriteLine(number.Format(true));
        var decodednumber = new X509CrlNumberExtension(number.Oid.Value, number.RawData, number.Critical);
        Assert.That(decodednumber, Is.Not.Null);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(decodednumber.Format(true));
        Assert.That(decodednumber.CrlNumber, Is.EqualTo(crlNumber));
    }

    [Test]
    public void VerifyAuthorityInformationAccessExtension()
    {
        var caIssuers = new[]
        {
            "http://ca.example.org/issuer1.crt",
            "http://ca.example.org/issuer2.crt"
        };
        const string ocsp = "http://ocsp.example.org";

        var aia = new X509AuthorityInformationAccessExtension(caIssuers, ocsp);
        Assert.That(aia.Oid.Value, Is.EqualTo(X509AuthorityInformationAccessExtension.AuthorityInformationAccessOid));
        Assert.That(aia.CaIssuersUris, Is.EqualTo(caIssuers));
        Assert.That(aia.OcspResponderUris.Count, Is.EqualTo(1));
        Assert.That(aia.OcspResponderUris[0], Is.EqualTo(ocsp));

        var decoded = new X509AuthorityInformationAccessExtension(aia.Oid.Value, aia.RawData, aia.Critical);
        Assert.That(decoded.CaIssuersUris, Is.EqualTo(caIssuers));
        Assert.That(decoded.OcspResponderUris.Count, Is.EqualTo(1));
        Assert.That(decoded.OcspResponderUris[0], Is.EqualTo(ocsp));

        var collection = new SysX509.X509ExtensionCollection { aia };
        var typed = collection.FindExtension<X509AuthorityInformationAccessExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.CaIssuersUris, Is.EqualTo(caIssuers));
    }

    [Test]
    public void VerifyCrlDistributionPointsExtension()
    {
        var distributionPoints = new List<string>
        {
            "http://ca.example.org/ca1.crl",
            "http://ca.example.org/ca2.crl"
        };

        var cdp = new X509CrlDistributionPointsExtension(distributionPoints);
        Assert.That(cdp.Oid.Value, Is.EqualTo(X509CrlDistributionPointsExtension.CrlDistributionPointsOid));
        Assert.That(cdp.DistributionPointUris, Is.EqualTo(distributionPoints));

        var decoded = new X509CrlDistributionPointsExtension(cdp.Oid.Value, cdp.RawData, cdp.Critical);
        Assert.That(decoded.DistributionPointUris, Is.EqualTo(distributionPoints));

        var collection = new SysX509.X509ExtensionCollection { cdp };
        var typed = collection.FindExtension<X509CrlDistributionPointsExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.DistributionPointUris, Is.EqualTo(distributionPoints));
    }

    [Test]
    public void VerifyCertificatePoliciesExtension()
    {
        var policyOids = new[] { "2.23.140.1.2.1", "1.3.6.1.4.1.311.60.2.1.3" };

        var ext = new X509CertificatePoliciesExtension(policyOids);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509CertificatePoliciesExtension.CertificatePoliciesOid));
        Assert.That(ext.PolicyOids, Is.EqualTo(policyOids));

        var decoded = new X509CertificatePoliciesExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.PolicyOids, Is.EqualTo(policyOids));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509CertificatePoliciesExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.PolicyOids, Is.EqualTo(policyOids));
    }

    [Test]
    public void VerifyNameConstraintsExtension()
    {
        var permitted = new[] { ".example.org", ".internal.example.org" };
        var excluded = new[] { ".blocked.example.org" };

        var ext = new X509NameConstraintsExtension(permitted, excluded);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509NameConstraintsExtension.NameConstraintsOid));
        Assert.That(ext.PermittedDnsDomains, Is.EqualTo(permitted));
        Assert.That(ext.ExcludedDnsDomains, Is.EqualTo(excluded));

        var decoded = new X509NameConstraintsExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.PermittedDnsDomains, Is.EqualTo(permitted));
        Assert.That(decoded.ExcludedDnsDomains, Is.EqualTo(excluded));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509NameConstraintsExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.PermittedDnsDomains, Is.EqualTo(permitted));
    }

    [Test]
    public void VerifyPolicyConstraintsExtension()
    {
        var ext = new X509PolicyConstraintsExtension(requireExplicitPolicy: 1, inhibitPolicyMapping: 2);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509PolicyConstraintsExtension.PolicyConstraintsOid));
        Assert.That(ext.RequireExplicitPolicy, Is.EqualTo(1));
        Assert.That(ext.InhibitPolicyMapping, Is.EqualTo(2));

        var decoded = new X509PolicyConstraintsExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.RequireExplicitPolicy, Is.EqualTo(1));
        Assert.That(decoded.InhibitPolicyMapping, Is.EqualTo(2));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509PolicyConstraintsExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.RequireExplicitPolicy, Is.EqualTo(1));
    }

    [Test]
    public void VerifyInhibitAnyPolicyExtension()
    {
        var ext = new X509InhibitAnyPolicyExtension(0);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509InhibitAnyPolicyExtension.InhibitAnyPolicyOid));
        Assert.That(ext.SkipCerts, Is.EqualTo(0));

        var decoded = new X509InhibitAnyPolicyExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.SkipCerts, Is.EqualTo(0));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509InhibitAnyPolicyExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.SkipCerts, Is.EqualTo(0));
    }

    [Test]
    public void VerifyIssuingDistributionPointExtension()
    {
        var uris = new[] { "http://ca.example.org/issuing.crl" };

        var ext = new X509IssuingDistributionPointExtension(uris, indirectCrl: true);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509IssuingDistributionPointExtension.IssuingDistributionPointOid));
        Assert.That(ext.DistributionPointUris, Is.EqualTo(uris));
        Assert.That(ext.IndirectCrl, Is.True);

        var decoded = new X509IssuingDistributionPointExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.DistributionPointUris, Is.EqualTo(uris));
        Assert.That(decoded.IndirectCrl, Is.True);

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509IssuingDistributionPointExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.IndirectCrl, Is.True);
    }

    [Test]
    public void VerifyDeltaCrlIndicatorExtension()
    {
        var ext = new X509DeltaCrlIndicatorExtension(new BigInteger(123));
        Assert.That(ext.Oid.Value, Is.EqualTo(X509DeltaCrlIndicatorExtension.DeltaCrlIndicatorOid));
        Assert.That(ext.BaseCrlNumber, Is.EqualTo(new BigInteger(123)));

        var decoded = new X509DeltaCrlIndicatorExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.BaseCrlNumber, Is.EqualTo(new BigInteger(123)));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509DeltaCrlIndicatorExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.BaseCrlNumber, Is.EqualTo(new BigInteger(123)));
    }

    [Test]
    public void VerifyFreshestCrlExtension()
    {
        var uris = new[] { "http://ca.example.org/delta1.crl", "http://ca.example.org/delta2.crl" };

        var ext = new X509FreshestCrlExtension(uris);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509FreshestCrlExtension.FreshestCrlOid));
        Assert.That(ext.DistributionPointUris, Is.EqualTo(uris));

        var decoded = new X509FreshestCrlExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.DistributionPointUris, Is.EqualTo(uris));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509FreshestCrlExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.DistributionPointUris, Is.EqualTo(uris));
    }

    [Test]
    public void VerifyOcspNoCheckExtension()
    {
        var ext = new X509OcspNoCheckExtension();
        Assert.That(ext.Oid.Value, Is.EqualTo(X509OcspNoCheckExtension.OcspNoCheckOid));

        var decoded = new X509OcspNoCheckExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.Oid.Value, Is.EqualTo(X509OcspNoCheckExtension.OcspNoCheckOid));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509OcspNoCheckExtension>();
        Assert.That(typed, Is.Not.Null);
    }

    [Test]
    public void VerifyTlsFeatureExtension()
    {
        var ext = new X509TlsFeatureExtension(new[] { X509TlsFeatureExtension.StatusRequest, X509TlsFeatureExtension.StatusRequestV2 });
        Assert.That(ext.Oid.Value, Is.EqualTo(X509TlsFeatureExtension.TlsFeatureOid));
        Assert.That(ext.FeatureIds, Is.EqualTo(new[] { X509TlsFeatureExtension.StatusRequest, X509TlsFeatureExtension.StatusRequestV2 }));

        var decoded = new X509TlsFeatureExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.FeatureIds, Is.EqualTo(ext.FeatureIds));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509TlsFeatureExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.FeatureIds, Is.EqualTo(ext.FeatureIds));
    }

    [Test]
    public void VerifyPrivateKeyUsagePeriodExtension()
    {
        DateTimeOffset notBefore = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        DateTimeOffset notAfter = new DateTimeOffset(2026, 12, 31, 23, 59, 59, TimeSpan.Zero);

        var ext = new X509PrivateKeyUsagePeriodExtension(notBefore, notAfter);
        Assert.That(ext.Oid.Value, Is.EqualTo(X509PrivateKeyUsagePeriodExtension.PrivateKeyUsagePeriodOid));
        Assert.That(ext.NotBefore, Is.EqualTo(notBefore));
        Assert.That(ext.NotAfter, Is.EqualTo(notAfter));

        var decoded = new X509PrivateKeyUsagePeriodExtension(ext.Oid.Value!, ext.RawData, ext.Critical);
        Assert.That(decoded.NotBefore, Is.EqualTo(notBefore));
        Assert.That(decoded.NotAfter, Is.EqualTo(notAfter));

        var collection = new SysX509.X509ExtensionCollection { ext };
        var typed = collection.FindExtension<X509PrivateKeyUsagePeriodExtension>();
        Assert.That(typed, Is.Not.Null);
        Assert.That(typed!.NotAfter, Is.EqualTo(notAfter));
    }
    #endregion
}


