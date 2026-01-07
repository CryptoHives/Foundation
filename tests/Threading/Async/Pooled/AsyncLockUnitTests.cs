// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CHT001 // ValueTask awaited multiple times - intentionally testing cancellation behavior

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncLockUnitTests
{
    [Test]
    public void AsyncLockUnlockedSynchronouslyPermitsLock()
    {
        var mutex = new AsyncLock(defaultEventQueueSize: 8);

        Task<AsyncLock.Releaser> lockTask = mutex.LockAsync().AsTask();

        Assert.That(lockTask.IsCompleted, Is.True);
        Assert.That(lockTask.IsFaulted, Is.False);
        Assert.That(lockTask.IsCanceled, Is.False);
    }

    [Test]
    public async Task AsyncLockLockedPreventsLockUntilUnlocked()
    {
        var mutex = new AsyncLock(defaultEventQueueSize: 8);
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
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

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

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public void AsyncLockPreCancelledUnlockedSynchronouslyTakesLock()
    {
        var mutex = new AsyncLock();
        var token = new CancellationToken(true);

        Task<AsyncLock.Releaser> task = mutex.LockAsync(token).AsTask();

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.False);
        Assert.That(task.IsFaulted, Is.False);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task AsyncLockPreCancelledLockedSynchronouslyCancels(bool useAsTask)
    {
        var mutex = new AsyncLock();
        ValueTask<AsyncLock.Releaser> lockTask = mutex.LockAsync();
        var token = new CancellationToken(true);

        if (useAsTask)
        {
            Task<AsyncLock.Releaser> task = mutex.LockAsync(token).AsTask();
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(task.IsCanceled, Is.True);
            Assert.That(task.IsFaulted, Is.False);
        }
        else
        {
            ValueTask<AsyncLock.Releaser> valueTask = mutex.LockAsync(token);
            Assert.That(valueTask.IsCompleted, Is.True);
            Assert.That(valueTask.IsCanceled, Is.True);
            Assert.That(valueTask.IsFaulted, Is.False);
        }

        await lockTask.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockCancelledLockLeavesLockUnlocked()
    {
        var mutex = new AsyncLock();
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

        Assert.ThrowsAsync<TaskCanceledException>(async () => await task.ConfigureAwait(false));
        Assert.That(task.IsCanceled, Is.True);
        await unlock.DisposeAsync().ConfigureAwait(false);

        ValueTask<AsyncLock.Releaser> finalLockTask = mutex.LockAsync();
        await finalLockTask.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockCanceledTooLateStillTakesLock()
    {
        var mutex = new AsyncLock();
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
        await Task.Run(async () => {
            var asyncLock = new AsyncLock();
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
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

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

        Assert.That(al.IsTaken, Is.False);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentially()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

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
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueuing()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

            // Cancel before queueing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            Assert.ThrowsAsync<TaskCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueued()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        // Take the lock so subsequent waiters are queued
        using (await al.LockAsync().ConfigureAwait(false))
        {
            ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

            // Cancel after queuing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelled()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelAfterLock()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task WaitAsyncWithCancellationTokenCancelAfterTimeout()
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource(250);

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
            Assert.ThrowsAsync<TaskCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    [Theory]
    public async Task WaitAsyncGetAwaiterWithCancellationTokenCancelAfterLock(bool useAsTask)
    {
        var customPool = new TestObjectPool<AsyncLock.Releaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.Releaser> vt = al.LockAsync(cts.Token);

        if (useAsTask)
        {
            using (vt.AsTask().GetAwaiter().GetResult())
            {
                Assert.That(al.IsTaken);
            }
        }
        else
        {
            using (vt.Preserve().GetAwaiter().GetResult())
            {
                Assert.That(al.IsTaken);
            }
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.Zero);
    }

    private static TaskCompletionSource<TResult> CreateAsyncTaskSource<TResult>()
    {
        return new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
