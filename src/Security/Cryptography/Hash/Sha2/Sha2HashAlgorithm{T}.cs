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
    private bool _useOsNative;
    private System.Security.Cryptography.HashAlgorithm? _osImpl;

    /// <summary>
    /// The number of words in the state.
    /// </summary>
    public const int StateSizeWords = 8;

    /// <summary>
    /// The maximum chunk size copied into a pooled buffer when feeding data to an OS-native implementation.
    /// </summary>
    private const int OsNativeChunkSizeBytes = 8192;

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
    /// <param name="useOsNative">
    /// <see langword="true"/> to delegate hashing to the OS-native implementation returned by
    /// <see cref="CreateOsNativeInstance"/> instead of this algorithm's managed implementation.
    /// </param>
    protected Sha2HashAlgorithm(bool useOsNative = false)
    {
        _useOsNative = useOsNative;

        // Allocate buffers - block size determined by derived class properties
        _buffer = ArrayPool<byte>.Shared.Rent(BlockSizeBytes);
        _state = ArrayPool<T>.Shared.Rent(StateSizeWords);
        _allocated = true;
        Initialize();
    }

    /// <summary>
    /// When <see cref="_useOsNative"/> is requested, creates the OS-native <see cref="System.Security.Cryptography.HashAlgorithm"/>
    /// instance to delegate hashing to. Returns <see langword="null"/> if this algorithm has no known OS-native
    /// equivalent, in which case the managed implementation is used instead.
    /// </summary>
    protected virtual System.Security.Cryptography.HashAlgorithm? CreateOsNativeInstance() => null;

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public sealed override void Initialize()
    {
        if (!_allocated) throw new ObjectDisposedException(GetType().Name);

        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);

        if (_useOsNative)
        {
            _osImpl ??= CreateOsNativeInstance();
            if (_osImpl is not null)
            {
                _osImpl.Initialize();
                return;
            }

            // Defensive fallback: the Os bit was requested but no OS-native instance is available.
            _useOsNative = false;
        }

        InitializeState();
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
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected sealed override void HashCore(ReadOnlySpan<byte> source)
    {
        if (!_allocated) throw new ObjectDisposedException(GetType().Name);

        if (_useOsNative)
        {
            HashCoreOsNative(source);
            return;
        }

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

    /// <summary>
    /// Feeds <paramref name="source"/> into <see cref="_osImpl"/> via a pooled chunk buffer, since
    /// <see cref="System.Security.Cryptography.HashAlgorithm.TransformBlock"/> requires an array.
    /// </summary>
    private void HashCoreOsNative(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty) return;

        int chunkSize = Math.Min(source.Length, OsNativeChunkSizeBytes);
        byte[] chunk = ArrayPool<byte>.Shared.Rent(chunkSize);
        try
        {
            int offset = 0;
            while (offset < source.Length)
            {
                int length = Math.Min(chunkSize, source.Length - offset);
                source.Slice(offset, length).CopyTo(chunk);
                _osImpl!.TransformBlock(chunk, 0, length, chunk, 0);
                offset += length;
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(chunk, clearArray: true);
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected sealed override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (!_allocated) throw new ObjectDisposedException(GetType().Name);
        if (destination.Length < OutputSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        if (_useOsNative)
        {
            _osImpl!.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
            byte[] hash = _osImpl.Hash!;
            Debug.Assert(hash.Length == OutputSizeBytes, "OS-native hash output size must match OutputSizeBytes.");
            hash.CopyTo(destination);
            bytesWritten = OutputSizeBytes;
            return true;
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

            _osImpl?.Dispose();
            _osImpl = null;
        }
        base.Dispose(disposing);
    }
}
