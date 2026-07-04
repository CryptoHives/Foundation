// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

/// <summary>
/// Regression stress tests for the race between a stale timeout callback and waiter reuse.
/// </summary>
/// <remarks>
/// <para>
/// Timer disposal does not synchronize with an in-flight callback: a timeout callback that
/// fired just before the waiter completed can still execute after the waiter has been
/// recycled and re-enqueued for a new operation. Without the version guard the stale
/// callback removed the reused waiter from the queue and spuriously cancelled the new
/// operation — even one waiting without any timeout.
/// </para>
/// <para>
/// The stale window only exists when the timer fires within the sub-millisecond dispatch
/// window around the waiter's completion, so the test releases the contended primitive at a
/// sweep of offsets around the timer due time and runs several racers concurrently to
/// multiply the attempts. The test is probabilistic by nature; a regression shows up as an
/// infinite (non-timed) wait observing a <see cref="TimeoutException"/>.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StaleTimerCallbackStressTests
{
    private const int Racers = 4;
    private const int IterationsPerRacer = 64;
    private const double TimerDueMilliseconds = 15.0;

    private static readonly TimeSpan ShortTimeout = TimeSpan.FromMilliseconds(TimerDueMilliseconds);

    [Test]
    public async Task AsyncLockStaleTimerCallbackDoesNotCancelReusedWaiter()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();

        var racers = new Task[Racers];
        for (int r = 0; r < Racers; r++)
        {
#pragma warning disable CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
            racers[r] = Task.Run(() => RaceAsyncLockAsync(pool));
#pragma warning restore CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
        }

        await Task.WhenAll(racers).ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncSemaphoreStaleTimerCallbackDoesNotCancelReusedWaiter()
    {
        using var pool = new TestObjectPool<bool>();

        var racers = new Task[Racers];
        for (int r = 0; r < Racers; r++)
        {
#pragma warning disable CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
            racers[r] = Task.Run(() => RaceAsyncSemaphoreAsync(pool));
#pragma warning restore CA2025 // Do not pass 'IDisposable' instances into unawaited tasks
        }

        await Task.WhenAll(racers).ConfigureAwait(false);
    }

    private static async Task RaceAsyncLockAsync(TestObjectPool<AsyncLock.Releaser> pool)
    {
        var mutex = new AsyncLock(pool: pool);

        for (int i = 0; i < IterationsPerRacer; i++)
        {
            // contended timed wait: enqueues the waiter and arms the timer
            AsyncLock.Releaser held = await mutex.LockAsync().ConfigureAwait(false);
            var armed = Stopwatch.StartNew();
            Task<AsyncLock.Releaser> timedWait = LockWithTimeoutAsync(mutex);

            // release as close as possible to the timer due time so the completion
            // races the fired-but-not-yet-executed timer callback
            SpinUntil(armed, ReleaseOffsetMilliseconds(i));
            held.Dispose();

            AsyncLock.Releaser timedReleaser;
            try
            {
                timedReleaser = await timedWait.ConfigureAwait(false);
            }
            catch (TimeoutException)
            {
                // the timer legitimately won the race; nothing to reuse this round
                continue;
            }

            // reuse the waiter for a contended infinite wait; a stale callback landing
            // now would spuriously cancel it
            Task<AsyncLock.Releaser> infiniteWait = LockForeverAsync(mutex);
            Thread.SpinWait(2000);

            timedReleaser.Dispose();

            try
            {
                (await infiniteWait.ConfigureAwait(false)).Dispose();
            }
            catch (TimeoutException)
            {
                Assert.Fail($"Iteration {i}: a stale timer callback cancelled a reused waiter.");
            }
        }
    }

    private static async Task RaceAsyncSemaphoreAsync(TestObjectPool<bool> pool)
    {
        var semaphore = new AsyncSemaphore(initialCount: 1, pool: pool);

        for (int i = 0; i < IterationsPerRacer; i++)
        {
            // drain the permit, then start a contended timed wait with an armed timer
            await semaphore.WaitAsync().ConfigureAwait(false);
            var armed = Stopwatch.StartNew();
            Task timedWait = WaitWithTimeoutAsync(semaphore);

            // release as close as possible to the timer due time so the completion
            // races the fired-but-not-yet-executed timer callback
            SpinUntil(armed, ReleaseOffsetMilliseconds(i));
            semaphore.Release();

            try
            {
                await timedWait.ConfigureAwait(false);
            }
            catch (TimeoutException)
            {
                // the timer legitimately won the race; re-take the returned permit
                await semaphore.WaitAsync().ConfigureAwait(false);
            }

            // reuse the waiter for a contended infinite wait; a stale callback landing
            // now would spuriously cancel it
            Task infiniteWait = WaitForeverAsync(semaphore);
            Thread.SpinWait(2000);

            semaphore.Release();

            try
            {
                await infiniteWait.ConfigureAwait(false);
            }
            catch (TimeoutException)
            {
                Assert.Fail($"Iteration {i}: a stale timer callback cancelled a reused waiter.");
            }

            // return the permit acquired by the infinite wait for the next iteration
            semaphore.Release();
        }
    }

    /// <summary>
    /// Sweeps the release time from just before to just after the timer due time,
    /// so some iterations release while the timer callback is being dispatched.
    /// </summary>
    private static double ReleaseOffsetMilliseconds(int iteration)
        => TimerDueMilliseconds - 1.0 + ((iteration % 21) * 0.1);

    private static void SpinUntil(Stopwatch armed, double milliseconds)
    {
        while (armed.Elapsed.TotalMilliseconds < milliseconds)
        {
            Thread.SpinWait(20);
        }
    }

    private static async Task<AsyncLock.Releaser> LockWithTimeoutAsync(AsyncLock mutex)
        => await mutex.LockAsync(ShortTimeout).ConfigureAwait(false);

    private static async Task<AsyncLock.Releaser> LockForeverAsync(AsyncLock mutex)
        => await mutex.LockAsync().ConfigureAwait(false);

    private static async Task WaitWithTimeoutAsync(AsyncSemaphore semaphore)
        => await semaphore.WaitAsync(ShortTimeout).ConfigureAwait(false);

    private static async Task WaitForeverAsync(AsyncSemaphore semaphore)
        => await semaphore.WaitAsync().ConfigureAwait(false);
}
