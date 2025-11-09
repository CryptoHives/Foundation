// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;

/// <summary>
/// Set the auto reset event.
/// </summary>
[TestFixture]
[MemoryDiagnoser]
public class AsyncAutoResetEventSetBenchmarks : AsyncAutoResetEventBaseBenchmarks
{
    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Standard")]
    public void AutoResetEventSet()
    {
        _eventStandard!.Set();
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Pooled")]
    public void PooledAsyncAutoResetEventSet()
    {
        _eventPooled!.Set();
    }

    [Test]
    [Benchmark]
    [BenchmarkCategory("Set", "Nito")]
    public void NitoAsyncAutoResetEventSet()
    {
        _eventNitoAsync!.Set();
    }

    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Set", "RefImpl")]
    public void RefImplAsyncAutoResetEventSet()
    {
        _eventRefImpl!.Set();
    }
}

