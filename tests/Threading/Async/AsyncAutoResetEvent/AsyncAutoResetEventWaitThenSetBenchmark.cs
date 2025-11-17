// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncAutoResetEvent;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring Wait-then-Set performance with multiple queued waiters on AutoResetEvent implementations.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance of signaling an auto-reset event
/// when multiple threads/tasks are already waiting. It measures contention handling
/// and the overhead of releasing queued waiters.
/// </para>
/// <para>
/// <b>Test scenario:</b> Queue multiple waiters, then signal the event and measure how quickly
/// the first queued waiter is released.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Standard:</b> Synchronous System.Threading.AutoResetEvent with blocking thread waits.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource with FIFO waiter queue.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library using Task-based primitives and internal queuing.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource with FIFO waiter queue.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Signaling overhead under contention and memory allocations per operation.
/// The number of concurrent waiters is controlled by the <see cref="Iterations"/> parameter.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[BenchmarkCategory("AsyncAutoResetEvent")]
[NonParallelizable]
public class AsyncAutoResetEventWaitThenSetBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    private Task? _task;
    private ValueTask _valueTask; 
    private volatile int _activeThreads;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 2 },
        new object[] { 10 }
    };

    [Params(1, 2, 10)]
    public int Iterations = 10;

    public AsyncAutoResetEventWaitThenSetBenchmarks() { }

    public AsyncAutoResetEventWaitThenSetBenchmarks(int iterations)
    {
        Iterations = iterations;
    }

    [Test]
    public void AutoResetEvent()
    {
        AutoResetEventSetup();
        AutoResetEventWaitThenSet();
        AutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(AutoResetEventWaitThenSet))]
    public void AutoResetEventSetup()
    {
        _eventStandard!.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            var t = new Thread(AutoResetEventWaiterThread) {
                Name = "AutoResetEventThread_" + i
            };
            t.Start();
        }
    }
    private void AutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        _eventStandard!.WaitOne();
        Interlocked.Decrement(ref _activeThreads);
    }

    [IterationCleanup(Target = nameof(AutoResetEventWaitThenSet))]
    public void AutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventStandard!.Set();
        }
    }

    /// <summary>
    /// Benchmark for standard synchronous AutoResetEvent with multiple queued thread waiters.
    /// </summary>
    /// <remarks>
    /// Measures the cost of signaling a blocking thread-based auto-reset event
    /// when multiple threads are queued. This is the synchronous baseline.
    /// <b>Out of competition</b> since there is no task await possible in the benchmark.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "Standard")]
    public void AutoResetEventWaitThenSet()
    {
        _eventStandard!.Set();
    }

    [Test]
    public async Task PooledAsyncAutoResetEventAsync()
    {
        PooledAsyncAutoResetEventSetup();
        await PooledAsyncAutoResetEventWaitThenSetAsync().ConfigureAwait(false);
        PooledAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(PooledAsyncAutoResetEventWaitThenSetAsync))]
    public void PooledAsyncAutoResetEventSetup()
    {
        _eventPooled!.Reset();

        _valueTask = _eventPooled!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            Task.Run(PooledAsyncAutoResetEventWaiterThread);
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(PooledAsyncAutoResetEventWaitThenSetAsync))]
    public void PooledAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventPooled!.Set();
        }
    }

    private async ValueTask PooledAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        await _eventPooled!.WaitAsync().ConfigureAwait(false);
        Interlocked.Decrement(ref _activeThreads);
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event with multiple queued async waiters.
    /// </summary>
    /// <remarks>
    /// Measures the cost of signaling a pooled auto-reset event when multiple
    /// async waiters are queued. The pooled implementation uses a FIFO queue
    /// of reusable IValueTaskSource instances to minimize allocations.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "Pooled")]
    public async Task PooledAsyncAutoResetEventWaitThenSetAsync()
    {
        _eventPooled!.Set();
        await _valueTask!.ConfigureAwait(false);
    }

    [Test]
    public async Task PooledAsTaskAsyncAutoResetEventAsync()
    {
        PooledAsTaskAsyncAutoResetEventSetup();
        await PooledAsTaskAsyncAutoResetEventWaitThenSetAsync().ConfigureAwait(false);
        PooledAsTaskAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(PooledAsTaskAsyncAutoResetEventWaitThenSetAsync))]
    public void PooledAsTaskAsyncAutoResetEventSetup()
    {
        _eventPooled!.Reset();

        _task = _eventPooled!.WaitAsync().AsTask();

        for (int i = 1; i < Iterations; i++)
        {
            Task.Run(PooledAsyncAutoResetEventWaiterThread);
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(PooledAsTaskAsyncAutoResetEventWaitThenSetAsync))]
    public void PooledAsTaskAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventPooled!.Set();
        }
    }

    /// <summary>
    /// Benchmark for pooled async auto-reset event with multiple queued async waiters.
    /// </summary>
    /// <remarks>
    /// Measures the cost of signaling a pooled auto-reset event when multiple
    /// async waiters are queued. The pooled implementation uses a FIFO queue
    /// of reusable IValueTaskSource instances to minimize allocations.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "PooledAsTask")]
    public async Task PooledAsTaskAsyncAutoResetEventWaitThenSetAsync()
    {
        _eventPooled!.Set();
        await _task!.ConfigureAwait(false);
    }


    [Test]
    public async Task NitoAsyncAutoResetEventAsync()
    {
        NitoAsyncAutoResetEventSetup();
        await NitoAsyncAutoResetEventWaitThenSetAsync().ConfigureAwait(false);
        NitoAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(NitoAsyncAutoResetEventWaitThenSetAsync))]
    public void NitoAsyncAutoResetEventSetup()
    {
        if (_eventNitoAsync!.IsSet)
        {
            _eventNitoAsync!.Wait();
        }

        _task = _eventNitoAsync!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            Task.Run(NitoAsyncAutoResetEventWaiterThread);
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(NitoAsyncAutoResetEventWaitThenSetAsync))]
    public void NitoAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventNitoAsync!.Set();
        }
    }

    private async Task NitoAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        await _eventNitoAsync!.WaitAsync().ConfigureAwait(false);
        Interlocked.Decrement(ref _activeThreads);
    }

    /// <summary>
    /// Benchmark for Nito.AsyncEx async auto-reset event with multiple queued async waiters.
    /// </summary>
    /// <remarks>
    /// Measures the cost of signaling the Nito.AsyncEx auto-reset event when multiple
    /// async waiters are queued. This implementation uses Task-based primitives
    /// with internal queuing.
    /// </remarks>
    [Benchmark]
    [BenchmarkCategory("WaitThenSet", "Nito.AsyncEx")]
    public async Task NitoAsyncAutoResetEventWaitThenSetAsync()
    {
        _eventNitoAsync!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task RefImplAsyncAutoResetEventAsync()
    {
        RefImplAsyncAutoResetEventSetup();
        await RefImplAsyncAutoResetEventWaitThenSetAsync().ConfigureAwait(false);
        RefImplAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(RefImplAsyncAutoResetEventWaitThenSetAsync))]
    public void RefImplAsyncAutoResetEventSetup()
    {
        _eventRefImpl!.Reset();

        _task = _eventRefImpl!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            Task.Run(RefImplAsyncAutoResetEventWaiterThread);
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(RefImplAsyncAutoResetEventWaitThenSetAsync))]
    public void RefImplAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventRefImpl!.Set();
        }
    }

    private async Task RefImplAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        await _eventRefImpl!.WaitAsync().ConfigureAwait(false);
        Interlocked.Decrement(ref _activeThreads);
    }

    /// <summary>
    /// Benchmark for reference implementation async auto-reset event with multiple queued async waiters (baseline).
    /// </summary>
    /// <remarks>
    /// Measures the cost of signaling a TaskCompletionSource-based auto-reset event
    /// when multiple async waiters are queued. This serves as the baseline for
    /// comparing allocation-free pooled patterns under contention.
    /// </remarks>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("WaitThenSet", "RefImpl")]
    public async Task RefImplAsyncAutoResetEventWaitThenSetAsync()
    {
        _eventRefImpl!.Set();
        await _task!.ConfigureAwait(false);
    }
}

