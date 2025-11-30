// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
public abstract class AsyncAutoResetEventBaseBenchmark
{
    private protected AsyncAutoResetEvent _eventPooled;
    private protected NitoAsyncEx.AsyncAutoResetEvent _eventNitoAsync;
    private protected RefImpl.AsyncAutoResetEvent _eventRefImp;
    private protected AutoResetEvent _eventStandard;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// The cancellation tokens for test and benchmark runs.
    /// </summary>
    public static IEnumerable<object[]> CancelParams()
    {
        yield return new object[] { "None", CancellationToken.None };
        yield return new object[] { "Token", new CancellationTokenSource().Token };
    }

    /// <summary>
    /// The cancellation tokens for test and benchmark runs.
    /// </summary>
    public static IEnumerable<object[]> CancelNoneParams()
    {
        yield return new object[] { "None", CancellationToken.None };
    }

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _eventPooled = new AsyncAutoResetEvent();
        _eventNitoAsync = new NitoAsyncEx.AsyncAutoResetEvent();
        _eventRefImp = new RefImpl.AsyncAutoResetEvent();
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
    }
}

