// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using CryptoHives.Foundation.Threading.Async.Pooled;
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
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[NonParallelizable]
[BenchmarkCategory("AsyncLock")]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    private Task[]? _tasks;
    private Task<AsyncLock.AsyncLockReleaser>[]? _tasksReleaser;
    private ValueTask<AsyncLock.AsyncLockReleaser>[]? _lockHandle;
#if !SIGNASSEMBLY
    private Nito.AsyncEx.AwaitableDisposable<IDisposable>[]? _lockNitoHandle;
#endif
    private ValueTask<AsyncKeyedLock.AsyncNonKeyedLockReleaser>[]? _lockNonKeyedHandle;
#if !NETFRAMEWORK
    private Task<IDisposable>[]? _lockNeoSmartHandle;
#endif
    private Task<RefImpl.AsyncLock.AsyncLockReleaser>[]? _lockRefImplHandle;

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(0, 1, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncLockMultipleBenchmark() { }

    public AsyncLockMultipleBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockSemaphoreSlimMultipleTestAsync(CancellationType cancellationType)
    {
        SemaphoreSlimGlobalSetup();
        return LockUnlockSemaphoreSlimMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockSemaphoreSlimMultipleAsync))]
    public void SemaphoreSlimGlobalSetup()
    {
        base.GlobalSetup();
        _tasks = new Task[Iterations];
    }

    /// <summary>
    /// Benchmark for SemaphoreSlim used as async lock with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "SemaphoreSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockSemaphoreSlimMultipleAsync(CancellationType cancellationType)
    {
        await _semaphoreSlim.WaitAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasks![i] = _semaphoreSlim.WaitAsync(cancellationType.CancellationToken);
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }

        foreach (Task handle in _tasks!)
        {
            await handle.ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockPooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        return LockUnlockPooledMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
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
    [BenchmarkCategory("Multiple", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockPooledMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockPooled.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = _lockPooled.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (ValueTask<AsyncLock.AsyncLockReleaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockPooledTaskMultipleTestAsync(CancellationType cancellationType)
    {
        PooledTaskGlobalSetup();
        return LockUnlockPooledTaskMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledTaskMultipleAsync))]
    public void PooledTaskGlobalSetup()
    {
        base.GlobalSetup();
        _tasksReleaser = new Task<AsyncLock.AsyncLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters using Task (converted from ValueTask).
    /// </summary>
    /// <remarks>
    /// Measures the overhead when ValueTask is converted to Task via AsTask() for multiple queued requests.
    /// This pattern incurs Task allocation overhead compared to awaiting ValueTask directly.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "PooledTask")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockPooledTaskMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockPooled.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasksReleaser![i] = _lockPooled.LockAsync(cancellationType.CancellationToken).AsTask();
            }
        }

        foreach (Task<AsyncLock.AsyncLockReleaser> task in _tasksReleaser!)
        {
            using (await task.ConfigureAwait(false)) { }
        }
    }

#if !SIGNASSEMBLY
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNitoMultipleTestAsync(CancellationType cancellationType)
    {
        NitoGlobalSetup();
        return LockUnlockNitoMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNitoMultipleAsync))]
    public void NitoGlobalSetup()
    {
        base.GlobalSetup();
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
    [BenchmarkCategory("Multiple", "Nito")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNitoMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNitoAsync.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNitoHandle![i] = _lockNitoAsync.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (Nito.AsyncEx.AwaitableDisposable<IDisposable> handle in _lockNitoHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
#endif

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNeoSmartMultipleTestAsync(CancellationType cancellationType)
    {
        NeoSmartGlobalSetup();
        return LockUnlockNeoSmartMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNeoSmartMultipleAsync))]
    public void NeoSmartGlobalSetup()
    {
        base.GlobalSetup();
        _lockNeoSmartHandle = new Task<IDisposable>[Iterations];
    }

    /// <summary>
    /// <b>Out of contest:</b> Benchmark for NeoSmart.AsyncLock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party NeoSmart.AsyncLock library under contention.
    /// This implementation uses Task-based disposable primitives.
    /// Since NeoSmart has a means of detecting that the lock is a nested acquisition by the same
    /// Task, the behavior differs here as it can directly pass a completed task for nested waits.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "NeoSmart")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNeoSmartMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNeoSmart.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNeoSmartHandle![i] = _lockNeoSmart.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (Task<IDisposable> handle in _lockNeoSmartHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
#endif


    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task LockUnlockRefImplMultipleTestAsync(CancellationType cancellationType)
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplMultipleAsync))]
    public void RefImplGlobalSetup()
    {
        base.GlobalSetup();
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
    [BenchmarkCategory("Multiple", "RefImpl")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task LockUnlockRefImplMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockRefImp.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockRefImplHandle![i] = _lockRefImp.LockAsync();
            }
        }

        foreach (Task<RefImpl.AsyncLock.AsyncLockReleaser> handle in _lockRefImplHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNonKeyedMultipleTestAsync(CancellationType cancellationType)
    {
        NonKeyedGlobalSetup();
        return LockUnlockNonKeyedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNonKeyedMultipleAsync))]
    public void NonKeyedGlobalSetup()
    {
        base.GlobalSetup();
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
    [BenchmarkCategory("Multiple", "NonKeyed")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNonKeyedMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNonKeyed.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNonKeyedHandle![i] = _lockNonKeyed.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (ValueTask<AsyncKeyedLock.AsyncNonKeyedLockReleaser> handle in _lockNonKeyedHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
