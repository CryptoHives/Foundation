// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

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
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters;
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
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
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="initialCount"/> is less than or equal to zero.</exception>
    public AsyncCountdownEvent(int initialCount, bool runContinuationAsynchronously = true, int defaultEventQueueSize = 0, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (initialCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialCount), initialCount, "Initial count must be greater than zero.");
        }

        _currentCount = initialCount;
        _initialCount = initialCount;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _mutex = new();
        _waiters = new(defaultEventQueueSize > 0 ? defaultEventQueueSize : ValueTaskSourceObjectPools.DefaultEventQueueSize);
        _localWaiter = new(this);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets the current count remaining.
    /// </summary>
    public int CurrentCount
    {
        get { lock (_mutex) return _currentCount; }
    }

    /// <summary>
    /// Gets the initial count that was set when the countdown event was created.
    /// </summary>
    public int InitialCount
    {
        get { lock (_mutex) return _initialCount; }
    }

    /// <summary>
    /// Gets whether the countdown has reached zero.
    /// </summary>
    public bool IsSet
    {
        get { lock (_mutex) return _currentCount == 0; }
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

        int count;
        ManualResetValueTaskSource<bool>[]? toRelease = null;

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
                count = _waiters.Count;
                if (count > 0)
                {
                    toRelease = ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Rent(count);
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i] = _waiters.Dequeue();
                    }
                    Debug.Assert(_waiters.Count == 0);
                }
            }
            else
            {
                return;
            }
        }

        if (toRelease is not null)
        {
            try
            {
                for (int i = 0; i < count; i++)
                {
                    toRelease[i].SetResult(true);
                }
            }
            finally
            {
                ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
            }
        }
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

    /// <summary>
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) =>
    {
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

        ManualResetValueTaskSource<bool>? toCancel = null;
        lock (_mutex)
        {
            int count = _waiters.Count;
            while (count-- > 0)
            {
                var dequeued = _waiters.Dequeue();
                if (ReferenceEquals(dequeued, waiter))
                {
                    toCancel = waiter;
                    continue;
                }
                _waiters.Enqueue(dequeued);
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<bool>(waiter.CancellationToken)));
    }
}
