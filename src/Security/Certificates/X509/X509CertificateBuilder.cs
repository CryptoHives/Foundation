// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
#pragma warning disable CS0618 // Type or member is obsolete

namespace CryptoHives.Foundation.Security.Certificates.X509;

using CryptoHives.Foundation.Security.Certificates;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using CryptoHives.Foundation.Security.Cryptography.Rng;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using CH = CryptoHives.Foundation.Security.Cryptography;
using Sys = System.Security.Cryptography;

/// <summary>
/// Builds X.509 v3 certificates using a fluent builder pattern.
/// </summary>
/// <remarks>
/// <para>
/// The builder constructs the TBS (To Be Signed) certificate structure, signs it
/// with the specified private key, and returns a complete <see cref="X509Certificate"/>.
/// </para>
/// <para>
/// Use the static factory methods <see cref="CreateForRsa"/>, <see cref="CreateForEcDsa"/>,
/// <see cref="CreateForEd25519"/>, and <see cref="CreateForEd448"/> for a streamlined
/// experience that auto-generates keys and configures the builder.
/// </para>
/// <para>
/// Time encoding follows RFC 5280 §4.1.2.5: UTCTime for dates before 2050,
/// GeneralizedTime otherwise.
/// </para>
/// <code>
/// // RSA self-signed certificate
/// var cert = X509CertificateBuilder.CreateForRsa(2048)
///     .SetSubject(X509Name.FromString("CN=example.com"))
///     .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
///     .AddBasicConstraints(false)
///     .BuildSelfSigned();
///
/// // Ed25519 self-signed certificate
/// var cert = X509CertificateBuilder.CreateForEd25519()
///     .SetSubject(X509Name.FromString("CN=ed25519.example.com"))
///     .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
///     .BuildSelfSigned();
/// </code>
/// </remarks>
public sealed class X509CertificateBuilder
{
    private X509Name? _subject;
    private X509Name? _issuer;
    private byte[]? _serialNumber;
    private DateTimeOffset _notBefore;
    private DateTimeOffset _notAfter;
    private byte[]? _publicKeySpkiDer;
    private readonly List<X509Extension> _extensions = [];

    // Auto-generated key material (set by factory methods)
    private RsaKeyParameters? _autoRsaKey;
    private byte[]? _autoEcPrivateKey;
    private string? _autoEcCurveName;
    private string? _autoEcHashAlgorithm;
    private byte[]? _autoEdSeed;
    private string? _autoEdAlgorithm; // "Ed25519" or "Ed448"

    // ========================================================================
    // Static Factory Methods
    // ========================================================================

    /// <summary>
    /// Creates a builder with an auto-generated RSA key pair.
    /// </summary>
    /// <param name="keySizeBits">The RSA key size in bits (default: 2048).</param>
    /// <returns>A builder pre-configured with the RSA key.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="keySizeBits"/> is less than 1024.</exception>
    /// <remarks>
    /// The generated key is stored internally. Call <see cref="BuildSelfSigned()"/>
    /// (parameterless) to sign with the auto-generated key.
    /// </remarks>
    public static X509CertificateBuilder CreateForRsa(int keySizeBits = 2048)
    {
        if (keySizeBits < 1024) throw new ArgumentOutOfRangeException(nameof(keySizeBits), "RSA key size must be at least 1024 bits.");

        using var rsa = Sys.RSA.Create();
        rsa.KeySize = keySizeBits;
        var p = rsa.ExportParameters(true);
        var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        var builder = new X509CertificateBuilder();
        builder._autoRsaKey = key;
        builder.SetPublicKey(key);
        return builder;
    }

