// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates.Tests;

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CryptoHives.Security.Certificates;
using CryptoHives.Security.Certificates.X509Crl;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

/// <summary>
/// Tests for the CRL class.
/// </summary>
[TestFixture, Category("CRL")]
[Parallelizable]
[SetCulture("en-us")]
public class CRLTests
{
    #region DataPointSources
    [DatapointSource]
    public static readonly CRLAsset[] CRLTestCases = new AssetCollection<CRLAsset>(TestUtils.EnumerateTestAssets("*.crl")).ToArray();

    [DatapointSource]
    public static readonly KeyHashPair[] KeyHashPairs = new KeyHashPairCollection {
            { 2048, HashAlgorithmName.SHA256 },
            { 3072, HashAlgorithmName.SHA384 },
            { 4096, HashAlgorithmName.SHA512 } }.ToArray();
    #endregion

    #region Test Setup
    /// <summary>
    /// Set up a Global Discovery Server and Client instance and connect the session
    /// </summary>
    [OneTimeSetUp]
    protected void OneTimeSetUp()
    {
        _issuerCert = CertificateBuilder.Create("CN=Root CA, O=CryptoHives")
            .SetCAConstraint()
            .CreateForRSA();
    }

    /// <summary>
    /// Clean up the Test cert.
    /// </summary>
    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        _issuerCert?.Dispose();
    }
    #endregion

    #region Test Methods
    /// <summary>
    /// Verify self signed app certs.
    /// </summary>
    [Theory]
    public void DecodeCRLs(
        CRLAsset crlAsset
        )
    {
        var x509Crl = new X509CRL(crlAsset.Crl);
        Assert.NotNull(x509Crl);
        TestContext.Out.WriteLine($"CRLAsset:   {x509Crl.Issuer}");
        var crlInfo = WriteCRL(x509Crl);
        TestContext.Out.WriteLine(crlInfo);
    }

    /// <summary>
    /// Validate a CRL Builder and decoder pass.
    /// </summary>
    [Test]
    public void CrlInternalBuilderTest()
    {
        var dname = new X500DistinguishedName("CN=Test, O=CryptoHives");
        var hash = HashAlgorithmName.SHA256;
        var crlBuilder = CrlBuilder.Create(dname, hash)
            .SetNextUpdate(DateTime.Today.AddDays(30).ToUniversalTime());
        byte[] serial = new byte[] { 4, 5, 6, 7 };
        var revokedarray = new RevokedCertificate(serial);
        crlBuilder.RevokedCertificates.Add(revokedarray);
        string serstring = "45678910";
        var revokedstring = new RevokedCertificate(serstring);
        crlBuilder.RevokedCertificates.Add(revokedstring);
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(123));
        var crlEncoded = crlBuilder.Encode();
        ValidateCRL(serial, serstring, hash, crlBuilder, crlEncoded);
    }

    /// <summary>
    /// Validate the full CRL encoder and decoder pass.
    /// </summary>
    [Theory]
    public void CrlBuilderTest(bool empty, bool noExtensions, KeyHashPair keyHashPair)
    {
        var crlBuilder = CrlBuilder.Create(_issuerCert.SubjectName, keyHashPair.HashAlgorithmName)
            .SetThisUpdate(DateTime.UtcNow.Date)
            .SetNextUpdate(DateTime.UtcNow.Date.AddDays(30));

        byte[] serial = new byte[] { 4, 5, 6, 7 };
        string serstring = "123456789101";
        if (!empty)
        {
            // little endian byte array as serial number?
            var revokedarray = new RevokedCertificate(serial) {
                RevocationDate = DateTime.UtcNow.AddDays(30)
            };
            crlBuilder.RevokedCertificates.Add(revokedarray);
            var revokedstring = new RevokedCertificate(serstring);
            crlBuilder.RevokedCertificates.Add(revokedstring);
        }

        if (!noExtensions)
        {
            crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(1111));
            crlBuilder.CrlExtensions.Add(X509Extensions.BuildAuthorityKeyIdentifier(_issuerCert));
        }

        var i509Crl = crlBuilder.CreateForRSA(_issuerCert);
        X509CRL x509Crl = new X509CRL(i509Crl.RawData);
        Assert.NotNull(x509Crl);
        Assert.NotNull(x509Crl.CrlExtensions);
        Assert.NotNull(x509Crl.RevokedCertificates);
        Assert.That(x509Crl.IssuerName.RawData, Is.EqualTo(_issuerCert.SubjectName.RawData));
        Assert.That(x509Crl.ThisUpdate, Is.EqualTo(crlBuilder.ThisUpdate));
        Assert.That(x509Crl.NextUpdate, Is.EqualTo(crlBuilder.NextUpdate));

        if (empty)
        {
            Assert.That(x509Crl.RevokedCertificates.Count, Is.EqualTo(0));
        }
        else
        {
            Assert.That(x509Crl.RevokedCertificates.Count, Is.EqualTo(2));
            Assert.That(x509Crl.RevokedCertificates[0].UserCertificate, Is.EqualTo(serial));
            Assert.That(x509Crl.RevokedCertificates[1].SerialNumber, Is.EqualTo(serstring));
        }

        if (noExtensions)
        {
            Assert.That(x509Crl.CrlExtensions.Count, Is.EqualTo(0));
        }
        else
        {
            Assert.That(x509Crl.CrlExtensions.Count, Is.EqualTo(2));
        }

        using var issuerPubKey = X509CertificateLoader.LoadCertificate(_issuerCert.RawData);
        Assert.True(x509Crl.VerifySignature(issuerPubKey, true));
    }

    /// <summary>
    /// Validate the full CRL encoder and decoder pass.
    /// </summary>
    [Theory]
    public void CrlBuilderTestWithSignatureGenerator(KeyHashPair keyHashPair)
    {
        var crlBuilder = CrlBuilder.Create(_issuerCert.SubjectName, keyHashPair.HashAlgorithmName)
            .SetThisUpdate(DateTime.UtcNow.Date)
            .SetNextUpdate(DateTime.UtcNow.Date.AddDays(30));

        // little endian byte array as serial number?
        byte[] serial = new byte[] { 4, 5, 6, 7 };
        var revokedarray = new RevokedCertificate(serial);
        crlBuilder.RevokedCertificates.Add(revokedarray);

        string serstring = "709876543210";
        var revokedstring = new RevokedCertificate(serstring);
        crlBuilder.RevokedCertificates.Add(revokedstring);

        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(1111));
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildAuthorityKeyIdentifier(_issuerCert));

        IX509CRL ix509Crl;
        using (RSA rsa = _issuerCert.GetRSAPrivateKey())
        {
            X509SignatureGenerator generator = X509SignatureGenerator.CreateForRSA(rsa, RSASignaturePadding.Pkcs1);
            ix509Crl = crlBuilder.CreateSignature(generator);
        }
        X509CRL x509Crl = new X509CRL(ix509Crl);
        Assert.NotNull(x509Crl);
        Assert.NotNull(x509Crl.CrlExtensions);
        Assert.NotNull(x509Crl.RevokedCertificates);
        Assert.That(x509Crl.IssuerName.RawData, Is.EqualTo(_issuerCert.SubjectName.RawData));
        Assert.That(x509Crl.ThisUpdate, Is.EqualTo(crlBuilder.ThisUpdate));
        Assert.That(x509Crl.NextUpdate, Is.EqualTo(crlBuilder.NextUpdate));
        Assert.That(x509Crl.RevokedCertificates.Count, Is.EqualTo(2));
        Assert.That(x509Crl.RevokedCertificates[0].UserCertificate, Is.EqualTo(serial));
        Assert.That(x509Crl.RevokedCertificates[1].SerialNumber, Is.EqualTo(serstring));
        Assert.That(x509Crl.CrlExtensions.Count, Is.EqualTo(2));
        using var issuerPubKey = X509CertificateLoader.LoadCertificate(_issuerCert.RawData);
        Assert.True(x509Crl.VerifySignature(issuerPubKey, true));
    }

    /// <summary>
    /// Validate a CRL Builder and decoder pass on using utc and generalized times.
    /// </summary>
    [Test]
    public void CrlUtcAndGeneralizedTimeTest()
    {
        // Generate a CRL with dates over 2050 
        var dname = new X500DistinguishedName("CN=Test, O=CryptoHives");
        var hash = HashAlgorithmName.SHA256;
        DateTime baseYear = new DateTime(2055, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var crlBuilder = CrlBuilder.Create(dname, hash)
            .SetThisUpdate(baseYear)
            .SetNextUpdate(baseYear.AddDays(100));
        byte[] serial = new byte[] { 4, 5, 6, 7 };
        var revokedarray = new RevokedCertificate(serial) {
            RevocationDate = baseYear.AddDays(1)
        };
        crlBuilder.RevokedCertificates.Add(revokedarray);
        string serstring = "45678910";
        var revokedstring = new RevokedCertificate(serstring) {
            RevocationDate = baseYear.AddDays(1)
        };
        crlBuilder.RevokedCertificates.Add(revokedstring);
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(123));
        var crlEncoded = crlBuilder.Encode();
        Assert.NotNull(crlEncoded);
        ValidateCRL(serial, serstring, hash, crlBuilder, crlEncoded);

        // Generate a CRL with dates up-to 2050
        baseYear = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        crlBuilder = CrlBuilder.Create(dname, hash)
            .SetThisUpdate(baseYear)
            .SetNextUpdate(baseYear.AddDays(100));
        revokedarray = new RevokedCertificate(serial);
        crlBuilder.RevokedCertificates.Add(revokedarray);
        revokedstring = new RevokedCertificate(serstring) {
            RevocationDate = baseYear.AddDays(20)
        };
        crlBuilder.RevokedCertificates.Add(revokedstring);
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(123));
        crlEncoded = crlBuilder.Encode();
        Assert.NotNull(crlEncoded);
        ValidateCRL(serial, serstring, hash, crlBuilder, crlEncoded);
    }
    #endregion

    #region Private Methods
    private string WriteCRL(X509CRL x509Crl)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Issuer:     ").AppendLine(x509Crl.Issuer);
        stringBuilder.Append("ThisUpdate: ").Append(x509Crl.ThisUpdate).AppendLine();
        stringBuilder.Append("NextUpdate: ").Append(x509Crl.NextUpdate).AppendLine();
        stringBuilder.AppendLine("RevokedCertificates:");
        foreach (var revokedCert in x509Crl.RevokedCertificates)
        {
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:20}", revokedCert.SerialNumber).Append(", ").Append(revokedCert.RevocationDate).Append(", ");
            foreach (var entryExt in revokedCert.CrlEntryExtensions)
            {
                stringBuilder.Append(entryExt.Format(false)).Append(' ');
            }
            stringBuilder.AppendLine("");
        }
        stringBuilder.AppendLine("Extensions:");
        foreach (var extension in x509Crl.CrlExtensions)
        {
            stringBuilder.AppendLine(extension.Format(false));
        }
        return stringBuilder.ToString();
    }

    private void ValidateCRL(
        byte[] serial,
        string serstring,
        HashAlgorithmName hash,
        CrlBuilder crlBuilder,
        byte[] crlEncoded)
    {
        Assert.NotNull(crlEncoded);
        var x509Crl = new X509CRL();
        x509Crl.DecodeCrl(crlEncoded);
        Assert.NotNull(x509Crl);
        Assert.NotNull(x509Crl.CrlExtensions);
        Assert.NotNull(x509Crl.RevokedCertificates);
        Assert.That(x509Crl.IssuerName.RawData, Is.EqualTo(crlBuilder.IssuerName.RawData));
        Assert.That(crlBuilder.ThisUpdate, Is.EqualTo(x509Crl.ThisUpdate).Within(TimeSpan.FromSeconds(1)));
        Assert.That(crlBuilder.NextUpdate, Is.EqualTo(x509Crl.NextUpdate).Within(TimeSpan.FromSeconds(1)));
        Assert.That(x509Crl.RevokedCertificates.Count, Is.EqualTo(2));
        Assert.That(x509Crl.RevokedCertificates[0].UserCertificate, Is.EqualTo(serial));
        Assert.That(x509Crl.RevokedCertificates[1].SerialNumber, Is.EqualTo(serstring));
        Assert.That(x509Crl.CrlExtensions.Count, Is.EqualTo(1));
        Assert.That(x509Crl.HashAlgorithmName, Is.EqualTo(hash));
    }
    #endregion

    #region Private Fields
    private X509Certificate2 _issuerCert;
    #endregion
}
