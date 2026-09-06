// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncCountdownEvent;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

#if !SIGNASSEMBLY
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncCountdownEvent.
/// </summary>
public abstract class AsyncCountdownEventBaseBenchmark
{
    private protected AsyncCountdownEvent _countdownPooled;
#if !SIGNASSEMBLY
    private protected NitoAsyncEx.AsyncCountdownEvent _countdownNitoAsync;
#endif
#if NET10_0_OR_GREATER
    private protected DotNext.Threading.AsyncCountdownEvent _countdownDotNext;
#endif
    private protected RefImpl.AsyncCountdownEvent _countdownRefImp;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncCountdownEvent _countdownProtoPromises;
#endif
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
#if !SIGNASSEMBLY
        _countdownNitoAsync = new NitoAsyncEx.AsyncCountdownEvent(ParticipantCount);
#endif
#if NET10_0_OR_GREATER
        _countdownDotNext = new DotNext.Threading.AsyncCountdownEvent(ParticipantCount);
#endif
        _countdownRefImp = new RefImpl.AsyncCountdownEvent(ParticipantCount);
#if !NETFRAMEWORK
        _countdownProtoPromises = new Proto.Promises.Threading.AsyncCountdownEvent(ParticipantCount);
#endif
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
#if NET10_0_OR_GREATER
        _countdownDotNext?.Dispose();
#endif
    }
}
