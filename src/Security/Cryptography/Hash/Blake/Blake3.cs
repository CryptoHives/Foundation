// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

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
    public Blake3() : this(DefaultHashSizeBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Blake3(int outputBytes)
    {
        if (outputBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        _mode = Blake3Mode.Hash;
        _baseFlags = 0;
        HashSizeValue = outputBytes * 8;
        _keyWords = new uint[8];
        _cv = new uint[8];
        _chunkBuffer = new byte[ChunkSizeBytes];
        _cvStack = new List<uint[]>();
        Initialize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in keyed hash mode.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    private Blake3(byte[] key, int outputBytes)
    {
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (key.Length != KeySizeBytes)
        {
            throw new ArgumentException($"Key must be exactly {KeySizeBytes} bytes.", nameof(key));
        }

        if (outputBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        _mode = Blake3Mode.KeyedHash;
        _baseFlags = FlagKeyedHash;
        HashSizeValue = outputBytes * 8;
        _keyWords = new uint[8];
        _cv = new uint[8];
        _chunkBuffer = new byte[ChunkSizeBytes];
        _cvStack = new List<uint[]>();

        // Parse key as little-endian uint32 words
        for (int i = 0; i < 8; i++)
        {
            _keyWords[i] = BinaryPrimitives.ReadUInt32LittleEndian(key.AsSpan(i * 4));
        }

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

    /// <inheritdoc/>
    public override void Initialize()
    {
        if (_mode == Blake3Mode.KeyedHash)
        {
            Array.Copy(_keyWords, _cv, 8);
        }
        else
        {
            Array.Copy(IV, _keyWords, 8);
            Array.Copy(IV, _cv, 8);
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
                Array.Copy(_keyWords, _cv, 8);
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

            // We shouldn't get here with multi-chunk, but just in case
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
        Array.Copy(_cv, result, 8);
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

    private void CompressBlockFull(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags, Span<uint> result)
    {
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
            result[i] = v[i] ^ v[i + 8];
            result[i + 8] = v[i + 8] ^ _cv[i];
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ParseBlock(ReadOnlySpan<byte> block, Span<uint> m)
    {
        for (int i = 0; i < 16; i++)
        {
            m[i] = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(i * 4));
        }
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
#endif
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
            d = RotateRight(d ^ a, 16);
            c = c + d;
            b = RotateRight(b ^ c, 12);
            a = a + b + my;
            d = RotateRight(d ^ a, 8);
            c = c + d;
            b = RotateRight(b ^ c, 7);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateRight(uint x, int n) => BitOperations.RotateRight(x, n);
}
