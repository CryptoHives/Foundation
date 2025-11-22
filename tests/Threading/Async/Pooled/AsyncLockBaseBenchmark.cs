// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1051  // Do not declare visible instance fields, benchmarks require fastest access

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

public abstract class AsyncLockBaseBenchmark
{
#if NET9_0_OR_GREATER
    protected readonly System.Threading.Lock Lock = new();
#endif
    protected readonly object ObjectLock = new();
    protected readonly AsyncLock LockPooled = new();
    protected readonly System.Threading.SemaphoreSlim SemaphoreSlim = new(1, 1);
    protected readonly NitoAsyncEx.AsyncLock LockNitoAsync = new();
    protected readonly AsyncKeyedLock.AsyncNonKeyedLocker LockNonKeyed = new();
    protected readonly RefImpl.AsyncLock LockRefImpl = new();
#if !NETFRAMEWORK
    protected readonly NeoSmart.AsyncLock.AsyncLock LockNeoSmart = new();
#endif

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
    }
}
