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
/// An async version of <see cref="AutoResetEvent"/> which uses a pooled approach
/// to implement waiters for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free 
/// async signaling by reusing pooled <see cref="IValueTaskSource{T}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>. As a side effect,
/// the benchmarks reveal that in many cases performance is also better than other known
/// implementations.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> Awaiting on <see cref="ValueTask"/> has its own caveats, as it 
/// is a struct that can only be awaited or converted with AsTask() ONE single time.
/// Additional attempts to await after the first await or additional conversions to AsTask() will throw 
/// an <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// <b>Continuation Scheduling:</b> The <see cref="RunContinuationAsynchronously"/> property
/// controls how continuations are executed when the event is signaled. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool, preventing the signaling thread from
/// being blocked by continuation execution. When set to <see langword="false"/>, continuations
/// may execute synchronously on the signaling thread, reducing context switching overhead but
/// potentially increasing Set() call duration and could lead to deadlocks because the waiting code
/// may be executed directly by the signaling thread.
/// </para>
/// <para>
/// <b>Performance Warning - AsTask() Usage:</b> When <see cref="RunContinuationAsynchronously"/>
/// is <see langword="true"/>, converting the returned <see cref="ValueTask"/> to <see cref="Task"/>
/// via AsTask() and storing the result before the event is signaled can cause severe performance
/// degradation (often 10x-100x slower) and additional memory allocations. This is an implementation
/// detail of the underlying <see cref="ManualResetValueTaskSourceCore{T}"/> which
/// cannot complete synchronously when a Task wrapper exists before signaling, forcing asynchronous
/// scheduling even when the event is already signaled.
/// </para>
/// <para>
/// <b>Recommendation:</b> Always await <see cref="ValueTask"/> directly. Avoid conversion 
/// to <see cref="Task"/> using AsTask(). Avoid storing AsTask() results across signaling boundaries.
/// When usage of <see cref="Task"/> is mandatory, a native implementation using 
/// <see cref="TaskCompletionSource{T}"/> should be considered.
/// </para>
/// <code>
/// // GOOD: Direct ValueTask await (optimal performance)
/// await eventInstance.WaitAsync().ConfigureAwait(false);
/// 
/// // SIGH: Immediate AsTask() conversion and await (adds memory allocation, but avoids performance hit)
/// await eventInstance.WaitAsync().AsTask().ConfigureAwait(false);
/// 
/// // BAD: Storing AsTask before signaling (possible severe performance degradation)
/// Task t = eventInstance.WaitAsync().AsTask();  // Stored before Set()
/// eventInstance.Set();
/// ...
/// await t.ConfigureAwait(false);  // 10x-100x slower due to forced async scheduling AFTER Set()
/// </code>
/// </remarks>
public sealed class AsyncAutoResetEvent
{
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter = new();
#if NET9_0_OR_GREATER
    private readonly Lock _mutex = new();
#else
    private readonly object _mutex = new();
#endif
    private volatile int _signaled;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncAutoResetEvent"/>
    /// class with the specified initial state.
    /// </summary>
    /// <param name="initialState">The initial state of the event.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    public AsyncAutoResetEvent(bool initialState = false, bool runContinuationAsynchronously = true)
    {
        _signaled = initialState ? 1 : 0;
        _runContinuationAsynchronously = runContinuationAsynchronously;
    }

