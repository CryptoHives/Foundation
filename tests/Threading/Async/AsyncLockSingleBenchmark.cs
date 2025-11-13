// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading.Tasks;

[TestFixture]
[MemoryDiagnoser]
[NonParallelizable]
public class AsyncLockSingleBenchmark : AsyncLockBaseBenchmark
{
    [Test]
    [Benchmark]
    public void LockUnlockSingle()
    {
        lock (_lock)
        {
            // simulate work
        }
    }

    [Test]
    [Benchmark]
    public async Task LockUnlockPooledSingleAsync()
    {
        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            // simulate work
        }
    }

    [Test]
    [Benchmark]
    public async Task LockUnlockNitoSingleAsync()
    {
        using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            // simulate work
        }
    }
}
