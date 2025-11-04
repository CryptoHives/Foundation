// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.Tests;

#if ECC_SUPPORT
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CryptoHives.Security.Certificates;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

/// <summary>
/// Tests for the CertificateBuilder class.
/// </summary>
[TestFixture, Category("Certificate"), Category("ECDsa")]
[Parallelizable]
[SetCulture("en-us")]
public class CertificateTestsForECDsa
{
    #region DataPointSources
    public const string Subject = "CN=Test Cert Subject, O=CryptoHives";

    [DatapointSource]
    public static readonly CertificateAsset[] CertificateTestCases =
        new AssetCollection<CertificateAsset>(TestUtils.EnumerateTestAssets("*.?er")).ToArray();

    [DatapointSource]
    public static readonly ECCurveHashPair[] ECCurveHashPairs = GetECCurveHashPairs();
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
        ICertificateBuilder builder = CertificateBuilder.Create(Subject)
            .SetNotBefore(DateTime.Today.AddYears(-1))
            .SetNotAfter(DateTime.Today.AddYears(25))
            .AddExtension(new X509SubjectAltNameExtension("urn:cryptohives.org:mypc", new string[] { "mypc", "mypc.cryptohives.org", "192.168.1.100" }));
        byte[] previousSerialNumber = null;
        foreach (ECCurveHashPair eCCurveHash in ECCurveHashPairs)
        {
            if (!eCCurveHash.Curve.IsNamed) continue;
            using X509Certificate2 cert = builder
                .SetHashAlgorithm(eCCurveHash.HashAlgorithmName)
                .SetECCurve(eCCurveHash.Curve)
                .CreateForECDsa();

            Assert.NotNull(cert);
            WriteCertificate(cert, $"Default cert with ECDsa {eCCurveHash.Curve.Oid.FriendlyName} {eCCurveHash.HashAlgorithmName} signature.");
            Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(eCCurveHash.HashAlgorithmName));
            // ensure serial numbers are different
            Assert.That(cert.GetSerialNumber(), Is.Not.EqualTo(previousSerialNumber));
            X509PfxUtils.VerifyECDsaKeyPair(cert, cert, true);
            Assert.True(X509Utils.VerifySelfSigned(cert));
            CheckPEMWriter(cert);
        }
    }

    /// <summary>
    /// Create the default ECDsa certificate.
    /// </summary>
    [Theory, Repeat(10)]
    public void CreateSelfSignedForECDsaDefaultTest(ECCurveHashPair eccurveHashPair)
    {
        // default cert
        X509Certificate2 cert = CertificateBuilder.Create(Subject)
            .SetECCurve(eccurveHashPair.Curve)
            .CreateForECDsa();
        Assert.NotNull(cert);
        WriteCertificate(cert, "Default ECDsa cert");
        using (ECDsa privateKey = cert.GetECDsaPrivateKey())
        {
            Assert.NotNull(privateKey);
            privateKey.ExportParameters(false);
            privateKey.ExportParameters(true);
        }
        using (ECDsa publicKey = cert.GetECDsaPublicKey())
        {
            Assert.NotNull(publicKey);
            publicKey.ExportParameters(false);
        }
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(X509Defaults.HashAlgorithmName));
        Assert.GreaterOrEqual(DateTime.UtcNow, cert.NotBefore);
        Assert.GreaterOrEqual(DateTime.UtcNow.AddMonths(X509Defaults.LifeTime), cert.NotAfter.ToUniversalTime());
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        X509KeyUsageExtension keyUsage = X509Extensions.FindExtension<X509KeyUsageExtension>(cert.Extensions);
        Assert.NotNull(keyUsage);
        X509PfxUtils.VerifyECDsaKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert), "Verify self signed.");
        CheckPEMWriter(cert);
    }

    [Theory, Repeat(10)]
    public void CreateSelfSignedForECDsaAllFields(
        ECCurveHashPair ecCurveHashPair
        )
    {
        // set dates and extension
        string applicationUri = "urn:cryptohives.org:mypc";
        string[] domains = new string[] { "mypc", "mypc.cryptohives.org", "192.168.1.100" };
        X509Certificate2 cert = CertificateBuilder.Create(Subject)
            .SetNotBefore(DateTime.Today.AddYears(-1))
            .SetNotAfter(DateTime.Today.AddYears(25))
            .AddExtension(new X509SubjectAltNameExtension(applicationUri, domains))
            .SetHashAlgorithm(ecCurveHashPair.HashAlgorithmName)
            .SetECCurve(ecCurveHashPair.Curve)
            .CreateForECDsa();
        Assert.NotNull(cert);
        WriteCertificate(cert, $"Default cert ECDsa {ecCurveHashPair.Curve.Oid.FriendlyName} with modified lifetime and alt name extension");
        Assert.That(cert.Subject, Is.EqualTo(Subject));
        using (ECDsa privateKey = cert.GetECDsaPrivateKey())
        {
            Assert.NotNull(privateKey);
            privateKey.ExportParameters(false);
            privateKey.ExportParameters(true);
        }
        using (ECDsa publicKey = cert.GetECDsaPublicKey())
        {
            Assert.NotNull(publicKey);
            publicKey.ExportParameters(false);
        }
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(ecCurveHashPair.HashAlgorithmName));
        TestUtils.ValidateSelSignedBasicConstraints(cert);
        X509PfxUtils.VerifyECDsaKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
        CheckPEMWriter(cert);
    }

    [Theory, Repeat(10)]
    public void CreateCACertForECDsa(
        ECCurveHashPair ecCurveHashPair
        )
    {
        // create a CA cert
        X509Certificate2 cert = CertificateBuilder.Create(Subject)
            .SetCAConstraint()
            .SetHashAlgorithm(ecCurveHashPair.HashAlgorithmName)
            .AddExtension(X509Extensions.BuildX509CRLDistributionPoints(new string[] { "http://myca/mycert.crl", "http://myaltca/mycert.crl" }))
            .SetECCurve(ecCurveHashPair.Curve)
            .CreateForECDsa();
        Assert.NotNull(cert);
        WriteCertificate(cert, "Default cert with RSA {keyHashPair.KeySize} {keyHashPair.HashAlgorithmName} and CRL distribution points");
        Assert.That(Oids.GetHashAlgorithmName(cert.SignatureAlgorithm.Value), Is.EqualTo(ecCurveHashPair.HashAlgorithmName));
        X509BasicConstraintsExtension basicConstraintsExtension = X509Extensions.FindExtension<X509BasicConstraintsExtension>(cert.Extensions);
        Assert.NotNull(basicConstraintsExtension);
        Assert.True(basicConstraintsExtension.CertificateAuthority);
        Assert.False(basicConstraintsExtension.HasPathLengthConstraint);
        X509PfxUtils.VerifyECDsaKeyPair(cert, cert, true);
        Assert.True(X509Utils.VerifySelfSigned(cert));
        CheckPEMWriter(cert);
    }

    [Test]
    public void CreateECDsaDefaultWithSerialTest()
    {
        ECCurve eccurve = ECCurve.NamedCurves.nistP256;
        // default cert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumberLength(0)
                .SetECCurve(eccurve)
                .CreateForECDsa();
            }
        );
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumberLength(X509Defaults.SerialNumberLengthMax + 1)
                .SetECCurve(eccurve)
                .CreateForECDsa();
            }
        );
        ICertificateBuilderCreateForECDsaAny builder = CertificateBuilder.Create(Subject)
            .SetSerialNumberLength(X509Defaults.SerialNumberLengthMax)
            .SetECCurve(eccurve);

        // ensure every cert has a different serial number
        X509Certificate2 cert1 = builder.CreateForECDsa();
        X509Certificate2 cert2 = builder.CreateForECDsa();
        WriteCertificate(cert1, "Cert1 with max length serial number");
        WriteCertificate(cert2, "Cert2 with max length serial number");
        Assert.GreaterOrEqual(X509Defaults.SerialNumberLengthMax, cert1.GetSerialNumber().Length);
        Assert.GreaterOrEqual(X509Defaults.SerialNumberLengthMax, cert2.GetSerialNumber().Length);
        Assert.That(cert2.SerialNumber, Is.Not.EqualTo(cert1.SerialNumber));
    }

    [Test]
    public void CreateECDsaManualSerialTest()
    {
        ECCurve eccurve = ECCurve.NamedCurves.nistP256;
        // default cert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumber(Array.Empty<byte>())
                .SetECCurve(eccurve)
                .CreateForECDsa();
            }
        );
        Assert.Throws<ArgumentOutOfRangeException>(
            () => {
                CertificateBuilder.Create(Subject)
                .SetSerialNumber(new byte[X509Defaults.SerialNumberLengthMax + 1])
                .SetECCurve(eccurve)
                .CreateForECDsa();
            }
        );
        byte[] serial = new byte[X509Defaults.SerialNumberLengthMax];
        for (int i = 0; i < serial.Length; i++)
        {
            serial[i] = (byte)((i + 1) | 0x80);
        }

        // test if sign bit is cleared
        ICertificateBuilder builder = CertificateBuilder.Create(Subject)
            .SetSerialNumber(serial);

        serial[^1] &= 0x7f;
        Assert.That(builder.GetSerialNumber(), Is.EqualTo(serial));
        X509Certificate2 cert1 = builder.SetECCurve(eccurve).CreateForECDsa();
        WriteCertificate(cert1, "Cert1 with max length serial number");
        TestContext.Out.WriteLine($"Serial: {serial.ToHexString(true)}");
        Assert.That(cert1.GetSerialNumber(), Is.EqualTo(serial));
        Assert.That(cert1.GetSerialNumber(), Has.Length.EqualTo(X509Defaults.SerialNumberLengthMax));

        // clear sign bit
        builder.SetSerialNumberLength(X509Defaults.SerialNumberLengthMax);

        X509Certificate2 cert2 = builder.SetECCurve(eccurve).CreateForECDsa();
        WriteCertificate(cert2, "Cert2 with max length serial number");
        TestContext.Out.WriteLine($"Serial: {cert2.SerialNumber}");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(X509Defaults.SerialNumberLengthMax, Is.GreaterThanOrEqualTo(cert2.GetSerialNumber().Length));
            Assert.That(cert2.SerialNumber, Is.Not.EqualTo(cert1.SerialNumber));
        }
    }

    [Theory]
    public void CreateForECDsaWithGeneratorTest(
        ECCurveHashPair ecCurveHashPair
        )
    {
        // default signing cert with custom key
        X509Certificate2 signingCert = CertificateBuilder.Create(Subject)
            .SetCAConstraint()
            .SetHashAlgorithm(HashAlgorithmName.SHA512)
            .SetECCurve(ecCurveHashPair.Curve)
            .CreateForECDsa();

        WriteCertificate(signingCert, $"Signing ECDsa {signingCert.GetECDsaPublicKey().KeySize} cert");

        using (ECDsa ecdsaPrivateKey = signingCert.GetECDsaPrivateKey())
        {
            var generator = X509SignatureGenerator.CreateForECDsa(ecdsaPrivateKey);
            X509Certificate2 cert = CertificateBuilder.Create("CN=App Cert")
                .SetIssuer(X509CertificateLoader.LoadCertificate(signingCert.RawData))
                .CreateForRSA(generator);
            Assert.That(cert, Is.Not.Null);
            WriteCertificate(cert, "Default signed ECDsa cert");
        }

        using (ECDsa ecdsaPrivateKey = signingCert.GetECDsaPrivateKey())
        using (ECDsa ecdsaPublicKey = signingCert.GetECDsaPublicKey())
        {
            var generator = X509SignatureGenerator.CreateForECDsa(ecdsaPrivateKey);
            X509Certificate2 cert = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(ecCurveHashPair.HashAlgorithmName)
                .SetIssuer(X509CertificateLoader.LoadCertificate(signingCert.RawData))
                .SetECDsaPublicKey(ecdsaPublicKey)
                .CreateForECDsa(generator);
            Assert.That(cert, Is.Not.Null);
            WriteCertificate(cert, "Default signed ECDsa cert with Public Key");
        }

        using (ECDsa ecdsaPrivateKey = signingCert.GetECDsaPrivateKey())
        {
            var generator = X509SignatureGenerator.CreateForECDsa(ecdsaPrivateKey);
            X509Certificate2 cert = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(ecCurveHashPair.HashAlgorithmName)
                .SetIssuer(X509CertificateLoader.LoadCertificate(signingCert.RawData))
                .SetECCurve(ecCurveHashPair.Curve)
                .CreateForECDsa(generator);
            Assert.That(cert, Is.Not.Null);
            WriteCertificate(cert, "Default signed RSA cert");
            CheckPEMWriter(cert);
        }

        // ensure invalid path throws argument exception
        Assert.Throws<NotSupportedException>(() => {
            using ECDsa ecdsaPrivateKey = signingCert.GetECDsaPrivateKey();
            var generator = X509SignatureGenerator.CreateForECDsa(ecdsaPrivateKey);
            X509Certificate2 cert = CertificateBuilder.Create("CN=App Cert")
                .SetHashAlgorithm(ecCurveHashPair.HashAlgorithmName)
                .SetECCurve(ecCurveHashPair.Curve)
                .CreateForECDsa(generator);
        });
    }
    #endregion

    #region Private Methods
    private static ECCurveHashPair[] GetECCurveHashPairs()
    {
        var result = new ECCurveHashPairCollection {
                { ECCurve.NamedCurves.nistP256, HashAlgorithmName.SHA256 },
                { ECCurve.NamedCurves.nistP384, HashAlgorithmName.SHA384 },
                { ECCurve.NamedCurves.brainpoolP256r1, HashAlgorithmName.SHA256 },
                { ECCurve.NamedCurves.brainpoolP384r1, HashAlgorithmName.SHA384 }
            };

        int i = 0;
        while (i < result.Count)
        {
            ECDsa key = null;

            // test if curve is supported
            try
            {
                // For CBL Linux 2.0 and macOS test if key can be created
                using (key = ECDsa.Create(result[i].Curve))
                {
                }

                // for Azure Linux 3.0 test if cert can be created
                using X509Certificate2 cert = CertificateBuilder.Create(Subject)
                    .SetHashAlgorithm(result[i].HashAlgorithmName)
                    .SetECCurve(result[i].Curve)
                    .CreateForECDsa();
            }
            catch
            {
                result.RemoveAt(i);
                continue;
            }
            finally
            {
                key?.Dispose();
            }
            i++;
        }

        return result.ToArray();
    }

    private void WriteCertificate(X509Certificate2 cert, string message)
    {
        TestContext.Out.WriteLine(message);
        TestContext.Out.WriteLine(cert);
        foreach (X509Extension ext in cert.Extensions)
        {
            TestContext.Out.WriteLine(ext.Format(false));
        }
    }

    private void CheckPEMWriter(X509Certificate2 certificate, string password = null)
    {
        PEMWriter.ExportCertificateAsPEM(certificate);
        if (certificate.HasPrivateKey)
        {
#if !NETFRAMEWORK
            PEMWriter.ExportPrivateKeyAsPEM(certificate, password);
            PEMWriter.ExportECDsaPrivateKeyAsPEM(certificate);
#endif
        }
    }
    #endregion

    #region Private Fields
    #endregion
}
#endif


