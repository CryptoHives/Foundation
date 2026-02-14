// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Defines support for extendable-output function (XOF) mode,
/// allowing variable-length output from a hash algorithm.
/// </summary>
/// <remarks>
/// <para>
/// An XOF produces an arbitrary number of output bytes. After absorbing all input,
/// the caller squeezes as many bytes as needed, possibly in multiple calls.
/// </para>
/// <para>
/// Algorithms that implement this interface include SHAKE128/256, TurboSHAKE128/256,
/// cSHAKE128/256, KT128/256, KMAC128/256, BLAKE3, and Ascon-XOF128.
/// </para>
/// </remarks>
public interface IExtendableOutput
{
    /// <summary>
    /// Absorbs input data into the XOF state.
    /// </summary>
    /// <param name="input">The input data to absorb.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when data is added after output has been squeezed.
    /// </exception>
    void Absorb(ReadOnlySpan<byte> input);

    /// <summary>
    /// Squeezes output bytes from the XOF state.
    /// </summary>
    /// <remarks>
    /// After the first call, the hash is finalized and no more data can be absorbed.
    /// May be called multiple times for streaming output.
    /// </remarks>
    /// <param name="output">The buffer to receive the output bytes.</param>
    void Squeeze(Span<byte> output);

    /// <summary>
    /// Resets the XOF state so the instance can be reused for a new computation.
    /// </summary>
    /// <remarks>
    /// After calling this method, the instance is in the same state as a newly constructed one.
    /// All previously absorbed data and squeezed output are discarded.
    /// </remarks>
    void Reset();
}
