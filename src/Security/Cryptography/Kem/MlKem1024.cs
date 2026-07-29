// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;

/// <summary>
/// ML-KEM-1024 Key Encapsulation Mechanism (NIST security category 5).
/// </summary>
/// <remarks>
/// <para>
/// ML-KEM-1024 is a post-quantum key encapsulation mechanism standardized in
/// <see href="https://csrc.nist.gov/pubs/fips/203/final">FIPS 203</see>.
/// It provides NIST security category 5 (equivalent to AES-256).
/// </para>
/// <para>
/// ML-KEM is based on the Module-Lattice problem and is designed to be secure
/// against both classical and quantum adversaries.
/// </para>
/// <para>
/// <b>Parameters (FIPS 203 Table 1):</b>
/// <list type="bullet">
///   <item><description>k = 4, η₁ = 2, η₂ = 2</description></item>
///   <item><description>Encapsulation key: 1568 bytes</description></item>
///   <item><description>Decapsulation key: 3168 bytes</description></item>
///   <item><description>Ciphertext: 1568 bytes</description></item>
///   <item><description>Shared secret: 32 bytes</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var kem = MlKem1024.Create();
///
/// // Key generation
/// byte[] ek = new byte[MlKem1024.EncapsulationKeySizeBytesConst];
/// byte[] dk = new byte[MlKem1024.DecapsulationKeySizeBytesConst];
/// kem.GenerateKeyPair(ek, dk);
///
/// // Encapsulation (sender)
/// byte[] ct = new byte[MlKem1024.CiphertextSizeBytesConst];
/// byte[] ss1 = new byte[MlKem1024.SharedSecretSizeBytesConst];
/// kem.Encapsulate(ek, ct, ss1);
///
/// // Decapsulation (receiver)
/// byte[] ss2 = new byte[MlKem1024.SharedSecretSizeBytesConst];
/// kem.Decapsulate(dk, ct, ss2);
/// // ss1 and ss2 are now identical 32-byte shared secrets
/// </code>
/// </para>
/// </remarks>
public sealed class MlKem1024 : IKem
{
    private static readonly MlKemParams Params = MlKemParams.MlKem1024;

    /// <summary>
    /// The shared secret size in bytes (32 bytes).
    /// </summary>
    public const int SharedSecretSizeBytesConst = MlKemParams.SharedSecretBytes;

    /// <summary>
    /// The encapsulation key size in bytes (1568 bytes).
    /// </summary>
    public const int EncapsulationKeySizeBytesConst = 1568;

    /// <summary>
    /// The decapsulation key size in bytes (3168 bytes).
    /// </summary>
    public const int DecapsulationKeySizeBytesConst = 3168;

    /// <summary>
    /// The ciphertext size in bytes (1568 bytes).
    /// </summary>
    public const int CiphertextSizeBytesConst = 1568;

    /// <summary>
    /// The key generation seed size in bytes (64 bytes).
    /// </summary>
    public const int KeyGenSeedSizeBytesConst = MlKemParams.KeyGenSeedBytes;

    /// <summary>
    /// The encapsulation seed size in bytes (32 bytes).
    /// </summary>
    public const int EncapsSeedSizeBytesConst = MlKemParams.EncapsSeedBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="MlKem1024"/> class.
    /// </summary>
    public MlKem1024() { }

    /// <summary>
    /// Creates a new ML-KEM-1024 instance.
    /// </summary>
    /// <returns>A new ML-KEM-1024 instance.</returns>
    public static MlKem1024 Create() => new();

    /// <inheritdoc/>
    public string AlgorithmName => "ML-KEM-1024";

    /// <inheritdoc/>
    public int SharedSecretSizeBytes => SharedSecretSizeBytesConst;

    /// <inheritdoc/>
    public int EncapsulationKeySizeBytes => EncapsulationKeySizeBytesConst;

    /// <inheritdoc/>
    public int DecapsulationKeySizeBytes => DecapsulationKeySizeBytesConst;

    /// <inheritdoc/>
    public int CiphertextSizeBytes => CiphertextSizeBytesConst;

    /// <inheritdoc/>
    public void GenerateKeyPair(Span<byte> encapsulationKey, Span<byte> decapsulationKey)
    {
        if (encapsulationKey.Length < EncapsulationKeySizeBytesConst)
            throw new ArgumentException($"Encapsulation key buffer must be at least {EncapsulationKeySizeBytesConst} bytes.", nameof(encapsulationKey));
        if (decapsulationKey.Length < DecapsulationKeySizeBytesConst)
            throw new ArgumentException($"Decapsulation key buffer must be at least {DecapsulationKeySizeBytesConst} bytes.", nameof(decapsulationKey));

        Span<byte> seed = stackalloc byte[MlKemParams.KeyGenSeedBytes];
        MlKemCore.GenerateRandomSeed(seed);
        MlKemCore.KeyGen(Params, seed, encapsulationKey, decapsulationKey);
    }

