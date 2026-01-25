// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Specifies the mode of operation for BLAKE3.
/// </summary>
public enum Blake3Mode
{
    /// <summary>
    /// Standard hash mode (default).
    /// </summary>
    Hash = 0,

    /// <summary>
    /// Keyed hash mode for message authentication (MAC).
    /// </summary>
    KeyedHash = 1,

    /// <summary>
    /// Key derivation mode for deriving keys from input material.
    /// </summary>
    DeriveKey = 2
}

/// <summary>
/// Computes the BLAKE3 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE3 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE3 is a cryptographic hash function that is much faster than SHA-256 while
/// maintaining high security. It supports variable output length (XOF mode).
/// </para>
/// <para>
/// BLAKE3 supports three modes: standard hashing, keyed hashing (MAC), and key derivation.
/// </para>
/// </remarks>
public sealed class Blake3 : HashAlgorithm
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

    // Number of compression rounds
    private const int Rounds = 7;

    // BLAKE3 flags
    private const uint FlagChunkStart = 1 << 0;
    private const uint FlagChunkEnd = 1 << 1;
    private const uint FlagParent = 1 << 2;
    private const uint FlagRoot = 1 << 3;
    private const uint FlagKeyedHash = 1 << 4;

    // BLAKE3 IV (same as BLAKE2s)
    private static readonly uint[] IV =
    [
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU,
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U
    ];

#if NET8_0_OR_GREATER
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // Rotate right by 16 bits
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vectors
    private static readonly Vector128<uint> IVLow = Vector128.Create(
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU);

    private static readonly Vector128<uint> IVHigh = Vector128.Create(
        0x510e527fU, 0x9b05688cU, 0x1f83d9abU, 0x5be0cd19U);

    // Vector state for SSE path
    private Vector128<uint> _cvVec0;
    private Vector128<uint> _cvVec1;
    private Vector128<uint> _keyVec0;
    private Vector128<uint> _keyVec1;
    private readonly bool _useSsse3;
