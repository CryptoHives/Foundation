// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

/// <summary>
/// Provides ObjectPools for efficient memory usage.
/// </summary>
[ExcludeFromCodeCoverage]
public static class ObjectPools
{
    /// <summary>
    /// Gets a pooled <see cref="StringBuilder"/> instance.
    /// </summary>
    /// <remarks>
    /// Ensure that the following usage pattern is applied to
    /// appropriately dispose the object and return it to the pool.
    /// <code>
    ///     using var owner = ObjectPools.GetStringBuilder();
    ///     StringBuilder sb = owner.Object;
    ///     ...
    /// </code>
    /// </remarks>
    public static ObjectOwner<StringBuilder> GetStringBuilder()
    {
        return new ObjectOwner<StringBuilder>(PoolFactory.SharedStringBuilderPool);
    }
}

/// <summary>
/// A factory of object pools.
/// </summary>
/// <remarks>
/// This class makes it easy to create efficient object pools used to improve
/// performance by reducing strain on the garbage collector.
/// </remarks>
[ExcludeFromCodeCoverage]
public static class PoolFactory
{
    /// <summary>
    /// The capacity of the StringBuilder objects to keep in the pool.
    /// </summary>
    public const int DefaultStringBuilderCapacity = 1024;

    /// <summary>
    /// The max capacity of the StringBuilder object pool.
    /// </summary>
    public const int DefaultMaxStringBuilderCapacity = 8 * 1024;

    /// <summary>
    /// The initial capacity of the StringBuilder object pool.
    /// </summary>
    public const int InitialStringBuilderCapacity = 128;

    private static readonly IPooledObjectPolicy<StringBuilder> _defaultStringBuilderPolicy = new StringBuilderPooledObjectPolicy {
        InitialCapacity = InitialStringBuilderCapacity,
        MaximumRetainedCapacity = DefaultStringBuilderCapacity
    };

    /// <summary>
    /// Creates a pool of <see cref="StringBuilder"/> instances.
    /// </summary>
    /// <param name="maxCapacity">The maximum number of items to keep in the pool. This defaults to 1024. This value is a recommendation, the pool may keep more objects than this.</param>
    /// <param name="maxStringBuilderCapacity">The maximum capacity of the string builders to keep in the pool. This defaults to 64K.</param>
    /// <returns>The pool.</returns>
    public static ObjectPool<StringBuilder> CreateStringBuilderPool(int maxCapacity = DefaultStringBuilderCapacity, int maxStringBuilderCapacity = DefaultMaxStringBuilderCapacity)
    {
        if (maxCapacity < 1) throw new ArgumentOutOfRangeException(nameof(maxCapacity));
        if (maxStringBuilderCapacity < 1) throw new ArgumentOutOfRangeException(nameof(maxStringBuilderCapacity));

        if (maxStringBuilderCapacity == DefaultMaxStringBuilderCapacity)
        {
            return MakePool(_defaultStringBuilderPolicy, maxCapacity);
        }

        return MakePool(
            new StringBuilderPooledObjectPolicy {
                InitialCapacity = InitialStringBuilderCapacity,
                MaximumRetainedCapacity = maxStringBuilderCapacity
            }, maxCapacity);
    }

    /// <summary>
    /// Gets the shared pool of <see cref="StringBuilder"/> instances.
    /// </summary>
    public static ObjectPool<StringBuilder> SharedStringBuilderPool { get; } = CreateStringBuilderPool();

    private static DefaultObjectPool<T> MakePool<T>(IPooledObjectPolicy<T> policy, int maxRetained)
        where T : class
    {
        return new(policy, maxRetained);
    }
}


