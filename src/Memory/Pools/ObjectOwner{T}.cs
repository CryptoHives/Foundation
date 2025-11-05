// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Pools;

using Microsoft.Extensions.ObjectPool;
using System;

/// <summary>
/// Owner of object shared from <see cref="ObjectPool{T}"/> who
/// is responsible for disposing the underlying object appropriately.
/// </summary>
/// <remarks>
/// Use only in a limited scope such as a using statement to ensure
/// that the the ObjectOwner struct is not copied and the Object is returned to the pool, e.g.
/// <code>
///     using var owner = new ObjectOwner&lt;MyType&gt;(myPool);
///     MyType obj = owner.Object;
/// </code>
/// note: do not cast to IDisposable to avoid a boxing allocation
/// </remarks>
public readonly struct ObjectOwner<T> : IDisposable where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectOwner{T}"/> struct.
    /// </summary>
    /// <param name="objectPool"></param>
    public ObjectOwner(ObjectPool<T> objectPool)
    {
        ObjectPool = objectPool;
        Object = objectPool.Get();
    }

    /// <summary>
    /// The Object Pool the object was obtained from.
    /// </summary>
    private ObjectPool<T> ObjectPool { get; }

    /// <summary>
    /// The Object obtained from the pool.
    /// </summary>
    public T Object { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        ObjectPool.Return(Object);
    }
}
