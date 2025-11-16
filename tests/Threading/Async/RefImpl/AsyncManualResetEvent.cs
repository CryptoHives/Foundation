// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.RefImpl;

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
    private volatile TaskCompletionSource<bool> m_tcs = new TaskCompletionSource<bool>();

    public Task WaitAsync() { return m_tcs.Task; }

    public void Set() { m_tcs.TrySetResult(true); }

    public void Reset()
    {
        while (true)
        {
            var tcs = m_tcs;
            if (!tcs.Task.IsCompleted ||
                Interlocked.CompareExchange(ref m_tcs, new TaskCompletionSource<bool>(), tcs) == tcs)
            {
                return;
            }
        }
    }
}

