// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1849 // Call async methods when in an async method
#pragma warning disable CHT001 // ValueTask awaited multiple times - intentionally testing cancellation behavior

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
    public async Task IsSetReflectsEventState()
    {
        var ev = new AsyncAutoResetEvent(initialState: false, defaultEventQueueSize: 8);
        Assert.That(ev.IsSet, Is.False);
        Assert.That(ev.RunContinuationAsynchronously, Is.True);

        ev.Set();
        Assert.That(ev.IsSet, Is.True);

        await ev.WaitAsync().ConfigureAwait(false);
        Assert.That(ev.IsSet, Is.False);
    }

    [Test]
    public async Task IsSetReturnsFalseAfterSetReleasesWaiter()
    {
        var ev = new AsyncAutoResetEvent(initialState: false, runContinuationAsynchronously: false, defaultEventQueueSize: 8);
        Assert.That(ev.RunContinuationAsynchronously, Is.False);

        var waiter = ev.WaitAsync();

        ev.Set();
        await waiter.ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.False);
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var ev = new AsyncAutoResetEvent();
        Assert.That(ev.RunContinuationAsynchronously, Is.True);

        ev = new AsyncAutoResetEvent(runContinuationAsynchronously: false);
        Assert.That(ev.RunContinuationAsynchronously, Is.False);

        ev.RunContinuationAsynchronously = true;
        Assert.That(ev.RunContinuationAsynchronously, Is.True);
    }

    [Theory, CancelAfter(1000)]
    public void RunContinuationAsynchronouslyExecutesCorrectly(bool runContinuationAsynchronously)
    {
        var ev = new AsyncAutoResetEvent(runContinuationAsynchronously: runContinuationAsynchronously);
        var continuationThreadId = 0;
        var signalingThreadId = 0;

        var waiter = Task.Run(async () =>
        {
            await ev.WaitAsync().ConfigureAwait(false);
            continuationThreadId = Environment.CurrentManagedThreadId;
        });

        var setter = Task.Run(async () => {
            await Task.Delay(100).ConfigureAwait(false);
            signalingThreadId = Environment.CurrentManagedThreadId;
            ev.Set();
            Thread.Sleep(1000);
        });

        Task.WaitAll(waiter, setter);

        Assert.That(continuationThreadId, runContinuationAsynchronously ? Is.Not.EqualTo(signalingThreadId) : Is.EqualTo(signalingThreadId));
    }

    [Test]
    public void ConstructorWithCustomPool()
    {
        var customPool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: customPool);

        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleConsecutiveSetCallsOnlySignalOnce()
    {
        var ev = new AsyncAutoResetEvent();

        ev.Set();
        ev.Set();
        ev.Set();

        Assert.That(ev.IsSet, Is.True);

        await ev.WaitAsync().ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.False);

        var waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        ev.Set();
        await waiter.ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAsyncAfterSetAllWithNoWaitersCompletesImmediately()
    {
        var ev = new AsyncAutoResetEvent();

        ev.SetAll();

        var waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);

        await waiter.ConfigureAwait(false);
    }

    [Test]
    public async Task CancellationOfMiddleWaiterInQueue()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        var waiter1 = ev.WaitAsync();
        using var cts = new CancellationTokenSource();
        var waiter2 = ev.WaitAsync(cts.Token);
        var waiter3 = ev.WaitAsync();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await waiter2.ConfigureAwait(false));

        ev.Set();
        await waiter1.ConfigureAwait(false);

        ev.Set();
        await waiter3.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleCancellationsOfDifferentWaiters()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        using var cts1 = new CancellationTokenSource();
        using var cts2 = new CancellationTokenSource();
        using var cts3 = new CancellationTokenSource();

        var waiter1 = ev.WaitAsync(cts1.Token);
        var waiter2 = ev.WaitAsync(cts2.Token);
        var waiter3 = ev.WaitAsync(cts3.Token);

        await AsyncAssert.CancelAsync(cts1).ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts3).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await waiter1.ConfigureAwait(false));
        Assert.ThrowsAsync<TaskCanceledException>(async () => await waiter3.ConfigureAwait(false));

        ev.Set();
        await waiter2.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task CancellationAfterSetButBeforeAwaitDoesNotThrow()
    {
        var ev = new AsyncAutoResetEvent();
        using var cts = new CancellationTokenSource();

        var waiter = ev.WaitAsync(cts.Token);
        ev.Set();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        await waiter.ConfigureAwait(false);
    }

    [Test]
    public void WaitAsyncUnsetReturnsNonCompletedValueTask()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False);

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public void WaitAsyncUnsetUsesInternalAndPooledValueTaskSource()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False);
        Assert.That(ev.InternalWaiterInUse, Is.True);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1));
    }

    [Test]
    public async Task WaitAsyncSetCompletesValueTask()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False);
        Assert.That(ev.InternalWaiterInUse, Is.True);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);
        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1));

        ev.Set();
        await vt.ConfigureAwait(false);
        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1));

        ev.Set();
        await vt2.ConfigureAwait(false);
        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncUnsetNeverCompletesAsync()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        Task t = ev.WaitAsync().AsTask();

        Assert.That(t.IsCompleted, Is.False);

        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncSetCompletesImmediatelyAndResets()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: true, pool: tpvts);

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True);

        await vt.ConfigureAwait(false);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);
        ev.Set();
        await vt2.ConfigureAwait(false);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);
        ev.Set();
        ev.Set();
        await t.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task SetWithNoWaitersSetsSignalForNextWaiter()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ev.Set();

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True);

        await vt.ConfigureAwait(false);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        ev.Set();
        ev.Set();

        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(5000)]
    public async Task SetReleasesQueuedWaiter()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ValueTask waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        _ = Task.Run(async () => { await Task.Delay(1000).ConfigureAwait(false); ev.Set(); });

        await waiter.ConfigureAwait(false);

        Assert.Throws<InvalidOperationException>(() => _ = waiter.IsCompleted);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        ev.Set();
        ev.Set();

        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    public async Task SetAllReleasesAllQueuedWaiters(int numberOfWaiters)
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        var valueTasks = new ValueTask[numberOfWaiters];
        var tasks = new Task[numberOfWaiters];

        for (int i = 0; i < numberOfWaiters; i++)
        {
            valueTasks[i] = ev.WaitAsync();
        }

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(numberOfWaiters - 1));

        for (int i = 0; i < numberOfWaiters; i++)
        {
            Assert.That(valueTasks[i].IsCompleted, Is.False);
        }

        for (int i = 0; i < numberOfWaiters; i++)
        {
            tasks[i] = ev.WaitAsync().AsTask();
        }

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(numberOfWaiters * 2 - 1));

        ev.SetAll();

        for (int i = 0; i < numberOfWaiters; i++)
        {
            await valueTasks[i].ConfigureAwait(false);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await valueTasks[i].ConfigureAwait(false));
        }

        for (int i = 0; i < numberOfWaiters; i++)
        {
            await tasks[i].ConfigureAwait(false);
        }

        for (int i = 0; i < numberOfWaiters; i++)
        {
            await tasks[i].ConfigureAwait(false);
        }

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.False);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        ev.Set();
        ev.Set();

        await vt.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task SetAllWithNoWaitersSetsSignalForNextWaiter()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);

        ev.SetAll();

        ValueTask vt = ev.WaitAsync();
        Assert.That(vt.IsCompleted, Is.True);

        await vt.ConfigureAwait(false);

        ValueTask vt2 = ev.WaitAsync();
        Assert.That(vt2.IsCompleted, Is.False);

        Task t = ev.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        ev.Set();
        ev.Set();

        await vt2.ConfigureAwait(false);
        await t.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenCancels(bool useAsTask)
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        if (useAsTask)
        {
            Task t = ev.WaitAsync(cts.Token).AsTask();
            Assert.ThrowsAsync<TaskCanceledException>(async () => await t.ConfigureAwait(false));
        }
        else
        {
            Assert.ThrowsAsync<TaskCanceledException>(async () => await ev.WaitAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued(bool useAsTask)
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: tpvts);
        using var cts = new CancellationTokenSource();

        if (useAsTask)
        {
            Task t = ev.WaitAsync(cts.Token).AsTask();
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
            Assert.ThrowsAsync<TaskCanceledException>(async () => await t.ConfigureAwait(false));
        }
        else
        {
            ValueTask vt = ev.WaitAsync(cts.Token);
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
            Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
        }

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled(bool useAsTask)
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        if (useAsTask)
        {
            Task t = ev.WaitAsync(cts.Token).AsTask();
            await t.ConfigureAwait(false);
        }
        else
        {
            await ev.WaitAsync(cts.Token).ConfigureAwait(false);
        }

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }
}

