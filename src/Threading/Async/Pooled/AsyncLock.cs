// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An allocation-free async-compatible exclusive lock implemented with pooled ValueTask sources.
/// Note that this lock is <b>not</b> recursive!
/// </summary>
/// <remarks>
/// <example>
/// <para>The vast majority of use cases are to just replace a <c>lock</c> statement. That is, with the original code looking like this:</para>
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
/// <para>If we want to replace the blocking operation <c>Thread.Sleep</c> with an asynchronous equivalent, it's not directly possible because of the <c>lock</c> block. We cannot <c>await</c> inside of a <c>lock</c>.</para>
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
    public readonly struct AsyncLockReleaser : IDisposable, IAsyncDisposable
    {
        private readonly AsyncLock _owner;

        internal AsyncLockReleaser(AsyncLock owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Releases the lock.
        /// </summary>
        public void Dispose()
        {
            _owner.ReleaseLock();
        }

        /// <summary>
        /// Asynchronously releases the lock (synchronous for this implementation).
        /// </summary>
        public ValueTask DisposeAsync()
        {
            _owner.ReleaseLock();
            return default;
        }
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
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired.  Dispose the returned releaser to release the lock.</returns>
    public ValueTask<AsyncLockReleaser> LockAsync()
        => LockAsync(CancellationToken.None);

    /// <summary>
    /// Asynchronously acquires the lock, with a cancellation token.
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
    /// <param name="cancellationToken">The cancellation token. Cancellation is observed before queuing.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired.  Dispose the returned releaser to release the lock.</returns>
    public ValueTask<AsyncLockReleaser> LockAsync(CancellationToken cancellationToken)
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

            ManualResetValueTaskSource<AsyncLockReleaser> waiter;
            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                var pooledWaiter = _pool.Get();
                pooledWaiter.SetOwnerPool(_pool);
                waiter = pooledWaiter;
            }

            waiter.RunContinuationsAsynchronously = true;
            _waiters.Enqueue(waiter);
            return new ValueTask<AsyncLockReleaser>(waiter, waiter.Version);
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
    /// Whether the lock is currently held.
    /// </summary>
    public bool IsTaken => _taken != 0;
}
