// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable VSTHRD012 // Provide JoinableTaskFactory where allowed

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
/// Base class for benchmarking and testing different implementations of AsyncReaderWriterLock.
/// </summary>
public abstract class AsyncReaderWriterLockBaseBenchmark
{
    private protected AsyncReaderWriterLock _rwLockPooled;
    private protected NitoAsyncEx.AsyncReaderWriterLock _rwLockNitoAsync;
    private protected RefImpl.AsyncReaderWriterLock _rwLockRefImp;
    private protected Microsoft.VisualStudio.Threading.AsyncReaderWriterLock _rwLockVSThreading;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncReaderWriterLock _rwLockProtoPromises;
#endif
    private protected ReaderWriterLockSlim _rwLockSlim;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _rwLockPooled = new AsyncReaderWriterLock();
        _rwLockNitoAsync = new NitoAsyncEx.AsyncReaderWriterLock();
        _rwLockRefImp = new RefImpl.AsyncReaderWriterLock();
        _rwLockVSThreading = new Microsoft.VisualStudio.Threading.AsyncReaderWriterLock();
#if !NETFRAMEWORK
        _rwLockProtoPromises = new Proto.Promises.Threading.AsyncReaderWriterLock();
#endif
        _rwLockSlim = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _rwLockSlim?.Dispose();
        _rwLockVSThreading?.Dispose();
    }
}
