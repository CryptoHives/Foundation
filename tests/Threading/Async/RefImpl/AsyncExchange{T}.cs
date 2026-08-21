// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.RefImpl;

using System.Threading.Tasks;

/// <summary>
/// A two-party rendezvous that lets two tasks swap values.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task, for benchmarking against
/// the pooled implementation.
/// </remarks>
public class AsyncExchange<T>
{
    private readonly object _syncRoot = new();
    private TaskCompletionSource<T>? _pendingWaiter;
    private T _pendingValue = default!;

    /// <summary>
    /// Offers <paramref name="value"/> and returns the counterpart's value, suspending until a
    /// counterpart arrives.
    /// </summary>
    public Task<T> ExchangeAsync(T value)
    {
        TaskCompletionSource<T> toComplete;
        T theirValue;

        lock (_syncRoot)
        {
            if (_pendingWaiter is null)
            {
                _pendingWaiter = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
                _pendingValue = value;
                return _pendingWaiter.Task;
            }

            toComplete = _pendingWaiter;
            theirValue = _pendingValue;
            _pendingWaiter = null;
            _pendingValue = default!;
        }

        toComplete.SetResult(value);
        return Task.FromResult(theirValue);
    }
}
