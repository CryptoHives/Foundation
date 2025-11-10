// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;

/// <summary>
/// A policy for pooling <see cref="ManualResetValueTaskSource{T}"/> instances.
/// </summary>
public class PooledValueTaskSourceObjectPolicy<T> : PooledObjectPolicy<ManualResetValueTaskSource<T>>
{
    /// <inheritdoc />
    public override ManualResetValueTaskSource<T> Create()
    {
        return new ManualResetValueTaskSource<T>();
    }

    /// <inheritdoc />
    public override bool Return(ManualResetValueTaskSource<T> obj)
    {
        return obj.TryReset();
    }
}
