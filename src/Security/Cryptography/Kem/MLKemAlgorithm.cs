// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;

/// <summary>
/// Describes an ML-KEM parameter set (FIPS 203 Table 1) and its key, ciphertext,
/// and shared secret sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons (<see cref="MLKemAlgorithm.MLKem512"/>,
/// <see cref="MLKemAlgorithm.MLKem768"/>, <see cref="MLKemAlgorithm.MLKem1024"/>) and
/// compared by name, so they are also equal by reference. The API shape mirrors
/// <c>System.Security.Cryptography.MLKemAlgorithm</c> from .NET 10 so code written
/// against the in-box types ports directly to older target frameworks.
/// </remarks>
public sealed class MLKemAlgorithm : IEquatable<MLKemAlgorithm>
{
    /// <summary>
    /// Gets the ML-KEM-512 parameter set (NIST security category 1).
    /// </summary>
    public static MLKemAlgorithm MLKem512 { get; } = new("ML-KEM-512", MLKemParams.MLKem512);

    /// <summary>
    /// Gets the ML-KEM-768 parameter set (NIST security category 3).
    /// </summary>
    public static MLKemAlgorithm MLKem768 { get; } = new("ML-KEM-768", MLKemParams.MLKem768);

    /// <summary>
    /// Gets the ML-KEM-1024 parameter set (NIST security category 5).
    /// </summary>
    public static MLKemAlgorithm MLKem1024 { get; } = new("ML-KEM-1024", MLKemParams.MLKem1024);

    private MLKemAlgorithm(string name, MLKemParams parameters)
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
    public int SharedSecretSizeInBytes => MLKemParams.SharedSecretBytes;

    /// <summary>
    /// Gets the size of the private seed (d ‖ z) in bytes (64).
    /// </summary>
    public int PrivateSeedSizeInBytes => MLKemParams.KeyGenSeedBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal MLKemParams Parameters { get; }

    /// <summary>
    /// Determines whether two parameter sets are the same.
    /// </summary>
    /// <param name="left">The first parameter set, or <see langword="null"/>.</param>
    /// <param name="right">The second parameter set, or <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if both operands describe the same parameter set.</returns>
    public static bool operator ==(MLKemAlgorithm? left, MLKemAlgorithm? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        return left is not null && left.Equals(right);
    }

    /// <summary>
    /// Determines whether two parameter sets are different.
    /// </summary>
    /// <param name="left">The first parameter set, or <see langword="null"/>.</param>
    /// <param name="right">The second parameter set, or <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the operands describe different parameter sets.</returns>
    public static bool operator !=(MLKemAlgorithm? left, MLKemAlgorithm? right) => !(left == right);

    /// <inheritdoc/>
    public bool Equals(MLKemAlgorithm? other) => other is not null && Name == other.Name;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as MLKemAlgorithm);

    /// <inheritdoc/>
    public override int GetHashCode() => Name.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Name;
}
