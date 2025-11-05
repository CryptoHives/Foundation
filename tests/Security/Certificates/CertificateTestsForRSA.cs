// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CryptoHives.Security.Certificates;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

/// <summary>
/// Tests for the CertificateBuilder class.
/// </summary>
[TestFixture, Category("Certificate"), Category("RSA")]
[Parallelizable]
[SetCulture("en-us")]
public class CertificateTestsForRSA
{
    #region DataPointSources
    public const string Subject = "CN=Test Cert Subject, C=US, S=Florida, O=CryptoHives";

    [DatapointSource]
    public static readonly CertificateAsset[] CertificateTestCases = new AssetCollection<CertificateAsset>(TestUtils.EnumerateTestAssets("*.?er")).ToArray();

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
    }

    /// <summary>
    /// Clean up the Test PKI folder
    /// </summary>
    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
    }
    #endregion

    #region Test Methods
    /// <summary>
    /// Verify self signed app certs. Use one builder to create multiple certs.
    /// </summary>
    [Test]
    public void VerifyOneSelfSignedAppCertForAll()
    {
        var builder = CertificateBuilder.Create(Subject)
                        .SetNotBefore(DateTime.Today.AddYears(-1))
                        .SetNotAfter(DateTime.Today.AddYears(25))
                        .AddExtension(new X509SubjectAltNameExtension("urn:cryptohives.org:mypc",
                            new string[] { "mypc", "mypc.cryptohives.org", "192.168.1.100" }));
        byte[] previousSerialNumber = null;
        foreach (var keyHash in KeyHashPairs)
        {
            using var cert = builder
                .SetHashAlgorithm(keyHash.HashAlgorithmName)
                .SetRSAKeySize(keyHash.KeySize)
                .CreateForRSA();
            Assert.NotNull(cert);
            WriteCertificate(cert, $"Default cert with RSA {keyHash.KeySize} {keyHash.HashAlgorithmName} signature.");
            Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(keyHash.HashAlgorithmName));
            // ensure serial numbers are different
            Assert.That(cert.GetSerialNumber(), Is.Not.EqualTo(previousSerialNumber));
            X509PfxUtils.VerifyRSAKeyPair(cert, cert, true);
            Assert.True(X509Utils.VerifySelfSigned(cert));
            Assert.That(cert.IssuerName.Name, Is.EqualTo(cert.SubjectName.Name));
            Assert.That(cert.IssuerName.RawData, Is.EqualTo(cert.SubjectName.RawData));
            CheckPEMWriter(cert);
        }
    }

    /// <summary>
    /// Create the default RSA certificate.
    /// </summary>
    [Test]
    public void CreateSelfSignedForRSADefaultTest()
    {
        // default cert
        using X509Certificate2 cert = CertificateBuilder.Create(Subject).CreateForRSA();
        Assert.NotNull(cert);
        WriteCertificate(cert, "Default RSA cert");
        using (var privateKey = cert.GetRSAPrivateKey())
        {
            Assert.NotNull(privateKey);
            privateKey.ExportParameters(false);
            privateKey.ExportParameters(true);
        }
        using (var publicKey = cert.GetRSAPublicKey())
        {
            Assert.NotNull(publicKey);
            Assert.That(publicKey.KeySize, Is.EqualTo(X509Defaults.RSAKeySize));
            publicKey.ExportParameters(false);
        }
        Assert.That(cert.IssuerName.Name, Is.EqualTo(cert.SubjectName.Name));
        Assert.That(cert.IssuerName.RawData, Is.EqualTo(cert.SubjectName.RawData));
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(X509Defaults.HashAlgorithmName));
        Assert.GreaterOrEqual(DateTime.UtcNow, cert.NotBefore);
        Assert.GreaterOrEqual(DateTime.UtcNow.AddMonths(X509Defaults.LifeTime), cert.NotAfter.ToUniversalTime());
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        X509Utils.VerifyRSAKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
    }

    [Theory]
    public void CreateSelfSignedForRSADefaultHashCustomKey(
        KeyHashPair keyHashPair,
        bool signOnly
        )
    {
        // default cert with custom key
        var builder = CertificateBuilder.Create(Subject);

        if (signOnly)
        {
            // Key usage for sign only
            X509KeyUsageFlags keyUsageFlags = X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.NonRepudiation;
            builder.AddExtension(new X509KeyUsageExtension(keyUsageFlags, true));
        }

        using X509Certificate2 cert = builder.SetRSAKeySize(keyHashPair.KeySize).CreateForRSA();
        WriteCertificate(cert, $"Default RSA {keyHashPair.KeySize} cert");

        X509Utils.VerifyRSAKeyPair(cert, cert, true);
        Assert.That(cert.Subject, Is.EqualTo(Subject));
        Assert.That(cert.GetRSAPublicKey().KeySize, Is.EqualTo(keyHashPair.KeySize));
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(X509Defaults.HashAlgorithmName));
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        Assert.That(cert.IssuerName.Name, Is.EqualTo(cert.SubjectName.Name));
        Assert.That(cert.IssuerName.RawData, Is.EqualTo(cert.SubjectName.RawData));
        Assert.True(X509Utils.VerifySelfSigned(cert));
    }

    [Theory]
    public void CreateSelfSignedForRSACustomHashDefaultKey(
        KeyHashPair keyHashPair
        )
    {
        // default cert with custom HashAlgorithm
        var cert = CertificateBuilder.Create(Subject)
            .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
            .CreateForRSA();
        Assert.NotNull(cert);
        WriteCertificate(cert, $"Default RSA {keyHashPair.HashAlgorithmName} cert");
        Assert.That(cert.Subject, Is.EqualTo(Subject));
        Assert.That(cert.GetRSAPublicKey().KeySize, Is.EqualTo(X509Defaults.RSAKeySize));
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(keyHashPair.HashAlgorithmName));
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        X509Utils.VerifyRSAKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
    }

    [Theory]
    public void CreateSelfSignedForRSAAllFields(
        KeyHashPair keyHashPair
        )
    {
        // set dates and extension
        var applicationUri = "urn:cryptohives.org:mypc";
        var domains = new string[] { "mypc", "mypc.cryptohives.org", "192.168.1.100" };
        var cert = CertificateBuilder.Create(Subject)
            .SetNotBefore(DateTime.Today.AddYears(-1))
            .SetNotAfter(DateTime.Today.AddYears(25))
            .AddExtension(new X509SubjectAltNameExtension(applicationUri, domains))
            .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
            .SetRSAKeySize(keyHashPair.KeySize)
            .CreateForRSA();
        Assert.NotNull(cert);
        WriteCertificate(cert, $"Default cert RSA {keyHashPair.KeySize} with modified lifetime and alt name extension");
        Assert.That(cert.Subject, Is.EqualTo(Subject));
        using (var privateKey = cert.GetRSAPrivateKey())
        {
            Assert.NotNull(privateKey);
            privateKey.ExportParameters(false);
            privateKey.ExportParameters(true);
        }
        using (var publicKey = cert.GetRSAPublicKey())
        {
            Assert.NotNull(publicKey);
            publicKey.ExportParameters(false);
        }
        Assert.That(cert.GetRSAPublicKey().KeySize, Is.EqualTo(keyHashPair.KeySize));
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(keyHashPair.HashAlgorithmName));
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        X509Utils.VerifyRSAKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
        CheckPEMWriter(cert);
    }

    [Theory]
    public void CreateCACertForRSA(
        KeyHashPair keyHashPair
        )
    {
        // create a CA cert
        using var cert = CertificateBuilder.Create(Subject)
            .SetCAConstraint(-1)
            .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
            .AddExtension(X509Extensions.BuildX509CRLDistributionPoints("http://myca/mycert.crl"))
            .SetRSAKeySize(keyHashPair.KeySize)
            .CreateForRSA();
        Assert.NotNull(cert);
        WriteCertificate(cert, "Default cert with RSA {keyHashPair.KeySize} {keyHashPair.HashAlgorithmName} and CRL distribution points");
        Assert.That(cert.GetRSAPublicKey().KeySize, Is.EqualTo(keyHashPair.KeySize));
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(keyHashPair.HashAlgorithmName));
        var basicConstraintsExtension = X509Extensions.FindExtension<X509BasicConstraintsExtension>(cert.Extensions);
        Assert.NotNull(basicConstraintsExtension);
        Assert.True(basicConstraintsExtension.CertificateAuthority);
        Assert.False(basicConstraintsExtension.HasPathLengthConstraint);
        X509Utils.VerifyRSAKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
        CheckPEMWriter(cert);
    }

    [Test]
    public void CreateRSADefaultWithSerialTest()
    {
        // default cert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumberLength(0)
                .CreateForRSA();
            }
        );
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumberLength(X509Defaults.SerialNumberLengthMax + 1)
                .CreateForRSA();
            }
        );
        var builder = CertificateBuilder.Create(Subject)
            .SetSerialNumberLength(X509Defaults.SerialNumberLengthMax);

        // ensure every cert has a different serial number
        var cert1 = builder.CreateForRSA();
        var cert2 = builder.CreateForRSA();
        WriteCertificate(cert1, "Cert1 with max length serial number");
        WriteCertificate(cert2, "Cert2 with max length serial number");
        Assert.GreaterOrEqual(X509Defaults.SerialNumberLengthMax, cert1.GetSerialNumber().Length);
        Assert.GreaterOrEqual(X509Defaults.SerialNumberLengthMax, cert2.GetSerialNumber().Length);
        Assert.That(cert2.SerialNumber, Is.Not.EqualTo(cert1.SerialNumber));
    }

    [Test]
    public void CreateRSAManualSerialTest()
    {
        // default cert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumber(Array.Empty<byte>())
                .CreateForRSA();
            }
        );
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumber(new byte[X509Defaults.SerialNumberLengthMax + 1])
                .CreateForRSA();
            }
        );
        var serial = new byte[X509Defaults.SerialNumberLengthMax];
        for (int i = 0; i < serial.Length; i++)
        {
            serial[i] = (byte)((i + 1) | 0x80);
        }

        // test if sign bit is cleared
        var builder = CertificateBuilder.Create(Subject)
            .SetSerialNumber(serial);
        serial[^1] &= 0x7f;
        Assert.That(builder.GetSerialNumber(), Is.EqualTo(serial));
        var cert1 = builder.CreateForRSA();
        WriteCertificate(cert1, "Cert1 with max length serial number");
        TestContext.Out.WriteLine($"Serial: {serial.ToHexString(true)}");
        Assert.That(cert1.GetSerialNumber(), Is.EqualTo(serial));
        Assert.That(cert1.GetSerialNumber().Length, Is.EqualTo(X509Defaults.SerialNumberLengthMax));

        // clear sign bit
        builder.SetSerialNumberLength(X509Defaults.SerialNumberLengthMax);

        var cert2 = builder.CreateForRSA();
        WriteCertificate(cert2, "Cert2 with max length serial number");
        TestContext.Out.WriteLine($"Serial: {cert2.SerialNumber}");
        Assert.GreaterOrEqual(X509Defaults.SerialNumberLengthMax, cert2.GetSerialNumber().Length);
        Assert.That(cert2.SerialNumber, Is.Not.EqualTo(cert1.SerialNumber));
    }

    [Test]
    public void CreateIssuerRSAWithSuppliedKeyPair()
    {
        X509Certificate2 issuer = null;
        using RSA rsaKeyPair = RSA.Create();
        // create cert with supplied keys
        var generator = X509SignatureGenerator.CreateForRSA(rsaKeyPair, RSASignaturePadding.Pkcs1);
        using (var cert = CertificateBuilder.Create("CN=Root Cert")
            .SetCAConstraint(-1)
            .SetRSAPublicKey(rsaKeyPair)
            .CreateForRSA(generator))
        {
            Assert.NotNull(cert);
            issuer = X509CertificateLoader.LoadCertificate(cert.RawData);
            WriteCertificate(cert, "Default root cert with supplied RSA cert");
            CheckPEMWriter(cert);
        }

        // now sign a cert with supplied private key
        using var appCert = CertificateBuilder.Create("CN=App Cert")
            .SetIssuer(issuer)
            .CreateForRSA(generator);
        Assert.NotNull(appCert);
        WriteCertificate(appCert, "Signed RSA app cert");
        CheckPEMWriter(appCert);
    }

