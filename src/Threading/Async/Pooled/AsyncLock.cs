// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An allocation-free async-compatible exclusive lock implemented with pooled ValueTask sources.
/// Note that this lock is <b>not</b> recursive!
/// </summary>
/// <remarks>
/// <example>
/// <para>The vast majority of use cases are to just replace a <c>lock</c> statement. 
/// That is, with the original code looking like this:</para>
/// <code>
/// private readonly object _mutex = new object();
/// public void DoStuff()
/// {
///     lock (_mutex)
///     {
///         Thread.Sleep(TimeSpan.FromSeconds(1));
///     }
/// }
/// </code>
/// <para>To replace the blocking operation <c>Thread.Sleep</c> with an asynchronous equivalent, it's not directly possible because of the <c>lock</c> block. We cannot <c>await</c> inside of a <c>lock</c>.</para>
/// <para>So, we use the <c>async</c>-compatible <see cref="AsyncLock"/> instead:</para>
/// <code>
/// private readonly var _mutex = new AsyncLock();
/// public async Task DoStuffAsync()
/// {
///     using (await _mutex.LockAsync())
///     {
///         await Task.Delay(TimeSpan.FromSeconds(1));
///     }
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncLock
{
    private readonly Queue<ManualResetValueTaskSource<AsyncLockReleaser>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
    private readonly LocalManualResetValueTaskSource<AsyncLockReleaser> _localWaiter = new();
#if NET9_0_OR_GREATER
    private readonly Lock _mutex = new();
#else
    private readonly object _mutex = new();
#endif
    private volatile int _taken;

    // Pool for AsyncLockReleaser-typed value task sources.
    private static readonly ObjectPool<PooledManualResetValueTaskSource<AsyncLockReleaser>> _pool = new DefaultObjectPool<PooledManualResetValueTaskSource<AsyncLockReleaser>>(new PooledValueTaskSourceObjectPolicy<AsyncLockReleaser>());

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock.
    /// </summary>
    [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "By Design")]
    public readonly struct AsyncLockReleaser : IDisposable, IAsyncDisposable, IEquatable<AsyncLockReleaser>
    {
        private readonly AsyncLock _owner;

        internal AsyncLockReleaser(AsyncLock owner)
        {
            _owner = owner;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _owner.ReleaseLock();
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            _owner.ReleaseLock();
            return default;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is AsyncLockReleaser other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(AsyncLockReleaser other)
            => ReferenceEquals(_owner, other._owner);

        /// <inheritdoc/>
        public override int GetHashCode()
            => _owner is null ? 0 : _owner.GetHashCode();

        /// <summary>
        /// Determines whether two AsyncLockReleaser instances are equal.
        /// </summary>
        /// <param name="left">The first AsyncLockReleaser to compare.</param>
        /// <param name="right">The second AsyncLockReleaser to compare.</param>
        /// <returns>true if the specified AsyncLockReleaser instances are equal; otherwise, false.</returns>
        public static bool operator ==(AsyncLockReleaser left, AsyncLockReleaser right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two AsyncLockReleaser instances are not equal.
        /// </summary>
        /// <param name="left">The first AsyncLockReleaser to compare.</param>
        /// <param name="right">The second AsyncLockReleaser to compare.</param>
        /// <returns>false if the specified AsyncLockReleaser instances are equal; otherwise, true.</returns>
        public static bool operator !=(AsyncLockReleaser left, AsyncLockReleaser right)
            => !left.Equals(right);
    }

    /// <summary>
    /// Asynchronously acquires the lock.
    /// </summary>
    /// <remarks>
    /// Note that this lock is <b>not</b> recursive!
    /// The returned ValueTask must be disposed to release the lock
    /// and can only be awaited one single time.
    /// Use the following pattern to synchronize async Tasks.
    /// <code>
    /// private readonly var _lock = new AsyncLock();
    /// public async Task DoStuffAsync()
    /// {
    ///     using (await _lock.LockAsync())
    ///     {
    ///         await Task.Delay(TimeSpan.FromSeconds(1));
    ///     }
    /// }
    /// </code>
    /// </remarks>
    /// <returns>A <see cref="ValueTask{AsyncLockReleaser}"/> that completes when the lock is acquired.  Dispose the returned releaser to release the lock.</returns>
    public ValueTask<AsyncLockReleaser> LockAsync()
        => LockAsync(CancellationToken.None);

    /// <summary>
    /// Asynchronously acquires the lock, with a cancellation token.
    /// At this time the cancellation token is only observed before 
    /// queuing if the lock is already acquired.
    /// </summary>
    /// <remarks>
    /// Note that this lock is <b>not</b> recursive!
    /// The returned ValueTask must be disposed to release the lock.
    /// Use the following pattern to synchronize async Tasks.
    /// <code>
    /// private readonly var _lock = new AsyncLock();
    /// public async Task DoStuffAsync(CancellationToken ct)
    /// {
    ///     using (await _lock.LockAsync(ct))
    ///     {
    ///         await Task.Delay(TimeSpan.FromSeconds(1));
    ///     }
    /// }
    /// </code>
    /// </remarks>
    /// <param name="ct">The cancellation token. Cancellation is only observed before queuing.</param>
    /// <returns>A <see cref="ValueTask{AsyncLockReleaser}"/> that completes when the lock is acquired.  Dispose the returned releaser to release the lock.</returns>
    public ValueTask<AsyncLockReleaser> LockAsync(CancellationToken ct)
    {
        if (Interlocked.Exchange(ref _taken, 1) == 0)
        {
            return new ValueTask<AsyncLockReleaser>(new AsyncLockReleaser(this));
        }

        lock (_mutex)
        {
            if (Interlocked.Exchange(ref _taken, 1) == 0)
            {
                return new ValueTask<AsyncLockReleaser>(new AsyncLockReleaser(this));
            }

            if (ct.IsCancellationRequested)
            {
                return new ValueTask<AsyncLockReleaser>(Task.FromException<AsyncLockReleaser>(new OperationCanceledException(ct)));
            }

            return QueueWaiter(ct);
        }
    }

    /// <summary>
    /// Releases the lock. If any waiters are queued, the next waiter acquires the lock.
    /// </summary>
    internal void ReleaseLock()
    {
        ManualResetValueTaskSource<AsyncLockReleaser> toRelease;

        lock (_mutex)
        {
            if (_waiters.Count == 0)
            {
                Interlocked.Exchange(ref _taken, 0);
                return;
            }

            toRelease = _waiters.Dequeue();
        }

        toRelease.SetResult(new AsyncLockReleaser(this));
    }

    /// <summary>
    /// Queue a waiter for the lock. Expects the caller to hold the mutex.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ValueTask<AsyncLockReleaser> QueueWaiter(CancellationToken ct)
    {
        ManualResetValueTaskSource<AsyncLockReleaser> waiter;
        if (!_localWaiter.TryGetValueTaskSource(out waiter))
        {
            var pooledWaiter = _pool.Get();
            pooledWaiter.SetOwnerPool(_pool);
            waiter = pooledWaiter;
        }

        waiter.CancellationToken = ct;
        waiter.RunContinuationsAsynchronously = true;

        if (ct.CanBeCanceled)
        {
            waiter.CancellationTokenRegistration = ct.Register((state) => {
                var waiter = state as ManualResetValueTaskSource<AsyncLockReleaser>;
                if (waiter != null)
                {
                    ManualResetValueTaskSource<AsyncLockReleaser>? toCancel = null;
                    lock (_mutex)
                    {
                        int count = _waiters.Count;
                        while (count-- > 0)
                        {
                            var dequeued = _waiters.Dequeue();
                            if (ReferenceEquals(dequeued, waiter))
                            {
                                toCancel = waiter;
                                break;
                            }
                            _waiters.Enqueue(dequeued);
                        }
                    }

                    toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
                }
            }, state: waiter, useSynchronizationContext: false);
        }
        else
        {
            waiter.CancellationTokenRegistration = default;
        }

        _waiters.Enqueue(waiter);
        return new ValueTask<AsyncLockReleaser>(waiter, waiter.Version);
    }

    /// <summary>
    /// Whether the lock is currently held.
    /// </summary>
    public bool IsTaken => _taken != 0;
}
