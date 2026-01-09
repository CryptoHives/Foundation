// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1849 // Dispose synchronously blocks

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncReaderWriterLockUnitTests
{
    [Test]
    public async Task SingleReaderAcquiresImmediately()
    {
        var rwLock = new AsyncReaderWriterLock();

        var lockTask = rwLock.ReaderLockAsync();
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReaderLockHeld, Is.True);
            Assert.That(rwLock.IsWriterLockHeld, Is.False);
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(1));
        }

        Assert.That(rwLock.IsReaderLockHeld, Is.False);
        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    public async Task SingleWriterAcquiresImmediately()
    {
        var rwLock = new AsyncReaderWriterLock();

        var lockTask = rwLock.WriterLockAsync();
        Assert.That(lockTask.IsCompleted, Is.True);

        using (await lockTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriterLockHeld, Is.True);
            Assert.That(rwLock.IsReaderLockHeld, Is.False);
        }

        Assert.That(rwLock.IsWriterLockHeld, Is.False);
    }

    [Test]
    public async Task MultipleReadersCanAcquireConcurrently()
    {
        var rwLock = new AsyncReaderWriterLock();

        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        using (await rwLock.ReaderLockAsync().ConfigureAwait(false))
        {
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
            Assert.That(rwLock.IsReaderLockHeld, Is.True);
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));
    }

    [Test]
    public async Task WriterBlocksReaders()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);

        var writerReleaser = await rwLock.WriterLockAsync().ConfigureAwait(false);

        var readerTask = rwLock.ReaderLockAsync();
        Assert.That(readerTask.IsCompleted, Is.False);

        Assert.That(rwLock.WaitingReaderCount, Is.EqualTo(1));

        writerReleaser.Dispose();

        using (await readerTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsReaderLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Test]
    public async Task ReadersBlockWriter()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);

        var readerReleaser = await rwLock.ReaderLockAsync().ConfigureAwait(false);

        var writerTask = rwLock.WriterLockAsync();
        Assert.That(writerTask.IsCompleted, Is.False);

        Assert.That(rwLock.WaitingWriterCount, Is.EqualTo(1));

        readerReleaser.Dispose();

        using (await writerTask.ConfigureAwait(false))
        {
            Assert.That(rwLock.IsWriterLockHeld, Is.True);
        }

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
    }

    [Test]
    public async Task WriterPriorityOverNewReaders()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);
        var order = new System.Collections.Concurrent.ConcurrentQueue<string>();

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

    [Test]
    public async Task WriterReleasesAllPendingReaders()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);

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

        using (await r1.ConfigureAwait(false))
        using (await r2.ConfigureAwait(false))
        using (await r3.ConfigureAwait(false))
        {
            Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(3));
        }

        Assert.That(rwLock.CurrentReaderCount, Is.EqualTo(0));

        Assert.That(rwLock.InternalReaderWaiterInUse, Is.False);
        Assert.That(rwLock.InternalWriterWaiterInUse, Is.False);
        Assert.That(pool.ActiveCount, Is.EqualTo(0));
    }

    [Test]
    public async Task ReaderReleaseCancellationThrows()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);
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

    [Test]
    public async Task WriterReleaseCancellationThrows()
    {
        var pool = new TestObjectPool<AsyncReaderWriterLock.Releaser>();
        var rwLock = new AsyncReaderWriterLock(pool: pool);
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

    [Test]
    public async Task PreCancelledReaderThrows()
    {
        var rwLock = new AsyncReaderWriterLock();
        using var cts = new CancellationTokenSource();

        using (await rwLock.WriterLockAsync().ConfigureAwait(false))
        {
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

            var readerTask = rwLock.ReaderLockAsync(cts.Token);
            Assert.That(readerTask.IsCompleted, Is.True);
            Assert.That(readerTask.IsCanceled, Is.True);
        }
    }

    [Test]
    public async Task PreCancelledWriterThrows()
    {
        var rwLock = new AsyncReaderWriterLock();
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

    [Test]
    public void ReleaserEquality()
    {
        var rwLock = new AsyncReaderWriterLock();
        var releaser1 = rwLock.ReaderLockAsync().AsTask().GetAwaiter().GetResult();
        var releaser2 = rwLock.ReaderLockAsync().AsTask().GetAwaiter().GetResult();

        Assert.That(releaser1.Equals(releaser1), Is.True);
        Assert.That(releaser1 == releaser2, Is.True);
        Assert.That(releaser1 != releaser2, Is.False);
        Assert.That(releaser1.GetHashCode(), Is.EqualTo(releaser2.GetHashCode()));

        releaser1.Dispose();
        releaser2.Dispose();
    }
}
