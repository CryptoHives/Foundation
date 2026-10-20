// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Threading.Tests.Benchmarks.Pooled.AsyncReentrantLock;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Measures the overhead of <see cref="AsyncReentrantLock"/> over the <see cref="AsyncLock"/> it is built on,
/// for a single uncontended, non-nested acquisition.
/// </summary>
/// <remarks>
/// Kept out of the third-party comparison suite: the type is a prototype and solves reentrancy, which the
/// compared libraries do not.
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures single uncontended lock/unlock overhead: AsyncReentrantLock vs the plain AsyncLock it wraps.")]
[NonParallelizable]
[BenchmarkCategory("AsyncReentrantLock")]
public class AsyncReentrantLockBenchmark
{
    private AsyncLock _lockPlain = null!;
    private AsyncReentrantLock _reentrantLock = null!;
    private volatile int _counter;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _lockPlain = new();
        _reentrantLock = new();
    }

    /// <summary>
    /// Benchmark for the plain, non-reentrant pooled AsyncLock (single uncontended acquisition).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Single", "AsyncLock")]
    public async Task LockUnlockPlainSingleAsync()
    {
        using (await _lockPlain.LockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for AsyncReentrantLock (single uncontended, non-nested acquisition).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Single", "AsyncReentrantLock")]
    public async Task LockUnlockReentrantSingleAsync()
    {
        using (await _reentrantLock.LockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
}
