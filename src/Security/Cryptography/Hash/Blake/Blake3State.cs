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
    // Collection expression over ReadOnlySpan compiles to an RVA data blob read
    // directly from the image — no static-field + array-object double
    // dereference in the kernel prologues, which broadcast IV[0..3] on every
    // per-block compress call.
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

    // Field order groups co-accessed state (fixed-buffer structs are laid out
    // sequentially): the per-call control scalars, key, in-progress CV, and
    // root/finalize cluster land in the first ~200 bytes so the single-chunk
    // one-shot path (source <= 1024 bytes, TryHashOneShotSingleChunk) —
    // which writes _rootBlock/_rootCv/_rootBlockLen/_rootFlags in
    // SaveChunkAsRoot and reads them straight back in SqueezeRootBlock —
    // never touches the bulk streaming-only buffers below it and stays
    // within the first few cache lines; those bulk buffers (only touched by
    // the incremental Append()/multi-chunk path) and the XOF squeeze state
    // (only touched when output exceeds one block) follow.

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
    // Holds a fully-computed chaining value for a chunk that a bulk SIMD path
    // (e.g. AVX2 8-chunk batching) produced but could not yet commit to the
    // Merkle tree via AddChunkToTree, because at the time it was computed it
    // wasn't known whether more Append() data would follow (only the true last
    // chunk of the whole message may skip the ordinary, non-root-flagged tree
    // merge — see FinalizeRoot). Distinct from _cv, which is the in-progress
    // accumulator for a chunk still being buffered byte-by-byte; reusing _cv
    // here would corrupt it if a later Append() call starts a new chunk.
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

        // Kept out-of-line (see TryHashOneShotSingleChunk) so this hot,
        // large-input path — Append already contains the performance-critical
        // batch loops — isn't sharing a compiled method body with the cold
        // single-chunk branch's stackalloc/squeeze code; the two never run in
        // the same call, but a shared body means the JIT lays them out
        // together, which measurably hurt icache locality on the large-input
        // path when they were one method.
        Append(source);
        return TryGetCurrentHash(destination, out bytesWritten);
    }

    // Cold path relative to TryHashOneShot's large-input branch — see the
    // comment there for why this is split out instead of inlined.
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.NoInlining)]
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
            // A previous call may have left the final chunk of an AVX2 batch
            // "pending" (see below) because it didn't yet know whether more data
            // would follow. Any new bytes here prove it wasn't the last chunk
            // after all, so it's now safe to commit it to the tree normally.
            if (_hasPendingCv && length > 0)
            {
                Unsafe.CopyBlock(core->_cvStackBuf + _cvStackDepth * 8, core->_pendingCv, KeySizeWords * (uint)sizeof(uint));
                AddChunkToTree(core);
                _chunkCounter++;
                _hasPendingCv = false;
            }

            // Single scratch buffer for every chunk-parallel fast path below —
            // sized for the largest need (a full 64-chunk subtree group, 2 KB)
            // and reused as-is by the narrower needs (16/8/4-chunk single
            // batches, and CommitPartialBatch's tail case, all <= 480 bytes)
            // instead of each one stackalloc'ing its own buffer. Declared once,
            // here, before the RestartBatching label below — a stackalloc
            // reached via a backward goto re-allocates on every jump instead
            // of reusing the prior allocation, so this must sit outside the
            // loop, not inside the block the goto re-enters (that previously
            // stack-overflowed scalar-only hashing of large inputs, where
            // every single chunk finalize re-triggered the goto).
            uint* batchCvs = stackalloc uint[ChunksPerSubtreeGroup * KeySizeWords];

            // Chunk-parallel fast paths below are only applicable at a chunk
            // boundary (no partial chunk buffered) — checked once here rather
            // than at every branch, since nothing between this point and the
            // scalar loop at the bottom (the only place that buffers a partial
            // chunk) ever changes _chunkBufferLength, other than the scalar
            // loop's own finalize step, which jumps back here (see
            // RestartBatching below) instead of falling permanently out of
            // the batched paths — e.g. a small Append() leaving one byte
            // buffered, followed by a large Append(), would otherwise process
            // the entire large call one chunk at a time.
        RestartBatching:
            if (_chunkBufferLength == 0)
            {
                // Helps to not JIT this branch on Arm
                if (Avx512F.IsSupported)
                {
                    // Whole groups of 16 (AVX-512) or 8 (AVX2) independent chunks
                    // can be compressed together instead of one at a time. A batch
                    // that exactly drains the remaining input holds back its last
                    // chunk as the new pending chunk instead of committing it,
                    // since that one might turn out to be the true last chunk of
                    // the whole message (which must never go through the ordinary,
                    // non-root-flagged tree merge in AddChunkToTree — see FinalizeRoot).
                    if ((_simdSupport & SimdSupport.Avx512F) != 0 &&
                        length - offset >= Avx512BatchSizeBytes)
                    {
                        // 64-chunk subtree groups: four kernel batches accumulate 64 CVs
                        // reduced in one pass, so the surplus-lane reduction tail and the
                        // tree push are paid once per 64 KB instead of per 16 KB batch.
                        // The strictly-greater guard keeps the group clear of the message
                        // tail, so no pending-CV holdback is needed here.
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
                                // The 16 chunks form a complete, aligned subtree that
                                // provably isn't the message tail: reduce their CVs
                                // with wide parent compressions and push one tree
                                // node instead of 16 per-chunk commits with serial
                                // single-lane merges.
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

                                // Draining means offset would become exactly length —
                                // every remaining check below (this tier's own partial
                                // batch, AVX2, NEON, the scalar loop) is guaranteed a
                                // no-op at that point, so skip straight to it.
                                if (CommitBatchChunks(core, batchCvs, firstChunk, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += Avx512BatchSizeBytes;
                        }
                    }

                    // AVX-512 partial batch: 9..15 chunks handled by the 16-way kernel
                    // with duplicated lanes. Without this, a tail in this range would
                    // fall through to one full AVX2 8-chunk batch below plus a
                    // separate AVX2 partial-batch call for the 1..7 chunk remainder —
                    // two 8-wide kernel calls instead of one 16-wide call here. Same
                    // pending-CV holdback and per-chunk (unaligned counter) commit
                    // pattern as the AVX2 partial batch further down.
                    if ((_simdSupport & SimdSupport.Avx512F) != 0 &&
                        length - offset >= (ChunksPerAvx2Batch + 1) * ChunkSizeBytes)
                    {
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, &CompressChunksPartialAvx512);
                    }
                }

                // Helps to not JIT this branch if unsupported
                if (Avx2.IsSupported || Avx512F.IsSupported)
                {
                    // AVX2 8-chunk batches: primary path on AVX2-only hardware, and
                    // picks up an 8–16 KB tail left behind by the AVX-512 loop above.
                    // The Avx512F flag implies AVX2 hardware, so an isolated Avx512F
                    // selection still batches sub-16 KB inputs and tails here instead
                    // of falling back to the per-chunk path.
                    if ((_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0 &&
                        length - offset >= Avx2BatchSizeBytes)
                    {
                        // 64-chunk subtree groups (primary path on AVX2-only hardware;
                        // with AVX-512 enabled the loop above already consumed them):
                        // eight kernel batches accumulate 64 CVs reduced in one pass —
                        // see the AVX-512 group loop for the rationale.
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
                                // Aligned complete 8-chunk subtree that isn't the
                                // message tail — same wide reduction as the AVX-512
                                // loop above, one level lower.
                                ReduceChunkCvsToSubtreeCvAvx2(batchCvs, core->_keyWords, ChunksPerAvx2Batch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 3);
                                _chunkCounter += ChunksPerAvx2Batch;
                            }
                            else
                            {
                                int chunksToCommit = drainsRemainingInput ? ChunksPerAvx2Batch - 1 : ChunksPerAvx2Batch;

                                // Draining means offset would become exactly length —
                                // the remaining checks below (this tier's own partial
                                // batch, NEON, the scalar loop) are guaranteed no-ops
                                // at that point, so skip straight to it.
                                if (CommitBatchChunks(core, batchCvs, 0, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += Avx2BatchSizeBytes;
                        }
                    }

                    // Partial batch: 2..7 full chunks compressed in one pass by the
                    // 8-way kernel with surplus lanes ignoring real chunks — one
                    // pass costs ~1.5 single-lane chunk compressions, so it beats the
                    // per-chunk path from 2 real chunks upward. When the chunks
                    // exactly drain the input, the last one is held back as the
                    // pending chunk (it might be the true message tail — see the
                    // batch loops above); otherwise all of them provably have data
                    // following and commit directly. Chunk counters here may be
                    // unaligned, so CVs commit per-chunk (no subtree reduction).
                    if ((_simdSupport & (SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0 &&
                        length - offset >= 2 * ChunkSizeBytes)
                    {
                        // The batch loop above consumed all >= 8 KB spans, so at most
                        // 7 full chunks (8,191 bytes) remain. Below 5 real chunks, a
                        // genuine 4-lane kernel beats the 8-lane kernel: the 8-lane
                        // kernel's register spill and transpose cost are fixed
                        // regardless of how many of its 8 lanes are real (see
                        // CompressChunksPartial4Avx2 remarks).
                        int fullChunks = (length - offset) / ChunkSizeBytes;
                        delegate*<byte*, int, uint*, uint*, ulong, uint, void> kernel = fullChunks <= 4
                            ? &CompressChunksPartial4Avx2
                            : &CompressChunksPartialAvx2;
                        offset += CommitPartialBatch(core, srcPtr, offset, length, batchCvs, kernel);
                    }
                }

                // Helps to not JIT this branch on Arm
                if (AdvSimd.Arm64.IsSupported)
                {
                    // NEON 4-chunk batches: primary chunk-parallel path on ARM hardware,
                    // one register width down from the AVX2 8-chunk batches above (NEON's
                    // Vector128<uint> holds 4 lanes instead of AVX2's 8) — same subtree-group
                    // amortization strategy, just at 4-chunk width.
                    if ((_simdSupport & SimdSupport.Neon) != 0 &&
                        length - offset >= NeonBatchSizeBytes)
                    {
                        // 64-chunk subtree groups: sixteen kernel batches accumulate 64
                        // CVs reduced in one pass — see the AVX2 group loop above for
                        // the rationale, applied at 4-chunk width.
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
                                // Aligned complete 4-chunk subtree that isn't the
                                // message tail — same wide reduction as the AVX2
                                // loop above, one level lower.
                                ReduceChunkCvsToSubtreeCvNeon(batchCvs, core->_keyWords, ChunksPerNeonBatch, _baseFlags);
                                PushSubtreeCv(core, batchCvs, 2);
                                _chunkCounter += ChunksPerNeonBatch;
                            }
                            else
                            {
                                int chunksToCommit = drainsRemainingInput ? ChunksPerNeonBatch - 1 : ChunksPerNeonBatch;

                                // Draining means offset would become exactly length —
                                // the scalar loop below is guaranteed a no-op at that
                                // point, so skip straight to it.
                                if (CommitBatchChunks(core, batchCvs, 0, chunksToCommit, drainsRemainingInput))
                                {
                                    return;
                                }
                            }

                            offset += NeonBatchSizeBytes;
                        }
                    }

                    // NEON partial batch: 2..3 full chunks compressed in one pass by
                    // the 4-way kernel with surplus lanes duplicating real chunks —
                    // mirrors the AVX2 partial-batch handling above, one register
                    // width down (2..7 there vs 2..3 here).
                    if ((_simdSupport & SimdSupport.Neon) != 0 &&
                        length - offset >= 2 * ChunkSizeBytes)
                    {
                        // The batch loop above consumed all >= 4 KB spans, so at most
                        // 3 full chunks (3,071 bytes) remain.
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
    /// Shared tail-handling for every SIMD tier's "partial batch" case (fewer
    /// full chunks remaining than one whole batch, but enough to still beat
    /// per-chunk serial compression) — compresses all of them in a single
    /// call to <paramref name="partialKernel"/>, commits every chunk but the
    /// last to the tree, and holds the last one back as the pending chunk if
    /// it exactly drains the input (it might be the true message tail — see
    /// <see cref="FinalizeRoot"/>).
    /// </summary>
    /// <remarks>
    /// All four partial kernels (<c>CompressChunksPartialAvx512</c>,
    /// <c>CompressChunksPartialAvx2</c>, <c>CompressChunksPartial4Avx2</c>,
    /// <c>CompressChunksPartialNeon</c>) share this exact signature, so a
    /// plain unmanaged function pointer dispatches to any of them with no
    /// virtual-call or delegate-allocation overhead. Only the tail case is
    /// shared this way — the full-batch loops above have real per-tier
    /// asymmetries (e.g. AVX-512's tail opportunistically re-reduces at AVX2
    /// width) that don't generalize as cleanly.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the remaining full chunks start.</param>
    /// <param name="length">Total length of the current <c>Append</c> call's input.</param>
    /// <param name="scratch">
    /// Caller-owned buffer for the partial kernel's output CVs — never more
    /// than <c>(ChunksPerAvx512Batch - 1) * KeySizeWords</c> (120) words are
    /// used across any tier, well within the caller's shared 64-chunk-group
    /// (512-word) <c>batchCvs</c> buffer, so no separate allocation is needed.
    /// </param>
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
    /// input, the CV at index <paramref name="chunksToCommit"/> is held back
    /// as the new pending chunk instead of committed — it might turn out to be
    /// the true last chunk of the whole message, which must never go through
    /// the ordinary, non-root-flagged tree merge (see <see cref="FinalizeRoot"/>).
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if the pending chunk was held back — every caller
    /// of this method has confirmed that <c>offset == length</c> at that point,
    /// so every remaining check downstream is guaranteed a no-op; callers with
    /// their own control flow to unwind should <c>return</c> immediately.
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
    /// Shared body for every SIMD tier's "64-chunk subtree group" loop: runs
    /// <c>ChunksPerSubtreeGroup / batchWidth</c> kernel batches into
    /// <paramref name="batchCvs"/>, reduces all 64 CVs to one subtree CV in a
    /// single pass, and pushes it — so the surplus-lane reduction tail and the
    /// tree push are paid once per 64 KB instead of once per single-batch width.
    /// </summary>
    /// <remarks>
    /// Unlike <see cref="CommitPartialBatch"/>, the reduce step can't be a
    /// second <c>delegate*</c> parameter: <c>ReduceChunkCvsToSubtreeCvAvx2</c>/
    /// <c>ReduceChunkCvsToSubtreeCvNeon</c> are instance methods (they reach
    /// <c>_baseFlags</c>/<c>_simdSupport</c> through <see cref="ComputeParentCv"/>),
    /// and unmanaged function pointers can only target <see langword="static"/>
    /// methods. Dispatching on <see cref="AdvSimd.Arm64.IsSupported"/> — the
    /// same JIT-time-constant check already used elsewhere in <c>Append</c> —
    /// avoids introducing a managed, allocating delegate on this hot path just
    /// to unify two call sites; only one branch's code is ever actually
    /// compiled in for a given platform.
    /// </remarks>
    /// <param name="core">Pointer to the same instance as <see langword="this"/>.</param>
    /// <param name="srcPtr">Pointer to the start of the current <c>Append</c> call's input.</param>
    /// <param name="offset">Byte offset into <paramref name="srcPtr"/> where the group starts.</param>
    /// <param name="batchWidth">The tier's chunk-parallel width (4, 8, or 16).</param>
    /// <param name="batchSizeBytes">
    /// <c>batchWidth * ChunkSizeBytes</c> — the byte stride between kernel batches.
    /// </param>
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

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void AddChunkToTree(Blake3State* core) => AddSubtreeToTree(core, 0);

    /// <summary>
    /// Commits the CV already placed at the top of the CV stack as a complete,
    /// aligned subtree of 2^<paramref name="level"/> chunks, merging completed
    /// sibling pairs bottom-up (a chunk is the <paramref name="level"/> = 0 case).
    /// </summary>
    /// <remarks>
    /// <c>_chunkCounter</c> must still be at the subtree's starting chunk index,
    /// which must be a multiple of 2^<paramref name="level"/>; the caller
    /// advances the counter afterwards. Because the subtree is complete and
    /// aligned, the resulting stack state is identical to committing its
    /// chunks one at a time — the stack always mirrors the binary
    /// representation of the completed subtree count.
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
    /// The children are read directly as the message block — no staging copy.
    /// In-place merges (<paramref name="destination"/> == <paramref name="children"/>)
    /// are safe: both compress paths finish every message read before the
    /// result is written (the SIMD block compress writes only its local CV,
    /// the scalar path writes <paramref name="destination"/> after
    /// <see cref="Compress"/> returns).
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

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void CompressBlock(uint* cv, byte* block, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Ssse3 | SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            CompressBlockSsse3(cv, block, blockLen, counter, flags);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            CompressBlocksNeon(cv, block, 1, blockLen, counter, flags);
        }
        else
#endif
        {
            CompressBlocksScalar(cv, block, 1, blockLen, counter, flags);
        }
    }


    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void CompressBlocks(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & (SimdSupport.Ssse3 | SimdSupport.Avx2 | SimdSupport.Avx512F)) != 0)
        {
            CompressBlocksSsse3(cv, block, blocks, blockLen, counter, flags);
        }
        else if ((_simdSupport & SimdSupport.Neon) != 0)
        {
            CompressBlocksNeon(cv, block, blocks, blockLen, counter, flags);
        }
        else
#endif
        {
            CompressBlocksScalar(cv, block, blocks, blockLen, counter, flags);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void CompressBlocksScalar(uint* cv, byte* block, int blocks, uint blockLen, ulong counter, uint flags)
    {
        uint* m = stackalloc uint[BlockSizeWords];
        uint* v = stackalloc uint[BlockSizeWords];
        Unsafe.CopyBlock(v, cv, KeySizeWords * (uint)sizeof(uint));

        while (true)
        {
            BinarySpans.ReadUInt32LittleEndian(block, m, BlockSizeWords);

            v[8] = IV0; v[9] = IV1; v[10] = IV2; v[11] = IV3;
            v[12] = (uint)counter;
            v[13] = (uint)(counter >> 32);
            v[14] = blockLen;
            v[15] = flags;

            Compress(v, m);

            if (--blocks <= 0)
            {
                break;
            }

            for (int i = 0; i < 8; i++)
            {
                v[i] ^= v[i + 8];
            }

            block += blockLen;
            flags &= ~FlagChunkStart;
        }

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
