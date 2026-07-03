// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

/// <summary>
/// Regression stress tests for the race between token cancellation and waiter registration.
/// </summary>
/// <remarks>
/// <para>
/// The waiter setup used to register the cancellation callback while holding the internal
/// spin lock. A token cancelled concurrently with a contended acquisition could invoke the
/// callback synchronously on the registering thread, which then re-entered the non-reentrant
/// spin lock and spun forever, or the cancellation was lost because the waiter was not yet
/// enqueued when the callback ran.
/// </para>
/// <para>
/// Each test keeps the primitive permanently contended so the only valid outcome of an
/// acquisition is cancellation, and sweeps the cancellation timing across the acquisition
/// window. A regression shows up as an iteration that neither completes nor cancels.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CancellationRegistrationStressTests
{
    private const int Iterations = 1000;
    private static readonly TimeSpan IterationTimeout = TimeSpan.FromSeconds(30);

    [Test]
    public async Task AsyncLockCancelDuringContendedLockNeverHangs()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        AsyncLock.Releaser held = await mutex.LockAsync().ConfigureAwait(false);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                using (await mutex.LockAsync(ct).ConfigureAwait(false))
                {
                    Assert.Fail("The lock is held; acquisition must not succeed.");
                }
            }).ConfigureAwait(false);
        }

        held.Dispose();

        // liveness: the lock must still be acquirable after the stress
        using (await mutex.LockAsync().ConfigureAwait(false)) { }
        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task AsyncSemaphoreCancelDuringContendedWaitNeverHangs()
    {
        using var pool = new TestObjectPool<bool>();
        var semaphore = new AsyncSemaphore(initialCount: 0, pool: pool);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                await semaphore.WaitAsync(ct).ConfigureAwait(false);
                Assert.Fail("The semaphore has no permits; the wait must not succeed.");
            }).ConfigureAwait(false);
        }

        // liveness: a released permit must still be acquirable after the stress
        semaphore.Release();
        await semaphore.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncAutoResetEventCancelDuringContendedWaitNeverHangs()
    {
        using var pool = new TestObjectPool<bool>();
        var autoResetEvent = new AsyncAutoResetEvent(initialState: false, pool: pool);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                await autoResetEvent.WaitAsync(ct).ConfigureAwait(false);
                Assert.Fail("The event is not signaled; the wait must not succeed.");
            }).ConfigureAwait(false);
        }

        // liveness: a signal must still release a waiter after the stress
        autoResetEvent.Set();
        await autoResetEvent.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncManualResetEventCancelDuringContendedWaitNeverHangs()
    {
        using var pool = new TestObjectPool<bool>();
        var manualResetEvent = new AsyncManualResetEvent(set: false, pool: pool);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                await manualResetEvent.WaitAsync(ct).ConfigureAwait(false);
                Assert.Fail("The event is not set; the wait must not succeed.");
            }).ConfigureAwait(false);
        }

        // liveness: setting the event must still release waiters after the stress
        manualResetEvent.Set();
        await manualResetEvent.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncCountdownEventCancelDuringContendedWaitNeverHangs()
    {
        using var pool = new TestObjectPool<bool>();
        var countdownEvent = new AsyncCountdownEvent(initialCount: 1, pool: pool);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                await countdownEvent.WaitAsync(ct).ConfigureAwait(false);
                Assert.Fail("The countdown has not reached zero; the wait must not succeed.");
            }).ConfigureAwait(false);
        }

        // liveness: the final signal must still release waiters after the stress
        countdownEvent.Signal();
        await countdownEvent.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncBarrierCancelDuringContendedSignalAndWaitNeverHangs()
    {
        using var pool = new TestObjectPool<bool>();
        var barrier = new AsyncBarrier(participantCount: 2, pool: pool);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                await barrier.SignalAndWaitAsync(ct).ConfigureAwait(false);
                Assert.Fail("Only one participant signaled; the wait must not succeed.");
            }).ConfigureAwait(false);
        }

        // every cancelled signal must have restored the participant count
        Assert.That(barrier.ParticipantsRemaining, Is.EqualTo(2));

        // liveness: a full phase must still complete after the stress
        Task first = barrier.SignalAndWaitAsync().AsTask();
        Task second = barrier.SignalAndWaitAsync().AsTask();
        await Task.WhenAll(first, second).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncReaderWriterLockCancelDuringContendedLockNeverHangs()
    {
        using var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);

        AsyncReaderWriterLock.Releaser writerHeld = await rwLock.WriterLockAsync().ConfigureAwait(false);

        for (int i = 0; i < Iterations; i++)
        {
            // alternate the acquisition kind to cover the reader, writer and
            // upgradeable reader registration paths
            Func<CancellationToken, Task> acquire = (i % 3) switch
            {
                0 => async ct => {
                    using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
                    {
                        Assert.Fail("A writer holds the lock; the reader must not succeed.");
                    }
                },
                1 => async ct => {
                    using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
                    {
                        Assert.Fail("A writer holds the lock; the writer must not succeed.");
                    }
                },
                _ => async ct => {
                    using (await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
                    {
                        Assert.Fail("A writer holds the lock; the upgradeable reader must not succeed.");
                    }
                },
            };

            await RaceCancellationAsync(i, acquire).ConfigureAwait(false);
        }

        writerHeld.Dispose();

        // liveness: the lock must still be acquirable after the stress
        (await rwLock.WriterLockAsync().ConfigureAwait(false)).Dispose();
    }

    [Test]
    public async Task AsyncReaderWriterLockCancelDuringContendedUpgradeNeverHangs()
    {
        using var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);

        // a plain reader keeps the upgrade contended for the whole stress
        AsyncReaderWriterLock.Releaser readerHeld = await rwLock.ReaderLockAsync().ConfigureAwait(false);
        AsyncReaderWriterLock.Releaser upgradeable = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);

        for (int i = 0; i < Iterations; i++)
        {
            await RaceCancellationAsync(i, async ct => {
                using (await upgradeable.UpgradeToWriterLockAsync(ct).ConfigureAwait(false))
                {
                    Assert.Fail("A reader holds the lock; the upgrade must not succeed.");
                }
            }).ConfigureAwait(false);
        }

        readerHeld.Dispose();

        // liveness: with the reader gone the upgrade must still succeed
        (await upgradeable.UpgradeToWriterLockAsync().ConfigureAwait(false)).Dispose();
        upgradeable.Dispose();
        (await rwLock.WriterLockAsync().ConfigureAwait(false)).Dispose();
    }

    /// <summary>
    /// Starts the contended acquisition on the thread pool and cancels the token while the
    /// acquisition is in flight, asserting that the operation observes the cancellation.
    /// </summary>
    /// <remarks>
    /// The spin count derived from the iteration index sweeps the cancellation timing across
    /// the acquisition window, so over many iterations the cancellation hits before, inside
    /// and after the waiter registration.
    /// </remarks>
    /// <param name="iteration">The iteration index used to vary the cancellation timing.</param>
    /// <param name="acquire">The acquisition that must observe the cancellation.</param>
    private static async Task RaceCancellationAsync(int iteration, Func<CancellationToken, Task> acquire)
    {
        using var cts = new CancellationTokenSource();

        int started = 0;
        var waitTask = Task.Run(async () => {
            Volatile.Write(ref started, 1);
            try
            {
                await acquire(cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // expected: the acquisition observed the cancellation
            }
        });

        while (Volatile.Read(ref started) == 0)
        {
            Thread.SpinWait(1);
        }

        Thread.SpinWait(iteration % 128);
        cts.Cancel();

        using var timeoutCts = new CancellationTokenSource();
        Task completed = await Task.WhenAny(waitTask, Task.Delay(IterationTimeout, timeoutCts.Token)).ConfigureAwait(false);
        if (ReferenceEquals(completed, waitTask))
        {
            timeoutCts.Cancel();
            await waitTask.ConfigureAwait(false);
        }
        else
        {
            Assert.Fail($"Iteration {iteration}: the acquisition neither completed nor observed the cancellation (lost cancellation or deadlock).");
        }
    }
}
