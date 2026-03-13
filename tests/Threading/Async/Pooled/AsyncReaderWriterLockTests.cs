// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1849 // Dispose synchronously blocks

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

/*
 State transition table (LockState encoding and allowed transitions)

 Encoding (stored in _status):
 - Uncontested (0): no holders.
 - Reader (1..MaxReaderCount): number of concurrent readers.
 - UpgradeableReader (MaxReaderCount + 1 .. MaxReaderCount + N): an upgradeable reader is present;
   value = UpgradeableReader + (readerCount - 1). To get readerCount when >= UpgradeableReader: readerCount = status - UpgradeableReader + 1.
 - Writer (-1): exclusive writer holds the lock.
 - UpgradedWriter (-2): the upgradeable reader has upgraded to an exclusive writer.

 Events and transitions (high level):
 - Uncontested + ReaderLock -> Reader (1)
 - Reader + ReaderLock -> Reader (increment)
 - Reader release -> Reader (decrement) or Uncontested when count reaches 0
 - Uncontested + WriterLock -> Writer (-1)
 - Writer release ->
     * If waiting writers exist -> next Writer
     * else if waiting upgradeable readers exist -> UpgradeableReader (+ possible attached readers)
     * else if waiting readers exist -> Reader chain (set reader count)
     * else -> Uncontested
 - Uncontested + UpgradeableReaderLock -> UpgradeableReader (UpgradeableReader + 0)
 - UpgradeableReader + ReaderLock -> UpgradeableReader (increment encoded count)
 - UpgradeableReader.EnterUpgradedWriter:
     * If it is the only holder (no other readers) -> UpgradedWriter (-2)
     * Otherwise enqueued in _waitingUpgradedWriters and will transition to UpgradedWriter when outstanding readers drop to zero (and writers have priority)
 - UpgradedWriter release ->
     * Set status back to UpgradeableReader (or wake readers if no writers waiting) and possibly wake reader chain

 Cancellation semantics:
 - If a waiter is cancelled while queued, it is removed from its WaiterQueue and a TaskCanceledException is set on the waiter.
 - Cancellations do not modify _status unless the waiter had already been granted the lock (in which case disposal/release logic applies).

 Priority rules:
 - Waiting writers (including upgraded writers) are prioritized over new readers to avoid writer starvation.

 Notes / invariants to test:
 - status < 0 implies an exclusive holder (Writer or UpgradedWriter).
 - status == UpgradedWriter implies UpgradeableReader has been converted into exclusive UpgradedWriter.
 - status >= UpgradeableReader implies an upgradeable reader is present and CurrentReaderCount calculation must subtract UpgradeableReader.
*/

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncReaderWriterLockTests
{
    [Theory]
    public async Task SingleReaderAcquiresImmediately(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        var lockTask = rwLock.ReaderLockAsync();
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReadLockHeld, Is.True);
            Assert.That(rwLock.IsWriteLockHeld, Is.False);
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
        }

        Assert.That(rwLock.IsReadLockHeld, Is.False);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task SingleWriterAcquiresImmediately(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        var lockTask = rwLock.WriterLockAsync();
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriteLockHeld, Is.True);
            Assert.That(rwLock.IsReadLockHeld, Is.False);
        }

        Assert.That(rwLock.IsWriteLockHeld, Is.False);
    }

    [Theory]
    public async Task SingleUpgradeableReaderAcquiresImmediately(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        var lockTask = rwLock.UpgradeableReaderLockAsync();
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriteLockHeld, Is.False);
            Assert.That(rwLock.IsReadLockHeld, Is.True);
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
        }

        Assert.That(rwLock.IsWriteLockHeld, Is.False);
    }

    [Theory]
    public async Task MultipleReadersCanAcquireConcurrently(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
            Assert.That(rwLock.IsReadLockHeld, Is.True);
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task MultipleReadersCanDisposeOutOfOrder(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        var lockTask1 = await rwLock.ReaderLockAsync().ConfigureAwait(false);
        var lockTask2 = await rwLock.ReaderLockAsync().ConfigureAwait(false);
        var lockTask3 = await rwLock.ReaderLockAsync().ConfigureAwait(false);

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
        Assert.That(rwLock.IsReadLockHeld, Is.True);

        lockTask1.Dispose();
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(2));
        Assert.That(rwLock.IsReadLockHeld, Is.True);

        lockTask2.Dispose();
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
        Assert.That(rwLock.IsReadLockHeld, Is.True);

        lockTask3.Dispose();
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
        Assert.That(rwLock.IsReadLockHeld, Is.False);

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Theory]
    public async Task WriterBlocksReaders(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> readerTask;
        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            readerTask = rwLock.ReaderLockAsync();
            Assert.That(readerTask.IsCompleted, Is.False);
            Assert.That(rwLock.WaitingReaderCount, Is.EqualTo(1));
        }

        using (await readerTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReadLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Theory]
    public async Task ReadersBlockWriter(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> writerTask;
        using (var readerReleaser = await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            writerTask = rwLock.WriterLockAsync();
            Assert.That(writerTask.IsCompleted, Is.False);
            Assert.That(rwLock.WaitingWriterCount, Is.EqualTo(1));
        }

        using (await writerTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriteLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Theory]
    public async Task WriterPriorityOverNewReaders(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);
        var order = new ConcurrentQueue<string>();

        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            var writerTask = Task.Run(async () => {
                using (await rwLock.WriterLockAsync().ConfigureAwait(false))
                {
                    order.Enqueue("writer");
                }
            });

            await Task.Delay(50).ConfigureAwait(false);

            var readerTask = Task.Run(async () => {
                using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
                {
                    order.Enqueue("reader");
                }
            });

            await Task.Delay(50).ConfigureAwait(false);
        }

        await Task.Delay(100).ConfigureAwait(false);

        var items = order.ToArray();
        Assert.That(items[0], Is.EqualTo("writer"));
        Assert.That(items[1], Is.EqualTo("reader"));

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task WriterReleasesAllPendingReaders(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> r1, r2, r3;

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            r1 = rwLock.ReaderLockAsync();
            r2 = rwLock.ReaderLockAsync();
            r3 = rwLock.ReaderLockAsync();

            Assert.That(r1.IsCompleted, Is.False);
            Assert.That(r2.IsCompleted, Is.False);
            Assert.That(r3.IsCompleted, Is.False);
        }

        using (await r3.ConfigureAwait(false))
        using (await r2.ConfigureAwait(false))
        using (await r1.ConfigureAwait(false))
        {
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task ReaderReleaseCancellationThrows(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            var readerTask = rwLock.ReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.False);

            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await readerTask.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task UpgradedReaderReleaseCancellationThrows(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            var readerTask = rwLock.UpgradeableReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.False);

            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await readerTask.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task WriterReleaseCancellationThrows(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            var writerTask = rwLock.WriterLockAsync(cts.Token);
            Assert.That(writerTask.IsCompleted, Is.False);

            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await writerTask.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task UpgradedWriterReleaseCancellationThrows(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (var upgradeableReleaser = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false))
        using (await upgradeableReleaser.UpgradeToWriterLockAsync().ConfigureAwait(false))
        {
            var writerTask = rwLock.WriterLockAsync(cts.Token);
            Assert.That(writerTask.IsCompleted, Is.False);

            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await writerTask.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task PreCancelledReaderThrows(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var readerTask = rwLock.ReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.True);
            Assert.That(readerTask.IsCanceled, Is.True);
        }
    }

    [Theory]
    public async Task PreCancelledUpgradeableReaderThrows(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var readerTask = rwLock.UpgradeableReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.True);
            Assert.That(readerTask.IsCanceled, Is.True);
        }
    }

    [Theory]
    public async Task PreCancelledWriterThrows(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var writerTask = rwLock.WriterLockAsync(cts.Token);
            Assert.That(writerTask.IsCompleted, Is.True);
            Assert.That(writerTask.IsCanceled, Is.True);
        }
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyWorks()
    {
        var rwLock = new AsyncReaderWriterLock();
        Assert.That(rwLock.RunContinuationAsynchronously, Is.True);

        rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: false);
        Assert.That(rwLock.RunContinuationAsynchronously, Is.False);

        rwLock.RunContinuationAsynchronously = true;
        Assert.That(rwLock.RunContinuationAsynchronously, Is.True);
    }

    [Theory]
    public void ReleaserEquality(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        var releaser1 = rwLock.ReaderLockAsync().AsTask().GetAwaiter().GetResult();
        var releaser2 = rwLock.ReaderLockAsync().AsTask().GetAwaiter().GetResult();

        Assert.That(releaser1.Equals(releaser1), Is.True);
        Assert.That(releaser1 == releaser2, Is.True);
        Assert.That(releaser1 != releaser2, Is.False);
        Assert.That(releaser1.GetHashCode(), Is.EqualTo(releaser2.GetHashCode()));

        releaser1.Dispose();
        releaser2.Dispose();
    }

    [Theory, CancelAfter(5000)]
    public async Task UpgradeableStateTransitions(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        // Acquire an upgradeable reader and another regular reader
        using (var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false))
        {
            ValueTask<AsyncReaderWriterLock.Releaser> upgradeTask;
            using (var regular = await rwLock.ReaderLockAsync().ConfigureAwait(false))
            {
                // Upgrade should wait while the other reader is present
                upgradeTask = upgr.UpgradeToWriterLockAsync();
                Assert.That(upgradeTask.IsCompleted, Is.False);

                // Current state: upgradeable present + one regular reader => count == 2
                Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
                Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(2));

                // Release the regular reader and complete the upgrade
            }

            using (await upgradeTask.ConfigureAwait(false))
            {
                Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.True);
                Assert.That(rwLock.IsWriteLockHeld, Is.True);
            }

            using (Assert.EnterMultipleScope())
            {
                // After disposing upgraded-writer releaser, the upgradeable reader should remain held
                Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
                Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
            }
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Theory]
    public async Task MultipleUpgradedWritersAreSerialized(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> t1;
        ValueTask<AsyncReaderWriterLock.Releaser> t2;

        // Hold writer to force upgradeable readers to queue, dispose immediately after enqueuing
        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            t1 = rwLock.UpgradeableReaderLockAsync();
            t2 = rwLock.UpgradeableReaderLockAsync();

            Assert.That(rwLock.WaitingUpgradeableReaderCount, Is.EqualTo(2));

            // Writer will be disposed at the end of this using-block, allowing queued upgradeables to wake
        }

        using (var upgr1 = await t1.ConfigureAwait(false))
        {
            // First upgradeable reader upgrades to writer
            var upgWriter1 = upgr1.UpgradeToWriterLockAsync();
            Assert.That(upgWriter1.IsCompleted, Is.True);

            using (await upgWriter1.ConfigureAwait(false))
            {
                // while first upgraded writer holds lock, the second upgradeable reader must not have been promoted yet
                Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.True);
            }
        }

        // Now the second upgradeable reader should complete acquisition
        using (var upgr2 = await t2.ConfigureAwait(false))
        {
            var upgWriter2 = upgr2.UpgradeToWriterLockAsync();
            Assert.That(upgWriter2.IsCompleted, Is.True);

            using (await upgWriter2.ConfigureAwait(false))
            {
                Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.True);
            }
        }
        Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.False);
    }

    [Theory]
    public async Task EnterUpgradedWriter_OnNonUpgradeable_Throws(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        // Reader releaser should not allow upgrading
        using (var reader = await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            Assert.Throws<InvalidOperationException>(() => reader.UpgradeToWriterLockAsync());
        }

        // Default (uninitialized) releaser should also throw
        var none = default(AsyncReaderWriterLock.Releaser);
        Assert.Throws<InvalidOperationException>(() => none.UpgradeToWriterLockAsync());
    }

    [Theory]
    public async Task WaitingCountsAndInternalFlagsAfterUpgradeAndCancellation(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        using var writer = await rwLock.WriterLockAsync().ConfigureAwait(false);

        // queue an upgradeable reader with cancellation
        using var cts = new CancellationTokenSource();
        var waiting = rwLock.UpgradeableReaderLockAsync(cts.Token);
        Assert.That(rwLock.WaitingUpgradeableReaderCount, Is.EqualTo(1));

        // cancel and ensure waiter cleaned up
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () => await waiting.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times
        Assert.That(rwLock.InternalUpgradeableReaderWaiterInUse, Is.False);
    }

    [Theory]
    public async Task EnterUpgradedWriterCancellation_WhenWaiting(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        // Acquire upgradeable reader and another regular reader to block upgrade
        using var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync().ConfigureAwait(false);

        using var cts = new CancellationTokenSource();
        var upgradeAttempt = upgr.UpgradeToWriterLockAsync(cts.Token);
        Assert.That(upgradeAttempt.IsCompleted, Is.False);

        // cancel the upgrade attempt and ensure it is removed from waiter queue
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () => await upgradeAttempt.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(rwLock.InternalUpgradedWriterWaiterInUse, Is.False);

        // clean up other reader and ensure state is consistent: only upgradeable reader remains
        otherReader.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
    }

    [Theory]
    public async Task EnterUpgradedWriter_OnUpgradedReleaser_Throws(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        // Acquire upgradeable reader and upgrade to writer
        using var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);
        using (var upgWriter = await upgr.UpgradeToWriterLockAsync().ConfigureAwait(false))
        {
            // The returned releaser is an UpgradedWriter and must not be allowed to call EnterUpgradedWriterLockAsync()
            Assert.Throws<InvalidOperationException>(() => upgWriter.UpgradeToWriterLockAsync());
        }

        // clean up
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
    }

    [Theory]
    public async Task PreCancelledEnterUpgradedWriterThrows(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);
        var task = upgr.UpgradeToWriterLockAsync(cts.Token);
        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.False);
        Assert.Throws<InvalidOperationException>(() => upgr.Dispose());
    }

    [Theory]
    public async Task CancelWaitingUpgradedWriter_CleansUp(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        // Acquire upgradeable reader and another regular reader to block upgrade
        using var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync().ConfigureAwait(false);

        using var cts = new CancellationTokenSource();
        var upgradeAttempt = upgr.UpgradeToWriterLockAsync(cts.Token);
        Assert.That(upgradeAttempt.IsCompleted, Is.False);

        // cancel the upgrade attempt and ensure it is removed from waiter queue
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () => await upgradeAttempt.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(rwLock.InternalUpgradedWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));

        // clean up other reader and ensure state is consistent: only upgradeable reader remains
        otherReader.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
    }

    [Theory]
    public async Task ReaderWhileUpgradeableWaiting_BlockedWhenWriterWaiting(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        // Hold a writer briefly to force the upgradeable request to queue behind it
        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableTask1;
        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableTask2;
        ValueTask<AsyncReaderWriterLock.Releaser> r1Task;
        ValueTask<AsyncReaderWriterLock.Releaser> r2Task;

        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            upgradeableTask1 = rwLock.UpgradeableReaderLockAsync();
            Assert.That(upgradeableTask1.IsCompleted, Is.True);

            upgradeableTask2 = rwLock.UpgradeableReaderLockAsync();
            Assert.That(upgradeableTask2.IsCompleted, Is.False);

            r1Task = rwLock.ReaderLockAsync();
            Assert.That(r1Task.IsCompleted, Is.True);

            r2Task = rwLock.ReaderLockAsync();
            Assert.That(r2Task.IsCompleted, Is.True);
        }

        // After writer is released both queued upgradeable and reader should complete (upgradeable first)
        using (var upgr1 = await upgradeableTask1.ConfigureAwait(false)) { }
        using var upgr2 = await upgradeableTask2.ConfigureAwait(false);
        using var r1 = await r1Task.ConfigureAwait(false);
        using var r2 = await r2Task.ConfigureAwait(false);
    }

    [Theory]
    public async Task NewReadersBlockedDuringUpgradedWriterQueue(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);

        using var upgr = await rwLock.UpgradeableReaderLockAsync().ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync().ConfigureAwait(false);

        // Start upgrade which will be queued because otherReader is present
        var upgradeAttempt = upgr.UpgradeToWriterLockAsync();
        Assert.That(upgradeAttempt.IsCompleted, Is.False);

        // New reader attempts should be blocked while an upgraded writer is waiting
        var rNew = rwLock.ReaderLockAsync();
        Assert.That(rNew.IsCompleted, Is.False);

        // clean up: release other reader so upgrade proceeds, then ensure rNew completes after upgrade releases
        otherReader.Dispose();
        using (await upgradeAttempt.ConfigureAwait(false)) { }
        var r = await rNew.ConfigureAwait(false);
        r.Dispose();
    }

    [Theory]
    public async Task CancelWaitingUpgradeDoesNotLoseWake(bool runContinuationAsynchronously)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> t1;
        ValueTask<AsyncReaderWriterLock.Releaser> t2;
        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            t1 = rwLock.UpgradeableReaderLockAsync();
            using var cts = new CancellationTokenSource();
            t2 = rwLock.UpgradeableReaderLockAsync(cts.Token);

            // schedule cancellation shortly after writer is released
            _ = Task.Run(async () => { await Task.Delay(10).ConfigureAwait(false); cts.Cancel(); });
        }

        // t1 should be granted and t2 should be canceled; ensure internal waiters cleared and pool drained
        var upgr1 = await t1.ConfigureAwait(false);
        upgr1.Dispose();

#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () => await t2.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times

        Assert.That(rwLock.InternalUpgradeableReaderWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Theory]
    public void DoubleDisposeReleaser_IsNoop(bool runContinuationAsynchronously)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: runContinuationAsynchronously);
        var releaser = rwLock.ReaderLockAsync().AsTask().GetAwaiter().GetResult();
        releaser.Dispose();
        // second dispose should be okay and not throw
        releaser.Dispose();
    }
}

