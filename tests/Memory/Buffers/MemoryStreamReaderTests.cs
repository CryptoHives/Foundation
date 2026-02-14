// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !(NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER)
#define MEMORYSTREAM_READ_SPAN_POLYFILL
#endif

#if !NET7_0_OR_GREATER
#define READEXACTLY_POLYFILL
#endif

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;
using System.Linq;

/// <summary>
/// Shared reader tests for <see cref="ArrayPoolMemoryStream"/>
/// and <see cref="ReadOnlySequenceMemoryStream"/>.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(StreamTypeArgs))]
[Parallelizable(ParallelScope.All)]
public class MemoryStreamReaderTests
{
    private readonly string _streamType;

    /// <summary>
    /// Stream implementations to test.
    /// </summary>
    public static readonly object[] StreamTypeArgs =
    [
        new object[] { "ArrayPool" },
        new object[] { "ReadOnlySequence" }
    ];

    /// <summary>
    /// Initializes a new instance of the <see cref="MemoryStreamReaderTests"/> class.
    /// </summary>
    public MemoryStreamReaderTests(string streamType)
    {
        _streamType = streamType;
    }

    #region Read

    [Test]
    public void ReadAcrossMultipleSegmentsShouldReturnConcatenatedBytes()
    {
        byte[] a = { 1, 2, 3 };
        byte[] b = { 4, 5, 6, 7 };
        byte[] ab = { 1, 2, 3, 4, 5, 6, 7 };

        using var stream = CreateStream(a, b);

        byte[] result = stream.ToArray();
        Assert.That(result, Is.EqualTo(ab));
        Assert.That(stream.Position, Is.Zero);

        for (int i = 0; i < result.Length; i++)
        {
            int value = stream.ReadByte();
            Assert.That(value, Is.EqualTo(result[i]));
        }

        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
        Assert.That(stream.Position, Is.EqualTo(ab.Length));

        for (int offset = 0; offset < ab.Length; offset++)
        {
            stream.Position = offset;
            Assert.That(stream.Position, Is.EqualTo(offset));

            int value = stream.ReadByte();
            Assert.That(value, Is.EqualTo(ab[offset]));
        }

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
    public void ReadSpanShouldCopyAcrossBoundariesAndAdvancePosition()
    {
        using var stream = CreateStream([10, 11, 12], [13, 14, 15]);

        byte[] buffer = new byte[5];
        int read = stream.Read(buffer.AsSpan(0, 5));

        Assert.That(read, Is.EqualTo(5));
        Assert.That(buffer, Is.EqualTo(new byte[] { 10, 11, 12, 13, 14 }));
        Assert.That(stream.Position, Is.EqualTo(5));

        int last = stream.ReadByte();
        Assert.That(last, Is.EqualTo(15));
        Assert.That(stream.Position, Is.EqualTo(6));
    }

    [Test]
    public void ReadArrayShouldCopyAcrossBoundariesAndAdvancePosition()
    {
        using var stream = CreateStream([1, 2, 3], [4, 5, 6, 7]);

        byte[] dest = new byte[10];
        for (int i = 0; i < dest.Length; i++)
        {
            dest[i] = 0xFF;
        }

        int read = stream.Read(dest, 2, 4);

        Assert.That(read, Is.EqualTo(4));
        Assert.That(dest[0], Is.EqualTo(0xFF));
        Assert.That(dest[1], Is.EqualTo(0xFF));
        Assert.That(dest[2], Is.EqualTo(1));
        Assert.That(dest[3], Is.EqualTo(2));
        Assert.That(dest[4], Is.EqualTo(3));
        Assert.That(dest[5], Is.EqualTo(4));
        Assert.That(dest[6], Is.EqualTo(0xFF));
        Assert.That(stream.Position, Is.EqualTo(4));

        byte[] remaining = new byte[8];
        int read2 = stream.Read(remaining, 0, remaining.Length);
        Assert.That(read2, Is.EqualTo(3));
        Assert.That(remaining[0], Is.EqualTo(5));
        Assert.That(remaining[1], Is.EqualTo(6));
        Assert.That(remaining[2], Is.EqualTo(7));
        Assert.That(stream.Position, Is.EqualTo(7));

        int read3 = stream.Read(remaining, 1, 4);
        Assert.That(read3, Is.Zero);
    }

    [Test]
    public void ReadArrayWithZeroCountShouldReturnZeroAndNotAdvance()
    {
        using var stream = CreateStream([10, 11, 12]);

        byte[] buffer = new byte[4];
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = 0xAA;
        }

        int read = stream.Read(buffer, 1, 0);

        Assert.That(read, Is.Zero);
        Assert.That(stream.Position, Is.Zero);
        Assert.That(buffer, Is.EqualTo(new byte[] { 0xAA, 0xAA, 0xAA, 0xAA }));
    }

