// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
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
/// Base class for benchmarking and testing different implementations of AsyncCountdownEvent.
/// </summary>
public abstract class AsyncCountdownEventBaseBenchmark
{
    private protected int _participantCount;
    private protected AsyncCountdownEvent _countdownPooled;
    private protected NitoAsyncEx.AsyncCountdownEvent _countdownNitoAsync;
    private protected RefImpl.AsyncCountdownEvent _countdownRefImp;
    private protected CountdownEvent _countdownStandard;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _participantCount = 10;
        _countdownPooled = new AsyncCountdownEvent(_participantCount);
        _countdownNitoAsync = new NitoAsyncEx.AsyncCountdownEvent(_participantCount);
        _countdownRefImp = new RefImpl.AsyncCountdownEvent(_participantCount);
        _countdownStandard = new CountdownEvent(_participantCount);
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
        _countdownStandard?.Dispose();
    }
}
