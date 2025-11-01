// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETFRAMEWORK
#define STREAM_WITH_READEXACTLY_SUPPORT
#endif

namespace CryptoHives.Memory.Tests.Buffers;

using CryptoHives.Memory.Buffers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Buffers;
using System.IO;

/// <summary>
/// Tests for <see cref="ArrayPoolBufferWriter{T}"/> where T is <see cref="byte"/>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ArrayPoolMemoryStreamTests
{
    /// <summary>
    /// Test the default behavior of <see cref="ArrayPoolMemoryStream"/>.
    /// </summary>
    [Test]
    public void ArrayPoolMemoryStreamWhenConstructedWithDefaultOptionsShouldNotThrow()
    {
        // Arrange
        using ArrayPoolMemoryStream stream = new();

        // Act
        Action act = stream.Dispose;
        byte[] buffer = "U"u8.ToArray();

        using (Assert.EnterMultipleScope())
        {
            // Assert
            Assert.That(stream.CanSeek, Is.True);
            Assert.That(stream.CanRead, Is.True);
            Assert.That(stream.CanWrite, Is.True);
        }

        Assert.Throws<NotSupportedException>(() => stream.SetLength(0));
        Assert.Throws<IOException>(() => stream.Seek(-1, SeekOrigin.Begin));
        Assert.Throws<IOException>(() => stream.Seek(0, (SeekOrigin)66));

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);

        stream.Position = 0;
        Assert.That(stream.Position, Is.Zero);

        Assert.That(stream.Length, Is.Zero);

        Assert.That(stream.Seek(0, SeekOrigin.Begin), Is.Zero);
        stream.WriteByte(0xaa);
        stream.Write(buffer, 0, 1);
        stream.Write(buffer.AsSpan(0, 1));
        stream.Flush();
        Assert.That(stream.Length, Is.EqualTo(3));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Position, Is.EqualTo(3));
            Assert.That(stream.Length, Is.EqualTo(3));
        }

        Assert.That(stream.Seek(-3, SeekOrigin.Current), Is.Zero);
        Assert.That(stream.ReadByte(), Is.EqualTo(0xaa));
        Assert.That(stream.Length, Is.EqualTo(3));
        Assert.That(stream.Position, Is.EqualTo(1));
        Assert.That(stream.Read(buffer, 0, 1), Is.EqualTo(1));
        Assert.That(stream.Position, Is.EqualTo(2));
        Assert.That(stream.Length, Is.EqualTo(3));
        Assert.That(buffer[0], Is.EqualTo(0x55));
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.EqualTo(1));
        Assert.That(stream.Position, Is.EqualTo(3));
        Assert.That(stream.Length, Is.EqualTo(3));
        Assert.That(buffer[0], Is.EqualTo(0x55));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Read(buffer, 0, 1), Is.Zero);
        Assert.That(stream.Read(buffer.AsSpan(0, 1)), Is.Zero);

        ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
        Assert.That(sequence.Length, Is.EqualTo(3));
        Assert.That(sequence.Slice(0, 1).ToArray()[0], Is.EqualTo(0xaa));
        Assert.That(sequence.Slice(1, 1).ToArray()[0], Is.EqualTo(0x55));
        Assert.That(sequence.Slice(2, 1).ToArray()[0], Is.EqualTo(0x55));

        byte[] array = stream.ToArray();
        Assert.That(array, Has.Length.EqualTo(3));
        Assert.That(array[0], Is.EqualTo(0xaa));
        Assert.That(array[1], Is.EqualTo(0x55));
        Assert.That(array[2], Is.EqualTo(0x55));

        Assert.DoesNotThrow(() => act());

        Assert.That(stream.ToArray(), Is.Empty);
    }

    /// <summary>
    /// Test the default behavior of <see cref="ArrayPoolBufferWriter{T}"/>.
    /// </summary>
    [Theory]
    public void ArrayPoolMemoryStreamWrite(
        [Values(0, 1, 16, 17, 128, 333, 777, 1024, 4096)] int chunkSize,
        [Values(16, 128, 333, 1024, 4096, 65536)] int defaultBufferSize)
    {
        var random = new Random(42);
        int length;
        ReadOnlySequence<byte> sequence;
        byte[] buffer = new byte[chunkSize];

        // Arrange
        using var writer = new ArrayPoolMemoryStream(defaultBufferSize);

        // Act
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            // fill chunk with a byte
            for (int v = 0; v < chunkSize; v++)
            {
                buffer[v] = (byte)i;
            }

            // write next chunk
            switch (random.Next(3))
            {
                case 0:
                    for (int v = 0; v < chunkSize; v++)
                    {
                        writer.WriteByte((byte)i);
                    }
                    break;
                case 1:
                    writer.Write(buffer, 0, chunkSize);
                    break;
                default:
                    writer.Write(buffer.AsSpan(0, chunkSize));
                    break;
            }
        }

        length = (byte.MaxValue + 1) * chunkSize;
        sequence = writer.GetReadOnlySequence();
        buffer = sequence.ToArray();

        // Assert sequence properties
        Assert.That(buffer, Has.Length.EqualTo(length));
        Assert.That(sequence.Length, Is.EqualTo(length));

        for (int i = 0; i < buffer.Length; i++)
        {
            Assert.That(buffer[i], Is.EqualTo((byte)(i / chunkSize)));
        }

        for (int i = 0; i <= byte.MaxValue; i++)
        {
            ReadOnlySequence<byte> chunkSequence = sequence.Slice(i * chunkSize, chunkSize);
            Assert.That(chunkSequence.Length, Is.EqualTo((long)chunkSize));

            buffer = chunkSequence.ToArray();
            for (int v = 0; v < chunkSize; v++)
            {
                Assert.That(buffer[v], Is.EqualTo((byte)i));
            }
        }

        long result = writer.Seek(0, SeekOrigin.Begin);
        Assert.That(result, Is.Zero);

        result = writer.Seek(0, SeekOrigin.End);
        Assert.That(result, Is.EqualTo(length));

        // read back from writer MemoryStream
        result = writer.Seek(0, SeekOrigin.Begin);
        Assert.That(result, Is.Zero);

        Assert.That(writer.Length, Is.EqualTo(length));

        long position;
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            if (random.Next(2) == 0)
            {
                position = writer.Seek(chunkSize * i, SeekOrigin.Begin);
                Assert.That(position, Is.EqualTo(chunkSize * i));
            }

            switch (random.Next(3))
            {
                case 0:
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(writer.ReadByte(), Is.EqualTo((byte)i));
                    }
                    break;
                case 1:
