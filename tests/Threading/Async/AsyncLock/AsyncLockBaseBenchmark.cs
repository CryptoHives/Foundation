// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async;
using Nito.AsyncEx;
using NUnit.Framework;

public abstract class AsyncLockBaseBenchmark
{
    protected readonly PooledAsyncLock _lockPooled = new();
    protected readonly AsyncLock _lockNitoAsync = new();
    protected readonly object _lock = new();

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
    }
}
