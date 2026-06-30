// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
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
public class AsyncAutoResetEventTests
{
    [Test]
    public async Task IsSetReflectsEventState()
    {
        var ev = new AsyncAutoResetEvent(initialState: false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.IsSet, Is.False);
            Assert.That(ev.RunContinuationAsynchronously, Is.True);
        }

        ev.Set();
        Assert.That(ev.IsSet, Is.True);

        await ev.WaitAsync().ConfigureAwait(false);
        Assert.That(ev.IsSet, Is.False);
    }

    [Test]
    public async Task IsSetReturnsFalseAfterSetReleasesWaiter()
    {
        var ev = new AsyncAutoResetEvent(initialState: false, runContinuationAsynchronously: false);
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

    [Theory, CancelAfter(3000)]
    public async Task RunContinuationAsynchronouslyExecutesCorrectly(bool runContinuationAsynchronously)
    {
        AsyncAutoResetEvent ev = new(runContinuationAsynchronously: runContinuationAsynchronously);
        int stage = 0;

        var waiter = Task.Run(async () => {
            await ev.WaitAsync().ConfigureAwait(false);
            await Task.Delay(100).ConfigureAwait(false);
            Interlocked.Exchange(ref stage, 100);
        });

        // Give the waiter time to start waiting
        await Task.Delay(100).ConfigureAwait(false);

        int beforeContinuation = Interlocked.Exchange(ref stage, 1);
        ev.Set();
        int afterContinuation = Interlocked.Exchange(ref stage, 2);

        // Wait for continuation to complete
        await waiter.ConfigureAwait(false);

        Assert.That(beforeContinuation, Is.Zero);
        if (runContinuationAsynchronously)
        {
            using (Assert.EnterMultipleScope())
            {
                // Continuation should not have run inline
                Assert.That(afterContinuation, Is.EqualTo(1));
                Assert.That(stage, Is.EqualTo(100));
            }
        }
        else
        {
            using (Assert.EnterMultipleScope())
            {
                // Continuation may have run inline
                Assert.That(afterContinuation, Is.AnyOf(1, 100));
                Assert.That(stage, Is.AnyOf(2, 100));
            }
        }
    }

    [Test]
    public void ConstructorWithCustomPool()
    {
        using var customPool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: customPool);
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
    public async Task WaitAsyncAfterPulseAllWithNoWaitersCompletesImmediately()
    {
        var ev = new AsyncAutoResetEvent();

        ev.PulseAll();

        var waiter = ev.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);

        await waiter.ConfigureAwait(false);
    }

    [Test]
    public async Task CancellationOfMiddleWaiterInQueue()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        var waiter1 = ev.WaitAsync();
        using var cts = new CancellationTokenSource();
        var waiter2 = ev.WaitAsync(cts.Token);
        var waiter3 = ev.WaitAsync();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        ev.Set();
        await waiter1.ConfigureAwait(false);

        ev.Set();
        await waiter3.ConfigureAwait(false);

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleCancellationsOfDifferentWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        using var cts1 = new CancellationTokenSource();
        using var cts2 = new CancellationTokenSource();
        using var cts3 = new CancellationTokenSource();

        var waiter1 = ev.WaitAsync(cts1.Token);
        var waiter2 = ev.WaitAsync(cts2.Token);
        var waiter3 = ev.WaitAsync(cts3.Token);

        await AsyncAssert.CancelAsync(cts1).ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts3).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter1.ConfigureAwait(false));
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter3.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        ev.Set();
        await waiter2.ConfigureAwait(false);

        Assert.That(pool.ActiveCount, Is.Zero);
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
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        ValueTask vt = ev.WaitAsync();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt.IsCompleted, Is.False);

            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    [CancelAfter(10000)]
    public async Task WaitAsyncCancelReturnsToPool(CancellationToken ct)
    {
        using var cts = new CancellationTokenSource();
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: pool);

        ValueTask vt = ev.WaitAsync(cts.Token);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt.IsCompleted, Is.False);
            Assert.That(ev.InternalWaiterInUse, Is.True);
        }

        ValueTask vt2 = ev.WaitAsync(cts.Token);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt2.IsCompleted, Is.False);
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(1));
        }

        // cancel
        cts.CancelAfter(TimeSpan.FromMilliseconds(500));

        // pooled waiter is canceled during wait, then returned to pool
#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure
        Assert.That(ev.IsSet, Is.False);

        // internal waiter hits cancel and is returned to local 
        ev.Set();
