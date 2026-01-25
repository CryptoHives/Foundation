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
public sealed class SHA512_224 : HashAlgorithm
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
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = SHA512Core.BlockSizeBytes;

    private readonly byte[] _buffer;
    private readonly ulong[] _state;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    public SHA512_224()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new ulong[8];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512/224";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    /// <returns>A new SHA-512/224 hash algorithm instance.</returns>
    public static new SHA512_224 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        // SHA-512/224 initial values (FIPS 180-4 Section 5.3.6.1)
        _state[0] = 0x8c3d37c819544da2;
        _state[1] = 0x73e1996689dcd4d6;
        _state[2] = 0x1dfab7ae32ff9c82;
        _state[3] = 0x679dd514582f9fcf;
        _state[4] = 0x0f6d2b697bd44da8;
        _state[5] = 0x77e36f7304c48942;
        _state[6] = 0x3f9d85a86a1d36c8;
        _state[7] = 0x1112e6ad91d692a1;

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

        // Output first 3 full words (24 bytes) + 4 bytes from 4th word = 28 bytes
        for (int i = 0; i < 3; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * 8), _state[i]);
        }
        // Last 4 bytes from word 3 (high 32 bits)
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(24), (uint)(_state[3] >> 32));

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
