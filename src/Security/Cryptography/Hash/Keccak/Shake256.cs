// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes a variable-length output using SHAKE256 (XOF).
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHAKE256 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// SHAKE256 is an extendable-output function (XOF) based on the Keccak sponge construction.
/// Unlike traditional hash functions, XOFs can produce output of arbitrary length.
/// </para>
/// <para>
/// SHAKE256 provides 256-bit security strength against all attacks.
/// </para>
/// </remarks>
public sealed class Shake256 : KeccakXofCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 512;

    /// <summary>
    /// The rate in bytes (1088 bits for SHAKE256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The capacity in bytes (512 bits for SHAKE256).
    /// </summary>
    public const int CapacityBytes = 64;

    /// <summary>
    /// The SHAKE domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x1F;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake256"/> class with default output size.
    /// </summary>
    public Shake256() : this(DefaultOutputBits / 8)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake256"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Shake256(int outputBytes) : this(SimdSupport.KeccakDefault, outputBytes)
    {
    }

    internal Shake256(SimdSupport simdSupport, int outputBytes)
        : base(RateBytes, outputBytes, DomainSeparator, 0, simdSupport)
    {
        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHAKE256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Shake256"/> class with default output size.
    /// </summary>
    /// <returns>A new SHAKE256 instance.</returns>
    public static new Shake256 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Shake256"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new SHAKE256 instance.</returns>
    public static Shake256 Create(int outputBytes) => new(outputBytes);

    internal static Shake256 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8) => new(simdSupport, outputBytes);

    /// <summary>
    /// Computes the SHAKE256 hash of <paramref name="source"/> using the default output size
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>64</c> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Shake256>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the SHAKE256 hash of <paramref name="source"/> using the default output size
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the SHAKE256 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<Shake256>.HashData(source);
}

