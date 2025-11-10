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

/// <summary>
/// An async version of <see cref="AutoResetEvent"/> which uses a
/// poolable <see cref="ManualResetValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public class PooledAsyncAutoResetEvent
{
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters = new(PooledEventsCommon.DefaultEventQueueSize);
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
    /// The ValueTask can only be awaited or transformed with AsTask() one single time, then it is returned to
    /// the pool and every subsequent access throws a <see cref="InvalidOperationException"/>
    /// </remarks>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous wait operation.</returns>
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

            ManualResetValueTaskSource<bool> waiter = PooledEventsCommon.GetPooledValueTaskSource();
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
        ManualResetValueTaskSource<bool>[]? toRelease;

        lock (_waiters)
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
