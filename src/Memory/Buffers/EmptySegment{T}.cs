// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;

/// <summary>
/// An <see cref="ISegmentOwner{T}"/> that represents an empty, zero-allocation segment
/// backed by <see cref="Array.Empty{T}"/>. Follows the null-object pattern to avoid
/// <see langword="null"/> checks in consumers.
/// </summary>
public sealed class EmptySegment<T> : ISegmentOwner<T>
{
    private EmptySegment(ArraySegment<T> segment)
    {
        Segment = segment;
    }

    /// <summary>
    /// Gets the shared empty segment singleton. No allocation is ever needed.
    /// </summary>
    public static ISegmentOwner<T> Instance { get; } = new EmptySegment<T>(new ArraySegment<T>(Array.Empty<T>()));

    /// <inheritdoc/>
    public ArraySegment<T> Segment { get; private set; }

    /// <inheritdoc/>
    public T this[int i]
    {
        get => throw new ArgumentOutOfRangeException(nameof(i), "Empty segment has no elements.");
        set => throw new ArgumentOutOfRangeException(nameof(i), "Empty segment has no elements.");
    }

    /// <inheritdoc/>
    public void Dispose()
    {
    }

    /// <inheritdoc/>
    public bool TrySetSegment(int offset, int length)
    {
        return false;
    }
}
