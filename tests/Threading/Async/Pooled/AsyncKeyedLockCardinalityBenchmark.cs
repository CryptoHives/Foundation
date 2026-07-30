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
/// the lock for each key once per operation.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;</c> - ConcurrentDictionary-backed entry registry with pooled IValueTaskSource waiters.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;</c> - the reference implementation this type was benchmarked against.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;</c> - fixed stripe array; unaffected by key cardinality by design.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations as <see cref="KeyCount"/> grows
/// (1, 4, 16, 64), isolating dictionary entry churn from actual lock contention.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
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
            using (await _lockPooled.LockAsync(key).ConfigureAwait(false)) { }
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
            using (await _lockThirdParty.LockAsync(key).ConfigureAwait(false)) { }
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
            using (await _lockStriped.LockAsync(key).ConfigureAwait(false)) { }
        }
    }
}
