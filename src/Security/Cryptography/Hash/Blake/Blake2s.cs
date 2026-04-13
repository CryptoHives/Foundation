// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693
#pragma warning disable CS0414  // _simdSupport is read inside #if NET8_0_OR_GREATER guard

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the BLAKE2s hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE2s that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE2s is optimized for 32-bit platforms and produces digests from 1 to 32 bytes.
/// The default output size is 32 bytes (256 bits).
/// </para>
/// <para>
/// BLAKE2s supports an optional key for keyed hashing (MAC mode) with keys up to 32 bytes.
/// </para>
/// </remarks>
public sealed partial class Blake2s : HashAlgorithm
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

    private readonly SimdSupport _simdSupport;
    private readonly uint[] _state;
    private readonly byte[] _buffer;
    private readonly byte[]? _key;
    private readonly int _outputBytes;
    private ulong _bytesCompressed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with default output size (32 bytes).
    /// </summary>
    public Blake2s() : this(SimdSupport.All, MaxHashSizeBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    public Blake2s(int outputBytes) : this(SimdSupport.All, outputBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-32 bytes.</param>
    public Blake2s(int outputBytes, byte[]? key) : this(SimdSupport.All, outputBytes, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2s"/> class with specified output size, key, and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-32 bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake2s(SimdSupport simdSupport, int outputBytes, byte[]? key)
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

        _simdSupport = SimdSupport.None;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
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
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <returns>A new BLAKE2s instance.</returns>
    internal static Blake2s Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes, null);

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
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    /// <param name="key">The key for keyed hashing (up to 32 bytes).</param>
    /// <returns>A new BLAKE2s instance configured for keyed hashing.</returns>
    internal static Blake2s CreateKeyed(SimdSupport simdSupport, int outputBytes, byte[] key) => new(simdSupport, outputBytes, key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        int keyLength = _key?.Length ?? 0;
        uint paramBlock = 0x01010000U | ((uint)keyLength << 8) | (uint)_outputBytes;

        Array.Copy(IV, _state, StateSize);
        _state[0] ^= paramBlock;

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

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private unsafe void Compress(byte* msgPtr, uint* state, int bytesConsumed, bool isFinal)
    {
        _bytesCompressed += (ulong)bytesConsumed;

#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Ssse3) != 0)
        {
            CompressSsse3(msgPtr, state, _bytesCompressed, isFinal);
        }
#if EXPERIMENTAL
        else if ((_simdSupport & SimdSupport.Avx2) != 0)
        {
            CompressAvx2(msgPtr, state, _bytesCompressed, isFinal);
        }
        else if ((_simdSupport & SimdSupport.Sse2) != 0)
        {
            CompressSse2(msgPtr, state, _bytesCompressed, isFinal);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            CompressNeon(msgPtr, state, _bytesCompressed, isFinal);
        }
        else
#endif
#endif
        {
            CompressScalar(msgPtr, state, _bytesCompressed, isFinal);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private unsafe void Compress(ReadOnlySpan<byte> block, int bytesConsumed, bool isFinal)
    {
        fixed (uint* state = _state)
        fixed (byte* msgPtr = block)
        {
            Compress(msgPtr, state, bytesConsumed, isFinal);
        }
    }

    /// <inheritdoc/>
    protected override unsafe void HashCore(ReadOnlySpan<byte> source)
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
                Compress(_buffer, BlockSizeBytes, false);
                _bufferLength = 0;
            }
        }

        // Process full blocks, but always keep at least one block for finalization
        fixed (uint* state = _state)
        fixed (byte* msgPtr = source)
        {
            while (offset + BlockSizeBytes < source.Length)
            {
                Compress(msgPtr + offset, state, BlockSizeBytes, false);
                offset += BlockSizeBytes;
            }
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
        Compress(_buffer, _bufferLength, true);

        // Extract output
        ExtractOutput(destination);

        bytesWritten = _outputBytes;
        return true;
    }

    private void ExtractOutput(Span<byte> destination)
    {
        int fullWords = _outputBytes / sizeof(UInt32);

        BinarySpans.WriteUInt32LittleEndian(_state.AsSpan(0, fullWords), destination);

        // Handle partial final word
        int remainingBytes = _outputBytes % sizeof(UInt32);
        if (remainingBytes > 0)
        {
            Span<byte> temp = stackalloc byte[sizeof(UInt32)];
            BinaryPrimitives.WriteUInt32LittleEndian(temp, _state[fullWords]);
            temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(UInt32)));
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
            if (_key != null)
            {
                ClearBuffer(_key);
            }
        }
        base.Dispose(disposing);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressScalar(byte* msgPtr, uint* state, ulong bytesCompressed, bool isFinal)
    {
        uint* mr = (uint*)msgPtr;
        if (!BitConverter.IsLittleEndian)
        {
            uint* scratch = stackalloc uint[ScratchSize];
            BinarySpans.ReadUInt32LittleEndian(msgPtr, scratch, ScratchSize);
            mr = scratch;
        }

        uint m0 = mr[0], m1 = mr[1], m2 = mr[2], m3 = mr[3],
             m4 = mr[4], m5 = mr[5], m6 = mr[6], m7 = mr[7],
             m8 = mr[8], m9 = mr[9], m10 = mr[10], m11 = mr[11],
             m12 = mr[12], m13 = mr[13], m14 = mr[14], m15 = mr[15];

        uint v0 = state[0], v1 = state[1], v2 = state[2], v3 = state[3],
             v4 = state[4], v5 = state[5], v6 = state[6], v7 = state[7];

        uint v8 = 0x6a09e667U, v9 = 0xbb67ae85U,
             v10 = 0x3c6ef372U, v11 = 0xa54ff53aU,
             v12 = 0x510e527fU ^ (uint)bytesCompressed,
             v13 = 0x9b05688cU ^ (uint)(bytesCompressed >> 32),
             v14 = isFinal ? ~0x1f83d9abU : 0x1f83d9abU,
             v15 = 0x5be0cd19U;

        // Round 0 — sigma: 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
        G(ref v0, ref v4, ref v8, ref v12, m0, m1); G(ref v1, ref v5, ref v9, ref v13, m2, m3);
        G(ref v2, ref v6, ref v10, ref v14, m4, m5); G(ref v3, ref v7, ref v11, ref v15, m6, m7);
        G(ref v0, ref v5, ref v10, ref v15, m8, m9); G(ref v1, ref v6, ref v11, ref v12, m10, m11);
        G(ref v2, ref v7, ref v8, ref v13, m12, m13); G(ref v3, ref v4, ref v9, ref v14, m14, m15);
        // Round 1 — sigma: 14,10,4,8,9,15,13,6,1,12,0,2,11,7,5,3
        G(ref v0, ref v4, ref v8, ref v12, m14, m10); G(ref v1, ref v5, ref v9, ref v13, m4, m8);
        G(ref v2, ref v6, ref v10, ref v14, m9, m15); G(ref v3, ref v7, ref v11, ref v15, m13, m6);
        G(ref v0, ref v5, ref v10, ref v15, m1, m12); G(ref v1, ref v6, ref v11, ref v12, m0, m2);
        G(ref v2, ref v7, ref v8, ref v13, m11, m7); G(ref v3, ref v4, ref v9, ref v14, m5, m3);
        // Round 2 — sigma: 11,8,12,0,5,2,15,13,10,14,3,6,7,1,9,4
        G(ref v0, ref v4, ref v8, ref v12, m11, m8); G(ref v1, ref v5, ref v9, ref v13, m12, m0);
        G(ref v2, ref v6, ref v10, ref v14, m5, m2); G(ref v3, ref v7, ref v11, ref v15, m15, m13);
        G(ref v0, ref v5, ref v10, ref v15, m10, m14); G(ref v1, ref v6, ref v11, ref v12, m3, m6);
        G(ref v2, ref v7, ref v8, ref v13, m7, m1); G(ref v3, ref v4, ref v9, ref v14, m9, m4);
        // Round 3 — sigma: 7,9,3,1,13,12,11,14,2,6,5,10,4,0,15,8
        G(ref v0, ref v4, ref v8, ref v12, m7, m9); G(ref v1, ref v5, ref v9, ref v13, m3, m1);
        G(ref v2, ref v6, ref v10, ref v14, m13, m12); G(ref v3, ref v7, ref v11, ref v15, m11, m14);
        G(ref v0, ref v5, ref v10, ref v15, m2, m6); G(ref v1, ref v6, ref v11, ref v12, m5, m10);
        G(ref v2, ref v7, ref v8, ref v13, m4, m0); G(ref v3, ref v4, ref v9, ref v14, m15, m8);
        // Round 4 — sigma: 9,0,5,7,2,4,10,15,14,1,11,12,6,8,3,13
        G(ref v0, ref v4, ref v8, ref v12, m9, m0); G(ref v1, ref v5, ref v9, ref v13, m5, m7);
        G(ref v2, ref v6, ref v10, ref v14, m2, m4); G(ref v3, ref v7, ref v11, ref v15, m10, m15);
        G(ref v0, ref v5, ref v10, ref v15, m14, m1); G(ref v1, ref v6, ref v11, ref v12, m11, m12);
        G(ref v2, ref v7, ref v8, ref v13, m6, m8); G(ref v3, ref v4, ref v9, ref v14, m3, m13);
        // Round 5 — sigma: 2,12,6,10,0,11,8,3,4,13,7,5,15,14,1,9
        G(ref v0, ref v4, ref v8, ref v12, m2, m12); G(ref v1, ref v5, ref v9, ref v13, m6, m10);
        G(ref v2, ref v6, ref v10, ref v14, m0, m11); G(ref v3, ref v7, ref v11, ref v15, m8, m3);
        G(ref v0, ref v5, ref v10, ref v15, m4, m13); G(ref v1, ref v6, ref v11, ref v12, m7, m5);
        G(ref v2, ref v7, ref v8, ref v13, m15, m14); G(ref v3, ref v4, ref v9, ref v14, m1, m9);
        // Round 6 — sigma: 12,5,1,15,14,13,4,10,0,7,6,3,9,2,8,11
        G(ref v0, ref v4, ref v8, ref v12, m12, m5); G(ref v1, ref v5, ref v9, ref v13, m1, m15);
        G(ref v2, ref v6, ref v10, ref v14, m14, m13); G(ref v3, ref v7, ref v11, ref v15, m4, m10);
        G(ref v0, ref v5, ref v10, ref v15, m0, m7); G(ref v1, ref v6, ref v11, ref v12, m6, m3);
        G(ref v2, ref v7, ref v8, ref v13, m9, m2); G(ref v3, ref v4, ref v9, ref v14, m8, m11);
        // Round 7 — sigma: 13,11,7,14,12,1,3,9,5,0,15,4,8,6,2,10
        G(ref v0, ref v4, ref v8, ref v12, m13, m11); G(ref v1, ref v5, ref v9, ref v13, m7, m14);
        G(ref v2, ref v6, ref v10, ref v14, m12, m1); G(ref v3, ref v7, ref v11, ref v15, m3, m9);
        G(ref v0, ref v5, ref v10, ref v15, m5, m0); G(ref v1, ref v6, ref v11, ref v12, m15, m4);
        G(ref v2, ref v7, ref v8, ref v13, m8, m6); G(ref v3, ref v4, ref v9, ref v14, m2, m10);
        // Round 8 — sigma: 6,15,14,9,11,3,0,8,12,2,13,7,1,4,10,5
        G(ref v0, ref v4, ref v8, ref v12, m6, m15); G(ref v1, ref v5, ref v9, ref v13, m14, m9);
        G(ref v2, ref v6, ref v10, ref v14, m11, m3); G(ref v3, ref v7, ref v11, ref v15, m0, m8);
        G(ref v0, ref v5, ref v10, ref v15, m12, m2); G(ref v1, ref v6, ref v11, ref v12, m13, m7);
        G(ref v2, ref v7, ref v8, ref v13, m1, m4); G(ref v3, ref v4, ref v9, ref v14, m10, m5);
        // Round 9 — sigma: 10,2,8,4,7,6,1,5,15,11,9,14,3,12,13,0
        G(ref v0, ref v4, ref v8, ref v12, m10, m2); G(ref v1, ref v5, ref v9, ref v13, m8, m4);
        G(ref v2, ref v6, ref v10, ref v14, m7, m6); G(ref v3, ref v7, ref v11, ref v15, m1, m5);
        G(ref v0, ref v5, ref v10, ref v15, m15, m11); G(ref v1, ref v6, ref v11, ref v12, m9, m14);
        G(ref v2, ref v7, ref v8, ref v13, m3, m12); G(ref v3, ref v4, ref v9, ref v14, m13, m0);

        state[0] ^= v0 ^ v8; state[1] ^= v1 ^ v9;
        state[2] ^= v2 ^ v10; state[3] ^= v3 ^ v11;
        state[4] ^= v4 ^ v12; state[5] ^= v5 ^ v13;
        state[6] ^= v6 ^ v14; state[7] ^= v7 ^ v15;
    }

    /// <summary>
    /// BLAKE2s mixing function G (uses 32-bit rotations).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
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
}
