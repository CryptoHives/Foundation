// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using CryptoHives.Foundation.Threading.Async.Pooled;

/// <summary>
/// Provides a shared pool of pooled ValueTask sources for <see cref="AsyncKeyedLock{TKey}"/>.
/// </summary>
/// <remarks>
/// <see cref="ValueTaskSourceObjectPools"/> cannot hold this pool because its Releaser type is
/// generic over <typeparamref name="TKey"/>. Declaring it here instead means the CLR creates one
/// shared static pool per closed <typeparamref name="TKey"/> type, the same technique
/// <see cref="System.Buffers.ArrayPool{T}.Shared"/> uses.
/// </remarks>
/// <typeparam name="TKey">The key type of the <see cref="AsyncKeyedLock{TKey}"/> using this pool.</typeparam>
public static class ValueTaskSourceObjectPools<TKey> where TKey : notnull
{
    /// <summary>
    /// Holds the shared <see cref="ValueTaskSourceObjectPool{T}"/> object pool for <see cref="AsyncKeyedLock{TKey}.Releaser"/>.
    /// </summary>
    public static readonly ValueTaskSourceObjectPool<AsyncKeyedLock<TKey>.Releaser> ValueTaskSourcePoolAsyncKeyedLockReleaser =
        new(new PooledValueTaskSourceObjectPolicy<AsyncKeyedLock<TKey>.Releaser>(), ValueTaskSourceObjectPools.DefaultMaxRetainedItems);
}
