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
public class AsyncAutoResetEventSetWaitBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    [Test]
    [BenchmarkCategory("SetWait", "Standard")]
    public void AutoResetEventSetWait()
    {
        _eventStandard!.Set();
        _ = _eventStandard!.WaitOne();
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("SetWait", "Pooled")]
    public async Task PooledAsyncAutoResetEventSetWait()
    {
        _eventPooled!.Set();
        await _eventPooled!.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("SetWait", "Nito")]
    public async Task NitoAsyncAutoResetEventSetWait()
    {
        _eventNitoAsync!.Set();
        await _eventNitoAsync!.WaitAsync().ConfigureAwait(false);
    }

    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("SetWait", "RefImpl")]
    public async Task RefImplAsyncAutoResetEventSetWait()
    {
        _eventRefImpl!.Set();
        await _eventRefImpl!.WaitAsync().ConfigureAwait(false);
    }
}

