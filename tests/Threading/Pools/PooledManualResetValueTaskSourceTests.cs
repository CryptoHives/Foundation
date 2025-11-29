// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PooledManualResetValueTaskSourceTests
{
    [Test, CancelAfter(1000)]
    public async Task ValueTaskCompletesWhenSetResultCalledAsync()
    {
        TestObjectPool<bool> tpvts = new TestObjectPool<bool>();
        PooledManualResetValueTaskSource<bool> vts = tpvts.GetPooledValueTaskSource();

        var vt = new ValueTask<bool>(vts, vts.Version);
        short version = vts.Version;

        using (Assert.EnterMultipleScope())
        {
            // version matches
            Assert.That(version, Is.EqualTo(vts.Version));

            // not completed yet
            Assert.That(vt.IsCompleted, Is.False);
        }

        // complete
        vts.SetResult(true);

        // now completed
        bool result = await vt.ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);

            // version has changed
            Assert.That(version, Is.Not.EqualTo(vts.Version));
        }

        // calling with old version throws
        _ = Assert.ThrowsAsync<InvalidOperationException>(async () => await vt.ConfigureAwait(false));
        _ = Assert.ThrowsAsync<InvalidOperationException>(vt.AsTask);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test, CancelAfter(1000)]
    public async Task ValueTaskAsTaskCompletesWhenSetResultCalledAsync()
    {
        TestObjectPool<bool> tpvts = new TestObjectPool<bool>();
        PooledManualResetValueTaskSource<bool> vts = tpvts.GetPooledValueTaskSource();

        var vt = new ValueTask<bool>(vts, vts.Version);
        short version = vts.Version;

        Task<bool> t = vt.AsTask();

        using (Assert.EnterMultipleScope())
        {
            // version matches
            Assert.That(version, Is.EqualTo(vts.Version));

            // not completed yet
            Assert.That(t.IsCompleted, Is.False);
        }

        // complete
        vts.SetResult(true);

        // now completed
        bool result = await t.ConfigureAwait(false);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);

            // version changed
            Assert.That(version, Is.Not.EqualTo(vts.Version));
        }

        // calling with old version throws
        _ = Assert.ThrowsAsync<InvalidOperationException>(async () => await vt.ConfigureAwait(false));
        _ = Assert.ThrowsAsync<InvalidOperationException>(vt.AsTask);

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public async Task OnCompletedInvokesContinuationWhenSignaledAsync()
    {
        TestObjectPool<bool> tpvts = new TestObjectPool<bool>();
        PooledManualResetValueTaskSource<bool> vts = tpvts.GetPooledValueTaskSource();

        short token = vts.Version;
        var tcs = new TaskCompletionSource<bool>();

        // register continuation
        vts.OnCompleted(state => ((TaskCompletionSource<bool>)state!).SetResult(true), tcs, token, ValueTaskSourceOnCompletedFlags.None);

        // still pending
        Assert.That(vts.GetStatus(token), Is.EqualTo(ValueTaskSourceStatus.Pending));

        // signal
        vts.SetResult(true);

        // continuation should run
        bool success = await tcs.Task.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            // status becomes succeeded
            Assert.That(vts.GetStatus(token), Is.EqualTo(ValueTaskSourceStatus.Succeeded));
            Assert.That(success, Is.True);
        }

        // GetResult returns vts to the pool
        bool reset = vts.GetResult(vts.Version);
        short after = vts.Version;

        using (Assert.EnterMultipleScope())
        {
            // reset successful
            Assert.That(reset, Is.True);

            // version has changed
            Assert.That(after, Is.Not.EqualTo(token));
        }

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }

    [Test]
    public void TryResetIncrementsVersion()
    {
        TestObjectPool<bool> tpvts = new TestObjectPool<bool>();
        PooledManualResetValueTaskSource<bool> vts = tpvts.GetPooledValueTaskSource();
        short version = vts.Version;

        // version matches
        Assert.That(version, Is.EqualTo(vts.Version));

        // complete
        vts.SetResult(true);

        // GetResult returns vts to the pool
        bool reset = vts.GetResult(vts.Version);
        short after = vts.Version;

        using (Assert.EnterMultipleScope())
        {
            // reset successful
            Assert.That(reset, Is.True);

            // version has changed
            Assert.That(after, Is.Not.EqualTo(version));
        }

        Assert.That(tpvts.ActiveCount, Is.EqualTo(0), "Instance count should be 0 after reuse.");
    }
}