#endif

    private readonly uint[] _keyWords;
    private readonly uint[] _cv;
    private readonly byte[] _chunkBuffer;
    private readonly List<uint[]> _cvStack;
    private readonly int _outputBytes;
    private readonly Blake3Mode _mode;
    private readonly uint _baseFlags;
    private int _chunkBufferLength;
    private ulong _chunkCounter;
    private int _blocksCompressed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with default output size (32 bytes).
    /// </summary>
    public Blake3() : this(DefaultHashSizeBytes, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Blake3(int outputBytes) : this(outputBytes, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake3(int outputBytes, SimdSupport simdSupport)
    {
        if (outputBytes < 1)
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        _mode = Blake3Mode.Hash;
        _baseFlags = 0;
        HashSizeValue = outputBytes * 8;
        _keyWords = new uint[8];
        _cv = new uint[8];
        _chunkBuffer = new byte[ChunkSizeBytes];
        _cvStack = new List<uint[]>();

#if NET8_0_OR_GREATER
        _useSsse3 = (simdSupport & SimdSupport.Ssse3) != 0 && Ssse3.IsSupported;
#endif

        Initialize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in keyed hash mode.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    private Blake3(byte[] key, int outputBytes) : this(key, outputBytes, SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in keyed hash mode with SIMD support.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    private Blake3(byte[] key, int outputBytes, SimdSupport simdSupport)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be exactly {KeySizeBytes} bytes.", nameof(key));

        if (outputBytes < 1)
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        _mode = Blake3Mode.KeyedHash;
        _baseFlags = FlagKeyedHash;
        HashSizeValue = outputBytes * 8;
        _keyWords = new uint[8];
        _cv = new uint[8];
        _chunkBuffer = new byte[ChunkSizeBytes];
        _cvStack = new List<uint[]>();

#if NET8_0_OR_GREATER
        _useSsse3 = (simdSupport & SimdSupport.Ssse3) != 0 && Ssse3.IsSupported;
#endif

        // Parse key as little-endian uint32 words
        for (int i = 0; i < 8; i++)
        {
            _keyWords[i] = BinaryPrimitives.ReadUInt32LittleEndian(key.AsSpan(i * 4));
        }

#if NET8_0_OR_GREATER
        if (_useSsse3)
        {
            _keyVec0 = Vector128.Create(_keyWords[0], _keyWords[1], _keyWords[2], _keyWords[3]);
            _keyVec1 = Vector128.Create(_keyWords[4], _keyWords[5], _keyWords[6], _keyWords[7]);
        }
#endif

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _mode switch {
        Blake3Mode.KeyedHash => "BLAKE3-Keyed",
        Blake3Mode.DeriveKey => "BLAKE3-DeriveKey",
        _ => "BLAKE3"
    };

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets the mode of operation for this instance.
    /// </summary>
    public Blake3Mode Mode => _mode;

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
            if (Ssse3.IsSupported) support |= SimdSupport.Ssse3;
#endif
            return support;
        }
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE3 instance.</returns>
    public static new Blake3 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance.</returns>
    public static Blake3 Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE3 instance.</returns>
    internal static Blake3 Create(int outputBytes, SimdSupport simdSupport) => new(outputBytes, simdSupport);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    public static Blake3 CreateKeyed(byte[] key) => new(key, DefaultHashSizeBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    public static Blake3 CreateKeyed(byte[] key, int outputBytes) => new(key, outputBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class with specified SIMD support.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    internal static Blake3 CreateKeyed(byte[] key, int outputBytes, SimdSupport simdSupport) => new(key, outputBytes, simdSupport);

    /// <inheritdoc/>
    public override void Initialize()
    {
        if (_mode == Blake3Mode.KeyedHash)
        {
            Array.Copy(_keyWords, _cv, 8);
#if NET8_0_OR_GREATER
            if (_useSsse3)
            {
                _cvVec0 = _keyVec0;
                _cvVec1 = _keyVec1;
            }
#endif
        }
        else
        {
            Array.Copy(IV, _keyWords, 8);
            Array.Copy(IV, _cv, 8);
#if NET8_0_OR_GREATER
            if (_useSsse3)
            {
                _keyVec0 = IVLow;
                _keyVec1 = IVHigh;
                _cvVec0 = IVLow;
                _cvVec1 = IVHigh;
            }
#endif
        }

        _chunkBufferLength = 0;
        _chunkCounter = 0;
        _blocksCompressed = 0;
        _cvStack.Clear();
        ClearBuffer(_chunkBuffer);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        while (offset < source.Length)
        {
            // If chunk buffer is full, finalize the chunk
            if (_chunkBufferLength == ChunkSizeBytes)
            {
                uint[] chunkCv = FinalizeChunk();
                AddChunkToTree(chunkCv);
                _chunkCounter++;
                _chunkBufferLength = 0;
                _blocksCompressed = 0;
#if NET8_0_OR_GREATER
                if (_useSsse3)
                {
                    _cvVec0 = _keyVec0;
                    _cvVec1 = _keyVec1;
                }
                else
#endif
                {
                    Array.Copy(_keyWords, _cv, 8);
                }
            }

            int toCopy = Math.Min(ChunkSizeBytes - _chunkBufferLength, source.Length - offset);
            source.Slice(offset, toCopy).CopyTo(_chunkBuffer.AsSpan(_chunkBufferLength));
            _chunkBufferLength += toCopy;
            offset += toCopy;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = _outputBytes;
        FinalizeAndSqueeze(destination);
        return true;
    }

    /// <summary>
    /// Finalizes the hash and produces output of the specified length.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void FinalizeAndSqueeze(Span<byte> output)
    {
        if (_cvStack.Count == 0 && _chunkCounter == 0)
        {
            // Single chunk case - finalize with root flag
            Span<uint> rootOutput = stackalloc uint[16];
            FinalizeChunkAsRoot(rootOutput);
            ExtractOutput(rootOutput, output);
        }
        else
        {
            Span<uint> rootOutput = stackalloc uint[16];

            // Multi-chunk case - finalize current chunk and add to tree
            uint[] chunkCv = FinalizeChunk();
            _cvStack.Add(chunkCv);

            // Now merge all CVs in the stack
            while (_cvStack.Count > 1)
            {
                uint[] right = _cvStack[^1];
                _cvStack.RemoveAt(_cvStack.Count - 1);
                uint[] left = _cvStack[^1];
                _cvStack.RemoveAt(_cvStack.Count - 1);

                if (_cvStack.Count == 0)
                {
                    // This is the final merge - use ROOT flag and full output
                    ParentOutput(left, right, rootOutput);
                    ExtractOutput(rootOutput, output);
                    return;
                }
                else
                {
                    // Not the final merge - no ROOT flag
                    uint[] parentCv = ParentCv(left, right, isRoot: false);
                    _cvStack.Add(parentCv);
                }
            }

            // Single CV remaining after merges
            if (_cvStack.Count == 1)
            {
                uint[] cv = _cvStack[0];
                ExtractCvAsOutput(cv, output);
            }
        }
    }

    /// <summary>
    /// Produces full output from a parent node with ROOT flag (for XOF output).
    /// </summary>
    private void ParentOutput(uint[] left, uint[] right, Span<uint> result)
    {
        // Concatenate left and right CVs as block input
        Span<byte> block = stackalloc byte[BlockSizeBytes];
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(block.Slice(i * 4), left[i]);
        }
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(block.Slice(32 + i * 4), right[i]);
        }

        uint flags = _baseFlags | FlagParent | FlagRoot;

        Span<uint> v = stackalloc uint[16];
        Span<uint> m = stackalloc uint[16];
        ParseBlock(block, m);

        // Initialize state with key words
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
            result[i] = v[i] ^ v[i + 8];
            result[i + 8] = v[i + 8] ^ _keyWords[i];
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
#if NET8_0_OR_GREATER
            if (_useSsse3)
            {
                _cvVec0 = default;
                _cvVec1 = default;
                _keyVec0 = default;
                _keyVec1 = default;
            }
#endif
            Array.Clear(_keyWords, 0, _keyWords.Length);
            Array.Clear(_cv, 0, _cv.Length);
            ClearBuffer(_chunkBuffer);
            _cvStack.Clear();
        }
        base.Dispose(disposing);
    }

    private uint[] FinalizeChunk()
    {
        Span<byte> block = stackalloc byte[BlockSizeBytes];
        int offset = 0;

        while (offset < _chunkBufferLength)
        {
            int blockLen = Math.Min(BlockSizeBytes, _chunkBufferLength - offset);
            bool isStart = _blocksCompressed == 0;
            bool isEnd = offset + blockLen >= _chunkBufferLength;

            uint flags = _baseFlags;
            if (isStart) flags |= FlagChunkStart;
            if (isEnd) flags |= FlagChunkEnd;

            block.Clear();
            _chunkBuffer.AsSpan(offset, blockLen).CopyTo(block);

            CompressBlock(block, (uint)blockLen, _chunkCounter, flags);
            _blocksCompressed++;
            offset += BlockSizeBytes;
        }

        uint[] result = new uint[8];
#if NET8_0_OR_GREATER
        if (_useSsse3)
        {
            // Extract from vector state
            Span<uint> temp = stackalloc uint[8];
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref temp[0]), _cvVec0);
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref temp[4]), _cvVec1);
            temp.CopyTo(result.AsSpan());
        }
        else
