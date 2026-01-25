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
public sealed class SHA224 : HashAlgorithm
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
    public const int BlockSizeBytes = SHA256Core.BlockSizeBytes;

    private readonly byte[] _buffer;
    private readonly uint[] _state;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    public SHA224()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new uint[8];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-224";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA224"/> class.
    /// </summary>
    /// <returns>A new SHA-224 hash algorithm instance.</returns>
    public static new SHA224 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
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
                SHA256Core.ProcessBlock(_buffer, _state);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            SHA256Core.ProcessBlock(source.Slice(offset, BlockSizeBytes), _state);
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

        SHA256Core.PadAndFinalize(_buffer, _bufferLength, _bytesProcessed, _state);

        // Output first 7 words (28 bytes) in big-endian
        for (int i = 0; i < 7; i++)
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
