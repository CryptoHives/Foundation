// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncLock;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

#if !SIGNASSEMBLY
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
public abstract class AsyncLockBaseBenchmark
{
#if NET9_0_OR_GREATER
    private protected Lock _lock;
#endif
    private protected object _objectLock;
    private protected AsyncLock _lockPooled;
    private protected SemaphoreSlim _semaphoreSlim;
    private protected SpinLock _spinLock;
    private protected CryptoHives.Foundation.Threading.Internal.SpinLock _spinLockCryptoHives;
#if !SIGNASSEMBLY
    private protected NitoAsyncEx.AsyncLock _lockNitoAsync;
#endif
    private protected global::AsyncKeyedLock.AsyncNonKeyedLocker _lockNonKeyed;
    private protected RefImpl.AsyncLock _lockRefImp;
    private protected Microsoft.VisualStudio.Threading.AsyncSemaphore _lockVSThreading;
#if !NETFRAMEWORK
    private protected NeoSmart.AsyncLock.AsyncLock _lockNeoSmart;
    private protected Proto.Promises.Threading.AsyncLock _lockProtoPromise;
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
        _spinLock = new(enableThreadOwnerTracking: false);
        _spinLockCryptoHives = new();
#if !SIGNASSEMBLY
        _lockNitoAsync = new();
#endif
        _lockNonKeyed = new();
        _lockRefImp = new();
        _lockVSThreading = new(1);
#if !NETFRAMEWORK
        _lockNeoSmart = new();
        _lockProtoPromise = new();
#endif
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _lockVSThreading?.Dispose();
    }
}
