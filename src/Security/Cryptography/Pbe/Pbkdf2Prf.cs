// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// The pseudorandom function PBKDF2 uses when deriving a key from a password.
/// </summary>
/// <remarks>
/// <para>
/// Deliberately closed, and deliberately smaller than the set of hashes this library implements.
/// PBES2 encodes the pseudorandom function as an <c>AlgorithmIdentifier</c> inside the file, so a
/// function can only be used here if RFC 8018 assigns it an object identifier. There is no
/// <c>hmacWithBLAKE3</c> OID, so no amount of naming would let one be written.
/// </para>
/// <para>
/// This is why the type is an enum rather than a name: the choice is genuinely finite, so an
/// unencodable one should fail to compile rather than throw at export. It is also the reason this
/// does not use <c>System.Security.Cryptography.HashAlgorithmName</c> — that type is an open string
/// wrapper, which would suggest a freedom the format does not have, and
/// <see cref="Kdf.Pbkdf2"/> already avoids it for the same reason where the PRF genuinely is open.
/// </para>
/// <para>
/// Reading is not limited to this set. The import path maps whatever OID a file carries to a
/// pseudorandom function, so a key written elsewhere with, say, HMAC-SHA-224 still opens.
/// </para>
/// </remarks>
public enum Pbkdf2Prf
{
    /// <summary>
    /// No function selected. Rejected by the <see cref="PbeOptions"/> constructor.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// HMAC-SHA-1, the RFC 8018 default. Offered for interoperability with older readers; prefer
    /// <see cref="HmacSha256"/> or stronger for anything new.
    /// </summary>
    HmacSha1 = 1,

    /// <summary>HMAC-SHA-256.</summary>
    HmacSha256 = 2,

    /// <summary>HMAC-SHA-384.</summary>
    HmacSha384 = 3,

    /// <summary>HMAC-SHA-512.</summary>
    HmacSha512 = 4,
}
