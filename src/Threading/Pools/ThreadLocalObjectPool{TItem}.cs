// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// An <see cref="ObjectPool{TItem}"/> implementation optimized for thread-affine
/// rent/return patterns, usable as a drop-in alternative to <see cref="DefaultObjectPool{TItem}"/>.
/// </summary>
/// <remarks>
/// <para>
/// The pool consists of three tiers:
/// </para>
/// <list type="bullet">
/// <item><description>
/// <b>Per-thread single-item cache:</b> the most recently returned item on a thread is stored
/// in a thread-static slot and handed out again by <see cref="Get"/> without any interlocked
/// operation. The slot remembers its owning pool, so items never migrate between pool instances.
/// </description></item>
/// <item><description>
/// <b>Fast item slot:</b> a single pool-wide slot accessed with
/// <see cref="Interlocked.CompareExchange{T}(ref T, T, T)"/> serves cross-thread
/// rent/return ping-pong (an item returned on one thread and rented on another).
/// </description></item>
/// <item><description>
/// <b>Shared queue:</b> remaining items are stored in a <see cref="ConcurrentQueue{TItem}"/>
/// bounded by the maximum retained count, matching <see cref="DefaultObjectPool{TItem}"/> behavior.
/// </description></item>
/// </list>
/// <para>
/// Item lifecycle is controlled by the supplied <see cref="IPooledObjectPolicy{TItem}"/>:
/// <see cref="IPooledObjectPolicy{TItem}.Create"/> is invoked when the pool is empty and
/// <see cref="IPooledObjectPolicy{TItem}.Return"/> is invoked (and must reset the item)
/// before the item is stored for reuse. Items rejected by the policy are dropped.
/// </para>
/// <para>
/// <b>Retention note:</b> the thread-static cache retains up to one item per thread per
/// <typeparamref name="TItem"/> in addition to the maximum retained count, and that slot
/// keeps the owning pool instance reachable for the lifetime of the thread.
/// </para>
/// </remarks>
/// <typeparam name="TItem">The type of the pooled items.</typeparam>
public class ThreadLocalObjectPool<TItem> : ObjectPool<TItem> where TItem : class
{
    [ThreadStatic]
    private static TItem? t_cachedItem;

    [ThreadStatic]
    private static object? t_cachedItemOwner;

    private readonly IPooledObjectPolicy<TItem> _policy;
    private readonly ConcurrentQueue<TItem> _items = new();

    // The maximum number of items stored in the queue; one additional item is held in _fastItem.
    private readonly int _maxCapacity;
    private TItem? _fastItem;
    private int _count;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadLocalObjectPool{TItem}"/> class
    /// retaining up to <c>Environment.ProcessorCount * 2</c> items in the shared tiers.
    /// </summary>
    /// <param name="policy">The policy to use when creating and returning items to the pool.</param>
    public ThreadLocalObjectPool(IPooledObjectPolicy<TItem> policy)
        : this(policy, Environment.ProcessorCount * 2)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadLocalObjectPool{TItem}"/> class.
    /// </summary>
    /// <param name="policy">The policy to use when creating and returning items to the pool.</param>
    /// <param name="maximumRetained">The maximum number of items to retain in the shared tiers.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="policy"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="maximumRetained"/> is negative.</exception>
    public ThreadLocalObjectPool(IPooledObjectPolicy<TItem> policy, int maximumRetained)
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
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public override TItem Get()
    {
        // Fast path: take the item cached by this thread if it belongs to this pool.
        TItem? item = t_cachedItem;
        if (item is not null && ReferenceEquals(t_cachedItemOwner, this))
        {
            t_cachedItem = null;
            t_cachedItemOwner = null;
            return item;
        }

        return GetFromShared();
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public override void Return(TItem obj)
    {
        // The policy resets the item; items rejected by the policy are dropped.
        if (obj is null || !_policy.Return(obj))
        {
            return;
        }

        // Fast path: cache the item on this thread if the slot is free.
        if (t_cachedItem is null)
        {
            t_cachedItem = obj;
            t_cachedItemOwner = this;
            return;
        }

        ReturnToShared(obj);
    }

    /// <summary>
    /// Gets the policy used when creating and returning items to the pool.
    /// </summary>
    protected IPooledObjectPolicy<TItem> Policy => _policy;

    /// <summary>
    /// Rents an item from the shared tiers, bypassing the thread-local cache.
    /// </summary>
    /// <remarks>
    /// Derived classes that maintain their own front-side cache (e.g. to avoid the cost of
    /// thread-static access in shared generic code) rent through this method after a cache miss.
    /// </remarks>
    /// <returns>A pooled item, or a new item created by the policy when the pool is empty.</returns>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    protected TItem GetFromShared()
    {
        TItem? item = _fastItem;
        if (item is null || Interlocked.CompareExchange(ref _fastItem, null, item) != item)
        {
            if (_items.TryDequeue(out item))
            {
                Interlocked.Decrement(ref _count);
                return item;
            }

            return _policy.Create();
        }

        return item;
    }

    /// <summary>
    /// Stores an item in the shared tiers, bypassing the thread-local cache.
    /// </summary>
    /// <remarks>
    /// The item must already have been reset (the policy is not applied by this method).
    /// The item is dropped when the shared tiers are full.
    /// </remarks>
    /// <param name="obj">The reset item to store for reuse.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    protected void ReturnToShared(TItem obj)
    {
        if (_fastItem is not null || Interlocked.CompareExchange(ref _fastItem, obj, null) is not null)
        {
            if (Interlocked.Increment(ref _count) <= _maxCapacity)
            {
                _items.Enqueue(obj);
                return;
            }

            // Shared tiers are full; drop the item to be collected.
            Interlocked.Decrement(ref _count);
        }
    }
}
