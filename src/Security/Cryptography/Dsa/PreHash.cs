// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using System.Collections.Generic;

/// <summary>
/// Pre-hash support shared by HashML-DSA (FIPS 204 §5.4) and HashSLH-DSA (FIPS 205 §10.2).
/// </summary>
/// <remarks>
/// The pre-hash variants sign M′ = 0x01 ‖ |ctx| ‖ ctx ‖ OID ‖ PH(M), where OID is the
/// DER-encoded object identifier of the pre-hash function PH and PH(M) is computed by the
/// caller. The domain-separation byte 0x01 distinguishes pre-hashed from pure signatures.
/// </remarks>
internal static class PreHash
{
    /// <summary>
    /// The approved pre-hash functions (NIST hash algorithm arc 2.16.840.1.101.3.4.2.x)
    /// and their digest lengths in bytes. SHAKE128 and SHAKE256 use 32- and 64-byte
    /// outputs respectively, per FIPS 204/205.
    /// </summary>
    private static readonly Dictionary<string, int> KnownDigests = new()
    {
        ["2.16.840.1.101.3.4.2.1"] = 32,  // SHA-256
        ["2.16.840.1.101.3.4.2.2"] = 48,  // SHA-384
        ["2.16.840.1.101.3.4.2.3"] = 64,  // SHA-512
        ["2.16.840.1.101.3.4.2.4"] = 28,  // SHA-224
        ["2.16.840.1.101.3.4.2.5"] = 28,  // SHA-512/224
        ["2.16.840.1.101.3.4.2.6"] = 32,  // SHA-512/256
        ["2.16.840.1.101.3.4.2.7"] = 28,  // SHA3-224
        ["2.16.840.1.101.3.4.2.8"] = 32,  // SHA3-256
        ["2.16.840.1.101.3.4.2.9"] = 48,  // SHA3-384
        ["2.16.840.1.101.3.4.2.10"] = 64, // SHA3-512
        ["2.16.840.1.101.3.4.2.11"] = 32, // SHAKE128 (256-bit output)
        ["2.16.840.1.101.3.4.2.12"] = 64, // SHAKE256 (512-bit output)
    };

    /// <summary>
    /// The maximum prefix size: 2 + 255 (ctx) + 13 (DER OID headroom).
    /// </summary>
    public const int MaxPrefixBytes = 2 + 255 + 13;

    /// <summary>
    /// Validates the pre-hash OID and digest length.
    /// </summary>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function.</param>
    /// <param name="hashLength">The supplied digest length in bytes.</param>
    /// <exception cref="ArgumentNullException"><paramref name="hashAlgorithmOid"/> is null.</exception>
    /// <exception cref="ArgumentException">The OID is not an approved pre-hash function, or the digest length does not match it.</exception>
    public static void ValidateHash(string hashAlgorithmOid, int hashLength)
    {
        if (hashAlgorithmOid is null)
            throw new ArgumentNullException(nameof(hashAlgorithmOid));
        if (!KnownDigests.TryGetValue(hashAlgorithmOid, out int expected))
            throw new ArgumentException($"'{hashAlgorithmOid}' is not an approved pre-hash function OID.", nameof(hashAlgorithmOid));
        if (hashLength != expected)
            throw new ArgumentException($"The digest for OID {hashAlgorithmOid} must be exactly {expected} bytes.", nameof(hashLength));
    }

    /// <summary>
    /// Builds the pre-hash message prefix 0x01 ‖ |ctx| ‖ ctx ‖ DER(OID). The digest PH(M)
    /// follows as the message part when calling the internal sign/verify functions.
    /// </summary>
    /// <param name="context">The context string (at most 255 bytes).</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function.</param>
    /// <param name="prefix">The buffer to receive the prefix (at least <see cref="MaxPrefixBytes"/> bytes).</param>
    /// <returns>The number of prefix bytes written.</returns>
    public static int BuildPrefix(ReadOnlySpan<byte> context, string hashAlgorithmOid, Span<byte> prefix)
    {
        prefix[0] = 1;
        prefix[1] = (byte)context.Length;
        context.CopyTo(prefix.Slice(2));
        int length = 2 + context.Length;
        length += EncodeOid(hashAlgorithmOid, prefix.Slice(length));
        return length;
    }

    /// <summary>
    /// DER-encodes a dotted-decimal object identifier (tag 0x06 ‖ length ‖ arcs).
    /// </summary>
    /// <param name="oid">The dotted-decimal OID.</param>
    /// <param name="destination">The output buffer.</param>
    /// <returns>The number of bytes written.</returns>
    internal static int EncodeOid(string oid, Span<byte> destination)
    {
        string[] parts = oid.Split('.');
        Span<byte> body = stackalloc byte[16];
        int bodyLength = 0;

        // First two arcs combine into one value: 40·arc1 + arc2.
        long first = long.Parse(parts[0]) * 40 + long.Parse(parts[1]);
        bodyLength += EncodeArc(first, body.Slice(bodyLength));
        for (int i = 2; i < parts.Length; i++)
        {
            bodyLength += EncodeArc(long.Parse(parts[i]), body.Slice(bodyLength));
        }

        destination[0] = 0x06;
        destination[1] = (byte)bodyLength;
        body.Slice(0, bodyLength).CopyTo(destination.Slice(2));
        return 2 + bodyLength;
    }

    private static int EncodeArc(long value, Span<byte> destination)
    {
        // Base-128, most significant group first, high bit set on all but the last byte.
        Span<byte> groups = stackalloc byte[10];
        int count = 0;
        do
        {
            groups[count++] = (byte)(value & 0x7F);
            value >>= 7;
        }
        while (value > 0);

        for (int i = 0; i < count; i++)
        {
            byte b = groups[count - 1 - i];
            destination[i] = i == count - 1 ? b : (byte)(b | 0x80);
        }

        return count;
    }
}
