// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring Wait-then-Set performance with batched queued waiters on ManualResetEvent implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance and memory overhead of batched signaling scenarios
/// where multiple wait operations are queued first, then signaled once, and finally
/// all completions are awaited. This pattern tests bulk waiter queue management and batch completion efficiency.
/// Unlike AutoResetEvent which releases one waiter per Set(), ManualResetEvent releases all waiters at once.
/// </para>
/// <para>
/// <b>Test scenario:</b> Reset event, then Queue N waiters, then signal once, then await all N completions.
/// This differs from WaitSet benchmarks by batching operations rather than interleaving them.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (ValueTask, baseline):</b> Allocation-free implementation using pooled IValueTaskSource with FIFO waiter queue.</description></item>
/// <item><description><b>Pooled (AsTask):</b> Same pooled implementation converted to Task via AsTask() (incurs allocation overhead).</description></item>
/// <item><description><b>Pooled (ContSync):</b> Pooled implementation with synchronous continuation execution (RunContinuationAsynchronously=false).</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based primitives and internal FIFO queue.</description></item>
/// <item><description><b>RefImpl:</b> Reference implementation using TaskCompletionSource with FIFO waiter queue.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Batch signaling throughput, memory allocations, and queue management overhead
/// with varying batch sizes (controlled by <see cref="Iterations"/> parameter: 1, 2, 10, 100).
/// </para>
/// <para>
/// <b>Performance insight:</b> This pattern stresses the waiter queue and completion infrastructure
/// more than interleaved Wait/Set patterns, revealing allocation and throughput characteristics
/// under sustained batched load.
/// </para>
/// <para>
/// <b>Continuation behavior:</b> The pooled implementation supports configurable continuation scheduling via
/// <see cref="Threading.Async.Pooled.RunContinuationAsynchronously"/>.
/// When set to false, continuations may execute synchronously on the signaling thread, reducing context switching
/// overhead but potentially blocking the caller longer with a risk of deadlocks.
/// </para>
/// <para>
/// <b>AsTask() storage warning:</b> Converting ValueTask to Task via AsTask() and storing the result
/// before awaiting can cause severe performance degradation. The ManualResetValueTaskSourceCore internally
/// queues continuations, and storing Task references before signaling prevents immediate completion,
/// forcing asynchronous scheduling even when the event is already signaled. Always await ValueTask directly
/// or convert to Task immediately before awaiting for optimal performance.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[BenchmarkCategory("AsyncManualResetEvent")]
[NonParallelizable]
public class AsyncManualResetEventWaitThenSetBenchmark : AsyncManualResetEventBaseBenchmark
{
    private Task?[] _task;
    private ValueTask[] _valueTask;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 10 },
        new object[] { 100 }
    };

    [Params(1, 2, 10, 100)]
    public int Iterations { get; set; } = 10;

    public AsyncManualResetEventWaitThenSetBenchmark()
    {
        _task = Array.Empty<Task>();
        _valueTask = Array.Empty<ValueTask>();
    }

    public AsyncManualResetEventWaitThenSetBenchmark(int iterations) : this()
    {
        Iterations = iterations;
    }

    /// <summary>
    /// Global setup for benchmarks and tests.
    /// </summary>
    public override void GlobalSetup()
    {
        base.GlobalSetup();

        _task = new Task[Iterations];
        _valueTask = new ValueTask[Iterations];
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    public override void GlobalCleanup()
    {
        base.GlobalCleanup();
    }

    /// <summary>
    /// Global setup for benchmarks testing synchronous continuation execution.
    /// </summary>
    /// <remarks>
    /// Configures the pooled event to run continuations synchronously (on the signaling thread)
    /// instead of queuing them to the thread pool. This reduces context switching overhead
    /// but may increase Set() call duration. Faster at the risk of deadlocks.
    /// </remarks>
    [GlobalSetup(Targets = new[] {
        nameof(PooledContSyncAsyncManualResetEventWaitThenSetAsync),
        nameof(PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync),
        nameof(PooledAsTaskContSyncManualResetEventWaitThenSetAsync)
    })]
    public void GlobalSetupSynchronousContinuation()
    {
        GlobalSetup();
        _eventPooled.RunContinuationAsynchronously = false;
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with synchronous continuations using ValueTask.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the allocation-free hot path with synchronous continuation execution.
    /// When RunContinuationAsynchronously=false, continuations run on the signaling thread,
    /// eliminating thread pool queuing overhead at the cost of potentially blocking Set() longer.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters → Signal once (sync continuations) → Await all completions.
    /// </para>
    /// <para>
    /// This demonstrates the performance trade-off between reduced context switching and
    /// increased Set() call duration when continuations execute synchronously.
    /// </para>
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "Pooled")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledContSyncAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        return PooledAsyncManualResetEventWaitThenSetAsync(cancellationType);
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledAsyncManualResetEventContSyncWaitThenSetTestAsync(CancellationType cancellationType)
    {
        _eventPooled.RunContinuationAsynchronously = false;
        return PooledAsyncManualResetEventWaitThenSetAsync(cancellationType);
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with synchronous continuations using AsTask() conversion.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the overhead when ValueTask is awaited via AsTask() with synchronous continuation execution.
    /// Combines the allocation cost of AsTask() with synchronous continuation behavior.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters → await AsTask() immediately → Signal once (sync continuations).
    /// </para>
    /// <para>
    /// This pattern demonstrates lower overhead than storing Task references before signaling.
    /// </para>
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "PooledAsValueTask")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledAsValueTaskContSyncAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        return PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType);
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledAsTaskAsyncManualResetEventContSyncWaitThenSetTestAsync(CancellationType cancellationType)
    {
        _eventPooled.RunContinuationAsynchronously = false;
        return PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(cancellationType);
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with synchronous continuations and pre-stored Task references.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the severe performance degradation when Task references are stored before signaling
    /// with synchronous continuation execution. This anti-pattern forces asynchronous completion
    /// even when events are signaled, negating the benefits of synchronous continuations.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Store all Task references via AsTask() → Signal once → Await stored Tasks.
    /// </para>
    /// <para>
    /// <b>Performance warning:</b> This is an anti-pattern. Storing Task references prevents
    /// ManualResetValueTaskSourceCore from completing synchronously, causing unnecessary
    /// thread pool scheduling and degraded performance. Always await immediately or use ValueTask directly.
    /// </para>
    /// </remarks>
    [Benchmark(Description = "PooledAsTaskContSync")]
    [BenchmarkCategory("WaitThenSet", "PooledAsTask")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledAsTaskContSyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        return PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType);
    }

    [Test]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public Task PooledAsTaskRunSyncManualResetEventContSyncWaitThenSetTestAsync(CancellationType cancellationType)
    {
        _eventPooled.RunContinuationAsynchronously = false;
        return PooledAsTaskManualResetEventWaitThenSetAsync(cancellationType);
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with batched queued async waiters using ValueTask.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the allocation-free hot path when batching wait/signal/await operations
    /// with default asynchronous continuation execution (RunContinuationAsynchronously=true).
    /// The pooled implementation reuses pooled IValueTaskSource instances from the FIFO queue
    /// to minimize allocations during batch processing.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters → Signal once → Await all completions.
    /// </para>
    /// <para>
    /// This is the optimal usage pattern for the pooled implementation, demonstrating
    /// zero-allocation batch waiter handling with asynchronous continuation scheduling.
    /// </para>
    /// </remarks>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("WaitThenSet", "Pooled")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task PooledAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {

        _eventPooled.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            _valueTask[i] = _eventPooled.WaitAsync(cancellationType.CancellationToken);
        }

        _eventPooled.Set();

        for (int i = 0; i < Iterations; i++)
        {
            await _valueTask[i].ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with immediate AsTask() conversion and await.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the overhead when ValueTask is converted to Task via AsTask() immediately before awaiting.
    /// This pattern incurs Task allocation overhead but avoids the severe performance degradation
    /// of storing Task references before signaling.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters → Signal once → Immediately convert and await via AsTask().
    /// </para>
    /// <para>
    /// <b>Performance note:</b> This pattern is acceptable when Task is required (e.g., Task.WhenAll),
    /// but incurs allocation overhead compared to awaiting ValueTask directly. The immediate conversion
    /// allows the underlying ManualResetValueTaskSourceCore to complete synchronously when possible.
    /// </para>
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "PooledAsValueTask")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task PooledAsValueTaskAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        _eventPooled.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            _valueTask[i] = _eventPooled!.WaitAsync(cancellationType.CancellationToken);
        }

        _eventPooled.Set();

        for (int i = 0; i < Iterations; i++)
        {
            await _valueTask[i].AsTask().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Benchmark for pooled async manual-reset event with pre-stored Task references (anti-pattern).
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the severe performance degradation when Task references from AsTask() are stored
    /// before signaling the event. This anti-pattern forces asynchronous completion scheduling
    /// even when the event is already signaled, causing significant overhead.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Store all Task references via AsTask() → Signal once → Await stored Tasks.
    /// </para>
    /// <para>
    /// <b>Performance warning:</b> This is an anti-pattern and should be avoided. When Task references
    /// are stored before the event is signaled, the ManualResetValueTaskSourceCore cannot complete
    /// synchronously. Instead, it must queue continuations to the thread pool, negating the benefits
    /// of the pooled ValueTask implementation and causing severe performance degradation (often 10x-100x slower).
    /// </para>
    /// <para>
    /// <b>Recommendation:</b> Always await ValueTask directly, or convert to Task immediately before awaiting.
    /// Never store AsTask() results across signaling boundaries.
    /// </para>
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "PooledAsTask")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task PooledAsTaskManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        _eventPooled.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            _task[i] = _eventPooled!.WaitAsync(cancellationType.CancellationToken).AsTask();
        }

        _eventPooled.Set();

        for (int i = 0; i < Iterations; i++)
        {
            await _task[i]!.ConfigureAwait(false);
        }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async manual-reset event with batched queued async waiters.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the performance of the third-party Nito.AsyncEx library under batched load.
    /// This implementation uses Task-based primitives and allocates per queued waiter.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters as Task → Signal once → Await all completions.
    /// </para>
    /// <para>
    /// Serves as a Task-based reference for comparing against pooled ValueTask implementations.
    /// </para>
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "Nito.AsyncEx")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneNotCancelledGroup))]
    public async Task NitoAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        _eventNitoAsync.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            _task[i] = _eventNitoAsync!.WaitAsync(cancellationType.CancellationToken);
        }

        _eventNitoAsync.Set();

        for (int i = 0; i < Iterations; i++)
        {
            await _task[i]!.ConfigureAwait(false);
        }
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async manual-reset event with batched queued async waiters (baseline).
    /// </summary>
    /// <remarks>
    /// <para>
    /// Measures the performance of the TaskCompletionSource-based reference implementation under batched load.
    /// This serves as the baseline for comparing allocation-free pooled patterns in batch scenarios.
    /// Allocates a new TaskCompletionSource per queued waiter.
    /// </para>
    /// <para>
    /// <b>Pattern:</b> Queue all waiters as Task → Signal once → Await all completions.
    /// </para>
    /// <para>
    /// This baseline demonstrates typical Task-based async event performance and allocation
    /// characteristics when processing batched wait/signal operations.
    /// </para>
    /// </remarks>
    [Test]
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "RefImpl")]
    [TestCaseSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    [ArgumentsSource(typeof(CancellationType), nameof(CancellationType.NoneGroup))]
    public async Task RefImplAsyncManualResetEventWaitThenSetAsync(CancellationType cancellationType)
    {
        _eventRefImp.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            _task[i] = _eventRefImp!.WaitAsync();
        }

        _eventRefImp.Set();

        for (int i = 0; i < Iterations; i++)
        {
            await _task[i]!.ConfigureAwait(false);
        }
    }
}
