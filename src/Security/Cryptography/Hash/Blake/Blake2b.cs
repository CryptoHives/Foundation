// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Computes the BLAKE2b hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE2b that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE2b is optimized for 64-bit platforms and produces digests from 1 to 64 bytes.
/// The default output size is 64 bytes (512 bits).
/// </para>
/// <para>
/// BLAKE2b supports an optional key for keyed hashing (MAC mode) with keys up to 64 bytes.
/// </para>
/// </remarks>
public sealed class Blake2b : HashAlgorithm
{
    /// <summary>
    /// The maximum hash size in bits.
    /// </summary>
    public const int MaxHashSizeBits = 512;

    /// <summary>
    /// The maximum hash size in bytes.
    /// </summary>
    public const int MaxHashSizeBytes = MaxHashSizeBits / 8;

    /// <summary>
    /// The maximum key size in bytes.
    /// </summary>
    public const int MaxKeySizeBytes = 64;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 128;

    // Rounds of mixing
    private const int Rounds = 12;

    // The size of the state buffer
    private const int StateSize = 8;

    // The size of the scratch buffers
    private const int ScratchSize = 16;

    // BLAKE2b IV constants (same as SHA-512)
    private static readonly ulong[] IV =
    [
        0x6a09e667f3bcc908UL,
        0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL,
        0xa54ff53a5f1d36f1UL,
        0x510e527fade682d1UL,
        0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL,
        0x5be0cd19137e2179UL
    ];

    // BLAKE2b sigma permutations for message scheduling
    private static readonly byte[] Sigma = new byte[Rounds * ScratchSize]
    {
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3,
        11, 8, 12, 0, 5, 2, 15, 13, 10, 14, 3, 6, 7, 1, 9, 4,
        7, 9, 3, 1, 13, 12, 11, 14, 2, 6, 5, 10, 4, 0, 15, 8,
        9, 0, 5, 7, 2, 4, 10, 15, 14, 1, 11, 12, 6, 8, 3, 13,
        2, 12, 6, 10, 0, 11, 8, 3, 4, 13, 7, 5, 15, 14, 1, 9,
        12, 5, 1, 15, 14, 13, 4, 10, 0, 7, 6, 3, 9, 2, 8, 11,
        13, 11, 7, 14, 12, 1, 3, 9, 5, 0, 15, 4, 8, 6, 2, 10,
        6, 15, 14, 9, 11, 3, 0, 8, 12, 2, 13, 7, 1, 4, 10, 5,
        10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0,
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3
    };

#if NET8_0_OR_GREATER
    // Pre-computed shuffle masks for byte-aligned rotations (static to avoid recreation)
    private static readonly Vector256<byte> RotateMask32 = Vector256.Create(
        (byte)4, 5, 6, 7, 0, 1, 2, 3,
        12, 13, 14, 15, 8, 9, 10, 11,
        20, 21, 22, 23, 16, 17, 18, 19,
        28, 29, 30, 31, 24, 25, 26, 27);

    private static readonly Vector256<byte> RotateMask24 = Vector256.Create(
        (byte)3, 4, 5, 6, 7, 0, 1, 2,
        11, 12, 13, 14, 15, 8, 9, 10,
        19, 20, 21, 22, 23, 16, 17, 18,
        27, 28, 29, 30, 31, 24, 25, 26);

    private static readonly Vector256<byte> RotateMask16 = Vector256.Create(
        (byte)2, 3, 4, 5, 6, 7, 0, 1,
        10, 11, 12, 13, 14, 15, 8, 9,
        18, 19, 20, 21, 22, 23, 16, 17,
        26, 27, 28, 29, 30, 31, 24, 25);

    // Pre-computed IV vectors for AVX2 path
    private static readonly Vector256<ulong> IVLow = Vector256.Create(
        0x6a09e667f3bcc908UL, 0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL, 0xa54ff53a5f1d36f1UL);

    private static readonly Vector256<ulong> IVHigh = Vector256.Create(
        0x510e527fade682d1UL, 0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL, 0x5be0cd19137e2179UL);

    // Finalization mask for inverting element 2 of row3
    private static readonly Vector256<ulong> FinalMask = Vector256.Create(0UL, 0UL, ~0UL, 0UL);

    // Pre-computed Vector128<int> indices for gather operations (scaled by 8 for ulong stride)
    private static readonly Vector128<int>[] GatherIndicesX = new Vector128<int>[Rounds * 2];
    private static readonly Vector128<int>[] GatherIndicesY = new Vector128<int>[Rounds * 2];

