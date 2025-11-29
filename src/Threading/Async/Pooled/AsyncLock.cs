// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
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
    private readonly Queue<ManualResetValueTaskSource<AsyncLockReleaser>> _waiters;
    private readonly ObjectPool<PooledManualResetValueTaskSource<AsyncLockReleaser>> _pool;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
    private volatile int _taken;

    /// <summary>
    /// Constructs a new AsyncLock instance with optional custom pool and custom default queue size.
    /// </summary>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    public AsyncLock(int defaultEventQueueSize = 0, ObjectPool<PooledManualResetValueTaskSource<AsyncLockReleaser>>? pool = null)
    {
        _waiters = new(defaultEventQueueSize > 0 ? defaultEventQueueSize : ValueTaskSourceObjectPools.DefaultEventQueueSize);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolAsyncLockReleaser;
        _mutex = new();
        _taken = 0;
    }

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock.
    /// </summary>
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
    /// Asynchronously acquires the lock, with a cancellation token.
    /// The cancellation token is only observed if the lock can not
    /// be acquired immediately.
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
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A <see cref="ValueTask{AsyncLockReleaser}"/> that completes when the lock is acquired.
    /// Dispose the returned releaser to release the lock.
    /// </returns>
    public ValueTask<AsyncLockReleaser> LockAsync(CancellationToken cancellationToken = default)
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

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<AsyncLockReleaser>(Task.FromException<AsyncLockReleaser>(new OperationCanceledException(cancellationToken)));
            }

            var waiter = _pool.Get();
            waiter.RunContinuationsAsynchronously = true;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
                waiter.CancellationTokenRegistration = cancellationToken.Register(CancellationCallback, state: waiter, useSynchronizationContext: false);
            }
            else
            {
                waiter.CancellationTokenRegistration = default;
            }

            _waiters.Enqueue(waiter);
            return new ValueTask<AsyncLockReleaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Whether the lock is currently held.
    /// </summary>
    public bool IsTaken => _taken != 0;

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

    private void CancellationCallback(object? state)
    {
        if (state is ManualResetValueTaskSource<AsyncLockReleaser> waiter)
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
    }
}
