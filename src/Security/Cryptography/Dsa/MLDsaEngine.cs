// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// Shared argument validation and dispatch for the per-parameter-set ML-DSA classes.
/// </summary>
internal static class MLDsaEngine
{
    public static void GenerateKeyPair(MLDsaParams p, Span<byte> publicKey, Span<byte> secretKey,
                                       bool pairwiseConsistencyTest)
    {
        if (publicKey.Length < p.PublicKeyBytes)
            throw new ArgumentException($"Public key buffer must be at least {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (secretKey.Length < p.SecretKeyBytes)
            throw new ArgumentException($"Secret key buffer must be at least {p.SecretKeyBytes} bytes.", nameof(secretKey));

        Span<byte> seed = stackalloc byte[MLDsaParams.KeyGenSeedBytes];
        MLDsaCore.GenerateRandomSeed(seed);
        MLDsaCore.KeyGen(p, seed, publicKey, secretKey, pairwiseConsistencyTest);
        CryptographicOperations.ZeroMemory(seed);
    }

    public static void GenerateKeyPair(MLDsaParams p, ReadOnlySpan<byte> seed, Span<byte> publicKey,
                                       Span<byte> secretKey, bool pairwiseConsistencyTest)
    {
        if (seed.Length != MLDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Seed must be exactly {MLDsaParams.KeyGenSeedBytes} bytes.", nameof(seed));
        if (publicKey.Length < p.PublicKeyBytes)
            throw new ArgumentException($"Public key buffer must be at least {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (secretKey.Length < p.SecretKeyBytes)
            throw new ArgumentException($"Secret key buffer must be at least {p.SecretKeyBytes} bytes.", nameof(secretKey));

        MLDsaCore.KeyGen(p, seed, publicKey, secretKey, pairwiseConsistencyTest);
    }

    public static void Sign(MLDsaParams p, ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message,
                            ReadOnlySpan<byte> context, bool deterministic, Span<byte> signature)
    {
        if (secretKey.Length != p.SecretKeyBytes)
            throw new ArgumentException($"Secret key must be exactly {p.SecretKeyBytes} bytes.", nameof(secretKey));
        if (context.Length > MLDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MLDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (signature.Length < p.SignatureBytes)
            throw new ArgumentException($"Signature buffer must be at least {p.SignatureBytes} bytes.", nameof(signature));

        Span<byte> prefix = stackalloc byte[2 + MLDsaParams.MaxContextBytes];
        int prefixLength = MLDsaCore.BuildExternalPrefix(context, prefix);

        Span<byte> rnd = stackalloc byte[MLDsaParams.SignSeedBytes];
        if (!deterministic)
        {
            MLDsaCore.GenerateRandomSeed(rnd);
        }

        MLDsaCore.Sign(p, secretKey, prefix.Slice(0, prefixLength), message, rnd, signature);
        CryptographicOperations.ZeroMemory(rnd);
    }

    public static bool Verify(MLDsaParams p, ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message,
                              ReadOnlySpan<byte> context, ReadOnlySpan<byte> signature)
    {
        if (publicKey.Length != p.PublicKeyBytes)
            throw new ArgumentException($"Public key must be exactly {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (context.Length > MLDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MLDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (signature.Length != p.SignatureBytes)
            throw new ArgumentException($"Signature must be exactly {p.SignatureBytes} bytes.", nameof(signature));

        Span<byte> prefix = stackalloc byte[2 + MLDsaParams.MaxContextBytes];
        int prefixLength = MLDsaCore.BuildExternalPrefix(context, prefix);

        return MLDsaCore.Verify(p, publicKey, prefix.Slice(0, prefixLength), message, signature);
    }
}
