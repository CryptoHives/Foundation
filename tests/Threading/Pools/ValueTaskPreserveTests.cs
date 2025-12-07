// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ValueTask.Preserve"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ValueTaskPreserveTests
{
    [Test]
    public async Task PreserveCompletedValueTaskReturnsCompletedTask()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.True);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreservePendingValueTaskReturnsTask()
    {
        var tcs = new TaskCompletionSource<bool>();
        ValueTask vt = new(tcs.Task);
        ValueTask preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(true);
        await preserved.ConfigureAwait(false);
        Assert.That(preserved.IsCompleted, Is.True);
    }

    [Test]
    public async Task PreserveCanBeAwaitedMultipleTimes()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();

        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveGenericCompletedValueTaskReturnsCompletedTask()
    {
        ValueTask<int> vt = new(42);
        ValueTask<int> preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.True);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public async Task PreserveGenericPendingValueTaskReturnsTask()
    {
        var tcs = new TaskCompletionSource<int>();
        ValueTask<int> vt = new(tcs.Task);
        ValueTask<int> preserved = vt.Preserve();

        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(123);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public async Task BuiltInPreserveCanBeAwaitedMultipleTimes()
    {
        ValueTask vt = default;
        ValueTask preserved = vt.Preserve();

        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task BuiltInPreserveGenericCanBeAwaitedMultipleTimes()
    {
        ValueTask<int> vt = new(99);
        ValueTask<int> preserved = vt.Preserve();

        int r1 = await preserved.ConfigureAwait(false);
        int r2 = await preserved.ConfigureAwait(false);
        int r3 = await preserved.ConfigureAwait(false);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(r1, Is.EqualTo(99));
            Assert.That(r2, Is.EqualTo(99));
            Assert.That(r3, Is.EqualTo(99));
        }
    }
}
