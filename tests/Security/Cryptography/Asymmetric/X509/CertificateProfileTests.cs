// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CertificateProfileTests
{
    // ========================================================================
    // TLS Server
    // ========================================================================

    [Test]
    public void TlsServerProfileRsa()
    {
        var cert = CertificateProfiles.CreateTlsServerForRSA(
                "CN=tls.example.com, O=Test, C=US",
                ["tls.example.com", "www.tls.example.com"])
            .BuildSelfSigned();

        Assert.That(cert.Subject.ToString(), Does.Contain("CN=tls.example.com"));

        var bc = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
        Assert.That(bc, Is.Not.Null);
        var (isCA, _) = ExtensionParsers.BasicConstraints.Parse(bc!.Value);
        Assert.That(isCA, Is.False);

        var eku = cert.Extensions.GetExtension(X509ExtensionCollection.OidExtendedKeyUsage);
        Assert.That(eku, Is.Not.Null);
        var ekuOids = ExtensionParsers.ExtendedKeyUsage.Parse(eku!.Value);
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidServerAuth));

        var san = cert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectAlternativeName);
        Assert.That(san, Is.Not.Null);
        var sans = ExtensionParsers.SubjectAlternativeName.Parse(san!.Value);
        Assert.That(sans, Has.Count.EqualTo(2));
        Assert.That(sans[0].Value, Is.EqualTo("tls.example.com"));
        Assert.That(sans[1].Value, Is.EqualTo("www.tls.example.com"));

        var ku = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
        Assert.That(ku, Is.Not.Null);
        var flags = ExtensionParsers.KeyUsage.Parse(ku!.Value);
        Assert.That(flags.HasFlag(KeyUsageFlags.DigitalSignature), Is.True);
        Assert.That(flags.HasFlag(KeyUsageFlags.KeyEncipherment), Is.True);

        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    [Test]
    public void TlsServerProfileEcDsa()
    {
        var cert = CertificateProfiles.CreateTlsServerForEcDsa(
                "CN=ec-tls.example.com",
                ["ec-tls.example.com"])
            .BuildSelfSigned();

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);

        var eku = cert.Extensions.GetExtension(X509ExtensionCollection.OidExtendedKeyUsage);
        var ekuOids = ExtensionParsers.ExtendedKeyUsage.Parse(eku!.Value);
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidServerAuth));
    }

    // ========================================================================
    // TLS Client
    // ========================================================================

    [Test]
    public void TlsClientProfileRsa()
    {
        var cert = CertificateProfiles.CreateTlsClientForRSA("CN=client@example.com")
            .BuildSelfSigned();

        Assert.That(cert.Subject.ToString(), Does.Contain("CN=client@example.com"));

        var eku = cert.Extensions.GetExtension(X509ExtensionCollection.OidExtendedKeyUsage);
        Assert.That(eku, Is.Not.Null);
        var ekuOids = ExtensionParsers.ExtendedKeyUsage.Parse(eku!.Value);
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidClientAuth));

        var ku = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
        var flags = ExtensionParsers.KeyUsage.Parse(ku!.Value);
        Assert.That(flags.HasFlag(KeyUsageFlags.DigitalSignature), Is.True);
        Assert.That(flags.HasFlag(KeyUsageFlags.KeyEncipherment), Is.False);

        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    [Test]
    public void TlsClientProfileEcDsa()
    {
        var cert = CertificateProfiles.CreateTlsClientForEcDsa("CN=ec-client@example.com")
            .BuildSelfSigned();

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // CA Certificate
    // ========================================================================

    [Test]
    public void CaProfileRsa()
    {
        var cert = CertificateProfiles.CreateCaCertificate(
                "CN=Test Root CA, O=CryptoHives, C=US", pathLengthConstraint: 1, keySizeBits: 2048)
            .BuildSelfSigned();

        var bc = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
        var (isCA, pathLen) = ExtensionParsers.BasicConstraints.Parse(bc!.Value);
        Assert.That(isCA, Is.True);
        Assert.That(pathLen, Is.EqualTo(1));

        var ku = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
        var flags = ExtensionParsers.KeyUsage.Parse(ku!.Value);
        Assert.That(flags.HasFlag(KeyUsageFlags.KeyCertSign), Is.True);
        Assert.That(flags.HasFlag(KeyUsageFlags.CrlSign), Is.True);

        var ski = cert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectKeyIdentifier);
        Assert.That(ski, Is.Not.Null);

        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    [Test]
    public void CaProfileEcDsa()
    {
        var cert = CertificateProfiles.CreateCaCertificateEcDsa(
                "CN=EC Root CA, C=DE")
            .BuildSelfSigned();

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        var bc = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
        var (isCA, _) = ExtensionParsers.BasicConstraints.Parse(bc!.Value);
        Assert.That(isCA, Is.True);
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // OPC UA
    // ========================================================================

    [Test]
    public void OpcUaProfileRsa()
    {
        var cert = CertificateProfiles.CreateOpcUa(
                "CN=MyOpcUaApp, O=Industrial, C=DE",
                "urn:myhost:MyOpcUaApp",
                ["myhost.example.com"])
            .BuildSelfSigned();

        Assert.That(cert.Subject.ToString(), Does.Contain("CN=MyOpcUaApp"));

        var eku = cert.Extensions.GetExtension(X509ExtensionCollection.OidExtendedKeyUsage);
        var ekuOids = ExtensionParsers.ExtendedKeyUsage.Parse(eku!.Value);
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidServerAuth));
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidClientAuth));

        var san = cert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectAlternativeName);
        var sans = ExtensionParsers.SubjectAlternativeName.Parse(san!.Value);
        Assert.That(sans, Has.Count.EqualTo(2));
        Assert.That(sans[0].Type, Is.EqualTo(SanType.Uri));
        Assert.That(sans[0].Value, Is.EqualTo("urn:myhost:MyOpcUaApp"));
        Assert.That(sans[1].Type, Is.EqualTo(SanType.DnsName));
        Assert.That(sans[1].Value, Is.EqualTo("myhost.example.com"));

        var ku = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
        var flags = ExtensionParsers.KeyUsage.Parse(ku!.Value);
        Assert.That(flags.HasFlag(KeyUsageFlags.DigitalSignature), Is.True);
        Assert.That(flags.HasFlag(KeyUsageFlags.NonRepudiation), Is.True);
        Assert.That(flags.HasFlag(KeyUsageFlags.DataEncipherment), Is.True);

        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    [Test]
    public void OpcUaProfileEcDsa()
    {
        var cert = CertificateProfiles.CreateOpcUaEcDsa(
                "CN=EcOpcUaApp, O=Industrial, C=DE",
                "urn:myhost:EcOpcUaApp",
                ["myhost.example.com"])
            .BuildSelfSigned();

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // CA issues leaf via profile + chain validates
    // ========================================================================

    [Test]
    public void CaProfileIssuesTlsServerAndChainValidates()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=Profile CA, O=CryptoHives, C=US");

        var caCert = CreateCaCert(caRsa, caName);
        var leafCert = CreateLeafCert(caRsa, caName, "CN=profile-leaf.example.com");

        var result = X509ChainValidator.Validate(
            leafCert, Array.Empty<X509Certificate>(), [caCert]);

        Assert.That(result.IsValid, Is.True);
        Assert.That(result.Chain, Has.Count.EqualTo(2));
    }

    private static RsaKeyParameters ExportKey(RSA rsa)
    {
        var p = rsa.ExportParameters(true);
        return new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);
    }

    private static X509Certificate CreateCaCert(RSA rsa, X509Name name)
    {
        using var key = ExportKey(rsa);
        return new X509CertificateBuilder()
            .SetSubject(name)
            .SetSerialNumber(1L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(key)
            .AddBasicConstraints(true, 0)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(key);
    }

    private static X509Certificate CreateLeafCert(
        RSA issuerRsa, X509Name issuerName, string subjectCn)
    {
        using var leafRsa = RSA.Create(2048);
        using var leafKey = ExportKey(leafRsa);
        using var issuerKey = ExportKey(issuerRsa);

        return new X509CertificateBuilder()
            .SetSubject(X509Name.FromString(subjectCn))
            .SetSerialNumber(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafKey)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature | KeyUsageFlags.KeyEncipherment)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName((SanType.DnsName, "profile-leaf.example.com"))
            .BuildSignedRsa(issuerKey, issuerName);
    }
}
