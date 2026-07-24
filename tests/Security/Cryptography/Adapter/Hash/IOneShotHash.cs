// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using System;

/// <summary>
/// One-shot hash entry point for benchmark adapters whose wrapped library has a
/// dedicated single-call API that is faster than the streaming
/// <c>HashCore</c>/<c>TryHashFinal</c> path.
/// </summary>
/// <remarks>
/// The <see cref="System.Security.Cryptography.HashAlgorithm.TryComputeHash"/> the
/// benchmarks call is non-virtual and always dispatches to the streaming members, so
/// third-party one-shot fast paths (e.g. <c>Blake3.Hasher.Hash(input, output)</c>,
/// which uses recursive subtree or multi-threaded hashing) would otherwise never be
/// exercised. Benchmarks check for this interface and prefer it when present, so each
/// library competes with its best single-call API; implementations without it are
/// measured exactly as before.
/// </remarks>
public interface IOneShotHash
{
    /// <summary>
    /// Computes the hash of <paramref name="source"/> in a single call using the
    /// wrapped library's fastest one-shot API.
    /// </summary>
    /// <param name="source">The input to hash.</param>
    /// <param name="destination">The buffer receiving the hash.</param>
    /// <param name="bytesWritten">The number of bytes written to <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if the destination buffer was large enough; otherwise <see langword="false"/>.</returns>
    bool TryComputeHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten);
}
