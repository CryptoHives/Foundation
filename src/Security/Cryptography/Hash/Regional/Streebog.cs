// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the Streebog (GOST R 34.11-2012) hash for the input data using a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// Streebog is the Russian national cryptographic hash standard.
/// It supports output sizes of 256 or 512 bits.
/// </para>
/// </remarks>
public sealed class Streebog : HashAlgorithm
{
    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    // S-box (Pi substitution)
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

    // Permutation Tau
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

    // Linear transformation matrix A (as ulong values for efficiency)
    private static readonly ulong[] A =
    [
        0x8e20faa72ba0b470UL, 0x47107ddd9b505a38UL, 0xad08b0e0c3282d1cUL, 0xd8045870ef14980eUL,
        0x6c022c38f90a4c07UL, 0x3601161cf205268dUL, 0x1b8e0b0e798c13c8UL, 0x83478b07b2468764UL,
        0xa011d380818e8f40UL, 0x5086e740ce47c920UL, 0x2843fd2067adea10UL, 0x14aff010bdd87508UL,
        0x0ad97808d06cb404UL, 0x05e23c0468365a02UL, 0x8c711e02341b2d01UL, 0x46b60f011a83988eUL,
        0x90dab52a387ae76fUL, 0x486dd4151c3dfdb9UL, 0x24b86a840e90f0d2UL, 0x125c354207f57b69UL,
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

    // Iteration constants C (12 rounds)
    private static readonly byte[][] C;

    private readonly int _hashSizeBytes;
    private readonly byte[] _hash;
    private readonly byte[] _n;
    private readonly byte[] _sigma;
    private readonly byte[] _buffer;
    private int _bufferLength;

    static Streebog()
    {
        unchecked
        {
            C = new byte[12][];
            for (int i = 0; i < 12; i++)
            {
                C[i] = new byte[64];
            }

            // Generate C values using LPS transform
            // In Streebog, iteration constants use little-endian: C[i] = LPS(i || 0...0)
            byte[] tmp = new byte[64];
            for (int i = 0; i < 12; i++)
            {
                Array.Clear(tmp, 0, 64);
                tmp[0] = (byte)i;  // Little-endian: LSB at index 0
                LPS(tmp, C[i]);
            }
        }
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
        if (hashSizeBytes != 32 && hashSizeBytes != 64)
        {
            throw new ArgumentException("Hash size must be 32 or 64 bytes.", nameof(hashSizeBytes));
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;
        _hash = new byte[64];
        _n = new byte[64];
        _sigma = new byte[64];
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
        // IV is 0x00...00 for 512-bit, 0x01...01 for 256-bit
        byte iv = _hashSizeBytes == 32 ? (byte)0x01 : (byte)0x00;
        for (int i = 0; i < 64; i++)
        {
            _hash[i] = iv;
        }

        Array.Clear(_n, 0, 64);
        Array.Clear(_sigma, 0, 64);
        ClearBuffer(_buffer);
        _bufferLength = 0;
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
                AddToN(512);
                AddToSigma(_buffer);
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            byte[] block = source.Slice(offset, BlockSizeBytes).ToArray();
            ProcessBlock(block);
            AddToN(512);
            AddToSigma(block);
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
        unchecked
        {
            if (destination.Length < _hashSizeBytes)
            {
                bytesWritten = 0;
                return false;
            }

            // Pad the final block
            byte[] padded = new byte[64];
            _buffer.AsSpan(0, _bufferLength).CopyTo(padded);
            padded[_bufferLength] = 0x01;

            // Stage 3: process padded message
            ProcessBlock(padded);
            AddToN(_bufferLength * 8);
            AddToSigma(padded);

            // Final compressions use g0 (with zero counter)
            byte[] zero = new byte[64];
            byte[] tmp = new byte[64];

            // h = g0(h, N)
            GN(_hash, zero, _n, tmp);
            Array.Copy(tmp, _hash, 64);

            // h = g0(h, Sigma)
            GN(_hash, zero, _sigma, tmp);
            Array.Copy(tmp, _hash, 64);

            // Output (possibly truncated)
            if (_hashSizeBytes == 32)
            {
                _hash.AsSpan(32, 32).CopyTo(destination);
            }
            else
            {
                _hash.AsSpan(0, 64).CopyTo(destination);
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
            ClearBuffer(_hash);
            ClearBuffer(_n);
            ClearBuffer(_sigma);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }

    private void ProcessBlock(byte[] block)
    {
        unchecked
        {
            byte[] tmp = new byte[64];
            GN(_hash, _n, block, tmp);
            Array.Copy(tmp, _hash, 64);
        }
    }

    private static void GN(byte[] h, byte[] n, byte[] m, byte[] result)
    {
        unchecked
        {
            byte[] k = new byte[64];
            byte[] tmp = new byte[64];

            // K = h XOR n
            for (int i = 0; i < 64; i++)
            {
                k[i] = (byte)(h[i] ^ n[i]);
            }

            // Apply E(K, m) 
            E(k, m, tmp);

            // result = h XOR tmp XOR m
            for (int i = 0; i < 64; i++)
            {
                result[i] = (byte)(h[i] ^ tmp[i] ^ m[i]);
            }
        }
    }

    private static void E(byte[] k, byte[] m, byte[] result)
    {
        unchecked
        {
            byte[] state = new byte[64];
            byte[] tmp = new byte[64];

            Array.Copy(m, state, 64);

            for (int r = 0; r < 12; r++)
            {
                // AddRoundKey
                for (int i = 0; i < 64; i++)
                {
                    state[i] ^= k[i];
                }

                // LPS
                LPS(state, tmp);
                Array.Copy(tmp, state, 64);

                // Key schedule: LPS(k XOR C[r])
                for (int i = 0; i < 64; i++)
                {
                    k[i] ^= C[r][i];
                }
                LPS(k, tmp);
                Array.Copy(tmp, k, 64);
            }

            // Final AddRoundKey
            for (int i = 0; i < 64; i++)
            {
                result[i] = (byte)(state[i] ^ k[i]);
            }
        }
    }

    private static void LPS(byte[] input, byte[] output)
    {
        byte[] tmp = new byte[64];

        // S (substitution)
        for (int i = 0; i < 64; i++)
        {
            tmp[i] = Pi[input[i]];
        }

        // P (permutation)
        byte[] perm = new byte[64];
        for (int i = 0; i < 64; i++)
        {
            perm[Tau[i]] = tmp[i];
        }

        // L (linear transformation)
        unchecked
        {
            for (int i = 0; i < 8; i++)
            {
                ulong v = 0;
                for (int j = 0; j < 8; j++)
                {
                    byte b = perm[i * 8 + j];
                    for (int k = 0; k < 8; k++)
                    {
                        if ((b & (1 << (7 - k))) != 0)
                        {
                            v ^= A[j * 8 + k];
                        }
                    }
                }

                for (int j = 0; j < 8; j++)
                {
                    output[i * 8 + j] = (byte)(v >> (56 - j * 8));
                }
            }
        }
    }

    private void AddToN(int bits)
    {
        unchecked
        {
            // Streebog uses little-endian byte order for N
            int carry = bits;
            for (int i = 0; i < 64 && carry > 0; i++)
            {
                int sum = _n[i] + (carry & 0xFF);
                _n[i] = (byte)sum;
                carry = (carry >> 8) + (sum >> 8);
            }
        }
    }

    private void AddToSigma(byte[] block)
    {
        unchecked
        {
            // Streebog uses little-endian byte order for Sigma
            int carry = 0;
            for (int i = 0; i < 64; i++)
            {
                int sum = _sigma[i] + block[i] + carry;
                _sigma[i] = (byte)sum;
                carry = sum >> 8;
            }
        }
    }
}
