// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;

/// <summary>
/// Maps the FIPS 203/204/205 parameter set names to the NIST CSOR object identifiers used in
/// <c>AlgorithmIdentifier</c>, and back.
/// </summary>
/// <remarks>
/// <para>
/// Every value here was read out of a generated structure rather than transcribed: the ML-KEM and
/// ML-DSA arcs from the SubjectPublicKeyInfo that .NET 10's in-box types emit, and all eighteen
/// cross-checked against the latest BouncyCastle. The two agree.
/// </para>
/// <para>
/// The signature arc is 2.16.840.1.101.3.4.3 (id-ml-dsa-* at 17-19, id-slh-dsa-* at 20-31) and the
/// KEM arc is 2.16.840.1.101.3.4.4 (id-ml-kem-* at 1-3). Note that SLH-DSA is <b>not</b> ordered
/// the way the parameter sets are usually listed: the six SHA2 sets take 20-25 and the six SHAKE
/// sets 26-31, each in category order with <c>s</c> before <c>f</c>.
/// </para>
/// <para>
/// For all three families the <c>AlgorithmIdentifier</c> carries <b>no parameters</b> at all - not
/// even ASN.1 NULL - because the parameter set is identified by the OID itself.
/// </para>
/// </remarks>
internal static class PqcKeyOids
{
    // ML-KEM (FIPS 203), arc 2.16.840.1.101.3.4.4
    public const string MLKem512 = "2.16.840.1.101.3.4.4.1";
    public const string MLKem768 = "2.16.840.1.101.3.4.4.2";
    public const string MLKem1024 = "2.16.840.1.101.3.4.4.3";

    // ML-DSA (FIPS 204), arc 2.16.840.1.101.3.4.3
    public const string MLDsa44 = "2.16.840.1.101.3.4.3.17";
    public const string MLDsa65 = "2.16.840.1.101.3.4.3.18";
    public const string MLDsa87 = "2.16.840.1.101.3.4.3.19";

    // SLH-DSA (FIPS 205), arc 2.16.840.1.101.3.4.3
    public const string SlhDsaSha2_128s = "2.16.840.1.101.3.4.3.20";
    public const string SlhDsaSha2_128f = "2.16.840.1.101.3.4.3.21";
    public const string SlhDsaSha2_192s = "2.16.840.1.101.3.4.3.22";
    public const string SlhDsaSha2_192f = "2.16.840.1.101.3.4.3.23";
    public const string SlhDsaSha2_256s = "2.16.840.1.101.3.4.3.24";
    public const string SlhDsaSha2_256f = "2.16.840.1.101.3.4.3.25";
    public const string SlhDsaShake128s = "2.16.840.1.101.3.4.3.26";
    public const string SlhDsaShake128f = "2.16.840.1.101.3.4.3.27";
    public const string SlhDsaShake192s = "2.16.840.1.101.3.4.3.28";
    public const string SlhDsaShake192f = "2.16.840.1.101.3.4.3.29";
    public const string SlhDsaShake256s = "2.16.840.1.101.3.4.3.30";
    public const string SlhDsaShake256f = "2.16.840.1.101.3.4.3.31";

    /// <summary>
    /// Returns the OID for an ML-KEM parameter set name.
    /// </summary>
    /// <param name="name">The ACVP/FIPS name, e.g. <c>ML-KEM-768</c>.</param>
    /// <returns>The dotted-decimal OID.</returns>
    /// <exception cref="ArgumentException">The name is not a FIPS 203 parameter set.</exception>
    public static string ForMLKem(string name) => name switch {
        "ML-KEM-512" => MLKem512,
        "ML-KEM-768" => MLKem768,
        "ML-KEM-1024" => MLKem1024,
        _ => throw new ArgumentException($"Unknown ML-KEM parameter set: {name}", nameof(name)),
    };

    /// <summary>
    /// Returns the ML-KEM parameter set name for an OID, or <see langword="null"/> when the OID
    /// belongs to another algorithm.
    /// </summary>
    /// <param name="oid">The dotted-decimal OID.</param>
    /// <returns>The parameter set name, or <see langword="null"/>.</returns>
    public static string? MLKemNameFor(string oid) => oid switch {
        MLKem512 => "ML-KEM-512",
        MLKem768 => "ML-KEM-768",
        MLKem1024 => "ML-KEM-1024",
        _ => null,
    };

