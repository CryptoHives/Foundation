// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Threading.Tests.Async;

using System.Threading.Tasks;
using NUnit.Framework;
using CryptoHives.Threading.Async;
using System;



[TestFixture]
[NonParallelizable] // prevents interference with the shared object pool
public class PooledAsyncAutoResetEventTests
{
    [Test]
    public void WaitAsync_WhenNotSignaled_ReturnsNonCompletedValueTask()
    {
        var ev = new PooledAsyncAutoResetEvent();

        ValueTask vt = ev.WaitAsync();

        Assert.That(vt.IsCompleted, Is.False, "Expected WaitAsync to return a non-completed ValueTask when not signaled");
    }

    [Test]
    public async Task WaitAsync_WhenInitiallySignaled_ReturnsCompletedAndResetsAsync()
    {
        var ev = new PooledAsyncAutoResetEvent(initialState: true);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask when initially signaled");

        await vt; // should complete immediately

        // Subsequent waiter should not be completed because the signal is auto-reset
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to return a non-completed ValueTask after reset");
    }

    [Test]
    public async Task Set_WithNoWaiters_SetsSignaledForNextWaiterAsync()
    {
        var ev = new PooledAsyncAutoResetEvent();

        ev.Set(); // no waiters, should set internal signaled flag

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask after Set() with no waiters");

        await vt;

        // After consuming the signaled state it should reset again
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after consuming signaled state");
    }

    [Test, CancelAfter(5000)]
    public async Task Set_ReleasesSingleWaiterAsync()
    {
        var ev = new PooledAsyncAutoResetEvent();

        ValueTask waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False, "Waiter should not be completed before Set()");

        _ = Task.Run(async () => { await Task.Delay(1000);  ev.Set(); });

        await waiter;

        Assert.That(waiter.IsCompleted, Is.True, "Expected no leftover signaled state after releasing a queued waiter");

        await waiter;

        // Ensure no leftover signaled state
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected no leftover signaled state after releasing a queued waiter");
    }

    [Test]
    public async Task SetAll_ReleasesAllQueuedWaitersAsync()
    {
        var ev = new PooledAsyncAutoResetEvent();

        ValueTask w1 = ev.WaitAsync();
        ValueTask w2 = ev.WaitAsync();
        ValueTask w3 = ev.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(w1.IsCompleted, Is.False, "w1 should not be completed before SetAll()");
            Assert.That(w2.IsCompleted, Is.False, "w2 should not be completed before SetAll()");
            Assert.That(w3.IsCompleted, Is.False, "w3 should not be completed before SetAll()");
        }

        Task aw1 = w1.AsTask();
        Task aw2 = w2.AsTask();
        Task aw3 = w3.AsTask();

        ev.SetAll();

        Assert.Multiple(() => {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w1);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w2);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w3);
        });

        await aw1;
        await aw2;
        await aw3;

        // After SetAll consumed, no lingering signaled state (auto-reset behavior)
        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after SetAll() released queued waiters");
    }

    [Test]
    public async Task SetAll_WithNoWaiters_SetsSignaledForNextWaiterAsync()
    {
        var ev = new PooledAsyncAutoResetEvent();

        ev.SetAll(); // no waiters => should set signaled flag

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask after SetAll() with no waiters");

        await vt;

        // Consumed, next waiter should be non-completed
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after consuming signaled state");
    }
}

