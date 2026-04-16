// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// BLAKE3 XOF (extendable-output) implementation using counter-mode output expansion.
/// </summary>
internal unsafe partial struct Blake3State
{
    /// <summary>
    /// Finalizes the hash and squeezes output of the specified length.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal void Squeeze(Span<byte> output)
    {
        fixed (Blake3State* core = &this)
        {
            var destination = new Span<byte>(core->_squeezeBuf, BlockSizeBytes);
            if (!_squeezed)
            {
                FinalizeRoot();
                _squeezed = true;
                _outputCounter = 0;
                _squeezeOffset = 0;

                // Fill the first squeeze buffer block (counter = 0)
                SqueezeRootBlock(0, destination);
            }

            int remaining = output.Length;
            int destOffset = 0;

            // Resume from partial block left by a previous Squeeze call
            if (_squeezeOffset > 0 && remaining > 0)
            {
                int available = BlockSizeBytes - _squeezeOffset;
                int toCopy = Math.Min(remaining, available);
                Unsafe.CopyBlockUnaligned(
                    ref MemoryMarshal.GetReference(output.Slice(destOffset)),
                    ref core->_squeezeBuf[_squeezeOffset],
                    (uint)toCopy);
                destOffset += toCopy;
                remaining -= toCopy;
                _squeezeOffset += toCopy;

                if (_squeezeOffset == BlockSizeBytes)
                {
                    _outputCounter++;
                    SqueezeRootBlock(_outputCounter, destination);
                    _squeezeOffset = 0;
                }
            }

            // Process full 64-byte output blocks
            while (remaining >= BlockSizeBytes)
            {
                Unsafe.CopyBlockUnaligned(
                    ref MemoryMarshal.GetReference(output.Slice(destOffset)),
                    ref core->_squeezeBuf[0],
                    BlockSizeBytes);
                destOffset += BlockSizeBytes;
                remaining -= BlockSizeBytes;

                _outputCounter++;
                SqueezeRootBlock(_outputCounter, destination);
                _squeezeOffset = 0;
            }

            // Handle trailing partial block
            if (remaining > 0)
            {
                Unsafe.CopyBlockUnaligned(
                    ref MemoryMarshal.GetReference(output.Slice(destOffset)),
                    ref core->_squeezeBuf[0],
                    (uint)remaining);
                _squeezeOffset = remaining;
            }
        }
    }

    /// <summary>
    /// Finalizes the root hash computation by processing any remaining chunks
    /// and combining all chaining values into the final root output.
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
            fixed (Blake3State* core = &this)
            {
                FinalizeChunk(core, core->_cvStackBuf + _cvStackDepth * 8);

                _cvStackDepth++;

                // Merge all CVs in the stack
                while (_cvStackDepth > 1)
                {
                    uint* left = core->_cvStackBuf + (_cvStackDepth - 2) * 8;
                    uint* right = core->_cvStackBuf + (_cvStackDepth - 1) * 8;

                    if (_cvStackDepth == 2)
                    {
                        SaveParentAsRoot(core, left, right);
                        return;
                    }

                    ComputeParentCv(left, right, left);

                    _cvStackDepth--;
                }

                // Single CV remaining — treat as parent root with zero right child
                if (_cvStackDepth == 1)
                {
                    uint* zr = stackalloc uint[8];
                    SaveParentAsRoot(core, core->_cvStackBuf, zr);
                }
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

        fixed (Blake3State* core = &this)
        {
            // Process all blocks except the last — compress directly from chunk buffer
            byte* p = core->_chunkBuffer;
            byte* pEnd = p + lastBlockOffset;
            while (p < pEnd)
            {
                uint flags = _baseFlags;
                if (_blocksCompressed == 0)
                {
                    flags |= FlagChunkStart;
                }

                CompressBlock(core->_cv, p, BlockSizeBytes, _chunkCounter, flags);

                _blocksCompressed++;
                p += BlockSizeBytes;
            }

            // Save root parameters from the last block
            uint finalFlags = _baseFlags | FlagChunkEnd | FlagRoot;
            if (_blocksCompressed == 0)
            {
                finalFlags |= FlagChunkStart;
            }

            uint* rb = core->_rootBlock;
            if (lastBlockLen == BlockSizeBytes)
            {
                // Full last block: read directly from chunk buffer
                BinarySpans.ReadUInt32LittleEndian(core->_chunkBuffer + lastBlockOffset, rb, BlockSizeWords);
            }
            else
            {
                // Partial last block: stackalloc is zero-initialized for padding
                byte* block = stackalloc byte[BlockSizeBytes];
                if (lastBlockLen > 0)
                {
                    Unsafe.CopyBlockUnaligned(ref *block, ref core->_chunkBuffer[lastBlockOffset], (uint)lastBlockLen);
                }

                BinarySpans.ReadUInt32LittleEndian(block, rb, BlockSizeWords);
            }

            Unsafe.CopyBlock(core->_rootCv, core->_cv, KeySizeWords * (uint)sizeof(uint));

            _rootBlockLen = (uint)lastBlockLen;
            _rootFlags = finalFlags;
        }
    }

    /// <summary>
    /// Saves a parent merge as the root node for counter-mode output.
    /// </summary>
    private void SaveParentAsRoot(Blake3State* core, uint* left, uint* right)
    {
        // Copy left[8] and right[8] directly into _rootBlock[16]
        Unsafe.CopyBlock(core->_rootBlock, left, 8 * (uint)sizeof(uint));
        Unsafe.CopyBlock(&core->_rootBlock[8], right, 8 * (uint)sizeof(uint));
        Unsafe.CopyBlock(core->_rootCv, core->_keyWords, KeySizeWords * (uint)sizeof(uint));
        _rootBlockLen = BlockSizeBytes;
        _rootFlags = _baseFlags | FlagParent | FlagRoot;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void SqueezeRootBlock(ulong counter, Span<byte> destination)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Ssse3) != 0)
        {
            SqueezeRootBlockSsse3(counter, destination);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            SqueezeRootBlockNeon(counter, destination);
        }
        else
#endif
        {
            SqueezeRootBlockScalar(counter, destination);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlockScalar(ulong counter, Span<byte> destination)
    {
        uint* v = stackalloc uint[BlockSizeWords];
        v[0] = _rootCv[0]; v[1] = _rootCv[1]; v[2] = _rootCv[2]; v[3] = _rootCv[3];
        v[4] = _rootCv[4]; v[5] = _rootCv[5]; v[6] = _rootCv[6]; v[7] = _rootCv[7];
        v[8] = IV[0]; v[9] = IV[1]; v[10] = IV[2]; v[11] = IV[3];
        v[12] = (uint)counter;
        v[13] = (uint)(counter >> 32);
        v[14] = _rootBlockLen;
        v[15] = _rootFlags;

        fixed (uint* rb = _rootBlock)
        {
            Compress(v, rb);
        }

        // Full 16-word output: v[i] ^ v[i+8] || v[i+8] ^ rootCv[i]
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * sizeof(uint)), v[i] ^ v[i + 8]);
        }
        for (int i = 0; i < 8; i++)
        {
            BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(32 + i * sizeof(uint)), v[i + 8] ^ _rootCv[i]);
        }
    }
}
