// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;

/// <summary>
/// Owner of an <see cref="ArraySegment{T}"/> that controls the lifetime of its
/// underlying memory. Implementors decide the acquisition and release strategy
/// (pool return, GC collection, or no-op) while callers use a single consistent API.
/// </summary>
/// <remarks>
/// Three built-in implementations cover the most common ownership strategies:
/// <list type="bullet">
///   <item><description><see cref="PooledSegment{T}"/> — rents from <see cref="System.Buffers.ArrayPool{T}"/> and returns on dispose.</description></item>
///   <item><description><see cref="AllocatedSegment{T}"/> — wraps a GC-managed array; only the segment wrapper is cleared on dispose.</description></item>
///   <item><description><see cref="EmptySegment{T}"/> — a zero-allocation null-object sentinel.</description></item>
/// </list>
/// </remarks>
public interface ISegmentOwner<T> : IDisposable
{
    /// <summary>
    /// Gets the current <see cref="ArraySegment{T}"/> view of the underlying array.
    /// </summary>
    ArraySegment<T> Segment { get; }

    /// <summary>
    /// Gets or sets element <paramref name="i"/> relative to <see cref="ArraySegment{T}.Offset"/>
    /// inside <see cref="ArraySegment{T}.Array"/>.
    /// </summary>
    /// <param name="i">Zero-based index within the current segment.</param>
    T this[int i] { get; set; }

    /// <summary>
    /// Sets the offset and the length of the <see cref="ArraySegment{T}"/>.
    /// </summary>
    /// <param name="offset">The new zero-based offset into the underlying array.</param>
    /// <param name="length">The number of elements to expose starting at <paramref name="offset"/>.</param>
    /// <returns>
    /// <see langword="true"/> if the segment was updated; <see langword="false"/> if the underlying
    /// array is <see langword="null"/> or too small to satisfy the requested range.
    /// </returns>
    bool TrySetSegment(int offset, int length);
}
