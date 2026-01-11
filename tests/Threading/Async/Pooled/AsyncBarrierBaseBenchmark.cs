// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncBarrier.
/// </summary>
public abstract class AsyncBarrierBaseBenchmark
{
    private protected AsyncBarrier _barrierPooled;
    private protected RefImpl.AsyncBarrier _barrierRefImp;
    private protected Barrier _barrierStandard;
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
        _barrierPooled = new AsyncBarrier(ParticipantCount);
        _barrierRefImp = new RefImpl.AsyncBarrier(ParticipantCount);
        _barrierStandard = new Barrier(ParticipantCount);
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
        _barrierStandard?.Dispose();
    }
}
