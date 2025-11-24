// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
public class AsyncLockUnitTests
{
    [Test]
    public async Task LockUnlockSingleAwaiterAsync()
    {
        var al = new AsyncLock();

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync();
        Assert.That(vt.IsCompleted);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
            Assert.That(vt.IsCompleted);
        }

        Assert.That(al.IsTaken, Is.False);
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentiallyAsync()
    {
        var al = new AsyncLock();

        Task t1, t2;
        using (await al.LockAsync().ConfigureAwait(false))
        {
            t1 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });
            t2 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });

            await Task.Delay(10).ConfigureAwait(false);
            Assert.That(al.IsTaken);

            // release outer lock and wait for tasks to complete
        }

        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockLockedOnlyPermitsOneLockerAtATime()
    {
        var mutex = new AsyncLock();
        var task1HasLock = new TaskCompletionSource<bool>();
        var task1Continue = new TaskCompletionSource<bool>();
        var task2Ready = new TaskCompletionSource<bool>();
        var task2HasLock = new TaskCompletionSource<bool>();
        var task2Continue = new TaskCompletionSource<bool>();

        var task1 = Task.Run(async () =>
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(true);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () =>
        {
            var key = mutex.LockAsync();
            task2Ready.SetResult(true);
            using (await key.ConfigureAwait(false))
            {
                task2HasLock.SetResult(true);
                await task2Continue.Task.ConfigureAwait(false);
            }
        });
        await task2Ready.Task.ConfigureAwait(false);

        var task3 = Task.Run(async () =>
        {
            await mutex.LockAsync().ConfigureAwait(false);
        });

        task1Continue.SetResult(true);
        await task2HasLock.Task.ConfigureAwait(false);

        Assert.That(task3.IsCompleted, Is.False);
        task2Continue.SetResult(false);

        // pro forma waits
        await task1.ConfigureAwait(false);
        await task2.ConfigureAwait(false);
        await task3.ConfigureAwait(false);
    }

    [Test]
    public async Task CancellationBeforeQueueingThrowsAsync()
    {
        var al = new AsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

#if NET8_0_OR_GREATER
            await cts.CancelAsync().ConfigureAwait(false);
#else
            cts.Cancel();
#endif

            var exVt = al.LockAsync(cts.Token);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await exVt.ConfigureAwait(false));
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueueingAsync()
    {
        var al = new AsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

            // Cancel before queueing
#if NET8_0_OR_GREATER
            await cts.CancelAsync().ConfigureAwait(false);
#else
            cts.Cancel();
#endif

            Assert.ThrowsAsync<OperationCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueuedAsync()
    {
        var al = new AsyncLock();

        using var cts = new CancellationTokenSource();

        // Take the lock so subsequent waiters are queued
        using (await al.LockAsync().ConfigureAwait(false))
        {
            var vt = al.LockAsync(cts.Token);

            // Cancel after queuing
#if NET8_0_OR_GREATER
            await cts.CancelAsync().ConfigureAwait(false);
#else
            cts.Cancel();
#endif

            Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelledAsync()
    {
        var al = new AsyncLock();

        using var cts = new CancellationTokenSource();

        var vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelAfterLockAsync()
    {
        var al = new AsyncLock();

        using var cts = new CancellationTokenSource();

        var vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
#if NET8_0_OR_GREATER
        await cts.CancelAsync().ConfigureAwait(false);
#else
        cts.Cancel();
#endif
    }

    [Test, CancelAfter(1000)]
    public async Task WaitAsyncWithCancellationTokenCancelAfterTimeoutAsync()
    {
        var al = new AsyncLock();

        using var cts = new CancellationTokenSource(100);

        var vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }
    }
}
