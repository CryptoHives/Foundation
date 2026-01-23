// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;

/// <summary>
/// Computes the SHA-1 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-1 based on FIPS 180-4.
/// It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// <strong>Security Warning:</strong> SHA-1 is cryptographically weak and should NOT
/// be used for security purposes such as digital signatures or certificate verification.
/// It is provided only for legacy compatibility.
/// </para>
/// </remarks>
[Obsolete("SHA-1 is cryptographically weak and should not be used for security purposes.")]
public sealed class SHA1 : HashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 160;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    private readonly byte[] _buffer;
    private readonly uint[] _state;
    private readonly uint[] _w;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA1"/> class.
    /// </summary>
    public SHA1()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new uint[5];
        _w = new uint[80];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-1";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA1"/> class.
    /// </summary>
    /// <returns>A new SHA-1 hash algorithm instance.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static new SHA1 Create() => new();
#pragma warning restore CS0618

    /// <inheritdoc/>
    public override void Initialize()
    {
        // SHA-1 initialization constants
        _state[0] = 0x67452301;
        _state[1] = 0xefcdab89;
        _state[2] = 0x98badcfe;
        _state[3] = 0x10325476;
        _state[4] = 0xc3d2e1f0;

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
                ProcessBlock(_buffer);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
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

        PadAndFinalize();

        // Output 5 words (20 bytes) in big-endian
        for (int i = 0; i < 5; i++)
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
            Array.Clear(_w, 0, _w.Length);
        }
        base.Dispose(disposing);
    }

    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            // Parse block into 16 32-bit words (big-endian)
            for (int i = 0; i < 16; i++)
            {
                _w[i] = BinaryPrimitives.ReadUInt32BigEndian(block.Slice(i * 4));
            }

            // Extend 16 words to 80 words
            for (int i = 16; i < 80; i++)
            {
                _w[i] = BitOperations.RotateLeft(_w[i - 3] ^ _w[i - 8] ^ _w[i - 14] ^ _w[i - 16], 1);
            }

            uint a = _state[0];
            uint b = _state[1];
            uint c = _state[2];
            uint d = _state[3];
            uint e = _state[4];

            // Round 1: 0-19
            for (int i = 0; i < 20; i++)
            {
                uint f = (b & c) | (~b & d);
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x5a827999 + _w[i];
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 2: 20-39
            for (int i = 20; i < 40; i++)
            {
                uint f = b ^ c ^ d;
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x6ed9eba1 + _w[i];
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 3: 40-59
            for (int i = 40; i < 60; i++)
            {
                uint f = (b & c) | (b & d) | (c & d);
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x8f1bbcdc + _w[i];
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 4: 60-79
            for (int i = 60; i < 80; i++)
            {
                uint f = b ^ c ^ d;
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0xca62c1d6 + _w[i];
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            _state[0] += a;
            _state[1] += b;
            _state[2] += c;
            _state[3] += d;
            _state[4] += e;
        }
    }

    private void PadAndFinalize()
    {
        unchecked
        {
            long totalBits = (_bytesProcessed + _bufferLength) * 8;

            _buffer[_bufferLength++] = 0x80;

            if (_bufferLength > 56)
            {
                while (_bufferLength < BlockSizeBytes)
                {
                    _buffer[_bufferLength++] = 0x00;
                }
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            while (_bufferLength < 56)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(56), totalBits);

            ProcessBlock(_buffer);
        }
    }
}
