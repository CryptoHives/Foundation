// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Certificates;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CrlTests
{
    // ========================================================================
    // RSA CRL Round-Trip
    // ========================================================================

    [Test]
    public void RsaCrlRoundTrip()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=RSA CRL CA, O=CryptoHives, C=US");
        var caCert = CreateCaCert(caRsa, caName);

        var leaf = CreateLeafCert(caRsa, caName, "CN=revoked.example.com");

        var now = DateTimeOffset.UtcNow;
        using var crlKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(30))
            .AddRevokedCertificate(leaf.SerialNumber, now, CrlReason.KeyCompromise)
            .BuildSignedRsa(crlKey);

        Assert.That(crl.Version, Is.EqualTo(2));
        Assert.That(crl.Issuer.ToString(), Does.Contain("CN=RSA CRL CA"));
        Assert.That(crl.NextUpdate, Is.Not.Null);
        Assert.That(crl.RevokedCertificates, Has.Count.EqualTo(1));
        Assert.That(crl.RevokedCertificates[0].Reason, Is.EqualTo(CrlReason.KeyCompromise));
        Assert.That(X509CrlValidator.VerifySignature(crl, caCert), Is.True);

        // DER round-trip
        var parsed = X509CrlParser.ParseDer(crl.ExportDer());
        Assert.That(parsed.Version, Is.EqualTo(2));
        Assert.That(parsed.RevokedCertificates, Has.Count.EqualTo(1));
        Assert.That(X509CrlValidator.VerifySignature(parsed, caCert), Is.True);
    }

    // ========================================================================
    // ECDSA CRL Round-Trip
    // ========================================================================

    [Test]
    public void EcDsaCrlRoundTrip()
    {
        using var ecdsa = new EcDsaCipher("nistP256");
        byte[] d = ecdsa.ExportPrivateKey()!;
        var (qx, qy) = ecdsa.ExportPublicKey();

        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(qx, 0, pubPoint, 1, qx.Length);
        Buffer.BlockCopy(qy, 0, pubPoint, 1 + qx.Length, qy.Length);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", "1.2.840.10045.3.1.7", pubPoint);

        var caName = X509Name.FromString("CN=EC CRL CA, O=CryptoHives, C=DE");
        var caCert = new X509CertificateBuilder()
            .SetSubject(caName)
            .SetSerialNumber(1L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(spki)
            .AddBasicConstraints(true)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSelfSigned(d, "nistP256");

        var now = DateTimeOffset.UtcNow;
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(7))
            .AddRevokedCertificate([0x01, 0x02, 0x03], now, CrlReason.Superseded)
            .BuildSignedEcDsa(d, "nistP256");

        Assert.That(crl.Version, Is.EqualTo(2));
        Assert.That(crl.RevokedCertificates, Has.Count.EqualTo(1));
        Assert.That(X509CrlValidator.VerifySignature(crl, caCert), Is.True);
    }

    // ========================================================================
    // Ed25519 CRL Round-Trip
    // ========================================================================

    [Test]
    public void Ed25519CrlRoundTrip()
    {
        byte[] seed = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] pub = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pub);
        byte[] spki = KeyEncoding.ExportEdPublicKey(pub, "1.3.101.112");

        var caName = X509Name.FromString("CN=Ed25519 CRL CA, C=JP");
        var caCert = new X509CertificateBuilder()
            .SetSubject(caName)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5))
            .SetPublicKey(spki)
            .AddBasicConstraints(true)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSelfSignedEd25519(seed);

        var now = DateTimeOffset.UtcNow;
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .AddRevokedCertificate([0xAA, 0xBB], now, CrlReason.CessationOfOperation)
            .BuildSignedEd25519(seed);

        Assert.That(crl.Version, Is.EqualTo(2));
        Assert.That(crl.NextUpdate, Is.Null);
        Assert.That(crl.RevokedCertificates, Has.Count.EqualTo(1));
        Assert.That(X509CrlValidator.VerifySignature(crl, caCert), Is.True);
    }

    // ========================================================================
    // CRL Revocation Check
    // ========================================================================

    [Test]
    public void CrlRevocationCheck()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=Revocation CA, C=US");
        var caCert = CreateCaCert(caRsa, caName);

        var leaf1 = CreateLeafCert(caRsa, caName, "CN=revoked1.example.com");
        var leaf2 = CreateLeafCert(caRsa, caName, "CN=revoked2.example.com");
        var leaf3 = CreateLeafCert(caRsa, caName, "CN=revoked3.example.com");
        var leafValid = CreateLeafCert(caRsa, caName, "CN=valid.example.com");

        var now = DateTimeOffset.UtcNow;
        using var crlKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(30))
            .AddRevokedCertificate(leaf1, now, CrlReason.KeyCompromise)
            .AddRevokedCertificate(leaf2, now, CrlReason.Superseded)
            .AddRevokedCertificate(leaf3, now, CrlReason.CaCompromise)
            .BuildSignedRsa(crlKey);

        Assert.That(crl.IsRevoked(leaf1), Is.True);
        Assert.That(crl.IsRevoked(leaf2), Is.True);
        Assert.That(crl.IsRevoked(leaf3), Is.True);
        Assert.That(crl.IsRevoked(leafValid), Is.False);
        Assert.That(crl.IsRevoked(leaf1.SerialNumber), Is.True);
        Assert.That(crl.IsRevoked(leafValid.SerialNumber), Is.False);
    }

    // ========================================================================
    // CRL Revocation Reason
    // ========================================================================

    [Test]
    public void CrlRevocationReason()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=Reason CA, C=US");

        var now = DateTimeOffset.UtcNow;
        byte[] serial1 = [0x10, 0x20];
        byte[] serial2 = [0x30, 0x40];
        byte[] serial3 = [0x50, 0x60];

        using var caKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .AddRevokedCertificate(serial1, now, CrlReason.KeyCompromise)
            .AddRevokedCertificate(serial2, now, CrlReason.Superseded)
            .AddRevokedCertificate(serial3, now)
            .BuildSignedRsa(caKey);

        Assert.That(crl.RevokedCertificates, Has.Count.EqualTo(3));
        Assert.That(crl.RevokedCertificates[0].Reason, Is.EqualTo(CrlReason.KeyCompromise));
        Assert.That(crl.RevokedCertificates[1].Reason, Is.EqualTo(CrlReason.Superseded));
        Assert.That(crl.RevokedCertificates[2].Reason, Is.EqualTo(CrlReason.Unspecified));
    }

    // ========================================================================
    // CRL PEM Round-Trip
    // ========================================================================

    [Test]
    public void CrlPemRoundTrip()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=PEM CRL CA, C=US");
        var caCert = CreateCaCert(caRsa, caName);

        var now = DateTimeOffset.UtcNow;
        using var crlKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(7))
            .AddRevokedCertificate([0x01], now, CrlReason.KeyCompromise)
            .BuildSignedRsa(crlKey);

        string pem = crl.ExportPem();
        Assert.That(pem, Does.Contain("-----BEGIN X509 CRL-----"));
        Assert.That(pem, Does.Contain("-----END X509 CRL-----"));

        var parsed = X509CrlParser.ParsePem(pem);
        Assert.That(parsed.Version, Is.EqualTo(2));
        Assert.That(parsed.RevokedCertificates, Has.Count.EqualTo(1));
        Assert.That(X509CrlValidator.VerifySignature(parsed, caCert), Is.True);
    }

    // ========================================================================
    // Empty CRL
    // ========================================================================

    [Test]
    public void EmptyCrl()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=Empty CRL CA, C=US");
        var caCert = CreateCaCert(caRsa, caName);

        var now = DateTimeOffset.UtcNow;
        using var crlKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(30))
            .BuildSignedRsa(crlKey);

        Assert.That(crl.Version, Is.EqualTo(2));
        Assert.That(crl.RevokedCertificates, Has.Count.EqualTo(0));
        Assert.That(crl.IsRevoked([0x01]), Is.False);
        Assert.That(X509CrlValidator.VerifySignature(crl, caCert), Is.True);
    }

    // ========================================================================
    // CRL GetRevocationEntry
    // ========================================================================

    [Test]
    public void CrlGetRevocationEntry()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=Entry CA, C=US");

        byte[] serial1 = [0xAA, 0xBB];
        byte[] serial2 = [0xCC, 0xDD];
        byte[] serialMissing = [0xFF];

        var now = DateTimeOffset.UtcNow;
        using var caKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .AddRevokedCertificate(serial1, now, CrlReason.KeyCompromise)
            .AddRevokedCertificate(serial2, now, CrlReason.AffiliationChanged)
            .BuildSignedRsa(caKey);

        var entry1 = crl.GetRevocationEntry(serial1);
        Assert.That(entry1, Is.Not.Null);
        Assert.That(entry1!.Reason, Is.EqualTo(CrlReason.KeyCompromise));

        var entry2 = crl.GetRevocationEntry(serial2);
        Assert.That(entry2, Is.Not.Null);
        Assert.That(entry2!.Reason, Is.EqualTo(CrlReason.AffiliationChanged));

        var entryMissing = crl.GetRevocationEntry(serialMissing);
        Assert.That(entryMissing, Is.Null);
    }

    // ========================================================================
    // CRL Issuing Distribution Point and Delta CRL Indicator Round-Trip
    // ========================================================================

    [Test]
    public void CrlIssuingDistributionPointAndDeltaIndicatorRoundTrip()
    {
        using var caRsa = RSA.Create(2048);
        var caName = X509Name.FromString("CN=CRL Extension CA, C=US");
        var now = DateTimeOffset.UtcNow;

        using var caKey = ExportKey(caRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(caName)
            .SetThisUpdate(now)
            .SetNextUpdate(now.AddDays(7))
            .AddIssuingDistributionPoint(["http://ca.example.org/issuing.crl"], indirectCrl: true)
            .AddDeltaCrlIndicator(12)
            .BuildSignedRsa(caKey);

        var issuingDpExt = crl.Extensions.GetExtension(X509ExtensionCollection.OidIssuingDistributionPoint);
        Assert.That(issuingDpExt, Is.Not.Null);
        var (uris, indirect) = ExtensionParsers.IssuingDistributionPoint.Parse(issuingDpExt!.Value);
        Assert.That(uris, Has.Count.EqualTo(1));
        Assert.That(uris[0], Is.EqualTo("http://ca.example.org/issuing.crl"));
        Assert.That(indirect, Is.True);

        var deltaExt = crl.Extensions.GetExtension(X509ExtensionCollection.OidDeltaCrlIndicator);
        Assert.That(deltaExt, Is.Not.Null);
        Assert.That(ExtensionParsers.DeltaCrlIndicator.Parse(deltaExt!.Value), Is.EqualTo(12));
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static RsaKeyParameters ExportKey(RSA rsa)
    {
        var p = rsa.ExportParameters(true);
        return new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);
    }

    private static X509Certificate CreateCaCert(RSA caRsa, X509Name name)
    {
        using var key = ExportKey(caRsa);
        return new X509CertificateBuilder()
            .SetSubject(name)
            .SetSerialNumber(1L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(key)
            .AddBasicConstraints(true)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSelfSigned(key);
    }

    private static X509Certificate CreateLeafCert(RSA caRsa, X509Name caName, string subjectCn)
    {
        using var leafRsa = RSA.Create(2048);
        using var leafKey = ExportKey(leafRsa);
        using var caKey = ExportKey(caRsa);

        return new X509CertificateBuilder()
            .SetSubject(X509Name.FromString(subjectCn))
            .SetSerialNumber(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafKey)
            .AddBasicConstraints(false)
            .BuildSignedRsa(caKey, caName);
    }
}