#endif
        {
            Array.Copy(_cv, result, 8);
        }
        return result;
    }

    private void FinalizeChunkAsRoot(Span<uint> result)
    {
        int offset = 0;
        int lastBlockOffset = 0;
        int lastBlockLen = _chunkBufferLength;

        if (_chunkBufferLength == 0)
        {
            lastBlockLen = 0;
        }
        else
        {
            while (lastBlockLen > BlockSizeBytes)
            {
                lastBlockOffset += BlockSizeBytes;
                lastBlockLen -= BlockSizeBytes;
            }
        }

        Span<byte> block = stackalloc byte[BlockSizeBytes];

        // Process all blocks except the last
        while (offset < lastBlockOffset)
        {
            bool isStart = _blocksCompressed == 0;

            uint flags = _baseFlags;
            if (isStart) flags |= FlagChunkStart;

            block.Clear();
            _chunkBuffer.AsSpan(offset, BlockSizeBytes).CopyTo(block);

            CompressBlock(block, BlockSizeBytes, _chunkCounter, flags);
            _blocksCompressed++;
            offset += BlockSizeBytes;
        }

        // Process the last block with root flag
        uint finalFlags = _baseFlags | FlagChunkEnd | FlagRoot;
        if (_blocksCompressed == 0) finalFlags |= FlagChunkStart;

        block.Clear();
        if (lastBlockLen > 0)
        {
            _chunkBuffer.AsSpan(lastBlockOffset, lastBlockLen).CopyTo(block);
        }

        CompressBlockFull(block, (uint)lastBlockLen, _chunkCounter, finalFlags, result);
    }

    private void AddChunkToTree(uint[] chunkCv)
    {
        _cvStack.Add(chunkCv);

        ulong totalChunks = _chunkCounter + 1;
        while ((totalChunks & 1) == 0 && _cvStack.Count >= 2)
        {
            uint[] right = _cvStack[^1];
            _cvStack.RemoveAt(_cvStack.Count - 1);
            uint[] left = _cvStack[^1];
            _cvStack.RemoveAt(_cvStack.Count - 1);

            uint[] parentCv = ParentCv(left, right, isRoot: false);
            _cvStack.Add(parentCv);
            totalChunks >>= 1;
        }
    }

    private uint[] ParentCv(uint[] left, uint[] right, bool isRoot)
    {
        Span<byte> block = stackalloc byte[BlockSizeBytes];
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(block.Slice(i * 4), left[i]);
        }
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(block.Slice(32 + i * 4), right[i]);
        }

        uint flags = _baseFlags | FlagParent;
        if (isRoot) flags |= FlagRoot;

        Span<uint> v = stackalloc uint[16];
        Span<uint> m = stackalloc uint[16];
        ParseBlock(block, m);

        v[0] = _keyWords[0]; v[1] = _keyWords[1]; v[2] = _keyWords[2]; v[3] = _keyWords[3];
        v[4] = _keyWords[4]; v[5] = _keyWords[5]; v[6] = _keyWords[6]; v[7] = _keyWords[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = 0;
        v[13] = 0;
        v[14] = BlockSizeBytes;
        v[15] = flags;

        Compress(v, m);

        uint[] result = new uint[8];
        for (int i = 0; i < 8; i++)
        {
            result[i] = v[i] ^ v[i + 8];
        }
        return result;
    }

    private void CompressBlock(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if (_useSsse3)
        {
            CompressBlockSsse3(block, blockLen, counter, flags);
            return;
        }
#endif

        Span<uint> v = stackalloc uint[16];
        Span<uint> m = stackalloc uint[16];
        ParseBlock(block, m);

        v[0] = _cv[0]; v[1] = _cv[1]; v[2] = _cv[2]; v[3] = _cv[3];
        v[4] = _cv[4]; v[5] = _cv[5]; v[6] = _cv[6]; v[7] = _cv[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = (uint)counter;
        v[13] = (uint)(counter >> 32);
        v[14] = blockLen;
        v[15] = flags;

        Compress(v, m);

        for (int i = 0; i < 8; i++)
        {
            _cv[i] = v[i] ^ v[i + 8];
        }
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
private void CompressBlockSsse3(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags)
    {
        // Parse message block
        Span<uint> m = stackalloc uint[16];
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, uint>(block).CopyTo(m);
        }
        else
        {
            for (int i = 0; i < 16; i++)
            {
                m[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
            }
        }

        // Initialize rows
        var row0 = _cvVec0;
        var row1 = _cvVec1;
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);

        // 7 rounds of mixing with BLAKE3's fixed message schedule
        // Round 1: 0,1,2,3,4,5,6,7 | 8,9,10,11,12,13,14,15
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[0], m[2], m[4], m[6]),
            Vector128.Create(m[1], m[3], m[5], m[7]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[8], m[10], m[12], m[14]),
            Vector128.Create(m[9], m[11], m[13], m[15]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 2: 2,6,3,10,7,0,4,13 | 1,11,12,5,9,14,15,8
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[2], m[3], m[7], m[4]),
            Vector128.Create(m[6], m[10], m[0], m[13]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[1], m[12], m[9], m[15]),
            Vector128.Create(m[11], m[5], m[14], m[8]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 3: 3,4,10,12,13,2,7,14 | 6,5,9,0,11,15,8,1
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[3], m[10], m[13], m[7]),
            Vector128.Create(m[4], m[12], m[2], m[14]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[6], m[9], m[11], m[8]),
            Vector128.Create(m[5], m[0], m[15], m[1]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 4: 10,7,12,9,14,3,13,15 | 4,0,11,2,5,8,1,6
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[10], m[12], m[14], m[13]),
            Vector128.Create(m[7], m[9], m[3], m[15]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[4], m[11], m[5], m[1]),
            Vector128.Create(m[0], m[2], m[8], m[6]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 5: 12,13,9,11,15,10,14,8 | 7,2,5,3,0,1,6,4
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[12], m[9], m[15], m[14]),
            Vector128.Create(m[13], m[11], m[10], m[8]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[7], m[5], m[0], m[6]),
            Vector128.Create(m[2], m[3], m[1], m[4]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 6: 9,14,11,5,8,12,15,1 | 13,3,0,10,2,6,4,7
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[9], m[11], m[8], m[15]),
            Vector128.Create(m[14], m[5], m[12], m[1]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[13], m[0], m[2], m[4]),
            Vector128.Create(m[3], m[10], m[6], m[7]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Round 7: 11,15,5,0,1,9,8,6 | 14,10,2,12,3,4,7,13
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[11], m[5], m[1], m[8]),
            Vector128.Create(m[15], m[0], m[9], m[6]));
        DiagPermuteForward(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[14], m[2], m[3], m[7]),
            Vector128.Create(m[10], m[12], m[4], m[13]));
        DiagPermuteBack(ref row1, ref row2, ref row3);

        // Finalize: cv = row0 ^ row2, cv = row1 ^ row3
        _cvVec0 = Sse2.Xor(row0, row2);
        _cvVec1 = Sse2.Xor(row1, row3);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DiagPermuteForward(ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
        row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
        row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DiagPermuteBack(ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        row1 = Sse2.Shuffle(row1, 0b10_01_00_11); // 3,0,1,2
        row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
        row3 = Sse2.Shuffle(row3, 0b00_11_10_01); // 1,2,3,0
    }

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
        // d = ror(d ^ a, 16)
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8)
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        var t2 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t2, 7), Sse2.ShiftLeftLogical(t2, 25));
    }
