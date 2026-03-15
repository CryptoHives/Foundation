// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1849 // Dispose synchronously blocks

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Reflection;
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
[TestFixtureSource(nameof(RunContinuationAsyncArgs))]
[Parallelizable(ParallelScope.All)]
public class AsyncReaderWriterLockTests
{
    public const int CancelAfterMS = 5000;
    private readonly bool RunContinuationAsynchronously;

    /// <summary>
    /// Stream implementations to test.
    /// </summary>
    public static readonly object[] RunContinuationAsyncArgs =
    [
        new object[] { "RunContSync" },
        new object[] { "RunContAsync" }
    ];

    public AsyncReaderWriterLockTests(string runContinuationAsync)
    {
        RunContinuationAsynchronously = runContinuationAsync == "RunContAsync";
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task SingleReaderAcquiresImmediately(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        var lockTask = rwLock.ReaderLockAsync(ct);
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task SingleWriterAcquiresImmediately(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        var lockTask = rwLock.WriterLockAsync(ct);
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriteLockHeld, Is.True);
            Assert.That(rwLock.IsReadLockHeld, Is.False);
        }

        Assert.That(rwLock.IsWriteLockHeld, Is.False);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task SingleUpgradeableReaderAcquiresImmediately(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        var lockTask = rwLock.UpgradeableReaderLockAsync(ct);
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriteLockHeld, Is.False);
            Assert.That(rwLock.IsReadLockHeld, Is.True);
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
        }

