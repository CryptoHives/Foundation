// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !SIGNASSEMBLY
// See AsyncKeyedLockBaseBenchmark.cs for why AsyncUtilities is behind an alias.
extern alias AsyncUtilitiesLib;
#endif

namespace Threading.Tests.Async.Pooled;

#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable CA1849 // Synchronous Dispose() is intentional here - releasing the held outer locks isn't the phase being measured

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring lock/unlock performance with multiple queued waiters on keyed async lock
/// implementations, across both a single key and multiple keys held concurrently.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite is the keyed counterpart to <c>AsyncLockMultipleBenchmark</c>, adapted with
/// a second axis: instead of one lock ever being held, <see cref="KeyCount"/> distinct keys are held
/// simultaneously, and <see cref="Iterations"/> additional waiters are queued behind <b>each</b> of
/// those keys before everything is released and drained.
/// </para>
/// <para>
/// <b>Test scenario:</b> Hold <see cref="KeyCount"/> keys, queue <see cref="Iterations"/> lock
/// requests behind each held key, release all held keys, then sequentially acquire every queued
/// waiter. <c>KeyCount = 1</c> reproduces the non-keyed "single key under contention" scenario
/// exactly (directly comparable to <c>AsyncLockMultipleBenchmark</c>); <c>KeyCount &gt; 1</c>
/// exercises genuine cross-key concurrency at varying per-key contention levels simultaneously.
/// </para>
/// <para>
/// <b>Exception - striped variants:</b> the three fixed-stripe implementations (AsyncKeyedLock
/// Striped, KeyedSemaphores Striped, AsyncUtilities Striped) alias arbitrary keys onto a fixed
/// stripe count, so two of this benchmark's keys can collide on the same stripe - holding multiple
/// of them open at once would then risk a genuine self-deadlock (confirmed by reproducing exactly
/// that hang during development). Those three therefore process one key at a time - hold, queue,
/// drain, release, then the next key - never multiple keys held open simultaneously. Every other
/// (dictionary-backed) variant has true per-key isolation and holds all <see cref="KeyCount"/> keys
/// open concurrently as described above.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncKeyedLock&lt;TKey&gt;</c> - ConcurrentDictionary-backed entry registry with pooled IValueTaskSource waiters.</description></item>
/// <item><description><b>AsyncKeyedLock:</b> Third-party <c>AsyncKeyedLocker&lt;TKey&gt;</c>.</description></item>
/// <item><description><b>AsyncKeyedLock (Striped):</b> Third-party <c>StripedAsyncKeyedLocker&lt;TKey&gt;</c>.</description></item>
/// <item><description><b>Dao.IndividualLock:</b> Third-party <c>IndividualLocks&lt;TKey&gt;</c>.</description></item>
/// <item><description><b>AsyncUtilities (Striped):</b> Third-party <c>StripedAsyncLock&lt;TKey&gt;</c>.</description></item>
/// <item><description><b>RefImpl:</b> Theodor Zoulias's "AsyncDuplicateLock" reference implementation - out of contest, no cancellation support.</description></item>
/// </list>
/// <para>
/// <b>Exception - KeyedSemaphores is excluded from this suite</b> (it is present in every other one).
/// This suite builds its queue synchronously: it starts <see cref="Iterations"/> acquisitions without
/// awaiting them, releases the held key, and only then drains. KeyedSemaphores cannot be driven that
/// way - measured standalone, outside BenchmarkDotNet, at KeyedSemaphores 6.1.0 on one key, that
/// pattern costs a flat <b>~15.6 ms per queued waiter</b> (one Windows scheduler quantum: 18.5 ms for
/// 1 waiter, 40.5 for 2, 78.0 for 5, 156.3 for 10), against <b>~1.7 µs for ten acquisitions</b> when
/// each one is awaited immediately, and ~1.3 ms per waiter under genuine concurrent contention. The
/// resulting 20,000-48,000x ratios describe the interaction between this suite's pre-queue pattern and
/// that library, not the library's performance, so reporting them alongside the others would misinform
/// rather than compare. Storing an unawaited <c>ValueTask</c> and awaiting it once later is legal under
/// the <c>ValueTask</c> contract, so this is a genuine incompatibility rather than misuse - but the
/// mechanism behind the quantum-length stall was not diagnosed, and no conclusion about KeyedSemaphores'
/// real-world behaviour should be drawn from its absence here. Compare its normal-usage numbers in
/// <see cref="AsyncKeyedLockCardinalityBenchmark"/> and <see cref="AsyncKeyedLockConcurrentBenchmark"/>.
/// </para>
/// <para>
/// All pooled/third-party implementations are tested with both a default and a not-yet-cancelled
/// <see cref="System.Threading.CancellationToken"/>, matching <c>AsyncLockMultipleBenchmark</c>'s
/// convention - see <see cref="CancellationType"/>. <c>RefImpl</c> doesn't support cancellation
/// tokens and is benchmarked without one (out of contest).
/// </para>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations as both <see cref="KeyCount"/>
/// (1, 4, 16) and per-key <see cref="Iterations"/> (0, 1, 10, 100) grow. <see cref="Iterations"/>
/// = 0 measures the uncontended acquire/release pair; every larger value adds queued waiters, so
/// the growth in allocated bytes across that axis is the per-waiter cost of the contended path.
/// </para>
/// <para>
/// <b>Note on the critical section:</b> the work done while holding a key is a single counter
/// increment, so these numbers isolate lock overhead and deliberately do not model a caller that
/// holds a key across real work.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures lock/unlock performance with multiple waiters queued behind each of several keys.")]
[NonParallelizable]
[BenchmarkCategory("AsyncKeyedLock")]
public class AsyncKeyedLockMultipleBenchmark : AsyncKeyedLockBaseBenchmark
{
    private string[]? _keys;

