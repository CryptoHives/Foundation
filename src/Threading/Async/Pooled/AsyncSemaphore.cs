// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
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
    private WaiterQueue<bool> _waiters;
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
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
        _mutex = new();
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
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        lock (_mutex)
        {
            if (_currentCount > 0)
            {
                _currentCount--;
                return default;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
            }

            if (!_localWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<bool> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
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

            _waiters.Enqueue(waiter);
            return new ValueTask(waiter, waiter.Version);
        }
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

        lock (_mutex)
        {
            int waitersToRelease = Math.Min(releaseCount, _waiters.Count);
            int remainingReleases = releaseCount - waitersToRelease;

            if (waitersToRelease > 0)
            {
                toReleaseChain = _waiters.DetachFirst(waitersToRelease, out _);
            }

            _currentCount += remainingReleases;
        }

        WaiterQueue<bool>.SetChainResult(toReleaseChain, true);
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

        // O(1) removal from intrusive linked list.
        ManualResetValueTaskSource<bool>? toCancel = null;
        lock (_mutex)
        {
            if (_waiters.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<bool>(waiter.CancellationToken)));
    }
}