    /// <summary>
    /// Returns the OID for an ML-DSA parameter set name.
    /// </summary>
    /// <param name="name">The ACVP/FIPS name, e.g. <c>ML-DSA-65</c>.</param>
    /// <returns>The dotted-decimal OID.</returns>
    /// <exception cref="ArgumentException">The name is not a FIPS 204 parameter set.</exception>
    public static string ForMLDsa(string name) => name switch {
        "ML-DSA-44" => MLDsa44,
        "ML-DSA-65" => MLDsa65,
        "ML-DSA-87" => MLDsa87,
        _ => throw new ArgumentException($"Unknown ML-DSA parameter set: {name}", nameof(name)),
    };

    /// <summary>
    /// Returns the ML-DSA parameter set name for an OID, or <see langword="null"/> when the OID
    /// belongs to another algorithm.
    /// </summary>
    /// <param name="oid">The dotted-decimal OID.</param>
    /// <returns>The parameter set name, or <see langword="null"/>.</returns>
    public static string? MLDsaNameFor(string oid) => oid switch {
        MLDsa44 => "ML-DSA-44",
        MLDsa65 => "ML-DSA-65",
        MLDsa87 => "ML-DSA-87",
        _ => null,
    };

    /// <summary>
    /// Returns the OID for an SLH-DSA parameter set name.
    /// </summary>
    /// <param name="name">The ACVP/FIPS name, e.g. <c>SLH-DSA-SHAKE-128f</c>.</param>
    /// <returns>The dotted-decimal OID.</returns>
    /// <exception cref="ArgumentException">The name is not a FIPS 205 parameter set.</exception>
    public static string ForSlhDsa(string name) => name switch {
        "SLH-DSA-SHA2-128s" => SlhDsaSha2_128s,
        "SLH-DSA-SHA2-128f" => SlhDsaSha2_128f,
        "SLH-DSA-SHA2-192s" => SlhDsaSha2_192s,
        "SLH-DSA-SHA2-192f" => SlhDsaSha2_192f,
        "SLH-DSA-SHA2-256s" => SlhDsaSha2_256s,
        "SLH-DSA-SHA2-256f" => SlhDsaSha2_256f,
        "SLH-DSA-SHAKE-128s" => SlhDsaShake128s,
        "SLH-DSA-SHAKE-128f" => SlhDsaShake128f,
        "SLH-DSA-SHAKE-192s" => SlhDsaShake192s,
        "SLH-DSA-SHAKE-192f" => SlhDsaShake192f,
        "SLH-DSA-SHAKE-256s" => SlhDsaShake256s,
        "SLH-DSA-SHAKE-256f" => SlhDsaShake256f,
        _ => throw new ArgumentException($"Unknown SLH-DSA parameter set: {name}", nameof(name)),
    };

    /// <summary>
    /// Returns the SLH-DSA parameter set name for an OID, or <see langword="null"/> when the OID
    /// belongs to another algorithm.
    /// </summary>
    /// <param name="oid">The dotted-decimal OID.</param>
    /// <returns>The parameter set name, or <see langword="null"/>.</returns>
    public static string? SlhDsaNameFor(string oid) => oid switch {
        SlhDsaSha2_128s => "SLH-DSA-SHA2-128s",
        SlhDsaSha2_128f => "SLH-DSA-SHA2-128f",
        SlhDsaSha2_192s => "SLH-DSA-SHA2-192s",
        SlhDsaSha2_192f => "SLH-DSA-SHA2-192f",
        SlhDsaSha2_256s => "SLH-DSA-SHA2-256s",
        SlhDsaSha2_256f => "SLH-DSA-SHA2-256f",
        SlhDsaShake128s => "SLH-DSA-SHAKE-128s",
        SlhDsaShake128f => "SLH-DSA-SHAKE-128f",
        SlhDsaShake192s => "SLH-DSA-SHAKE-192s",
        SlhDsaShake192f => "SLH-DSA-SHAKE-192f",
        SlhDsaShake256s => "SLH-DSA-SHAKE-256s",
        SlhDsaShake256f => "SLH-DSA-SHAKE-256f",
        _ => null,
    };
}
