// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring Set-then-Wait performance on AutoResetEvent implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the fast-path performance when an auto-reset event
/// is signaled before a wait operation begins, allowing immediate completion without queuing.
/// </para>
/// <para>
/// <b>Test scenario:</b> Signal the event first, then immediately wait (should complete synchronously).
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Standard:</b> Synchronous System.Threading.AutoResetEvent (blocking wait).</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library using Task-based primitives.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Fast-path overhead and memory allocations when event is pre-signaled.
/// </para>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[BenchmarkCategory("AsyncAutoResetEvent")]
public class AsyncAutoResetEventSetThenWaitBenchmark : AsyncAutoResetEventBaseBenchmark
{
    /// <summary>
    /// Benchmark for standard synchronous AutoResetEvent Set-then-Wait.
    /// </summary>
    /// <remarks>
    /// Measures the synchronous blocking wait after signaling.
    /// This is a pure synchronous baseline with no async overhead.
    /// </remarks>
    [Test]
    [BenchmarkCategory("SetThenWait", "Standard")]
    public void AutoResetEventSetThenWait()
    {
        _ = _eventStandard!.Set();
        _ = _eventStandard!.WaitOne();
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event Set-then-Wait.
    /// </summary>
    /// <remarks>
    /// Measures the fast-path async completion when the event is pre-signaled.
    /// The pooled implementation should return a completed ValueTask immediately.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SetThenWait", "Pooled")]
    public async Task PooledAsyncAutoResetEventSetThenWaitAsync()
    {
        _eventPooled!.Set();
        await _eventPooled!.WaitAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event Set-then-Wait using AsTask().
    /// </summary>
    /// <remarks>
    /// Measures the fast-path async completion when the event is pre-signaled.
    /// The pooled implementation should return a completed ValueTask immediately
    /// which is then converted to a Task.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SetThenWait", "PooledAsTask")]
    public async Task PooledAsTaskAsyncAutoResetEventSetThenWaitAsync()
    {
        _eventPooled!.Set();
        await _eventPooled!.WaitAsync().AsTask().ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async auto-reset event Set-then-Wait.
    /// </summary>
    /// <remarks>
    /// Measures the fast-path async completion for the Nito.AsyncEx library.
    /// This implementation uses Task-based primitives.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("SetThenWait", "Nito.AsyncEx")]
    public async Task NitoAsyncAutoResetEventSetThenWaitAsync()
    {
        _eventNitoAsync!.Set();
        await _eventNitoAsync!.WaitAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for reference implementation async auto-reset event Set-then-Wait (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the fast-path performance of the TaskCompletionSource-based reference implementation.
    /// This serves as the baseline for comparing allocation-free patterns.
    /// </remarks>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("SetThenWait", "RefImpl")]
    public async Task RefImplAsyncAutoResetEventSetThenWaitAsync()
    {
        _eventRefImp!.Set();
        await _eventRefImp!.WaitAsync().ConfigureAwait(false);
    }
}

