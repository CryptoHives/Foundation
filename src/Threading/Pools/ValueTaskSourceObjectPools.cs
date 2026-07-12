// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using CryptoHives.Foundation.Threading.Async.Pooled;

/// <summary>
/// Provides common constants and shared pools used in async events.
/// </summary>
public static class ValueTaskSourceObjectPools
{
    /// <summary>
    /// The default maximum number of retained object pool items.
    /// </summary>
    public const int DefaultMaxRetainedItems = 128;

    /// <summary>
    /// Holds the shared <see cref="LifoValueTaskSourceObjectPool{T}"/> object pool for <see cref="bool"/>.
    /// </summary>
    public static readonly LifoValueTaskSourceObjectPool<bool> ValueTaskSourcePoolBoolean = new(new PooledValueTaskSourceObjectPolicy<bool>(), DefaultMaxRetainedItems);

    /// <summary>
    /// Holds the shared <see cref="LifoValueTaskSourceObjectPool{T}"/> object pool for <see cref="AsyncLock.Releaser"/>.
    /// </summary>
    public static readonly LifoValueTaskSourceObjectPool<AsyncLock.Releaser> ValueTaskSourcePoolAsyncLockReleaser = new(new PooledValueTaskSourceObjectPolicy<AsyncLock.Releaser>(), DefaultMaxRetainedItems);

    /// <summary>
    /// Holds the shared <see cref="LifoValueTaskSourceObjectPool{T}"/> object pool for <see cref="AsyncReaderWriterLock.Releaser"/>.
    /// </summary>
    public static readonly LifoValueTaskSourceObjectPool<AsyncReaderWriterLock.Releaser> ValueTaskSourcePoolAsyncReaderWriterLockReleaser = new(new PooledValueTaskSourceObjectPolicy<AsyncReaderWriterLock.Releaser>(), DefaultMaxRetainedItems);
}
