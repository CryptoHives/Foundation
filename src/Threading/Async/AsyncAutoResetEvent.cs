// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Threading.Async;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="AutoResetEvent"/> based on
/// https://devblogs.microsoft.com/pfxteam/building-async-coordination-primitives-part-2-asyncautoresetevent/.
/// </summary>
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
                // TaskCreationOptions.RunContinuationsAsynchronously is needed
                // to decouple the reader thread from the processing in the subscriptions.
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

