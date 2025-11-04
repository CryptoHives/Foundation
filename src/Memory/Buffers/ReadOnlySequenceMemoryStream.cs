// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
#define MEMORYSTREAM_WITH_SPAN_SUPPORT
#endif

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;
using System.Diagnostics;
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
        _nextSequencePosition = sequence.GetPosition(0);
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
            _currentBuffer.Span.Slice(_currentOffset, bytesToCopy).CopyTo(buffer.Slice(offset));
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

#if !MEMORYSTREAM_WITH_SPAN_SUPPORT
    /// <inheritdoc/>
    public void Write(ReadOnlySpan<byte> buffer)
    {
        throw new NotSupportedException();
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

        _nextSequencePosition = _sequence.GetPosition(offset);

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
#if NET8_0_OR_GREATER
        _sequenceOffset = _sequence.GetOffset(_nextSequencePosition);
#else
        _sequenceOffset = GetOffset(_nextSequencePosition);
#endif
        _currentOffset = 0;
        _endOfSequence = !_sequence.TryGet(ref _nextSequencePosition, out _currentBuffer, advance: true);
        return _endOfSequence;
    }

    /// <summary>
    /// Sets the current buffer.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool SetCurrentBuffer(long offset)
    {
        _nextSequencePosition = _sequence.GetPosition(offset);
#if NET8_0_OR_GREATER
        _sequenceOffset = _sequence.GetOffset(_nextSequencePosition);
#else
        _sequenceOffset = GetOffset(_nextSequencePosition);
#endif
        _endOfSequence = !_sequence.TryGet(ref _nextSequencePosition, out _currentBuffer, advance: true);
        long currentOffset = offset - _sequenceOffset;
        if (currentOffset < 0 || (currentOffset >= _currentBuffer.Length && currentOffset > 0))
        {
            return false;
        }

        _currentOffset = (int)currentOffset;
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

#if !NET8_0_OR_GREATER
    /// <summary>
    /// Returns the offset of a <paramref name="position" /> within this sequence from the start.
    /// </summary>
    /// <param name="position">The <see cref="System.SequencePosition"/> of which to get the offset.</param>
    /// <returns>The offset from the start of the sequence.</returns>
    /// <exception cref="System.ArgumentOutOfRangeException">The position is out of range.</exception>
    private long GetOffset(SequencePosition position)
    {
        object? positionSequenceObject = position.GetObject();
        bool positionIsNull = positionSequenceObject == null;
        // TODO: Implement a BoundsCheck for SequencePosition
        //BoundsCheck(position, !positionIsNull);

        object? startObject = _sequence.Start.GetObject();
        object? endObject = _sequence.End.GetObject();

        uint positionIndex = (uint)position.GetInteger();

        // if sequence object is null we suppose start segment
        if (positionIsNull)
        {
            positionSequenceObject = _sequence.Start.GetObject();
            positionIndex = (uint)_sequence.Start.GetInteger();
        }

        // Single-Segment Sequence
        if (startObject == endObject)
        {
            return positionIndex;
        }
        else
        {
            // Verify position validity, this is not covered by BoundsCheck for Multi-Segment Sequence
            // BoundsCheck for Multi-Segment Sequence check only validity inside current sequence but not for SequencePosition validity.
            // For single segment position bound check is implicit.
            Debug.Assert(positionSequenceObject != null);

            if (((ReadOnlySequenceSegment<byte>)positionSequenceObject!).Memory.Length - positionIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Multi-Segment Sequence
            ReadOnlySequenceSegment<byte>? currentSegment = (ReadOnlySequenceSegment<byte>?)startObject;
            while (currentSegment != null && currentSegment != positionSequenceObject)
            {
                currentSegment = currentSegment.Next!;
            }

            // Hit the end of the segments but didn't find the segment
            if (currentSegment is null)
            {
                throw new ArgumentOutOfRangeException();
            }

            Debug.Assert(currentSegment!.RunningIndex + positionIndex >= 0);

            return currentSegment!.RunningIndex + positionIndex;
        }
    }
#endif
}
