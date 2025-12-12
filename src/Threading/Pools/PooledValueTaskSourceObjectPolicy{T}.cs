// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;

/// <summary>
/// A policy for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// </summary>
public class PooledValueTaskSourceObjectPolicy<T> : PooledObjectPolicy<PooledManualResetValueTaskSource<T>>
{
    /// <inheritdoc />
    public override PooledManualResetValueTaskSource<T> Create()
    {
        return new PooledManualResetValueTaskSource<T>();
    }

    /// <inheritdoc />
    public override bool Return(PooledManualResetValueTaskSource<T> obj)
    {
        return obj?.TryReset() ?? false;
    }
}
