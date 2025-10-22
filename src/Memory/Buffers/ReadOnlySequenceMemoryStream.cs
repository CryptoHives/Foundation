// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Memory.Buffers;

using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;

/// <summary>
/// Class to create a read only MemoryStream which uses a <see cref="ReadOnlySequence{T}"/>
/// for the buffer stream, where T must be a <see cref="byte"/>.
/// </summary>
public sealed class ReadOnlySequenceMemoryStream : MemoryStream
{
    private readonly ReadOnlySequence<byte> _sequence;
    private SequencePosition _nextSequencePosition;
    private long _sequenceOffset;
    private ReadOnlyMemory<byte> _currentBuffer;
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

    /// <inheritdoc/>
    public override int Read(Span<byte> buffer)
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
        _sequenceOffset = _sequence.GetOffset(_nextSequencePosition);
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
        _sequenceOffset = _sequence.GetOffset(_nextSequencePosition);

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
}
