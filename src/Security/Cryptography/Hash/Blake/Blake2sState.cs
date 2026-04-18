// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693
#pragma warning disable CS0414  // _simdSupport is read inside #if NET8_0_OR_GREATER guard

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Core state for the BLAKE2s hash computation.
/// </summary>
/// <remarks>
/// <para>
/// This is a lightweight struct that holds the full BLAKE2s hash state inline using
/// <c>fixed</c> buffers, avoiding heap allocations for the state and block buffer.
/// </para>
/// <para>
/// BLAKE2s is optimized for 32-bit platforms and uses 32-bit words with a 64-byte block size.
/// </para>
/// </remarks>
internal unsafe partial struct Blake2sState : IIncrementalHash
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
    internal const int Rounds = 10;

    // The size of the state buffer
    private const int StateSize = 8;

    // The size of the scratch buffers
    internal const int ScratchSize = BlockSizeBytes / sizeof(uint);

    // BLAKE2s IV constants (same as SHA-256)
    private static ReadOnlySpan<uint> IV =>
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
    internal static ReadOnlySpan<byte> Sigma =>
    [
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
    ];

    public int HashLengthBytes => _outputBytes;

    // Scalar state for non-SIMD path and output extraction
    private fixed byte _buffer[BlockSizeBytes];
    private fixed uint _state[StateSize];
    private ulong _bytesCompressed;
    private uint _bufferLength;
    private readonly SimdSupport _simdSupport;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2sState"/> struct with specified output size and SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    /// <param name="outputBytes">The desired output size in bytes (1-32).</param>
    internal Blake2sState(SimdSupport simdSupport, int outputBytes)
    {
        _outputBytes = outputBytes;
        _simdSupport = SimdSupport.None;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
#endif

        Initialize();
    }

    /// <inheritdoc/>
    public void Append<T>(ReadOnlySpan<T> input) where T : struct
    {
        Append(MemoryMarshal.AsBytes(input));
    }

    /// <inheritdoc/>
    public void Append<T>(ReadOnlySequence<T> input) where T : struct
    {
        foreach (var segment in input)
        {
            Append(segment.Span);
        }
    }

    /// <inheritdoc/>
    public bool TryGetCurrentHash(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Zero-pad the remaining buffer
        Unsafe.InitBlockUnaligned(ref _buffer[_bufferLength], 0, BlockSizeBytes - _bufferLength);

        // Compress final block
        Compress(ref _buffer[0], _bufferLength, true);

        // Extract output
        ExtractOutput(destination);

        bytesWritten = _outputBytes;
        return true;
    }

    /// <inheritdoc/>
    public void Reset(object? resetState)
    {
        byte[]? key = resetState as byte[];
        int keyLength = key?.Length ?? 0;

        uint paramBlock = 0x01010000U | ((uint)keyLength << 8) | (uint)_outputBytes;
        InitializeState(paramBlock);

        Unsafe.InitBlockUnaligned(ref _buffer[0], 0, BlockSizeBytes);
        _bytesCompressed = 0;
        _bufferLength = 0;

        // If keyed, the first block is the zero-padded key
        if (key != null && keyLength > 0)
        {
            Unsafe.CopyBlockUnaligned(ref _buffer[0], ref MemoryMarshal.GetReference(key), (uint)keyLength);
            _bufferLength = BlockSizeBytes;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Initialize();
    }

    /// <inheritdoc/>
    public void Append(ReadOnlySpan<byte> input)
    {
        uint remaining = (uint)input.Length;
        ref byte rinput = ref MemoryMarshal.GetReference(input);

        // If we have data in buffer, fill it first
        if (_bufferLength != 0)
        {
            // Only compress if buffer is full AND there's more data coming
            uint toCopy;
            if (remaining > (toCopy = (uint)BlockSizeBytes - _bufferLength))
            {
                if (toCopy > 0)
                {
                    Unsafe.CopyBlockUnaligned(ref _buffer[_bufferLength], ref rinput, toCopy);
                    _bufferLength += toCopy;
                    rinput = ref Unsafe.Add(ref rinput, (nint)toCopy);
                    remaining -= toCopy;
                }

                Compress(ref _buffer[0], BlockSizeBytes, false);
                _bufferLength = 0;
            }
        }

        // Process all full blocks, but always keep at least one block for finalization
        if (remaining > BlockSizeBytes)
        {
            uint cb = (remaining - 1) & ~((uint)BlockSizeBytes - 1);
            Compress(ref rinput, cb, false);
            rinput = ref Unsafe.Add(ref rinput, (nint)cb);
            remaining -= cb;
        }

        // Store remaining bytes in buffer
        if (remaining != 0)
        {
            Unsafe.CopyBlockUnaligned(ref _buffer[_bufferLength], ref rinput, remaining);
            _bufferLength += remaining;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void Compress(ref byte input, uint cb, bool isFinal)
    {
        uint blockSize = Math.Min(BlockSizeBytes, cb);
        fixed (Blake2sState* core = &this)
        fixed (byte* pinput = &input)
        {
            uint* state = core->_state;
            byte* block = pinput;
            byte* blockEnd = pinput + cb;

            do
            {
                _bytesCompressed += (ulong)blockSize;

#if NET8_0_OR_GREATER
                if ((_simdSupport & SimdSupport.Ssse3) != 0)
                {
                    CompressSsse3(block, state, _bytesCompressed, isFinal);
                }
#if EXPERIMENTAL
                else if ((_simdSupport & SimdSupport.Avx2) != 0)
                {
                    CompressAvx2(block, state, _bytesCompressed, isFinal);
                }
                else if ((_simdSupport & SimdSupport.Sse2) != 0)
                {
                    CompressSse2(block, state, _bytesCompressed, isFinal);
                }
                else if ((_simdSupport & SimdSupport.Neon) != 0)
                {
                    CompressNeon(block, state, _bytesCompressed, isFinal);
                }
#endif
                else
#endif
                {
                    CompressScalar(block, state, _bytesCompressed, isFinal);
                }

                block += blockSize;
            } while (block < blockEnd);
        }
    }

    private void Initialize()
    {
        Unsafe.InitBlockUnaligned(ref Unsafe.As<uint, byte>(ref _state[0]), 0, StateSize * (uint)sizeof(uint));
        Unsafe.InitBlockUnaligned(ref _buffer[0], 0, BlockSizeBytes);
        _bytesCompressed = 0;
        _bufferLength = 0;
    }

    private void InitializeState(uint paramBlock)
    {
        Unsafe.CopyBlock(
            ref Unsafe.As<uint, byte>(ref _state[0]),
            ref Unsafe.As<uint, byte>(ref MemoryMarshal.GetReference(IV)),
            StateSize * (uint)sizeof(uint));
        _state[0] ^= paramBlock;
    }

    private void ExtractOutput(Span<byte> destination)
    {
        int fullWords = _outputBytes / sizeof(uint);

        fixed (byte* dst = destination)
        fixed (uint* state = _state)
        {
            BinarySpans.WriteUInt32LittleEndian(state, dst, fullWords);

            // Handle partial final word
            int remainingBytes = _outputBytes % sizeof(uint);
            if (remainingBytes > 0)
            {
                Span<byte> temp = stackalloc byte[sizeof(uint)];
                BinaryPrimitives.WriteUInt32LittleEndian(temp, _state[fullWords]);
                temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * sizeof(uint)));
            }
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressScalar(byte* msgPtr, uint* state, ulong bytesCompressed, bool isFinal)
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
