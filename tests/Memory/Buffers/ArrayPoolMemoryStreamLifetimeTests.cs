// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;
using System.Linq;

/// <summary>
/// Covers the members of <see cref="ArrayPoolMemoryStream"/> that concern buffer lifetime:
/// <see cref="ArrayPoolMemoryStream.SetLength"/> and the buffer-exposing members inherited from
/// <see cref="MemoryStream"/> that must not be allowed to report on the unused base-class array.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class ArrayPoolMemoryStreamLifetimeTests
{
    /// <summary>Small segments, so every test spans several of them.</summary>
    private const int SegmentSize = 64;

    private static ArrayPoolMemoryStream CreateStream() => new(4, SegmentSize);

    private static byte[] Payload(int length, int seed = 1)
    {
        var data = new byte[length];
        new Random(seed).NextBytes(data);
        return data;
    }

    private static ArrayPoolMemoryStream CreateFilled(byte[] data)
    {
        ArrayPoolMemoryStream stream = CreateStream();
        stream.Write(data, 0, data.Length);
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }

    private static byte[] ReadAll(Stream stream)
    {
        using var sink = new MemoryStream();
        stream.CopyTo(sink);
        return sink.ToArray();
    }

    // ---------------------------------------------------------------- SetLength

    [Test]
    public void SetLengthToZeroEmptiesTheStreamAndAllowsReuse()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(500));

        stream.SetLength(0);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Length, Is.Zero);
            Assert.That(stream.Position, Is.Zero);
        }

        byte[] second = Payload(300, seed: 2);
        stream.Write(second, 0, second.Length);
        stream.Seek(0, SeekOrigin.Begin);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Length, Is.EqualTo(second.Length));
            Assert.That(ReadAll(stream), Is.EqualTo(second));
        }
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(SegmentSize - 1)]
    [TestCase(SegmentSize)]
    [TestCase(SegmentSize + 1)]
    [TestCase(200)]
    [TestCase(499)]
    public void TruncatingKeepsThePrefix(int target)
    {
        byte[] data = Payload(500);
        using ArrayPoolMemoryStream stream = CreateFilled(data);

        stream.SetLength(target);
        stream.Seek(0, SeekOrigin.Begin);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Length, Is.EqualTo(target));
            Assert.That(ReadAll(stream), Is.EqualTo(data.Take(target).ToArray()));
        }
    }

    [TestCase(500, 501)]
    [TestCase(500, SegmentSize * 12)]
    [TestCase(0, 100)]
    public void GrowingZeroFillsTheTail(int from, int to)
    {
        byte[] data = Payload(from);
        using ArrayPoolMemoryStream stream = CreateFilled(data);

        stream.SetLength(to);
        stream.Seek(0, SeekOrigin.Begin);

        byte[] expected = new byte[to];
        data.CopyTo(expected, 0);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Length, Is.EqualTo(to));
            Assert.That(ReadAll(stream), Is.EqualTo(expected));
        }
    }

    [Test]
    public void GrowingZeroFillsEvenWhenThePooledArrayIsDirty()
    {
        // Fill, drop the length, then grow back: the bytes reappearing in the tail must be zeros and
        // not the payload that was there a moment ago.
        byte[] data = Payload(400);
        using ArrayPoolMemoryStream stream = CreateFilled(data);

        stream.SetLength(10);
        stream.SetLength(400);
        stream.Seek(0, SeekOrigin.Begin);

        byte[] actual = ReadAll(stream);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(actual.Take(10).ToArray(), Is.EqualTo(data.Take(10).ToArray()));
            Assert.That(actual.Skip(10).ToArray(), Is.All.Zero);
        }
    }

    [Test]
    public void SetLengthClampsAPositionPastTheNewEnd()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(500));
        stream.Seek(400, SeekOrigin.Begin);

        stream.SetLength(100);

        Assert.That(stream.Position, Is.EqualTo(100));
    }

    [Test]
    public void SetLengthRejectsNegativeValues()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(10));
        Assert.That(() => stream.SetLength(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void SetLengthIsRejectedOnExternallyOwnedBuffers()
    {
        var owned = new ArraySegment<byte>(new byte[16], 0, 16);
        using var stream = new ArrayPoolMemoryStream([owned]);

        Assert.That(() => stream.SetLength(0), Throws.TypeOf<NotSupportedException>());
    }

    // -------------------------------------------------- buffer-exposing members

    [Test]
    public void GetBufferIsRejectedRatherThanReportingTheBaseClassArray()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(500));
        Assert.That(() => stream.GetBuffer(), Throws.TypeOf<NotSupportedException>());
    }

    [Test]
    public void TryGetBufferFailsRatherThanSucceedingWithNothing()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(500));

        bool result = stream.TryGetBuffer(out ArraySegment<byte> buffer);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(buffer.Array, Is.Null);
        }
    }

    [Test]
    public void WriteToEmitsTheWholePayload()
    {
        byte[] data = Payload(500);
        using ArrayPoolMemoryStream stream = CreateFilled(data);
        long positionBefore = stream.Position;

        using var sink = new MemoryStream();
        stream.WriteTo(sink);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(sink.ToArray(), Is.EqualTo(data));
            Assert.That(stream.Position, Is.EqualTo(positionBefore), "WriteTo must not move the cursor");
        }
    }

    [Test]
    public void WriteToRejectsANullDestination()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(10));
        Assert.That(() => stream.WriteTo(null!), Throws.TypeOf<ArgumentNullException>());
    }

    [Test]
    public void CapacityReportsRentedSpaceRatherThanZero()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(500));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(stream.Capacity, Is.GreaterThanOrEqualTo(stream.Length));
            Assert.That(stream.Capacity, Is.GreaterThan(0));
        }
    }

    [Test]
    public void CapacityCannotBeSet()
    {
        using ArrayPoolMemoryStream stream = CreateFilled(Payload(10));
        Assert.That(() => stream.Capacity = 4096, Throws.TypeOf<NotSupportedException>());
    }


    [Test]
    public void BorrowedSequenceStillWorksAndDoesNotTransferOwnership()
    {
        byte[] data = Payload(500);
        using ArrayPoolMemoryStream stream = CreateFilled(data);

        ReadOnlySequence<byte> borrowed = stream.GetReadOnlySequence();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(borrowed.ToArray(), Is.EqualTo(data));
            Assert.That(stream.Length, Is.EqualTo(data.Length), "borrowing must not empty the stream");
        }
    }
}
