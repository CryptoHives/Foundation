// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA2012 // Use ValueTasks correctly

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring lock/unlock performance and memory allocations when queued waiters
/// specify a timeout.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite quantifies the cost of the timed wait path under contention: each
/// queued waiter arms a timer (plus its timeout state) that is disposed again when the waiter
/// completes. The timeout is long enough to never elapse, so the measurement isolates the
/// arm/dispose overhead from actual timeout handling.
/// </para>
/// <para>
/// <b>Test scenario:</b> Hold the lock, queue multiple timed lock requests, then release and
/// sequentially acquire each queued lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (no timeout) (baseline):</b> Allocation-free contended path without a timer; shows the timed path overhead as the ratio.</description></item>
/// <item><description><b>Pooled (ValueTask):</b> Same pooled implementation with a timeout per queued waiter.</description></item>
/// <item><description><b>SemaphoreSlim:</b> System primitive used as async lock with timed WaitAsync.</description></item>
/// <item><description><b>VS.Threading:</b> VS threading library AsyncSemaphore with timed EnterAsync.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Allocated bytes per operation for the timed contended path with varying
/// numbers of queued waiters (controlled by <see cref="Iterations"/> parameter: 0, 1, 10, 100).
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncLock")]
public class AsyncLockTimeoutBenchmark : AsyncLockBaseBenchmark
{
    /// <summary>
    /// A timeout that never elapses during the benchmark, so only the arm/dispose cost is measured.
    /// </summary>
    private static readonly TimeSpan LongTimeout = TimeSpan.FromMinutes(10);

    private ValueTask<AsyncLock.Releaser>[]? _lockHandle;
    private Task<bool>[]? _semaphoreSlimHandle;
    private Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[]? _lockVSThreadingHandle;

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(0, 1, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncLockTimeoutBenchmark() { }

    public AsyncLockTimeoutBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    public Task LockUnlockPooledNoTimeoutMultipleTestAsync()
    {
        PooledNoTimeoutGlobalSetup();
        return LockUnlockPooledNoTimeoutMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledNoTimeoutMultipleAsync))]
    public void PooledNoTimeoutGlobalSetup()
    {
        base.GlobalSetup();
        _lockHandle = new ValueTask<AsyncLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters without a timeout (baseline).
    /// </summary>
    /// <remarks>
    /// The allocation-free contended path: queued waiters reuse pooled IValueTaskSource
    /// instances and arm no timer. The timed variants below show their overhead relative
    /// to this baseline.
    /// </remarks>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("MultipleTimeout", "Pooled (no timeout)")]
    public async Task LockUnlockPooledNoTimeoutMultipleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = _lockPooled.LockAsync();
            }
        }

        foreach (ValueTask<AsyncLock.Releaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockPooledTimeoutMultipleTestAsync()
    {
        PooledTimeoutGlobalSetup();
        return LockUnlockPooledTimeoutMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledTimeoutMultipleAsync))]
    public void PooledTimeoutGlobalSetup()
    {
        base.GlobalSetup();
        _lockHandle = new ValueTask<AsyncLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters that specify a timeout.
    /// </summary>
    /// <remarks>
    /// Each queued waiter arms a timer and its timeout state; both are released when the
    /// waiter acquires the lock. The allocation delta to the no-timeout baseline is the
    /// per-waiter cost of the timed contended path.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("MultipleTimeout", "Pooled (ValueTask)")]
    public async Task LockUnlockPooledTimeoutMultipleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = _lockPooled.LockAsync(LongTimeout);
            }
        }

        foreach (ValueTask<AsyncLock.Releaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockSemaphoreSlimTimeoutMultipleTestAsync()
    {
        SemaphoreSlimTimeoutGlobalSetup();
        return LockUnlockSemaphoreSlimTimeoutMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockSemaphoreSlimTimeoutMultipleAsync))]
    public void SemaphoreSlimTimeoutGlobalSetup()
    {
        base.GlobalSetup();
        _semaphoreSlimHandle = new Task<bool>[Iterations];
    }

    /// <summary>
    /// Benchmark for SemaphoreSlim used as async lock with multiple queued waiters that specify a timeout.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("MultipleTimeout", "System", "SemaphoreSlim")]
    public async Task LockUnlockSemaphoreSlimTimeoutMultipleAsync()
    {
        await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _semaphoreSlimHandle![i] = _semaphoreSlim.WaitAsync(LongTimeout);
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }

        foreach (Task<bool> handle in _semaphoreSlimHandle!)
        {
            await handle.ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    public Task LockUnlockVSThreadingTimeoutMultipleTestAsync()
    {
        VSThreadingTimeoutGlobalSetup();
        return LockUnlockVSThreadingTimeoutMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockVSThreadingTimeoutMultipleAsync))]
    public void VSThreadingTimeoutGlobalSetup()
    {
        base.GlobalSetup();
        _lockVSThreadingHandle = new Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for Visual Studio Threading async semaphore used as an async lock with multiple
    /// queued waiters that specify a timeout.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("MultipleTimeout", "VS.Threading", "AsyncSemaphore")]
    public async Task LockUnlockVSThreadingTimeoutMultipleAsync()
    {
        using (await _lockVSThreading.EnterAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockVSThreadingHandle![i] = _lockVSThreading.EnterAsync(LongTimeout);
            }
        }

        foreach (var handle in _lockVSThreadingHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
