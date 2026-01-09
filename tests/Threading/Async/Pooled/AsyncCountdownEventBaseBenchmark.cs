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
/// Base class for benchmarking and testing different implementations of AsyncCountdownEvent.
/// </summary>
public abstract class AsyncCountdownEventBaseBenchmark
{
    private protected AsyncCountdownEvent _countdownPooled;
    private protected NitoAsyncEx.AsyncCountdownEvent _countdownNitoAsync;
    private protected RefImpl.AsyncCountdownEvent _countdownRefImp;
    private protected CountdownEvent _countdownStandard;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    [Params(1, 10)]
    public int ParticipantCount { get; set; } = 5;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _countdownPooled = new AsyncCountdownEvent(ParticipantCount);
        _countdownNitoAsync = new NitoAsyncEx.AsyncCountdownEvent(ParticipantCount);
        _countdownRefImp = new RefImpl.AsyncCountdownEvent(ParticipantCount);
        _countdownStandard = new CountdownEvent(ParticipantCount);
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
