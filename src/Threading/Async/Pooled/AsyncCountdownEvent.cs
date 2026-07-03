// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1508 // Avoid dead conditional code

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async version of <see cref="CountdownEvent"/> which uses a pooled approach
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
/// controls how continuations are executed when the countdown reaches zero. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool.
/// </para>
/// <para>
/// <b>Allocation Behavior:</b> Immediate acquisitions are completely allocation-free using atomic 
/// operations. When the countdown is contended, waiting without a timeout is allocation-free on .NET 6.0+ 
/// (using <c>UnsafeRegister</c> for cancellation), while older frameworks may allocate for cancellation 
/// registration. Specifying a finite timeout allocates a timer that is automatically disposed when the 
/// operation completes. Exception and task allocations occur only if a timeout actually elapses or 
/// cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled 
/// <see cref="IValueTaskSource{TResult}"/> instances are reused to minimize allocation pressure across 
/// repeated lock operations.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncCountdownEvent _countdown = new AsyncCountdownEvent(3);
///
/// public async Task WaitForAllWorkersAsync(CancellationToken ct)
/// {
///     await _countdown.WaitAsync(ct);
///     // All workers have signaled
/// }
///
/// public void WorkerCompleted()
/// {
///     _countdown.Signal();
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncCountdownEvent
{
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private Internal.SpinLock _spinLock;
    private WaiterQueue<bool> _waiters;
    private int _currentCount;
    private int _initialCount;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Constructs a new AsyncCountdownEvent instance with the specified initial count.
    /// </summary>
    /// <param name="initialCount">The initial count for the countdown event.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="initialCount"/> is less than or equal to zero.</exception>
    public AsyncCountdownEvent(int initialCount, bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (initialCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCount), initialCount, "Initial count must be greater than zero.");
        }

        _currentCount = initialCount;
        _initialCount = initialCount;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _spinLock = new();
        _waiters = new();
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets the current count remaining.
    /// </summary>
    public int CurrentCount
    {
        get => Volatile.Read(ref _currentCount);
    }

    /// <summary>
    /// Gets the initial count that was set when the countdown event was created.
    /// </summary>
    public int InitialCount
    {
        get => Volatile.Read(ref _initialCount);
    }

    /// <summary>
    /// Gets whether the countdown has reached zero.
    /// </summary>
    public bool IsSet
    {
        get => Volatile.Read(ref _currentCount) == 0;
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
    /// Asynchronously waits for the countdown to reach zero.
    /// </summary>
    /// <remarks>
    /// If the countdown has already reached zero, the method returns a completed <see cref="ValueTask"/>.
    /// Otherwise, it enqueues a waiter and returns a task that completes when the countdown reaches zero.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the countdown reaches zero.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        if (Volatile.Read(ref _currentCount) == 0)
        {
            return default;
        }

        return WaitAsyncImpl(Timeout.InfiniteTimeSpan, cancellationToken);
    }

    /// <summary>
    /// Asynchronously waits for the countdown to reach zero, or until the specified timeout elapses.
    /// </summary>
    /// <remarks>
    /// If the countdown has already reached zero, the method returns a completed <see cref="ValueTask"/> immediately
    /// without allocating any cancellation infrastructure. A <see cref="CancellationTokenSource"/> is allocated
    /// only when the countdown is non-zero and a finite positive timeout is requested; it is disposed
    /// automatically when the returned <see cref="ValueTask"/> is awaited.
    /// </remarks>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the countdown reaches zero.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the timeout elapses before the countdown reaches zero.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the countdown reaches zero.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        if (Volatile.Read(ref _currentCount) == 0)
        {
            return default;
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
        PooledManualResetValueTaskSource<bool> waiter;
        short version;

        _spinLock.Enter();
        try
        {
            if (_currentCount == 0)
            {
                return default;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
            }

            waiter = _pool.GetPooledWaiter(this);
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
    /// Decrements the countdown by one.
    /// </summary>
    /// <remarks>
    /// When the countdown reaches zero, all waiting tasks are signaled.
    /// </remarks>
    /// <exception cref="InvalidOperationException">Thrown when the countdown has already reached zero.</exception>
    public void Signal()
    {
        Signal(1);
    }

    /// <summary>
    /// Decrements the countdown by the specified amount.
    /// </summary>
    /// <param name="signalCount">The number of signals to decrement.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="signalCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the signal count would cause the countdown to go below zero.</exception>
    public void Signal(int signalCount)
    {
        if (signalCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(signalCount), signalCount, "Signal count must be at least 1.");
        }

        ManualResetValueTaskSource<bool>? toReleaseChain = null;

        _spinLock.Enter();
        try
        {
            if (_currentCount == 0)
            {
                throw new InvalidOperationException("The countdown has already reached zero.");
            }

            if (signalCount > _currentCount)
            {
                throw new InvalidOperationException("Signal count exceeds the current count.");
            }

            _currentCount -= signalCount;
            if (_currentCount == 0)
            {
                toReleaseChain = _waiters.DetachAll(out _);
            }
            else
            {
                return;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        toReleaseChain?.SetChainResult(true);
    }

    /// <summary>
    /// Signals the countdown and waits for it to reach zero.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the countdown reaches zero.</returns>
    public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
    {
        Signal();
        return WaitAsync(cancellationToken);
    }

    /// <summary>
    /// Increments the countdown by one.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the countdown has already reached zero.</exception>
    public void AddCount()
    {
        AddCount(1);
    }

    /// <summary>
    /// Increments the countdown by the specified amount.
    /// </summary>
    /// <param name="signalCount">The number to add to the countdown.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="signalCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the countdown has already reached zero.</exception>
    public void AddCount(int signalCount)
    {
        if (signalCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(signalCount), signalCount, "Signal count must be at least 1.");
        }

        _spinLock.Enter();
        try
        {
            if (_currentCount == 0)
            {
                throw new InvalidOperationException("The countdown has already reached zero.");
            }

            _currentCount += signalCount;
        }
        finally
        {
            _spinLock.Exit();
        }
    }

    /// <summary>
    /// Attempts to add to the countdown.
    /// </summary>
    /// <param name="signalCount">The number to add to the countdown.</param>
    /// <returns><see langword="true"/> if the add was successful; otherwise, <see langword="false"/>.</returns>
    public bool TryAddCount(int signalCount = 1)
    {
        if (signalCount < 1)
        {
            return false;
        }

        _spinLock.Enter();
        try
        {
            if (_currentCount == 0)
            {
                return false;
            }

            _currentCount += signalCount;
            return true;
        }
        finally
        {
            _spinLock.Exit();
        }
    }

    /// <summary>
    /// Resets the countdown to the specified count, or to the initial count if not specified.
    /// </summary>
    /// <param name="count">The new count value. If not specified, resets to initial count.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is less than or equal to zero.</exception>
    public void Reset(int count = 0)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), count, "Count must be non-negative.");
        }

        _spinLock.Enter();
        try
        {
            Debug.Assert(_waiters.Count == 0, "There should be no waiters when resetting the countdown.");
            _currentCount = count > 0 ? count : _initialCount;
            if (count > 0)
            {
                _initialCount = count;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

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
        toCancel?.SetException(ManualResetValueTaskSource<bool>.OperationCanceled);
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<bool>)state!;
        var context = (AsyncCountdownEvent)waiter.Owner!;
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
