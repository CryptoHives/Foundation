// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ValueTask.Preserve"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ValueTaskPreserveTests
{
    [Test]
    public async Task PreserveCompletedValueTaskReturnsCompletedTask()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.True);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreservePendingValueTaskReturnsTask()
    {
        var tcs = new TaskCompletionSource<bool>();
        ValueTask vt = new(tcs.Task);
        ValueTask preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(true);
        await preserved.ConfigureAwait(false);
        Assert.That(preserved.IsCompleted, Is.True);
    }

    [Test]
    public async Task PreserveCanBeAwaitedMultipleTimes()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();

        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveGenericCompletedValueTaskReturnsCompletedTask()
    {
        ValueTask<int> vt = new(42);
        ValueTask<int> preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.True);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public async Task PreserveGenericPendingValueTaskReturnsTask()
    {
        var tcs = new TaskCompletionSource<int>();
        ValueTask<int> vt = new(tcs.Task);
        ValueTask<int> preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(123);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public async Task PreserveGenericCanBeAwaitedMultipleTimes()
    {
        ValueTask<int> vt = new(99);
        ValueTask<int> preserved = vt.Preserve();

        int r1 = await preserved.ConfigureAwait(false);
        int r2 = await preserved.ConfigureAwait(false);
        int r3 = await preserved.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(r1, Is.EqualTo(99));
            Assert.That(r2, Is.EqualTo(99));
            Assert.That(r3, Is.EqualTo(99));
        }
    }

    [Test, CancelAfter(1000)]
    public async Task PreservePooledSourceCompletedCanBeAwaitedMultipleTimes()
    {
        var pool = new TestObjectPool<int>();
        PooledManualResetValueTaskSource<int> source = pool.GetPooledWaiter(null);
        source.SetResult(42);

        var vt = new ValueTask<int>(source, source.Version);
        ValueTask<int> preserved = vt.Preserve();

        // should not throw when awaited multiple times
        int r1 = await preserved.ConfigureAwait(false);
        int r2 = await preserved.ConfigureAwait(false);
        int r3 = await preserved.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(r1, Is.EqualTo(42));
            Assert.That(r2, Is.EqualTo(42));
            Assert.That(r3, Is.EqualTo(42));
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task PreservePooledSourcePendingCanBeAwaitedMultipleTimes()
    {
        var pool = new TestObjectPool<int>();
        PooledManualResetValueTaskSource<int> source = pool.GetPooledWaiter(null);

        var vt = new ValueTask<int>(source, source.Version);
        ValueTask<int> preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        // Complete the source
        source.SetResult(99);

        // should not throw when awaited multiple times
        int r1 = await preserved.ConfigureAwait(false);
        int r2 = await preserved.ConfigureAwait(false);
        int r3 = await preserved.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(r1, Is.EqualTo(99));
            Assert.That(r2, Is.EqualTo(99));
            Assert.That(r3, Is.EqualTo(99));
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task PreservePooledSourceDoesNotThrowAfterPoolReturn()
    {
        var pool = new TestObjectPool<string>();
        PooledManualResetValueTaskSource<string> source = pool.GetPooledWaiter(null);

        var vt = new ValueTask<string>(source, source.Version);
        ValueTask<string> preserved = vt.Preserve();

        // Complete the source - this will return it to the pool after GetResult
        source.SetResult("hello");

        // first await consumes the original and returns to pool
        string r1 = await preserved.ConfigureAwait(false);

        // subsequent awaits should still work because Preserve() captured the result
        string r2 = await preserved.ConfigureAwait(false);
        string r3 = await preserved.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(r1, Is.EqualTo("hello"));
            Assert.That(r2, Is.EqualTo("hello"));
            Assert.That(r3, Is.EqualTo("hello"));
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task PreservePooledSourceWithExceptionCanBeAwaitedMultipleTimes()
    {
        var pool = new TestObjectPool<int>();
        PooledManualResetValueTaskSource<int> source = pool.GetPooledWaiter(null);

        var vt = new ValueTask<int>(source, source.Version);
        ValueTask<int> preserved = vt.Preserve();

        // Set exception
        source.SetException(new InvalidOperationException("Test exception"));

        // should throw the same exception each time
        var ex1 = Assert.ThrowsAsync<InvalidOperationException>(async () => await preserved.ConfigureAwait(false));
        var ex2 = Assert.ThrowsAsync<InvalidOperationException>(async () => await preserved.ConfigureAwait(false));
        var ex3 = Assert.ThrowsAsync<InvalidOperationException>(async () => await preserved.ConfigureAwait(false));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex1!.Message, Is.EqualTo("Test exception"));
            Assert.That(ex2!.Message, Is.EqualTo("Test exception"));
            Assert.That(ex3!.Message, Is.EqualTo("Test exception"));
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task OriginalPooledSourceThrowsOnMultipleAwaitWithoutPreserve()
    {
        var pool = new TestObjectPool<int>();
        PooledManualResetValueTaskSource<int> source = pool.GetPooledWaiter(null);
        source.SetResult(42);

        var vt = new ValueTask<int>(source, source.Version);

        // first await works
        int result = await vt.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(42));

        // second await throws because the source was consumed and returned to pool
        _ = Assert.ThrowsAsync<InvalidOperationException>(async () => await vt.ConfigureAwait(false));

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(1000)]
    public async Task PreservePooledNonGenericSourceCanBeAwaitedMultipleTimes()
    {
        var pool = new TestObjectPool<bool>();
        PooledManualResetValueTaskSource<bool> source = pool.GetPooledWaiter(null);

        // Create non-generic ValueTask from generic source
        var vtGeneric = new ValueTask<bool>(source, source.Version);
        var vt = new ValueTask(vtGeneric.AsTask());
        ValueTask preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        // Complete the source
        source.SetResult(true);

        // should not throw when awaited multiple times
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);

        Assert.That(pool.ActiveCount, Is.Zero);
    }
}
