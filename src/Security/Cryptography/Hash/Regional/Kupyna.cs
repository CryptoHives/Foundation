// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the Kupyna (DSTU 7564:2014) hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of Kupyna that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// Kupyna is the Ukrainian national cryptographic hash standard defined in DSTU 7564:2014.
/// It supports output sizes of 256, 384, or 512 bits.
/// </para>
/// <para>
/// The algorithm uses a Davies-Meyer compression function with two fixed permutations
/// T⊕ (P) and T+ (Q), derived from the Kalyna block cipher (DSTU 7624:2014).
/// Each round applies AddRoundConstant, SubBytes, ShiftBytes, and MixColumns.
/// </para>
/// <para>
/// Implementation follows the specification in the IACR ePrint 2015/885 paper and the
/// official reference by Kiianchuk, Mordvinov, and Oliynykov.
/// </para>
/// </remarks>
public sealed class Kupyna : HashAlgorithm
{
    /// <summary>
    /// Number of 64-bit columns in the state for hash sizes up to 256 bits.
    /// </summary>
    private const int Nb512 = 8;

    /// <summary>
    /// Number of 64-bit columns in the state for hash sizes up to 512 bits.
    /// </summary>
    private const int Nb1024 = 16;

    /// <summary>
    /// Number of rounds for the 512-bit state.
    /// </summary>
    private const int Nr512 = 10;

    /// <summary>
    /// Number of rounds for the 1024-bit state.
    /// </summary>
    private const int Nr1024 = 14;

    // S-boxes from DSTU 7564:2014 (official reference tables by Kiianchuk, Mordvinov, Oliynykov).
    // Row i of the state uses sbox[i % 4]: rows 0,4 → S0; rows 1,5 → S1; rows 2,6 → S2; rows 3,7 → S3.
    private static ReadOnlySpan<byte> S0 =>
    [
        0xa8, 0x43, 0x5f, 0x06, 0x6b, 0x75, 0x6c, 0x59, 0x71, 0xdf, 0x87, 0x95, 0x17, 0xf0, 0xd8, 0x09,
        0x6d, 0xf3, 0x1d, 0xcb, 0xc9, 0x4d, 0x2c, 0xaf, 0x79, 0xe0, 0x97, 0xfd, 0x6f, 0x4b, 0x45, 0x39,
        0x3e, 0xdd, 0xa3, 0x4f, 0xb4, 0xb6, 0x9a, 0x0e, 0x1f, 0xbf, 0x15, 0xe1, 0x49, 0xd2, 0x93, 0xc6,
        0x92, 0x72, 0x9e, 0x61, 0xd1, 0x63, 0xfa, 0xee, 0xf4, 0x19, 0xd5, 0xad, 0x58, 0xa4, 0xbb, 0xa1,
        0xdc, 0xf2, 0x83, 0x37, 0x42, 0xe4, 0x7a, 0x32, 0x9c, 0xcc, 0xab, 0x4a, 0x8f, 0x6e, 0x04, 0x27,
        0x2e, 0xe7, 0xe2, 0x5a, 0x96, 0x16, 0x23, 0x2b, 0xc2, 0x65, 0x66, 0x0f, 0xbc, 0xa9, 0x47, 0x41,
        0x34, 0x48, 0xfc, 0xb7, 0x6a, 0x88, 0xa5, 0x53, 0x86, 0xf9, 0x5b, 0xdb, 0x38, 0x7b, 0xc3, 0x1e,
        0x22, 0x33, 0x24, 0x28, 0x36, 0xc7, 0xb2, 0x3b, 0x8e, 0x77, 0xba, 0xf5, 0x14, 0x9f, 0x08, 0x55,
        0x9b, 0x4c, 0xfe, 0x60, 0x5c, 0xda, 0x18, 0x46, 0xcd, 0x7d, 0x21, 0xb0, 0x3f, 0x1b, 0x89, 0xff,
        0xeb, 0x84, 0x69, 0x3a, 0x9d, 0xd7, 0xd3, 0x70, 0x67, 0x40, 0xb5, 0xde, 0x5d, 0x30, 0x91, 0xb1,
        0x78, 0x11, 0x01, 0xe5, 0x00, 0x68, 0x98, 0xa0, 0xc5, 0x02, 0xa6, 0x74, 0x2d, 0x0b, 0xa2, 0x76,
        0xb3, 0xbe, 0xce, 0xbd, 0xae, 0xe9, 0x8a, 0x31, 0x1c, 0xec, 0xf1, 0x99, 0x94, 0xaa, 0xf6, 0x26,
        0x2f, 0xef, 0xe8, 0x8c, 0x35, 0x03, 0xd4, 0x7f, 0xfb, 0x05, 0xc1, 0x5e, 0x90, 0x20, 0x3d, 0x82,
        0xf7, 0xea, 0x0a, 0x0d, 0x7e, 0xf8, 0x50, 0x1a, 0xc4, 0x07, 0x57, 0xb8, 0x3c, 0x62, 0xe3, 0xc8,
        0xac, 0x52, 0x64, 0x10, 0xd0, 0xd9, 0x13, 0x0c, 0x12, 0x29, 0x51, 0xb9, 0xcf, 0xd6, 0x73, 0x8d,
        0x81, 0x54, 0xc0, 0xed, 0x4e, 0x44, 0xa7, 0x2a, 0x85, 0x25, 0xe6, 0xca, 0x7c, 0x8b, 0x56, 0x80
    ];

