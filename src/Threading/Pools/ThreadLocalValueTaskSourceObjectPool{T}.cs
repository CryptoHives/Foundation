// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Runtime.CompilerServices;

/// <summary>
/// A <see cref="ThreadLocalObjectPool{TItem}"/> for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// It sets the owner pool when an instance is retrieved from the pool, so it gets automatically returned.
/// </summary>
/// <remarks>
/// <para>
/// This pool is a drop-in alternative to <see cref="ValueTaskSourceObjectPool{T}"/> that serves
/// thread-affine rent/return patterns without interlocked operations by caching the most recently
/// returned waiter in a thread-static slot (see <see cref="ThreadLocalObjectPool{TItem}"/> for details).
/// </para>
/// <para>
/// The thread-static cache lives on this class rather than the base: for the value-type
/// <typeparamref name="T"/> arguments used by the primitives the code is specialized per
/// instantiation, so the thread-static access is compiled to the inlined fast pattern instead
/// of the shared-generics runtime helper the base class has to use for its class-typed items.
/// </para>
/// </remarks>
public sealed class ThreadLocalValueTaskSourceObjectPool<T> : ThreadLocalObjectPool<PooledManualResetValueTaskSource<T>>, IGetPooledManualResetValueTaskSource<T>
{
    [ThreadStatic]
    private static PooledManualResetValueTaskSource<T>? t_cachedItem;

    [ThreadStatic]
    private static object? t_cachedItemOwner;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadLocalValueTaskSourceObjectPool{T}"/> class.
    /// </summary>
    /// <param name="policy">The policy to use when creating and returning objects to the pool.</param>
    /// <param name="maximumRetained">The maximum number of objects to retain in the pool.</param>
    public ThreadLocalValueTaskSourceObjectPool(IPooledObjectPolicy<PooledManualResetValueTaskSource<T>> policy, int maximumRetained)
        : base(policy, maximumRetained)
    {
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
        // Fast path: take the waiter cached by this thread if it belongs to this pool.
        PooledManualResetValueTaskSource<T>? item = t_cachedItem;
        if (item is not null && ReferenceEquals(t_cachedItemOwner, this))
        {
            t_cachedItem = null;
            t_cachedItemOwner = null;
        }
        else
        {
            item = GetFromShared();
        }

        item.SetOwnerPool(this, owner);
        return item;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public override void Return(PooledManualResetValueTaskSource<T> obj)
    {
        // The policy resets the waiter; waiters rejected by the policy are dropped.
        if (obj is null || !Policy.Return(obj))
        {
            return;
        }

        // Fast path: cache the waiter on this thread if the slot is free.
        if (t_cachedItem is null)
        {
            t_cachedItem = obj;
            t_cachedItemOwner = this;
            return;
        }

        ReturnToShared(obj);
    }
}
