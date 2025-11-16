// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncAutoResetEvent;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Threading;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

public abstract class AsyncAutoResetEventBaseBenchmarks
{
    protected Threading.Async.Pooled.AsyncAutoResetEvent? _eventPooled;
    protected NitoAsyncEx.AsyncAutoResetEvent? _eventNitoAsync;
    protected RefImpl.AsyncAutoResetEvent? _eventRefImpl;
    protected AutoResetEvent? _eventStandard;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _eventPooled = new Threading.Async.Pooled.AsyncAutoResetEvent();
        _eventNitoAsync = new NitoAsyncEx.AsyncAutoResetEvent();
        _eventRefImpl = new RefImpl.AsyncAutoResetEvent();
        _eventStandard = new AutoResetEvent(false);
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _eventStandard?.Dispose();
    }
}

