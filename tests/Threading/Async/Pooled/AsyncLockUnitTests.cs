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
public class AsyncLockUnitTests
{
    [Test]
    public void AsyncLockUnlockedSynchronouslyPermitsLock()
    {
        var mutex = new AsyncLock();

        var lockTask = mutex.LockAsync().AsTask();

        Assert.That(lockTask.IsCompleted, Is.True);
        Assert.That(lockTask.IsFaulted, Is.False);
        Assert.That(lockTask.IsCanceled, Is.False);
    }

    [Test]
    public async Task AsyncLockLockedPreventsLockUntilUnlocked()
    {
        var mutex = new AsyncLock();
        var task1HasLock = CreateAsyncTaskSource<object?>();
        var task1Continue = CreateAsyncTaskSource<object?>();

        var task1 = Task.Run(async () =>
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(null);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () =>
        {
            await mutex.LockAsync().ConfigureAwait(false);
        });

        Assert.That(task2.IsCompleted, Is.False);
        task1Continue.SetResult(null);
        await task2.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockDoubleDisposeOnlyPermitsOneTask()
    {
        var mutex = new AsyncLock();
        var task1HasLock = CreateAsyncTaskSource<object?>();
        var task1Continue = CreateAsyncTaskSource<object?>();

        await Task.Run(async () =>
        {
            var key = await mutex.LockAsync().ConfigureAwait(false);
            await key.DisposeAsync().ConfigureAwait(false);
            await key.DisposeAsync().ConfigureAwait(false);
        }).ConfigureAwait(false);

        var task1 = Task.Run(async () =>
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(null);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () =>
        {
            await mutex.LockAsync().ConfigureAwait(false);
        });

        Assert.That(task2.IsCompleted, Is.False);
        task1Continue.SetResult(null);
        await task2.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockLockedOnlyPermitsOneLockerAtATime()
    {
        var mutex = new AsyncLock();
        var task1HasLock = CreateAsyncTaskSource<object?>();
        var task1Continue = CreateAsyncTaskSource<object?>();
        var task2Ready = CreateAsyncTaskSource<object?>();
        var task2HasLock = CreateAsyncTaskSource<object?>();
        var task2Continue = CreateAsyncTaskSource<object?>();

        var task1 = Task.Run(async () =>
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(null);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () =>
        {
            var key = mutex.LockAsync();
            task2Ready.SetResult(null);
            using (await key.ConfigureAwait(false))
            {
                task2HasLock.SetResult(null);
                await task2Continue.Task.ConfigureAwait(false);
            }
        });
        await task2Ready.Task.ConfigureAwait(false);

        var task3 = Task.Run(async () =>
        {
            await mutex.LockAsync().ConfigureAwait(false);
        });

        task1Continue.SetResult(null);
        await task2HasLock.Task.ConfigureAwait(false);

        Assert.That(task3.IsCompleted, Is.False);
        task2Continue.SetResult(null);
        await task2.ConfigureAwait(false);
        await task3.ConfigureAwait(false);
    }

    [Test]
    public void AsyncLockPreCancelledUnlockedSynchronouslyTakesLock()
    {
        var mutex = new AsyncLock();
        var token = new CancellationToken(true);

        var task = mutex.LockAsync(token).AsTask();

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.False);
        Assert.That(task.IsFaulted, Is.False);
    }

    [Test]
    public void AsyncLockPreCancelledLockedSynchronouslyCancels()
    {
        var mutex = new AsyncLock();
        var lockTask = mutex.LockAsync();
        var token = new CancellationToken(true);

        var task = mutex.LockAsync(token).AsTask();

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.True);
        Assert.That(task.IsFaulted, Is.False);
    }

    [Test]
    public void AsyncLockPreCancelledLockedAsynchronouslyCancels()
    {
        var mutex = new AsyncLock();
        var lockTask = mutex.LockAsync();
        var token = new CancellationToken(true);

        var valueTask = mutex.LockAsync(token);

        Assert.That(valueTask.IsCompleted, Is.True);
        Assert.That(valueTask.IsCanceled, Is.True);
        Assert.That(valueTask.IsFaulted, Is.False);
    }

    [Test]
    public async Task AsyncLockCancelledLockLeavesLockUnlocked()
    {
        var mutex = new AsyncLock();
        using var cts = new CancellationTokenSource();
        var taskReady = CreateAsyncTaskSource<object?>();

        var unlock = await mutex.LockAsync().ConfigureAwait(false);
        var task = Task.Run(async () =>
        {
            var lockTask = mutex.LockAsync(cts.Token);
            taskReady.SetResult(null);
            await lockTask.ConfigureAwait(false);
        });
        await taskReady.Task.ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await task.ConfigureAwait(false));
        Assert.That(task.IsCanceled, Is.True);
        await unlock.DisposeAsync().ConfigureAwait(false);

