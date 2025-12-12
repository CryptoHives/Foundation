// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;

/// <summary>
/// Owner of object shared from <see cref="ObjectPool{T}"/> who
/// is responsible for disposing the underlying object appropriately.
/// </summary>
/// <remarks>
/// Use only in a limited scope such as in a using statement to ensure
/// that the ObjectOwner struct is not copied and the object is returned to the pool, e.g.
/// <code>
///     using var owner = new ObjectOwner&lt;MyType&gt;(myPool);
///     MyType obj = owner.Object;
/// </code>
/// Note: do not cast to IDisposable to avoid a boxing allocation.
/// </remarks>
public readonly struct ObjectOwner<T> : IDisposable, IEquatable<ObjectOwner<T>> where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectOwner{T}"/> struct.
    /// </summary>
    /// <param name="objectPool"></param>
    public ObjectOwner(ObjectPool<T> objectPool)
    {
        ObjectPool = objectPool ?? throw new ArgumentNullException(nameof(objectPool));
        PooledObject = objectPool.Get();
    }

    /// <summary>
    /// The Object Pool the object was obtained from.
    /// </summary>
    private ObjectPool<T> ObjectPool { get; }

    /// <summary>
    /// The pooled Object obtained from the pool.
    /// </summary>
    public T PooledObject { get; }

    /// <inheritdoc/>
    public void Dispose()
    {
        ObjectPool.Return(PooledObject);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is ObjectOwner<T> owner && Equals(owner);
    }

    /// <inheritdoc/>
    public bool Equals(ObjectOwner<T> other)
    {
        return EqualityComparer<ObjectPool<T>>.Default.Equals(ObjectPool, other.ObjectPool) &&
               EqualityComparer<T>.Default.Equals(PooledObject, other.PooledObject);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(ObjectPool, PooledObject);
    }

    /// <summary>
    /// Determines whether two ObjectOwner instances are equal.
    /// </summary>
    public static bool operator ==(ObjectOwner<T> left, ObjectOwner<T> right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two ObjectOwner instances are not equal.
    /// </summary>
    public static bool operator !=(ObjectOwner<T> left, ObjectOwner<T> right)
    {
        return !left.Equals(right);
    }
}
