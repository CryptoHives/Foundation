// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.RefImpl;

using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable CA1724 // Type name conflicts with the sibling Async/AsyncConditionVariable/ test namespace

/// <summary>
/// An async condition variable paired with <see cref="AsyncLock"/>.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task. The surface mirrors
/// <c>Nito.AsyncEx.AsyncConditionVariable</c> so the benchmarks can substitute this type for it
/// when the test assembly is strong-name signed.
/// </remarks>
public class AsyncConditionVariable
{
    private readonly AsyncLock _lock;
    private readonly Queue<TaskCompletionSource<bool>> _waiters = new();

    public AsyncConditionVariable(AsyncLock asyncLock)
    {
        _lock = asyncLock;
    }

    /// <summary>
    /// Releases the lock, waits for a notification and re-acquires the lock.
    /// The caller must hold the lock.
    /// </summary>
    public async Task WaitAsync()
    {
        TaskCompletionSource<bool> waiter = new(TaskCreationOptions.RunContinuationsAsynchronously);
        lock (_waiters)
        {
            _waiters.Enqueue(waiter);
        }

        _lock.Release();
        try
        {
            await waiter.Task.ConfigureAwait(false);
        }
        finally
        {
            _ = await _lock.LockAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Wakes a single waiter, if any. A notification with no waiters is lost.
    /// </summary>
    public void Notify()
    {
        TaskCompletionSource<bool>? toSignal = null;
        lock (_waiters)
        {
            if (_waiters.Count > 0)
            {
                toSignal = _waiters.Dequeue();
            }
        }

        toSignal?.SetResult(true);
    }

    /// <summary>
    /// Wakes every waiter. A notification with no waiters is lost.
    /// </summary>
    public void NotifyAll()
    {
        TaskCompletionSource<bool>[] toSignal;
        lock (_waiters)
        {
            toSignal = _waiters.ToArray();
            _waiters.Clear();
        }

        foreach (TaskCompletionSource<bool> waiter in toSignal)
        {
            waiter.SetResult(true);
        }
    }
}
