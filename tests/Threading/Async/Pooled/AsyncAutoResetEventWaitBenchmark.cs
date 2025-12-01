// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA1062 // Validate arguments of public methods

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring async wait performance on AutoResetEvent implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance of waiting on an auto-reset event
/// across different implementations when the event is signaled after the wait begins.
/// </para>
/// <para>
/// <b>Test scenario:</b> Start waiting on the event, then immediately signal it and await completion.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (ValueTask):</b> Allocation-free implementation using pooled IValueTaskSource and ValueTask.</description></item>
/// <item><description><b>Pooled (Task):</b> Same pooled implementation but converted to Task via AsTask().</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library using Task-based primitives.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations per operation.
/// </para>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[BenchmarkCategory("AsyncAutoResetEvent")]
public class AsyncAutoResetEventWaitBenchmark : AsyncAutoResetEventBaseBenchmark
{
    /// <summary>
    /// Benchmark for pooled async auto-reset event using Task (converted from ValueTask).
    /// </summary>
    /// <remarks>
    /// Measures the performance when ValueTask is converted to Task via AsTask(),
    /// which incurs allocation overhead compared to awaiting ValueTask directly.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "PooledAsTask")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task PooledAsyncAutoResetEventTaskWaitAsync(CancellationType cancellationType)
    {
        ValueTask vt = _eventPooled!.WaitAsync(cancellationType.CancellationToken);
        _eventPooled.Set();
        await vt.AsTask().ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event using ValueTask directly.
    /// </summary>
    /// <remarks>
    /// Measures the allocation-free hot path using pooled IValueTaskSource.
    /// This is the optimal usage pattern for the pooled implementation.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "Pooled")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task PooledAsyncAutoResetEventValueTaskWaitAsync(CancellationType cancellationType)
    {
        ValueTask vt = _eventPooled!.WaitAsync(cancellationType.CancellationToken);
        _eventPooled.Set();
        await vt.ConfigureAwait(false);
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async auto-reset event.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party Nito.AsyncEx library,
    /// which uses Task-based async primitives and allocates per waiter.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "Nito.AsyncEx")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task NitoAsyncAutoResetEventTaskWaitAsync(CancellationType cancellationType)
    {
        Task t = _eventNitoAsync!.WaitAsync(cancellationType.CancellationToken);
        _eventNitoAsync.Set();
        await t.ConfigureAwait(false);
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async auto-reset event (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the performance of a TaskCompletionSource-based reference implementation.
    /// This serves as the baseline for comparing allocation-free pooled patterns.
    /// </remarks>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Wait", "RefImpl")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task RefImplAsyncAutoResetEventTaskWaitAsync(CancellationType cancellationType)
    {
        Task t = _eventRefImp!.WaitAsync();
        _eventRefImp.Set();
        await t.ConfigureAwait(false);
    }
}

