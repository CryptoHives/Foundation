// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1849 // Call async methods when in an async method

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-threaded upgraded writer lock performance on AsyncReaderWriterLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of an async reader-writer lock
/// for upgraded writer lock acquisition in uncontended scenarios.
/// </para>
/// <para>
/// <b>Test scenario:</b> Acquire an upgradeable reader lock, optionally acquire additional reader
/// locks, then upgrade to a writer lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>ReaderWriterLockSlim:</b> .NET built-in synchronous reader-writer lock.</description></item>
/// <item><description><b>Pooled (baseline):</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Proto.Promises:</b> Third-party async library with Promises-based reader-writer lock.</description></item>
/// <item><description><b>VS.Threading:</b> Third-party async library with custom Task-based reader-writer lock.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockUpgradedWriterBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[]? _rwlockVSThreadingHandle;
    private CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[]? _rwLockPooledHandle;
#if !NETFRAMEWORK
    private Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[]? _rwlockProtoPromisesHandle;
#endif
    private volatile int _counter;

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 5 }
    };

    [Params(0, 1, 2, 5)]
    public int Iterations { get; set; } = 5;

    public AsyncReaderWriterLockUpgradedWriterBenchmark() { }

    public AsyncReaderWriterLockUpgradedWriterBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task ReaderLockSlimMultipleTestAsync(CancellationType cancellationType)
    {
        SlimGlobalSetup();
        var result = UpgradedWriterLockPooledAsync(cancellationType);
        return result;
    }

    [GlobalSetup(Target = nameof(ReadLockReaderWriterLockSlim))]
    public void SlimGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledHandle = new CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for ReaderWriterLockSlim upgradeable read lock.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradedWriterLock", "System", "RWLockSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public void ReadLockReaderWriterLockSlim(CancellationType cancellationType)
    {
        _rwLockSlim.EnterUpgradeableReadLock();
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _rwLockSlim.EnterReadLock();
            }

            for (int i = 0; i < Iterations; i++)
            {
                _rwLockSlim.ExitReadLock();
            }

            _rwLockSlim.EnterWriteLock();
            unchecked { _counter++; }
            _rwLockSlim.ExitWriteLock();
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
        var result = UpgradedWriterLockPooledAsync(cancellationType);
        return result;
    }

    [GlobalSetup(Target = nameof(UpgradedWriterLockPooledAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledHandle = new CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock (upgraded writer).
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("UpgradedWriterLock", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task UpgradedWriterLockPooledAsync(CancellationType cancellationType)
    {
        using var reader = await _rwLockPooled.UpgradeableReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        for (int i = 0; i < Iterations; i++)
        {
            _rwLockPooledHandle![i] = await _rwLockPooled.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        }

        var writerLock = reader.UpgradeToWriterLockAsync(cancellationType.CancellationToken);
        for (int i = 0; i < Iterations; i++)
        {
            _rwLockPooledHandle![i].Dispose();
        }

        using (await writerLock.ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockVSThreadingMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingGlobalSetup();
        var result = ReaderLockVSThreadingAsync(cancellationType);
        return result;
    }

    [GlobalSetup(Target = nameof(ReaderLockVSThreadingAsync))]
    public void VSThreadingGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockVSThreadingHandle = new Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for VS.Threading async reader-writer lock (upgraded writer).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradedWriterLock", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task ReaderLockVSThreadingAsync(CancellationType cancellationType)
    {
        using var reader = await _rwLockVSThreading.UpgradeableReadLockAsync(cancellationType.CancellationToken);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockVSThreadingHandle![i] = await _rwLockVSThreading.ReadLockAsync(cancellationType.CancellationToken);
        }

        var writerLock = _rwLockVSThreading.WriteLockAsync(cancellationType.CancellationToken);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockVSThreadingHandle![i].Dispose();
        }

        using (await writerLock)
        {
            unchecked { _counter++; }
        }
    }

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockProtoPromisesTestAsync(CancellationType cancellationType)
    {
        ProtoPromisesGlobalSetup();
        var result = UpgradedWriterLockProtoPromisesAsync(cancellationType);
        return result;
    }

    [GlobalSetup(Target = nameof(UpgradedWriterLockProtoPromisesAsync))]
    public void ProtoPromisesGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockProtoPromisesHandle = new Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[Iterations];
    }

    /// <summary>
    /// Benchmark for Proto.Promises async reader-writer lock (upgradeable reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("UpgradedWriterLock", "Proto.Promises")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.ProtoPromisesNoneNotCanceledGroup))]
    public async Task UpgradedWriterLockProtoPromisesAsync(CancellationType cancellationType)
    {
        using var reader = await _rwLockProtoPromises.UpgradeableReaderLockAsync(cancellationType.CancelationToken, false);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockProtoPromisesHandle![i] = await _rwLockProtoPromises.ReaderLockAsync(cancellationType.CancelationToken, false);
        }

        var writerLock = _rwLockProtoPromises.UpgradeToWriterLockAsync(reader, cancellationType.CancelationToken, false);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockProtoPromisesHandle![i].Dispose();
        }

        using (await writerLock)
        {
            unchecked { _counter++; }
        }
    }
#endif
}