    #endregion

    #region ReadExactly

    [Test]
    public void ReadExactlySpanShouldFillBufferAcrossBoundaries()
    {
        using var stream = CreateStream([1, 2, 3], [4, 5, 6, 7]);
        byte[] buffer = new byte[5];

        stream.ReadExactly(buffer.AsSpan());

        Assert.That(buffer, Is.EqualTo(new byte[] { 1, 2, 3, 4, 5 }));
        Assert.That(stream.Position, Is.EqualTo(5));
    }

    [Test]
    public void ReadExactlySpanShouldThrowWhenNotEnoughData()
    {
        using var stream = CreateStream([1, 2, 3]);
        byte[] buffer = new byte[5];

        Assert.Throws<EndOfStreamException>(() => stream.ReadExactly(buffer.AsSpan()));
    }

    [Test]
    public void ReadExactlySpanWithEmptyBufferShouldSucceed()
    {
        using var stream = CreateStream([1, 2]);

        Assert.DoesNotThrow(() => stream.ReadExactly(Span<byte>.Empty));
        Assert.That(stream.Position, Is.Zero);
    }

    [Test]
    public void ReadExactlyArrayShouldFillBufferAcrossBoundaries()
    {
        using var stream = CreateStream([10, 11], [12, 13, 14]);
        byte[] buffer = new byte[6];
        buffer[0] = 0xFF;
        buffer[5] = 0xFF;

        stream.ReadExactly(buffer, 1, 4);

        Assert.That(buffer[0], Is.EqualTo(0xFF));
        Assert.That(buffer[1], Is.EqualTo(10));
        Assert.That(buffer[2], Is.EqualTo(11));
        Assert.That(buffer[3], Is.EqualTo(12));
        Assert.That(buffer[4], Is.EqualTo(13));
        Assert.That(buffer[5], Is.EqualTo(0xFF));
        Assert.That(stream.Position, Is.EqualTo(4));
    }

    [Test]
    public void ReadExactlyArrayShouldThrowWhenNotEnoughData()
    {
        using var stream = CreateStream([1, 2]);
        byte[] buffer = new byte[5];

        Assert.Throws<EndOfStreamException>(() => stream.ReadExactly(buffer, 0, 5));
    }

    [Test]
    public void ReadExactlyArrayWithZeroCountShouldSucceed()
    {
        using var stream = CreateStream([1, 2]);

        Assert.DoesNotThrow(() => stream.ReadExactly(new byte[4], 0, 0));
        Assert.That(stream.Position, Is.Zero);
    }

    [Test]
    public void ReadExactlyShouldReadExactAmountAvailable()
    {
        using var stream = CreateStream([42, 43, 44]);
        byte[] buffer = new byte[3];

        stream.ReadExactly(buffer.AsSpan());

        Assert.That(buffer, Is.EqualTo(new byte[] { 42, 43, 44 }));
        Assert.That(stream.Position, Is.EqualTo(3));
    }

    #endregion

    #region Seek

    [Test]
    public void SeekShouldSetPositionCorrectlyAndRespectOrigins()
    {
        using var stream = CreateStream([20, 21, 22], [23, 24, 25, 26]);
        long length = stream.Length;

        // Seek from begin
        long pos = stream.Seek(4, SeekOrigin.Begin);
        Assert.That(pos, Is.EqualTo(4));
        Assert.That(stream.Position, Is.EqualTo(4));
        Assert.That(stream.ReadByte(), Is.EqualTo(24));

        // Seek from current (back two)
        pos = stream.Seek(-2, SeekOrigin.Current);
        Assert.That(pos, Is.EqualTo(3));
        Assert.That(stream.Position, Is.EqualTo(3));
        Assert.That(stream.ReadByte(), Is.EqualTo(23));

        // Seek from end
        pos = stream.Seek(0, SeekOrigin.End);
        Assert.That(pos, Is.EqualTo(length));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
    }

