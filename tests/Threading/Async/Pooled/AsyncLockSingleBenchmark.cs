// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-threaded lock/unlock performance on AsyncLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of async locks in uncontended scenarios
/// where lock acquisition completes immediately without queuing.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and immediately release an uncontended lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Standard (lock):</b> Synchronous C# lock statement (Monitor-based).</description></item>
/// <item><description><b>Pooled (baseline):</b> Allocation-free async implementation using pooled IValueTaskSource with struct releaser.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based lock and IDisposable releaser.</description></item>
/// <item><description><b>AsyncKeyedLock (NonKeyed):</b> Third-party high-performance async lock library.</description></item>
/// <item><description><b>NeoSmart:</b> Third-party async lock library with nested-acquisition detection.</description></item>
/// <item><description><b>VS.Threading:</b> Third-party async library using AsyncSemaphore as a lock.</description></item>
/// <item><description><b>RefImpl:</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Fast-path overhead and memory allocations when no contention exists.
/// This represents the optimal case for (async) lock implementations.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of uncontended lock/unlock operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncLock")]
public class AsyncLockSingleBenchmark : AsyncLockBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for unchecked increment.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the increment operation.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Increment")]
    public void IncrementSingle()
    {
        // simulate work
        unchecked { _counter++; }
    }

#if NET9_0_OR_GREATER
    /// <summary>
    /// Benchmark for .NET 9.0 C# Lock statement.
    /// </summary>
    /// <remarks>
    /// Measures the baseline performance of the .NET 9 Lock mechanism.
    /// This is the fastest synchronous option but blocks threads and cannot be used with await.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Lock")]
    public void LockUnlockSingle()
    {
        lock (_lock)
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for .NET 9.0 C# Lock statement with EnterScope().
    /// </summary>
    /// <remarks>
    /// Measures the baseline performance of the .NET 9 Lock mechanism with EnterScope().
    /// This is the fastest synchronous option but blocks threads and cannot be used with await.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Lock.EnterScope")]
    public void LockEnterScopeSingle()
    {
        using (_lock.EnterScope())
        {
            // simulate work
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for standard synchronous C# lock statement.
    /// </summary>
    /// <remarks>
    /// Measures the baseline performance of the synchronous Monitor-based lock mechanism.
    /// This option blocks threads and cannot be used with await.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "lock()")]
    public void ObjectLockUnlockSingle()
    {
        lock (_objectLock)
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for SpinWait.SpinOnce.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SpinWait", "System", "SpinOnce")]
    public void SpinWaitSingle()
    {
        var spinWait = new SpinWait();
        spinWait.SpinOnce();
    }

    /// <summary>
    /// Benchmark for Interlocked.Increment vs C# lock statements.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Interlocked.Inc")]
    public void InterlockedIncrementSingle()
    {
        _ = Interlocked.Increment(ref _counter);
    }

    /// <summary>
    /// Benchmark for Interlocked.Add vs C# lock statements.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Interlocked.Add")]
    public void InterlockedAdd()
    {
        _ = Interlocked.Add(ref _counter, 1);
    }

    /// <summary>
    /// Benchmark for Interlocked.CompareExchange vs C# lock statements.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Lock", "System", "Interlocked.CmpX")]
    public void InterlockedCompareExchange()
    {
        // perform the increment in an unchecked context to match other increment benchmarks
        unchecked
        {
            // compare always succeeds
            _ = Interlocked.CompareExchange(ref _counter, _counter + 1, _counter);
        }
    }

    /// <summary>
    /// Benchmark for System SpinLock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SpinLock", "System", "SpinLock")]
    public async Task LockUnlockSpinLockSingleAsync()
    {
        bool lockTaken = false;
        _spinLock.Enter(ref lockTaken);
        try
        {
            // simulate work
            unchecked { _counter++; }
        }
        finally
        {
            _spinLock.Exit();
        }
    }

    /// <summary>
    /// Benchmark for Crypto Hives Internal SpinLock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SpinLock", "CryptoHives", "SpinLock")]
    public async Task LockUnlockCryptoHivesSpinLockSingleAsync()
    {
        _spinLockCryptoHives.Enter();
        try
        {
            // simulate work
            unchecked { _counter++; }
        }
        finally
        {
            _spinLockCryptoHives.Exit();
        }
    }

    /// <summary>
    /// Benchmark for SemaphoreSlim used as a lock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "System", "SemaphoreSlim")]
    public async Task LockUnlockSemaphoreSlimSingleAsync()
    {
        await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
        try
        {
            // simulate work
            unchecked { _counter++; }
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    /// <summary>
    /// Benchmark for pooled async lock (single uncontended acquisition).
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the allocation-free async lock using pooled IValueTaskSource.
    /// In the uncontended case, the lock returns a completed ValueTask immediately with no allocations.
    /// </remarks>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("LockAsync", "Pooled")]
    public async Task LockUnlockPooledSingleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async lock (single uncontended acquisition).
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the third-party Nito.AsyncEx async lock.
    /// This implementation uses Task-based primitives.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "Nito.AsyncEx")]
    public async Task LockUnlockNitoSingleAsync()
    {
        using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for AsyncKeyedLock (NonKeyed) async lock (single uncontended acquisition).
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the third-party AsyncKeyedLock library.
    /// This high-performance library uses ValueTask-based primitives and optimized pooling.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "NonKeyed")]
    public async Task LockUnlockNonKeyedSingleAsync()
    {
        using (await _lockNonKeyed.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

#if !NETFRAMEWORK
    /// <summary>
    /// Benchmark for the NeoSmart AsyncLock implementation.
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the third party NeoSmart implementation.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "NeoSmart")]
    public async Task LockUnlockNeoSmartSingleAsync()
    {
        using (await _lockNeoSmart.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the Proto.Promises async lock implementation.
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the third party Proto.Promises implementation.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "ProtoPromise")]
    public async Task LockUnlockProtoPromiseSingleAsync()
    {
        using (await _lockProtoPromise.LockAsync(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for Visual Studio Threading async semaphore used as an async lock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "VS.Threading", "AsyncSemaphore")]
    public async Task LockUnlockVSThreadingSingleAsync()
    {
        using (await _lockVSThreading.EnterAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for reference implementation async lock.
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the TaskCompletionSource-based reference implementation.
    /// This serves as the baseline for comparing allocation-free patterns in uncontended scenarios.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "RefImpl")]
    public async Task LockUnlockRefImplSingleAsync()
    {
        using (await _lockRefImp.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }
}
