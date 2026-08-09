// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring lock/unlock throughput with several threads acquiring keys concurrently.
/// </summary>
/// <remarks>
/// <para>
/// Every other benchmark in this suite (<see cref="AsyncKeyedLockSingleKeyBenchmark"/>,
/// <see cref="AsyncKeyedLockCardinalityBenchmark"/>, <see cref="AsyncKeyedLockRollingKeyBenchmark"/>,
/// <see cref="AsyncKeyedLockMultipleBenchmark"/>) runs on a single logical flow. That leaves the most
/// important scalability property of a dictionary-backed keyed lock completely unmeasured: the
/// per-key locks never contend with each other, but the <em>bookkeeping</em> around them may.
/// The pooled implementation serializes every acquire and release through one global administrative
/// spin lock, so its entry lookup/ref-count/idle-list work is a single shared critical section across
/// all keys - whereas a fixed-stripe implementation has N independent locks and no shared bookkeeping
/// at all. On one thread that difference is invisible; this suite is what makes it visible.
/// </para>
/// <para>
/// <b>Test scenario:</b> Per operation, start <see cref="ThreadCount"/> concurrent tasks; each performs
/// <see cref="OpsPerThread"/> acquire/release cycles, then wait for all of them.
/// </para>
/// <para>
/// <b>Key-space modes</b> (via <see cref="SharedKeys"/>):
/// </para>
/// <list type="bullet">
/// <item><description><b>false (disjoint):</b> each thread works exclusively on its own private slice of
/// keys, so <em>no two threads ever contend for the same key</em>. Any slowdown as
/// <see cref="ThreadCount"/> grows is therefore pure bookkeeping contention, not real lock contention -
/// the cleanest possible measurement of the shared-administrative-state bottleneck.</description></item>
/// <item><description><b>true (shared):</b> all threads roam the whole key space, so genuine same-key
/// contention is mixed in as well - less isolated, but closer to a realistic workload.</description></item>
/// </list>
/// <para>
/// The total key space is a fixed <see cref="KeySpaceSize"/> in both modes and at every
/// <see cref="ThreadCount"/>, so the two modes are directly comparable and a change along the thread
/// axis is attributable to concurrency alone rather than to a working set that grew with it. It stays
/// below the pooled implementation's default idle-eviction threshold so entry eviction/reallocation
/// cost does not contaminate the measurement.
/// </para>
/// <para>
/// <b>Note on absolute numbers:</b> each timed operation includes the cost of starting and joining
/// <see cref="ThreadCount"/> tasks. That overhead is identical across every implementation compared here,
/// so relative Ratios remain meaningful, but absolute Means are not comparable to the single-flow suites.
/// </para>
/// <para>
/// <b>Note on oversubscription:</b> <see cref="ThreadCount"/> counts concurrent tasks, not cores. Once
/// it exceeds the host's physical core count the measurement changes in kind rather than degree -
/// implementations whose waiters spin keep burning a core that the lock holder needs, while those whose
/// waiters park do not. Rows above that threshold should be read as a different regime, not as further
/// points on the same curve.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures lock/unlock throughput with several threads acquiring keys concurrently.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockConcurrentBenchmark : AsyncKeyedLockBaseBenchmark
{
    /// <summary>
    /// Total number of distinct keys touched per operation, in <b>both</b> key-space modes and at every
    /// <see cref="ThreadCount"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Deliberately a constant rather than a per-thread multiple. When the key space was sized as
    /// <c>ThreadCount * KeysPerThread</c>, raising <see cref="ThreadCount"/> also grew the working set
    /// (8 keys at 1 thread, 64 at 8), so the <see cref="ThreadCount"/> axis scaled parallelism and
    /// cardinality together and the two effects could not be separated. Holding the working set fixed
    /// means a change along that axis is attributable to concurrency alone - which is the entire point
    /// of this suite.
    /// </para>
    /// <para>
    /// Chosen to stay below the pooled implementation's default idle-eviction threshold (128), so entry
    /// eviction and reallocation cost does not contaminate the measurement - that behaviour has its own
    /// suite in <see cref="AsyncKeyedLockRollingKeyBenchmark"/>. Every value in <see cref="ThreadCount"/>
    /// must divide this evenly, or the disjoint-mode partition below stops being disjoint.
    /// </para>
    /// </remarks>
    private const int KeySpaceSize = 64;

    /// <summary>
    /// Acquire/release cycles each thread performs per timed operation. Large enough that the real lock
    /// work dominates the fixed cost of starting the tasks.
    /// </summary>
    /// <remarks>
    /// Per-thread rather than per-operation, so total work grows with <see cref="ThreadCount"/>: an
    /// implementation that scaled perfectly would hold a flat Mean across the axis, and the degree to
    /// which the Mean rises is the degree to which it does not.
    /// </remarks>
    private const int OpsPerThread = 100;

    private string[]? _keys;
    private Task[]? _tasks;

    public static readonly object[] FixtureArgs = {
        new object[] { 1, false },
        new object[] { 2, false },
        new object[] { 4, false },
        new object[] { 8, false },
        new object[] { 1, true },
        new object[] { 2, true },
        new object[] { 4, true },
        new object[] { 8, true },
    };

    /// <summary>
    /// Number of concurrent tasks contending for the lock.
    /// </summary>
    [Params(1, 2, 4, 8)]
    public int ThreadCount { get; set; } = 4;

    /// <summary>
    /// Whether every thread roams the whole key space (<see langword="true"/>) or works only on its own
    /// private, non-overlapping slice of it (<see langword="false"/>).
    /// </summary>
    [Params(false, true)]
    public bool SharedKeys { get; set; }

    public AsyncKeyedLockConcurrentBenchmark() { }

    public AsyncKeyedLockConcurrentBenchmark(int threadCount, bool sharedKeys)
    {
        ThreadCount = threadCount;
        SharedKeys = sharedKeys;
    }

    private void SetUpKeys()
    {
        base.GlobalSetup();
        _tasks = new Task[ThreadCount];
        _keys = new string[KeySpaceSize];
        for (int i = 0; i < _keys.Length; i++)
        {
            _keys[i] = $"key-{i}";
        }
    }

    /// <summary>
    /// Maps a (thread, iteration) pair to a key index. Both modes walk the same
    /// <see cref="KeySpaceSize"/> keys; they differ only in whether two threads can ever land on the
    /// same one.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <b>Disjoint mode</b> partitions the key space by residue class: thread <paramref name="thread"/>
    /// only ever touches indices congruent to <paramref name="thread"/> modulo
    /// <see cref="ThreadCount"/>. Since <see cref="ThreadCount"/> divides <see cref="KeySpaceSize"/>,
    /// the wrap-around preserves that congruence, so the per-thread slices stay disjoint while their
    /// union is always the whole space - which is what keeps the working set independent of thread
    /// count. (A contiguous <c>[t * stride, (t+1) * stride)</c> split would work equally well; the
    /// interleaved form additionally spreads each thread's keys across the dictionary's buckets rather
    /// than concentrating them.)
    /// </para>
    /// <para>
    /// <b>Shared mode</b> lets every thread walk the whole space, offset from each other so they do not
    /// march in lockstep on the same key at the same moment.
    /// </para>
    /// </remarks>
    private int KeyIndex(int thread, int iteration)
    {
        if (!SharedKeys)
        {
            return ((iteration * ThreadCount) + thread) % KeySpaceSize;
        }

        return ((thread * (KeySpaceSize / ThreadCount)) + iteration) % KeySpaceSize;
    }

    [Test]
    public Task LockUnlockPooledConcurrentTestAsync()
    {
        PooledGlobalSetup();
        return LockUnlockPooledConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledConcurrentAsync))]
    public void PooledGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the pooled keyed async lock under concurrent multi-threaded access.
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Concurrent", "Pooled")]
    public async Task LockUnlockPooledConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockPooled.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

    [Test]
    public Task LockUnlockThirdPartyConcurrentTestAsync()
    {
        ThirdPartyGlobalSetup();
        return LockUnlockThirdPartyConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockThirdPartyConcurrentAsync))]
    public void ThirdPartyGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library under concurrent multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "AsyncKeyedLock")]
    public async Task LockUnlockThirdPartyConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockThirdParty.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

    [Test]
    public Task LockUnlockStripedConcurrentTestAsync()
    {
        StripedGlobalSetup();
        return LockUnlockStripedConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockStripedConcurrentAsync))]
    public void StripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant under concurrent multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "AsyncKeyedLock (Striped)")]
    public async Task LockUnlockStripedConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockStriped.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

