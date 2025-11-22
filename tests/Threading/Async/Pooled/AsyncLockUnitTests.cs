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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1849:Call async methods when in an async method", Justification = "Not available in legacy platforms")]
    public async Task CancellationBeforeQueueingThrowsAsync()
    {
        var al = new AsyncLock();

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();
            var exVt = al.LockAsync(cts.Token);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await exVt.ConfigureAwait(false));
        }
    }
}
