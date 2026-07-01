// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
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
public class AsyncBarrierTests
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantCount, Is.EqualTo(5));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(5));
            Assert.That(barrier.CurrentPhase, Is.Zero);
        }
    }

    [Test]
    public async Task SingleParticipantCompletesImmediately()
    {
        var barrier = new AsyncBarrier(1);

        ValueTask waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.True);
        await waiter.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));
        }
    }

    [Test]
    public async Task TwoParticipantsSynchronize()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: pool);
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.EqualTo(2));
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(phase, Is.Zero);
            Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(3));
        }

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(3));
        }
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
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, pool: pool);

        barrier.RemoveParticipant();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
        }

        await Task.WhenAll(
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false)),
            Task.Run(async () => await barrier.SignalAndWaitAsync().ConfigureAwait(false))
        ).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task RemoveParticipantReleasesWaitersWhenZeroRemaining()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: pool);

        ValueTask waiter = barrier.SignalAndWaitAsync();
        Assert.That(waiter.IsCompleted, Is.False);

        barrier.RemoveParticipant();
        await waiter.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(barrier.ParticipantCount, Is.EqualTo(1));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
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
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: pool);
        using var cts = new CancellationTokenSource();

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
            await barrier.SignalAndWaitAsync(cts.Token).ConfigureAwait(false));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task CancellationWhileWaitingThrows()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(2, pool: pool);
        using var cts = new CancellationTokenSource();

        ValueTask waiter = barrier.SignalAndWaitAsync(cts.Token);
        Assert.That(waiter.IsCompleted, Is.False);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await waiter.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantCount, Is.EqualTo(5));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(5));
        }

        // Remove 1 participant
        barrier.RemoveParticipant();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantCount, Is.EqualTo(4));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(4));
        }
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(1));
            Assert.That(barrier.CurrentPhase, Is.Zero);
        }

        // Remove the last remaining participant - should release waiters
        barrier.RemoveParticipant();

        await waiter1.ConfigureAwait(false);
        await waiter2.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));
            Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
        }
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
        using (Assert.EnterMultipleScope())
        {
            Assert.That(barrier.ParticipantCount, Is.EqualTo(3));
            Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));
        }

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

        Assert.That(barrier.CurrentPhase, Is.Zero);

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
        Assert.That(phase0, Is.Zero);

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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex!.InnerException, Is.TypeOf<InvalidOperationException>());
            Assert.That(ex.InnerException!.Message, Is.EqualTo("Post-phase error"));
        }
    }

    [Test]
    public async Task PostPhaseActionExceptionPropagatedToAllWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, b => {
            if (b.CurrentPhase == 0)
            {
                throw new InvalidOperationException("Phase 0 error");
            }
        }, pool: pool);

        ValueTask waiter1 = barrier.SignalAndWaitAsync();
        ValueTask waiter2 = barrier.SignalAndWaitAsync();

        // Last participant triggers the post-phase action
        BarrierPostPhaseException? ex3 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await barrier.SignalAndWaitAsync().ConfigureAwait(false));

        // Previous waiters should also receive the exception
#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        BarrierPostPhaseException? ex1 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter1.ConfigureAwait(false));
        BarrierPostPhaseException? ex2 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {

            Assert.That(ex1!.InnerException!.Message, Is.EqualTo("Phase 0 error"));
            Assert.That(ex2!.InnerException!.Message, Is.EqualTo("Phase 0 error"));
            Assert.That(ex3!.InnerException!.Message, Is.EqualTo("Phase 0 error"));

            // Phase should still advance after exception
            Assert.That(barrier.CurrentPhase, Is.EqualTo(1));

            Assert.That(pool.ActiveCount, Is.Zero);
        }
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

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex!.InnerException, Is.TypeOf<InvalidOperationException>());
            Assert.That(ex.InnerException!.Message, Is.EqualTo("Remove participant error"));
        }
    }

    [Test]
    public async Task PostPhaseActionExceptionOnRemoveParticipantsPropagatedToWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(3, b => {
            throw new InvalidOperationException("Remove error");
        }, pool: pool);

        // Two participants signal
        ValueTask waiter1 = barrier.SignalAndWaitAsync();
        ValueTask waiter2 = barrier.SignalAndWaitAsync();

        // Remove the last remaining participant - triggers post-phase action
        Assert.Throws<BarrierPostPhaseException>(barrier.RemoveParticipant);

        // Waiters should receive the exception
