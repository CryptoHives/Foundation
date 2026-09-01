// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Pools;

using CryptoHives.Foundation.Memory.Buffers;
using Microsoft.Extensions.ObjectPool;
using System;

/// <summary>
/// An immutable set of <see cref="ArrayPoolBufferWriter{T}"/> settings that hands out writers already
/// configured with them.
/// </summary>
/// <typeparam name="T">The element type the writers accept.</typeparam>
/// <remarks>
/// <para>
/// Writers are configured when they are rented rather than when they are constructed, so pooled
/// instances are interchangeable and a single pool serves an entire application. Declare one provider
/// per use case and rent from it; every provider draws from the same pool unless it is given one of
/// its own.
/// </para>
/// <code>
///     static readonly ArrayPoolBufferWriterProvider&lt;byte&gt; JsonWriters = new(maxChunkSize: 1 &lt;&lt; 20);
///     static readonly ArrayPoolBufferWriterProvider&lt;byte&gt; SecretWriters = new(clearArray: true);
///
///     using var writer = JsonWriters.Rent();
/// </code>
/// <para>
/// A provider is immutable and safe to share; the writers it hands out are not, and belong to one
/// caller until disposed.
/// </para>
/// </remarks>
public sealed class ArrayPoolBufferWriterProvider<T>
{
    private readonly bool _clearArray;
    private readonly int _defaultChunkSize;
    private readonly int _maxChunkSize;
    private readonly ObjectPool<ArrayPoolBufferWriter<T>> _pool;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriterProvider{T}"/> class.
    /// </summary>
    /// <param name="clearArray">Whether rented writers zero each buffer as it returns to the array pool.</param>
    /// <param name="defaultChunkSize">The size of the first chunk a rented writer takes.</param>
    /// <param name="maxChunkSize">
    /// The ceiling the chunk size ramps up to. A value at or below <paramref name="defaultChunkSize"/>
    /// disables the ramp, pinning every chunk to that size.
    /// </param>
    /// <param name="pool">
    /// The pool to draw from. Defaults to the shared pool for <typeparamref name="T"/>, which is what
    /// lets differently configured providers share one set of instances. Pass a pool from
    /// <see cref="PoolFactory.CreateBufferWriterPool{T}"/> only when a use case genuinely needs to be
    /// isolated from the rest of the application.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="defaultChunkSize"/> is less than one.</exception>
    public ArrayPoolBufferWriterProvider(
        bool clearArray = false,
        int defaultChunkSize = ArrayPoolBufferWriter<T>.DefaultChunkSize,
        int maxChunkSize = ArrayPoolBufferWriter<T>.MaxChunkSize,
        ObjectPool<ArrayPoolBufferWriter<T>>? pool = null)
    {
        if (defaultChunkSize < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(defaultChunkSize), defaultChunkSize, "The chunk size must be at least one element.");
        }

        _clearArray = clearArray;
        _defaultChunkSize = defaultChunkSize;
        _maxChunkSize = maxChunkSize;
        _pool = pool ?? PoolFactory.SharedBufferWriterPool<T>();
    }

    /// <summary>
    /// Rents a writer carrying this provider's settings.
    /// </summary>
    /// <returns>A writer in its just-constructed state, configured and attached to the pool.</returns>
    /// <remarks>
    /// Dispose the writer as usual and it returns itself to the pool. Do not use it afterwards: a
    /// returned instance does not throw, it silently becomes whatever the next renter is doing.
    /// </remarks>
    public ArrayPoolBufferWriter<T> Rent()
    {
        ArrayPoolBufferWriter<T> writer = _pool.Get();

        // Unconditionally, even for the default settings: the instance still carries whatever the
        // previous renter configured.
        writer.Configure(_clearArray, _defaultChunkSize, _maxChunkSize);
        writer.AttachPool(_pool);
        return writer;
    }
}
