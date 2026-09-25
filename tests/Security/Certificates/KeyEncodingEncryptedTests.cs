// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Text;
using CryptoHives.Foundation.Security.Certificates;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KeyEncodingEncryptedTests
{
    private static readonly byte[] TestPassword = Encoding.UTF8.GetBytes("test-password-123!");

    // ========================================================================
    // Encrypted PKCS#8 Round-Trip
    // ========================================================================

    [Test]
    public void EncryptedPkcs8RsaRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] pkcs1Priv = KeyEncoding.ExportRsaPrivateKey(key);
        byte[] pkcs8 = KeyEncoding.ExportPkcs8PrivateKey("1.2.840.113549.1.1.1", null, pkcs1Priv);

        byte[] encrypted = KeyEncoding.ExportEncryptedPkcs8PrivateKey(pkcs8, TestPassword, 1000);
        Assert.That(encrypted, Is.Not.EqualTo(pkcs8));

        byte[] decryptedInner = KeyEncoding.ImportEncryptedPkcs8PrivateKey(
            encrypted, TestPassword, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.113549.1.1.1"));
        Assert.That(curveOid, Is.Null);
        Assert.That(decryptedInner, Is.EqualTo(pkcs1Priv));
    }

    [Test]
    public void EncryptedPkcs8EcRoundTrip()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(true);
        string curveOidVal = ep.Curve.Oid!.Value!;

        byte[] innerDer = BuildEcPkcs8InnerDer(ep.D!, ep.Q.X!, ep.Q.Y!);
        byte[] pkcs8 = KeyEncoding.ExportPkcs8PrivateKey("1.2.840.10045.2.1", curveOidVal, innerDer);

        byte[] encrypted = KeyEncoding.ExportEncryptedPkcs8PrivateKey(pkcs8, TestPassword, 1000);
        byte[] decryptedInner = KeyEncoding.ImportEncryptedPkcs8PrivateKey(
            encrypted, TestPassword, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.10045.2.1"));
        Assert.That(curveOid, Is.EqualTo(curveOidVal));
        Assert.That(decryptedInner, Is.EqualTo(innerDer));
    }

    [Test]
    public void EncryptedPkcs8Ed25519RoundTrip()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.112");

        byte[] encrypted = KeyEncoding.ExportEncryptedPkcs8PrivateKey(pkcs8, TestPassword, 1000);
        byte[] decryptedInner = KeyEncoding.ImportEncryptedPkcs8PrivateKey(
            encrypted, TestPassword, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.3.101.112"));
        Assert.That(curveOid, Is.Null);

        // Verify the decrypted inner key matches original seed
        var reader = new AsnReader(decryptedInner, AsnEncodingRules.DER);
        byte[] decryptedSeed = reader.ReadOctetString();
        Assert.That(decryptedSeed, Is.EqualTo(seed));
    }

    // ========================================================================
    // Encrypted PEM Round-Trip
    // ========================================================================

    [Test]
    public void EncryptedPemRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] pkcs1Priv = KeyEncoding.ExportRsaPrivateKey(key);
        byte[] pkcs8 = KeyEncoding.ExportPkcs8PrivateKey("1.2.840.113549.1.1.1", null, pkcs1Priv);

        string encryptedPem = KeyEncoding.ExportEncryptedPem(pkcs8, TestPassword, 1000);
        Assert.That(encryptedPem, Does.StartWith("-----BEGIN ENCRYPTED PRIVATE KEY-----"));
        Assert.That(encryptedPem, Does.EndWith("-----END ENCRYPTED PRIVATE KEY-----"));

        byte[] decryptedInner = KeyEncoding.ImportEncryptedPem(
            encryptedPem, TestPassword, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.113549.1.1.1"));
        Assert.That(decryptedInner, Is.EqualTo(pkcs1Priv));
    }

    // ========================================================================
    // Wrong Password
    // ========================================================================

    [Test]
    public void WrongPasswordThrows()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.112");
        byte[] encrypted = KeyEncoding.ExportEncryptedPkcs8PrivateKey(pkcs8, TestPassword, 1000);

        byte[] wrongPassword = Encoding.UTF8.GetBytes("wrong-password");

        Assert.Throws<CryptographicException>(() =>
            KeyEncoding.ImportEncryptedPkcs8PrivateKey(
                encrypted, wrongPassword, out _, out _));
    }

    // ========================================================================
    // PKCS#12 Round-Trip
    // ========================================================================

    [Test]
    public void Pkcs12RsaRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        byte[] pkcs8 = rsa.ExportPkcs8PrivateKey();

        var name = X509Name.FromString("CN=pkcs12-rsa.example.com, C=US");

        var p = rsa.ExportParameters(true);
        using var rsaKey = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(9001L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .AddBasicConstraints(false)
            .BuildSelfSigned(rsaKey);

        byte[] pfx = Pkcs12.Export(cert, pkcs8, TestPassword, 1000);
        Assert.That(pfx, Is.Not.Empty);

        var (importedCert, importedPkcs8) = Pkcs12.Import(pfx, TestPassword);

        Assert.That(importedCert.RawDer, Is.EqualTo(cert.RawDer));
        Assert.That(importedCert.Subject.ToString(), Is.EqualTo(cert.Subject.ToString()));

        byte[] importedInner = KeyEncoding.ImportPkcs8PrivateKey(
            importedPkcs8, out string algOid, out _);
        Assert.That(algOid, Is.EqualTo("1.2.840.113549.1.1.1"));

        byte[] originalInner = KeyEncoding.ImportPkcs8PrivateKey(
            pkcs8, out _, out _);
        Assert.That(importedInner, Is.EqualTo(originalInner));
    }

    [Test]
    public void Pkcs12EcdsaRoundTrip()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        byte[] pkcs8 = ecdsa.ExportPkcs8PrivateKey();

        var ep = ecdsa.ExportParameters(false);
        string curveOidVal = ep.Curve.Oid!.Value!;

        byte[] pubPoint = new byte[1 + ep.Q.X!.Length + ep.Q.Y!.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(ep.Q.X!, 0, pubPoint, 1, ep.Q.X!.Length);
        Buffer.BlockCopy(ep.Q.Y!, 0, pubPoint, 1 + ep.Q.X!.Length, ep.Q.Y!.Length);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", curveOidVal, pubPoint);

        var name = X509Name.FromString("CN=pkcs12-ecdsa.example.com, C=DE");

        var epPriv = ecdsa.ExportParameters(true);
        byte[] d = epPriv.D!;

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(9002L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(spki)
            .AddBasicConstraints(false)
            .BuildSelfSigned(d, "nistP256");

        byte[] pfx = Pkcs12.Export(cert, pkcs8, TestPassword, 1000);
        var (importedCert, importedPkcs8) = Pkcs12.Import(pfx, TestPassword);

        Assert.That(importedCert.RawDer, Is.EqualTo(cert.RawDer));

        byte[] importedInner = KeyEncoding.ImportPkcs8PrivateKey(
            importedPkcs8, out string algOid, out string? curveOid);
        Assert.That(algOid, Is.EqualTo("1.2.840.10045.2.1"));
        Assert.That(curveOid, Is.EqualTo(curveOidVal));

        byte[] originalInner = KeyEncoding.ImportPkcs8PrivateKey(
            pkcs8, out _, out _);
        Assert.That(importedInner, Is.EqualTo(originalInner));
    }

    // ========================================================================
    // X509Certificate Export
    // ========================================================================

    [Test]
    public void CertExportDer()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=export-der.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(9003L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .BuildSelfSigned(rsaKey);

        byte[] exported = cert.ExportDer();
        Assert.That(exported, Is.EqualTo(cert.RawDer));
        Assert.That(exported, Is.Not.SameAs(cert.RawDer));
    }

    [Test]
    public void CertExportPem()
    {
        using var rsaKey = CreateRsaKey(2048);
        var name = X509Name.FromString("CN=export-pem.example.com, C=US");

        var cert = new X509CertificateBuilder()
            .SetSubject(name)
            .SetIssuer(name)
            .SetSerialNumber(9004L)
            .SetValidity(
                DateTimeOffset.UtcNow.AddDays(-1),
                DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(rsaKey)
            .BuildSelfSigned(rsaKey);

        string pem = cert.ExportPem();
        Assert.That(pem, Does.StartWith("-----BEGIN CERTIFICATE-----"));
        Assert.That(pem, Does.EndWith("-----END CERTIFICATE-----"));

        var parsed = X509CertificateParser.ParsePem(pem);
        Assert.That(parsed.RawDer, Is.EqualTo(cert.RawDer));
        Assert.That(parsed.Subject.ToString(), Is.EqualTo(cert.Subject.ToString()));
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

    private static byte[] BuildEcPkcs8InnerDer(byte[] d, byte[] qx, byte[] qy)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteInteger(1);
        writer.WriteOctetString(d);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(qx, 0, pubPoint, 1, qx.Length);
        Buffer.BlockCopy(qy, 0, pubPoint, 1 + qx.Length, qy.Length);
        writer.WriteBitString(pubPoint);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
        writer.PopSequence();
        return writer.Encode();
    }
}

#endif
