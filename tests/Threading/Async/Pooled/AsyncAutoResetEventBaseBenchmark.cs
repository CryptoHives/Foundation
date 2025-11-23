// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
[SuppressMessage("Design", "CA1051:Do not declare visible instance fields", Justification = "Benchmarks require fastest access")]
public abstract class AsyncAutoResetEventBaseBenchmark
{
    protected AsyncAutoResetEvent? _eventPooled;
    protected NitoAsyncEx.AsyncAutoResetEvent? _eventNitoAsync;
    protected RefImpl.AsyncAutoResetEvent? _eventRefImp;
    protected AutoResetEvent? _eventStandard;

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
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _eventStandard?.Dispose();
    }
}

