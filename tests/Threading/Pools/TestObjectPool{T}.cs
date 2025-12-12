// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Threading;

/// <summary>
/// A test pool for <see cref="PooledManualResetValueTaskSource{T}"/> instances.
/// A counter tracks get object instances. Allows to check active objects in use.
/// </summary>

internal class TestObjectPool<T> : ObjectPool<PooledManualResetValueTaskSource<T>>, IGetPooledManualResetValueTaskSource<T> where T : notnull
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
    /// <remarks>
    /// In this implementation, this method is not supported. Use <see cref="GetPooledWaiter(object)"/> instead.
    /// </remarks>
    [Obsolete("Use GetPooledWaiter instead.", true)]
    public override PooledManualResetValueTaskSource<T> Get()
    {
        throw new InvalidOperationException("Unexpected call to get pooled object. Use GetPooledWaiter instead.");
    }

    /// <inheritdoc/>
    public PooledManualResetValueTaskSource<T> GetPooledWaiter(object? owner)
    {
        PooledManualResetValueTaskSource<T> vts = _valueTaskSourcePool.Get();
        vts.SetOwnerPool(_valueTaskSourcePool, owner);
        Interlocked.Increment(ref _getCount);
        return vts;
    }

    /// <inheritdoc/>
    public override void Return(PooledManualResetValueTaskSource<T> obj)
    {
        _valueTaskSourcePool.Return(obj);
    }
}

