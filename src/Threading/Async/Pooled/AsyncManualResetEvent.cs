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
/// An async version of <see cref="ManualResetEvent"/> which uses a pooled approach
/// to implement waiters for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free 
/// async signaling by reusing pooled <see cref="IValueTaskSource{T}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>. However, since every
/// waiter needs its own <see cref="IValueTaskSource{T}"/>, there is more overhead when many waiters
/// are signalled than with a native <see cref="TaskCompletionSource{Boolean}"/> implementation.
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
public sealed class AsyncManualResetEvent
{
    private readonly ValueTaskSourceObjectPool<bool> _pool;
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters;
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
    private volatile bool _signaled;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Creates an async ValueTask compatible ManualResetEvent.
    /// </summary>
    /// <param name="set">The initial state of the event.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    public AsyncManualResetEvent(bool set = false, bool runContinuationAsynchronously = true, int defaultEventQueueSize = 0, ValueTaskSourceObjectPool<bool>? pool = null)
    {
        _mutex = new();
        _localWaiter = new();
        _signaled = set;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _waiters = new(defaultEventQueueSize > 0 ? defaultEventQueueSize : ValueTaskSourceObjectPools.DefaultEventQueueSize);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Whether this event is currently set.
    /// </summary>
    public bool IsSet
    {
        get { lock (_mutex) return _signaled; }
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
    /// Asynchronously waits for this event to be set.
    /// </summary>
    /// <remarks>
    /// If the event is already signalled, the method returns a completed <see cref="ValueTask"/>.
    /// Otherwise, it enqueues a waiter and returns a task that completes when the signal is received.
    /// The ValueTask is a struct that can only be awaited or transformed with AsTask() ONE time, then
    /// it is returned to the pool and every subsequent access throws an <see cref="InvalidOperationException"/>.
    /// <code>
    ///     var ct = new CancellationTokenSource(1000).Token;
    ///     var event = new AsyncManualResetEvent();
    ///     
    ///     // GOOD: single await with cancellation token
    ///     await _event.WaitAsync(ct).ConfigureAwait(false);
    ///     
    ///     // GOOD: single await after calling WaitAsync()
    ///     ValueTask vt = _event.WaitAsync(ct);
    ///     _event.Set();
    ///     await vt.ConfigureAwait(false);
    ///
    ///     // FAIL: multiple awaits on ValueTask - throws InvalidOperationException on second await
    ///     await vt.ConfigureAwait(false);
    /// 
    ///     // GOOD: single AsTask() usage, multiple await on Task
    ///     Task t = _event.WaitAsync(ct).AsTask();
    ///     _event.Set();
    ///     await t.ConfigureAwait(false);
    ///     await t.ConfigureAwait(false);
    ///     
    ///     // FAIL: single await with GetAwaiter().GetResult() - may throw InvalidOperationException
    ///     await _event.WaitAsync(ct).GetAwaiter().GetResult();
    /// </code>
    /// Be aware that the underlying pooled implementation of <see cref="IValueTaskSource"/>
    /// may leak if the returned ValueTask is never awaited or transformed to a <see cref="Task"/>.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that is used for the asynchronous wait operation.</returns>
    public ValueTask WaitAsync(CancellationToken cancellationToken = default)
    {
        lock (_mutex)
        {
            if (_signaled)
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
                waiter = _pool.Get();
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
    /// Signals the event, releasing all waiting threads if any are queued.
    /// </summary>
    /// <remarks>
    /// If no threads are waiting, the event is set to a signaled state, allowing any subsequent
    /// threads to proceed without blocking. This method is thread-safe.
    /// </remarks>
    public void Set()
    {
        int count;
        ManualResetValueTaskSource<bool>[] toRelease;

        lock (_mutex)
        {
            if (_signaled)
            {
                return;
            }

            _signaled = true;

            count = _waiters.Count;
            if (count == 0)
            {
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

    /// <summary>
    /// Resets the event.
    /// If the event is already reset, this method does nothing.
    /// </summary>
    public void Reset()
    {
        lock (_mutex)
        {
            Debug.Assert(_waiters.Count == 0, "There should be no waiters when resetting the event.");
            _signaled = false;
        }
    }

    private void CancellationCallback(object? state)
    {
        if (state is ManualResetValueTaskSource<bool> waiter)
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