    /// <inheritdoc/>
    public void GenerateKeyPair(ReadOnlySpan<byte> seed, Span<byte> encapsulationKey, Span<byte> decapsulationKey)
    {
        if (seed.Length != MlKemParams.KeyGenSeedBytes)
            throw new ArgumentException($"Seed must be exactly {MlKemParams.KeyGenSeedBytes} bytes.", nameof(seed));
        if (encapsulationKey.Length < EncapsulationKeySizeBytesConst)
            throw new ArgumentException($"Encapsulation key buffer must be at least {EncapsulationKeySizeBytesConst} bytes.", nameof(encapsulationKey));
        if (decapsulationKey.Length < DecapsulationKeySizeBytesConst)
            throw new ArgumentException($"Decapsulation key buffer must be at least {DecapsulationKeySizeBytesConst} bytes.", nameof(decapsulationKey));

        MlKemCore.KeyGen(Params, seed, encapsulationKey, decapsulationKey);
    }

    /// <inheritdoc/>
    public void Encapsulate(ReadOnlySpan<byte> encapsulationKey, Span<byte> ciphertext, Span<byte> sharedSecret)
    {
        if (encapsulationKey.Length != EncapsulationKeySizeBytesConst)
            throw new ArgumentException($"Encapsulation key must be exactly {EncapsulationKeySizeBytesConst} bytes.", nameof(encapsulationKey));
        if (ciphertext.Length < CiphertextSizeBytesConst)
            throw new ArgumentException($"Ciphertext buffer must be at least {CiphertextSizeBytesConst} bytes.", nameof(ciphertext));
        if (sharedSecret.Length < SharedSecretSizeBytesConst)
            throw new ArgumentException($"Shared secret buffer must be at least {SharedSecretSizeBytesConst} bytes.", nameof(sharedSecret));

        if (!MlKemCore.IsValidEncapsulationKey(Params, encapsulationKey))
            throw new ArgumentException("Encapsulation key failed the FIPS 203 §7.2 modulus check.", nameof(encapsulationKey));

        Span<byte> m = stackalloc byte[MlKemParams.EncapsSeedBytes];
        MlKemCore.GenerateRandomSeed(m);
        MlKemCore.Encaps(Params, encapsulationKey, m, ciphertext, sharedSecret);
    }

    /// <inheritdoc/>
    public void Encapsulate(ReadOnlySpan<byte> encapsulationKey, ReadOnlySpan<byte> seed,
                            Span<byte> ciphertext, Span<byte> sharedSecret)
    {
        if (encapsulationKey.Length != EncapsulationKeySizeBytesConst)
            throw new ArgumentException($"Encapsulation key must be exactly {EncapsulationKeySizeBytesConst} bytes.", nameof(encapsulationKey));
        if (seed.Length != MlKemParams.EncapsSeedBytes)
            throw new ArgumentException($"Seed must be exactly {MlKemParams.EncapsSeedBytes} bytes.", nameof(seed));
        if (ciphertext.Length < CiphertextSizeBytesConst)
            throw new ArgumentException($"Ciphertext buffer must be at least {CiphertextSizeBytesConst} bytes.", nameof(ciphertext));
        if (sharedSecret.Length < SharedSecretSizeBytesConst)
            throw new ArgumentException($"Shared secret buffer must be at least {SharedSecretSizeBytesConst} bytes.", nameof(sharedSecret));

        if (!MlKemCore.IsValidEncapsulationKey(Params, encapsulationKey))
            throw new ArgumentException("Encapsulation key failed the FIPS 203 §7.2 modulus check.", nameof(encapsulationKey));

        MlKemCore.Encaps(Params, encapsulationKey, seed, ciphertext, sharedSecret);
    }

    /// <inheritdoc/>
    public void Decapsulate(ReadOnlySpan<byte> decapsulationKey, ReadOnlySpan<byte> ciphertext,
                            Span<byte> sharedSecret)
    {
        if (decapsulationKey.Length != DecapsulationKeySizeBytesConst)
            throw new ArgumentException($"Decapsulation key must be exactly {DecapsulationKeySizeBytesConst} bytes.", nameof(decapsulationKey));
        if (ciphertext.Length != CiphertextSizeBytesConst)
            throw new ArgumentException($"Ciphertext must be exactly {CiphertextSizeBytesConst} bytes.", nameof(ciphertext));
        if (sharedSecret.Length < SharedSecretSizeBytesConst)
            throw new ArgumentException($"Shared secret buffer must be at least {SharedSecretSizeBytesConst} bytes.", nameof(sharedSecret));

        if (!MlKemCore.IsValidDecapsulationKey(Params, decapsulationKey))
            throw new ArgumentException("Decapsulation key failed the FIPS 203 §7.3 hash check.", nameof(decapsulationKey));

        MlKemCore.Decaps(Params, decapsulationKey, ciphertext, sharedSecret);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // No sensitive state to clear — all keys are passed as parameters.
    }
}