    private AsyncKeyedLock<string>.Releaser[]? _pooledOuter;
    private ValueTask<AsyncKeyedLock<string>.Releaser>[]? _pooledHandle;

    private IDisposable?[]? _thirdPartyOuter;
    private ValueTask<IDisposable>[]? _thirdPartyHandle;

    // Striped locks alias arbitrary keys onto a fixed stripe count, so - unlike every
    // dictionary-backed variant above/below, which guarantees true per-key isolation - two
    // different keys can collide on the same stripe. Holding multiple keys open at once would
    // then self-deadlock (acquiring the second waits on the first, which nothing will ever
    // release). So the three striped variants below process one key at a time: hold, queue,
    // drain, release, then move on - never two keys held open simultaneously. Reused per key,
    // so these need only one outer slot and Iterations handle slots, not KeyCount of each.
    private ValueTask<AsyncKeyedLock.StripedAsyncKeyedLockReleaser>[]? _stripedHandle;

    // The timed competitors below use each library's timeout-capable overload, whose return type differs
    // from its untimed one - a nullable releaser that reports whether the wait succeeded rather than one
    // that always did. That is exactly why they are separate benchmark methods rather than another
    // cancellationType variant of the existing ones: the arrays cannot be shared.
    private ValueTask<IDisposable?>[]? _thirdPartyTimedHandle;
    private ValueTask<AsyncKeyedLock.StripedAsyncKeyedLockReleaser?>[]? _stripedTimedHandle;

    // No KeyedSemaphores fields here - both variants are excluded from this suite; see the
    // "Exception - KeyedSemaphores is excluded" paragraph in the class remarks for the measurements
    // behind that decision.

#if !SIGNASSEMBLY
    private IDisposable[]? _daoOuter;
    private Task<IDisposable>[]? _daoHandle;
    private ValueTask<AsyncUtilitiesLib::AsyncUtilities.StripedAsyncLock<string>.Releaser>[]? _asyncUtilitiesStripedHandle;
#endif

    private RefImpl.AsyncKeyedLock<string>.Releaser[]? _refImplOuter;
    private ValueTask<RefImpl.AsyncKeyedLock<string>.Releaser>[]? _refImplHandle;

    public static readonly object[] FixtureArgs = {
        new object[] { 1, 0 },
        new object[] { 1, 1 },
        new object[] { 1, 10 },
        new object[] { 1, 100 },
        new object[] { 4, 0 },
        new object[] { 4, 1 },
        new object[] { 4, 10 },
        new object[] { 4, 100 },
        new object[] { 16, 0 },
        new object[] { 16, 1 },
        new object[] { 16, 10 },
        new object[] { 16, 100 },
    };

    [Params(1, 4, 16)]
    public int KeyCount { get; set; } = 4;

