// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
#endif
using System.Threading;

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

    // BLAKE3 IV
    internal const uint IV0 = 0x6a09e667U;
    internal const uint IV1 = 0xbb67ae85U;
    internal const uint IV2 = 0x3c6ef372U;
    internal const uint IV3 = 0xa54ff53aU;
    internal const uint IV4 = 0x510e527fU;
    internal const uint IV5 = 0x9b05688cU;
    internal const uint IV6 = 0x1f83d9abU;
    internal const uint IV7 = 0x5be0cd19U;

#if NET8_0_OR_GREATER
    // ReadOnlySpan collection expression compiles to an RVA data blob — avoids
    // a static-field + array dereference on every per-block compress call.
    internal static ReadOnlySpan<uint> IV =>
    [
        IV0, IV1, IV2, IV3,
        IV4, IV5, IV6, IV7,
    ];
#else
    private static readonly uint[] s_IV = new uint[] {
        IV0, IV1, IV2, IV3,
        IV4, IV5, IV6, IV7,
    };

    internal static ReadOnlySpan<uint> IV => s_IV;
#endif

    // Field order groups co-accessed state for cache locality: hot per-call
    // scalars, key, and the root/finalize cluster used by the <=1024-byte
    // one-shot path come first; streaming-only and XOF-only buffers follow.

    // Hot per-call state
    private int _cvStackDepth;
    private int _chunkBufferLength;
    private ulong _chunkCounter;
    private int _blocksCompressed;
    private readonly int _outputBytes;
    private readonly uint _baseFlags;
    private readonly SimdSupport _simdSupport;

    private fixed uint _keyWords[KeySizeWords];
    private fixed uint _cv[KeySizeWords];

    // Root/finalize cluster — see field-order comment above.
    private fixed uint _rootBlock[BlockSizeWords];
    private fixed uint _rootCv[KeySizeWords];
    private uint _rootBlockLen;
    private uint _rootFlags;

#if NET8_0_OR_GREATER
    // Chaining value for a chunk that a bulk SIMD batch computed but couldn't yet
    // commit to the tree — unknown at the time whether it's the true last
    // chunk (see FinalizeRoot). Distinct from _cv, the in-progress accumulator
    // for a chunk still being buffered byte-by-byte.
    private fixed uint _pendingCv[KeySizeWords];
    private bool _hasPendingCv;
