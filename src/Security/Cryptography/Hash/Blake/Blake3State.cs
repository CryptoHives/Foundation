// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Core state for the BLAKE3 hash computation.
/// </summary>
/// <remarks>
/// <para>
/// This is a lightweight struct that holds the full BLAKE3 hash state inline using
/// <c>fixed</c> buffers, avoiding heap allocations for the state, chunk buffer,
/// and CV stack.
/// </para>
/// <para>
/// BLAKE3 is a tree-hashing construction using a 1024-byte chunk size and 64-byte
/// compression blocks. This struct manages the full Merkle tree state.
/// </para>
/// </remarks>
internal unsafe partial struct Blake3State : IIncrementalHash<bool>
{
    /// <summary>
    /// The default hash size in bits.
    /// </summary>
    public const int DefaultHashSizeBits = 256;

    /// <summary>
    /// The default hash size in bytes.
    /// </summary>
    public const int DefaultHashSizeBytes = DefaultHashSizeBits / 8;

    /// <summary>
    /// The required key size in bytes for keyed hash mode.
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    /// <summary>
    /// The chunk size in bytes (1024 bytes).
    /// </summary>
    public const int ChunkSizeBytes = 1024;

    // Max tree depth (2^54 chunks × 1024 bytes = 16 exabytes)
    private const int MaxStackDepth = 54;

    /// <summary>
    /// The required key size in uint words for internal usage.
    /// </summary>
    private const int KeySizeWords = KeySizeBytes / sizeof(uint);

    /// <summary>
    /// The block size in uint words for internal usage.
    /// </summary>
    private const int BlockSizeWords = BlockSizeBytes / sizeof(uint);

    // BLAKE3 flags
    internal const uint FlagChunkStart = 1 << 0;
    internal const uint FlagChunkEnd = 1 << 1;
    internal const uint FlagParent = 1 << 2;
    internal const uint FlagRoot = 1 << 3;
    internal const uint FlagKeyedHash = 1 << 4;
    internal const uint FlagDeriveKeyContext = 1 << 5;
    internal const uint FlagDeriveKeyMaterial = 1 << 6;

    // BLAKE3 IV (same as BLAKE2s)
    private static readonly uint[] s_IV = new uint[] {
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU,
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U
    };

    internal static ReadOnlySpan<uint> IV => s_IV;

    // Fixed buffers for all state
    private fixed byte _chunkBuffer[ChunkSizeBytes];
    private fixed uint _keyWords[KeySizeWords];
    private fixed uint _cv[KeySizeWords];
    private fixed uint _cvStackBuf[MaxStackDepth * 8];
    private fixed uint _rootBlock[BlockSizeWords];
    private fixed uint _rootCv[KeySizeWords];
    private fixed byte _squeezeBuf[BlockSizeBytes];

    // Scalar state
    private int _cvStackDepth;
    private int _chunkBufferLength;
    private ulong _chunkCounter;
    private int _blocksCompressed;
    private readonly int _outputBytes;
    private readonly uint _baseFlags;
    private readonly SimdSupport _simdSupport;

    // XOF state
    private uint _rootBlockLen;
    private uint _rootFlags;
    public bool _squeezed;
    private ulong _outputCounter;
    private int _squeezeOffset;

    /// <inheritdoc/>
    public int HashLengthBytes => _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3State"/> struct for standard hashing.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    internal Blake3State(SimdSupport simdSupport, int outputBytes)
    {
        _outputBytes = outputBytes;
        _baseFlags = 0;
        _simdSupport = SimdSupport.None;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
#endif

        InitializeHash();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3State"/> struct for standard hashing.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="key"></param>
    internal Blake3State(SimdSupport simdSupport, int outputBytes, ReadOnlySpan<byte> key)
    {
        _outputBytes = outputBytes;
        _baseFlags = 0;
        _simdSupport = SimdSupport.None;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
#endif

        for (int i = 0; i < KeySizeWords; i++)
        {
            _keyWords[i] = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(i * sizeof(uint)));
        }

        InitializeKeyed();
    }

    public bool Squeezed => _squeezed;

    /// <inheritdoc/>
    public void Reset(bool keyedMode)
    {
        if (!keyedMode)
        {
            InitializeHash();
        }
        else
        {
            InitializeKeyed();
        }

        ResetCommonState();
    }

