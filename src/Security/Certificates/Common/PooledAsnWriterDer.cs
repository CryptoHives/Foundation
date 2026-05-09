// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1024 // Return properties where appropriate.

namespace CryptoHives.Foundation.Security.Certificates;

using System;
using System.Formats.Asn1;

/// <summary>
/// A disposable wrapper for pooled <see cref="AsnWriter"/> instances.
/// The encoding for the pooled writers is <see cref="AsnEncodingRules.DER"/>.
/// </summary>
internal readonly struct PooledAsnWriterDer : IDisposable
{
    private readonly AsnWriter _writer;

    /// <summary>
    /// Creates a new pooled writer wrapper.
    /// </summary>
    private PooledAsnWriterDer(AsnWriter writer)
    {
        _writer = writer;
    }

    /// <summary>
    /// Gets a pooled <see cref="AsnWriter"/> wrapped in a disposable struct.
    /// </summary>
    /// <returns>A disposable wrapper that returns the writer to the pool when disposed.</returns>
    public static PooledAsnWriterDer Get()
    {
        return new PooledAsnWriterDer(AsnWriterPoolDer.Get());
    }

    /// <summary>
    /// Gets the underlying <see cref="AsnWriter"/>.
    /// </summary>
    public AsnWriter Writer => _writer;

    /// <inheritdoc cref="AsnWriter.Encode()"/>
    public byte[] Encode() => _writer.Encode();

    /// <inheritdoc cref="AsnWriter.TryEncode(Span{byte}, out int)"/>
    public bool TryEncode(Span<byte> buffer, out int bytesWritten)
        => _writer.TryEncode(buffer, out bytesWritten);

    /// <summary>
    /// Returns the writer to the pool.
    /// </summary>
    public void Dispose()
    {
        AsnWriterPoolDer.Return(_writer);
    }
}
