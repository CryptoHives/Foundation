// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1000 // Do not declare static members on generic types

namespace CryptoHives.Foundation.Memory.Buffers;

using System.Buffers;

/// <summary>
/// An <see cref="ISequenceOwner{T}"/> that represents an empty, zero-allocation sequence backed by
/// <see cref="ReadOnlySequence{T}.Empty"/>. Follows the null-object pattern to avoid
/// <see langword="null"/> checks in consumers.
/// </summary>
/// <remarks>
/// This is what a producer hands back when there is nothing to own, so callers can always write
/// <c>using</c> over the result of a detach without a null test.
/// </remarks>
public sealed class EmptySequence<T> : ISequenceOwner<T>
{
    private EmptySequence()
    {
    }

    /// <summary>
    /// Gets the shared empty sequence singleton. No allocation is ever needed.
    /// </summary>
    public static ISequenceOwner<T> Instance { get; } = new EmptySequence<T>();

    /// <inheritdoc/>
    public ReadOnlySequence<T> Sequence => ReadOnlySequence<T>.Empty;

    /// <inheritdoc/>
    public long Length => 0;

    /// <inheritdoc/>
    public bool IsEmpty => true;

    /// <inheritdoc/>
    /// <remarks>
    /// A no-op. The singleton owns nothing, so disposing it — including repeatedly, and from several
    /// callers — has no effect.
    /// </remarks>
    public void Dispose()
    {
    }
}
