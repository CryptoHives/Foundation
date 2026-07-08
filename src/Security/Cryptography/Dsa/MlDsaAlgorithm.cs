// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Describes an ML-DSA parameter set (FIPS 204 Table 1) and its key and signature sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons (<see cref="MlDsa44"/>, <see cref="MlDsa65"/>,
/// <see cref="MlDsa87"/>) and compared by reference. The API shape mirrors
/// <c>System.Security.Cryptography.MLDsaAlgorithm</c> from .NET 10 so code written
/// against the in-box types ports directly to older target frameworks.
/// </remarks>
public sealed class MlDsaAlgorithm
{
    /// <summary>
    /// Gets the ML-DSA-44 parameter set (NIST security category 2).
    /// </summary>
    public static MlDsaAlgorithm MlDsa44 { get; } = new("ML-DSA-44", MlDsaParams.MlDsa44);

    /// <summary>
    /// Gets the ML-DSA-65 parameter set (NIST security category 3).
    /// </summary>
    public static MlDsaAlgorithm MlDsa65 { get; } = new("ML-DSA-65", MlDsaParams.MlDsa65);

    /// <summary>
    /// Gets the ML-DSA-87 parameter set (NIST security category 5).
    /// </summary>
    public static MlDsaAlgorithm MlDsa87 { get; } = new("ML-DSA-87", MlDsaParams.MlDsa87);

    private MlDsaAlgorithm(string name, MlDsaParams parameters)
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
    public int SecretKeySizeInBytes => Parameters.SecretKeyBytes;

    /// <summary>
    /// Gets the size of a signature in bytes.
    /// </summary>
    public int SignatureSizeInBytes => Parameters.SignatureBytes;

    /// <summary>
    /// Gets the size of the private seed ξ in bytes (32).
    /// </summary>
    public int PrivateSeedSizeInBytes => MlDsaParams.KeyGenSeedBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal MlDsaParams Parameters { get; }

    /// <inheritdoc/>
    public override string ToString() => Name;
}
