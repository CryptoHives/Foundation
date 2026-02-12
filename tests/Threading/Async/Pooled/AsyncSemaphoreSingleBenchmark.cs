// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-threaded wait/release performance on AsyncSemaphore implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance of async semaphores in uncontended scenarios
/// where semaphore acquisition completes immediately without queuing.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and immediately release an uncontended semaphore with count 1.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>SemaphoreSlim:</b> .NET built-in async semaphore.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based semaphore.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Fast-path overhead and memory allocations when no contention exists.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of uncontended semaphore wait/release operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncSemaphore")]
public class AsyncSemaphoreSingleBenchmark : AsyncSemaphoreBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for SemaphoreSlim used as a semaphore.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitRelease", "SemaphoreSlim", "SemaphoreSlim")]
    public async Task WaitReleaseSemaphoreSlimSingleAsync()
    {
        await _semaphoreSlim.WaitAsync().ConfigureAwait(false);
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    /// <summary>
    /// Benchmark for pooled async semaphore (single uncontended acquisition).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("WaitRelease", "Pooled")]
    public async Task WaitReleasePooledSingleAsync()
    {
        await _semaphorePooled.WaitAsync().ConfigureAwait(false);
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _semaphorePooled.Release();
        }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async semaphore (single uncontended acquisition).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitRelease", "Nito.AsyncEx")]
    public async Task WaitReleaseNitoSingleAsync()
    {
        await _semaphoreNitoAsync.WaitAsync().ConfigureAwait(false);
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _semaphoreNitoAsync.Release();
        }
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async semaphore (single uncontended acquisition).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitRelease", "RefImpl")]
    public async Task WaitReleaseRefImplSingleAsync()
    {
        await _semaphoreRefImp.WaitAsync().ConfigureAwait(false);
        try
        {
            unchecked { _counter++; }
        }
        finally
        {
            _semaphoreRefImp.Release();
        }
    }
}