    // Kept in sync with FixtureArgs above - NUnit and BenchmarkDotNet must exercise the same
    // matrix. Iterations = 100 matters most of the three: the per-waiter cost of the contended
    // path is only legible once enough waiters queue to dominate the acquire/release pair.
    [Params(0, 1, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncKeyedLockMultipleBenchmark() { }

    public AsyncKeyedLockMultipleBenchmark(int keyCount, int iterations)
    {
        KeyCount = keyCount;
        Iterations = iterations;
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
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public Task LockUnlockPooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        return LockUnlockPooledMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        SetUpKeys();
        _pooledOuter = new AsyncKeyedLock<string>.Releaser[KeyCount];
        _pooledHandle = new ValueTask<AsyncKeyedLock<string>.Releaser>[KeyCount * Iterations];
    }

    /// <summary>
    /// Benchmark for the pooled keyed async lock: <see cref="KeyCount"/> keys held simultaneously,
    /// <see cref="Iterations"/> waiters queued behind each.
    /// </summary>
    /// <remarks>
    /// The only variant here that exercises <see cref="CancellationType.Timed"/>, because it is the only
    /// implementation in this suite whose timeout overload has the same shape as its untimed one - the
    /// third-party keyed lockers do offer timeouts, but return a different releaser type with
    /// try-semantics instead of throwing, so their timed path is not the same operation. The timed row's
    /// value is therefore the comparison against this method's own <c>None</c> row: the difference is
    /// what arming and disposing one timer per queued waiter costs.
    /// </remarks>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Multiple", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public async Task LockUnlockPooledMultipleAsync(CancellationType cancellationType)
    {
        // Timeout is InfiniteTimeSpan for the untimed variants, which the implementation treats as "arm
        // no timer" - so this one call site serves every variant without branching.
        for (int k = 0; k < KeyCount; k++)
        {
            _pooledOuter![k] = await _lockPooled
                .LockAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken)
                .ConfigureAwait(false);
        }

        for (int k = 0; k < KeyCount; k++)
        {
            for (int i = 0; i < Iterations; i++)
            {
                _pooledHandle![(k * Iterations) + i] =
                    _lockPooled.LockAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken);
            }
        }

        for (int k = 0; k < KeyCount; k++)
        {
            unchecked { _counter++; }
            _pooledOuter![k].Dispose();
        }

        foreach (ValueTask<AsyncKeyedLock<string>.Releaser> handle in _pooledHandle!)
        {
            using (await handle.ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockThirdPartyMultipleTestAsync(CancellationType cancellationType)
    {
        ThirdPartyGlobalSetup();
        return LockUnlockThirdPartyMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockThirdPartyMultipleAsync))]
    public void ThirdPartyGlobalSetup()
    {
        SetUpKeys();
        _thirdPartyOuter = new IDisposable[KeyCount];
        _thirdPartyHandle = new ValueTask<IDisposable>[KeyCount * Iterations];
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock library: <see cref="KeyCount"/> keys held
    /// simultaneously, <see cref="Iterations"/> waiters queued behind each.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "AsyncKeyedLock")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockThirdPartyMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            _thirdPartyOuter![k] = await _lockThirdParty.LockOrNullAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int k = 0; k < KeyCount; k++)
        {
            for (int i = 0; i < Iterations; i++)
            {
                _thirdPartyHandle![(k * Iterations) + i] = _lockThirdParty.LockAsync(_keys![k], cancellationType.CancellationToken);
            }
        }

        for (int k = 0; k < KeyCount; k++)
        {
            unchecked { _counter++; }
            IDisposable? disposable = _thirdPartyOuter![k];
            disposable?.Dispose();
        }

        foreach (ValueTask<IDisposable> handle in _thirdPartyHandle!)
        {
            using (await handle.ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockStripedMultipleTestAsync(CancellationType cancellationType)
    {
        StripedGlobalSetup();
        return LockUnlockStripedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockStripedMultipleAsync))]
    public void StripedGlobalSetup()
    {
        SetUpKeys();
        _stripedHandle = new ValueTask<AsyncKeyedLock.StripedAsyncKeyedLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for the third-party AsyncKeyedLock striped variant: each of <see cref="KeyCount"/>
    /// keys is held, has <see cref="Iterations"/> waiters queued behind it, and is fully drained
    /// before moving to the next key (never multiple keys held open simultaneously - see the
    /// striped-field comment above for why).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "AsyncKeyedLock (Striped)")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockStripedMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            AsyncKeyedLock.StripedAsyncKeyedLockReleaser outer =
                await _lockStriped.LockAsync(_keys![k], cancellationType.CancellationToken).ConfigureAwait(false);

            for (int i = 0; i < Iterations; i++)
            {
                _stripedHandle![i] = _lockStriped.LockAsync(_keys![k], cancellationType.CancellationToken);
            }

            unchecked { _counter++; }
            outer.Dispose();

            for (int i = 0; i < Iterations; i++)
            {
                using (await _stripedHandle![i].ConfigureAwait(false))
                {
                    unchecked { _counter++; }
                }
            }
        }
    }

#if !SIGNASSEMBLY
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockDaoMultipleTestAsync(CancellationType cancellationType)
    {
        DaoGlobalSetup();
        return LockUnlockDaoMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockDaoMultipleAsync))]
    public void DaoGlobalSetup()
    {
        SetUpKeys();
        _daoOuter = new IDisposable[KeyCount];
        _daoHandle = new Task<IDisposable>[KeyCount * Iterations];
    }

    /// <summary>
    /// Benchmark for the third-party Dao.IndividualLock library: <see cref="KeyCount"/> keys held
    /// simultaneously, <see cref="Iterations"/> waiters queued behind each.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "Dao.IndividualLock")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockDaoMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            _daoOuter![k] = await _lockDao.LockAsync(_keys![k], cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int k = 0; k < KeyCount; k++)
        {
            for (int i = 0; i < Iterations; i++)
            {
                _daoHandle![(k * Iterations) + i] = _lockDao.LockAsync(_keys![k], cancellationType.CancellationToken);
            }
        }

        for (int k = 0; k < KeyCount; k++)
        {
            unchecked { _counter++; }
            _daoOuter![k].Dispose();
        }

        foreach (Task<IDisposable> handle in _daoHandle!)
        {
            using (await handle.ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockAsyncUtilitiesStripedMultipleTestAsync(CancellationType cancellationType)
    {
        AsyncUtilitiesStripedGlobalSetup();
        return LockUnlockAsyncUtilitiesStripedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockAsyncUtilitiesStripedMultipleAsync))]
    public void AsyncUtilitiesStripedGlobalSetup()
    {
        SetUpKeys();
        _asyncUtilitiesStripedHandle = new ValueTask<AsyncUtilitiesLib::AsyncUtilities.StripedAsyncLock<string>.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for the third-party AsyncUtilities striped async lock: each of <see cref="KeyCount"/>
    /// keys is held, has <see cref="Iterations"/> waiters queued behind it, and is fully drained
    /// before moving to the next key (never multiple keys held open simultaneously - see the
    /// striped-field comment above for why).
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "AsyncUtilities (Striped)")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockAsyncUtilitiesStripedMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            AsyncUtilitiesLib::AsyncUtilities.StripedAsyncLock<string>.Releaser outer = await _lockAsyncUtilitiesStriped.LockAsync(_keys![k], cancellationType.CancellationToken).ConfigureAwait(false);

            for (int i = 0; i < Iterations; i++)
            {
                _asyncUtilitiesStripedHandle![i] = _lockAsyncUtilitiesStriped.LockAsync(_keys![k], cancellationType.CancellationToken);
            }

            unchecked { _counter++; }
            outer.Dispose();

            for (int i = 0; i < Iterations; i++)
            {
                using (await _asyncUtilitiesStripedHandle![i].ConfigureAwait(false))
                {
                    unchecked { _counter++; }
                }
            }
        }
    }
