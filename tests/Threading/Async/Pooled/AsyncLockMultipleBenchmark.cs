// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable CA2012 // Use ValueTasks correctly

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring lock/unlock performance with multiple queued waiters on AsyncLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance and memory overhead of acquiring and releasing
/// an async lock when multiple lock requests are queued. It measures contention handling
/// and the efficiency of FIFO waiter queue implementations.
/// </para>
/// <para>
/// <b>Test scenario:</b> Hold the lock, queue multiple lock requests, then release and sequentially
/// acquire each queued lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (ValueTask):</b> Allocation-free implementation using pooled IValueTaskSource with struct releaser.</description></item>
/// <item><description><b>Pooled (Task):</b> Same pooled implementation converted to Task via AsTask() (incurs allocation).</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based lock and IDisposable releaser.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// <item><description><b>AsyncKeyedLock (NonKeyed):</b> Third-party high-performance async lock library.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations under contention with varying numbers
/// of queued waiters (controlled by <see cref="Iterations"/> parameter: 0, 1, 10, 100).
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[NonParallelizable]
[BenchmarkCategory("AsyncLock")]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    private Task<AsyncLock.AsyncLockReleaser>[]? _tasks;
    private ValueTask<AsyncLock.AsyncLockReleaser>[]? _lockHandle;
#if !SIGNASSEMBLY
    private Nito.AsyncEx.AwaitableDisposable<IDisposable>[]? _lockNitoHandle;
#endif
    private Task<RefImpl.AsyncLock.AsyncLockReleaser>[]? _lockRefImplHandle;
    private ValueTask<AsyncKeyedLock.AsyncNonKeyedLockReleaser>[]? _lockNonKeyedHandle;

    public static object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(0, 1, 10, 100)]
    public int Iterations = 10;

    public AsyncLockMultipleBenchmark() { }

    public AsyncLockMultipleBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    public Task LockUnlockPooledMultipleTestAsync()
    {
        PooledGlobalSetup();
        return LockUnlockPooledMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        _lockHandle = new ValueTask<AsyncLock.AsyncLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters using ValueTask.
    /// </summary>
    /// <remarks>
    /// Measures the allocation-free hot path when queuing multiple lock requests.
    /// Demonstrates the pooled implementation's ability to minimize allocations
    /// by reusing pooled IValueTaskSource instances for queued waiters.
    /// </remarks>
    [Benchmark]
    public async Task LockUnlockPooledMultipleAsync()
    {
        using (await LockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = LockPooled.LockAsync();
            }
        }

        foreach (ValueTask<AsyncLock.AsyncLockReleaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockPooledTaskMultipleTestAsync()
    {
        PooledTaskGlobalSetup();
        return LockUnlockPooledTaskMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledTaskMultipleAsync))]
    public void PooledTaskGlobalSetup()
    {
        _tasks = new Task<AsyncLock.AsyncLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters using Task (converted from ValueTask).
    /// </summary>
    /// <remarks>
    /// Measures the overhead when ValueTask is converted to Task via AsTask() for multiple queued requests.
    /// This pattern incurs Task allocation overhead compared to awaiting ValueTask directly.
    /// </remarks>
    [Benchmark]
    public async Task LockUnlockPooledTaskMultipleAsync()
    {
        using (await LockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasks![i] = LockPooled.LockAsync().AsTask();
            }
        }

        foreach (Task<AsyncLock.AsyncLockReleaser> task in _tasks!)
        {
            using (await task.ConfigureAwait(false)) { }
        }
    }

#if !SIGNASSEMBLY
    [Test]
    public Task LockUnlockNitoMultipleTestAsync()
    {
        NitoGlobalSetup();
        return LockUnlockNitoMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockNitoMultipleAsync))]
    public void NitoGlobalSetup()
    {
        _lockNitoHandle = new Nito.AsyncEx.AwaitableDisposable<IDisposable>[Iterations];
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party Nito.AsyncEx library under contention.
    /// This implementation uses Task-based primitives and allocates per queued waiter.
    /// </remarks>
    [Benchmark]
    public async Task LockUnlockNitoMultipleAsync()
    {
        using (await LockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNitoHandle![i] = LockNitoAsync.LockAsync();
            }
        }

        foreach (Nito.AsyncEx.AwaitableDisposable<IDisposable> handle in _lockNitoHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
#endif

    [Test]
    public Task LockUnlockRefImplMultipleTestAsync()
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplMultipleAsync))]
    public void RefImplGlobalSetup()
    {
        _lockRefImplHandle = new Task<RefImpl.AsyncLock.AsyncLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for reference implementation async lock with multiple queued waiters (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the performance of the TaskCompletionSource-based reference implementation under contention.
    /// This serves as the baseline for comparing allocation-free pooled patterns with multiple waiters.
    /// Allocates a new TaskCompletionSource per queued waiter.
    /// </remarks>
    [Benchmark(Baseline = true)]
    public async Task LockUnlockRefImplMultipleAsync()
    {
        using (await LockRefImpl.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockRefImplHandle![i] = LockRefImpl.LockAsync();
            }
        }

        foreach (var handle in _lockRefImplHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockNonKeyedMultipleTestAsync()
    {
        NonKeyedGlobalSetup();
        return LockUnlockNonKeyedMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockNonKeyedMultipleAsync))]
    public void NonKeyedGlobalSetup()
    {
        _lockNonKeyedHandle = new ValueTask<AsyncKeyedLock.AsyncNonKeyedLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for AsyncKeyedLock (NonKeyed) async lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party AsyncKeyedLock library under contention.
    /// This high-performance library uses ValueTask-based primitives and optimized pooling strategies.
    /// </remarks>
    [Benchmark]
    public async Task LockUnlockNonKeyedMultipleAsync()
    {
        using (await LockNonKeyed.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNonKeyedHandle![i] = LockNonKeyed.LockAsync();
            }
        }

        foreach (ValueTask<AsyncKeyedLock.AsyncNonKeyedLockReleaser> handle in _lockNonKeyedHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
