// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Describes an ML-KEM parameter set (FIPS 203 Table 1) and its key, ciphertext,
/// and shared secret sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons (<see cref="MlKem512"/>, <see cref="MlKem768"/>,
/// <see cref="MlKem1024"/>) and compared by reference. The API shape mirrors
/// <c>System.Security.Cryptography.MLKemAlgorithm</c> from .NET 10 so code written
/// against the in-box types ports directly to older target frameworks.
/// </remarks>
public sealed class MlKemAlgorithm
{
    /// <summary>
    /// Gets the ML-KEM-512 parameter set (NIST security category 1).
    /// </summary>
    public static MlKemAlgorithm MlKem512 { get; } = new("ML-KEM-512", MlKemParams.MlKem512);

    /// <summary>
    /// Gets the ML-KEM-768 parameter set (NIST security category 3).
    /// </summary>
    public static MlKemAlgorithm MlKem768 { get; } = new("ML-KEM-768", MlKemParams.MlKem768);

    /// <summary>
    /// Gets the ML-KEM-1024 parameter set (NIST security category 5).
    /// </summary>
    public static MlKemAlgorithm MlKem1024 { get; } = new("ML-KEM-1024", MlKemParams.MlKem1024);

    private MlKemAlgorithm(string name, MlKemParams parameters)
    {
        Name = name;
        Parameters = parameters;
    }

    /// <summary>
    /// Gets the algorithm name, e.g. <c>ML-KEM-768</c>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the size of the encapsulation (public) key in bytes.
    /// </summary>
    public int EncapsulationKeySizeInBytes => Parameters.EncapsulationKeyBytes;

    /// <summary>
    /// Gets the size of the expanded decapsulation (private) key in bytes.
    /// </summary>
    public int DecapsulationKeySizeInBytes => Parameters.DecapsulationKeyBytes;

    /// <summary>
    /// Gets the size of the ciphertext in bytes.
    /// </summary>
    public int CiphertextSizeInBytes => Parameters.CiphertextBytes;

    /// <summary>
    /// Gets the size of the shared secret in bytes (32).
    /// </summary>
    public int SharedSecretSizeInBytes => MlKemParams.SharedSecretBytes;

    /// <summary>
    /// Gets the size of the private seed (d ‖ z) in bytes (64).
    /// </summary>
    public int PrivateSeedSizeInBytes => MlKemParams.KeyGenSeedBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal MlKemParams Parameters { get; }

    /// <inheritdoc/>
    public override string ToString() => Name;
}
