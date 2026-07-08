// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;

/// <summary>
/// An <see cref="ISegmentOwner{T}"/> that wraps a GC-managed <typeparamref name="T"/> array
/// in an <see cref="ArraySegment{T}"/>. The underlying array is eligible for garbage collection;
/// <see cref="Dispose"/> only clears the segment wrapper.
/// </summary>
public sealed class AllocatedSegment<T> : ISegmentOwner<T>
{
    private AllocatedSegment(ArraySegment<T> segment)
    {
        Segment = segment;
    }

    /// <inheritdoc/>
    public ArraySegment<T> Segment { get; private set; }

    /// <inheritdoc/>
    public T this[int i]
    {
        get => Segment.Array![i + Segment.Offset];
        set => Segment.Array![i + Segment.Offset] = value;
    }

    /// <summary>
    /// Wraps <paramref name="buffer"/> in an <see cref="AllocatedSegment{T}"/> covering the
    /// full array (offset 0, length equal to the array length). No copy is made.
    /// </summary>
    /// <param name="buffer">The array to wrap.</param>
    /// <returns>
    /// An <see cref="ISegmentOwner{T}"/> whose <see cref="ISegmentOwner{T}.Segment"/> references
    /// the same array as <paramref name="buffer"/>. The segment wrapper is cleared on dispose;
    /// the array itself is unaffected and remains eligible for GC.
    /// </returns>
    public static ISegmentOwner<T> Create(T[] buffer)
    {
        return new AllocatedSegment<T>(new ArraySegment<T>(buffer));
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Segment = default;
    }

    /// <inheritdoc/>
    public bool TrySetSegment(int offset, int length)
    {
        var array = Segment.Array;
        if (array?.Length >= offset + length)
        {
            Segment = new ArraySegment<T>(array, offset, length);
            return true;
        }

        return false;
    }
}
