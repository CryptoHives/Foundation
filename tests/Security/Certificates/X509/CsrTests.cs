// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Certificates;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CsrTests
{
    // ========================================================================
    // RSA CSR
    // ========================================================================

    [Test]
    public void RsaCsrRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        var csr = new CsrBuilder()
            .SetSubject(X509Name.FromString("CN=rsa-csr.example.com, O=Test, C=US"))
            .SetPublicKey(key)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsage.DigitalSignature | KeyUsage.KeyEncipherment)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName((SanType.DnsName, "rsa-csr.example.com"))
            .BuildRsa(key);

        Assert.That(csr.Version, Is.EqualTo(1));
        Assert.That(csr.Subject.ToString(), Does.Contain("CN=rsa-csr.example.com"));
        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("RSA"));
        Assert.That(csr.VerifySignature(), Is.True);

        // Round-trip through DER
        var parsed = CsrParser.ParseDer(csr.RawDer);
        Assert.That(parsed.Version, Is.EqualTo(1));
        Assert.That(parsed.Subject.ToString(), Does.Contain("CN=rsa-csr.example.com"));
        Assert.That(parsed.VerifySignature(), Is.True);

        // Verify extensions
        Assert.That(parsed.Extensions.Count, Is.GreaterThanOrEqualTo(3));
        var sanExt = parsed.Extensions.GetExtension(X509ExtensionCollection.OidSubjectAlternativeName);
        Assert.That(sanExt, Is.Not.Null);
        var sans = ExtensionParsers.SubjectAlternativeName.Parse(sanExt!.Value);
        Assert.That(sans, Has.Count.EqualTo(1));
        Assert.That(sans[0].Value, Is.EqualTo("rsa-csr.example.com"));
    }

    // ========================================================================
    // RSA CSR Factory
    // ========================================================================

    [Test]
    public void RsaCsrFactory()
    {
        var csr = CsrBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=factory-rsa.example.com"))
            .AddSubjectAlternativeName((SanType.DnsName, "factory-rsa.example.com"))
            .Build();

        Assert.That(csr.Version, Is.EqualTo(1));
        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("RSA"));
        Assert.That(csr.VerifySignature(), Is.True);
    }

    // ========================================================================
    // ECDSA CSR
    // ========================================================================

    [Test]
    public void EcDsaCsrRoundTrip()
    {
        using var ecdsa = new EcDsaCipher("nistP256");
        byte[] d = ecdsa.ExportPrivateKey()!;
        var (qx, qy) = ecdsa.ExportPublicKey();

        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(qx, 0, pubPoint, 1, qx.Length);
        Buffer.BlockCopy(qy, 0, pubPoint, 1 + qx.Length, qy.Length);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", "1.2.840.10045.3.1.7", pubPoint);

        var csr = new CsrBuilder()
            .SetSubject(X509Name.FromString("CN=ec-csr.example.com, C=DE"))
            .SetPublicKey(spki)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidClientAuth)
            .BuildEcDsa(d, "nistP256");

        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(csr.VerifySignature(), Is.True);

        // PEM round-trip
        string pem = csr.ExportPem();
        Assert.That(pem, Does.Contain("-----BEGIN CERTIFICATE REQUEST-----"));
        var parsed = CsrParser.ParsePem(pem);
        Assert.That(parsed.Subject.ToString(), Does.Contain("CN=ec-csr.example.com"));
        Assert.That(parsed.VerifySignature(), Is.True);
    }

    // ========================================================================
    // ECDSA CSR Factory
    // ========================================================================

    [Test]
    public void EcDsaCsrFactory()
    {
        var csr = CsrBuilder.CreateForEcDsa("nistP256")
            .SetSubject(X509Name.FromString("CN=factory-ec.example.com"))
            .Build();

        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(csr.VerifySignature(), Is.True);
    }

    // ========================================================================
    // Ed25519 CSR
    // ========================================================================

    [Test]
    public void Ed25519CsrRoundTrip()
    {
        var csr = CsrBuilder.CreateForEd25519()
            .SetSubject(X509Name.FromString("CN=ed25519-csr.example.com"))
            .AddSubjectAlternativeName((SanType.DnsName, "ed25519-csr.example.com"))
            .Build();

        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("Ed25519"));
        Assert.That(csr.VerifySignature(), Is.True);

        // DER round-trip
        byte[] der = csr.ExportDer();
        var parsed = CsrParser.ParseDer(der);
        Assert.That(parsed.VerifySignature(), Is.True);
        Assert.That(parsed.Subject.ToString(), Does.Contain("CN=ed25519-csr.example.com"));
    }

    // ========================================================================
    // Ed448 CSR
    // ========================================================================

    [Test]
    public void Ed448CsrRoundTrip()
    {
        var csr = CsrBuilder.CreateForEd448()
            .SetSubject(X509Name.FromString("CN=ed448-csr.example.com"))
            .Build();

        Assert.That(csr.GetPublicKeyAlgorithm(), Is.EqualTo("Ed448"));
        Assert.That(csr.VerifySignature(), Is.True);

        string pem = csr.ExportPem();
        var parsed = CsrParser.ParsePem(pem);
        Assert.That(parsed.VerifySignature(), Is.True);
    }

    // ========================================================================
    // CSR with SAN Extension Request
    // ========================================================================

    [Test]
    public void CsrWithMultipleSanEntries()
    {
        var csr = CsrBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=multi-san.example.com"))
            .AddSubjectAlternativeName(
                (SanType.DnsName, "multi-san.example.com"),
                (SanType.DnsName, "www.multi-san.example.com"),
                (SanType.DnsName, "api.multi-san.example.com"))
            .Build();

        Assert.That(csr.VerifySignature(), Is.True);

        var sanExt = csr.Extensions.GetExtension(X509ExtensionCollection.OidSubjectAlternativeName);
        Assert.That(sanExt, Is.Not.Null);

        var sans = ExtensionParsers.SubjectAlternativeName.Parse(sanExt!.Value);
        Assert.That(sans, Has.Count.EqualTo(3));
        Assert.That(sans[0].Value, Is.EqualTo("multi-san.example.com"));
        Assert.That(sans[1].Value, Is.EqualTo("www.multi-san.example.com"));
        Assert.That(sans[2].Value, Is.EqualTo("api.multi-san.example.com"));
    }

    // ========================================================================
    // CSR No Extensions
    // ========================================================================

    [Test]
    public void CsrWithNoExtensions()
    {
        var csr = CsrBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=no-ext.example.com"))
            .Build();

        Assert.That(csr.VerifySignature(), Is.True);
        Assert.That(csr.Extensions.Count, Is.EqualTo(0));
    }

    // ========================================================================
    // CSR to Certificate (issue a cert from a CSR)
    // ========================================================================

    [Test]
    public void CsrToCertificateIssuance()
    {
        // Create a CA (two key copies because RsaCipher disposes key material)
        using var caRsa = RSA.Create(2048);
        var cp = caRsa.ExportParameters(true);
        using var caKeySelf = new RsaKeyParameters(
            cp.Modulus!, cp.Exponent!, cp.D!, cp.P!, cp.Q!, cp.DP!, cp.DQ!, cp.InverseQ!);
        var caName = X509Name.FromString("CN=Test CA, O=CryptoHives, C=US");
        var caCert = new X509CertificateBuilder()
            .SetSubject(caName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(caKeySelf)
            .AddBasicConstraints(true, 1)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSelfSigned(caKeySelf);

        // Create a CSR
        var csr = CsrBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=issued.example.com"))
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName((SanType.DnsName, "issued.example.com"))
            .Build();

        Assert.That(csr.VerifySignature(), Is.True);

        // Issue a certificate from the CSR (re-export to get fresh byte arrays)
        var cp2 = caRsa.ExportParameters(true);
        using var caKeySign = new RsaKeyParameters(
            cp2.Modulus!, cp2.Exponent!, cp2.D!, cp2.P!, cp2.Q!, cp2.DP!, cp2.DQ!, cp2.InverseQ!);
        var leafCert = new X509CertificateBuilder()
            .SetSubject(csr.Subject)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(csr.SubjectPublicKeyInfoDer)
            .AddBasicConstraints(false)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName((SanType.DnsName, "issued.example.com"))
            .BuildSignedRsa(caKeySign, caName);

        Assert.That(leafCert.IsSelfSigned, Is.False);
        Assert.That(leafCert.Subject.ToString(), Does.Contain("CN=issued.example.com"));
        Assert.That(leafCert.Issuer.ToString(), Does.Contain("CN=Test CA"));
        Assert.That(X509CertificateValidator.VerifySignature(leafCert, caCert), Is.True);
    }
}
