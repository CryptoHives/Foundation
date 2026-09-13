// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.KeyFormats;

using NUnit.Framework;
using System;
using System.Formats.Asn1;

/// <summary>
/// Structural assertions shared by the three key-format fixtures.
/// </summary>
/// <remarks>
/// The per-algorithm fixtures make their own calls - that keeps them readable, and a failure names
/// the algorithm - but the checks on the resulting bytes live here. These decode the DER
/// independently of the writer rather than comparing against a golden blob, so a test failure says
/// which field is wrong instead of only that something changed.
/// </remarks>
internal static class KeyFormatAssert
{
    /// <summary>
    /// A <c>TryExportPkcs8PrivateKeyPem</c> as the three key types expose it.
    /// </summary>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    internal delegate bool TryExportPem(Span<char> destination, out int charsWritten);

    /// <summary>
    /// Runs the erasable plaintext-PEM export and materializes the result for comparison.
    /// </summary>
    /// <param name="size">The size the key reported, from <c>GetPkcs8PrivateKeyPemSize</c>.</param>
    /// <param name="tryExport">The export to run.</param>
    /// <returns>The PEM text.</returns>
    /// <remarks>
    /// The library refuses to build this string because it cannot erase it. A test can: the whole
    /// point of the assertions here is to read the bytes, and the process is about to exit. Keeping
    /// the conversion in one place also means every fixture exercises the reported size rather than
    /// a buffer someone guessed.
    /// </remarks>
    public static string PrivateKeyPem(int size, TryExportPem tryExport)
    {
        char[] buffer = new char[size];

        Assert.That(tryExport(buffer, out int charsWritten), Is.True,
            "the buffer sized by GetPkcs8PrivateKeyPemSize must be large enough");
        Assert.That(charsWritten, Is.EqualTo(size),
            "GetPkcs8PrivateKeyPemSize must report exactly what the export writes");

        return new string(buffer, 0, charsWritten);
    }

    /// <summary>
    /// Asserts that <paramref name="der"/> is a SubjectPublicKeyInfo for the expected algorithm and
    /// key, with no algorithm parameters and no trailing data.
    /// </summary>
    /// <param name="der">The encoding under test.</param>
    /// <param name="expectedOid">The expected algorithm OID.</param>
    /// <param name="expectedKey">The expected raw public key.</param>
    public static void IsSpki(byte[] der, string expectedOid, byte[] expectedKey)
    {
        var reader = new AsnReader(der, AsnEncodingRules.DER);
        AsnReader spki = reader.ReadSequence();
        Assert.That(reader.HasData, Is.False, "SubjectPublicKeyInfo must not be followed by trailing data.");

        AsnReader algorithm = spki.ReadSequence();
        Assert.That(algorithm.ReadObjectIdentifier(), Is.EqualTo(expectedOid), "algorithm OID");
        Assert.That(algorithm.HasData, Is.False,
            "The PQC families define no AlgorithmIdentifier parameters, not even NULL.");

        byte[] key = spki.ReadBitString(out int unusedBits);
        Assert.That(unusedBits, Is.Zero, "The subject public key BIT STRING must have no unused bits.");
        Assert.That(key, Is.EqualTo(expectedKey), "public key");
        Assert.That(spki.HasData, Is.False);
    }

    /// <summary>
    /// Asserts that <paramref name="der"/> is a PKCS#8 PrivateKeyInfo for the expected algorithm,
    /// and returns the contents of its <c>privateKey</c> OCTET STRING.
    /// </summary>
    /// <param name="der">The encoding under test.</param>
    /// <param name="expectedOid">The expected algorithm OID.</param>
    /// <returns>The private key blob.</returns>
    public static byte[] IsPkcs8(byte[] der, string expectedOid)
    {
        var reader = new AsnReader(der, AsnEncodingRules.DER);
        AsnReader info = reader.ReadSequence();
        Assert.That(reader.HasData, Is.False, "PrivateKeyInfo must not be followed by trailing data.");

        Assert.That(info.ReadInteger(), Is.EqualTo(System.Numerics.BigInteger.Zero), "PKCS#8 version");

        AsnReader algorithm = info.ReadSequence();
        Assert.That(algorithm.ReadObjectIdentifier(), Is.EqualTo(expectedOid), "algorithm OID");
        Assert.That(algorithm.HasData, Is.False,
            "The PQC families define no AlgorithmIdentifier parameters, not even NULL.");

        return info.ReadOctetString();
    }

