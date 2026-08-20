// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncLockExTests
{
    [Test, CancelAfter(5000)]
    public async Task DepthBumpIsVisibleToCallerAfterUncontendedAcquisition()
    {
        // Pins down the exact behavior LockAsync's non-async fast path depends on: an AsyncLocal
        // mutation made inside an `async` method is NOT visible to that method's own caller once it
        // returns, even on a fully synchronous completion - see the type-level remarks on AsyncLockEx.
        // If this regresses (e.g. LockAsync's fast path is refactored back into an async method),
        // every nested/reentrant acquisition silently breaks, so this is worth its own direct test.
        var mutex = new AsyncLockEx();

        Assert.That(mutex.CurrentDepth, Is.Zero);

        AsyncLockEx.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);
        Assert.That(mutex.CurrentDepth, Is.EqualTo(1), "depth should be 1 right after the outer acquisition, before any nested call");

        outer.Dispose();
        Assert.That(mutex.CurrentDepth, Is.Zero, "depth should be restored once the outer acquisition is disposed");
    }

    [Test]
    public async Task LockAsyncPermitsSingleAcquisition()
    {
        var mutex = new AsyncLockEx();

        using (await mutex.LockAsync().ConfigureAwait(false)) { }

        Assert.That(mutex.DepthsCreated, Is.EqualTo(1));
    }

    [Test, CancelAfter(5000)]
    public async Task NestedReentrantAcquisitionSucceedsWithoutDeadlock()
    {
        // The whole point of this type: re-entering the same lock from a call nested inside an
        // already-held acquisition must not deadlock, unlike AsyncLock.
        var mutex = new AsyncLockEx();

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                }
            }
        }

        // Three nested acquisitions on one flow means depths 0, 1, and 2 were each touched once.
        Assert.That(mutex.DepthsCreated, Is.EqualTo(3));
    }

    [Test, CancelAfter(5000)]
    public async Task DepthIsRestoredAfterOuterAcquisitionCompletes()
    {
        var mutex = new AsyncLockEx();

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            using (await mutex.LockAsync().ConfigureAwait(false)) { }
        }

        // A later, unrelated top-level acquisition on the same (now fully unwound) flow must start
        // fresh at depth 0 again, reusing the existing depth-0 lock rather than creating a new one.
        using (await mutex.LockAsync().ConfigureAwait(false)) { }

        Assert.That(mutex.DepthsCreated, Is.EqualTo(2));
    }

    [Test, CancelAfter(5000)]
    public async Task UnrelatedConcurrentTopLevelCallersSerialize()
    {
        // Two completely unrelated logical flows both acquiring at depth 0 must genuinely serialize -
        // this is ordinary mutual exclusion and must hold regardless of the reentrancy machinery.
        var mutex = new AsyncLockEx();
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

        Assert.That(violations, Is.Zero, "Unrelated top-level callers ran inside the lock concurrently.");
    }

    [Test, CancelAfter(5000)]
    public async Task ConcurrentSiblingsSpawnedUnderAHeldLockSerializeAgainstEachOther()
    {
        // The key correctness property motivating the per-depth lock array instead of a naive
        // "skip if already held" flag: two children spawned via Task.WhenAll from inside an already-held
        // acquisition both inherit the same ambient depth, so a flag-based design would let both believe
        // they're safely reentrant and race inside the region. Here they must instead genuinely
        // contend for the same depth-1 lock and never run concurrently.
        var mutex = new AsyncLockEx();
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
            Assert.That(violations, Is.Zero, "Sibling tasks spawned under a held lock ran concurrently instead of serializing.");
            // Depth 0 (the outer hold) plus depth 1 (shared by all three siblings) - not one lock per sibling.
            Assert.That(mutex.DepthsCreated, Is.EqualTo(2));
        }
    }

    [Test, CancelAfter(5000)]
    public async Task LockAsyncWithTimeoutSupportsReentrancyToo()
    {
        var mutex = new AsyncLockEx();

        using (await mutex.LockAsync(System.TimeSpan.FromSeconds(5)).ConfigureAwait(false))
        {
            using (await mutex.LockAsync(System.TimeSpan.FromSeconds(5)).ConfigureAwait(false))
            {
            }
        }
    }

    [Test, CancelAfter(10000)]
    public async Task KNOWNBUG_NestingAfterAContendedAcquisitionSelfDeadlocks()
    {
        // CHARACTERIZATION TEST for a real, currently-unfixed self-deadlock - it asserts the BROKEN
        // behavior on purpose, so the day the underlying flaw is fixed this test fails loudly and gets
        // flipped to assert success instead.
        //
        // Chain of causation:
        //  1. AsyncLocal mutations inside an `async` method never propagate back to that method's caller
        //     (the documented limitation that forced LockAsync's fast path to be non-async).
        //  2. The CONTENDED path still has to go through `async AwaitAndBumpDepth`, so a caller that had
        //     to genuinely wait for its depth-level lock resumes with its ambient state UNCHANGED - it
        //     believes it is still at its pre-call depth, even though it now holds one level deeper.
        //  3. When that caller nests again, ResolveTargetDepth computes the target from that stale state
        //     and hands back the depth the caller ALREADY HOLDS - so it waits on itself. Deadlock.
        //
        // The type-level remarks describe (2) as "further nesting is not reliably tracked", which
        // understates it: it is not merely mistracked, it is a guaranteed self-deadlock.
        var mutex = new AsyncLockEx();
        var winnerHasDepth1 = new TaskCompletionSource();
        var loserIsWaiting = new TaskCompletionSource();
        Exception? loserNestedResult = null;

        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            // Winner: takes depth 1 uncontended, holds it until the loser is definitely queued behind it.
            async Task WinnerAsync()
            {
                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    winnerHasDepth1.SetResult();
                    await loserIsWaiting.Task.ConfigureAwait(false);
                }
            }

            // Loser: must genuinely WAIT for depth 1, so it resumes via the async AwaitAndBumpDepth path
            // and therefore loses its ambient depth bump - then it nests again.
            async Task LoserAsync()
            {
                await winnerHasDepth1.Task.ConfigureAwait(false);

                ValueTask<AsyncLockEx.Releaser> contended = mutex.LockAsync();
                loserIsWaiting.SetResult();

                using (await contended.ConfigureAwait(false))
                {
                    // Now holding depth 1 via the contended path. Nest once more, with a finite timeout
                    // so a deadlock surfaces as a TimeoutException instead of hanging the test run.
                    try
                    {
                        using (await mutex.LockAsync(System.TimeSpan.FromMilliseconds(500)).ConfigureAwait(false)) { }
                    }
                    catch (TimeoutException ex)
                    {
                        loserNestedResult = ex;
                    }
                }
            }

            await Task.WhenAll(WinnerAsync(), LoserAsync()).ConfigureAwait(false);
        }

        Assert.That(
            loserNestedResult,
            Is.TypeOf<TimeoutException>(),
            "Expected the known self-deadlock (nesting after a contended acquisition targets the depth "
            + "the caller already holds). If this now succeeds, the underlying flaw was fixed - flip this "
            + "test to assert successful nested acquisition and update the AsyncLockEx remarks.");
    }

    [Test, CancelAfter(5000)]
    public async Task OrphanedFireAndForgetChildFallsBackToParentDepthInsteadOfCrossContaminating()
    {
        // The exact scenario that motivated the generation-checked fallback: a parent acquires, fires
        // a detached (unawaited) Task.Run child, and returns immediately - releasing depth 0 before the
        // child even runs. The child still inherits ambient depth 1 via ExecutionContext flow into
        // Task.Run, but its "parent" is gone by the time it acquires. It must detect that its remembered
        // depth-0 generation is stale and fall back to contending for depth 0 itself, NOT skip ahead to
        // depth 1 - proven here by DepthsCreated staying at 1 (depth 1 is never touched at all) and the
        // child observing depth 1 (0 + 1 from its own fallback acquisition), not depth 2.
        var mutex = new AsyncLockEx();
        var parentReleased = new TaskCompletionSource();
        int observedDepthAfterChildAcquire = -1;

        Task childTask;
        using (await mutex.LockAsync().ConfigureAwait(false))
        {
            childTask = Task.Run(async () =>
            {
                // Wait until the parent's using block has definitely already exited, so this is not a
                // timing-dependent race - the parent is guaranteed gone by the time LockAsync runs below.
                await parentReleased.Task.ConfigureAwait(false);

                using (await mutex.LockAsync().ConfigureAwait(false))
                {
                    observedDepthAfterChildAcquire = mutex.CurrentDepth;
                }
            });
        }

        parentReleased.SetResult();
        await childTask.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(observedDepthAfterChildAcquire, Is.EqualTo(1), "orphaned child should fall back to depth 0 (bumping to 1), not skip ahead to depth 2");
            Assert.That(mutex.DepthsCreated, Is.EqualTo(1), "depth 1 should never be touched at all if the fallback worked");
        }
    }

    [Test, CancelAfter(5000)]
    public async Task ReleaseThrowsWhenOrphanedDeeperHolderStillLive()
    {
        // The release-time misuse guard: if a fire-and-forget child is STILL holding depth 1 at the
        // exact moment its parent releases depth 0, that's unambiguous proof of the fire-and-forget
        // nesting misuse this type warns against - the release must still happen cleanly, but disposal
        // must throw afterward to surface the bug immediately instead of letting it manifest later as
        // unexplained contention.
        var mutex = new AsyncLockEx();
        var childHasLock = new TaskCompletionSource();
        var childCanRelease = new TaskCompletionSource();

        AsyncLockEx.Releaser outer = await mutex.LockAsync().ConfigureAwait(false);

        Task childTask = Task.Run(async () =>
        {
            using (await mutex.LockAsync().ConfigureAwait(false))
            {
                childHasLock.SetResult();
                await childCanRelease.Task.ConfigureAwait(false);
            }
        });

        await childHasLock.Task.ConfigureAwait(false);

        Assert.Throws<System.InvalidOperationException>(() => outer.Dispose());

        // Let the orphaned child actually finish before checking depth 0 is usable again - otherwise
        // its still-live depth-1 hold would (correctly, if coarsely) trip the same guard a second time.
        // The guard only checks "is something still held one level deeper," not "was it specifically
        // spawned by me" - it can't tell those apart without real per-acquisition ancestry tracking,
        // which this prototype doesn't have. See the type-level remarks.
        childCanRelease.SetResult();
        await childTask.ConfigureAwait(false);

        // The underlying depth-0 lock must have been released despite the throw - prove it's usable
        // again immediately, not wedged.
        using (await mutex.LockAsync().ConfigureAwait(false)) { }
    }
}