#if !NETFRAMEWORK
    [Test]
    public Task LockUnlockKeyedSemaphoresDictionaryConcurrentTestAsync()
    {
        KeyedSemaphoresDictionaryGlobalSetup();
        return LockUnlockKeyedSemaphoresDictionaryConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresDictionaryConcurrentAsync))]
    public void KeyedSemaphoresDictionaryGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores dictionary-backed lock under concurrent
    /// multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "KeyedSemaphores")]
    public async Task LockUnlockKeyedSemaphoresDictionaryConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockKeyedSemaphoresDictionary.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

    [Test]
    public Task LockUnlockKeyedSemaphoresStripedConcurrentTestAsync()
    {
        KeyedSemaphoresStripedGlobalSetup();
        return LockUnlockKeyedSemaphoresStripedConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockKeyedSemaphoresStripedConcurrentAsync))]
    public void KeyedSemaphoresStripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party KeyedSemaphores striped variant under concurrent multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "KeyedSemaphores (Striped)")]
    public async Task LockUnlockKeyedSemaphoresStripedConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockKeyedSemaphoresStriped.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }
#endif

    [Test]
    public Task LockUnlockDaoConcurrentTestAsync()
    {
        DaoGlobalSetup();
        return LockUnlockDaoConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockDaoConcurrentAsync))]
    public void DaoGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party Dao.IndividualLock library under concurrent multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "Dao.IndividualLock")]
    public async Task LockUnlockDaoConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockDao.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

    [Test]
    public Task LockUnlockAsyncUtilitiesStripedConcurrentTestAsync()
    {
        AsyncUtilitiesStripedGlobalSetup();
        return LockUnlockAsyncUtilitiesStripedConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockAsyncUtilitiesStripedConcurrentAsync))]
    public void AsyncUtilitiesStripedGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the third-party AsyncUtilities striped async lock under concurrent multi-threaded access.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "AsyncUtilities (Striped)")]
    public async Task LockUnlockAsyncUtilitiesStripedConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockAsyncUtilitiesStriped.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }

    [Test]
    public Task LockUnlockRefImplConcurrentTestAsync()
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplConcurrentAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplConcurrentAsync))]
    public void RefImplGlobalSetup() => SetUpKeys();

    /// <summary>
    /// Benchmark for the "AsyncDuplicateLock" reference implementation under concurrent
    /// multi-threaded access. <b>In contest here</b>, unlike in the other classes.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class was previously labelled out of contest, on the grounds that the reference
    /// implementation's ref-count decrement and removal were not race-free under extreme
    /// contention - exactly the shape this suite produces at <see cref="SharedKeys"/> =
    /// <see langword="true"/> and high <see cref="ThreadCount"/>. That caveat described an earlier
    /// hand-written variant. The baseline is now a faithful port of Theodor Zoulias's version, whose
    /// compare-and-swap release loop exists precisely to close that race, so its results here are
    /// legitimate and should be read as a genuine comparison.
    /// </para>
    /// <para>
    /// It remains out of contest in the classes that vary cancellation or timeout, since it supports
    /// neither - but neither of those is an axis here.
    /// </para>
    /// <para>
    /// Worth keeping in mind when reading the multi-threaded scaling: this implementation has no
    /// administrative lock at all, reaching its key map only through
    /// <see cref="System.Collections.Concurrent.ConcurrentDictionary{TKey, TValue}"/> operations. An
    /// implementation that guards a shared map with a single lock is not just paying a different
    /// waiting policy, it is serializing where this one does not.
    /// </para>
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Concurrent", "RefImpl")]
    public async Task LockUnlockRefImplConcurrentAsync()
    {
        for (int t = 0; t < ThreadCount; t++)
        {
            int thread = t;
            _tasks![t] = Task.Run(async () => {
                for (int i = 0; i < OpsPerThread; i++)
                {
                    using (await _lockRefImpl.LockAsync(_keys![KeyIndex(thread, i)]).ConfigureAwait(false))
                    {
                        unchecked { _counter++; }
                    }
                }
            });
        }

        await Task.WhenAll(_tasks!).ConfigureAwait(false);
    }
}
