// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable VSTHRD012 // Provide JoinableTaskFactory where allowed

namespace Threading.Tests.Benchmarks.Pooled.AsyncReaderWriterLock;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading;
using RefImpl = Threading.Tests.Async.RefImpl;

#if !SIGNASSEMBLY
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncReaderWriterLock.
/// </summary>
public abstract class AsyncReaderWriterLockBaseBenchmark
{
    private protected AsyncReaderWriterLock _rwLockPooled;
#if !SIGNASSEMBLY
    private protected NitoAsyncEx.AsyncReaderWriterLock _rwLockNitoAsync;
#endif
    private protected RefImpl.AsyncReaderWriterLock _rwLockRefImp;
    private protected Microsoft.VisualStudio.Threading.AsyncReaderWriterLock _rwLockVSThreading;
#if !NETFRAMEWORK
    private protected Proto.Promises.Threading.AsyncReaderWriterLock _rwLockProtoPromises;
#endif
    private protected ReaderWriterLockSlim _rwLockSlim;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _rwLockPooled = new AsyncReaderWriterLock();
#if !SIGNASSEMBLY
        _rwLockNitoAsync = new NitoAsyncEx.AsyncReaderWriterLock();
#endif
        _rwLockRefImp = new RefImpl.AsyncReaderWriterLock();
        _rwLockVSThreading = new Microsoft.VisualStudio.Threading.AsyncReaderWriterLock();
#if !NETFRAMEWORK
        _rwLockProtoPromises = new Proto.Promises.Threading.AsyncReaderWriterLock();
#endif
        _rwLockSlim = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _rwLockSlim?.Dispose();
        _rwLockVSThreading?.Dispose();
    }
}
