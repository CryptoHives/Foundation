// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncManualResetEventUnitTests
{
    [Test]
    public void IsSetReflectsEventState()
    {
        var mre = new AsyncManualResetEvent(set: false);
        Assert.That(mre.IsSet, Is.False);

        mre.Set();
        Assert.That(mre.IsSet, Is.True);

        mre.Reset();
        Assert.That(mre.IsSet, Is.False);
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var mre = new AsyncManualResetEvent();
        Assert.That(mre.RunContinuationAsynchronously, Is.True);

        mre = new AsyncManualResetEvent(runContinuationAsynchronously: false);
        Assert.That(mre.RunContinuationAsynchronously, Is.False);

        mre.RunContinuationAsynchronously = true;
        Assert.That(mre.RunContinuationAsynchronously, Is.True);
    }

    [Test]
    public void ConstructorWithCustomPool()
    {
        var customPool = new TestObjectPool<bool>();
        _ = new AsyncManualResetEvent(pool: customPool);

        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncUnsetNeverCompletes()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: tpvts);

        Task task = mre.WaitAsync().AsTask();

        await AsyncAssert.NeverCompletesAsync(task).ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Theory]
    public void WaitAsyncAfterSetCompletesSynchronously(bool useAsTask)
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: tpvts);

        mre.Set();

        if (useAsTask)
        {
            Task task = mre.WaitAsync().AsTask();
            Assert.That(task.IsCompleted, Is.True);
        }
        else
        {
            ValueTask task = mre.WaitAsync();
            Assert.That(task.IsCompleted, Is.True);
        }

        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public void WaitAsyncWithInitialStateSetCompletesSynchronously()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: tpvts);

        ValueTask task = mre.WaitAsync();

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleWaitersCompleteAfterSet()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: tpvts);

        Task t1 = mre.WaitAsync().AsTask();
        Task t2 = mre.WaitAsync().AsTask();

        Assert.That(mre.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1));

        mre.Set();

        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(t1.IsCompleted, Is.True);
            Assert.That(t2.IsCompleted, Is.True);
            Assert.That(mre.IsSet, Is.True);
        }

        Assert.That(mre.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(10)]
    public async Task MultipleWaitersAllComplete(int numberOfWaiters)
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: tpvts);

        Task[] taskWaiters = Enumerable.Range(0, numberOfWaiters).Select(_ => mre.WaitAsync().AsTask()).ToArray();

        Assert.That(mre.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(numberOfWaiters - 1));

        foreach (Task t in taskWaiters)
        {
            Assert.That(t.IsCompleted, Is.False);
        }

        mre.Set();

        await Task.WhenAll(taskWaiters).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(taskWaiters.All(t => t.IsCompleted), Is.True);
            Assert.That(mre.IsSet, Is.True);
        }

        Assert.That(mre.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task ResetUnsetsEvent()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: tpvts);

        Assert.That(mre.IsSet, Is.True);

        mre.Reset();

        Assert.That(mre.IsSet, Is.False);

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task ResetWhenAlreadyResetDoesNothing()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: false, pool: tpvts);

        mre.Reset();

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task SetAfterResetReleasesNewWaiters()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: tpvts);

        await mre.WaitAsync().ConfigureAwait(false);

        mre.Reset();

        var waiter = mre.WaitAsync().AsTask();
        Assert.That(waiter.IsCompleted, Is.False);

        mre.Set();

        await waiter.ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleSetCallsOnlySignalOnce()
    {
        var tpvts = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: tpvts);

        mre.Set();
        mre.Set();
        mre.Set();

        Assert.That(mre.IsSet, Is.True);

        await mre.WaitAsync().ConfigureAwait(false);

        Assert.That(mre.IsSet, Is.True);

        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueuing()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        ValueTask vt = ev.WaitAsync(cts.Token);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(set: false, pool: tpvts);
        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        await vt.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task CancellationOfMiddleWaiterInQueue()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: tpvts);

        var waiter1 = ev.WaitAsync();
        using var cts = new CancellationTokenSource();
        var waiter2 = ev.WaitAsync(cts.Token);
        var waiter3 = ev.WaitAsync();

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(2));

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await waiter2.ConfigureAwait(false));

        Assert.That(ev.InternalWaiterInUse, Is.True);
        Assert.That(tpvts.ActiveCount, Is.EqualTo(1));

        ev.Set();

        await waiter1.ConfigureAwait(false);
        await waiter3.ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
        Assert.That(tpvts.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task CancellationAfterSetButBeforeAwaitDoesNotThrow()
    {
        var tpvts = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: tpvts);
        using var cts = new CancellationTokenSource();

        var waiter = ev.WaitAsync(cts.Token);
        ev.Set();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        await waiter.ConfigureAwait(false);

        Assert.That(tpvts.ActiveCount, Is.Zero);
    }
}
