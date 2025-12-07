// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests;

using CryptoHives.Foundation.Threading;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ValueTaskExtensions"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ValueTaskExtensionsTests
{
#if NETFRAMEWORK || NETSTANDARD2_0
    [Test]
    public async Task PreserveCompletedValueTaskReturnsCompletedTask()
    {
        // Arrange
        ValueTask vt = default;

        // Act
        Task preserved = ValueTaskExtensions.Preserve(vt);

        // Assert
        Assert.That(preserved.IsCompleted, Is.True);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreservePendingValueTaskReturnsTask()
    {
        // Arrange
        var tcs = new TaskCompletionSource<bool>();
        ValueTask vt = new(tcs.Task);

        // Act
        Task preserved = ValueTaskExtensions.Preserve(vt);

        // Assert
        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(true);
        await preserved.ConfigureAwait(false);
        Assert.That(preserved.IsCompleted, Is.True);
    }

    [Test]
    public async Task PreserveCanBeAwaitedMultipleTimes()
    {
        // Arrange
        ValueTask vt = default;

        // Act
        Task preserved = ValueTaskExtensions.Preserve(vt);

        // Assert - can await multiple times without exception
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task PreserveGenericCompletedValueTaskReturnsCompletedTask()
    {
        // Arrange
        ValueTask<int> vt = new(42);

        // Act
        Task<int> preserved = ValueTaskExtensions.Preserve(vt);

        // Assert
        Assert.That(preserved.IsCompleted, Is.True);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public async Task PreserveGenericPendingValueTaskReturnsTask()
    {
        // Arrange
        var tcs = new TaskCompletionSource<int>();
        ValueTask<int> vt = new(tcs.Task);

        // Act
        Task<int> preserved = ValueTaskExtensions.Preserve(vt);

        // Assert
        Assert.That(preserved.IsCompleted, Is.False);

        tcs.SetResult(123);
        int result = await preserved.ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public async Task PreserveGenericCanBeAwaitedMultipleTimes()
    {
        // Arrange
        ValueTask<int> vt = new(99);

        // Act
        Task<int> preserved = ValueTaskExtensions.Preserve(vt);

        // Assert - can await multiple times without exception
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
#else
    // On .NET Core 2.1+, .NET 5+, .NET Standard 2.1+ use built-in Preserve()
    [Test]
    public async Task BuiltInPreserveCanBeAwaitedMultipleTimes()
    {
        // Arrange
        ValueTask vt = default;

        // Act - use built-in Preserve() which returns ValueTask
        ValueTask preserved = vt.Preserve();

        // Assert - can await multiple times without exception
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
        await preserved.ConfigureAwait(false);
    }

    [Test]
    public async Task BuiltInPreserveGenericCanBeAwaitedMultipleTimes()
    {
        // Arrange
        ValueTask<int> vt = new(99);

        // Act - use built-in Preserve() which returns ValueTask<T>
        ValueTask<int> preserved = vt.Preserve();

        // Assert - can await multiple times without exception
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
#endif

    [Test]
    public async Task AwaitWithoutContextValueTaskReturnsConfiguredAwaitable()
    {
        // Arrange
        ValueTask vt = default;

        // Act & Assert - should not throw
        await ValueTaskExtensions.AwaitWithoutContext(vt);
    }

    [Test]
    public async Task AwaitWithoutContextGenericValueTaskReturnsConfiguredAwaitable()
    {
        // Arrange
        ValueTask<int> vt = new(42);

        // Act
        int result = await ValueTaskExtensions.AwaitWithoutContext(vt);

        // Assert
        Assert.That(result, Is.EqualTo(42));
    }
}
