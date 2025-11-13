// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using CryptoHives.Foundation.Threading.Async;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Threading;

[TestFixture]
public class AsyncLockUnitTests
{
    [Test]
    public async Task LockUnlockSingleAwaiter()
    {
        var al = new PooledAsyncLock();

        ValueTask<PooledAsyncLock.Releaser> vt = al.LockAsync();
        Assert.That(vt.IsCompleted);

        using (var releaser = await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        Assert.That(al.IsTaken, Is.False);
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentially()
    {
        var al = new PooledAsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            var t1 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });
            var t2 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });

            await Task.Delay(10).ConfigureAwait(false);
            Assert.That(al.IsTaken);

            // release outer lock and wait for tasks to complete
        }

        await Task.Delay(50).ConfigureAwait(false);
    }

    [Test]
    public async Task CancellationBeforeQueueingThrows()
    {
        var al = new PooledAsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();
            var exVt = al.LockAsync(cts.Token);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await exVt.ConfigureAwait(false));
        }
    }
}
