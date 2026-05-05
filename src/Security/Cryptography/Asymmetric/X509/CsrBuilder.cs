// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

/// <summary>
/// Builds PKCS#10 Certificate Signing Requests using a fluent builder pattern.
/// </summary>
/// <remarks>
/// <para>
/// The builder constructs the CertificationRequestInfo structure, signs it
/// with the specified private key, and returns a complete <see cref="X509CertificateSigningRequest"/>.
/// </para>
/// <para>
/// Use the static factory methods <see cref="CreateForRsa"/>, <see cref="CreateForEcDsa"/>,
/// <see cref="CreateForEd25519"/>, and <see cref="CreateForEd448"/> for a streamlined
/// experience that auto-generates keys and configures the builder.
/// </para>
/// <code>
/// // RSA CSR
/// var csr = CsrBuilder.CreateForRsa(2048)
///     .SetSubject(X509Name.FromString("CN=example.com"))
///     .AddSubjectAlternativeName((SanType.DnsName, "example.com"))
///     .Build();
///
/// // Ed25519 CSR
/// var csr = CsrBuilder.CreateForEd25519()
///     .SetSubject(X509Name.FromString("CN=ed25519.example.com"))
///     .Build();
/// </code>
/// </remarks>
public sealed class CsrBuilder
{
    private X509Name? _subject;
    private byte[]? _publicKeySpkiDer;
    private readonly List<X509Extension> _extensions = [];

    private RsaKeyParameters? _autoRsaKey;
    private byte[]? _autoEcPrivateKey;
    private string? _autoEcCurveName;
    private string? _autoEcHashAlgorithm;
    private byte[]? _autoEdSeed;
    private string? _autoEdAlgorithm;

    // ========================================================================
    // Static Factory Methods
    // ========================================================================

