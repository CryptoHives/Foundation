// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using CryptoHives.Foundation.Threading.Async.Pooled;
using System;

/// <summary>
/// Provides common constants and shared pools used in async events.
/// </summary>
public static class ValueTaskSourceObjectPools
{
    /// <summary>
    /// The default size for a queue used in a event.
    /// </summary>
    public const int DefaultEventQueueSize = 8;

    /// <summary>
    /// The default maximum number of retained object pool items.
    /// </summary>
    public const int DefaultMaxRetainedItems = 128;

    private static readonly Lazy<ValueTaskSourceObjectPool<bool>> _valueTaskSourcePoolBoolean =
        new(() => new ValueTaskSourceObjectPool<bool>(new PooledValueTaskSourceObjectPolicy<bool>(), DefaultMaxRetainedItems));

    private static readonly Lazy<ValueTaskSourceObjectPool<AsyncLock.AsyncLockReleaser>> _valueTaskSourcePoolAsyncLockReleaser =
        new(() => new ValueTaskSourceObjectPool<AsyncLock.AsyncLockReleaser>(new PooledValueTaskSourceObjectPolicy<AsyncLock.AsyncLockReleaser>(), DefaultMaxRetainedItems));

    /// <summary>
    /// Gets the shared <see cref="ValueTaskSourceObjectPool{T}"/> object pool for <see cref="bool"/>.
    /// </summary>
    public static ValueTaskSourceObjectPool<bool> ValueTaskSourcePoolBoolean => _valueTaskSourcePoolBoolean.Value;

    /// <summary>
    /// Gets the shared <see cref="ValueTaskSourceObjectPool{T}"/> object pool for <see cref="AsyncLock.AsyncLockReleaser"/>.
    /// </summary>
    public static ValueTaskSourceObjectPool<AsyncLock.AsyncLockReleaser> ValueTaskSourcePoolAsyncLockReleaser => _valueTaskSourcePoolAsyncLockReleaser.Value;
}
