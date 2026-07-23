// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

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
            byte* dst = core->_squeezeBuf;
            if (!_squeezed)
            {
                FinalizeRoot(core);
                _squeezed = true;
                _outputCounter = 0;
                _squeezeOffset = 0;

                // Fill the first squeeze buffer block (counter = 0)
                SqueezeRootBlock(core, 0, dst);
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
                    SqueezeRootBlock(core, _outputCounter, dst);
                    _squeezeOffset = 0;
                }
            }

            // Process full 64-byte output blocks. Unlike chunk compression,
            // squeeze blocks have no chaining dependency on each other — each
            // is an independent function of (_rootCv, _rootBlock, counter) —
            // so instead of one SqueezeRootBlock call per block (each reloading
            // _rootCv/_rootBlock and round-tripping through _squeezeBuf), batch
            // everything but the already-buffered current block and the
            // look-ahead block directly into the caller's span.
            int fullBlocks = remaining / BlockSizeBytes;
            if (fullBlocks > 0)
            {
                // Block _outputCounter is already sitting in _squeezeBuf from
                // the previous iteration/call — just copy it out.
                Unsafe.CopyBlockUnaligned(
                    ref MemoryMarshal.GetReference(output.Slice(destOffset)),
                    ref core->_squeezeBuf[0],
                    BlockSizeBytes);
                destOffset += BlockSizeBytes;
                remaining -= BlockSizeBytes;

                int extraBlocks = fullBlocks - 1;
                if (extraBlocks > 0)
                {
                    fixed (byte* extraDst = output.Slice(destOffset, extraBlocks * BlockSizeBytes))
                    {
                        SqueezeRootBlocks(core, _outputCounter + 1, extraBlocks, extraDst);
                    }

                    destOffset += extraBlocks * BlockSizeBytes;
                    remaining -= extraBlocks * BlockSizeBytes;
                }

                _outputCounter += (ulong)fullBlocks;

                // Look-ahead: prime _squeezeBuf with the next block for a
                // trailing partial read below, or a future Squeeze call.
                SqueezeRootBlock(core, _outputCounter, dst);
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
    private void FinalizeRoot(Blake3State* core)
    {
        if (_cvStackDepth == 0 && _chunkCounter == 0)
        {
            // Single chunk case — source is the incremental chunk buffer,
            // rather than the caller's own source span (see SaveChunkAsRootFromSource).
            SaveChunkAsRoot(core, core->_chunkBuffer, _chunkBufferLength);
        }
        else
        {
            // Multi-chunk case - finalize current chunk and push onto stack
#if NET8_0_OR_GREATER
            // A bulk SIMD path (AVX2 batching) may have already computed the
            // pending chunk's CV without being able to commit it to the tree
            // yet (see Append) — use it directly instead of re-deriving it
            // from _chunkBuffer/_cv, which wouldn't hold this chunk's data.
            if (_hasPendingCv)
            {
                Unsafe.CopyBlock(core->_cvStackBuf + _cvStackDepth * 8, core->_pendingCv, KeySizeWords * (uint)sizeof(uint));
            }
            else
#endif
            {
                FinalizeChunk(core, core->_cvStackBuf + _cvStackDepth * 8);
            }

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

                // left/right are adjacent stack slots — the contiguous
                // 64-byte parent block ComputeParentCv reads directly.
                ComputeParentCv(left, core->_keyWords, left);

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

    /// <summary>
    /// Saves the single-chunk root node parameters for counter-mode output, for a
    /// message that is at most one chunk. Serves both the streaming case (source =
    /// the incremental <c>_chunkBuffer</c>, once a chunk is known to be the last)
    /// and the one-shot case (source = the caller's own buffer directly, so a
    /// single call never pays the byte-copy-in that streaming <see cref="Blake3State.Append"/>
    /// requires to support resuming across multiple calls).
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>[SkipLocalsInit]</c>: this runs once for every hash of at most one chunk,
    /// so skipping the 64-byte block zeroing matters for small inputs; the padding
    /// tail is zeroed explicitly in the partial-block branch instead.
    /// </para>
    /// <para>
    /// Requires <c>_chunkCounter == 0</c> and <c>_cv</c> holding the IV or key —
    /// true both for a freshly-buffered single chunk and for the one-shot source
    /// case, where the caller must not have appended any data first.
    /// </para>
    /// </remarks>
    [SkipLocalsInit]
    private void SaveChunkAsRoot(Blake3State* core, byte* srcPtr, int length)
    {
        int lastBlockOffset = (length <= BlockSizeBytes) ? 0
            : (length - 1) / BlockSizeBytes * BlockSizeBytes;
        int lastBlockLen = length - lastBlockOffset;

        uint flags = _baseFlags | FlagChunkStart;

        // Process all blocks except the last — compress directly from the source
        byte* p = srcPtr;
        byte* pEnd = srcPtr + lastBlockOffset;
        if (p < pEnd)
        {
            int blocks = lastBlockOffset / BlockSizeBytes;
            CompressBlocks(core->_cv, p, blocks, BlockSizeBytes, _chunkCounter, flags);

            p = pEnd;
            flags = _baseFlags;
        }

        uint finalFlags = flags | FlagChunkEnd | FlagRoot;

        uint* rb = core->_rootBlock;
        if (BitConverter.IsLittleEndian)
        {
            Unsafe.CopyBlockUnaligned(ref *(byte*)rb, ref *pEnd, (uint)lastBlockLen);
            Unsafe.InitBlockUnaligned((byte*)rb + lastBlockLen, 0, (uint)(BlockSizeBytes - lastBlockLen));
        }
        else
        {
            byte* block = stackalloc byte[BlockSizeBytes];
            Unsafe.CopyBlockUnaligned(ref *block, ref *pEnd, (uint)lastBlockLen);
            Unsafe.InitBlockUnaligned(block + lastBlockLen, 0, (uint)(BlockSizeBytes - lastBlockLen));
            BinarySpans.ReadUInt32LittleEndian(block, rb, BlockSizeWords);
        }

        Unsafe.CopyBlock(core->_rootCv, core->_cv, KeySizeWords * (uint)sizeof(uint));

        _rootBlockLen = (uint)lastBlockLen;
        _rootFlags = finalFlags;
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
    private void SqueezeRootBlock(Blake3State* core, ulong counter, byte* dst)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Ssse3 | SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            SqueezeRootBlocksSsse3(core, counter, 1, dst);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            SqueezeRootBlocksNeon(core, counter, 1, dst);
        }
        else
#endif
        {
            SqueezeRootBlocksScalar(core, counter, 1, dst);
        }
    }

    /// <summary>
    /// Squeezes <paramref name="blocks"/> consecutive, independent output blocks
    /// (counters <paramref name="startCounter"/>.. <paramref name="startCounter"/>
    /// + <paramref name="blocks"/> - 1) directly into <paramref name="dst"/>
    /// in one call.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Unlike chunk compression, squeeze blocks have no chaining dependency on
    /// each other — every block is an independent function of
    /// (<c>_rootCv</c>, <c>_rootBlock</c>, counter) — so batching here means
    /// each per-tier kernel loads <c>_rootCv</c>/<c>_rootBlock</c> once instead
    /// of once per block, and writes straight into the caller's span instead of
    /// round-tripping through <c>_squeezeBuf</c>.
    /// </para>
    /// <para>
    /// On AVX2/AVX512F hardware, that same independence lets
    /// <c>SqueezeRootBlocks8Avx2</c> compute 8 output blocks *in
    /// parallel* across lanes (keyed on counter instead of chunk content) —
    /// full groups of 8 go through that kernel, and any 0-7 leftover blocks
    /// fall back to the single-lane SSSE3 kernel. There's no AVX-512-specific
    /// 16-lane squeeze kernel (yet): <c>CompressVector512</c> only exposes the
    /// folded 8-word CV, not the second output half a full squeeze block
    /// needs, and duplicating its round schedule to add that risks the
    /// register-pressure-sensitive chunk-compression hot path for a tier that
    /// already benefits from the AVX2-width kernel here.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void SqueezeRootBlocks(Blake3State* core, ulong startCounter, int blocks, byte* dst)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            int offset = 0;
            int fullGroups = blocks / ChunksPerAvx2Batch;
            for (int g = 0; g < fullGroups; g++)
            {
                SqueezeRootBlocks8Avx2(
                    core,
                    startCounter + (ulong)(g * ChunksPerAvx2Batch),
                    dst + offset);
                offset += ChunksPerAvx2Batch * BlockSizeBytes;
            }

            int remaining = blocks - fullGroups * ChunksPerAvx2Batch;
            if (remaining > 0)
            {
                SqueezeRootBlocksSsse3(
                    core, startCounter + (ulong)(fullGroups * ChunksPerAvx2Batch), remaining, dst + offset);
            }
        }
        else if ((_simdSupport & SimdSupport.Ssse3) != 0)
        {
            SqueezeRootBlocksSsse3(core, startCounter, blocks, dst);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            int offset = 0;
            int fullGroups = blocks / ChunksPerNeonBatch;
            for (int g = 0; g < fullGroups; g++)
            {
                SqueezeRootBlocks4Neon(
                    core,
                    startCounter + (ulong)(g * ChunksPerNeonBatch),
                    dst + offset);
                offset += ChunksPerNeonBatch * BlockSizeBytes;
            }

            int remaining = blocks - fullGroups * ChunksPerNeonBatch;
            if (remaining > 0)
            {
                SqueezeRootBlocksNeon(
                    core, startCounter + (ulong)(fullGroups * ChunksPerNeonBatch), remaining, dst + offset);
            }
        }
        else
#endif
        {
            SqueezeRootBlocksScalar(core, startCounter, blocks, dst);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlocksScalar(Blake3State* core, ulong startCounter, int blocks, byte* dst)
    {
        uint* v = stackalloc uint[BlockSizeWords];
        uint blockLen = _rootBlockLen;
        uint flags = _rootFlags;

        // Raw pointer stores instead of Span.Slice: the caller always sizes
        // destination to exactly blocks * BlockSizeBytes, but that guarantee
        // isn't visible across the call boundary, so Slice would otherwise
        // re-check bounds on every block.
        for (int i = 0; i < blocks; i++)
        {
            ulong counter = startCounter + (ulong)i;

            Unsafe.CopyBlock(v, core->_rootCv, KeySizeWords * (uint)sizeof(uint));
            v[8] = IV0; v[9] = IV1; v[10] = IV2; v[11] = IV3;
            v[12] = (uint)counter;
            v[13] = (uint)(counter >> 32);
            v[14] = blockLen;
            v[15] = flags;

            Compress(v, core->_rootBlock);

            for (int j = 0; j < 8; j++)
            {
                v[j] ^= v[j + 8];
                v[j + 8] ^= core->_rootCv[j];
            }

            BinarySpans.WriteUInt32LittleEndian(v, dst + i * BlockSizeBytes, BlockSizeWords);
        }
    }
}
