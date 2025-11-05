// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Tests.Buffers;

using CryptoHives.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;
using System.Linq;

/// <summary>
/// Tests for <see cref="ReadOnlySequenceMemoryStream"/>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ReadOnlySequenceMemoryStreamTests
{
    /// <summary>
    /// Test the default behavior of <see cref="ReadOnlySequenceMemoryStream"/>.
    /// </summary>
    [Test]
    public void ReadOnlySequenceMemoryStreamWhenConstructedWithDefaultOptionsShouldNotThrow()
    {
        // Arrange
        using ReadOnlySequenceMemoryStream stream = new(ReadOnlySequence<byte>.Empty);

        // Act
        void Act() => stream.Dispose();
        byte[] buffer = new byte[1];

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.CanSeek, Is.True);
            Assert.That(stream.CanRead, Is.True);
            Assert.That(stream.CanWrite, Is.False);
        }

        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Seek(0, SeekOrigin.End), Is.Zero);
            Assert.That(stream.Seek(0, SeekOrigin.Current), Is.Zero);
            Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        }

        Assert.Throws<IOException>(() => stream.Seek(-1, SeekOrigin.Begin));
        Assert.Throws<IOException>(() => stream.Seek(0, (SeekOrigin)66));
        Assert.Throws<IOException>(() => stream.Seek(1000, SeekOrigin.Begin));

        Assert.Throws<NotSupportedException>(() => stream.SetLength(0));
        Assert.Throws<NotSupportedException>(() => stream.WriteByte(0));
        Assert.Throws<NotSupportedException>(() => stream.Write(buffer, 0, 1));
        Assert.Throws<NotSupportedException>(() => stream.Write(buffer.AsSpan(0, 1)));

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);
        stream.Flush();

        stream.Position = 0;
        Assert.That(stream.ToArray(), Is.Empty);

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);

        Assert.That(stream.ToArray(), Is.Empty);

        Assert.DoesNotThrow(() => Act());
    }

    [Test]
    public void ReadAcrossMultipleSegmentsShouldReturnConcatenatedBytes()
    {
        // Arrange
        byte[] a = { 1, 2, 3 };
        byte[] b = { 4, 5, 6, 7 };
        byte[] ab = { 1, 2, 3, 4, 5, 6, 7 };
        ReadOnlySequence<byte> seq = CreateSequence(a, b);

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        // Act
        byte[] result = stream.ToArray();

        // Assert
        Assert.That(result, Is.EqualTo(ab));

        // Position should be unchanged by ToArray
        Assert.That(stream.Position, Is.Zero);

        // ReadByte sequentially and ensure values are correct and -1 at end
        for (int i = 0; i < result.Length; i++)
        {
            int value = stream.ReadByte();
            Assert.That(value, Is.EqualTo(result[i]));
        }

        Assert.That(stream.ReadByte(), Is.EqualTo(-1));

        // Position should be at end
        Assert.That(stream.Position, Is.EqualTo(seq.Length));

        // set Position back to 0 and read again bytes
        for (int offset = 0; offset < ab.Length; offset++)
        {
            stream.Position = offset;
            Assert.That(stream.Position, Is.EqualTo(offset));

            int value = stream.ReadByte();
            Assert.That(value, Is.EqualTo(ab[offset]));
        }

        // set Position back to 0 and read again bytes
        for (int offset = 0; offset < ab.Length; offset++)
        {
            stream.Position = offset;
            Assert.That(stream.Position, Is.EqualTo(offset));

            result = stream.ToArray();
            Assert.That(result, Is.EqualTo(ab));

            result = new byte[stream.Length];
            int read = stream.Read(result, 0, result.Length);
            Assert.That(read, Is.EqualTo(ab.Length - offset));
            Assert.That(result.AsSpan(0, read).ToArray(), Is.EqualTo(ab.Skip(offset).ToArray()));
        }
    }

    [Test]
    public void ReadSpanShouldCopyAcrossSegmentBoundariesAndAdvancePosition()
    {
        // Arrange
        byte[] a = { 10, 11, 12 };
        byte[] b = { 13, 14, 15 };
        ReadOnlySequence<byte> seq = CreateSequence(a, b);

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        byte[] buffer = new byte[5];

        // Act
        int read = stream.Read(buffer.AsSpan(0, 5));

        // Assert
        Assert.That(read, Is.EqualTo(5));
        Assert.That(buffer, Is.EqualTo(new byte[] { 10, 11, 12, 13, 14 }));
        Assert.That(stream.Position, Is.EqualTo(5));

        // Reading remaining byte
        int last = stream.ReadByte();
        Assert.That(last, Is.EqualTo(15));
        Assert.That(stream.Position, Is.EqualTo(6));
    }

    [Test]
    public void ReadArrayShouldCopyAcrossSegmentBoundariesAndAdvancePosition()
    {
        // Arrange
        byte[] a = { 1, 2, 3 };
        byte[] b = { 4, 5, 6, 7 };
        ReadOnlySequence<byte> seq = CreateSequence(a, b);

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        // Prepare a larger destination buffer and pre-fill with sentinel to detect written region
        byte[] dest = new byte[10];
        for (int i = 0; i < dest.Length; i++)
        {
            dest[i] = 0xFF;
        }

        // Act - read 4 bytes into dest at offset 2
        int read = stream.Read(dest, 2, 4);

        // Assert
        Assert.That(read, Is.EqualTo(4));
        Assert.That(dest[0], Is.EqualTo(0xFF));
        Assert.That(dest[1], Is.EqualTo(0xFF));
        Assert.That(dest[2], Is.EqualTo(1));
        Assert.That(dest[3], Is.EqualTo(2));
        Assert.That(dest[4], Is.EqualTo(3));
        Assert.That(dest[5], Is.EqualTo(4));
        Assert.That(dest[6], Is.EqualTo(0xFF));
        Assert.That(stream.Position, Is.EqualTo(4));

        // Read the remaining bytes into a fresh buffer with large count (more than available)
        byte[] remaining = new byte[8];
        int read2 = stream.Read(remaining, 0, remaining.Length);
        Assert.That(read2, Is.EqualTo(3));
        Assert.That(remaining[0], Is.EqualTo(5));
        Assert.That(remaining[1], Is.EqualTo(6));
        Assert.That(remaining[2], Is.EqualTo(7));
        Assert.That(stream.Position, Is.EqualTo(seq.Length));

        // Further reads should return 0 and not modify buffers
        int read3 = stream.Read(remaining, 1, 4);
        Assert.That(read3, Is.Zero);
    }

    [Test]
    public void ReadArrayWithZeroCountShouldReturnZeroAndNotAdvance()
    {
        // Arrange
        byte[] a = { 10, 11, 12 };
        ReadOnlySequence<byte> seq = CreateSequence(a);

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        byte[] buffer = new byte[4];
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = 0xAA;
        }

        // Act
        int read = stream.Read(buffer, 1, 0);

        // Assert
        Assert.That(read, Is.Zero);
        Assert.That(stream.Position, Is.Zero);

        // Ensure buffer not modified
        Assert.That(buffer, Is.EqualTo(new byte[] { 0xAA, 0xAA, 0xAA, 0xAA }));
    }

    [Test]
    public void SeekShouldSetPositionCorrectlyAndRespectOrigins()
    {
        // Arrange
        byte[] a = { 20, 21, 22 };
        byte[] b = { 23, 24, 25, 26 };
        ReadOnlySequence<byte> seq = CreateSequence(a, b);
        long length = seq.Length;

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        // Seek from begin
        long pos = stream.Seek(4, SeekOrigin.Begin);
        Assert.That(pos, Is.EqualTo(4));
        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(stream.ReadByte(), Is.EqualTo(24)); // index 4 -> value 24

        // Seek from current (back two)
        pos = stream.Seek(-2, SeekOrigin.Current);
        Assert.That(pos, Is.EqualTo(3));
        Assert.That(stream.Position, Is.EqualTo(3));
        Assert.That(stream.ReadByte(), Is.EqualTo(23)); // index 3 -> value 23

        // Seek from end
        pos = stream.Seek(0, SeekOrigin.End);
        Assert.That(pos, Is.EqualTo(length));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
    }

    [Test]
    public void SeekToEndThenSeekBackAndReadLastByte()
    {
        // Arrange
        byte[] a = { 100, 101 };
        ReadOnlySequence<byte> seq = CreateSequence(a);

        using var stream = new ReadOnlySequenceMemoryStream(seq);

        // Seek to end
        long pos = stream.Seek(2, SeekOrigin.Begin);
        Assert.That(pos, Is.EqualTo(2));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));

        // Seek to last byte and read
        pos = stream.Seek(-1, SeekOrigin.End);
        Assert.That(pos, Is.EqualTo(1));
        Assert.That(stream.ReadByte(), Is.EqualTo(101));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
    }

    /// <summary>
    /// Helper to create a multi-segment ReadOnlySequence from arrays.
    /// </summary>
    private sealed class TestSegment : ReadOnlySequenceSegment<byte>
    {
        public TestSegment(ReadOnlyMemory<byte> memory)
        {
            Memory = memory;
        }

        public TestSegment Append(ReadOnlyMemory<byte> memory)
        {
            var next = new TestSegment(memory) {
                RunningIndex = RunningIndex + Memory.Length
            };
            Next = next;
            return next;
        }
    }

    private static ReadOnlySequence<byte> CreateSequence(params byte[][] parts)
    {
        if (parts == null || parts.Length == 0)
        {
            return ReadOnlySequence<byte>.Empty;
        }

        var first = new TestSegment(parts[0]);
        TestSegment last = first;
        for (int i = 1; i < parts.Length; i++)
        {
            last = last.Append(parts[i]);
        }

        return new ReadOnlySequence<byte>(first, 0, last, last.Memory.Length);
    }
}
