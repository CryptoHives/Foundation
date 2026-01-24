// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

/// <summary>
/// Computes the Streebog (GOST R 34.11-2012) hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// Streebog is the Russian national cryptographic hash standard defined in GOST R 34.11-2012.
/// It supports output sizes of 256 or 512 bits.
/// </para>
/// <para>
/// This implementation follows RFC 6986 which specifies the GOST R 34.11-2012 algorithm.
/// </para>
/// TODO: Expose a class Streebog256 and Streebog512 and make Streebog internal.
/// </remarks>
public sealed class Streebog : HashAlgorithm
{
    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    /// <summary>
    /// Number of rounds in the E function.
    /// </summary>
    private const int Rounds = 12;

    // S-box (Pi substitution) - RFC 6986 Section 6.2
    // This is a byte substitution table for the nonlinear transformation.
    private static readonly byte[] Pi =
    [
        0xFC, 0xEE, 0xDD, 0x11, 0xCF, 0x6E, 0x31, 0x16, 0xFB, 0xC4, 0xFA, 0xDA, 0x23, 0xC5, 0x04, 0x4D,
        0xE9, 0x77, 0xF0, 0xDB, 0x93, 0x2E, 0x99, 0xBA, 0x17, 0x36, 0xF1, 0xBB, 0x14, 0xCD, 0x5F, 0xC1,
        0xF9, 0x18, 0x65, 0x5A, 0xE2, 0x5C, 0xEF, 0x21, 0x81, 0x1C, 0x3C, 0x42, 0x8B, 0x01, 0x8E, 0x4F,
        0x05, 0x84, 0x02, 0xAE, 0xE3, 0x6A, 0x8F, 0xA0, 0x06, 0x0B, 0xED, 0x98, 0x7F, 0xD4, 0xD3, 0x1F,
        0xEB, 0x34, 0x2C, 0x51, 0xEA, 0xC8, 0x48, 0xAB, 0xF2, 0x2A, 0x68, 0xA2, 0xFD, 0x3A, 0xCE, 0xCC,
        0xB5, 0x70, 0x0E, 0x56, 0x08, 0x0C, 0x76, 0x12, 0xBF, 0x72, 0x13, 0x47, 0x9C, 0xB7, 0x5D, 0x87,
        0x15, 0xA1, 0x96, 0x29, 0x10, 0x7B, 0x9A, 0xC7, 0xF3, 0x91, 0x78, 0x6F, 0x9D, 0x9E, 0xB2, 0xB1,
        0x32, 0x75, 0x19, 0x3D, 0xFF, 0x35, 0x8A, 0x7E, 0x6D, 0x54, 0xC6, 0x80, 0xC3, 0xBD, 0x0D, 0x57,
        0xDF, 0xF5, 0x24, 0xA9, 0x3E, 0xA8, 0x43, 0xC9, 0xD7, 0x79, 0xD6, 0xF6, 0x7C, 0x22, 0xB9, 0x03,
        0xE0, 0x0F, 0xEC, 0xDE, 0x7A, 0x94, 0xB0, 0xBC, 0xDC, 0xE8, 0x28, 0x50, 0x4E, 0x33, 0x0A, 0x4A,
        0xA7, 0x97, 0x60, 0x73, 0x1E, 0x00, 0x62, 0x44, 0x1A, 0xB8, 0x38, 0x82, 0x64, 0x9F, 0x26, 0x41,
        0xAD, 0x45, 0x46, 0x92, 0x27, 0x5E, 0x55, 0x2F, 0x8C, 0xA3, 0xA5, 0x7D, 0x69, 0xD5, 0x95, 0x3B,
        0x07, 0x58, 0xB3, 0x40, 0x86, 0xAC, 0x1D, 0xF7, 0x30, 0x37, 0x6B, 0xE4, 0x88, 0xD9, 0xE7, 0x89,
        0xE1, 0x1B, 0x83, 0x49, 0x4C, 0x3F, 0xF8, 0xFE, 0x8D, 0x53, 0xAA, 0x90, 0xCA, 0xD8, 0x85, 0x61,
        0x20, 0x71, 0x67, 0xA4, 0x2D, 0x2B, 0x09, 0x5B, 0xCB, 0x9B, 0x25, 0xD0, 0xBE, 0xE5, 0x6C, 0x52,
        0x59, 0xA6, 0x74, 0xD2, 0xE6, 0xF4, 0xB4, 0xC0, 0xD1, 0x66, 0xAF, 0xC2, 0x39, 0x4B, 0x63, 0xB6
    ];

