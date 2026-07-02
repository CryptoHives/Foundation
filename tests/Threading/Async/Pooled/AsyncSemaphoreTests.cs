// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncSemaphoreTests
{
    [Test]
    public void ConstructorWithNegativeCountThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncSemaphore(-1));
    }

    [Test]
    public void ConstructorWithZeroCountIsValid()
    {
        var semaphore = new AsyncSemaphore(0);
        Assert.That(semaphore.CurrentCount, Is.Zero);
    }

    [Test]
    public async Task CurrentCountDecreasesOnWait()
    {
        var semaphore = new AsyncSemaphore(3);
        Assert.That(semaphore.CurrentCount, Is.EqualTo(3));

        await semaphore.WaitAsync().ConfigureAwait(false);
        Assert.That(semaphore.CurrentCount, Is.EqualTo(2));

        await semaphore.WaitAsync().ConfigureAwait(false);
        Assert.That(semaphore.CurrentCount, Is.EqualTo(1));

        await semaphore.WaitAsync().ConfigureAwait(false);
        Assert.That(semaphore.CurrentCount, Is.Zero);
    }

    [Test]
    public async Task ReleaseIncreasesCurrentCount()
    {
        var semaphore = new AsyncSemaphore(1);

        await semaphore.WaitAsync().ConfigureAwait(false);
        Assert.That(semaphore.CurrentCount, Is.Zero);

        semaphore.Release();
        Assert.That(semaphore.CurrentCount, Is.EqualTo(1));
    }

    [Test]
    public void ReleaseWithZeroCountThrows()
    {
        var semaphore = new AsyncSemaphore(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => semaphore.Release(0));
    }

    [Test]
    public async Task WaitAsyncBlocksWhenCountIsZero()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);

        var waiter = semaphore.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        semaphore.Release();
        await waiter.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task MultipleWaitersAreReleasedInOrder()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);
        var completed = new System.Collections.Concurrent.ConcurrentBag<int>();

        var t1 = semaphore.WaitAsync();
        await Task.Delay(50).ConfigureAwait(false);
        var t2 = semaphore.WaitAsync();
        await Task.Delay(50).ConfigureAwait(false);
        var t3 = semaphore.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(t1.IsCompleted, Is.False);
            Assert.That(t2.IsCompleted, Is.False);
            Assert.That(t3.IsCompleted, Is.False);
        }

        semaphore.Release(3);

        await t1.ConfigureAwait(false);
        completed.Add(1);
        await t2.ConfigureAwait(false);
        completed.Add(2);
        await t3.ConfigureAwait(false);
        completed.Add(3);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(completed, Has.Count.EqualTo(3));

            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task ReleaseManyReleasesMultipleWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);

        var t1 = semaphore.WaitAsync();
        var t2 = semaphore.WaitAsync();
        var t3 = semaphore.WaitAsync();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(t1.IsCompleted, Is.False);
            Assert.That(t2.IsCompleted, Is.False);
            Assert.That(t3.IsCompleted, Is.False);
        }

        semaphore.Release(2);

        await t1.ConfigureAwait(false);
        await t2.ConfigureAwait(false);

        Assert.That(t3.IsCompleted, Is.False);

        semaphore.Release();
        await t3.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancellationBeforeWaitThrows()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await semaphore.WaitAsync(cts.Token).ConfigureAwait(false));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);
        using var cts = new CancellationTokenSource();

        var waiter = semaphore.WaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda/closure
        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await waiter.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda/closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancelledMiddleWaiterDoesNotAffectOthers()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);
        using var cts = new CancellationTokenSource();

        var t1 = semaphore.WaitAsync();
#pragma warning disable CHT001 // ValueTask awaited multiple times
        var t2 = semaphore.WaitAsync(cts.Token);
#pragma warning restore CHT001 // ValueTask awaited multiple times
        var t3 = semaphore.WaitAsync();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda/closure
        Assert.ThrowsAsync<OperationCanceledException>(async () => await t2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda/closure

        semaphore.Release(2);

        await t1.ConfigureAwait(false);
        await t3.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var semaphore = new AsyncSemaphore(1);
        Assert.That(semaphore.RunContinuationAsynchronously, Is.True);

        semaphore = new AsyncSemaphore(1, runContinuationAsynchronously: false);
        Assert.That(semaphore.RunContinuationAsynchronously, Is.False);

        semaphore.RunContinuationAsynchronously = true;
        Assert.That(semaphore.RunContinuationAsynchronously, Is.True);
    }

    [Test]
    public async Task WaitAsyncWithTimeoutCompletesWhenPermitAvailableBeforeTimeout()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: pool);

        _ = Task.Run(async () => { await Task.Delay(50).ConfigureAwait(false); semaphore.Release(); });

        await semaphore.WaitAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(semaphore.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test, CancelAfter(3000)]
    public async Task WaitAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        var semaphore = new AsyncSemaphore(0);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await semaphore.WaitAsync(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutCompletesImmediatelyWhenPermitAvailable()
    {
        var semaphore = new AsyncSemaphore(1);

        await semaphore.WaitAsync(TimeSpan.Zero).ConfigureAwait(false);

        Assert.That(semaphore.CurrentCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithZeroTimeoutThrowsWhenNoPermit()
    {
        var semaphore = new AsyncSemaphore(0);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await semaphore.WaitAsync(TimeSpan.Zero).ConfigureAwait(false));
    }

    [Test]
    public void WaitAsyncWithNegativeTimeoutThrows()
    {
        var semaphore = new AsyncSemaphore(1);

#pragma warning disable VSTHRD110
        Assert.Throws<ArgumentOutOfRangeException>(() => semaphore.WaitAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore VSTHRD110
    }

    [Test]
    public async Task WaitAsyncWithInfiniteTimeoutBehavesLikeWaitAsync()
    {
        var semaphore = new AsyncSemaphore(1);

        await semaphore.WaitAsync(Timeout.InfiniteTimeSpan).ConfigureAwait(false);

        Assert.That(semaphore.CurrentCount, Is.Zero);
    }

    [Test]
    [Repeat(50)]
    public async Task Release_RacingWaiterCancellation_NoLostPermitOrCorruption()
    {
        var semaphore = new AsyncSemaphore(0);

        const int waiterCount = 4;
        var ctsList = new CancellationTokenSource[waiterCount];
        var waitTasks = new ValueTask[waiterCount];
        for (int i = 0; i < waiterCount; i++)
        {
            ctsList[i] = new CancellationTokenSource();
            waitTasks[i] = semaphore.WaitAsync(ctsList[i].Token);
        }

        // Cancel one queued waiter concurrently with releasing exactly enough permits for all
        // of them - racing Release's batch DetachUpTo against the cancellation callback's
        // single-node removal of the same waiter.
        var cancelTask = Task.Run(() => ctsList[1].Cancel());
        var releaseTask = Task.Run(() => semaphore.Release(waiterCount));

        await Task.WhenAll(cancelTask, releaseTask).ConfigureAwait(false);

        int granted = 0;
        int canceled = 0;
        for (int i = 0; i < waiterCount; i++)
        {
            try
            {
                await waitTasks[i].ConfigureAwait(false);
                granted++;
            }
            catch (OperationCanceledException)
            {
                canceled++;
            }
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(granted + canceled, Is.EqualTo(waiterCount));
            // Any permit not consumed by a cancelled waiter must be returned to the count, not lost.
            Assert.That(semaphore.CurrentCount, Is.EqualTo(waiterCount - granted));
        }

        foreach (var cts in ctsList)
        {
            cts.Dispose();
        }
    }
}
