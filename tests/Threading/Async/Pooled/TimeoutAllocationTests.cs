// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method

#if !NETFRAMEWORK

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Measures and reports the managed heap bytes allocated by a contended wait, with and
/// without a timeout.
/// </summary>
/// <remarks>
/// <para>
/// The contended arm of a wait operation runs synchronously inside the calling thread before
/// the <see cref="ValueTask"/> is returned, so <see cref="GC.GetAllocatedBytesForCurrentThread"/>
/// around the call captures exactly the per-waiter cost: zero for the plain contended path,
/// and the timer plus its timeout state for the timed path.
/// </para>
/// <para>
/// The minimum across samples (skipping the first, which warms up the local waiter) is the
/// steady-state cost; single-sample spikes from GC bookkeeping or tiering are ignored.
/// </para>
/// </remarks>
[TestFixture]
[NonParallelizable]
public class TimeoutAllocationTests
{
    private const int Samples = 100;
    private const long TimedArmAllocationLimit = 1024;

    /// <summary>
    /// A timeout that never elapses during the test, so only the arm cost is measured.
    /// </summary>
    private static readonly TimeSpan LongTimeout = TimeSpan.FromMinutes(10);

    /// <summary>
    /// Measures the bytes allocated by arming a contended <see cref="AsyncLock.LockAsync(TimeSpan, System.Threading.CancellationToken)"/>.
    /// </summary>
    [Test]
    public async Task ReportAsyncLockContendedArmAllocations()
    {
        var mutex = new AsyncLock();

        long noTimeout = await MeasureAsyncLockArmAsync(mutex, timeout: null).ConfigureAwait(false);
        long withTimeout = await MeasureAsyncLockArmAsync(mutex, LongTimeout).ConfigureAwait(false);

        Report("AsyncLock.LockAsync", noTimeout, withTimeout);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(noTimeout, Is.Zero, "The contended LockAsync without timeout must stay allocation-free in steady state.");
            Assert.That(withTimeout, Is.LessThanOrEqualTo(TimedArmAllocationLimit), "The timed contended LockAsync should only allocate the timer and its timeout state.");
        }
    }

    /// <summary>
    /// Measures the bytes allocated by arming a contended <see cref="AsyncSemaphore.WaitAsync(TimeSpan, System.Threading.CancellationToken)"/>.
    /// </summary>
    [Test]
    public async Task ReportAsyncSemaphoreContendedArmAllocations()
    {
        var semaphore = new AsyncSemaphore(initialCount: 1);

        long noTimeout = await MeasureAsyncSemaphoreArmAsync(semaphore, timeout: null).ConfigureAwait(false);
        long withTimeout = await MeasureAsyncSemaphoreArmAsync(semaphore, LongTimeout).ConfigureAwait(false);

        Report("AsyncSemaphore.WaitAsync", noTimeout, withTimeout);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(noTimeout, Is.Zero, "The contended WaitAsync without timeout must stay allocation-free in steady state.");
            Assert.That(withTimeout, Is.LessThanOrEqualTo(TimedArmAllocationLimit), "The timed contended WaitAsync should only allocate the timer and its timeout state.");
        }
    }

    private static async Task<long> MeasureAsyncLockArmAsync(AsyncLock mutex, TimeSpan? timeout)
    {
        long min = long.MaxValue;

        AsyncLock.Releaser held = await mutex.LockAsync().ConfigureAwait(false);
        for (int i = 0; i < Samples; i++)
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            ValueTask<AsyncLock.Releaser> pending = timeout.HasValue
                ? mutex.LockAsync(timeout.Value)
                : mutex.LockAsync();
            long bytes = GC.GetAllocatedBytesForCurrentThread() - before;

            held.Dispose();
            held = await pending.ConfigureAwait(false);

            if (i > 0)
            {
                min = Math.Min(min, bytes);
            }
        }

        held.Dispose();
        return min;
    }

    private static async Task<long> MeasureAsyncSemaphoreArmAsync(AsyncSemaphore semaphore, TimeSpan? timeout)
    {
        long min = long.MaxValue;

        await semaphore.WaitAsync().ConfigureAwait(false);
        for (int i = 0; i < Samples; i++)
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            ValueTask pending = timeout.HasValue
                ? semaphore.WaitAsync(timeout.Value)
                : semaphore.WaitAsync();
            long bytes = GC.GetAllocatedBytesForCurrentThread() - before;

            semaphore.Release();
            await pending.ConfigureAwait(false);

            if (i > 0)
            {
                min = Math.Min(min, bytes);
            }
        }

        semaphore.Release();
        return min;
    }

    private static void Report(string operation, long noTimeout, long withTimeout)
    {
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{operation} contended arm, steady state (min of {Samples - 1} samples):");
        TestContext.Out.WriteLine($"{"  without timeout",-40} {noTimeout,10:N0} B");
        TestContext.Out.WriteLine($"{"  with timeout",-40} {withTimeout,10:N0} B");
        TestContext.Out.WriteLine($"{"  timed path overhead",-40} {withTimeout - noTimeout,10:N0} B");
    }
}
#endif
