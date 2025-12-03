// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;

/// <summary>
/// A <see cref="DefaultObjectPool{T}"/> for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// It sets the owner pool when an instance is retrieved from the pool, so it gets automatically returned.
/// </summary>
public class ValueTaskSourceObjectPool<T> : DefaultObjectPool<PooledManualResetValueTaskSource<T>>, IPooledManualResetValueTaskSource<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTaskSourceObjectPool{T}"/> class.
    /// </summary>
    /// <param name="policy">The policy to use when creating and returning objects to the pool.</param>
    /// <param name="maximumRetained">The maximum number of objects to retain in the pool.</param>
    public ValueTaskSourceObjectPool(IPooledObjectPolicy<PooledManualResetValueTaskSource<T>> policy, int maximumRetained)
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
    public PooledManualResetValueTaskSource<T> GetPooledWaiter(object owner)
    {
        var result = base.Get();
        result.SetOwnerPool(this, owner);
        return result;
    }
}
