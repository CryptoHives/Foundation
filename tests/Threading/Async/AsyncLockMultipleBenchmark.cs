// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using BenchmarkDotNet.Attributes;
using Nito.AsyncEx;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static CryptoHives.Foundation.Threading.Async.PooledAsyncLock;

[TestFixture]
[MemoryDiagnoser]
[NonParallelizable]
public class AsyncLockMultipleBenchmark : AsyncLockBaseBenchmark
{
    [Test]
    [Benchmark]
    public async Task LockUnlockPooledMultipleAsync()
    {
        ValueTask<Releaser> lockHandle00;
        ValueTask<Releaser> lockHandle01;
        ValueTask<Releaser> lockHandle02;
        ValueTask<Releaser> lockHandle03;
        ValueTask<Releaser> lockHandle04;
        ValueTask<Releaser> lockHandle05;
        ValueTask<Releaser> lockHandle06;
        ValueTask<Releaser> lockHandle07;
        ValueTask<Releaser> lockHandle08;
        ValueTask<Releaser> lockHandle09;

        using (await _lockPooled.LockAsync().ConfigureAwait(false))
        {
            lockHandle00 = _lockPooled.LockAsync();
            lockHandle01 = _lockPooled.LockAsync();
            lockHandle02 = _lockPooled.LockAsync();
            lockHandle03 = _lockPooled.LockAsync();
            lockHandle04 = _lockPooled.LockAsync();
            lockHandle05 = _lockPooled.LockAsync();
            lockHandle06 = _lockPooled.LockAsync();
            lockHandle07 = _lockPooled.LockAsync();
            lockHandle08 = _lockPooled.LockAsync();
            lockHandle09 = _lockPooled.LockAsync();
        }

        using (await lockHandle00.ConfigureAwait(false)) { }
        using (await lockHandle01.ConfigureAwait(false)) { }
        using (await lockHandle02.ConfigureAwait(false)) { }
        using (await lockHandle03.ConfigureAwait(false)) { }
        using (await lockHandle04.ConfigureAwait(false)) { }
        using (await lockHandle05.ConfigureAwait(false)) { }
        using (await lockHandle06.ConfigureAwait(false)) { }
        using (await lockHandle07.ConfigureAwait(false)) { }
        using (await lockHandle08.ConfigureAwait(false)) { }
        using (await lockHandle09.ConfigureAwait(false)) { }
    }

    [Test]
    [Benchmark]
    public async Task LockUnlockNitoMultipleAsync()
    {
        AwaitableDisposable<IDisposable> lockHandle00;
        AwaitableDisposable<IDisposable> lockHandle01;
        AwaitableDisposable<IDisposable> lockHandle02;
        AwaitableDisposable<IDisposable> lockHandle03;
        AwaitableDisposable<IDisposable> lockHandle04;
        AwaitableDisposable<IDisposable> lockHandle05;
        AwaitableDisposable<IDisposable> lockHandle06;
        AwaitableDisposable<IDisposable> lockHandle07;
        AwaitableDisposable<IDisposable> lockHandle08;
        AwaitableDisposable<IDisposable> lockHandle09;

        using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
        {
            lockHandle00 = _lockNitoAsync.LockAsync();
            lockHandle01 = _lockNitoAsync.LockAsync();
            lockHandle02 = _lockNitoAsync.LockAsync();
            lockHandle03 = _lockNitoAsync.LockAsync();
            lockHandle04 = _lockNitoAsync.LockAsync();
            lockHandle05 = _lockNitoAsync.LockAsync();
            lockHandle06 = _lockNitoAsync.LockAsync();
            lockHandle07 = _lockNitoAsync.LockAsync();
            lockHandle08 = _lockNitoAsync.LockAsync();
            lockHandle09 = _lockNitoAsync.LockAsync();
        }

        using (await lockHandle00.ConfigureAwait(false)) { }
        using (await lockHandle01.ConfigureAwait(false)) { }
        using (await lockHandle02.ConfigureAwait(false)) { }
        using (await lockHandle03.ConfigureAwait(false)) { }
        using (await lockHandle04.ConfigureAwait(false)) { }
        using (await lockHandle05.ConfigureAwait(false)) { }
        using (await lockHandle06.ConfigureAwait(false)) { }
        using (await lockHandle07.ConfigureAwait(false)) { }
        using (await lockHandle08.ConfigureAwait(false)) { }
        using (await lockHandle09.ConfigureAwait(false)) { }
    }
}
