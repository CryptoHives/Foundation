// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1859 // Use concrete types when possible for improved performance

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
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
        using ArrayPoolBufferWriter<byte> writer = new();

        void Act() => writer.Dispose();
        byte[] buffer = new byte[1];

        Memory<byte> memory = writer.GetMemory(1);
        memory.Span[0] = 0;
        writer.Advance(1);
        writer.Write(buffer);
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();

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
    /// Test the chunking behavior of <see cref="ArrayPoolBufferWriter{T}"/>.
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

        using var writer = new ArrayPoolBufferWriter<byte>(true, defaultChunkSize, maxChunkSize);

        for (int i = 0; i <= byte.MaxValue; i++)
        {
            Span<byte> span;
            int randomGetChunkSize = maxChunkSize > 0 ? chunkSize + random.Next(maxChunkSize) : chunkSize;

            int repeats = random.Next(3);
            do
            {
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

            for (int v = 0; v < chunkSize; v++)
            {
                span[v] = (byte)i;
            }

            writer.Advance(chunkSize);

            if (random.Next(10) == 0)
            {
                length = chunkSize * (i + 1);
                sequence = writer.GetReadOnlySequence();
                buffer = sequence.ToArray();

                using (Assert.EnterMultipleScope())
                {
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
            Assert.That(buffer, Has.Length.EqualTo(length));
            Assert.That(sequence.Length, Is.EqualTo(length));
        }

        for (int i = 0; i < buffer.Length; i++)
        {
            Assert.That(buffer[i], Is.EqualTo((byte)(i / chunkSize)));
        }
    }

    /// <summary>
    /// Fuzzer-style test that writes random chunks via <see cref="BuildChunkBuffer"/>
    /// and verifies the resulting <see cref="ReadOnlySequence{T}"/> integrity.
    /// </summary>
    [Theory]
    public void ArrayPoolBufferWriterFuzzer(
        [Values(1, 64, 512)] int chunkSize,
        [Values(256, 4096)] int defaultChunkSize,
        [Values(0, 4096)] int maxChunkSize,
        [Values(0, 42, 9876)] int seed)
    {
        using var writer = new ArrayPoolBufferWriter<byte>(true, defaultChunkSize, maxChunkSize);

        BuildChunkBuffer(writer, new Random(seed), chunkSize, maxChunkSize);

        int expectedLength = (byte.MaxValue + 1) * chunkSize;
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
        byte[] buffer = sequence.ToArray();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(sequence.Length, Is.EqualTo(expectedLength));
            Assert.That(buffer, Has.Length.EqualTo(expectedLength));
        }

        for (int i = 0; i < buffer.Length; i++)
        {
            Assert.That(buffer[i], Is.EqualTo((byte)(i / chunkSize)));
        }
    }

    /// <summary>
    /// Fuzzer-style test that performs random <see cref="IBufferWriter{T}"/> operations
    /// and verifies the accumulated output matches expectations.
    /// </summary>
    [Theory]
    public void ArrayPoolBufferWriterRandomOperations(
        [Values(42, 1337, 99999)] int seed,
        [Values(256, 4096)] int defaultChunkSize,
        [Values(0, 8192)] int maxChunkSize)
    {
        var random = new Random(seed);
        using var writer = new ArrayPoolBufferWriter<byte>(true, defaultChunkSize, maxChunkSize);
        using var expected = new System.IO.MemoryStream();

        for (int round = 0; round < 500; round++)
        {
            int size = random.Next(0, 1024);
            byte[] data = new byte[size];
            random.NextBytes(data);

            switch (random.Next(3))
            {
                case 0:
                    Memory<byte> memory = writer.GetMemory(size);
                    data.CopyTo(memory);
                    writer.Advance(size);
                    break;
                case 1:
                    Span<byte> span = writer.GetSpan(size);
                    data.CopyTo(span);
                    writer.Advance(size);
                    break;
                default:
                    writer.Write(data);
                    break;
            }

            expected.Write(data, 0, data.Length);
        }

        byte[] expectedBytes = expected.ToArray();
        byte[] actualBytes = writer.GetReadOnlySequence().ToArray();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(actualBytes, Has.Length.EqualTo(expectedBytes.Length));
            Assert.That(actualBytes, Is.EqualTo(expectedBytes));
        }
    }

    /// <summary>
    /// Fills a <see cref="IBufferWriter{T}"/> with a sequence of chunks with byte values from 0 to 255.
    /// </summary>
    /// <param name="writer">The buffer writer to fill.</param>
    /// <param name="random">A random object to supply to vary buffer allocations.</param>
    /// <param name="chunkSize">The size of each chunk in the buffer.</param>
    /// <param name="maxChunkSize">The maximum chunk size used to get span or memory to write to if > 0.</param>
    private static void BuildChunkBuffer(IBufferWriter<byte> writer, Random random, int chunkSize, int maxChunkSize)
    {
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            Span<byte> span;
            int randomGetChunkSize = maxChunkSize > 0 ? chunkSize + random.Next(maxChunkSize) : chunkSize;

            int repeats = random.Next(3);
            do
            {
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

            for (int v = 0; v < chunkSize; v++)
            {
                span[v] = (byte)i;
            }

            writer.Advance(chunkSize);
        }
    }
}
