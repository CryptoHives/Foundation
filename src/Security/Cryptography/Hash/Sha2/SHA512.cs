// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - K and IV are standard cryptographic constant names per FIPS 180-4

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Computes the SHA-512 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-512 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// On .NET 8+, this implementation uses optimized BitOperations for improved
/// performance. Otherwise, a portable software implementation is used.
/// </para>
/// <para>
/// SHA-512 produces a 512-bit (64-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA512 : HashAlgorithm
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
    public const int BlockSizeBytes = 128;

    // SHA-512 round constants
    private static readonly ulong[] K =
    [
        0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc,
        0x3956c25bf348b538, 0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118,
        0xd807aa98a3030242, 0x12835b0145706fbe, 0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2,
        0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235, 0xc19bf174cf692694,
        0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
        0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5,
        0x983e5152ee66dfab, 0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4,
        0xc6e00bf33da88fc2, 0xd5a79147930aa725, 0x06ca6351e003826f, 0x142929670a0e6e70,
        0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed, 0x53380d139d95b3df,
        0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
        0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30,
        0xd192e819d6ef5218, 0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8,
        0x19a4c116b8d2d0c8, 0x1e376c085141ab53, 0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8,
        0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373, 0x682e6ff3d6b2b8a3,
        0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
        0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b,
        0xca273eceea26619c, 0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178,
        0x06f067aa72176fba, 0x0a637dc5a2c898a6, 0x113f9804bef90dae, 0x1b710b35131c471b,
        0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc, 0x431d67c49c100d4c,
        0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
    ];

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets a value indicating whether hardware-accelerated SHA-512 is available.
    /// </summary>
    /// <remarks>
    /// Unlike SHA-256, there are no dedicated SHA-512 CPU instructions.
    /// This property indicates whether AVX2 optimizations are available for
    /// improved message schedule computation.
    /// </remarks>
    public static bool IsAccelerated => Avx2.IsSupported;
#endif

    private readonly byte[] _buffer;
    private readonly ulong[] _state;
    private readonly ulong[] _w;
    private readonly SimdSupport _simdSupport;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    public SHA512() : this(SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal SHA512(SimdSupport simdSupport)
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new ulong[8];
        _w = new ulong[80];
        _simdSupport = simdSupport;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
#endif
            return support;
        }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512"/> class.
    /// </summary>
    /// <returns>A new SHA-512 hash algorithm instance.</returns>
    public static new SHA512 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA-512 hash algorithm instance.</returns>
    internal static SHA512 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <inheritdoc/>
    public override void Initialize()
    {
        // Initialize state with SHA-512 constants
        _state[0] = 0x6a09e667f3bcc908;
        _state[1] = 0xbb67ae8584caa73b;
        _state[2] = 0x3c6ef372fe94f82b;
        _state[3] = 0xa54ff53a5f1d36f1;
        _state[4] = 0x510e527fade682d1;
        _state[5] = 0x9b05688c2b3e6c1f;
        _state[6] = 0x1f83d9abfb41bd6b;
        _state[7] = 0x5be0cd19137e2179;

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

        // Convert state to bytes (big-endian)
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * 8), _state[i]);
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
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Avx2) != 0 && Avx2.IsSupported)
        {
            ProcessBlockAvx2(block);
            return;
        }