    [Test]
    public void SeekToEndThenSeekBackAndReadLastByte()
    {
        using var stream = CreateStream([100, 101]);

        long pos = stream.Seek(2, SeekOrigin.Begin);
        Assert.That(pos, Is.EqualTo(2));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));

        pos = stream.Seek(-1, SeekOrigin.End);
        Assert.That(pos, Is.EqualTo(1));
        Assert.That(stream.ReadByte(), Is.EqualTo(101));
        Assert.That(stream.ReadByte(), Is.EqualTo(-1));
    }

    #endregion

    #region Helpers

    private MemoryStream CreateStream(params byte[][] segments) => _streamType switch {
        "ArrayPool" => CreateArrayPoolStream(segments),
        "ReadOnlySequence" => CreateReadOnlySequenceStream(segments),
        _ => throw new NotSupportedException($"Unknown stream type: {_streamType}")
    };

    private static ArrayPoolMemoryStream CreateArrayPoolStream(byte[][] segments)
    {
        var arraySegments = segments.Select(s => new ArraySegment<byte>(s));
        return new ArrayPoolMemoryStream(arraySegments);
    }

    private static ReadOnlySequenceMemoryStream CreateReadOnlySequenceStream(byte[][] segments)
    {
        if (segments.Length == 0)
        {
            return new ReadOnlySequenceMemoryStream(ReadOnlySequence<byte>.Empty);
        }

        var first = new SequenceSegment(segments[0]);
        SequenceSegment last = first;
        for (int i = 1; i < segments.Length; i++)
        {
            last = last.Append(segments[i]);
        }

        var seq = new ReadOnlySequence<byte>(first, 0, last, last.Memory.Length);
        return new ReadOnlySequenceMemoryStream(seq);
    }

    private sealed class SequenceSegment : ReadOnlySequenceSegment<byte>
    {
        public SequenceSegment(ReadOnlyMemory<byte> memory)
        {
            Memory = memory;
        }

        public SequenceSegment Append(ReadOnlyMemory<byte> memory)
        {
            var next = new SequenceSegment(memory) {
                RunningIndex = RunningIndex + Memory.Length
            };
            Next = next;
            return next;
        }
    }

    #endregion
}

#if MEMORYSTREAM_READ_SPAN_POLYFILL
/// <summary>
/// Bridges <c>Read(Span)</c> calls to the concrete polyfill methods
/// on pre-.NET Standard 2.1 targets where <see cref="MemoryStream"/> lacks the Span API.
/// </summary>
internal static class MemoryStreamReadSpanPolyfillExtensions
{
    public static int Read(this MemoryStream stream, Span<byte> buffer)
    {
        if (stream is ArrayPoolMemoryStream apms) return apms.Read(buffer);
        if (stream is ReadOnlySequenceMemoryStream rosms) return rosms.Read(buffer);
        throw new NotSupportedException($"Read(Span) polyfill not available for {stream.GetType().Name}.");
    }
}
#endif

#if READEXACTLY_POLYFILL
/// <summary>
/// Bridges <c>ReadExactly</c> calls to the concrete polyfill methods on pre-.NET 7 targets.
/// </summary>
internal static class MemoryStreamReadExactlyPolyfillExtensions
{
    public static void ReadExactly(this MemoryStream stream, Span<byte> buffer)
    {
        if (stream is ArrayPoolMemoryStream apms) apms.ReadExactly(buffer);
        else if (stream is ReadOnlySequenceMemoryStream rosms) rosms.ReadExactly(buffer);
        else throw new NotSupportedException($"ReadExactly polyfill not available for {stream.GetType().Name}.");
    }

    public static void ReadExactly(this MemoryStream stream, byte[] buffer, int offset, int count)
    {
        if (stream is ArrayPoolMemoryStream apms) apms.ReadExactly(buffer, offset, count);
        else if (stream is ReadOnlySequenceMemoryStream rosms) rosms.ReadExactly(buffer, offset, count);
        else throw new NotSupportedException($"ReadExactly polyfill not available for {stream.GetType().Name}.");
    }
}
#endif