#if NETFRAMEWORK || NETCOREAPP3_1_OR_GREATER
    [Test]
    [SuppressMessage("Interoperability", "CA1416: Validate platform compatibility", Justification = "Test is ignored.")]
    public void CreateIssuerRSACngWithSuppliedKeyPair()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Assert.Ignore("Cng provider only available on windows");
        }
        X509Certificate2 issuer = null;
        CngKey cngKey = CngKey.Create(CngAlgorithm.Rsa);
        using RSA rsaKeyPair = new RSACng(cngKey);
        // create cert with supplied keys
        var generator = X509SignatureGenerator.CreateForRSA(rsaKeyPair, RSASignaturePadding.Pkcs1);
        using (var cert = CertificateBuilder.Create("CN=Root Cert")
            .SetCAConstraint(-1)
            .SetRSAPublicKey(rsaKeyPair)
            .CreateForRSA(generator))
        {
            Assert.NotNull(cert);
            issuer = X509CertificateLoader.LoadCertificate(cert.RawData);
            WriteCertificate(cert, "Default root cert with supplied RSA cert");
            CheckPEMWriter(cert);
        }

        // now sign a cert with supplied private key
        using var appCert = CertificateBuilder.Create("CN=App Cert")
            .SetIssuer(issuer)
            .CreateForRSA(generator);
        Assert.NotNull(appCert);
        Assert.That(appCert.IssuerName.Name, Is.EqualTo(issuer.SubjectName.Name));
        Assert.That(appCert.IssuerName.RawData, Is.EqualTo(issuer.SubjectName.RawData));
        WriteCertificate(appCert, "Signed RSA app cert");
        CheckPEMWriter(appCert);
    }
