// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.IO;

/// <summary>
/// Provides incremental ParallelHash computation.
/// </summary>
public sealed class IncrementalParallelHash : IDisposable
{
    /// <summary>
    /// The default block size in bytes (4 MiB).
    /// </summary>
    public const int DefaultBlockSizeBytes = 0x100_000;

    private readonly MemoryStream _buffer;
    private readonly ShakeType _type;
    private readonly int _blockSizeBytes;
    private readonly byte[] _customization;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="IncrementalParallelHash"/> class.
    /// </summary>
    /// <param name="type">The SHAKE variant used for the ParallelHash construction.</param>
    /// <param name="blockSizeBytes">The block size in bytes.</param>
    /// <param name="customization">Optional customization string S (default: empty).</param>
    public IncrementalParallelHash(ShakeType type = ShakeType.Shake128, int blockSizeBytes = DefaultBlockSizeBytes, ReadOnlySpan<byte> customization = default)
    {
        if (blockSizeBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blockSizeBytes), "Block size must be positive.");
        }

        _type = type;
        _blockSizeBytes = blockSizeBytes;
        _customization = customization.IsEmpty ? Array.Empty<byte>() : customization.ToArray();
        _buffer = new MemoryStream();
    }

    /// <summary>
    /// Absorbs data into the ParallelHash instance.
    /// </summary>
    /// <param name="data">The data to absorb.</param>
    public void Absorb(ReadOnlySpan<byte> data)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        if (!data.IsEmpty)
        {
            byte[] copy = data.ToArray();
            _buffer.Write(copy, 0, copy.Length);
        }
    }

    /// <summary>
    /// Squeezes the final hash output.
    /// </summary>
    /// <param name="output">The span to receive the hash value.</param>
    /// <returns>The output span containing the hash value.</returns>
    public Span<byte> Squeeze(Span<byte> output)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        ReadOnlySpan<byte> input = _buffer.ToArray();
        ParallelHash.ComputeHashCore(output, input, _blockSizeBytes, _type == ShakeType.Shake256, _customization);
        return output;
    }

    /// <summary>
    /// Resets the instance for reuse.
    /// </summary>
    public void Reset()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        _buffer.SetLength(0);
        _buffer.Position = 0;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _buffer.Dispose();
        _isDisposed = true;
    }

    /// <summary>
    /// The SHAKE type used for the hash computation.
    /// </summary>
    public enum ShakeType
    {
        /// <summary>
        /// Use SHAKE128 (128-bit security strength).
        /// </summary>
        Shake128,

        /// <summary>
        /// Use SHAKE256 (256-bit security strength).
        /// </summary>
        Shake256
    }
}
