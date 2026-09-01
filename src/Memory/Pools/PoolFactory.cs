// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1024 // Use properties where appropriate

namespace CryptoHives.Foundation.Memory.Pools;

using CryptoHives.Foundation.Memory.Buffers;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// A factory of object pools.
/// </summary>
/// <remarks>
/// This class makes it easy to create efficient object pools used to improve
/// performance by reducing strain on the garbage collector.
/// </remarks>
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

    /// <summary>
    /// Creates a pool of <see cref="ArrayPoolBufferWriter{T}"/> instances.
    /// </summary>
    /// <typeparam name="T">The element type the writers accept.</typeparam>
    /// <param name="maximumRetained">
    /// The maximum number of writers to keep. Pass a value of zero or less to use the default,
    /// which scales with the processor count.
    /// </param>
    /// <returns>The pool.</returns>
    /// <remarks>
    /// <para>
    /// The pool takes no writer settings: those are applied when a writer is rented, so instances in
    /// the pool are interchangeable. Hand the returned pool to an
    /// <see cref="ArrayPoolBufferWriterProvider{T}"/> to rent from it.
    /// </para>
    /// <para>
    /// Most callers do not need this. <see cref="SharedBufferWriterPool{T}"/> is the pool every
    /// provider uses by default, and sharing it is what keeps the instance count down; create a
    /// separate one only to isolate a use case deliberately.
    /// </para>
    /// </remarks>
    public static ObjectPool<ArrayPoolBufferWriter<T>> CreateBufferWriterPool<T>(int maximumRetained = 0)
    {
        return CreatePool(
            static () => new ArrayPoolBufferWriter<T>(),
            static writer =>
            {
                if (writer.TryReset())
                {
                    return true;
                }

                // DefaultObjectPool drops a rejected instance without disposing it, so a writer that
                // cannot be reset has to be torn down here or its buffers never reach the pool again.
                writer.Dispose();
                return false;
            },
            maximumRetained);
    }

    /// <summary>
    /// Gets the shared pool of <see cref="ArrayPoolBufferWriter{T}"/> instances for the default
    /// configuration, one pool per element type.
    /// </summary>
    /// <typeparam name="T">The element type the writers accept.</typeparam>
    public static ObjectPool<ArrayPoolBufferWriter<T>> SharedBufferWriterPool<T>()
        => SharedBufferWriterPoolHolder<T>.Instance;

    /// <summary>
    /// Creates a pool for any reference type, driven by a pair of delegates.
    /// </summary>
    /// <typeparam name="T">The type to pool.</typeparam>
    /// <param name="create">Produces a new instance when the pool is empty.</param>
    /// <param name="reset">
    /// Restores an instance to a reusable state on return. Return <see langword="true"/> to let the
    /// pool keep it, or <see langword="false"/> to reject it.
    /// </param>
    /// <param name="maximumRetained">
    /// The maximum number of instances to keep. Pass a value of zero or less to use the default,
    /// which scales with the processor count.
    /// </param>
    /// <returns>The pool.</returns>
    /// <remarks>
    /// <para>
    /// This exists so callers can pool types this package does not reference. It is how a
    /// <c>Utf8JsonWriter</c> gets pooled without the Memory package taking a dependency on
    /// <c>System.Text.Json</c>:
    /// </para>
    /// <code>
    /// ObjectPool&lt;Utf8JsonWriter&gt; pool = PoolFactory.CreatePool(
    ///     () => new Utf8JsonWriter(Stream.Null),
    ///     writer => { writer.Reset(Stream.Null); return true; });
    /// </code>
    /// <para>
    /// <b>A rejected instance is dropped, not disposed.</b> When <paramref name="reset"/> returns
    /// <see langword="false"/> the pool simply lets the instance go, so if <typeparamref name="T"/>
    /// holds unmanaged or pooled resources, <paramref name="reset"/> must dispose it before returning
    /// <see langword="false"/> — otherwise those resources are never released.
    /// </para>
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="create"/> or <paramref name="reset"/> is <see langword="null"/>.</exception>
    public static ObjectPool<T> CreatePool<T>(Func<T> create, Func<T, bool> reset, int maximumRetained = 0)
        where T : class
    {
        if (create == null) throw new ArgumentNullException(nameof(create));
        if (reset == null) throw new ArgumentNullException(nameof(reset));

        var policy = new DelegatePolicy<T>(create, reset);

        // DefaultObjectPool picks its own retention (processor count based) when not told otherwise.
        return maximumRetained > 0
            ? new DefaultObjectPool<T>(policy, maximumRetained)
            : new DefaultObjectPool<T>(policy);
    }

    private static DefaultObjectPool<T> MakePool<T>(IPooledObjectPolicy<T> policy, int maxRetained)
        where T : class
    {
        return new(policy, maxRetained);
    }

    /// <summary>
    /// Holds one shared buffer-writer pool per element type. A generic static is the simplest way to
    /// get a per-closed-type singleton without a dictionary lookup on every rent.
    /// </summary>
    private static class SharedBufferWriterPoolHolder<T>
    {
        public static readonly ObjectPool<ArrayPoolBufferWriter<T>> Instance = CreateBufferWriterPool<T>();
    }

    /// <summary>
    /// Adapts a create/reset delegate pair to the pooling policy contract.
    /// </summary>
    private sealed class DelegatePolicy<T> : PooledObjectPolicy<T>
        where T : class
    {
        private readonly Func<T> _create;
        private readonly Func<T, bool> _reset;

        public DelegatePolicy(Func<T> create, Func<T, bool> reset)
        {
            _create = create;
            _reset = reset;
        }

        public override T Create() => _create();

        public override bool Return(T obj) => _reset(obj);
    }
}


