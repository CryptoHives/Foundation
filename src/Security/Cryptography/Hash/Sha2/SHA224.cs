// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-224 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-224 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-224 produces a 224-bit (28-byte) hash value and is based on SHA-256
/// with different initial values and truncated output.
/// </para>
/// </remarks>
public sealed class SHA224 : Sha2HashAlgorithm<uint>
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 224;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    public SHA224() : this(SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA224"/> class with forced SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal SHA224(SimdSupport simdSupport)
    {
        _simdSupport = simdSupport & SHA256.SimdSupport;
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-224";

    /// <inheritdoc/>
    public override int BlockSize => SHA256Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA256Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Gets the SIMD instruction sets supported by SHA-224 on the current platform.
    /// </summary>
    /// <remarks>
    /// SHA-224 uses the same compression function as SHA-256.
    /// </remarks>
    internal new static SimdSupport SimdSupport => SHA256.SimdSupport;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    /// <returns>A new SHA-224 hash algorithm instance.</returns>
    public static new SHA224 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA224"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA-224 hash algorithm instance.</returns>
    internal static SHA224 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <summary>
    /// Computes the SHA-224 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<SHA224>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the SHA-224 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the SHA-224 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<SHA224>.HashData(source);

    /// <summary>
    /// Computes the SHA-224 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<SHA224>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the SHA-224 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the SHA-224 hash.</returns>
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<SHA224>.HashData(source);

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // SHA-224 uses different IV than SHA-256 (FIPS 180-4 Section 5.3.2)
        _state[0] = 0xc1059ed8;
        _state[1] = 0x367cd507;
        _state[2] = 0x3070dd17;
        _state[3] = 0xf70e5939;
        _state[4] = 0xffc00b31;
        _state[5] = 0x68581511;
        _state[6] = 0x64f98fa7;
        _state[7] = 0xbefa4fa4;
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
        // Output first 7 words (28 bytes) in big-endian
        for (int i = 0; i < HashSizeBytes / sizeof(UInt32); i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(i * sizeof(UInt32)), state[i]);
        }
    }
}
