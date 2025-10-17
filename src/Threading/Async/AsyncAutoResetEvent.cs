// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

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
    /// Set next waiting task.
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
    /// Set all waiting tasks.
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