    /// <summary>
    /// Asserts that a private key blob is the seed arm of the ML-KEM / ML-DSA CHOICE and carries
    /// the expected seed.
    /// </summary>
    /// <param name="blob">The contents of the <c>privateKey</c> OCTET STRING.</param>
    /// <param name="expectedSeed">The expected seed.</param>
    public static void IsSeedChoice(byte[] blob, byte[] expectedSeed)
    {
        var reader = new AsnReader(blob, AsnEncodingRules.DER);
        Asn1Tag tag = reader.PeekTag();

        Assert.That(tag.TagClass, Is.EqualTo(TagClass.ContextSpecific), "the seed arm is context-specific");
        Assert.That(tag.TagValue, Is.Zero, "the seed arm is [0]");
        Assert.That(tag.IsConstructed, Is.False, "the seed arm is primitive, not constructed");

        byte[] seed = reader.ReadOctetString(tag);
        Assert.That(seed, Is.EqualTo(expectedSeed), "seed");
        Assert.That(reader.HasData, Is.False);
    }

    /// <summary>
    /// Asserts that a private key blob is the expanded-key arm of the CHOICE and carries the
    /// expected key.
    /// </summary>
    /// <param name="blob">The contents of the <c>privateKey</c> OCTET STRING.</param>
    /// <param name="expectedKey">The expected expanded key.</param>
    public static void IsExpandedKeyChoice(byte[] blob, byte[] expectedKey)
    {
        var reader = new AsnReader(blob, AsnEncodingRules.DER);
        Asn1Tag tag = reader.PeekTag();

        Assert.That(tag.TagClass, Is.EqualTo(TagClass.Universal), "the expandedKey arm is a plain OCTET STRING");
        Assert.That(tag.TagValue, Is.EqualTo((int)UniversalTagNumber.OctetString));

        Assert.That(reader.ReadOctetString(), Is.EqualTo(expectedKey), "expanded key");
        Assert.That(reader.HasData, Is.False);
    }

    /// <summary>
    /// Asserts that <paramref name="der"/> is an EncryptedPrivateKeyInfo using PBES2.
    /// </summary>
    /// <param name="der">The encoding under test.</param>
    public static void IsPbes2(byte[] der)
    {
        var reader = new AsnReader(der, AsnEncodingRules.DER);
        AsnReader info = reader.ReadSequence();
        Assert.That(reader.HasData, Is.False);

        AsnReader algorithm = info.ReadSequence();
        Assert.That(algorithm.ReadObjectIdentifier(), Is.EqualTo("1.2.840.113549.1.5.13"),
            "exports must use PBES2");
    }

    /// <summary>
    /// Asserts the RFC 7468 shape .NET 10 emits: the expected label, 64-character lines, LF
    /// endings, and no trailing newline.
    /// </summary>
    /// <param name="pem">The PEM text under test.</param>
    /// <param name="label">The expected label.</param>
    public static void IsPem(string pem, string label)
    {
        Assert.That(pem, Does.StartWith($"-----BEGIN {label}-----\n"));
        Assert.That(pem, Does.EndWith($"\n-----END {label}-----"));
        Assert.That(pem, Does.Not.Contain("\r"), "PEM output uses LF, matching the in-box formatter.");

        string[] lines = pem.Split('\n');
        for (int i = 1; i < lines.Length - 2; i++)
        {
            Assert.That(lines[i], Has.Length.EqualTo(64),
                $"line {i} must be a full 64-character base64 line");
        }

        Assert.That(lines[^2], Has.Length.LessThanOrEqualTo(64).And.Length.GreaterThan(0),
            "the final base64 line must be non-empty and no longer than 64 characters");
    }
}
