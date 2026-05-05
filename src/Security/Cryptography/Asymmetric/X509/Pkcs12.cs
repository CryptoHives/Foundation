// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.X509;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using CH = CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Provides PKCS#12 (PFX) import and export per RFC 7292.
/// </summary>
/// <remarks>
/// <para>
/// Export uses modern PBES2 (PBKDF2-HMAC-SHA256 + AES-256-CBC) for the shrouded
/// key bag, stores certificates in unencrypted data content, and protects integrity
/// with an HMAC-SHA256 MAC whose key is derived via PBKDF2.
/// </para>
/// <para>
/// Import supports PBES2-encrypted shrouded key bags, unencrypted key bags,
/// and X.509 certificate bags.
/// </para>
/// </remarks>
public static class Pkcs12
{
    private const string OidData = "1.2.840.113549.1.7.1";
    private const string OidCertBag = "1.2.840.113549.1.12.10.1.3";
    private const string OidShroudedKeyBag = "1.2.840.113549.1.12.10.1.2";
    private const string OidKeyBag = "1.2.840.113549.1.12.10.1.1";
    private const string OidX509Certificate = "1.2.840.113549.1.9.22.1";
    private const string OidHmacWithSha256 = "1.2.840.113549.2.9";

    private const int MacIterations = 2048;

    /// <summary>
    /// Exports a certificate and its associated private key as a PKCS#12 (PFX) container.
    /// </summary>
    /// <param name="certificate">The X.509 certificate to include.</param>
    /// <param name="privateKeyPkcs8">The unencrypted PKCS#8 PrivateKeyInfo DER of the associated private key.</param>
    /// <param name="password">The password used to protect the PFX container.</param>
    /// <param name="iterations">The PBKDF2 iteration count for key encryption (default 600,000).</param>
    /// <returns>The DER-encoded PKCS#12 (PFX) container.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="certificate"/> or <paramref name="privateKeyPkcs8"/> is <c>null</c>.
    /// </exception>
    public static byte[] Export(
        X509Certificate certificate,
        byte[] privateKeyPkcs8,
        ReadOnlySpan<byte> password,
        int iterations = 600_000)
    {
        if (certificate is null) throw new ArgumentNullException(nameof(certificate));
        if (privateKeyPkcs8 is null) throw new ArgumentNullException(nameof(privateKeyPkcs8));

        // Build cert bag SafeContents
        byte[] certSafeContents = EncodeCertSafeContents(certificate.RawDer);

        // Build key bag SafeContents (shrouded)
        byte[] encryptedPkcs8 = KeyEncoding.ExportEncryptedPkcs8PrivateKey(privateKeyPkcs8, password, iterations);
        byte[] keySafeContents = EncodeShroudedKeyBagSafeContents(encryptedPkcs8);

        // AuthenticatedSafe = SEQUENCE OF ContentInfo
        byte[] authSafeContent = EncodeAuthenticatedSafe(certSafeContents, keySafeContents);

        // MacData
        byte[] macSalt = new byte[20];
        CH.Rng.RandomNumberGenerator.Fill(macSalt);

        byte[] macKey = Pbkdf2.DeriveKey(
            key => new HmacSha256(key), password.ToArray(), macSalt, MacIterations, 32);

        byte[] macDigest;
        using (var hmac = new HmacSha256(macKey))
        {
            hmac.Update(authSafeContent);
            macDigest = new byte[hmac.MacSize];
            hmac.Finalize(macDigest);
        }

        return EncodePfx(authSafeContent, macDigest, macSalt);
    }

