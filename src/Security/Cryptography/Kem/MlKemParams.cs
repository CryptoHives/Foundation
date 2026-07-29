// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Defines the parameter sets for ML-KEM as specified in FIPS 203 Table 1.
/// </summary>
internal sealed class MlKemParams
{
    /// <summary>ML-KEM-512 parameter set (NIST security category 1).</summary>
    public static readonly MlKemParams MlKem512 = new(k: 2, eta1: 3, eta2: 2, du: 10, dv: 4);

    /// <summary>ML-KEM-768 parameter set (NIST security category 3).</summary>
    public static readonly MlKemParams MlKem768 = new(k: 3, eta1: 2, eta2: 2, du: 10, dv: 4);

    /// <summary>ML-KEM-1024 parameter set (NIST security category 5).</summary>
    public static readonly MlKemParams MlKem1024 = new(k: 4, eta1: 2, eta2: 2, du: 11, dv: 5);

    /// <summary>The polynomial degree.</summary>
    public const int N = 256;

    /// <summary>The modulus q = 3329.</summary>
    public const int Q = 3329;

    /// <summary>The shared secret size in bytes.</summary>
    public const int SharedSecretBytes = 32;

    /// <summary>The seed size for key generation (d ‖ z = 64 bytes).</summary>
    public const int KeyGenSeedBytes = 64;

    /// <summary>The randomness size for encapsulation (m = 32 bytes).</summary>
    public const int EncapsSeedBytes = 32;

    /// <summary>The module rank (number of polynomials per vector).</summary>
    public readonly int K;

    /// <summary>The CBD parameter for secret/error vector generation during key generation.</summary>
    public readonly int Eta1;

    /// <summary>The CBD parameter for error vector generation during encryption.</summary>
    public readonly int Eta2;

    /// <summary>The number of bits for compressing the <c>u</c> component of the ciphertext.</summary>
    public readonly int Du;

    /// <summary>The number of bits for compressing the <c>v</c> component of the ciphertext.</summary>
    public readonly int Dv;

    /// <summary>The encapsulation key size in bytes: 384·k + 32.</summary>
    public readonly int EncapsulationKeyBytes;

    /// <summary>The decapsulation key size in bytes: 768·k + 96.</summary>
    public readonly int DecapsulationKeyBytes;

    /// <summary>The ciphertext size in bytes: 32·(du·k + dv).</summary>
    public readonly int CiphertextBytes;

    /// <summary>Byte size of the encoded polynomial vector s (384·k).</summary>
    public readonly int PolyVecEncodedBytes;

    /// <summary>Byte size of the compressed u vector: 32·du·k.</summary>
    public readonly int PolyVecCompressedBytes;

    /// <summary>Byte size of the compressed v polynomial: 32·dv.</summary>
    public readonly int PolyCompressedBytes;

    private MlKemParams(int k, int eta1, int eta2, int du, int dv)
    {
        K = k;
        Eta1 = eta1;
        Eta2 = eta2;
        Du = du;
        Dv = dv;

        // FIPS 203 §7: sizes
        PolyVecEncodedBytes = 384 * k;
        EncapsulationKeyBytes = PolyVecEncodedBytes + 32;
        DecapsulationKeyBytes = 768 * k + 96;
        PolyVecCompressedBytes = 32 * du * k;
        PolyCompressedBytes = 32 * dv;
        CiphertextBytes = PolyVecCompressedBytes + PolyCompressedBytes;
    }
}
