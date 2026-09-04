// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncKeyedLock;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;
using RefImpl = Threading.Tests.Async.RefImpl;

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
/// <item><description><b>KeyedSemaphores:</b> Third-party <c>KeyedSemaphoresDictionary&lt;TKey&gt;</c> - dictionary-backed with ref-count eviction, the closest architectural match to the pooled implementation.</description></item>
/// <item><description><b>KeyedSemaphores (Striped):</b> Third-party <c>KeyedSemaphoresCollection&lt;TKey&gt;</c> - fixed-size striped array, same tradeoff as the AsyncKeyedLock striped variant.</description></item>
/// <item><description><b>Dao.IndividualLock:</b> Third-party <c>IndividualLocks&lt;TKey&gt;</c> - dictionary-backed keyed lock library.</description></item>
/// <item><description><b>AsyncUtilities (Striped):</b> Third-party <c>StripedAsyncLock&lt;TKey&gt;</c> - another fixed-size striped implementation.</description></item>
/// <item><description><b>RefImpl:</b> Theodor Zoulias's "AsyncDuplicateLock" reference implementation (SemaphoreSlim per key, ConcurrentDictionary with compare-and-swap ref-counting) - the baseline the AsyncKeyedLock author benchmarks against.</description></item>
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
            unchecked { _counter++; }
        }
    }

#if !NETFRAMEWORK
    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores dictionary-backed lock (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "KeyedSemaphores")]
    public async Task LockUnlockKeyedSemaphoresDictionarySingleKeyAsync()
    {
        using (await _lockKeyedSemaphoresDictionary.LockAsync(Key).ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores striped variant (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "KeyedSemaphores (Striped)")]
    public async Task LockUnlockKeyedSemaphoresStripedSingleKeyAsync()
    {
        using (await _lockKeyedSemaphoresStriped.LockAsync(Key).ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
#endif

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for the third-party Dao.IndividualLock library (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "Dao.IndividualLock")]
    public async Task LockUnlockDaoSingleKeyAsync()
    {
        using (await _lockDao.LockAsync(Key).ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }

    /// <summary>
    /// Benchmark for the third-party AsyncUtilities striped async lock (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "AsyncUtilities (Striped)")]
    public async Task LockUnlockAsyncUtilitiesStripedSingleKeyAsync()
    {
        using (await _lockAsyncUtilitiesStriped.LockAsync(Key).ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
#endif

    /// <summary>
    /// Benchmark for the "AsyncDuplicateLock" reference implementation (single uncontended key).
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("LockAsync", "RefImpl")]
    public async Task LockUnlockRefImplSingleKeyAsync()
    {
        using (await _lockRefImpl.LockAsync(Key).ConfigureAwait(false))
        {
            unchecked { _counter++; }
        }
    }
}