        var finalLockTask = mutex.LockAsync();
        await finalLockTask.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockCanceledLockThrowsException()
    {
        var mutex = new AsyncLock();
        using var cts = new CancellationTokenSource();

        await mutex.LockAsync().ConfigureAwait(false);
        var canceledLockTask = mutex.LockAsync(cts.Token).AsTask();
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<TaskCanceledException>(async () => await canceledLockTask.ConfigureAwait(false));
    }

    [Test]
    public async Task AsyncLockCanceledTooLateStillTakesLock()
    {
        var mutex = new AsyncLock();
        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.AsyncLockReleaser> cancelableLockTask;
        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            cancelableLockTask = mutex.LockAsync(cts.Token);
        }

        var key = await cancelableLockTask.ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        var nextLocker = mutex.LockAsync().AsTask();
        Assert.That(nextLocker.IsCompleted, Is.False);

        await key.DisposeAsync().ConfigureAwait(false);
        await nextLocker.ConfigureAwait(false);
    }

    [Test]
    public async Task AsyncLockSupportsMultipleAsynchronousLocks()
    {
        // This test deadlocks with the old AsyncEx: https://github.com/StephenCleary/AsyncEx/issues/57

        await Task.Run(() =>
        {
            var asyncLock = new AsyncLock();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
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
                () => {
                    using (asyncLock.LockAsync().GetAwaiter().GetResult())
                    {
                        Thread.Sleep(1000);
                    }
                });

            task2.Wait();
            cancellationTokenSource.Cancel();
            task1.Wait();
        }).ConfigureAwait(false);
    }

    [Test]
    public async Task LockUnlockSingleAwaiterAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync();
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
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task MultipleWaitersAreServedSequentiallyAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
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
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task AsyncLockLockedOnlyPermitsOneLockerAtATimeAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        var task1HasLock = new TaskCompletionSource<bool>();
        var task1Continue = new TaskCompletionSource<bool>();
        var task2Ready = new TaskCompletionSource<bool>();
        var task2HasLock = new TaskCompletionSource<bool>();
        var task2Continue = new TaskCompletionSource<bool>();

        var task1 = Task.Run(async () =>
        {
            using (await al.LockAsync().ConfigureAwait(false))
            {
                task1HasLock.SetResult(true);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () =>
        {
            ValueTask<AsyncLock.AsyncLockReleaser> key = al.LockAsync();
            task2Ready.SetResult(true);
            using (await key.ConfigureAwait(false))
            {
                task2HasLock.SetResult(true);
                await task2Continue.Task.ConfigureAwait(false);
            }
        });
        await task2Ready.Task.ConfigureAwait(false);

        var task3 = Task.Run(async () =>
        {
            await al.LockAsync().ConfigureAwait(false);
        });

        task1Continue.SetResult(true);
        await task2HasLock.Task.ConfigureAwait(false);

        Assert.That(task3.IsCompleted, Is.False);
        task2Continue.SetResult(false);

        // pro forma waits
        await task1.ConfigureAwait(false);
        await task2.ConfigureAwait(false);
        await task3.ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task CancellationBeforeQueueingThrowsAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            ValueTask<AsyncLock.AsyncLockReleaser> exVt = al.LockAsync(cts.Token);
            Assert.ThrowsAsync<TaskCanceledException>(async () => await exVt.ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsBeforeQueueingAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using (await al.LockAsync().ConfigureAwait(false))
        {
            using var cts = new CancellationTokenSource();

            // Cancel before queueing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            Assert.ThrowsAsync<TaskCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelsWhileQueuedAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        // Take the lock so subsequent waiters are queued
        using (await al.LockAsync().ConfigureAwait(false))
        {
            ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

            // Cancel after queuing
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenSucceedsIfNotCancelledAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncWithCancellationTokenCancelAfterLockAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test, CancelAfter(1000)]
    public async Task WaitAsyncWithCancellationTokenCancelAfterTimeoutAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource(250);

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

        using (await vt.ConfigureAwait(false))
        {
            Assert.That(al.IsTaken);
            Assert.ThrowsAsync<TaskCanceledException>(async () => await al.LockAsync(cts.Token).ConfigureAwait(false));
        }

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncGetAwaiterWithCancellationTokenCancelAfterLockAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

        using (vt.GetAwaiter().GetResult())
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WaitAsyncAsTaskGetAwaiterWithCancellationTokenCancelAfterLockAsync()
    {
        var customPool = new TestObjectPool<AsyncLock.AsyncLockReleaser>();
        var al = new AsyncLock(pool: customPool);

        using var cts = new CancellationTokenSource();

        ValueTask<AsyncLock.AsyncLockReleaser> vt = al.LockAsync(cts.Token);

        using (vt.AsTask().GetAwaiter().GetResult())
        {
            Assert.That(al.IsTaken);
        }

        // Cancel after lock is released, should not throw
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.That(al.InternalWaiterInUse, Is.False);
        Assert.That(customPool.ActiveCount, Is.EqualTo(0));
    }

    private static TaskCompletionSource<TResult> CreateAsyncTaskSource<TResult>()
    {
        return new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
    }

}
