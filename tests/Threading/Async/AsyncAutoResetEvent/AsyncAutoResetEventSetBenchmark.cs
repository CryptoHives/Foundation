// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncAutoResetEvent;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;

/// <summary>
/// Set the auto reset event.
/// </summary>
[TestFixture]
[ThreadingDiagnoser]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
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