#endif

    // Bulk buffers (streaming/multi-chunk path only)
    private fixed byte _chunkBuffer[ChunkSizeBytes];
    private fixed uint _cvStackBuf[MaxStackDepth * 8];

    // XOF squeeze state (only touched when output exceeds one block)
    private fixed byte _squeezeBuf[BlockSizeBytes];
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
        _baseFlags = FlagKeyedHash;
        _simdSupport = SimdSupport.None;
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
#endif

        fixed (Blake3State* core = &this)
        {
            BinarySpans.ReadUInt32LittleEndian(key, new Span<uint>(core->_keyWords, KeySizeWords));
        }

        InitializeKeyed();
    }

    public bool Squeezed => _squeezed;

    /// <inheritdoc/>
    public void Reset(bool keyedMode)
    {
        // InitializeHash/InitializeKeyed already call ResetCommonState — don't
        // pay for it twice on every Reset (constructors rely on that same call).
        if (!keyedMode)
        {
            InitializeHash();
        }
        else
        {
            InitializeKeyed();
        }
    }

    /// <inheritdoc/>
    /// <remarks>
    /// <c>[SkipLocalsInit]</c>: the stack squeeze buffer is fully overwritten by
    /// <see cref="SqueezeRootBlock"/> (all variants write the complete 64-byte block)
    /// before any bytes are copied out.
    /// </remarks>
    [SkipLocalsInit]
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
            fixed (Blake3State* core = &this)
            {
                // Fast path: output fits in a single squeeze block — write directly to destination
                FinalizeRoot(core);
                _squeezed = true;
                byte* buf = stackalloc byte[BlockSizeBytes];
                SqueezeRootBlock(core, 0, buf);
                Unsafe.CopyBlockUnaligned(ref destination[0], ref buf[0], (uint)_outputBytes);
                return true;
            }
        }

        Squeeze(destination);
        return true;
    }

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> in a single call,
    /// without the incremental-hashing bookkeeping that streaming
    /// <see cref="Append(ReadOnlySpan{byte})"/> + <see cref="TryGetCurrentHash"/> pay to support
    /// resuming across multiple calls.
    /// </summary>
    /// <remarks>
    /// Requires a freshly-initialized state — the caller must not have appended
    /// any data first (matching the same precondition as constructing a new
    /// instance). For inputs of at most one chunk, this compresses directly from
    /// <paramref name="source"/> with no <c>_chunkBuffer</c> copy at all — the
    /// dominant fixed cost of the streaming path at small sizes. Larger inputs
    /// reuse the existing batched <see cref="Append(ReadOnlySpan{byte})"/>/<see cref="TryGetCurrentHash"/>
    /// machinery, which already amortizes any bookkeeping over many chunks.
    /// </remarks>
    public bool TryHashOneShot(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = _outputBytes;

        if (source.Length <= ChunkSizeBytes)
        {
            TryHashOneShotSingleChunk(source, destination);
            return true;
        }

        Append(source);
        return TryGetCurrentHash(destination, out bytesWritten);
    }

    // OptimizedLoop keeps this cold path's stackalloc/squeeze code out of the
    // hot large-input branch's icache footprint.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void TryHashOneShotSingleChunk(ReadOnlySpan<byte> source, Span<byte> destination)
    {
        fixed (Blake3State* core = &this)
        {
            fixed (byte* srcPtr = source)
            {
                SaveChunkAsRoot(core, srcPtr, source.Length);
            }

            if (_outputBytes <= BlockSizeBytes)
            {
                byte* buf = stackalloc byte[BlockSizeBytes];
                SqueezeRootBlock(core, 0, buf);
                Unsafe.CopyBlockUnaligned(ref destination[0], ref buf[0], (uint)_outputBytes);
            }
            else
            {
                // Prime the squeeze buffer exactly as the (!_squeezed) branch of
                // Squeeze() would, then mark squeezed so it resumes from here
                // instead of re-deriving the root from _chunkBuffer.
                SqueezeRootBlock(core, 0, core->_squeezeBuf);

                _squeezed = true;
                _outputCounter = 0;
                _squeezeOffset = 0;
                Squeeze(destination.Slice(0, _outputBytes));
            }
        }
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
            Append(MemoryMarshal.AsBytes(segment.Span));
        }
    }

    /// <inheritdoc/>
    /// <remarks>
    /// <c>[SkipLocalsInit]</c>: the <c>batchCvs</c> stack buffers (up to 2 KB,
    /// otherwise zeroed on every batched call) are fully overwritten by the SIMD
    /// chunk kernels before the commit loops read them.
    /// <c>AggressiveOptimization</c>: this method's own batch-loop scaffolding
    /// (offset arithmetic, tier dispatch) would otherwise run under quick-JIT
    /// (Tier 0) on early calls before tiering-up or OSR promotes it, even though
    /// the SIMD kernels it calls are already forced to full optimization.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Append(ReadOnlySpan<byte> source)
    {
        fixed (Blake3State* core = &this)
        fixed (byte* srcPtr = source)
        {
            int length = source.Length;
            int offset = 0;

#if NET8_0_OR_GREATER
            // A prior call may have left the last batch chunk pending (see
            // below) since it didn't know whether more data would follow. New
            // bytes prove it wasn't the final chunk, so commit it now.
            if (_hasPendingCv && length > 0)
            {
                Unsafe.CopyBlock(core->_cvStackBuf + _cvStackDepth * 8, core->_pendingCv, KeySizeWords * (uint)sizeof(uint));
                AddChunkToTree(core);
                _chunkCounter++;
                _hasPendingCv = false;
            }

            // Shared scratch buffer for every chunk-parallel path below, sized
            // for the largest need (64-chunk subtree group, 2 KB). Declared
            // once here, outside the RestartBatching loop.
            uint* batchCvs = stackalloc uint[ChunksPerSubtreeGroup * KeySizeWords];

            // The batched paths only apply at a chunk boundary. The scalar
            // loop's finalize step jumps back here if unaligned buffers
            // are processed and the chunk buffer is empty again.
        RestartBatching:
            if (_chunkBufferLength == 0)
            {
                // Helps to not JIT this branch on Arm
                if (Avx512F.IsSupported)
                {
                    // Groups of 16 independent chunks compressed together. A
                    // batch that exactly drains the input holds back its last
                    // chunk as pending instead of committing it (see FinalizeRoot).
                    if ((_simdSupport & SimdSupport.Avx512F) != 0 &&
                        length - offset >= Avx512BatchSizeBytes)
                    {
                        // 64-chunk subtree groups: 4 batches reduce to one CV,
                        // one tree push per 64 KB. Strictly-greater guard keeps
                        // the group clear of the message tail.
                        while ((_chunkCounter & (ChunksPerSubtreeGroup - 1)) == 0 &&
                            length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes)
                        {
                            offset = CompressSubtreeGroup(core, srcPtr, offset, ChunksPerAvx512Batch,
                                Avx512BatchSizeBytes, batchCvs, &CompressChunksPartialAvx512);
                        }

                        while (length - offset >= Avx512BatchSizeBytes)
                        {
                            CompressChunksPartialAvx512(srcPtr + offset, ChunksPerAvx512Batch, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);

                            bool drainsRemainingInput = offset + Avx512BatchSizeBytes == length;

                            if (!drainsRemainingInput && (_chunkCounter & (ChunksPerAvx512Batch - 1)) == 0)
                            {
                                // Complete, aligned 16-chunk subtree, not the
                                // tail: reduce and push one tree node instead
                                // of 16 serial single-chunk commits.
                                ReduceChunkCvsToSubtreeCvAvx2(batchCvs, core->_keyWords, ChunksPerAvx512Batch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 4);
                                _chunkCounter += ChunksPerAvx512Batch;
                            }
                            else
                            {
                                int firstChunk = 0;
                                if (drainsRemainingInput && (_chunkCounter & (ChunksPerAvx2Batch - 1)) == 0)
                                {
                                    // Even in the final batch, the first 8 chunks form
                                    // an aligned complete subtree (chunks 8..15 follow
                                    // them, so none can be the message tail): reduce
                                    // them wide; only the last 7 commit serially. The
                                    // in-place reduction never writes past the first
                                    // 8 CV slots, so CVs 8..15 stay intact.
                                    ReduceChunkCvsToSubtreeCvAvx2(batchCvs, core->_keyWords, ChunksPerAvx2Batch, _baseFlags);
                                    PushSubtreeCv(core, batchCvs, 3);
                                    _chunkCounter += ChunksPerAvx2Batch;
                                    firstChunk = ChunksPerAvx2Batch;
                                }

                                int chunksToCommit = drainsRemainingInput ? ChunksPerAvx512Batch - 1 : ChunksPerAvx512Batch;

                                // Draining means offset == length; return directly.
                                if (CommitBatchChunks(core, batchCvs, firstChunk, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += Avx512BatchSizeBytes;
                        }
                    }

                    // AVX-512 partial batch: 9..15 chunks via the 16-way kernel
                    if ((_simdSupport & SimdSupport.Avx512F) != 0 &&
                        length - offset >= (ChunksPerAvx2Batch + 1) * ChunkSizeBytes)
                    {
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, &CompressChunksPartialAvx512);
                    }
                }

                // Helps to not JIT this branch if unsupported
                if (Avx2.IsSupported || Avx512F.IsSupported)
                {
                    // AVX2 8-chunk batches: primary path on AVX2-only hardware
                    if ((_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0 &&
                        length - offset >= Avx2BatchSizeBytes)
                    {
                        // 64-chunk subtree groups 
                        while ((_chunkCounter & (ChunksPerSubtreeGroup - 1)) == 0 &&
                               length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes)
                        {
                            offset = CompressSubtreeGroup(core, srcPtr, offset, ChunksPerAvx2Batch,
                                Avx2BatchSizeBytes, batchCvs, &CompressChunksPartialAvx2);
                        }

                        while (length - offset >= Avx2BatchSizeBytes)
                        {
                            CompressChunksPartialAvx2(
                                srcPtr + offset,
                                ChunksPerAvx2Batch,
                                core->_keyWords,
                                batchCvs,
                                _chunkCounter,
                                _baseFlags);

                            bool drainsRemainingInput = offset + Avx2BatchSizeBytes == length;

                            if (!drainsRemainingInput && (_chunkCounter & (ChunksPerAvx2Batch - 1)) == 0)
                            {
                                // Complete aligned 8-chunk subtree, not the tail.
                                ReduceChunkCvsToSubtreeCvAvx2(batchCvs, core->_keyWords, ChunksPerAvx2Batch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 3);
                                _chunkCounter += ChunksPerAvx2Batch;
                            }
                            else
                            {
                                int chunksToCommit = drainsRemainingInput ? ChunksPerAvx2Batch - 1 : ChunksPerAvx2Batch;

                                // Draining means offset == length; return directly.
                                if (CommitBatchChunks(core, batchCvs, 0, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += Avx2BatchSizeBytes;
                        }
                    }

                    // Partial batch: 2..7 chunks via the 8-way kernel with surplus
                    // lanes ignoring real data — beats per-chunk from 2 chunks up.
                    // Counters may be unaligned here, so CVs commit per-chunk.
                    if ((_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0 &&
                        length - offset >= 2 * ChunkSizeBytes)
                    {
                        // At most 7 chunks remain. Below 5, the 4-lane kernel
                        // beats the 8-lane one

                        int fullChunks = (length - offset) / ChunkSizeBytes;
                        delegate*<byte*, int, uint*, uint*, ulong, uint, void> kernel = fullChunks <= 4
                            ? &CompressChunksPartial4Ssse3
                            : &CompressChunksPartialAvx2;
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, kernel);
                    }
                }

                // Helps to not JIT this branch where SSSE3 is unavailable
                if (Ssse3.IsSupported)
                {
                    // SSSE3 4-chunk batches.
                    //
                    // Unlike AVX2 and NEON this tier reduces four CVs per subtree
                    // rather than eight, using CompressParents4Ssse3 — the 8-lane
                    // reduce needs Vector256 and is unavailable here.
                    if ((_simdSupport & SimdSupport.Ssse3) != 0 &&
                        length - offset >= Ssse3BatchSizeBytes)
                    {
                        // 64-chunk subtree groups: 16 batches reduce to one CV,
                        // so the tree only sees one push per 64 KB instead of 64.
                        while ((_chunkCounter & (ChunksPerSubtreeGroup - 1)) == 0 &&
                            length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes)
                        {
                            offset = CompressSubtreeGroup(core, srcPtr, offset, ChunksPerSsse3Batch,
                                Ssse3BatchSizeBytes, batchCvs, &CompressChunksPartial4Ssse3);
                        }

                        while (length - offset >= Ssse3BatchSizeBytes)
                        {
                            CompressChunksPartial4Ssse3(
                                srcPtr + offset,
                                ChunksPerSsse3Batch,
                                core->_keyWords,
                                batchCvs,
                                _chunkCounter,
                                _baseFlags);

                            bool drainsRemainingInput = offset + Ssse3BatchSizeBytes == length;

                            if (!drainsRemainingInput && (_chunkCounter & (ChunksPerSsse3Batch - 1)) == 0)
                            {
                                // Complete aligned 4-chunk subtree, not the tail:
                                // fold the four CVs into one before pushing.
                                ReduceChunkCvsToSubtreeCvSsse3(batchCvs, core->_keyWords, ChunksPerSsse3Batch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 2);
                                _chunkCounter += ChunksPerSsse3Batch;
                                offset += Ssse3BatchSizeBytes;
                                continue;
                            }

                            int chunksToCommit = drainsRemainingInput ? ChunksPerSsse3Batch - 1 : ChunksPerSsse3Batch;

                            // Draining means offset == length; return directly.
                            if (CommitBatchChunks(core, batchCvs, 0, chunksToCommit, drainsRemainingInput))
                            {
                                return;
                            }

                            offset += Ssse3BatchSizeBytes;
                        }
                    }

                    // SSSE3 partial batch: exactly 3 chunks via the 4-way kernel with
                    // one ignored lane, mirroring the NEON tier's threshold (2 chunks
                    // did not repay the transpose cost there either).
                    if ((_simdSupport & SimdSupport.Ssse3) != 0 &&
                        length - offset >= 3 * ChunkSizeBytes)
                    {
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, &CompressChunksPartial4Ssse3);
                    }
                }

                // Helps to not JIT this branch on Arm
                if (AdvSimd.Arm64.IsSupported)
                {
                    // NEON 4-chunk batches: same subtree-group strategy as AVX2
                    // above, one register width down (4 lanes vs. 8).
                    if ((_simdSupport & SimdSupport.Neon) != 0 &&
                        length - offset >= NeonBatchSizeBytes)
                    {
                        // 64-chunk subtree groups
                        while ((_chunkCounter & (ChunksPerSubtreeGroup - 1)) == 0 &&
                               length - offset > ChunksPerSubtreeGroup * ChunkSizeBytes)
                        {
                            offset = CompressSubtreeGroup(core, srcPtr, offset, ChunksPerNeonBatch,
                                NeonBatchSizeBytes, batchCvs, &CompressChunksPartialNeon);
                        }

                        while (length - offset >= NeonBatchSizeBytes)
                        {
                            CompressChunksPartialNeon(srcPtr + offset, ChunksPerNeonBatch, core->_keyWords, batchCvs, _chunkCounter, _baseFlags);

                            bool drainsRemainingInput = offset + NeonBatchSizeBytes == length;

                            if (!drainsRemainingInput && (_chunkCounter & (ChunksPerNeonBatch - 1)) == 0)
                            {
                                // Complete aligned 4-chunk subtree, not the tail.
                                ReduceChunkCvsToSubtreeCvNeon(batchCvs, core->_keyWords, ChunksPerNeonBatch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 2);
                                _chunkCounter += ChunksPerNeonBatch;
                            }
                            else
                            {
                                int chunksToCommit = drainsRemainingInput ? ChunksPerNeonBatch - 1 : ChunksPerNeonBatch;

                                // Draining means offset == length; return directly.
                                if (CommitBatchChunks(core, batchCvs, 0, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += NeonBatchSizeBytes;
                        }
                    }

                    // NEON partial batch: exactly 3 chunks via the 4-way kernel
                    // with one ignored lane. The 2-chunk case benchmarked
                    // slower than scalar (fixed transpose/spill cost not repaid
                    // by 2 chunks), so it falls through to the scalar loop instead.
                    if ((_simdSupport & SimdSupport.Neon) != 0 &&
                        length - offset >= 3 * ChunkSizeBytes)
                    {
                        // At most 3 chunks remain here (3,072..4,095 bytes).
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, &CompressChunksPartialNeon);
                    }
                }
            }
#endif

            // single chunk processing
            while (offset < length)
            {
                // If chunk buffer is full, finalize the chunk
                if (_chunkBufferLength == ChunkSizeBytes)
                {
                    FinalizeChunk(core, core->_cvStackBuf + _cvStackDepth * 8);

                    AddChunkToTree(core);
                    _chunkCounter++;
                    _chunkBufferLength = 0;
                    _blocksCompressed = 0;
                    Unsafe.CopyBlock(core->_cv, core->_keyWords, KeySizeWords * (uint)sizeof(uint));

#if NET8_0_OR_GREATER
                    // The buffer is empty again and more chunks remain for batching
                    if (length - offset > 2 * ChunkSizeBytes)
                    {
                        goto RestartBatching;
                    }
#endif
                }

                int toCopy = Math.Min(ChunkSizeBytes - _chunkBufferLength, length - offset);
                Unsafe.CopyBlockUnaligned(
                    ref core->_chunkBuffer[_chunkBufferLength],
                    ref srcPtr[offset],
                    (uint)toCopy);
                _chunkBufferLength += toCopy;
                offset += toCopy;
            }
        }
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Shared tail handling for a SIMD tier's partial batch (fewer full chunks
    /// remaining than one whole batch, but enough to beat serial per-chunk
    /// compression): compresses them all via <paramref name="partialKernel"/>,
    /// commits every chunk but the last, and holds the last back as pending if
    /// it exactly drains the input (see <see cref="FinalizeRoot"/>).
    /// </summary>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the remaining full chunks start.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="scratch">Caller-owned scratch buffer for the partial kernel's output CVs.</param>
    /// <param name="partialKernel">The tier-specific partial-batch compression kernel to call.</param>
    /// <returns>The number of bytes consumed (<c>fullChunks * ChunkSizeBytes</c>).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private int CommitPartialBatch(
        Blake3State* core, byte* srcPtr, int offset, int length, uint* scratch,
        delegate*<byte*, int, uint*, uint*, ulong, uint, void> partialKernel)
    {
        int fullChunks = (length - offset) / ChunkSizeBytes;
        bool drainsRemainingInput = offset + fullChunks * ChunkSizeBytes == length;

        uint* partialCvs = scratch;
        partialKernel(srcPtr + offset, fullChunks, core->_keyWords, partialCvs, _chunkCounter, _baseFlags);

        int chunksToCommit = drainsRemainingInput ? fullChunks - 1 : fullChunks;
        CommitBatchChunks(core, partialCvs, 0, chunksToCommit, drainsRemainingInput);

        return fullChunks * ChunkSizeBytes;
    }

    /// <summary>
    /// Commits CVs <c>[firstChunk, chunksToCommit)</c> from a compressed batch
    /// buffer to the tree one at a time. If the batch exactly drained the
    /// input, the CV at index <paramref name="chunksToCommit"/> is held back as
    /// pending instead (see <see cref="FinalizeRoot"/>).
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if the pending chunk was held back, meaning
    /// <c>offset == length</c>; callers should <c>return</c> immediately.
    /// </returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private bool CommitBatchChunks(Blake3State* core, uint* batchCvs, int firstChunk, int chunksToCommit, bool drainsRemainingInput)
    {
        for (int i = firstChunk; i < chunksToCommit; i++)
        {
            Unsafe.CopyBlock(
                core->_cvStackBuf + _cvStackDepth * 8,
                batchCvs + i * KeySizeWords,
                KeySizeWords * (uint)sizeof(uint));
            AddChunkToTree(core);
            _chunkCounter++;
        }

        if (drainsRemainingInput)
        {
            Unsafe.CopyBlock(
                core->_pendingCv,
                batchCvs + chunksToCommit * KeySizeWords,
                KeySizeWords * (uint)sizeof(uint));
            _hasPendingCv = true;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Copies a reduced subtree CV onto the tree stack and pushes it —
    /// the shared tail of every "aligned subtree" branch across the SIMD
    /// batch loops and <see cref="CompressSubtreeGroup"/>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void PushSubtreeCv(Blake3State* core, uint* cvs, int level)
    {
        Unsafe.CopyBlock(
            core->_cvStackBuf + _cvStackDepth * 8,
            cvs,
            KeySizeWords * (uint)sizeof(uint));
        AddSubtreeToTree(core, level);
    }

    /// <summary>
    /// Shared body for every SIMD tier's 64-chunk subtree-group loop: runs
    /// <c>ChunksPerSubtreeGroup / batchWidth</c> kernel batches into
    /// <paramref name="batchCvs"/>, reduces all 64 CVs to one subtree CV, and
    /// pushes it — so the reduction and tree push are paid once per 64 KB.
    /// </summary>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the group starts.</param>
    /// <param name="batchWidth">The tier's chunk-parallel width (4, 8, or 16).</param>
    /// <param name="batchSizeBytes"><c>batchWidth * ChunkSizeBytes</c>.</param>
    /// <param name="batchCvs">Caller-owned scratch buffer, at least 64 CVs (512 words) long.</param>
    /// <param name="kernel">The tier-specific partial-batch compression kernel to call.</param>
    /// <returns><paramref name="offset"/> advanced by <c>ChunksPerSubtreeGroup * ChunkSizeBytes</c>.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private int CompressSubtreeGroup(
        Blake3State* core, byte* srcPtr, int offset, int batchWidth, int batchSizeBytes,
        uint* batchCvs, delegate*<byte*, int, uint*, uint*, ulong, uint, void> kernel)
    {
        for (int b = 0; b < ChunksPerSubtreeGroup / batchWidth; b++)
        {
            kernel(
                srcPtr + offset,
                batchWidth,
                core->_keyWords,
                batchCvs + b * batchWidth * KeySizeWords,
                _chunkCounter + (ulong)(b * batchWidth),
                _baseFlags);
            offset += batchSizeBytes;
        }

        // hardcoding, so the JIT can remove
        if (AdvSimd.Arm64.IsSupported)
        {
            ReduceChunkCvsToSubtreeCvNeon(batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
        }
        else if (Ssse3.IsSupported && (_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) == 0)
        {
            // SSSE3 tier: the 8-lane reduce needs Vector256, so use the 4-lane
            // one. Runs once per 64-chunk group (64 KB of input), so the extra
            // runtime check here is far below the noise floor.
            ReduceChunkCvsToSubtreeCvSsse3(batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
        }
        else
        {
            ReduceChunkCvsToSubtreeCvAvx2(batchCvs, core->_keyWords, ChunksPerSubtreeGroup, _baseFlags);
        }

        PushSubtreeCv(core, batchCvs, 6);
        _chunkCounter += ChunksPerSubtreeGroup;
        return offset;
    }
#endif

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
            _cvStackDepth = 0;
#if NET8_0_OR_GREATER
            Unsafe.InitBlockUnaligned(core->_pendingCv, 0, KeySizeWords * (uint)sizeof(uint));
            _hasPendingCv = false;
#endif
        }
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
#if NET8_0_OR_GREATER
        _hasPendingCv = false;
#endif
    }

    // [SkipLocalsInit]: the block buffer is zeroed per chunk by localsinit but only
    // needed as padding for a partial last block — zeroed explicitly there instead.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void FinalizeChunk(Blake3State* core, uint* destination)
    {
        // Compute last block boundary via integer math, same as SaveChunkAsRootFromSource.
        int lastBlockOffset = (_chunkBufferLength <= BlockSizeBytes) ? 0
            : (_chunkBufferLength - 1) / BlockSizeBytes * BlockSizeBytes;
        int lastBlockLen = _chunkBufferLength - lastBlockOffset;

        uint flags = _baseFlags;
        if (_blocksCompressed == 0) flags |= FlagChunkStart;

        // All blocks except the last: batched into a single CompressBlock call
        // (same chunk counter for every block — only the flags differ across
        // blocks of the same chunk) — one load/store of the running CV instead
        // of one per block.
        byte* p = core->_chunkBuffer;
        if (lastBlockOffset > 0)
        {
            int blocks = lastBlockOffset / BlockSizeBytes;

            CompressBlocks(core->_cv, p, blocks, BlockSizeBytes, _chunkCounter, flags);

            _blocksCompressed += blocks;
            p += lastBlockOffset;
            flags = _baseFlags;
        }

        uint finalFlags = flags | FlagChunkEnd;
        if (lastBlockLen == BlockSizeBytes)
        {
            CompressBlock(core->_cv, p, (uint)lastBlockLen, _chunkCounter, finalFlags);
        }
        else
        {
            // Partial last block: zero-pad the tail explicitly (SkipLocalsInit)
            byte* block = stackalloc byte[BlockSizeBytes];
            Unsafe.CopyBlockUnaligned(ref *block, ref *p, (uint)lastBlockLen);
            Unsafe.InitBlockUnaligned(block + lastBlockLen, 0, (uint)(BlockSizeBytes - lastBlockLen));

            CompressBlock(core->_cv, block, (uint)lastBlockLen, _chunkCounter, finalFlags);
        }

        _blocksCompressed++;

        Unsafe.CopyBlock(destination, core->_cv, KeySizeWords * (uint)sizeof(uint));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void AddChunkToTree(Blake3State* core) => AddSubtreeToTree(core, 0);

    /// <summary>
    /// Commits the CV already placed at the top of the CV stack as a complete,
    /// aligned subtree of 2^<paramref name="level"/> chunks, merging completed
    /// sibling pairs bottom-up (a chunk is the <paramref name="level"/> = 0 case).
    /// </summary>
    /// <remarks>
    /// <c>_chunkCounter</c> must still be at the subtree's starting chunk
    /// index (a multiple of 2^<paramref name="level"/>); the caller advances
    /// it afterwards.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void AddSubtreeToTree(Blake3State* core, int level)
    {
        _cvStackDepth++;

        ulong totalSubtrees = (_chunkCounter >> level) + 1;
        while ((totalSubtrees & 1) == 0 && _cvStackDepth >= 2)
        {
            // The two sibling CVs are adjacent stack slots — exactly the
            // contiguous 64-byte parent block ComputeParentCv reads; the
            // merge lands in-place in left's slot.
            uint* left = core->_cvStackBuf + (_cvStackDepth - 2) * 8;
            ComputeParentCv(left, core->_keyWords, left);

            _cvStackDepth--;
            totalSubtrees >>= 1;
        }
    }

    /// <summary>
    /// Compresses one parent node whose 64-byte message block is the two child
    /// CVs stored contiguously at <paramref name="children"/> (16 words),
    /// writing the parent's 8-word CV to <paramref name="destination"/>.
    /// </summary>
    /// <remarks>
    /// The children are read directly as the message block, no staging copy.
    /// In-place merges (<paramref name="destination"/> == <paramref name="children"/>)
    /// are safe since both compress paths finish reading before writing.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ComputeParentCv(uint* children, uint* key, uint* destination)
    {
        uint flags = _baseFlags | FlagParent;
        uint* cv = stackalloc uint[KeySizeWords];
        Unsafe.CopyBlock(cv, key, KeySizeWords * (uint)sizeof(uint));
        CompressBlock(cv, (byte*)children, BlockSizeBytes, 0, flags);
        Unsafe.CopyBlock(destination, cv, KeySizeWords * (uint)sizeof(uint));
    }

    // Single/few-block work (parent merges, one chunk via FinalizeChunk/
    // SaveChunkAsRoot) has no independent work to spread across NEON's lanes,
    // so row-vectorizing it benchmarked slower than scalar — NEON-tier
    // instances use the scalar kernel here too, same as no-SIMD instances.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void CompressBlock(uint* cv, byte* block, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Ssse3 | SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            CompressBlockSsse3(cv, block, blockLen, counter, flags);
        }
        else
#endif
        {
            CompressBlocksScalar(cv, block, 1, blockLen, counter, flags);
        }
    }

    // See CompressBlock — same reasoning applies here.
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void CompressBlocks(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Ssse3 | SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            CompressBlocksSsse3(cv, block, blocks, blockLen, counter, flags);
        }
        else
#endif
        {
            CompressBlocksScalar(cv, block, blocks, blockLen, counter, flags);
        }
    }

    // [SkipLocalsInit]: v0..v7 are fully assigned from cv below before any read.
    // v0..v15 are named locals rather than a stackalloc'd array, passed by ref
    // into a force-inlined Compress: named locals only avoid the array's
    // memory traffic if Compress is actually inlined, since byref params to a
    // non-inlined callee force real stack addresses anyway.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlocksScalar(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
        uint* m = stackalloc uint[BlockSizeWords];
        uint v0 = cv[0], v1 = cv[1], v2 = cv[2], v3 = cv[3];
        uint v4 = cv[4], v5 = cv[5], v6 = cv[6], v7 = cv[7];

        while (true)
        {
            BinarySpans.ReadUInt32LittleEndian(block, m, BlockSizeWords);

            uint v8 = IV0, v9 = IV1, v10 = IV2, v11 = IV3;
            uint v12 = (uint)counter;
            uint v13 = (uint)(counter >> 32);
            uint v14 = blockLen;
            uint v15 = flags;

            Compress(
                ref v0, ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7,
                ref v8, ref v9, ref v10, ref v11, ref v12, ref v13, ref v14, ref v15,
                m);

            if (--blocks <= 0)
            {
                cv[0] = v0 ^ v8; cv[1] = v1 ^ v9; cv[2] = v2 ^ v10; cv[3] = v3 ^ v11;
                cv[4] = v4 ^ v12; cv[5] = v5 ^ v13; cv[6] = v6 ^ v14; cv[7] = v7 ^ v15;
                break;
            }

            v0 ^= v8; v1 ^= v9; v2 ^= v10; v3 ^= v11;
            v4 ^= v12; v5 ^= v13; v6 ^= v14; v7 ^= v15;

            block += blockLen;
            flags &= ~FlagChunkStart;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void Compress(
       ref uint v0, ref uint v1, ref uint v2, ref uint v3,
       ref uint v4, ref uint v5, ref uint v6, ref uint v7,
       ref uint v8, ref uint v9, ref uint v10, ref uint v11,
       ref uint v12, ref uint v13, ref uint v14, ref uint v15,
       uint* m)
    {
        // Round 1
        G(ref v0, ref v4, ref v8, ref v12, m[0], m[1]);
        G(ref v1, ref v5, ref v9, ref v13, m[2], m[3]);
        G(ref v2, ref v6, ref v10, ref v14, m[4], m[5]);
        G(ref v3, ref v7, ref v11, ref v15, m[6], m[7]);
        G(ref v0, ref v5, ref v10, ref v15, m[8], m[9]);
        G(ref v1, ref v6, ref v11, ref v12, m[10], m[11]);
        G(ref v2, ref v7, ref v8, ref v13, m[12], m[13]);
        G(ref v3, ref v4, ref v9, ref v14, m[14], m[15]);

        // Round 2
        G(ref v0, ref v4, ref v8, ref v12, m[2], m[6]);
        G(ref v1, ref v5, ref v9, ref v13, m[3], m[10]);
        G(ref v2, ref v6, ref v10, ref v14, m[7], m[0]);
        G(ref v3, ref v7, ref v11, ref v15, m[4], m[13]);
        G(ref v0, ref v5, ref v10, ref v15, m[1], m[11]);
        G(ref v1, ref v6, ref v11, ref v12, m[12], m[5]);
        G(ref v2, ref v7, ref v8, ref v13, m[9], m[14]);
        G(ref v3, ref v4, ref v9, ref v14, m[15], m[8]);

        // Round 3
        G(ref v0, ref v4, ref v8, ref v12, m[3], m[4]);
        G(ref v1, ref v5, ref v9, ref v13, m[10], m[12]);
        G(ref v2, ref v6, ref v10, ref v14, m[13], m[2]);
        G(ref v3, ref v7, ref v11, ref v15, m[7], m[14]);
        G(ref v0, ref v5, ref v10, ref v15, m[6], m[5]);
        G(ref v1, ref v6, ref v11, ref v12, m[9], m[0]);
        G(ref v2, ref v7, ref v8, ref v13, m[11], m[15]);
        G(ref v3, ref v4, ref v9, ref v14, m[8], m[1]);

        // Round 4
        G(ref v0, ref v4, ref v8, ref v12, m[10], m[7]);
        G(ref v1, ref v5, ref v9, ref v13, m[12], m[9]);
        G(ref v2, ref v6, ref v10, ref v14, m[14], m[3]);
        G(ref v3, ref v7, ref v11, ref v15, m[13], m[15]);
        G(ref v0, ref v5, ref v10, ref v15, m[4], m[0]);
        G(ref v1, ref v6, ref v11, ref v12, m[11], m[2]);
        G(ref v2, ref v7, ref v8, ref v13, m[5], m[8]);
        G(ref v3, ref v4, ref v9, ref v14, m[1], m[6]);

        // Round 5
        G(ref v0, ref v4, ref v8, ref v12, m[12], m[13]);
        G(ref v1, ref v5, ref v9, ref v13, m[9], m[11]);
        G(ref v2, ref v6, ref v10, ref v14, m[15], m[10]);
        G(ref v3, ref v7, ref v11, ref v15, m[14], m[8]);
        G(ref v0, ref v5, ref v10, ref v15, m[7], m[2]);
        G(ref v1, ref v6, ref v11, ref v12, m[5], m[3]);
        G(ref v2, ref v7, ref v8, ref v13, m[0], m[1]);
        G(ref v3, ref v4, ref v9, ref v14, m[6], m[4]);

        // Round 6
        G(ref v0, ref v4, ref v8, ref v12, m[9], m[14]);
        G(ref v1, ref v5, ref v9, ref v13, m[11], m[5]);
        G(ref v2, ref v6, ref v10, ref v14, m[8], m[12]);
        G(ref v3, ref v7, ref v11, ref v15, m[15], m[1]);
        G(ref v0, ref v5, ref v10, ref v15, m[13], m[3]);
        G(ref v1, ref v6, ref v11, ref v12, m[0], m[10]);
        G(ref v2, ref v7, ref v8, ref v13, m[2], m[6]);
        G(ref v3, ref v4, ref v9, ref v14, m[4], m[7]);

        // Round 7
        G(ref v0, ref v4, ref v8, ref v12, m[11], m[15]);
        G(ref v1, ref v5, ref v9, ref v13, m[5], m[0]);
        G(ref v2, ref v6, ref v10, ref v14, m[1], m[9]);
        G(ref v3, ref v7, ref v11, ref v15, m[8], m[6]);
        G(ref v0, ref v5, ref v10, ref v15, m[14], m[10]);
        G(ref v1, ref v6, ref v11, ref v12, m[2], m[12]);
        G(ref v2, ref v7, ref v8, ref v13, m[3], m[4]);
        G(ref v3, ref v4, ref v9, ref v14, m[7], m[13]);
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