    private static ReadOnlySpan<byte> S1 =>
    [
        0xce, 0xbb, 0xeb, 0x92, 0xea, 0xcb, 0x13, 0xc1, 0xe9, 0x3a, 0xd6, 0xb2, 0xd2, 0x90, 0x17, 0xf8,
        0x42, 0x15, 0x56, 0xb4, 0x65, 0x1c, 0x88, 0x43, 0xc5, 0x5c, 0x36, 0xba, 0xf5, 0x57, 0x67, 0x8d,
        0x31, 0xf6, 0x64, 0x58, 0x9e, 0xf4, 0x22, 0xaa, 0x75, 0x0f, 0x02, 0xb1, 0xdf, 0x6d, 0x73, 0x4d,
        0x7c, 0x26, 0x2e, 0xf7, 0x08, 0x5d, 0x44, 0x3e, 0x9f, 0x14, 0xc8, 0xae, 0x54, 0x10, 0xd8, 0xbc,
        0x1a, 0x6b, 0x69, 0xf3, 0xbd, 0x33, 0xab, 0xfa, 0xd1, 0x9b, 0x68, 0x4e, 0x16, 0x95, 0x91, 0xee,
        0x4c, 0x63, 0x8e, 0x5b, 0xcc, 0x3c, 0x19, 0xa1, 0x81, 0x49, 0x7b, 0xd9, 0x6f, 0x37, 0x60, 0xca,
        0xe7, 0x2b, 0x48, 0xfd, 0x96, 0x45, 0xfc, 0x41, 0x12, 0x0d, 0x79, 0xe5, 0x89, 0x8c, 0xe3, 0x20,
        0x30, 0xdc, 0xb7, 0x6c, 0x4a, 0xb5, 0x3f, 0x97, 0xd4, 0x62, 0x2d, 0x06, 0xa4, 0xa5, 0x83, 0x5f,
        0x2a, 0xda, 0xc9, 0x00, 0x7e, 0xa2, 0x55, 0xbf, 0x11, 0xd5, 0x9c, 0xcf, 0x0e, 0x0a, 0x3d, 0x51,
        0x7d, 0x93, 0x1b, 0xfe, 0xc4, 0x47, 0x09, 0x86, 0x0b, 0x8f, 0x9d, 0x6a, 0x07, 0xb9, 0xb0, 0x98,
        0x18, 0x32, 0x71, 0x4b, 0xef, 0x3b, 0x70, 0xa0, 0xe4, 0x40, 0xff, 0xc3, 0xa9, 0xe6, 0x78, 0xf9,
        0x8b, 0x46, 0x80, 0x1e, 0x38, 0xe1, 0xb8, 0xa8, 0xe0, 0x0c, 0x23, 0x76, 0x1d, 0x25, 0x24, 0x05,
        0xf1, 0x6e, 0x94, 0x28, 0x9a, 0x84, 0xe8, 0xa3, 0x4f, 0x77, 0xd3, 0x85, 0xe2, 0x52, 0xf2, 0x82,
        0x50, 0x7a, 0x2f, 0x74, 0x53, 0xb3, 0x61, 0xaf, 0x39, 0x35, 0xde, 0xcd, 0x1f, 0x99, 0xac, 0xad,
        0x72, 0x2c, 0xdd, 0xd0, 0x87, 0xbe, 0x5e, 0xa6, 0xec, 0x04, 0xc6, 0x03, 0x34, 0xfb, 0xdb, 0x59,
        0xb6, 0xc2, 0x01, 0xf0, 0x5a, 0xed, 0xa7, 0x66, 0x21, 0x7f, 0x8a, 0x27, 0xc7, 0xc0, 0x29, 0xd7
    ];