#endif

    private void CompressBlockFull(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags, Span<uint> result)
    {
        Span<uint> v = stackalloc uint[16];
        Span<uint> m = stackalloc uint[16];
        ParseBlock(block, m);

#if NET8_0_OR_GREATER
        if (_useSsse3)
        {
            Span<uint> cvTemp = stackalloc uint[8];
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref cvTemp[0]), _cvVec0);
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref cvTemp[4]), _cvVec1);
            v[0] = cvTemp[0]; v[1] = cvTemp[1]; v[2] = cvTemp[2]; v[3] = cvTemp[3];
            v[4] = cvTemp[4]; v[5] = cvTemp[5]; v[6] = cvTemp[6]; v[7] = cvTemp[7];
        }
        else
#endif
        {
            v[0] = _cv[0]; v[1] = _cv[1]; v[2] = _cv[2]; v[3] = _cv[3];
            v[4] = _cv[4]; v[5] = _cv[5]; v[6] = _cv[6]; v[7] = _cv[7];
        }

        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = (uint)counter;
        v[13] = (uint)(counter >> 32);
        v[14] = blockLen;
        v[15] = flags;

        Compress(v, m);

#if NET8_0_OR_GREATER
        if (_useSsse3)
        {
            Span<uint> cvTemp = stackalloc uint[8];
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref cvTemp[0]), _cvVec0);
            Unsafe.WriteUnaligned(ref Unsafe.As<uint, byte>(ref cvTemp[4]), _cvVec1);
            for (int i = 0; i < 8; i++)
            {
                result[i] = v[i] ^ v[i + 8];
                result[i + 8] = v[i + 8] ^ cvTemp[i];
            }
        }
        else
