// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
[SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Benchmarks require fastest access")]
public abstract class AsyncLockBaseBenchmark
{
#if NET9_0_OR_GREATER
    protected System.Threading.Lock _lock;
#endif
    protected object _objectLock;
    protected AsyncLock _lockPooled;
    protected System.Threading.SemaphoreSlim _semaphoreSlim;
    protected NitoAsyncEx.AsyncLock _lockNitoAsync;
    protected AsyncKeyedLock.AsyncNonKeyedLocker _lockNonKeyed;
    protected RefImpl.AsyncLock _lockRefImp;
#if !NETFRAMEWORK
    protected NeoSmart.AsyncLock.AsyncLock _lockNeoSmart;
#endif

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
#if NET9_0_OR_GREATER
        _lock = new();
#endif
        _objectLock = new();
        _lockPooled = new();
        _semaphoreSlim = new(1, 1);
        _lockNitoAsync = new();
        _lockNonKeyed = new();
        _lockRefImp = new();
#if !NETFRAMEWORK
        _lockNeoSmart = new();
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
