// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

/// <summary>
/// Builds X.509 v2 Certificate Revocation Lists using a fluent builder pattern.
/// </summary>
/// <remarks>
/// <para>
/// The builder constructs the TBSCertList structure, signs it
/// with the specified private key, and returns a complete <see cref="X509Crl"/>.
/// </para>
/// <para>
/// Time encoding follows RFC 5280 §4.1.2.5: UTCTime for dates before 2050,
/// GeneralizedTime otherwise.
/// </para>
/// <code>
/// var crl = new X509CrlBuilder()
///     .SetIssuer(caName)
///     .SetThisUpdate(DateTimeOffset.UtcNow)
///     .SetNextUpdate(DateTimeOffset.UtcNow.AddDays(30))
///     .AddRevokedCertificate(cert.SerialNumber, DateTimeOffset.UtcNow, CrlReason.KeyCompromise)
///     .BuildSignedRsa(caKey);
/// </code>
/// </remarks>
public sealed class X509CrlBuilder
{
    private X509Name? _issuer;
    private DateTimeOffset _thisUpdate;
    private DateTimeOffset? _nextUpdate;
    private readonly List<RevokedCertificate> _revokedCertificates = [];
    private readonly List<X509Extension> _extensions = [];

    /// <summary>
    /// Sets the CRL issuer name.
    /// </summary>
    /// <param name="issuer">The issuer distinguished name.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuer"/> is <c>null</c>.</exception>
    public X509CrlBuilder SetIssuer(X509Name issuer)
    {
        _issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        return this;
    }

    /// <summary>
    /// Sets the thisUpdate time for the CRL.
    /// </summary>
    /// <param name="thisUpdate">The date and time this CRL was issued.</param>
    /// <returns>This builder instance.</returns>
    public X509CrlBuilder SetThisUpdate(DateTimeOffset thisUpdate)
    {
        _thisUpdate = thisUpdate;
        return this;
    }

    /// <summary>
    /// Sets the nextUpdate time for the CRL.
    /// </summary>
    /// <param name="nextUpdate">The date and time the next CRL is expected.</param>
    /// <returns>This builder instance.</returns>
    public X509CrlBuilder SetNextUpdate(DateTimeOffset nextUpdate)
    {
        _nextUpdate = nextUpdate;
        return this;
    }

    /// <summary>
    /// Adds a revoked certificate entry by serial number.
    /// </summary>
    /// <param name="serialNumber">The serial number of the revoked certificate.</param>
    /// <param name="revocationDate">The date and time of revocation.</param>
    /// <param name="reason">The revocation reason code.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="serialNumber"/> is <c>null</c>.</exception>
    public X509CrlBuilder AddRevokedCertificate(byte[] serialNumber, DateTimeOffset revocationDate, CrlReason reason = CrlReason.Unspecified)
    {
        if (serialNumber is null) throw new ArgumentNullException(nameof(serialNumber));
        _revokedCertificates.Add(new RevokedCertificate(serialNumber, revocationDate, reason));
        return this;
    }

    /// <summary>
    /// Adds a revoked certificate entry by certificate reference.
    /// </summary>
    /// <param name="certificate">The certificate to revoke.</param>
    /// <param name="revocationDate">The date and time of revocation.</param>
    /// <param name="reason">The revocation reason code.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="certificate"/> is <c>null</c>.</exception>
    public X509CrlBuilder AddRevokedCertificate(X509Certificate certificate, DateTimeOffset revocationDate, CrlReason reason = CrlReason.Unspecified)
    {
        if (certificate is null) throw new ArgumentNullException(nameof(certificate));
        return AddRevokedCertificate(certificate.SerialNumber, revocationDate, reason);
    }

    /// <summary>
    /// Adds a raw extension to the CRL.
    /// </summary>
    /// <param name="oid">The extension OID.</param>
    /// <param name="critical">Whether the extension is critical.</param>
    /// <param name="value">The raw DER extension value.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oid"/> or <paramref name="value"/> is <c>null</c>.</exception>
    public X509CrlBuilder AddExtension(string oid, bool critical, byte[] value)
    {
        if (oid is null) throw new ArgumentNullException(nameof(oid));
        if (value is null) throw new ArgumentNullException(nameof(value));
        _extensions.Add(new X509Extension(oid, critical, value));
        return this;
    }

