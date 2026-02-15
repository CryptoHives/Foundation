// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-384 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-384 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-384 uses the same compression function as SHA-512 but with different
/// initial values and a truncated 384-bit (48-byte) output.
/// </para>
/// </remarks>
public sealed class SHA384 : Sha2HashAlgorithm<ulong>
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 384;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA384"/> class.
    /// </summary>
    public SHA384()
    {
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-384";

    /// <inheritdoc/>
    public override int BlockSize => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA384"/> class.
    /// </summary>
    /// <returns>A new SHA-384 hash algorithm instance.</returns>
    public static new SHA384 Create() => new();

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // Initialize state with SHA-384 constants (FIPS 180-4 Section 5.3.4)
        _state[0] = 0xcbbb9d5dc1059ed8;
        _state[1] = 0x629a292a367cd507;
        _state[2] = 0x9159015a3070dd17;
        _state[3] = 0x152fecd8f70e5939;
        _state[4] = 0x67332667ffc00b31;
        _state[5] = 0x8eb44a8768581511;
        _state[6] = 0xdb0c2e0d64f98fa7;
        _state[7] = 0x47b5481dbefa4fa4;
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
        // Convert first 6 words of state to bytes (big-endian), truncated to 48 bytes
        for (int i = 0; i < 6; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * sizeof(UInt64)), state[i]);
        }
    }
}
