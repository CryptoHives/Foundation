// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncLock;

using BenchmarkDotNet.Attributes;
using Nito.AsyncEx;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static CryptoHives.Foundation.Threading.Async.Pooled.AsyncLock;

[TestFixture]
[DisassemblyDiagnoser]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[NonParallelizable]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    private Task<AsyncLockReleaser>[]? _tasks;
    private ValueTask<AsyncLockReleaser>[]? _lockHandle;
    private AwaitableDisposable<IDisposable>[]? _lockNitoHandle;

    [Params(0, 1, 10, 100)]
    public int Iterations = 100;

    [Test]
    public Task LockUnlockPooledMultipleTestAsync()
    {
        PooledGlobalSetup();
        return LockUnlockPooledMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledGlobalSetup()
    {
        _lockHandle = new ValueTask<AsyncLockReleaser>[Iterations];
    }

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "Special test case")]
    public async Task LockUnlockPooledMultipleAsync()
    {
        using (await LockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = LockPooled.LockAsync();
            }
        }

        foreach (ValueTask<AsyncLockReleaser> handle in _lockHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockPooledTaskMultipleTestAsync()
    {
        PooledTaskGlobalSetup();
        return LockUnlockPooledTaskMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockPooledTaskMultipleAsync))]
    public void PooledTaskGlobalSetup()
    {
        _tasks = new Task<AsyncLockReleaser>[Iterations];
    }

    [Benchmark]
    public async Task LockUnlockPooledTaskMultipleAsync()
    {
        using (await LockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasks![i] = LockPooled.LockAsync().AsTask();
            }
        }

        // Await and dispose each acquired releaser sequentially to release the lock for the next waiter.
        foreach (Task<AsyncLockReleaser> t in _tasks!)
        {
            using (await t.ConfigureAwait(false)) { }
        }
    }

    [Test]
    public Task LockUnlockNitoMultipleTestAsync()
    {
        NitoGlobalSetup();
        return LockUnlockNitoMultipleAsync();
    }

    [GlobalSetup(Target = nameof(LockUnlockNitoMultipleAsync))]
    public void NitoGlobalSetup()
    {
        _lockNitoHandle = new AwaitableDisposable<IDisposable>[Iterations];
    }

    [Benchmark]
    public async Task LockUnlockNitoMultipleAsync()
    {
        using (await LockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNitoHandle![i] = LockNitoAsync.LockAsync();
            }
        }

        foreach (AwaitableDisposable<IDisposable> handle in _lockNitoHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
