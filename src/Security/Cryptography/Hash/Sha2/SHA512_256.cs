// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-512/256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-512/256 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-512/256 uses the same compression function as SHA-512 but with different
/// initial values (generated per FIPS 180-4) and a truncated 256-bit (32-byte) output.
/// </para>
/// </remarks>
public sealed class SHA512_256 : Sha2HashAlgorithm<ulong>
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
    /// Initializes a new instance of the <see cref="SHA512_256"/> class.
    /// </summary>
    public SHA512_256()
    {
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512/256";

    /// <inheritdoc/>
    public override int BlockSize => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512_256"/> class.
    /// </summary>
    /// <returns>A new SHA-512/256 hash algorithm instance.</returns>
    public static new SHA512_256 Create() => new();

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // SHA-512/256 uses different IV than SHA-512 (FIPS 180-4 Section 5.3.6)
        _state[0] = 0x22312194fc2bf72c;
        _state[1] = 0x9f555fa3c84c64c2;
        _state[2] = 0x2393b86b6f53b151;
        _state[3] = 0x963877195940eabd;
        _state[4] = 0x96283ee2a88effe3;
        _state[5] = 0xbe5e1e2553863992;
        _state[6] = 0x2b0199fc2c85b8aa;
        _state[7] = 0x0eb72ddc81c52ca2;
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
        // Output first 4 words (32 bytes) in big-endian
        for (int i = 0; i < 4; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * sizeof(UInt64)), state[i]);
        }
    }
}
