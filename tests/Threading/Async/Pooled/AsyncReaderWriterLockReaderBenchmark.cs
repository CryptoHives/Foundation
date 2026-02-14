// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

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
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of uncontended reader lock operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockReaderBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for ReaderWriterLockSlim read lock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "System", "ReaderWriterLockSlim")]
    public void ReadLockReaderWriterLockSlim()
    {
        _rwLockSlim.EnterReadLock();
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _rwLockSlim.ExitReadLock();
        }
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock (reader).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("ReaderLock", "Pooled")]
    public async Task ReaderLockPooledAsync()
    {
        using (await _rwLockPooled.ReaderLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async reader-writer lock (reader).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "Nito.AsyncEx")]
    public async Task ReaderLockNitoAsync()
    {
        using (await _rwLockNitoAsync.ReaderLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async reader-writer lock (reader).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ReaderLock", "RefImpl")]
    public async Task ReaderLockRefImplAsync()
    {
        using (await _rwLockRefImp.ReaderLockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
}
