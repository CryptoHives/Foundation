// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="SemaphoreSlim"/> based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-5-asyncsemaphore/.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task.
/// </remarks>
public class AsyncSemaphore
{
    private static readonly Task _completed = Task.FromResult(true);
    private readonly Queue<TaskCompletionSource<bool>> _waiters = new();
    private int _currentCount;

    public AsyncSemaphore(int initialCount)
    {
        if (initialCount < 0) throw new ArgumentOutOfRangeException(nameof(initialCount));
        _currentCount = initialCount;
    }

    public Task WaitAsync()
    {
        lock (_waiters)
        {
            if (_currentCount > 0)
            {
                _currentCount--;
                return _completed;
            }
            else
            {
                var waiter = new TaskCompletionSource<bool>();
                _waiters.Enqueue(waiter);
                return waiter.Task;
            }
        }
    }

    public void Release()
    {
        TaskCompletionSource<bool> toRelease;

        lock (_waiters)
        {
            if (_waiters.Count > 0)
            {
                toRelease = _waiters.Dequeue();
            }
            else
            {
                _currentCount++;
                return;
            }
        }

        toRelease.SetResult(true);
    }
}