#if STREAM_WITH_READEXACTLY_SUPPORT
                    writer.ReadExactly(buffer, 0, chunkSize);
#else
                    writer.Read(buffer, 0, chunkSize);
#endif
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(buffer[v], Is.EqualTo((byte)i));
                    }
                    break;
                default:
#if STREAM_WITH_READEXACTLY_SUPPORT
                    writer.ReadExactly(buffer.AsSpan(0, chunkSize));
#else
                    writer.Read(buffer.AsSpan(0, chunkSize));
#endif                    
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(buffer[v], Is.EqualTo((byte)i));
                    }
                    break;
            }
        }

        position = writer.Seek(0, SeekOrigin.Begin);
        Assert.That(position, Is.Zero);

        // read sequence using ReadOnlySequenceMemoryStream
        using var reader = new ReadOnlySequenceMemoryStream(sequence);
        Assert.That(reader.Length, Is.EqualTo(length));

        for (int i = 0; i <= byte.MaxValue; i++)
        {
            if (random.Next(2) == 0)
            {
                position = reader.Seek(chunkSize * i, SeekOrigin.Begin);
                Assert.That(position, Is.EqualTo(chunkSize * i));
            }

            switch (random.Next(3))
            {
                case 0:
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(reader.ReadByte(), Is.EqualTo((byte)i));
                    }
                    break;
                case 1:
#if STREAM_WITH_READEXACTLY_SUPPORT
                    reader.ReadExactly(buffer, 0, chunkSize);
#else
                    reader.Read(buffer, 0, chunkSize);
#endif
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(buffer[v], Is.EqualTo((byte)i));
                    }
                    break;
                default:
#if STREAM_WITH_READEXACTLY_SUPPORT
                    reader.ReadExactly(buffer.AsSpan(0, chunkSize));
#else
                    reader.Read(buffer.AsSpan(0, chunkSize));
#endif              
                    for (int v = 0; v < chunkSize; v++)
                    {
                        Assert.That(buffer[v], Is.EqualTo((byte)i));
                    }

                    break;
            }
        }

        position = reader.Seek(0, SeekOrigin.Begin);
        Assert.That(position, Is.Zero);
    }
}
