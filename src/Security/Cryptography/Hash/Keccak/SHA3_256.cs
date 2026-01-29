// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the SHA3-256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA3-256 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// SHA3-256 produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA3_256 : KeccakHashCore
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
    /// The rate in bytes (1088 bits for SHA3-256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The capacity in bytes.
    /// </summary>
    public const int CapacityBytes = 64;

    /// <summary>
    /// The SHA-3 domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x06;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_256"/> class.
    /// </summary>
    public SHA3_256() : this(SimdSupport.KeccakDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal SHA3_256(SimdSupport simdSupport) : base(RateBytes, HashSizeBytes, DomainSeparator, simdSupport)
    {
        HashSizeValue = HashSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA3-256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_256"/> class.
    /// </summary>
    /// <returns>A new SHA3-256 hash algorithm instance.</returns>
    public static new SHA3_256 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA3-256 hash algorithm instance.</returns>
    internal static SHA3_256 Create(SimdSupport simdSupport) => new(simdSupport);
}