#endif

    [Theory]
    public void CreateForRSAWithGeneratorTest(
        KeyHashPair keyHashPair
        )
    {
        // default signing cert with custom key
        using X509Certificate2 signingCert = CertificateBuilder.Create(Subject)
            .SetCAConstraint()
            .SetHashAlgorithm(HashAlgorithmName.SHA512)
            .SetRSAKeySize(2048)
            .CreateForRSA();
        WriteCertificate(signingCert, $"Signing RSA {signingCert.GetRSAPublicKey().KeySize} cert");

        using (RSA rsaPrivateKey = signingCert.GetRSAPrivateKey())
        {
            var generator = X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1);
            using var issuer = X509CertificateLoader.LoadCertificate(signingCert.RawData);
            using var cert = CertificateBuilder.Create("CN=App Cert")
                .SetIssuer(issuer)
                .CreateForRSA(generator);
            Assert.NotNull(cert);
            Assert.That(cert.IssuerName.Name, Is.EqualTo(issuer.SubjectName.Name));
            Assert.That(cert.IssuerName.RawData, Is.EqualTo(issuer.SubjectName.RawData));
            WriteCertificate(cert, "Default signed RSA cert");
            CheckPEMWriter(cert);
        }

        using (RSA rsaPrivateKey = signingCert.GetRSAPrivateKey())
        using (RSA rsaPublicKey = signingCert.GetRSAPublicKey())
        {
            var generator = X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1);
            using var issuer = X509CertificateLoader.LoadCertificate(signingCert.RawData);
            using var cert = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
                .SetIssuer(issuer)
                .SetRSAPublicKey(rsaPublicKey)
                .CreateForRSA(generator);
            Assert.NotNull(cert);
            WriteCertificate(cert, "Default signed RSA cert with Public Key");
        }

        using (RSA rsaPrivateKey = signingCert.GetRSAPrivateKey())
        {
            var generator = X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1);
            using var issuer = X509CertificateLoader.LoadCertificate(signingCert.RawData);
            using var cert = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
                .SetIssuer(issuer)
                .SetRSAKeySize(keyHashPair.KeySize)
                .CreateForRSA(generator);
            Assert.NotNull(cert);
            WriteCertificate(cert, "Default signed RSA cert");
            Assert.That(cert.IssuerName.Name, Is.EqualTo(issuer.SubjectName.Name));
            Assert.That(cert.IssuerName.RawData, Is.EqualTo(issuer.SubjectName.RawData));
            CheckPEMWriter(cert);
        }

        // ensure invalid path throws argument exception
        Assert.Throws<NotSupportedException>(() => {
            using RSA rsaPrivateKey = signingCert.GetRSAPrivateKey();
            var generator = X509SignatureGenerator.CreateForRSA(rsaPrivateKey, RSASignaturePadding.Pkcs1);
            _ = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(keyHashPair.HashAlgorithmName)
                .SetRSAKeySize(keyHashPair.KeySize)
                .CreateForRSA(generator);
        });

        CheckPEMWriter(signingCert, password: "123");
    }
    #endregion

    #region Private Methods
    private void WriteCertificate(X509Certificate2 cert, string message)
    {
        TestContext.Out.WriteLine(message);
        TestContext.Out.WriteLine(cert);
        foreach (var ext in cert.Extensions)
        {
            TestContext.Out.WriteLine(ext.Format(false));
        }
    }

    private void CheckPEMWriter(X509Certificate2 certificate, string password = null)
    {
        PEMWriter.ExportCertificateAsPEM(certificate);
        if (certificate.HasPrivateKey)
        {
#if NETFRAMEWORK || NETCOREAPP2_1 || !ECC_SUPPORT
                // The implementation based on bouncy castle has no support to export with password
                password = null;
#endif
            PEMWriter.ExportPrivateKeyAsPEM(certificate, password);
#if NETCOREAPP3_1_OR_GREATER && ECC_SUPPORT
            PEMWriter.ExportRSAPrivateKeyAsPEM(certificate);
#endif
        }
    }
    #endregion

    #region Private Fields
    #endregion
}