    /// <summary>
    /// Imports a PKCS#12 (PFX) container, extracting the certificate and private key.
    /// </summary>
    /// <param name="pfxData">The DER-encoded PKCS#12 (PFX) container.</param>
    /// <param name="password">The password used to decrypt the PFX container.</param>
    /// <returns>A tuple containing the parsed certificate and the unencrypted PKCS#8 private key DER.</returns>
    /// <exception cref="CryptographicException">
    /// The PFX data is invalid, the MAC verification fails, or the password is incorrect.
    /// </exception>
    public static (X509Certificate Certificate, byte[] PrivateKeyPkcs8) Import(
        ReadOnlySpan<byte> pfxData,
        ReadOnlySpan<byte> password)
    {
        DecodePfx(pfxData, out byte[] authSafeContent,
            out byte[]? macDigest, out byte[]? macSalt, out int macIterations,
            out string? macAlgOid);

        // Verify MAC if present
        if (macDigest is not null && macSalt is not null)
        {
            if (macAlgOid is not null && macAlgOid != OidHmacWithSha256 &&
                macAlgOid != "1.2.840.113549.2.7") // hmacWithSHA1
                throw new CryptographicException($"Unsupported MAC algorithm: {macAlgOid}");

            HmacFactory hmacFactory;
            int macKeyLen;
            if (macAlgOid == "1.2.840.113549.2.7")
            {
#pragma warning disable CS0618
                hmacFactory = key => new HmacSha1(key);
#pragma warning restore CS0618
                macKeyLen = 20;
            }
            else
            {
                hmacFactory = key => new HmacSha256(key);
                macKeyLen = 32;
            }

            byte[] macKey = Pbkdf2.DeriveKey(
                hmacFactory, password.ToArray(), macSalt,
                macIterations > 0 ? macIterations : MacIterations, macKeyLen);

            byte[] computed;
            using (var hmac = hmacFactory(macKey))
            {
                hmac.Update(authSafeContent);
                computed = new byte[hmac.MacSize];
                hmac.Finalize(computed);
            }

            if (!ConstantTimeEqual(macDigest, computed))
                throw new CryptographicException("PKCS#12 MAC verification failed. The password may be incorrect.");
        }

        // Parse AuthenticatedSafe
        X509Certificate? cert = null;
        byte[]? pkcs8 = null;

        var authSafeReader = new AsnReader(authSafeContent, AsnEncodingRules.DER);
        var authSafeSeq = authSafeReader.ReadSequence();

        while (authSafeSeq.HasData)
        {
            var contentInfo = authSafeSeq.ReadSequence();
            string contentType = contentInfo.ReadObjectIdentifier();

            if (contentType != OidData)
            {
                // Skip unsupported content types
                continue;
            }

            var explicit0 = contentInfo.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
            byte[] safeContentsOctets = explicit0.ReadOctetString();
            explicit0.ThrowIfNotEmpty();

            var safeContentsReader = new AsnReader(safeContentsOctets, AsnEncodingRules.DER);
            var safeContentsSeq = safeContentsReader.ReadSequence();

            while (safeContentsSeq.HasData)
            {
                var safeBag = safeContentsSeq.ReadSequence();
                string bagId = safeBag.ReadObjectIdentifier();
                var bagValue = safeBag.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));

                if (bagId == OidCertBag)
                {
                    var certBag = bagValue.ReadSequence();
                    string certId = certBag.ReadObjectIdentifier();
                    if (certId == OidX509Certificate)
                    {
                        var certExplicit = certBag.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
                        byte[] certDer = certExplicit.ReadOctetString();
                        certExplicit.ThrowIfNotEmpty();
                        cert = X509CertificateParser.ParseDer(certDer);
                    }
                }
                else if (bagId == OidShroudedKeyBag)
                {
                    byte[] encPkcs8Der = bagValue.ReadEncodedValue().ToArray();
                    pkcs8 = KeyEncoding.ImportEncryptedPkcs8PrivateKey(
                        encPkcs8Der, password, out _, out _);
                    // Re-export as clean PKCS#8
                    var innerReader = new AsnReader(encPkcs8Der, AsnEncodingRules.DER);
                    // pkcs8 already contains the algorithm-specific private key DER;
                    // reconstruct full PKCS#8 from the decrypted content
                    KeyEncoding.ImportEncryptedPkcs8PrivateKey(
                        encPkcs8Der, password, out string algOid, out string? curveOid);
                    pkcs8 = KeyEncoding.ExportPkcs8PrivateKey(algOid, curveOid, pkcs8);
                }
                else if (bagId == OidKeyBag)
                {
                    pkcs8 = bagValue.ReadEncodedValue().ToArray();
                }
            }
        }

        if (cert is null)
            throw new CryptographicException("PKCS#12 container does not contain a certificate.");
        if (pkcs8 is null)
            throw new CryptographicException("PKCS#12 container does not contain a private key.");

        return (cert, pkcs8);
    }

    private static byte[] EncodeCertSafeContents(byte[] certDer)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // SafeContents

        // SafeBag for certBag
        writer.PushSequence(); // SafeBag
        writer.WriteObjectIdentifier(OidCertBag);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0)); // [0] EXPLICIT

        // CertBag
        writer.PushSequence();
        writer.WriteObjectIdentifier(OidX509Certificate);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.WriteOctetString(certDer);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence(); // CertBag

        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence(); // SafeBag

        writer.PopSequence(); // SafeContents
        return writer.Encode();
    }

    private static byte[] EncodeShroudedKeyBagSafeContents(byte[] encryptedPkcs8)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // SafeContents

        writer.PushSequence(); // SafeBag
        writer.WriteObjectIdentifier(OidShroudedKeyBag);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0)); // [0] EXPLICIT
        writer.WriteEncodedValue(encryptedPkcs8); // EncryptedPrivateKeyInfo as-is
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence(); // SafeBag

        writer.PopSequence(); // SafeContents
        return writer.Encode();
    }

    private static byte[] EncodeAuthenticatedSafe(byte[] certSafeContents, byte[] keySafeContents)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // AuthenticatedSafe

        // ContentInfo wrapping cert safe contents
        WriteContentInfo(writer, certSafeContents);

        // ContentInfo wrapping key safe contents
        WriteContentInfo(writer, keySafeContents);

        writer.PopSequence();
        return writer.Encode();
    }

    private static void WriteContentInfo(AsnWriter writer, byte[] safeContents)
    {
        writer.PushSequence(); // ContentInfo
        writer.WriteObjectIdentifier(OidData);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.WriteOctetString(safeContents);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence();
    }

    private static byte[] EncodePfx(byte[] authSafeContent, byte[] macDigest, byte[] macSalt)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.PushSequence(); // PFX

        writer.WriteInteger(3); // version

        // authSafe ContentInfo
        writer.PushSequence(); // ContentInfo
        writer.WriteObjectIdentifier(OidData);
        writer.PushSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.WriteOctetString(authSafeContent);
        writer.PopSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        writer.PopSequence();

        // MacData
        writer.PushSequence();
        // DigestInfo
        writer.PushSequence();
        writer.PushSequence(); // AlgorithmIdentifier
        writer.WriteObjectIdentifier(OidHmacWithSha256);
        writer.WriteNull();
        writer.PopSequence();
        writer.WriteOctetString(macDigest);
        writer.PopSequence();
        writer.WriteOctetString(macSalt);
        writer.WriteInteger(MacIterations);
        writer.PopSequence(); // MacData

        writer.PopSequence(); // PFX
        return writer.Encode();
    }

    private static void DecodePfx(
        ReadOnlySpan<byte> source,
        out byte[] authSafeContent,
        out byte[]? macDigest,
        out byte[]? macSalt,
        out int macIterations,
        out string? macAlgOid)
    {
        var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
        var pfx = reader.ReadSequence();

        int version = (int)pfx.ReadInteger();
        if (version != 3)
            throw new CryptographicException($"Unsupported PKCS#12 version: {version}. Only version 3 is supported.");

        // authSafe ContentInfo
        var contentInfo = pfx.ReadSequence();
        string contentType = contentInfo.ReadObjectIdentifier();
        if (contentType != OidData)
            throw new CryptographicException("PKCS#12 authSafe content type is not 'data'.");

        var explicit0 = contentInfo.ReadSequence(new Asn1Tag(TagClass.ContextSpecific, 0));
        authSafeContent = explicit0.ReadOctetString();
        explicit0.ThrowIfNotEmpty();

        macDigest = null;
        macSalt = null;
        macIterations = 0;
        macAlgOid = null;

        // MacData (optional)
        if (pfx.HasData)
        {
            var macData = pfx.ReadSequence();

            // DigestInfo
            var digestInfo = macData.ReadSequence();
            var algId = digestInfo.ReadSequence();
            macAlgOid = algId.ReadObjectIdentifier();
            if (algId.HasData) algId.ReadNull();
            algId.ThrowIfNotEmpty();

            macDigest = digestInfo.ReadOctetString();
            digestInfo.ThrowIfNotEmpty();

            macSalt = macData.ReadOctetString();

            macIterations = macData.HasData ? (int)macData.ReadInteger() : MacIterations;
            macData.ThrowIfNotEmpty();
        }

        pfx.ThrowIfNotEmpty();
    }

    private static bool ConstantTimeEqual(byte[] a, byte[] b)
    {
        if (a.Length != b.Length) return false;
        int diff = 0;
        for (int i = 0; i < a.Length; i++)
            diff |= a[i] ^ b[i];
        return diff == 0;
    }
}
