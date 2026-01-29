// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Computes the Keccak-384 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is the original Keccak-384 algorithm, which differs from SHA3-384 in the
/// domain separator byte (0x01 vs 0x06).
/// </para>
/// <para>
/// Keccak-384 produces a 384-bit (48-byte) hash value.
/// </para>
/// </remarks>
public sealed class Keccak384 : KeccakHashCore
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 384;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The rate in bytes (832 bits for Keccak-384).
    /// </summary>
    public const int RateBytes = 104;

    /// <summary>
    /// The original Keccak domain separation byte (different from SHA-3).
    /// </summary>
    private const byte DomainSeparator = 0x01;

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak384"/> class.
    /// </summary>
    public Keccak384() : this(SimdSupport.KeccakDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak384"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Keccak384(SimdSupport simdSupport) : base(RateBytes, HashSizeBytes, DomainSeparator, simdSupport)
    {
        HashSizeValue = HashSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Keccak-384";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak384"/> class.
    /// </summary>
    /// <returns>A new Keccak-384 hash algorithm instance.</returns>
    public static new Keccak384 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak384"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new Keccak-384 hash algorithm instance.</returns>
    internal static Keccak384 Create(SimdSupport simdSupport) => new(simdSupport);
}
