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
public class AsyncCountdownEventUnitTests
{
    [Test]
    public void ConstructorWithZeroCountThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncCountdownEvent(0));
    }

    [Test]
    public void ConstructorWithNegativeCountThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncCountdownEvent(-1));
    }

    [Test]
    public void InitialCountIsCorrect()
    {
        var countdown = new AsyncCountdownEvent(5);
        Assert.That(countdown.CurrentCount, Is.EqualTo(5));
        Assert.That(countdown.InitialCount, Is.EqualTo(5));
        Assert.That(countdown.IsSet, Is.False);
    }

    [Test]
    public void SignalDecrementsCount()
    {
        var countdown = new AsyncCountdownEvent(3);

        countdown.Signal();
        Assert.That(countdown.CurrentCount, Is.EqualTo(2));

        countdown.Signal();
        Assert.That(countdown.CurrentCount, Is.EqualTo(1));

        countdown.Signal();
        Assert.That(countdown.CurrentCount, Is.EqualTo(0));
        Assert.That(countdown.IsSet, Is.True);
    }

    [Test]
    public void SignalWhenZeroThrows()
    {
        var countdown = new AsyncCountdownEvent(1);
        countdown.Signal();

        Assert.Throws<InvalidOperationException>(() => countdown.Signal());
    }

    [Test]
    public void SignalWithZeroCountThrows()
    {
        var countdown = new AsyncCountdownEvent(1);
        Assert.Throws<ArgumentOutOfRangeException>(() => countdown.Signal(0));
    }

    [Test]
    public void SignalExceedingCountThrows()
    {
        var countdown = new AsyncCountdownEvent(2);
        Assert.Throws<InvalidOperationException>(() => countdown.Signal(3));
    }

    [Test]
    public async Task WaitAsyncCompletesWhenCountReachesZero()
    {
        var customPool = new TestObjectPool<bool>();
        var countdown = new AsyncCountdownEvent(2, pool: customPool);

        var waiter = countdown.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        countdown.Signal();
        Assert.That(waiter.IsCompleted, Is.False);

        countdown.Signal();
        await waiter.ConfigureAwait(false);

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncCompletesImmediatelyWhenAlreadySet()
    {
        var countdown = new AsyncCountdownEvent(1);
        countdown.Signal();

        var waiter = countdown.WaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);
        await waiter.ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleWaitersAreAllReleased()
    {
        var customPool = new TestObjectPool<bool>();
        var countdown = new AsyncCountdownEvent(1, pool: customPool);

        var t1 = countdown.WaitAsync();
        var t2 = countdown.WaitAsync();
        var t3 = countdown.WaitAsync();

        Assert.That(t1.IsCompleted, Is.False);
        Assert.That(t2.IsCompleted, Is.False);
        Assert.That(t3.IsCompleted, Is.False);

        countdown.Signal();

        await t1.ConfigureAwait(false);
        await t2.ConfigureAwait(false);
        await t3.ConfigureAwait(false);

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task SignalAndWaitAsyncSignalsAndWaits()
    {
        var countdown = new AsyncCountdownEvent(2);

        var t1 = Task.Run(async () => await countdown.SignalAndWaitAsync().ConfigureAwait(false));

        await Task.Delay(100).ConfigureAwait(false);
        Assert.That(countdown.CurrentCount, Is.EqualTo(1));

        countdown.Signal();

        await t1.ConfigureAwait(false);
        Assert.That(countdown.IsSet, Is.True);
    }

    [Test]
    public void AddCountIncrementsCount()
    {
        var countdown = new AsyncCountdownEvent(2);

        countdown.AddCount();
        Assert.That(countdown.CurrentCount, Is.EqualTo(3));

        countdown.AddCount(2);
        Assert.That(countdown.CurrentCount, Is.EqualTo(5));
    }

    [Test]
    public void AddCountWhenSetThrows()
    {
        var countdown = new AsyncCountdownEvent(1);
        countdown.Signal();

        Assert.Throws<InvalidOperationException>(() => countdown.AddCount());
    }

    [Test]
    public void TryAddCountReturnsTrueWhenNotSet()
    {
        var countdown = new AsyncCountdownEvent(2);

        Assert.That(countdown.TryAddCount(), Is.True);
        Assert.That(countdown.CurrentCount, Is.EqualTo(3));
    }

    [Test]
    public void TryAddCountReturnsFalseWhenSet()
    {
        var countdown = new AsyncCountdownEvent(1);
        countdown.Signal();

        Assert.That(countdown.TryAddCount(), Is.False);
        Assert.That(countdown.CurrentCount, Is.EqualTo(0));
    }

    [Test]
    public void TryAddCountReturnsFalseForInvalidCount()
    {
        var countdown = new AsyncCountdownEvent(2);
        Assert.That(countdown.TryAddCount(0), Is.False);
        Assert.That(countdown.TryAddCount(-1), Is.False);
    }

    [Test]
    public void ResetResetsToInitialCount()
    {
        var countdown = new AsyncCountdownEvent(3);
        countdown.Signal();
        countdown.Signal();
        countdown.Signal();

        Assert.That(countdown.IsSet, Is.True);

        countdown.Reset();

        Assert.That(countdown.CurrentCount, Is.EqualTo(3));
        Assert.That(countdown.IsSet, Is.False);
    }

    [Test]
    public void ResetWithNewCount()
    {
        var countdown = new AsyncCountdownEvent(3);
        countdown.Signal();
        countdown.Signal();
        countdown.Signal();

        countdown.Reset(5);

        Assert.That(countdown.CurrentCount, Is.EqualTo(5));
        Assert.That(countdown.InitialCount, Is.EqualTo(5));
    }

    [Test]
    public async Task CancellationBeforeWaitThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var countdown = new AsyncCountdownEvent(2, pool: customPool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await countdown.WaitAsync(cts.Token).ConfigureAwait(false));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var countdown = new AsyncCountdownEvent(2, pool: customPool);
        using var cts = new CancellationTokenSource();

        var waiter = countdown.WaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await waiter.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var countdown = new AsyncCountdownEvent(1);
        Assert.That(countdown.RunContinuationAsynchronously, Is.True);

        countdown = new AsyncCountdownEvent(1, runContinuationAsynchronously: false);
        Assert.That(countdown.RunContinuationAsynchronously, Is.False);

        countdown.RunContinuationAsynchronously = true;
        Assert.That(countdown.RunContinuationAsynchronously, Is.True);
    }
}
