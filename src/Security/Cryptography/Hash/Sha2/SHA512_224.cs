// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-512/224 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-512/224 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-512/224 uses the same compression function as SHA-512 but with different
/// initial values (generated per FIPS 180-4) and a truncated 224-bit (28-byte) output.
/// </para>
/// </remarks>
public sealed class SHA512_224 : Sha2HashAlgorithm<ulong>
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 224;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    public SHA512_224()
    {
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512/224";

    /// <inheritdoc/>
    public override int BlockSize => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    /// <returns>A new SHA-512/224 hash algorithm instance.</returns>
    public static new SHA512_224 Create() => new();

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // SHA-512/224 uses different IV than SHA-512 (FIPS 180-4 Section 5.3.6)
        _state[0] = 0x8c3d37c819544da2;
        _state[1] = 0x73e1996689dcd4d6;
        _state[2] = 0x1dfab7ae32ff9c82;
        _state[3] = 0x679dd514582f9fcf;
        _state[4] = 0x0f6d2b697bd44da8;
        _state[5] = 0x77e36f7304c48942;
        _state[6] = 0x3f9d85a86a1d36c8;
        _state[7] = 0x1112e6ad91d692a1;
    }

    /// <inheritdoc/>
    protected override void ProcessBlock(ReadOnlySpan<byte> block, Span<ulong> state)
    {
        SHA512Core.ProcessBlock(block, state);
    }

    /// <inheritdoc/>
    protected override void PadAndFinalize(Span<byte> buffer, int bufferLength, long bytesProcessed, Span<ulong> state)
    {
        SHA512Core.PadAndFinalize(buffer, bufferLength, bytesProcessed, state);
    }

    /// <inheritdoc/>
    protected override void OutputHash(Span<byte> destination, ulong[] state)
    {
        // Output first 3.5 words (28 bytes) in big-endian
        for (int i = 0; i < 3; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * sizeof(UInt64)), state[i]);
        }
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(3 * sizeof(UInt64)), (uint)(state[3] >> 32));
    }
}
