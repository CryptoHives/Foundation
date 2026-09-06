// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncLock;

#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using RefImpl = Threading.Tests.Async.RefImpl;

/// <summary>
/// Benchmarks measuring lock/unlock performance with multiple queued waiters on AsyncLock implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance and memory overhead of acquiring and releasing
/// an async lock when multiple lock requests are queued. It measures contention handling
/// and the efficiency of FIFO waiter queue implementations.
/// </para>
/// <para>
/// <b>Test scenario:</b> Hold the lock, queue multiple lock requests, then release and sequentially
/// acquire each queued lock.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (ValueTask) (baseline):</b> Allocation-free implementation using pooled IValueTaskSource with struct releaser.</description></item>
/// <item><description><b>Pooled (Task):</b> Same pooled implementation converted to Task via AsTask() (incurs allocation).</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based lock and IDisposable releaser.</description></item>
/// <item><description><b>VS.Threading:</b> VS threading library using AsyncSemaphore for locking.</description></item>
/// <item><description><b>NeoSmart:</b> Third-party async lock library with nested-acquisition detection.</description></item>
/// <item><description><b>Proto.Promises:</b> Threading library implementing AsyncLock for locking via promises.</description></item>
/// <item><description><b>AsyncKeyedLock (NonKeyed):</b> Third-party high-performance async lock library.</description></item>
/// <item><description><b>DotNext (.NET 10.0+ only):</b> Third-party <see cref="DotNext.Threading.AsyncExclusiveLock"/> - has no disposable
/// releaser, so each queued acquisition is paired with an explicit Release() call.</description></item>
/// <item><description><b>RefImpl:</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations under contention with varying numbers
/// of queued waiters (controlled by <see cref="Iterations"/> parameter: 0, 1, 10, 100).
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncLock")]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    private Task[]? _tasks;
    private Task<AsyncLock.Releaser>[]? _tasksReleaser;
    private ValueTask<AsyncLock.Releaser>[]? _lockHandle;
#if !SIGNASSEMBLY
    private Nito.AsyncEx.AwaitableDisposable<IDisposable>[]? _lockNitoHandle;
#endif
#if NET10_0_OR_GREATER
    private ValueTask[]? _lockDotNextHandle;
#endif
    private ValueTask<global::AsyncKeyedLock.AsyncNonKeyedLockReleaser>[]? _lockNonKeyedHandle;
    private Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[]? _lockVSThreadingHandle;

    // SemaphoreSlim's timed overload returns Task<bool> rather than Task, so the timed benchmark below
    // cannot reuse the untimed handle array.
    private Task<bool>[]? _semaphoreSlimTimedHandle;
#if !NETFRAMEWORK
    private Task<IDisposable>[]? _lockNeoSmartHandle;
    private Proto.Promises.Promise<Proto.Promises.Threading.AsyncLock.Key>[]? _lockProtoPromiseHandle;
