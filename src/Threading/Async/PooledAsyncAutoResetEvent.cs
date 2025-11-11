// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async;

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
public class PooledAsyncAutoResetEvent
{
    private readonly Queue<PooledManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
    private int _signaled;

    /// <summary>
    /// Initializes a new instance of the <see cref="PooledAsyncAutoResetEvent"/>
    /// class with the specified initial state.
    /// </summary>
    /// <param name="initialState">A boolean value indicating the initial state of the event. <see langword="true"/> if the event is initially
    /// signaled; otherwise, <see langword="false"/>.</param>
    public PooledAsyncAutoResetEvent(bool initialState = false)
    {
        _signaled = initialState ? 1 : 0;
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
    ///     var event = new PooledAsyncAutoResetEvent();
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
            return PooledEventsCommon.CompletedTask;
        }

        lock (_waiters)
        {
            // due to race conditions, _signalled may have changed
            if (Interlocked.Exchange(ref _signaled, 0) != 0)
            {
                return PooledEventsCommon.CompletedTask;
            }

            PooledManualResetValueTaskSource<bool> waiter = PooledEventsCommon.GetPooledValueTaskSource();
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
        PooledManualResetValueTaskSource<bool>? toRelease;

        lock (_waiters)
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
    /// Signals all waiting tasks to complete successfully.
    /// </summary>
    public void SetAll()
    {
        int count;
        PooledManualResetValueTaskSource<bool>[]? toRelease;

        lock (_waiters)
        {
            count = _waiters.Count;
            if (count == 0)
            {
                _ = Interlocked.Exchange(ref _signaled, 1);
                return;
            }

            toRelease = ArrayPool<PooledManualResetValueTaskSource<bool>>.Shared.Rent(count);
            for (int i = 0; i < count; i++)
            {
                toRelease[i] = _waiters.Dequeue();
            }

            Debug.Assert(_waiters.Count == 0);
        }

        try
        {
            PooledManualResetValueTaskSource<bool> waiter;
            for (int i = 0; i < count; i++)
            {
                waiter = toRelease[i];
                waiter.SetResult(true);
            }
        }
        finally
        {
            ArrayPool<PooledManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
        }
    }
}
