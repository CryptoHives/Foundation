// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1024 // Return properties where appropriate.

namespace CryptoHives.Foundation.Security.Certificates;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Formats.Asn1;

/// <summary>
/// Provides a pool of <see cref="AsnWriter"/> instances to reduce allocations.
/// The encoding for the pooled writers is <see cref="AsnEncodingRules.DER"/>.
/// </summary>
public static class AsnWriterPoolDer
{
    /// <summary>
    /// The shared pool of AsnWriter instances using DER encoding.
    /// </summary>
    private static readonly ObjectPool<AsnWriter> s_derWriterPool =
        new DefaultObjectPool<AsnWriter>(new AsnWriterPooledObjectPolicy(AsnEncodingRules.DER));

    /// <summary>
    /// Gets an <see cref="AsnWriter"/> from the pool with DER encoding rules.
    /// The caller is responsible for returning the writer to the pool.
    /// </summary>
    /// <returns>A pooled AsnWriter instance.</returns>
    public static AsnWriter Get() => s_derWriterPool.Get();

    /// <summary>
    /// Returns an <see cref="AsnWriter"/> to the pool after resetting it.
    /// </summary>
    /// <param name="writer">The writer to return to the pool.</param>
    public static void Return(AsnWriter writer)
    {
        if (writer != null)
        {
            writer.Reset();
            s_derWriterPool.Return(writer);
        }
    }

    /// <summary>
    /// Encodes the data from the writer and returns the writer to the pool.
    /// </summary>
    /// <param name="writer">The writer to encode and return.</param>
    /// <returns>The encoded byte array.</returns>
    public static byte[] EncodeAndReturn(AsnWriter writer)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        try
        {
            return writer.Encode();
        }
        finally
        {
            Return(writer);
        }
    }

    /// <summary>
    /// Encodes the data from the writer and returns the writer to the pool.
    /// <see cref="AsnWriter.TryEncode(Span{byte}, out int)"/> for the underlying ASN writer API.
    /// </summary>
    /// <param name="writer">The writer to encode and return.</param>
    /// <param name="buffer">The buffer to which the encoded data is written.</param>
    /// <param name="bytesWritten">The number</param>
    /// <returns>The encoded byte array.</returns>
    public static bool TryEncodeAndReturn(AsnWriter writer, Span<byte> buffer, out int bytesWritten)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        if (writer.TryEncode(buffer, out bytesWritten))
        {
            Return(writer);
            return true;
        }
        return false;
    }

    /// <summary>
    /// A pooled object policy for <see cref="AsnWriter"/>.
    /// </summary>
    private sealed class AsnWriterPooledObjectPolicy : PooledObjectPolicy<AsnWriter>
    {
        private readonly AsnEncodingRules _encodingRules;

        public AsnWriterPooledObjectPolicy(AsnEncodingRules encodingRules)
        {
            _encodingRules = encodingRules;
        }

        public override AsnWriter Create()
        {
            return new AsnWriter(_encodingRules);
        }

        public override bool Return(AsnWriter obj)
        {
            // Reset the writer for reuse
            obj.Reset();
            return true;
        }
    }
}

