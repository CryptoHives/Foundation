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
        var pool = new TestObjectPool<bool>();

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(1));

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(2));

        queue.Enqueue(pool.GetPooledWaiter(null));
        Assert.That(queue.Count, Is.EqualTo(3));
    }

    [Test]
    public void DequeueReturnsInFifoOrder()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void DequeueClearsNodeLinks()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var node = pool.GetPooledWaiter(null);
        queue.Enqueue(node);
        queue.Dequeue();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(node.Next, Is.Null);
            Assert.That(node.Prev, Is.Null);
        }
    }

    [Test]
    public void RemoveOnlyElement()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void RemoveHead()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void RemoveTail()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void RemoveMiddle()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void RemoveNodeNotInQueueReturnsFalse()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var inQueue = pool.GetPooledWaiter(null);
        var notInQueue = pool.GetPooledWaiter(null);

        queue.Enqueue(inQueue);

        bool removed = queue.Remove(notInQueue);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(removed, Is.False);
            Assert.That(queue.Count, Is.EqualTo(1));
        }
    }

    [Test]
    public void RemoveFromEmptyQueueReturnsFalse()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();
        var node = pool.GetPooledWaiter(null);

        bool removed = queue.Remove(node);
        Assert.That(removed, Is.False);
    }

    [Test]
    public void DoubleRemoveReturnsFalseOnSecondCall()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void DetachAllReturnsChainAndClearsQueue()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void DetachAllClearsPrevLinks()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void DetachFirstReturnsSubset()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var a = pool.GetPooledWaiter(null);
        var b = pool.GetPooledWaiter(null);
        var c = pool.GetPooledWaiter(null);
        var d = pool.GetPooledWaiter(null);

        queue.Enqueue(a);
        queue.Enqueue(b);
        queue.Enqueue(c);
        queue.Enqueue(d);

        var head = queue.DetachFirst(2, out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(count, Is.EqualTo(2));
            Assert.That(head, Is.SameAs(a));
            Assert.That(head!.Next, Is.SameAs(b));
            Assert.That(head.Next!.Next, Is.Null);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(c));
            Assert.That(queue.Dequeue(), Is.SameAs(d));
        }
    }

    [Test]
    public void DetachFirstMoreThanAvailableDetachesAll()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var a = pool.GetPooledWaiter(null);
        var b = pool.GetPooledWaiter(null);

        queue.Enqueue(a);
        queue.Enqueue(b);

        var head = queue.DetachFirst(5, out int count);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(count, Is.EqualTo(2));
            Assert.That(head, Is.SameAs(a));
            Assert.That(head!.Next, Is.SameAs(b));
            Assert.That(head.Next!.Next, Is.Null);
            Assert.That(queue.Count, Is.Zero);
        }
    }

    [Test]
    public void EnqueueAfterRemoveAllWorksCorrectly()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

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
    }

    [Test]
    public void InterleavedEnqueueDequeueRemove()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var a = pool.GetPooledWaiter(null);
        var b = pool.GetPooledWaiter(null);
        var c = pool.GetPooledWaiter(null);
        var d = pool.GetPooledWaiter(null);

        queue.Enqueue(a);
        queue.Enqueue(b);
        queue.Enqueue(c);

        // Remove middle
        queue.Remove(b);
        Assert.That(queue.Count, Is.EqualTo(2));

        // Dequeue head
        var dequeued = queue.Dequeue();
        Assert.That(dequeued, Is.SameAs(a));

        // Enqueue new
        queue.Enqueue(d);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.SameAs(c));
            Assert.That(queue.Dequeue(), Is.SameAs(d));
            Assert.That(queue.Count, Is.Zero);
        }
    }

    [Test]
    public void RemoveAllNodesOneByOneInForwardOrder()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var a = pool.GetPooledWaiter(null);
        var b = pool.GetPooledWaiter(null);
        var c = pool.GetPooledWaiter(null);

        queue.Enqueue(a);
        queue.Enqueue(b);
        queue.Enqueue(c);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Remove(a), Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));

            Assert.That(queue.Remove(b), Is.True);
            Assert.That(queue.Count, Is.EqualTo(1));

            Assert.That(queue.Remove(c), Is.True);
            Assert.That(queue.Count, Is.Zero);
        }
    }

    [Test]
    public void RemoveAllNodesOneByOneInReverseOrder()
    {
        var queue = new WaiterQueue<bool>();
        var pool = new TestObjectPool<bool>();

        var a = pool.GetPooledWaiter(null);
        var b = pool.GetPooledWaiter(null);
        var c = pool.GetPooledWaiter(null);

        queue.Enqueue(a);
        queue.Enqueue(b);
        queue.Enqueue(c);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(queue.Remove(c), Is.True);
            Assert.That(queue.Count, Is.EqualTo(2));

            Assert.That(queue.Remove(b), Is.True);
            Assert.That(queue.Count, Is.EqualTo(1));

            Assert.That(queue.Remove(a), Is.True);
            Assert.That(queue.Count, Is.Zero);
        }
    }
}
