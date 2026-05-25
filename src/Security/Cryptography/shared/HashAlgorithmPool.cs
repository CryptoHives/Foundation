// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using Microsoft.Extensions.ObjectPool;

/// <summary>
/// Provides a per-type object pool of hash algorithm instances for use by static
/// one-shot <c>HashData</c> / <c>TryHashData</c> methods.
/// </summary>
/// <typeparam name="T">
/// A concrete <see cref="HashAlgorithm"/> type that exposes a public parameterless constructor.
/// </typeparam>
/// <remarks>
/// <para>
/// One <see cref="DefaultObjectPool{T}"/> is created per closed generic type via the static
/// initializer, so the pool is effectively a singleton per algorithm.
/// </para>
/// <para>
/// Because <see cref="HashAlgorithm"/> implements <see cref="IResettable"/>, the default policy
/// automatically calls <c>TryReset()</c> → <c>Initialize()</c> on every return, ensuring
/// instances are always in a clean state when rented out again.
/// </para>
/// </remarks>
internal static class HashAlgorithmPool<T>
    where T : HashAlgorithm, new()
{
    private static readonly ObjectPool<T> _pool =
        new DefaultObjectPool<T>(new DefaultPooledObjectPolicy<T>());

    /// <summary>
    /// Attempts to compute the hash of <paramref name="source"/> and write it into
    /// <paramref name="destination"/> without allocating a hash instance or output array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value.</param>
    /// <param name="bytesWritten">
    /// When this method returns, the number of bytes written into <paramref name="destination"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="destination"/> was large enough;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryHashData(
        ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        T hasher = _pool.Get();
        try
        {
            return hasher.TryComputeHash(source, destination, out bytesWritten);
        }
        finally
        {
            _pool.Return(hasher);
        }
    }

    /// <summary>
    /// Computes the hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the hash value.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
    {
        T hasher = _pool.Get();
        try
        {
            int hashBytes = hasher.HashSize / 8;
            byte[] result = new byte[hashBytes];
            hasher.TryComputeHash(source, result, out _);
            return result;
        }
        finally
        {
            _pool.Return(hasher);
        }
    }
}

/// <summary>
/// Creates object pools for hash algorithm types that require a factory delegate,
/// for example algorithms whose default constructor produces a different output size
/// than the desired pooled configuration (e.g. <c>Streebog-256</c>, <c>Kupyna-256</c>).
/// </summary>
internal static class HashAlgorithmPool
{
    /// <summary>
    /// Creates an <see cref="ObjectPool{T}"/> backed by a custom factory delegate.
    /// </summary>
    /// <typeparam name="T">A concrete <see cref="HashAlgorithm"/> type.</typeparam>
    /// <param name="factory">A delegate that produces a new, initialised instance of <typeparamref name="T"/>.</param>
    /// <returns>A new <see cref="ObjectPool{T}"/> that resets instances via <see cref="IResettable.TryReset"/> on return.</returns>
    public static ObjectPool<T> CreatePool<T>(Func<T> factory)
        where T : HashAlgorithm
        => new DefaultObjectPool<T>(new DelegatePoolPolicy<T>(factory));

    /// <summary>
    /// Attempts to compute the hash of <paramref name="source"/> using a delegate-backed pool,
    /// writing the result into <paramref name="destination"/>.
    /// </summary>
    /// <typeparam name="T">A concrete <see cref="HashAlgorithm"/> type.</typeparam>
    /// <param name="pool">The pool to rent from and return to.</param>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value.</param>
    /// <param name="bytesWritten">
    /// When this method returns, the number of bytes written into <paramref name="destination"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="destination"/> was large enough;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryHashData<T>(
        ObjectPool<T> pool, ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        where T : HashAlgorithm
    {
        T hasher = pool.Get();
        try
        {
            return hasher.TryComputeHash(source, destination, out bytesWritten);
        }
        finally
        {
            pool.Return(hasher);
        }
    }

    /// <summary>
    /// Computes the hash of <paramref name="source"/> using a delegate-backed pool and returns
    /// it as a new byte array.
    /// </summary>
    /// <typeparam name="T">A concrete <see cref="HashAlgorithm"/> type.</typeparam>
    /// <param name="pool">The pool to rent from and return to.</param>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the hash value.</returns>
    public static byte[] HashData<T>(ObjectPool<T> pool, ReadOnlySpan<byte> source)
        where T : HashAlgorithm
    {
        T hasher = pool.Get();
        try
        {
            int hashBytes = hasher.HashSize / 8;
            byte[] result = new byte[hashBytes];
            hasher.TryComputeHash(source, result, out _);
            return result;
        }
        finally
        {
            pool.Return(hasher);
        }
    }

    /// <summary>
    /// A <see cref="PooledObjectPolicy{T}"/> that uses a factory delegate to create instances
    /// and resets them via <see cref="IResettable.TryReset"/> on return.
    /// </summary>
    private sealed class DelegatePoolPolicy<T> : PooledObjectPolicy<T>
        where T : HashAlgorithm
    {
        private readonly Func<T> _factory;

        public DelegatePoolPolicy(Func<T> factory) => _factory = factory;

        /// <inheritdoc/>
        public override T Create() => _factory();

        /// <inheritdoc/>
        public override bool Return(T obj) => obj.TryReset();
    }
}
