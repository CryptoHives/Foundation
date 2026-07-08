// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;
using System.Buffers;

/// <summary>
/// An <see cref="ISegmentOwner{T}"/> that rents a buffer from <see cref="ArrayPool{T}.Shared"/>
/// and returns it automatically on dispose.
/// </summary>
/// <remarks>
/// Implemented as a sealed class so the backing array can never be disposed more than once
/// by an unintended struct copy.
/// </remarks>
public sealed class PooledSegment<T> : ISegmentOwner<T>
{
#if DEBUG
    // for testing clear buffers when returned
    private const bool ClearArray = true;
#else
    private const bool ClearArray = false;
#endif

    private PooledSegment(ArraySegment<T> segment)
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
    /// Rents a buffer with at least <paramref name="minimumLength"/> elements from
    /// <see cref="ArrayPool{T}.Shared"/> and returns it wrapped in a <see cref="PooledSegment{T}"/>.
    /// </summary>
    /// <param name="minimumLength">The minimum number of elements required.</param>
    /// <returns>
    /// An <see cref="ISegmentOwner{T}"/> whose <see cref="ISegmentOwner{T}.Segment"/> has
    /// <see cref="ArraySegment{T}.Count"/> equal to <paramref name="minimumLength"/>.
    /// </returns>
    public static ISegmentOwner<T> Rent(int minimumLength)
    {
        var segment = new ArraySegment<T>(ArrayPool<T>.Shared.Rent(minimumLength), 0, minimumLength);
        return new PooledSegment<T>(segment);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        var array = Segment.Array;
        if (array != null)
        {
            ArrayPool<T>.Shared.Return(array, ClearArray);
            Segment = default;
        }
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
