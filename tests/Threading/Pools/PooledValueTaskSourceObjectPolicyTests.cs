// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PooledValueTaskSourceObjectPolicyTests
{
    [Test]
    public void CreateReturnsNewInstance()
    {
        var policy = new PooledValueTaskSourceObjectPolicy<bool>();

        var instance = policy.Create();

        Assert.That(instance, Is.Not.Null);
    }

    [Test]
    public void ReturnWithNullInstanceReturnsFalse()
    {
        var policy = new PooledValueTaskSourceObjectPolicy<bool>();

        bool result = policy.Return(null!);

        Assert.That(result, Is.False);
    }

    [Test]
    public void ReturnWithResettableInstanceReturnsTrue()
    {
        var policy = new PooledValueTaskSourceObjectPolicy<bool>();
        var instance = policy.Create();

        bool result = policy.Return(instance);

        Assert.That(result, Is.True);
    }
}
