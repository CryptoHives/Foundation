// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using OS = System.Security.Cryptography;

/// <summary>
/// Password-based encryption tests for the PQC key formats.
/// </summary>
/// <remarks>
/// Covers the PBES2 matrix this library writes, the character-versus-byte password distinction,
/// and the legacy PKCS#12 schemes it only reads. The legacy blobs are produced by BouncyCastle
/// rather than checked in as opaque test data: a generated fixture states which scheme it is
/// exercising, and it doubles as an interop test against a real producer of those files.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class EncryptedKeyFormatTests
{
    /// <summary>
    /// Gets every combination the exporter can express.
    /// </summary>
    /// <remarks>
    /// Exhaustive rather than sampled, and it can be: both axes are closed enums, so this is the
    /// entire matrix - twelve cases - not a selection from an open set.
    /// </remarks>
    public static IEnumerable<TestCaseData> Pbes2Combinations()
    {
        foreach (PbeEncryptionAlgorithm cipher in new[]
        {
            PbeEncryptionAlgorithm.Aes128Cbc,
            PbeEncryptionAlgorithm.Aes192Cbc,
            PbeEncryptionAlgorithm.Aes256Cbc,
        })
        {
            foreach (Pbkdf2Prf prf in new[]
            {
                Pbkdf2Prf.HmacSha1,
                Pbkdf2Prf.HmacSha256,
                Pbkdf2Prf.HmacSha384,
                Pbkdf2Prf.HmacSha512,
            })
            {
                yield return new TestCaseData(cipher, prf).SetName($"{cipher}_{prf}");
            }
        }
    }

    [Test]
    [TestCaseSource(nameof(Pbes2Combinations))]
    public void Pbes2_RoundTrips(PbeEncryptionAlgorithm cipher, Pbkdf2Prf prf)
    {
        var parameters = new PbeOptions(cipher, prf, 1024);
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("correct horse", parameters);
        KeyFormatAssert.IsPbes2(encrypted);

        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey("correct horse".AsSpan(), encrypted);
        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    public void ByteAndCharacterPasswordsAreNotInterchangeable()
    {
        var parameters = new PbeOptions(
            PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 1024);
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        // "abc" as characters is UTF-8 encoded before the KDF sees it; the byte overload passes
        // its input through untouched. For pure ASCII the two happen to coincide, so use a
        // password where the encodings genuinely differ.
        byte[] rawPassword = [0x00, 0xFF, 0x10];
        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(rawPassword, parameters);

        using var roundTripped = MLDsa.ImportEncryptedPkcs8PrivateKey(rawPassword, encrypted);
        Assert.That(roundTripped.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()),
            "a byte password must round-trip through the byte overload");

        Assert.That(
            () => MLDsa.ImportEncryptedPkcs8PrivateKey("\u0000\u00ff\u0010".AsSpan(), encrypted),
            Throws.InstanceOf<OS.CryptographicException>(),
            "the same code points as characters are UTF-8 encoded, so they must not decrypt it");
    }

    [Test]
    public void AsciiPasswordWorksThroughEitherOverload()
    {
        var parameters = new PbeOptions(
            PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 1024);
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("abc", parameters);

        // UTF-8 of "abc" is the same three bytes, so this is not a contradiction of the test
        // above - it is the reason that test needed a non-ASCII password to make its point.
        using var viaBytes = MLDsa.ImportEncryptedPkcs8PrivateKey("abc"u8, encrypted);
        Assert.That(viaBytes.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    public void EmptyPasswordRoundTrips()
    {
        var parameters = new PbeOptions(
            PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 1024);
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(string.Empty, parameters);
        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey(string.Empty.AsSpan(), encrypted);

        Assert.That(imported.ExportMLDsaPrivateSeed(), Is.EqualTo(key.ExportMLDsaPrivateSeed()));
    }

    [Test]
    public void ConstructorRejectsWhatCannotBeEncoded()
    {
        // These used to be export-time CryptographicExceptions - one for TripleDes3KeyPkcs12, one
        // for an Unknown cipher, one for an unsupported PRF such as MD5. Two of those three can no
        // longer be written down at all, because neither enum offers the value, and the third now
        // fails where the mistake is made rather than several calls later.
        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                () => new PbeOptions(PbeEncryptionAlgorithm.Unknown, Pbkdf2Prf.HmacSha256, 1024),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new PbeOptions(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.Unknown, 1024),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new PbeOptions((PbeEncryptionAlgorithm)99, Pbkdf2Prf.HmacSha256, 1024),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new PbeOptions(PbeEncryptionAlgorithm.Aes256Cbc, (Pbkdf2Prf)99, 1024),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new PbeOptions(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 0),
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }

    [Test]
    public void LegacyPkcs12TripleDes_IsReadable()
    {
        // The scheme older OpenSSL and Windows tooling used for shrouded key bags. This library
        // never writes it, so BouncyCastle stands in for the tool that produced the file.
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] plaintextPkcs8 = key.ExportPkcs8PrivateKey();

        byte[] legacy = EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(
            PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc,
            "legacy-password".ToCharArray(),
            salt: [1, 2, 3, 4, 5, 6, 7, 8],
            iterationCount: 2048,
            PrivateKeyFactory.CreateKey(plaintextPkcs8)).GetDerEncoded();

        using var imported = MLDsa.ImportEncryptedPkcs8PrivateKey("legacy-password".AsSpan(), legacy);

        // Compare the public key rather than the seed: BouncyCastle re-encodes the PKCS#8 from its
        // own key object, and which arm of the CHOICE it picks is its business, not this test's.
        Assert.That(imported.ExportMLDsaPublicKey(), Is.EqualTo(key.ExportMLDsaPublicKey()));
    }

    [Test]
    public void LegacyPkcs12TripleDes_WrongPasswordThrows()
    {
        using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa44);

        byte[] legacy = EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(
            PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc,
            "legacy-password".ToCharArray(),
            salt: [1, 2, 3, 4, 5, 6, 7, 8],
            iterationCount: 2048,
            PrivateKeyFactory.CreateKey(key.ExportPkcs8PrivateKey())).GetDerEncoded();

        Assert.That(
            () => MLDsa.ImportEncryptedPkcs8PrivateKey("wrong".AsSpan(), legacy),
            Throws.InstanceOf<OS.CryptographicException>());
    }

    [Test]
    public void UnsupportedScheme_ReportsTheOid()
    {
        // A well-formed EncryptedPrivateKeyInfo whose scheme we do not implement: the message
        // should name it rather than failing as a generic parse error.
        var writer = new System.Formats.Asn1.AsnWriter(System.Formats.Asn1.AsnEncodingRules.DER);
        using (writer.PushSequence())
        {
            using (writer.PushSequence())
            {
                writer.WriteObjectIdentifier("1.2.840.113549.1.5.3"); // pbeWithMD5AndDES-CBC
            }

            writer.WriteOctetString([1, 2, 3, 4]);
        }

        Assert.That(
            () => MLDsa.ImportEncryptedPkcs8PrivateKey("pw".AsSpan(), writer.Encode()),
            Throws.InstanceOf<OS.CryptographicException>().With.Message.Contains("1.2.840.113549.1.5.3"));
    }
}
