// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async;
using NUnit.Framework;
using System.Threading;

public abstract class AsyncAutoResetEventBaseBenchmarks
{
    protected PooledAsyncAutoResetEvent? _eventPooled;
    protected Nito.AsyncEx.AsyncAutoResetEvent? _eventNitoAsync;
    protected RefImpl.AsyncAutoResetEvent? _eventRefImpl;
    protected AutoResetEvent? _eventStandard;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        _eventPooled = new PooledAsyncAutoResetEvent();
        _eventNitoAsync = new Nito.AsyncEx.AsyncAutoResetEvent();
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

