// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Rng;

using System;
using System.Buffers;
using Sys = System.Security.Cryptography;

/// <summary>
/// Polyfill for <see cref="System.Security.Cryptography.RandomNumberGenerator"/>.
/// </summary>
public class RandomNumberGenerator : IDisposable
{
    private Sys.RandomNumberGenerator? _rng;
    private static RandomNumberGenerator? _instance = new RandomNumberGenerator();

    private RandomNumberGenerator()
    {
        _rng = Sys.RandomNumberGenerator.Create();
    }

    /// <inheritdoc cref="Sys.RandomNumberGenerator.Create()"/>
    public static RandomNumberGenerator Create() => new RandomNumberGenerator();

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="Sys.RandomNumberGenerator.Dispose(bool)"/>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _rng?.Dispose();
            _rng = null;
        }
    }

    /// <summary>
    /// Fills the specified span with cryptographically strong random bytes.
    /// </summary>
    public static void Fill(Span<byte> data) => _instance!.GetBytes(data);

    /// <summary>
    /// Fills the specified span with cryptographically strong random bytes.
    /// </summary>
    public static void Fill(byte[] data) => _instance!._rng!.GetBytes(data);

    /// <inheritdoc cref="Sys.RandomNumberGenerator.GetBytes(byte[])"/>
    public void GetBytes(byte[] data)
    {
        _rng!.GetBytes(data);
    }

    /// <inheritdoc cref="Sys.RandomNumberGenerator.GetBytes(byte[], int, int)"/>
    public void GetBytes(byte[] data, int offset, int count)
    {
        _rng!.GetBytes(data, offset, count);
    }

    /// <summary>
    /// Fills a span with cryptographically strong random bytes.
    /// </summary>
    public void GetBytes(Span<byte> data)
    {
#if NET6_0_OR_GREATER
        _rng!.GetBytes(data);
#else
        byte[] temp = ArrayPool<byte>.Shared.Rent(data.Length);
        try
        {
            _rng!.GetBytes(temp, 0, data.Length);
            temp.AsSpan(0, data.Length).CopyTo(data);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(temp);
        }
#endif
    }
}