    // Tau permutation - RFC 6986 Section 6.3
    // Transposes the 8x8 byte matrix (column-major to row-major).
    private static readonly byte[] Tau =
    [
        0, 8, 16, 24, 32, 40, 48, 56,
        1, 9, 17, 25, 33, 41, 49, 57,
        2, 10, 18, 26, 34, 42, 50, 58,
        3, 11, 19, 27, 35, 43, 51, 59,
        4, 12, 20, 28, 36, 44, 52, 60,
        5, 13, 21, 29, 37, 45, 53, 61,
        6, 14, 22, 30, 38, 46, 54, 62,
        7, 15, 23, 31, 39, 47, 55, 63
    ];

    // Linear transformation matrix A - RFC 6986 Section 6.4
    // Each entry represents an element of GF(2^64), applied row-by-row.
    private static readonly ulong[] A =
    [
        0x8e20faa72ba0b470UL, 0x47107ddd9b505a38UL, 0xad08b0e0c3282d1cUL, 0xd8045870ef14980eUL,
        0x6c022c38f90a4c07UL, 0x3601161cf205268dUL, 0x1b8e0b0e798c13c8UL, 0x83478b07b2468764UL,
        0xa011d380818e8f40UL, 0x5086e740ce47c920UL, 0x2843fd2067adea10UL, 0x14aff010bdd87508UL,
        0x0ad97808d06cb404UL, 0x05e23c0468365a02UL, 0x8c711e02341b2d01UL, 0x46b60f011a83988eUL,
        0x90dab52a387ae76fUL, 0x486dd4151c3dfdb9UL, 0x24b86a840e90f0d2UL, 0x125c354207487869UL,
        0x092e94218d243cbaUL, 0x8a174a9ec8121e5dUL, 0x4585254f64090fa0UL, 0xaccc9ca9328a8950UL,
        0x9d4df05d5f661451UL, 0xc0a878a0a1330aa6UL, 0x60543c50de970553UL, 0x302a1e286fc58ca7UL,
        0x18150f14b9ec46ddUL, 0x0c84890ad27623e0UL, 0x0642ca05693b9f70UL, 0x0321658cba93c138UL,
        0x86275df09ce8aaa8UL, 0x439da0784e745554UL, 0xafc0503c273aa42aUL, 0xd960281e9d1d5215UL,
        0xe230140fc0802984UL, 0x71180a8960409a42UL, 0xb60c05ca30204d21UL, 0x5b068c651810a89eUL,
        0x456c34887a3805b9UL, 0xac361a443d1c8cd2UL, 0x561b0d22900e4669UL, 0x2b838811480723baUL,
        0x9bcf4486248d9f5dUL, 0xc3e9224312c8c1a0UL, 0xeffa11af0964ee50UL, 0xf97d86d98a327728UL,
        0xe4fa2054a80b329cUL, 0x727d102a548b194eUL, 0x39b008152acb8227UL, 0x9258048415eb419dUL,
        0x492c024284fbaec0UL, 0xaa16012142f35760UL, 0x550b8e9e21f7a530UL, 0xa48b474f9ef5dc18UL,
        0x70a6a56e2440598eUL, 0x3853dc371220a247UL, 0x1ca76e95091051adUL, 0x0edd37c48a08a6d8UL,
        0x07e095624504536cUL, 0x8d70c431ac02a736UL, 0xc83862965601dd1bUL, 0x641c314b2b8ee083UL
    ];

    // Combined LPS lookup tables: T[row][byte_value] -> ulong contribution
    // These tables precompute S-box substitution, P permutation, and L linear transformation
    // for each byte position (8 tables × 256 entries × 8 bytes = 16KB total)
    private static readonly ulong[] T0, T1, T2, T3, T4, T5, T6, T7;

    // Iteration constants C for the 12 rounds as ulong[8] - RFC 6986 Section 6.5
    // Precomputed from the byte arrays for efficient 64-bit XOR operations
    private static readonly ulong[][] CU;

#if NET8_0_OR_GREATER
    // Round constants as Vector512 for SIMD operations
    private static readonly Vector512<ulong>[] CV;
#endif

