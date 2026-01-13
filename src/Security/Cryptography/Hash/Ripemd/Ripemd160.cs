// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the RIPEMD-160 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// RIPEMD-160 is a 160-bit cryptographic hash function designed by Hans Dobbertin,
/// Antoon Bosselaers, and Bart Preneel. It is widely used in cryptocurrency systems,
/// particularly Bitcoin for address generation (in combination with SHA-256).
/// </para>
/// <para>
/// This is a fully managed implementation that does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// <strong>Note:</strong> While RIPEMD-160 is still considered secure for its design goals,
/// SHA-256 or SHA-3 are recommended for new applications requiring 128+ bit security.
/// </para>
/// </remarks>
public sealed class Ripemd160 : HashAlgorithm
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

    // Initial hash values
    private const uint H0 = 0x67452301;
    private const uint H1 = 0xEFCDAB89;
    private const uint H2 = 0x98BADCFE;
    private const uint H3 = 0x10325476;
    private const uint H4 = 0xC3D2E1F0;

    // Left line constants
    private static readonly uint[] KL = [0x00000000, 0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xA953FD4E];

    // Right line constants
    private static readonly uint[] KR = [0x50A28BE6, 0x5C4DD124, 0x6D703EF3, 0x7A6D76E9, 0x00000000];

    // Left line message schedule
    private static readonly int[] RL =
    [
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        7, 4, 13, 1, 10, 6, 15, 3, 12, 0, 9, 5, 2, 14, 11, 8,
        3, 10, 14, 4, 9, 15, 8, 1, 2, 7, 0, 6, 13, 11, 5, 12,
        1, 9, 11, 10, 0, 8, 12, 4, 13, 3, 7, 15, 14, 5, 6, 2,
        4, 0, 5, 9, 7, 12, 2, 10, 14, 1, 3, 8, 11, 6, 15, 13
    ];

    // Right line message schedule
    private static readonly int[] RR =
    [
        5, 14, 7, 0, 9, 2, 11, 4, 13, 6, 15, 8, 1, 10, 3, 12,
        6, 11, 3, 7, 0, 13, 5, 10, 14, 15, 8, 12, 4, 9, 1, 2,
        15, 5, 1, 3, 7, 14, 6, 9, 11, 8, 12, 2, 10, 0, 4, 13,
        8, 6, 4, 1, 3, 11, 15, 0, 5, 12, 2, 13, 9, 7, 10, 14,
        12, 15, 10, 4, 1, 5, 8, 7, 6, 2, 13, 14, 0, 3, 9, 11
    ];

    // Left line rotations
    private static readonly int[] SL =
    [
        11, 14, 15, 12, 5, 8, 7, 9, 11, 13, 14, 15, 6, 7, 9, 8,
        7, 6, 8, 13, 11, 9, 7, 15, 7, 12, 15, 9, 11, 7, 13, 12,
        11, 13, 6, 7, 14, 9, 13, 15, 14, 8, 13, 6, 5, 12, 7, 5,
        11, 12, 14, 15, 14, 15, 9, 8, 9, 14, 5, 6, 8, 6, 5, 12,
        9, 15, 5, 11, 6, 8, 13, 12, 5, 12, 13, 14, 11, 8, 5, 6
    ];

    // Right line rotations
    private static readonly int[] SR =
    [
        8, 9, 9, 11, 13, 15, 15, 5, 7, 7, 8, 11, 14, 14, 12, 6,
        9, 13, 15, 7, 12, 8, 9, 11, 7, 7, 12, 7, 6, 15, 13, 11,
        9, 7, 15, 11, 8, 6, 6, 14, 12, 13, 5, 14, 13, 13, 7, 5,
        15, 5, 8, 11, 14, 14, 6, 14, 6, 9, 12, 9, 12, 5, 15, 8,
        8, 5, 12, 9, 12, 5, 14, 6, 8, 13, 6, 5, 15, 13, 11, 11
    ];

    private uint _h0, _h1, _h2, _h3, _h4;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _totalLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Ripemd160"/> class.
    /// </summary>
    public Ripemd160()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "RIPEMD-160";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Ripemd160"/> class.
    /// </summary>
    /// <returns>A new RIPEMD-160 hash algorithm instance.</returns>
    public static new Ripemd160 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        _h0 = H0;
        _h1 = H1;
        _h2 = H2;
        _h3 = H3;
        _h4 = H4;
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

        // Append length in bits as little-endian 64-bit
        BinaryPrimitives.WriteUInt64LittleEndian(padding.Slice(padLength), bitLength);

        HashCore(padding);

        // Output hash (little-endian)
        BinaryPrimitives.WriteUInt32LittleEndian(destination, _h0);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(4), _h1);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(8), _h2);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(12), _h3);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(16), _h4);

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            _h0 = _h1 = _h2 = _h3 = _h4 = 0;
        }
        base.Dispose(disposing);
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
#endif
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        Span<uint> x = stackalloc uint[16];

        unchecked
        {
            for (int i = 0; i < 16; i++)
            {
                x[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
            }

            uint al = _h0, bl = _h1, cl = _h2, dl = _h3, el = _h4;
            uint ar = _h0, br = _h1, cr = _h2, dr = _h3, er = _h4;

            // 80 rounds
            for (int j = 0; j < 80; j++)
            {
                int round = j / 16;
                uint fl, fr, tl, tr;

                // Left line
                fl = F(round, bl, cl, dl);
                tl = al + fl + x[RL[j]] + KL[round];
                tl = RotateLeft(tl, SL[j]) + el;
                al = el;
                el = dl;
                dl = RotateLeft(cl, 10);
                cl = bl;
                bl = tl;

                // Right line
                fr = F(4 - round, br, cr, dr);
                tr = ar + fr + x[RR[j]] + KR[round];
                tr = RotateLeft(tr, SR[j]) + er;
                ar = er;
                er = dr;
                dr = RotateLeft(cr, 10);
                cr = br;
                br = tr;
            }

            uint t = _h1 + cl + dr;
            _h1 = _h2 + dl + er;
            _h2 = _h3 + el + ar;
            _h3 = _h4 + al + br;
            _h4 = _h0 + bl + cr;
            _h0 = t;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint F(int round, uint x, uint y, uint z)
    {
        return round switch {
            0 => x ^ y ^ z,
            1 => (x & y) | (~x & z),
            2 => (x | ~y) ^ z,
            3 => (x & z) | (y & ~z),
            4 => x ^ (y | ~z),
            _ => 0
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateLeft(uint x, int n) => BitOperations.RotateLeft(x, n);
}