#endif
        {
            for (int i = 0; i < 8; i++)
            {
                result[i] = v[i] ^ v[i + 8];
                result[i + 8] = v[i + 8] ^ _cv[i];
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ParseBlock(ReadOnlySpan<byte> block, Span<uint> m)
    {
#if NET8_0_OR_GREATER
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, uint>(block).CopyTo(m);
            return;
        }
#endif
        for (int i = 0; i < 16; i++)
        {
            m[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void Compress(Span<uint> v, Span<uint> m)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    private static void ExtractOutput(ReadOnlySpan<uint> cv, Span<byte> output)
    {
        int offset = 0;
        int wordIndex = 0;
        Span<byte> temp = stackalloc byte[4];

        while (offset < output.Length && wordIndex < cv.Length)
        {
            int bytesToCopy = Math.Min(4, output.Length - offset);
            if (bytesToCopy == 4)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(output.Slice(offset), cv[wordIndex]);
                offset += 4;
            }
            else
            {
                BinaryPrimitives.WriteUInt32LittleEndian(temp, cv[wordIndex]);
                temp.Slice(0, bytesToCopy).CopyTo(output.Slice(offset));
                offset += bytesToCopy;
            }
            wordIndex++;
        }
    }

    private static void ExtractCvAsOutput(uint[] cv, Span<byte> output)
    {
        int offset = 0;
        Span<byte> temp = stackalloc byte[4];

        for (int i = 0; i < 8 && offset < output.Length; i++)
        {
            int bytesToCopy = Math.Min(4, output.Length - offset);
            if (bytesToCopy == 4)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(output.Slice(offset), cv[i]);
                offset += 4;
            }
            else
            {
                BinaryPrimitives.WriteUInt32LittleEndian(temp, cv[i]);
                temp.Slice(0, bytesToCopy).CopyTo(output.Slice(offset));
                offset += bytesToCopy;
            }
        }
    }
}