#endif

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public Task LockUnlockThirdPartyTimedMultipleTestAsync(CancellationType cancellationType)
    {
        ThirdPartyTimedGlobalSetup();
        return LockUnlockThirdPartyTimedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockThirdPartyTimedMultipleAsync))]
    public void ThirdPartyTimedGlobalSetup()
    {
        SetUpKeys();
        _thirdPartyOuter = new IDisposable?[KeyCount];
        _thirdPartyTimedHandle = new ValueTask<IDisposable?>[KeyCount * Iterations];
    }

    /// <summary>
    /// Timed counterpart to <see cref="LockUnlockThirdPartyMultipleAsync"/>, using the third-party
    /// library's own timeout overload so the timed rows have something to compare against.
    /// </summary>
    /// <remarks>
    /// <c>LockOrNullAsync</c> rather than <c>LockAsync</c> because the timeout must be observable: it
    /// returns <see langword="null"/> when the wait gives up, where our <c>LockAsync</c> throws. The
    /// timeout used here never elapses, so both always succeed and what is measured is the same thing on
    /// both sides - arming and disposing a timer per queued waiter.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "AsyncKeyedLock")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public async Task LockUnlockThirdPartyTimedMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            _thirdPartyOuter![k] = await _lockThirdParty
                .LockOrNullAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken)
                .ConfigureAwait(false);
        }

        for (int k = 0; k < KeyCount; k++)
        {
            for (int i = 0; i < Iterations; i++)
            {
                _thirdPartyTimedHandle![(k * Iterations) + i] =
                    _lockThirdParty.LockOrNullAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken);
            }
        }

        for (int k = 0; k < KeyCount; k++)
        {
            unchecked { _counter++; }
            _thirdPartyOuter![k]?.Dispose();
        }

        foreach (ValueTask<IDisposable?> handle in _thirdPartyTimedHandle!)
        {
            using (await handle.ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public Task LockUnlockStripedTimedMultipleTestAsync(CancellationType cancellationType)
    {
        StripedTimedGlobalSetup();
        return LockUnlockStripedTimedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockStripedTimedMultipleAsync))]
    public void StripedTimedGlobalSetup()
    {
        SetUpKeys();
        _stripedTimedHandle = new ValueTask<AsyncKeyedLock.StripedAsyncKeyedLockReleaser?>[Iterations];
    }

    /// <summary>
    /// Timed counterpart to <see cref="LockUnlockStripedMultipleAsync"/>, one key at a time for the same
    /// stripe-collision reason as its untimed sibling.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "AsyncKeyedLock (Striped)")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public async Task LockUnlockStripedTimedMultipleAsync(CancellationType cancellationType)
    {
        for (int k = 0; k < KeyCount; k++)
        {
            AsyncKeyedLock.StripedAsyncKeyedLockReleaser? outer = await _lockStriped
                .LockOrNullAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken)
                .ConfigureAwait(false);

            for (int i = 0; i < Iterations; i++)
            {
                _stripedTimedHandle![i] =
                    _lockStriped.LockOrNullAsync(_keys![k], cancellationType.Timeout, cancellationType.CancellationToken);
            }

            unchecked { _counter++; }
            outer?.Dispose();

            for (int i = 0; i < Iterations; i++)
            {
                using (await _stripedTimedHandle![i].ConfigureAwait(false))
                {
                    unchecked { _counter++; }
                }
            }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task LockUnlockRefImplMultipleTestAsync(CancellationType cancellationType)
    {
        RefImplGlobalSetup();
        return LockUnlockRefImplMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockRefImplMultipleAsync))]
    public void RefImplGlobalSetup()
    {
        SetUpKeys();
        _refImplOuter = new RefImpl.AsyncKeyedLock<string>.Releaser[KeyCount];
        _refImplHandle = new ValueTask<RefImpl.AsyncKeyedLock<string>.Releaser>[KeyCount * Iterations];
    }

    /// <summary>
    /// Benchmark for the "AsyncDuplicateLock" reference implementation: <see cref="KeyCount"/>
    /// keys held simultaneously, <see cref="Iterations"/> waiters queued behind each. Out of contest:
    /// no cancellation token support, so only <see cref="CancellationType.None"/> is exercised.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "RefImpl")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task LockUnlockRefImplMultipleAsync(CancellationType cancellationType)
    {
        _ = cancellationType;

        for (int k = 0; k < KeyCount; k++)
        {
            _refImplOuter![k] = await _lockRefImpl.LockAsync(_keys![k]).ConfigureAwait(false);
        }

        for (int k = 0; k < KeyCount; k++)
        {
            for (int i = 0; i < Iterations; i++)
            {
                _refImplHandle![(k * Iterations) + i] = _lockRefImpl.LockAsync(_keys![k]);
            }
        }

        for (int k = 0; k < KeyCount; k++)
        {
            unchecked { _counter++; }
            _refImplOuter![k].Dispose();
        }

        foreach (ValueTask<RefImpl.AsyncKeyedLock<string>.Releaser> handle in _refImplHandle!)
        {
            using (await handle.ConfigureAwait(false))
            {
                unchecked { _counter++; }
            }
        }
    }
}
