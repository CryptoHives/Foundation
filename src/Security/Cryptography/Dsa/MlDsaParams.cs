// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Defines the parameter sets for ML-DSA as specified in FIPS 204 Table 1.
/// </summary>
internal sealed class MlDsaParams
{
    /// <summary>ML-DSA-44 parameter set (NIST security category 2).</summary>
    public static readonly MlDsaParams MlDsa44 = new(k: 4, l: 4, eta: 2, tau: 39, gamma1Bits: 17, gamma2: (Q - 1) / 88, omega: 80, lambda: 128);

    /// <summary>ML-DSA-65 parameter set (NIST security category 3).</summary>
    public static readonly MlDsaParams MlDsa65 = new(k: 6, l: 5, eta: 4, tau: 49, gamma1Bits: 19, gamma2: (Q - 1) / 32, omega: 55, lambda: 192);

    /// <summary>ML-DSA-87 parameter set (NIST security category 5).</summary>
    public static readonly MlDsaParams MlDsa87 = new(k: 8, l: 7, eta: 2, tau: 60, gamma1Bits: 19, gamma2: (Q - 1) / 32, omega: 75, lambda: 256);

    /// <summary>The polynomial degree.</summary>
    public const int N = 256;

    /// <summary>The modulus q = 8380417 = 2²³ − 2¹³ + 1.</summary>
    public const int Q = 8380417;

    /// <summary>The number of dropped bits d from vector t.</summary>
    public const int D = 13;

    /// <summary>The key generation seed size in bytes (ξ = 32 bytes).</summary>
    public const int KeyGenSeedBytes = 32;

    /// <summary>The signing randomness size in bytes (rnd = 32 bytes).</summary>
    public const int SignSeedBytes = 32;

    /// <summary>The maximum context string length in bytes.</summary>
    public const int MaxContextBytes = 255;

    /// <summary>The module dimensions of matrix A (k rows).</summary>
    public readonly int K;

    /// <summary>The module dimensions of matrix A (ℓ columns).</summary>
    public readonly int L;

    /// <summary>The private key range parameter η ∈ {2, 4}.</summary>
    public readonly int Eta;

    /// <summary>The number of ±1 coefficients in the challenge polynomial c.</summary>
    public readonly int Tau;

    /// <summary>β = τ·η, the rejection bound offset.</summary>
    public readonly int Beta;

    /// <summary>The mask coefficient range γ₁ = 2¹⁷ or 2¹⁹.</summary>
    public readonly int Gamma1;

    /// <summary>The low-order rounding range γ₂ = (q−1)/88 or (q−1)/32.</summary>
    public readonly int Gamma2;

    /// <summary>The maximum total number of hint bits ω.</summary>
    public readonly int Omega;

    /// <summary>The collision strength parameter λ in bits; c̃ is λ/4 bytes.</summary>
    public readonly int Lambda;

    /// <summary>The size of the commitment hash c̃ in bytes (λ/4).</summary>
    public readonly int CTildeBytes;

    /// <summary>Bits per coefficient when packing z: 1 + bitlen(γ₁ − 1).</summary>
    public readonly int ZBits;

    /// <summary>Bits per coefficient when packing s1/s2: bitlen(2η).</summary>
    public readonly int EtaBits;

    /// <summary>Bits per coefficient when packing w1.</summary>
    public readonly int W1Bits;

    /// <summary>The public key size in bytes: 32 + 320·k.</summary>
    public readonly int PublicKeyBytes;

    /// <summary>The secret key size in bytes: 128 + 32·((k+ℓ)·bitlen(2η) + 13·k).</summary>
    public readonly int SecretKeyBytes;

    /// <summary>The signature size in bytes: λ/4 + ℓ·32·zBits + ω + k.</summary>
    public readonly int SignatureBytes;

    private MlDsaParams(int k, int l, int eta, int tau, int gamma1Bits, int gamma2, int omega, int lambda)
    {
        K = k;
        L = l;
        Eta = eta;
        Tau = tau;
        Beta = tau * eta;
        Gamma1 = 1 << gamma1Bits;
        Gamma2 = gamma2;
        Omega = omega;
        Lambda = lambda;

        CTildeBytes = lambda / 4;
        ZBits = gamma1Bits + 1;
        EtaBits = eta == 2 ? 3 : 4;
        W1Bits = gamma2 == (Q - 1) / 88 ? 6 : 4;

        // FIPS 204 §7.1/7.2/7.3: sizes
        PublicKeyBytes = 32 + 32 * 10 * k;
        SecretKeyBytes = 32 + 32 + 64 + 32 * ((k + l) * EtaBits + D * k);
        SignatureBytes = CTildeBytes + l * 32 * ZBits + omega + k;
    }
}
