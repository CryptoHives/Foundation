// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
public class AsyncManualResetEventUnitTests
{
    [Test]
    public async Task WaitAsyncUnsetIsNotCompletedAsync()
    {
        var mre = new AsyncManualResetEvent();

        Task task = mre.WaitAsync().AsTask();

        await AsyncAssert.NeverCompletesAsync(task).ConfigureAwait(false);
    }

    [Test]
    public void WaitAsyncValueTaskAfterSetCompletesSynchronously()
    {
        var mre = new AsyncManualResetEvent();

        mre.Set();
        ValueTask task = mre.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncTaskAfterSetCompletesSynchronously()
    {
        var mre = new AsyncManualResetEvent();

        mre.Set();
        Task task = mre.WaitAsync().AsTask();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncSetCompletesSynchronously()
    {
        var mre = new AsyncManualResetEvent(true);

        ValueTask task = mre.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public async Task MultipleWaitersAfterSetAllCompleteAsync()
    {
        var mre = new AsyncManualResetEvent();

        Task t1 = mre.WaitAsync().AsTask();
        Task t2 = mre.WaitAsync().AsTask();

        mre.Set();

        // both should complete because ManualResetEvent stays signaled
        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(t1.IsCompleted);
            Assert.That(t2.IsCompleted);
            Assert.That(mre.IsSet);
        }
    }

    [Test]
    public async Task MultipleWaitersValueTaskAndTaskCompleteAfterSetAsync()
    {
        var mre = new AsyncManualResetEvent();

        // create several waiters using ValueTask and Task forms
        Task[] taskWaiters = Enumerable.Range(0,5).Select(_ => mre.WaitAsync().AsTask()).ToArray();

        // ensure none completed yet
        foreach (Task? t in taskWaiters) Assert.That(t.IsCompleted, Is.False);

        // signal the event
        mre.Set();

        // await waiters
        await Task.WhenAll(taskWaiters).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            // verify all completed and event remains set
            Assert.That(taskWaiters.All(t => t.IsCompleted));
            Assert.That(mre.IsSet);
        }
    }

    [Test]
    public async Task ResetUnsetsEventAsync()
    {
        var mre = new AsyncManualResetEvent(true);

        Assert.That(mre.IsSet);

        mre.Reset();

        Assert.That(mre.IsSet, Is.False);

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);
    }

    [Test]
    public async Task ResetWhenAlreadyResetDoesNothingAsync()
    {
        var mre = new AsyncManualResetEvent(false);

        // Should not throw and should remain unset
        mre.Reset();

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueueingAsync()
    {
        var ev = new AsyncManualResetEvent();
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        var vt = ev.WaitAsync(cts.Token);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueuedAsync()
    {
        var ev = new AsyncManualResetEvent(false);
        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelledAsync()
    {
        var ev = new AsyncManualResetEvent();
        using var cts = new CancellationTokenSource();

        var vt = ev.WaitAsync(cts.Token);

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        await vt.ConfigureAwait(false);
    }
}
