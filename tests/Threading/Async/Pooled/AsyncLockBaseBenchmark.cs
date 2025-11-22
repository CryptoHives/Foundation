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
    protected System.Threading.Lock Lock;
#endif
    protected object ObjectLock;
    protected AsyncLock LockPooled;
    protected System.Threading.SemaphoreSlim SemaphoreSlim;
    protected NitoAsyncEx.AsyncLock LockNitoAsync;
    protected AsyncKeyedLock.AsyncNonKeyedLocker LockNonKeyed;
    protected RefImpl.AsyncLock LockRefImpl;
#if !NETFRAMEWORK
    protected NeoSmart.AsyncLock.AsyncLock LockNeoSmart;
#endif

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
#if NET9_0_OR_GREATER
        Lock = new();
#endif
        ObjectLock = new();
        LockPooled = new();
        SemaphoreSlim = new(1, 1);
        LockNitoAsync = new();
        LockNonKeyed = new();
        LockRefImpl = new();
#if !NETFRAMEWORK
        LockNeoSmart = new();
#endif
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
