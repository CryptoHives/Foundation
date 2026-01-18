// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Computes the BLAKE2s hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// BLAKE2s is optimized for 32-bit platforms and produces digests from 1 to 32 bytes.
/// The default output size is 32 bytes (256 bits).
/// </para>
/// <para>
/// BLAKE2s supports an optional key for keyed hashing (MAC mode) with keys up to 32 bytes.
/// </para>
/// </remarks>
public sealed class Blake2s : HashAlgorithm
{
    /// <summary>
    /// The maximum hash size in bits.
    /// </summary>
    public const int MaxHashSizeBits = 256;

    /// <summary>
    /// The maximum hash size in bytes.
    /// </summary>
    public const int MaxHashSizeBytes = MaxHashSizeBits / 8;

    /// <summary>
    /// The maximum key size in bytes.
    /// </summary>
    public const int MaxKeySizeBytes = 32;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    // Rounds of mixing
    private const int Rounds = 10;

    // The size of the state buffer
    private const int StateSize = 8;

    // The size of the scratch buffers
    private const int ScratchSize = 16;

    // BLAKE2s IV constants (same as SHA-256)
    private static readonly uint[] IV =
    [
        0x6a09e667U,
        0xbb67ae85U,
        0x3c6ef372U,
        0xa54ff53aU,
        0x510e527fU,
        0x9b05688cU,
        0x1f83d9abU,
        0x5be0cd19U
    ];

    // BLAKE2s sigma permutations (10 rounds)
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
        10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0
    };

#if NET8_0_OR_GREATER
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // BLAKE2s rotations: 16, 12, 8, 7 bits

    // Rotate right by 16 bits (swap high/low 16-bit halves within each 32-bit word)
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vectors for SSE/AVX path (Vector128<uint> holds 4 elements = 1 row)
    private static readonly Vector128<uint> IVLow = Vector128.Create(
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU);

    private static readonly Vector128<uint> IVHigh = Vector128.Create(
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U);

    // Finalization mask for inverting element 2 of row3 (v[14])
    private static readonly Vector128<uint> FinalMask = Vector128.Create(0U, 0U, ~0U, 0U);

    // Pre-computed Vector128<int> indices for gather operations (scaled by 4 for uint stride)
    private static readonly Vector128<int>[] GatherIndicesX = new Vector128<int>[Rounds * 2];
    private static readonly Vector128<int>[] GatherIndicesY = new Vector128<int>[Rounds * 2];

    // Vector state for SSE path (2 x Vector128<uint> = 8 elements = full state)
    private Vector128<uint> _stateVec0;
    private Vector128<uint> _stateVec1;
    private readonly bool _useSse2;
    private readonly bool _useAvx2;

    static Blake2s()
    {
        for (int round = 0; round < Rounds; round++)
        {
            int offset = round * ScratchSize;

            // Column step indices (multiply by 4 for byte offset of uint)
            GatherIndicesX[round * 2] = Vector128.Create(
                Sigma[offset + 0] * 4, Sigma[offset + 2] * 4,
                Sigma[offset + 4] * 4, Sigma[offset + 6] * 4);
            GatherIndicesY[round * 2] = Vector128.Create(
                Sigma[offset + 1] * 4, Sigma[offset + 3] * 4,
                Sigma[offset + 5] * 4, Sigma[offset + 7] * 4);

            // Diagonal step indices
            GatherIndicesX[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 8] * 4, Sigma[offset + 10] * 4,
                Sigma[offset + 12] * 4, Sigma[offset + 14] * 4);
            GatherIndicesY[round * 2 + 1] = Vector128.Create(
                Sigma[offset + 9] * 4, Sigma[offset + 11] * 4,
                Sigma[offset + 13] * 4, Sigma[offset + 15] * 4);
        }
    }