    private static ReadOnlySpan<byte> S2 =>
    [
        0x93, 0xd9, 0x9a, 0xb5, 0x98, 0x22, 0x45, 0xfc, 0xba, 0x6a, 0xdf, 0x02, 0x9f, 0xdc, 0x51, 0x59,
        0x4a, 0x17, 0x2b, 0xc2, 0x94, 0xf4, 0xbb, 0xa3, 0x62, 0xe4, 0x71, 0xd4, 0xcd, 0x70, 0x16, 0xe1,
        0x49, 0x3c, 0xc0, 0xd8, 0x5c, 0x9b, 0xad, 0x85, 0x53, 0xa1, 0x7a, 0xc8, 0x2d, 0xe0, 0xd1, 0x72,
        0xa6, 0x2c, 0xc4, 0xe3, 0x76, 0x78, 0xb7, 0xb4, 0x09, 0x3b, 0x0e, 0x41, 0x4c, 0xde, 0xb2, 0x90,
        0x25, 0xa5, 0xd7, 0x03, 0x11, 0x00, 0xc3, 0x2e, 0x92, 0xef, 0x4e, 0x12, 0x9d, 0x7d, 0xcb, 0x35,
        0x10, 0xd5, 0x4f, 0x9e, 0x4d, 0xa9, 0x55, 0xc6, 0xd0, 0x7b, 0x18, 0x97, 0xd3, 0x36, 0xe6, 0x48,
        0x56, 0x81, 0x8f, 0x77, 0xcc, 0x9c, 0xb9, 0xe2, 0xac, 0xb8, 0x2f, 0x15, 0xa4, 0x7c, 0xda, 0x38,
        0x1e, 0x0b, 0x05, 0xd6, 0x14, 0x6e, 0x6c, 0x7e, 0x66, 0xfd, 0xb1, 0xe5, 0x60, 0xaf, 0x5e, 0x33,
        0x87, 0xc9, 0xf0, 0x5d, 0x6d, 0x3f, 0x88, 0x8d, 0xc7, 0xf7, 0x1d, 0xe9, 0xec, 0xed, 0x80, 0x29,
        0x27, 0xcf, 0x99, 0xa8, 0x50, 0x0f, 0x37, 0x24, 0x28, 0x30, 0x95, 0xd2, 0x3e, 0x5b, 0x40, 0x83,
        0xb3, 0x69, 0x57, 0x1f, 0x07, 0x1c, 0x8a, 0xbc, 0x20, 0xeb, 0xce, 0x8e, 0xab, 0xee, 0x31, 0xa2,
        0x73, 0xf9, 0xca, 0x3a, 0x1a, 0xfb, 0x0d, 0xc1, 0xfe, 0xfa, 0xf2, 0x6f, 0xbd, 0x96, 0xdd, 0x43,
        0x52, 0xb6, 0x08, 0xf3, 0xae, 0xbe, 0x19, 0x89, 0x32, 0x26, 0xb0, 0xea, 0x4b, 0x64, 0x84, 0x82,
        0x6b, 0xf5, 0x79, 0xbf, 0x01, 0x5f, 0x75, 0x63, 0x1b, 0x23, 0x3d, 0x68, 0x2a, 0x65, 0xe8, 0x91,
        0xf6, 0xff, 0x13, 0x58, 0xf1, 0x47, 0x0a, 0x7f, 0xc5, 0xa7, 0xe7, 0x61, 0x5a, 0x06, 0x46, 0x44,
        0x42, 0x04, 0xa0, 0xdb, 0x39, 0x86, 0x54, 0xaa, 0x8c, 0x34, 0x21, 0x8b, 0xf8, 0x0c, 0x74, 0x67
    ];

