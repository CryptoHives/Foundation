// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncBarrier.
/// </summary>
public abstract class AsyncBarrierBaseBenchmark
{
    private protected int _participantCount;
    private protected AsyncBarrier _barrierPooled;
    private protected RefImpl.AsyncBarrier _barrierRefImp;
    private protected Barrier _barrierStandard;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _participantCount = 4;
        _barrierPooled = new AsyncBarrier(_participantCount);
        _barrierRefImp = new RefImpl.AsyncBarrier(_participantCount);
        _barrierStandard = new Barrier(_participantCount);
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