#endif

    // Scalar state for non-SSE path and output extraction
    private readonly uint[] _state;
    private readonly byte[] _buffer;
    private readonly byte[]? _key;
    private readonly int _outputBytes;
    private ulong _bytesCompressed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with default output size (32 bytes).
    /// </summary>
    public Blake2s() : this(MaxHashSizeBytes, null, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    public Blake2s(int outputBytes) : this(outputBytes, null, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-32 bytes.</param>
    public Blake2s(int outputBytes, byte[]? key) : this(outputBytes, key, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size, key, and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-32 bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake2s(int outputBytes, byte[]? key, SimdSupport simdSupport)
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
        _state = new uint[StateSize];
        _buffer = new byte[BlockSizeBytes];

#if NET8_0_OR_GREATER
        _useAvx2 = (simdSupport & SimdSupport.Avx2) != 0 && Avx2.IsSupported && Sse2.IsSupported;
        _useSse2 = (_useAvx2 || (simdSupport & SimdSupport.Sse2) != 0) && Sse2.IsSupported;
#endif

        if (key != null && key.Length > 0)
        {
            _key = new byte[key.Length];
            Array.Copy(key, _key, key.Length);
        }

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key != null ? "BLAKE2s-MAC" : "BLAKE2s";

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
            if (Sse2.IsSupported) support |= SimdSupport.Sse2;
            if (Avx2.IsSupported) support |= SimdSupport.Avx2;
#endif
            return support;
        }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2s"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE2s instance.</returns>
    public static new Blake2s Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2s"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <returns>A new BLAKE2s instance.</returns>
    public static Blake2s Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2s"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2s instance.</returns>
    internal static Blake2s Create(int outputBytes, SimdSupport simdSupport) => new(outputBytes, null, simdSupport);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2s"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The key for keyed hashing (up to 32 bytes).</param>
    /// <returns>A new BLAKE2s instance configured for keyed hashing.</returns>
    public static Blake2s CreateKeyed(int outputBytes, byte[] key) => new(outputBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2s"/> class with default output size.
    /// </summary>
    /// <param name="key">The key for keyed hashing (up to 32 bytes).</param>
    /// <returns>A new BLAKE2s instance configured for keyed hashing.</returns>
    public static Blake2s CreateKeyed(byte[] key) => new(MaxHashSizeBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2s"/> class with specified SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The key for keyed hashing (up to 32 bytes).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2s instance configured for keyed hashing.</returns>
    internal static Blake2s CreateKeyed(int outputBytes, byte[] key, SimdSupport simdSupport) => new(outputBytes, key, simdSupport);

    /// <inheritdoc/>
    public override void Initialize()
    {
        int keyLength = _key?.Length ?? 0;
        uint paramBlock = 0x01010000U | ((uint)keyLength << 8) | (uint)_outputBytes;

#if NET8_0_OR_GREATER
        if (_useSse2)
        {
            // Initialize vector state: IV with parameter XOR on first word
            _stateVec0 = Sse2.Xor(IVLow, Vector128.Create(paramBlock, 0U, 0U, 0U));
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
        if (_useSse2)
        {
            // Extract from vector state
            ExtractOutputSse2(destination);
            bytesWritten = _outputBytes;
            return true;
        }
#endif

        // Scalar output extraction
        int fullWords = _outputBytes / 4;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * 4), _state[i]);
        }

        // Handle partial final word
        int remainingBytes = _outputBytes % 4;
        if (remainingBytes > 0)
        {
            Span<byte> temp = stackalloc byte[4];
            BinaryPrimitives.WriteUInt32LittleEndian(temp, _state[fullWords]);
            temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * 4));
        }

        bytesWritten = _outputBytes;
        return true;
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ExtractOutputSse2(Span<byte> destination)
    {
        // Store vectors to stack, then copy required bytes
        Span<uint> temp = stackalloc uint[8];
        Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref temp[0]), _stateVec0);
        Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref temp[4]), _stateVec1);

        int fullWords = _outputBytes / 4;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * 4), temp[i]);
        }

        int remainingBytes = _outputBytes % 4;
        if (remainingBytes > 0)
        {
            Span<byte> tempBytes = stackalloc byte[4];
            BinaryPrimitives.WriteUInt32LittleEndian(tempBytes, temp[fullWords]);
            tempBytes.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * 4));
        }
    }
