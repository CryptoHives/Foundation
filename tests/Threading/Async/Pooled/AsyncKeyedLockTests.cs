// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method
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
public class AsyncKeyedLockTests
{
    [Test]
    public void LockUnlockedSynchronouslyPermitsLock()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        Task<AsyncKeyedLock<string>.Releaser> lockTask = locks.LockAsync("a").AsTask();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(lockTask.IsCompleted, Is.True);
            Assert.That(lockTask.IsFaulted, Is.False);
            Assert.That(lockTask.IsCanceled, Is.False);
        }
    }

    [Test]
    public void LockAsyncWithNullKeyThrows()
    {
        var locks = new AsyncKeyedLock<string>();

#pragma warning disable VSTHRD110
#pragma warning disable CA2012
        Assert.Throws<ArgumentNullException>(() => locks.LockAsync(null!));
#pragma warning restore CA2012
#pragma warning restore VSTHRD110
    }

    [Test]
    public async Task DifferentKeysDoNotBlockEachOther()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            // A lock on a different key must complete immediately even while "a" is held.
            Task<AsyncKeyedLock<string>.Releaser> other = locks.LockAsync("b").AsTask();
            Assert.That(other.IsCompleted, Is.True);
            (await other.ConfigureAwait(false)).Dispose();
        }
    }

    [Test]
    public async Task SameKeyBlocksUntilReleased()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        TaskCompletionSource<object?> task1HasLock = CreateAsyncTaskSource<object?>();
        TaskCompletionSource<object?> task1Continue = CreateAsyncTaskSource<object?>();

        var task1 = Task.Run(async () => {
            using (await locks.LockAsync("a").ConfigureAwait(false))
            {
                task1HasLock.SetResult(null);
                await task1Continue.Task.ConfigureAwait(false);
            }
        });
        await task1HasLock.Task.ConfigureAwait(false);

        var task2 = Task.Run(async () => {
            await locks.LockAsync("a").ConfigureAwait(false);
        });

        Assert.That(task2.IsCompleted, Is.False);
        task1Continue.SetResult(null);
        await task2.ConfigureAwait(false);
    }

    [Test]
    public async Task EntryIsInactiveAfterLastReleaseOnKey()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        Assert.That(locks.IsInUse("a"), Is.False);

        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            Assert.That(locks.IsInUse("a"), Is.True);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.IsInUse("a"), Is.False);
            Assert.That(locks.Count, Is.Zero);
            Assert.That(pool.ActiveCount, Is.Zero);
        }
    }

    [Test]
    public async Task EntryStaysAliveWhileWaitersAreQueued()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        Task t1, t2;
        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            t1 = Task.Run(async () => { using (await locks.LockAsync("a").ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });
            t2 = Task.Run(async () => { using (await locks.LockAsync("a").ConfigureAwait(false)) { await Task.Delay(10).ConfigureAwait(false); } });

            await Task.Delay(10).ConfigureAwait(false);
            Assert.That(locks.IsInUse("a"), Is.True);

            // release outer lock and wait for tasks to complete
        }

        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.InternalWaiterInUse("a"), Is.False);
            Assert.That(locks.IsInUse("a"), Is.False);
        }
    }

    [Test]
    public async Task MultipleKeysTrackIndependentEntries()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        AsyncKeyedLock<string>.Releaser lockA = await locks.LockAsync("a").ConfigureAwait(false);
        AsyncKeyedLock<string>.Releaser lockB = await locks.LockAsync("b").ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.Count, Is.EqualTo(2));
            Assert.That(locks.IsInUse("a"), Is.True);
            Assert.That(locks.IsInUse("b"), Is.True);
        }

        lockA.Dispose();
        Assert.That(locks.Count, Is.EqualTo(1));

        lockB.Dispose();
        Assert.That(locks.Count, Is.Zero);
    }

    [Test]
    public void PreCancelledUnlockedSynchronouslyTakesLock()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        var token = new CancellationToken(true);

        Task<AsyncKeyedLock<string>.Releaser> task = locks.LockAsync("a", token).AsTask();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(task.IsCanceled, Is.False);
            Assert.That(task.IsFaulted, Is.False);
        }
    }

    [Test]
    public async Task PreCancelledLockedSynchronouslyCancelsAndReleasesAdminReference()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        ValueTask<AsyncKeyedLock<string>.Releaser> lockTask = locks.LockAsync("a");
        var token = new CancellationToken(true);

        Task<AsyncKeyedLock<string>.Releaser> task = locks.LockAsync("a", token).AsTask();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(task.IsCompleted, Is.True);
            Assert.That(task.IsCanceled, Is.True);
            Assert.That(task.IsFaulted, Is.False);
        }

        // The cancelled acquisition must have released its administrative reference on the entry,
        // leaving only the still-held outer lock's reference behind.
        Assert.That(locks.IsInUse("a"), Is.True);

        (await lockTask.ConfigureAwait(false)).Dispose();
        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test]
    public async Task CancelledLockLeavesKeyUsableAndEvictable()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        using var cts = new CancellationTokenSource();
        TaskCompletionSource<object?> taskReady = CreateAsyncTaskSource<object?>();

        AsyncKeyedLock<string>.Releaser unlock = await locks.LockAsync("a").ConfigureAwait(false);
        var task = Task.Run(async () => {
            ValueTask<AsyncKeyedLock<string>.Releaser> lockTask = locks.LockAsync("a", cts.Token);
            taskReady.SetResult(null);
            await lockTask.ConfigureAwait(false);
        });
        await taskReady.Task.ConfigureAwait(false);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await task.ConfigureAwait(false));
        Assert.That(task.IsCanceled, Is.True);
        unlock.Dispose();

        Assert.That(locks.IsInUse("a"), Is.False);

        using (await locks.LockAsync("a").ConfigureAwait(false)) { }

        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test]
    public async Task LockAsyncWithZeroTimeoutThrowsAndReleasesAdminReference()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        AsyncKeyedLock<string>.Releaser outerReleaser = await locks.LockAsync("a").ConfigureAwait(false);

        Assert.ThrowsAsync<TimeoutException>(async () =>
            _ = await locks.LockAsync("a", TimeSpan.Zero).ConfigureAwait(false));

        Assert.That(locks.IsInUse("a"), Is.True);

        outerReleaser.Dispose();
        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test, CancelAfter(3000)]
    public async Task LockAsyncWithTimeoutThrowsWhenTimeoutElapses()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        using AsyncKeyedLock<string>.Releaser outerReleaser = await locks.LockAsync("a").ConfigureAwait(false);

        Assert.ThrowsAsync<TimeoutException>(async () =>
            await locks.LockAsync("a", TimeSpan.FromMilliseconds(100)).ConfigureAwait(false));

        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(locks.InternalWaiterInUse("a"), Is.False);
    }

    [Test]
    public void LockAsyncWithNegativeTimeoutThrows()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

