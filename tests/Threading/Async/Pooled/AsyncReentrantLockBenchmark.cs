// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring the overhead <see cref="AsyncLockEx"/>'s reentrancy machinery adds over plain
/// <see cref="AsyncLock"/> for a single, uncontended, non-nested acquisition.
/// </summary>
/// <remarks>
/// <para>
/// This is a narrow, self-contained benchmark, not part of the competitive third-party comparison suite
/// the other Threading benchmarks use: <see cref="AsyncLockEx"/> is explicitly prototype-status (see its
/// type-level remarks) and solves a different problem (reentrancy) than the primitives compared
/// elsewhere, so putting it side by side with hardened, allocation-optimized libraries would misleadingly
/// imply it's a finished, directly comparable primitive. The point here is only to quantify its own
/// overhead against the non-reentrant baseline it's built on top of.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and immediately release a single, uncontended, top-level-only
/// (never nested) lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>AsyncLock (baseline):</b> The plain, non-reentrant, allocation-free pooled lock this whole library is built around.</description></item>
/// <item><description><b>AsyncLockEx:</b> The reentrant prototype - one <see cref="System.Threading.AsyncLocal{T}"/> read, a <see cref="System.Collections.Concurrent.ConcurrentDictionary{TKey,TValue}"/> lookup for the depth-0 lock, a generation check, and an <see cref="System.Threading.AsyncLocal{T}"/> write, on top of the same underlying AsyncLock acquisition.</description></item>
/// </list>
/// <para>
/// <b>Key metric:</b> how much the reentrancy bookkeeping costs even when nothing is actually nested -
/// the best case for <see cref="AsyncLockEx"/>, since every acquisition here targets depth 0 with no
/// fallback or misuse-guard work to do.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures single uncontended lock/unlock overhead: AsyncLockEx vs the plain AsyncLock it wraps.")]
[NonParallelizable]
[BenchmarkCategory("AsyncLockEx")]
public class AsyncLockExBenchmark
{
    private AsyncLock _lockPlain = null!;
    private AsyncLockEx _lockEx = null!;
    private volatile int _counter;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _lockPlain = new();
        _lockEx = new();
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
    /// Benchmark for the reentrant AsyncLockEx prototype (single uncontended, non-nested acquisition).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Single", "AsyncLockEx")]
    public async Task LockUnlockExSingleAsync()
    {
        using (await _lockEx.LockAsync().ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
}