    private static ReadOnlySpan<byte> S3 =>
    [
        0x68, 0x8d, 0xca, 0x4d, 0x73, 0x4b, 0x4e, 0x2a, 0xd4, 0x52, 0x26, 0xb3, 0x54, 0x1e, 0x19, 0x1f,
        0x22, 0x03, 0x46, 0x3d, 0x2d, 0x4a, 0x53, 0x83, 0x13, 0x8a, 0xb7, 0xd5, 0x25, 0x79, 0xf5, 0xbd,
        0x58, 0x2f, 0x0d, 0x02, 0xed, 0x51, 0x9e, 0x11, 0xf2, 0x3e, 0x55, 0x5e, 0xd1, 0x16, 0x3c, 0x66,
        0x70, 0x5d, 0xf3, 0x45, 0x40, 0xcc, 0xe8, 0x94, 0x56, 0x08, 0xce, 0x1a, 0x3a, 0xd2, 0xe1, 0xdf,
        0xb5, 0x38, 0x6e, 0x0e, 0xe5, 0xf4, 0xf9, 0x86, 0xe9, 0x4f, 0xd6, 0x85, 0x23, 0xcf, 0x32, 0x99,
        0x31, 0x14, 0xae, 0xee, 0xc8, 0x48, 0xd3, 0x30, 0xa1, 0x92, 0x41, 0xb1, 0x18, 0xc4, 0x2c, 0x71,
        0x72, 0x44, 0x15, 0xfd, 0x37, 0xbe, 0x5f, 0xaa, 0x9b, 0x88, 0xd8, 0xab, 0x89, 0x9c, 0xfa, 0x60,
        0xea, 0xbc, 0x62, 0x0c, 0x24, 0xa6, 0xa8, 0xec, 0x67, 0x20, 0xdb, 0x7c, 0x28, 0xdd, 0xac, 0x5b,
        0x34, 0x7e, 0x10, 0xf1, 0x7b, 0x8f, 0x63, 0xa0, 0x05, 0x9a, 0x43, 0x77, 0x21, 0xbf, 0x27, 0x09,
        0xc3, 0x9f, 0xb6, 0xd7, 0x29, 0xc2, 0xeb, 0xc0, 0xa4, 0x8b, 0x8c, 0x1d, 0xfb, 0xff, 0xc1, 0xb2,
        0x97, 0x2e, 0xf8, 0x65, 0xf6, 0x75, 0x07, 0x04, 0x49, 0x33, 0xe4, 0xd9, 0xb9, 0xd0, 0x42, 0xc7,
        0x6c, 0x90, 0x00, 0x8e, 0x6f, 0x50, 0x01, 0xc5, 0xda, 0x47, 0x3f, 0xcd, 0x69, 0xa2, 0xe2, 0x7a,
        0xa7, 0xc6, 0x93, 0x0f, 0x0a, 0x06, 0xe6, 0x2b, 0x96, 0xa3, 0x1c, 0xaf, 0x6a, 0x12, 0x84, 0x39,
        0xe7, 0xb0, 0x82, 0xf7, 0xfe, 0x9d, 0x87, 0x5c, 0x81, 0x35, 0xde, 0xb4, 0xa5, 0xfc, 0x80, 0xef,
        0xcb, 0xbb, 0x6b, 0x76, 0xba, 0x5a, 0x7d, 0x78, 0x0b, 0x95, 0xe3, 0xad, 0x74, 0x98, 0x3b, 0x36,
        0x64, 0x6d, 0xdc, 0xf0, 0x59, 0xa9, 0x4c, 0x17, 0x7f, 0x91, 0xb8, 0xc9, 0x57, 0x1b, 0xe0, 0x61
    ];

