// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncLock;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

[TestFixture]
[DisassemblyDiagnoser]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[Description("Measures the performance of single-threaded lock/unlock operations.")]
[NonParallelizable]
public class AsyncLockSingleBenchmark : AsyncLockBaseBenchmark
{
    private int _counter;

    [Test]
    [Benchmark]
    public void LockUnlockSingle()
    {
        lock (Lock)
        {
            // simulate work
            _counter++;
        }
    }

    [Test]
    [Benchmark]
    public async Task LockUnlockPooledSingleAsync()
    {
        using (await LockPooled.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            _counter++;
        }
    }

    [Test]
    [Benchmark]
    public async Task LockUnlockNitoSingleAsync()
    {
        using (await LockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            // simulate work
            _counter++;
        }
    }
}
