// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
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
public class AsyncSemaphoreUnitTests
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
        Assert.That(semaphore.CurrentCount, Is.EqualTo(0));
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
        Assert.That(semaphore.CurrentCount, Is.EqualTo(0));
    }

    [Test]
    public async Task ReleaseIncreasesCurrentCount()
    {
        var semaphore = new AsyncSemaphore(1);

        await semaphore.WaitAsync().ConfigureAwait(false);
        Assert.That(semaphore.CurrentCount, Is.EqualTo(0));

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
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);

        var waiter = semaphore.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        semaphore.Release();
        await waiter.ConfigureAwait(false);

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task MultipleWaitersAreReleasedInOrder()
    {
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);
        var completed = new System.Collections.Concurrent.ConcurrentBag<int>();

        var t1 = semaphore.WaitAsync();
        await Task.Delay(50).ConfigureAwait(false);
        var t2 = semaphore.WaitAsync();
        await Task.Delay(50).ConfigureAwait(false);
        var t3 = semaphore.WaitAsync();

        Assert.That(t1.IsCompleted, Is.False);
        Assert.That(t2.IsCompleted, Is.False);
        Assert.That(t3.IsCompleted, Is.False);

        semaphore.Release(3);

        await t1.ConfigureAwait(false);
        completed.Add(1);
        await t2.ConfigureAwait(false);
        completed.Add(2);
        await t3.ConfigureAwait(false);
        completed.Add(3);

        Assert.That(completed.Count, Is.EqualTo(3));

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task ReleaseManyReleasesMultipleWaiters()
    {
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);

        var t1 = semaphore.WaitAsync();
        var t2 = semaphore.WaitAsync();
        var t3 = semaphore.WaitAsync();

        Assert.That(t1.IsCompleted, Is.False);
        Assert.That(t2.IsCompleted, Is.False);
        Assert.That(t3.IsCompleted, Is.False);

        semaphore.Release(2);

        await t1.ConfigureAwait(false);
        await t2.ConfigureAwait(false);

        Assert.That(t3.IsCompleted, Is.False);

        semaphore.Release();
        await t3.ConfigureAwait(false);

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationBeforeWaitThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await semaphore.WaitAsync(cts.Token).ConfigureAwait(false));

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);
        using var cts = new CancellationTokenSource();

        var waiter = semaphore.WaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await waiter.ConfigureAwait(false));

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancelledMiddleWaiterDoesNotAffectOthers()
    {
        var customPool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(0, pool: customPool);
        using var cts = new CancellationTokenSource();

        var t1 = semaphore.WaitAsync();
        var t2 = semaphore.WaitAsync(cts.Token);
        var t3 = semaphore.WaitAsync();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await t2.ConfigureAwait(false));

        semaphore.Release(2);

        await t1.ConfigureAwait(false);
        await t3.ConfigureAwait(false);

        Assert.That(semaphore.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
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
}