#endif
    private Task<RefImpl.AsyncLock.Releaser>[]? _lockRefImplHandle;

    public static readonly object[] FixtureArgs = {
        new object[] { 0 },
        new object[] { 1 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(0, 1, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncLockMultipleBenchmark() { }

    public AsyncLockMultipleBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockSemaphoreSlimMultipleTestAsync(CancellationType cancellationType)
    {
        SemaphoreSlimGlobalSetup();
        return LockUnlockSemaphoreSlimMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockSemaphoreSlimMultipleAsync))]
    public void SemaphoreSlimGlobalSetup()
    {
        base.GlobalSetup();
        _tasks = new Task[Iterations];
    }

    /// <summary>
    /// Benchmark for SemaphoreSlim used as async lock with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "System", "SemaphoreSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockSemaphoreSlimMultipleAsync(CancellationType cancellationType)
    {
        await _semaphoreSlim.WaitAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasks![i] = _semaphoreSlim.WaitAsync(cancellationType.CancellationToken);
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }

        foreach (Task handle in _tasks!)
        {
            await handle.ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public Task LockUnlockPooledMultipleTestAsync(CancellationType cancellationType)
    {
        PooledGlobalSetup();
        return LockUnlockPooledMultipleAsync(cancellationType);
    }

    // Note: only this variant carries the timed dimension. It is the baseline, so its timed row is
    // directly comparable to its own untimed one, which is the measurement that matters - what a timer
    // per queued waiter costs. Repeating it across every Pooled shape would multiply the matrix without
    // adding a distinct question.

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
        _lockHandle = new ValueTask<AsyncLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters using ValueTask.
    /// </summary>
    /// <remarks>
    /// Measures the allocation-free hot path when queuing multiple lock requests.
    /// Demonstrates the pooled implementation's ability to minimize allocations
    /// by reusing pooled IValueTaskSource instances for queued waiters.
    /// </remarks>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Multiple", "Pooled (ValueTask)")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledTimedGroup))]
    public async Task LockUnlockPooledMultipleAsync(CancellationType cancellationType)
    {
        // Timeout is InfiniteTimeSpan for the untimed variants, which the implementation treats as "arm
        // no timer" - so one call site serves every variant without branching.
        using (await _lockPooled.LockAsync(cancellationType.Timeout, cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = _lockPooled.LockAsync(cancellationType.Timeout, cancellationType.CancellationToken);
            }
        }

        foreach (ValueTask<AsyncLock.Releaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockPooledTaskMultipleTestAsync(CancellationType cancellationType)
    {
        PooledTaskGlobalSetup();
        return LockUnlockPooledTaskMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledTaskMultipleAsync))]
    public void PooledTaskGlobalSetup()
    {
        base.GlobalSetup();
        _tasksReleaser = new Task<AsyncLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async lock with multiple queued waiters using Task (converted from ValueTask).
    /// </summary>
    /// <remarks>
    /// Measures the overhead when ValueTask is converted to Task via AsTask() for multiple queued requests.
    /// This pattern incurs Task allocation overhead compared to awaiting ValueTask directly.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "Pooled (Task)")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockPooledTaskMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockPooled.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasksReleaser![i] = _lockPooled.LockAsync(cancellationType.CancellationToken).AsTask();
            }
        }

        foreach (Task<AsyncLock.Releaser> task in _tasksReleaser!)
        {
            using (await task.ConfigureAwait(false)) { }
        }
    }

#if !SIGNASSEMBLY
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNitoMultipleTestAsync(CancellationType cancellationType)
    {
        NitoGlobalSetup();
        return LockUnlockNitoMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNitoMultipleAsync))]
    public void NitoGlobalSetup()
    {
        base.GlobalSetup();
        _lockNitoHandle = new Nito.AsyncEx.AwaitableDisposable<IDisposable>[Iterations];
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party Nito.AsyncEx library under contention.
    /// This implementation uses Task-based primitives and allocates per queued waiter.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "Nito")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNitoMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNitoAsync.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNitoHandle![i] = _lockNitoAsync.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (Nito.AsyncEx.AwaitableDisposable<IDisposable> handle in _lockNitoHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
#endif

#if NET10_0_OR_GREATER
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockDotNextMultipleTestAsync(CancellationType cancellationType)
    {
        DotNextGlobalSetup();
        return LockUnlockDotNextMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockDotNextMultipleAsync))]
    public void DotNextGlobalSetup()
    {
        base.GlobalSetup();
        _lockDotNextHandle = new ValueTask[Iterations];
    }

    /// <summary>
    /// Benchmark for the DotNext.Threading async exclusive lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party DotNext.Threading library under contention.
    /// <see cref="DotNext.Threading.AsyncExclusiveLock"/> has no disposable releaser, so each
    /// acquisition - the initial one and every queued one - is paired with an explicit Release() call.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "DotNext")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockDotNextMultipleAsync(CancellationType cancellationType)
    {
        await _lockDotNext.AcquireAsync(cancellationType.CancellationToken).ConfigureAwait(false);
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockDotNextHandle![i] = _lockDotNext.AcquireAsync(cancellationType.CancellationToken);
            }
        }
        finally
        {
            _lockDotNext.Release();
        }

        foreach (ValueTask handle in _lockDotNextHandle!)
        {
            await handle.ConfigureAwait(false);
            _lockDotNext.Release();
        }
    }
