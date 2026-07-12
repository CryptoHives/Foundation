// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// A LIFO <see cref="ObjectPool{TItem}"/> for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// It sets the owner pool when an instance is retrieved from the pool, so it gets automatically returned.
/// </summary>
/// <remarks>
/// <para>
/// The pool consists of two tiers:
/// </para>
/// <list type="bullet">
/// <item><description>
/// <b>Fast item slot:</b> a single slot accessed with
/// <see cref="Interlocked.CompareExchange{T}(ref T, T, T)"/> serves cross-thread
/// rent/return ping-pong (an item returned on one thread and rented on another)
/// without touching the stack lock.
/// </description></item>
/// <item><description>
/// <b>Intrusive LIFO stack:</b> overflow items are linked through their intrusive
/// list link into a free list guarded by a short spin lock. LIFO order hands out the
/// most recently returned — cache-warm — waiter first and needs no per-node allocations,
/// which makes deep rent/return bursts cheaper than a FIFO queue.
/// </description></item>
/// </list>
/// <para>
/// Item lifecycle is controlled by the supplied <see cref="IPooledObjectPolicy{TItem}"/>:
/// <see cref="IPooledObjectPolicy{TItem}.Create"/> is invoked when the pool is empty and
/// <see cref="IPooledObjectPolicy{TItem}.Return"/> is invoked (and must reset the item)
/// before the item is stored for reuse. Items rejected by the policy are dropped.
/// </para>
/// </remarks>
public class LifoValueTaskSourceObjectPool<T> : ObjectPool<PooledManualResetValueTaskSource<T>>, IGetPooledManualResetValueTaskSource<T>
{
    private readonly IPooledObjectPolicy<PooledManualResetValueTaskSource<T>> _policy;

    // The maximum number of items stored in the stack; one additional item is held in _fastItem.
    private readonly int _maxCapacity;

    private PooledManualResetValueTaskSource<T>? _fastItem;
    private Internal.SpinLock _stackLock;
    private volatile PooledManualResetValueTaskSource<T>? _stackHead;
    private int _stackCount;

    /// <summary>
    /// Initializes a new instance of the <see cref="LifoValueTaskSourceObjectPool{T}"/> class.
    /// </summary>
    /// <param name="policy">The policy to use when creating and returning objects to the pool.</param>
    /// <param name="maximumRetained">The maximum number of objects to retain in the pool.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="policy"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="maximumRetained"/> is negative.</exception>
    public LifoValueTaskSourceObjectPool(IPooledObjectPolicy<PooledManualResetValueTaskSource<T>> policy, int maximumRetained)
    {
        if (policy is null)
        {
            throw new ArgumentNullException(nameof(policy));
        }

        if (maximumRetained < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maximumRetained), maximumRetained, "Maximum retained count must be non-negative.");
        }

        _policy = policy;

        // -1 to account for the fast item slot, mirroring DefaultObjectPool.
        _maxCapacity = maximumRetained - 1;
        _stackLock = new();
    }

    /// <inheritdoc/>
    /// <remarks>
    /// In this implementation, this method is not supported. Use <see cref="GetPooledWaiter(object)"/> instead.
    /// </remarks>
    [Obsolete("Use GetPooledWaiter instead.", true)]
    public override PooledManualResetValueTaskSource<T> Get()
    {
        throw new InvalidOperationException("Unexpected call to get pooled object. Use GetPooledWaiter instead.");
    }

    /// <inheritdoc/>
    /// <remarks>
    /// In addition to the base Get() behavior, this method sets the owner pool and the owner of the retrieved instance.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public PooledManualResetValueTaskSource<T> GetPooledWaiter(object owner)
    {
        PooledManualResetValueTaskSource<T>? item = _fastItem;
        if (item is null || Interlocked.CompareExchange(ref _fastItem, null, item) != item)
        {
            item = PopStack() ?? _policy.Create();
        }

        item.SetOwnerPool(this, owner);
        return item;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public override void Return(PooledManualResetValueTaskSource<T> obj)
    {
        // The policy resets the waiter; waiters rejected by the policy are dropped.
        if (obj is null || !_policy.Return(obj))
        {
            return;
        }

        if (_fastItem is not null || Interlocked.CompareExchange(ref _fastItem, obj, null) is not null)
        {
            PushStack(obj);
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private PooledManualResetValueTaskSource<T>? PopStack()
    {
        // Cheap pre-check avoids taking the lock when the free list is empty.
        if (_stackHead is null)
        {
            return null;
        }

        PooledManualResetValueTaskSource<T>? head;

        _stackLock.Enter();
        try
        {
            // The volatile head must be re-read under the lock; a competing
            // pop may have emptied the free list since the pre-check.
            head = _stackHead;
#pragma warning disable CA1508 // Avoid dead conditional code - false positive on volatile re-read
            if (head is null)
            {
                return null;
            }
#pragma warning restore CA1508

            _stackHead = (PooledManualResetValueTaskSource<T>?)head.Next;
            _stackCount--;
        }
        finally
        {
            _stackLock.Exit();
        }

        head.Next = null;
        return head;
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void PushStack(PooledManualResetValueTaskSource<T> obj)
    {
        _stackLock.Enter();
        try
        {
            if (_stackCount >= _maxCapacity)
            {
                // Free list is full; drop the item to be collected.
                return;
            }

            obj.Next = _stackHead;
            _stackHead = obj;
            _stackCount++;
        }
        finally
        {
            _stackLock.Exit();
        }
    }
}
