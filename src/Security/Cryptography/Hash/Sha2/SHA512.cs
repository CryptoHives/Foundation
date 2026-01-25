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
public sealed class SHA512 : HashAlgorithm
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
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = SHA512Core.BlockSizeBytes;

    private readonly byte[] _buffer;
    private readonly ulong[] _state;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    public SHA512()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new ulong[8];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    /// <returns>A new SHA-512 hash algorithm instance.</returns>
    public static new SHA512 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
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

        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                SHA512Core.ProcessBlock(_buffer, _state);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            SHA512Core.ProcessBlock(source.Slice(offset, BlockSizeBytes), _state);
            _bytesProcessed += BlockSizeBytes;
            offset += BlockSizeBytes;
        }

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

        SHA512Core.PadAndFinalize(_buffer, _bufferLength, _bytesProcessed, _state);

        // Convert state to bytes (big-endian)
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * 8), _state[i]);
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
