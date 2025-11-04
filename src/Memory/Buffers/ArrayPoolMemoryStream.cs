// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
#define MEMORYSTREAM_WITH_SPAN_SUPPORT
#endif

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// Class to create a MemoryStream which uses ArrayPool buffers.
/// </summary>
public sealed class ArrayPoolMemoryStream : MemoryStream
{
    /// <summary>
    /// The default buffer size of the allocated array pool buffers.
    /// </summary>
    public static readonly int DefaultBufferSize = 4096;

    /// <summary>
    /// The default list size for the array segments.
    /// </summary>
    public static readonly int DefaultBufferListSize = 8;

    private readonly List<ArraySegment<byte>> _buffers;
    private readonly int _start;
    private readonly int _count;
    private readonly int _bufferSize;
    private readonly bool _externalBuffersReadOnly;
    private int _bufferIndex;
    private ArraySegment<byte> _currentBuffer;
    private int _currentPosition;
    private int _endOfLastBuffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Attaches the stream to read from a enumerable of buffers wrapped in <see cref="ArraySegment{Byte}"/>.
    /// Buffers are not returned to the ArrayPool when the stream is disposed.
    /// </summary>
    public ArrayPoolMemoryStream(IEnumerable<ArraySegment<byte>> buffers)
    {
        _externalBuffersReadOnly = true;
        _buffers = new List<ArraySegment<byte>>(buffers);
        _endOfLastBuffer = 0;

        if (_buffers.Count > 0)
        {
            _endOfLastBuffer = _buffers[^1].Count;
        }

        SetCurrentBuffer(0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that rents ArrayPool buffers as necessary.
    /// </summary>
    /// <param name="bufferListSize">The initial size of the buffer list</param>
    /// <param name="bufferSize">The size of the buffers</param>
    /// <param name="start">The start of the ArraySegment in a buffer</param>
    /// <param name="count">The count of bytes in the ArraySegment that is used in the buffer</param>
    /// <exception cref="ArgumentException"></exception>
    public ArrayPoolMemoryStream(int bufferListSize, int bufferSize, int start, int count)
    {
        if (bufferSize <= 0) throw new ArgumentException("The bufferSize must be larger than zero", nameof(bufferSize));
        if (bufferListSize <= 0) throw new ArgumentException("The initial bufferListSize must be larger than zero", nameof(bufferListSize));
        if (start < 0) throw new ArgumentException("The start of a segment in the buffer must be at least zero", nameof(start));
        if (count <= 0) throw new ArgumentException("The count of bytes in a buffer must be larger than zero", nameof(count));
        if (start + count > bufferSize) throw new ArgumentException("The segment exceeds the size of the buffer");

        _buffers = new List<ArraySegment<byte>>(bufferListSize);
        _bufferSize = bufferSize;
        _start = start;
        _count = count;
        _endOfLastBuffer = 0;
        _externalBuffersReadOnly = false;

        SetCurrentBuffer(0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary using buffer defaults.
    /// </summary>
    public ArrayPoolMemoryStream() :
        this(DefaultBufferListSize, DefaultBufferSize, 0, DefaultBufferSize)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary using buffer list size defaults.
    /// </summary>
    public ArrayPoolMemoryStream(int bufferSize) :
        this(DefaultBufferListSize, bufferSize, 0, bufferSize)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary.
    /// </summary>
    public ArrayPoolMemoryStream(int bufferListSize, int bufferSize) :
        this(bufferListSize, bufferSize, 0, bufferSize)
    { }

    /// <inheritdoc/>
    public override bool CanRead => true;

    /// <inheritdoc/>
    public override bool CanSeek => true;

    /// <inheritdoc/>
    public override bool CanWrite => !_externalBuffersReadOnly;

    /// <inheritdoc/>
    public override long Length => GetAbsoluteLength();

    /// <inheritdoc/>
    public override long Position
    {
        get { return GetAbsolutePosition(); }
        set { Seek(value, SeekOrigin.Begin); }
    }

    /// <inheritdoc/>
    public override void Flush()
    {
        // nothing to do.
    }

    /// <summary>
    /// Returns a <see cref="ReadOnlySequence{Byte}"/> of the buffers stored in the stream.
    /// ReadOnlySequence is only valid as long as the stream is not
    /// disposed and no more data is written.
    /// </summary>
    public ReadOnlySequence<byte> GetReadOnlySequence()
    {
        if (_buffers.Count == 0 || _buffers[0].Array == null)
        {
            return ReadOnlySequence<byte>.Empty;
        }

        int endIndex = GetBufferCount(0);
        if (endIndex == 0)
        {
            return ReadOnlySequence<byte>.Empty;
        }

        var firstSegment = new ArrayPoolBufferSegment<byte>(_buffers[0].Array!, _buffers[0].Offset, endIndex);
        ArrayPoolBufferSegment<byte> nextSegment = firstSegment;
        for (int ii = 1; ii < _buffers.Count; ii++)
        {
            ArraySegment<byte> buffer = _buffers[ii];
            if (buffer.Array != null && endIndex > 0)
            {
                endIndex = GetBufferCount(ii);
                nextSegment = nextSegment.Append(buffer.Array, buffer.Offset, endIndex);
            }
        }

        return new ReadOnlySequence<byte>(firstSegment, 0, nextSegment, endIndex);
    }

    /// <inheritdoc/>
    public override int ReadByte()
    {
        do
        {
            // check for end of stream.
            if (_currentBuffer.Array == null)
            {
                return -1;
            }

            int bytesLeft = GetBufferCount(_bufferIndex) - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft > 0)
            {
                return _currentBuffer.Array[_currentBuffer.Offset + _currentPosition++];
            }

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        } while (true);
    }

#if MEMORYSTREAM_WITH_SPAN_SUPPORT
    /// <inheritdoc/>
    public override int Read(Span<byte> buffer)
#else
    /// <inheritdoc/>
    public int Read(Span<byte> buffer)
#endif
    {
        int count = buffer.Length;
        int offset = 0;
        int bytesRead = 0;

        while (count > 0)
        {
            // check for end of stream.
            if (_currentBuffer.Array == null)
            {
                return bytesRead;
            }

            int bytesLeft = GetBufferCount(_bufferIndex) - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft > count)
            {
                _currentBuffer.AsSpan(_currentPosition, count).CopyTo(buffer.Slice(offset));
                bytesRead += count;
                _currentPosition += count;
                return bytesRead;
            }

            // copy the bytes available and move to next buffer.
            _currentBuffer.AsSpan(_currentPosition, bytesLeft).CopyTo(buffer.Slice(offset));
            bytesRead += bytesLeft;

            offset += bytesLeft;
            count -= bytesLeft;

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        }

        return bytesRead;
    }

    /// <inheritdoc/>
    public override int Read(byte[] buffer, int offset, int count)
    {
        int bytesRead = 0;

        while (count > 0)
        {
            // check for end of stream.
            if (_currentBuffer.Array == null)
            {
                return bytesRead;
            }

            int bytesLeft = GetBufferCount(_bufferIndex) - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft > count)
            {
                Array.Copy(_currentBuffer.Array, _currentPosition + _currentBuffer.Offset, buffer, offset, count);
                bytesRead += count;
                _currentPosition += count;
                return bytesRead;
            }

            // copy the bytes available and move to next buffer.
            Array.Copy(_currentBuffer.Array, _currentPosition + _currentBuffer.Offset, buffer, offset, bytesLeft);
            bytesRead += bytesLeft;

            offset += bytesLeft;
            count -= bytesLeft;

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        }

        return bytesRead;
    }

    /// <inheritdoc/>
    public override long Seek(long offset, SeekOrigin loc)
    {
        switch (loc)
        {
            case SeekOrigin.Begin:
                break;

            case SeekOrigin.Current:
                offset += GetAbsolutePosition();
                break;

            case SeekOrigin.End:
                offset += GetAbsoluteLength();
                break;

            default:
                throw new IOException("Invalid seek origin value.");
        }

        if (offset < 0)
        {
            throw new IOException("Cannot seek beyond the beginning of the stream.");
        }

        // special case
        if (offset == 0)
        {
            SetCurrentBuffer(0);
            return 0;
        }

        int position = (int)offset;

        if (position > GetAbsolutePosition())
        {
            CheckEndOfStream();
        }

        for (int ii = 0; ii < _buffers.Count; ii++)
        {
            int length = GetBufferCount(ii);

            if (offset <= length)
            {
                SetCurrentBuffer(ii);
                _currentPosition = (int)offset;
                return position;
            }

            offset -= length;
        }

        throw new IOException("Cannot seek beyond the end of the stream.");
    }

    /// <inheritdoc/>
    public override void SetLength(long value)
    {
        throw new NotSupportedException();
    }

    /// <inheritdoc/>
    public override void WriteByte(byte value)
    {
        do
        {
            // allocate new buffer if necessary
            CheckEndOfStream();

            int bytesLeft = _currentBuffer.Count - _currentPosition;

            // copy the byte requested.
            if (bytesLeft >= 1)
            {
                _currentBuffer.Array![_currentBuffer.Offset + _currentPosition] = value;
                UpdateCurrentPosition(1);

                return;
            }

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        } while (true);
    }

#if MEMORYSTREAM_WITH_SPAN_SUPPORT
    /// <inheritdoc/>
    public override void Write(ReadOnlySpan<byte> buffer)
#else
    /// <inheritdoc/>
    public void Write(ReadOnlySpan<byte> buffer)
#endif
    {
        int count = buffer.Length;
        int offset = 0;
        while (count > 0)
        {
            // check for end of stream.
            CheckEndOfStream();

            int bytesLeft = _currentBuffer.Count - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft >= count)
            {
                buffer.Slice(offset, count).CopyTo(_currentBuffer.AsSpan(_currentPosition));

                UpdateCurrentPosition(count);

                return;
            }

            // copy the bytes available and move to next buffer.
            buffer.Slice(offset, bytesLeft).CopyTo(_currentBuffer.AsSpan(_currentPosition));

            offset += bytesLeft;
            count -= bytesLeft;

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        }
    }

