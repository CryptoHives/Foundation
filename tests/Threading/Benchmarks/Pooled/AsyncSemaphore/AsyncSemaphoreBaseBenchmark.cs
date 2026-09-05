// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncSemaphore;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

#if !SIGNASSEMBLY
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncSemaphore.
/// </summary>
public abstract class AsyncSemaphoreBaseBenchmark
{
    private protected AsyncSemaphore _semaphorePooled;
#if !SIGNASSEMBLY
    private protected NitoAsyncEx.AsyncSemaphore _semaphoreNitoAsync;
#endif
    private protected RefImpl.AsyncSemaphore _semaphoreRefImp;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncSemaphore _semaphoreProtoPromises;
#endif
    private protected Microsoft.VisualStudio.Threading.AsyncSemaphore _semaphoreVSThreading;
    private protected SemaphoreSlim _semaphoreSlim;

    /// <summary>
    /// How many holders each semaphore admits at once.
    /// </summary>
    /// <remarks>
    /// Virtual rather than fixed at one because a semaphore configured with a count of one is a mutex,
    /// and measuring only that duplicates what the AsyncLock benchmarks already cover while never
    /// exercising the behaviour that makes a semaphore a semaphore - several holders admitted
    /// concurrently, and a release that has to decide which of several waiters to wake. Derived classes
    /// that care override this with a <c>[Params]</c> property; the rest inherit the mutex configuration
    /// their existing numbers were taken with.
    /// </remarks>
    private protected virtual int SemaphoreInitialCount => 1;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        int count = SemaphoreInitialCount;

        _semaphorePooled = new AsyncSemaphore(count);
#if !SIGNASSEMBLY
        _semaphoreNitoAsync = new NitoAsyncEx.AsyncSemaphore(count);
#endif
        _semaphoreRefImp = new RefImpl.AsyncSemaphore(count);
#if !NETFRAMEWORK
        _semaphoreProtoPromises = new Proto.Promises.Threading.AsyncSemaphore(count);
#endif
        _semaphoreSlim = new SemaphoreSlim(count, count);
        _semaphoreVSThreading = new Microsoft.VisualStudio.Threading.AsyncSemaphore(count);
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