#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(ev.IsSet, Is.True);
        }
    }

    [Test]
    public async Task WaitAsyncSetCompletesValueTask()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: pool);

        ValueTask vt = ev.WaitAsync();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt.IsCompleted, Is.False);
            Assert.That(ev.InternalWaiterInUse, Is.True);
        }

        ValueTask vt2 = ev.WaitAsync();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt2.IsCompleted, Is.False);
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(1));
        }

        ev.Set();
        await vt.ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.EqualTo(1));
        }

        ev.Set();
        await vt2.ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task WaitAsyncUnsetNeverCompletesAsync()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        Task t = ev.WaitAsync().AsTask();

        Assert.That(t.IsCompleted, Is.False);

        await AsyncAssert.NeverCompletesAsync(t).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task WaitAsyncSetCompletesImmediatelyAndResets()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: true, pool: pool);

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task SetWithNoWaitersSetsSignalForNextWaiter()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test, CancelAfter(5000)]
    public async Task SetReleasesQueuedWaiter()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    public async Task PulseAllReleasesAllQueuedWaiters(int numberOfWaiters)
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        var valueTasks = new ValueTask[numberOfWaiters];
        var tasks = new Task[numberOfWaiters];

        for (int i = 0; i < numberOfWaiters; i++)
        {
            valueTasks[i] = ev.WaitAsync();
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(numberOfWaiters - 1));
        }

        for (int i = 0; i < numberOfWaiters; i++)
        {
            Assert.That(valueTasks[i].IsCompleted, Is.False);
        }

        for (int i = 0; i < numberOfWaiters; i++)
        {
            tasks[i] = ev.WaitAsync().AsTask();
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.True);
            Assert.That(pool.ActiveCount, Is.EqualTo(numberOfWaiters * 2 - 1));
        }

        ev.PulseAll();

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task PulseAllWithNoWaitersSetsSignalForNextWaiter()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        ev.PulseAll();

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenCancels(bool useAsTask)
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncManualResetEvent(pool: pool);
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued(bool useAsTask)
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(initialState: false, pool: pool);
        using var cts = new CancellationTokenSource();

        if (useAsTask)
        {
            Task t = ev.WaitAsync(cts.Token).AsTask();
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
#if NETFRAMEWORK
            Assert.ThrowsAsync<TaskCanceledException>(async () => await t.ConfigureAwait(false));
#else
            Assert.ThrowsAsync<OperationCanceledException>(async () => await t.ConfigureAwait(false));
#endif
        }
        else
        {
            ValueTask vt = ev.WaitAsync(cts.Token);
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
#pragma warning disable CHT010 // ValueTask captured in lambda or closure
            Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Theory]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled(bool useAsTask)
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public void TryReset_SucceedsWhenNotInUse()
    {
        var ev = new AsyncAutoResetEvent();

        Assert.That(ev.IsSet, Is.False);

        bool reset = ev.TryReset();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(reset, Is.True);

            Assert.That(ev.IsSet, Is.False);
            Assert.That(ev.RunContinuationAsynchronously, Is.True);
        }
    }

    [Test]
    public async Task WaitAsyncWithTimeoutCompletesWhenSignalledBeforeTimeout()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        _ = Task.Run(async () => { await Task.Delay(50).ConfigureAwait(false); ev.Set(); });

        await ev.WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test, CancelAfter(3000)]
    public async Task WaitAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        var ev = new AsyncAutoResetEvent();

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await ev.WaitAsync(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(ev.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutThrowsImmediatelyWhenNotSignalled()
    {
        var ev = new AsyncAutoResetEvent();

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await ev.WaitAsync(TimeSpan.Zero).ConfigureAwait(false));
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutCompletesImmediatelyWhenSignalled()
    {
        var ev = new AsyncAutoResetEvent(initialState: true);

        await ev.WaitAsync(TimeSpan.Zero).ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.False);
    }

    [Test]
    public void WaitAsyncWithNegativeTimeoutThrows()
    {
        var ev = new AsyncAutoResetEvent();

#pragma warning disable VSTHRD110 // Observe the awaitable result
        Assert.Throws<ArgumentOutOfRangeException>(() => ev.WaitAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore VSTHRD110
    }

    [Test]
    public async Task WaitAsyncWithInfiniteTimeoutBehavesLikeWaitAsync()
    {
        var ev = new AsyncAutoResetEvent();

        ev.Set();

        await ev.WaitAsync(Timeout.InfiniteTimeSpan).ConfigureAwait(false);

        Assert.That(ev.IsSet, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithTimeoutPooledWaitersAreReturnedOnSignal()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        // Force use of pooled waiter by exhausting the local waiter with a first pending wait.
        var waiter1 = ev.WaitAsync(TimeSpan.FromSeconds(5));
        var waiter2 = ev.WaitAsync(TimeSpan.FromSeconds(5));

        ev.Set();
        ev.Set();

        await waiter1.ConfigureAwait(false);
        await waiter2.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test, CancelAfter(3000)]
    public async Task WaitAsyncWithTimeoutPooledWaitersAreReturnedOnTimeout()
    {
        using var pool = new TestObjectPool<bool>();
        var ev = new AsyncAutoResetEvent(pool: pool);

        var waiter1 = ev.WaitAsync(TimeSpan.FromMilliseconds(200));
        var waiter2 = ev.WaitAsync(TimeSpan.FromMilliseconds(200));

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter1.ConfigureAwait(false));
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        await Task.Delay(50).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ev.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }
}