#endif
        ProcessBlockScalar(block);
    }

    private void ProcessBlockScalar(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            // Prepare message schedule - load first 16 words from block
            for (int i = 0; i < 16; i++)
            {
                _w[i] = BinaryPrimitives.ReadUInt64BigEndian(block.Slice(i * 8));
            }

            // Extend message schedule W[16..79]
            for (int i = 16; i < 80; i++)
            {
                ulong w15 = _w[i - 15];
                ulong w2 = _w[i - 2];

                // σ0(x) = ROTR^1(x) XOR ROTR^8(x) XOR SHR^7(x)
                ulong s0 = RotateRight(w15, 1) ^ RotateRight(w15, 8) ^ (w15 >> 7);

                // σ1(x) = ROTR^19(x) XOR ROTR^61(x) XOR SHR^6(x)
                ulong s1 = RotateRight(w2, 19) ^ RotateRight(w2, 61) ^ (w2 >> 6);

                _w[i] = _w[i - 16] + s0 + _w[i - 7] + s1;
            }

            // Initialize working variables
            ulong a = _state[0];
            ulong b = _state[1];
            ulong c = _state[2];
            ulong d = _state[3];
            ulong e = _state[4];
            ulong f = _state[5];
            ulong g = _state[6];
            ulong h = _state[7];

#if NET8_0_OR_GREATER
            // Unrolled compression rounds for better instruction-level parallelism
            for (int i = 0; i < 80; i += 8)
            {
                Round(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h, K[i + 0], _w[i + 0]);
                Round(ref h, ref a, ref b, ref c, ref d, ref e, ref f, ref g, K[i + 1], _w[i + 1]);
                Round(ref g, ref h, ref a, ref b, ref c, ref d, ref e, ref f, K[i + 2], _w[i + 2]);
                Round(ref f, ref g, ref h, ref a, ref b, ref c, ref d, ref e, K[i + 3], _w[i + 3]);
                Round(ref e, ref f, ref g, ref h, ref a, ref b, ref c, ref d, K[i + 4], _w[i + 4]);
                Round(ref d, ref e, ref f, ref g, ref h, ref a, ref b, ref c, K[i + 5], _w[i + 5]);
                Round(ref c, ref d, ref e, ref f, ref g, ref h, ref a, ref b, K[i + 6], _w[i + 6]);
                Round(ref b, ref c, ref d, ref e, ref f, ref g, ref h, ref a, K[i + 7], _w[i + 7]);
            }
#else
            // Standard compression loop
            for (int i = 0; i < 80; i++)
            {
                ulong S1 = RotateRight(e, 14) ^ RotateRight(e, 18) ^ RotateRight(e, 41);
                ulong ch = (e & f) ^ (~e & g);
                ulong temp1 = h + S1 + ch + K[i] + _w[i];
                ulong S0 = RotateRight(a, 28) ^ RotateRight(a, 34) ^ RotateRight(a, 39);
                ulong maj = (a & b) ^ (a & c) ^ (b & c);
                ulong temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
            }
#endif

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

#if NET8_0_OR_GREATER
    /// <summary>
    /// Process a single 128-byte block using AVX2 optimizations.
    /// </summary>
    /// <remarks>
    /// This implementation uses AVX2 for loading message words and
    /// BitOperations.RotateRight for efficient rotation (JIT compiles to RORX).
    /// The compression function uses 8-way unrolling for better ILP.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlockAvx2(ReadOnlySpan<byte> block)
    {
        unchecked
        {
            // Load and byte-swap the first 16 message words using AVX2
            // AVX2 can process 4 x 64-bit values at once
            for (int i = 0; i < 16; i += 4)
            {
                Vector256<ulong> data = Vector256.Create(
                    BinaryPrimitives.ReadUInt64BigEndian(block.Slice(i * 8)),
                    BinaryPrimitives.ReadUInt64BigEndian(block.Slice((i + 1) * 8)),
                    BinaryPrimitives.ReadUInt64BigEndian(block.Slice((i + 2) * 8)),
                    BinaryPrimitives.ReadUInt64BigEndian(block.Slice((i + 3) * 8))
                );

                _w[i] = data.GetElement(0);
                _w[i + 1] = data.GetElement(1);
                _w[i + 2] = data.GetElement(2);
                _w[i + 3] = data.GetElement(3);
            }

            // Compute message schedule W[16..79]
            for (int i = 16; i < 80; i++)
            {
                ulong w15 = _w[i - 15];
                ulong w2 = _w[i - 2];

                ulong s0 = BitOperations.RotateRight(w15, 1) ^
                           BitOperations.RotateRight(w15, 8) ^
                           (w15 >> 7);
                ulong s1 = BitOperations.RotateRight(w2, 19) ^
                           BitOperations.RotateRight(w2, 61) ^
                           (w2 >> 6);

                _w[i] = _w[i - 16] + s0 + _w[i - 7] + s1;
            }

            // Compression function with 8-way unrolling
            ulong a = _state[0];
            ulong b = _state[1];
            ulong c = _state[2];
            ulong d = _state[3];
            ulong e = _state[4];
            ulong f = _state[5];
            ulong g = _state[6];
            ulong h = _state[7];

            for (int i = 0; i < 80; i += 8)
            {
                RoundAvx2(ref a, ref b, ref c, ref d, ref e, ref f, ref g, ref h, K[i + 0], _w[i + 0]);
                RoundAvx2(ref h, ref a, ref b, ref c, ref d, ref e, ref f, ref g, K[i + 1], _w[i + 1]);
                RoundAvx2(ref g, ref h, ref a, ref b, ref c, ref d, ref e, ref f, K[i + 2], _w[i + 2]);
                RoundAvx2(ref f, ref g, ref h, ref a, ref b, ref c, ref d, ref e, K[i + 3], _w[i + 3]);
                RoundAvx2(ref e, ref f, ref g, ref h, ref a, ref b, ref c, ref d, K[i + 4], _w[i + 4]);
                RoundAvx2(ref d, ref e, ref f, ref g, ref h, ref a, ref b, ref c, K[i + 5], _w[i + 5]);
                RoundAvx2(ref c, ref d, ref e, ref f, ref g, ref h, ref a, ref b, K[i + 6], _w[i + 6]);
                RoundAvx2(ref b, ref c, ref d, ref e, ref f, ref g, ref h, ref a, K[i + 7], _w[i + 7]);
            }

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RoundAvx2(ref ulong a, ref ulong b, ref ulong c, ref ulong d,
                                   ref ulong e, ref ulong f, ref ulong g, ref ulong h,
                                   ulong k, ulong w)
    {
        unchecked
        {
            ulong S1 = BitOperations.RotateRight(e, 14) ^
                       BitOperations.RotateRight(e, 18) ^
                       BitOperations.RotateRight(e, 41);
            ulong ch = (e & f) ^ (~e & g);
            ulong temp1 = h + S1 + ch + k + w;

            ulong S0 = BitOperations.RotateRight(a, 28) ^
                       BitOperations.RotateRight(a, 34) ^
                       BitOperations.RotateRight(a, 39);
            ulong maj = (a & b) ^ (a & c) ^ (b & c);
            ulong temp2 = S0 + maj;

            d += temp1;
            h = temp1 + temp2;
        }
    }
#endif

#if NET8_0_OR_GREATER
    /// <summary>
    /// Performs a single SHA-512 round with optimized rotation.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Round(ref ulong a, ref ulong b, ref ulong c, ref ulong d,
                              ref ulong e, ref ulong f, ref ulong g, ref ulong h,
                              ulong k, ulong w)
    {
        unchecked
        {
            // Σ1(e) = ROTR^14(e) XOR ROTR^18(e) XOR ROTR^41(e)
            ulong S1 = BitOperations.RotateRight(e, 14) ^
                       BitOperations.RotateRight(e, 18) ^
                       BitOperations.RotateRight(e, 41);

            // Ch(e,f,g) = (e AND f) XOR (NOT e AND g)
            ulong ch = (e & f) ^ (~e & g);

            ulong temp1 = h + S1 + ch + k + w;

            // Σ0(a) = ROTR^28(a) XOR ROTR^34(a) XOR ROTR^39(a)
            ulong S0 = BitOperations.RotateRight(a, 28) ^
                       BitOperations.RotateRight(a, 34) ^
                       BitOperations.RotateRight(a, 39);

            // Maj(a,b,c) = (a AND b) XOR (a AND c) XOR (b AND c)
            ulong maj = (a & b) ^ (a & c) ^ (b & c);

            ulong temp2 = S0 + maj;

            d += temp1;
            h = temp1 + temp2;
        }
    }

#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateRight(ulong x, int n) => BitOperations.RotateRight(x, n);

    private void PadAndFinalize()
    {
        unchecked
        {
            // For SHA-512, length is 128 bits (16 bytes), but we only support up to 64-bit length
            long totalBits = (_bytesProcessed + _bufferLength) * 8;

            _buffer[_bufferLength++] = 0x80;

            // Pad to 112 bytes (896 bits) mod 128
            if (_bufferLength > 112)
            {
                while (_bufferLength < BlockSizeBytes)
                {
                    _buffer[_bufferLength++] = 0x00;
                }
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            while (_bufferLength < 112)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            // Append length in bits (big-endian, 128-bit)
            // High 64 bits are zero for our implementation
            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(112), 0L);
            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(120), totalBits);

            ProcessBlock(_buffer);
        }
    }
}
