// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Shared helpers for the HashML-DSA / HashSLH-DSA pre-hash tests: maps ACVP hash
/// algorithm names to this library's hash implementations and their OIDs.
/// </summary>
internal static class PreHashTestUtil
{
    /// <summary>
    /// Computes PH(message) for an ACVP hash algorithm name and returns the digest with its OID.
    /// </summary>
    public static (byte[] Digest, string Oid) ComputeDigest(string acvpHashAlg, byte[] message)
    {
        (Func<HashAlgorithm> factory, int size, string oid) = acvpHashAlg switch
        {
            "SHA2-224" => ((Func<HashAlgorithm>)(() => SHA224.Create()), 28, "2.16.840.1.101.3.4.2.4"),
            "SHA2-256" => (() => SHA256.Create(), 32, "2.16.840.1.101.3.4.2.1"),
            "SHA2-384" => (() => SHA384.Create(), 48, "2.16.840.1.101.3.4.2.2"),
            "SHA2-512" => (() => SHA512.Create(), 64, "2.16.840.1.101.3.4.2.3"),
            "SHA2-512/224" => (() => SHA512_224.Create(), 28, "2.16.840.1.101.3.4.2.5"),
            "SHA2-512/256" => (() => SHA512_256.Create(), 32, "2.16.840.1.101.3.4.2.6"),
            "SHA3-224" => (() => SHA3_224.Create(), 28, "2.16.840.1.101.3.4.2.7"),
            "SHA3-256" => (() => SHA3_256.Create(), 32, "2.16.840.1.101.3.4.2.8"),
            "SHA3-384" => (() => SHA3_384.Create(), 48, "2.16.840.1.101.3.4.2.9"),
            "SHA3-512" => (() => SHA3_512.Create(), 64, "2.16.840.1.101.3.4.2.10"),
            "SHAKE-128" => (() => Shake128.Create(32), 32, "2.16.840.1.101.3.4.2.11"),
            "SHAKE-256" => (() => Shake256.Create(64), 64, "2.16.840.1.101.3.4.2.12"),
            _ => throw new ArgumentException($"Unknown ACVP hash algorithm: {acvpHashAlg}", nameof(acvpHashAlg)),
        };

        using HashAlgorithm hash = factory();
        byte[] digest = new byte[size];
        hash.TryComputeHash(message, digest, out _);
        return (digest, oid);
    }

    public static MlDsaParams MlDsaParamsFor(string parameterSet) => parameterSet switch
    {
        "ML-DSA-44" => MlDsaParams.MlDsa44,
        "ML-DSA-65" => MlDsaParams.MlDsa65,
        "ML-DSA-87" => MlDsaParams.MlDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    public static MlDsaAlgorithm MlDsaAlgorithmFor(string parameterSet) => parameterSet switch
    {
        "ML-DSA-44" => MlDsaAlgorithm.MlDsa44,
        "ML-DSA-65" => MlDsaAlgorithm.MlDsa65,
        "ML-DSA-87" => MlDsaAlgorithm.MlDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    public static SlhDsaParams SlhDsaParamsFor(string parameterSet) => parameterSet switch
    {
        "SLH-DSA-SHA2-128s" => SlhDsaParams.Sha2_128s,
        "SLH-DSA-SHAKE-128s" => SlhDsaParams.Shake128s,
        "SLH-DSA-SHA2-128f" => SlhDsaParams.Sha2_128f,
        "SLH-DSA-SHAKE-128f" => SlhDsaParams.Shake128f,
        "SLH-DSA-SHA2-192s" => SlhDsaParams.Sha2_192s,
        "SLH-DSA-SHAKE-192s" => SlhDsaParams.Shake192s,
        "SLH-DSA-SHA2-192f" => SlhDsaParams.Sha2_192f,
        "SLH-DSA-SHAKE-192f" => SlhDsaParams.Shake192f,
        "SLH-DSA-SHA2-256s" => SlhDsaParams.Sha2_256s,
        "SLH-DSA-SHAKE-256s" => SlhDsaParams.Shake256s,
        "SLH-DSA-SHA2-256f" => SlhDsaParams.Sha2_256f,
        "SLH-DSA-SHAKE-256f" => SlhDsaParams.Shake256f,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    public static SlhDsaAlgorithm SlhDsaAlgorithmFor(string parameterSet) => parameterSet switch
    {
        "SLH-DSA-SHA2-128s" => SlhDsaAlgorithm.SlhDsaSha2_128s,
        "SLH-DSA-SHAKE-128s" => SlhDsaAlgorithm.SlhDsaShake128s,
        "SLH-DSA-SHA2-128f" => SlhDsaAlgorithm.SlhDsaSha2_128f,
        "SLH-DSA-SHAKE-128f" => SlhDsaAlgorithm.SlhDsaShake128f,
        "SLH-DSA-SHA2-192s" => SlhDsaAlgorithm.SlhDsaSha2_192s,
        "SLH-DSA-SHAKE-192s" => SlhDsaAlgorithm.SlhDsaShake192s,
        "SLH-DSA-SHA2-192f" => SlhDsaAlgorithm.SlhDsaSha2_192f,
        "SLH-DSA-SHAKE-192f" => SlhDsaAlgorithm.SlhDsaShake192f,
        "SLH-DSA-SHA2-256s" => SlhDsaAlgorithm.SlhDsaSha2_256s,
        "SLH-DSA-SHAKE-256s" => SlhDsaAlgorithm.SlhDsaShake256s,
        "SLH-DSA-SHA2-256f" => SlhDsaAlgorithm.SlhDsaSha2_256f,
        "SLH-DSA-SHAKE-256f" => SlhDsaAlgorithm.SlhDsaShake256f,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    public static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }

        return bytes;
    }
}
