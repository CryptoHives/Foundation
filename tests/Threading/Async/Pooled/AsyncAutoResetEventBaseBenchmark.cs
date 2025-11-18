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

public abstract class AsyncAutoResetEventBaseBenchmark
{
    protected AsyncAutoResetEvent? _eventPooled;
    protected NitoAsyncEx.AsyncAutoResetEvent? _eventNitoAsync;
    protected RefImpl.AsyncAutoResetEvent? _eventRefImpl;
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
        _eventRefImpl = new RefImpl.AsyncAutoResetEvent();
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

