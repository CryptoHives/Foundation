// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncConditionVariableTests
{
    // -------------------------------------------------------------------------
    // Construction
    // -------------------------------------------------------------------------

    [Test]
    public void DefaultPropertyValues()
    {
        var cv = new AsyncConditionVariable();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(cv.RunContinuationAsynchronously, Is.True);
            Assert.That(cv.WaiterCount, Is.Zero);
        }
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyRoundTrips()
    {
        var cv = new AsyncConditionVariable(runContinuationAsynchronously: false);
        Assert.That(cv.RunContinuationAsynchronously, Is.False);

        cv.RunContinuationAsynchronously = true;
        Assert.That(cv.RunContinuationAsynchronously, Is.True);
    }

    // -------------------------------------------------------------------------
    // Signal / SignalAll with no waiters — signal is discarded
    // -------------------------------------------------------------------------

    [Test]
    public async Task SignalWithNoWaitersIsDiscarded()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        // Signal when nobody is waiting — must not store state
        cv.Signal();

        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                tcs.SetResult(true);       // signal that we are about to wait
                await cv.WaitAsync(mutex).ConfigureAwait(false);
            }
        });

        await tcs.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false); // give the waiter time to block

        // Waiter should still be blocked — the prior signal was lost
        Assert.That(waiter.IsCompleted, Is.False);

        // Now provide a real signal to let it finish
        cv.Signal();
        await waiter.ConfigureAwait(false);
    }

    [Test]
    public async Task SignalAllWithNoWaitersIsDiscarded()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        cv.SignalAll();

        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                tcs.SetResult(true);
                await cv.WaitAsync(mutex).ConfigureAwait(false);
            }
        });

        await tcs.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(waiter.IsCompleted, Is.False);

        cv.Signal();
        await waiter.ConfigureAwait(false);
    }

    // -------------------------------------------------------------------------
    // Basic wait and signal
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task WaiterBlocksUntilSignaled()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);
        bool signaled = false;

        var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                waitReady.SetResult(true);
                await cv.WaitAsync(mutex).ConfigureAwait(false);
                Assert.That(signaled, Is.True);
                Assert.That(mutex.IsTaken, Is.True);
            }
        });

        await waitReady.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);
        Assert.That(waiter.IsCompleted, Is.False);

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            signaled = true;
            cv.Signal();
        }

        await waiter.ConfigureAwait(false);
    }

    [Test, CancelAfter(3000)]
    public async Task LockIsHeldAfterWaitReturns()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);
        bool lockHeldAfterWait = false;

        var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                waitReady.SetResult(true);
                await cv.WaitAsync(mutex).ConfigureAwait(false);
                // Verify we hold the lock by checking that a second LockAsync call blocks
                lockHeldAfterWait = mutex.IsTaken;
            }
        });

        await waitReady.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        cv.Signal();
        await waiter.ConfigureAwait(false);

        Assert.That(lockHeldAfterWait, Is.True);
    }

    // -------------------------------------------------------------------------
    // Signal wakes exactly one waiter
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task SignalWakesExactlyOneWaiter()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);
        int wokenCount = 0;

        async Task MakeWaiter()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                await cv.WaitAsync(mutex).ConfigureAwait(false);
                Interlocked.Increment(ref wokenCount);
            }
        }

        var w1 = Task.Run(MakeWaiter);
        var w2 = Task.Run(MakeWaiter);
        var w3 = Task.Run(MakeWaiter);

        // Wait for all three to be blocked
        while (cv.WaiterCount < 3)
        {
            await Task.Delay(10).ConfigureAwait(false);
        }

        cv.Signal();
        await Task.Delay(100).ConfigureAwait(false);

        Assert.That(Volatile.Read(ref wokenCount), Is.EqualTo(1));

        // Release remaining two
        cv.Signal();
        cv.Signal();

        await Task.WhenAll(w1, w2, w3).ConfigureAwait(false);
        Assert.That(Volatile.Read(ref wokenCount), Is.EqualTo(3));
    }

    // -------------------------------------------------------------------------
    // SignalAll wakes all waiters
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task SignalAllWakesAllWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);
        int wokenCount = 0;

        async Task MakeWaiter()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                await cv.WaitAsync(mutex).ConfigureAwait(false);
                Interlocked.Increment(ref wokenCount);
            }
        }

        var tasks = Enumerable.Range(0, 5).Select(_ => Task.Run(MakeWaiter)).ToArray();

        while (cv.WaiterCount < 5)
        {
            await Task.Delay(10).ConfigureAwait(false);
        }

        cv.SignalAll();

        await Task.WhenAll(tasks).ConfigureAwait(false);
        Assert.That(Volatile.Read(ref wokenCount), Is.EqualTo(5));
    }

    // -------------------------------------------------------------------------
    // Cancellation
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task PreCancelledTokenThrowsWithoutReleasingLock()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            var cancelled = new CancellationToken(canceled: true);

            Assert.ThrowsAsync<OperationCanceledException>(
                async () => await cv.WaitAsync(mutex, cancelled).ConfigureAwait(false));

            // Lock must still be held — we never released it
            Assert.That(mutex.IsTaken, Is.True);
            Assert.That(cv.WaiterCount, Is.Zero);
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task CancellationWhileWaitingReAcquiresLock()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);
        bool lockHeldAfterCancel = false;

        using var cts = new CancellationTokenSource();

        var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                waitReady.SetResult(true);
                try
                {
                    await cv.WaitAsync(mutex, cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    lockHeldAfterCancel = mutex.IsTaken;
                    throw;
                }
            }
        });

        await waitReady.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter.ConfigureAwait(false));
        Assert.That(lockHeldAfterCancel, Is.True);
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task CancellationRemovesWaiterFromQueue()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        using var cts = new CancellationTokenSource();

        var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                waitReady.SetResult(true);
                await cv.WaitAsync(mutex, cts.Token).ConfigureAwait(false);
            }
        });

        await waitReady.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);
        Assert.That(cv.WaiterCount, Is.EqualTo(1));

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter.ConfigureAwait(false));

        Assert.That(cv.WaiterCount, Is.Zero);
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task SignalAndCancellationRaceLeavesMutexConsistent()
    {
        // If Signal() and cancellation race, the lock must still be in a consistent state.
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        for (int i = 0; i < 50; i++)
        {
            using var cts = new CancellationTokenSource();
            var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            var waiter = Task.Run(async () => {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    waitReady.SetResult(true);
                    try
                    {
                        await cv.WaitAsync(mutex, cts.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) { }
                }
            });

            await waitReady.Task.ConfigureAwait(false);

            // Race: cancel and signal simultaneously
            cts.Cancel();
            cv.Signal();

            await waiter.ConfigureAwait(false);

            // Lock must be free after each iteration
            Assert.That(mutex.IsTaken, Is.False, $"Iteration {i}: lock should be free");
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // Classic producer-consumer pattern
    // -------------------------------------------------------------------------

    [Test, CancelAfter(5000)]
    public async Task ClassicProducerConsumerPattern()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        var queue = new Queue<int>();
        const int itemCount = 20;
        var produced = new List<int>();
        var consumed = new List<int>();

        var producer = Task.Run(async () => {
            for (int i = 0; i < itemCount; i++)
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    queue.Enqueue(i);
                    produced.Add(i);
                    cv.Signal();
                }
                await Task.Delay(1).ConfigureAwait(false);
            }
        });

        var consumer = Task.Run(async () => {
            while (consumed.Count < itemCount)
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    while (queue.Count == 0)
                        await cv.WaitAsync(mutex).ConfigureAwait(false);

                    consumed.Add(queue.Dequeue());
                }
            }
        });

        await Task.WhenAll(producer, consumer).ConfigureAwait(false);

        Assert.That(consumed, Is.EqualTo(produced));
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // WaiterCount
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task WaiterCountTracksActiveWaiters()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        Assert.That(cv.WaiterCount, Is.Zero);

        var gate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        async Task MakeWaiter()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                await cv.WaitAsync(mutex).ConfigureAwait(false);
            }
        }

        var tasks = new[]
        {
            Task.Run(MakeWaiter),
            Task.Run(MakeWaiter),
            Task.Run(MakeWaiter),
        };

        while (cv.WaiterCount < 3)
        {
            await Task.Delay(10).ConfigureAwait(false);
        }

        Assert.That(cv.WaiterCount, Is.EqualTo(3));

        cv.SignalAll();
        await Task.WhenAll(tasks).ConfigureAwait(false);

        Assert.That(cv.WaiterCount, Is.Zero);
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // Stress test
    // -------------------------------------------------------------------------

    [Test, CancelAfter(10000)]
    public async Task StressMultipleProducersAndConsumers()
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(pool: pool);

        var queue = new Queue<int>();
        const int totalItems = 500;
        int producedCount = 0;
        int consumedCount = 0;

        async Task Producer()
        {
            while (true)
            {
                int item;
                lock (queue)
                {
                    item = producedCount++;
                    if (item >= totalItems) { producedCount--; return; }
                }

                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    queue.Enqueue(item);
                    cv.Signal();
                }
            }
        }

        async Task Consumer()
        {
            while (true)
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    while (queue.Count == 0)
                    {
                        if (Volatile.Read(ref consumedCount) >= totalItems) return;
                        await cv.WaitAsync(mutex).ConfigureAwait(false);
                    }

                    queue.Dequeue();
                    int done = Interlocked.Increment(ref consumedCount);
                    if (done >= totalItems)
                    {
                        cv.SignalAll(); // wake stuck consumers
                        return;
                    }
                }
            }
        }

        var producers = Enumerable.Range(0, 4).Select(_ => Task.Run(Producer)).ToArray();
        var consumers = Enumerable.Range(0, 4).Select(_ => Task.Run(Consumer)).ToArray();

        await Task.WhenAll(producers).ConfigureAwait(false);

        // Once all items are produced, wake any consumers stuck in WaitAsync
        cv.SignalAll();

        await Task.WhenAll(consumers).ConfigureAwait(false);

        Assert.That(Volatile.Read(ref consumedCount), Is.EqualTo(totalItems));
        Assert.That(mutex.IsTaken, Is.False);
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // RunContinuationAsynchronously
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    [TestCase(true)]
    [TestCase(false)]
    public async Task RunContinuationAsynchronouslyExecutesCorrectly(bool runAsync)
    {
        using var pool = new TestObjectPool<bool>();
        var mutex = new AsyncLock();
        var cv = new AsyncConditionVariable(runContinuationAsynchronously: runAsync, pool: pool);

        var waitReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                waitReady.SetResult(true);
                await cv.WaitAsync(mutex).ConfigureAwait(false);
            }
        });

        await waitReady.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        cv.Signal();
        await waiter.ConfigureAwait(false);

        Assert.That(pool.ActiveCount, Is.Zero);
    }
}
