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
    private WaiterQueue<bool> _waiters;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
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
        _mutex = new();
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
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        lock (_mutex)
        {
            if (_currentCount == 0)
            {
                return default;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
            }

            PooledManualResetValueTaskSource<bool> waiter;
            waiter = _pool.GetPooledWaiter(this);
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

        lock (_mutex)
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

        WaiterQueue<bool>.SetChainResult(toReleaseChain, true);
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

        lock (_mutex)
        {
            if (_currentCount == 0)
            {
                throw new InvalidOperationException("The countdown has already reached zero.");
            }

            _currentCount += signalCount;
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

        lock (_mutex)
        {
            if (_currentCount == 0)
            {
                return false;
            }

            _currentCount += signalCount;
            return true;
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

        lock (_mutex)
        {
            Debug.Assert(_waiters.Count == 0, "There should be no waiters when resetting the countdown.");
            _currentCount = count > 0 ? count : _initialCount;
            if (count > 0)
            {
                _initialCount = count;
            }
        }
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

        // O(1) removal from intrusive linked list.
        ManualResetValueTaskSource<bool>? toCancel = null;
        lock (_mutex)
        {
            if (_waiters.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

#pragma warning disable CA1508 // Avoid dead conditional code
        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<bool>(waiter.CancellationToken)));
#pragma warning restore CA1508 // Avoid dead conditional code
    }
}
