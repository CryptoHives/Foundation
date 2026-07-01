// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

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
public class AsyncLockTests
{
    [Test]
    public void AsyncLockUnlockedSynchronouslyPermitsLock()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        Task<AsyncLock.Releaser> lockTask = mutex.LockAsync().AsTask();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(lockTask.IsCompleted, Is.True);
            Assert.That(lockTask.IsFaulted, Is.False);
            Assert.That(lockTask.IsCanceled, Is.False);
        }
    }

    [Test]
    public async Task AsyncLockLockedPreventsLockUntilUnlocked()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        TaskCompletionSource<object?> task1HasLock = CreateAsyncTaskSource<object?>();
        TaskCompletionSource<object?> task1Continue = CreateAsyncTaskSource<object?>();

        var task1 = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(null);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () => {
            await mutex.LockAsync().ConfigureAwait(false);
        });

        Assert.That(task2.IsCompleted, Is.False);
        task1Continue.SetResult(null);
        await task2.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockOnlyPermitsOneLockerAtATime()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        var task1HasLock = new TaskCompletionSource<bool>();
        var task1Continue = new TaskCompletionSource<bool>();
        var task2Ready = new TaskCompletionSource<bool>();
        var task2HasLock = new TaskCompletionSource<bool>();
        var task2Continue = new TaskCompletionSource<bool>();

        var task1 = Task.Run(async () => {
            using (await al.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(true);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () => {
            ValueTask<AsyncLock.Releaser> key = al.LockAsync();
            task2Ready.SetResult(true);
            using (await key.ConfigureAwait(false))
            {
                task2HasLock.SetResult(true);
                await task2Continue.Task.ConfigureAwait(false);
            }
        });
        await task2Ready.Task.ConfigureAwait(false);

        var task3 = Task.Run(async () => {
            await al.LockAsync().ConfigureAwait(false);
        });

        task1Continue.SetResult(true);
        await task2HasLock.Task.ConfigureAwait(false);

        Assert.That(task3.IsCompleted, Is.False);
        task2Continue.SetResult(false);

        await task1.ConfigureAwait(false);
        await task2.ConfigureAwait(false);
        await task3.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(al.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public void AsyncLockPreCancelledUnlockedSynchronouslyTakesLock()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        var token = new CancellationToken(true);

        Task<AsyncLock.Releaser> task = mutex.LockAsync(token).AsTask();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(task.IsCanceled, Is.False);
            Assert.That(task.IsFaulted, Is.False);
        }
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task AsyncLockPreCancelledLockedSynchronouslyCancels(bool useAsTask)
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        ValueTask<AsyncLock.Releaser> lockTask = mutex.LockAsync();
        var token = new CancellationToken(true);

        if (useAsTask)
        {
            Task<AsyncLock.Releaser> task = mutex.LockAsync(token).AsTask();
            using (Assert.EnterMultipleScope())
            {
                Assert.That(task.IsCompleted, Is.True);
                Assert.That(task.IsCanceled, Is.True);
                Assert.That(task.IsFaulted, Is.False);
            }
        }
        else
        {
            ValueTask<AsyncLock.Releaser> valueTask = mutex.LockAsync(token);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(valueTask.IsCompleted, Is.True);
                Assert.That(valueTask.IsCanceled, Is.True);
                Assert.That(valueTask.IsFaulted, Is.False);
            }
        }

        await lockTask.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockCancelledLockLeavesLockUnlocked()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();
        TaskCompletionSource<object?> taskReady = CreateAsyncTaskSource<object?>();

        AsyncLock.Releaser unlock = await mutex.LockAsync().ConfigureAwait(false);
        var task = Task.Run(async () => {
            ValueTask<AsyncLock.Releaser> lockTask = mutex.LockAsync(cts.Token);
            taskReady.SetResult(null);
            await lockTask.ConfigureAwait(false);
        });
        await taskReady.Task.ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await task.ConfigureAwait(false));
        Assert.That(task.IsCanceled, Is.True);
        await unlock.DisposeAsync().ConfigureAwait(false);

        ValueTask<AsyncLock.Releaser> finalLockTask = mutex.LockAsync();
        await finalLockTask.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockCanceledTooLateStillTakesLock()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> cancelableLockTask;
        using (await mutex.LockAsync().Preserve().ConfigureAwait(false))
        {
            cancelableLockTask = mutex.LockAsync(cts.Token);
        }

        AsyncLock.Releaser key = await cancelableLockTask.ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Task<AsyncLock.Releaser> nextLocker = mutex.LockAsync().AsTask();
        Assert.That(nextLocker.IsCompleted, Is.False);

        await key.DisposeAsync().ConfigureAwait(false);
        await nextLocker.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockSupportsMultipleAsynchronousLocks()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();

        await Task.Run(async () => {
            var asyncLock = new AsyncLock(pool: pool);
            using var cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            var task1 = Task.Run(
                async () => {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        using (await asyncLock.LockAsync().ConfigureAwait(false))
                        {
                            await Task.Delay(10).ConfigureAwait(false);
                        }
                    }
                });

            var task2 = Task.Run(
                async () => {
                    using (await asyncLock.LockAsync().ConfigureAwait(false))
                    {
                        await Task.Delay(1000).ConfigureAwait(false);
                    }
                });

            var task3 = Task.Run(
                () => {
                    using (asyncLock.LockAsync().AsTask().GetAwaiter().GetResult())
                    {
                        Thread.Sleep(100);
                    }
                });

            await task2.ConfigureAwait(false);
            await task3.ConfigureAwait(false);
            await AsyncAssert.CancelAsync(cancellationTokenSource).ConfigureAwait(false);
            await task1.ConfigureAwait(false);
        }).ConfigureAwait(false);
    }

    [Test]
    public async Task LockUnlockSingleAwaiter()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync();
        Assert.That(vt.IsCompleted);

        using (await vt.ConfigureAwait(false))
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(al.IsTaken);
                Assert.That(vt.IsCompleted);
            }
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(al.IsTaken, Is.False);
            Assert.That(al.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentially()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        Task t1, t2;
        using (await al.LockAsync().ConfigureAwait(false))
        {
            t1 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });
            t2 = Task.Run(async () => { using (await al.LockAsync().ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });

            await Task.Delay(10).ConfigureAwait(false);
            Assert.That(al.IsTaken);

            // release outer lock and wait for tasks to complete
        }

        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueuing()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

            // Cancel before queueing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            Assert.ThrowsAsync<TaskCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();

        // Take the lock so subsequent waiters are queued
        using (await al.LockAsync().ConfigureAwait(false))
        {
            ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

            // Cancel after queuing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT010 // ValueTask captured in lambda or closure
            Assert.ThrowsAsync<OperationCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT010 // ValueTask captured in lambda or closure
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelAfterLock()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test, CancelAfter(1000)]
    public async Task WaitAsyncWithCancellationTokenCancelAfterTimeout()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource(250);

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
            Assert.ThrowsAsync<OperationCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Theory]
    public async Task WaitAsyncGetAwaiterWithCancellationTokenCancelAfterLock(bool useAsTask)
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: pool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        if (useAsTask)
        {
            using (await vt.AsTask().ConfigureAwait(false))
            {
                Assert.That(al.IsTaken);
            }
        }
        else
        {
            using (await vt.Preserve().ConfigureAwait(false))
            {
                Assert.That(al.IsTaken);
            }
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
    }

    [Test]
    public void TryReset_SucceedsWhenNotInUse()
    {
        var ev = new AsyncLock();

        Assert.That(ev.IsTaken, Is.False);

        bool reset = ev.TryReset();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(reset, Is.True);
            Assert.That(ev.IsTaken, Is.False);
        }
    }

    [Test]
    public async Task LockAsyncWithTimeoutCompletesWhenLockAvailableBeforeTimeout()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using (await mutex.LockAsync().ConfigureAwait(false)) { }

        using (await mutex.LockAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false))
        {
            Assert.That(mutex.IsTaken);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mutex.InternalWaiterInUse, Is.False);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test, CancelAfter(3000)]
    public async Task LockAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using var outerReleaser = await mutex.LockAsync().ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            await mutex.LockAsync(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task LockAsyncWithZeroTimeoutCompletesImmediatelyWhenUnlocked()
    {
        var mutex = new AsyncLock();

        using (await mutex.LockAsync(TimeSpan.Zero).ConfigureAwait(false))
        {
            Assert.That(mutex.IsTaken);
        }

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task LockAsyncWithZeroTimeoutThrowsWhenLocked()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using var outerReleaser = await mutex.LockAsync().ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () =>
            _ = await mutex.LockAsync(TimeSpan.Zero).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    [Test]
    public void LockAsyncWithNegativeTimeoutThrows()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

#pragma warning disable VSTHRD110
#pragma warning disable CA2012
        Assert.Throws<ArgumentOutOfRangeException>(() => mutex.LockAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore CA2012
#pragma warning restore VSTHRD110

        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    [Test]
    public async Task LockAsyncWithInfiniteTimeoutBehavesLikeLockAsync()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        using (await mutex.LockAsync(Timeout.InfiniteTimeSpan).ConfigureAwait(false))
        {
            Assert.That(mutex.IsTaken);
        }

        Assert.That(mutex.InternalWaiterInUse, Is.False);
    }

    private static TaskCompletionSource<TResult> CreateAsyncTaskSource<TResult>()
    {
        return new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
    }

    [Test]
    public async Task ReleaserFromSameLockAreEqual()
    {
        var mutex = new AsyncLock();

        AsyncLock.Releaser first;
        using (first = await mutex.LockAsync().ConfigureAwait(false)) { }
        AsyncLock.Releaser second;
        using (second = await mutex.LockAsync().ConfigureAwait(false)) { }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.Equals(second), Is.True);
            Assert.That(first.Equals((object)second), Is.True);
            Assert.That(first == second, Is.True);
            Assert.That(first != second, Is.False);
            Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
        }
    }

    [Test]
    public async Task ReleaserFromDifferentLocksAreNotEqual()
    {
        var mutexA = new AsyncLock();
        var mutexB = new AsyncLock();

        AsyncLock.Releaser releaserA;
        using (releaserA = await mutexA.LockAsync().ConfigureAwait(false)) { }
        AsyncLock.Releaser releaserB;
        using (releaserB = await mutexB.LockAsync().ConfigureAwait(false)) { }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(releaserA.Equals(releaserB), Is.False);
            Assert.That(releaserA.Equals((object)releaserB), Is.False);
            Assert.That(releaserA == releaserB, Is.False);
            Assert.That(releaserA != releaserB, Is.True);
            Assert.That(releaserA.Equals("not a releaser"), Is.False);
        }
    }

    [Test]
    public void DefaultReleasersAreEqual()
    {
        var first = default(AsyncLock.Releaser);
        var second = default(AsyncLock.Releaser);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.Equals(second), Is.True);
            Assert.That(first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
            Assert.That(first.GetHashCode(), Is.Zero);
        }
    }

    [Test]
    public async Task TryReset_FailsWhileLockHeld()
    {
        var mutex = new AsyncLock();

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            Assert.That(mutex.TryReset(), Is.False);
        }
    }

    [Test]
    public async Task TryReset_FailsWhileWaitersQueued()
    {
        using var pool = new TestObjectPool<AsyncLock.Releaser>();
        var mutex = new AsyncLock(pool: pool);

        Task waiterTask;
        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            waiterTask = Task.Run(async () => {
                using (await mutex.LockAsync().ConfigureAwait(false)) { }
            });

            // Give the waiter time to enqueue before asserting the reset is declined.
            while (mutex.InternalWaiterInUse == false)
            {
                await Task.Delay(1).ConfigureAwait(false);
            }

            Assert.That(mutex.TryReset(), Is.False);
            // Outer lock releases here, unblocking the queued waiter.
        }

        await waiterTask.ConfigureAwait(false);
    }
}
