// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using System;

/// <summary>
/// Defines the interface for a Message Authentication Code (MAC) algorithm.
/// </summary>
/// <remarks>
/// <para>
/// A MAC takes a secret key and a message and produces a fixed-size tag that can be
/// used to verify the authenticity and integrity of the message. Only parties that
/// know the key can produce or verify valid tags.
/// </para>
/// <para>
/// Implementations support a streaming API: call <see cref="Update"/> one or more
/// times, then call <see cref="Finalize(Span{byte})"/> to produce the tag.
/// Call <see cref="Reset"/> to reuse the instance with the same key.
/// </para>
/// </remarks>
public interface IMac : IDisposable
{
    /// <summary>
    /// Gets the name of the MAC algorithm.
    /// </summary>
    string AlgorithmName { get; }

    /// <summary>
    /// Gets the MAC output size in bytes.
    /// </summary>
    int MacSize { get; }

    /// <summary>
    /// Feeds input data into the MAC computation.
    /// </summary>
    /// <param name="input">The data to process.</param>
    void Update(ReadOnlySpan<byte> input);

    /// <summary>
    /// Computes the final MAC tag and writes it to <paramref name="destination"/>.
    /// </summary>
    /// <param name="destination">
    /// The buffer to receive the MAC tag. Must be at least <see cref="MacSize"/> bytes.
    /// </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="destination"/> is too small.
    /// </exception>
    void Finalize(Span<byte> destination);

    /// <summary>
    /// Resets the MAC to its initial state so it can be reused with the same key.
    /// </summary>
    void Reset();
}
