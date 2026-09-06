// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncConditionVariable;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using RefImpl = Threading.Tests.Async.RefImpl;
using System.Threading;

#if SIGNASSEMBLY
using NitoAsyncEx = Threading.Tests.Async.RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncConditionVariable.
/// </summary>
/// <remarks>
/// A condition variable is inseparable from the lock it is paired with, so each implementation
/// brings its own lock; the benchmarks measure the pair.
/// </remarks>
public abstract class AsyncConditionVariableBaseBenchmark
{
    private protected AsyncLock _lockPooled;
    private protected AsyncConditionVariable _conditionPooled;
    private protected NitoAsyncEx.AsyncLock _lockNitoAsync;
    private protected NitoAsyncEx.AsyncConditionVariable _conditionNitoAsync;
    private protected RefImpl.AsyncLock _lockRefImp;
    private protected RefImpl.AsyncConditionVariable _conditionRefImp;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// How many items travel through the producer/consumer pair per operation.
    /// </summary>
    [Params(1, 10)]
    public int Iterations { get; set; } = 10;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _lockPooled = new AsyncLock();
        _conditionPooled = new AsyncConditionVariable();
        _lockNitoAsync = new NitoAsyncEx.AsyncLock();
        _conditionNitoAsync = new NitoAsyncEx.AsyncConditionVariable(_lockNitoAsync);
        _lockRefImp = new RefImpl.AsyncLock();
        _conditionRefImp = new RefImpl.AsyncConditionVariable(_lockRefImp);
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }
}
