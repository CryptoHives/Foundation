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

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    public SHA256()
    {
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
    /// Creates a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    /// <returns>A new SHA-256 hash algorithm instance.</returns>
    public static new SHA256 Create() => new();

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
