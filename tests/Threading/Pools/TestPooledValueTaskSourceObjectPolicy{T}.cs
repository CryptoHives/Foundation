// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using System.Threading;

/// <summary>
/// A test policy for pooling <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// A counter tracks returned object instances.
/// </summary>
internal class TestPooledValueTaskSourceObjectPolicy<T> : PooledValueTaskSourceObjectPolicy<T>
{
    private int _returnedCount = 0;

    /// <summary>
    /// Gets the current number of instances of the class that are in use.
    /// </summary>
    public int ReturnedCount => _returnedCount;

    /// <inheritdoc />
    public override PooledManualResetValueTaskSource<T> Create()
    {
        var obj = base.Create();
        return obj;
    }

    /// <inheritdoc />
    public override bool Return(PooledManualResetValueTaskSource<T> obj)
    {
        Interlocked.Increment(ref _returnedCount);
        return base.Return(obj);
    }
}

