// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Ignore Naming Styles, use identifiers from specs to make the code more readable

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the Whirlpool hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of Whirlpool that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// Whirlpool is a hash function standardized in ISO/IEC 10118-3:2004.
/// It produces a 512-bit (64-byte) hash value.
/// </para>
/// </remarks>
public sealed class Whirlpool : HashAlgorithm
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
    public const int BlockSizeBytes = 64;

    private const int Rounds = 10;

    // S-box
    private static readonly byte[] Sbox =
    [
        0x18, 0x23, 0xc6, 0xe8, 0x87, 0xb8, 0x01, 0x4f, 0x36, 0xa6, 0xd2, 0xf5, 0x79, 0x6f, 0x91, 0x52,
        0x60, 0xbc, 0x9b, 0x8e, 0xa3, 0x0c, 0x7b, 0x35, 0x1d, 0xe0, 0xd7, 0xc2, 0x2e, 0x4b, 0xfe, 0x57,
        0x15, 0x77, 0x37, 0xe5, 0x9f, 0xf0, 0x4a, 0xda, 0x58, 0xc9, 0x29, 0x0a, 0xb1, 0xa0, 0x6b, 0x85,
        0xbd, 0x5d, 0x10, 0xf4, 0xcb, 0x3e, 0x05, 0x67, 0xe4, 0x27, 0x41, 0x8b, 0xa7, 0x7d, 0x95, 0xd8,
        0xfb, 0xee, 0x7c, 0x66, 0xdd, 0x17, 0x47, 0x9e, 0xca, 0x2d, 0xbf, 0x07, 0xad, 0x5a, 0x83, 0x33,
        0x63, 0x02, 0xaa, 0x71, 0xc8, 0x19, 0x49, 0xd9, 0xf2, 0xe3, 0x5b, 0x88, 0x9a, 0x26, 0x32, 0xb0,
        0xe9, 0x0f, 0xd5, 0x80, 0xbe, 0xcd, 0x34, 0x48, 0xff, 0x7a, 0x90, 0x5f, 0x20, 0x68, 0x1a, 0xae,
        0xb4, 0x54, 0x93, 0x22, 0x64, 0xf1, 0x73, 0x12, 0x40, 0x08, 0xc3, 0xec, 0xdb, 0xa1, 0x8d, 0x3d,
        0x97, 0x00, 0xcf, 0x2b, 0x76, 0x82, 0xd6, 0x1b, 0xb5, 0xaf, 0x6a, 0x50, 0x45, 0xf3, 0x30, 0xef,
        0x3f, 0x55, 0xa2, 0xea, 0x65, 0xba, 0x2f, 0xc0, 0xde, 0x1c, 0xfd, 0x4d, 0x92, 0x75, 0x06, 0x8a,
        0xb2, 0xe6, 0x0e, 0x1f, 0x62, 0xd4, 0xa8, 0x96, 0xf9, 0xc5, 0x25, 0x59, 0x84, 0x72, 0x39, 0x4c,
        0x5e, 0x78, 0x38, 0x8c, 0xd1, 0xa5, 0xe2, 0x61, 0xb3, 0x21, 0x9c, 0x1e, 0x43, 0xc7, 0xfc, 0x04,
        0x51, 0x99, 0x6d, 0x0d, 0xfa, 0xdf, 0x7e, 0x24, 0x3b, 0xab, 0xce, 0x11, 0x8f, 0x4e, 0xb7, 0xeb,
        0x3c, 0x81, 0x94, 0xf7, 0xb9, 0x13, 0x2c, 0xd3, 0xe7, 0x6e, 0xc4, 0x03, 0x56, 0x44, 0x7f, 0xa9,
        0x2a, 0xbb, 0xc1, 0x53, 0xdc, 0x0b, 0x9d, 0x6c, 0x31, 0x74, 0xf6, 0x46, 0xac, 0x89, 0x14, 0xe1,
        0x16, 0x3a, 0x69, 0x09, 0x70, 0xb6, 0xd0, 0xed, 0xcc, 0x42, 0x98, 0xa4, 0x28, 0x5c, 0xf8, 0x86
    ];

    // Round constants (precomputed from S-box)
    private static readonly ulong[] RoundConstants = InitializeRoundConstants();

    private static ulong[] InitializeRoundConstants()
    {
        unchecked
        {
            // Initialize round constants
            var roundConstants = new ulong[Rounds];
            for (int r = 0; r < Rounds; r++)
            {
                roundConstants[r] = 0;
                for (int i = 0; i < 8; i++)
                {
                    int idx = 8 * r + i;
                    roundConstants[r] |= (ulong)Sbox[idx] << (56 - 8 * i);
                }
            }
            return roundConstants;
        }
    }

    // Precomputed tables for faster computation
    private static readonly ulong[] C0, C1, C2, C3, C4, C5, C6, C7;

    static Whirlpool()
    {
        unchecked
        {
            // Initialize round constants
            RoundConstants = new ulong[Rounds];
            for (int r = 0; r < Rounds; r++)
            {
                RoundConstants[r] = 0;
                for (int i = 0; i < 8; i++)
                {
                    int idx = 8 * r + i;
                    RoundConstants[r] |= (ulong)Sbox[idx] << (56 - 8 * i);
                }
            }

            // Initialize lookup tables
            C0 = new ulong[256];
            C1 = new ulong[256];
            C2 = new ulong[256];
            C3 = new ulong[256];
            C4 = new ulong[256];
            C5 = new ulong[256];
            C6 = new ulong[256];
            C7 = new ulong[256];

            for (int x = 0; x < 256; x++)
            {
                byte s = Sbox[x];

                // E vector for MDS matrix: [1, 1, 4, 1, 8, 5, 2, 9]
                byte v1 = Mul(s, 1);
                byte v2 = Mul(s, 2);
                byte v4 = Mul(s, 4);
                byte v5 = Mul(s, 5);
                byte v8 = Mul(s, 8);
                byte v9 = Mul(s, 9);

                // Build C tables using circulant MDS matrix rows
                C0[x] = PackRow(v1, v1, v4, v1, v8, v5, v2, v9);
                C1[x] = PackRow(v9, v1, v1, v4, v1, v8, v5, v2);
                C2[x] = PackRow(v2, v9, v1, v1, v4, v1, v8, v5);
                C3[x] = PackRow(v5, v2, v9, v1, v1, v4, v1, v8);
                C4[x] = PackRow(v8, v5, v2, v9, v1, v1, v4, v1);
                C5[x] = PackRow(v1, v8, v5, v2, v9, v1, v1, v4);
                C6[x] = PackRow(v4, v1, v8, v5, v2, v9, v1, v1);
                C7[x] = PackRow(v1, v4, v1, v8, v5, v2, v9, v1);
            }
        }
    }

    private readonly ulong[] _hash;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _totalBits;

    /// <summary>
    /// Initializes a new instance of the <see cref="Whirlpool"/> class.
    /// </summary>
    public Whirlpool()
    {
        HashSizeValue = HashSizeBits;
        _hash = new ulong[8];
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Whirlpool";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Whirlpool"/> class.
    /// </summary>
    /// <returns>A new Whirlpool hash algorithm instance.</returns>
    public static new Whirlpool Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_hash, 0, _hash.Length);
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _totalBits = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        unchecked
        {
            _totalBits += (ulong)source.Length * 8;
        }
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

        // Padding
        int bufIdx = _bufferLength;
        _buffer[bufIdx] = 0x80;
        bufIdx++;

        if (bufIdx > 32)
        {
            while (bufIdx < BlockSizeBytes)
            {
                _buffer[bufIdx] = 0x00;
                bufIdx++;
            }
            ProcessBlock(_buffer);
            bufIdx = 0;
        }

        while (bufIdx < 32)
        {
            _buffer[bufIdx] = 0x00;
            bufIdx++;
        }

        // Append 256-bit length (we only use 64 bits)
        // Fill bytes 32-55 with zeros
        _buffer.AsSpan(bufIdx, 56 - bufIdx).Clear();

        // Write length in big-endian at bytes 56-63
        BinaryPrimitives.WriteUInt64BigEndian(_buffer.AsSpan(56), _totalBits);

        ProcessBlock(_buffer);

        // Output hash (big-endian)
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * 8), _hash[i]);
        }

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_hash, 0, _hash.Length);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            Span<ulong> state = stackalloc ulong[8];
            Span<ulong> k = stackalloc ulong[8];
            Span<ulong> l = stackalloc ulong[8];
            Span<ulong> blockData = stackalloc ulong[8];

            // Convert block to ulong array
            for (int i = 0; i < 8; i++)
            {
                blockData[i] = BinaryPrimitives.ReadUInt64BigEndian(block.Slice(i * 8));
            }

            // Initialize state with key (current hash) XOR block
            for (int i = 0; i < 8; i++)
            {
                k[i] = _hash[i];
                state[i] = blockData[i] ^ k[i];
            }

            // Rounds
            for (int r = 0; r < Rounds; r++)
            {
                // Key schedule
                for (int i = 0; i < 8; i++)
                {
                    l[i] = C0[(int)((k[(i + 0) & 7] >> 56) & 0xFF)] ^
                           C1[(int)((k[(i + 7) & 7] >> 48) & 0xFF)] ^
                           C2[(int)((k[(i + 6) & 7] >> 40) & 0xFF)] ^
                           C3[(int)((k[(i + 5) & 7] >> 32) & 0xFF)] ^
                           C4[(int)((k[(i + 4) & 7] >> 24) & 0xFF)] ^
                           C5[(int)((k[(i + 3) & 7] >> 16) & 0xFF)] ^
                           C6[(int)((k[(i + 2) & 7] >> 8) & 0xFF)] ^
                           C7[(int)(k[(i + 1) & 7] & 0xFF)];
                }

                l[0] ^= RoundConstants[r];
                l.CopyTo(k);

                // Transform state
                for (int i = 0; i < 8; i++)
                {
                    l[i] = C0[(int)((state[(i + 0) & 7] >> 56) & 0xFF)] ^
                           C1[(int)((state[(i + 7) & 7] >> 48) & 0xFF)] ^
                           C2[(int)((state[(i + 6) & 7] >> 40) & 0xFF)] ^
                           C3[(int)((state[(i + 5) & 7] >> 32) & 0xFF)] ^
                           C4[(int)((state[(i + 4) & 7] >> 24) & 0xFF)] ^
                           C5[(int)((state[(i + 3) & 7] >> 16) & 0xFF)] ^
                           C6[(int)((state[(i + 2) & 7] >> 8) & 0xFF)] ^
                           C7[(int)(state[(i + 1) & 7] & 0xFF)] ^
                           k[i];
                }

                l.CopyTo(state);
            }

            // Miyaguchi-Preneel compression
            for (int i = 0; i < 8; i++)
            {
                _hash[i] ^= state[i] ^ blockData[i];
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte Mul(byte a, int b)
    {
        unchecked
        {
            // Multiply in GF(2^8) with polynomial x^8 + x^4 + x^3 + x^2 + 1
            int result = 0;
            int aa = a;

            while (b != 0)
            {
                if ((b & 1) != 0)
                {
                    result ^= aa;
                }
                aa <<= 1;
                if ((aa & 0x100) != 0)
                {
                    aa ^= 0x11D; // Reduction polynomial
                }
                b >>= 1;
            }

            return (byte)result;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong PackRow(byte b0, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7)
    {
        return ((ulong)b0 << 56) | ((ulong)b1 << 48) | ((ulong)b2 << 40) | ((ulong)b3 << 32) |
               ((ulong)b4 << 24) | ((ulong)b5 << 16) | ((ulong)b6 << 8) | b7;
    }
}
