// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.RefImpl;

using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="ManualResetEvent"/> based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-1-asyncmanualresetevent/.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task.
/// </remarks>
public class AsyncManualResetEvent
{
    private volatile TaskCompletionSource<bool> _tcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public Task WaitAsync() => _tcs.Task;

    public void Set() => _tcs.TrySetResult(true);

    public void Reset()
    {
        while (true)
        {
            TaskCompletionSource<bool> tcs = _tcs;
            if (!tcs.Task.IsCompleted ||
                Interlocked.CompareExchange(ref _tcs, new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously), tcs) == tcs)
            {
                return;
            }
        }
    }
}

