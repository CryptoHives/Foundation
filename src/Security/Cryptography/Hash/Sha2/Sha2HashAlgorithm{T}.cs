// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1819 // Properties should not return arrays

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Diagnostics;

/// <summary>
/// Base class for SHA-2 family hash algorithms, providing common buffering and padding logic.
/// </summary>
/// <typeparam name="T">The word type (uint for SHA-256 family, ulong for SHA-512 family).</typeparam>
/// <remarks>
/// This base class eliminates code duplication across SHA-2 variants by providing common
/// implementations of HashCore, TryHashFinal, and Dispose. Derived classes only need to
/// provide initialization values, block processing, and output formatting.
/// </remarks>
public abstract class Sha2HashAlgorithm<T> : HashAlgorithm
    where T : struct
{
    private protected readonly T[] _state;
    private readonly byte[] _buffer;
    private long _bytesProcessed;
    private int _bufferLength;
    private bool _allocated;

    /// <summary>
    /// The number of words in the state.
    /// </summary>
    public const int StateSizeWords = 8;

    /// <summary>
    /// Gets the block size in bytes for this algorithm.
    /// </summary>
    protected abstract int BlockSizeBytes { get; }

    /// <summary>
    /// Gets the hash output size in bytes.
    /// </summary>
    protected abstract int OutputSizeBytes { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sha2HashAlgorithm{TWord}"/> class.
    /// </summary>
    protected Sha2HashAlgorithm()
    {
        // Allocate buffers - block size determined by derived class properties
        _buffer = ArrayPool<byte>.Shared.Rent(BlockSizeBytes);
        _state = ArrayPool<T>.Shared.Rent(StateSizeWords);
        _allocated = true;
        Initialize();
    }

    /// <inheritdoc/>
    public sealed override void Initialize()
    {
        InitializeState();
        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);
    }

    /// <summary>
    /// Initializes the hash state with algorithm-specific initial values.
    /// </summary>
    protected abstract void InitializeState();

    /// <summary>
    /// Processes a single block, updating the state.
    /// </summary>
    /// <param name="block">The block data to process.</param>
    /// <param name="state">The state array to update.</param>
    protected abstract void ProcessBlock(ReadOnlySpan<byte> block, Span<T> state);

    /// <summary>
    /// Pads and finalizes the hash computation.
    /// </summary>
    /// <param name="buffer">The buffer containing remaining unprocessed bytes.</param>
    /// <param name="bufferLength">The number of valid bytes in the buffer.</param>
    /// <param name="bytesProcessed">Total bytes processed before this finalization.</param>
    /// <param name="state">The state array to update.</param>
    protected abstract void PadAndFinalize(Span<byte> buffer, int bufferLength, long bytesProcessed, Span<T> state);

    /// <summary>
    /// Writes the final hash output from the state to the destination.
    /// </summary>
    /// <param name="destination">The destination span for the hash output.</param>
    /// <param name="state">The state array containing the hash values.</param>
    protected abstract void OutputHash(Span<byte> destination, T[] state);

    /// <inheritdoc/>
    protected sealed override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have leftover data in the buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                ProcessBlock(_buffer, _state);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes), _state);
            _bytesProcessed += BlockSizeBytes;
            offset += BlockSizeBytes;
        }

        // Store remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected sealed override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < OutputSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        PadAndFinalize(_buffer, _bufferLength, _bytesProcessed, _state);
        OutputHash(destination, _state);

        bytesWritten = OutputSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected sealed override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_allocated)
            {
                ArrayPool<byte>.Shared.Return(_buffer, clearArray: true);
                ArrayPool<T>.Shared.Return(_state, clearArray: true);
                _allocated = false;
            }
        }
        base.Dispose(disposing);
    }
}
