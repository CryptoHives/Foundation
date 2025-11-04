// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Threading.Async;

using CryptoHives.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="AsyncAutoResetEvent"/> which uses a
/// poolable <see cref="PooledValueTaskSource{Boolean}"/> to avoid allocations
/// of <see cref="TaskCompletionSource{Boolean}"/> and <see cref="Task"/>.
/// </summary>
public class PooledAsyncAutoResetEvent
{
    private static readonly ValueTask _completed = new ValueTask(Task.CompletedTask);
    private static readonly ObjectPool<PooledValueTaskSource<bool>> _pool = new DefaultObjectPool<PooledValueTaskSource<bool>>(new ValueTaskSourcePooledObjectPolicy<bool>());
    private readonly Queue<PooledValueTaskSource<bool>> _waiters = new();
    private bool _signaled;

    /// <summary>
    /// Initializes a new instance of the <see cref="PooledAsyncAutoResetEvent"/>
    /// class with the specified initial state.
    /// </summary>
    /// <param name="initialState">A boolean value indicating the initial state of the event. <see langword="true"/> if the event is initially
    /// signaled; otherwise, <see langword="false"/>.</param>
    public PooledAsyncAutoResetEvent(bool initialState = false)
    {
        _signaled = initialState;
    }

    /// <summary>
    /// Asynchronously waits for a signal to be received.
    /// </summary>
    /// <remarks>
    /// If the signal has already been received, the method returns a completed <see cref="ValueTask"/>.
    /// Otherwise, it enqueues a waiter and returns a task that completes when the signal is received.
    /// </remarks>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous wait operation.</returns>
    public ValueTask WaitAsync()
    {
        lock (_waiters)
        {
            if (_signaled)
            {
                _signaled = false;
                return _completed; // completed ValueTask
            }

            PooledValueTaskSource<bool> waiter = _pool.Get();
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
        PooledValueTaskSource<bool>? toRelease;

        lock (_waiters)
        {
            if (_waiters.Count == 0)
            {
                _signaled = true;
                return;
            }

            toRelease = _waiters.Dequeue();
        }

        toRelease.SetResult(true);
        _pool.Return(toRelease);
    }

    /// <summary>
    /// Signals all waiting tasks to complete successfully.
    /// </summary>
    public void SetAll()
    {
        List<PooledValueTaskSource<bool>> toRelease;
        lock (_waiters)
        {
            if (_waiters.Count == 0)
            {
                _signaled = true;
                return;
            }
            toRelease = _waiters.ToList();
            _waiters.Clear();
        }

        foreach (PooledValueTaskSource<bool> waiter in toRelease)
        {
            waiter.SetResult(true);
            _pool.Return(waiter);
        }
    }
}
