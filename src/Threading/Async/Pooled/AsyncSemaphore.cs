// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async version of <see cref="SemaphoreSlim"/> which uses a pooled approach
/// to implement waiters for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free
/// async signaling by reusing pooled <see cref="IValueTaskSource{TResult}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{TResult}"/> and <see cref="Task"/>.
/// </para>
/// <para>
/// <b>Optional timeout and cancellation token</b> parameters on <see cref="WaitAsync(TimeSpan, CancellationToken)"/>.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> Awaiting on <see cref="ValueTask"/> has its own caveats, as it
/// is a struct that can only be awaited or converted with AsTask() ONE single time.
/// Additional attempts to await after the first await or additional conversions to AsTask() will throw
/// an <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// <b>Continuation Scheduling:</b> The <see cref="RunContinuationAsynchronously"/> property
/// controls how continuations are executed when a permit is released. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool, preventing the releasing thread from
/// being blocked by continuation execution.
/// </para>
/// <para>
/// <b>Allocation Behavior:</b> Immediate acquisitions are completely allocation-free using atomic 
/// operations. When the semaphore is contended, waiting without a timeout is allocation-free on .NET 6.0+ 
/// (using <c>UnsafeRegister</c> for cancellation), while older frameworks may allocate for cancellation 
/// registration. Specifying a finite timeout allocates a timer that is automatically disposed when the 
/// operation completes. Exception and task allocations occur only if a timeout actually elapses or 
/// cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled 
/// <see cref="IValueTaskSource{TResult}"/> instances are reused to minimize allocation pressure across 
/// repeated lock operations.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncSemaphore _semaphore = new AsyncSemaphore(3);
///
/// public async Task AccessLimitedResourceAsync(CancellationToken ct)
/// {
///     await _semaphore.WaitAsync(ct);
///     try
///     {
///         // Access limited resource (max 3 concurrent)
///         await DoWorkAsync();
///     }
///     finally
///     {
///         _semaphore.Release();
///     }
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncSemaphore
{
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private WaiterQueue<bool> _waiters;
    private Internal.SpinLock _spinLock;
    private int _currentCount;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Constructs a new AsyncSemaphore instance with the specified initial count.
    /// </summary>
    /// <param name="initialCount">The initial number of permits available.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="initialCount"/> is negative.</exception>
    public AsyncSemaphore(int initialCount, bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (initialCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCount), initialCount, "Initial count must be non-negative.");
        }

        _currentCount = initialCount;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _spinLock = new();
        _waiters = new();
        _localWaiter = new(this);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets the current count of available permits.
    /// </summary>
    public int CurrentCount
    {
        get => Volatile.Read(ref _currentCount);
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When <see langword="true"/> (default), continuations are queued to the thread pool when a permit
    /// is released, preventing the releasing thread from being blocked by continuation execution.
    /// When <see langword="false"/>, continuations may execute synchronously on the releasing thread.
    /// </para>
    /// </remarks>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Asynchronously waits to acquire a permit from the semaphore.
    /// </summary>
    /// <remarks>
    /// If a permit is available, the method returns a completed <see cref="ValueTask"/>.
    /// Otherwise, it enqueues a waiter and returns a task that completes when a permit becomes available.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when a permit is acquired.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        while (true)
        {
            int observed = Volatile.Read(ref _currentCount);
            if (observed <= 0)
            {
                break;
            }

            if (Interlocked.CompareExchange(ref _currentCount, observed - 1, observed) == observed)
            {
                return default;
            }

            // retry until race condition succeeds
        }

        return WaitAsyncImpl(Timeout.InfiniteTimeSpan, cancellationToken);
    }


    /// <summary>
    /// Asynchronously waits to acquire a permit from the semaphore, or until the specified timeout elapses.
    /// </summary>
    /// <remarks>
    /// If a permit is available, the method returns a completed <see cref="ValueTask"/> immediately
    /// without allocating any cancellation infrastructure. A <see cref="CancellationTokenSource"/> is allocated
    /// only when no permit is available and a finite positive timeout is requested; it is disposed
    /// automatically when the returned <see cref="ValueTask"/> is awaited.
    /// </remarks>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when a permit is acquired.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the timeout elapses before a permit becomes available.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before a permit becomes available.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout == Timeout.InfiniteTimeSpan)
        {
            return WaitAsync(cancellationToken);
        }

        if (timeout < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(timeout));

        // fast path without lock
        while (true)
        {
            int observed = Volatile.Read(ref _currentCount);
            if (observed <= 0)
            {
                break;
            }

            if (Interlocked.CompareExchange(ref _currentCount, observed - 1, observed) == observed)
            {
                return default;
            }
        }

        if (timeout == TimeSpan.Zero)
        {
            return new ValueTask(Task.FromException(new TimeoutException()));
        }

        return WaitAsyncImpl(timeout, cancellationToken);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask WaitAsyncImpl(TimeSpan timeout, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
        }

        ManualResetValueTaskSource<bool> waiter;
        short version;

        _spinLock.Enter();
        try
        {
            // due to race conditions, count may have changed until the lock is taken
            while (true)
            {
                int observed = Volatile.Read(ref _currentCount);
                if (observed <= 0)
                {
                    break;
                }

                if (Interlocked.CompareExchange(ref _currentCount, observed - 1, observed) == observed)
                {
                    return default;
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask(Task.FromCanceled(cancellationToken));
            }

            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
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

        return new ValueTask(waiter, version);
    }

    /// <summary>
    /// Releases a permit back to the semaphore.
    /// </summary>
    /// <remarks>
    /// If any waiters are queued, the next waiter acquires the permit.
    /// Otherwise, the available count is incremented.
    /// </remarks>
    public void Release()
    {
        Release(1);
    }

    /// <summary>
    /// Releases the specified number of permits back to the semaphore.
    /// </summary>
    /// <param name="releaseCount">The number of permits to release.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="releaseCount"/> is less than 1.</exception>
    public void Release(int releaseCount)
    {
        if (releaseCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(releaseCount), releaseCount, "Release count must be at least 1.");
        }

        ManualResetValueTaskSource<bool>? toReleaseChain = null;

        _spinLock.Enter();
        try
        {
            int waitersToRelease = Math.Min(releaseCount, _waiters.Count);
            int remainingReleases = releaseCount - waitersToRelease;

            if (waitersToRelease > 0)
            {
                toReleaseChain = _waiters.DetachUpTo(waitersToRelease, out _);
            }

            Interlocked.Add(ref _currentCount, remainingReleases);
        }
        finally
        {
            _spinLock.Exit();
        }

        toReleaseChain?.SetChainResult(true);
    }

    /// <summary>
    /// Callback used with <see cref="Timer"/> to trigger timeout.
    /// </summary>
    private void TimerCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<bool> waiter)
        {
            return;
        }

        ManualResetValueTaskSource<bool>? toCancel = RemoveWaiter(waiter);
        toCancel?.SetException(new TimeoutException());
    }

    /// <summary>
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<bool>)state!;
        var context = (AsyncSemaphore)waiter.Owner!;
        context.CancellationCallback(waiter);
    };

    private void CancellationCallback(ManualResetValueTaskSource<bool> waiter)
    {
#else
    private void CancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<bool> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<bool>? toCancel = RemoveWaiter(waiter);
        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }

    /// <summary>
    /// O(1) removal from intrusive linked list.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ManualResetValueTaskSource<bool>? RemoveWaiter(ManualResetValueTaskSource<bool> waiter)
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
