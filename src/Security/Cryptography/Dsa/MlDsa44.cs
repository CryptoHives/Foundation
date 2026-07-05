// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// ML-DSA-44 digital signature algorithm (NIST security category 2).
/// </summary>
/// <remarks>
/// <para>
/// ML-DSA-44 is a post-quantum digital signature scheme standardized in
/// <see href="https://csrc.nist.gov/pubs/fips/204/final">FIPS 204</see>, derived from
/// CRYSTALS-Dilithium and based on the Module-LWE problem.
/// </para>
/// <para>
/// <b>Parameters (FIPS 204 Table 1):</b> (k, ℓ) = (4, 4), η = 2, τ = 39, γ₁ = 2¹⁷.
/// Public key: 1312 bytes, secret key: 2560 bytes, signature: 2420 bytes.
/// </para>
/// </remarks>
public sealed class MlDsa44 : IDsa
{
    private static readonly MlDsaParams Params = MlDsaParams.MlDsa44;

    /// <summary>The public key size in bytes (1312 bytes).</summary>
    public const int PublicKeySizeBytesConst = 1312;

    /// <summary>The secret key size in bytes (2560 bytes).</summary>
    public const int SecretKeySizeBytesConst = 2560;

    /// <summary>The signature size in bytes (2420 bytes).</summary>
    public const int SignatureSizeBytesConst = 2420;

    /// <summary>The key generation seed size in bytes (32 bytes).</summary>
    public const int KeyGenSeedSizeBytesConst = MlDsaParams.KeyGenSeedBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="MlDsa44"/> class.
    /// </summary>
    public MlDsa44() { }

    /// <summary>
    /// Creates a new ML-DSA-44 instance.
    /// </summary>
    /// <returns>A new ML-DSA-44 instance.</returns>
    public static MlDsa44 Create() => new();

    /// <inheritdoc/>
    public string AlgorithmName => "ML-DSA-44";

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
