// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

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
    /// 
    /// </summary>
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
internal static class PoolFactory
{
    private const int DefaultCapacity = 1024;
    private const int DefaultMaxStringBuilderCapacity = 8 * 1024;
    private const int InitialStringBuilderCapacity = 128;

    private static readonly IPooledObjectPolicy<StringBuilder> _defaultStringBuilderPolicy = new StringBuilderPooledObjectPolicy {
        InitialCapacity = InitialStringBuilderCapacity,
        MaximumRetainedCapacity = DefaultCapacity
    };

    /// <summary>
    /// Creates a pool of <see cref="StringBuilder"/> instances.
    /// </summary>
    /// <param name="maxCapacity">The maximum number of items to keep in the pool. This defaults to 1024. This value is a recommendation, the pool may keep more objects than this.</param>
    /// <param name="maxStringBuilderCapacity">The maximum capacity of the string builders to keep in the pool. This defaults to 64K.</param>
    /// <returns>The pool.</returns>
    public static ObjectPool<StringBuilder> CreateStringBuilderPool(int maxCapacity = DefaultCapacity, int maxStringBuilderCapacity = DefaultMaxStringBuilderCapacity)
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

