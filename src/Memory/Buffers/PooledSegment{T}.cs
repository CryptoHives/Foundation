// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1000 // Do not declare static members on generic types

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
    // Clearing every returned buffer in a debug build turns a use-after-return into obvious zeroes
    // instead of plausible stale data. It is a diagnostic, not a security control: a caller that needs
    // its buffer wiped must say so through the clearArray parameter on Rent, which is honoured in
    // every configuration. In release this folds away to the caller's flag alone.
    private const bool AlwaysClearInDebug = true;
#else
    private const bool AlwaysClearInDebug = false;
#endif

    private readonly bool _clearArray;

    private PooledSegment(ArraySegment<T> segment, bool clearArray)
    {
        Segment = segment;
        _clearArray = clearArray;
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
    /// <param name="clearArray">
    /// Whether to zero the buffer as it returns to the pool. Pass <see langword="true"/> when the
    /// segment holds key material or anything else that should not be legible to the next renter.
    /// </param>
    /// <returns>
    /// An <see cref="ISegmentOwner{T}"/> whose <see cref="ISegmentOwner{T}.Segment"/> has
    /// <see cref="ArraySegment{T}.Count"/> equal to <paramref name="minimumLength"/>.
    /// </returns>
    /// <remarks>
    /// <para>
    /// A rented buffer arrives holding whatever the previous tenant left in it, and by default goes
    /// back the same way. <paramref name="clearArray"/> zeroes it on the way back, so what this buys
    /// is that the <em>next</em> renter cannot read the data — it does nothing about the window during
    /// which the data was live, and nothing about copies taken elsewhere.
    /// </para>
    /// <para>
    /// The whole array is zeroed, not just the segment window, so a
    /// <see cref="ISegmentOwner{T}.TrySetSegment"/> call cannot leave part of it legible. The cost is
    /// a pass over the buffer on dispose, proportional to its length.
    /// </para>
    /// </remarks>
    public static ISegmentOwner<T> Rent(int minimumLength, bool clearArray = false)
    {
        var segment = new ArraySegment<T>(ArrayPool<T>.Shared.Rent(minimumLength), 0, minimumLength);
        return new PooledSegment<T>(segment, clearArray || AlwaysClearInDebug);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        var array = Segment.Array;
        if (array != null)
        {
            ArrayPool<T>.Shared.Return(array, _clearArray);
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