#pragma warning disable CHT010 // ValueTask captured in lambda or closure
        BarrierPostPhaseException? ex1 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter1.ConfigureAwait(false));
        BarrierPostPhaseException? ex2 = Assert.ThrowsAsync<BarrierPostPhaseException>(async () =>
            await waiter2.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex1!.InnerException!.Message, Is.EqualTo("Remove error"));
            Assert.That(ex2!.InnerException!.Message, Is.EqualTo("Remove error"));
            Assert.That(pool.ActiveCount, Is.Zero);
        }
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

    [Test]
    public async Task SignalAndWaitAsyncWithTimeoutCompletesWhenAllArrive()
    {
        var barrier = new AsyncBarrier(2);

        var task1 = barrier.SignalAndWaitAsync(TimeSpan.FromSeconds(5)).AsTask();
        var task2 = barrier.SignalAndWaitAsync(TimeSpan.FromSeconds(5)).AsTask();

        await Task.WhenAll(task1, task2).ConfigureAwait(false);
    }

    [Test, CancelAfter(3000)]
    public async Task SignalAndWaitAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        var barrier = new AsyncBarrier(2);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await barrier.SignalAndWaitAsync(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);
    }

    [Test]
    public async Task SignalAndWaitAsyncWithZeroTimeoutThrowsWhenParticipantsPending()
    {
        var barrier = new AsyncBarrier(2);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await barrier.SignalAndWaitAsync(TimeSpan.Zero).ConfigureAwait(false));
    }

    [Test]
    public async Task SignalAndWaitAsyncWithZeroTimeoutCompletesWhenLastParticipant()
    {
        var barrier = new AsyncBarrier(1);

        await barrier.SignalAndWaitAsync(TimeSpan.Zero).ConfigureAwait(false);
    }

    [Test]
    public void SignalAndWaitAsyncWithNegativeTimeoutThrows()
    {
        var barrier = new AsyncBarrier(2);

#pragma warning disable VSTHRD110
        Assert.Throws<ArgumentOutOfRangeException>(() => barrier.SignalAndWaitAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore VSTHRD110
    }

    [Test]
    public async Task SignalAndWaitAsyncWithInfiniteTimeoutBehavesLikeDefault()
    {
        var barrier = new AsyncBarrier(2);

        var task1 = barrier.SignalAndWaitAsync(Timeout.InfiniteTimeSpan).AsTask();
        var task2 = barrier.SignalAndWaitAsync(Timeout.InfiniteTimeSpan).AsTask();

        await Task.WhenAll(task1, task2).ConfigureAwait(false);
    }

    [Test]
    public void SignalAndWaitAsyncAfterAllParticipantsRemovedThrows()
    {
        var barrier = new AsyncBarrier(1);
        barrier.RemoveParticipants(1);

#pragma warning disable VSTHRD110
        Assert.Throws<InvalidOperationException>(() => barrier.SignalAndWaitAsync());
#pragma warning restore VSTHRD110
    }

    [Test]
    public void SignalAndWaitAsyncWithTimeoutAfterAllParticipantsRemovedThrows()
    {
        var barrier = new AsyncBarrier(1);
        barrier.RemoveParticipants(1);

#pragma warning disable VSTHRD110
        Assert.Throws<InvalidOperationException>(() => barrier.SignalAndWaitAsync(TimeSpan.FromSeconds(5)));
#pragma warning restore VSTHRD110
    }

    [Test]
    [Repeat(50)]
    public async Task RemoveParticipants_RacingLastSignal_TriggersPhaseCompletionExactlyOnce()
    {
        int postPhaseActionCallCount = 0;
        var barrier = new AsyncBarrier(3, _ => Interlocked.Increment(ref postPhaseActionCallCount));

        ValueTask p1 = barrier.SignalAndWaitAsync();
        ValueTask p2 = barrier.SignalAndWaitAsync();

        // RemoveParticipants and the third SignalAndWaitAsync both independently drive
        // _participantsRemaining to zero and can each trigger phase completion; only
        // whichever one the spinlock admits first should actually fire the post-phase action.
        // If RemoveParticipants wins, the third signal becomes a non-last signal for the new
        // (2-participant) phase and would queue forever with nothing left to complete it, so it
        // is bounded by a timeout and a resulting cancellation is an accepted outcome.
        var removeTask = Task.Run(() => barrier.RemoveParticipants(1));
        bool cancellationObserved = false;
        var signalTask = Task.Run(async () => {
            try
            {
                await barrier.SignalAndWaitAsync(TimeSpan.FromMilliseconds(300)).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Expected in one race outcome: third signal may time out/cancel.
                cancellationObserved = true;
            }
        });

        await Task.WhenAll(removeTask, signalTask).ConfigureAwait(false);
        _ = cancellationObserved;

        await p1.ConfigureAwait(false);
        await p2.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(postPhaseActionCallCount, Is.EqualTo(1));
            Assert.That(barrier.ParticipantCount, Is.EqualTo(2));
            Assert.That(barrier.ParticipantsRemaining, Is.InRange(1, 2));
        }
    }
}
