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
/// Base class for benchmarking and testing different implementations of AsyncManualResetEvent.
/// </summary>
public abstract class AsyncManualResetEventBaseBenchmark
{
    private protected AsyncManualResetEvent _eventPooled;
    private protected NitoAsyncEx.AsyncManualResetEvent _eventNitoAsync;
    private protected RefImpl.AsyncManualResetEvent _eventRefImp;
    private protected ManualResetEvent _eventStandard;
    private protected ManualResetEventSlim _eventSlim;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _eventPooled = new AsyncManualResetEvent();
        _eventNitoAsync = new NitoAsyncEx.AsyncManualResetEvent();
        _eventRefImp = new RefImpl.AsyncManualResetEvent();
        _eventStandard = new ManualResetEvent(false);
        _eventSlim = new ManualResetEventSlim(false);
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
        _eventStandard?.Dispose();
        _eventSlim?.Dispose();
    }
}
