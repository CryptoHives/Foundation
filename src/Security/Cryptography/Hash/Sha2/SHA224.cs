// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    public SHA224()
    {
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
    /// Creates a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    /// <returns>A new SHA-224 hash algorithm instance.</returns>
    public static new SHA224 Create() => new();

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
