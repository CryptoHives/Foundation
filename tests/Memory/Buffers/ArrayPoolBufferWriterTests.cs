// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Tests.Buffers;

using CryptoHives.Memory.Buffers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Buffers;

/// <summary>
/// Tests for <see cref="ArrayPoolBufferWriter{T}"/> where T is <see cref="byte"/>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ArrayPoolBufferWriterTests
{
    /// <summary>
    /// Test the default behavior of <see cref="ArrayPoolBufferWriter{T}"/>.
    /// </summary>
    [Test]
    public void ArrayPoolBufferWriterWhenConstructedWithDefaultOptionsShouldNotThrow()
    {
        // Arrange
        using ArrayPoolBufferWriter<byte> writer = new();

        // Act
        void Act() => writer.Dispose();
        byte[] buffer = new byte[1];

        Memory<byte> memory = writer.GetMemory(1);
        memory.Span[0] = 0;
        writer.Advance(1);
        writer.Write(buffer);
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => writer.GetMemory(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => writer.GetSpan(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => writer.Advance(2));

        Assert.DoesNotThrow(() => Act());

        Assert.Throws<ObjectDisposedException>(() => writer.GetReadOnlySequence());
        Assert.Throws<ObjectDisposedException>(() => writer.GetMemory(2));
        Assert.Throws<ObjectDisposedException>(() => writer.GetSpan(2));
        Assert.Throws<ObjectDisposedException>(() => writer.Advance(2));
    }

    /// <summary>
    /// Test the default behavior of <see cref="ArrayPoolBufferWriter{T}"/>.
    /// </summary>
    [Theory]
    public void ArrayPoolBufferWriterChunking(
        [Values(0, 1, 16, 128, 333, 1024, 7777)] int chunkSize,
        [Values(16, 333, 1024, 4096)] int defaultChunkSize,
        [Values(0, 1024, 4096, 65536)] int maxChunkSize)
    {
        var random = new Random(42);
        int length;
        ReadOnlySequence<byte> sequence;
        byte[] buffer;

        // Arrange
        using var writer = new ArrayPoolBufferWriter<byte>(true, defaultChunkSize, maxChunkSize);

        // Act
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            Span<byte> span;
            int randomGetChunkSize = maxChunkSize > 0 ? chunkSize + random.Next(maxChunkSize) : chunkSize;

            int repeats = random.Next(3);
            do
            {
                // get a new chunk
                if (random.Next(2) == 0)
                {
                    Memory<byte> memory = writer.GetMemory(randomGetChunkSize);
                    Assert.That(memory.Length, Is.GreaterThanOrEqualTo(chunkSize));
                    span = memory.Span;
                }
                else
                {
                    span = writer.GetSpan(randomGetChunkSize);
                }

                Assert.That(span.Length, Is.GreaterThanOrEqualTo(chunkSize));
            }
            while (repeats-- > 0);

            // fill chunk with a byte
            for (int v = 0; v < chunkSize; v++)
            {
                span[v] = (byte)i;
            }

            writer.Advance(chunkSize);

            // Assert interim projections
            if (random.Next(10) == 0)
            {
                length = chunkSize * (i + 1);
                sequence = writer.GetReadOnlySequence();
                buffer = sequence.ToArray();

                using (Assert.EnterMultipleScope())
                {
                    // Assert
                    Assert.That(buffer, Has.Length.EqualTo(length));
                    Assert.That(sequence.Length, Is.EqualTo(length));
                }
            }
        }

        length = (byte.MaxValue + 1) * chunkSize;
        sequence = writer.GetReadOnlySequence();
        buffer = sequence.ToArray();

        using (Assert.EnterMultipleScope())
        {
            // Assert
            Assert.That(buffer, Has.Length.EqualTo(length));
            Assert.That(sequence.Length, Is.EqualTo(length));
        }

        for (int i = 0; i < buffer.Length; i++)
        {
            Assert.That(buffer[i], Is.EqualTo((byte)(i / chunkSize)));
        }
    }

    /// <summary>
    /// Fills a <see cref="IBufferWriter{T}"/> with a sequence of chunks with byte values from 0 to 255.
    /// </summary>
    /// <param name="writer">The buffer writer to fill.</param>
    /// <param name="random">A random object to supply to vary buffer allocations.</param>
    /// <param name="chunkSize">The size of each chunk in the buffer.</param>
    /// <param name="maxChunkSize">The maximum chunk size used to get span or memory to write to if > 0.</param>
    private void BuildChunkBuffer(IBufferWriter<byte> writer, Random random, int chunkSize, int maxChunkSize)
    {
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            Span<byte> span;
            int randomGetChunkSize = maxChunkSize > 0 ? chunkSize + random.Next(maxChunkSize) : chunkSize;

            int repeats = random.Next(3);
            do
            {
                // get a new chunk
                if (random.Next(2) == 0)
                {
                    Memory<byte> memory = writer.GetMemory(randomGetChunkSize);
                    Assert.That(memory.Length, Is.GreaterThanOrEqualTo(chunkSize));
                    span = memory.Span;
                }
                else
                {
                    span = writer.GetSpan(randomGetChunkSize);
                }

                Assert.That(span.Length, Is.GreaterThanOrEqualTo(chunkSize));
            }
            while (repeats-- > 0);

            // fill chunk with a byte
            for (int v = 0; v < chunkSize; v++)
            {
                span[v] = (byte)i;
            }

            writer.Advance(chunkSize);
        }
    }
}
