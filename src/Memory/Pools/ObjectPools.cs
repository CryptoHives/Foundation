// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1024 // Use properties where appropriate

namespace CryptoHives.Foundation.Memory.Pools;

using CryptoHives.Foundation.Memory.Buffers;
using Microsoft.Extensions.ObjectPool;
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

    /// <summary>
    /// Rents an <see cref="ArrayPoolBufferWriter{T}"/> with default settings from the shared pool for
    /// its element type.
    /// </summary>
    /// <typeparam name="T">The element type the writer accepts.</typeparam>
    /// <returns>A writer in its just-constructed state.</returns>
    /// <remarks>
    /// Dispose the writer as usual and it returns itself to the pool. No <see cref="ObjectOwner{T}"/>
    /// wrapper is needed here, unlike <see cref="GetStringBuilder"/>, because the writer is disposable
    /// in its own right:
    /// <code>
    ///     using var writer = ObjectPools.RentBufferWriter&lt;byte&gt;();
    ///     data.CopyTo(writer.GetSpan(data.Length));
    ///     writer.Advance(data.Length);
    ///
    ///     Consume(writer.GetReadOnlySequence());       // borrowed, valid in this scope
    /// </code>
    /// To let the payload leave the scope instead, return <c>writer.LeaseSequence()</c> and do not
    /// dispose the writer here — the lease carries it and releases it later.
    /// For anything other than the default settings, declare an
    /// <see cref="ArrayPoolBufferWriterProvider{T}"/> once and rent from it. It draws from this same
    /// pool, so configuring a use case costs no extra instances.
    /// <para>
    /// <b>Do not use the writer after disposing it.</b> A returned instance does not throw; it
    /// silently becomes whatever the next renter is doing.
    /// </para>
    /// </remarks>
    public static ArrayPoolBufferWriter<T> RentBufferWriter<T>()
        => DefaultBufferWriterProvider<T>.Instance.Rent();

    /// <summary>
    /// Holds one default-settings provider per element type, so the no-argument rent path does not
    /// allocate one per call.
    /// </summary>
    private static class DefaultBufferWriterProvider<T>
    {
        public static readonly ArrayPoolBufferWriterProvider<T> Instance = new();
    }
}

