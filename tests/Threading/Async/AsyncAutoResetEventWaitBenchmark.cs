// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Set the auto reset event and then wait for the triggered event.
/// </summary>
[TestFixture]
[MemoryDiagnoser]
public class AsyncAutoResetEventWaitBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "Pooled")]
    public async Task PooledAsyncAutoResetEventTaskWaitAsync()
    {
        Task t = _eventPooled!.WaitAsync().AsTask();
        _eventPooled!.Set();
        await t.ConfigureAwait(false);
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "Pooled")]
    public async Task PooledAsyncAutoResetEventValueTaskWaitAsync()
    {
        ValueTask vt = _eventPooled!.WaitAsync();
        _eventPooled!.Set();
        await vt.ConfigureAwait(false);
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("Wait", "Nito")]
    public async Task NitoAsyncAutoResetEventTaskWaitAsync()
    {
        Task t = _eventNitoAsync!.WaitAsync();
        _eventNitoAsync!.Set();
        await t.ConfigureAwait(false);
    }

    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Wait", "RefImpl")]
    public async Task RefImplAsyncAutoResetEventTaskWaitAsync()
    {
        Task t = _eventRefImpl!.WaitAsync();
        _eventRefImpl!.Set();
        await t.ConfigureAwait(false);
    }
}

