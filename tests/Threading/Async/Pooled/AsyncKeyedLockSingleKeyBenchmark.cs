// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring single-key, uncontended lock/unlock performance on keyed async lock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite isolates the administrative overhead a keyed lock pays on top of a plain
/// <c>AsyncLock</c>-style primitive: looking up (or creating) the per-key entry and updating its
/// reference count, even when the key is never actually contended.
/// </para>
/// <para>
/// <b>Test scenario:</b> Repeatedly acquire and immediately release the lock for a single, constant key.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;</c> - ConcurrentDictionary-backed entry registry with pooled IValueTaskSource waiters.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;</c> - the reference implementation this type was benchmarked against.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;</c> - fixed stripe array instead of a dictionary, no per-key entry lifecycle.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Per-operation overhead and memory allocations for the entry lookup/ref-count
/// bookkeeping path, since the key is never contended in this benchmark.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of uncontended lock/unlock operations on a single key.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockSingleKeyBenchmark : AsyncKeyedLockBaseBenchmark
{
    private const string Key = "benchmark-key";
    private volatile int _counter;

    /// <summary>
    /// Benchmark for the pooled keyed async lock (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("LockAsync", "Pooled")]
    public async Task LockUnlockPooledSingleKeyAsync()
    {
        using (await _lockPooled.LockAsync(Key).ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "AsyncKeyedLock")]
    public async Task LockUnlockThirdPartySingleKeyAsync()
    {
        using (await _lockThirdParty.LockAsync(Key).ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "AsyncKeyedLock (Striped)")]
    public async Task LockUnlockStripedSingleKeyAsync()
    {
        using (await _lockStriped.LockAsync(Key).ConfigureAwait(false))
        {
            // simulate work
            unchecked { _counter++; }
        }
    }
}
