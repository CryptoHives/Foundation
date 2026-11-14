// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

/// <summary>
/// Maps signature algorithm OIDs to display names, hash algorithms, and key types.
/// </summary>
internal static class SignatureAlgorithm
{
    internal const string OidSha1WithRsa = "1.2.840.113549.1.1.5";
    internal const string OidSha256WithRsa = "1.2.840.113549.1.1.11";
    internal const string OidSha384WithRsa = "1.2.840.113549.1.1.12";
    internal const string OidSha512WithRsa = "1.2.840.113549.1.1.13";
    internal const string OidRsaPss = "1.2.840.113549.1.1.10";
    internal const string OidEcdsaWithSha256 = "1.2.840.10045.4.3.2";
    internal const string OidEcdsaWithSha384 = "1.2.840.10045.4.3.3";
    internal const string OidEcdsaWithSha512 = "1.2.840.10045.4.3.4";
    internal const string OidEd25519 = "1.3.101.112";
    internal const string OidEd448 = "1.3.101.113";

    /// <summary>
    /// Gets the display name for a signature algorithm OID.
    /// </summary>
    /// <param name="oid">The algorithm OID.</param>
    /// <returns>The display name, or the OID itself if unknown.</returns>
    internal static string GetName(string oid) => oid switch
    {
        OidSha1WithRsa => "sha1WithRSAEncryption",
        OidSha256WithRsa => "sha256WithRSAEncryption",
        OidSha384WithRsa => "sha384WithRSAEncryption",
        OidSha512WithRsa => "sha512WithRSAEncryption",
        OidRsaPss => "rsaPSS",
        OidEcdsaWithSha256 => "ecdsa-with-SHA256",
        OidEcdsaWithSha384 => "ecdsa-with-SHA384",
        OidEcdsaWithSha512 => "ecdsa-with-SHA512",
        OidEd25519 => "Ed25519",
        OidEd448 => "Ed448",
        _ => oid,
    };

    /// <summary>
    /// Gets the hash algorithm name for a signature algorithm OID.
    /// </summary>
    /// <param name="oid">The algorithm OID.</param>
    /// <returns>The hash algorithm name, or <c>null</c> for algorithms that don't use a separate hash (Ed25519/Ed448).</returns>
    internal static string? GetHashAlgorithm(string oid) => oid switch
    {
        OidSha1WithRsa => "SHA1",
        OidSha256WithRsa => "SHA256",
        OidSha384WithRsa => "SHA384",
        OidSha512WithRsa => "SHA512",
        OidRsaPss => "SHA256",
        OidEcdsaWithSha256 => "SHA256",
        OidEcdsaWithSha384 => "SHA384",
        OidEcdsaWithSha512 => "SHA512",
        OidEd25519 or OidEd448 => null,
        _ => null,
    };

    /// <summary>
    /// Gets the key algorithm type for a signature algorithm OID.
    /// </summary>
    /// <param name="oid">The algorithm OID.</param>
    /// <returns>The key type string.</returns>
    internal static string GetKeyAlgorithm(string oid) => oid switch
    {
        OidSha1WithRsa or OidSha256WithRsa or OidSha384WithRsa or OidSha512WithRsa or OidRsaPss => "RSA",
        OidEcdsaWithSha256 or OidEcdsaWithSha384 or OidEcdsaWithSha512 => "ECDSA",
        OidEd25519 => "Ed25519",
        OidEd448 => "Ed448",
        _ => "Unknown",
    };
}
