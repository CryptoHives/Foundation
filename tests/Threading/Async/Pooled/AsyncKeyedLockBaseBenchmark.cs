// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;

/// <summary>
/// Base class for benchmarking and testing different implementations of a keyed async lock.
/// </summary>
public abstract class AsyncKeyedLockBaseBenchmark
{
    private protected AsyncKeyedLock<string> _lockPooled;
    private protected AsyncKeyedLock.AsyncKeyedLocker<string> _lockThirdParty;
    private protected AsyncKeyedLock.StripedAsyncKeyedLocker<string> _lockStriped;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _lockPooled = new();
        _lockThirdParty = new();
        // Same striping width AsyncKeyedLock's own README recommends as a starting point.
        _lockStriped = new(numberOfStripes: 31, maxCount: 1, comparer: null!);
    }
}
