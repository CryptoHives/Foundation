// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async count down reference implementation based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-3-asynccountdownevent/.
/// </summary>
/// <remarks>
/// A reference implementation that uses <see cref="AsyncManualResetEvent"/> and Task.
/// </remarks>
public class AsyncCountdownEvent
{
    private readonly AsyncManualResetEvent _amre = new();
    private int _count;
    private readonly int _initialCount;

    public AsyncCountdownEvent(int initialCount)
    {
        if (initialCount <= 0) throw new ArgumentOutOfRangeException(nameof(initialCount));
        _initialCount = initialCount;
        _count = initialCount;
    }

    public Task WaitAsync() => _amre.WaitAsync();

    public void Signal()
    {
        if (_count <= 0) throw new InvalidOperationException();

        int newCount = Interlocked.Decrement(ref _count);
        if (newCount == 0)
        {
            _amre.Set();
        }
        else if (newCount < 0)
        {
            throw new InvalidOperationException();
        }
    }

    public void Reset()
    {
        int oldCount = Interlocked.Exchange(ref _count, _initialCount);
        if (oldCount == 0)
        {
            _amre.Reset();
        }
    }

    public Task SignalAndWait()
    {
        Signal();
        return WaitAsync();
    }
}
