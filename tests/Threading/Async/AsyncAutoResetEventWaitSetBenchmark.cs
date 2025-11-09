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
    private volatile int _activeThreads = 0;

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
            Thread t = new Thread(AutoResetEventWaiterThread);
            t.Name = "AutoResetEventThread_" + i;
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
    public async Task PooledAsyncAutoResetEvent()
    {
        PooledAsyncAutoResetEventSetup();
        await PooledAsyncAutoResetEventWaitSet().ConfigureAwait(false);
        PooledAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(PooledAsyncAutoResetEventWaitSet))]
    public void PooledAsyncAutoResetEventSetup()
    {
        _task = _eventPooled!.WaitAsync().AsTask();

        for (int i = 1; i < Iterations; i++)
        {
            Thread t = new Thread(PooledAsyncAutoResetEventWaiterThread);
            t.Name = "PooledAutoResetEventThread_" + i;
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(PooledAsyncAutoResetEventWaitSet))]
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
    public async Task PooledAsyncAutoResetEventWaitSet()
    {
        _eventPooled!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task NitoAsyncAutoResetEvent()
    {
        NitoAsyncAutoResetEventSetup();
        await NitoAsyncAutoResetEventWaitSet().ConfigureAwait(false);
        NitoAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(NitoAsyncAutoResetEventWaitSet))]
    public void NitoAsyncAutoResetEventSetup()
    {
        _task = _eventNitoAsync!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            Thread t = new Thread(NitoAsyncAutoResetEventWaiterThread);
            t.Name = "NitoAsyncAutoResetEventThread_" + i;
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(NitoAsyncAutoResetEventWaitSet))]
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
    public async Task NitoAsyncAutoResetEventWaitSet()
    {
        _eventNitoAsync!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task RefImplAsyncAutoResetEvent()
    {
        RefImplAsyncAutoResetEventSetup();
        await RefImplAsyncAutoResetEventWaitSet().ConfigureAwait(false);
        RefImplAsyncAutoResetEventCleanup();
    }

    [IterationSetup(Target = nameof(RefImplAsyncAutoResetEventWaitSet))]
    public void RefImplAsyncAutoResetEventSetup()
    {
        _task = _eventRefImpl!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            Thread t = new Thread(RefImplAsyncAutoResetEventWaiterThread);
            t.Name = "RefImplAsyncAutoResetEventThread_" + i;
            t.Start();
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(RefImplAsyncAutoResetEventWaitSet))]
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
    public async Task RefImplAsyncAutoResetEventWaitSet()
    {
        _eventRefImpl!.Set();
        await _task!.ConfigureAwait(false);
    }
}

