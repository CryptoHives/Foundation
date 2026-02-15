// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the SHA-512 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-512 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-512 produces a 512-bit (64-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA512 : Sha2HashAlgorithm<ulong>
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 512;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    public SHA512()
    {
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512";

    /// <inheritdoc/>
    public override int BlockSize => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int BlockSizeBytes => SHA512Core.BlockSizeBytes;

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    /// <returns>A new SHA-512 hash algorithm instance.</returns>
    public static new SHA512 Create() => new();

    /// <inheritdoc/>
    protected override void InitializeState()
    {
        // Initialize state with SHA-512 constants (FIPS 180-4 Section 5.3.5)
        _state[0] = 0x6a09e667f3bcc908;
        _state[1] = 0xbb67ae8584caa73b;
        _state[2] = 0x3c6ef372fe94f82b;
        _state[3] = 0xa54ff53a5f1d36f1;
        _state[4] = 0x510e527fade682d1;
        _state[5] = 0x9b05688c2b3e6c1f;
        _state[6] = 0x1f83d9abfb41bd6b;
        _state[7] = 0x5be0cd19137e2179;
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
        // Convert state to bytes (big-endian)
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * sizeof(UInt64)), state[i]);
        }
    }
}
