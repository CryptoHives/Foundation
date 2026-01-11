// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-threaded writer lock performance on AsyncReaderWriterLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of async reader-writer locks
/// for writer acquisition in uncontended scenarios.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and release a writer lock with no contention.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>ReaderWriterLockSlim:</b> .NET built-in synchronous reader-writer lock.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based reader-writer lock.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[Description("Measures the performance of uncontended writer lock operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockWriterBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for ReaderWriterLockSlim write lock.
    /// </summary>
    [Test]
    [Benchmark]
    public void WriteLockReaderWriterLockSlim()
    {
        _rwLockSlim.EnterWriteLock();
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _rwLockSlim.ExitWriteLock();
        }
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock (writer).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    public async Task WriterLockPooledAsync()
    {
        using (await _rwLockPooled.WriterLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async reader-writer lock (writer).
    /// </summary>
    [Test]
    [Benchmark]
    public async Task WriterLockNitoAsync()
    {
        using (await _rwLockNitoAsync.WriterLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async reader-writer lock (writer).
    /// </summary>
    [Test]
    [Benchmark]
    public async Task WriterLockRefImplAsync()
    {
        using (await _rwLockRefImp.WriterLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
}
