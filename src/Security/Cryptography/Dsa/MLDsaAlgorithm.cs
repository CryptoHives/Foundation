// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// Describes an ML-DSA parameter set (FIPS 204 Table 1) and its key and signature sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons (<see cref="MLDsa44"/>, <see cref="MLDsa65"/>,
/// <see cref="MLDsa87"/>) and compared by name, so they are also equal by reference. The
/// API shape mirrors <c>System.Security.Cryptography.MLDsaAlgorithm</c> from .NET 10 so code
/// written against the in-box types ports directly to older target frameworks.
/// </remarks>
public sealed class MLDsaAlgorithm : IEquatable<MLDsaAlgorithm>
{
    /// <summary>
    /// Gets the ML-DSA-44 parameter set (NIST security category 2).
    /// </summary>
    public static MLDsaAlgorithm MLDsa44 { get; } = new("ML-DSA-44", MLDsaParams.MLDsa44);

    /// <summary>
    /// Gets the ML-DSA-65 parameter set (NIST security category 3).
    /// </summary>
    public static MLDsaAlgorithm MLDsa65 { get; } = new("ML-DSA-65", MLDsaParams.MLDsa65);

    /// <summary>
    /// Gets the ML-DSA-87 parameter set (NIST security category 5).
    /// </summary>
    public static MLDsaAlgorithm MLDsa87 { get; } = new("ML-DSA-87", MLDsaParams.MLDsa87);

    private MLDsaAlgorithm(string name, MLDsaParams parameters)
    {
        Name = name;
        Parameters = parameters;
    }

    /// <summary>
    /// Gets the algorithm name, e.g. <c>ML-DSA-65</c>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the size of the public key in bytes.
    /// </summary>
    public int PublicKeySizeInBytes => Parameters.PublicKeyBytes;

    /// <summary>
    /// Gets the size of the secret key in bytes.
    /// </summary>
    public int PrivateKeySizeInBytes => Parameters.SecretKeyBytes;

    /// <summary>
    /// Gets the size of a signature in bytes.
    /// </summary>
    public int SignatureSizeInBytes => Parameters.SignatureBytes;

    /// <summary>
    /// Gets the size of the private seed ξ in bytes (32).
    /// </summary>
    public int PrivateSeedSizeInBytes => MLDsaParams.KeyGenSeedBytes;

    /// <summary>
    /// Gets the size of the externally computed μ value in bytes (64).
    /// </summary>
    public int MuSizeInBytes => MLDsaParams.MuBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal MLDsaParams Parameters { get; }

    /// <summary>
    /// Determines whether two parameter sets are the same.
    /// </summary>
    /// <param name="left">The first parameter set, or <see langword="null"/>.</param>
    /// <param name="right">The second parameter set, or <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if both operands describe the same parameter set.</returns>
    public static bool operator ==(MLDsaAlgorithm? left, MLDsaAlgorithm? right)
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
    public static bool operator !=(MLDsaAlgorithm? left, MLDsaAlgorithm? right) => !(left == right);

    /// <inheritdoc/>
    public bool Equals(MLDsaAlgorithm? other) => other is not null && Name == other.Name;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as MLDsaAlgorithm);

    /// <inheritdoc/>
    public override int GetHashCode() => Name.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Name;
}
