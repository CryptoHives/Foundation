// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class WaiterQueueTests
{
    [Test]
    public void EmptyQueueHasZeroCount()
    {
        var queue = new WaiterQueue<bool>();
        Assert.That(queue.Count, Is.Zero);
    }

    [Test]
    public void EnqueueIncreasesCount()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(1));

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(2));

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(3));

        pool.Return((queue.Dequeue() as PooledManualResetValueTaskSource<bool>)!);
        pool.Return((queue.Dequeue() as PooledManualResetValueTaskSource<bool>)!);
        pool.Return((queue.Dequeue() as PooledManualResetValueTaskSource<bool>)!);
    }

    [Test]
    public void DequeueReturnsInFifoOrder()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Dequeue(), Is.SameAs(first));
            Assert.That(queue.Dequeue(), Is.SameAs(second));
            Assert.That(queue.Dequeue(), Is.SameAs(third));
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }

    [Test]
    public void DequeueClearsNodeLinks()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var node = pool.GetPooledWaiter(null);
        queue.Enqueue(node);
        var queuedWaiter = queue.Dequeue() as PooledManualResetValueTaskSource<bool>;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queuedWaiter, Is.Not.Null);
            Assert.That(node.Next, Is.Null);
            Assert.That(node.Prev, Is.Null);
        }

        pool.Return(queuedWaiter);
    }

    [Test]
    public void RemoveOnlyElement()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var node = pool.GetPooledWaiter(null);
        queue.Enqueue(node);

        bool removed = queue.Remove(node);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.True);
            Assert.That(queue.Count, Is.Zero);
            Assert.That(node.Next, Is.Null);
            Assert.That(node.Prev, Is.Null);
        }

        pool.Return(node);
    }

    [Test]
    public void RemoveHead()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        bool removed = queue.Remove(first);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(second));
            Assert.That(queue.Dequeue(), Is.SameAs(third));
        }

        pool.Return(first);

        queue.Remove(second);
        pool.Return(second);

        queue.Remove(third);
        pool.Return(third);
    }

    [Test]
    public void RemoveTail()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        bool removed = queue.Remove(third);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(first));
            Assert.That(queue.Dequeue(), Is.SameAs(second));
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }

    [Test]
    public void RemoveMiddle()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        bool removed = queue.Remove(second);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(first));
            Assert.That(queue.Dequeue(), Is.SameAs(third));
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }

    [Test]
    public void RemoveNodeNotInQueueReturnsFalse()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var inQueue = pool.GetPooledWaiter(null);
        var notInQueue = pool.GetPooledWaiter(null);

        queue.Enqueue(inQueue);

        bool removed = queue.Remove(notInQueue);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.False);
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        pool.Return(inQueue);
        pool.Return(notInQueue);
    }

    [Test]
    public void RemoveFromEmptyQueueReturnsFalse()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();
        var node = pool.GetPooledWaiter(null);

        bool removed = queue.Remove(node);
        Assert.That(removed, Is.False);

        pool.Return(node);
    }

    [Test]
    public void DoubleRemoveReturnsFalseOnSecondCall()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var node = pool.GetPooledWaiter(null);
        queue.Enqueue(node);

        bool first = queue.Remove(node);
        bool second = queue.Remove(node);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first, Is.True);
            Assert.That(second, Is.False);
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(node);
    }

    [Test]
    public void DetachAllReturnsChainAndClearsQueue()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        var head = queue.DetachAll(out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Count, Is.Zero);
            Assert.That(count, Is.EqualTo(3));
            Assert.That(head, Is.SameAs(first));
            Assert.That(head!.Next, Is.SameAs(second));
            Assert.That(head.Next!.Next, Is.SameAs(third));
            Assert.That(head.Next.Next!.Next, Is.Null);
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }

    [Test]
    public void DetachAllClearsPrevLinks()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);

        queue.DetachAll(out _);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(first.Prev, Is.Null);
            Assert.That(second.Prev, Is.Null);
        }

        pool.Return(first);
        pool.Return(second);
    }

    [Test]
    public void DetachAllFromEmptyQueueReturnsNull()
    {
        var queue = new WaiterQueue<bool>();

        var head = queue.DetachAll(out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(head, Is.Null);
            Assert.That(count, Is.Zero);
        }
    }

    [Test]
    public void EnqueueAfterDetachAllWorksCorrectly()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        queue.Enqueue(first);

        queue.DetachAll(out _);
        first.Next = null;

        var second = pool.GetPooledWaiter(null);
        queue.Enqueue(second);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Count, Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.SameAs(second));
        }

        pool.Return(first);
        pool.Return(second);
    }

    [Test]
    public void DetachFirstReturnsSubset()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);
        var fourth = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);
        queue.Enqueue(fourth);

        var head = queue.DetachUpTo(2, out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(count, Is.EqualTo(2));
            Assert.That(head, Is.SameAs(first));
            Assert.That(head!.Next, Is.SameAs(second));
            Assert.That(head.Next!.Next, Is.Null);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(third));
            Assert.That(queue.Dequeue(), Is.SameAs(fourth));
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
        pool.Return(fourth);
    }

    [Test]
    public void DetachFirstMoreThanAvailableDetachesAll()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);

        var head = queue.DetachUpTo(5, out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(count, Is.EqualTo(2));
            Assert.That(head, Is.SameAs(first));
            Assert.That(head!.Next, Is.SameAs(second));
            Assert.That(head.Next!.Next, Is.Null);
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(first);
        pool.Return(second);
    }

    [Test]
    public void EnqueueAfterRemoveAllWorksCorrectly()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        queue.Enqueue(first);
        queue.Remove(first);

        var second = pool.GetPooledWaiter(null);
        queue.Enqueue(second);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Count, Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.SameAs(second));
        }

        pool.Return(first);
        pool.Return(second);
    }

    [Test]
    public void InterleavedEnqueueDequeueRemove()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);
        var fourth = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        // Remove middle
        queue.Remove(second);
        Assert.That(queue.Count, Is.EqualTo(2));

        // Dequeue head
        var dequeued = queue.Dequeue();
        Assert.That(dequeued, Is.SameAs(first));

        // Enqueue new
        queue.Enqueue(fourth);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(third));
            Assert.That(queue.Dequeue(), Is.SameAs(fourth));
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
        pool.Return(fourth);
    }

    [Test]
    public void RemoveAllNodesOneByOneInForwardOrder()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Remove(first), Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));

            Assert.That(queue.Remove(second), Is.True);
            Assert.That(queue.Count, Is.EqualTo(1));

            Assert.That(queue.Remove(third), Is.True);
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }

    [Test]
    public void RemoveAllNodesOneByOneInReverseOrder()
    {
        var queue = new WaiterQueue<bool>();
        using var pool = new TestObjectPool<bool>();

        var first = pool.GetPooledWaiter(null);
        var second = pool.GetPooledWaiter(null);
        var third = pool.GetPooledWaiter(null);

        queue.Enqueue(first);
        queue.Enqueue(second);
        queue.Enqueue(third);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Remove(third), Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));

            Assert.That(queue.Remove(second), Is.True);
            Assert.That(queue.Count, Is.EqualTo(1));

            Assert.That(queue.Remove(first), Is.True);
            Assert.That(queue.Count, Is.Zero);
        }

        pool.Return(first);
        pool.Return(second);
        pool.Return(third);
    }
}
