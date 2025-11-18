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
/// An async version of <see cref="AutoResetEvent"/> which uses a
/// poolable <see cref="PooledManualResetValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public class AsyncAutoResetEvent
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
        get { lock (_mutex) return _signaled != 0; }
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
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
    ///     // FAIL: single await with GetAwaiter().GetResult() - may throw InvalidOperationException
    ///     await _event.WaitAsync().GetAwaiter().GetResult();
    /// </code>
    /// Be aware that the underlying pooled implementation of <see cref="IValueTaskSource"/>
    /// may leak if the returned ValueTask is never awaited or transformed to a <see cref="Task"/>.
    /// </remarks>
    /// <returns>A <see cref="ValueTask"/> that is used for the asynchronous wait operation.</returns>
    public ValueTask WaitAsync()
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

            ManualResetValueTaskSource<bool> waiter;
            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = PooledEventsCommon.GetPooledValueTaskSource();
            }

            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            _waiters.Enqueue(waiter);
            return new ValueTask(waiter, waiter.Version);
        }
    }

#if TODO // implement wait with cancel
    /// <summary>
    /// Asynchronously waits for this event to be set or for the wait to be canceled.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    public ValueTask WaitAsync(CancellationToken cancellationToken)
    {
    }
#endif

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
}
