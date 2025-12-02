// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;

/// <summary>
/// A <see cref="DefaultObjectPool{T}"/> for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// It sets the owner pool when an instance is retrieved from the pool, so it gets automatically returned.
/// </summary>
public class ValueTaskSourceObjectPool<T> : DefaultObjectPool<PooledManualResetValueTaskSource<T>>
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
    /// In addition to the base behavior, this method sets the owner pool of the retrieved instance.
    /// </remarks>
    public override PooledManualResetValueTaskSource<T> Get()
    {
        var result = base.Get();
        result.SetOwnerPool(this);
        return result;
    }
}