    /// <summary>
    /// Adds an Issuing Distribution Point extension.
    /// </summary>
    /// <param name="distributionPointUris">Distribution point URIs for this issuing point.</param>
    /// <param name="indirectCrl">Whether this CRL is an indirect CRL.</param>
    /// <returns>This builder instance.</returns>
    public X509CrlBuilder AddIssuingDistributionPoint(string[]? distributionPointUris = null, bool indirectCrl = false)
    {
        bool hasUris = distributionPointUris is { Length: > 0 };
        if (!hasUris && !indirectCrl)
        {
            throw new ArgumentException("At least one distribution point URI or indirectCRL flag is required.");
        }

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();

        if (hasUris)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            foreach (string uri in distributionPointUris!)
            {
                if (string.IsNullOrWhiteSpace(uri)) continue;
                writer.WriteCharacterString(UniversalTagNumber.IA5String, uri, new Asn1Tag(TagClass.ContextSpecific, 6));
            }
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }

        if (indirectCrl)
        {
            writer.WriteBoolean(true, new Asn1Tag(TagClass.ContextSpecific, 4));
        }

        writer.PopSequence();
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidIssuingDistributionPoint, true, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Delta CRL Indicator extension.
    /// </summary>
    /// <param name="baseCrlNumber">The base CRL number this delta applies to.</param>
    /// <returns>This builder instance.</returns>
    public X509CrlBuilder AddDeltaCrlIndicator(long baseCrlNumber)
    {
        if (baseCrlNumber < 0) throw new ArgumentOutOfRangeException(nameof(baseCrlNumber));

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteInteger(baseCrlNumber);
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidDeltaCrlIndicator, true, writer.Encode()));
        return this;
    }

    // ========================================================================
    // Build Methods
    // ========================================================================

    /// <summary>
    /// Builds a CRL signed with an RSA private key.
    /// </summary>
    /// <param name="issuerKey">The RSA private key for signing.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509Crl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuerKey"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Crl BuildSignedRsa(RsaKeyParameters issuerKey, string hashAlgorithm = "SHA256")
    {
        if (issuerKey is null) throw new ArgumentNullException(nameof(issuerKey));

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA256" => SignatureAlgorithm.OidSha256WithRsa,
            "SHA384" => SignatureAlgorithm.OidSha384WithRsa,
            "SHA512" => SignatureAlgorithm.OidSha512WithRsa,
            "SHA1" => SignatureAlgorithm.OidSha1WithRsa,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] tbsDer = BuildTbsCertList(sigAlgOid);
        byte[] hash = CryptoHelper.HashData(AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);
        using var rsa = new RsaCipher(issuerKey);
        byte[] signature = rsa.SignPkcs1(hash, hashAlgorithm);

        return BuildCrl(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a CRL signed with an ECDSA private key.
    /// </summary>
    /// <param name="issuerPrivateKey">The EC private key scalar (big-endian d value).</param>
    /// <param name="curveName">The curve name or OID.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509Crl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuerPrivateKey"/> is <c>null</c>.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Crl BuildSignedEcDsa(byte[] issuerPrivateKey, string curveName, string hashAlgorithm = "SHA256")
    {
        if (issuerPrivateKey is null) throw new ArgumentNullException(nameof(issuerPrivateKey));

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA256" => SignatureAlgorithm.OidEcdsaWithSha256,
            "SHA384" => SignatureAlgorithm.OidEcdsaWithSha384,
            "SHA512" => SignatureAlgorithm.OidEcdsaWithSha512,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] tbsDer = BuildTbsCertList(sigAlgOid);
        byte[] hash = CryptoHelper.HashData(AsnUtils.ToHashAlgorithmName(hashAlgorithm), tbsDer);
        var curve = EcDsaCipher.ResolveCurve(curveName);
        var (r, s) = EcDsaCore.Sign(hash, issuerPrivateKey, curve, AsnUtils.ToHashAlgorithmName(hashAlgorithm));
        byte[] signature = AsnUtils.EncodeEcdsaSignature(r, s);

        return BuildCrl(tbsDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a CRL signed with an Ed25519 private seed.
    /// </summary>
    /// <param name="issuerSeed">The 32-byte Ed25519 private seed.</param>
    /// <returns>The built <see cref="X509Crl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuerSeed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="issuerSeed"/> is not 32 bytes.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Crl BuildSignedEd25519(byte[] issuerSeed)
    {
        if (issuerSeed is null) throw new ArgumentNullException(nameof(issuerSeed));
        if (issuerSeed.Length != 32) throw new ArgumentException("Ed25519 seed must be 32 bytes.", nameof(issuerSeed));

        byte[] tbsDer = BuildTbsCertList(SignatureAlgorithm.OidEd25519);
        byte[] signature = Ed25519.Sign(issuerSeed, tbsDer);

        return BuildCrl(tbsDer, SignatureAlgorithm.OidEd25519, signature);
    }

    /// <summary>
    /// Builds a CRL signed with an Ed448 private seed.
    /// </summary>
    /// <param name="issuerSeed">The 57-byte Ed448 private seed.</param>
    /// <returns>The built <see cref="X509Crl"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="issuerSeed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="issuerSeed"/> is not 57 bytes.</exception>
    /// <exception cref="InvalidOperationException">Required fields are not set.</exception>
    public X509Crl BuildSignedEd448(byte[] issuerSeed)
    {
        if (issuerSeed is null) throw new ArgumentNullException(nameof(issuerSeed));
        if (issuerSeed.Length != 57) throw new ArgumentException("Ed448 seed must be 57 bytes.", nameof(issuerSeed));

        byte[] tbsDer = BuildTbsCertList(SignatureAlgorithm.OidEd448);
        byte[] signature = Ed448.Sign(issuerSeed, tbsDer);

        return BuildCrl(tbsDer, SignatureAlgorithm.OidEd448, signature);
    }

    // ========================================================================
    // Private Helpers
    // ========================================================================

    private byte[] BuildTbsCertList(string sigAlgOid)
    {
        if (_issuer is null) throw new InvalidOperationException("Issuer is required.");

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();

        // Version INTEGER (v2 = 1)
        writer.WriteInteger(1);

        // Signature AlgorithmIdentifier
        writer.WriteAlgorithmIdentifier(sigAlgOid);

        // Issuer
        _issuer.WriteTo(writer);

        // thisUpdate Time
        writer.WriteTime(_thisUpdate);

        // nextUpdate Time OPTIONAL
        if (_nextUpdate.HasValue)
            writer.WriteTime(_nextUpdate.Value);

        // revokedCertificates SEQUENCE OF SEQUENCE OPTIONAL
        if (_revokedCertificates.Count > 0)
        {
            writer.PushSequence();
            foreach (var entry in _revokedCertificates)
            {
                writer.PushSequence();

                // userCertificate CertificateSerialNumber (INTEGER)
                writer.WriteIntegerUnsigned(AsnUtils.TrimLeadingZeros(entry.SerialNumber));

                // revocationDate Time
                writer.WriteTime(entry.RevocationDate);

                // crlEntryExtensions Extensions OPTIONAL
                if (entry.Reason != CrlReason.Unspecified)
                {
                    writer.PushSequence(); // Extensions
                    writer.PushSequence(); // Extension

                    writer.WriteObjectIdentifier(X509CrlParser.OidCrlReason);

                    // OCTET STRING wrapping ENUMERATED
                    var reasonWriter = new AsnWriter(AsnEncodingRules.DER);
                    reasonWriter.WriteEnumeratedValue(entry.Reason);
                    writer.WriteOctetString(reasonWriter.Encode());

                    writer.PopSequence(); // Extension
                    writer.PopSequence(); // Extensions
                }

                writer.PopSequence();
            }
            writer.PopSequence();
        }

        // crlExtensions [0] EXPLICIT Extensions OPTIONAL
        if (_extensions.Count > 0)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
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
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }

        writer.PopSequence();
        return writer.Encode();
    }

    private static X509Crl BuildCrl(byte[] tbsDer, string sigAlgOid, byte[] signature)
    {
        var outerWriter = new AsnWriter(AsnEncodingRules.DER);
        outerWriter.PushSequence();
        outerWriter.WriteEncodedValue(tbsDer);
        outerWriter.WriteAlgorithmIdentifier(sigAlgOid);
        outerWriter.WriteBitString(signature);
        outerWriter.PopSequence();

        byte[] rawDer = outerWriter.Encode();
        return X509CrlParser.ParseDer(rawDer);
    }
}
