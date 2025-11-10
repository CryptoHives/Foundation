// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Async;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Provides common constants, static variables and pools for efficient memory usage in async events.
/// </summary>
[ExcludeFromCodeCoverage]
public static class PooledEventsCommon
{
    /// <summary>
    /// The default size for a queue used in a event.
    /// </summary>
    public const int DefaultEventQueueSize = 4;

    /// <summary>
    /// A cached version of a completed ValueTask.
    /// As a struct, assigning it is just copy from here.
    /// </summary>
    public static readonly ValueTask CompletedTask = new(Task.CompletedTask);

    /// <summary>
    /// Gets an instance of a <see cref="ManualResetValueTaskSource{Boolean}"/> object pool.
    /// </summary>
    public static readonly ObjectPool<ManualResetValueTaskSource<bool>> ValueTaskSourcePool = new DefaultObjectPool<ManualResetValueTaskSource<bool>>(new PooledValueTaskSourceObjectPolicy<bool>());
}