    /// <inheritdoc/>
    public bool TryGetCurrentHash(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = _outputBytes;

        if (!_squeezed && _outputBytes <= BlockSizeBytes)
        {
            // Fast path: output fits in a single squeeze block — write directly to destination
            FinalizeRoot();
            _squeezed = true;
            Span<byte> buf = stackalloc byte[BlockSizeBytes];
            SqueezeRootBlock(0, buf);
            buf.Slice(0, _outputBytes).CopyTo(destination);
            return true;
        }

        Squeeze(destination);
        return true;
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
    public void Append(ReadOnlySpan<byte> source)
    {
        fixed (Blake3State* core = &this)
        {
            int offset = 0;
            while (offset < source.Length)
            {
                // If chunk buffer is full, finalize the chunk
                if (_chunkBufferLength == ChunkSizeBytes)
                {
                    FinalizeChunk(core, core->_cvStackBuf + _cvStackDepth * 8);

                    AddChunkToTree();
                    _chunkCounter++;
                    _chunkBufferLength = 0;
                    _blocksCompressed = 0;
                    Unsafe.CopyBlock(core->_cv, core->_keyWords, KeySizeWords * (uint)sizeof(uint));
                }

                int toCopy = Math.Min(ChunkSizeBytes - _chunkBufferLength, source.Length - offset);
                Unsafe.CopyBlockUnaligned(
                    ref core->_chunkBuffer[_chunkBufferLength],
                    ref MemoryMarshal.GetReference(source.Slice(offset)),
                    (uint)toCopy);
                _chunkBufferLength += toCopy;
                offset += toCopy;
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        fixed (Blake3State* core = &this)
        {
            Unsafe.InitBlockUnaligned(core->_keyWords, 0, KeySizeWords * (uint)sizeof(uint));
            Unsafe.InitBlockUnaligned(core->_cv, 0, KeySizeWords * (uint)sizeof(uint));
            Unsafe.InitBlockUnaligned(core->_chunkBuffer, 0, ChunkSizeBytes);
            Unsafe.InitBlockUnaligned(core->_cvStackBuf, 0, MaxStackDepth * 8 * (uint)sizeof(uint));
            Unsafe.InitBlockUnaligned(core->_rootBlock, 0, BlockSizeWords * (uint)sizeof(uint));
            Unsafe.InitBlockUnaligned(core->_rootCv, 0, KeySizeWords * (uint)sizeof(uint));
            Unsafe.InitBlockUnaligned(core->_squeezeBuf, 0, BlockSizeBytes);
        }
        _cvStackDepth = 0;
    }

    private void InitializeHash()
    {
        Unsafe.CopyBlock(
            ref Unsafe.As<uint, byte>(ref _keyWords[0]),
            ref Unsafe.As<uint, byte>(ref MemoryMarshal.GetReference(IV)),
            KeySizeWords * (uint)sizeof(uint));
        Unsafe.CopyBlock(
            ref Unsafe.As<uint, byte>(ref _cv[0]),
            ref Unsafe.As<uint, byte>(ref MemoryMarshal.GetReference(IV)),
            KeySizeWords * (uint)sizeof(uint));
        ResetCommonState();
    }

    private void InitializeKeyed()
    {
        Unsafe.CopyBlock(
            ref Unsafe.As<uint, byte>(ref _cv[0]),
            ref Unsafe.As<uint, byte>(ref _keyWords[0]),
            KeySizeWords * (uint)sizeof(uint));
        ResetCommonState();
    }

    private void ResetCommonState()
    {
        _chunkBufferLength = 0;
        _chunkCounter = 0;
        _blocksCompressed = 0;
        _cvStackDepth = 0;
        _squeezed = false;
        _outputCounter = 0;
        _squeezeOffset = 0;
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void FinalizeChunk(Blake3State* bs, uint* destination)
    {
        byte* block = stackalloc byte[BlockSizeBytes];
        byte* p = bs->_chunkBuffer;
        byte* pEnd = p + _chunkBufferLength;
        int offset = 0;
        while (pEnd - p > 0)
        {
            int blockLen = Math.Min(BlockSizeBytes, _chunkBufferLength - offset);
            bool isStart = _blocksCompressed == 0;
            bool isEnd = offset + blockLen >= _chunkBufferLength;

            uint flags = _baseFlags;
            if (isStart) flags |= FlagChunkStart;
            if (isEnd) flags |= FlagChunkEnd;

            if (blockLen == BlockSizeBytes)
            {
                // Full block: compress directly from chunk buffer — no copy needed
                CompressBlock(bs->_cv, p, BlockSizeBytes, _chunkCounter, flags);
            }
            else
            {
                // Partial last block: stackalloc is zero-initialized for padding
                Unsafe.CopyBlockUnaligned(
                    ref *block,
                    ref *p,
                    (uint)blockLen);

                CompressBlock(bs->_cv, block, (uint)blockLen, _chunkCounter, flags);
            }

            _blocksCompressed++;
            offset += BlockSizeBytes;
            p += BlockSizeBytes;
        }

        Unsafe.CopyBlock(destination, bs->_cv, KeySizeWords * (uint)sizeof(uint));
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void AddChunkToTree()
    {
        _cvStackDepth++;

        fixed (Blake3State* core = &this)
        {
            ulong totalChunks = _chunkCounter + 1;
            while ((totalChunks & 1) == 0 && _cvStackDepth >= 2)
            {
                uint* left = core->_cvStackBuf + (_cvStackDepth - 2) * 8;
                uint* right = core->_cvStackBuf + (_cvStackDepth - 1) * 8;

                // Merge into left's slot (left is read into block before destination is written)
                ComputeParentCv(left, right, left);

                _cvStackDepth--;
                totalChunks >>= 1;
            }
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ComputeParentCv(uint* left, uint* right, uint* destination)
    {
        uint* m = stackalloc uint[BlockSizeWords];

        // Copy left[8] and right[8] into m[16]
        Unsafe.CopyBlock(m, left, 8 * (uint)sizeof(uint));
        Unsafe.CopyBlock(m + 8, right, 8 * (uint)sizeof(uint));

        uint flags = _baseFlags | FlagParent;

        uint* v = stackalloc uint[BlockSizeWords];
        v[0] = _keyWords[0]; v[1] = _keyWords[1]; v[2] = _keyWords[2]; v[3] = _keyWords[3];
        v[4] = _keyWords[4]; v[5] = _keyWords[5]; v[6] = _keyWords[6]; v[7] = _keyWords[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = 0;
        v[13] = 0;
        v[14] = BlockSizeBytes;
        v[15] = flags;

        Compress(v, m);

        for (int i = 0; i < 8; i++)
        {
            destination[i] = v[i] ^ v[i + 8];
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void CompressBlock(uint* cv, byte* block, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Ssse3) != 0)
        {
            CompressBlockSsse3(cv, block, blockLen, counter, flags);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            CompressBlockNeon(cv, block, blockLen, counter, flags);
        }
        else
#endif
        {
            CompressBlockScalar(cv, block, blockLen, counter, flags);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlockScalar(uint* cv, byte* block, uint blockLen, ulong counter, uint flags)
    {
        uint* m = stackalloc uint[BlockSizeWords];
        BinarySpans.ReadUInt32LittleEndian(block, m, BlockSizeWords);

        uint* v = stackalloc uint[BlockSizeWords];
        v[0] = cv[0]; v[1] = cv[1]; v[2] = cv[2]; v[3] = cv[3];
        v[4] = cv[4]; v[5] = cv[5]; v[6] = cv[6]; v[7] = cv[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = (uint)counter;
        v[13] = (uint)(counter >> 32);
        v[14] = blockLen;
        v[15] = flags;

        Compress(v, m);

        for (int i = 0; i < 8; i++)
        {
            cv[i] = v[i] ^ v[i + 8];
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal static void Compress(uint* v, uint* m)
    {
        // Round 1
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[0], m[1]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[2], m[3]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[4], m[5]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[6], m[7]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[8], m[9]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[10], m[11]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[12], m[13]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[14], m[15]);

        // Round 2
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[2], m[6]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[3], m[10]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[7], m[0]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[4], m[13]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[1], m[11]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[12], m[5]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[9], m[14]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[15], m[8]);

        // Round 3
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[3], m[4]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[10], m[12]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[13], m[2]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[7], m[14]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[6], m[5]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[9], m[0]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[11], m[15]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[8], m[1]);

        // Round 4
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[10], m[7]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[12], m[9]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[14], m[3]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[13], m[15]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[4], m[0]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[11], m[2]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[5], m[8]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[1], m[6]);

        // Round 5
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[12], m[13]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[9], m[11]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[15], m[10]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[14], m[8]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[7], m[2]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[5], m[3]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[0], m[1]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[6], m[4]);

        // Round 6
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[9], m[14]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[11], m[5]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[8], m[12]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[15], m[1]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[13], m[3]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[0], m[10]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[2], m[6]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[4], m[7]);

        // Round 7
        G(ref v[0], ref v[4], ref v[8], ref v[12], m[11], m[15]);
        G(ref v[1], ref v[5], ref v[9], ref v[13], m[5], m[0]);
        G(ref v[2], ref v[6], ref v[10], ref v[14], m[1], m[9]);
        G(ref v[3], ref v[7], ref v[11], ref v[15], m[8], m[6]);
        G(ref v[0], ref v[5], ref v[10], ref v[15], m[14], m[10]);
        G(ref v[1], ref v[6], ref v[11], ref v[12], m[2], m[12]);
        G(ref v[2], ref v[7], ref v[8], ref v[13], m[3], m[4]);
        G(ref v[3], ref v[4], ref v[9], ref v[14], m[7], m[13]);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void G(ref uint a, ref uint b, ref uint c, ref uint d, uint mx, uint my)
    {
        unchecked
        {
            a = a + b + mx;
            d = BitOperations.RotateRight(d ^ a, 16);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 12);
            a = a + b + my;
            d = BitOperations.RotateRight(d ^ a, 8);
            c = c + d;
            b = BitOperations.RotateRight(b ^ c, 7);
        }
    }
}