    /// <summary>
    /// Creates a builder with an auto-generated ECDSA key pair.
    /// </summary>
    /// <param name="curveName">The curve name or OID (e.g., "nistP256", "P-384").</param>
    /// <param name="hashAlgorithm">The hash algorithm for signing (default: auto-selected by curve size).</param>
    /// <returns>A builder pre-configured with the ECDSA key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="curveName"/> is <c>null</c>.</exception>
    /// <exception cref="System.Security.Cryptography.CryptographicException">The curve is not supported.</exception>
    public static X509CertificateBuilder CreateForEcDsa(string curveName, string? hashAlgorithm = null)
    {
        if (curveName is null) throw new ArgumentNullException(nameof(curveName));

        using var ecdsa = new EcDsaCipher(curveName);
        byte[] d = ecdsa.ExportPrivateKey()!;
        var (qx, qy) = ecdsa.ExportPublicKey();

        var curve = EcDsaCipher.ResolveCurve(curveName);
        string curveOid = GetCurveOid(curveName);

        byte[] pubPoint = new byte[1 + qx.Length + qy.Length];
        pubPoint[0] = 0x04;
        Buffer.BlockCopy(qx, 0, pubPoint, 1, qx.Length);
        Buffer.BlockCopy(qy, 0, pubPoint, 1 + qx.Length, qy.Length);
        byte[] spki = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.10045.2.1", curveOid, pubPoint);

        string hash = hashAlgorithm ?? (curve.FieldBits switch {
            <= 256 => "SHA256",
            <= 384 => "SHA384",
            _ => "SHA512",
        });

        var builder = new X509CertificateBuilder();
        builder._autoEcPrivateKey = d;
        builder._autoEcCurveName = curveName;
        builder._autoEcHashAlgorithm = hash;
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    /// <summary>
    /// Creates a builder with an auto-generated Ed25519 key pair (RFC 8032).
    /// </summary>
    /// <returns>A builder pre-configured with the Ed25519 key.</returns>
    public static X509CertificateBuilder CreateForEd25519()
    {
        byte[] seed = new byte[32];
        using var rng = Sys.RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.112");

        var builder = new X509CertificateBuilder();
        builder._autoEdSeed = seed;
        builder._autoEdAlgorithm = "Ed25519";
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    /// <summary>
    /// Creates a builder with an auto-generated Ed448 key pair (RFC 8032).
    /// </summary>
    /// <returns>A builder pre-configured with the Ed448 key.</returns>
    public static X509CertificateBuilder CreateForEd448()
    {
        byte[] seed = new byte[57];
        using var rng = Sys.RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.113");

        var builder = new X509CertificateBuilder();
        builder._autoEdSeed = seed;
        builder._autoEdAlgorithm = "Ed448";
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    /// <summary>
    /// Sets the certificate subject name.
    /// </summary>
    /// <param name="subject">The subject distinguished name.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <c>null</c>.</exception>
    public X509CertificateBuilder SetSubject(X509Name subject)
    {
        _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        return this;
    }

    /// <summary>
    /// Sets the certificate issuer name.
    /// </summary>
    /// <param name="issuer">The issuer distinguished name.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuer"/> is <c>null</c>.</exception>
    public X509CertificateBuilder SetIssuer(X509Name issuer)
    {
        _issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        return this;
    }

    /// <summary>
    /// Sets the certificate serial number.
    /// </summary>
    /// <param name="serial">The serial number bytes.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="serial"/> is <c>null</c>.</exception>
    public X509CertificateBuilder SetSerialNumber(byte[] serial)
    {
        _serialNumber = serial ?? throw new ArgumentNullException(nameof(serial));
        return this;
    }

    /// <summary>
    /// Sets the certificate serial number from a long value.
    /// </summary>
    /// <param name="serial">The serial number.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder SetSerialNumber(long serial)
    {
        // Encode as minimal big-endian bytes
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteInteger(serial);
        byte[] encoded = writer.Encode();
        // Strip the tag and length bytes to get the value
        var reader = new AsnReader(encoded, AsnEncodingRules.DER);
        _serialNumber = reader.ReadIntegerBytes().ToArray();
        return this;
    }

    /// <summary>
    /// Sets the certificate validity period.
    /// </summary>
    /// <param name="notBefore">The earliest valid time.</param>
    /// <param name="notAfter">The latest valid time.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder SetValidity(DateTimeOffset notBefore, DateTimeOffset notAfter)
    {
        _notBefore = notBefore;
        _notAfter = notAfter;
        return this;
    }

    /// <summary>
    /// Sets the certificate's public key from a DER-encoded SubjectPublicKeyInfo.
    /// </summary>
    /// <param name="spkiDer">The SPKI DER bytes.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="spkiDer"/> is <c>null</c>.</exception>
    public X509CertificateBuilder SetPublicKey(byte[] spkiDer)
    {
        _publicKeySpkiDer = spkiDer ?? throw new ArgumentNullException(nameof(spkiDer));
        return this;
    }

    /// <summary>
    /// Sets the certificate's public key from RSA key parameters.
    /// </summary>
    /// <param name="key">The RSA key parameters.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
    public X509CertificateBuilder SetPublicKey(RsaKeyParameters key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        byte[] pkcs1 = KeyEncoding.ExportRsaPublicKey(key);
        _publicKeySpkiDer = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.113549.1.1.1", null, pkcs1);
        return this;
    }

    /// <summary>
    /// Adds a raw extension to the certificate.
    /// </summary>
    /// <param name="oid">The extension OID.</param>
    /// <param name="critical">Whether the extension is critical.</param>
    /// <param name="value">The raw DER extension value.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddExtension(string oid, bool critical, byte[] value)
    {
        _extensions.Add(new X509Extension(oid, critical, value));
        return this;
    }

    /// <summary>
    /// Adds a Basic Constraints extension.
    /// </summary>
    /// <param name="isCA">Whether this certificate is a CA.</param>
    /// <param name="pathLen">The optional path length constraint.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddBasicConstraints(bool isCA, int? pathLen = null)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        if (isCA)
        {
            writer.WriteBoolean(true);
        }

        if (pathLen.HasValue)
        {
            writer.WriteInteger(pathLen.Value);
        }

        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidBasicConstraints, true, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Key Usage extension.
    /// </summary>
    /// <param name="flags">The key usage flags.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddKeyUsage(KeyUsage flags)
    {
        byte raw = 0;
        if (flags.HasFlag(KeyUsage.DigitalSignature))
        {
            raw |= 0x80;
        }

        if (flags.HasFlag(KeyUsage.NonRepudiation))
        {
            raw |= 0x40;
        }

        if (flags.HasFlag(KeyUsage.KeyEncipherment))
        {
            raw |= 0x20;
        }

        if (flags.HasFlag(KeyUsage.DataEncipherment))
        {
            raw |= 0x10;
        }

        if (flags.HasFlag(KeyUsage.KeyAgreement))
        {
            raw |= 0x08;
        }

        if (flags.HasFlag(KeyUsage.KeyCertSign))
        {
            raw |= 0x04;
        }

        if (flags.HasFlag(KeyUsage.CrlSign))
        {
            raw |= 0x02;
        }

        // Count trailing zero bits for unused bits calculation
        int unusedBits = 0;
        byte check = raw;
        while (unusedBits < 7 && (check & 1) == 0)
        {
            unusedBits++;
            check >>= 1;
        }

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteBitString([raw], unusedBits);
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidKeyUsage, true, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Subject Alternative Name extension.
    /// </summary>
    /// <param name="names">The SAN entries.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddSubjectAlternativeName(params (SanType Type, string Value)[] names)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        foreach (var (type, value) in names)
        {
            switch (type)
            {
                case SanType.DnsName:
                    writer.WriteCharacterString(
                        UniversalTagNumber.IA5String, value, new Asn1Tag(TagClass.ContextSpecific, 2));
                    break;
                case SanType.Email:
                    writer.WriteCharacterString(
                        UniversalTagNumber.IA5String, value, new Asn1Tag(TagClass.ContextSpecific, 1));
                    break;
                case SanType.Uri:
                    writer.WriteCharacterString(
                        UniversalTagNumber.IA5String, value, new Asn1Tag(TagClass.ContextSpecific, 6));
                    break;
                case SanType.IpAddress:
                    var ip = System.Net.IPAddress.Parse(value);
                    writer.WriteOctetString(ip.GetAddressBytes(),
                        new Asn1Tag(TagClass.ContextSpecific, 7));
                    break;
            }
        }
        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidSubjectAlternativeName, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Subject Key Identifier extension.
    /// </summary>
    /// <param name="ski">The key identifier bytes.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ski"/> is <c>null</c>.</exception>
    public X509CertificateBuilder AddSubjectKeyIdentifier(byte[] ski)
    {
        if (ski is null) throw new ArgumentNullException(nameof(ski));
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteOctetString(ski);
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidSubjectKeyIdentifier, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds an Extended Key Usage extension.
    /// </summary>
    /// <param name="oids">The EKU purpose OIDs (e.g., <see cref="ExtensionParsers.ExtendedKeyUsage.OidServerAuth"/>).</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oids"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="oids"/> is empty.</exception>
    public X509CertificateBuilder AddExtendedKeyUsage(params string[] oids)
    {
        if (oids is null) throw new ArgumentNullException(nameof(oids));
        if (oids.Length == 0) throw new ArgumentException("At least one EKU OID is required.", nameof(oids));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        foreach (string oid in oids)
        {
            writer.WriteObjectIdentifier(oid);
        }

        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidExtendedKeyUsage, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds an Authority Key Identifier extension.
    /// </summary>
    /// <param name="keyId">The key identifier bytes (typically the SKI of the issuer).</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="keyId"/> is <c>null</c>.</exception>
    public X509CertificateBuilder AddAuthorityKeyIdentifier(byte[] keyId)
    {
        if (keyId is null) throw new ArgumentNullException(nameof(keyId));
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteOctetString(keyId, new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidAuthorityKeyIdentifier, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a CRL Distribution Points extension with URI distribution points.
    /// </summary>
    /// <param name="uris">The CRL distribution point URIs.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uris"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="uris"/> is empty.</exception>
    public X509CertificateBuilder AddCrlDistributionPoint(params string[] uris)
    {
        if (uris is null) throw new ArgumentNullException(nameof(uris));
        if (uris.Length == 0) throw new ArgumentException("At least one URI is required.", nameof(uris));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // CRLDistributionPoints ::= SEQUENCE OF DistributionPoint
        foreach (string uri in uris)
        {
            writer.PushSequence(); // DistributionPoint ::= SEQUENCE
            // distributionPoint [0] DistributionPointName
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            // fullName [0] GeneralNames
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            // uniformResourceIdentifier [6] IA5String
            writer.WriteCharacterString(
                UniversalTagNumber.IA5String, uri, new Asn1Tag(TagClass.ContextSpecific, 6));
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.PopSequence(); // DistributionPoint
        }
        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidCrlDistributionPoints, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds an Authority Information Access extension.
    /// </summary>
    /// <param name="ocspUri">The OCSP responder URI, or <c>null</c> to omit.</param>
    /// <param name="caIssuersUri">The CA Issuers URI, or <c>null</c> to omit.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentException">Both parameters are <c>null</c>.</exception>
    public X509CertificateBuilder AddAuthorityInfoAccess(string? ocspUri = null, string? caIssuersUri = null)
    {
        if (ocspUri is null && caIssuersUri is null)
        {
            throw new ArgumentException("At least one of ocspUri or caIssuersUri must be provided.");
        }

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // AuthorityInfoAccessSyntax ::= SEQUENCE OF AccessDescription

        if (ocspUri is not null)
        {
            writer.PushSequence(); // AccessDescription
            writer.WriteObjectIdentifier("1.3.6.1.5.5.7.48.1"); // id-ad-ocsp
            writer.WriteCharacterString(
                UniversalTagNumber.IA5String, ocspUri, new Asn1Tag(TagClass.ContextSpecific, 6));
            writer.PopSequence();
        }

        if (caIssuersUri is not null)
        {
            writer.PushSequence(); // AccessDescription
            writer.WriteObjectIdentifier("1.3.6.1.5.5.7.48.2"); // id-ad-caIssuers
            writer.WriteCharacterString(
                UniversalTagNumber.IA5String, caIssuersUri, new Asn1Tag(TagClass.ContextSpecific, 6));
            writer.PopSequence();
        }

        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidAuthorityInfoAccess, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Private Key Usage Period extension.
    /// </summary>
    /// <param name="notBefore">Optional private key usage start.</param>
    /// <param name="notAfter">Optional private key usage end.</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddPrivateKeyUsagePeriod(DateTimeOffset? notBefore = null, DateTimeOffset? notAfter = null)
    {
        if (!notBefore.HasValue && !notAfter.HasValue)
        {
            throw new ArgumentException("At least one of notBefore or notAfter must be provided.");
        }

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();

        if (notBefore.HasValue)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.WriteGeneralizedTime(notBefore.Value, true);
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }

        if (notAfter.HasValue)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
            writer.WriteGeneralizedTime(notAfter.Value, true);
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 1, isConstructed: true));
        }

        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidPrivateKeyUsagePeriod, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds an OCSP No Check extension.
    /// </summary>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddOcspNoCheck()
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteNull();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidOcspNoCheck, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a TLS Feature extension.
    /// </summary>
    /// <param name="featureIds">TLS feature identifiers (e.g. status_request=5).</param>
    /// <returns>This builder instance.</returns>
    public X509CertificateBuilder AddTlsFeature(params int[] featureIds)
    {
        if (featureIds is null) throw new ArgumentNullException(nameof(featureIds));
        if (featureIds.Length == 0) throw new ArgumentException("At least one TLS feature identifier is required.", nameof(featureIds));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        foreach (int featureId in featureIds)
        {
            if (featureId < 0) throw new ArgumentOutOfRangeException(nameof(featureIds));
            writer.WriteInteger(featureId);
        }
        writer.PopSequence();

        _extensions.Add(new X509Extension(X509ExtensionCollection.OidTlsFeature, false, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Builds a self-signed certificate using an RSA private key.
    /// </summary>
    /// <param name="privateKey">The RSA private key for signing.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="privateKey"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Certificate BuildSelfSigned(RsaKeyParameters privateKey, string hashAlgorithm = "SHA256")
    {
        if (privateKey is null) throw new ArgumentNullException(nameof(privateKey));

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch {
            "SHA256" => SignatureAlgorithm.OidSha256WithRsa,
            "SHA384" => SignatureAlgorithm.OidSha384WithRsa,
            "SHA512" => SignatureAlgorithm.OidSha512WithRsa,
            "SHA1" => SignatureAlgorithm.OidSha1WithRsa,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        // Auto-set public key from private key if not already set
        if (_publicKeySpkiDer is null)
        {
            SetPublicKey(privateKey);
        }

        byte[] tbsDer = BuildTbs(sigAlgOid);

        // Hash and sign
        byte[] hash = CryptoHelper.HashData(
            AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);

        using var rsa = new RsaCipher(privateKey);
        byte[] signature = rsa.SignPkcs1(hash, hashAlgorithm);

        return BuildCertificate(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a self-signed certificate using an EC private key.
    /// </summary>
    /// <param name="ecPrivateKey">The EC private key scalar (big-endian d value).</param>
    /// <param name="curveName">The curve name or OID.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (e.g., "SHA256").</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ecPrivateKey"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Certificate BuildSelfSigned(ReadOnlySpan<byte> ecPrivateKey, string curveName, string hashAlgorithm = "SHA256")
    {
        if (ecPrivateKey.IsEmpty) throw new ArgumentNullException(nameof(ecPrivateKey));

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch {
            "SHA256" => SignatureAlgorithm.OidEcdsaWithSha256,
            "SHA384" => SignatureAlgorithm.OidEcdsaWithSha384,
            "SHA512" => SignatureAlgorithm.OidEcdsaWithSha512,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] tbsDer = BuildTbs(sigAlgOid);

        // Hash the TBS
        byte[] hash = CryptoHelper.HashData(
            AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);

        // Sign with ECDSA
        var curve = EcDsaCipher.ResolveCurve(curveName);
        var (r, s) = EcDsaCore.Sign(hash, ecPrivateKey, curve, AsnUtils.ToHashAlgorithmName(hashAlgorithm));
        byte[] signature = AsnUtils.EncodeEcdsaSignature(r, s);

        return BuildCertificate(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a self-signed certificate using an Ed25519 private seed (RFC 8032).
    /// </summary>
    /// <param name="seed">The 32-byte Ed25519 private seed.</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="seed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="seed"/> is not 32 bytes.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Certificate BuildSelfSignedEd25519(ReadOnlySpan<byte> seed)
    {
        if (seed.IsEmpty) throw new ArgumentNullException(nameof(seed));
        if (seed.Length != 32) throw new ArgumentException("Ed25519 seed must be 32 bytes.", nameof(seed));

        return BuildSelfSignedEdDsa(seed, SignatureAlgorithm.OidEd25519);
    }

    /// <summary>
    /// Builds a self-signed certificate using an Ed448 private seed (RFC 8032).
    /// </summary>
    /// <param name="seed">The 57-byte Ed448 private seed.</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="seed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="seed"/> is not 57 bytes.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Certificate BuildSelfSignedEd448(ReadOnlySpan<byte> seed)
    {
        if (seed.IsEmpty) throw new ArgumentNullException(nameof(seed));
        if (seed.Length != 57) throw new ArgumentException("Ed448 seed must be 57 bytes.", nameof(seed));

        return BuildSelfSignedEdDsa(seed, SignatureAlgorithm.OidEd448);
    }

    /// <summary>
    /// Builds a self-signed certificate using the key material from a factory method.
    /// </summary>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// No key was configured via a factory method. Use <see cref="CreateForRsa"/>,
    /// <see cref="CreateForEcDsa"/>, <see cref="CreateForEd25519"/>, or <see cref="CreateForEd448"/>.
    /// </exception>
    /// <remarks>
    /// This overload requires the builder to have been created via one of the static
    /// factory methods (<see cref="CreateForRsa"/>, <see cref="CreateForEcDsa"/>,
    /// <see cref="CreateForEd25519"/>, or <see cref="CreateForEd448"/>).
    /// </remarks>
    public X509Certificate BuildSelfSigned()
    {
        if (_autoRsaKey is not null)
        {
            return BuildSelfSigned(_autoRsaKey);
        }

        if (_autoEcPrivateKey is not null && _autoEcCurveName is not null)
        {
            return BuildSelfSigned(_autoEcPrivateKey, _autoEcCurveName, _autoEcHashAlgorithm ?? "SHA256");
        }

        if (_autoEdSeed is not null && _autoEdAlgorithm is not null)
        {
            string oid = _autoEdAlgorithm == "Ed25519"
                ? SignatureAlgorithm.OidEd25519
                : SignatureAlgorithm.OidEd448;
            return BuildSelfSignedEdDsa(_autoEdSeed, oid);
        }

        throw new InvalidOperationException(
            "No key material available. Use CreateForRsa(), CreateForEcDsa(), " +
            "CreateForEd25519(), or CreateForEd448() to create a builder with auto-generated keys, " +
            "or call a BuildSelfSigned overload that accepts key parameters.");
    }

    private byte[] BuildTbs(string sigAlgOid)
    {
        if (_subject is null) throw new InvalidOperationException("Subject is required.");
        if (_publicKeySpkiDer is null) throw new InvalidOperationException("Public key is required.");

        X509Name issuer = _issuer ?? _subject;
        byte[] serial = _serialNumber ?? GenerateRandomSerial();

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();

        // Version [0] EXPLICIT INTEGER (v3 = 2)
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        writer.WriteInteger(2);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));

        // Serial number
        writer.WriteIntegerUnsigned(serial);

        // Signature algorithm
        writer.WriteAlgorithmIdentifier(sigAlgOid);

        // Issuer
        issuer.WriteTo(writer);

        // Validity
        writer.PushSequence();
        writer.WriteTime(_notBefore);
        writer.WriteTime(_notAfter);
        writer.PopSequence();

        // Subject
        _subject.WriteTo(writer);

        // SubjectPublicKeyInfo (raw copy)
        writer.WriteEncodedValue(_publicKeySpkiDer);

        // Auto-compute SKI if not present and this is a CA cert
        bool hasSki = false;
        bool isCA = false;
        foreach (var ext in _extensions)
        {
            if (ext.Oid == X509ExtensionCollection.OidSubjectKeyIdentifier)
            {
                hasSki = true;
            }

            if (ext.Oid == X509ExtensionCollection.OidBasicConstraints)
            {
                var (ca, _) = ExtensionParsers.BasicConstraints.Parse(ext.Value);
                isCA = ca;
            }
        }
        if (isCA && !hasSki && _publicKeySpkiDer is not null)
        {
            byte[] ski = ComputeSubjectKeyIdentifier(_publicKeySpkiDer);
            var skiWriter = new AsnWriter(AsnEncodingRules.DER);
            skiWriter.WriteOctetString(ski);
            _extensions.Add(new X509Extension(X509ExtensionCollection.OidSubjectKeyIdentifier, false, skiWriter.Encode()));
        }

        // Extensions [3] EXPLICIT
        if (_extensions.Count > 0)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 3, isConstructed: true));
            writer.PushSequence();
            foreach (var ext in _extensions)
            {
                writer.PushSequence();
                writer.WriteObjectIdentifier(ext.Oid);
                if (ext.Critical)
                {
                    writer.WriteBoolean(true);
                }

                writer.WriteOctetString(ext.Value.Span);
                writer.PopSequence();
            }
            writer.PopSequence();
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 3, isConstructed: true));
        }

        writer.PopSequence();
        return writer.Encode();
    }

    private X509Certificate BuildCertificate(ReadOnlySpan<byte> tbsDer, string sigAlgOid, ReadOnlySpan<byte> signature)
    {
        // Build outer Certificate SEQUENCE
        var outerWriter = new AsnWriter(AsnEncodingRules.DER);
        outerWriter.PushSequence();
        outerWriter.WriteEncodedValue(tbsDer);
        outerWriter.WriteAlgorithmIdentifier(sigAlgOid);
        outerWriter.WriteBitString(signature);
        outerWriter.PopSequence();

        byte[] rawDer = outerWriter.Encode();
        return X509CertificateParser.ParseDer(rawDer);
    }

    private static byte[] GenerateRandomSerial()
    {
        byte[] serial = new byte[20];
        using var rng = RandomNumberGenerator.Create();
        do
        {
            rng.GetBytes(serial);
            serial[0] &= 0x7F; // ensure positive
        }
        while (serial[0] == 0);

        return serial;
    }

    private X509Certificate BuildSelfSignedEdDsa(ReadOnlySpan<byte> seed, string sigAlgOid)
    {
        // Auto-set public key if not already set
        if (_publicKeySpkiDer is null)
        {
            if (sigAlgOid == SignatureAlgorithm.OidEd25519)
            {
                byte[] pub = new byte[32];
                Ed25519.PublicKeyFromSeed(seed, pub);
                _publicKeySpkiDer = KeyEncoding.ExportEdPublicKey(pub, "1.3.101.112");
            }
            else
            {
                byte[] pub = new byte[57];
                Ed448.PublicKeyFromSeed(seed, pub);
                _publicKeySpkiDer = KeyEncoding.ExportEdPublicKey(pub, "1.3.101.113");
            }
        }

        byte[] tbsDer = BuildTbs(sigAlgOid);

        // EdDSA signs the raw TBS bytes (no pre-hashing)
        byte[] signature = sigAlgOid == SignatureAlgorithm.OidEd25519
            ? Ed25519.Sign(seed, tbsDer)
            : Ed448.Sign(seed, tbsDer);

        return BuildCertificate(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Computes the Subject Key Identifier as the SHA-1 hash of the public key
    /// BIT STRING content per RFC 5280 §4.2.1.2.
    /// </summary>
    private static byte[] ComputeSubjectKeyIdentifier(ReadOnlySpan<byte> spkiDer)
    {
        byte[] publicKeyBytes = KeyEncoding.ImportSubjectPublicKeyInfo(spkiDer, out _, out _);
        using var sha1 = new CH.Hash.SHA1();
        byte[] ski = new byte[20];
        sha1.TryComputeHash(publicKeyBytes, ski, out _);
        return ski;
    }

    /// <summary>
    /// Builds a certificate signed by an RSA issuer key.
    /// </summary>
    /// <param name="issuerKey">The RSA private key of the issuer.</param>
    /// <param name="issuerName">The issuer's distinguished name.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    public X509Certificate BuildSignedRsa(RsaKeyParameters issuerKey, X509Name issuerName, string hashAlgorithm = "SHA256")
    {
        if (issuerKey is null) throw new ArgumentNullException(nameof(issuerKey));
        if (issuerName is null) throw new ArgumentNullException(nameof(issuerName));

        var savedIssuer = _issuer;
        _issuer = issuerName;

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch {
            "SHA256" => SignatureAlgorithm.OidSha256WithRsa,
            "SHA384" => SignatureAlgorithm.OidSha384WithRsa,
            "SHA512" => SignatureAlgorithm.OidSha512WithRsa,
            "SHA1" => SignatureAlgorithm.OidSha1WithRsa,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] tbsDer = BuildTbs(sigAlgOid);
        _issuer = savedIssuer;

        byte[] hash = CryptoHelper.HashData(
            AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);
        using var rsa = new RsaCipher(issuerKey);
        byte[] signature = rsa.SignPkcs1(hash, hashAlgorithm);

        return BuildCertificate(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a certificate signed by an ECDSA issuer key.
    /// </summary>
    /// <param name="issuerPrivateKey">The EC private key scalar (big-endian d value) of the issuer.</param>
    /// <param name="issuerCurveName">The issuer's curve name or OID.</param>
    /// <param name="issuerName">The issuer's distinguished name.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    public X509Certificate BuildSignedEcDsa(ReadOnlySpan<byte> issuerPrivateKey, string issuerCurveName, X509Name issuerName, string hashAlgorithm = "SHA256")
    {
        if (issuerPrivateKey.IsEmpty) throw new ArgumentNullException(nameof(issuerPrivateKey));
        if (issuerName is null) throw new ArgumentNullException(nameof(issuerName));

        var savedIssuer = _issuer;
        _issuer = issuerName;

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch {
            "SHA256" => SignatureAlgorithm.OidEcdsaWithSha256,
            "SHA384" => SignatureAlgorithm.OidEcdsaWithSha384,
            "SHA512" => SignatureAlgorithm.OidEcdsaWithSha512,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] tbsDer = BuildTbs(sigAlgOid);
        _issuer = savedIssuer;

        byte[] hash = CryptoHelper.HashData(
            AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);
        var curve = EcDsaCipher.ResolveCurve(issuerCurveName);
        var (r, s) = EcDsaCore.Sign(hash, issuerPrivateKey, curve, AsnUtils.ToHashAlgorithmName(hashAlgorithm));
        byte[] signature = AsnUtils.EncodeEcdsaSignature(r, s);

        return BuildCertificate(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a certificate signed by an Ed25519 issuer key.
    /// </summary>
    /// <param name="issuerSeed">The 32-byte Ed25519 private seed of the issuer.</param>
    /// <param name="issuerName">The issuer's distinguished name.</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    public X509Certificate BuildSignedEd25519(ReadOnlySpan<byte> issuerSeed, X509Name issuerName)
    {
        if (issuerSeed.IsEmpty) throw new ArgumentNullException(nameof(issuerSeed));
        if (issuerSeed.Length != 32) throw new ArgumentException("Ed25519 seed must be 32 bytes.", nameof(issuerSeed));
        if (issuerName is null) throw new ArgumentNullException(nameof(issuerName));

        var savedIssuer = _issuer;
        _issuer = issuerName;

        byte[] tbsDer = BuildTbs(SignatureAlgorithm.OidEd25519);
        _issuer = savedIssuer;

        byte[] signature = Ed25519.Sign(issuerSeed, tbsDer);
        return BuildCertificate(tbsDer, SignatureAlgorithm.OidEd25519, signature);
    }

    /// <summary>
    /// Builds a certificate signed by an Ed448 issuer key.
    /// </summary>
    /// <param name="issuerSeed">The 57-byte Ed448 private seed of the issuer.</param>
    /// <param name="issuerName">The issuer's distinguished name.</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    public X509Certificate BuildSignedEd448(ReadOnlySpan<byte> issuerSeed, X509Name issuerName)
    {
        if (issuerSeed.IsEmpty) throw new ArgumentNullException(nameof(issuerSeed));
        if (issuerSeed.Length != 57) throw new ArgumentException("Ed448 seed must be 57 bytes.", nameof(issuerSeed));
        if (issuerName is null) throw new ArgumentNullException(nameof(issuerName));

        var savedIssuer = _issuer;
        _issuer = issuerName;

        byte[] tbsDer = BuildTbs(SignatureAlgorithm.OidEd448);
        _issuer = savedIssuer;

        byte[] signature = Ed448.Sign(issuerSeed, tbsDer);
        return BuildCertificate(tbsDer, SignatureAlgorithm.OidEd448, signature);
    }

    /// <summary>
    /// Builds a certificate signed by the key from a factory method, with the specified issuer name.
    /// </summary>
    /// <param name="issuerName">The issuer's distinguished name.</param>
    /// <returns>The built <see cref="X509Certificate"/>.</returns>
    public X509Certificate BuildSigned(X509Name issuerName)
    {
        if (issuerName is null) throw new ArgumentNullException(nameof(issuerName));

        if (_autoRsaKey is not null)
        {
            return BuildSignedRsa(_autoRsaKey, issuerName);
        }

        if (_autoEcPrivateKey is not null && _autoEcCurveName is not null)
        {
            return BuildSignedEcDsa(_autoEcPrivateKey, _autoEcCurveName, issuerName, _autoEcHashAlgorithm ?? "SHA256");
        }

        if (_autoEdSeed is not null && _autoEdAlgorithm is not null)
        {
            if (_autoEdAlgorithm == "Ed25519")
            {
                return BuildSignedEd25519(_autoEdSeed, issuerName);
            }

            // Ed448
            var savedIssuer = _issuer;
            _issuer = issuerName;
            byte[] tbsDer = BuildTbs(SignatureAlgorithm.OidEd448);
            _issuer = savedIssuer;
            byte[] signature = Ed448.Sign(_autoEdSeed, tbsDer);
            return BuildCertificate(tbsDer, SignatureAlgorithm.OidEd448, signature);
        }

        throw new InvalidOperationException("No key material available. Use a factory method or a typed BuildSigned overload.");
    }

    private static string GetCurveOid(string curveName) => curveName switch {
        "nistP256" or "P-256" or "secp256r1" or "prime256v1" or "ECDSA_P256"
            => "1.2.840.10045.3.1.7",
        "nistP384" or "P-384" or "secp384r1" or "ECDSA_P384"
            => "1.3.132.0.34",
        "nistP521" or "P-521" or "secp521r1" or "ECDSA_P521"
            => "1.3.132.0.35",
        "secp256k1" or "secP256k1"
            => "1.3.132.0.10",
        "brainpoolP256r1" or "1.3.36.3.3.2.8.1.1.7"
            => "1.3.36.3.3.2.8.1.1.7",
        "brainpoolP384r1" or "1.3.36.3.3.2.8.1.1.11"
            => "1.3.36.3.3.2.8.1.1.11",
        "brainpoolP512r1" or "1.3.36.3.3.2.8.1.1.13"
            => "1.3.36.3.3.2.8.1.1.13",
        _ => throw new Sys.CryptographicException($"Unknown curve: {curveName}"),
    };
}
