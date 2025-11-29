// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncAutoResetEventUnitTests
{
    [Test]
    public void WaitAsyncWhenNotSignaledReturnsNonCompletedValueTask()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask vt = ev.WaitAsync();

        Assert.That(vt.IsCompleted, Is.False, "Expected WaitAsync to return a non-completed ValueTask when not signaled");
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1), "Instance count should be 1 without await.");
    }

    [Test]
    public async Task WaitAsyncWhenNotSignaledTaskNeverCompletesAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        Task t = ev.WaitAsync().AsTask();

        Assert.That(t.IsCompleted, Is.False, "Expected WaitAsync to return a non-completed Task when not signaled");

        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1), "Instance count should be 1 without await.");
    }

    [Test]
    public async Task WaitAsyncWhenInitiallySignaledReturnsCompletedAndResetsAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: true, pool: tpvts);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask when initially signaled");

        await vt.ConfigureAwait(false); // should complete immediately

        // Subsequent waiter should not be completed because the signal is auto-reset
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to return a non-completed ValueTask after reset");
        ev.Set();
        await vt2.ConfigureAwait(false);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);
        ev.Set();
        ev.Set();
        await t.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task SetWithNoWaitersSetsSignaledForNextWaiterAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ev.Set(); // no waiters, should set internal signaled flag

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask after Set() with no waiters");

        await vt.ConfigureAwait(false);

        // After consuming the signaled state it should reset again
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after consuming signaled state");

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        // set twice to release both waiters
        ev.Set();
        ev.Set();

        // consume both
        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test, CancelAfter(5000)]
    public async Task SetReleasesSingleWaiterAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False, "Waiter should not be completed before Set()");

        _ = Task.Run(async () => { await Task.Delay(1000).ConfigureAwait(false); ev.Set(); });

        await waiter.ConfigureAwait(false);

        Assert.Throws<InvalidOperationException>(() => _ = waiter.IsCompleted);

        // Ensure no leftover signaled state
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected no leftover signaled state after releasing a queued waiter");

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        // set twice to release both waiters
        ev.Set();
        ev.Set();

        // consume both
        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task SetAllReleasesAllQueuedWaitersAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask w1 = ev.WaitAsync();
        ValueTask w2 = ev.WaitAsync();
        ValueTask w3 = ev.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(w1.IsCompleted, Is.False, "w1 should not be completed before SetAll()");
            Assert.That(w2.IsCompleted, Is.False, "w2 should not be completed before SetAll()");
            Assert.That(w3.IsCompleted, Is.False, "w3 should not be completed before SetAll()");
        }

        Task aw1 = ev.WaitAsync().AsTask();
        Task aw2 = ev.WaitAsync().AsTask();
        Task aw3 = ev.WaitAsync().AsTask();

        ev.SetAll();

        // ValueTask can be awaited one time
        await w1.ConfigureAwait(false);
        await w2.ConfigureAwait(false);
        await w3.ConfigureAwait(false);

        // ValueTask throws on the second await
        using (Assert.EnterMultipleScope())
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w1.ConfigureAwait(false));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w2.ConfigureAwait(false));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await w3.ConfigureAwait(false));
        }

        // Task can be awaited multiple times
        await aw1.ConfigureAwait(false);
        await aw2.ConfigureAwait(false);
        await aw3.ConfigureAwait(false);

        // Task can be awaited multiple times
        await aw1.ConfigureAwait(false);
        await aw2.ConfigureAwait(false);
        await aw3.ConfigureAwait(false);

        // After SetAll consumed, no lingering signaled state (auto-reset behavior)
        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after SetAll() released queued waiters");

        // The task is not signalled
        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        // set twice to release both waiters
        ev.Set();
        ev.Set();

        // consume both
        await vt.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task SetAllWithNoWaitersSetsSignaledForNextWaiterAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ev.SetAll(); // no waiters => should set signaled flag

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True, "Expected WaitAsync to return a completed ValueTask after SetAll() with no waiters");

        await vt.ConfigureAwait(false);

        // Consumed, next waiter should be non-completed
        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False, "Expected subsequent WaitAsync to be non-completed after consuming signaled state");

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        // set twice to release both waiters
        ev.Set();
        ev.Set();

        // consume both
        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueueingAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await ev.WaitAsync(cts.Token).ConfigureAwait(false));
        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueuedAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: tpvts);
        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelledAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        var vt = ev.WaitAsync(cts.Token);

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        await vt.ConfigureAwait(false);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task WaitAsyncAsTaskWithCancellationTokenCancelsWhileQueuedAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: tpvts);
        using var cts = new CancellationTokenSource();

        Task t = ev.WaitAsync(cts.Token).AsTask();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#if NETFRAMEWORK
        Assert.ThrowsAsync<TaskCanceledException>(async () => await t.ConfigureAwait(false));
#else
        Assert.ThrowsAsync<OperationCanceledException>(async () => await t.ConfigureAwait(false));
#endif
        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task WaitAsyncAsTaskWithCancellationTokenSucceedsIfNotCancelledAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        Task t = ev.WaitAsync(cts.Token).AsTask();

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        await t.ConfigureAwait(false);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }
}

