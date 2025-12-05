// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring barrier synchronization performance.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance of async barrier implementations
/// when multiple participants synchronize.
/// </para>
/// <para>
/// <b>Test scenario:</b> Multiple participants signal and wait at a barrier.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Barrier:</b> .NET built-in synchronous barrier.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[Description("Measures the performance of barrier synchronization operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncBarrier")]
public class AsyncBarrierSignalAndWaitBenchmark : AsyncBarrierBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for standard Barrier.
    /// </summary>
    [Test]
    [Benchmark]
    public void SignalAndWaitBarrierStandard()
    {
        var barrier = new Barrier(_participantCount);
        var tasks = new Task[_participantCount];
        for (int i = 0; i < _participantCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                barrier.SignalAndWait();
                Interlocked.Increment(ref _counter);
            });
        }
        Task.WaitAll(tasks);
        barrier.Dispose();
    }

    /// <summary>
    /// Benchmark for pooled async barrier.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    public async Task SignalAndWaitPooledAsync()
    {
        var barrier = new AsyncBarrier(_participantCount);
        var tasks = new Task[_participantCount];
        for (int i = 0; i < _participantCount; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                await barrier.SignalAndWaitAsync().ConfigureAwait(false);
                Interlocked.Increment(ref _counter);
            });
        }
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for reference implementation async barrier.
    /// </summary>
    [Test]
    [Benchmark]
    public async Task SignalAndWaitRefImplAsync()
    {
        var barrier = new RefImpl.AsyncBarrier(_participantCount);
        var tasks = new Task[_participantCount];
        for (int i = 0; i < _participantCount; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                await barrier.SignalAndWaitAsync().ConfigureAwait(false);
                Interlocked.Increment(ref _counter);
            });
        }
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}