#pragma warning disable VSTHRD110
#pragma warning disable CA2012
        Assert.Throws<ArgumentOutOfRangeException>(() => locks.LockAsync("a", TimeSpan.FromMilliseconds(-2)));
#pragma warning restore CA2012
#pragma warning restore VSTHRD110

        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test]
    public async Task LockAsyncWithInfiniteTimeoutBehavesLikeLockAsync()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        using (await locks.LockAsync("a", Timeout.InfiniteTimeSpan).ConfigureAwait(false))
        {
            Assert.That(locks.IsInUse("a"), Is.True);
        }

        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test]
    public async Task ReleaserCopiesOfSameAcquisitionAreEqual()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        // A releaser identifies one acquisition, so copies of the same handle compare equal.
        AsyncKeyedLock<string>.Releaser first = await locks.LockAsync("a").ConfigureAwait(false);
        AsyncKeyedLock<string>.Releaser second = first;
        first.Dispose();

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
    public async Task ReleaserFromHandoffOnSameEntryAreNotEqual()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        // Two overlapping acquisitions of the same key share the same underlying entry, but they are
        // still distinct acquisitions - the generation token stamped on handoff keeps them apart.
        AsyncKeyedLock<string>.Releaser first = await locks.LockAsync("a").ConfigureAwait(false);
        Task<AsyncKeyedLock<string>.Releaser> secondTask = locks.LockAsync("a").AsTask();
        first.Dispose();
        AsyncKeyedLock<string>.Releaser second = await secondTask.ConfigureAwait(false);
        second.Dispose();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.Equals(second), Is.False);
            Assert.That(first == second, Is.False);
            Assert.That(first != second, Is.True);
        }
    }

    [Test]
    public async Task ReleaserFromReacquiredEntryAreNotEqual()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        // Two non-overlapping acquisitions of the same key now reuse the same cached entry, so only
        // the per-acquisition generation token distinguishes their releasers.
        AsyncKeyedLock<string>.Releaser first;
        using (first = await locks.LockAsync("a").ConfigureAwait(false)) { }
        Assert.That(locks.IsInUse("a"), Is.False);

        AsyncKeyedLock<string>.Releaser second;
        using (second = await locks.LockAsync("a").ConfigureAwait(false)) { }

        Assert.That(first.Equals(second), Is.False);
    }

    [Test]
    public async Task ReleaserFromDifferentKeysAreNotEqual()
    {
        var locks = new AsyncKeyedLock<string>();

        AsyncKeyedLock<string>.Releaser releaserA;
        using (releaserA = await locks.LockAsync("a").ConfigureAwait(false)) { }
        AsyncKeyedLock<string>.Releaser releaserB;
        using (releaserB = await locks.LockAsync("b").ConfigureAwait(false)) { }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(releaserA.Equals(releaserB), Is.False);
            Assert.That(releaserA == releaserB, Is.False);
            Assert.That(releaserA != releaserB, Is.True);
            Assert.That(releaserA.Equals("not a releaser"), Is.False);
        }
    }

    [Test]
    public async Task ReleaserExposesKey()
    {
        var locks = new AsyncKeyedLock<string>();

        using AsyncKeyedLock<string>.Releaser releaser = await locks.LockAsync("a").ConfigureAwait(false);

        Assert.That(releaser.Key, Is.EqualTo("a"));
    }

    [Test]
    public async Task ReleaserDisposeAsyncReleasesLock()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        AsyncKeyedLock<string>.Releaser releaser = await locks.LockAsync("a").ConfigureAwait(false);
        await releaser.DisposeAsync().ConfigureAwait(false);

        Assert.That(locks.IsInUse("a"), Is.False);
    }

    [Test]
    public async Task SupportsManyConcurrentKeysUnderContention()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        var tasks = new Task[20];
        for (int i = 0; i < tasks.Length; i++)
        {
            string key = $"key-{i % 4}";
            tasks[i] = Task.Run(async () => {
                for (int j = 0; j < 25; j++)
                {
                    using (await locks.LockAsync(key).ConfigureAwait(false))
                    {
                        await Task.Yield();
                    }
                }
            });
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);

        Assert.That(locks.Count, Is.Zero);
    }

    [Test]
    public async Task SurvivesConcurrentEvictionPressure()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();

        // A cache far smaller than the key set, so nearly every release evicts and nearly every
        // acquisition rents from the entry pool - all while other threads mutate the same idle list.
        var locks = new AsyncKeyedLock<string>(pool: pool, maxIdleEntries: 2);

        var tasks = new Task[16];
        for (int i = 0; i < tasks.Length; i++)
        {
            int offset = i;
            tasks[i] = Task.Run(async () => {
                for (int j = 0; j < 100; j++)
                {
                    using (await locks.LockAsync($"key-{(offset + j) % 32}").ConfigureAwait(false))
                    {
                        await Task.Yield();
                    }
                }
            });
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.Count, Is.Zero);
            Assert.That(locks.CachedCount, Is.EqualTo(2));
        }
    }

    [Test]
    public async Task ReleasedKeyStaysCachedForReuse()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        using (await locks.LockAsync("a").ConfigureAwait(false)) { }

        using (Assert.EnterMultipleScope())
        {
            // Released, so no longer in use - but still mapped, so the next acquisition reuses it.
            Assert.That(locks.IsInUse("a"), Is.False);
            Assert.That(locks.IsCached("a"), Is.True);
            Assert.That(locks.CachedCount, Is.EqualTo(1));
        }

        using (await locks.LockAsync("a").ConfigureAwait(false)) { }

        Assert.That(locks.CachedCount, Is.EqualTo(1), "Re-acquiring a cached key must not create a second entry.");
    }

    [Test]
    public async Task IdleCacheIsBoundedByMaxIdleEntries()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool, maxIdleEntries: 4);

        for (int i = 0; i < 32; i++)
        {
            using (await locks.LockAsync($"key-{i}").ConfigureAwait(false)) { }
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.CachedCount, Is.EqualTo(4));
            Assert.That(locks.Count, Is.Zero);

            // The cache is least-recently-used, so the newest keys survive and the oldest are gone.
            Assert.That(locks.IsCached("key-31"), Is.True);
            Assert.That(locks.IsCached("key-0"), Is.False);
        }
    }

    [Test]
    public async Task ZeroMaxIdleEntriesEvictsEagerly()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool, maxIdleEntries: 0);

        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            Assert.That(locks.IsInUse("a"), Is.True);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(locks.IsCached("a"), Is.False);
            Assert.That(locks.CachedCount, Is.Zero);
        }

        // Still fully usable with the cache disabled.
        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            Assert.That(locks.IsInUse("a"), Is.True);
        }
    }

    [Test]
    public void NegativeMaxIdleEntriesThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AsyncKeyedLock<string>(maxIdleEntries: -1));
    }

    [Test]
    public async Task DisposingReleaserTwiceThrows()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        AsyncKeyedLock<string>.Releaser releaser = await locks.LockAsync("a").ConfigureAwait(false);
        releaser.Dispose();

        Assert.Throws<InvalidOperationException>(releaser.Dispose);
    }

    [Test]
    public async Task DisposingStaleReleaserAfterReacquireThrows()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        // The entry is reused by the second acquisition, so the stale handle would otherwise release
        // a hold that belongs to somebody else.
        AsyncKeyedLock<string>.Releaser stale = await locks.LockAsync("a").ConfigureAwait(false);
        stale.Dispose();

        using (await locks.LockAsync("a").ConfigureAwait(false))
        {
            Assert.Throws<InvalidOperationException>(stale.Dispose);
            Assert.That(locks.IsInUse("a"), Is.True, "The live acquisition must still hold the lock.");
        }
    }

    [Test]
    public async Task RepeatedLockOnCachedKeyDoesNotAllocate()
    {
        using var pool = new TestObjectPool<AsyncKeyedLock<string>.Releaser>();
        var locks = new AsyncKeyedLock<string>(pool: pool);

        // Warm up so the entry, its local waiter and the dictionary node all already exist.
        for (int i = 0; i < 100; i++)
        {
            using (await locks.LockAsync("a").ConfigureAwait(false)) { }
        }

        const int Iterations = 1000;

        long before = GC.GetAllocatedBytesForCurrentThread();
        for (int i = 0; i < Iterations; i++)
        {
            using (await locks.LockAsync("a").ConfigureAwait(false)) { }
        }
        long perOperation = (GC.GetAllocatedBytesForCurrentThread() - before) / Iterations;

#if DEBUG
        // Debug builds compile async state machines as classes, so every LockAsync boxes one no matter
        // what the entry cache does - a fixed ~184 B that has nothing to do with this type. Entry churn
        // would add several hundred bytes on top, so this bound still catches a regression; the exact
        // zero that the documented allocation behavior promises is asserted by the Release build.
        Assert.That(perOperation, Is.LessThan(256), "Lock/release on a cached key must not churn entries.");
#else
        Assert.That(perOperation, Is.Zero, "Uncontended lock/release on a cached key must be allocation free.");
#endif
    }

    private static TaskCompletionSource<TResult> CreateAsyncTaskSource<TResult>()
    {
        return new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
