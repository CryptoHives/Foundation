// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

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
/// <para>So, we use the <c>async</c>-compatible <see cref="PooledAsyncLock"/> instead:</para>
/// <code>
/// private readonly var _mutex = new PooledAsyncLock();
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
public sealed class PooledAsyncLock
{
    private readonly Queue<ManualResetValueTaskSource<Releaser>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
    private readonly LocalManualResetValueTaskSource<Releaser> _localWaiter = new();
    private bool _taken;

    // Pool for Releaser-typed value task sources.
    private static readonly ObjectPool<PooledManualResetValueTaskSource<Releaser>> _pool = new DefaultObjectPool<PooledManualResetValueTaskSource<Releaser>>(new PooledValueTaskSourceObjectPolicy<Releaser>());

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable
    {
        private readonly PooledAsyncLock _owner;

        internal Releaser(PooledAsyncLock owner)
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
    /// Asynchronously acquires the lock, with a cancellation token.
    /// </summary>
    /// <remarks>
    /// Note that this lock is <b>not</b> recursive!
    /// The returned ValueTask must be disposed to release the lock
    /// and can only be awaited one single time.
    /// Use the following pattern to synchronize async Tasks.
    /// <code>
    /// private readonly var _lock = new PooledAsyncLock();
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
    public ValueTask<Releaser> LockAsync()
        => LockAsync(CancellationToken.None);

    /// <summary>
    /// Asynchronously acquires the lock, with a cancellation token.
    /// </summary>
    /// <remarks>
    /// Note that this lock is <b>not</b> recursive!
    /// The returned ValueTask must be disposed to release the lock.
    /// Use the following pattern to synchronize async Tasks.
    /// <code>
    /// private readonly var _lock = new PooledAsyncLock();
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
    public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken)
    {
        lock (_waiters)
        {
            if (!_taken)
            {
                _taken = true;
                return new ValueTask<Releaser>(new Releaser(this));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromException<Releaser>(new OperationCanceledException(cancellationToken)));
            }

            if (_localWaiter.TryGetValueTaskSource())
            {
                _waiters.Enqueue(_localWaiter);
                return new ValueTask<Releaser>(_localWaiter, _localWaiter.Version);
            }

            PooledManualResetValueTaskSource<Releaser> waiter = _pool.Get();
            waiter.SetOwnerPool(_pool);
            _waiters.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Releases the lock. If any waiters are queued, the next waiter acquires the lock.
    /// </summary>
    internal void ReleaseLock()
    {
        ManualResetValueTaskSource<Releaser> toRelease;

        lock (_waiters)
        {
            if (_waiters.Count == 0)
            {
                _taken = false;
                return;
            }

            toRelease = _waiters.Dequeue();
        }

        toRelease.SetResult(new Releaser(this));
    }

    /// <summary>
    /// Whether the lock is currently held.
    /// </summary>
    public bool IsTaken
    {
        get { lock (_waiters) return _taken; }
    }
}
