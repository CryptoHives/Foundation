// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncSemaphore.
/// </summary>
public abstract class AsyncSemaphoreBaseBenchmark
{
    private protected AsyncSemaphore _semaphorePooled;
    private protected NitoAsyncEx.AsyncSemaphore _semaphoreNitoAsync;
    private protected RefImpl.AsyncSemaphore _semaphoreRefImp;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncSemaphore _semaphoreProtoPromises;
#endif
    private protected Microsoft.VisualStudio.Threading.AsyncSemaphore _semaphoreVSThreading;
    private protected SemaphoreSlim _semaphoreSlim;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _semaphorePooled = new AsyncSemaphore(1);
        _semaphoreNitoAsync = new NitoAsyncEx.AsyncSemaphore(1);
        _semaphoreRefImp = new RefImpl.AsyncSemaphore(1);
#if !NETFRAMEWORK
        _semaphoreProtoPromises = new Proto.Promises.Threading.AsyncSemaphore(1);
#endif
        _semaphoreSlim = new SemaphoreSlim(1, 1);
        _semaphoreVSThreading = new Microsoft.VisualStudio.Threading.AsyncSemaphore(1);
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _semaphoreSlim?.Dispose();
        _semaphoreVSThreading?.Dispose();
    }
}
