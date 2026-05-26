// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-256 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-256 produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// using CryptoHives.Foundation.Security.Cryptography.Hash;
///
/// byte[] data = Encoding.UTF8.GetBytes("Hello, World!");
/// using var sha256 = SHA256.Create();
/// byte[] hash = sha256.ComputeHash(data);
/// </code>
/// </example>
public sealed class SHA256 : Sha2HashAlgorithm<uint>
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 256;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    public SHA256() : this(SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA256"/> class with forced SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal SHA256(SimdSupport simdSupport)
    {
        _simdSupport = simdSupport & SimdSupport;
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-256";

    /// <inheritdoc/>
    public override int BlockSize => SHA256Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA256Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Gets the SIMD instruction sets supported by SHA-256 on the current platform.
    /// </summary>
    internal new static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (SHA256Core.IsArmSha256Supported) support |= SimdSupport.ArmSha256;
#endif
            return support;
        }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    /// <returns>A new SHA-256 hash algorithm instance.</returns>
    public static new SHA256 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA256"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA-256 hash algorithm instance.</returns>
    internal static SHA256 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <summary>
    /// Computes the SHA-256 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<SHA256>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the SHA-256 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the SHA-256 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<SHA256>.HashData(source);

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // Initialize state with SHA-256 constants
        _state[0] = 0x6a09e667;
        _state[1] = 0xbb67ae85;
        _state[2] = 0x3c6ef372;
        _state[3] = 0xa54ff53a;
        _state[4] = 0x510e527f;
        _state[5] = 0x9b05688c;
        _state[6] = 0x1f83d9ab;
        _state[7] = 0x5be0cd19;
    }

    /// <inheritdoc/>
    protected override void ProcessBlock(ReadOnlySpan<byte> block, Span<uint> state)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.ArmSha256) != 0)
        {
            SHA256Core.ProcessBlockArm(block, state);
            return;
        }
#endif
        SHA256Core.ProcessBlock(block, state);
    }

    /// <inheritdoc/>
    protected override void PadAndFinalize(Span<byte> buffer, int bufferLength, long bytesProcessed, Span<uint> state)
    {
        SHA256Core.PadAndFinalize(buffer, bufferLength, bytesProcessed, state);
    }

    /// <inheritdoc/>
    protected override void OutputHash(Span<byte> destination, uint[] state)
    {
        // Convert state to bytes (big-endian)
        for (int i = 0; i < HashSizeBytes / sizeof(UInt32); i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(i * sizeof(UInt32)), state[i]);
        }
    }
}
