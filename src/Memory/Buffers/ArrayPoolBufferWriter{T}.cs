// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;
using System.Runtime.CompilerServices;

/// <summary>
/// Helper to build a <see cref="ReadOnlySequence{T}"/> from a set of buffers.
/// Implements <see cref="IBufferWriter{T}"/> interface.
/// </summary>
public sealed class ArrayPoolBufferWriter<T> : IBufferWriter<T>, IDisposable
{
    /// <summary>
    /// The default chunk size.
    /// </summary>
    public static readonly int DefaultChunkSize = 256;

    /// <summary>
    /// The default maximum chunk size.
    /// </summary>
    public static readonly int MaxChunkSize = 65536;

    private static readonly T[] _emptyBuffer = Array.Empty<T>();
    private readonly bool _clearArray;
    private readonly int _maxChunkSize;
    private int _chunkSize;
    private T[] _currentBuffer;
    private ArrayPoolBufferSegment<T>? _firstSegment;
    private ArrayPoolBufferSegment<T>? _nextSegment;
    private int _offset;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    public ArrayPoolBufferWriter()
        : this(false, DefaultChunkSize, MaxChunkSize)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    public ArrayPoolBufferWriter(int defaultChunksize, int maxChunkSize)
        : this(false, defaultChunksize, maxChunkSize)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolBufferWriter{T}"/> class.
    /// </summary>
    public ArrayPoolBufferWriter(bool clearArray, int defaultChunksize, int maxChunkSize)
    {
        _firstSegment = _nextSegment = null;
        _offset = 0;
        _clearArray = clearArray;
        _chunkSize = defaultChunksize;
        _maxChunkSize = maxChunkSize;
        _currentBuffer = _emptyBuffer;
        _disposed = false;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_firstSegment != null)
        {
            ArrayPoolBufferSegment<T>? segment = _firstSegment;
            while (segment != null)
            {
                segment.Return(_clearArray);
                segment = (ArrayPoolBufferSegment<T>?)segment.Next;
            }

            _firstSegment = _nextSegment = null;
        }
        _disposed = true;
    }

    /// <inheritdoc/>
    public void Advance(int count)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), $"{nameof(count)} must be non-negative.");
        if (_offset + count > _currentBuffer.Length) throw new ArgumentOutOfRangeException(nameof(count), $"Cannot advance to {_offset + count} at the end of the buffer, which has a size of {_currentBuffer.Length}.");

        _offset += count;
    }

    /// <inheritdoc/>
    public Memory<T> GetMemory(int sizeHint = 0)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (sizeHint < 0) throw new ArgumentOutOfRangeException(nameof(sizeHint), $"{nameof(sizeHint)} must be non-negative.");

        int remainingSpace = CheckAndAllocateBuffer(sizeHint);
        return _currentBuffer.AsMemory(_offset, remainingSpace);
    }

    /// <inheritdoc/>
    public Span<T> GetSpan(int sizeHint = 0)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));
        if (sizeHint < 0) throw new ArgumentOutOfRangeException(nameof(sizeHint), $"{nameof(sizeHint)} must be non-negative.");

        int remainingSpace = CheckAndAllocateBuffer(sizeHint);
        return _currentBuffer.AsSpan(_offset, remainingSpace);
    }

    /// <summary>
    /// Get a ReadOnlySequence that represents the written data.
    /// The sequence is only valid until the next write operation or
    /// until the writer is disposed.
    /// </summary>
    public ReadOnlySequence<T> GetReadOnlySequence()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(ArrayPoolBufferWriter<T>));

        AddSegment();

        if (_firstSegment == null || _nextSegment == null)
        {
            return ReadOnlySequence<T>.Empty;
        }

        return new ReadOnlySequence<T>(_firstSegment, 0, _nextSegment, _nextSegment.Memory.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AddSegment()
    {
        if (_offset > 0)
        {
            if (_firstSegment == null)
            {
                _firstSegment = _nextSegment = new ArrayPoolBufferSegment<T>(_currentBuffer, 0, _offset);
            }
            else
            {
                _nextSegment = _nextSegment!.Append(_currentBuffer, 0, _offset);
            }
        }
        else if (_currentBuffer.Length > 0)
        {
            ArrayPool<T>.Shared.Return(_currentBuffer, _clearArray);
        }

        _offset = 0;
        _currentBuffer = _emptyBuffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int CheckAndAllocateBuffer(int sizeHint)
    {
        int remainingSpace = _currentBuffer.Length - _offset;
        if (remainingSpace < sizeHint || sizeHint == 0)
        {
            AddSegment();

            remainingSpace = Math.Max(sizeHint, _chunkSize);
            _currentBuffer = ArrayPool<T>.Shared.Rent(remainingSpace);
            _offset = 0;

            if (_chunkSize < _maxChunkSize)
            {
                _chunkSize = Math.Min(_maxChunkSize, _chunkSize * 2);
            }
        }

        return remainingSpace;
    }
}
