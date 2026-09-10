// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Formats.Asn1;
using OS = System.Security.Cryptography;

/// <summary>
/// Reads and writes PKCS#8 <c>PrivateKeyInfo</c> / <c>OneAsymmetricKey</c> (RFC 5958 §2).
/// </summary>
/// <remarks>
/// <code>
/// OneAsymmetricKey ::= SEQUENCE {
///     version                 INTEGER,
///     privateKeyAlgorithm     AlgorithmIdentifier,
///     privateKey              OCTET STRING,
///     attributes          [0] IMPLICIT Attributes OPTIONAL,
///     publicKey           [1] IMPLICIT BIT STRING OPTIONAL }
/// </code>
/// Version 0 is written, matching what .NET 10 emits for all three PQC families: none of them puts
/// the public key in the optional <c>[1]</c> field, because every one of these private key formats
/// already contains or can recompute it.
/// </remarks>
internal static class Pkcs8
{
    /// <summary>
    /// Encodes a private key blob as a <c>PrivateKeyInfo</c>.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="privateKey">
    /// The contents of the <c>privateKey</c> OCTET STRING. For ML-KEM and ML-DSA this is itself a
    /// DER-encoded CHOICE (see <see cref="PqcPrivateKeyChoice"/>); for SLH-DSA it is the raw key.
    /// </param>
    /// <returns>The DER encoding.</returns>
    public static byte[] Write(string algorithmOid, ReadOnlySpan<byte> privateKey)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);

        using (writer.PushSequence())
        {
            writer.WriteInteger(0);

            using (writer.PushSequence())
            {
                writer.WriteObjectIdentifier(algorithmOid);
            }

            writer.WriteOctetString(privateKey);
        }

        return writer.Encode();
    }

    /// <summary>
    /// Decodes a <c>PrivateKeyInfo</c>.
    /// </summary>
    /// <param name="source">The DER encoding.</param>
    /// <param name="algorithmOid">Receives the algorithm OID.</param>
    /// <returns>The contents of the <c>privateKey</c> OCTET STRING.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed, carries unexpected
    /// algorithm parameters, or is followed by trailing data.</exception>
    public static byte[] Read(ReadOnlySpan<byte> source, out string algorithmOid)
    {
        // AsnReader needs a ReadOnlyMemory<byte>, which a span cannot supply, so the whole
        // PrivateKeyInfo - private key included - has to be copied. Clear the copy on the way out
        // rather than leaving it for the collector.
        byte[] copy = source.ToArray();

        try
        {
            var reader = new AsnReader(copy, AsnEncodingRules.DER);
            AsnReader info = reader.ReadSequence();
            DerGuard.NoTrailingData(reader);

            if (!info.TryReadInt32(out int version) || version > 1)
            {
                throw new OS.CryptographicException(
                    "Unsupported PKCS#8 PrivateKeyInfo version.");
            }

            AsnReader algorithm = info.ReadSequence();
            algorithmOid = algorithm.ReadObjectIdentifier();
            DerGuard.NoAlgorithmParameters(algorithm);

            byte[] privateKey = info.ReadOctetString();

            // attributes [0] and publicKey [1] are optional and we do not use either. Skip them
            // rather than reject: a structure carrying them is still well formed, and the in-box
            // readers accept it.
            while (info.HasData)
            {
                info.ReadEncodedValue();
            }

            return privateKey;
        }
        catch (AsnContentException e)
        {
            throw new OS.CryptographicException("The PKCS#8 PrivateKeyInfo structure is malformed.", e);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(copy);
        }
    }
}
