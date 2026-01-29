// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes a variable-length output using SHAKE128 (XOF).
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHAKE128 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// SHAKE128 is an extendable-output function (XOF) based on the Keccak sponge construction.
/// Unlike traditional hash functions, XOFs can produce output of arbitrary length.
/// </para>
/// <para>
/// SHAKE128 provides 128-bit security strength against all attacks.
/// </para>
/// </remarks>
public sealed class Shake128 : KeccakXofCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for SHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The capacity in bytes (256 bits for SHAKE128).
    /// </summary>
    public const int CapacityBytes = 32;

    /// <summary>
    /// The SHAKE domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x1F;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake128"/> class with default output size.
    /// </summary>
    public Shake128() : this(DefaultOutputBits / 8)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Shake128(int outputBytes) : this(SimdSupport.KeccakDefault, outputBytes)
    {
    }

    internal Shake128(SimdSupport simdSupport, int outputBytes) : base(RateBytes, outputBytes, DomainSeparator, simdSupport)
    {
        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHAKE128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Shake128"/> class with default output size.
    /// </summary>
    /// <returns>A new SHAKE128 instance.</returns>
    public static new Shake128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Shake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new SHAKE128 instance.</returns>
    public static Shake128 Create(int outputBytes) => new(outputBytes);

    internal static Shake128 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8) => new(simdSupport, outputBytes);
}

