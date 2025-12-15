// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the Streebog (GOST R 34.11-2012) hash for the input data using a clean-room implementation.
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

    // Iteration constants C for the 12 rounds - RFC 6986 Section 6.5
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

    private readonly int _hashSizeBytes;
    private readonly byte[] _h;      // Hash state (512-bit)
    private readonly byte[] _n;      // Bit counter (512-bit)
    private readonly byte[] _sigma;  // Checksum accumulator (512-bit)
    private readonly byte[] _buffer; // Message block buffer
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
        if (hashSizeBytes != 32 && hashSizeBytes != 64)
        {
            throw new ArgumentException("Hash size must be 32 or 64 bytes.", nameof(hashSizeBytes));
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;
        _h = new byte[64];
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
        // IV is 0x00 for 512-bit, 0x01 for 256-bit (RFC 6986 Section 6.1)
        byte iv = _hashSizeBytes == 32 ? (byte)0x01 : (byte)0x00;

        for (int i = 0; i < 64; i++)
        {
            _h[i] = iv;
            _n[i] = 0;
            _sigma[i] = 0;
        }

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
            byte[] block = source.Slice(offset, BlockSizeBytes).ToArray();
            ProcessBlock(block);
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
    private void ProcessBlock(byte[] m)
    {
        // g_N(h, m)
        GN(_h, _n, m);

        // N = (N + 512) mod 2^512
        AddModulus512(_n, 512);

        // Sigma = (Sigma + m) mod 2^512
        AddBlock512(_sigma, m);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad the final block: m || 1 || 0...0
        byte[] paddedBlock = new byte[64];
        _buffer.AsSpan(0, _bufferLength).CopyTo(paddedBlock);
        paddedBlock[_bufferLength] = 0x01;
        // Rest is already zeros

        // Stage 3: Process padded block
        GN(_h, _n, paddedBlock);

        // Update N with the bit count of the final partial block
        AddModulus512(_n, _bufferLength * 8);

        // Update Sigma with padded block
        AddBlock512(_sigma, paddedBlock);

        // Stage 4: Final compressions
        byte[] zero = new byte[64];
        GN(_h, zero, _n);
        GN(_h, zero, _sigma);

        // Output: full hash for 512-bit, upper 256 bits for 256-bit
        if (_hashSizeBytes == 32)
        {
            // For 256-bit, take the last 32 bytes (h[32..63])
            _h.AsSpan(32, 32).CopyTo(destination);
        }
        else
        {
            _h.AsSpan(0, 64).CopyTo(destination);
        }

        bytesWritten = _hashSizeBytes;
        return true;
    }

    /// <summary>
    /// The g_N compression function: h = h ^ E(h ^ N, m) ^ m
    /// Uses Miyaguchi-Preneel construction.
    /// </summary>
    private static void GN(byte[] h, byte[] n, byte[] m)
    {
        byte[] k = new byte[64];
        byte[] t = new byte[64];

        // k = h ^ N
        Xor512(h, n, k);

        // k = LPS(k)
        ApplyLPS(k);

        // t = E(k, m)
        E(k, m, t);

        // h = h ^ t ^ m
        Xor512(h, t, h);
        Xor512(h, m, h);
    }

    /// <summary>
    /// The E function: 12-round block cipher with key schedule.
    /// </summary>
    private static void E(byte[] k, byte[] m, byte[] result)
    {
        byte[] state = new byte[64];
        byte[] key = new byte[64];

        Array.Copy(m, state, 64);
        Array.Copy(k, key, 64);

        for (int round = 0; round < Rounds; round++)
        {
            // AddRoundKey: state = state ^ key
            Xor512(state, key, state);

            // LPS transform on state
            ApplyLPS(state);

            // Key schedule: key = LPS(key ^ C[round])
            Xor512(key, C[round], key);
            ApplyLPS(key);
        }

        // Final AddRoundKey
        Xor512(state, key, result);
    }

    /// <summary>
    /// Combined LPS transformation: L(P(S(data)))
    /// S = Substitution using Pi S-box
    /// P = Permutation using Tau
    /// L = Linear transformation using matrix A
    /// </summary>
    internal static void ApplyLPS(byte[] data)
    {
        unchecked
        {
            // S-box substitution
            byte[] substituted = new byte[64];
            for (int i = 0; i < 64; i++)
            {
                substituted[i] = Pi[data[i]];
            }

            // P permutation (transpose)
            byte[] permuted = new byte[64];
            for (int i = 0; i < 64; i++)
            {
                permuted[i] = substituted[Tau[i]];
            }

            // L linear transformation
            // Process state as 8 x 64-bit words
            for (int i = 0; i < 8; i++)
            {
                ulong v = 0;

                // Process 8 bytes per row in reverse order
                for (int j = 0; j < 8; j++)
                {
                    byte b = permuted[i * 8 + (7 - j)];

                    // For each bit in the byte (LSB first), use reversed bit index in A
                    for (int k = 0; k < 8; k++)
                    {
                        if ((b & (1 << k)) != 0)
                        {
                            v ^= A[j * 8 + (7 - k)];
                        }
                    }
                }

                // Store result in little-endian byte order
                data[i * 8 + 0] = (byte)(v);
                data[i * 8 + 1] = (byte)(v >> 8);
                data[i * 8 + 2] = (byte)(v >> 16);
                data[i * 8 + 3] = (byte)(v >> 24);
                data[i * 8 + 4] = (byte)(v >> 32);
                data[i * 8 + 5] = (byte)(v >> 40);
                data[i * 8 + 6] = (byte)(v >> 48);
                data[i * 8 + 7] = (byte)(v >> 56);
            }
        }
    }

    /// <summary>
    /// XOR two 512-bit (64-byte) values.
    /// </summary>
    private static void Xor512(byte[] a, byte[] b, byte[] result)
    {
        for (int i = 0; i < 64; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }
    }

    /// <summary>
    /// Add a number of bits to the 512-bit counter (little-endian arithmetic).
    /// </summary>
    private static void AddModulus512(byte[] counter, int bits)
    {
        unchecked
        {
            int carry = bits;
            for (int i = 0; i < 64 && carry > 0; i++)
            {
                int sum = counter[i] + (carry & 0xFF);
                counter[i] = (byte)sum;
                carry = (carry >> 8) + (sum >> 8);
            }
        }
    }

    /// <summary>
    /// Add two 512-bit blocks as little-endian integers modulo 2^512.
    /// </summary>
    private static void AddBlock512(byte[] a, byte[] b)
    {
        unchecked
        {
            int carry = 0;
            for (int i = 0; i < 64; i++)
            {
                int sum = a[i] + b[i] + carry;
                a[i] = (byte)sum;
                carry = sum >> 8;
            }
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_h);
            ClearBuffer(_n);
            ClearBuffer(_sigma);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
