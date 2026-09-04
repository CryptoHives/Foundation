// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncBarrier;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncBarrier.
/// </summary>
public abstract class AsyncBarrierBaseBenchmark
{
    private protected AsyncBarrier _barrierPooled;
    private protected RefImpl.AsyncBarrier _barrierRefImp;
    private protected Barrier _barrierStandard;

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
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _barrierStandard?.Dispose();
    }
}
