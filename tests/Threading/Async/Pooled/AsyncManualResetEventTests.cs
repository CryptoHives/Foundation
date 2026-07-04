// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CHT001 // ValueTask awaited multiple times - intentionally testing cancellation behavior

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncManualResetEventTests
{
    [Test]
    public void IsSetReflectsEventState()
    {
        var mre = new AsyncManualResetEvent(set: false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.IsSet, Is.False);
            Assert.That(mre.RunContinuationAsynchronously, Is.True);
        }

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

        mre.RunContinuationAsynchronously = false;
        Assert.That(mre.RunContinuationAsynchronously, Is.False);
    }

    [Test]
    public void ConstructorWithCustomPool()
    {
        using var pool = new TestObjectPool<bool>();
        _ = new AsyncManualResetEvent(pool: pool);

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncUnsetNeverCompletes()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: pool);

        Task task = mre.WaitAsync().AsTask();

        await AsyncAssert.NeverCompletesAsync(task).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Theory]
    public void WaitAsyncAfterSetCompletesSynchronously(bool useAsTask)
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: pool);

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

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test]
    public void WaitAsyncWithInitialStateSetCompletesSynchronously()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: pool);

        ValueTask task = mre.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task MultipleWaitersCompleteAfterSet()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: pool);

        Task t1 = mre.WaitAsync().AsTask();
        Task t2 = mre.WaitAsync().AsTask();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(1));
        }

        mre.Set();

        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(t1.IsCompleted, Is.True);
            Assert.That(t2.IsCompleted, Is.True);
            Assert.That(mre.IsSet, Is.True);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(10)]
    public async Task MultipleWaitersAllComplete(int numberOfWaiters)
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: pool);

        Task[] taskWaiters = Enumerable.Range(0, numberOfWaiters).Select(_ => mre.WaitAsync().AsTask()).ToArray();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(numberOfWaiters - 1));
        }

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task ResetUnsetsEvent()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: pool);

        Assert.That(mre.IsSet, Is.True);

        mre.Reset();

        Assert.That(mre.IsSet, Is.False);

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.True);
    }

    [Test]
    public async Task ResetWhenAlreadyResetDoesNothing()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: false, pool: pool);

        mre.Reset();

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);

        Assert.That(mre.InternalWaiterInUse, Is.True);
    }

    [Test]
    public async Task SetAfterResetReleasesNewWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(set: true, pool: pool);

        await mre.WaitAsync().ConfigureAwait(false);

        mre.Reset();

        var waiter = mre.WaitAsync().AsTask();
        Assert.That(waiter.IsCompleted, Is.False);

        mre.Set();

        await waiter.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mre.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task MultipleSetCallsOnlySignalOnce()
    {
        using var pool = new TestObjectPool<bool>();
        var mre = new AsyncManualResetEvent(pool: pool);

        mre.Set();
        mre.Set();
        mre.Set();

        Assert.That(mre.IsSet, Is.True);

        await mre.WaitAsync().ConfigureAwait(false);

        Assert.That(mre.IsSet, Is.True);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueuing()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        ValueTask vt = ev.WaitAsync(cts.Token);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(set: false, pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask vt = ev.WaitAsync(cts.Token);

        _ = Task.Run(async () => { await Task.Delay(100).ConfigureAwait(false); ev.Set(); });

        await vt.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancellationOfMiddleWaiterInQueue()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        var waiter1 = ev.WaitAsync();
        using var cts = new CancellationTokenSource();
        var waiter2 = ev.WaitAsync(cts.Token);
        var waiter3 = ev.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(2));
        }

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(1));
        }

        ev.Set();

        await waiter1.ConfigureAwait(false);
        await waiter3.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancellationAfterSetButBeforeAwaitDoesNotThrow()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);
        using var cts = new CancellationTokenSource();

        var waiter = ev.WaitAsync(cts.Token);
        ev.Set();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        await waiter.ConfigureAwait(false);

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test]
    public void TryReset_SucceedsWhenNotInUse()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(set: true, pool: pool);

        Assert.That(ev.IsSet, Is.True);

        bool reset = ev.TryReset();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(reset, Is.True);
            Assert.That(ev.IsSet, Is.False);
            Assert.That(ev.RunContinuationAsynchronously, Is.True);
        }
    }

    [Test]
    public async Task TryReset_FailsWhileWaitersQueued()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(set: false, pool: pool);

        var waiterTask = Task.Run(async () => await ev.WaitAsync().ConfigureAwait(false));

        while (!ev.InternalWaiterInUse)
        {
            await Task.Delay(1).ConfigureAwait(false);
        }

        Assert.That(ev.TryReset(), Is.False);

        ev.Set();
        await waiterTask.ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAsyncWithTimeoutCompletesWhenSetBeforeTimeout()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        _ = Task.Run(async () => { await Task.Delay(50).ConfigureAwait(false); ev.Set(); });

        await ev.WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
    }

    [Test, CancelAfter(3000)]
    public async Task WaitAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        Assert.ThrowsAsync<TimeoutException>(async () =>
            await ev.WaitAsync(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutThrowsImmediatelyWhenNotSet()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        Assert.ThrowsAsync<TimeoutException>(async () =>
            await ev.WaitAsync(TimeSpan.Zero).ConfigureAwait(false));
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutCompletesImmediatelyWhenSet()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(set: true, pool: pool);

        await ev.WaitAsync(TimeSpan.Zero).ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.True);
    }

    [Test]
    public void WaitAsyncWithNegativeTimeoutThrows()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

#pragma warning disable VSTHRD110
        Assert.Throws<ArgumentOutOfRangeException>(() => ev.WaitAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore VSTHRD110
    }

    [Test]
    public async Task WaitAsyncWithInfiniteTimeoutBehavesLikeWaitAsync()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);

        ev.Set();

        await ev.WaitAsync(Timeout.InfiniteTimeSpan).ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.True);
    }
}
