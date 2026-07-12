// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Tests for <see cref="ThreadLocalObjectPool{TItem}"/> and <see cref="ThreadLocalValueTaskSourceObjectPool{T}"/>.
/// </summary>
/// <remarks>
/// The thread-static cache slot is shared per pooled item type and thread. Each test uses a
/// distinct value task source type parameter so the slots do not interfere between tests.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ThreadLocalObjectPoolTests
{
    [Test]
    public void GetCreatesNewInstanceViaPolicy()
    {
        var pool = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<int>>(
            new PooledValueTaskSourceObjectPolicy<int>(), maximumRetained: 4);

        var instance = pool.Get();

        Assert.That(instance, Is.Not.Null);
    }

    [Test]
    public void ReturnedInstanceIsReusedFromThreadCache()
    {
        var pool = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<long>>(
            new PooledValueTaskSourceObjectPolicy<long>(), maximumRetained: 4);

        var first = pool.Get();
        pool.Return(first);

        var second = pool.Get();

        Assert.That(second, Is.SameAs(first));
    }

    [Test]
    public void ReturnedInstanceIsResetByPolicy()
    {
        var pool = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<short>>(
            new PooledValueTaskSourceObjectPolicy<short>(), maximumRetained: 4);

        var instance = pool.Get();
        short version = instance.Version;

        pool.Return(instance);
        var reused = pool.Get();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(reused, Is.SameAs(instance));
            Assert.That(reused.Version, Is.Not.EqualTo(version), "The policy must reset the instance on return.");
        }
    }

    [Test]
    public void ThreadCacheIsIsolatedBetweenPoolInstances()
    {
        var policy = new PooledValueTaskSourceObjectPolicy<byte>();
        var poolA = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<byte>>(policy, maximumRetained: 4);
        var poolB = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<byte>>(policy, maximumRetained: 4);

        var itemA = poolA.Get();
        poolA.Return(itemA); // lands in the thread-static slot, owned by poolA

        var itemB = poolB.Get();

        Assert.That(itemB, Is.Not.SameAs(itemA), "An item cached by one pool must not be handed out by another.");

        // poolA still finds its cached item
        Assert.That(poolA.Get(), Is.SameAs(itemA));
    }

    [Test]
    public void OverflowInstancesGoToSharedTierUpToMaximumRetained()
    {
        var pool = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<uint>>(
            new PooledValueTaskSourceObjectPolicy<uint>(), maximumRetained: 2);

        var rented = new List<PooledManualResetValueTaskSource<uint>>();
        for (int i = 0; i < 4; i++)
        {
            rented.Add(pool.Get());
        }

        foreach (var item in rented)
        {
            pool.Return(item);
        }

        // 1 item in the thread cache + 2 in the shared tier are retained; the 4th was dropped
        var reused = new HashSet<PooledManualResetValueTaskSource<uint>>();
        for (int i = 0; i < 4; i++)
        {
            reused.Add(pool.Get());
        }

        int retained = 0;
        foreach (var item in rented)
        {
            if (reused.Contains(item))
            {
                retained++;
            }
        }

        Assert.That(retained, Is.EqualTo(3));
    }

    [Test]
    public void ReturnWithNullInstanceIsIgnored()
    {
        var pool = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<float>>(
            new PooledValueTaskSourceObjectPolicy<float>(), maximumRetained: 4);

        Assert.DoesNotThrow(() => pool.Return(null!));
    }

    [Test]
    public void ConstructorValidatesArguments()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.Throws<ArgumentNullException>(() =>
                _ = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<int>>(null!, 4));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _ = new ThreadLocalObjectPool<PooledManualResetValueTaskSource<int>>(
                    new PooledValueTaskSourceObjectPolicy<int>(), -1));
        }
    }

    [Test]
    public void ValueTaskSourcePoolGetThrows()
    {
        var pool = new ThreadLocalValueTaskSourceObjectPool<decimal>(
            new PooledValueTaskSourceObjectPolicy<decimal>(), maximumRetained: 4);

        // dispatching through the base class binds to the non-obsolete base member
        // but executes the throwing override
        Assert.Throws<InvalidOperationException>(() => _ = ((ThreadLocalObjectPool<PooledManualResetValueTaskSource<decimal>>)pool).Get());
    }

    [Test]
    public void ValueTaskSourcePoolAutoReturnsOnGetResult()
    {
        var pool = new ThreadLocalValueTaskSourceObjectPool<double>(
            new PooledValueTaskSourceObjectPolicy<double>(), maximumRetained: 4);
        var owner = new object();

        PooledManualResetValueTaskSource<double> waiter = pool.GetPooledWaiter(owner);
        Assert.That(waiter.Owner, Is.SameAs(owner));

        waiter.SetResult(1.0);
        _ = waiter.GetResult(waiter.Version); // returns the waiter to the pool

        var reused = pool.GetPooledWaiter(owner);

        Assert.That(reused, Is.SameAs(waiter));
    }
}
