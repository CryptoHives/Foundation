// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes a variable-length output using TurboSHAKE256 (XOF) per RFC 9861.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of TurboSHAKE256 based on the reduced-round
/// Keccak permutation. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// TurboSHAKE256 is an extendable-output function (XOF) based on a reduced-round
/// Keccak-p[1600, n_r=12] permutation with 12 rounds instead of 24 used in SHAKE.
/// It provides 256-bit security strength and is approximately twice as fast as SHAKE256.
/// </para>
/// <para>
/// TurboSHAKE256 uses a rate of 136 bytes (1088 bits) and a capacity of 64 bytes (512 bits).
/// </para>
/// <para>
/// The domain separation byte D must be in the range [0x01, 0x7F]. The default value is 0x1F.
/// </para>
/// </remarks>
public sealed class TurboShake256 : KeccakXofCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 512;

    /// <summary>
    /// The rate in bytes (1088 bits for TurboShake256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The capacity in bytes (512 bits for TurboShake256).
    /// </summary>
    public const int CapacityBytes = 64;

    /// <summary>
    /// The TurboShake domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x1F;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake256"/> class with default output size.
    /// </summary>
    public TurboShake256() : this(DefaultOutputBits / 8)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake256"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public TurboShake256(int outputBytes) : this(SimdSupport.KeccakDefault, outputBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake256"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte (must be in range [0x01, 0x7F]).</param>
    public TurboShake256(int outputBytes, byte domainSeparator) : this(SimdSupport.KeccakDefault, outputBytes, domainSeparator)
    {
    }

    internal TurboShake256(SimdSupport simdSupport, int outputBytes) : this(simdSupport, outputBytes, DomainSeparator)
    {
    }

    internal TurboShake256(SimdSupport simdSupport, int outputBytes, byte domainSeparator) : base(RateBytes, outputBytes, domainSeparator, simdSupport)
    {
        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        if (domainSeparator < 0x01 || domainSeparator > 0x7F)
        {
            throw new ArgumentOutOfRangeException(nameof(domainSeparator), "Domain separator must be in range [0x01, 0x7F].");
        }

        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "TurboSHAKE256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <inheritdoc/>
    protected override int StartRound => 12;

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake256"/> class with default output size.
    /// </summary>
    /// <returns>A new TurboShake256 instance.</returns>
    public static new TurboShake256 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake256"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new TurboShake256 instance.</returns>
    public static TurboShake256 Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake256"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte.</param>
    /// <returns>A new TurboShake256 instance.</returns>
    public static TurboShake256 Create(int outputBytes, byte domainSeparator) => new(outputBytes, domainSeparator);

    internal static TurboShake256 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8) => new(simdSupport, outputBytes);

    internal static TurboShake256 Create(SimdSupport simdSupport, int outputBytes, byte domainSeparator) => new(simdSupport, outputBytes, domainSeparator);
}