    // Vector state for AVX2 path
    private Vector256<ulong> _stateVec0;
    private Vector256<ulong> _stateVec1;
    private readonly bool _useAvx2;

    static Blake2b()
    {
        for (int round = 0; round < Rounds; round++)
        {
            int offset = round * ScratchSize;

            // Column step indices (multiply by 8 for byte offset of ulong)
            GatherIndicesX[round * 2] = Vector128.Create(
                Sigma[offset + 0] * 8, Sigma[offset + 2] * 8,
                Sigma[offset + 4] * 8, Sigma[offset + 6] * 8);
            GatherIndicesY[round * 2] = Vector128.Create(
                Sigma[offset + 1] * 8, Sigma[offset + 3] * 8,
                Sigma[offset + 5] * 8, Sigma[offset + 7] * 8);

            // Diagonal step indices
            GatherIndicesX[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 8] * 8, Sigma[offset + 10] * 8,
                Sigma[offset + 12] * 8, Sigma[offset + 14] * 8);
            GatherIndicesY[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 9] * 8, Sigma[offset + 11] * 8,
                Sigma[offset + 13] * 8, Sigma[offset + 15] * 8);
        }
    }
#endif

    // Scalar state for non-AVX2 path and output extraction
    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private readonly byte[]? _key;
    private readonly int _outputBytes;
    private ulong _bytesCompressed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with default output size (64 bytes).
    /// </summary>
    public Blake2b() : this(MaxHashSizeBytes, null, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    public Blake2b(int outputBytes) : this(outputBytes, null, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-64 bytes.</param>
    public Blake2b(int outputBytes, byte[]? key) : this(outputBytes, key, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size, key, and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-64 bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake2b(int outputBytes, byte[]? key, SimdSupport simdSupport)
    {
        if (outputBytes < 1 || outputBytes > MaxHashSizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes),
                $"Output size must be between 1 and {MaxHashSizeBytes} bytes.");
        }

        if (key != null && key.Length > MaxKeySizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(key),
                $"Key size must be between 0 and {MaxKeySizeBytes} bytes.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _state = new ulong[StateSize];
        _buffer = new byte[BlockSizeBytes];

#if NET8_0_OR_GREATER
        _useAvx2 = (simdSupport & SimdSupport.Avx2) != 0 && Avx2.IsSupported;
#endif

        if (key != null && key.Length > 0)
        {
            _key = new byte[key.Length];
            Array.Copy(key, _key, key.Length);
        }

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key != null ? "BLAKE2b-MAC" : "BLAKE2b";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a value indicating whether this instance is configured for keyed hashing (MAC mode).
    /// </summary>
    public bool IsKeyed => _key != null;

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    /// <returns>Flags indicating which SIMD instruction sets are available.</returns>
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
    /// Creates a new instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE2b instance.</returns>
    public static new Blake2b Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    public static Blake2b Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2b instance.</returns>
    internal static Blake2b Create(int outputBytes, SimdSupport simdSupport) => new(outputBytes, null, simdSupport);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(int outputBytes, byte[] key) => new(outputBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(byte[] key) => new(MaxHashSizeBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with specified SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    internal static Blake2b CreateKeyed(int outputBytes, byte[] key, SimdSupport simdSupport) => new(outputBytes, key, simdSupport);

    /// <inheritdoc/>
    public override void Initialize()
    {
        int keyLength = _key?.Length ?? 0;
        ulong paramBlock = 0x01010000UL | ((ulong)keyLength << 8) | (uint)_outputBytes;

#if NET8_0_OR_GREATER
        if (_useAvx2)
        {
            // Initialize vector state: IV with parameter XOR on first word
            _stateVec0 = Avx2.Xor(IVLow, Vector256.Create(paramBlock, 0UL, 0UL, 0UL));
            _stateVec1 = IVHigh;
        }
        else
#endif
        {
            // Scalar initialization
            Array.Copy(IV, _state, StateSize);
            _state[0] ^= paramBlock;
        }

        _bytesCompressed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);

        // If keyed, the first block is the zero-padded key
        if (_key != null && _key.Length > 0)
        {
            Array.Copy(_key, _buffer, _key.Length);
            _bufferLength = BlockSizeBytes;
        }
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have data in buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            // Only compress if buffer is full AND there's more data coming
            // (we need to keep the last block for finalization)
            if (_bufferLength == BlockSizeBytes && offset < source.Length)
            {
                Compress(_buffer, false);
                _bufferLength = 0;
            }
        }

        // Process full blocks, but always keep at least one block for finalization
        while (offset + BlockSizeBytes < source.Length)
        {
            Compress(source.Slice(offset, BlockSizeBytes), false);
            offset += BlockSizeBytes;
        }

        // Store remaining bytes in buffer
        if (offset < source.Length)
        {
            int remaining = source.Length - offset;
            if (_bufferLength == 0)
            {
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan());
                _bufferLength = remaining;
            }
            else
            {
                // Buffer already has data, append to it
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += remaining;
            }
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Zero-pad the remaining buffer
        _buffer.AsSpan(_bufferLength).Clear();

        // Compress final block
        Compress(_buffer, true);

#if NET8_0_OR_GREATER
        if (_useAvx2)
        {
            // Extract from vector state
            ExtractOutputAvx2(destination);
            bytesWritten = _outputBytes;
            return true;
        }
#endif

        // Scalar output extraction
        int fullWords = _outputBytes / 8;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * 8), _state[i]);
        }

        // Handle partial final word
        int remainingBytes = _outputBytes % 8;
        if (remainingBytes > 0)
        {
            Span<byte> temp = stackalloc byte[8];
            BinaryPrimitives.WriteUInt64LittleEndian(temp, _state[fullWords]);
            temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * 8));
        }

        bytesWritten = _outputBytes;
        return true;
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ExtractOutputAvx2(Span<byte> destination)
    {
        // Store vectors to stack, then copy required bytes
        Span<ulong> temp = stackalloc ulong[8];
        Unsafe.WriteUnaligned(ref Unsafe.As<ulong, byte>(ref temp[0]), _stateVec0);
        Unsafe.WriteUnaligned(ref Unsafe.As<ulong, byte>(ref temp[4]), _stateVec1);

        int fullWords = _outputBytes / 8;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * 8), temp[i]);
        }

        int remainingBytes = _outputBytes % 8;
        if (remainingBytes > 0)
        {
            Span<byte> tempBytes = stackalloc byte[8];
            BinaryPrimitives.WriteUInt64LittleEndian(tempBytes, temp[fullWords]);
            tempBytes.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * 8));
        }
    }
