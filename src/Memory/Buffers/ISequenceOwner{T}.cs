// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;
using System.Buffers;

/// <summary>
/// Owner of a <see cref="ReadOnlySequence{T}"/> that controls the lifetime of the buffers behind it.
/// Implementors decide the release strategy (pool return, GC collection, or no-op) while callers use
/// a single consistent API.
/// </summary>
/// <remarks>
/// <para>
/// This is the sequence-shaped counterpart to <see cref="ISegmentOwner{T}"/>, and follows the same
/// idea as <see cref="System.Buffers.IMemoryOwner{T}"/>: the interface carries the payload, and
/// <see cref="IDisposable"/> carries the lifetime. It exists because the borrowed sequences returned
/// by <see cref="ArrayPoolMemoryStream.GetReadOnlySequence"/> and
/// <see cref="ArrayPoolBufferWriter{T}.GetReadOnlySequence"/> are only valid while their producer
/// lives; an owner lets a payload outlive the object that produced it.
/// </para>
/// <para>
/// Ownership is exclusive. There is no reference counting: a single holder is responsible for
/// disposal, and reading <see cref="Sequence"/> afterwards is undefined, because pooled buffers may
/// already have been handed to another tenant.
/// </para>
/// <para>
/// Narrowing the payload does not require a method here, unlike
/// <see cref="ISegmentOwner{T}.TrySetSegment"/> on the segment side: a
/// <see cref="ReadOnlySequence{T}"/> is read-only and slicing it is a cheap value operation that
/// leaves ownership untouched — <c>owner.Sequence.Slice(start, length)</c>.
/// </para>
/// <para>
/// Built-in implementations:
/// <list type="bullet">
///   <item><description><see cref="SequenceLease{T}"/> — a payload paired with the disposable that ends its life. This is what the producers hand out, and it is a struct, so it costs nothing.</description></item>
///   <item><description><see cref="SegmentSequence{T}"/> — adapts any <see cref="ISegmentOwner{T}"/> into a single-segment sequence.</description></item>
///   <item><description><see cref="EmptySequence{T}"/> — a zero-allocation null-object sentinel.</description></item>
/// </list>
/// </para>
/// <para>
/// Note that <see cref="SequenceLease{T}"/> is a struct: reaching it through this interface boxes it,
/// which is the one allocation it exists to avoid. Take the lease by its own type unless several
/// owner kinds genuinely have to be handled uniformly.
/// </para>
/// </remarks>
/// <example>
/// <code>
/// using SequenceLease&lt;byte&gt; payload = writer.LeaseSequence();  // carries the writer along
/// byte[] digest = Blake3.HashData(payload.Sequence);               // hashed in place, no copy
/// </code>
/// </example>
public interface ISequenceOwner<T> : IDisposable
{
    /// <summary>
    /// Gets the sequence spanning the owned buffers.
    /// </summary>
    /// <remarks>Valid until this owner is disposed.</remarks>
    ReadOnlySequence<T> Sequence { get; }

    /// <summary>
    /// Gets the total number of elements in <see cref="Sequence"/>.
    /// </summary>
    long Length { get; }

    /// <summary>
    /// Gets whether the owner holds no elements.
    /// </summary>
    bool IsEmpty { get; }
}
