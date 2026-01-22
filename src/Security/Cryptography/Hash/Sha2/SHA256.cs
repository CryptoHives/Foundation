// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - K and IV are standard cryptographic constant names per FIPS 180-4

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

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
/// On .NET 8+, this implementation uses optimized BitOperations for improved
/// performance. Otherwise, a portable software implementation is used.
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
    public const int BlockSizeBytes = 64;

    // SHA-256 round constants (first 32 bits of the fractional parts of the cube roots of the first 64 primes)
    private static readonly uint[] K =
    [
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
    ];

    private readonly byte[] _buffer;
    private readonly uint[] _state;
    private readonly uint[] _w;
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
        _w = new uint[64];
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
                ProcessBlock(_buffer);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
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

        PadAndFinalize();

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
            Array.Clear(_w, 0, _w.Length);
        }
        base.Dispose(disposing);
    }

    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            // Prepare message schedule
            for (int i = 0; i < 16; i++)
            {
                _w[i] = BinaryPrimitives.ReadUInt32BigEndian(block.Slice(i * 4));
            }

            for (int i = 16; i < 64; i++)
            {
                uint s0 = BitOperations.RotateRight(_w[i - 15], 7) ^ BitOperations.RotateRight(_w[i - 15], 18) ^ (_w[i - 15] >> 3);
                uint s1 = BitOperations.RotateRight(_w[i - 2], 17) ^ BitOperations.RotateRight(_w[i - 2], 19) ^ (_w[i - 2] >> 10);
                _w[i] = _w[i - 16] + s0 + _w[i - 7] + s1;
            }

            // Initialize working variables
            uint a = _state[0];
            uint b = _state[1];
            uint c = _state[2];
            uint d = _state[3];
            uint e = _state[4];
            uint f = _state[5];
            uint g = _state[6];
            uint h = _state[7];

            // Main loop
            for (int i = 0; i < 64; i++)
            {
                uint S1 = BitOperations.RotateRight(e, 6) ^ BitOperations.RotateRight(e, 11) ^ BitOperations.RotateRight(e, 25);
                uint ch = (e & f) ^ (~e & g);
                uint temp1 = h + S1 + ch + K[i] + _w[i];
                uint S0 = BitOperations.RotateRight(a, 2) ^ BitOperations.RotateRight(a, 13) ^ BitOperations.RotateRight(a, 22);
                uint maj = (a & b) ^ (a & c) ^ (b & c);
                uint temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
            }

            // Add compressed chunk to current hash value
            _state[0] += a;
            _state[1] += b;
            _state[2] += c;
            _state[3] += d;
            _state[4] += e;
            _state[5] += f;
            _state[6] += g;
            _state[7] += h;
        }
    }

    private void PadAndFinalize()
    {
        unchecked
        {
            long totalBits = (_bytesProcessed + _bufferLength) * 8;

            // Add padding bit
            _buffer[_bufferLength++] = 0x80;

            // Pad to 56 bytes (448 bits) mod 64
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

            // Append length in bits (big-endian)
            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(56), totalBits);

            ProcessBlock(_buffer);
        }
    }
}
