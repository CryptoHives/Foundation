// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable CA1724 // Type names shuld not match namespaces

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An async version of <see cref="lock"/> based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-6-asynclock/.
/// </summary>
/// <remarks>
/// A reference implementation that uses TaskCompletionSource and Task.
/// </remarks>
public class AsyncLock
{
    private readonly AsyncSemaphore _semaphore;
    private readonly Task<Releaser> _releaser;

    public readonly struct Releaser : IDisposable
    {
        private readonly AsyncLock _toRelease;

        internal Releaser(AsyncLock toRelease)
        {
            _toRelease = toRelease;
        }

        public void Dispose()
        {
            _toRelease?._semaphore.Release();
        }
    }

    public AsyncLock()
    {
        _semaphore = new AsyncSemaphore(1);
        _releaser = Task.FromResult(new Releaser(this));
    }

    public Task<Releaser> LockAsync()
    {
        Task wait = _semaphore.WaitAsync();
        return wait.IsCompleted
            ? _releaser
            : wait.ContinueWith((_, state) => new Releaser((AsyncLock)state!), this, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    }
}

