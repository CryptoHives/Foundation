// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable CA1724 // Type names shuld not match namespaces

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async barrier reference implementation based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-4-asyncbarrier/.
/// </summary>
/// <remarks>
/// A lock free reference implementation that uses <see cref="ConcurrentStack{TaskCompletionSource}"/> and Task.
/// </remarks>
public class AsyncBarrier
{
    private readonly int _participantCount;
    private int _remainingParticipants;
    private ConcurrentStack<TaskCompletionSource<bool>> _waiters;

    public AsyncBarrier(int participantCount)
    {
        if (participantCount <= 0) throw new ArgumentOutOfRangeException(nameof(participantCount));
        _remainingParticipants = _participantCount = participantCount;
        _waiters = new ConcurrentStack<TaskCompletionSource<bool>>();
    }

    public Task SignalAndWaitAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        _waiters.Push(tcs);
        if (Interlocked.Decrement(ref _remainingParticipants) == 0)
        {
            _remainingParticipants = _participantCount;
            ConcurrentStack<TaskCompletionSource<bool>> waiters = _waiters;
            _waiters = new ConcurrentStack<TaskCompletionSource<bool>>();
            Parallel.ForEach(waiters, w => w.SetResult(true));
        }
        return tcs.Task;
    }
}
