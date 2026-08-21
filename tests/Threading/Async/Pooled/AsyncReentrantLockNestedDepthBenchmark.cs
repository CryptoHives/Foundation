// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring how <see cref="AsyncReentrantLock"/>'s cost scales with reentrant nesting depth.
/// </summary>
/// <remarks>
/// <para>
/// There is no baseline to compare against here - plain <see cref="AsyncLock"/> cannot nest at all
/// (it would deadlock), which is the entire reason <see cref="AsyncReentrantLock"/> exists. This benchmark
/// isolates the incremental per-level cost instead: each additional depth pays for one more
/// <see cref="System.Collections.Concurrent.ConcurrentDictionary{TKey,TValue}"/> lookup/insert (the
/// first time that depth is reached), one more generation check against the parent depth, and one more
/// <see cref="System.Threading.AsyncLocal{T}"/> read/write pair on both the way in and the way out.
/// </para>
/// <para>
/// <b>Test scenario:</b> Recursively acquire the same <see cref="AsyncReentrantLock"/> <see cref="Depth"/> times
/// in a row (each acquisition nested inside the previous one's <c>using</c> block), then unwind.
/// </para>
/// <para>
/// <b>Key metric:</b> Mean and Allocated as <see cref="Depth"/> grows (1, 2, 4, 8) - whether cost scales
/// linearly with depth (expected, since each level is independent bookkeeping) or worse.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncReentrantLock")]
public class AsyncReentrantLockNestedDepthBenchmark
{
    private AsyncReentrantLock _reentrantLock = null!;
    private volatile int _counter;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 4 },
        new object[] { 8 },
    };

    /// <summary>
    /// How many levels deep to reentrantly acquire the same lock before unwinding.
    /// </summary>
    [Params(1, 2, 4, 8)]
    public int Depth { get; set; } = 1;

    public AsyncReentrantLockNestedDepthBenchmark() { }

    public AsyncReentrantLockNestedDepthBenchmark(int depth)
    {
        Depth = depth;
    }

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup() => _reentrantLock = new();

    private async Task RecurseAsync(int remaining)
    {
        using (await _reentrantLock.LockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }

            if (remaining > 1)
            {
                await RecurseAsync(remaining - 1).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Benchmark for reentrantly acquiring AsyncReentrantLock <see cref="Depth"/> levels deep.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("NestedDepth", "AsyncReentrantLock")]
    public Task NestedReentrantAcquireAsync() => RecurseAsync(Depth);
}
