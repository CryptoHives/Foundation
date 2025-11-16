// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncLock;

using AsyncKeyedLock;
using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using Nito.AsyncEx;
using NUnit.Framework;

public abstract class AsyncLockBaseBenchmark
{
    protected readonly AsyncNonKeyedLocker LockNonKeyed = new();
    protected readonly Threading.Async.Pooled.AsyncLock LockPooled = new();
    protected readonly Nito.AsyncEx.AsyncLock LockNitoAsync = new();
    protected readonly object Lock = new();

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