    /// <inheritdoc/>
    public override void Write(byte[] buffer, int offset, int count)
    {
        while (count > 0)
        {
            // check for end of stream.
            CheckEndOfStream();

            int bytesLeft = _currentBuffer.Count - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft >= count)
            {
                Array.Copy(buffer, offset, _currentBuffer.Array!, _currentPosition + _currentBuffer.Offset, count);

                UpdateCurrentPosition(count);

                return;
            }

            // copy the bytes available and move to next buffer.
            Array.Copy(buffer, offset, _currentBuffer.Array!, _currentPosition + _currentBuffer.Offset, bytesLeft);

            offset += bytesLeft;
            count -= bytesLeft;

            // move to next buffer.
            SetCurrentBuffer(_bufferIndex + 1);
        }
    }

    /// <inheritdoc/>
    public override byte[] ToArray()
    {
        if (_buffers == null) throw new ObjectDisposedException(nameof(ArrayPoolMemoryStream));

        int absoluteLength = GetAbsoluteLength();
        if (absoluteLength == 0)
        {
            return Array.Empty<byte>();
        }

#if NET8_0_OR_GREATER
        byte[] array = GC.AllocateUninitializedArray<byte>(absoluteLength);
#else
        byte[] array = new byte[absoluteLength];
#endif

        int offset = 0;
        foreach (ArraySegment<byte> buffer in _buffers)
        {
            if (buffer.Array != null)
            {
                int length = Math.Min(absoluteLength - offset, buffer.Count);
                Array.Copy(buffer.Array, buffer.Offset, array, offset, length);
                offset += length;
            }
        }

        return array;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing && _buffers != null)
        {
            if (!_externalBuffersReadOnly)
            {
                foreach (ArraySegment<byte> buffer in _buffers)
                {
                    if (buffer.Array != null)
                    {
                        ArrayPool<byte>.Shared.Return(buffer.Array);
                    }
                }
            }

            ClearBuffers();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Update the current buffer count.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void UpdateCurrentPosition(int count)
    {
        _currentPosition += count;

        if (_bufferIndex == (_buffers.Count - 1) &&
            _endOfLastBuffer < _currentPosition)
        {
            _endOfLastBuffer = _currentPosition;
        }
    }

    /// <summary>
    /// Sets the current buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetCurrentBuffer(int index)
    {
        if (index < 0 || index >= _buffers.Count)
        {
            _currentBuffer = default(ArraySegment<byte>);
            _currentPosition = 0;
            return;
        }

        _bufferIndex = index;
        _currentBuffer = _buffers[index];
        _currentPosition = 0;
    }

    /// <summary>
    /// Returns the total length in all buffers.
    /// </summary>
    private int GetAbsoluteLength()
    {
        int length = 0;

        for (int ii = 0; ii < _buffers.Count; ii++)
        {
            length += GetBufferCount(ii);
        }

        return length;
    }

    /// <summary>
    /// Returns the current position.
    /// </summary>
    private int GetAbsolutePosition()
    {
        // check if at end of stream.
        if (_currentBuffer.Array == null)
        {
            return GetAbsoluteLength();
        }

        // calculate position.
        int position = 0;

        for (int ii = 0; ii < _bufferIndex; ii++)
        {
            position += GetBufferCount(ii);
        }

        position += _currentPosition;

        return position;
    }

    /// <summary>
    /// Returns the number of bytes used in the buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetBufferCount(int index)
    {
        if (index == _buffers.Count - 1)
        {
            return _endOfLastBuffer;
        }

        return _buffers[index].Count;
    }

    /// <summary>
    /// Check if end of stream is reached and take new buffer if necessary.
    /// </summary>
    /// <exception cref="IOException">Throws if end of stream is reached.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void CheckEndOfStream()
    {
        // check for end of stream.
        if (_currentBuffer.Array == null)
        {
            byte[] newBuffer = ArrayPool<byte>.Shared.Rent(_bufferSize);
            _buffers.Add(new ArraySegment<byte>(newBuffer, _start, _count));
            _endOfLastBuffer = 0;

            SetCurrentBuffer(_buffers.Count - 1);
        }
    }

    /// <summary>
    /// Clears the buffers and resets the state variables.
    /// </summary>
    private void ClearBuffers()
    {
        _buffers.Clear();
        _bufferIndex = 0;
        _endOfLastBuffer = 0;
        SetCurrentBuffer(0);
    }
}
