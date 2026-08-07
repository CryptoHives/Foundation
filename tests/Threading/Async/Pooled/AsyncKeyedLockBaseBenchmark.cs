// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// Isolates the AsyncUtilities assembly behind an alias (see the PackageReference's Aliases
// attribute in Threading.Tests.csproj) so its types/extension methods are invisible under the
// default global:: alias everywhere else in this project - only this file, which declares the
// field, needs to name the type.
extern alias AsyncUtilitiesLib;

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

/// <summary>
/// Base class for benchmarking and testing different implementations of a keyed async lock.
/// </summary>
public abstract class AsyncKeyedLockBaseBenchmark
{
    private protected AsyncKeyedLock<string> _lockPooled;
    private protected AsyncKeyedLock.AsyncKeyedLocker<string> _lockThirdParty;
    private protected AsyncKeyedLock.StripedAsyncKeyedLocker<string> _lockStriped;
#if !NETFRAMEWORK
    private protected KeyedSemaphores.KeyedSemaphoresDictionary<string> _lockKeyedSemaphoresDictionary;
    private protected KeyedSemaphores.KeyedSemaphoresCollection<string> _lockKeyedSemaphoresStriped;
#endif
    private protected Dao.IndividualLock.IndividualLocks<string> _lockDao;
    private protected AsyncUtilitiesLib::AsyncUtilities.StripedAsyncLock<string> _lockAsyncUtilitiesStriped;
    private protected RefImpl.AsyncKeyedLock<string> _lockRefImpl;

    private protected volatile int _counter;

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
#if !NETFRAMEWORK
        _lockKeyedSemaphoresDictionary = new();
        _lockKeyedSemaphoresStriped = new(numberOfSemaphores: 31);
#endif
        _lockDao = new(EqualityComparer<string>.Default);
        _lockAsyncUtilitiesStriped = new(stripes: 31);
        _lockRefImpl = new();
    }
}
