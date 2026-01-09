// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // Use ValueTasks correctly

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
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
[TestFixtureSource(nameof(FixtureArgs))]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[Description("Measures the performance of barrier synchronization operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncBarrier")]
public class AsyncBarrierSignalAndWaitBenchmark : AsyncBarrierBaseBenchmark
{
    private Task[] _tasks;
    private ValueTask[] _valueTasks;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 10 },
    };

    public AsyncBarrierSignalAndWaitBenchmark() { }

    public AsyncBarrierSignalAndWaitBenchmark(int participateCount)
    {
        ParticipantCount = participateCount;
    }

    /// <summary>
    /// Override for custom global setup.
    /// </summary>
    public override void GlobalSetup()
    {
        _tasks = new Task[ParticipantCount];
        _valueTasks = new ValueTask[ParticipantCount];
        base.GlobalSetup();
    }

    /// <summary>
    /// Benchmark for standard barrier.
    /// </summary>
    [Test]
    [Benchmark]
    public async Task SignalAndWaitBarrierStandard()
    {
        for (int i = 0; i < ParticipantCount; i++)
        {
            _tasks[i] = Task.Run(_barrierStandard.SignalAndWait);
        }
        for (int i = 0; i < ParticipantCount; i++)
        {
            await _tasks[i].ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Benchmark for pooled async barrier.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    public async Task SignalAndWaitPooledAsync()
    {
        for (int i = 0; i < ParticipantCount; i++)
        {
            _valueTasks[i] = _barrierPooled.SignalAndWaitAsync();
        }
        for (int i = 0; i < ParticipantCount; i++)
        {
            await _valueTasks[i].ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Benchmark for reference implementation async barrier.
    /// </summary>
    [Test]
    [Benchmark]
    public async Task SignalAndWaitRefImplAsync()
    {
        for (int i = 0; i < ParticipantCount; i++)
        {
            _tasks[i] = _barrierRefImp.SignalAndWaitAsync();
        }
        for (int i = 0; i < ParticipantCount; i++)
        {
            await _tasks[i].ConfigureAwait(false);
        }
    }
}
