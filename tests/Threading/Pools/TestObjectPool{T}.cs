// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System.Threading;

/// <summary>
/// A test pool for <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// A counter tracks get object instances. Allows to check active objects in use.
/// </summary>

internal class TestObjectPool<T> : ObjectPool<PooledManualResetValueTaskSource<T>> where T : notnull
{
    private readonly ObjectPool<PooledManualResetValueTaskSource<T>> _valueTaskSourcePool;
    private readonly TestPooledValueTaskSourceObjectPolicy<T> _valueTaskSourcePoolPolicy;
    private int _getCount = 0;

    public TestObjectPool()
    {
        _valueTaskSourcePoolPolicy = new TestPooledValueTaskSourceObjectPolicy<T>();
        _valueTaskSourcePool = new DefaultObjectPool<PooledManualResetValueTaskSource<T>>(_valueTaskSourcePoolPolicy);
    }

    /// <summary>
    /// Gets the active number of objects of the class that are in use.
    /// </summary>
    public int ActiveCount => _getCount - _valueTaskSourcePoolPolicy.ReturnedCount;

    /// <inheritdoc/>
    public override PooledManualResetValueTaskSource<T> Get()
    {
        PooledManualResetValueTaskSource<T> vts = _valueTaskSourcePool.Get();
        vts.SetOwnerPool(_valueTaskSourcePool);
        Interlocked.Increment(ref _getCount);
        return vts;
    }

    /// <inheritdoc/>
    public override void Return(PooledManualResetValueTaskSource<T> obj)
    {
        _valueTaskSourcePool.Return(obj);
    }
}

