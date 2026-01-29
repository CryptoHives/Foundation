// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the Keccak-256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is the original Keccak-256 algorithm as used by Ethereum, which differs from
/// SHA3-256 in the domain separator byte (0x01 vs 0x06).
/// </para>
/// <para>
/// Keccak-256 produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
public sealed class Keccak256 : KeccakHashCore
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 256;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The rate in bytes (1088 bits for Keccak-256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The original Keccak domain separation byte (different from SHA-3).
    /// </summary>
    private const byte DomainSeparator = 0x01;

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak256"/> class.
    /// </summary>
    public Keccak256() : this(SimdSupport.KeccakDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Keccak256(SimdSupport simdSupport) : base(RateBytes, HashSizeBytes, DomainSeparator, simdSupport)
    {
        HashSizeValue = HashSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Keccak-256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak256"/> class.
    /// </summary>
    /// <returns>A new Keccak-256 hash algorithm instance.</returns>
    public static new Keccak256 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new Keccak-256 hash algorithm instance.</returns>
    internal static Keccak256 Create(SimdSupport simdSupport) => new(simdSupport);
}
