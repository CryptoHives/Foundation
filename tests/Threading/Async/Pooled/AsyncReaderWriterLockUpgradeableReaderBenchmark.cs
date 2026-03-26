// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method
#pragma warning disable CS0165 // 
#pragma warning disable VSTHRD110 // Observe result of async calls

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-threaded upgradeable reader lock performance on AsyncReaderWriterLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of an async reader-writer lock
/// for upgradeable reader acquisition in uncontended and contended scenarios.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and release an upgradeable reader lock with and without contention.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>ReaderWriterLockSlim:</b> .NET built-in synchronous reader-writer lock.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Proto.Promises:</b> Third-party async library with Promises-based reader-writer lock.</description></item>
/// <item><description><b>VS.Threading:</b> Third-party async library with custom Task-based reader-writer lock.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockUpgradeableReaderBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[]? _rwlockVSThreadingHandle;
    private CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[]? _rwLockPooledHandle;
#if !NETFRAMEWORK
    private Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[]? _rwlockProtoPromisesHandle;
#endif

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 5 }
    };

    [Params(0, 1, 2, 5)]
    public int Iterations { get; set; } = 5;

    public AsyncReaderWriterLockUpgradeableReaderBenchmark() { }

    public AsyncReaderWriterLockUpgradeableReaderBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task ReaderLockSlimMultipleTestAsync(CancellationType cancellationType)
    {
        SlimGlobalSetup();
        var result = UpgradeableReaderLockPooledAsync(cancellationType);
        SlimGlobalCleanup();
        return result;
    }

    [GlobalSetup(Target = nameof(ReadLockReaderWriterLockSlim))]
    public void SlimGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledHandle = new CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[Iterations];
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwLockSlim.EnterReadLock();
            }
        }).GetAwaiter().GetResult();
    }

    [GlobalCleanup(Target = nameof(ReadLockReaderWriterLockSlim))]
    public void SlimGlobalCleanup()
    {
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwLockSlim.ExitReadLock();
            }
        });
        Thread.Sleep(1);
        base.GlobalCleanup();
    }

    /// <summary>
    /// Benchmark for ReaderWriterLockSlim upgradeable read lock.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradeableReaderLock", "System", "RWLockSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public void ReadLockReaderWriterLockSlim(CancellationType cancellationType)
    {
        _rwLockSlim.EnterUpgradeableReadLock();
        try
        {
            for (int i = 2; i < Iterations; i++)
            {
                _rwLockSlim.EnterReadLock();
            }

            for (int i = 2; i < Iterations; i++)
            {
                _rwLockSlim.ExitReadLock();
            }
        }
        finally
        {
            _rwLockSlim.ExitUpgradeableReadLock();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockPooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        var result = UpgradeableReaderLockPooledAsync(cancellationType);
        PooledGlobalCleanup();
        return result;
    }

    [GlobalSetup(Target = nameof(UpgradeableReaderLockPooledAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledHandle = new CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[Iterations];
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwLockPooledHandle![0] = _rwLockPooled.ReaderLockAsync().AsTask().GetAwaiter().GetResult();
            }
        }).GetAwaiter().GetResult();
    }

    [GlobalCleanup(Target = nameof(UpgradeableReaderLockPooledAsync))]
    public void PooledGlobalCleanup()
    {
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwLockPooledHandle![0].Dispose();
            }
        });
        Thread.Sleep(1);
        base.GlobalCleanup();
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock (upgradeable reader).
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("UpgradeableReaderLock", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task UpgradeableReaderLockPooledAsync(CancellationType cancellationType)
    {
        using (await _rwLockPooled.UpgradeableReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 2; i < Iterations; i++)
            {
                _rwLockPooledHandle![i] = await _rwLockPooled.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
            }

            for (int i = 2; i < Iterations; i++)
            {
                _rwLockPooledHandle![i].Dispose();
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockVSThreadingMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingGlobalSetup();
        var result = ReaderLockVSThreadingAsync(cancellationType);
        VSThreadingGlobalCleanup();
        return result;
    }

    [GlobalSetup(Target = nameof(ReaderLockVSThreadingAsync))]
    public void VSThreadingGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockVSThreadingHandle = new Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[Iterations];
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwlockVSThreadingHandle![0] = _rwLockVSThreading.ReadLockAsync().GetAwaiter().GetResult();
            }
        }).GetAwaiter().GetResult();
    }

    [GlobalCleanup(Target = nameof(ReaderLockVSThreadingAsync))]
    public void VSThreadingGlobalCleanup()
    {
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwlockVSThreadingHandle![0].Dispose();
            }
        });
        Thread.Sleep(1);
        base.GlobalCleanup();
    }

    /// <summary>
    /// Benchmark for VS.Threading async reader-writer lock (upgradeable reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradeableReaderLock", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task ReaderLockVSThreadingAsync(CancellationType cancellationType)
    {
        using (await _rwLockVSThreading.UpgradeableReadLockAsync(cancellationType.CancellationToken))
        {
            for (int i = 2; i < Iterations; i++)
            {
                _rwlockVSThreadingHandle![i] = await _rwLockVSThreading.ReadLockAsync(cancellationType.CancellationToken);
            }

            for (int i = 2; i < Iterations; i++)
            {
                _rwlockVSThreadingHandle![i].Dispose();
            }
        }
    }

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockProtoPromisesTestAsync(CancellationType cancellationType)
    {
        ProtoPromisesGlobalSetup();
        var result = UpgradeableReaderLockProtoPromisesAsync(cancellationType);
        ProtoPromisesGlobalCleanup();
        return result;
    }

    [GlobalSetup(Target = nameof(UpgradeableReaderLockProtoPromisesAsync))]
    public void ProtoPromisesGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockProtoPromisesHandle = new Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[Iterations];
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwlockProtoPromisesHandle![0] = _rwLockProtoPromises.ReaderLockAsync(false).GetAwaiter().GetResult();
            }
        }).GetAwaiter().GetResult();
    }

    [GlobalCleanup(Target = nameof(UpgradeableReaderLockProtoPromisesAsync))]
    public void ProtoPromisesGlobalCleanup()
    {
        Task.Run(() => {
            if (Iterations > 0)
            {
                _rwlockProtoPromisesHandle![0].Dispose();
            }
        });
        Thread.Sleep(1);
        base.GlobalCleanup();
    }

    /// <summary>
    /// Benchmark for Proto.Promises async reader-writer lock (upgradeable reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradeableReaderLock", "Proto.Promises")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.ProtoPromisesNoneNotCanceledGroup))]
    public async Task UpgradeableReaderLockProtoPromisesAsync(CancellationType cancellationType)
    {
        using (await _rwLockProtoPromises.UpgradeableReaderLockAsync(cancellationType.CancelationToken, false))
        {
            for (int i = 2; i < Iterations; i++)
            {
                _rwlockProtoPromisesHandle![i] = await _rwLockProtoPromises.ReaderLockAsync(cancellationType.CancelationToken, false);
            }

            for (int i = 2; i < Iterations; i++)
            {
                _rwlockProtoPromisesHandle![i].Dispose();
            }
        }
    }
#endif
}
