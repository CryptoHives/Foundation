// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncSemaphore;

#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Benchmarks measuring wait/release performance with multiple queued waiters on async semaphore
/// implementations, across semaphores that admit one holder and several.
/// </summary>
/// <remarks>
/// <para>
/// The counterpart to <c>AsyncLockMultipleBenchmark</c> for a primitive that, until this class existed,
/// was only ever measured uncontended and only ever configured as a mutex. Both of those left the
/// interesting half unmeasured: a semaphore's waiter queue is the whole reason the pooled implementation
/// exists, and a count above one is what distinguishes it from a lock.
/// </para>
/// <para>
/// <b>Test scenario:</b> Exhaust the semaphore's permits, queue <see cref="Iterations"/> further wait
/// requests behind them, release the held permits, then drain every queued waiter.
/// </para>
/// <para>
/// <b>Parameters:</b> <see cref="InitialCount"/> sets how many holders are admitted at once - 1 makes
/// this directly comparable to <c>AsyncLockMultipleBenchmark</c>, while larger values exercise a release
/// path that has several permits to hand out rather than one. <see cref="Iterations"/> sets how deep the
/// queue behind them grows.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> <c>AsyncSemaphore</c> with pooled IValueTaskSource waiters.</description></item>
/// <item><description><b>SemaphoreSlim:</b> The framework primitive, the obvious alternative.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party <c>AsyncSemaphore</c>.</description></item>
/// <item><description><b>VS.Threading:</b> Visual Studio threading <c>AsyncSemaphore</c>.</description></item>
/// <item><description><b>ProtoPromise:</b> Third-party <c>AsyncSemaphore</c> (non-Framework targets only).</description></item>
/// <item><description><b>RefImpl:</b> Reference implementation - out of contest.</description></item>
/// </list>
/// <para>
/// Timed variants are provided for the three implementations whose timeout overload has the same shape
/// as their untimed one; see <see cref="CancellationType"/> for why they are separate methods.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures wait/release performance with multiple waiters queued behind an async semaphore.")]
[NonParallelizable]
[BenchmarkCategory("AsyncSemaphore")]
public class AsyncSemaphoreMultipleBenchmark : AsyncSemaphoreBaseBenchmark
{
    private ValueTask[]? _pooledHandle;
    private Task[]? _taskHandle;
    private Task<bool>[]? _semaphoreSlimTimedHandle;
    private Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[]? _vsThreadingHandle;
#if !NETFRAMEWORK
    private Proto.Promises.Promise[]? _promiseHandle;
#endif

    public static readonly object[] FixtureArgs = {
        new object[] { 1, 0 },
        new object[] { 1, 10 },
        new object[] { 1, 100 },
        new object[] { 4, 0 },
        new object[] { 4, 10 },
        new object[] { 4, 100 },
    };

    /// <summary>
    /// Permits the semaphore admits at once. <c>1</c> is a mutex; larger values are what makes this a
    /// semaphore benchmark rather than a second lock benchmark.
    /// </summary>
    [Params(1, 4)]
    public int InitialCount { get; set; } = 1;

    /// <summary>
    /// Waiters queued behind the exhausted permits.
    /// </summary>
    [Params(0, 10, 100)]
    public int Iterations { get; set; } = 10;

    private protected override int SemaphoreInitialCount => InitialCount;

    public AsyncSemaphoreMultipleBenchmark() { }

    public AsyncSemaphoreMultipleBenchmark(int initialCount, int iterations)
    {
        InitialCount = initialCount;
        Iterations = iterations;
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public Task WaitReleasePooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        return WaitReleasePooledMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleasePooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        GlobalSetup();
        _pooledHandle = new ValueTask[Iterations];
    }

