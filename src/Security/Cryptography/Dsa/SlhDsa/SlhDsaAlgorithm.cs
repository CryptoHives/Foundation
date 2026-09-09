// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores - The algorithm names are defined by the FIPS 205 standard and contain underscores.

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// Describes an SLH-DSA parameter set (FIPS 205 Table 2) and its key and signature sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons, and equality compares the algorithm name so a
/// descriptor still matches after crossing an assembly or serialization boundary. The API
/// shape mirrors <c>System.Security.Cryptography.SlhDsaAlgorithm</c> from .NET 10. The
/// <c>s</c> (small) sets minimize signature size at a high signing cost; the <c>f</c> (fast)
/// sets sign an order of magnitude faster with larger signatures. Verification is fast for
/// all sets.
/// </remarks>
public sealed class SlhDsaAlgorithm : IEquatable<SlhDsaAlgorithm>
{
    /// <summary>Gets the SLH-DSA-SHA2-128s parameter set (security category 1, small).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_128s { get; } = new(SlhDsaParams.Sha2_128s);

    /// <summary>Gets the SLH-DSA-SHAKE-128s parameter set (security category 1, small).</summary>
    public static SlhDsaAlgorithm SlhDsaShake128s { get; } = new(SlhDsaParams.Shake128s);

    /// <summary>Gets the SLH-DSA-SHA2-128f parameter set (security category 1, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_128f { get; } = new(SlhDsaParams.Sha2_128f);

    /// <summary>Gets the SLH-DSA-SHAKE-128f parameter set (security category 1, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaShake128f { get; } = new(SlhDsaParams.Shake128f);

    /// <summary>Gets the SLH-DSA-SHA2-192s parameter set (security category 3, small).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_192s { get; } = new(SlhDsaParams.Sha2_192s);

    /// <summary>Gets the SLH-DSA-SHAKE-192s parameter set (security category 3, small).</summary>
    public static SlhDsaAlgorithm SlhDsaShake192s { get; } = new(SlhDsaParams.Shake192s);

    /// <summary>Gets the SLH-DSA-SHA2-192f parameter set (security category 3, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_192f { get; } = new(SlhDsaParams.Sha2_192f);

    /// <summary>Gets the SLH-DSA-SHAKE-192f parameter set (security category 3, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaShake192f { get; } = new(SlhDsaParams.Shake192f);

    /// <summary>Gets the SLH-DSA-SHA2-256s parameter set (security category 5, small).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_256s { get; } = new(SlhDsaParams.Sha2_256s);

    /// <summary>Gets the SLH-DSA-SHAKE-256s parameter set (security category 5, small).</summary>
    public static SlhDsaAlgorithm SlhDsaShake256s { get; } = new(SlhDsaParams.Shake256s);

    /// <summary>Gets the SLH-DSA-SHA2-256f parameter set (security category 5, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaSha2_256f { get; } = new(SlhDsaParams.Sha2_256f);

    /// <summary>Gets the SLH-DSA-SHAKE-256f parameter set (security category 5, fast).</summary>
    public static SlhDsaAlgorithm SlhDsaShake256f { get; } = new(SlhDsaParams.Shake256f);

    private SlhDsaAlgorithm(SlhDsaParams parameters)
    {
        Parameters = parameters;
    }

    /// <summary>
    /// Gets the algorithm name, e.g. <c>SLH-DSA-SHAKE-128f</c>.
    /// </summary>
    public string Name => Parameters.Name;

    /// <summary>
    /// Gets the size of the public key in bytes (2n).
    /// </summary>
    public int PublicKeySizeInBytes => Parameters.PublicKeyBytes;

    /// <summary>
    /// Gets the size of the private key in bytes (4n).
    /// </summary>
    public int PrivateKeySizeInBytes => Parameters.SecretKeyBytes;

    /// <summary>
    /// Gets the size of a signature in bytes.
    /// </summary>
    public int SignatureSizeInBytes => Parameters.SignatureBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal SlhDsaParams Parameters { get; }

    /// <summary>
    /// Determines whether two parameter sets are the same.
    /// </summary>
    /// <param name="left">The first parameter set, or <see langword="null"/>.</param>
    /// <param name="right">The second parameter set, or <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if both operands describe the same parameter set.</returns>
    public static bool operator ==(SlhDsaAlgorithm? left, SlhDsaAlgorithm? right)
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
    public static bool operator !=(SlhDsaAlgorithm? left, SlhDsaAlgorithm? right) => !(left == right);

    /// <inheritdoc/>
    public bool Equals(SlhDsaAlgorithm? other) => other is not null && Name == other.Name;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as SlhDsaAlgorithm);

    /// <inheritdoc/>
    public override int GetHashCode() => Name.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Name;
}