    // Iteration constants C for the 12 rounds - RFC 6986 Section 6.5 (kept for ApplyLPS byte[] overload)
    // These are the exact hex values from the specification.
    private static readonly byte[][] C =
    [
        FromHex("b1085bda1ecadae9ebcb2f81c0657c1f2f6a76432e45d016714eb88d7585c4fc4b7ce09192676901a2422a08a460d31505767436cc744d23dd806559f2a64507"),
        FromHex("6fa3b58aa99d2f1a4fe39d460f70b5d7f3feea720a232b9861d55e0f16b501319ab5176b12d699585cb561c2db0aa7ca55dda21bd7cbcd56e679047021b19bb7"),
        FromHex("f574dcac2bce2fc70a39fc286a3d843506f15e5f529c1f8bf2ea7514b1297b7bd3e20fe490359eb1c1c93a376062db09c2b6f443867adb31991e96f50aba0ab2"),
        FromHex("ef1fdfb3e81566d2f948e1a05d71e4dd488e857e335c3c7d9d721cad685e353fa9d72c82ed03d675d8b71333935203be3453eaa193e837f1220cbebc84e3d12e"),
        FromHex("4bea6bacad4747999a3f410c6ca923637f151c1f1686104a359e35d7800fffbdbfcd1747253af5a3dfff00b723271a167a56a27ea9ea63f5601758fd7c6cfe57"),
        FromHex("ae4faeae1d3ad3d96fa4c33b7a3039c02d66c4f95142a46c187f9ab49af08ec6cffaa6b71c9ab7b40af21f66c2bec6b6bf71c57236904f35fa68407a46647d6e"),
        FromHex("f4c70e16eeaac5ec51ac86febf240954399ec6c7e6bf87c9d3473e33197a93c90992abc52d822c3706476983284a05043517454ca23c4af38886564d3a14d493"),
        FromHex("9b1f5b424d93c9a703e7aa020c6e41414eb7f8719c36de1e89b4443b4ddbc49af4892bcb929b069069d18d2bd1a5c42f36acc2355951a8d9a47f0dd4bf02e71e"),
        FromHex("378f5a541631229b944c9ad8ec165fde3a7d3a1b258942243cd955b7e00d0984800a440bdbb2ceb17b2b8a9aa6079c540e38dc92cb1f2a607261445183235adb"),
        FromHex("abbedea680056f52382ae548b2e4f3f38941e71cff8a78db1fffe18a1b3361039fe76702af69334b7a1e6c303b7652f43698fad1153bb6c374b4c7fb98459ced"),
        FromHex("7bcd9ed0efc889fb3002c6cd635afe94d8fa6bbbebab076120018021148466798a1d71efea48b9caefbacd1d7d476e98dea2594ac06fd85d6bcaa4cd81f32d1b"),
        FromHex("378ee767f11631bad21380b00449b17acda43c32bcdf1d77f82012d430219f9b5d80ef9d1891cc86e71da4aa88e12852faf417d5d9b21b9948bc924af11bd720")
    ];

    private static readonly ulong[] _zeroArray = [0, 0, 0, 0, 0, 0, 0, 0];

    static Streebog()
    {
        // Initialize the 8 combined LPS lookup tables as flat arrays for better cache locality
        T0 = new ulong[256];
        T1 = new ulong[256];
        T2 = new ulong[256];
        T3 = new ulong[256];
        T4 = new ulong[256];
        T5 = new ulong[256];
        T6 = new ulong[256];
        T7 = new ulong[256];

        // Compute lookup tables
        for (int inputByte = 0; inputByte < 256; inputByte++)
        {
            byte substituted = Pi[inputByte];

            for (int row = 0; row < 8; row++)
            {
                ulong contribution = 0;
                for (int k = 0; k < 8; k++)
                {
                    if ((substituted & (1 << k)) != 0)
                    {
                        contribution ^= A[row * 8 + (7 - k)];
                    }
                }

                switch (row)
                {
                    case 0: T0[inputByte] = contribution; break;
                    case 1: T1[inputByte] = contribution; break;
                    case 2: T2[inputByte] = contribution; break;
                    case 3: T3[inputByte] = contribution; break;
                    case 4: T4[inputByte] = contribution; break;
                    case 5: T5[inputByte] = contribution; break;
                    case 6: T6[inputByte] = contribution; break;
                    case 7: T7[inputByte] = contribution; break;
                }
            }
        }

        // Initialize round constants as ulong arrays
        CU = new ulong[12][];
        for (int round = 0; round < 12; round++)
        {
            CU[round] = new ulong[8];
            for (int i = 0; i < 8; i++)
            {
                CU[round][i] = BinaryPrimitives.ReadUInt64LittleEndian(C[round].AsSpan(i * 8, 8));
            }
        }

#if NET8_0_OR_GREATER
        // Initialize round constants as Vector512 for SIMD
        CV = new Vector512<ulong>[12];
        for (int round = 0; round < 12; round++)
        {
            CV[round] = Vector512.Create(
                CU[round][0], CU[round][1], CU[round][2], CU[round][3],
                CU[round][4], CU[round][5], CU[round][6], CU[round][7]);
        }
#endif
    }

