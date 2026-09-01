// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Helper to build a <see cref="ReadOnlySequence{T}"/> from a set of buffers.
/// Implements <see cref="IBufferWriter{T}"/> interface.
/// </summary>
/// <remarks>
/// <para>
/// Instances can be pooled. Rent one with <see cref="Pools.ObjectPools.RentBufferWriter{T}"/> and
/// dispose it as usual — a rented writer returns itself to its pool instead of being destroyed, and
/// <see cref="TryReset"/> puts it back into its just-constructed state on the way.
/// </para>
/// <para>
/// <b>Using a rented writer after disposing it is undefined.</b> Unlike an ordinary
/// <see cref="IDisposable"/>, a returned instance does not throw <see cref="ObjectDisposedException"/>;
/// it silently becomes whatever the next renter is doing. This is the same contract as
/// <see cref="ArrayPool{T}"/> itself.
/// </para>
/// </remarks>
public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable, IResettable
{
    private static readonly T[] _emptyBuffer = Array.Empty<T>();

    // Not readonly: a pooled writer is reconfigured by Configure as it leaves the pool, so one pool
    // can serve every configuration in an application rather than one pool per set of settings.
    private bool _clearArray;
    private int _maxChunkSize;
    private int _defaultChunkSize;
    private int _chunkSize;
    private T[] _currentBuffer;
    private ArrayPoolBufferSegment<T>? _firstSegment;
    private ArrayPoolBufferSegment<T>? _nextSegment;
    private int _offset;
    private bool _disposed;
    private ObjectPool<ArrayPoolBufferWriter<T>>? _pool;

    /// <summary>
    /// The default chunk size.
    /// </summary>
    public const int DefaultChunkSize = 256;

    /// <summary>
    /// The default maximum chunk size.
    /// </summary>
    public const int MaxChunkSize = 65536;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    public ArrayPoolBufferWriter()
        : this(false, DefaultChunkSize, MaxChunkSize)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    public ArrayPoolBufferWriter(int defaultChunksize, int maxChunkSize)
        : this(false, defaultChunksize, maxChunkSize)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    /// <param name="clearArray">Whether each buffer is zeroed as it returns to the array pool.</param>
    /// <param name="defaultChunksize">The size of the first chunk rented.</param>
    /// <param name="maxChunkSize">
    /// The ceiling the chunk size ramps up to. A value at or below <paramref name="defaultChunksize"/>
    /// disables the ramp, pinning every chunk to that size.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="defaultChunksize"/> is less than one.</exception>
    public ArrayPoolBufferWriter(bool clearArray, int defaultChunksize, int maxChunkSize)
    {
        _firstSegment = _nextSegment = null;
        _offset = 0;
        _currentBuffer = _emptyBuffer;
        _disposed = false;

        Configure(clearArray, defaultChunksize, maxChunkSize);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// For a writer rented from a pool this returns the instance to that pool rather than destroying
    /// it, so it can be reused. See the remarks on <see cref="ArrayPoolBufferWriter{T}"/> for what that
    /// means for a reference held past disposal.
    /// </remarks>
    public void Dispose()
    {
        // Exactly-once within a rental: whichever caller wins the exchange performs the return, so an
        // accidental second Dispose cannot put the same instance into the pool twice.
        ObjectPool<ArrayPoolBufferWriter<T>>? pool = Interlocked.Exchange(ref _pool, null);

        // Reset here rather than leaving it to the pool's policy. The rented arrays have to be back
        // in the array pool before anyone else can take this writer, and that must not depend on how
        // a particular pool was configured. TryReset is idempotent, so a policy that resets again on
        // return costs nothing. If the reset is refused the instance is not fit to be pooled, so fall
        // through and tear it down instead.
        if (pool != null && TryReset())
        {
            pool.Return(this);
            return;
        }

        ReleaseSegments();
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Resets the writer to its just-constructed state so it can be reused.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if the writer was reset and may be returned to a pool;
    /// <see langword="false"/> if it has been disposed and must be discarded.
    /// </returns>
    /// <remarks>
    /// Implements <see cref="IResettable"/> from <c>Microsoft.Extensions.ObjectPool</c>. Every rented
    /// segment goes back to <see cref="ArrayPool{T}"/> — none is retained for the next use, because a
    /// pool that is already full drops the instance rather than keeping it, and a retained segment
    /// would then leak out of the pool. Idempotent.
    /// </remarks>
    public bool TryReset()
    {
        if (_disposed)
        {
            return false;
        }

        ReleaseSegments();
        _chunkSize = _defaultChunkSize;   // undo the growth ramp applied by CheckAndAllocateBuffer
        return true;
    }

    /// <summary>
    /// Applies a set of settings to this writer and restarts its chunk-size ramp.
    /// </summary>
    /// <param name="clearArray">Whether each buffer is zeroed as it returns to the array pool.</param>
    /// <param name="defaultChunkSize">The size of the first chunk rented.</param>
    /// <param name="maxChunkSize">The ceiling the chunk size ramps up to.</param>
    /// <remarks>
    /// <para>
    /// Internal on purpose, and called only as a writer leaves the pool. That placement is what makes
    /// <c>clearArray</c> trustworthy: a writer is reset — and therefore zeroes its buffers, if that is
    /// what its renter asked for — while the outgoing settings are still in force, and only then does
    /// the next renter's configuration land. A public setter would let a caller turn clearing off
    /// after writing sensitive bytes, and those buffers would reach the array pool unzeroed.
    /// </para>
    /// <para>
    /// Settings are not part of the reset, so a writer sitting in the pool still carries the last
    /// renter's values. Callers must therefore configure on every rent, not only when the settings
    /// differ from the defaults.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="defaultChunkSize"/> is less than one.</exception>
    internal void Configure(bool clearArray, int defaultChunkSize, int maxChunkSize)
    {
        // Only the starting size is constrained. A maximum at or below it is meaningful rather than
        // wrong: the ramp in CheckAndAllocateBuffer is guarded by _chunkSize < _maxChunkSize, so such
        // a pairing simply pins every chunk to defaultChunkSize.
        if (defaultChunkSize < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(defaultChunkSize), defaultChunkSize, "The chunk size must be at least one element.");
        }

        _clearArray = clearArray;
        _defaultChunkSize = defaultChunkSize;
        _maxChunkSize = maxChunkSize;
        _chunkSize = defaultChunkSize;

        // A stale second Dispose falls through to the teardown path and sets _disposed, even though
        // the instance is by then sitting in the pool. Clearing it as the writer leaves the pool is
        // what stops the next renter inheriting that. An instance that was genuinely disposed cannot
        // reach here: the pool policy's TryReset rejects it and disposes it instead of pooling it.
        _disposed = false;
    }

    /// <summary>
    /// Associates this writer with the pool it was rented from, so that <see cref="Dispose"/> returns
    /// it there instead of destroying it.
    /// </summary>
    /// <param name="pool">The owning pool.</param>
    internal void AttachPool(ObjectPool<ArrayPoolBufferWriter<T>> pool)
    {
        _pool = pool;
    }

    /// <summary>
    /// Returns every rented array to <see cref="ArrayPool{T}"/> and clears the segment chain.
    /// </summary>
    /// <remarks>
    /// <see cref="AddSegment"/> runs first so the in-progress buffer is dealt with too: it is either
    /// folded into the chain and released with it, or — when nothing was written into it — returned
    /// directly. Without that step a writer torn down between <see cref="GetSpan"/> and the next
    /// segment boundary would strand its current buffer outside the pool.
    /// </remarks>
    private void ReleaseSegments()
    {
        AddSegment();

        ArrayPoolBufferSegment<T>? segment = _firstSegment;
        while (segment != null)
        {
            segment.Return(_clearArray);
            segment = (ArrayPoolBufferSegment<T>?)segment.Next;
        }

        _firstSegment = _nextSegment = null;
    }

    /// <inheritdoc/>
    public void Advance(int count)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be non-negative.");
        if (_offset + count > _currentBuffer.Length) throw new ArgumentOutOfRangeException(nameof(count), $"Cannot advance to {_offset + count} at the end of the buffer, which has a size of {_currentBuffer.Length}.");

        _offset += count;
    }

    /// <inheritdoc/>
    public Memory<T> GetMemory(int sizeHint = 0)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (sizeHint < 0) throw new ArgumentOutOfRangeException(nameof(sizeHint), $"{nameof(sizeHint)} must be non-negative.");

        int remainingSpace = CheckAndAllocateBuffer(sizeHint);
        return _currentBuffer.AsMemory(_offset, remainingSpace);
    }

    /// <inheritdoc/>
    public Span<T> GetSpan(int sizeHint = 0)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (sizeHint < 0) throw new ArgumentOutOfRangeException(nameof(sizeHint), $"{nameof(sizeHint)} must be non-negative.");

        int remainingSpace = CheckAndAllocateBuffer(sizeHint);
        return _currentBuffer.AsSpan(_offset, remainingSpace);
    }

    /// <summary>
    /// Get a ReadOnlySequence that represents the written data.
    /// The sequence is only valid until the next write operation or
    /// until the writer is disposed.
    /// </summary>
    /// <remarks>
    /// The sequence borrows the writer's buffers; it does not own them. Use
    /// <see cref="LeaseSequence"/> when the payload has to leave the scope that built it.
    /// </remarks>
    public ReadOnlySequence<T> GetReadOnlySequence()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));

        AddSegment();

        if (_firstSegment == null || _nextSegment == null)
        {
            return ReadOnlySequence<T>.Empty;
        }

        return new ReadOnlySequence<T>(_firstSegment, 0, _nextSegment, _nextSegment.Memory.Length);
    }

    /// <summary>
    /// Pairs the written data with this writer as a single disposable value, so the payload can leave
    /// the scope that produced it.
    /// </summary>
    /// <returns>
    /// A <see cref="SequenceLease{T}"/> over the written data. Disposing it disposes this writer,
    /// which returns it to its pool if it was rented, and its buffers to the array pool.
    /// </returns>
    /// <remarks>
    /// <para>
    /// This allocates nothing — the lease is a struct, and the sequence is the one this writer already
    /// holds. It is the cheapest way to hand a payload to a caller:
    /// </para>
    /// <code>
    ///     static SequenceLease&lt;byte&gt; BuildPayload()
    ///     {
    ///         var writer = ObjectPools.RentBufferWriter&lt;byte&gt;();   // deliberately not `using`
    ///         Serialize(writer);
    ///         return writer.LeaseSequence();
    ///     }
    ///
    ///     using SequenceLease&lt;byte&gt; payload = BuildPayload();
    ///     Send(payload.Sequence);
    /// </code>
    /// <para>
    /// The writer stays alive for the life of the lease, so a rented one stays out of its pool for
    /// that long. Do not write to the writer after leasing: that invalidates the leased sequence
    /// exactly as it would one from <see cref="GetReadOnlySequence"/>.
    /// </para>
    /// </remarks>
    /// <exception cref="ObjectDisposedException">The writer has been disposed.</exception>
    public SequenceLease<T> LeaseSequence()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));

        return new SequenceLease<T>(GetReadOnlySequence(), this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddSegment()
    {
        if (_offset > 0)
        {
            if (_firstSegment == null)
            {
                _firstSegment = _nextSegment = new ArrayPoolBufferSegment<T>(_currentBuffer, 0, _offset);
            }
            else
            {
                _nextSegment = _nextSegment!.Append(_currentBuffer, 0, _offset);
            }
        }
        else if (_currentBuffer.Length > 0)
        {
            ArrayPool<T>.Shared.Return(_currentBuffer, _clearArray);
        }

        _offset = 0;
        _currentBuffer = _emptyBuffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int CheckAndAllocateBuffer(int sizeHint)
    {
        int remainingSpace = _currentBuffer.Length - _offset;
        if (remainingSpace < sizeHint || sizeHint == 0)
        {
            AddSegment();

            remainingSpace = Math.Max(sizeHint, _chunkSize);
            _currentBuffer = ArrayPool<T>.Shared.Rent(remainingSpace);
            _offset = 0;

            if (_chunkSize < _maxChunkSize)
            {
                _chunkSize = Math.Min(_maxChunkSize, _chunkSize * 2);
            }
        }

        return remainingSpace;
    }
}
