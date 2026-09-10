// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Formats.Asn1;
using OS = System.Security.Cryptography;

/// <summary>
/// The form an ML-KEM or ML-DSA private key took inside a PKCS#8 <c>privateKey</c> OCTET STRING.
/// </summary>
internal enum PqcPrivateKeyForm
{
    /// <summary>The seed only: 32 bytes for ML-DSA, 64 for ML-KEM.</summary>
    Seed,

    /// <summary>The expanded private key.</summary>
    ExpandedKey,

    /// <summary>Both, as a SEQUENCE.</summary>
    Both,
}

/// <summary>
/// Encodes and decodes the ML-KEM / ML-DSA private key CHOICE that sits inside the PKCS#8
/// <c>privateKey</c> OCTET STRING.
/// </summary>
/// <remarks>
/// <para>
/// <code>
/// PrivateKey ::= CHOICE {
///     seed        [0] IMPLICIT OCTET STRING,
///     expandedKey     OCTET STRING,
///     both            SEQUENCE { seed OCTET STRING, expandedKey OCTET STRING } }
/// </code>
/// </para>
/// <para>
/// The seed arm is context-specific tag 0, <b>primitive</b>. Verified against what .NET 10 emits:
/// an ML-DSA-44 key generated in-box exports a 34-byte privateKey beginning <c>80 20</c> - tag
/// <c>[0]</c>, length 32 - and an ML-KEM-512 key exports 66 bytes beginning <c>80 40</c>.
/// </para>
/// <para>
/// SLH-DSA has no CHOICE at all: its <c>privateKey</c> OCTET STRING holds the raw 4n-byte key
/// directly, so it never comes through here.
/// </para>
/// </remarks>
internal static class PqcPrivateKeyChoice
{
    private static readonly Asn1Tag SeedTag = new(TagClass.ContextSpecific, 0, isConstructed: false);

    /// <summary>
    /// Encodes the seed arm.
    /// </summary>
    /// <param name="seed">The seed.</param>
    /// <returns>The DER encoding of the CHOICE.</returns>
    public static byte[] WriteSeed(ReadOnlySpan<byte> seed)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteOctetString(seed, SeedTag);
        return writer.Encode();
    }

    /// <summary>
    /// Encodes the expanded-key arm.
    /// </summary>
    /// <param name="expandedKey">The expanded private key.</param>
    /// <returns>The DER encoding of the CHOICE.</returns>
    public static byte[] WriteExpandedKey(ReadOnlySpan<byte> expandedKey)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);
        writer.WriteOctetString(expandedKey);
        return writer.Encode();
    }

    /// <summary>
    /// Decodes the CHOICE.
    /// </summary>
    /// <param name="source">The contents of the PKCS#8 <c>privateKey</c> OCTET STRING.</param>
    /// <param name="seed">Receives the seed, or <see langword="null"/> when the arm carries none.</param>
    /// <param name="expandedKey">
    /// Receives the expanded key, or <see langword="null"/> when the arm carries none.
    /// </param>
    /// <returns>Which arm was present.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed.</exception>
    public static PqcPrivateKeyForm Read(
        ReadOnlySpan<byte> source,
        out byte[]? seed,
        out byte[]? expandedKey)
    {
        try
        {
            var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
            Asn1Tag tag = reader.PeekTag();

            if (tag.TagClass == TagClass.ContextSpecific && tag.TagValue == 0)
            {
                seed = reader.ReadOctetString(SeedTag);
                expandedKey = null;
                DerGuard.NoTrailingData(reader);
                return PqcPrivateKeyForm.Seed;
            }

            if (tag.TagClass == TagClass.Universal && tag.TagValue == (int)UniversalTagNumber.OctetString)
            {
                seed = null;
                expandedKey = reader.ReadOctetString();
                DerGuard.NoTrailingData(reader);
                return PqcPrivateKeyForm.ExpandedKey;
            }

            if (tag.TagClass == TagClass.Universal && tag.TagValue == (int)UniversalTagNumber.Sequence)
            {
                AsnReader both = reader.ReadSequence();
                DerGuard.NoTrailingData(reader);
                seed = both.ReadOctetString();
                expandedKey = both.ReadOctetString();
                DerGuard.NoTrailingData(both);
                return PqcPrivateKeyForm.Both;
            }

            throw new OS.CryptographicException(
                "The private key does not match any arm of the ML-KEM/ML-DSA private key CHOICE.");
        }
        catch (AsnContentException e)
        {
            throw new OS.CryptographicException("The private key structure is malformed.", e);
        }
    }
}
