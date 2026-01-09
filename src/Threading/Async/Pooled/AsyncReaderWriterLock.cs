// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async reader-writer lock which uses a pooled approach to implement waiters
/// for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free
/// async signaling by reusing pooled <see cref="IValueTaskSource{TResult}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{TResult}"/> and <see cref="Task"/>.
/// </para>
/// <para>
/// The lock supports multiple concurrent readers or a single exclusive writer.
/// Writer requests are prioritized over new reader requests to prevent writer starvation.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> Awaiting on <see cref="ValueTask"/> has its own caveats, as it
/// is a struct that can only be awaited or converted with AsTask() ONE single time.
/// Additional attempts to await after the first await or additional conversions to AsTask() will throw
/// an <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// <b>Continuation Scheduling:</b> The <see cref="RunContinuationAsynchronously"/> property
/// controls how continuations are executed when the lock is released. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncReaderWriterLock _rwLock = new AsyncReaderWriterLock();
///
/// public async Task ReadAsync(CancellationToken ct)
/// {
///     using (await _rwLock.ReaderLockAsync(ct))
///     {
///         // Multiple readers can hold the lock concurrently
///         await ReadDataAsync();
///     }
/// }
///
/// public async Task WriteAsync(CancellationToken ct)
/// {
///     using (await _rwLock.WriterLockAsync(ct))
///     {
///         // Exclusive access - no other readers or writers
///         await WriteDataAsync();
///     }
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncReaderWriterLock
{
    private readonly IGetPooledManualResetValueTaskSource<Releaser> _pool;

    private readonly Queue<ManualResetValueTaskSource<Releaser>> _waitingWriters;
    private readonly LocalManualResetValueTaskSource<Releaser> _localWriterWaiter;

    private readonly Queue<ManualResetValueTaskSource<Releaser>> _waitingReaders;
    private readonly LocalManualResetValueTaskSource<Releaser> _localReaderWaiter;

#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif

    private int _status;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncReaderWriterLock _owner;
        private readonly bool _isWriter;

        internal Releaser(AsyncReaderWriterLock owner, bool isWriter)
        {
            _owner = owner;
            _isWriter = isWriter;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_owner is not null)
            {
                if (_isWriter)
                {
                    _owner.ReleaseWriterLock();
                }
                else
                {
                    _owner.ReleaseReaderLock();
                }
            }
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is Releaser other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Releaser other)
            => ReferenceEquals(_owner, other._owner) && _isWriter == other._isWriter;

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(_owner, _isWriter);
        }

        /// <summary>
        /// Determines whether two Releaser instances are equal.
        /// </summary>
        public static bool operator ==(Releaser left, Releaser right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two Releaser instances are not equal.
        /// </summary>
        public static bool operator !=(Releaser left, Releaser right)
            => !left.Equals(right);
    }

    /// <summary>
    /// Constructs a new AsyncReaderWriterLock instance.
    /// </summary>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    /// <param name="pool">Custom pool for waiters.</param>
    public AsyncReaderWriterLock(
        bool runContinuationAsynchronously = true,
        int defaultEventQueueSize = 0,
        IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
    {
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _mutex = new();

        int queueSize = defaultEventQueueSize > 0 ? defaultEventQueueSize : ValueTaskSourceObjectPools.DefaultEventQueueSize;

        _waitingWriters = new(queueSize);
        _localWriterWaiter = new(this);

        _waitingReaders = new(queueSize);
        _localReaderWaiter = new(this);

        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolAsyncReaderWriterLockReleaser;

        _status = 0;
    }

    /// <summary>
    /// Gets whether the lock is currently held by any readers.
    /// </summary>
    public bool IsReaderLockHeld
    {
        get { lock (_mutex) return _status > 0; }
    }

    /// <summary>
    /// Gets whether the lock is currently held by a writer.
    /// </summary>
    public bool IsWriterLockHeld
    {
        get { lock (_mutex) return _status < 0; }
    }

    /// <summary>
    /// Gets the current number of readers holding the lock.
    /// </summary>
    public int CurrentReaderCount
    {
        get { lock (_mutex) return _status > 0 ? _status : 0; }
    }

    /// <summary>
    /// Gets the number of writers waiting for the lock.
    /// </summary>
    public int WaitingWriterCount
    {
        get { lock (_mutex) return _waitingWriters.Count; }
    }

    /// <summary>
    /// Gets the number of readers waiting for the lock.
    /// </summary>
    public int WaitingReaderCount
    {
        get { lock (_mutex) return _waitingReaders.Count; }
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Asynchronously acquires a reader lock.
    /// </summary>
    /// <remarks>
    /// Multiple readers can hold the lock concurrently. If a writer is waiting,
    /// new readers will be queued behind the writer to prevent writer starvation.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the reader lock is acquired.</returns>
    public ValueTask<Releaser> ReaderLockAsync(CancellationToken cancellationToken = default)
    {
        lock (_mutex)
        {
            if (_status >= 0 && _waitingWriters.Count == 0)
            {
                _status++;
                return new ValueTask<Releaser>(new Releaser(this, false));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localReaderWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_readerCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(ReaderCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingReaders.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Asynchronously acquires a writer lock.
    /// </summary>
    /// <remarks>
    /// Only one writer can hold the lock at a time, and no readers can hold the lock
    /// while a writer has it. Writers are prioritized over new readers.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the writer lock is acquired.</returns>
    public ValueTask<Releaser> WriterLockAsync(CancellationToken cancellationToken = default)
    {
        lock (_mutex)
        {
            if (_status == 0)
            {
                _status = -1;
                return new ValueTask<Releaser>(new Releaser(this, true));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localWriterWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_writerCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(WriterCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingWriters.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Gets a value indicating whether the local reader waiter is currently in use.
    /// </summary>
    internal bool InternalReaderWaiterInUse => _localReaderWaiter.InUse;

    /// <summary>
    /// Gets a value indicating whether the local writer waiter is currently in use.
    /// </summary>
    internal bool InternalWriterWaiterInUse => _localWriterWaiter.InUse;

    private void ReleaseReaderLock()
    {
        ManualResetValueTaskSource<Releaser>? toWake = null;

        lock (_mutex)
        {
            Debug.Assert(_status > 0, "Reader lock should be held.");
            _status--;

            if (_status == 0 && _waitingWriters.Count > 0)
            {
                _status = -1;
                toWake = _waitingWriters.Dequeue();
            }
        }

        toWake?.SetResult(new Releaser(this, true));
    }

    private void ReleaseWriterLock()
    {
        ManualResetValueTaskSource<Releaser>? writerToWake = null;
        ManualResetValueTaskSource<Releaser>[]? readersToWake = null;
        int readerCount = 0;

        lock (_mutex)
        {
            Debug.Assert(_status == -1, "Writer lock should be held.");

            if (_waitingWriters.Count > 0)
            {
                writerToWake = _waitingWriters.Dequeue();
            }
            else if (_waitingReaders.Count > 0)
            {
                readerCount = _waitingReaders.Count;
                readersToWake = ArrayPool<ManualResetValueTaskSource<Releaser>>.Shared.Rent(readerCount);
                for (int i = 0; i < readerCount; i++)
                {
                    readersToWake[i] = _waitingReaders.Dequeue();
                }
                _status = readerCount;
            }
            else
            {
                _status = 0;
            }
        }

        if (writerToWake is not null)
        {
            writerToWake.SetResult(new Releaser(this, true));
        }
        else if (readersToWake is not null)
        {
            try
            {
                for (int i = 0; i < readerCount; i++)
                {
                    readersToWake[i].SetResult(new Releaser(this, false));
                }
            }
            finally
            {
                ArrayPool<ManualResetValueTaskSource<Releaser>>.Shared.Return(readersToWake);
            }
        }
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _readerCancellationCallbackAction = static (state, ct) =>
    {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.ReaderCancellationCallback(waiter);
    };

    private void ReaderCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void ReaderCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            int count = _waitingReaders.Count;
            while (count-- > 0)
            {
                var dequeued = _waitingReaders.Dequeue();
                if (ReferenceEquals(dequeued, waiter))
                {
                    toCancel = waiter;
                    continue;
                }
                _waitingReaders.Enqueue(dequeued);
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _writerCancellationCallbackAction = static (state, ct) =>
    {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.WriterCancellationCallback(waiter);
    };

    private void WriterCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void WriterCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            int count = _waitingWriters.Count;
            while (count-- > 0)
            {
                var dequeued = _waitingWriters.Dequeue();
                if (ReferenceEquals(dequeued, waiter))
                {
                    toCancel = waiter;
                    continue;
                }
                _waitingWriters.Enqueue(dequeued);
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }
}
