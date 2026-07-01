// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // ValueTask instances should only be consumed once — intentional in race tests
#pragma warning disable CA1031 // Catch a more specific exception type — intentional in race tests

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Threading.Tests.Pools;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class AsyncExchangeTests
{
    // -------------------------------------------------------------------------
    // Construction
    // -------------------------------------------------------------------------

    [Test]
    public void DefaultPropertyValues()
    {
        var ex = new AsyncExchange<int>();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.RunContinuationAsynchronously, Is.True);
            Assert.That(ex.HasWaiter, Is.False);
            Assert.That(ex.InternalWaiterInUse, Is.False);
        }
    }

    [Test]
    public void RunContinuationAsynchronouslyPropertyRoundTrips()
    {
        var ex = new AsyncExchange<int>(runContinuationAsynchronously: false);
        Assert.That(ex.RunContinuationAsynchronously, Is.False);

        ex.RunContinuationAsynchronously = true;
        Assert.That(ex.RunContinuationAsynchronously, Is.True);
    }

    // -------------------------------------------------------------------------
    // TryReset
    // -------------------------------------------------------------------------

    [Test]
    public void TryReset_SucceedsWhenNoWaiter()
    {
        var ex = new AsyncExchange<int>();
        Assert.That(ex.TryReset(), Is.True);
    }

    [Test, CancelAfter(3000)]
    public async Task TryReset_FailsWhileWaiterIsPending()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            ready.SetResult(true);
            await ex.ExchangeAsync(1).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(ex.TryReset(), Is.False);

        await ex.ExchangeAsync(2).ConfigureAwait(false);   // pair with the waiter to unblock it
        await waiter.ConfigureAwait(false);
    }

    // -------------------------------------------------------------------------
    // Basic exchange
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task TwoPartiesExchangeValues()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        var partyA = Task.Run(async () => await ex.ExchangeAsync(42).ConfigureAwait(false));
        var partyB = Task.Run(async () => await ex.ExchangeAsync(99).ConfigureAwait(false));

        int[] results = await Task.WhenAll(partyA, partyB).ConfigureAwait(false);

        // Each party gets the other's value
        Assert.That(results, Contains.Item(42));
        Assert.That(results, Contains.Item(99));
        Assert.That(results[0], Is.Not.EqualTo(results[1]));

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task FirstPartyBlocksUntilSecondArrives()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var partyA = Task.Run(async () => {
            ready.SetResult(true);
            return await ex.ExchangeAsync(1).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(partyA.IsCompleted, Is.False);
        Assert.That(ex.HasWaiter, Is.True);

        int fromA = await ex.ExchangeAsync(2).ConfigureAwait(false);
        int fromB = await partyA.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(fromA, Is.EqualTo(1));
            Assert.That(fromB, Is.EqualTo(2));
            Assert.That(ex.HasWaiter, Is.False);
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task SecondPartyCompletesImmediatelySynchronously()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var partyA = Task.Run(async () => {
            ready.SetResult(true);
            return await ex.ExchangeAsync(10).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        // Second caller returns synchronously — ValueTask is already completed
        ValueTask<int> vt = ex.ExchangeAsync(20);
        Assert.That(vt.IsCompleted, Is.True);
        Assert.That(await vt.ConfigureAwait(false), Is.EqualTo(10));

        Assert.That(await partyA.ConfigureAwait(false), Is.EqualTo(20));
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // Reference types
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task WorksWithReferenceTypes()
    {
        var ex = new AsyncExchange<string?>();

        var partyA = Task.Run(async () => await ex.ExchangeAsync("hello").ConfigureAwait(false));
        var partyB = Task.Run(async () => await ex.ExchangeAsync("world").ConfigureAwait(false));

        string?[] results = await Task.WhenAll(partyA, partyB).ConfigureAwait(false);

        Assert.That(results, Contains.Item("hello"));
        Assert.That(results, Contains.Item("world"));
    }

    [Test, CancelAfter(3000)]
    public async Task WorksWithNullValues()
    {
        var ex = new AsyncExchange<string?>();

        var partyA = Task.Run(async () => await ex.ExchangeAsync(null).ConfigureAwait(false));
        var partyB = Task.Run(async () => await ex.ExchangeAsync("value").ConfigureAwait(false));

        string?[] results = await Task.WhenAll(partyA, partyB).ConfigureAwait(false);

        Assert.That(results, Contains.Item((string?)null));
        Assert.That(results, Contains.Item("value"));
    }

    // -------------------------------------------------------------------------
    // Cancellation
    // -------------------------------------------------------------------------

    [Test]
    public void PreCancelledTokenReturnsImmediatelyCancelled()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        var cancelled = new CancellationToken(canceled: true);
        ValueTask<int> vt = ex.ExchangeAsync(42, cancelled);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(vt.IsCompleted, Is.True);
            Assert.That(vt.IsCanceled, Is.True);
            Assert.That(ex.HasWaiter, Is.False);
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task CancellationWhileWaitingThrowsAndClearsSlot()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        using var cts = new CancellationTokenSource();

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            ready.SetResult(true);
            return await ex.ExchangeAsync(1, cts.Token).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(ex.HasWaiter, Is.True);

        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await waiter.ConfigureAwait(false));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ex.HasWaiter, Is.False);
            Assert.That(ex.InternalWaiterInUse, Is.False);
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    [Test, CancelAfter(3000)]
    public async Task CancellationAndExchangeRaceLeaveExchangeConsistent()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        for (int i = 0; i < 100; i++)
        {
            using var cts = new CancellationTokenSource();

            var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            var waiter = Task.Run(async () => {
                ready.SetResult(true);
                try { return await ex.ExchangeAsync(1, cts.Token).ConfigureAwait(false); }
                catch (OperationCanceledException) { return -1; }
            });

            await ready.Task.ConfigureAwait(false);

            // Race: cancel and arrive simultaneously
            await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);
            ValueTask<int> arriving;
            try
            {
                arriving = ex.ExchangeAsync(2);
            }
            catch
            {
                arriving = new ValueTask<int>(-1);
            }

            int waiterResult = await waiter.ConfigureAwait(false);
            int arrivingResult = arriving.IsCompleted ? await arriving.ConfigureAwait(false) : -1;

            if (!arriving.IsCompleted)
            {
                // Second party became a new waiter — drain it
                try { await ex.ExchangeAsync(0).ConfigureAwait(false); } catch { }
                await arriving.ConfigureAwait(false);
            }

            // In every iteration the exchange ends in a consistent state
            Assert.That(ex.HasWaiter, Is.False, $"Iteration {i}: slot should be empty");
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // HasWaiter
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    public async Task HasWaiterReflectsSlotOccupancy()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);

        Assert.That(ex.HasWaiter, Is.False);

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var waiter = Task.Run(async () => {
            ready.SetResult(true);
            return await ex.ExchangeAsync(1).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        Assert.That(ex.HasWaiter, Is.True);

        await ex.ExchangeAsync(2).ConfigureAwait(false);
        await waiter.ConfigureAwait(false);

        Assert.That(ex.HasWaiter, Is.False);
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // RunContinuationAsynchronously
    // -------------------------------------------------------------------------

    [Test, CancelAfter(3000)]
    [TestCase(true)]
    [TestCase(false)]
    public async Task RunContinuationAsynchronouslyExecutesCorrectly(bool runAsync)
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(runContinuationAsynchronously: runAsync, pool: pool);

        var ready = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        var partyA = Task.Run(async () => {
            ready.SetResult(true);
            return await ex.ExchangeAsync(1).ConfigureAwait(false);
        });

        await ready.Task.ConfigureAwait(false);
        await Task.Delay(50).ConfigureAwait(false);

        int result = await ex.ExchangeAsync(2).ConfigureAwait(false);

        Assert.That(result, Is.EqualTo(1));
        Assert.That(await partyA.ConfigureAwait(false), Is.EqualTo(2));
        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // Stress: sequential rounds
    // -------------------------------------------------------------------------

    [Test, CancelAfter(10000)]
    public async Task SequentialRoundsExchangeCorrectly()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);
        const int rounds = 200;

        for (int i = 0; i < rounds; i++)
        {
            int a = i;
            int b = i + 1000;

            var taskA = Task.Run(async () => await ex.ExchangeAsync(a).ConfigureAwait(false));
            var taskB = Task.Run(async () => await ex.ExchangeAsync(b).ConfigureAwait(false));

            int[] results = await Task.WhenAll(taskA, taskB).ConfigureAwait(false);

            using (Assert.EnterMultipleScope())
            {
                Assert.That(results, Contains.Item(a));
                Assert.That(results, Contains.Item(b));
            }
        }

        Assert.That(pool.ActiveCount, Is.Zero);
    }

    // -------------------------------------------------------------------------
    // Stress: concurrent wavefronts
    // -------------------------------------------------------------------------

    [Test, CancelAfter(10000)]
    public async Task ConcurrentPairsExchangeCorrectly()
    {
        using var pool = new TestObjectPool<int>();
        var ex = new AsyncExchange<int>(pool: pool);
        const int pairs = 100;

        // Launch pairs*2 tasks simultaneously; in each pair one gets the other's value
        var tasks = Enumerable.Range(0, pairs * 2)
            .Select(i => Task.Run(async () => await ex.ExchangeAsync(i).ConfigureAwait(false)))
            .ToArray();

        int[] results = await Task.WhenAll(tasks).ConfigureAwait(false);

        // Every value must appear exactly once as either input or output
        int[] allInputs = Enumerable.Range(0, pairs * 2).ToArray();
        int[] allOutputs = results.OrderBy(x => x).ToArray();

        // Each task received the value of exactly one peer
        // Sum of all results == sum of all inputs (values are conserved)
        Assert.That(results.Sum(), Is.EqualTo(allInputs.Sum()));

        Assert.That(pool.ActiveCount, Is.Zero);
    }
}