    /// <summary>
    /// Whether this event is currently set.
    /// </summary>
    public bool IsSet
    {
        get { return _signaled != 0; }
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When <see langword="true"/> (default), continuations are queued to the thread pool when the event
    /// is signaled, preventing the signaling thread from being blocked by continuation execution.
    /// When <see langword="false"/>, continuations may execute synchronously on the signaling thread.
    /// </para>
    /// <para>
    /// <b>Performance Warning:</b> When this property is <see langword="true"/>, converting <see cref="ValueTask"/>
    /// to <see cref="Task"/> via AsTask() and storing the result before signaling causes severe performance
    /// degradation. Always await <see cref="ValueTask"/> directly to avoid this issue.
    /// </para>
    /// </remarks>
    public bool RunContinuationAsynchronously
    {
        get { return _runContinuationAsynchronously; }
        set { _runContinuationAsynchronously = value; }
    }

    /// <summary>
    /// Asynchronously waits for a signal to be received.
    /// </summary>
    /// <remarks>
    /// If the signal has already been received, the method returns a completed <see cref="ValueTask"/>.
    /// Otherwise, it enqueues a waiter and returns a task that completes when the signal is received.
    /// The ValueTask is a struct that can only be awaited or transformed with AsTask() ONE time, then
    /// it is returned to the pool and every subsequent access throws an <see cref="InvalidOperationException"/>.
    /// <code>
    ///     var event = new AsyncAutoResetEvent();
    ///     
    ///     // GOOD: single await
    ///     await _event.WaitAsync().ConfigureAwait(false);
    ///     
    ///     // GOOD: single await after calling WaitAsync()
    ///     ValueTask vt = _event.WaitAsync();
    ///     _event.Set();
    ///     await vt.ConfigureAwait(false);
    ///
    ///     // FAIL: multiple awaits on ValueTask - throws InvalidOperationException on second await
    ///     await vt.ConfigureAwait(false);
    /// 
    ///     // GOOD: single AsTask() usage, multiple await on Task
    ///     Task t = _event.WaitAsync().AsTask();
    ///     _event.Set();
    ///     await t.ConfigureAwait(false);
    ///     await t.ConfigureAwait(false);
    ///     
    ///     // FAIL: single await with GetAwaiter().GetResult() - is undefined behavior and
    ///     // may throw InvalidOperationException. Convert to Task first.
    ///     await _event.WaitAsync().GetAwaiter().GetResult();
    /// </code>
    /// Be aware that the underlying pooled implementation of <see cref="IValueTaskSource"/>
    /// may leak if the returned ValueTask is never awaited or transformed to a <see cref="Task"/>.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that is used for the asynchronous wait operation.</returns>
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        // fast path without lock
        if (Interlocked.Exchange(ref _signaled, 0) != 0)
        {
            return default;
        }

        lock (_mutex)
        {
            // due to race conditions, _signalled may have changed until the lock is taken
            if (Interlocked.Exchange(ref _signaled, 0) != 0)
            {
                return default;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask(Task.FromException(new OperationCanceledException(cancellationToken)));
            }

            ManualResetValueTaskSource<bool> waiter;
            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = PooledEventsCommon.GetPooledValueTaskSource();
            }

            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
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
            return new ValueTask(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Signals the event, releasing a single waiting thread if any are queued.
    /// </summary>
    /// <remarks>
    /// If no threads are waiting, the event is set to a signaled state, allowing any subsequent
    /// threads to proceed without blocking. This method is thread-safe.
    /// </remarks>
    public void Set()
    {
        ManualResetValueTaskSource<bool>? toRelease;

        lock (_mutex)
        {
            if (_waiters.Count == 0)
            {
                _ = Interlocked.Exchange(ref _signaled, 1);
                return;
            }

            toRelease = _waiters.Dequeue();
        }

        toRelease.SetResult(true);
    }

    /// <summary>
    /// Reset the signaled state for test purposes.
    /// </summary>
    internal void Reset()
    {
        Interlocked.Exchange(ref _signaled, 0);
    }

    /// <summary>
    /// Signals all waiting tasks to complete successfully.
    /// </summary>
    public void SetAll()
    {
        int count;
        ManualResetValueTaskSource<bool>[]? toRelease;

        lock (_mutex)
        {
            count = _waiters.Count;
            if (count == 0)
            {
                _ = Interlocked.Exchange(ref _signaled, 1);
                return;
            }

            toRelease = ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Rent(count);
            for (int i = 0; i < count; i++)
            {
                toRelease[i] = _waiters.Dequeue();
            }

            Debug.Assert(_waiters.Count == 0);
        }

        try
        {
            ManualResetValueTaskSource<bool> waiter;
            for (int i = 0; i < count; i++)
            {
                waiter = toRelease[i];
                waiter.SetResult(true);
            }
        }
        finally
        {
            ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
        }
    }

    private void CancellationCallback(object? state)
    {
        var waiter = state as ManualResetValueTaskSource<bool>;
        if (waiter != null)
        {
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
                        break;
                    }
                    _waiters.Enqueue(dequeued);
                }
            }

            toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
        }
    }
}
