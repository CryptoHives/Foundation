// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async;

using CryptoHives.Foundation.Threading.Pools;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="ManualResetEvent"/> which uses a
/// poolable <see cref="ManualResetValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public sealed class PooledAsyncManualResetEvent
{
    /// <summary>
    /// The queue of waiting ValueTasks to wake up on Set.
    /// </summary>
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);

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
    public ValueTask WaitAsync()
    {
        lock (_waiters)
        {
            if (_signaled)
            {
                return PooledEventsCommon.CompletedTask;
            }

            ManualResetValueTaskSource<bool> waiter = PooledEventsCommon.ValueTaskSourcePool.Get();
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
                PooledEventsCommon.ValueTaskSourcePool.Return(waiter);
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
        lock (_waiters)
        {
            Debug.Assert(_waiters.Count == 0, "There should be no waiters when resetting the event.");
            _signaled = false;
        }
    }
}
