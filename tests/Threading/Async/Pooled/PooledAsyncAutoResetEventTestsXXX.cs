// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

[TestFixture]
public class PooledAsyncAutoResetEventUnitTestsX
{
    [Test]
    public async Task WaitAsyncUnsetIsNotCompletedAsync()
    {
        var are = new AsyncAutoResetEvent();

        Task task = are.WaitAsync().AsTask();

        await AsyncAssert.NeverCompletesAsync(task).ConfigureAwait(false);
    }

    [Test]
    public void WaitAsyncValueTaskAfterSetCompletesSynchronously()
    {
        var are = new AsyncAutoResetEvent();

        are.Set();
        ValueTask task = are.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncTaskAfterSetCompletesSynchronously()
    {
        var are = new AsyncAutoResetEvent();

        are.Set();
        Task task = are.WaitAsync().AsTask();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public void WaitAsyncSetCompletesSynchronously()
    {
        var are = new AsyncAutoResetEvent(true);

        ValueTask task = are.WaitAsync();

        Assert.That(task.IsCompleted);
    }

    [Test]
    public async Task MultipleWaitAsyncAfterSetOnlyOneIsCompletedAsync()
    {
        var are = new AsyncAutoResetEvent();

        are.Set();
        Task task1 = are.WaitAsync().AsTask();
        Task task2 = are.WaitAsync().AsTask();

        Assert.That(task1.IsCompleted);
        await AsyncAssert.NeverCompletesAsync(task2).ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleWaitAsyncSetOnlyOneIsCompletedAsync()
    {
        var are = new AsyncAutoResetEvent(true);

        Task task1 = are.WaitAsync().AsTask();
        Task task2 = are.WaitAsync().AsTask();

        Assert.That(task1.IsCompleted);
        await AsyncAssert.NeverCompletesAsync(task2).ConfigureAwait(false);
    }

    [Test]
    public async Task MultipleWaitAsyncAfterMultipleSetOnlyOneIsCompletedAsync()
    {
        var are = new AsyncAutoResetEvent();

        are.Set();
        are.Set();
        Task task1 = are.WaitAsync().AsTask();
        Task task2 = are.WaitAsync().AsTask();

        Assert.That(task1.IsCompleted);
        await AsyncAssert.NeverCompletesAsync(task2).ConfigureAwait(false);
    }

#if TODO
    [Test]
    public void WaitAsyncPreCancelledSetSynchronouslyCompletesWait()
    {
        var are = new PooledAsyncAutoResetEvent(true);
        var token = new CancellationToken(true);

        ValueTask task = are.WaitAsync(token);

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.False);
        Assert.That(task.IsFaulted, Is.False);
    }

    [Test]
    public async Task WaitAsyncCancelledDoesNotAutoReset()
    {
        var are = new PooledAsyncAutoResetEvent();
        var cts = new CancellationTokenSource();

        cts.Cancel();
        ValueTask task1 = are.WaitAsync(cts.Token);
        task1.WaitWithoutException();
        are.Set();
        ValueTask task2 = are.WaitAsync();

        await task2.ConfigureAwait(false);
    }

    [Test]
    public void WaitAsyncPreCancelledUnsetSynchronouslyCancels()
    {
        var are = new PooledAsyncAutoResetEvent(false);
        var token = new CancellationToken(true);

        ValueTask task = are.WaitAsync(token);

        Assert.That(task.IsCompleted, Is.True);
        Assert.That(task.IsCanceled, Is.True);
        Assert.That(task.IsFaulted, Is.False);
    }

    [Test]
    public void WaitAsyncFromCustomSynchronizationContextPreCancelledUnsetSynchronouslyCancels()
    {
        AsyncContext.Run(() =>
        {
            var are = new PooledAsyncAutoResetEvent(false);
            var token = new CancellationToken(true);

            var task = are.WaitAsync(token);

            Assert.IsTrue(task.IsCompleted);
            Assert.IsTrue(task.IsCanceled);
            Assert.IsFalse(task.IsFaulted);
        });
    }

    [Test]
    public async Task WaitAsyncCancelledThrowsException()
    {
        var are = new PooledAsyncAutoResetEvent();
        var cts = new CancellationTokenSource();
        cts.Cancel();
        ValueTask task = are.WaitAsync(cts.Token);
        await Assert.ThrowsAsync<OperationCanceledException>(task);
    }

    [Test]
    public void IdIsNotZero()
    {
        var are = new PooledAsyncAutoResetEvent();
        Assert.That(0, are.Id, Is.NotEqual);
    }
#endif

    private static class AsyncAssert
    {
        public static async Task NeverCompletesAsync(Task task, int timeoutMs = 1000)
        {
            Task completed = await Task.WhenAny(task, Task.Delay(timeoutMs)).ConfigureAwait(false);
            if (completed == task)
                Assert.Fail("Expected task to never complete.");
        }
    }
}