    // Combined SubBytes + MixColumns lookup tables.
    // T_k[b] for row k, input byte b: the ulong whose byte j = MDS[j][k] * S[k%4][b].
    // This eliminates separate SubBytes and MixColumns steps — one table lookup per row per column.
    private static readonly ulong[] T0, T1, T2, T3, T4, T5, T6, T7;

    // ShiftBytes offsets per state size (integrated into T-table round via shifted source reads).
    private static readonly int[] Shifts512 = [0, 1, 2, 3, 4, 5, 6, 7];
    private static readonly int[] Shifts1024 = [0, 1, 2, 3, 4, 5, 6, 11];

    [SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "Perf not critical for regional hash algorithms.")]
    static Kupyna()
    {
        // MDS circulant matrix first row from DSTU 7564:2014.
        // MDS[j][k] = mds[(k - j) mod 8] for the 8×8 circulant.
        ReadOnlySpan<byte> mds = [1, 1, 5, 1, 8, 6, 7, 4];

        T0 = new ulong[256];
        T1 = new ulong[256];
        T2 = new ulong[256];
        T3 = new ulong[256];
        T4 = new ulong[256];
        T5 = new ulong[256];
        T6 = new ulong[256];
        T7 = new ulong[256];

        ulong[][] tables = [T0, T1, T2, T3, T4, T5, T6, T7];

        for (int k = 0; k < 8; k++)
        {
            ReadOnlySpan<byte> sbox = (k & 3) switch { 0 => S0, 1 => S1, 2 => S2, _ => S3 };
            ulong[] table = tables[k];

            for (int b = 0; b < 256; b++)
            {
                byte sb = sbox[b];
                ulong entry = 0;
                for (int j = 0; j < 8; j++)
                {
                    entry |= (ulong)GfMul(mds[(k - j) & 7], sb) << (j * 8);
                }

                table[b] = entry;
            }
        }
    }

    private readonly int _hashSizeBytes;
    private readonly int _blockSize;
    private readonly int _columns;
    private readonly int _rounds;
    private readonly int _colMask;
    private readonly int[] _shifts;
    private readonly ulong[] _state;
    private readonly ulong[] _tempState1;
    private readonly ulong[] _tempState2;
    private readonly ulong[] _scratch;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _inputBlocks;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kupyna"/> class with 512-bit output.
    /// </summary>
    public Kupyna() : this(64)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Kupyna"/> class.
    /// </summary>
    /// <param name="hashSizeBytes">The desired output size in bytes (32, 48, or 64).</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="hashSizeBytes"/> is not 32, 48, or 64.
    /// </exception>
    public Kupyna(int hashSizeBytes)
    {
        if (hashSizeBytes != 32 && hashSizeBytes != 48 && hashSizeBytes != 64)
        {
            throw new ArgumentException("Hash size must be 32 (256-bit), 48 (384-bit), or 64 (512-bit) bytes.", nameof(hashSizeBytes));
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;

        if (hashSizeBytes <= 32)
        {
            _columns = Nb512;
            _rounds = Nr512;
        }
        else
        {
            _columns = Nb1024;
            _rounds = Nr1024;
        }

        _blockSize = _columns << 3;
        _colMask = _columns - 1;
        _shifts = _columns == Nb512 ? Shifts512 : Shifts1024;
        _state = new ulong[_columns];
        _tempState1 = new ulong[_columns];
        _tempState2 = new ulong[_columns];
        _scratch = new ulong[_columns];
        _buffer = new byte[_blockSize];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => $"Kupyna-{_hashSizeBytes * 8}";

    /// <inheritdoc/>
    public override int BlockSize => _blockSize;

    /// <summary>
    /// Creates a new instance with default 512-bit output.
    /// </summary>
    /// <returns>A new <see cref="Kupyna"/> instance.</returns>
    public static new Kupyna Create() => new();

    /// <summary>
    /// Creates a new instance with specified output size.
    /// </summary>
    /// <param name="hashSizeBytes">The hash size in bytes (32, 48, or 64).</param>
    /// <returns>A new <see cref="Kupyna"/> instance.</returns>
    public static Kupyna Create(int hashSizeBytes) => new(hashSizeBytes);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        _state[0] = (ulong)_blockSize;

        _bufferLength = 0;
        _inputBlocks = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(_blockSize - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == _blockSize)
            {
                ProcessBlock(_buffer);
                _bufferLength = 0;
                ++_inputBlocks;
            }
        }

        while (offset + _blockSize <= source.Length)
        {
            ProcessBlock(source.Slice(offset, _blockSize));
            offset += _blockSize;
            ++_inputBlocks;
        }

        int remaining = source.Length - offset;
        if (remaining > 0)
        {
            source.Slice(offset, remaining).CopyTo(_buffer.AsSpan());
            _bufferLength = remaining;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        unchecked
        {
            // Padding per DSTU 7564: append 0x80, zeros, then 96-bit message length in bits
            int inputBytes = _bufferLength;
            _buffer[_bufferLength++] = 0x80;

            int lenPos = _blockSize - 12;
            if (_bufferLength > lenPos)
            {
                while (_bufferLength < _blockSize)
                {
                    _buffer[_bufferLength++] = 0;
                }

                _bufferLength = 0;
                ProcessBlock(_buffer);
            }

            while (_bufferLength < lenPos)
            {
                _buffer[_bufferLength++] = 0;
            }

            // 96-bit message length in bits (little-endian: 32-bit low + 64-bit high)
            ulong c = ((_inputBlocks & 0xFFFFFFFFUL) * (ulong)_blockSize + (uint)inputBytes) << 3;
            BinaryPrimitives.WriteUInt32LittleEndian(_buffer.AsSpan(_bufferLength), (uint)c);
            _bufferLength += sizeof(UInt32);
            c >>= 32;
            c += ((_inputBlocks >> 32) * (ulong)_blockSize) << 3;
            BinaryPrimitives.WriteUInt64LittleEndian(_buffer.AsSpan(_bufferLength), c);

            ProcessBlock(_buffer);

            // Output transformation: state ^= P(state)
            Array.Copy(_state, 0, _tempState1, 0, _columns);
            P(_tempState1);
            for (int col = 0; col < _columns; ++col)
            {
                _state[col] ^= _tempState1[col];
            }

            // Truncation: extract hash from the last columns
            int neededColumns = _hashSizeBytes / sizeof(UInt64);
            int outOff = 0;
            for (int col = _columns - neededColumns; col < _columns; ++col)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(outOff, sizeof(UInt64)), _state[col]);
                outOff += sizeof(UInt64);
            }

            bytesWritten = _hashSizeBytes;
            return true;
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            Array.Clear(_tempState1, 0, _tempState1.Length);
            Array.Clear(_tempState2, 0, _tempState2.Length);
            Array.Clear(_scratch, 0, _scratch.Length);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Processes a single block using the compression function: h = P(h ⊕ m) ⊕ Q(m) ⊕ h.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            for (int col = 0; col < _columns; ++col)
            {
                ulong word = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(col << 3, sizeof(UInt64)));
                _tempState1[col] = _state[col] ^ word;
                _tempState2[col] = word;
            }

            P(_tempState1);
            Q(_tempState2);

            for (int col = 0; col < _columns; ++col)
            {
                _state[col] ^= _tempState1[col] ^ _tempState2[col];
            }
        }
    }

    /// <summary>
    /// Applies the T⊕ (P) permutation with XOR-based round constants.
    /// </summary>
    /// <remarks>
    /// Uses precomputed T-tables to combine SubBytes, ShiftBytes, and MixColumns into a single
    /// step of 8 table lookups and 7 XORs per column.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void P(ulong[] s)
    {
        unchecked
        {
            ulong[] src = s, dst = _scratch;
            for (int round = 0; round < _rounds; ++round)
            {
                AddRoundConstantP(src, round);
                SubShiftMix(src, dst);
                (src, dst) = (dst, src);
            }

            // Both Nr512 (10) and Nr1024 (14) are even, so the result is already in s.
        }
    }

    /// <summary>
    /// Applies the T+ (Q) permutation with addition-based round constants.
    /// </summary>
    /// <remarks>
    /// Uses precomputed T-tables to combine SubBytes, ShiftBytes, and MixColumns into a single
    /// step of 8 table lookups and 7 XORs per column.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void Q(ulong[] s)
    {
        unchecked
        {
            ulong[] src = s, dst = _scratch;
            for (int round = 0; round < _rounds; ++round)
            {
                AddRoundConstantQ(src, round);
                SubShiftMix(src, dst);
                (src, dst) = (dst, src);
            }
        }
    }

    /// <summary>
    /// Adds XOR-based round constants to the state (P permutation).
    /// </summary>
    /// <remarks>
    /// Per DSTU 7564: only byte 0 of each column is modified.
    /// <c>state[col][0] ^= (col * 0x10) ^ round</c>.
    /// In little-endian ulong representation, byte 0 is the least significant byte.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void AddRoundConstantP(ulong[] s, int round)
    {
        unchecked
        {
            for (int col = 0; col < _columns; ++col)
            {
                s[col] ^= (ulong)((col << 4) ^ round);
            }
        }
    }

    /// <summary>
    /// Adds addition-based round constants to the state (Q permutation).
    /// </summary>
    /// <remarks>
    /// Per DSTU 7564: the 64-bit column word is added to a constant constructed as
    /// <c>0x00F0F0F0F0F0F0F3 ^ (((columns - col - 1) * 0x10 ^ round) &lt;&lt; 56)</c>.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void AddRoundConstantQ(ulong[] s, int round)
    {
        unchecked
        {
            for (int col = 0; col < _columns; ++col)
            {
                ulong rc = 0x00F0F0F0F0F0F0F3UL ^ ((ulong)(((_columns - col - 1) << 4) ^ round) << 56);
                s[col] += rc;
            }
        }
    }

    /// <summary>
    /// Combined SubBytes + ShiftBytes + MixColumns transformation using precomputed T-tables.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For each output column, reads 8 bytes from shifted source columns (integrating ShiftBytes),
    /// performs T-table lookups (combining SubBytes + MixColumns), and XORs the 8 results.
    /// </para>
    /// <para>
    /// This replaces three separate passes with a single pass of 8 table lookups + 7 XORs per column.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void SubShiftMix(ulong[] src, ulong[] dst)
    {
        unchecked
        {
            int cols = _columns;
            int mask = _colMask;
            int s1 = _shifts[1], s2 = _shifts[2], s3 = _shifts[3];
            int s4 = _shifts[4], s5 = _shifts[5], s6 = _shifts[6], s7 = _shifts[7];

            for (int col = 0; col < cols; ++col)
            {
                dst[col] = T0[(byte)src[col]]
                         ^ T1[(byte)(src[(col - s1) & mask] >> 8)]
                         ^ T2[(byte)(src[(col - s2) & mask] >> 16)]
                         ^ T3[(byte)(src[(col - s3) & mask] >> 24)]
                         ^ T4[(byte)(src[(col - s4) & mask] >> 32)]
                         ^ T5[(byte)(src[(col - s5) & mask] >> 40)]
                         ^ T6[(byte)(src[(col - s6) & mask] >> 48)]
                         ^ T7[(byte)(src[(col - s7) & mask] >> 56)];
            }
        }
    }

    /// <summary>
    /// Multiplies two elements in GF(2^8) with reduction polynomial x^8+x^4+x^3+x^2+1 (0x11D).
    /// </summary>
    /// <remarks>
    /// Used only during static T-table initialization; not called at runtime.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static byte GfMul(byte a, byte b)
    {
        unchecked
        {
            uint p = 0, aa = a, bb = b;
            while (bb != 0)
            {
                if ((bb & 1) != 0)
                {
                    p ^= aa;
                }

                aa <<= 1;
                if ((aa & 0x100) != 0)
                {
                    aa ^= 0x11D;
                }

                bb >>= 1;
            }

            return (byte)p;
        }
    }
}
