// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// BLAKE3 XOF (extendable-output) implementation using counter-mode output expansion.
/// </summary>
public sealed partial class Blake3
{
    // XOF streaming state: saved root output node for counter-mode squeeze
    private readonly uint[] _rootBlock = new uint[BlockSizeWords];
    private readonly uint[] _rootCv = new uint[KeySizeWords];
    private uint _rootBlockLen;
    private uint _rootFlags;
    private bool _squeezed;
    private ulong _outputCounter;
    private int _squeezeOffset;
    private readonly byte[] _squeezeBuf = new byte[BlockSizeBytes];

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        if (_squeezed) throw new InvalidOperationException("Cannot add data after finalization.");
        HashCore(input);
    }

    /// <inheritdoc/>
    public void Reset()
    {
        Initialize();
    }

    /// <summary>
    /// Finalizes the hash and squeezes output of the specified length.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Squeeze(Span<byte> output)
    {
        if (!_squeezed)
        {
            FinalizeRoot();
            _squeezed = true;
            _outputCounter = 0;
            _squeezeOffset = 0;

            // Fill the first squeeze buffer block (counter = 0)
            _squeezeRootBlock(0, _squeezeBuf);
        }

        int remaining = output.Length;
        int destOffset = 0;

        // Resume from partial block left by a previous Squeeze call
        if (_squeezeOffset > 0 && remaining > 0)
        {
            int available = BlockSizeBytes - _squeezeOffset;
            int toCopy = Math.Min(remaining, available);
            _squeezeBuf.AsSpan(_squeezeOffset, toCopy).CopyTo(output.Slice(destOffset));
            destOffset += toCopy;
            remaining -= toCopy;
            _squeezeOffset += toCopy;

            if (_squeezeOffset == BlockSizeBytes)
            {
                _outputCounter++;
                _squeezeRootBlock(_outputCounter, _squeezeBuf);
                _squeezeOffset = 0;
            }
        }

        // Process full 64-byte output blocks
        while (remaining >= BlockSizeBytes)
        {
            _squeezeBuf.AsSpan(0, BlockSizeBytes).CopyTo(output.Slice(destOffset));
            destOffset += BlockSizeBytes;
            remaining -= BlockSizeBytes;

            _outputCounter++;
            _squeezeRootBlock(_outputCounter, _squeezeBuf);
            _squeezeOffset = 0;
        }

        // Handle trailing partial block
        if (remaining > 0)
        {
            _squeezeBuf.AsSpan(0, remaining).CopyTo(output.Slice(destOffset));
            _squeezeOffset = remaining;
        }
    }

    /// <summary>
    /// Finalizes the tree hash and saves the root output node parameters for counter-mode XOF.
    /// </summary>
    private void FinalizeRoot()
    {
        if (_cvStackDepth == 0 && _chunkCounter == 0)
        {
            // Single chunk case
            SaveChunkAsRoot();
        }
        else
        {
            // Multi-chunk case - finalize current chunk and push onto stack
            FinalizeChunk(_cvStackBuf.AsSpan(_cvStackDepth * 8, 8));
            _cvStackDepth++;

            // Merge all CVs in the stack
            while (_cvStackDepth > 1)
            {
                ReadOnlySpan<uint> left = _cvStackBuf.AsSpan((_cvStackDepth - 2) * 8, 8);
                ReadOnlySpan<uint> right = _cvStackBuf.AsSpan((_cvStackDepth - 1) * 8, 8);

                if (_cvStackDepth == 2)
                {
                    SaveParentAsRoot(left, right);
                    return;
                }

                ComputeParentCv(left, right, _cvStackBuf.AsSpan((_cvStackDepth - 2) * 8, 8));
                _cvStackDepth--;
            }

            // Single CV remaining — treat as parent root with zero right child
            if (_cvStackDepth == 1)
            {
                Span<uint> zeroRight = stackalloc uint[8];
                SaveParentAsRoot(_cvStackBuf.AsSpan(0, 8), zeroRight);
            }
        }
    }

    /// <summary>
    /// Saves the single-chunk root node parameters for counter-mode output.
    /// </summary>
    private void SaveChunkAsRoot()
    {
        // Compute last block boundary via integer math
        int lastBlockOffset = (_chunkBufferLength <= BlockSizeBytes) ? 0
            : (_chunkBufferLength - 1) / BlockSizeBytes * BlockSizeBytes;
        int lastBlockLen = _chunkBufferLength - lastBlockOffset;

        // Process all blocks except the last — compress directly from chunk buffer
        int offset = 0;
        while (offset < lastBlockOffset)
        {
            uint flags = _baseFlags;
            if (_blocksCompressed == 0) flags |= FlagChunkStart;

            _compressBlock(_chunkBuffer.AsSpan(offset, BlockSizeBytes), BlockSizeBytes, _chunkCounter, flags);
            _blocksCompressed++;
            offset += BlockSizeBytes;
        }

        // Save root parameters from the last block
        uint finalFlags = _baseFlags | FlagChunkEnd | FlagRoot;
        if (_blocksCompressed == 0) finalFlags |= FlagChunkStart;

        if (lastBlockLen == BlockSizeBytes)
        {
            // Full last block: read directly from chunk buffer
            CopyBlockUInt32LittleEndian(_chunkBuffer.AsSpan(lastBlockOffset, BlockSizeBytes), _rootBlock);
        }
        else
        {
            // Partial last block: stackalloc is zero-initialized for padding
            Span<byte> block = stackalloc byte[BlockSizeBytes];
            if (lastBlockLen > 0)
            {
                _chunkBuffer.AsSpan(lastBlockOffset, lastBlockLen).CopyTo(block);
            }

            CopyBlockUInt32LittleEndian(block, _rootBlock);
        }

        Array.Copy(_cv, _rootCv, KeySizeWords);
        _rootBlockLen = (uint)lastBlockLen;
        _rootFlags = finalFlags;
    }

    /// <summary>
    /// Saves a parent merge as the root node for counter-mode output.
    /// </summary>
    private void SaveParentAsRoot(ReadOnlySpan<uint> left, ReadOnlySpan<uint> right)
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

        CopyBlockUInt32LittleEndian(block, _rootBlock);
        Array.Copy(_keyWords, _rootCv, KeySizeWords);
        _rootBlockLen = BlockSizeBytes;
        _rootFlags = _baseFlags | FlagParent | FlagRoot;
    }


    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlockScalar(ulong counter, Span<byte> destination)
    {
        Span<uint> v = stackalloc uint[BlockSizeWords];
        v[0] = _rootCv[0]; v[1] = _rootCv[1]; v[2] = _rootCv[2]; v[3] = _rootCv[3];
        v[4] = _rootCv[4]; v[5] = _rootCv[5]; v[6] = _rootCv[6]; v[7] = _rootCv[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = (uint)counter;
        v[13] = (uint)(counter >> 32);
        v[14] = _rootBlockLen;
        v[15] = _rootFlags;

        Span<uint> m = stackalloc uint[BlockSizeWords];
        _rootBlock.AsSpan().CopyTo(m);

        Compress(v, m);

        // Full 16-word output: v[i] ^ v[i+8] || v[i+8] ^ rootCv[i]
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * 4), v[i] ^ v[i + 8]);
        }
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(32 + i * 4), v[i + 8] ^ _rootCv[i]);
        }
    }
}
