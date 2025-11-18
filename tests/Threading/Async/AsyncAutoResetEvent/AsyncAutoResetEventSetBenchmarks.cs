// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncAutoResetEvent;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;

/// <summary>
/// Benchmarks measuring Set operation overhead on AutoResetEvent implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the raw performance overhead of signaling an auto-reset event
/// when no waiters are queued. It measures the cost of the Set() operation itself without
/// the complication of waiter completion or queue management.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly call Set() on an event with no queued waiters.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Standard:</b> Synchronous System.Threading.AutoResetEvent (OS-level kernel object).</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource with interlocked signaled flag.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library using Task-based primitives with internal state management.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and managed state.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Pure signaling overhead and memory allocations when event is set without waiters.
/// This represents the minimal cost of the Set() operation in each implementation.
/// </para>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[BenchmarkCategory("AsyncAutoResetEvent")]
public class AsyncAutoResetEventSetBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    /// <summary>
    /// Benchmark for standard synchronous <see cref="AutoResetEvent"/> Set operation.
    /// </summary>
    /// <remarks>
    /// Measures the baseline performance of the OS-level synchronous AutoResetEvent.Set() call.
    /// This involves kernel transitions and is the synchronous baseline for comparison.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Standard")]
    public void AutoResetEventSet()
    {
        _eventStandard!.Set();
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event Set operation.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the allocation-free async implementation's Set() method.
    /// When no waiters are queued, this simply sets an interlocked signaled flag.
    /// This is a pure managed operation with minimal overhead.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Pooled")]
    public void PooledAsyncAutoResetEventSet()
    {
        _eventPooled!.Set();
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async auto-reset event Set operation.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party Nito.AsyncEx library's Set() method.
    /// This implementation uses Task-based primitives and internal locking for state management.
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Nito.AsyncEx")]
    public void NitoAsyncAutoResetEventSet()
    {
        _eventNitoAsync!.Set();
    }

    /// <summary>
    /// Benchmark for reference implementation async auto-reset event Set operation (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the performance of the TaskCompletionSource-based reference implementation's Set() method.
    /// This serves as the baseline for comparing managed async event signaling overhead.
    /// Uses locking and queue management for state synchronization.
    /// </remarks>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Set", "RefImpl")]
    public void RefImplAsyncAutoResetEventSet()
    {
        _eventRefImpl!.Set();
    }
}

