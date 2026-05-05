// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates;

using System;
using System.Formats.Asn1;
using Microsoft.Extensions.ObjectPool;

/// <summary>
/// Provides a pool of <see cref="AsnWriter"/> instances to reduce allocations.
/// </summary>
internal static class AsnWriterPool
{
    /// <summary>
    /// The shared pool of AsnWriter instances using DER encoding.
    /// </summary>
    private static readonly ObjectPool<AsnWriter> s_derWriterPool =
        new DefaultObjectPool<AsnWriter>(new AsnWriterPooledObjectPolicy(AsnEncodingRules.DER));

    /// <summary>
    /// Gets an <see cref="AsnWriter"/> from the pool with DER encoding rules.
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
        byte[] result = writer.Encode();
        Return(writer);
        return result;
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

/// <summary>
/// A disposable wrapper for pooled <see cref="AsnWriter"/> instances.
/// </summary>
internal readonly struct PooledAsnWriter : IDisposable
{
    private readonly AsnWriter _writer;

    /// <summary>
    /// Creates a new pooled writer wrapper.
    /// </summary>
    private PooledAsnWriter(AsnWriter writer)
    {
        _writer = writer;
    }

    /// <summary>
    /// Gets a pooled <see cref="AsnWriter"/> wrapped in a disposable struct.
    /// </summary>
    /// <returns>A disposable wrapper that returns the writer to the pool when disposed.</returns>
    public static PooledAsnWriter Get()
    {
        return new PooledAsnWriter(AsnWriterPool.Get());
    }

    /// <summary>
    /// Gets the underlying <see cref="AsnWriter"/>.
    /// </summary>
    public AsnWriter Writer => _writer;

    /// <summary>
    /// Encodes the data from the writer.
    /// </summary>
    /// <returns>The encoded byte array.</returns>
    public byte[] Encode() => _writer.Encode();

    /// <summary>
    /// Returns the writer to the pool.
    /// </summary>
    public void Dispose()
    {
        AsnWriterPool.Return(_writer);
    }
}
