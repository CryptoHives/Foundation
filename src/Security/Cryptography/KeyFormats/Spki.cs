// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Formats.Asn1;
using OS = System.Security.Cryptography;

/// <summary>
/// Reads and writes X.509 <c>SubjectPublicKeyInfo</c> (RFC 5280 §4.1.2.7).
/// </summary>
/// <remarks>
/// <code>
/// SubjectPublicKeyInfo ::= SEQUENCE {
///     algorithm         AlgorithmIdentifier,
///     subjectPublicKey  BIT STRING }
///
/// AlgorithmIdentifier ::= SEQUENCE {
///     algorithm   OBJECT IDENTIFIER,
///     parameters  ANY DEFINED BY algorithm OPTIONAL }
/// </code>
/// For ML-KEM, ML-DSA and SLH-DSA the parameters field is absent entirely - not ASN.1 NULL, which
/// is what the RSA encoding uses - because the OID already identifies the parameter set.
/// </remarks>
internal static class Spki
{
    /// <summary>
    /// Encodes a raw public key as a <c>SubjectPublicKeyInfo</c>.
    /// </summary>
    /// <param name="algorithmOid">The algorithm OID.</param>
    /// <param name="publicKey">The raw public key bytes.</param>
    /// <returns>The DER encoding.</returns>
    public static byte[] Write(string algorithmOid, ReadOnlySpan<byte> publicKey)
    {
        var writer = new AsnWriter(AsnEncodingRules.DER);

        using (writer.PushSequence())
        {
            using (writer.PushSequence())
            {
                writer.WriteObjectIdentifier(algorithmOid);
            }

            writer.WriteBitString(publicKey);
        }

        return writer.Encode();
    }

    /// <summary>
    /// Decodes a <c>SubjectPublicKeyInfo</c>.
    /// </summary>
    /// <param name="source">The DER encoding.</param>
    /// <param name="algorithmOid">Receives the algorithm OID.</param>
    /// <returns>The raw public key bytes.</returns>
    /// <exception cref="OS.CryptographicException">The structure is malformed, carries unexpected
    /// algorithm parameters, or is followed by trailing data.</exception>
    public static byte[] Read(ReadOnlySpan<byte> source, out string algorithmOid)
    {
        try
        {
            var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
            AsnReader spki = reader.ReadSequence();
            DerGuard.NoTrailingData(reader);

            AsnReader algorithm = spki.ReadSequence();
            algorithmOid = algorithm.ReadObjectIdentifier();

            // The PQC families define no parameters. Anything here is a different encoding than
            // the one this reader claims to understand, so reject rather than ignore it.
            DerGuard.NoAlgorithmParameters(algorithm);

            byte[] publicKey = spki.ReadBitString(out int unusedBitCount);
            if (unusedBitCount != 0)
            {
                throw new OS.CryptographicException(
                    "The subject public key BIT STRING must have no unused bits.");
            }

            DerGuard.NoTrailingData(spki);
            return publicKey;
        }
        catch (AsnContentException e)
        {
            throw new OS.CryptographicException("The SubjectPublicKeyInfo structure is malformed.", e);
        }
    }
}
