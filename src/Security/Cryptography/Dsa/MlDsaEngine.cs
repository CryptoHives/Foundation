// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// Shared argument validation and dispatch for the per-parameter-set ML-DSA classes.
/// </summary>
internal static class MlDsaEngine
{
    public static void GenerateKeyPair(MlDsaParams p, Span<byte> publicKey, Span<byte> secretKey)
    {
        if (publicKey.Length < p.PublicKeyBytes)
            throw new ArgumentException($"Public key buffer must be at least {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (secretKey.Length < p.SecretKeyBytes)
            throw new ArgumentException($"Secret key buffer must be at least {p.SecretKeyBytes} bytes.", nameof(secretKey));

        Span<byte> seed = stackalloc byte[MlDsaParams.KeyGenSeedBytes];
        MlDsaCore.GenerateRandomSeed(seed);
        MlDsaCore.KeyGen(p, seed, publicKey, secretKey);
        CryptographicOperations.ZeroMemory(seed);
    }

    public static void GenerateKeyPair(MlDsaParams p, ReadOnlySpan<byte> seed, Span<byte> publicKey, Span<byte> secretKey)
    {
        if (seed.Length != MlDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Seed must be exactly {MlDsaParams.KeyGenSeedBytes} bytes.", nameof(seed));
        if (publicKey.Length < p.PublicKeyBytes)
            throw new ArgumentException($"Public key buffer must be at least {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (secretKey.Length < p.SecretKeyBytes)
            throw new ArgumentException($"Secret key buffer must be at least {p.SecretKeyBytes} bytes.", nameof(secretKey));

        MlDsaCore.KeyGen(p, seed, publicKey, secretKey);
    }

    public static void Sign(MlDsaParams p, ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message,
                            ReadOnlySpan<byte> context, bool deterministic, Span<byte> signature)
    {
        if (secretKey.Length != p.SecretKeyBytes)
            throw new ArgumentException($"Secret key must be exactly {p.SecretKeyBytes} bytes.", nameof(secretKey));
        if (context.Length > MlDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MlDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (signature.Length < p.SignatureBytes)
            throw new ArgumentException($"Signature buffer must be at least {p.SignatureBytes} bytes.", nameof(signature));

        Span<byte> prefix = stackalloc byte[2 + MlDsaParams.MaxContextBytes];
        int prefixLength = MlDsaCore.BuildExternalPrefix(context, prefix);

        Span<byte> rnd = stackalloc byte[MlDsaParams.SignSeedBytes];
        if (!deterministic)
        {
            MlDsaCore.GenerateRandomSeed(rnd);
        }

        MlDsaCore.Sign(p, secretKey, prefix.Slice(0, prefixLength), message, rnd, signature);
        CryptographicOperations.ZeroMemory(rnd);
    }

    public static bool Verify(MlDsaParams p, ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message,
                              ReadOnlySpan<byte> context, ReadOnlySpan<byte> signature)
    {
        if (publicKey.Length != p.PublicKeyBytes)
            throw new ArgumentException($"Public key must be exactly {p.PublicKeyBytes} bytes.", nameof(publicKey));
        if (context.Length > MlDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MlDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (signature.Length != p.SignatureBytes)
            throw new ArgumentException($"Signature must be exactly {p.SignatureBytes} bytes.", nameof(signature));

        Span<byte> prefix = stackalloc byte[2 + MlDsaParams.MaxContextBytes];
        int prefixLength = MlDsaCore.BuildExternalPrefix(context, prefix);

        return MlDsaCore.Verify(p, publicKey, prefix.Slice(0, prefixLength), message, signature);
    }
}
