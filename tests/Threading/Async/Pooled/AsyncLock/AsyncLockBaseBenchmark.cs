// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async.Pooled.AsyncLock;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;

public abstract class AsyncLockBaseBenchmark
{
#if NET9_0_OR_GREATER
    protected readonly System.Threading.Lock Lock = new();
#endif
    protected readonly object ObjectLock = new();
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
