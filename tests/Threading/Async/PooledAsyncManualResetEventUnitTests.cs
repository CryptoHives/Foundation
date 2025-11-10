// SPDX-FileCopyrightText:2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Tests.Async;

using CryptoHives.Foundation.Threading.Async;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class PooledAsyncManualResetEventUnitTests
{
    [Test]
    public async Task WaitAsyncUnsetIsNotCompletedAsync()
    {
        var mre = new PooledAsyncManualResetEvent();

        Task task = mre.WaitAsync().AsTask();

        await AsyncAssert.NeverCompletesAsync(task).ConfigureAwait(false);
    }

    [Test]
    public void WaitAsyncValueTaskAfterSetCompletesSynchronously()
    {
        var mre = new PooledAsyncManualResetEvent();

        mre.Set();
        ValueTask task = mre.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncTaskAfterSetCompletesSynchronously()
    {
        var mre = new PooledAsyncManualResetEvent();

        mre.Set();
        Task task = mre.WaitAsync().AsTask();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncSetCompletesSynchronously()
    {
        var mre = new PooledAsyncManualResetEvent(true);

        ValueTask task = mre.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public async Task MultipleWaitersAfterSetAllCompleteAsync()
    {
        var mre = new PooledAsyncManualResetEvent();

        Task t1 = mre.WaitAsync().AsTask();
        Task t2 = mre.WaitAsync().AsTask();

        mre.Set();

        // both should complete because ManualResetEvent stays signaled
        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        Assert.That(t1.IsCompleted);
        Assert.That(t2.IsCompleted);
        Assert.That(mre.IsSet);
    }

    [Test]
    public async Task MultipleWaitersValueTaskAndTaskCompleteAfterSetAsync()
    {
        var mre = new PooledAsyncManualResetEvent();

        // create several waiters using ValueTask and Task forms
        Task[] taskWaiters = Enumerable.Range(0,5).Select(_ => mre.WaitAsync().AsTask()).ToArray();

        // ensure none completed yet
        foreach (Task? t in taskWaiters) Assert.That(t.IsCompleted, Is.False);

        // signal the event
        mre.Set();

        // await waiters
        await Task.WhenAll(taskWaiters).ConfigureAwait(false);

        // verify all completed and event remains set
        Assert.That(taskWaiters.All(t => t.IsCompleted));
        Assert.That(mre.IsSet);
    }

    [Test]
    public async Task ResetUnsetsEventAsync()
    {
        var mre = new PooledAsyncManualResetEvent(true);

        Assert.That(mre.IsSet);

        mre.Reset();

        Assert.That(mre.IsSet, Is.False);

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);
    }

    [Test]
    public async Task ResetWhenAlreadyResetDoesNothingAsync()
    {
        var mre = new PooledAsyncManualResetEvent(false);

        // Should not throw and should remain unset
        mre.Reset();

        Task wait = mre.WaitAsync().AsTask();
        await AsyncAssert.NeverCompletesAsync(wait).ConfigureAwait(false);
    }

    private static class AsyncAssert
    {
        public static async Task NeverCompletesAsync(Task task, int timeoutMs =500)
        {
            Task completed = await Task.WhenAny(task, Task.Delay(timeoutMs)).ConfigureAwait(false);
            if (completed == task)
            {
                Assert.Fail("Expected task to never complete.");
            }
        }
    }
}
