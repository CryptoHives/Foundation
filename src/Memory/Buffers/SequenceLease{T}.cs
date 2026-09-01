// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Memory.Buffers;

using System;
using System.Buffers;

/// <summary>
/// A payload and the disposable that ends its life, carried together as a single value so the pair
/// can travel through a pipeline without the consumer knowing what produced it.
/// </summary>
/// <typeparam name="T">The element type of the sequence.</typeparam>
/// <remarks>
/// <para>
/// This is a <see langword="struct"/> deliberately: it exists to move a payload across a scope
/// boundary without paying for a handle to do it. Obtain one from
/// <see cref="ArrayPoolBufferWriter{T}.LeaseSequence"/> or
/// <see cref="ArrayPoolMemoryStream.LeaseSequence"/>, where the producer itself rides along as the
/// disposable — so disposing the lease returns the producer, which returns its buffers.
/// </para>
/// <para>
/// Nothing is transferred and nothing is allocated: the sequence is the one the producer already
/// holds, and the producer stays alive for as long as the lease does. The trade is that a pooled
/// producer stays out of circulation until the payload is finished with.
/// </para>
/// <para>
/// Use it in a limited scope, as with <see cref="Pools.ObjectOwner{T}"/>:
/// </para>
/// <code>
///     using SequenceLease&lt;byte&gt; payload = BuildPayload();
///     Send(payload.Sequence);
/// </code>
/// <para>
/// <b>Do not copy it.</b> Two copies disposed means the producer is disposed twice. <b>Do not cast it
/// to <see cref="ISequenceOwner{T}"/> or <see cref="IDisposable"/></b> unless a boxing allocation is
/// acceptable — that is the one way to spend the allocation this type exists to avoid. Storing it in a
/// <c>Channel</c>, a list or an async method's locals is fine; those hold the struct inline.
/// </para>
/// <para>
/// The default value is a valid empty lease: no payload, no owner, and disposing it does nothing.
/// </para>
/// </remarks>
public readonly struct SequenceLease<T> : ISequenceOwner<T>, IEquatable<SequenceLease<T>>
{
    private readonly ReadOnlySequence<T> _sequence;
    private readonly IDisposable? _owner;

    /// <summary>
    /// Initializes a new instance of the <see cref="SequenceLease{T}"/> struct.
    /// </summary>
    /// <param name="sequence">The payload.</param>
    /// <param name="owner">
    /// The object whose disposal releases the payload, usually the producer that yielded
    /// <paramref name="sequence"/>. May be <see langword="null"/> for a payload that owns nothing.
    /// </param>
    public SequenceLease(ReadOnlySequence<T> sequence, IDisposable? owner)
    {
        _sequence = sequence;
        _owner = owner;
    }

    /// <inheritdoc/>
    public ReadOnlySequence<T> Sequence => _sequence;

    /// <inheritdoc/>
    public long Length => _sequence.Length;

    /// <inheritdoc/>
    public bool IsEmpty => _sequence.IsEmpty;

    /// <summary>
    /// Disposes the owner, releasing the payload.
    /// </summary>
    /// <remarks>
    /// Not idempotent in itself — it simply forwards to the owner, so whether a second call is safe is
    /// the owner's business. Both producers in this package tolerate it.
    /// </remarks>
    public void Dispose() => _owner?.Dispose();

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is SequenceLease<T> other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(SequenceLease<T> other)
        => ReferenceEquals(_owner, other._owner)
        && _sequence.Start.Equals(other._sequence.Start)
        && _sequence.End.Equals(other._sequence.End);

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(_owner, _sequence.Length);
    }

    /// <summary>
    /// Determines whether two leases refer to the same payload and owner.
    /// </summary>
    /// <param name="left">The first lease.</param>
    /// <param name="right">The second lease.</param>
    /// <returns><see langword="true"/> if they are equal.</returns>
    public static bool operator ==(SequenceLease<T> left, SequenceLease<T> right) => left.Equals(right);

    /// <summary>
    /// Determines whether two leases refer to different payloads or owners.
    /// </summary>
    /// <param name="left">The first lease.</param>
    /// <param name="right">The second lease.</param>
    /// <returns><see langword="true"/> if they are not equal.</returns>
    public static bool operator !=(SequenceLease<T> left, SequenceLease<T> right) => !left.Equals(right);
}
