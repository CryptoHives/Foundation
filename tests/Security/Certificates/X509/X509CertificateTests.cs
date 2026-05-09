// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Certificates;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class X509CertificateTests
{
    // ========================================================================
    // Parsing
    // ========================================================================

    [Test]
    public void ParseSelfSignedRsaCertificate()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=test.example.com, O=Test Org, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(42L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature | KeyUsageFlags.KeyEncipherment)
            .BuildSelfSigned(rsaKey);

        byte[] der = cert.RawDer;
        var parsed = X509CertificateParser.ParseDer(der);

        Assert.That(parsed.Version, Is.EqualTo(3));
        Assert.That(parsed.Subject.ToString(), Does.Contain("CN=test.example.com"));
        Assert.That(parsed.Issuer.ToString(), Does.Contain("O=Test Org"));
        Assert.That(parsed.IsSelfSigned, Is.True);
        Assert.That(parsed.IsValid, Is.True);
        Assert.That(parsed.GetPublicKeyAlgorithm(), Is.EqualTo("RSA"));
        Assert.That(parsed.Thumbprint, Is.Not.Empty);
    }

    [Test]
    public void ParseSelfSignedEcdsaCertificate()
    {
        var (ecPriv, spki) = CreateEcKey("nistP256");
        var name = X509Name.FromString("CN=ec-test.example.com, C=DE");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(100L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(spki)
            .AddBasicConstraints(false)
            .BuildSelfSigned(ecPriv, "nistP256");

        var parsed = X509CertificateParser.ParseDer(cert.RawDer);

        Assert.That(parsed.Version, Is.EqualTo(3));
        Assert.That(parsed.Subject.ToString(), Does.Contain("CN=ec-test.example.com"));
        Assert.That(parsed.IsSelfSigned, Is.True);
        Assert.That(parsed.IsValid, Is.True);
        Assert.That(parsed.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
    }

    // ========================================================================
    // Signature Verification
    // ========================================================================

    [Test]
    public void VerifySelfSignedRsaSignature()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=rsa-verify.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(200L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(true, 0)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(rsaKey, "SHA256");

        bool valid = X509CertificateValidator.VerifySelfSigned(cert);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void VerifySelfSignedEcdsaSignature()
    {
        var (ecPriv, spki) = CreateEcKey("nistP256");
        var name = X509Name.FromString("CN=ecdsa-verify.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(300L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(spki)
            .AddBasicConstraints(false)
            .BuildSelfSigned(ecPriv, "nistP256", "SHA256");

        bool valid = X509CertificateValidator.VerifySelfSigned(cert);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Distinguished Name
    // ========================================================================

    [Test]
    public void ParseDistinguishedName()
    {
        var name = X509Name.FromString("CN=example.com, O=Example Inc, C=US");

        Assert.That(name.Attributes, Has.Count.EqualTo(3));
        Assert.That(name.ToString(), Is.EqualTo("CN=example.com, O=Example Inc, C=US"));

        byte[] der = name.EncodeDer();
        var parsed = X509Name.ParseDer(der);
        Assert.That(parsed.ToString(), Is.EqualTo(name.ToString()));
    }

    // ========================================================================
    // Extension Parsing
    // ========================================================================

    [Test]
    public void ParseBasicConstraintsExtension()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=CA Test, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(400L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(3650))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(true, 1)
            .BuildSelfSigned(rsaKey);

        var ext = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
        Assert.That(ext, Is.Not.Null);
        Assert.That(ext!.Critical, Is.True);

        var (isCA, pathLen) = ExtensionParsers.BasicConstraints.Parse(ext.Value);
        Assert.That(isCA, Is.True);
        Assert.That(pathLen, Is.EqualTo(1));
    }

    [Test]
    public void ParseKeyUsageExtension()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=KU Test, C=US");

        var flags = KeyUsageFlags.DigitalSignature | KeyUsageFlags.KeyEncipherment;
        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(500L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddKeyUsage(flags)
            .BuildSelfSigned(rsaKey);

        var ext = cert.Extensions.GetExtension(X509ExtensionCollection.OidKeyUsage);
        Assert.That(ext, Is.Not.Null);

        var parsed = ExtensionParsers.KeyUsage.Parse(ext!.Value);
        Assert.That(parsed.HasFlag(KeyUsageFlags.DigitalSignature), Is.True);
        Assert.That(parsed.HasFlag(KeyUsageFlags.KeyEncipherment), Is.True);
        Assert.That(parsed.HasFlag(KeyUsageFlags.KeyCertSign), Is.False);
    }

    [Test]
    public void ParseSubjectAlternativeName()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=SAN Test, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(600L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddSubjectAlternativeName(
                (SanType.DnsName, "example.com"),
                (SanType.DnsName, "*.example.com"),
                (SanType.IpAddress, "192.168.1.1"))
            .BuildSelfSigned(rsaKey);

        var ext = cert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectAlternativeName);
        Assert.That(ext, Is.Not.Null);

        var sans = ExtensionParsers.SubjectAlternativeName.Parse(ext!.Value);
        Assert.That(sans, Has.Count.EqualTo(3));
        Assert.That(sans[0].Type, Is.EqualTo(SanType.DnsName));
        Assert.That(sans[0].Value, Is.EqualTo("example.com"));
        Assert.That(sans[1].Value, Is.EqualTo("*.example.com"));
        Assert.That(sans[2].Type, Is.EqualTo(SanType.IpAddress));
        Assert.That(sans[2].Value, Is.EqualTo("192.168.1.1"));
    }

    // ========================================================================
    // Builder Round-Trip
    // ========================================================================

    [Test]
    public void BuilderRoundTrip()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=roundtrip.example.com, O=RoundTrip, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(700L)
            .SetValidity(
                new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature)
            .AddSubjectAlternativeName(
                (SanType.DnsName, "roundtrip.example.com"))
            .BuildSelfSigned(rsaKey);

        byte[] der = cert.RawDer;
        var parsed = X509CertificateParser.ParseDer(der);

        Assert.That(parsed.Version, Is.EqualTo(cert.Version));
        Assert.That(parsed.Subject.ToString(), Is.EqualTo(cert.Subject.ToString()));
        Assert.That(parsed.Issuer.ToString(), Is.EqualTo(cert.Issuer.ToString()));
        Assert.That(parsed.SignatureAlgorithmOid, Is.EqualTo(cert.SignatureAlgorithmOid));
        Assert.That(parsed.NotBefore.Year, Is.EqualTo(2025));
        Assert.That(parsed.NotAfter.Year, Is.EqualTo(2026));
        Assert.That(parsed.Extensions.Count, Is.EqualTo(cert.Extensions.Count));
    }

    // ========================================================================
    // Factory Method: CreateForRsa
    // ========================================================================

    [Test]
    public void CreateForRsaSelfSigned()
    {
        var name = X509Name.FromString("CN=rsa-factory.example.com, C=US");

        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .AddBasicConstraints(false)
            .BuildSelfSigned();

        Assert.That(cert.Version, Is.EqualTo(3));
        Assert.That(cert.Subject.ToString(), Does.Contain("CN=rsa-factory.example.com"));
        Assert.That(cert.IsSelfSigned, Is.True);
        Assert.That(cert.IsValid, Is.True);
        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("RSA"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // Factory Method: CreateForEcDsa
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    public void CreateForEcDsaSelfSigned(string curveName)
    {
        var name = X509Name.FromString($"CN=ecdsa-factory.example.com, C=DE");

        var cert = X509CertificateBuilder.CreateForEcDsa(curveName)
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .AddBasicConstraints(false)
            .BuildSelfSigned();

        Assert.That(cert.Version, Is.EqualTo(3));
        Assert.That(cert.Subject.ToString(), Does.Contain("CN=ecdsa-factory.example.com"));
        Assert.That(cert.IsSelfSigned, Is.True);
        Assert.That(cert.IsValid, Is.True);
        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("ECDSA"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // Factory Method: CreateForEd25519
    // ========================================================================

    [Test]
    public void CreateForEd25519SelfSigned()
    {
        var name = X509Name.FromString("CN=ed25519-factory.example.com, C=CH");

        var cert = X509CertificateBuilder.CreateForEd25519()
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .BuildSelfSigned();

        Assert.That(cert.Version, Is.EqualTo(3));
        Assert.That(cert.Subject.ToString(), Does.Contain("CN=ed25519-factory.example.com"));
        Assert.That(cert.IsSelfSigned, Is.True);
        Assert.That(cert.IsValid, Is.True);
        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("Ed25519"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // Factory Method: CreateForEd448
    // ========================================================================

    [Test]
    public void CreateForEd448SelfSigned()
    {
        var name = X509Name.FromString("CN=ed448-factory.example.com, C=JP");

        var cert = X509CertificateBuilder.CreateForEd448()
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .BuildSelfSigned();

        Assert.That(cert.Version, Is.EqualTo(3));
        Assert.That(cert.Subject.ToString(), Does.Contain("CN=ed448-factory.example.com"));
        Assert.That(cert.IsSelfSigned, Is.True);
        Assert.That(cert.IsValid, Is.True);
        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("Ed448"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // Explicit EdDSA BuildSelfSigned (non-factory)
    // ========================================================================

    [Test]
    public void BuildSelfSignedEd25519Explicit()
    {
        byte[] seed = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.112");

        var name = X509Name.FromString("CN=ed25519-explicit.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(spki)
            .BuildSelfSignedEd25519(seed);

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("Ed25519"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    [Test]
    public void BuildSelfSignedEd448Explicit()
    {
        byte[] seed = new byte[57];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.113");

        var name = X509Name.FromString("CN=ed448-explicit.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(spki)
            .BuildSelfSignedEd448(seed);

        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("Ed448"));
        Assert.That(X509CertificateValidator.VerifySelfSigned(cert), Is.True);
    }

    // ========================================================================
    // PEM Round-Trip
    // ========================================================================

    [Test]
    public void PemRoundTrip()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=pem-test.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(800L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .BuildSelfSigned(rsaKey);

        string pem = PemHelper.Encode(cert.RawDer, "CERTIFICATE");
        Assert.That(pem, Does.StartWith("-----BEGIN CERTIFICATE-----"));
        Assert.That(pem, Does.EndWith("-----END CERTIFICATE-----"));

        var parsed = X509CertificateParser.ParsePem(pem);
        Assert.That(parsed.Subject.ToString(), Is.EqualTo(cert.Subject.ToString()));
        Assert.That(parsed.RawDer, Is.EqualTo(cert.RawDer));
    }

    // ========================================================================
    // BCL Cross-Validation
    // ========================================================================

#if NET10_0_OR_GREATER
    [Test]
    public void CrossValidateWithBcl()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=bcl-test.example.com, O=BCL Test, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(900L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(true, 0)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(rsaKey, "SHA256");

        byte[] der = cert.RawDer;
        using var bclCert = System.Security.Cryptography.X509Certificates.X509CertificateLoader.LoadCertificate(der);

        Assert.That(bclCert.Subject, Does.Contain("CN=bcl-test.example.com"));
        Assert.That(bclCert.Issuer, Does.Contain("O=BCL Test"));
        Assert.That(bclCert.Version, Is.EqualTo(3));
        Assert.That(bclCert.NotBefore, Is.LessThan(DateTime.UtcNow));
        Assert.That(bclCert.NotAfter, Is.GreaterThan(DateTime.UtcNow));
    }
#endif

    // ========================================================================
    // Real-World Certificate Parsing
    // ========================================================================

    [Test]
    public void ParseRealWorldCert()
    {
        // ISRG Root X1 (Let's Encrypt) — a well-known self-signed RSA CA cert
        byte[] der = Convert.FromBase64String(IsrgRootX1Base64);
        var cert = X509CertificateParser.ParseDer(der);

        Assert.That(cert.Version, Is.EqualTo(3));
        Assert.That(cert.Subject.ToString(), Does.Contain("O=Internet Security Research Group"));
        Assert.That(cert.IsSelfSigned, Is.True);
        Assert.That(cert.GetPublicKeyAlgorithm(), Is.EqualTo("RSA"));

        var bcExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidBasicConstraints);
        Assert.That(bcExt, Is.Not.Null);
        var (isCA, _) = ExtensionParsers.BasicConstraints.Parse(bcExt!.Value);
        Assert.That(isCA, Is.True);

        bool sigValid = X509CertificateValidator.VerifySelfSigned(cert);
        Assert.That(sigValid, Is.True);
    }

    // ========================================================================
    // Extended Key Usage
    // ========================================================================

    [Test]
    public void ExtendedKeyUsageRoundTrip()
    {
        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=eku-test.example.com"))
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .AddExtendedKeyUsage(
                ExtensionParsers.ExtendedKeyUsage.OidServerAuth,
                ExtensionParsers.ExtendedKeyUsage.OidClientAuth)
            .BuildSelfSigned();

        var ekuExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidExtendedKeyUsage);
        Assert.That(ekuExt, Is.Not.Null);

        var ekuOids = ExtensionParsers.ExtendedKeyUsage.Parse(ekuExt!.Value);
        Assert.That(ekuOids, Has.Count.EqualTo(2));
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidServerAuth));
        Assert.That(ekuOids, Does.Contain(ExtensionParsers.ExtendedKeyUsage.OidClientAuth));
    }

    // ========================================================================
    // Authority Key Identifier Builder
    // ========================================================================

    [Test]
    public void AuthorityKeyIdentifierRoundTrip()
    {
        byte[] expectedKeyId = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=aki-test.example.com"))
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .AddAuthorityKeyIdentifier(expectedKeyId)
            .BuildSelfSigned();

        var akiExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidAuthorityKeyIdentifier);
        Assert.That(akiExt, Is.Not.Null);

        var (keyId, _, _) = ExtensionParsers.AuthorityKeyIdentifier.Parse(akiExt!.Value);
        Assert.That(keyId, Is.EqualTo(expectedKeyId));
    }

    // ========================================================================
    // CRL Distribution Points Builder
    // ========================================================================

    [Test]
    public void CrlDistributionPointRoundTrip()
    {
        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=crldp-test.example.com"))
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .AddCrlDistributionPoint("http://crl.example.com/ca.crl")
            .BuildSelfSigned();

        var crlExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidCrlDistributionPoints);
        Assert.That(crlExt, Is.Not.Null);

        var uris = ExtensionParsers.CrlDistributionPoints.Parse(crlExt!.Value);
        Assert.That(uris, Has.Count.EqualTo(1));
        Assert.That(uris[0], Is.EqualTo("http://crl.example.com/ca.crl"));
    }

    // ========================================================================
    // Authority Information Access Builder
    // ========================================================================

    [Test]
    public void AuthorityInfoAccessRoundTrip()
    {
        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=aia-test.example.com"))
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .AddAuthorityInfoAccess(
                ocspUri: "http://ocsp.example.com",
                caIssuersUri: "http://ca.example.com/ca.crt")
            .BuildSelfSigned();

        var aiaExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidAuthorityInfoAccess);
        Assert.That(aiaExt, Is.Not.Null);

        var entries = ExtensionParsers.AuthorityInfoAccess.Parse(aiaExt!.Value);
        Assert.That(entries, Has.Count.EqualTo(2));
        Assert.That(entries[0].Method, Is.EqualTo(ExtensionParsers.AuthorityInfoAccess.OidOcsp));
        Assert.That(entries[0].Location, Is.EqualTo("http://ocsp.example.com"));
        Assert.That(entries[1].Method, Is.EqualTo(ExtensionParsers.AuthorityInfoAccess.OidCaIssuers));
        Assert.That(entries[1].Location, Is.EqualTo("http://ca.example.com/ca.crt"));
    }

    // ========================================================================
    // Auto-SKI for CA Certs
    // ========================================================================

    [Test]
    public void CaCertAutoComputesSki()
    {
        var cert = X509CertificateBuilder.CreateForRsa(2048)
            .SetSubject(X509Name.FromString("CN=CA Auto SKI, C=US"))
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .AddBasicConstraints(true, 0)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned();

        var skiExt = cert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectKeyIdentifier);
        Assert.That(skiExt, Is.Not.Null);

        byte[] ski = ExtensionParsers.SubjectKeyIdentifier.Parse(skiExt!.Value);
        Assert.That(ski, Has.Length.EqualTo(20));
    }

    // ========================================================================
    // Issuer-Signed Certificate Chain
    // ========================================================================

    [Test]
    public void IssuerSignedRsaCertChain()
    {
        var caName = X509Name.FromString("CN=Test CA, O=CryptoHives, C=US");

        using var rsa = System.Security.Cryptography.RSA.Create(2048);

        // ExportParameters returns fresh arrays each call; needed because
        // RsaCipher.Dispose zeroes the key data.
        var p1 = rsa.ExportParameters(true);
        var caKey1 = new RsaKeyParameters(
            p1.Modulus!, p1.Exponent!, p1.D!, p1.P!, p1.Q!, p1.DP!, p1.DQ!, p1.InverseQ!);

        var caCertManual = new X509CertificateBuilder()
            .SetSubject(caName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(caKey1)
            .AddBasicConstraints(true, 1)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(caKey1);

        byte[] caSki = ExtensionParsers.SubjectKeyIdentifier.Parse(
            caCertManual.Extensions.GetExtension(X509ExtensionCollection.OidSubjectKeyIdentifier)!.Value);

        Assert.That(caCertManual.IsSelfSigned, Is.True);
        Assert.That(X509CertificateValidator.VerifySelfSigned(caCertManual), Is.True);

        // Build leaf — fresh key export to avoid zeroed arrays
        var p2 = rsa.ExportParameters(true);
        using var caKey2 = new RsaKeyParameters(
            p2.Modulus!, p2.Exponent!, p2.D!, p2.P!, p2.Q!, p2.DP!, p2.DQ!, p2.InverseQ!);

        var leafName = X509Name.FromString("CN=leaf.example.com, O=CryptoHives, C=US");
        using var leafRsa = System.Security.Cryptography.RSA.Create(2048);
        var lp = leafRsa.ExportParameters(true);
        var leafKey = new RsaKeyParameters(
            lp.Modulus!, lp.Exponent!, lp.D!, lp.P!, lp.Q!, lp.DP!, lp.DQ!, lp.InverseQ!);

        var leafCert = new X509CertificateBuilder()
            .SetSubject(leafName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafKey)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature | KeyUsageFlags.KeyEncipherment)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName((SanType.DnsName, "leaf.example.com"))
            .AddAuthorityKeyIdentifier(caSki)
            .BuildSignedRsa(caKey2, caName);

        Assert.That(leafCert.IsSelfSigned, Is.False);
        Assert.That(leafCert.Subject.ToString(), Does.Contain("CN=leaf.example.com"));
        Assert.That(leafCert.Issuer.ToString(), Does.Contain("CN=Test CA"));

        Assert.That(X509CertificateValidator.VerifySignature(leafCert, caCertManual), Is.True);

        var leafAki = ExtensionParsers.AuthorityKeyIdentifier.Parse(
            leafCert.Extensions.GetExtension(X509ExtensionCollection.OidAuthorityKeyIdentifier)!.Value);
        Assert.That(leafAki.KeyId, Is.EqualTo(caSki));
    }

    [Test]
    public void IssuerSignedEcdsaCertChain()
    {
        var caName = X509Name.FromString("CN=EC CA, C=DE");

        using var caDsa = new EcDsaCipher("nistP256");
        byte[] caD = caDsa.ExportPrivateKey()!;
        var (caQx, caQy) = caDsa.ExportPublicKey();
        byte[] caPubPoint = new byte[1 + caQx.Length + caQy.Length];
        caPubPoint[0] = 0x04;
        Buffer.BlockCopy(caQx, 0, caPubPoint, 1, caQx.Length);
        Buffer.BlockCopy(caQy, 0, caPubPoint, 1 + caQx.Length, caQy.Length);
        byte[] caSpki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", "1.2.840.10045.3.1.7", caPubPoint);

        var caCert = new X509CertificateBuilder()
            .SetSubject(caName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5))
            .SetPublicKey(caSpki)
            .AddBasicConstraints(true, 0)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign)
            .BuildSelfSigned(caD, "nistP256");

        byte[] caSki = ExtensionParsers.SubjectKeyIdentifier.Parse(
            caCert.Extensions.GetExtension(X509ExtensionCollection.OidSubjectKeyIdentifier)!.Value);

        // Leaf
        var leafName = X509Name.FromString("CN=ec-leaf.example.com, C=DE");
        using var leafDsa = new EcDsaCipher("nistP256");
        byte[] leafD = leafDsa.ExportPrivateKey()!;
        var (leafQx, leafQy) = leafDsa.ExportPublicKey();
        byte[] leafPub = new byte[1 + leafQx.Length + leafQy.Length];
        leafPub[0] = 0x04;
        Buffer.BlockCopy(leafQx, 0, leafPub, 1, leafQx.Length);
        Buffer.BlockCopy(leafQy, 0, leafPub, 1 + leafQx.Length, leafQy.Length);
        byte[] leafSpki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", "1.2.840.10045.3.1.7", leafPub);

        var leafCert = new X509CertificateBuilder()
            .SetSubject(leafName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafSpki)
            .AddBasicConstraints(false)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddAuthorityKeyIdentifier(caSki)
            .BuildSignedEcDsa(caD, "nistP256", caName);

        Assert.That(leafCert.IsSelfSigned, Is.False);
        Assert.That(X509CertificateValidator.VerifySignature(leafCert, caCert), Is.True);
    }

    // ========================================================================
    // Name Equality
    // ========================================================================

    [Test]
    public void NameEquality()
    {
        var name1 = X509Name.FromString("CN=test.com, O=Org, C=US");
        var name2 = X509Name.FromString("CN=test.com, O=Org, C=US");
        var name3 = X509Name.FromString("CN=other.com, O=Org, C=US");

        Assert.That(name1, Is.EqualTo(name2));
        Assert.That(name1.GetHashCode(), Is.EqualTo(name2.GetHashCode()));
        Assert.That(name1, Is.Not.EqualTo(name3));
    }

    // ========================================================================
    // Expired Certificate
    // ========================================================================

    [Test]
    public void ExpiredCertificateIsNotValid()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=expired.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(1000L)
            .SetValidity(
                new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .SetPublicKey(rsaKey)
            .BuildSelfSigned(rsaKey);

        Assert.That(cert.IsValid, Is.False);
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static RsaKeyParameters CreateRsaKey(int bits)
    {
        using var rsa = RSA.Create(bits);
        var p = rsa.ExportParameters(true);
        return new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);
    }

    private static (byte[] PrivateKey, byte[] SpkiDer) CreateEcKey(string curveName)
    {
        using var ecdsa = new EcDsaCipher(curveName);
        byte[] d = ecdsa.ExportPrivateKey()!;
        var (qx, qy) = ecdsa.ExportPublicKey();

        string curveOid = curveName switch
        {
            "nistP256" or "P-256" => "1.2.840.10045.3.1.7",
            "nistP384" or "P-384" => "1.3.132.0.34",
            "nistP521" or "P-521" => "1.3.132.0.35",
            _ => throw new ArgumentException($"Unknown curve: {curveName}"),
        };

        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(qx, 0, pubPoint, 1, qx.Length);
        Buffer.BlockCopy(qy, 0, pubPoint, 1 + qx.Length, qy.Length);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", curveOid, pubPoint);

        return (d, spki);
    }

    // ISRG Root X1 (Let's Encrypt Root CA) — DER as Base64
    private const string IsrgRootX1Base64 =
        "MIIFazCCA1OgAwIBAgIRAIIQz7DSQONZRGPgu2OCiwAwDQYJKoZIhvcNAQELBQAw" +
        "TzELMAkGA1UEBhMCVVMxKTAnBgNVBAoTIEludGVybmV0IFNlY3VyaXR5IFJlc2Vh" +
        "cmNoIEdyb3VwMRUwEwYDVQQDEwxJU1JHIFJvb3QgWDEwHhcNMTUwNjA0MTEwNDM4" +
        "WhcNMzUwNjA0MTEwNDM4WjBPMQswCQYDVQQGEwJVUzEpMCcGA1UEChMgSW50ZXJu" +
        "ZXQgU2VjdXJpdHkgUmVzZWFyY2ggR3JvdXAxFTATBgNVBAMTDElTUkcgUm9vdCBY" +
        "MTCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAK3oJHP0FDfzm54rVygc" +
        "h77ct984kIxuPOZXoHj3dcKi/vVqbvYATyjb3miGbESTtrFj/RQSa78f0uoxmyF+" +
        "0TM8ukj13Xnfs7j/EvEhmkvBioZxaUpmZmyPfjxwv60pIgbz5MDmgK7iS4+3mX6U" +
        "A5/TR5d8mUgjU+g4rk8Kb4Mu0UlXjIB0ttov0DiNewNwIRt18jA8+o+u3dpjq+sW" +
        "T8KOEUt+zwvo/7V3LvSye0rgTBIlDHCNAymg4VMk7BPZ7hm/ELNKjD+Jo2FR3qyH" +
        "B5T0Y3HsLuJvW5iB4YlcNHlsdu87kGJ55tukmi8mxdAQ4Q7e2RCOFvu396j3x+UC" +
        "B5iPNgiV5+I3lg02dZ77DnKxHZu8A/lJBdiB3QW0KtZB6awBdpUKD9jf1b0SHzUv" +
        "KBds0pjBqAlkd25HN7rOrFleaJ1/ctaJxQZBKT5ZPt0m9STJEadao0xAH0ahmbWn" +
        "OlFuhjuefXKnEgV4We0+UXgVCwOPjdAvBbI+e0ocS3MFEvzG6uBQE3xDk3SzynTn" +
        "jh8BCNAw1FtxNrQHusEwMFxIt4I7mKZ9YIqioymCzLq9gwQbooMDQaHWBfEbwrbw" +
        "qHyGO0aoSCqI3Haadr8faqU9GY/rOPNk3sgrDQoo//fb4hVC1CLQJ13hef4Y53CI" +
        "rU7m2Ys6xt0nUW7/vGT1M0NPAgMBAAGjQjBAMA4GA1UdDwEB/wQEAwIBBjAPBgNV" +
        "HRMBAf8EBTADAQH/MB0GA1UdDgQWBBR5tFnme7bl5AFzgAiIyBpY9umbbjANBgkq" +
        "hkiG9w0BAQsFAAOCAgEAVR9YqbyyqFDQDLHYGmkgJykIrGF1XIpu+ILlaS/V9lZL" +
        "ubhzEFnTIZd+50xx+7LSYK05qAvqFyFWhfFQDlnrzuBZ6brJFe+GnY+EgPbk6ZGQ" +
        "3BebYhtF8GaV0nxvwuo77x/Py9auJ/GpsMiu/X1+mvoiBOv/2X/qkSsisRcOj/KK" +
        "NFtY2PwByVS5uCbMiogziUwthDyC3+6WVwW6LLv3xLfHTjuCvjHIInNzktHCgKQ5" +
        "ORAzI4JMPJ+GslWYHb4phowim57iaztXOoJwTdwJx4nLCgdNbOhdjsnvzqvHu7Ur" +
        "TkXWStAmzOVyyghqpZXjFaH3pO3JLF+l+/+sKAIuvtd7u+Nxe5AW0wdeRlN8NwdC" +
        "jNPElpzVmbUq4JUagEiuTDkHzsxHpFKVK7q4+63SM1N95R1NbdWhscdCb+ZAJzVc" +
        "oyi3B43njTOQ5yOf+1CceWxG1bQVs5ZufpsMljq4Ui0/1lvh+wjChP4kqKOJ2qxq" +
        "4RgqsahDYVvTH9w7jXbyLeiNdd8XM2w9U/t7y0Ff/9yi0GE44Za4rF2LN9d11TPA" +
        "mRGunUHBcnWEvgJBQl9nJEiU0Zsnvgc/ubhPgXRR4Xq37Z0j4r7g1SgEEzwxA57d" +
        "emyPxgcYxn/eR44/KJ4EBs+lVDR3veyJm+kXQ99b21/+jh5Xos1AnX5iItreGCc=";
}
