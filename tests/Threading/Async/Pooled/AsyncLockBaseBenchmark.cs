// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
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

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncAutoResetEvent.
/// </summary>
public abstract class AsyncLockBaseBenchmark
{
#if NET9_0_OR_GREATER
    private protected Lock _lock;
#endif
    private protected object _objectLock;
    private protected AsyncLock _lockPooled;
    private protected SemaphoreSlim _semaphoreSlim;
    private protected NitoAsyncEx.AsyncLock _lockNitoAsync;
    private protected AsyncKeyedLock.AsyncNonKeyedLocker _lockNonKeyed;
    private protected RefImpl.AsyncLock _lockRefImp;
#if !NETFRAMEWORK
    private protected NeoSmart.AsyncLock.AsyncLock _lockNeoSmart;
#endif
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
#if NET9_0_OR_GREATER
        _lock = new();
#endif
        _objectLock = new();
        _lockPooled = new();
        _semaphoreSlim = new(1, 1);
        _lockNitoAsync = new();
        _lockNonKeyed = new();
        _lockRefImp = new();
#if !NETFRAMEWORK
        _lockNeoSmart = new();
#endif
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }
}
