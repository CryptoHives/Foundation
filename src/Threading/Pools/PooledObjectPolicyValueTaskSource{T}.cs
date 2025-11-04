// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Threading.Pools;

using Microsoft.Extensions.ObjectPool;

/// <summary>
/// A policy for pooling <see cref="PooledValueTaskSource{T}"/> instances.
/// </summary>
internal class ValueTaskSourcePooledObjectPolicy<T> : PooledObjectPolicy<PooledValueTaskSource<T>>
{
    /// <inheritdoc />
    public override PooledValueTaskSource<T> Create()
    {
        return new PooledValueTaskSource<T>();
    }

    /// <inheritdoc />
    public override bool Return(PooledValueTaskSource<T> obj)
    {
        return obj.TryReset();
    }
}