    private readonly int _hashSizeBytes;
    private readonly ulong[] _h;      // Hash state (512-bit as 8 ulongs)
    private readonly ulong[] _n;      // Bit counter (512-bit as 8 ulongs)
    private readonly ulong[] _sigma;  // Checksum accumulator (512-bit as 8 ulongs)
    private readonly byte[] _buffer;  // Message block buffer
    private int _bufferLength;

    /// <summary>
    /// Converts a hex string to a byte array.
    /// </summary>
    /// <remarks>
    /// This conversion stores the first hex byte value in the string at position 0.
    /// </remarks>
    internal static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[bytes.Length - i - 1] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return bytes;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Streebog"/> class with 512-bit output.
    /// </summary>
    public Streebog() : this(64)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Streebog"/> class.
    /// </summary>
    /// <param name="hashSizeBytes">The desired output size in bytes (32 or 64).</param>
    public Streebog(int hashSizeBytes)
    {
        if (hashSizeBytes != 32 && hashSizeBytes != 64) throw new ArgumentException("Hash size must be 32 or 64 bytes.", nameof(hashSizeBytes));

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;
        _h = new ulong[8];
        _n = new ulong[8];
        _sigma = new ulong[8];
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <summary>
    /// Gets the name of the hash algorithm.
    /// </summary>
    public override string AlgorithmName => _hashSizeBytes == 32 ? "Streebog-256" : "Streebog-512";

    /// <summary>
    /// Gets the block size of the hash algorithm.
    /// </summary>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Streebog"/> class with default output size (64 bytes).
    /// </summary>
    /// <returns>A new Streebog hash algorithm instance.</returns>
    public static new Streebog Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Streebog"/> class with specified output size.
    /// </summary>
    /// <param name="hashSizeBytes">The hash size in bytes (32 or 64).</param>
    /// <returns>A new Streebog hash algorithm instance.</returns>
    public static Streebog Create(int hashSizeBytes) => new(hashSizeBytes);

    /// <inheritdoc/>
    public override void Initialize()
    {
        // IV is 0x00 for 512-bit, 0x01 for 256-bit (RFC 6986 Section 6.1)
        ulong iv = _hashSizeBytes == 32 ? 0x0101010101010101UL : 0UL;

        _h[0] = iv; _h[1] = iv; _h[2] = iv; _h[3] = iv;
        _h[4] = iv; _h[5] = iv; _h[6] = iv; _h[7] = iv;
        _n[0] = 0; _n[1] = 0; _n[2] = 0; _n[3] = 0;
        _n[4] = 0; _n[5] = 0; _n[6] = 0; _n[7] = 0;
        _sigma[0] = 0; _sigma[1] = 0; _sigma[2] = 0; _sigma[3] = 0;
        _sigma[4] = 0; _sigma[5] = 0; _sigma[6] = 0; _sigma[7] = 0;

        ClearBuffer(_buffer);
        _bufferLength = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // Fill buffer if partially full
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

        // Process complete blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
            offset += BlockSizeBytes;
        }

        // Buffer remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan());
            _bufferLength = source.Length - offset;
        }
    }

    /// <summary>
    /// Processes a complete 64-byte message block.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> m)
    {
        // Convert message to ulong array
        Span<ulong> mn = stackalloc ulong[8];

        // On little-endian platforms, directly reinterpret the byte span as ulong.
        // This avoids 16 individual BinaryPrimitives.ReadUInt64LittleEndian calls.
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, ulong>(m).CopyTo(mn);
        }
        else
        {
            mn[0] = BinaryPrimitives.ReadUInt64LittleEndian(m);
            mn[1] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(8));
            mn[2] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(16));
            mn[3] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(24));
            mn[4] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(32));
            mn[5] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(40));
            mn[6] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(48));
            mn[7] = BinaryPrimitives.ReadUInt64LittleEndian(m.Slice(56));
        }

        // g_N(h, m)
        GN(_h, _n, mn);

        // N = (N + 512) mod 2^512
        AddModulus512(_n, 512);

        // Sigma = (Sigma + m) mod 2^512
        AddBlock512(_sigma, mn);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad the final block: m || 1 || 0...0
        Span<byte> paddedBlock = stackalloc byte[64];
        paddedBlock.Clear();
        _buffer.AsSpan(0, _bufferLength).CopyTo(paddedBlock);
        paddedBlock[_bufferLength] = 0x01;

        // Convert padded block to ulongs
        Span<ulong> p = stackalloc ulong[8];
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, ulong>(paddedBlock).CopyTo(p);
        }
        else
        {
            p[0] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock);
            p[1] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(8));
            p[2] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(16));
            p[3] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(24));
            p[4] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(32));
            p[5] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(40));
            p[6] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(48));
            p[7] = BinaryPrimitives.ReadUInt64LittleEndian(paddedBlock.Slice(56));
        }

        // Stage 3: Process padded block
        GN(_h, _n, p);

        // Update N with the bit count of the final partial block
        AddModulus512(_n, _bufferLength * 8);

        // Update Sigma with padded block
        AddBlock512(_sigma, p);

        // Stage 4: Final compressions with zero
        GN(_h, _zeroArray, _n);
        GN(_h, _zeroArray, _sigma);

        // Output: convert ulong array back to bytes
        if (_hashSizeBytes == 32)
        {
            // For 256-bit, take the last 32 bytes (h[4..7])
            BinaryPrimitives.WriteUInt64LittleEndian(destination, _h[4]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(8), _h[5]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(16), _h[6]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(24), _h[7]);
        }
        else
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination, _h[0]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(8), _h[1]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(16), _h[2]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(24), _h[3]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(32), _h[4]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(40), _h[5]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(48), _h[6]);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(56), _h[7]);
        }

        bytesWritten = _hashSizeBytes;
        return true;
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// The g_N compression function: h = h ^ E(h ^ N, m) ^ m
    /// Uses Miyaguchi-Preneel construction with SIMD acceleration.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GN(ulong[] h, ReadOnlySpan<ulong> n, ReadOnlySpan<ulong> m)
    {
        // Load h, n, m as Vector512
        Vector512<ulong> hV = Vector512.Create(h[0], h[1], h[2], h[3], h[4], h[5], h[6], h[7]);
        Vector512<ulong> nV = Vector512.Create(n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7]);
        Vector512<ulong> mV = Vector512.Create(m[0], m[1], m[2], m[3], m[4], m[5], m[6], m[7]);

        // k = h ^ N
        Vector512<ulong> kV = Vector512.Xor(hV, nV);

        // k = LPS(k)
        Span<ulong> k = stackalloc ulong[8];
        kV.CopyTo(k);
        ApplyLPS(k);

        // t = E(k, m)
        // E function outputs directly to Vector512, reusing kV for temp storage
        E(k, m, ref kV);

        // h = h ^ t ^ m (using SIMD)
        Vector512<ulong> resultV = Vector512.Xor(Vector512.Xor(hV, kV), mV);

        // Store result back to h
        h[0] = resultV.GetElement(0);
        h[1] = resultV.GetElement(1);
        h[2] = resultV.GetElement(2);
        h[3] = resultV.GetElement(3);
        h[4] = resultV.GetElement(4);
        h[5] = resultV.GetElement(5);
        h[6] = resultV.GetElement(6);
        h[7] = resultV.GetElement(7);
    }

    /// <summary>
    /// The E function: 12-round block cipher with key schedule using SIMD.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void E(ReadOnlySpan<ulong> k, ReadOnlySpan<ulong> m, ref Vector512<ulong> resultV)
    {
        // Initialize state and key as Vector512
        Vector512<ulong> stateV = Vector512.Create(m[0], m[1], m[2], m[3], m[4], m[5], m[6], m[7]);
        Vector512<ulong> keyV = Vector512.Create(k[0], k[1], k[2], k[3], k[4], k[5], k[6], k[7]);

        Span<ulong> state = stackalloc ulong[8];
        Span<ulong> key = stackalloc ulong[8];

        for (int round = 0; round < Rounds; round++)
        {
            // AddRoundKey: state = state ^ key (SIMD)
            stateV = Vector512.Xor(stateV, keyV);

            // LPS transform on state (needs scalar for table lookups)
            stateV.CopyTo(state);
            ApplyLPS(state);
            stateV = Vector512.Create(state[0], state[1], state[2], state[3], state[4], state[5], state[6], state[7]);

            // Key schedule: key = LPS(key ^ C[round]) (SIMD for XOR)
            keyV = Vector512.Xor(keyV, CV[round]);
            keyV.CopyTo(key);
            ApplyLPS(key);
            keyV = Vector512.Create(key[0], key[1], key[2], key[3], key[4], key[5], key[6], key[7]);
        }

        // Final AddRoundKey (SIMD)
        resultV = Vector512.Xor(stateV, keyV);
    }
