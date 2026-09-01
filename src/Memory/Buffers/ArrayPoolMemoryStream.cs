// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1725 // Change names of parameters to match base declaration

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
#define MEMORYSTREAM_WITH_SPAN_SUPPORT
#endif

namespace CryptoHives.Foundation.Memory.Buffers;

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
    private readonly List<ArraySegment<byte>> _buffers;
    private readonly int _start;
    private readonly int _count;
    private readonly int _bufferSize;
    private readonly bool _externalBuffersReadOnly;
    private readonly bool _clearArray;
    private int _bufferIndex;
    private ArraySegment<byte> _currentBuffer;
    private int _currentPosition;
    private int _endOfLastBuffer;

    /// <summary>
    /// The default buffer size of the allocated array pool buffers.
    /// </summary>
    public static readonly int DefaultBufferSize = 4096;

    /// <summary>
    /// The default list size for the array segments.
    /// </summary>
    public static readonly int DefaultBufferListSize = 8;

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
    /// <param name="clearArray">
    /// Whether each buffer is zeroed as it goes back to the <see cref="ArrayPool{T}"/>, so the next
    /// renter cannot read what this stream wrote. Set it when the stream carries key material or
    /// other secrets; the cost is one <c>Array.Clear</c> per buffer at disposal.
    /// </param>
    /// <exception cref="ArgumentException"></exception>
    public ArrayPoolMemoryStream(int bufferListSize, int bufferSize, int start, int count, bool clearArray = false)
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
        _clearArray = clearArray;

        SetCurrentBuffer(0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary using buffer defaults.
    /// </summary>
    public ArrayPoolMemoryStream() :
        this(DefaultBufferListSize, DefaultBufferSize, 0, DefaultBufferSize, false)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream using buffer defaults, choosing whether buffers are zeroed as they
    /// return to the <see cref="ArrayPool{T}"/>.
    /// </summary>
    /// <param name="clearArray">
    /// Whether each buffer is zeroed as it goes back to the <see cref="ArrayPool{T}"/>, so the next
    /// renter cannot read what this stream wrote.
    /// </param>
    public ArrayPoolMemoryStream(bool clearArray) :
        this(DefaultBufferListSize, DefaultBufferSize, 0, DefaultBufferSize, clearArray)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary using buffer list size defaults.
    /// </summary>
    /// <param name="bufferSize">The size of the buffers</param>
    /// <param name="clearArray">
    /// Whether each buffer is zeroed as it goes back to the <see cref="ArrayPool{T}"/>, so the next
    /// renter cannot read what this stream wrote.
    /// </param>
    public ArrayPoolMemoryStream(int bufferSize, bool clearArray = false) :
        this(DefaultBufferListSize, bufferSize, 0, bufferSize, clearArray)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArrayPoolMemoryStream"/> class.
    /// Creates a writeable stream that creates buffers as necessary.
    /// </summary>
    /// <param name="bufferListSize">The initial size of the buffer list</param>
    /// <param name="bufferSize">The size of the buffers</param>
    /// <param name="clearArray">
    /// Whether each buffer is zeroed as it goes back to the <see cref="ArrayPool{T}"/>, so the next
    /// renter cannot read what this stream wrote.
    /// </param>
    public ArrayPoolMemoryStream(int bufferListSize, int bufferSize, bool clearArray = false) :
        this(bufferListSize, bufferSize, 0, bufferSize, clearArray)
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
        get => GetAbsolutePosition();
        set => Seek(value, SeekOrigin.Begin);
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
    /// <remarks>
    /// The sequence borrows the stream's buffers; it does not own them. Use
    /// <see cref="LeaseSequence"/> when the payload has to leave the scope that built it.
    /// </remarks>
    public ReadOnlySequence<byte> GetReadOnlySequence()
        => BuildSequence();

    /// <summary>
    /// Pairs the stream's payload with the stream itself as a single disposable value, so the payload
    /// can leave the scope that produced it.
    /// </summary>
    /// <returns>
    /// A <see cref="SequenceLease{Byte}"/> over the payload. Disposing it disposes this stream, which
    /// returns its buffers to the array pool.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The lease is a struct, so this costs only the segment chain that
    /// <see cref="GetReadOnlySequence"/> builds — nothing beyond what reading the payload would cost
    /// anyway.
    /// </para>
    /// <code>
    ///     using SequenceLease&lt;byte&gt; payload = stream.LeaseSequence();
    ///     Send(payload.Sequence);
    /// </code>
    /// <para>
    /// Do not write to the stream after leasing: that invalidates the leased sequence exactly as it
    /// would one from <see cref="GetReadOnlySequence"/>.
    /// </para>
    /// </remarks>
    public SequenceLease<byte> LeaseSequence()
        => new(GetReadOnlySequence(), this);

    /// <summary>
    /// Builds the segment chain spanning the payload.
    /// </summary>
    private ReadOnlySequence<byte> BuildSequence()
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

        var head = new ArrayPoolBufferSegment<byte>(_buffers[0].Array!, _buffers[0].Offset, endIndex);
        ArrayPoolBufferSegment<byte> nextSegment = head;

        for (int ii = 1; ii < _buffers.Count; ii++)
        {
            ArraySegment<byte> buffer = _buffers[ii];
            if (buffer.Array != null && endIndex > 0)
            {
                endIndex = GetBufferCount(ii);
                nextSegment = nextSegment.Append(buffer.Array, buffer.Offset, endIndex);
            }
        }

        return new ReadOnlySequence<byte>(head, 0, nextSegment, endIndex);
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
    public override int Read(Span<byte> destination)
#else
    /// <inheritdoc/>
    public int Read(Span<byte> destination)
#endif
    {
        int count = destination.Length;
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
                _currentBuffer.AsSpan(_currentPosition, count).CopyTo(destination.Slice(offset));
                bytesRead += count;
                _currentPosition += count;
                return bytesRead;
            }

            // copy the bytes available and move to next buffer.
            _currentBuffer.AsSpan(_currentPosition, bytesLeft).CopyTo(destination.Slice(offset));
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

#if !NET7_0_OR_GREATER
    /// <summary>
    /// Reads bytes from the current stream and advances the position within the stream until
    /// the <paramref name="buffer"/> is filled.
    /// </summary>
    /// <param name="buffer">A region of memory. When this method returns, the contents of this region
    /// are replaced by the bytes read from the current stream.</param>
    /// <exception cref="EndOfStreamException">
    /// The end of the stream is reached before filling the <paramref name="buffer"/>.
    /// </exception>
    public void ReadExactly(Span<byte> buffer)
    {
        int offset = 0;
        while (offset < buffer.Length)
        {
            int read = Read(buffer.Slice(offset));
            if (read == 0) throw new EndOfStreamException();
            offset += read;
        }
    }

    /// <summary>
    /// Reads <paramref name="count"/> bytes from the current stream and advances the position
    /// within the stream.
    /// </summary>
    /// <param name="buffer">
    /// An array of bytes. When this method returns, the buffer contains the specified byte array
    /// with the values between <paramref name="offset"/> and
    /// (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read
    /// from the current source.
    /// </param>
    /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin storing
    /// the data read from the current stream.</param>
    /// <param name="count">The number of bytes to be read from the current stream.</param>
    /// <exception cref="EndOfStreamException">
    /// The end of the stream is reached before reading <paramref name="count"/> bytes.
    /// </exception>
    public void ReadExactly(byte[] buffer, int offset, int count)
    {
        int totalRead = 0;
        while (totalRead < count)
        {
            int read = Read(buffer, offset + totalRead, count - totalRead);
            if (read == 0) throw new EndOfStreamException();
            totalRead += read;
        }
    }
#endif

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

        if (offset < 0) throw new IOException("Cannot seek beyond the beginning of the stream.");

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

    /// <summary>
    /// Not supported: the stream is backed by a list of pooled segments, so there is no single
    /// contiguous array to hand out.
    /// </summary>
    /// <remarks>
    /// Use <see cref="GetReadOnlySequence"/> for a borrowed view of the payload, or
    /// <see cref="LeaseSequence"/> to carry it past this scope. The base implementation is
    /// overridden because it would otherwise return the unused array of the <see cref="MemoryStream"/>
    /// this type derives from, silently reporting an empty payload.
    /// </remarks>
    /// <exception cref="NotSupportedException">Always.</exception>
    public override byte[] GetBuffer()
        => throw new NotSupportedException(
            "ArrayPoolMemoryStream is backed by multiple pooled segments and cannot expose a single buffer. Use GetReadOnlySequence() or LeaseSequence().");

    /// <summary>
    /// Always fails: the payload may span several pooled segments, and a segment handed out here
    /// would be returned to the pool when the stream is disposed.
    /// </summary>
    /// <param name="buffer">Always set to the default value.</param>
    /// <returns>Always <see langword="false"/>.</returns>
    /// <remarks>
    /// Overridden for the same reason as <see cref="GetBuffer"/>: the inherited implementation
    /// reports success with an empty segment. Use <see cref="GetReadOnlySequence"/> or
    /// <see cref="LeaseSequence"/> instead.
    /// </remarks>
    public override bool TryGetBuffer(out ArraySegment<byte> buffer)
    {
        buffer = default;
        return false;
    }

    /// <summary>
    /// Gets the total capacity of the rented segments, in bytes.
    /// </summary>
    /// <remarks>
    /// This is the space available before another segment is rented, not the payload length; use
    /// <see cref="Length"/> for that. The inherited implementation would report the capacity of the
    /// unused base-class array, which is always zero.
    /// </remarks>
    /// <exception cref="NotSupportedException">On set. Capacity grows automatically as data is written.</exception>
    public override int Capacity
    {
        get
        {
            int capacity = 0;
            for (int ii = 0; ii < _buffers.Count; ii++)
            {
                capacity += _buffers[ii].Count;
            }

            return capacity;
        }

        set => throw new NotSupportedException(
            "ArrayPoolMemoryStream rents segments on demand; its capacity cannot be set.");
    }

    /// <summary>
    /// Writes the entire payload to <paramref name="stream"/>, one pooled segment at a time.
    /// </summary>
    /// <param name="stream">The destination stream.</param>
    /// <remarks>
    /// Overridden because the inherited implementation writes the unused base-class array, i.e.
    /// nothing at all. The read cursor is not affected.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="stream"/> is <see langword="null"/>.</exception>
    public override void WriteTo(Stream stream)
    {
        if (stream == null) throw new ArgumentNullException(nameof(stream));

        for (int ii = 0; ii < _buffers.Count; ii++)
        {
            ArraySegment<byte> buffer = _buffers[ii];
            int count = GetBufferCount(ii);
            if (buffer.Array != null && count > 0)
            {
                stream.Write(buffer.Array, buffer.Offset, count);
            }
        }
    }

    /// <summary>
    /// Sets the length of the stream, renting or returning pooled segments as needed.
    /// </summary>
    /// <param name="value">The desired length in bytes.</param>
    /// <remarks>
    /// Truncating returns the segments that fall away to the pool and keeps the rest, which is what
    /// makes <c>SetLength(0)</c> a cheap way to reuse the stream for another payload. Growing appends
    /// zeroed bytes, since a rented array carries whatever the previous tenant left in it. As with
    /// <see cref="MemoryStream"/>, a position past the new end is pulled back to it.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is negative or exceeds <see cref="int.MaxValue"/>.</exception>
    /// <exception cref="NotSupportedException">The stream wraps externally owned buffers and is read-only.</exception>
    public override void SetLength(long value)
    {
        if (value < 0 || value > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(value));
        if (_externalBuffersReadOnly) throw new NotSupportedException("The stream wraps externally owned buffers and is read-only.");

        int target = (int)value;
        int current = GetAbsoluteLength();

        // Both helpers move the cursor as they work, so remember where the caller left it.
        int position = GetAbsolutePosition();

        if (target < current)
        {
            Truncate(target);
        }
        else if (target > current)
        {
            Grow(current, target);
        }

        // Match MemoryStream: the position is preserved, except that one past the new end is
        // pulled back to it.
        Seek(position < target ? position : target, SeekOrigin.Begin);
    }

    /// <summary>
    /// Drops the payload back to <paramref name="target"/> bytes, returning whole segments that are
    /// no longer needed to the pool.
    /// </summary>
    private void Truncate(int target)
    {
        // Find the segment holding the new end. Every segment before the last is full by
        // construction, so a running total over the used counts locates it.
        int keep = 0;
        int consumed = 0;
        while (keep < _buffers.Count)
        {
            int count = GetBufferCount(keep);
            if (consumed + count >= target)
            {
                break;
            }

            consumed += count;
            keep++;
        }

        // Everything past the segment we land in goes back to the pool.
        for (int ii = _buffers.Count - 1; ii > keep; ii--)
        {
            byte[]? array = _buffers[ii].Array;
            if (array != null)
            {
                ArrayPool<byte>.Shared.Return(array, _clearArray);
            }

            _buffers.RemoveAt(ii);
        }

        if (_buffers.Count == 0)
        {
            ClearBuffers();
            return;
        }

        _endOfLastBuffer = target - consumed;
        SetCurrentBuffer(0);
    }

    /// <summary>
    /// Extends the payload from <paramref name="current"/> to <paramref name="target"/> bytes with
    /// zeros, renting further segments as required.
    /// </summary>
    private void Grow(int current, int target)
    {
        Seek(current, SeekOrigin.Begin);

        int remaining = target - current;
        while (remaining > 0)
        {
            CheckEndOfStream();

            int room = _currentBuffer.Count - _currentPosition;
            int chunk = remaining < room ? remaining : room;

            // A pooled array is not cleared on rent, so the new tail has to be zeroed explicitly.
            Array.Clear(_currentBuffer.Array!, _currentBuffer.Offset + _currentPosition, chunk);

            _currentPosition += chunk;
            remaining -= chunk;

            if (_bufferIndex == _buffers.Count - 1 && _currentPosition > _endOfLastBuffer)
            {
                _endOfLastBuffer = _currentPosition;
            }

            if (_currentPosition >= _currentBuffer.Count)
            {
                SetCurrentBuffer(_bufferIndex + 1);
            }
        }
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
    public override void Write(ReadOnlySpan<byte> destination)
#else
    /// <inheritdoc/>
    public void Write(ReadOnlySpan<byte> destination)
#endif
    {
        int count = destination.Length;
        int offset = 0;
        while (count > 0)
        {
            // check for end of stream.
            CheckEndOfStream();

            int bytesLeft = _currentBuffer.Count - _currentPosition;

            // copy the bytes requested.
            if (bytesLeft >= count)
            {
                destination.Slice(offset, count).CopyTo(_currentBuffer.AsSpan(_currentPosition));

                UpdateCurrentPosition(count);

                return;
            }

            // copy the bytes available and move to next buffer.
            destination.Slice(offset, bytesLeft).CopyTo(_currentBuffer.AsSpan(_currentPosition));

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

    /// <summary>
    /// Attempts to copy the stream content into the provided destination span.
    /// Returns true on success, false if the destination is too small.
    /// </summary>
    /// <param name="destination">The destination span that receives the stream content.</param>
    /// <param name="bytesWritten">When this method returns, contains the number of bytes written to <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if the content was copied; otherwise <see langword="false"/>.</returns>
    public bool TryCopyTo(Span<byte> destination, out int bytesWritten)
    {
        int absoluteLength = GetAbsoluteLength();

        if (destination.Length < absoluteLength)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = absoluteLength;

        int offset = 0;
        foreach (ArraySegment<byte> buffer in _buffers)
        {
            if (buffer.Array != null)
            {
                int length = Math.Min(absoluteLength - offset, buffer.Count);
                new ReadOnlySpan<byte>(buffer.Array, buffer.Offset, length).CopyTo(destination.Slice(offset));
                offset += length;
                if (offset >= absoluteLength)
                {
                    break;
                }
            }
        }
        return true;
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
                        ArrayPool<byte>.Shared.Return(buffer.Array, _clearArray);
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