    /// <summary>
    /// Benchmark for the pooled async semaphore: all permits taken, <see cref="Iterations"/> waiters
    /// queued behind them.
    /// </summary>
    /// <remarks>
    /// Timeout is <c>InfiniteTimeSpan</c> for the untimed variants, which the implementation treats as
    /// "arm no timer", so one call site serves every variant without branching.
    /// </remarks>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Multiple", "Pooled")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public async Task WaitReleasePooledMultipleAsync(CancellationType cancellationType)
    {
        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphorePooled.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _pooledHandle![i] = _semaphorePooled.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken);
        }

        for (int i = 0; i < InitialCount; i++)
        {
            _semaphorePooled.Release();
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _pooledHandle![i].ConfigureAwait(false);
            _semaphorePooled.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task WaitReleaseSemaphoreSlimMultipleTestAsync(CancellationType cancellationType)
    {
        SemaphoreSlimGlobalSetup();
        return WaitReleaseSemaphoreSlimMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseSemaphoreSlimMultipleAsync))]
    public void SemaphoreSlimGlobalSetup()
    {
        GlobalSetup();
        _taskHandle = new Task[Iterations];
    }

    /// <summary>
    /// Benchmark for <c>SemaphoreSlim</c> with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "System", "SemaphoreSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task WaitReleaseSemaphoreSlimMultipleAsync(CancellationType cancellationType)
    {
        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphoreSlim.WaitAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _taskHandle![i] = _semaphoreSlim.WaitAsync(cancellationType.CancellationToken);
        }

        _semaphoreSlim.Release(InitialCount);

        for (int i = 0; i < Iterations; i++)
        {
            await _taskHandle![i].ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public Task WaitReleaseSemaphoreSlimTimedMultipleTestAsync(CancellationType cancellationType)
    {
        SemaphoreSlimTimedGlobalSetup();
        return WaitReleaseSemaphoreSlimTimedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseSemaphoreSlimTimedMultipleAsync))]
    public void SemaphoreSlimTimedGlobalSetup()
    {
        GlobalSetup();
        _semaphoreSlimTimedHandle = new Task<bool>[Iterations];
    }

    /// <summary>
    /// Timed counterpart to <see cref="WaitReleaseSemaphoreSlimMultipleAsync"/>. A separate method
    /// because the timed overload returns <c>Task&lt;bool&gt;</c> rather than <c>Task</c>.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "System", "SemaphoreSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public async Task WaitReleaseSemaphoreSlimTimedMultipleAsync(CancellationType cancellationType)
    {
        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphoreSlim.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _semaphoreSlimTimedHandle![i] =
                _semaphoreSlim.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken);
        }

        _semaphoreSlim.Release(InitialCount);

        for (int i = 0; i < Iterations; i++)
        {
            await _semaphoreSlimTimedHandle![i].ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task WaitReleaseNitoMultipleTestAsync(CancellationType cancellationType)
    {
        NitoGlobalSetup();
        return WaitReleaseNitoMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseNitoMultipleAsync))]
    public void NitoGlobalSetup()
    {
        GlobalSetup();
        _taskHandle = new Task[Iterations];
    }

    /// <summary>
    /// Benchmark for the Nito.AsyncEx async semaphore with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "Nito.AsyncEx")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task WaitReleaseNitoMultipleAsync(CancellationType cancellationType)
    {
        _ = cancellationType;

        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphoreNitoAsync.WaitAsync().ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _taskHandle![i] = _semaphoreNitoAsync.WaitAsync();
        }

        for (int i = 0; i < InitialCount; i++)
        {
            _semaphoreNitoAsync.Release();
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _taskHandle![i].ConfigureAwait(false);
            _semaphoreNitoAsync.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task WaitReleaseVSThreadingMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingGlobalSetup();
        return WaitReleaseVSThreadingMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseVSThreadingMultipleAsync))]
    public void VSThreadingGlobalSetup()
    {
        GlobalSetup();
        _vsThreadingHandle = new Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for the Visual Studio threading async semaphore with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task WaitReleaseVSThreadingMultipleAsync(CancellationType cancellationType)
    {
        var held = new Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser[InitialCount];
        for (int i = 0; i < InitialCount; i++)
        {
            held[i] = await _semaphoreVSThreading.EnterAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _vsThreadingHandle![i] = _semaphoreVSThreading.EnterAsync(cancellationType.CancellationToken);
        }

        for (int i = 0; i < InitialCount; i++)
        {
            held[i].Dispose();
        }

        for (int i = 0; i < Iterations; i++)
        {
            using (await _vsThreadingHandle![i].ConfigureAwait(false)) { }
        }
    }

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task WaitReleaseProtoPromiseMultipleTestAsync(CancellationType cancellationType)
    {
        ProtoPromiseGlobalSetup();
        return WaitReleaseProtoPromiseMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseProtoPromiseMultipleAsync))]
    public void ProtoPromiseGlobalSetup()
    {
        GlobalSetup();
        _promiseHandle = new Proto.Promises.Promise[Iterations];
    }

    /// <summary>
    /// Benchmark for the ProtoPromise async semaphore with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "ProtoPromise")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task WaitReleaseProtoPromiseMultipleAsync(CancellationType cancellationType)
    {
        _ = cancellationType;

        // ProtoPromise's WaitAsync takes the continuation option directly rather than through
        // ConfigureAwait, matching how AsyncSemaphoreSingleBenchmark drives it.
        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphoreProtoPromises.WaitAsync(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _promiseHandle![i] = _semaphoreProtoPromises.WaitAsync(false);
        }

        for (int i = 0; i < InitialCount; i++)
        {
            _semaphoreProtoPromises.Release();
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _promiseHandle![i];
            _semaphoreProtoPromises.Release();
        }
    }
#endif

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public Task WaitReleaseRefImplMultipleTestAsync(CancellationType cancellationType)
    {
        RefImplGlobalSetup();
        return WaitReleaseRefImplMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(WaitReleaseRefImplMultipleAsync))]
    public void RefImplGlobalSetup()
    {
        GlobalSetup();
        _taskHandle = new Task[Iterations];
    }

    /// <summary>
    /// Benchmark for the reference implementation with multiple queued waiters. Out of contest.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "RefImpl")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task WaitReleaseRefImplMultipleAsync(CancellationType cancellationType)
    {
        _ = cancellationType;

        for (int i = 0; i < InitialCount; i++)
        {
            await _semaphoreRefImp.WaitAsync().ConfigureAwait(false);
        }

        for (int i = 0; i < Iterations; i++)
        {
            _taskHandle![i] = _semaphoreRefImp.WaitAsync();
        }

        for (int i = 0; i < InitialCount; i++)
        {
            _semaphoreRefImp.Release();
        }

        for (int i = 0; i < Iterations; i++)
        {
            await _taskHandle![i].ConfigureAwait(false);
            _semaphoreRefImp.Release();
        }
    }
}
