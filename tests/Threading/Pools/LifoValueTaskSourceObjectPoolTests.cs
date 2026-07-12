// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Tests for <see cref="LifoValueTaskSourceObjectPool{T}"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class LifoValueTaskSourceObjectPoolTests
{
    [Test]
    public void GetPooledWaiterReturnsNewInstanceWithOwner()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 4);
        var owner = new object();

        var instance = pool.GetPooledWaiter(owner);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance.Owner, Is.SameAs(owner));
        }
    }

    [Test]
    public void GetThrows()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 4);

        // dispatching through the base class binds to the non-obsolete base member
        // but executes the throwing override
        Assert.Throws<InvalidOperationException>(() => _ = ((ObjectPool<PooledManualResetValueTaskSource<bool>>)pool).Get());
    }

    [Test]
    public void ReturnedInstanceIsReused()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 4);
        var owner = new object();

        var first = pool.GetPooledWaiter(owner);
        pool.Return(first);

        var second = pool.GetPooledWaiter(owner);

        Assert.That(second, Is.SameAs(first));
    }

    [Test]
    public void ReturnedInstanceIsReset()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 4);
        var owner = new object();

        var waiter = pool.GetPooledWaiter(owner);
        short version = waiter.Version;
        waiter.SetResult(true);
        _ = waiter.GetResult(waiter.Version); // returns the waiter to the pool

        var reused = pool.GetPooledWaiter(owner);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(reused, Is.SameAs(waiter));
            Assert.That(reused.Version, Is.Not.EqualTo(version));
        }
    }

    [Test]
    public void FreeListHandsOutMostRecentlyReturnedFirst()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 8);
        var owner = new object();

        var a = pool.GetPooledWaiter(owner);
        var b = pool.GetPooledWaiter(owner);
        var c = pool.GetPooledWaiter(owner);

        // a lands in the fast item slot, b and c go onto the LIFO free list
        pool.Return(a);
        pool.Return(b);
        pool.Return(c);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(pool.GetPooledWaiter(owner), Is.SameAs(a), "fast item is served first");
            Assert.That(pool.GetPooledWaiter(owner), Is.SameAs(c), "stack pops the most recently returned item");
            Assert.That(pool.GetPooledWaiter(owner), Is.SameAs(b));
        }
    }

    [Test]
    public void OverflowInstancesAreDroppedBeyondMaximumRetained()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 2);
        var owner = new object();

        var rented = new List<PooledManualResetValueTaskSource<bool>>();
        for (int i = 0; i < 4; i++)
        {
            rented.Add(pool.GetPooledWaiter(owner));
        }

        foreach (var waiter in rented)
        {
            pool.Return(waiter);
        }

        // 1 item in the fast slot + 1 on the free list are retained; the rest were dropped
        var reused = new HashSet<PooledManualResetValueTaskSource<bool>>();
        for (int i = 0; i < 4; i++)
        {
            reused.Add(pool.GetPooledWaiter(owner));
        }

        int retained = 0;
        foreach (var waiter in rented)
        {
            if (reused.Contains(waiter))
            {
                retained++;
            }
        }

        Assert.That(retained, Is.EqualTo(2));
    }

    [Test]
    public void ReturnWithNullInstanceIsIgnored()
    {
        var pool = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), maximumRetained: 4);

        Assert.DoesNotThrow(() => pool.Return(null!));
    }

    [Test]
    public void ConstructorValidatesArguments()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.Throws<ArgumentNullException>(() =>
                _ = new LifoValueTaskSourceObjectPool<bool>(null!, 4));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _ = new LifoValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), -1));
        }
    }
}
