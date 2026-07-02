// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An allocation-free async-compatible exclusive lock implemented with pooled ValueTask sources.
/// Note that this lock is <b>not</b> recursive!
/// </summary>
/// <remarks>
/// /// <para>
/// <b>Optional timeout and cancellation token</b> parameters on <see cref="LockAsync(TimeSpan, CancellationToken)"/>.
/// </para>
/// 
/// <para>
/// <b>Allocation Behavior:</b> Immediate acquisitions are completely allocation-free using atomic 
/// operations. When the lock is contended, waiting without a timeout is allocation-free on .NET 6.0+ 
/// (using <c>UnsafeRegister</c> for cancellation), while older frameworks may allocate for cancellation 
/// registration. Specifying a finite timeout allocates a timer that is automatically disposed when the 
/// operation completes. Exception and task allocations occur only if a timeout actually elapses or 
/// cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled 
/// <see cref="IValueTaskSource{Releaser}"/> instances are reused to minimize allocation pressure across 
/// repeated lock operations.
/// </para>
/// 
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
/// <para>To replace the blocking operation <c>Thread.Sleep</c> with an asynchronous equivalent,
/// it's not directly possible because of the <c>lock</c> block. We cannot <c>await</c> inside
/// of a <c>lock</c>.</para>
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
/// 
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse
/// by an implementation of an <see cref="ObjectPool"/> that uses the <see cref="DefaultObjectPool{T}"/> implementation.
/// </remarks>
public sealed class AsyncLock : IResettable
{
    private readonly LocalManualResetValueTaskSource<Releaser> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<Releaser> _pool;
    private Internal.SpinLock _spinLock;
    private WaiterQueue<Releaser> _waiters;
    private volatile int _taken;

    /// <summary>
    /// Constructs a new AsyncLock instance with optional custom pool and custom default queue size.
    /// </summary>
    /// <param name="pool">Custom pool for this instance.</param>
    public AsyncLock(IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
    {
        _waiters = new();
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolAsyncLockReleaser;
        _spinLock = new();
        _taken = 0;
        _localWaiter = new(this);
        _localWaiter.RunContinuationsAsynchronously = true;
    }

    /// <inheritdoc/>
    public bool TryReset()
    {
        // check if lock is not in use before recycling the instance,
        // if the lock is currently held, it cannot be reset and reused
        if (!_spinLock.TryEnter())
        {
            return false;
        }

        try
        {
            // If the lock is held or waiters are queued the instance is still in active use;
            // decline the reset.
            if (_taken != 0 || _waiters.Count != 0)
            {
                return false;
            }

            _localWaiter.TryReset();
            _localWaiter.RunContinuationsAsynchronously = true;
            return true;
        }
        finally
        {
            _spinLock.Exit();
        }
    }

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncLock _owner;

        internal Releaser(AsyncLock owner)
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
            => obj is Releaser other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Releaser other)
            => ReferenceEquals(_owner, other._owner);

        /// <inheritdoc/>
        public override int GetHashCode()
            => _owner is null ? 0 : _owner.GetHashCode();

