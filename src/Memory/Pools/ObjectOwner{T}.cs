// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Memory.Pools;

using Microsoft.Extensions.ObjectPool;
using System;

/// <summary>
/// Owner of object shared from <see cref="ObjectPool{T}"/> who
/// is responsible for disposing the underlying object appropriately.
/// </summary>
public struct ObjectOwner<T> : IDisposable where T : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objectPool"></param>
    public ObjectOwner(ObjectPool<T> objectPool)
    {
        ObjectPool = objectPool;
        Object = objectPool.Get();
    }

    /// <summary>
    /// 
    /// </summary>
    private readonly ObjectPool<T> ObjectPool { get; }

    /// <summary>
    /// 
    /// </summary>
    public T Object { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        ObjectPool.Return(Object);
    }
}
