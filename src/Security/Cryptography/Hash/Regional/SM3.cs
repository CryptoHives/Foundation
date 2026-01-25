// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the SM3 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SM3 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SM3 is the Chinese national cryptographic hash standard (GB/T 32905-2016).
/// It produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
public sealed class SM3 : HashAlgorithm
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

    // Initial hash values
    private const uint IV0 = 0x7380166F;
    private const uint IV1 = 0x4914B2B9;
    private const uint IV2 = 0x172442D7;
    private const uint IV3 = 0xDA8A0600;
    private const uint IV4 = 0xA96F30BC;
    private const uint IV5 = 0x163138AA;
    private const uint IV6 = 0xE38DEE4D;
    private const uint IV7 = 0xB0FB0E4E;

    // Constants T_j
    private const uint T0_15 = 0x79CC4519;
    private const uint T16_63 = 0x7A879D8A;

    private uint _v0, _v1, _v2, _v3, _v4, _v5, _v6, _v7;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _totalLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SM3"/> class.
    /// </summary>
    public SM3()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SM3";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SM3"/> class.
    /// </summary>
    /// <returns>A new SM3 hash algorithm instance.</returns>
    public static new SM3 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        _v0 = IV0;
        _v1 = IV1;
        _v2 = IV2;
        _v3 = IV3;
        _v4 = IV4;
        _v5 = IV5;
        _v6 = IV6;
        _v7 = IV7;
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _totalLength = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        _totalLength += (ulong)source.Length;
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
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
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

        ulong bitLength = _totalLength * 8;
        int padLength = (_bufferLength < 56) ? (56 - _bufferLength) : (120 - _bufferLength);

        Span<byte> padding = stackalloc byte[padLength + 8];
        padding[0] = 0x80;
        padding.Slice(1, padLength - 1).Clear();

        // Append length in bits as big-endian 64-bit
        BinaryPrimitives.WriteUInt64BigEndian(padding.Slice(padLength), bitLength);

        HashCore(padding);

        // Output hash (big-endian)
        BinaryPrimitives.WriteUInt32BigEndian(destination, _v0);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(4), _v1);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(8), _v2);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(12), _v3);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(16), _v4);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(20), _v5);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(24), _v6);
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(28), _v7);

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            _v0 = _v1 = _v2 = _v3 = _v4 = _v5 = _v6 = _v7 = 0;
        }
        base.Dispose(disposing);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        Span<uint> w = stackalloc uint[68];
        Span<uint> wp = stackalloc uint[64];

        unchecked
        {
            // Message expansion
            for (int i = 0; i < 16; i++)
            {
                w[i] = BinaryPrimitives.ReadUInt32BigEndian(block.Slice(i * 4));
            }

            for (int i = 16; i < 68; i++)
            {
                uint tmp = w[i - 16] ^ w[i - 9] ^ BitOperations.RotateLeft(w[i - 3], 15);
                w[i] = P1(tmp) ^ BitOperations.RotateLeft(w[i - 13], 7) ^ w[i - 6];
            }

            for (int i = 0; i < 64; i++)
            {
                wp[i] = w[i] ^ w[i + 4];
            }

            // Compression
            uint a = _v0, b = _v1, c = _v2, d = _v3;
            uint e = _v4, f = _v5, g = _v6, h = _v7;

            for (int j = 0; j < 64; j++)
            {
                uint tj = (j < 16) ? T0_15 : T16_63;
                uint ss1 = BitOperations.RotateLeft(BitOperations.RotateLeft(a, 12) + e + BitOperations.RotateLeft(tj, j), 7);
                uint ss2 = ss1 ^ BitOperations.RotateLeft(a, 12);
                uint tt1, tt2;

                if (j < 16)
                {
                    tt1 = FF0(a, b, c) + d + ss2 + wp[j];
                    tt2 = GG0(e, f, g) + h + ss1 + w[j];
                }
                else
                {
                    tt1 = FF1(a, b, c) + d + ss2 + wp[j];
                    tt2 = GG1(e, f, g) + h + ss1 + w[j];
                }

                d = c;
                c = BitOperations.RotateLeft(b, 9);
                b = a;
                a = tt1;
                h = g;
                g = BitOperations.RotateLeft(f, 19);
                f = e;
                e = P0(tt2);
            }

            _v0 ^= a;
            _v1 ^= b;
            _v2 ^= c;
            _v3 ^= d;
            _v4 ^= e;
            _v5 ^= f;
            _v6 ^= g;
            _v7 ^= h;
        }
    }

    // Boolean functions
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint FF0(uint x, uint y, uint z) => x ^ y ^ z;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint FF1(uint x, uint y, uint z) => (x & y) | (x & z) | (y & z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint GG0(uint x, uint y, uint z) => x ^ y ^ z;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint GG1(uint x, uint y, uint z) => (x & y) | (~x & z);

    // Permutation functions
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint P0(uint x) => x ^ BitOperations.RotateLeft(x, 9) ^ BitOperations.RotateLeft(x, 17);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint P1(uint x) => x ^ BitOperations.RotateLeft(x, 15) ^ BitOperations.RotateLeft(x, 23);
}
