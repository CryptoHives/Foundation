// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes a variable-length output using TurboSHAKE128 (XOF) per RFC 9861.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of TurboSHAKE128 based on the reduced-round
/// Keccak permutation. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// TurboSHAKE128 is an extendable-output function (XOF) based on a reduced-round
/// Keccak-p[1600, n_r=12] permutation with 12 rounds instead of 24 used in SHAKE.
/// It provides 128-bit security strength and is approximately twice as fast as SHAKE128.
/// </para>
/// <para>
/// TurboSHAKE128 uses a rate of 168 bytes (1344 bits) and a capacity of 32 bytes (256 bits).
/// </para>
/// <para>
/// The domain separation byte D must be in the range [0x01, 0x7F]. The default value is 0x1F.
/// </para>
/// </remarks>
public sealed class TurboShake128 : KeccakXofCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for TurboShake128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The capacity in bytes (256 bits for TurboShake128).
    /// </summary>
    public const int CapacityBytes = 32;

    /// <summary>
    /// The TurboShake domain separation byte.
    /// </summary>
    public const byte DomainSeparator = 0x1F;

    /// <summary>
    /// The start round for the sponge construction.
    /// </summary>
    public const int StartRound = 12;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with default output size.
    /// </summary>
    public TurboShake128() : this(DefaultOutputBits / 8)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public TurboShake128(int outputBytes) : this(SimdSupport.KeccakDefault, outputBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte (must be in range [0x01, 0x7F]).</param>
    public TurboShake128(int outputBytes, byte domainSeparator) : this(SimdSupport.KeccakDefault, outputBytes, domainSeparator)
    {
    }

    internal TurboShake128(SimdSupport simdSupport, int outputBytes) : this(simdSupport, outputBytes, DomainSeparator)
    {
    }

    internal TurboShake128(SimdSupport simdSupport, int outputBytes, byte domainSeparator) :
        base(RateBytes, outputBytes, domainSeparator, StartRound, simdSupport)
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
    public override string AlgorithmName => "TurboSHAKE128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with default output size.
    /// </summary>
    /// <returns>A new TurboShake128 instance.</returns>
    public static new TurboShake128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new TurboShake128 instance.</returns>
    public static TurboShake128 Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte.</param>
    /// <returns>A new TurboShake128 instance.</returns>
    public static TurboShake128 Create(int outputBytes, byte domainSeparator) => new(outputBytes, domainSeparator);

    internal static TurboShake128 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8) => new(simdSupport, outputBytes);

    internal static TurboShake128 Create(SimdSupport simdSupport, int outputBytes, byte domainSeparator) => new(simdSupport, outputBytes, domainSeparator);

    /// <summary>
    /// Computes the TurboSHAKE128 hash of <paramref name="source"/> using the default output size
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>32</c> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<TurboShake128>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the TurboSHAKE128 hash of <paramref name="source"/> using the default output size
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the TurboSHAKE128 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<TurboShake128>.HashData(source);

    /// <summary>
    /// Computes the TurboSHAKE128 hash of <paramref name="source"/> using the default output size
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>32</c> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<TurboShake128>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the TurboSHAKE128 hash of <paramref name="source"/> using the default output size
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the TurboSHAKE128 hash.</returns>
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<TurboShake128>.HashData(source);
}

