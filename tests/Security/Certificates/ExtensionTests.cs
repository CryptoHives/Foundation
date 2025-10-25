// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates.Tests;

using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using CryptoHives.Security.Certificates;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;
using X509AuthorityKeyIdentifierExtension = CryptoHives.Security.Certificates.X509AuthorityKeyIdentifierExtension;

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
        using var x509Cert = X509CertificateLoader.LoadCertificate(certAsset.Cert);
        Assert.NotNull(x509Cert);
        TestContext.Out.WriteLine("CertificateAsset:");
        TestContext.Out.WriteLine(x509Cert);
        var altName = X509Extensions.FindExtension<X509SubjectAltNameExtension>(x509Cert);
        if (altName != null)
        {
            TestContext.Out.WriteLine("X509SubjectAltNameExtension:");
            TestContext.Out.WriteLine(altName?.Format(true));
            var ext = new X509Extension(altName.Oid, altName.RawData, altName.Critical);
            TestContext.Out.WriteLine(ext.Format(true));
        }
        var authority = X509Extensions.FindExtension<X509AuthorityKeyIdentifierExtension>(x509Cert);
        if (authority != null)
        {
            TestContext.Out.WriteLine("X509AuthorityKeyIdentifierExtension:");
            TestContext.Out.WriteLine(authority?.Format(true));
            var ext = new X509Extension(authority.Oid, authority.RawData, authority.Critical);
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
        var authorityName = new X500DistinguishedName("CN=Test,O=CryptoHives,DC=localhost");
        byte[] serialNumber = new byte[] { 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        byte[] subjectKeyIdentifier = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var aki = new X509AuthorityKeyIdentifierExtension(subjectKeyIdentifier, authorityName, serialNumber);
        Assert.NotNull(aki);
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
        Assert.That(akidecoded.Issuer.ToString(), Is.EqualTo(authorityName.ToString()));
        Assert.That(akidecoded.GetSerialNumber(), Is.EqualTo(serialNumber));
        Assert.That(akidecoded.SerialNumber, Is.EqualTo(AsnUtils.ToHexString(serialNumber, true)));
        Assert.That(akidecoded.GetKeyIdentifier(), Is.EqualTo(subjectKeyIdentifier));
        akidecoded = new X509AuthorityKeyIdentifierExtension(aki.Oid.Value, aki.RawData, aki.Critical);
        TestContext.Out.WriteLine("Decoded2:");
        TestContext.Out.WriteLine(akidecoded.Format(true));
        Assert.That(akidecoded.RawData, Is.EqualTo(aki.RawData));
        Assert.That(akidecoded.Issuer.ToString(), Is.EqualTo(authorityName.ToString()));
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
        Assert.NotNull(aki);
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
        Assert.NotNull(decodedsan);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(decodedsan.Format(true));
        Assert.NotNull(decodedsan.DomainNames);
        Assert.NotNull(decodedsan.IPAddresses);
        Assert.NotNull(decodedsan.Uris);
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
        Assert.NotNull(decodednumber);
        TestContext.Out.WriteLine("Decoded:");
        TestContext.Out.WriteLine(decodednumber.Format(true));
        Assert.That(decodednumber.CrlNumber, Is.EqualTo(crlNumber));
    }
    #endregion
}