        /// <summary>
        /// Determines whether two <see cref="Releaser"/> instances are equal.
        /// </summary>
        /// <param name="left">The first Releaser to compare.</param>
        /// <param name="right">The second Releaser to compare.</param>
        /// <returns>true if the specified Releaser instances are equal; otherwise, false.</returns>
        public static bool operator ==(Releaser left, Releaser right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="Releaser"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first Releaser to compare.</param>
        /// <param name="right">The second Releaser to compare.</param>
        /// <returns>false if the specified Releaser instances are equal; otherwise, true.</returns>
        public static bool operator !=(Releaser left, Releaser right)
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
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired.
    /// Dispose the returned releaser to release the lock.
    /// </returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)
    {
        if (Interlocked.Exchange(ref _taken, 1) == 0)
        {
            return new ValueTask<Releaser>(new Releaser(this));
        }

        return LockAsyncImpl(Timeout.InfiniteTimeSpan, cancellationToken);
    }

    /// <summary>
    /// Asynchronously acquires the lock, or throws if the lock cannot be acquired before the timeout elapses.
    /// </summary>
    /// <remarks>
    /// If the lock is immediately available, the method completes synchronously without allocating any
    /// cancellation infrastructure. A <see cref="CancellationTokenSource"/> is allocated only when the
    /// lock cannot be acquired immediately and a finite positive timeout is requested; it is disposed
    /// automatically when the returned <see cref="ValueTask{Releaser}"/> is awaited.
    /// </remarks>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired.
    /// Dispose the returned releaser to release the lock.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when the timeout elapses before the lock can be acquired.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        if (Interlocked.Exchange(ref _taken, 1) == 0)
        {
            return new ValueTask<Releaser>(new Releaser(this));
        }

        if (timeout == TimeSpan.Zero)
        {
            return new ValueTask<Releaser>(Task.FromException<Releaser>(new OperationCanceledException()));
        }

        return LockAsyncImpl(timeout, cancellationToken);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask<Releaser> LockAsyncImpl(TimeSpan timeout, CancellationToken cancellationToken)
    {
        ManualResetValueTaskSource<Releaser> waiter;
        short version;

        _spinLock.Enter();
        try
        {
            if (Interlocked.Exchange(ref _taken, 1) == 0)
            {
                return new ValueTask<Releaser>(new Releaser(this));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
                waiter.RunContinuationsAsynchronously = true;
            }

            waiter.CancellationToken = cancellationToken;

            version = waiter.Version;
            _waiters.Enqueue(waiter);

            if (timeout != Timeout.InfiniteTimeSpan)
            {
                waiter.TimeoutTimer = TimeProvider.System.CreateTimer(
                    TimerCallback, waiter, timeout, Timeout.InfiniteTimeSpan);
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        if (cancellationToken.CanBeCanceled)
        {
#if NET6_0_OR_GREATER
            // Use UnsafeRegister on .NET 6+ for allocation free registration
            waiter.CancellationTokenRegistration =
                cancellationToken.UnsafeRegister(_cancellationCallbackAction, waiter);
#else
            waiter.CancellationTokenRegistration =
                cancellationToken.Register(CancellationCallback, waiter, useSynchronizationContext: false);
#endif
        }
        else
        {
            Debug.Assert(waiter.CancellationTokenRegistration == default);
        }

        return new ValueTask<Releaser>(waiter, version);
    }

    /// <summary>
    /// Whether the lock is currently held.
    /// </summary>
    public bool IsTaken => _taken != 0;

    /// <summary>
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

    /// <summary>
    /// Releases the lock. If any waiters are queued, the next waiter acquires the lock.
    /// </summary>
    internal void ReleaseLock()
    {
        ManualResetValueTaskSource<Releaser> toRelease;

        _spinLock.Enter();
        try
        {
            if (_waiters.Count == 0)
            {
                _taken = 0;
                return;
            }

            toRelease = _waiters.Dequeue();
        }
        finally
        {
            _spinLock.Exit();
        }

        toRelease.SetResult(new Releaser(this));
    }

    /// <summary>
    /// Callback used with <see cref="Timer"/> to trigger timeout.
    /// </summary>
    private void TimerCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }

        ManualResetValueTaskSource<Releaser>? toCancel = RemoveWaiter(waiter);
        toCancel?.SetException(ManualResetValueTaskSource<bool>.OperationCanceled);
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncLock)waiter.Owner!;
        context.CancellationCallback(waiter);
    };

    private void CancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void CancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = RemoveWaiter(waiter);
        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }

    /// <summary>
    /// O(1) removal from intrusive linked list.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ManualResetValueTaskSource<Releaser>? RemoveWaiter(ManualResetValueTaskSource<Releaser> waiter)
    {
        _spinLock.Enter();
        try
        {
            if (_waiters.Remove(waiter))
            {
                return waiter;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        return null;
    }
}
