// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Threading.Tests.Async.RefImpl;

/// <summary>
/// Benchmarks measuring single-threaded reader lock performance on AsyncReaderWriterLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of async reader-writer locks
/// for reader acquisition in uncontended scenarios.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and release a reader lock with no contention.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>ReaderWriterLockSlim:</b> .NET built-in synchronous reader-writer lock.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based reader-writer lock.</description></item>
/// <item><description><b>Proto.Promises:</b> Third-party async library with Promises-based reader-writer lock.</description></item>
/// <item><description><b>VS.Threading:</b> Third-party async library with custom Task-based reader-writer lock.</description></item>
/// <item><description><b>RefImpl:</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockReaderBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private AsyncReaderWriterLock.Releaser[]? _rwLockRefImpHandle;
    private Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[]? _rwlockVSThreadingHandle;
    private CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[]? _rwLockPooledHandle;
    private IDisposable[]? _rwLockNitoHandle;
#if !NETFRAMEWORK
    private Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[]? _rwlockProtoPromisesHandle;
#endif

    private volatile int _counter;

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(0, 1, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncReaderWriterLockReaderBenchmark() { }

    public AsyncReaderWriterLockReaderBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    /// <summary>
    /// Benchmark for ReaderWriterLockSlim read lock.
    /// </summary>
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "System", "RWLockSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public void ReadLockReaderWriterLockSlim(CancellationType cancellationType)
    {
        _rwLockSlim.EnterReadLock();
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _rwLockSlim.EnterReadLock();
                unchecked { _counter++; }
            }

            for (int i = 0; i < Iterations; i++)
            {
                _rwLockSlim.ExitReadLock();
            }
        }
        finally
        {
            _rwLockSlim.ExitReadLock();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockPooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        return ReaderLockPooledAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(ReaderLockPooledAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledHandle = new CryptoHives.Foundation.Threading.Async.Pooled.AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock (reader).
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("ReaderLock", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task ReaderLockPooledAsync(CancellationType cancellationType)
    {
        using var result = await _rwLockPooled.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        for (int i = 0; i < Iterations; i++)
        {
            _rwLockPooledHandle![i] = await _rwLockPooled.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
            unchecked { _counter++; }
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _rwLockPooledHandle![i].DisposeAsync().ConfigureAwait(false);
        }
    }

#if !SIGNASSEMBLY
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockNitoMultipleTestAsync(CancellationType cancellationType)
    {
        NitoGlobalSetup();
        return ReaderLockNitoAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(ReaderLockNitoAsync))]
    public void NitoGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockNitoHandle = new IDisposable[Iterations];
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async reader-writer lock (reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "Nito.AsyncEx")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task ReaderLockNitoAsync(CancellationType cancellationType)
    {
        using var result = await _rwLockNitoAsync.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);

        for (int i = 0; i < Iterations; i++)
        {
            _rwLockNitoHandle![i] = await _rwLockNitoAsync.ReaderLockAsync(cancellationType.CancellationToken).ConfigureAwait(false);
            unchecked { _counter++; }
        }

        for (int i = 0; i < Iterations; i++)
        {
            _rwLockNitoHandle![i].Dispose();
        }
    }
#endif

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task ReaderLockRefImplTestAsync(CancellationType cancellationType)
    {
        RefImplGlobalSetup();
        return ReaderLockRefImplAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(ReaderLockRefImplAsync))]
    public void RefImplGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockRefImpHandle = new AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for reference implementation async reader-writer lock (reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "RefImpl")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task ReaderLockRefImplAsync(CancellationType cancellationType)
    {
        using (await _rwLockRefImp.ReaderLockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _rwLockRefImpHandle![i] = await _rwLockRefImp.ReaderLockAsync().ConfigureAwait(false);
                unchecked { _counter++; }
            }
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _rwLockRefImpHandle![i].DisposeAsync().ConfigureAwait(false);
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockVSThreadingMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingGlobalSetup();
        return ReaderLockVSThreadingAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(ReaderLockVSThreadingAsync))]
    public void VSThreadingGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockVSThreadingHandle = new Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser[Iterations];
    }

    /// <summary>
    /// Benchmark for VS.Threading async reader-writer lock (reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task ReaderLockVSThreadingAsync(CancellationType cancellationType)
    {
        using var result = await _rwLockVSThreading.ReadLockAsync(cancellationType.CancellationToken);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockVSThreadingHandle![i] = await _rwLockVSThreading.ReadLockAsync(cancellationType.CancellationToken);
            unchecked { _counter++; }
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _rwlockVSThreadingHandle![i].DisposeAsync().ConfigureAwait(false);
        }
    }

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task ReaderLockProtoPromisesTestAsync(CancellationType cancellationType)
    {
        ProtoPromisesGlobalSetup();
        return ReaderLockProtoPromisesAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(ReaderLockProtoPromisesAsync))]
    public void ProtoPromisesGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockProtoPromisesHandle = new Proto.Promises.Threading.AsyncReaderWriterLock.ReaderKey[Iterations];
    }

    /// <summary>
    /// Benchmark for Proto.Promises async reader-writer lock (reader).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "Proto.Promises")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.ProtoPromisesNoneNotCanceledGroup))]
    public async Task ReaderLockProtoPromisesAsync(CancellationType cancellationType)
    {
        using var result = await _rwLockProtoPromises.ReaderLockAsync(cancellationType.CancelationToken, false);
        for (int i = 0; i < Iterations; i++)
        {
            _rwlockProtoPromisesHandle![i] = await _rwLockProtoPromises.ReaderLockAsync(cancellationType.CancelationToken, false);
            unchecked { _counter++; }
        }

        for (int i = 0; i < Iterations; i++)
        {
            _rwlockProtoPromisesHandle![i].Dispose();
        }
    }
#endif
}
