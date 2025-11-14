// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// As precondition get a Task for the event waiter.
/// In the benchmark, set the auto reset event and then await the Task.
/// </summary>
[TestFixture]
[MemoryDiagnoser]
[NonParallelizable]
public class AsyncAutoResetEventWaitSetBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    private Task? _task;
    private volatile int _activeThreads;

    [Params(1, 10)]
    public int Iterations = 10;

    [Test]
    public void AutoResetEvent()
    {
        AutoResetEventSetup();
        AutoResetEventWaitSet();
        AutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(AutoResetEventWaitSet))]
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

    [IterationCleanup(Target = nameof(AutoResetEventWaitSet))]
    public void AutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventStandard!.Set();
        }
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Standard")]
    public void AutoResetEventWaitSet()
    {
        _eventStandard!.Set();
    }

    private void AutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        _eventStandard!.WaitOne();
        Interlocked.Decrement(ref _activeThreads);
    }

    [Test]
    public async Task PooledAsyncAutoResetEventAsync()
    {
        PooledAsyncAutoResetEventSetup();
        await PooledAsyncAutoResetEventWaitSetAsync().ConfigureAwait(false);
        PooledAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(PooledAsyncAutoResetEventWaitSetAsync))]
    public void PooledAsyncAutoResetEventSetup()
    {
        _task = _eventPooled!.WaitAsync().AsTask();

        for (int i = 1; i < Iterations; i++)
        {
            var t = new Thread(PooledAsyncAutoResetEventWaiterThread) {
                Name = "PooledAutoResetEventThread_" + i
            };
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(PooledAsyncAutoResetEventWaitSetAsync))]
    public void PooledAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventPooled!.Set();
        }
    }

    private void PooledAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        _eventPooled!.WaitAsync().AsTask().GetAwaiter().GetResult();
        Interlocked.Decrement(ref _activeThreads);
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Pooled")]
    public async Task PooledAsyncAutoResetEventWaitSetAsync()
    {
        _eventPooled!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task NitoAsyncAutoResetEventAsync()
    {
        NitoAsyncAutoResetEventSetup();
        await NitoAsyncAutoResetEventWaitSetAsync().ConfigureAwait(false);
        NitoAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(NitoAsyncAutoResetEventWaitSetAsync))]
    public void NitoAsyncAutoResetEventSetup()
    {
        _task = _eventNitoAsync!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            var t = new Thread(NitoAsyncAutoResetEventWaiterThread) {
                Name = "NitoAsyncAutoResetEventThread_" + i
            };
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(NitoAsyncAutoResetEventWaitSetAsync))]
    public void NitoAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventNitoAsync!.Set();
        }
    }

    private void NitoAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        _eventNitoAsync!.WaitAsync().GetAwaiter().GetResult();
        Interlocked.Decrement(ref _activeThreads);
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Nito")]
    public async Task NitoAsyncAutoResetEventWaitSetAsync()
    {
        _eventNitoAsync!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task RefImplAsyncAutoResetEventAsync()
    {
        RefImplAsyncAutoResetEventSetup();
        await RefImplAsyncAutoResetEventWaitSetAsync().ConfigureAwait(false);
        RefImplAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(RefImplAsyncAutoResetEventWaitSetAsync))]
    public void RefImplAsyncAutoResetEventSetup()
    {
        _task = _eventRefImpl!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            var t = new Thread(RefImplAsyncAutoResetEventWaiterThread) {
                Name = "RefImplAsyncAutoResetEventThread_" + i
            };
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(RefImplAsyncAutoResetEventWaitSetAsync))]
    public void RefImplAsyncAutoResetEventCleanup()
    {
        while (_activeThreads > 0)
        {
            _eventRefImpl!.Set();
        }
    }

    private void RefImplAsyncAutoResetEventWaiterThread()
    {
        Interlocked.Increment(ref _activeThreads);
        _eventRefImpl!.WaitAsync().GetAwaiter().GetResult();
        Interlocked.Decrement(ref _activeThreads);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("WaitSet", "RefImpl")]
    public async Task RefImplAsyncAutoResetEventWaitSetAsync()
    {
        _eventRefImpl!.Set();
        await _task!.ConfigureAwait(false);
    }
}

