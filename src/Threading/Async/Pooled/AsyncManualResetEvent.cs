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
/// An async version of <see cref="ManualResetEvent"/> which uses a
/// poolable <see cref="PooledManualResetValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public sealed class AsyncManualResetEvent
{
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter = new();
#if NET9_0_OR_GREATER
    private readonly Lock _mutex = new();
#else
    private readonly object _mutex = new();
#endif
    private volatile bool _signaled;

    /// <summary>
    /// Creates an async ValueTask compatible ManualResetEvent.
    /// </summary>
    /// <param name="set">The initial state of the ManualResetEvent</param>
    public AsyncManualResetEvent(bool set)
    {
        _signaled = set;
    }

    /// <summary>
    /// Creates an async ValueTask compatible ManualResetEvent which is not set.
    /// </summary>
    public AsyncManualResetEvent()
        : this(false)
    {
    }

    /// <summary>
    /// Whether this event is currently set.
    /// </summary>
    public bool IsSet
    {
        get { lock (_mutex) return _signaled; }
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
    ///     var event = new AsyncManualResetEvent();
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
        lock (_mutex)
        {
            if (_signaled)
            {
                return default;
            }

            ManualResetValueTaskSource<bool> waiter;
            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = PooledEventsCommon.GetPooledValueTaskSource();
            }

            waiter.RunContinuationsAsynchronously = true;
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
}
