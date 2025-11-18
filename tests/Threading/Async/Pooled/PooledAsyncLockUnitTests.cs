// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.Pooled;

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
        var al = new Threading.Async.Pooled.AsyncLock();

        ValueTask<Threading.Async.Pooled.AsyncLock.AsyncLockReleaser> vt = al.LockAsync();
        Assert.That(vt.IsCompleted);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        Assert.That(al.IsTaken, Is.False);
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentiallyAsync()
    {
        var al = new Threading.Async.Pooled.AsyncLock();

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
    public async Task CancellationBeforeQueueingThrowsAsync()
    {
        var al = new Threading.Async.Pooled.AsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();
            var exVt = al.LockAsync(cts.Token);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await exVt.ConfigureAwait(false));
        }
    }
}
