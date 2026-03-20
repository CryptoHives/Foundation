// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1725 // Change names of parameters to match base declaration

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
#define MEMORYSTREAM_WITH_SPAN_SUPPORT
#endif

namespace CryptoHives.Foundation.Memory.Buffers;

using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// Class to create a read only MemoryStream which uses
/// a <see cref="ReadOnlySequence{Byte}"/> as the buffer source.
/// </summary>
public sealed class ReadOnlySequenceMemoryStream : MemoryStream
{
    private readonly ReadOnlySequence<byte> _sequence;
    private SequencePosition _nextSequencePosition;
    private ReadOnlyMemory<byte> _currentBuffer;
    private long _sequenceOffset;
    private int _currentOffset;
    private bool _endOfSequence;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlySequenceMemoryStream"/> class.
    /// </summary>
    public ReadOnlySequenceMemoryStream(ReadOnlySequence<byte> sequence)
    {
        _sequence = sequence;
        _nextSequencePosition = _sequence.GetPosition(0);
        _endOfSequence = SetNextBuffer();
    }

    /// <inheritdoc/>
    public override bool CanRead => true;

    /// <inheritdoc/>
    public override bool CanSeek => true;

    /// <inheritdoc/>
    public override bool CanWrite => false;

    /// <inheritdoc/>
    public override long Length => _sequence.Length;

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

    /// <inheritdoc/>
    public override int ReadByte()
    {
        do
        {
            int bytesLeft = _currentBuffer.Length - _currentOffset;

            // copy the bytes requested.
            if (bytesLeft > 0)
            {
                return _currentBuffer.Span[_currentOffset++];
            }

            // move to next buffer.
            if (SetNextBuffer())
            {
                // end of stream.
                return -1;
            }

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
            int bytesLeft = _currentBuffer.Length - _currentOffset;
            int bytesToCopy = Math.Min(bytesLeft, count);

            // move to next buffer.
            if (bytesToCopy <= 0)
            {
                if (SetNextBuffer())
                {
                    return bytesRead;
                }

                continue;
            }

            // copy the bytes requested.
            _currentBuffer.Span.Slice(_currentOffset, bytesToCopy).CopyTo(destination.Slice(offset));
            _currentOffset += bytesToCopy;
            bytesRead += bytesToCopy;
            offset += bytesToCopy;
            count -= bytesToCopy;
        }

        return bytesRead;
    }

    /// <inheritdoc/>
    public override int Read(byte[] buffer, int offset, int count)
    {
        int bytesRead = 0;

        while (count > 0)
        {
            int bytesLeft = _currentBuffer.Length - _currentOffset;
            int bytesToCopy = Math.Min(bytesLeft, count);

            // move to next buffer.
            if (bytesToCopy <= 0)
            {
                if (SetNextBuffer())
                {
                    return bytesRead;
                }

                continue;
            }

            // copy the bytes requested.
            _currentBuffer.Slice(_currentOffset, bytesToCopy).CopyTo(buffer.AsMemory(offset));
            _currentOffset += bytesToCopy;
            bytesRead += bytesToCopy;
            offset += bytesToCopy;
            count -= bytesToCopy;
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

#if !MEMORYSTREAM_WITH_SPAN_SUPPORT
    /// <inheritdoc/>
    public void Write(ReadOnlySpan<byte> buffer)
    {
        throw new NotSupportedException("Writing to a ReadOnlySequence is not supported.");
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
                offset += _sequence.Length;
                break;

            default:
                throw new IOException("Invalid seek origin value.");
        }

        if (offset < 0) throw new IOException("Cannot seek beyond the beginning of the stream.");

        // special case
        if (offset > _sequence.Length) throw new IOException("Cannot seek beyond the end of the stream.");

        if (!SetCurrentBuffer(offset)) throw new IOException("Cannot seek beyond the end of the stream.");

        return GetAbsolutePosition();
    }

    /// <inheritdoc/>
    public override void SetLength(long value) => throw new NotSupportedException();

    /// <inheritdoc/>
    public override byte[] ToArray() => _sequence.ToArray();

    /// <summary>
    /// Sets the current buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool SetNextBuffer()
    {
        _sequenceOffset += _currentBuffer.Length;
        _currentOffset = 0;
        _endOfSequence = !_sequence.TryGet(ref _nextSequencePosition, out _currentBuffer, advance: true);

        if (_endOfSequence)
        {
            _sequenceOffset = _sequence.Length;
        }

        return _endOfSequence;
    }

    /// <summary>
    /// Sets the current buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool SetCurrentBuffer(long offset)
    {
        _nextSequencePosition = _sequence.GetPosition(offset);
        _sequenceOffset = offset;
        _currentOffset = 0;
        _endOfSequence = !_sequence.TryGet(ref _nextSequencePosition, out _currentBuffer, advance: true);

        if (_endOfSequence)
        {
            _sequenceOffset = _sequence.Length;
            _currentOffset = 0;
            return offset == _sequence.Length;
        }
        return true;
    }

    /// <summary>
    /// Returns the current position.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private long GetAbsolutePosition()
    {
        return _endOfSequence ? _sequence.Length : _currentOffset + _sequenceOffset;
    }

}