#else
    /// <summary>
    /// The g_N compression function: h = h ^ E(h ^ N, m) ^ m
    /// Uses Miyaguchi-Preneel construction.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GN(ulong[] h, ReadOnlySpan<ulong> n, ReadOnlySpan<ulong> m)
    {
        Span<ulong> k = stackalloc ulong[8];
        Span<ulong> t = stackalloc ulong[8];

        // k = h ^ N
        k[0] = h[0] ^ n[0]; k[1] = h[1] ^ n[1]; k[2] = h[2] ^ n[2]; k[3] = h[3] ^ n[3];
        k[4] = h[4] ^ n[4]; k[5] = h[5] ^ n[5]; k[6] = h[6] ^ n[6]; k[7] = h[7] ^ n[7];

        // k = LPS(k)
        ApplyLPS(k);

        // t = E(k, m)
        E(k, m, t);

        // h = h ^ t ^ m
        h[0] ^= t[0] ^ m[0]; h[1] ^= t[1] ^ m[1]; h[2] ^= t[2] ^ m[2]; h[3] ^= t[3] ^ m[3];
        h[4] ^= t[4] ^ m[4]; h[5] ^= t[5] ^ m[5]; h[6] ^= t[6] ^ m[6]; h[7] ^= t[7] ^ m[7];
    }

    /// <summary>
    /// The E function: 12-round block cipher with key schedule.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void E(ReadOnlySpan<ulong> k, ReadOnlySpan<ulong> m, Span<ulong> result)
    {
        Span<ulong> state = stackalloc ulong[8];
        Span<ulong> key = stackalloc ulong[8];

        m.CopyTo(state);
        k.CopyTo(key);

        for (int round = 0; round < Rounds; round++)
        {
            // AddRoundKey: state = state ^ key
            state[0] ^= key[0]; state[1] ^= key[1]; state[2] ^= key[2]; state[3] ^= key[3];
            state[4] ^= key[4]; state[5] ^= key[5]; state[6] ^= key[6]; state[7] ^= key[7];

            // LPS transform on state
            ApplyLPS(state);

            // Key schedule: key = LPS(key ^ C[round])
            ulong[] c = CU[round];
            key[0] ^= c[0]; key[1] ^= c[1]; key[2] ^= c[2]; key[3] ^= c[3];
            key[4] ^= c[4]; key[5] ^= c[5]; key[6] ^= c[6]; key[7] ^= c[7];
            ApplyLPS(key);
        }

        // Final AddRoundKey
        result[0] = state[0] ^ key[0]; result[1] = state[1] ^ key[1];
        result[2] = state[2] ^ key[2]; result[3] = state[3] ^ key[3];
        result[4] = state[4] ^ key[4]; result[5] = state[5] ^ key[5];
        result[6] = state[6] ^ key[6]; result[7] = state[7] ^ key[7];
    }
