// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.RefImpl;

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="AutoResetEvent"/> based on
/// https://devblogs.microsoft.com/pfxteam/building-async-coordination-primitives-part-2-asyncautoresetevent/.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task.
/// </remarks>
public class AsyncAutoResetEvent
{
    private static readonly Task _completed = Task.FromResult(true);
    private readonly Queue<TaskCompletionSource<bool>> _waits = new();
    private bool _signaled;

    /// <summary>
    /// Task can wait for next event.
    /// </summary>
    public Task WaitAsync()
    {
        lock (_waits)
        {
            if (_signaled)
            {
                _signaled = false;
                return _completed;
            }
            else
            {
                // TaskCreationOptions.RunContinuationsAsynchronously is needed to avoid deadlocks
                var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                _waits.Enqueue(tcs);
                return tcs.Task;
            }
        }
    }

    /// <summary>
    /// Signals the next waiting task to proceed or
    /// sets the signaled state if no tasks are waiting.
    /// </summary>
    public void Set()
    {
        TaskCompletionSource<bool> toRelease;
        lock (_waits)
        {
            if (_waits.Count > 0)
            {
                toRelease = _waits.Dequeue();
            }
            else
            {
                _signaled = true;
                return;
            }
        }
        toRelease.SetResult(true);
    }

    /// <summary>
    /// Resets the signaled state for benchmark purposes.
    /// </summary>
    internal void Reset()
    {
        lock (_waits)
        {
            _signaled = false;
        }
    }

    /// <summary>
    /// Signals all waiting tasks to complete successfully.
    /// </summary>
    public void SetAll()
    {
        lock (_waits)
        {
            TaskCompletionSource<bool> toRelease;
            while (_waits.Count > 0)
            {
                toRelease = _waits.Dequeue();
                toRelease.SetResult(true);
            }
            _signaled = true;
        }
    }
}

