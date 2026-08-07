// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// CA1508 fires on the null-check after StripedAsyncKeyedLocker.LockOrNullAsync specifically, since that
// overload's nullability annotations differ from the other libraries' otherwise-identical-shaped APIs
// used in this file. The check is correct and intentional - keep it consistent across every competitor
// here rather than special-casing one of them.
#pragma warning disable CA1508 // Avoid dead conditional code

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring non-blocking try-acquire performance on a single, uncontended key.
/// </summary>
/// <remarks>
/// <para>
/// A separate class (rather than more methods on <see cref="AsyncKeyedLockSingleKeyBenchmark"/>) because
/// its baseline is a different kind of operation - a synchronous, non-waiting attempt instead of an
/// awaited acquisition - so the two shouldn't share one Ratio column.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly attempt to acquire, and immediately release, a single, constant,
/// never-contended key via each library's non-blocking try-acquire API.
/// </para>
/// <para>
/// <b>Compared implementations:</b> only libraries that expose a native non-blocking try-acquire API are
/// included here - <c>Dao.IndividualLock</c>, <c>AsyncUtilities</c>'s <c>StripedAsyncLock</c>, and the
/// hand-rolled <c>RefImpl</c> reference pattern have none, and emulating one via a first-principles
/// wrapper would not be a fair comparison of what each library actually ships.
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;.TryLock</c> - a single atomic exchange, synchronous and non-throwing on failure.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;.LockOrNullAsync(key, 0)</c>.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;.LockOrNullAsync(key, 0)</c>.</description></item>
/// <item><description><b>KeyedSemaphores:</b> Third-party <c>KeyedSemaphoresDictionary&lt;TKey&gt;.TryLockAsync(key, TimeSpan.Zero, ct)</c>.</description></item>
/// <item><description><b>KeyedSemaphores (Striped):</b> Third-party <c>KeyedSemaphoresCollection&lt;TKey&gt;.TryLockAsync(key, TimeSpan.Zero, ct)</c>.</description></item>
/// </list>
/// <para>
/// This same access pattern - many threads racing <c>TryLock</c>/<c>LockOrNull</c> on one key under a
/// pooled entry/releaser implementation - is exactly the shape of a real, currently-unfixed upstream
/// race condition in the third-party AsyncKeyedLock library (GitHub issue #68): under sustained
/// high-throughput contention, its pooled releaser could be recycled for a different key while a stale
/// reference to it was still in flight, letting two threads hold the "same" key simultaneously. See
/// <see cref="AsyncKeyedLockTests.TryLockNeverAllowsTwoSimultaneousHoldersUnderContention"/> for a direct
/// stress test proving our own <c>TryLock</c> doesn't share that failure mode.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of non-blocking try-acquire operations on a single, uncontended key.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockTryLockBenchmark : AsyncKeyedLockBaseBenchmark
{
    private const string Key = "trylock-benchmark-key";

    /// <summary>
    /// Benchmark for the pooled keyed async lock's non-blocking try-acquire (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("TryLock", "Pooled")]
    public void TryLockPooledSingleKey()
    {
        if (_lockPooled.TryLock(Key, out AsyncKeyedLock<string>.Releaser releaser))
        {
            unchecked { _counter++; }
            releaser.Dispose();
        }
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library's non-blocking try-acquire (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("TryLock", "AsyncKeyedLock")]
    public async Task TryLockThirdPartySingleKeyAsync()
    {
        using IDisposable? releaser = await _lockThirdParty.LockOrNullAsync(Key, 0).ConfigureAwait(false);
        if (releaser is not null)
        {
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant's non-blocking try-acquire
    /// (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("TryLock", "AsyncKeyedLock (Striped)")]
    public async Task TryLockStripedSingleKeyAsync()
    {
        using IDisposable? releaser = await _lockStriped.LockOrNullAsync(Key, 0).ConfigureAwait(false);
        if (releaser is not null)
        {
            unchecked { _counter++; }
        }
    }

#if !NETFRAMEWORK
    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores dictionary-backed lock's non-blocking try-acquire
    /// (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("TryLock", "KeyedSemaphores")]
    public async Task TryLockKeyedSemaphoresDictionarySingleKeyAsync()
    {
        using IDisposable? releaser = await _lockKeyedSemaphoresDictionary
            .TryLockAsync(Key, TimeSpan.Zero, CancellationToken.None).ConfigureAwait(false);
        if (releaser is not null)
        {
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores striped variant's non-blocking try-acquire
    /// (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("TryLock", "KeyedSemaphores (Striped)")]
    public async Task TryLockKeyedSemaphoresStripedSingleKeyAsync()
    {
        using IDisposable? releaser = await _lockKeyedSemaphoresStriped
            .TryLockAsync(Key, TimeSpan.Zero, CancellationToken.None).ConfigureAwait(false);
        if (releaser is not null)
        {
            unchecked { _counter++; }
        }
    }
#endif
}