#endif

    /// <summary>
    /// Combined LPS transformation: L(P(S(data)))
    /// S = Substitution using Pi S-box
    /// P = Permutation using Tau
    /// L = Linear transformation using matrix A
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ApplyLPS(Span<ulong> data)
    {
        // Convert ulong span to byte span for table lookups
        Span<byte> d = MemoryMarshal.AsBytes(data);

        // Compute all 8 rows using lookup tables with hardcoded Tau indices
        // Row 0: Tau indices 0,8,16,24,32,40,48,56
        ulong r0 = T7[d[0]] ^ T6[d[8]] ^ T5[d[16]] ^ T4[d[24]] ^ T3[d[32]] ^ T2[d[40]] ^ T1[d[48]] ^ T0[d[56]];
        // Row 1: Tau indices 1,9,17,25,33,41,49,57
        ulong r1 = T7[d[1]] ^ T6[d[9]] ^ T5[d[17]] ^ T4[d[25]] ^ T3[d[33]] ^ T2[d[41]] ^ T1[d[49]] ^ T0[d[57]];
        // Row 2: Tau indices 2,10,18,26,34,42,50,58
        ulong r2 = T7[d[2]] ^ T6[d[10]] ^ T5[d[18]] ^ T4[d[26]] ^ T3[d[34]] ^ T2[d[42]] ^ T1[d[50]] ^ T0[d[58]];
        // Row 3: Tau indices 3,11,19,27,35,43,51,59
        ulong r3 = T7[d[3]] ^ T6[d[11]] ^ T5[d[19]] ^ T4[d[27]] ^ T3[d[35]] ^ T2[d[43]] ^ T1[d[51]] ^ T0[d[59]];
        // Row 4: Tau indices 4,12,20,28,36,44,52,60
        ulong r4 = T7[d[4]] ^ T6[d[12]] ^ T5[d[20]] ^ T4[d[28]] ^ T3[d[36]] ^ T2[d[44]] ^ T1[d[52]] ^ T0[d[60]];
        // Row 5: Tau indices 5,13,21,29,37,45,53,61
        ulong r5 = T7[d[5]] ^ T6[d[13]] ^ T5[d[21]] ^ T4[d[29]] ^ T3[d[37]] ^ T2[d[45]] ^ T1[d[53]] ^ T0[d[61]];
        // Row 6: Tau indices 6,14,22,30,38,46,54,62
        ulong r6 = T7[d[6]] ^ T6[d[14]] ^ T5[d[22]] ^ T4[d[30]] ^ T3[d[38]] ^ T2[d[46]] ^ T1[d[54]] ^ T0[d[62]];
        // Row 7: Tau indices 7,15,23,31,39,47,55,63
        ulong r7 = T7[d[7]] ^ T6[d[15]] ^ T5[d[23]] ^ T4[d[31]] ^ T3[d[39]] ^ T2[d[47]] ^ T1[d[55]] ^ T0[d[63]];

        data[0] = r0; data[1] = r1; data[2] = r2; data[3] = r3;
        data[4] = r4; data[5] = r5; data[6] = r6; data[7] = r7;
    }

    /// <summary>
    /// Combined LPS transformation for byte spans (used by test compatibility).
    /// </summary>
    internal static void ApplyLPS(Span<byte> data)
    {
        // Row 0: Tau indices 0,8,16,24,32,40,48,56
        ulong r0 = T7[data[0]] ^ T6[data[8]] ^ T5[data[16]] ^ T4[data[24]] ^ T3[data[32]] ^ T2[data[40]] ^ T1[data[48]] ^ T0[data[56]];
        // Row 1: Tau indices 1,9,17,25,33,41,49,57
        ulong r1 = T7[data[1]] ^ T6[data[9]] ^ T5[data[17]] ^ T4[data[25]] ^ T3[data[33]] ^ T2[data[41]] ^ T1[data[49]] ^ T0[data[57]];
        // Row 2: Tau indices 2,10,18,26,34,42,50,58
        ulong r2 = T7[data[2]] ^ T6[data[10]] ^ T5[data[18]] ^ T4[data[26]] ^ T3[data[34]] ^ T2[data[42]] ^ T1[data[50]] ^ T0[data[58]];
        // Row 3: Tau indices 3,11,19,27,35,43,51,59
        ulong r3 = T7[data[3]] ^ T6[data[11]] ^ T5[data[19]] ^ T4[data[27]] ^ T3[data[35]] ^ T2[data[43]] ^ T1[data[51]] ^ T0[data[59]];
        // Row 4: Tau indices 4,12,20,28,36,44,52,60
        ulong r4 = T7[data[4]] ^ T6[data[12]] ^ T5[data[20]] ^ T4[data[28]] ^ T3[data[36]] ^ T2[data[44]] ^ T1[data[52]] ^ T0[data[60]];
        // Row 5: Tau indices 5,13,21,29,37,45,53,61
        ulong r5 = T7[data[5]] ^ T6[data[13]] ^ T5[data[21]] ^ T4[data[29]] ^ T3[data[37]] ^ T2[data[45]] ^ T1[data[53]] ^ T0[data[61]];
        // Row 6: Tau indices 6,14,22,30,38,46,54,62
        ulong r6 = T7[data[6]] ^ T6[data[14]] ^ T5[data[22]] ^ T4[data[30]] ^ T3[data[38]] ^ T2[data[46]] ^ T1[data[54]] ^ T0[data[62]];
        // Row 7: Tau indices 7,15,23,31,39,47,55,63
        ulong r7 = T7[data[7]] ^ T6[data[15]] ^ T5[data[23]] ^ T4[data[31]] ^ T3[data[39]] ^ T2[data[47]] ^ T1[data[55]] ^ T0[data[63]];

        // Write result back to data in little-endian order
        BinaryPrimitives.WriteUInt64LittleEndian(data, r0);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(8), r1);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(16), r2);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(24), r3);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(32), r4);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(40), r5);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(48), r6);
        BinaryPrimitives.WriteUInt64LittleEndian(data.Slice(56), r7);
    }

    /// <summary>
    /// Add a number of bits to the 512-bit counter (little-endian arithmetic).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void AddModulus512(ulong[] counter, int bits)
    {
        unchecked
        {
            ulong sum = counter[0] + (ulong)bits;
            ulong carry = sum < counter[0] ? 1UL : 0UL;
            counter[0] = sum;
            if (carry == 0) return;

            sum = counter[1] + carry;
            carry = sum < counter[1] ? 1UL : 0UL;
            counter[1] = sum;
            if (carry == 0) return;
            sum = counter[2] + carry;
            carry = sum < counter[2] ? 1UL : 0UL;
            counter[2] = sum;
            if (carry == 0) return;
            sum = counter[3] + carry;
            carry = sum < counter[3] ? 1UL : 0UL;
            counter[3] = sum;
            if (carry == 0) return;
            sum = counter[4] + carry;
            carry = sum < counter[4] ? 1UL : 0UL;
            counter[4] = sum;
            if (carry == 0) return;
            sum = counter[5] + carry;
            carry = sum < counter[5] ? 1UL : 0UL;
            counter[5] = sum;
            if (carry == 0) return;
            sum = counter[6] + carry;
            carry = sum < counter[6] ? 1UL : 0UL;
            counter[6] = sum;
            if (carry == 0) return;
            counter[7] += carry;
        }
    }

    /// <summary>
    /// Add two 512-bit blocks as little-endian integers modulo 2^512.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void AddBlock512(ulong[] a, ReadOnlySpan<ulong> b)
    {
        unchecked
        {
            ulong sum = a[0] + b[0];
            ulong carry = sum < a[0] ? 1UL : 0UL;
            a[0] = sum;

            sum = a[1] + b[1] + carry;
            carry = (sum < a[1] || (carry == 1UL && sum == a[1])) ? 1UL : 0UL;
            a[1] = sum;
            sum = a[2] + b[2] + carry;
            carry = (sum < a[2] || (carry == 1UL && sum == a[2])) ? 1UL : 0UL;
            a[2] = sum;
            sum = a[3] + b[3] + carry;
            carry = (sum < a[3] || (carry == 1UL && sum == a[3])) ? 1UL : 0UL;
            a[3] = sum;
            sum = a[4] + b[4] + carry;
            carry = (sum < a[4] || (carry == 1UL && sum == a[4])) ? 1UL : 0UL;
            a[4] = sum;
            sum = a[5] + b[5] + carry;
            carry = (sum < a[5] || (carry == 1UL && sum == a[5])) ? 1UL : 0UL;
            a[5] = sum;
            sum = a[6] + b[6] + carry;
            carry = (sum < a[6] || (carry == 1UL && sum == a[6])) ? 1UL : 0UL;
            a[6] = sum;
            a[7] = a[7] + b[7] + carry;
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_h, 0, 8);
            Array.Clear(_n, 0, 8);
            Array.Clear(_sigma, 0, 8);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
