// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncAutoResetEvent;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
public abstract class AsyncAutoResetEventBaseBenchmark
{
    private protected AsyncAutoResetEvent _eventPooled;
#if !SIGNASSEMBLY
    private protected Nito.AsyncEx.AsyncAutoResetEvent _eventNitoAsync;
#endif
#if NET10_0_OR_GREATER
    private protected DotNext.Threading.AsyncAutoResetEvent _eventDotNext;
#endif
    private protected RefImpl.AsyncAutoResetEvent _eventRefImp;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncAutoResetEvent _eventProtoPromises;
#endif
    private protected AutoResetEvent _eventStandard;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _eventPooled = new AsyncAutoResetEvent();
#if !SIGNASSEMBLY
        _eventNitoAsync = new Nito.AsyncEx.AsyncAutoResetEvent();
#endif
#if NET10_0_OR_GREATER
        _eventDotNext = new DotNext.Threading.AsyncAutoResetEvent(false);
#endif
        _eventRefImp = new RefImpl.AsyncAutoResetEvent();
#if !NETFRAMEWORK
        _eventProtoPromises = new Proto.Promises.Threading.AsyncAutoResetEvent();
#endif
        _eventStandard = new AutoResetEvent(false);
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
#if NET10_0_OR_GREATER
        _eventDotNext?.Dispose();
#endif
    }
}

