// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;

/// <summary>
/// Defines the contract for an incremental hash computation over arbitrary value types.
/// </summary>
/// <typeparam name="TR">
/// The element reset type. The information required to reset the hash, e.g. a byte[] key or a bool.
/// </typeparam>
/// <remarks>
/// <para>
/// Implementations are expected to be lightweight structs that hold the full hash state
/// inline (no heap allocation for the state itself), suitable for use in high-performance
/// or stack-allocated contexts.
/// </para>
/// <para>
/// Data is accumulated via one or more <see cref="Append{T}(ReadOnlySpan{T})"/> calls.
/// The digest is retrieved — without modifying the accumulated state — via
/// <see cref="TryGetCurrentHash"/>. The state can then be discarded or explicitly cleared
/// via <see cref="Reset"/>.
/// </para>
/// <para>
/// All input-accepting overloads accept any unmanaged value type. The bytes are mixed in
/// memory-layout order, including any padding. Only <see cref="byte"/> is guaranteed to
/// produce identical results across all platforms and runtimes.
/// </para>
/// <para>
/// Higher-level consumers such as <see cref="HashAlgorithm"/> wrap implementations of this
/// interface and expose the same computation through the more familiar
/// <see cref="HashAlgorithm.AppendData(System.ReadOnlySpan{byte})"/> / <see cref="HashAlgorithm.TryGetHashAndReset"/>
/// API surface.
/// </para>
/// </remarks>
internal interface IIncrementalHash<TR> : IDisposable
{
    /// <summary>
    /// Gets the length of the hash digest produced by this instance, in bytes.
    /// </summary>
    int HashLengthBytes { get; }

    /// <summary>
    /// Appends the bytes of all values in <paramref name="input"/> to the hash state.
    /// </summary>
    /// <typeparam name="T">
    /// The element type. Must be a value type and must not contain any reference-type fields.
    /// </typeparam>
    /// <param name="input">The span of values whose memory representation is to be appended.</param>
    /// <remarks>
    /// Values are read in memory-layout order, including any struct padding bytes.
    /// Use <see cref="byte"/> when cross-platform or cross-architecture digest equivalence
    /// is required.
    /// </remarks>
    /// <exception cref="NotSupportedException">
    /// Thrown when <typeparamref name="T"/> is a reference type or contains reference-type fields.
    /// </exception>
    void Append<T>(ReadOnlySpan<T> input) where T : struct;

    /// <summary>
    /// Appends the bytes of all values in <paramref name="input"/> to the hash state.
    /// </summary>
    /// <param name="input">The span of byte values which are appended.</param>
    /// <exception cref="NotSupportedException">
    /// </exception>
    void Append(ReadOnlySpan<byte> input);

    /// <summary>
    /// Appends the bytes of all values in <paramref name="input"/> to the hash state,
    /// iterating over each segment of the sequence in order.
    /// </summary>
    /// <typeparam name="T">
    /// The element type. Must be a value type and must not contain any reference-type fields.
    /// </typeparam>
    /// <param name="input">
    /// The (possibly multi-segment) sequence of values whose memory representation is to be
    /// appended. Each segment is processed in order; the result is identical to calling
    /// <see cref="Append{T}(ReadOnlySpan{T})"/> once per segment.
    /// </param>
    /// <remarks>
    /// For a single-segment sequence this is equivalent to calling
    /// <see cref="Append{T}(ReadOnlySpan{T})"/> directly with
    /// <see cref="ReadOnlySequence{T}.First"/>.
    /// Values are read in memory-layout order, including any struct padding bytes.
    /// Use <see cref="byte"/> when cross-platform or cross-architecture digest equivalence
    /// is required.
    /// </remarks>
    /// <inheritdoc cref="Append{T}(ReadOnlySpan{T})" path="/exception"/>
    void Append<T>(ReadOnlySequence<T> input) where T : struct;

    /// <summary>
    /// Copies the current hash digest into <paramref name="destination"/> without
    /// resetting the accumulated state.
    /// </summary>
    /// <param name="destination">
    /// The buffer to receive the digest. Must have a capacity of at least
    /// <see cref="HashLengthBytes"/> bytes.
    /// </param>
    /// <param name="bytesWritten">
    /// On return, contains the number of bytes written to <paramref name="destination"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if <paramref name="destination"/> was large enough and the
    /// digest was written; <see langword="false"/> if the buffer was too small.
    /// </returns>
    /// <remarks>
    /// This method does not alter the internal state. Call <see cref="Reset"/> afterwards
    /// to prepare the instance for a new computation, or continue appending data.
    /// </remarks>
    bool TryGetCurrentHash(Span<byte> destination, out int bytesWritten);

    /// <summary>
    /// Resets the hash state so the instance can be reused for a new computation.
    /// </summary>
    /// <remarks>
    /// After this call the instance is in the same state as a freshly initialised one.
    /// Any previously appended data and any partially computed digest are discarded.
    /// </remarks>
    /// <param name="state">An additional state that is kept external.</param>
    void Reset(TR state);
}
