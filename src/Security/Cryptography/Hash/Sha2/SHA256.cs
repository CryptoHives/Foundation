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
public sealed class SHA256 : HashAlgorithm
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
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = SHA256Core.BlockSizeBytes;

    private readonly byte[] _buffer;
    private readonly uint[] _state;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    public SHA256()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new uint[8];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-256";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA256"/> class.
    /// </summary>
    /// <returns>A new SHA-256 hash algorithm instance.</returns>
    public static new SHA256 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
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

        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have leftover data in the buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                SHA256Core.ProcessBlock(_buffer, _state);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            SHA256Core.ProcessBlock(source.Slice(offset, BlockSizeBytes), _state);
            _bytesProcessed += BlockSizeBytes;
            offset += BlockSizeBytes;
        }

        // Store remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < HashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        SHA256Core.PadAndFinalize(_buffer, _bufferLength, _bytesProcessed, _state);

        // Convert state to bytes (big-endian)
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(i * 4), _state[i]);
        }

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            Array.Clear(_state, 0, _state.Length);
        }
        base.Dispose(disposing);
    }
}