#endif

#if !NETFRAMEWORK
    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNeoSmartMultipleTestAsync(CancellationType cancellationType)
    {
        NeoSmartGlobalSetup();
        return LockUnlockNeoSmartMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNeoSmartMultipleAsync))]
    public void NeoSmartGlobalSetup()
    {
        base.GlobalSetup();
        _lockNeoSmartHandle = new Task<IDisposable>[Iterations];
    }

    /// <summary>
    /// <b>Out of contest:</b> Benchmark for NeoSmart.AsyncLock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party NeoSmart.AsyncLock library under contention.
    /// This implementation uses Task-based disposable primitives.
    /// Since NeoSmart has a means of detecting that the lock is a nested acquisition by the same
    /// Task, the behavior differs here as it can directly pass a completed task for nested waits.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "NeoSmart")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNeoSmartMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNeoSmart.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNeoSmartHandle![i] = _lockNeoSmart.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (Task<IDisposable> handle in _lockNeoSmartHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.ProtoPromisesNoneNotCanceledGroup))]
    public Task LockUnlockProtoPromiseMultipleTestAsync(CancellationType cancelationType)
    {
        ProtoPromiseGlobalSetup();
        return LockUnlockProtoPromiseMultipleAsync(cancelationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockProtoPromiseMultipleAsync))]
    public void ProtoPromiseGlobalSetup()
    {
        base.GlobalSetup();
        _lockProtoPromiseHandle = new Proto.Promises.Promise<Proto.Promises.Threading.AsyncLock.Key>[Iterations];
    }

    /// <summary>
    /// Benchmark for Proto.Promises async lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party Proto.Promises async lock library under contention.
    /// This implementation uses Promises-based disposable primitives.
    /// Since ProtoPromises has custom implementations of pooling and waiter management, 
    /// the behavior under contention may differ significantly from Task- or ValueTask-based implementations.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "ProtoPromise")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.ProtoPromisesNoneNotCanceledGroup))]
    public async Task LockUnlockProtoPromiseMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockProtoPromise.LockAsync(cancellationType.CancelationToken, false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockProtoPromiseHandle![i] = _lockProtoPromise.LockAsync(cancellationType.CancelationToken, false);
            }
        }

        foreach (var handle in _lockProtoPromiseHandle!)
        {
            using (await handle) { }
        }
    }
