// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

/// <summary>
/// Object identifiers used by PKCS#5 (RFC 8018) and the legacy PKCS#12 password-based schemes.
/// </summary>
internal static class PbeOids
{
    /// <summary>PBES2, the scheme this library writes (RFC 8018 §A.4).</summary>
    public const string Pbes2 = "1.2.840.113549.1.5.13";

    /// <summary>PBKDF2 (RFC 8018 §A.2).</summary>
    public const string Pbkdf2 = "1.2.840.113549.1.5.12";

    // PBKDF2 pseudorandom functions (RFC 8018 §B.1.2).
    public const string HmacWithSha1 = "1.2.840.113549.2.7";
    public const string HmacWithSha256 = "1.2.840.113549.2.9";
    public const string HmacWithSha384 = "1.2.840.113549.2.10";
    public const string HmacWithSha512 = "1.2.840.113549.2.11";

    // Content encryption (NIST AES arc).
    public const string Aes128Cbc = "2.16.840.1.101.3.4.1.2";
    public const string Aes192Cbc = "2.16.840.1.101.3.4.1.22";
    public const string Aes256Cbc = "2.16.840.1.101.3.4.1.42";

    // Legacy PKCS#12 password-based encryption (RFC 7292 App. C). Read-only: these are what older
    // OpenSSL and Windows tooling produced, and a reader that rejects them cannot open real files.
    public const string PbeWithShaAnd3KeyTripleDesCbc = "1.2.840.113549.1.12.1.3";
    public const string PbeWithShaAnd2KeyTripleDesCbc = "1.2.840.113549.1.12.1.4";
    public const string PbeWithShaAnd128BitRc2Cbc = "1.2.840.113549.1.12.1.5";
    public const string PbeWithShaAnd40BitRc2Cbc = "1.2.840.113549.1.12.1.6";
}
