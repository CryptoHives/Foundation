// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CHTEXP001 // AsyncReentrantLock is experimental

namespace Threading.Tests.Benchmarks.Pooled.AsyncReentrantLock;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Measures how the cost of <see cref="AsyncReentrantLock"/> scales with nesting depth.
/// </summary>
/// <remarks>
/// There is no baseline: <see cref="AsyncLock"/> deadlocks on the first nested acquisition.
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
    [Benchmark]
    [BenchmarkCategory("NestedDepth", "AsyncReentrantLock")]
    public Task NestedReentrantAcquireAsync() => RecurseAsync(Depth);
}