        Assert.That(rwLock.IsWriteLockHeld, Is.False);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task MultipleReadersCanAcquireConcurrently(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        {
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
            Assert.That(rwLock.IsReadLockHeld, Is.True);
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task MultipleReadersCanDisposeOutOfOrder(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        var lockTask1 = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);
        var lockTask2 = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);
        var lockTask3 = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);

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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterBlocksReaders(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> readerTask;
        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            readerTask = rwLock.ReaderLockAsync(ct);
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterBlocksUpgradeableReaders(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableReaderTask;
        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            upgradeableReaderTask = rwLock.UpgradeableReaderLockAsync(ct);
            Assert.That(upgradeableReaderTask.IsCompleted, Is.False);
            Assert.That(rwLock.WaitingUpgradeableReaderCount, Is.EqualTo(1));
        }

        using (await upgradeableReaderTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReadLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task UpgradeableReaderBlocksUpgradeableReaders(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableReaderTask;
        using (await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
        {
            upgradeableReaderTask = rwLock.UpgradeableReaderLockAsync(ct);
            Assert.That(upgradeableReaderTask.IsCompleted, Is.False);
            Assert.That(rwLock.WaitingUpgradeableReaderCount, Is.EqualTo(1));
        }

        using (await upgradeableReaderTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReadLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReadersBlockWriter(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> writerTask;
        using (var readerReleaser = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        {
            writerTask = rwLock.WriterLockAsync(ct);
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterPriorityOverNewReaders(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);
        var order = new ConcurrentQueue<string>();

        using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        {
            var writerTask = Task.Run(async () => {
                using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
                {
                    order.Enqueue("writer");
                }
            }, ct);

            await Task.Delay(50, ct).ConfigureAwait(false);

            var readerTask = Task.Run(async () => {
                using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
                {
                    order.Enqueue("reader");
                }
            }, ct);

            await Task.Delay(50, ct).ConfigureAwait(false);
        }

        await Task.Delay(100, ct).ConfigureAwait(false);

        var items = order.ToArray();
        Assert.That(items[0], Is.EqualTo("writer"));
        Assert.That(items[1], Is.EqualTo("reader"));

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterReleasesAllPendingReaders(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> r1, r2, r3;

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            r1 = rwLock.ReaderLockAsync(ct);
            r2 = rwLock.ReaderLockAsync(ct);
            r3 = rwLock.ReaderLockAsync(ct);

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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReaderReleaseCancellationThrows(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task UpgradedReaderReleaseCancellationThrows(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterReleaseCancellationThrows(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task UpgradedWriterReleaseCancellationThrows(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);
        using var cts = new CancellationTokenSource();

        using (var upgradeableReleaser = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
        using (await upgradeableReleaser.UpgradeToWriterLockAsync(ct).ConfigureAwait(false))
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledReaderThrows(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var readerTask = rwLock.ReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.True);
            Assert.That(readerTask.IsCanceled, Is.True);
        }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledUpgradeableReaderThrows(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var readerTask = rwLock.UpgradeableReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.True);
            Assert.That(readerTask.IsCanceled, Is.True);
        }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledWriterThrows(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var writerTask = rwLock.WriterLockAsync(cts.Token);
            Assert.That(writerTask.IsCompleted, Is.True);
            Assert.That(writerTask.IsCanceled, Is.True);
        }
    }

    [Test, CancelAfter(CancelAfterMS)]
    public void RunContinuationAsynchronouslyPropertyWorks(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock();
        Assert.That(rwLock.RunContinuationAsynchronously, Is.True);

        rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: false);
        Assert.That(rwLock.RunContinuationAsynchronously, Is.False);

        rwLock.RunContinuationAsynchronously = true;
        Assert.That(rwLock.RunContinuationAsynchronously, Is.True);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public void ReleaserEquality(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        var releaser1 = rwLock.ReaderLockAsync(ct).AsTask().GetAwaiter().GetResult();
        var releaser2 = rwLock.ReaderLockAsync(ct).AsTask().GetAwaiter().GetResult();

        Assert.That(releaser1.Equals(releaser1), Is.True);
        Assert.That(releaser1 == releaser2, Is.True);
        Assert.That(releaser1 != releaser2, Is.False);
        Assert.That(releaser1.GetHashCode(), Is.EqualTo(releaser2.GetHashCode()));

        releaser1.Dispose();
        releaser2.Dispose();
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task UpgradeableStateTransitions(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        // Acquire an upgradeable reader and another regular reader
        using (var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
        {
            ValueTask<AsyncReaderWriterLock.Releaser> upgradeTask;
            using (var regular = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
            {
                // Upgrade should wait while the other reader is present
                upgradeTask = upgr.UpgradeToWriterLockAsync(ct);
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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task MultipleUpgradedWritersAreSerialized(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        ValueTask<AsyncReaderWriterLock.Releaser> t1;
        ValueTask<AsyncReaderWriterLock.Releaser> t2;

        // Hold writer to force upgradeable readers to queue, dispose immediately after enqueuing
        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            t1 = rwLock.UpgradeableReaderLockAsync(ct);
            t2 = rwLock.UpgradeableReaderLockAsync(ct);

            Assert.That(rwLock.WaitingUpgradeableReaderCount, Is.EqualTo(2));

            // Writer will be disposed at the end of this using-block, allowing queued upgradeables to wake
        }

        using (var upgr1 = await t1.ConfigureAwait(false))
        {
            // First upgradeable reader upgrades to writer
            var upgWriter1 = upgr1.UpgradeToWriterLockAsync(ct);
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
            var upgWriter2 = upgr2.UpgradeToWriterLockAsync(ct);
            Assert.That(upgWriter2.IsCompleted, Is.True);

            using (await upgWriter2.ConfigureAwait(false))
            {
                Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.True);
            }
        }
        Assert.That(rwLock.IsUpgradedWriterLockHeld, Is.False);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task EnterUpgradedWriter_OnNonUpgradeable_Throws(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Reader releaser should not allow upgrading
        using (var reader = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        {
            Assert.Throws<InvalidOperationException>(() => reader.UpgradeToWriterLockAsync());
        }

        // Default (uninitialized) releaser should also throw
        var none = default(AsyncReaderWriterLock.Releaser);
        Assert.Throws<InvalidOperationException>(() => none.UpgradeToWriterLockAsync());
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WaitingCountsAndInternalFlagsAfterUpgradeAndCancellation(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        using var writer = await rwLock.WriterLockAsync(ct).ConfigureAwait(false);

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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task EnterUpgradedWriterCancellation_WhenWaiting(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        // Acquire upgradeable reader and another regular reader to block upgrade
        using var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);

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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task EnterUpgradedWriter_OnUpgradedReleaser_Throws(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and upgrade to writer
        using var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        using (var upgWriter = await upgr.UpgradeToWriterLockAsync(ct).ConfigureAwait(false))
        {
            // The returned releaser is an UpgradedWriter and must not be allowed to call EnterUpgradedWriterLockAsync()
            Assert.Throws<InvalidOperationException>(() => upgWriter.UpgradeToWriterLockAsync());
        }

        // clean up
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.True);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledEnterUpgradedWriterThrows(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        AsyncReaderWriterLock.Releaser releaser;
        using (var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
        {
            var writer = upgr.UpgradeToWriterLockAsync(cts.Token);
            Assert.That(writer.IsCompleted, Is.True);
            Assert.That(writer.IsCanceled, Is.False);
            releaser = await writer.ConfigureAwait(false);
        }
        releaser.Dispose();
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task CancelWaitingUpgradedWriter_CleansUp(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        // Acquire upgradeable reader and another regular reader to block upgrade
        using var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);

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

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReaderWhileUpgradeableWaiting_BlockedWhenWriterWaiting(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Hold a writer briefly to force the upgradeable request to queue behind it
        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableTask1;
        ValueTask<AsyncReaderWriterLock.Releaser> upgradeableTask2;
        ValueTask<AsyncReaderWriterLock.Releaser> r1Task;
        ValueTask<AsyncReaderWriterLock.Releaser> r2Task;

        using (await rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        {
            upgradeableTask1 = rwLock.UpgradeableReaderLockAsync(ct);
            Assert.That(upgradeableTask1.IsCompleted, Is.True);

            upgradeableTask2 = rwLock.UpgradeableReaderLockAsync(ct);
            Assert.That(upgradeableTask2.IsCompleted, Is.False);

            r1Task = rwLock.ReaderLockAsync(ct);
            Assert.That(r1Task.IsCompleted, Is.True);

            r2Task = rwLock.ReaderLockAsync(ct);
            Assert.That(r2Task.IsCompleted, Is.True);
        }

        // After writer is released both queued upgradeable and reader should complete (upgradeable first)
        using (var upgr1 = await upgradeableTask1.ConfigureAwait(false)) { }
        using var upgr2 = await upgradeableTask2.ConfigureAwait(false);
        using var r1 = await r1Task.ConfigureAwait(false);
        using var r2 = await r2Task.ConfigureAwait(false);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task NewReadersBlockedDuringUpgradedWriterQueue(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        using var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var otherReader = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);

        // Start upgrade which will be queued because otherReader is present
        var upgradeAttempt = upgr.UpgradeToWriterLockAsync(ct);
        Assert.That(upgradeAttempt.IsCompleted, Is.False);

        // New reader attempts should be blocked while an upgraded writer is waiting
        var rNew = rwLock.ReaderLockAsync(ct);
        Assert.That(rNew.IsCompleted, Is.False);

        // clean up: release other reader so upgrade proceeds, then ensure rNew completes after upgrade releases
        otherReader.Dispose();
        using (await upgradeAttempt.ConfigureAwait(false)) { }
        var r = await rNew.ConfigureAwait(false);
        r.Dispose();
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task CancelWaitingUpgradeDoesNotLoseWake(CancellationToken ct)
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously, pool: pool);

        using var cts = new CancellationTokenSource();
        ValueTask<AsyncReaderWriterLock.Releaser> t1;
        ValueTask<AsyncReaderWriterLock.Releaser> t2;
        using (await rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        {
            t1 = rwLock.UpgradeableReaderLockAsync(ct);
            t2 = rwLock.UpgradeableReaderLockAsync(cts.Token);

            // schedule cancellation shortly after writer is released
            _ = Task.Run(async () => { await Task.Delay(10, ct).ConfigureAwait(false); cts.Cancel(); }, ct);
        }

        // t1 should be granted and t2 should be canceled; ensure internal waiters cleared and pool drained
        using var upgr1 = await t1.ConfigureAwait(false);

#pragma warning disable CHT001 // ValueTask awaited multiple times
        Assert.ThrowsAsync<TaskCanceledException>(async () => await t2.ConfigureAwait(false));
#pragma warning restore CHT001 // ValueTask awaited multiple times


        Assert.That(rwLock.InternalUpgradeableReaderWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task DisposeUpgradeableReaderWhileUpgradedWriterRuns(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and upgrade to writer immediately (no other readers)
        var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var upgWriter = await upgr.UpgradeToWriterLockAsync(ct).ConfigureAwait(false);

        // While upgraded writer is active, dispose the upgradeable reader releaser
        upgr.Dispose();

        // The upgradeable reader should no longer be considered held while upgraded writer runs
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);

        // Release upgraded writer and ensure final state has no upgradeable reader and no readers
        upgWriter.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task SerializedUpgradedWriterHandoffsDisposeBetweenRuns(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and enqueue two upgrades
        var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var t1 = upgr.UpgradeToWriterLockAsync(ct);
        var t2 = upgr.UpgradeToWriterLockAsync(ct);

        // first upgrade should be immediate
        Assert.That(t1.IsCompleted, Is.True);
        var upg1 = await t1.ConfigureAwait(false);

        // while first upgraded writer is active, dispose the upgradeable reader
        upgr.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);

        // release first upgraded writer, allowing second to proceed
        upg1.Dispose();

        // the second upgraded writer should be granted without an upgradeable reader present
        var upg2 = await t2.ConfigureAwait(false);
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);

        upg2.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task SerializedUpgradedWriterBlockingReaderHandoffsDisposeBetweenRuns(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and enqueue two upgrades
        var reader1 = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);
        var upgr = await rwLock.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var reader2 = await rwLock.ReaderLockAsync(ct).ConfigureAwait(false);
        var t1 = upgr.UpgradeToWriterLockAsync(ct);
        var t2 = upgr.UpgradeToWriterLockAsync(ct);

        reader1.Dispose();

        // while first upgraded writer is active, dispose the upgradeable reader
        upgr.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);

        reader2.Dispose();

        // first upgrade should be immediate
        Assert.That(t1.IsCompleted, Is.True);
        var upg1 = await t1.ConfigureAwait(false);

        // release first upgraded writer, allowing second to proceed
        upg1.Dispose();

        // the second upgraded writer should be granted without an upgradeable reader present
        var upg2 = await t2.ConfigureAwait(false);
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);

        upg2.Dispose();
        Assert.That(rwLock.IsUpgradeableReadLockHeld, Is.False);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task Releaser_EqualsAndHashCode(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var r = await rw.ReaderLockAsync(ct).ConfigureAwait(false);
        object boxed = r;
        Assert.That(r.Equals(boxed), Is.True);
        var copy = r;
        Assert.That(copy.Equals(r), Is.True);
        Assert.That(r.GetHashCode(), Is.EqualTo(copy.GetHashCode()));
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledUpgradeToWriter_IsCanceled(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        using var other = await rw.ReaderLockAsync(ct).ConfigureAwait(false);

        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var vt = upgr.UpgradeToWriterLockAsync(cts.Token);
        Assert.That(vt.IsCompleted, Is.True);
#pragma warning disable CHT001
        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT001
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledWriter_IsCanceled(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var r = await rw.ReaderLockAsync(ct).ConfigureAwait(false);

        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var vt = rw.WriterLockAsync(cts.Token);
        Assert.That(vt.IsCompleted, Is.True);
#pragma warning disable CHT001
        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT001
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task PreCancelledUpgradeableReader_IsCanceled(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var writer = await rw.WriterLockAsync(ct).ConfigureAwait(false);

        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var vt = rw.UpgradeableReaderLockAsync(cts.Token);
        Assert.That(vt.IsCompleted, Is.True);
#pragma warning disable CHT001
        Assert.ThrowsAsync<TaskCanceledException>(async () => await vt.ConfigureAwait(false));
#pragma warning restore CHT001
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WaitingUpgradedWritersCount_IncrementsWhenQueued(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        using var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var other = await rw.ReaderLockAsync(ct).ConfigureAwait(false);

        var attempt = upgr.UpgradeToWriterLockAsync(ct);
        Assert.That(attempt.IsCompleted, Is.False);
        Assert.That(rw.WaitingUpgradedWritersCount, Is.EqualTo(1));

        other.Dispose();
        using (await attempt.ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseUpgradedWriter_WakesUpgradeableWhenWithoutReader(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var upgWriter = await upgr.UpgradeToWriterLockAsync(ct).ConfigureAwait(false);

        // queue a waiting upgradeable reader while upgraded writer holds
        var tWaiting = rw.UpgradeableReaderLockAsync(ct);

        // dispose upgradeable releaser to move to UpgradedWriterWithoutReader
        upgr.Dispose();
        Assert.That(rw.IsUpgradeableReadLockHeld, Is.False);

        // release upgraded writer which should wake the waiting upgradeable reader
        upgWriter.Dispose();
        using var w = await tWaiting.ConfigureAwait(false);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseUpgradedWriter_WakesWriterWhenWaitingAndWithoutReader(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var upgWriter = await upgr.UpgradeToWriterLockAsync(ct).ConfigureAwait(false);

        // queue a regular writer while upgraded writer holds
        var writerWaiting = rw.WriterLockAsync(ct);

        // dispose upgradeable to set UpgradedWriterWithoutReader
        upgr.Dispose();
        upgWriter.Dispose();

        using (await writerWaiting.ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task WriterLock_FastPathCompletes(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        var vt = rw.WriterLockAsync(ct);
        Assert.That(vt.IsCompleted, Is.True);
        using (await vt.ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseReader_WakesQueuedReaders(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Hold writer so readers queue
        using (await rw.WriterLockAsync(ct).ConfigureAwait(false))
        {
            var r1 = rw.ReaderLockAsync(ct);
            var r2 = rw.ReaderLockAsync(ct);
            Assert.That(r1.IsCompleted, Is.False);
            Assert.That(r2.IsCompleted, Is.False);

            // release writer at end of using - readers should be granted
            await Task.Delay(1, ct).ConfigureAwait(false);
        }

        using (await rw.ReaderLockAsync(ct).ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task NonCancelableWaiter_RegistersDefault(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Hold a writer so the next writer request will queue with a non-cancelable token
        ValueTask<AsyncReaderWriterLock.Releaser> vt;
        using (await rw.WriterLockAsync(ct).ConfigureAwait(false))
        {
            vt = rw.WriterLockAsync(CancellationToken.None);
            Assert.That(vt.IsCompleted, Is.False);
        }

        // cancel not possible; complete the queued writer by releasing the held one
        using var w = await vt.ConfigureAwait(false);
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseReader_CompareExchangeFallthroughScenario(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Scenario: have upgradeable reader + extra reader so that ReleaseReader tries to promote upgraded writer
        using var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var r = await rw.ReaderLockAsync(ct).ConfigureAwait(false);

        // queue an upgraded writer which will wait due to additional reader
        var upgradeAttempt = upgr.UpgradeToWriterLockAsync(ct);
        Assert.That(upgradeAttempt.IsCompleted, Is.False);
        Assert.That(rw.WaitingUpgradedWritersCount, Is.EqualTo(1));

        // Now dispose the extra reader to allow the upgrade to proceed and exercise the CompareExchange path
        r.Dispose();
        using (await upgradeAttempt.ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseUpgradedWriter_WriterWakeWhenWithoutReaderScenario(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and upgrade to writer
        var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false);
        var upgWriter = await upgr.UpgradeToWriterLockAsync(ct).ConfigureAwait(false);

        // While upgraded writer holds, queue a regular writer and dispose the upgradeable to enter WithoutReader state
        var writerWaiting = rw.WriterLockAsync(ct);
        upgr.Dispose();

        // Now release upgraded writer and ensure a waiting writer is granted
        upgWriter.Dispose();
        using (await writerWaiting.ConfigureAwait(false)) { }
    }

    [Test]
    [CancelAfter(CancelAfterMS)]
    public async Task ReleaseUpgradeableReader_CompareExchangeFallback(CancellationToken ct)
    {
        var rw = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);

        // Acquire upgradeable reader and queue an upgraded writer, then a waiting upgradeable reader behind it
        ValueTask<AsyncReaderWriterLock.Releaser> waitingUpgr;
        using (var upgr = await rw.UpgradeableReaderLockAsync(ct).ConfigureAwait(false))
        {
            var upgAttempt = upgr.UpgradeToWriterLockAsync(ct);
            Assert.That(upgAttempt.IsCompleted, Is.True);

            using (await upgAttempt.ConfigureAwait(false)) { }

            // Queue another upgradeable reader which should wait
            waitingUpgr = rw.UpgradeableReaderLockAsync(ct);
            Assert.That(waitingUpgr.IsCompleted, Is.False);

            // Dispose the original upgradeable reader to exercise fallback in ReleaseUpgradeableReader
        }

        // The waiting upgradeable should be granted now
        using var w = await waitingUpgr.ConfigureAwait(false);
    }

#if TODO
    [Test][ CancelAfter(CancelAfterMS)]
    public void DoubleDisposeReleaser_IsNoop(CancellationToken ct)
    {
        var rwLock = new AsyncReaderWriterLock(runContinuationAsynchronously: RunContinuationAsynchronously);
        var releaser = rwLock.ReaderLockAsync(ct).AsTask().GetAwaiter().GetResult();
        releaser.Dispose();
        // second dispose should be okay and not throw
        releaser.Dispose();
    }
#endif

    [Test]
    public void TryReset_SucceedsWhenNotInUse()
    {
        var ev = new AsyncReaderWriterLock();

        Assert.That(ev.CurrentReaderCount, Is.Zero);
        Assert.That(ev.WaitingReaderCount, Is.Zero);
        Assert.That(ev.WaitingWriterCount, Is.Zero);
        Assert.That(ev.WaitingUpgradeableReaderCount, Is.Zero);
        Assert.That(ev.WaitingUpgradedWritersCount, Is.Zero);
        Assert.That(ev.RunContinuationAsynchronously, Is.True);

        bool reset = ev.TryReset();
        Assert.That(reset, Is.True);

        Assert.That(ev.CurrentReaderCount, Is.Zero);
        Assert.That(ev.WaitingReaderCount, Is.Zero);
        Assert.That(ev.WaitingWriterCount, Is.Zero);
        Assert.That(ev.WaitingUpgradeableReaderCount, Is.Zero);
        Assert.That(ev.WaitingUpgradedWritersCount, Is.Zero);
        Assert.That(ev.RunContinuationAsynchronously, Is.True);
    }

    [Test]
    public void TryReset_FailsWhenLocked()
    {
        var ev = new AsyncReaderWriterLock();

        // Acquire internal mutex via reflection and hold it to simulate being in-use
        var fld = typeof(AsyncReaderWriterLock).GetField("_mutex", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.That(fld, Is.Not.Null, "_mutex field not found");

        var mutex = fld.GetValue(ev);
        Assert.That(mutex, Is.Not.Null);

        // Enter the mutex to block TryReset
        Monitor.Enter(mutex);
        try
        {
            bool reset = ev.TryReset();
            Assert.That(reset, Is.False);
        }
        finally
        {
            Monitor.Exit(mutex);
        }
    }
}

