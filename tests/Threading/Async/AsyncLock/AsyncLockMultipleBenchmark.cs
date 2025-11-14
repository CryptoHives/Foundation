// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using Nito.AsyncEx;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static CryptoHives.Foundation.Threading.Async.PooledAsyncLock;

[TestFixture]
[MemoryDiagnoser]
[NonParallelizable]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    private Task[]? _tasks;
    private ValueTask<Releaser>[]? _lockHandle;
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
        _lockHandle = new ValueTask<Releaser>[Iterations];
    }

    [Benchmark]
    public async Task LockUnlockPooledMultipleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockHandle![i] = _lockPooled.LockAsync();
            }
        }

        foreach (ValueTask<Releaser> handle in _lockHandle!)
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

    [GlobalSetup(Target = nameof(LockUnlockPooledMultipleAsync))]
    public void PooledTaskGlobalSetup()
    {
        _tasks = new Task[Iterations];
    }

    [Benchmark]
    public async Task LockUnlockPooledTaskMultipleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _tasks![i] = _lockPooled.LockAsync().AsTask();
            }
        }

        foreach (Task task in _tasks!)
        {
            await task.ConfigureAwait(false);
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
        using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _lockNitoHandle![i] = _lockNitoAsync.LockAsync();
            }
        }

        foreach (AwaitableDisposable<IDisposable> handle in _lockNitoHandle!)
        {
            using (await handle.ConfigureAwait(false)) { }
        }
    }
}
