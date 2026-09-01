// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1000 // Do not declare static members on generic types

namespace CryptoHives.Foundation.Memory.Buffers;

using System;
using System.Buffers;

/// <summary>
/// An <see cref="ISequenceOwner{T}"/> that adapts a single <see cref="ISegmentOwner{T}"/> into a
/// one-node <see cref="ReadOnlySequence{T}"/>, taking over its lifetime.
/// </summary>
/// <remarks>
/// <para>
/// This is the composition point between the two ownership abstractions: every segment strategy —
/// <see cref="PooledSegment{T}"/>, <see cref="AllocatedSegment{T}"/>, <see cref="EmptySegment{T}"/> —
/// becomes a sequence owner for free, so code written against <see cref="ISequenceOwner{T}"/> works
/// with all of them without caring which is underneath.
/// </para>
/// <para>
/// Ownership transfers on <see cref="Create"/>: disposing this instance disposes the inner segment
/// owner, which is what returns a pooled buffer to its pool. Do not dispose the inner owner directly
/// after handing it over.
/// </para>
/// </remarks>
public sealed class SegmentSequence<T> : ISequenceOwner<T>
{
    private ISegmentOwner<T>? _owner;

    private SegmentSequence(ISegmentOwner<T> owner)
    {
        _owner = owner;
    }

    /// <summary>
    /// Wraps <paramref name="owner"/> so its segment can be consumed as a
    /// <see cref="ReadOnlySequence{T}"/>, transferring ownership to the returned instance.
    /// </summary>
    /// <param name="owner">The segment owner to adopt. No copy is made.</param>
    /// <returns>An <see cref="ISequenceOwner{T}"/> over the same memory.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="owner"/> is <see langword="null"/>.</exception>
    public static ISequenceOwner<T> Create(ISegmentOwner<T> owner)
    {
        if (owner == null) throw new ArgumentNullException(nameof(owner));

        return new SegmentSequence<T>(owner);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Built on each read rather than cached, so a <see cref="ISegmentOwner{T}.TrySetSegment"/>
    /// re-window on the inner owner is reflected here. Constructing the sequence is a struct
    /// operation and allocates nothing.
    /// </remarks>
    public ReadOnlySequence<T> Sequence
    {
        get
        {
            ArraySegment<T> segment = _owner?.Segment ?? default;
            if (segment.Array == null || segment.Count == 0)
            {
                return ReadOnlySequence<T>.Empty;
            }

            return new ReadOnlySequence<T>(segment.Array, segment.Offset, segment.Count);
        }
    }

    /// <inheritdoc/>
    public long Length => _owner?.Segment.Count ?? 0;

    /// <inheritdoc/>
    public bool IsEmpty => Length == 0;

    /// <inheritdoc/>
    /// <remarks>Disposes the adopted <see cref="ISegmentOwner{T}"/>. Idempotent.</remarks>
    public void Dispose()
    {
        ISegmentOwner<T>? owner = _owner;
        _owner = null;
        owner?.Dispose();
    }
}