#endif

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
#if NET8_0_OR_GREATER
            if (_useAvx2)
            {
                _stateVec0 = default;
                _stateVec1 = default;
            }
#endif
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
            if (_key != null)
            {
                ClearBuffer(_key);
            }
        }
        base.Dispose(disposing);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void Compress(ReadOnlySpan<byte> block, bool isFinal)
    {
#if NET8_0_OR_GREATER
        if (_useAvx2)
        {
            CompressAvx2(block, isFinal);
            return;
        }
#endif

        // Update counter
        _bytesCompressed += (ulong)_bufferLength;

        // Use stackalloc for working vectors to avoid heap allocations
        Span<ulong> v = stackalloc ulong[ScratchSize];
        Span<ulong> m = stackalloc ulong[ScratchSize];

        // Parse message block into 16 64-bit words (little-endian)
        // On little-endian platforms, directly reinterpret the byte span as ulong.
        // This avoids 16 individual BinaryPrimitives.ReadUInt64LittleEndian calls.
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, ulong>(block).CopyTo(m);
        }
        else
        {
            for (int i = 0; i < ScratchSize; i++)
            {
                m[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * 8));
            }
        }

        // Initialize working vector
        _state.CopyTo(v.Slice(0, StateSize));
        IV.CopyTo(v.Slice(StateSize, StateSize));

        v[12] ^= _bytesCompressed;                  // XOR with low 64 bits of counter
                                                    // v[13] = IV[5];                           // XOR with high 64 bits (always 0 for us)
        v[14] = isFinal ? ~IV[6] : IV[6];           // Invert if final block

        // 12 rounds of mixing
        for (int round = 0; round < Rounds * ScratchSize; round += ScratchSize)
        {
            // Column step
            G(ref v[0], ref v[4], ref v[8], ref v[12], m[Sigma[round + 0]], m[Sigma[round + 1]]);
            G(ref v[1], ref v[5], ref v[9], ref v[13], m[Sigma[round + 2]], m[Sigma[round + 3]]);
            G(ref v[2], ref v[6], ref v[10], ref v[14], m[Sigma[round + 4]], m[Sigma[round + 5]]);
            G(ref v[3], ref v[7], ref v[11], ref v[15], m[Sigma[round + 6]], m[Sigma[round + 7]]);

            // Diagonal step
            G(ref v[0], ref v[5], ref v[10], ref v[15], m[Sigma[round + 8]], m[Sigma[round + 9]]);
            G(ref v[1], ref v[6], ref v[11], ref v[12], m[Sigma[round + 10]], m[Sigma[round + 11]]);
            G(ref v[2], ref v[7], ref v[8], ref v[13], m[Sigma[round + 12]], m[Sigma[round + 13]]);
            G(ref v[3], ref v[4], ref v[9], ref v[14], m[Sigma[round + 14]], m[Sigma[round + 15]]);
        }

        // Finalize state
        _state[0] ^= v[0] ^ v[8];
        _state[1] ^= v[1] ^ v[9];
        _state[2] ^= v[2] ^ v[10];
        _state[3] ^= v[3] ^ v[11];
        _state[4] ^= v[4] ^ v[12];
        _state[5] ^= v[5] ^ v[13];
        _state[6] ^= v[6] ^ v[14];
        _state[7] ^= v[7] ^ v[15];
    }

    /// <summary>
    /// BLAKE2b mixing function G.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void G(ref ulong a, ref ulong b, ref ulong c, ref ulong d, ulong x, ulong y)
    {
        unchecked
        {
            a = a + b + x;
            d = BitOperations.RotateRight(d ^ a, 32);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 24);
            a = a + b + y;
            d = BitOperations.RotateRight(d ^ a, 16);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 63);
        }
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressAvx2(ReadOnlySpan<byte> block, bool isFinal)
    {
        _bytesCompressed += (ulong)_bufferLength;

        // Pin the message block for gather operations
        fixed (byte* mPtr = block)
        {
            // Initialize rows from vector state
            var row0 = _stateVec0;
            var row1 = _stateVec1;
            var row2 = IVLow;

            // row3 = IVHigh with counter/finalization applied
            var counterVec = Vector256.Create(_bytesCompressed, 0UL, 0UL, 0UL);
            var row3 = Avx2.Xor(IVHigh, counterVec);

            if (isFinal)
            {
                // Invert element 2 (the finalization flag)
                row3 = Avx2.Xor(row3, FinalMask);
            }

            // 12 rounds
            for (int round = 0; round < Rounds; round++)
            {
                int gatherIdx = round * 2;

                // Column step - use gather for message words
                var mx0 = Avx2.GatherVector256((long*)mPtr, GatherIndicesX[gatherIdx], 1).AsUInt64();
                var my0 = Avx2.GatherVector256((long*)mPtr, GatherIndicesY[gatherIdx], 1).AsUInt64();

                GRound(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal permutations
                row1 = Avx2.Permute4x64(row1, 0b00_11_10_01);
                row2 = Avx2.Permute4x64(row2, 0b01_00_11_10);
                row3 = Avx2.Permute4x64(row3, 0b10_01_00_11);

                // Diagonal step
                var mx1 = Avx2.GatherVector256((long*)mPtr, GatherIndicesX[gatherIdx + 1], 1).AsUInt64();
                var my1 = Avx2.GatherVector256((long*)mPtr, GatherIndicesY[gatherIdx + 1], 1).AsUInt64();

                GRound(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate
                row1 = Avx2.Permute4x64(row1, 0b10_01_00_11);
                row2 = Avx2.Permute4x64(row2, 0b01_00_11_10);
                row3 = Avx2.Permute4x64(row3, 0b00_11_10_01);
            }

            // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
            _stateVec0 = Avx2.Xor(_stateVec0, Avx2.Xor(row0, row2));
            _stateVec1 = Avx2.Xor(_stateVec1, Avx2.Xor(row1, row3));
        }
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using AVX2.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GRound(
        ref Vector256<ulong> a,
        ref Vector256<ulong> b,
        ref Vector256<ulong> c,
        ref Vector256<ulong> d,
        Vector256<ulong> x,
        Vector256<ulong> y)
    {
        // a = a + b + x
        a = Avx2.Add(a, Avx2.Add(b, x));
        // d = ror(d ^ a, 32)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), RotateMask32).AsUInt64();
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 24)
        b = Avx2.Shuffle(Avx2.Xor(b, c).AsByte(), RotateMask24).AsUInt64();
        // a = a + b + y
        a = Avx2.Add(a, Avx2.Add(b, y));
        // d = ror(d ^ a, 16)
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), RotateMask16).AsUInt64();
        // c = c + d
        c = Avx2.Add(c, d);
        // b = ror(b ^ c, 63) - must use shift+or
        var t = Avx2.Xor(b, c);
        b = Avx2.Or(Avx2.ShiftRightLogical(t, 63), Avx2.ShiftLeftLogical(t, 1));
    }
#endif
}
