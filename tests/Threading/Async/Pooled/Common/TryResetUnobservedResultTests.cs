// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA2012 // ValueTask instances should only be consumed once — deliberately held across the reset

namespace Threading.Tests.Async.Pooled.Common;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// A waiter that has been handed its result but has not observed it yet still owns the
/// instance-local value task source. Recycling the primitive at that moment resets the source
/// and bumps its version, so the pending await fails with an <see cref="InvalidOperationException"/>
/// instead of seeing its result. Every <see cref="Microsoft.Extensions.ObjectPool.IResettable"/>
/// primitive must decline the reset in that window.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TryResetUnobservedResultTests
{
    [Test, CancelAfter(3000)]
    public async Task AsyncAutoResetEventDeclinesWhileAResultIsUnobserved()
    {
        var e = new AsyncAutoResetEvent();

        ValueTask waiting = e.WaitAsync();
        e.Set();                                  // dequeues and completes the waiter

        Assert.That(e.TryReset(), Is.False);

        await waiting.ConfigureAwait(false);
        Assert.That(e.TryReset(), Is.True);
    }

    [Test, CancelAfter(3000)]
    public async Task AsyncManualResetEventDeclinesWhileAResultIsUnobserved()
    {
        var e = new AsyncManualResetEvent();

        ValueTask waiting = e.WaitAsync();
        e.Set();                                  // detaches and completes the waiter

        Assert.That(e.TryReset(), Is.False);

        await waiting.ConfigureAwait(false);
        Assert.That(e.TryReset(), Is.True);
    }

    [Test, CancelAfter(3000)]
    public async Task AsyncLockDeclinesWhileACancelledResultIsUnobserved()
    {
        var asyncLock = new AsyncLock();
        using var cts = new CancellationTokenSource();

        AsyncLock.Releaser releaser = await asyncLock.LockAsync().ConfigureAwait(false);

        ValueTask<AsyncLock.Releaser> queued = asyncLock.LockAsync(cts.Token);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);   // removes the waiter, faults it

        await releaser.DisposeAsync().ConfigureAwait(false);

        Assert.That(asyncLock.TryReset(), Is.False);

        // Awaited directly rather than via Assert.ThrowsAsync(async () => await queued...): that
        // would capture the ValueTask in a lambda/closure (CHT010) and, more importantly, any
        // conversion to a Task (e.g. AsTask()) done before this point would attach a continuation
        // immediately - observing the result as soon as cancellation completes, before the
        // TryReset() check above ever runs, and defeating the "still unobserved" setup this test
        // exists to exercise.
        try
        {
            _ = await queued.ConfigureAwait(false);
            Assert.Fail("Expected the queued acquisition to observe its cancellation.");
        }
        catch (OperationCanceledException)
        {
            // Expected: the queued waiter was cancelled while the lock was held.
        }

        Assert.That(asyncLock.TryReset(), Is.True);
    }

    [Test, CancelAfter(3000)]
    public async Task AsyncReaderWriterLockDeclinesWhileACancelledResultIsUnobserved()
    {
        var rwLock = new AsyncReaderWriterLock();
        using var cts = new CancellationTokenSource();

        AsyncReaderWriterLock.Releaser writer = await rwLock.WriterLockAsync().ConfigureAwait(false);

        ValueTask<AsyncReaderWriterLock.Releaser> queued = rwLock.WriterLockAsync(cts.Token);
        await AsyncAssert.CancelAsync(cts).ConfigureAwait(false);

        await writer.DisposeAsync().ConfigureAwait(false);

        Assert.That(rwLock.TryReset(), Is.False);

        // See AsyncLockDeclinesWhileACancelledResultIsUnobserved above for why this is a direct
        // try/catch rather than Assert.ThrowsAsync(async () => await queued...) or an early AsTask().
        try
        {
            _ = await queued.ConfigureAwait(false);
            Assert.Fail("Expected the queued acquisition to observe its cancellation.");
        }
        catch (OperationCanceledException)
        {
            // Expected: the queued writer was cancelled while the lock was held.
        }

        Assert.That(rwLock.TryReset(), Is.True);
    }
}
