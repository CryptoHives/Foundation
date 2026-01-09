// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CS4014 // Because this call is not awaited

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
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(5));
        Assert.That(barrier.CurrentPhase, Is.EqualTo(0));
    }

    [Test]
    public async Task SingleParticipantCompletesImmediately()
    {
        var barrier = new AsyncBarrier(1);

        ValueTask waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);
        await waiter.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));
    }

    [Test]
    public async Task TwoParticipantsSynchronize()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);
        int reached = 0;

        Task<int> t1 = Task.Run(async () => {
            Interlocked.Increment(ref reached);
            await barrier.SignalAndWaitAsync().ConfigureAwait(false);
            return Volatile.Read(ref reached);
        });

        await Task.Delay(100).ConfigureAwait(false);
        Assert.That(Volatile.Read(ref reached), Is.EqualTo(1));

        Interlocked.Increment(ref reached);
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);

        int result = await t1.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(2));
        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

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
    public async Task AddParticipantIncreasesRemainingAndCount()
    {
        var barrier = new AsyncBarrier(2);

        long phase = barrier.AddParticipant();
        Assert.That(phase, Is.EqualTo(0));
        Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(3));

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
        Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(3));
    }

    [Test]
    public void AddParticipantsWithInvalidCountThrows()
    {
        var barrier = new AsyncBarrier(2);
        Assert.Throws<ArgumentOutOfRangeException>(() => barrier.AddParticipants(0));
    }

    [Test]
    public async Task RemoveParticipantDecreasesRemainingAndCount()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, pool: customPool);

        barrier.RemoveParticipant();
        Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task RemoveParticipantReleasesWaitersWhenZeroRemaining()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);

        ValueTask waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        barrier.RemoveParticipant();
        await waiter.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
        Assert.That(barrier.ParticipantCount, Is.EqualTo(1));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public void RemoveParticipantsWithInvalidCountThrows()
    {
        var barrier = new AsyncBarrier(2);
        Assert.Throws<ArgumentOutOfRangeException>(() => barrier.RemoveParticipants(0));
    }

    [Test]
    public void RemoveMoreParticipantsThanTotalThrows()
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

        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: customPool);
        using var cts = new CancellationTokenSource();

        ValueTask waiter = barrier.SignalAndWaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await waiter.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));

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

    [Test]
    public void AddAndRemoveParticipantsSequence()
    {
        var barrier = new AsyncBarrier(3);

        // Add 2 more participants
        barrier.AddParticipants(2);
        Assert.That(barrier.ParticipantCount, Is.EqualTo(5));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(5));

        // Remove 1 participant
        barrier.RemoveParticipant();
        Assert.That(barrier.ParticipantCount, Is.EqualTo(4));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(4));
    }

    [Test]
    public async Task MoreSignalsThanParticipantsThrows()
    {
        var barrier = new AsyncBarrier(1);

        // First signal completes immediately
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);
        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        // Next signal in same phase should work since barrier resets
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);
        Assert.That(barrier.CurrentPhase, Is.EqualTo(2));
    }

    [Test]
    public async Task ParallelMultiPhaseSynchronization()
    {
        const int participantCount = 4;
        const int phaseCount = 3;
        var barrier = new AsyncBarrier(participantCount);
        int[] phaseCounters = new int[phaseCount];
        var allCompleted = new TaskCompletionSource<bool>();

        var tasks = new Task[participantCount];
        for (int i = 0; i < participantCount; i++)
        {
            tasks[i] = Task.Run(async () => {
                for (int phase = 0; phase < phaseCount; phase++)
                {
                    Interlocked.Increment(ref phaseCounters[phase]);
                    await barrier.SignalAndWaitAsync().ConfigureAwait(false);

                    // After barrier, all participants should have incremented
                    Assert.That(Volatile.Read(ref phaseCounters[phase]), Is.EqualTo(participantCount));
                }
            });
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(phaseCount));
        for (int i = 0; i < phaseCount; i++)
        {
            Assert.That(phaseCounters[i], Is.EqualTo(participantCount));
        }
    }

    [Test]
    public async Task PhaseAdvancesAfterRemoveParticipantReleasesWaiters()
    {
        var barrier = new AsyncBarrier(3);

        // Two participants signal
        ValueTask waiter1 = barrier.SignalAndWaitAsync();
        ValueTask waiter2 = barrier.SignalAndWaitAsync();

        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));
        Assert.That(barrier.CurrentPhase, Is.EqualTo(0));

        // Remove the last remaining participant - should release waiters
        barrier.RemoveParticipant();

        await waiter1.ConfigureAwait(false);
        await waiter2.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
        Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
    }

    [Test]
    public async Task AddParticipantAfterSomeHaveSignaled()
    {
        var barrier = new AsyncBarrier(2);

        // One participant signals
        ValueTask waiter = barrier.SignalAndWaitAsync();
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));

        // Add another participant - now need 2 more to release
        barrier.AddParticipant();
        Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));

        // Signal twice more to release all
        ValueTask waiter2 = barrier.SignalAndWaitAsync();
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);

        await waiter.ConfigureAwait(false);
        await waiter2.ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
    }

    [Test]
    public async Task RemoveParticipantWhenAllHaveSignaledButNotLastThrows()
    {
        var barrier = new AsyncBarrier(3);

        // Two participants signal, one remaining
        Task participant1 = barrier.SignalAndWaitAsync().AsTask();
        Task participant2 = barrier.SignalAndWaitAsync().AsTask();

        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));

        // Try to remove 2 participants when only 1 remaining
        Assert.Throws<InvalidOperationException>(() => barrier.RemoveParticipants(2));
    }

    [Test]
    public async Task CurrentPhaseReturnsCorrectValueAcrossPhases()
    {
        var barrier = new AsyncBarrier(2);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(0));

        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(2));

        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        Assert.That(barrier.CurrentPhase, Is.EqualTo(3));
    }

    [Test]
    public async Task AddParticipantReturnsCurrentPhase()
    {
        var barrier = new AsyncBarrier(1);

        long phase0 = barrier.AddParticipant();
        Assert.That(phase0, Is.EqualTo(0));

        // Complete phase 0
        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        long phase1 = barrier.AddParticipant();
        Assert.That(phase1, Is.EqualTo(1));
    }

    [Test]
    public async Task PostPhaseActionIsCalledOnPhaseCompletion()
    {
        int phaseCompletions = 0;
        var barrier = new AsyncBarrier(2, b => {
            Interlocked.Increment(ref phaseCompletions);
        });

        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        Assert.That(phaseCompletions, Is.EqualTo(1));

        await Task.WhenAll(
            barrier.SignalAndWaitAsync().AsTask(),
            barrier.SignalAndWaitAsync().AsTask()
        ).ConfigureAwait(false);

        Assert.That(phaseCompletions, Is.EqualTo(2));
    }

    [Test]
    public async Task PostPhaseActionReceivesCorrectPhaseNumber()
    {
        var observedPhases = new System.Collections.Generic.List<long>();
        var barrier = new AsyncBarrier(1, b => {
            // Note: CurrentPhase is incremented AFTER post-phase action
            observedPhases.Add(b.CurrentPhase);
        });

        await barrier.SignalAndWaitAsync().ConfigureAwait(false);
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);

        // Post-phase action is called before phase increment,
        // so it sees phases 0, 1, 2 (the current phase before increment)
        Assert.That(observedPhases, Is.EqualTo(new long[] { 0, 1, 2 }));
    }

    [Test]
    public async Task PostPhaseActionExceptionThrowsBarrierPostPhaseException()
    {
        var barrier = new AsyncBarrier(1, b => {
            throw new InvalidOperationException("Post-phase error");
        });

        BarrierPostPhaseException? ex = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await barrier.SignalAndWaitAsync().ConfigureAwait(false));

        Assert.That(ex!.InnerException, Is.TypeOf<InvalidOperationException>());
        Assert.That(ex.InnerException!.Message, Is.EqualTo("Post-phase error"));
    }

    [Test]
    public async Task PostPhaseActionExceptionPropagatedToAllWaiters()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, b => {
            if (b.CurrentPhase == 0)
            {
                throw new InvalidOperationException("Phase 0 error");
            }
        }, pool: customPool);

        ValueTask waiter1 = barrier.SignalAndWaitAsync();
        ValueTask waiter2 = barrier.SignalAndWaitAsync();

        // Last participant triggers the post-phase action
        BarrierPostPhaseException? ex3 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await barrier.SignalAndWaitAsync().ConfigureAwait(false));

