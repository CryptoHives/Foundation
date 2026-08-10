// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring lock/unlock performance across a growing number of distinct keys.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite quantifies the entry create/evict churn a dictionary-backed keyed lock pays
/// when many distinct keys are used but each is only ever held uncontended: every acquisition creates
/// a fresh entry and every release evicts it again, since no other waiter is ever queued on the same key.
/// This is the worst case for the entry lifecycle machinery, and the case a fixed-size striped lock
/// is specifically designed to avoid paying for.
/// </para>
/// <para>
/// <b>Test scenario:</b> Cycle through <see cref="KeyCount"/> distinct keys, acquiring and releasing
/// the lock for each key once per operation. A single counter increment stands in for the work done
/// under the lock, so the measurement isolates lock overhead rather than modelling a real workload.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;</c> - ConcurrentDictionary-backed entry registry with pooled IValueTaskSource waiters.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;</c> - the reference implementation this type was benchmarked against.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;</c> - fixed stripe array; unaffected by key cardinality by design.</description></item>
/// <item><description><b>KeyedSemaphores:</b> Third-party <c>KeyedSemaphoresDictionary&lt;TKey&gt;</c> - dictionary-backed with ref-count eviction, the closest architectural match to the pooled implementation.</description></item>
/// <item><description><b>KeyedSemaphores (Striped):</b> Third-party <c>KeyedSemaphoresCollection&lt;TKey&gt;</c> - fixed-size striped array; unaffected by key cardinality by design.</description></item>
/// <item><description><b>Dao.IndividualLock:</b> Third-party <c>IndividualLocks&lt;TKey&gt;</c> - dictionary-backed keyed lock library.</description></item>
/// <item><description><b>AsyncUtilities (Striped):</b> Third-party <c>StripedAsyncLock&lt;TKey&gt;</c> - another fixed-size striped implementation; unaffected by key cardinality by design.</description></item>
/// <item><description><b>RefImpl:</b> Theodor Zoulias's "AsyncDuplicateLock" reference implementation (SemaphoreSlim per key, ConcurrentDictionary with compare-and-swap ref-counting).</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations as <see cref="KeyCount"/> grows
/// (1, 4, 16, 64), isolating dictionary entry churn from actual lock contention.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures uncontended lock/unlock performance across a growing number of distinct keys.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockCardinalityBenchmark : AsyncKeyedLockBaseBenchmark
{
    private string[]? _keys;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 4 },
        new object[] { 16 },
        new object[] { 64 }
    };

    [Params(1, 4, 16, 64)]
    public int KeyCount { get; set; } = 4;

    public AsyncKeyedLockCardinalityBenchmark() { }

    public AsyncKeyedLockCardinalityBenchmark(int keyCount)
    {
        KeyCount = keyCount;
    }

    private void SetUpKeys()
    {
        base.GlobalSetup();
        _keys = new string[KeyCount];
        for (int i = 0; i < KeyCount; i++)
        {
            _keys[i] = $"key-{i}";
        }
    }

    [Test]
    public Task LockUnlockPooledCardinalityTestAsync()
    {
        PooledGlobalSetup();
        return LockUnlockPooledCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledCardinalityAsync))]
    public void PooledGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the pooled keyed async lock cycling through <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Cardinality", "Pooled")]
    public async Task LockUnlockPooledCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockPooled.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockThirdPartyCardinalityTestAsync()
    {
        ThirdPartyGlobalSetup();
        return LockUnlockThirdPartyCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockThirdPartyCardinalityAsync))]
    public void ThirdPartyGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library cycling through <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "AsyncKeyedLock")]
    public async Task LockUnlockThirdPartyCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockThirdParty.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockStripedCardinalityTestAsync()
    {
        StripedGlobalSetup();
        return LockUnlockStripedCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockStripedCardinalityAsync))]
    public void StripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant cycling through <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "AsyncKeyedLock (Striped)")]
    public async Task LockUnlockStripedCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

#if !NETFRAMEWORK
    [Test]
    public Task LockUnlockKeyedSemaphoresDictionaryCardinalityTestAsync()
    {
        KeyedSemaphoresDictionaryGlobalSetup();
        return LockUnlockKeyedSemaphoresDictionaryCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresDictionaryCardinalityAsync))]
    public void KeyedSemaphoresDictionaryGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores dictionary-backed lock cycling through
    /// <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "KeyedSemaphores")]
    public async Task LockUnlockKeyedSemaphoresDictionaryCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockKeyedSemaphoresDictionary.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockKeyedSemaphoresStripedCardinalityTestAsync()
    {
        KeyedSemaphoresStripedGlobalSetup();
        return LockUnlockKeyedSemaphoresStripedCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresStripedCardinalityAsync))]
    public void KeyedSemaphoresStripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores striped variant cycling through
    /// <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "KeyedSemaphores (Striped)")]
    public async Task LockUnlockKeyedSemaphoresStripedCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockKeyedSemaphoresStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }
#endif

    [Test]
    public Task LockUnlockDaoCardinalityTestAsync()
    {
        DaoGlobalSetup();
        return LockUnlockDaoCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockDaoCardinalityAsync))]
    public void DaoGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party Dao.IndividualLock library cycling through
    /// <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "Dao.IndividualLock")]
    public async Task LockUnlockDaoCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockDao.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockAsyncUtilitiesStripedCardinalityTestAsync()
    {
        AsyncUtilitiesStripedGlobalSetup();
        return LockUnlockAsyncUtilitiesStripedCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockAsyncUtilitiesStripedCardinalityAsync))]
    public void AsyncUtilitiesStripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncUtilities striped async lock cycling through
    /// <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "AsyncUtilities (Striped)")]
    public async Task LockUnlockAsyncUtilitiesStripedCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockAsyncUtilitiesStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockRefImplCardinalityTestAsync()
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplCardinalityAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplCardinalityAsync))]
    public void RefImplGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the "AsyncDuplicateLock" reference implementation cycling through
    /// <see cref="KeyCount"/> distinct keys.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Cardinality", "RefImpl")]
    public async Task LockUnlockRefImplCardinalityAsync()
    {
        foreach (string key in _keys!)
        {
            using (await _lockRefImpl.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }
}
