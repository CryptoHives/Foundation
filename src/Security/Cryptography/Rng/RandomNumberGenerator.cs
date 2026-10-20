// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Rng;

using System;
using System.Buffers;
using OS = System.Security.Cryptography;

/// <summary>
/// Cryptographically strong random bytes from the operating system generator, with the span-based
/// <see cref="Fill(Span{byte})"/> available on every target framework, including those where
/// <see cref="System.Security.Cryptography.RandomNumberGenerator"/> has no span API.
/// </summary>
/// <remarks>
/// It wraps the in-box generator rather than deriving from it, so it cannot be passed where an
/// <see cref="System.Security.Cryptography.RandomNumberGenerator"/> is expected. Importing both
/// namespaces is CS0104; alias one side, e.g. <c>using Bcl = System.Security.Cryptography;</c>.
/// </remarks>
public class RandomNumberGenerator : IDisposable
{
    private OS.RandomNumberGenerator? _rng;
    private static readonly RandomNumberGenerator? _instance = new RandomNumberGenerator();

    private RandomNumberGenerator()
    {
        _rng = OS.RandomNumberGenerator.Create();
    }

    private OS.RandomNumberGenerator Generator => _rng ?? throw new ObjectDisposedException(nameof(RandomNumberGenerator));

    /// <inheritdoc cref="OS.RandomNumberGenerator.Create()"/>
    public static RandomNumberGenerator Create() => new RandomNumberGenerator();

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="OS.RandomNumberGenerator.Dispose(bool)"/>
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
    /// <remarks>
    /// Uses one generator shared by the process, so it needs no instance and is safe to call
    /// from several threads at once.
    /// </remarks>
    /// <param name="data">The span to fill.</param>
    public static void Fill(Span<byte> data) => _instance!.GetBytes(data);

    /// <summary>
    /// Fills the specified array with cryptographically strong random bytes.
    /// </summary>
    /// <remarks>
    /// Uses the same shared generator as <see cref="Fill(Span{byte})"/>.
    /// </remarks>
    /// <param name="data">The array to fill.</param>
    /// <exception cref="ArgumentNullException"><paramref name="data"/> is <see langword="null"/>.</exception>
    public static void Fill(byte[] data) => _instance!.Generator.GetBytes(data);

    /// <inheritdoc cref="OS.RandomNumberGenerator.GetBytes(byte[])"/>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void GetBytes(byte[] data)
    {
        Generator.GetBytes(data);
    }

    /// <inheritdoc cref="OS.RandomNumberGenerator.GetBytes(byte[], int, int)"/>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void GetBytes(byte[] data, int offset, int count)
    {
        Generator.GetBytes(data, offset, count);
    }

    /// <summary>
    /// Fills a span with cryptographically strong random bytes.
    /// </summary>
    /// <remarks>
    /// Before .NET 6 the bytes are generated into a rented <see cref="ArrayPool{T}"/> array, which is
    /// cleared before it goes back to the pool.
    /// </remarks>
    /// <param name="data">The span to fill.</param>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void GetBytes(Span<byte> data)
    {
        OS.RandomNumberGenerator generator = Generator;
#if NET6_0_OR_GREATER
        generator.GetBytes(data);
#else
        byte[] temp = ArrayPool<byte>.Shared.Rent(data.Length);
        try
        {
            generator.GetBytes(temp, 0, data.Length);
            temp.AsSpan(0, data.Length).CopyTo(data);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(temp, clearArray: true);
        }
#endif
    }
}