#pragma warning disable CHT001 // ValueTask awaited multiple times
        // Previous waiters should also receive the exception
        BarrierPostPhaseException? ex1 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter1.ConfigureAwait(false));
        BarrierPostPhaseException? ex2 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter2.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(ex1!.InnerException!.Message, Is.EqualTo("Phase 0 error"));
        Assert.That(ex2!.InnerException!.Message, Is.EqualTo("Phase 0 error"));
        Assert.That(ex3!.InnerException!.Message, Is.EqualTo("Phase 0 error"));

        // Phase should still advance after exception
        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task PostPhaseActionExceptionDoesNotPreventNextPhase()
    {
        var barrier = new AsyncBarrier(1, b => {
            if (b.CurrentPhase == 0)
            {
                throw new InvalidOperationException("Phase 0 error");
            }
        });

        // Phase 0 throws
        Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await barrier.SignalAndWaitAsync().ConfigureAwait(false));

        Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

        // Phase 1 should succeed
        await barrier.SignalAndWaitAsync().ConfigureAwait(false);
        Assert.That(barrier.CurrentPhase, Is.EqualTo(2));
    }

    [Test]
    public async Task PostPhaseActionExceptionOnRemoveParticipantsThrowsBarrierPostPhaseException()
    {
        var barrier = new AsyncBarrier(2, b => {
            throw new InvalidOperationException("Remove participant error");
        });

        // One participant signals
        ValueTask valueTask = barrier.SignalAndWaitAsync();

        // Remove the last remaining participant - triggers post-phase action
        BarrierPostPhaseException? ex = Assert.Throws<BarrierPostPhaseException>(barrier.RemoveParticipant);

        Assert.That(ex!.InnerException, Is.TypeOf<InvalidOperationException>());
        Assert.That(ex.InnerException!.Message, Is.EqualTo("Remove participant error"));
    }

    [Test]
    public async Task PostPhaseActionExceptionOnRemoveParticipantsPropagatedToWaiters()
    {
        var customPool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, b => {
            throw new InvalidOperationException("Remove error");
        }, pool: customPool);

        // Two participants signal
        ValueTask waiter1 = barrier.SignalAndWaitAsync();
        ValueTask waiter2 = barrier.SignalAndWaitAsync();

        // Remove the last remaining participant - triggers post-phase action
        Assert.Throws<BarrierPostPhaseException>(barrier.RemoveParticipant);

#pragma warning disable CHT001 // ValueTask awaited multiple times
        // Waiters should receive the exception
        BarrierPostPhaseException? ex1 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter1.ConfigureAwait(false));
        BarrierPostPhaseException? ex2 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter2.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(ex1!.InnerException!.Message, Is.EqualTo("Remove error"));
        Assert.That(ex2!.InnerException!.Message, Is.EqualTo("Remove error"));

        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public void ConstructorWithPostPhaseActionAcceptsNull()
    {
        var barrier = new AsyncBarrier(2, postPhaseAction: null);
        Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
    }

    [Test]
    public async Task PostPhaseActionWithMultiplePhases()
    {
        int[] phaseCounts = new int[3];
        var barrier = new AsyncBarrier(2, b => {
            if (b.CurrentPhase < 3)
            {
                phaseCounts[b.CurrentPhase]++;
            }
        });

        for (int phase = 0; phase < 3; phase++)
        {
            await Task.WhenAll(
                barrier.SignalAndWaitAsync().AsTask(),
                barrier.SignalAndWaitAsync().AsTask()
            ).ConfigureAwait(false);
        }

        Assert.That(phaseCounts, Is.EqualTo(new[] { 1, 1, 1 }));
    }
}
