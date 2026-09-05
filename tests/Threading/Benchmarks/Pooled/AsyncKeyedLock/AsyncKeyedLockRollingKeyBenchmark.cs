// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncKeyedLock;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RefImpl = Threading.Tests.Async.RefImpl;

/// <summary>
/// Benchmarks measuring lock/unlock performance while rolling through a key space larger than the
/// entry lifecycle's retention capacity, so that keys genuinely age out and get evicted/reallocated
/// instead of always being found cached.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="AsyncKeyedLockCardinalityBenchmark"/> only ever cycles through up to 64 distinct keys -
/// below the pooled implementation's default <c>idleEvictionThreshold</c> (128), so every key it touches
/// stays lingering in the idle backlog forever after its first use. That benchmark suite therefore never
/// exercises the pooled implementation's actual eviction-and-reallocate path (a real <c>_entryPool</c>
/// <c>Get()</c>/<c>Return()</c> round-trip, not just an idle-list reclaim) - only its best case.
/// </para>
/// <para>
/// This suite closes that gap: it draws keys from a <see cref="KeySpaceSize"/>-key table, deliberately
/// sized larger than the retention capacity, and each timed operation touches a contiguous
/// <see cref="WindowSize"/>-key slice that slides forward across operations (wrapping around the table).
/// Once the window has advanced far enough that a key falls outside the most-recently-idled backlog, its
/// entry is genuinely evicted and returned to the pool before the window wraps back around to reuse it -
/// unlike <see cref="AsyncKeyedLockCardinalityBenchmark"/>, where nothing is ever evicted at all.
/// </para>
/// <para>
/// <see cref="AdvanceDivisor"/> controls how much each new window overlaps the previous one, i.e. what
/// fraction of a window's keys are actually new versus still-hot carryover from the last operation: at
/// <c>1</c> consecutive windows are fully disjoint (every key falls out of the idle backlog and gets
/// evicted every cycle, once <see cref="KeySpaceSize"/> exceeds the threshold); at <c>2</c> the window
/// advances by half its size (half its keys carry over as still-hot, half age out); at <c>4</c> it
/// advances by a quarter (three quarters stay hot, only a quarter age out per cycle) - modeling a more
/// realistic mixed hot/cold access pattern instead of the all-or-nothing eviction behavior <c>1</c> gives.
/// </para>
/// <para>
/// <b>Test scenario:</b> Per operation, acquire and release the lock once for each of <see cref="WindowSize"/>
/// keys drawn from a sliding, wrapping window over a <see cref="KeySpaceSize"/>-key table, advancing by
/// <c>WindowSize / AdvanceDivisor</c> keys between operations.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;</c> - the only implementation here with an idle-eviction threshold to actually stress.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;</c> - dictionary-backed, evicts immediately (no lazy eviction), so this axis mostly just scales its baseline cost.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;</c> - fixed stripe array; unaffected by key space size by design.</description></item>
/// <item><description><b>KeyedSemaphores:</b> Third-party <c>KeyedSemaphoresDictionary&lt;TKey&gt;</c> - dictionary-backed with immediate ref-count eviction.</description></item>
/// <item><description><b>KeyedSemaphores (Striped):</b> Third-party <c>KeyedSemaphoresCollection&lt;TKey&gt;</c> - fixed-size striped array; unaffected by key space size by design.</description></item>
/// <item><description><b>Dao.IndividualLock:</b> Third-party <c>IndividualLocks&lt;TKey&gt;</c> - dictionary-backed keyed lock library.</description></item>
/// <item><description><b>AsyncUtilities (Striped):</b> Third-party <c>StripedAsyncLock&lt;TKey&gt;</c> - another fixed-size striped implementation; unaffected by key space size by design.</description></item>
/// <item><description><b>RefImpl:</b> Theodor Zoulias's "AsyncDuplicateLock" reference implementation (SemaphoreSlim per key, ConcurrentDictionary with compare-and-swap ref-counting).</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations as <see cref="KeySpaceSize"/> and
/// <see cref="WindowSize"/> vary - in particular, how much the pooled implementation's Mean/Allocated
/// regress once <see cref="KeySpaceSize"/> exceeds its idle-eviction threshold and real pool churn kicks
/// in, compared to its own best case in <see cref="AsyncKeyedLockCardinalityBenchmark"/>.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures lock/unlock performance as a sliding key window forces entry eviction and reuse.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockRollingKeyBenchmark : AsyncKeyedLockBaseBenchmark
{
    private string[]? _keySpace;
    private int _windowStart;

    public static readonly object[] FixtureArgs = {
        new object[] { 64, 8, 1 },
        new object[] { 64, 8, 2 },
        new object[] { 64, 8, 4 },
        new object[] { 64, 32, 1 },
        new object[] { 64, 32, 2 },
        new object[] { 64, 32, 4 },
        new object[] { 1024, 8, 1 },
        new object[] { 1024, 8, 2 },
        new object[] { 1024, 8, 4 },
        new object[] { 1024, 32, 1 },
        new object[] { 1024, 32, 2 },
        new object[] { 1024, 32, 4 },
    };

    /// <summary>
    /// Total number of distinct keys in the underlying table that the rolling window is drawn from.
    /// </summary>
    [Params(64, 1024)]
    public int KeySpaceSize { get; set; } = 64;

    /// <summary>
    /// Number of keys touched (acquired and released once each) per timed operation, i.e. the size of
    /// the sliding window drawn from <see cref="KeySpaceSize"/>.
    /// </summary>
    [Params(8, 32)]
    public int WindowSize { get; set; } = 8;

    /// <summary>
    /// Divides <see cref="WindowSize"/> to get how many keys the window advances by between operations -
    /// see the class remarks for what each value models.
    /// </summary>
    [Params(1, 2, 4)]
    public int AdvanceDivisor { get; set; } = 1;

    public AsyncKeyedLockRollingKeyBenchmark() { }

    public AsyncKeyedLockRollingKeyBenchmark(int keySpaceSize, int windowSize, int advanceDivisor)
    {
        KeySpaceSize = keySpaceSize;
        WindowSize = windowSize;
        AdvanceDivisor = advanceDivisor;
    }

    private void SetUpKeySpace()
    {
        base.GlobalSetup();
        _keySpace = new string[KeySpaceSize];
        for (int i = 0; i < KeySpaceSize; i++)
        {
            _keySpace[i] = $"key-{i}";
        }
        _windowStart = 0;
    }

    [Test]
    public Task LockUnlockPooledRollingKeyTestAsync()
    {
        PooledGlobalSetup();
        return LockUnlockPooledRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledRollingKeyAsync))]
    public void PooledGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the pooled keyed async lock rolling through a <see cref="WindowSize"/>-key window
    /// over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("RollingKey", "Pooled")]
    public async Task LockUnlockPooledRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockPooled.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockThirdPartyRollingKeyTestAsync()
    {
        ThirdPartyGlobalSetup();
        return LockUnlockThirdPartyRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockThirdPartyRollingKeyAsync))]
    public void ThirdPartyGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library rolling through a <see cref="WindowSize"/>-key
    /// window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "AsyncKeyedLock")]
    public async Task LockUnlockThirdPartyRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockThirdParty.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockStripedRollingKeyTestAsync()
    {
        StripedGlobalSetup();
        return LockUnlockStripedRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockStripedRollingKeyAsync))]
    public void StripedGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "AsyncKeyedLock (Striped)")]
    public async Task LockUnlockStripedRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

