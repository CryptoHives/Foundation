// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1024 // Use properties where appropriate

namespace CryptoHives.Foundation.Memory.Pools;

using System.Text;

/// <summary>
/// Provides ObjectPools for efficient memory usage.
/// </summary>
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
    ///     StringBuilder sb = owner.PooledObject;
    ///     ...
    /// </code>
    /// </remarks>
    public static ObjectOwner<StringBuilder> GetStringBuilder()
    {
        return new ObjectOwner<StringBuilder>(PoolFactory.SharedStringBuilderPool);
    }
}

