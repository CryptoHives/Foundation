// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// ML-DSA-65 digital signature algorithm (NIST security category 3).
/// </summary>
/// <remarks>
/// <para>
/// ML-DSA-65 is a post-quantum digital signature scheme standardized in
/// <see href="https://csrc.nist.gov/pubs/fips/204/final">FIPS 204</see>, derived from
/// CRYSTALS-Dilithium and based on the Module-LWE problem.
/// </para>
/// <para>
/// <b>Parameters (FIPS 204 Table 1):</b> (k, ℓ) = (6, 5), η = 4, τ = 49, γ₁ = 2¹⁹.
/// Public key: 1952 bytes, secret key: 4032 bytes, signature: 3309 bytes.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var dsa = MlDsa65.Create();
///
/// byte[] pk = new byte[MlDsa65.PublicKeySizeBytesConst];
/// byte[] sk = new byte[MlDsa65.SecretKeySizeBytesConst];
/// dsa.GenerateKeyPair(pk, sk);
///
/// byte[] signature = new byte[MlDsa65.SignatureSizeBytesConst];
/// dsa.Sign(sk, message, context: default, signature);
///
/// bool valid = dsa.Verify(pk, message, context: default, signature);
/// </code>
/// </para>
/// </remarks>
public sealed class MlDsa65 : IDsa
{
    private static readonly MlDsaParams Params = MlDsaParams.MlDsa65;

    /// <summary>The public key size in bytes (1952 bytes).</summary>
    public const int PublicKeySizeBytesConst = 1952;

    /// <summary>The secret key size in bytes (4032 bytes).</summary>
    public const int SecretKeySizeBytesConst = 4032;

    /// <summary>The signature size in bytes (3309 bytes).</summary>
    public const int SignatureSizeBytesConst = 3309;

    /// <summary>The key generation seed size in bytes (32 bytes).</summary>
    public const int KeyGenSeedSizeBytesConst = MlDsaParams.KeyGenSeedBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="MlDsa65"/> class.
    /// </summary>
    public MlDsa65() { }

    /// <summary>
    /// Creates a new ML-DSA-65 instance.
    /// </summary>
    /// <returns>A new ML-DSA-65 instance.</returns>
    public static MlDsa65 Create() => new();

    /// <inheritdoc/>
    public string AlgorithmName => "ML-DSA-65";

    /// <inheritdoc/>
    public int PublicKeySizeBytes => PublicKeySizeBytesConst;

    /// <inheritdoc/>
    public int SecretKeySizeBytes => SecretKeySizeBytesConst;

    /// <inheritdoc/>
    public int SignatureSizeBytes => SignatureSizeBytesConst;

    /// <inheritdoc/>
    public void GenerateKeyPair(Span<byte> publicKey, Span<byte> secretKey)
        => MlDsaEngine.GenerateKeyPair(Params, publicKey, secretKey);

    /// <inheritdoc/>
    public void GenerateKeyPair(ReadOnlySpan<byte> seed, Span<byte> publicKey, Span<byte> secretKey)
        => MlDsaEngine.GenerateKeyPair(Params, seed, publicKey, secretKey);

    /// <inheritdoc/>
    public void Sign(ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, Span<byte> signature)
        => MlDsaEngine.Sign(Params, secretKey, message, context, deterministic: false, signature);

    /// <inheritdoc/>
    public void SignDeterministic(ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, Span<byte> signature)
        => MlDsaEngine.Sign(Params, secretKey, message, context, deterministic: true, signature);

    /// <inheritdoc/>
    public bool Verify(ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, ReadOnlySpan<byte> signature)
        => MlDsaEngine.Verify(Params, publicKey, message, context, signature);

    /// <inheritdoc/>
    public void Dispose()
    {
        // No sensitive state to clear — all keys are passed as parameters.
    }
}