#endif

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
        base.GlobalSetup();
        _lockRefImplHandle = new Task<RefImpl.AsyncLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for reference implementation async lock with multiple queued waiters (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the performance of the TaskCompletionSource-based reference implementation under contention.
    /// This serves as the baseline for comparing allocation-free pooled patterns with multiple waiters.
    /// Allocates a new TaskCompletionSource per queued waiter.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "RefImpl")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task LockUnlockRefImplMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockRefImp.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockRefImplHandle![i] = _lockRefImp.LockAsync();
            }
        }

        foreach (Task<RefImpl.AsyncLock.Releaser> handle in _lockRefImplHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockNonKeyedMultipleTestAsync(CancellationType cancellationType)
    {
        NonKeyedGlobalSetup();
        return LockUnlockNonKeyedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockNonKeyedMultipleAsync))]
    public void NonKeyedGlobalSetup()
    {
        base.GlobalSetup();
        _lockNonKeyedHandle = new ValueTask<global::AsyncKeyedLock.AsyncNonKeyedLockReleaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for AsyncKeyedLock (NonKeyed) async lock with multiple queued waiters.
    /// </summary>
    /// <remarks>
    /// Measures the performance of the third-party AsyncKeyedLock library under contention.
    /// This high-performance library uses ValueTask-based primitives and optimized pooling strategies.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "NonKeyed")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockNonKeyedMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockNonKeyed.LockAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNonKeyedHandle![i] = _lockNonKeyed.LockAsync(cancellationType.CancellationToken);
            }
        }

        foreach (ValueTask<global::AsyncKeyedLock.AsyncNonKeyedLockReleaser> handle in _lockNonKeyedHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task LockUnlockVSThreadingMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingGlobalSetup();
        return LockUnlockVSThreadingMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockVSThreadingMultipleAsync))]
    public void VSThreadingGlobalSetup()
    {
        base.GlobalSetup();
        _lockVSThreadingHandle = new Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for Visual Studio Threading async semaphore used as an async lock with multiple queued waiters.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Multiple", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task LockUnlockVSThreadingMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockVSThreading.EnterAsync(cancellationType.CancellationToken).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockVSThreadingHandle![i] = _lockVSThreading.EnterAsync(cancellationType.CancellationToken);
            }
        }

        foreach (var handle in _lockVSThreadingHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public Task LockUnlockSemaphoreSlimTimedMultipleTestAsync(CancellationType cancellationType)
    {
        SemaphoreSlimTimedGlobalSetup();
        return LockUnlockSemaphoreSlimTimedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockSemaphoreSlimTimedMultipleAsync))]
    public void SemaphoreSlimTimedGlobalSetup()
    {
        base.GlobalSetup();
        _semaphoreSlimTimedHandle = new Task<bool>[Iterations];
    }

    /// <summary>
    /// Timed counterpart to <see cref="LockUnlockSemaphoreSlimMultipleAsync"/>.
    /// </summary>
    /// <remarks>
    /// A separate method because the timed overload returns <c>Task&lt;bool&gt;</c> - reporting whether
    /// the wait succeeded - where the untimed one returns a bare <c>Task</c>, so the two cannot share a
    /// handle array. The timeout never elapses, so the result is always <see langword="true"/> and what
    /// is measured is the cost of arming and disposing a timer per queued waiter.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "System", "SemaphoreSlim")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public async Task LockUnlockSemaphoreSlimTimedMultipleAsync(CancellationType cancellationType)
    {
        await _semaphoreSlim.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken).ConfigureAwait(false);
        try
        {
            for (int i = 0; i < Iterations; i++)
            {
                _semaphoreSlimTimedHandle![i] =
                    _semaphoreSlim.WaitAsync(cancellationType.Timeout, cancellationType.CancellationToken);
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }

        foreach (Task<bool> handle in _semaphoreSlimTimedHandle!)
        {
            await handle.ConfigureAwait(false);
            _semaphoreSlim.Release();
        }
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public Task LockUnlockVSThreadingTimedMultipleTestAsync(CancellationType cancellationType)
    {
        VSThreadingTimedGlobalSetup();
        return LockUnlockVSThreadingTimedMultipleAsync(cancellationType);
    }

    [GlobalSetup(Target = nameof(LockUnlockVSThreadingTimedMultipleAsync))]
    public void VSThreadingTimedGlobalSetup()
    {
        base.GlobalSetup();
        _lockVSThreadingHandle = new Task<Microsoft.VisualStudio.Threading.AsyncSemaphore.Releaser>[Iterations];
    }

    /// <summary>
    /// Timed counterpart to <see cref="LockUnlockVSThreadingMultipleAsync"/>.
    /// </summary>
    /// <remarks>
    /// The return type matches its untimed sibling here, but the overload takes a timeout <em>instead
    /// of</em> a cancellation token rather than alongside one, so it still needs its own method rather
    /// than another variant of the existing one.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("Multiple", "VS.Threading")]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.TimedGroup))]
    public async Task LockUnlockVSThreadingTimedMultipleAsync(CancellationType cancellationType)
    {
        using (await _lockVSThreading.EnterAsync(cancellationType.Timeout).ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockVSThreadingHandle![i] = _lockVSThreading.EnterAsync(cancellationType.Timeout);
            }
        }

        foreach (var handle in _lockVSThreadingHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