    /// <summary>
    /// Creates a builder with an auto-generated RSA key pair.
    /// </summary>
    /// <param name="keySizeBits">The RSA key size in bits (default: 2048).</param>
    /// <returns>A builder pre-configured with the RSA key.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="keySizeBits"/> is less than 1024.</exception>
    public static CsrBuilder CreateForRsa(int keySizeBits = 2048)
    {
        if (keySizeBits < 1024) throw new ArgumentOutOfRangeException(nameof(keySizeBits), "RSA key size must be at least 1024 bits.");

        using var rsa = RSA.Create();
        rsa.KeySize = keySizeBits;
        var p = rsa.ExportParameters(true);
        var key = new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        var builder = new CsrBuilder();
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
    public static CsrBuilder CreateForEcDsa(string curveName, string? hashAlgorithm = null)
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

        string hash = hashAlgorithm ?? (curve.FieldBits switch
        {
            <= 256 => "SHA256",
            <= 384 => "SHA384",
            _ => "SHA512",
        });

        var builder = new CsrBuilder();
        builder._autoEcPrivateKey = d;
        builder._autoEcCurveName = curveName;
        builder._autoEcHashAlgorithm = hash;
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    /// <summary>
    /// Creates a builder with an auto-generated Ed25519 key pair.
    /// </summary>
    /// <returns>A builder pre-configured with the Ed25519 key.</returns>
    public static CsrBuilder CreateForEd25519()
    {
        byte[] seed = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.112");

        var builder = new CsrBuilder();
        builder._autoEdSeed = seed;
        builder._autoEdAlgorithm = "Ed25519";
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    /// <summary>
    /// Creates a builder with an auto-generated Ed448 key pair.
    /// </summary>
    /// <returns>A builder pre-configured with the Ed448 key.</returns>
    public static CsrBuilder CreateForEd448()
    {
        byte[] seed = new byte[57];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        byte[] publicKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, publicKey);
        byte[] spki = KeyEncoding.ExportEdPublicKey(publicKey, "1.3.101.113");

        var builder = new CsrBuilder();
        builder._autoEdSeed = seed;
        builder._autoEdAlgorithm = "Ed448";
        builder._publicKeySpkiDer = spki;
        return builder;
    }

    // ========================================================================
    // Fluent Setters
    // ========================================================================

    /// <summary>
    /// Sets the CSR subject name.
    /// </summary>
    /// <param name="subject">The subject distinguished name.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <c>null</c>.</exception>
    public CsrBuilder SetSubject(X509Name subject)
    {
        _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        return this;
    }

    /// <summary>
    /// Sets the public key from an RSA key.
    /// </summary>
    /// <param name="key">The RSA key parameters.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
    public CsrBuilder SetPublicKey(RsaKeyParameters key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        byte[] pkcs1 = KeyEncoding.ExportRsaPublicKey(key);
        _publicKeySpkiDer = KeyEncoding.ExportSubjectPublicKeyInfo("1.2.840.113549.1.1.1", null, pkcs1);
        return this;
    }

    /// <summary>
    /// Sets the public key from raw DER-encoded SubjectPublicKeyInfo.
    /// </summary>
    /// <param name="spkiDer">The DER-encoded SPKI bytes.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="spkiDer"/> is <c>null</c>.</exception>
    public CsrBuilder SetPublicKey(byte[] spkiDer)
    {
        _publicKeySpkiDer = spkiDer ?? throw new ArgumentNullException(nameof(spkiDer));
        return this;
    }

    /// <summary>
    /// Adds a raw extension to the extensionRequest attribute.
    /// </summary>
    /// <param name="oid">The extension OID.</param>
    /// <param name="critical">Whether the extension is critical.</param>
    /// <param name="value">The extension value bytes.</param>
    /// <returns>This builder instance.</returns>
    public CsrBuilder AddExtension(string oid, bool critical, byte[] value)
    {
        if (oid is null) throw new ArgumentNullException(nameof(oid));
        if (value is null) throw new ArgumentNullException(nameof(value));
        _extensions.Add(new X509Extension(oid, critical, value));
        return this;
    }

    /// <summary>
    /// Adds a Basic Constraints extension.
    /// </summary>
    /// <param name="isCA">Whether the subject is a CA.</param>
    /// <param name="pathLengthConstraint">Optional path length constraint.</param>
    /// <returns>This builder instance.</returns>
    public CsrBuilder AddBasicConstraints(bool isCA, int? pathLengthConstraint = null)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        if (isCA)
        {
            writer.WriteBoolean(true);
        }

        if (pathLengthConstraint.HasValue)
        {
            writer.WriteInteger(pathLengthConstraint.Value);
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
    public CsrBuilder AddKeyUsage(KeyUsageFlags flags)
    {
        ushort bits = (ushort)flags;
        byte[] bytes = [(byte)(bits >> 8), (byte)(bits & 0xFF)];
        int unusedBits = 0;
        if (bytes[1] == 0) { bytes = [bytes[0]]; }
        for (int i = 0; i < 8 && (bytes[^1] & (1 << i)) == 0; i++)
        {
            unusedBits++;
        }

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteBitString(bytes, unusedBits);
        _extensions.Add(new X509Extension(X509ExtensionCollection.OidKeyUsage, true, writer.Encode()));
        return this;
    }

    /// <summary>
    /// Adds a Subject Alternative Name extension.
    /// </summary>
    /// <param name="names">The SAN entries as (type, value) tuples.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="names"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="names"/> is empty.</exception>
    public CsrBuilder AddSubjectAlternativeName(params (SanType Type, string Value)[] names)
    {
        if (names is null) throw new ArgumentNullException(nameof(names));
        if (names.Length == 0) throw new ArgumentException("At least one SAN entry is required.", nameof(names));

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
    /// Adds an Extended Key Usage extension.
    /// </summary>
    /// <param name="oids">The EKU purpose OIDs.</param>
    /// <returns>This builder instance.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="oids"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="oids"/> is empty.</exception>
    public CsrBuilder AddExtendedKeyUsage(params string[] oids)
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

    // ========================================================================
    // Build Methods
    // ========================================================================

    /// <summary>
    /// Builds a CSR signed with an RSA private key.
    /// </summary>
    /// <param name="privateKey">The RSA private key for signing.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="privateKey"/> is <c>null</c>.</exception>
    public X509CertificateSigningRequest BuildRsa(RsaKeyParameters privateKey, string hashAlgorithm = "SHA256")
    {
        if (privateKey is null) throw new ArgumentNullException(nameof(privateKey));

        if (_publicKeySpkiDer is null)
        {
            SetPublicKey(privateKey);
        }

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA256" => SignatureAlgorithm.OidSha256WithRsa,
            "SHA384" => SignatureAlgorithm.OidSha384WithRsa,
            "SHA512" => SignatureAlgorithm.OidSha512WithRsa,
            "SHA1" => SignatureAlgorithm.OidSha1WithRsa,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] criDer = BuildCertificationRequestInfo();
        byte[] hash = CryptoHelper.HashData(ToHashAlgorithmName(hashAlgorithm), criDer);
        using var rsa = new RsaCipher(privateKey);
        byte[] signature = rsa.SignPkcs1(hash, hashAlgorithm);

        return BuildCsr(criDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a CSR signed with an ECDSA private key.
    /// </summary>
    /// <param name="ecPrivateKey">The EC private key scalar (big-endian d value).</param>
    /// <param name="curveName">The curve name or OID.</param>
    /// <param name="hashAlgorithm">The hash algorithm name (default: "SHA256").</param>
    /// <returns>The built <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ecPrivateKey"/> is <c>null</c>.</exception>
    public X509CertificateSigningRequest BuildEcDsa(byte[] ecPrivateKey, string curveName, string hashAlgorithm = "SHA256")
    {
        if (ecPrivateKey is null) throw new ArgumentNullException(nameof(ecPrivateKey));

        string sigAlgOid = hashAlgorithm.ToUpperInvariant() switch
        {
            "SHA256" => SignatureAlgorithm.OidEcdsaWithSha256,
            "SHA384" => SignatureAlgorithm.OidEcdsaWithSha384,
            "SHA512" => SignatureAlgorithm.OidEcdsaWithSha512,
            _ => throw new ArgumentException($"Unsupported hash: {hashAlgorithm}"),
        };

        byte[] criDer = BuildCertificationRequestInfo();
        byte[] hash = CryptoHelper.HashData(ToHashAlgorithmName(hashAlgorithm), criDer);
        var curve = EcDsaCipher.ResolveCurve(curveName);
        var (r, s) = EcDsaCore.Sign(hash, ecPrivateKey, curve, ToHashAlgorithmName(hashAlgorithm));
        byte[] signature = EncodeEcdsaSignature(r, s);

        return BuildCsr(criDer, sigAlgOid, signature);
    }

    /// <summary>
    /// Builds a CSR signed with an Ed25519 private seed.
    /// </summary>
    /// <param name="seed">The 32-byte Ed25519 private seed.</param>
    /// <returns>The built <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="seed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="seed"/> is not 32 bytes.</exception>
    public X509CertificateSigningRequest BuildEd25519(byte[] seed)
    {
        if (seed is null) throw new ArgumentNullException(nameof(seed));
        if (seed.Length != 32) throw new ArgumentException("Ed25519 seed must be 32 bytes.", nameof(seed));

        if (_publicKeySpkiDer is null)
        {
            byte[] pub = new byte[32];
            Ed25519.PublicKeyFromSeed(seed, pub);
            _publicKeySpkiDer = KeyEncoding.ExportEdPublicKey(pub, "1.3.101.112");
        }

        byte[] criDer = BuildCertificationRequestInfo();
        byte[] signature = Ed25519.Sign(seed, criDer);
        return BuildCsr(criDer, SignatureAlgorithm.OidEd25519, signature);
    }

    /// <summary>
    /// Builds a CSR signed with an Ed448 private seed.
    /// </summary>
    /// <param name="seed">The 57-byte Ed448 private seed.</param>
    /// <returns>The built <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="seed"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException"><paramref name="seed"/> is not 57 bytes.</exception>
    public X509CertificateSigningRequest BuildEd448(byte[] seed)
    {
        if (seed is null) throw new ArgumentNullException(nameof(seed));
        if (seed.Length != 57) throw new ArgumentException("Ed448 seed must be 57 bytes.", nameof(seed));

        if (_publicKeySpkiDer is null)
        {
            byte[] pub = new byte[57];
            Ed448.PublicKeyFromSeed(seed, pub);
            _publicKeySpkiDer = KeyEncoding.ExportEdPublicKey(pub, "1.3.101.113");
        }

        byte[] criDer = BuildCertificationRequestInfo();
        byte[] signature = Ed448.Sign(seed, criDer);
        return BuildCsr(criDer, SignatureAlgorithm.OidEd448, signature);
    }

    /// <summary>
    /// Builds a CSR using the key material from a factory method.
    /// </summary>
    /// <returns>The built <see cref="X509CertificateSigningRequest"/>.</returns>
    /// <exception cref="InvalidOperationException">No key was configured via a factory method.</exception>
    public X509CertificateSigningRequest Build()
    {
        if (_autoRsaKey is not null)
        {
            return BuildRsa(_autoRsaKey);
        }

        if (_autoEcPrivateKey is not null && _autoEcCurveName is not null)
        {
            return BuildEcDsa(_autoEcPrivateKey, _autoEcCurveName, _autoEcHashAlgorithm ?? "SHA256");
        }

        if (_autoEdSeed is not null && _autoEdAlgorithm is not null)
        {
            return _autoEdAlgorithm == "Ed25519"
                ? BuildEd25519(_autoEdSeed)
                : BuildEd448(_autoEdSeed);
        }

        throw new InvalidOperationException(
            "No key material available. Use CreateForRsa(), CreateForEcDsa(), " +
            "CreateForEd25519(), or CreateForEd448() to create a builder with auto-generated keys, " +
            "or call a typed Build overload that accepts key parameters.");
    }

    // ========================================================================
    // Private Helpers
    // ========================================================================

    private byte[] BuildCertificationRequestInfo()
    {
        if (_subject is null) throw new InvalidOperationException("Subject is required.");
        if (_publicKeySpkiDer is null) throw new InvalidOperationException("Public key is required.");

        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();

        // Version (v1 = 0)
        writer.WriteInteger(0);

        // Subject
        _subject.WriteTo(writer);

        // SubjectPublicKeyInfo (raw copy)
        writer.WriteEncodedValue(_publicKeySpkiDer);

        // Attributes [0] IMPLICIT
        if (_extensions.Count > 0)
        {
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));

            // extensionRequest attribute
            writer.PushSequence();
            writer.WriteObjectIdentifier(CsrParser.OidExtensionRequest);
            writer.PushSetOf();
            writer.PushSequence(); // Extensions ::= SEQUENCE OF Extension
            foreach (var ext in _extensions)
            {
                writer.PushSequence();
                writer.WriteObjectIdentifier(ext.Oid);
                if (ext.Critical)
                {
                    writer.WriteBoolean(true);
                }

                writer.WriteOctetString(ext.Value);
                writer.PopSequence();
            }
            writer.PopSequence();
            writer.PopSetOf();
            writer.PopSequence();

            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }
        else
        {
            // Empty attributes [0] — required by spec
            writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
            writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
        }

        writer.PopSequence();
        return writer.Encode();
    }

    private static X509CertificateSigningRequest BuildCsr(byte[] criDer, string sigAlgOid, byte[] signature)
    {
        var outerWriter = new AsnWriter(AsnEncodingRules.DER);
        outerWriter.PushSequence();
        outerWriter.WriteEncodedValue(criDer);
        WriteAlgorithmIdentifier(outerWriter, sigAlgOid);
        outerWriter.WriteBitString(signature);
        outerWriter.PopSequence();

        byte[] rawDer = outerWriter.Encode();
        return CsrParser.ParseDer(rawDer);
    }

    private static void WriteAlgorithmIdentifier(AsnWriter writer, string oid)
    {
        writer.PushSequence();
        writer.WriteObjectIdentifier(oid);

        string keyAlg = SignatureAlgorithm.GetKeyAlgorithm(oid);
        if (keyAlg == "RSA" && oid != SignatureAlgorithm.OidRsaPss)
        {
            writer.WriteNull();
        }

        writer.PopSequence();
    }

    private static HashAlgorithmName ToHashAlgorithmName(string name) => name.ToUpperInvariant() switch
    {
        "SHA1" => HashAlgorithmName.SHA1,
        "SHA256" => HashAlgorithmName.SHA256,
        "SHA384" => HashAlgorithmName.SHA384,
        "SHA512" => HashAlgorithmName.SHA512,
        _ => throw new ArgumentException($"Unsupported hash: {name}"),
    };

    private static byte[] EncodeEcdsaSignature(byte[] r, byte[] s)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence();
        writer.WriteIntegerUnsigned(TrimLeadingZeros(r));
        writer.WriteIntegerUnsigned(TrimLeadingZeros(s));
        writer.PopSequence();
        return writer.Encode();
    }

    private static ReadOnlySpan<byte> TrimLeadingZeros(byte[] value)
    {
        int i = 0;
        while (i < value.Length - 1 && value[i] == 0)
        {
            i++;
        }

        return value.AsSpan(i);
    }

    private static string GetCurveOid(string curveName) => curveName switch
    {
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
        _ => throw new CryptographicException($"Unknown curve: {curveName}"),
    };
}
