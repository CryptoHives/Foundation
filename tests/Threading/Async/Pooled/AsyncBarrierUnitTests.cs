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
public class AsyncBarrierUnitTests
{
    [Test]
    public void ConstructorWithZeroParticipantsThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncBarrier(0));
    }

    [Test]
    public void ConstructorWithNegativeParticipantsThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncBarrier(-1));
    }

    [Test]
    public void ParticipantCountIsCorrect()
    {
        var barrier = new AsyncBarrier(5);
        Assert.That(barrier.ParticipantCount, Is.EqualTo(5));
        Assert.That(barrier.RemainingParticipants, Is.EqualTo(5));
        Assert.That(barrier.CurrentPhase, Is.EqualTo(0));
    }

    [Test]
    public async Task SingleParticipantCompletesImmediately()
    {
        var barrier = new AsyncBarrier(1);

        var waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);
        await waiter.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
        Assert.That(barrier.RemainingParticipants, Is.EqualTo(1));
    }

    [Test]
    public async Task TwoParticipantsSynchronize()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);
        var reached = 0;

        var t1 = Task.Run(async () =>
        {
            Interlocked.Increment(ref reached);
            await barrier.SignalAndWaitAsync().ConfigureAwait(false);
            return Volatile.Read(ref reached);
        });

        await Task.Delay(100).ConfigureAwait(false);
        Assert.That(Volatile.Read(ref reached), Is.EqualTo(1));

        Interlocked.Increment(ref reached);
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);

        var result = await t1.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(2));
        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        Assert.That(barrier.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task MultiplePhases()
    {
        var barrier = new AsyncBarrier(2);

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(2));
    }

    [Test]
    public async Task AddParticipantIncreasesRemaining()
    {
        var barrier = new AsyncBarrier(2);

        var phase = barrier.AddParticipant();
        Assert.That(phase, Is.EqualTo(0));
        Assert.That(barrier.RemainingParticipants, Is.EqualTo(3));

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
    }

    [Test]
    public void AddParticipantsWithInvalidCountThrows()
    {
        var barrier = new AsyncBarrier(2);
        Assert.Throws<ArgumentOutOfRangeException>(() => barrier.AddParticipants(0));
    }

    [Test]
    public async Task RemoveParticipantDecreasesRemaining()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, pool: customPool);

        barrier.RemoveParticipant();
        Assert.That(barrier.RemainingParticipants, Is.EqualTo(2));

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        Assert.That(barrier.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task RemoveParticipantReleasesWaitersWhenZeroRemaining()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);

        var waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        barrier.RemoveParticipant();
        await waiter.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        Assert.That(barrier.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public void RemoveParticipantsWithInvalidCountThrows()
    {
        var barrier = new AsyncBarrier(2);
        Assert.Throws<ArgumentOutOfRangeException>(() => barrier.RemoveParticipants(0));
    }

    [Test]
    public void RemoveMoreParticipantsThanRemainingThrows()
    {
        var barrier = new AsyncBarrier(2);
        Assert.Throws<InvalidOperationException>(() => barrier.RemoveParticipants(3));
    }

    [Test]
    public async Task CancellationBeforeWaitThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await barrier.SignalAndWaitAsync(cts.Token).ConfigureAwait(false));

        Assert.That(barrier.RemainingParticipants, Is.EqualTo(2));

        Assert.That(barrier.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);
        using var cts = new CancellationTokenSource();

        var waiter = barrier.SignalAndWaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await waiter.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(barrier.RemainingParticipants, Is.EqualTo(2));

        Assert.That(barrier.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var barrier = new AsyncBarrier(2);
        Assert.That(barrier.RunContinuationAsynchronously, Is.True);

        barrier = new AsyncBarrier(2, runContinuationAsynchronously: false);
        Assert.That(barrier.RunContinuationAsynchronously, Is.False);

        barrier.RunContinuationAsynchronously = true;
        Assert.That(barrier.RunContinuationAsynchronously, Is.True);
    }
}