#if !NETFRAMEWORK
    [Test]
    public Task LockUnlockKeyedSemaphoresDictionaryRollingKeyTestAsync()
    {
        KeyedSemaphoresDictionaryGlobalSetup();
        return LockUnlockKeyedSemaphoresDictionaryRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresDictionaryRollingKeyAsync))]
    public void KeyedSemaphoresDictionaryGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores dictionary-backed lock rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "KeyedSemaphores")]
    public async Task LockUnlockKeyedSemaphoresDictionaryRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockKeyedSemaphoresDictionary.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockKeyedSemaphoresStripedRollingKeyTestAsync()
    {
        KeyedSemaphoresStripedGlobalSetup();
        return LockUnlockKeyedSemaphoresStripedRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresStripedRollingKeyAsync))]
    public void KeyedSemaphoresStripedGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores striped variant rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "KeyedSemaphores (Striped)")]
    public async Task LockUnlockKeyedSemaphoresStripedRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockKeyedSemaphoresStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }
#endif

#if !SIGNASSEMBLY
    [Test]
    public Task LockUnlockDaoRollingKeyTestAsync()
    {
        DaoGlobalSetup();
        return LockUnlockDaoRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockDaoRollingKeyAsync))]
    public void DaoGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party Dao.IndividualLock library rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "Dao.IndividualLock")]
    public async Task LockUnlockDaoRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockDao.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    public Task LockUnlockAsyncUtilitiesStripedRollingKeyTestAsync()
    {
        AsyncUtilitiesStripedGlobalSetup();
        return LockUnlockAsyncUtilitiesStripedRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockAsyncUtilitiesStripedRollingKeyAsync))]
    public void AsyncUtilitiesStripedGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the third-party AsyncUtilities striped async lock rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "AsyncUtilities (Striped)")]
    public async Task LockUnlockAsyncUtilitiesStripedRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockAsyncUtilitiesStriped.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }
#endif

    [Test]
    public Task LockUnlockRefImplRollingKeyTestAsync()
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplRollingKeyAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplRollingKeyAsync))]
    public void RefImplGlobalSetup() => SetUpKeySpace();

    /// <summary>
    /// Benchmark for the "AsyncDuplicateLock" reference implementation rolling through a
    /// <see cref="WindowSize"/>-key window over a <see cref="KeySpaceSize"/>-key table.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("RollingKey", "RefImpl")]
    public async Task LockUnlockRefImplRollingKeyAsync()
    {
        int start = NextWindowStart();
        for (int i = 0; i < WindowSize; i++)
        {
            string key = _keySpace![(start + i) % KeySpaceSize];
            using (await _lockRefImpl.LockAsync(key).ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    /// <summary>
    /// Returns the start offset of the next window and advances the rolling cursor by
    /// <c>WindowSize / AdvanceDivisor</c> (at least 1), wrapping around <see cref="KeySpaceSize"/>. A
    /// divisor of 1 advances a full window (no overlap with the previous one); higher divisors advance
    /// by a fraction of the window, so consecutive windows overlap and only that fraction of keys age
    /// out per cycle instead of the whole window.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int NextWindowStart()
    {
        int start = _windowStart;
        int advance = Math.Max(1, WindowSize / AdvanceDivisor);
        _windowStart = (_windowStart + advance) % KeySpaceSize;
        return start;
    }
}
