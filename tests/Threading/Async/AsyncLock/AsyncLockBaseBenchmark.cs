// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.AsyncLock;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;

public abstract class AsyncLockBaseBenchmark
{
    protected readonly object Lock = new();
    protected readonly Threading.Async.Pooled.AsyncLock LockPooled = new();
    protected readonly Nito.AsyncEx.AsyncLock LockNitoAsync = new();
    protected readonly AsyncKeyedLock.AsyncNonKeyedLocker LockNonKeyed = new();
    protected readonly RefImpl.AsyncLock LockRefImpl = new();

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
