// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CHTEXP001 // AsyncReentrantLock is experimental
#pragma warning disable CA1849 // Call async methods when in an async method

namespace Threading.Tests.Async.Pooled.AsyncReentrantLock;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncReentrantLockTests
{
    [Test, CancelAfter(5000)]
    public async Task DepthBumpIsVisibleToCallerAfterUncontendedAcquisition()
    {
        // Fails if LockAsync becomes an async method: its slot write would no longer reach the caller.
        var mutex = new AsyncReentrantLock();

        Assert.That(mutex.CurrentDepth, Is.Zero);

        AsyncReentrantLock.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);
        Assert.That(mutex.CurrentDepth, Is.EqualTo(1));

        outer.Dispose();
        Assert.That(mutex.CurrentDepth, Is.Zero);
    }

    [Test]
    public async Task LockAsyncPermitsSingleAcquisition()
    {
        var mutex = new AsyncReentrantLock();

        using (await mutex.LockAsync().ConfigureAwait(false)) { }

        Assert.That(mutex.DepthsCreated, Is.EqualTo(1));
    }

    [Test, CancelAfter(5000)]
    public async Task NestedReentrantAcquisitionSucceedsWithoutDeadlock()
    {
        var mutex = new AsyncReentrantLock();

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    Assert.That(mutex.CurrentDepth, Is.EqualTo(3));
                }
            }
        }

        Assert.That(mutex.DepthsCreated, Is.EqualTo(3));
    }

    [Test, CancelAfter(5000)]
    public async Task DepthIsRestoredAfterOuterAcquisitionCompletes()
    {
        var mutex = new AsyncReentrantLock();

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            using (await mutex.LockAsync().ConfigureAwait(false)) { }
        }

        using (await mutex.LockAsync().ConfigureAwait(false)) { }

        Assert.That(mutex.DepthsCreated, Is.EqualTo(2));
    }

    [Test, CancelAfter(5000)]
    public async Task NestingBeyondInitialCapacityGrowsDepthTable()
    {
        const int Depth = 10;
        var mutex = new AsyncReentrantLock();
        int deepest = 0;

        async Task RecurseAsync(int remaining)
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                if (remaining > 1)
                {
                    await RecurseAsync(remaining - 1).ConfigureAwait(false);
                }
                else
                {
                    deepest = mutex.CurrentDepth;
                }
            }
        }

        await RecurseAsync(Depth).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(deepest, Is.EqualTo(Depth));
            Assert.That(mutex.DepthsCreated, Is.EqualTo(Depth));
            Assert.That(mutex.CurrentDepth, Is.Zero);
        }
    }

    [TestCase(6)]
    [TestCase(AsyncReentrantLock.MaxDepthLocksCapacity)]
    [CancelAfter(5000)]
    public async Task NestingBeyondMaxDepthThrowsAndLeavesDepthUnchanged(int maxDepth)
    {
        var mutex = maxDepth == AsyncReentrantLock.MaxDepthLocksCapacity
            ? new AsyncReentrantLock()
            : new AsyncReentrantLock(AsyncReentrantLock.DefaultDepthLocksCapacity, maxDepth);
        var releasers = new List<AsyncReentrantLock.Releaser>();

        for (int i = 0; i < maxDepth; i++)
        {
            releasers.Add(await mutex.LockAsync().ConfigureAwait(false));
        }

#pragma warning disable VSTHRD110, CA2012 // the call throws before returning a ValueTask
        Assert.Throws<InvalidOperationException>(() => mutex.LockAsync());
#pragma warning restore VSTHRD110, CA2012

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mutex.CurrentDepth, Is.EqualTo(maxDepth));
            Assert.That(mutex.DepthsCreated, Is.EqualTo(maxDepth));
        }

        for (int i = releasers.Count - 1; i >= 0; i--)
        {
            releasers[i].Dispose();
        }

        Assert.That(mutex.CurrentDepth, Is.Zero);

        using (await mutex.LockAsync(TimeSpan.Zero).ConfigureAwait(false))
        {
            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
        }
    }

    [TestCase(AsyncReentrantLock.DefaultDepthLocksCapacity - 1, AsyncReentrantLock.MaxDepthLocksCapacity)]
    [TestCase(AsyncReentrantLock.DefaultDepthLocksCapacity, AsyncReentrantLock.DefaultDepthLocksCapacity - 1)]
    [TestCase(8, 6)]
    public void ConstructorRejectsInvalidCapacities(int defaultCapacity, int maxCapacity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new AsyncReentrantLock(defaultCapacity, maxCapacity));
    }

    [Test, CancelAfter(5000)]
    public async Task UnrelatedConcurrentTopLevelCallersSerialize()
    {
        var mutex = new AsyncReentrantLock();
        int insideCount = 0;
        int violations = 0;

        async Task WorkAsync()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                if (Interlocked.Increment(ref insideCount) > 1)
                {
                    Interlocked.Increment(ref violations);
                }

                await Task.Delay(20).ConfigureAwait(false);
                Interlocked.Decrement(ref insideCount);
            }
        }

        await Task.WhenAll(WorkAsync(), WorkAsync(), WorkAsync(), WorkAsync()).ConfigureAwait(false);

        Assert.That(violations, Is.Zero);
    }

    [Test, CancelAfter(5000)]
    public async Task ConcurrentSiblingsSpawnedUnderAHeldLockSerializeAgainstEachOther()
    {
        var mutex = new AsyncReentrantLock();
        int insideDepth1 = 0;
        int violations = 0;

        async Task NestedAsync()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                if (Interlocked.Increment(ref insideDepth1) > 1)
                {
                    Interlocked.Increment(ref violations);
                }

                await Task.Delay(20).ConfigureAwait(false);
                Interlocked.Decrement(ref insideDepth1);
            }
        }

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            await Task.WhenAll(NestedAsync(), NestedAsync(), NestedAsync()).ConfigureAwait(false);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(violations, Is.Zero);
            Assert.That(mutex.DepthsCreated, Is.EqualTo(2));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task ConcurrentSiblingsSeeOnlyTheirOwnDepth()
    {
        const int Siblings = 4;
        var mutex = new AsyncReentrantLock();
        var allQueued = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        int queued = 0;
        int wrongDepths = 0;

        async Task SiblingAsync()
        {
            if (mutex.CurrentDepth != 1) Interlocked.Increment(ref wrongDepths);

            ValueTask<AsyncReentrantLock.Releaser> pending = mutex.LockAsync();
            if (Interlocked.Increment(ref queued) == Siblings) allQueued.SetResult(true);

            using (await pending.ConfigureAwait(false))
            {
                await allQueued.Task.ConfigureAwait(false);
                if (mutex.CurrentDepth != 2) Interlocked.Increment(ref wrongDepths);
            }

            if (mutex.CurrentDepth != 1) Interlocked.Increment(ref wrongDepths);
        }

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            var siblings = new Task[Siblings];
            for (int i = 0; i < Siblings; i++)
            {
                siblings[i] = Task.Run(SiblingAsync);
            }

            await Task.WhenAll(siblings).ConfigureAwait(false);
            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(wrongDepths, Is.Zero);
            Assert.That(mutex.CurrentDepth, Is.Zero);
        }
    }

    [Test, CancelAfter(10000)]
    public async Task ConcurrentTreesOfSiblingsSerializeAtEveryDepth()
    {
        var mutex = new AsyncReentrantLock();
        var inside = new int[3];
        int violations = 0;

        async Task EnterAsync(int depth, int fanOut)
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                if (mutex.CurrentDepth != depth + 1 || Interlocked.Increment(ref inside[depth]) > 1)
                {
                    Interlocked.Increment(ref violations);
                }

                await Task.Yield();
                Interlocked.Decrement(ref inside[depth]);

                if (depth + 1 < inside.Length)
                {
                    var children = new Task[fanOut];
                    for (int i = 0; i < fanOut; i++)
                    {
                        children[i] = Task.Run(() => EnterAsync(depth + 1, fanOut));
                    }

                    await Task.WhenAll(children).ConfigureAwait(false);
                }
            }
        }

        var trees = new Task[4];
        for (int i = 0; i < trees.Length; i++)
        {
            trees[i] = Task.Run(() => EnterAsync(0, 3));
        }

        await Task.WhenAll(trees).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(violations, Is.Zero);
            Assert.That(mutex.DepthsCreated, Is.EqualTo(inside.Length));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task TwoInstancesTrackDepthIndependently()
    {
        var first = new AsyncReentrantLock();
        var second = new AsyncReentrantLock();

        using (await first.LockAsync().ConfigureAwait(false))
        using (await second.LockAsync().ConfigureAwait(false))
        using (await first.LockAsync().ConfigureAwait(false))
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(first.CurrentDepth, Is.EqualTo(2));
                Assert.That(second.CurrentDepth, Is.EqualTo(1));
            }
        }
    }

    [Test, CancelAfter(5000)]
    public async Task LockAsyncWithTimeoutSupportsReentrancyToo()
    {
        var mutex = new AsyncReentrantLock();

        using (await mutex.LockAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false))
        {
            using (await mutex.LockAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false))
            {
                Assert.That(mutex.CurrentDepth, Is.EqualTo(2));
            }
        }
    }

    [Test]
    public void LockAsyncRejectsNegativeTimeout()
    {
        var mutex = new AsyncReentrantLock();

#pragma warning disable VSTHRD110, CA2012 // the call throws before returning a ValueTask
        Assert.Throws<ArgumentOutOfRangeException>(() => mutex.LockAsync(TimeSpan.FromMilliseconds(-2)));
#pragma warning restore VSTHRD110, CA2012
    }

    [Test, CancelAfter(5000)]
    public async Task AwaitUsingReleasesAndRestoresDepth()
    {
        var mutex = new AsyncReentrantLock();

        await using (await mutex.LockAsync().ConfigureAwait(false))
        {
            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
        }

        Assert.That(mutex.CurrentDepth, Is.Zero);
        using (await mutex.LockAsync(TimeSpan.Zero).ConfigureAwait(false)) { }
    }

    [Test, CancelAfter(5000)]
    public async Task TimeoutThrowsAndLeavesDepthUnchanged()
    {
        var mutex = new AsyncReentrantLock();
        var holderReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var holderRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        Task holder = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                holderReady.SetResult(true);
                await holderRelease.Task.ConfigureAwait(false);
            }
        });

        await holderReady.Task.ConfigureAwait(false);

        await Assert.ThrowsAsync<TimeoutException>(async () => await mutex.LockAsync(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false)).ConfigureAwait(false);
        Assert.That(mutex.CurrentDepth, Is.Zero);

        holderRelease.SetResult(true);
        await holder.ConfigureAwait(false);

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task CancelledTopLevelAcquisitionLeavesDepthUnchanged()
    {
        var mutex = new AsyncReentrantLock();
        var holderReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var holderRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        Task holder = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                holderReady.SetResult(true);
                await holderRelease.Task.ConfigureAwait(false);
            }
        });

        await holderReady.Task.ConfigureAwait(false);

        using (var cts = new CancellationTokenSource())
        {
            Task<AsyncReentrantLock.Releaser> pending = mutex.LockAsync(cts.Token).AsTask();
            cts.Cancel();
            await Assert.CatchAsync<OperationCanceledException>(async () => await pending.ConfigureAwait(false)).ConfigureAwait(false);
        }

        Assert.That(mutex.CurrentDepth, Is.Zero);

        holderRelease.SetResult(true);
        await holder.ConfigureAwait(false);

        using (await mutex.LockAsync().ConfigureAwait(false)) { }
    }

    [Test, CancelAfter(5000)]
    public async Task CancelledNestedAcquisitionLeavesDepthUnchanged()
    {
        var mutex = new AsyncReentrantLock();
        var siblingReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var siblingRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            Task sibling = Task.Run(async () => {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    siblingReady.SetResult(true);
                    await siblingRelease.Task.ConfigureAwait(false);
                }
            });

            await siblingReady.Task.ConfigureAwait(false);

            using (var cts = new CancellationTokenSource())
            {
                Task<AsyncReentrantLock.Releaser> pending = mutex.LockAsync(cts.Token).AsTask();
                cts.Cancel();
                await Assert.CatchAsync<OperationCanceledException>(async () => await pending.ConfigureAwait(false)).ConfigureAwait(false);
            }

            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));

            siblingRelease.SetResult(true);
            await sibling.ConfigureAwait(false);

            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                Assert.That(mutex.CurrentDepth, Is.EqualTo(2));
            }
        }
    }

    [Test, CancelAfter(10000)]
    public async Task NestingAfterAContendedAcquisitionSucceeds()
    {
        var mutex = new AsyncReentrantLock();
        var winnerHasDepth1 = new TaskCompletionSource<bool>();
        var loserIsWaiting = new TaskCompletionSource<bool>();
        Exception? loserNestedResult = null;
        int loserDepthWhileHolding = -1;
        int loserDepthWhileNested = -1;

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            async Task WinnerAsync()
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    winnerHasDepth1.SetResult(true);
                    await loserIsWaiting.Task.ConfigureAwait(false);
                }
            }

            // Has to wait for depth 1, so it resumes through the contended path before nesting again.
            async Task LoserAsync()
            {
                await winnerHasDepth1.Task.ConfigureAwait(false);

                ValueTask<AsyncReentrantLock.Releaser> contended = mutex.LockAsync();
                loserIsWaiting.SetResult(true);

                using (await contended.ConfigureAwait(false))
                {
                    loserDepthWhileHolding = mutex.CurrentDepth;

                    try
                    {
                        using (await mutex.LockAsync(TimeSpan.FromMilliseconds(500)).ConfigureAwait(false))
                        {
                            loserDepthWhileNested = mutex.CurrentDepth;
                        }
                    }
                    catch (TimeoutException ex)
                    {
                        loserNestedResult = ex;
                    }
                }
            }

            await Task.WhenAll(WinnerAsync(), LoserAsync()).ConfigureAwait(false);
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(loserNestedResult, Is.Null, "nesting after a contended acquisition must not self-deadlock");
            Assert.That(loserDepthWhileHolding, Is.EqualTo(2));
            Assert.That(loserDepthWhileNested, Is.EqualTo(3));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task AsyncWrapperAroundLockAsyncHidesTheHoldFromItsCaller()
    {
        var mutex = new AsyncReentrantLock();

#pragma warning disable CHT011 // the wrapper is the point of the test
        async ValueTask<AsyncReentrantLock.Releaser> EnterAsync() => await mutex.LockAsync().ConfigureAwait(false);
#pragma warning restore CHT011

        using (await EnterAsync().ConfigureAwait(false))
        {
            Assert.That(mutex.CurrentDepth, Is.Zero);
            await Assert.ThrowsAsync<TimeoutException>(async () => await mutex.LockAsync(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false)).ConfigureAwait(false);
        }
    }

    [Test, CancelAfter(5000)]
    public async Task OrphanedFireAndForgetChildFallsBackToParentDepth()
    {
        var mutex = new AsyncReentrantLock();
        var parentReleased = new TaskCompletionSource<bool>();
        int observedDepthAfterChildAcquire = -1;

        Task childTask;
        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            childTask = Task.Run(async () => {
                await parentReleased.Task.ConfigureAwait(false);

                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    observedDepthAfterChildAcquire = mutex.CurrentDepth;
                }
            });
        }

        parentReleased.SetResult(true);
        await childTask.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(observedDepthAfterChildAcquire, Is.EqualTo(1));
            Assert.That(mutex.DepthsCreated, Is.EqualTo(1), "depth 1 should never be touched");
        }
    }

    [Test, CancelAfter(5000)]
    public async Task OrphanedGrandchildDoesNotRunConcurrentlyWithUnrelatedHolder()
    {
        var mutex = new AsyncReentrantLock();
        var unrelatedHolds = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var orphanDone = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        int unrelatedInside = 0;
        int overlap = -1;
        Task orphan = Task.CompletedTask;

        async Task ParentAsync()
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                orphan = Task.Run(async () => {
                    await unrelatedHolds.Task.ConfigureAwait(false);
                    using (await mutex.LockAsync().ConfigureAwait(false))
                    {
                        overlap = Volatile.Read(ref unrelatedInside);
                    }

                    orphanDone.SetResult(true);
                });
            }
        }

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            await ParentAsync().ConfigureAwait(false);
        }

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            Volatile.Write(ref unrelatedInside, 1);
            unrelatedHolds.SetResult(true);
            await Task.WhenAny(orphanDone.Task, Task.Delay(500)).ConfigureAwait(false);
            Volatile.Write(ref unrelatedInside, 0);
        }

        await orphan.ConfigureAwait(false);

        Assert.That(overlap, Is.Zero, "an orphan two levels deep acquired while an unrelated flow held the lock");
    }

    [Test, CancelAfter(5000)]
    public async Task LockStaysHeldWhileANestedFireAndForgetHolderRuns()
    {
        var mutex = new AsyncReentrantLock();
        var childHolds = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var childRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        AsyncReentrantLock.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);

        Task child = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                childHolds.SetResult(true);
                await childRelease.Task.ConfigureAwait(false);
            }
        });

        await childHolds.Task.ConfigureAwait(false);
        outer.Dispose();

        Task<AsyncReentrantLock.Releaser> next = mutex.LockAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(next, 100).ConfigureAwait(false);

        childRelease.SetResult(true);
        await child.ConfigureAwait(false);

        using (await next.ConfigureAwait(false))
        {
            Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task NestedFireAndForgetHolderCanNestAgainAfterItsParentReleases()
    {
        var mutex = new AsyncReentrantLock();
        var childHolds = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var parentReleased = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        int innerDepth = -1;

        AsyncReentrantLock.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);

        Task child = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                childHolds.SetResult(true);
                await parentReleased.Task.ConfigureAwait(false);
                using (await mutex.LockAsync(TimeSpan.FromSeconds(2)).ConfigureAwait(false))
                {
                    innerDepth = mutex.CurrentDepth;
                }
            }
        });

        await childHolds.Task.ConfigureAwait(false);
        outer.Dispose();
        Task<AsyncReentrantLock.Releaser> next = mutex.LockAsync().AsTask();
        parentReleased.SetResult(true);
        await child.ConfigureAwait(false);

        using (await next.ConfigureAwait(false))
        {
            Assert.That(innerDepth, Is.EqualTo(3));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task DeferredReleasesCascadeThroughEveryReleasedLevel()
    {
        var mutex = new AsyncReentrantLock();
        var childHolds = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var childRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        AsyncReentrantLock.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);
        AsyncReentrantLock.Releaser nested = await mutex.LockAsync().ConfigureAwait(false);

        Task child = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                childHolds.SetResult(true);
                await childRelease.Task.ConfigureAwait(false);
            }
        });

        await childHolds.Task.ConfigureAwait(false);
        nested.Dispose();
        outer.Dispose();

        Task<AsyncReentrantLock.Releaser> next = mutex.LockAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(next, 100).ConfigureAwait(false);

        childRelease.SetResult(true);
        await child.ConfigureAwait(false);

        using (await next.ConfigureAwait(false))
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(mutex.CurrentDepth, Is.EqualTo(1));
                Assert.That(mutex.DepthsCreated, Is.EqualTo(3));
            }
        }
    }

    [Test, CancelAfter(5000)]
    public async Task OrphanQueuedBehindASiblingWaitsAtTopLevelOnceItsParentReleases()
    {
        var mutex = new AsyncReentrantLock();
        var siblingHolds = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var siblingRelease = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var orphanQueued = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var orphanDone = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        int unrelatedInside = 0;
        int overlap = -1;
        int orphanDepth = -1;

        AsyncReentrantLock.Releaser parent = await mutex.LockAsync().ConfigureAwait(false);

        Task sibling = Task.Run(async () => {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                siblingHolds.SetResult(true);
                await siblingRelease.Task.ConfigureAwait(false);
            }
        });

        await siblingHolds.Task.ConfigureAwait(false);

        // Validates its claim on the parent now, then waits for depth 1 behind the sibling.
        Task orphan = Task.Run(async () => {
            ValueTask<AsyncReentrantLock.Releaser> pending = mutex.LockAsync();
            orphanQueued.SetResult(true);
            using (await pending.ConfigureAwait(false))
            {
                overlap = Volatile.Read(ref unrelatedInside);
                orphanDepth = mutex.CurrentDepth;
            }

            orphanDone.SetResult(true);
        });

        await orphanQueued.Task.ConfigureAwait(false);
        parent.Dispose();

        Task<AsyncReentrantLock.Releaser> unrelated = mutex.LockAsync().AsTask();
        siblingRelease.SetResult(true);

        using (await unrelated.ConfigureAwait(false))
        {
            Volatile.Write(ref unrelatedInside, 1);
            await Task.WhenAny(orphanDone.Task, Task.Delay(300)).ConfigureAwait(false);
            Volatile.Write(ref unrelatedInside, 0);
        }

        await Task.WhenAll(sibling, orphan).ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(overlap, Is.Zero, "the orphan ran while an unrelated flow held the lock");
            Assert.That(orphanDepth, Is.EqualTo(1), "the orphan should have acquired at top level");
        }
    }

    [Test]
    public void DisposingADefaultReleaser()
    {
        AsyncReentrantLock.Releaser releaser = default;

#if DEBUG
        Assert.Throws<InvalidOperationException>(releaser.Dispose);
#else
        Assert.DoesNotThrow(releaser.Dispose);
#endif
    }

    [Test]
    public void DefaultReleasersAreEqual()
    {
        var first = default(AsyncReentrantLock.Releaser);
        var second = default(AsyncReentrantLock.Releaser);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first, Is.EqualTo(second));
            Assert.That(first == second, Is.True);
            Assert.That(first.GetHashCode(), Is.Zero);
        }
    }
}
