// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Provides common constants, static variables and pools for efficient memory usage in async events.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class PooledEventsCommon
{
    /// <summary>
    /// The default size for a queue used in a event.
    /// </summary>
    public const int DefaultEventQueueSize = 8;

    /// <summary>
    /// Holds the shared <see cref="PooledManualResetValueTaskSource{Boolean}"/> object pool.
    /// </summary>
    private static readonly ObjectPool<PooledManualResetValueTaskSource<bool>> _valueTaskSourcePool = new DefaultObjectPool<PooledManualResetValueTaskSource<bool>>(new PooledValueTaskSourceObjectPolicy<bool>());

    /// <summary>
    /// Gets a ValueTaskSource from the pool.
    /// </summary>
    public static PooledManualResetValueTaskSource<bool> GetPooledValueTaskSource()
    {
        PooledManualResetValueTaskSource<bool> vts = _valueTaskSourcePool.Get();
        vts.SetOwnerPool(_valueTaskSourcePool);
        return vts;
    }
}
