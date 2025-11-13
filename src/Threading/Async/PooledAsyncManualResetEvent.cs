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
/// An async version of <see cref="ManualResetEvent"/> which uses a
/// poolable <see cref="PooledManualResetValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public sealed class PooledAsyncManualResetEvent
{
    /// <summary>
    /// The queue of waiting ValueTasks to wake up on Set.
    /// </summary>
    private readonly Queue<PooledManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);

    /// <summary>
    /// Whether the event is currently signaled.
    /// </summary>
    private bool _signaled;

    /// <summary>
    /// Creates an async ValueTask compatible ManualResetEvent.
    /// </summary>
    /// <param name="set">The initial state of the ManualResetEvent</param>
    public PooledAsyncManualResetEvent(bool set)
    {
        _signaled = set;
    }

    /// <summary>
    /// Creates an async ValueTask compatible ManualResetEvent which is not set.
    /// </summary>
    public PooledAsyncManualResetEvent()
        : this(false)
    {
    }

    /// <summary>
    /// Whether this event is currently set.
    /// </summary>
    public bool IsSet
    {
        get { lock (_waiters) return _signaled; }
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
    ///     var event = new PooledAsyncManualResetEvent();
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
        lock (_waiters)
        {
            if (_signaled)
            {
                return default;
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
    /// Sets the event, completes every waiting ValueTask.
    /// </summary>
    public void Set()
    {
        int count;
        PooledManualResetValueTaskSource<bool>[] toRelease;

        lock (_waiters)
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

    /// <summary>
    /// Resets the event.
    /// If the event is already reset, this method does nothing.
    /// </summary>
    public void Reset()
    {
        lock (_waiters)
        {
            Debug.Assert(_waiters.Count == 0, "There should be no waiters when resetting the event.");
            _signaled = false;
        }
    }
}