#endif

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
#if NET8_0_OR_GREATER
            if (_useSse2)
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
        if (_useSse2)
        {
            CompressSse2(block, isFinal);
            return;
        }
#endif

        // Update counter
        _bytesCompressed += (ulong)_bufferLength;

        // Use stackalloc for working vectors to avoid heap allocations
        Span<uint> v = stackalloc uint[ScratchSize];
        Span<uint> m = stackalloc uint[ScratchSize];

        // Parse message block into 16 32-bit words (little-endian)
#if NET8_0_OR_GREATER
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, uint>(block).CopyTo(m);
        }
        else
#endif
        {
            for (int i = 0; i < ScratchSize; i++)
            {
                m[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
            }
        }

        // Initialize working vector
        v[0] = _state[0];
        v[1] = _state[1];
        v[2] = _state[2];
        v[3] = _state[3];
        v[4] = _state[4];
        v[5] = _state[5];
        v[6] = _state[6];
        v[7] = _state[7];
        v[8] = IV[0];
        v[9] = IV[1];
        v[10] = IV[2];
        v[11] = IV[3];
        v[12] = IV[4] ^ (uint)_bytesCompressed;
        v[13] = IV[5] ^ (uint)(_bytesCompressed >> 32);
        v[14] = isFinal ? ~IV[6] : IV[6];
        v[15] = IV[7];

        // 10 rounds of mixing
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
    /// BLAKE2s mixing function G (uses 32-bit rotations).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void G(ref uint a, ref uint b, ref uint c, ref uint d, uint x, uint y)
    {
        unchecked
        {
            a = a + b + x;
            d = BitOperations.RotateRight(d ^ a, 16);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 12);
            a = a + b + y;
            d = BitOperations.RotateRight(d ^ a, 8);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 7);
        }
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressSse2(ReadOnlySpan<byte> block, bool isFinal)
    {
        _bytesCompressed += (ulong)_bufferLength;

        // Pin the message block for gather operations
        fixed (byte* mPtr = block)
        {
            // Initialize rows from vector state
            // row0 = v[0..3] = state[0..3]
            // row1 = v[4..7] = state[4..7]
            // row2 = v[8..11] = IV[0..3]
            // row3 = v[12..15] = IV[4..7] with counter/finalization
            var row0 = _stateVec0;
            var row1 = _stateVec1;
            var row2 = IVLow;

            // row3 = IVHigh with counter/finalization applied
            // v[12] = IV[4] ^ counter_low, v[13] = IV[5] ^ counter_high, v[14] = final ? ~IV[6] : IV[6], v[15] = IV[7]
            var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
            var row3 = Sse2.Xor(IVHigh, counterVec);

            if (isFinal)
            {
                row3 = Sse2.Xor(row3, FinalMask);
            }

            // Parse message - use gather if AVX2 available, otherwise scalar
            Span<uint> m = stackalloc uint[ScratchSize];
            if (BitConverter.IsLittleEndian)
            {
                MemoryMarshal.Cast<byte, uint>(block).CopyTo(m);
            }
            else
            {
                for (int i = 0; i < ScratchSize; i++)
                {
                    m[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
                }
            }

            // 10 rounds of mixing
            for (int round = 0; round < Rounds; round++)
            {
                int sigmaOffset = round * ScratchSize;

                // Column step: G on (v[0],v[4],v[8],v[12]), (v[1],v[5],v[9],v[13]), etc.
                var mx0 = Vector128.Create(m[Sigma[sigmaOffset + 0]], m[Sigma[sigmaOffset + 2]],
                    m[Sigma[sigmaOffset + 4]], m[Sigma[sigmaOffset + 6]]);
                var my0 = Vector128.Create(m[Sigma[sigmaOffset + 1]], m[Sigma[sigmaOffset + 3]],
                    m[Sigma[sigmaOffset + 5]], m[Sigma[sigmaOffset + 7]]);

                GRound(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal step: rotate rows to align diagonals
                // row1: rotate left by 1 -> [v5, v6, v7, v4]
                // row2: rotate left by 2 -> [v10, v11, v8, v9]
                // row3: rotate left by 3 -> [v15, v12, v13, v14]
                row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2

                var mx1 = Vector128.Create(m[Sigma[sigmaOffset + 8]], m[Sigma[sigmaOffset + 10]],
                    m[Sigma[sigmaOffset + 12]], m[Sigma[sigmaOffset + 14]]);
                var my1 = Vector128.Create(m[Sigma[sigmaOffset + 9]], m[Sigma[sigmaOffset + 11]],
                    m[Sigma[sigmaOffset + 13]], m[Sigma[sigmaOffset + 15]]);

                GRound(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate rows to restore column order
                row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
            }

            // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
            _stateVec0 = Sse2.Xor(_stateVec0, Sse2.Xor(row0, row2));
            _stateVec1 = Sse2.Xor(_stateVec1, Sse2.Xor(row1, row3));
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private unsafe void CompressAvx2(ReadOnlySpan<byte> block, bool isFinal)
    {
        _bytesCompressed += (ulong)_bufferLength;

        // Pin the message block for gather operations
        fixed (byte* mPtr = block)
        {
            // Initialize rows from vector state
            // row0 = v[0..3] = state[0..3]
            // row1 = v[4..7] = state[4..7]
            // row2 = v[8..11] = IV[0..3]
            // row3 = v[12..15] = IV[4..7] with counter/finalization
            var row0 = _stateVec0;
            var row1 = _stateVec1;
            var row2 = IVLow;

            // row3 = IVHigh with counter/finalization applied
            var counterVec = Vector128.Create((uint)_bytesCompressed, (uint)(_bytesCompressed >> 32), 0U, 0U);
            var row3 = Sse2.Xor(IVHigh, counterVec);

            if (isFinal)
            {
                row3 = Sse2.Xor(row3, FinalMask);
            }

            // 10 rounds of mixing
            for (int round = 0; round < Rounds; round++)
            {
                int gatherIdx = round * 2;

                // Column step - use AVX2 gather for message words
                var mx0 = Avx2.GatherVector128((int*)mPtr, GatherIndicesX[gatherIdx], 1).AsUInt32();
                var my0 = Avx2.GatherVector128((int*)mPtr, GatherIndicesY[gatherIdx], 1).AsUInt32();

                GRound(ref row0, ref row1, ref row2, ref row3, mx0, my0);

                // Diagonal step: rotate rows to align diagonals
                row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2

                // Diagonal step - use AVX2 gather for message words
                var mx1 = Avx2.GatherVector128((int*)mPtr, GatherIndicesX[gatherIdx + 1], 1).AsUInt32();
                var my1 = Avx2.GatherVector128((int*)mPtr, GatherIndicesY[gatherIdx + 1], 1).AsUInt32();

                GRound(ref row0, ref row1, ref row2, ref row3, mx1, my1);

                // Un-rotate rows to restore column order
                row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
                row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
                row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
            }

            // Finalize: state ^= row0 ^ row2, state ^= row1 ^ row3
            _stateVec0 = Sse2.Xor(_stateVec0, Sse2.Xor(row0, row2));
            _stateVec1 = Sse2.Xor(_stateVec1, Sse2.Xor(row1, row3));
        }
    }

    /// <summary>
    /// Performs one G round on 4 parallel lanes using SSE2.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void GRound(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12) - must use shift+or (not byte-aligned)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8) - use shuffle for byte-aligned rotation
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7) - must use shift+or (not byte-aligned)
        var t2 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t2, 7), Sse2.ShiftLeftLogical(t2, 25));
    }
#endif
}
