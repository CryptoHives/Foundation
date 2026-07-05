// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Describes an SLH-DSA parameter set (FIPS 205 Table 2) and its key and signature sizes.
/// </summary>
/// <remarks>
/// Instances are exposed as singletons and compared by reference. The API shape mirrors
/// <c>System.Security.Cryptography.SlhDsaAlgorithm</c> from .NET 10. The <c>s</c> (small)
/// sets minimize signature size at a high signing cost; the <c>f</c> (fast) sets sign an
/// order of magnitude faster with larger signatures. Verification is fast for all sets.
/// </remarks>
public sealed class SlhDsaAlgorithm
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
    /// Gets the size of the secret key in bytes (4n).
    /// </summary>
    public int SecretKeySizeInBytes => Parameters.SecretKeyBytes;

    /// <summary>
    /// Gets the size of a signature in bytes.
    /// </summary>
    public int SignatureSizeInBytes => Parameters.SignatureBytes;

    /// <summary>
    /// Gets the internal parameter set.
    /// </summary>
    internal SlhDsaParams Parameters { get; }

    /// <inheritdoc/>
    public override string ToString() => Name;
}
