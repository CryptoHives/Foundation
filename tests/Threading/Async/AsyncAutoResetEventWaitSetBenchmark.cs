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
        AutoResetEvent_Setup();
        AutoResetEvent_WaitSet();
        AutoResetEvent_Cleanup();
    }

    [IterationSetup(Target = nameof(AutoResetEvent_WaitSet))]
    public void AutoResetEvent_Setup()
    {
        _eventStandard!.Reset();

        for (int i = 0; i < Iterations; i++)
        {
            Thread t = new Thread(AutoResetEventWaiterThread);
            t.Name = "AutoResetEventThread_" + i;
            t.Start();
        }
    }

    [IterationCleanup(Target = nameof(AutoResetEvent_WaitSet))]
    public void AutoResetEvent_Cleanup()
    {
        while (_activeThreads > 0)
        {
            _eventStandard!.Set();
        }
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Standard")]
    public void AutoResetEvent_WaitSet()
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
        PooledAsyncAutoResetEvent_Setup();
        await PooledAsyncAutoResetEvent_WaitSet().ConfigureAwait(false);
        PooledAsyncAutoResetEvent_Cleanup();
    }

    [IterationSetup(Target = nameof(PooledAsyncAutoResetEvent_WaitSet))]
    public void PooledAsyncAutoResetEvent_Setup()
    {
        _task = _eventPooled!.WaitAsync().AsTask();

        for (int i = 1; i < Iterations; i++)
        {
            _ = Task.Run(async () => {
                Interlocked.Increment(ref _activeThreads);
                await _eventPooled!.WaitAsync().ConfigureAwait(false);
                Interlocked.Decrement(ref _activeThreads);
            });
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(PooledAsyncAutoResetEvent_WaitSet))]
    public void PooledAsyncAutoResetEvent_Cleanup()
    {
        while (_activeThreads > 0)
        {
            _eventPooled!.Set();
        }
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Pooled")]
    public async Task PooledAsyncAutoResetEvent_WaitSet()
    {
        _eventPooled!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task NitoAsyncAutoResetEvent()
    {
        NitoAsyncAutoResetEvent_Setup();
        await NitoAsyncAutoResetEvent_WaitSet().ConfigureAwait(false);
        NitoAsyncAutoResetEvent_Cleanup();
    }

    [IterationSetup(Target = nameof(NitoAsyncAutoResetEvent_WaitSet))]
    public void NitoAsyncAutoResetEvent_Setup()
    {
        _task = _eventNitoAsync!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            _ = Task.Run(async () => {
                Interlocked.Increment(ref _activeThreads);
                await _eventNitoAsync!.WaitAsync().ConfigureAwait(false);
                Interlocked.Decrement(ref _activeThreads);
            });
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [IterationCleanup(Target = nameof(NitoAsyncAutoResetEvent_WaitSet))]
    public void NitoAsyncAutoResetEvent_Cleanup()
    {
        while (_activeThreads > 0)
        {
            _eventNitoAsync!.Set();
        }
    }

    [Benchmark]
    [BenchmarkCategory("WaitSet", "Nito")]
    public async Task NitoAsyncAutoResetEvent_WaitSet()
    {
        _eventNitoAsync!.Set();
        await _task!.ConfigureAwait(false);
    }

    [Test]
    public async Task RefImplAsyncAutoResetEvent()
    {
        RefImplAsyncAutoResetEvent_Setup();
        await RefImplAsyncAutoResetEvent_WaitSet().ConfigureAwait(false);
    }

    [IterationSetup(Target = nameof(RefImplAsyncAutoResetEvent_WaitSet))]
    public void RefImplAsyncAutoResetEvent_Setup()
    {
        _eventRefImpl!.SetAll();

        _task = _eventRefImpl!.WaitAsync();

        for (int i = 1; i < Iterations; i++)
        {
            _ = Task.Run(async () => {
                Interlocked.Increment(ref _activeThreads);
                await _eventRefImpl!.WaitAsync().ConfigureAwait(false);
                Interlocked.Decrement(ref _activeThreads);
            });
        }

        while (_activeThreads < Iterations - 1)
        {
            Task.Delay(0).GetAwaiter().GetResult();
        }
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("WaitSet", "RefImpl")]
    public async Task RefImplAsyncAutoResetEvent_WaitSet()
    {
        _eventRefImpl!.Set();
        await _task!.ConfigureAwait(false);
    }
}

