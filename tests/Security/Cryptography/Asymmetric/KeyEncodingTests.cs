// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;
using Org.BouncyCastle.Security;
using BcEd25519Private = Org.BouncyCastle.Crypto.Parameters.Ed25519PrivateKeyParameters;
using BcEd25519Public = Org.BouncyCastle.Crypto.Parameters.Ed25519PublicKeyParameters;
using RsaParams = CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa.RsaKeyParameters;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KeyEncodingTests
{
    // ========================================================================
    // RSA PKCS#1 (RFC 8017)
    // ========================================================================

    [Test]
    public void RsaPublicKeyRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(false);
        using var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        byte[] der = KeyEncoding.ExportRsaPublicKey(key);
        using var imported = KeyEncoding.ImportRsaPublicKey(der);
        byte[] der2 = KeyEncoding.ExportRsaPublicKey(imported);

        Assert.That(der2, Is.EqualTo(der));
    }

    [Test]
    public void RsaPrivateKeyRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] der = KeyEncoding.ExportRsaPrivateKey(key);
        using var imported = KeyEncoding.ImportRsaPrivateKey(der);
        byte[] der2 = KeyEncoding.ExportRsaPrivateKey(imported);

        Assert.That(der2, Is.EqualTo(der));
        Assert.That(imported.HasPrivateKey, Is.True);
    }

    [Test]
    public void RsaPublicKeyInteropWithBcl()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(false);
        using var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        byte[] ourDer = KeyEncoding.ExportRsaPublicKey(key);
        byte[] bclDer = rsa.ExportRSAPublicKey();

        Assert.That(ourDer, Is.EqualTo(bclDer));
    }

    [Test]
    public void RsaPrivateKeyInteropWithBcl()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] ourDer = KeyEncoding.ExportRsaPrivateKey(key);
        byte[] bclDer = rsa.ExportRSAPrivateKey();

        Assert.That(ourDer, Is.EqualTo(bclDer));
    }

    // ========================================================================
    // RSA SPKI / PKCS#8
    // ========================================================================

    [Test]
    public void RsaSpkiRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(false);
        using var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        byte[] pkcs1 = KeyEncoding.ExportRsaPublicKey(key);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.113549.1.1.1", null, pkcs1);

        byte[] pkcs1Back = KeyEncoding.ImportSubjectPublicKeyInfo(
            spki, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.113549.1.1.1"));
        Assert.That(curveOid, Is.Null);
        Assert.That(pkcs1Back, Is.EqualTo(pkcs1));
    }

    [Test]
    public void RsaPkcs8RoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] pkcs1Priv = KeyEncoding.ExportRsaPrivateKey(key);
        byte[] pkcs8 = KeyEncoding.ExportPkcs8PrivateKey("1.2.840.113549.1.1.1", null, pkcs1Priv);

        byte[] pkcs1Back = KeyEncoding.ImportPkcs8PrivateKey(
            pkcs8, out string algOid, out string? curveOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.113549.1.1.1"));
        Assert.That(curveOid, Is.Null);
        Assert.That(pkcs1Back, Is.EqualTo(pkcs1Priv));
    }

    [Test]
    public void RsaSpkiInteropWithBcl()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(false);
        using var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        byte[] pkcs1 = KeyEncoding.ExportRsaPublicKey(key);
        byte[] ourSpki = KeyEncoding.ExportSubjectPublicKeyInfo(
            "1.2.840.113549.1.1.1", null, pkcs1);
        byte[] bclSpki = rsa.ExportSubjectPublicKeyInfo();

        Assert.That(ourSpki, Is.EqualTo(bclSpki));
    }

    [Test]
    public void RsaPkcs8InteropWithBcl()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] pkcs1Priv = KeyEncoding.ExportRsaPrivateKey(key);
        byte[] ourPkcs8 = KeyEncoding.ExportPkcs8PrivateKey(
            "1.2.840.113549.1.1.1", null, pkcs1Priv);
        byte[] bclPkcs8 = rsa.ExportPkcs8PrivateKey();

        Assert.That(ourPkcs8, Is.EqualTo(bclPkcs8));
    }

    // ========================================================================
    // EC Weierstrass (RFC 5915)
    // ========================================================================

    [Test]
    public void EcPrivateKeyRoundTrip()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(true);
        string curveOid = ep.Curve.Oid!.Value!;

        byte[] der = KeyEncoding.ExportEcPrivateKey(ep.D!, ep.Q.X!, ep.Q.Y!, curveOid);
        var (d, qx, qy) = KeyEncoding.ImportEcPrivateKey(der, out string oid);

        Assert.That(oid, Is.EqualTo(curveOid));
        Assert.That(d, Is.EqualTo(ep.D));
        Assert.That(qx, Is.EqualTo(ep.Q.X));
        Assert.That(qy, Is.EqualTo(ep.Q.Y));
    }

    [Test]
    public void EcSpkiRoundTrip()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(false);
        string curveOid = ep.Curve.Oid!.Value!;

        byte[] pubPoint = BuildUncompressedPoint(ep.Q.X!, ep.Q.Y!);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo(
            "1.2.840.10045.2.1", curveOid, pubPoint);

        byte[] pubBack = KeyEncoding.ImportSubjectPublicKeyInfo(
            spki, out string algOid, out string? cOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.10045.2.1"));
        Assert.That(cOid, Is.EqualTo(curveOid));
        Assert.That(pubBack, Is.EqualTo(pubPoint));
    }

    [Test]
    public void EcPkcs8RoundTrip()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(true);
        string curveOid = ep.Curve.Oid!.Value!;

        byte[] innerDer = BuildEcPkcs8InnerDer(ep.D!, ep.Q.X!, ep.Q.Y!);
        byte[] pkcs8 = KeyEncoding.ExportPkcs8PrivateKey(
            "1.2.840.10045.2.1", curveOid, innerDer);

        byte[] innerBack = KeyEncoding.ImportPkcs8PrivateKey(
            pkcs8, out string algOid, out string? cOid);

        Assert.That(algOid, Is.EqualTo("1.2.840.10045.2.1"));
        Assert.That(cOid, Is.EqualTo(curveOid));
        Assert.That(innerBack, Is.EqualTo(innerDer));
    }

    [Test]
    public void EcSpkiInteropWithBcl()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(false);
        string curveOid = ep.Curve.Oid!.Value!;

        byte[] pubPoint = BuildUncompressedPoint(ep.Q.X!, ep.Q.Y!);
        byte[] ourSpki = KeyEncoding.ExportSubjectPublicKeyInfo(
            "1.2.840.10045.2.1", curveOid, pubPoint);
        byte[] bclSpki = ecdsa.ExportSubjectPublicKeyInfo();

        Assert.That(ourSpki, Is.EqualTo(bclSpki));
    }

    [Test]
    public void EcPkcs8InteropWithBcl()
    {
        using var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var ep = ecdsa.ExportParameters(true);
        string curveOid = ep.Curve.Oid!.Value!;

        byte[] innerDer = BuildEcPkcs8InnerDer(ep.D!, ep.Q.X!, ep.Q.Y!);
        byte[] ourPkcs8 = KeyEncoding.ExportPkcs8PrivateKey(
            "1.2.840.10045.2.1", curveOid, innerDer);
        byte[] bclPkcs8 = ecdsa.ExportPkcs8PrivateKey();

        Assert.That(ourPkcs8, Is.EqualTo(bclPkcs8));
    }

    // ========================================================================
    // Edwards / Montgomery Curves (RFC 8410)
    // ========================================================================

    [Test]
    public void Ed25519SpkiRoundTrip()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed25519.PublicKeySize];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(pubKey, "1.3.101.112");
        byte[] imported = KeyEncoding.ImportEdPublicKey(spki, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.112"));
        Assert.That(imported, Is.EqualTo(pubKey));
    }

    [Test]
    public void Ed25519Pkcs8RoundTrip()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed25519.PublicKeySize];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.112");
        byte[] importedSeed = KeyEncoding.ImportEdPrivateKey(pkcs8, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.112"));
        Assert.That(importedSeed, Is.EqualTo(seed));

        byte[] derivedPub = new byte[Ed25519.PublicKeySize];
        Ed25519.PublicKeyFromSeed(importedSeed, derivedPub);
        Assert.That(derivedPub, Is.EqualTo(pubKey));
    }

    [Test]
    public void Ed448SpkiRoundTrip()
    {
        byte[] seed = new byte[Ed448.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed448.PublicKeySize];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(pubKey, "1.3.101.113");
        byte[] imported = KeyEncoding.ImportEdPublicKey(spki, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.113"));
        Assert.That(imported, Is.EqualTo(pubKey));
    }

    [Test]
    public void Ed448Pkcs8RoundTrip()
    {
        byte[] seed = new byte[Ed448.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed448.PublicKeySize];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.113");
        byte[] importedSeed = KeyEncoding.ImportEdPrivateKey(pkcs8, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.113"));
        Assert.That(importedSeed, Is.EqualTo(seed));

        byte[] derivedPub = new byte[Ed448.PublicKeySize];
        Ed448.PublicKeyFromSeed(importedSeed, derivedPub);
        Assert.That(derivedPub, Is.EqualTo(pubKey));
    }

    [Test]
    public void X25519SpkiRoundTrip()
    {
        byte[] privateKey = new byte[X25519.KeySize];
        RandomNumberGenerator.Fill(privateKey);
        byte[] publicKey = new byte[X25519.KeySize];
        X25519.ScalarMultBase(privateKey, publicKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.110");
        byte[] imported = KeyEncoding.ImportEdPublicKey(spki, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.110"));
        Assert.That(imported, Is.EqualTo(publicKey));
    }

    [Test]
    public void X25519Pkcs8RoundTrip()
    {
        byte[] privateKey = new byte[X25519.KeySize];
        RandomNumberGenerator.Fill(privateKey);
        byte[] publicKey = new byte[X25519.KeySize];
        X25519.ScalarMultBase(privateKey, publicKey);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(privateKey, "1.3.101.110");
        byte[] importedKey = KeyEncoding.ImportEdPrivateKey(pkcs8, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.110"));
        Assert.That(importedKey, Is.EqualTo(privateKey));

        byte[] derivedPub = new byte[X25519.KeySize];
        X25519.ScalarMultBase(importedKey, derivedPub);
        Assert.That(derivedPub, Is.EqualTo(publicKey));
    }

    [Test]
    public void X448SpkiRoundTrip()
    {
        byte[] privateKey = new byte[X448.KeySize];
        RandomNumberGenerator.Fill(privateKey);
        byte[] publicKey = new byte[X448.KeySize];
        X448.ScalarMultBase(privateKey, publicKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.111");
        byte[] imported = KeyEncoding.ImportEdPublicKey(spki, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.111"));
        Assert.That(imported, Is.EqualTo(publicKey));
    }

    [Test]
    public void X448Pkcs8RoundTrip()
    {
        byte[] privateKey = new byte[X448.KeySize];
        RandomNumberGenerator.Fill(privateKey);
        byte[] publicKey = new byte[X448.KeySize];
        X448.ScalarMultBase(privateKey, publicKey);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(privateKey, "1.3.101.111");
        byte[] importedKey = KeyEncoding.ImportEdPrivateKey(pkcs8, out string oid);

        Assert.That(oid, Is.EqualTo("1.3.101.111"));
        Assert.That(importedKey, Is.EqualTo(privateKey));

        byte[] derivedPub = new byte[X448.KeySize];
        X448.ScalarMultBase(importedKey, derivedPub);
        Assert.That(derivedPub, Is.EqualTo(publicKey));
    }

    [Test]
    public void Ed25519SpkiInteropWithBouncyCastle()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed25519.PublicKeySize];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(pubKey, "1.3.101.112");

        var bcPub = PublicKeyFactory.CreateKey(spki)
            as BcEd25519Public;

        Assert.That(bcPub, Is.Not.Null);
        Assert.That(bcPub!.GetEncoded(), Is.EqualTo(pubKey));
    }

    [Test]
    public void Ed25519Pkcs8InteropWithBouncyCastle()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);

        byte[] pkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.112");

        var bcPriv = PrivateKeyFactory.CreateKey(pkcs8)
            as BcEd25519Private;

        Assert.That(bcPriv, Is.Not.Null);
        Assert.That(bcPriv!.GetEncoded(), Is.EqualTo(seed));
    }

    // ========================================================================
    // PEM (RFC 7468)
    // ========================================================================

    [Test]
    public void PemRsaPublicKeyRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(false);
        using var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        byte[] der = KeyEncoding.ExportRsaPublicKey(key);
        string pem = KeyEncoding.ExportPem(der, "RSA PUBLIC KEY");
        byte[] derBack = KeyEncoding.ImportPem(pem, out string label);

        Assert.That(label, Is.EqualTo("RSA PUBLIC KEY"));
        Assert.That(derBack, Is.EqualTo(der));
    }

    [Test]
    public void PemRsaPrivateKeyRoundTrip()
    {
        using var rsa = RSA.Create(2048);
        var p = rsa.ExportParameters(true);
        using var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] der = KeyEncoding.ExportRsaPrivateKey(key);
        string pem = KeyEncoding.ExportPem(der, "RSA PRIVATE KEY");
        byte[] derBack = KeyEncoding.ImportPem(pem, out string label);

        Assert.That(label, Is.EqualTo("RSA PRIVATE KEY"));
        Assert.That(derBack, Is.EqualTo(der));
    }

    [Test]
    public void PemEd25519PublicKeyRoundTrip()
    {
        byte[] seed = new byte[Ed25519.SeedSize];
        RandomNumberGenerator.Fill(seed);
        byte[] pubKey = new byte[Ed25519.PublicKeySize];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] spki = KeyEncoding.ExportEdPublicKey(pubKey, "1.3.101.112");
        string pem = KeyEncoding.ExportPem(spki, "PUBLIC KEY");
        byte[] spkiBack = KeyEncoding.ImportPem(pem, out string label);

        Assert.That(label, Is.EqualTo("PUBLIC KEY"));
        Assert.That(spkiBack, Is.EqualTo(spki));
    }

    // ========================================================================
    // RFC 8410 Test Vector
    // ========================================================================

    [Test]
    public void Ed25519Rfc8410TestVector()
    {
        // RFC 8410 §10.3 — Ed25519 private key (without public key)
        const string pkcs8Pem =
            "-----BEGIN PRIVATE KEY-----\n" +
            "MC4CAQAwBQYDK2VwBCIEINTuctv5E1hK1bbY8fdp+K06/nwoy/HU++CXqI9EdVhC\n" +
            "-----END PRIVATE KEY-----";

        // RFC 8410 §10.1 — corresponding public key
        const string spkiPem =
            "-----BEGIN PUBLIC KEY-----\n" +
            "MCowBQYDK2VwAyEAGb9ECWmEzf6FQbrBZ9w7lshQhqowtrbLDFw4rXAxZuE=\n" +
            "-----END PUBLIC KEY-----";

        byte[] pkcs8Der = KeyEncoding.ImportPem(pkcs8Pem, out string privLabel);
        Assert.That(privLabel, Is.EqualTo("PRIVATE KEY"));

        byte[] seed = KeyEncoding.ImportEdPrivateKey(pkcs8Der, out string privOid);
        Assert.That(privOid, Is.EqualTo("1.3.101.112"));
        Assert.That(seed, Has.Length.EqualTo(32));

        byte[] spkiDer = KeyEncoding.ImportPem(spkiPem, out string pubLabel);
        Assert.That(pubLabel, Is.EqualTo("PUBLIC KEY"));

        byte[] pubKey = KeyEncoding.ImportEdPublicKey(spkiDer, out string pubOid);
        Assert.That(pubOid, Is.EqualTo("1.3.101.112"));
        Assert.That(pubKey, Has.Length.EqualTo(32));

        // Derive public key from seed and verify it matches the RFC vector
        byte[] derivedPub = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, derivedPub);
        Assert.That(derivedPub, Is.EqualTo(pubKey));

        // Round-trip: re-export and verify DER matches
        byte[] reExportedPkcs8 = KeyEncoding.ExportEdPrivateKey(seed, "1.3.101.112");
        Assert.That(reExportedPkcs8, Is.EqualTo(pkcs8Der));

        byte[] reExportedSpki = KeyEncoding.ExportEdPublicKey(pubKey, "1.3.101.112");
        Assert.That(reExportedSpki, Is.EqualTo(spkiDer));
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static byte[] BuildUncompressedPoint(byte[] qx, byte[] qy)
    {
        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        qx.CopyTo(pubPoint, 1);
        qy.CopyTo(pubPoint, 1 + qx.Length);
        return pubPoint;
    }

    private static byte[] BuildEcPkcs8InnerDer(byte[] d, byte[] qx, byte[] qy)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteInteger(1);
        writer.WriteOctetString(d);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
        writer.WriteBitString(BuildUncompressedPoint(qx, qy));
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 1));
        writer.PopSequence();
        return writer.Encode();
    }
}

#endif
