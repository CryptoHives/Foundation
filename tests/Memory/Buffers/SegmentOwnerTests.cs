// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1859 // Use concrete types when possible for improved performance
#pragma warning disable CA2000 // Dispose called explicitly inside lambda bodies; false positive

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for <see cref="ISegmentOwner{T}"/> implementations:
/// <see cref="EmptySegment{T}"/>, <see cref="PooledSegment{T}"/>,
/// and <see cref="AllocatedSegment{T}"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SegmentOwnerTests
{
    #region EmptySegment<T>

    /// <summary>
    /// The singleton <see cref="EmptyPayload{T}.Instance"/> must not be <see langword="null"/>.
    /// </summary>
    [Test]
    public void EmptyPayloadInstanceIsNotNull()
    {
        Assert.That(EmptySegment<byte>.Instance, Is.Not.Null);
    }

    /// <summary>
    /// Repeated access to <see cref="EmptyPayload{T}.Instance"/> must return the same object.
    /// </summary>
    [Test]
    public void EmptyPayloadInstanceIsSingleton()
    {
        var first = EmptySegment<byte>.Instance;
        var second = EmptySegment<byte>.Instance;
        Assert.That(first, Is.SameAs(second));
    }

    /// <summary>
    /// <see cref="EmptyPayload{T}.Segment"/> must be an empty segment backed by <see cref="Array.Empty{T}"/>.
    /// </summary>
    [Test]
    public void EmptyPayloadSegmentIsEmpty()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload.Segment.Count, Is.Zero);
            Assert.That(payload.Segment.Offset, Is.Zero);
            Assert.That(payload.Segment.Array, Is.Not.Null);
            Assert.That(payload.Segment.Array!.Length, Is.Zero);
        }
    }

    /// <summary>
    /// Reading from the indexer on an empty payload must throw <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    [Test]
    public void EmptyPayloadIndexerGetThrows()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = payload[0]);
    }

    /// <summary>
    /// Writing to the indexer on an empty payload must throw <see cref="ArgumentOutOfRangeException"/>.
    /// </summary>
    [Test]
    public void EmptyPayloadIndexerSetThrows()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;
        Assert.Throws<ArgumentOutOfRangeException>(() => payload[0] = 0);
    }

    /// <summary>
    /// <see cref="EmptyPayload{T}.Dispose"/> is a no-op and must never throw.
    /// </summary>
    [Test]
    public void EmptyPayloadDisposeDoesNotThrow()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;
        Assert.DoesNotThrow(() => payload.Dispose());
    }

    /// <summary>
    /// Calling <see cref="EmptyPayload{T}.Dispose"/> more than once must not throw.
    /// </summary>
    [Test]
    public void EmptyPayloadDisposeMultipleTimesDoesNotThrow()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;
        Assert.DoesNotThrow(() => {
            payload.Dispose();
            payload.Dispose();
            payload.Dispose();
        });
    }

    /// <summary>
    /// <see cref="EmptyPayload{T}.TrySetSegment"/> must always return <see langword="false"/>.
    /// </summary>
    [Test]
    public void EmptyPayloadTrySetSegmentAlwaysReturnsFalse()
    {
        ISegmentOwner<byte> payload = EmptySegment<byte>.Instance;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload.TrySetSegment(0, 0), Is.False);
            Assert.That(payload.TrySetSegment(0, 1), Is.False);
            Assert.That(payload.TrySetSegment(4, 8), Is.False);
        }
    }

    #endregion

    #region PooledSegment<T>

    /// <summary>
    /// <see cref="ArrayPoolPayload{T}.Rent"/> must return a non-null owner.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadRentReturnsNonNullOwner()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(16);
        Assert.That(payload, Is.Not.Null);
    }

    /// <summary>
    /// The segment length must equal the requested <c>minimumLength</c>.
    /// </summary>
    [Theory]
    public void ArrayPoolPayloadRentSegmentLengthEqualsRequestedLength(
        [Values(1, 16, 64, 128, 1024, 4096)] int length)
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(length);
        Assert.That(payload.Segment.Count, Is.EqualTo(length));
    }

    /// <summary>
    /// The segment offset must be zero after <see cref="ArrayPoolPayload{T}.Rent"/>.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadRentSegmentOffsetIsZero()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(64);
        Assert.That(payload.Segment.Offset, Is.Zero);
    }

    /// <summary>
    /// The backing array must be at least as large as the requested length.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadBackingArrayIsAtLeastRequestedLength()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(64);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload.Segment.Array, Is.Not.Null);
            Assert.That(payload.Segment.Array!.Length, Is.GreaterThanOrEqualTo(64));
        }
    }

    /// <summary>
    /// The indexer must allow round-trip get/set within the segment.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadIndexerGetSetRoundtrips()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(4);
        payload[0] = 0xAA;
        payload[1] = 0xBB;
        payload[2] = 0xCC;
        payload[3] = 0xDD;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload[0], Is.EqualTo(0xAA));
            Assert.That(payload[1], Is.EqualTo(0xBB));
            Assert.That(payload[2], Is.EqualTo(0xCC));
            Assert.That(payload[3], Is.EqualTo(0xDD));
        }
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> with a valid range must return
    /// <see langword="true"/> and update the segment.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadTrySetSegmentWithValidRangeReturnsTrueAndUpdatesSegment()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(64);
        bool result = payload.TrySetSegment(4, 32);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(payload.Segment.Offset, Is.EqualTo(4));
            Assert.That(payload.Segment.Count, Is.EqualTo(32));
        }
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> where length exceeds the array must
    /// return <see langword="false"/> and leave the segment unchanged.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadTrySetSegmentWithLengthExceedingArrayReturnsFalse()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(8);
        int arrayLength = payload.Segment.Array!.Length;
        int originalCount = payload.Segment.Count;

        bool result = payload.TrySetSegment(0, arrayLength + 1);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.False);
            Assert.That(payload.Segment.Count, Is.EqualTo(originalCount));
        }
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> where offset + length exceeds the array
    /// must return <see langword="false"/>.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadTrySetSegmentWithOffsetPlusLengthExceedingArrayReturnsFalse()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(16);
        int arrayLength = payload.Segment.Array!.Length;

        // offset=8, length=arrayLength-4  →  8 + (arrayLength-4) = arrayLength+4 > arrayLength
        bool result = payload.TrySetSegment(8, arrayLength - 4);
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// The indexer must respect the updated offset after a successful
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> call.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadIndexerRespectsUpdatedSegmentOffset()
    {
        using ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(32);

        // Write sentinel values directly into the backing array.
        byte[] array = payload.Segment.Array!;
        for (int i = 0; i < array.Length; i++)
            array[i] = (byte)i;

        bool moved = payload.TrySetSegment(8, 16);
        Assert.That(moved, Is.True);

        // payload[i] == array[i + offset]
        for (int i = 0; i < 16; i++)
            Assert.That(payload[i], Is.EqualTo((byte)(i + 8)));
    }

    /// <summary>
    /// After <see cref="IPayloadOwner{T}.Dispose"/> the segment must be invalidated
    /// (backing array is <see langword="null"/>).
    /// </summary>
    [Test]
    public void ArrayPoolPayloadDisposeInvalidatesSegment()
    {
        ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(64);
        payload.Dispose();
        Assert.That(payload.Segment.Array, Is.Null);
    }

    /// <summary>
    /// Calling <see cref="IPayloadOwner{T}.Dispose"/> more than once must not throw.
    /// </summary>
    [Test]
    public void ArrayPoolPayloadDisposeMultipleTimesDoesNotThrow()
    {
        ISegmentOwner<byte> payload = PooledSegment<byte>.Rent(64);
        Assert.DoesNotThrow(() => {
            payload.Dispose();
            payload.Dispose();
        });
    }

    #endregion

    #region AllocatedSegment<T>

    /// <summary>
    /// <see cref="AllocatedPayload{T}.Create"/> must wrap the provided array without copying.
    /// </summary>
    [Test]
    public void AllocatedPayloadCreateWrapsBufferWithoutCopying()
    {
        byte[] buffer = new byte[8];
        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload.Segment.Array, Is.SameAs(buffer));
            Assert.That(payload.Segment.Offset, Is.Zero);
            Assert.That(payload.Segment.Count, Is.EqualTo(buffer.Length));
        }
    }

    /// <summary>
    /// The indexer must allow round-trip get/set for all element types.
    /// </summary>
    [Test]
    public void AllocatedPayloadIndexerGetSetRoundtrips()
    {
        int[] buffer = new int[4];
        using ISegmentOwner<int> payload = AllocatedSegment<int>.Create(buffer);
        payload[0] = 10;
        payload[1] = 20;
        payload[2] = 30;
        payload[3] = 40;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload[0], Is.EqualTo(10));
            Assert.That(payload[1], Is.EqualTo(20));
            Assert.That(payload[2], Is.EqualTo(30));
            Assert.That(payload[3], Is.EqualTo(40));
        }
    }

    /// <summary>
    /// Writes via the indexer must be visible through the original array reference.
    /// </summary>
    [Test]
    public void AllocatedPayloadIndexerWritesThroughToUnderlyingArray()
    {
        byte[] buffer = new byte[3];
        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);
        payload[0] = 0xAA;
        payload[1] = 0xBB;
        payload[2] = 0xCC;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(buffer[0], Is.EqualTo(0xAA));
            Assert.That(buffer[1], Is.EqualTo(0xBB));
            Assert.That(buffer[2], Is.EqualTo(0xCC));
        }
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> with a valid range must return
    /// <see langword="true"/> and update the segment without changing the underlying array.
    /// </summary>
    [Test]
    public void AllocatedPayloadTrySetSegmentWithValidRangeReturnsTrueAndUpdatesSegment()
    {
        byte[] buffer = new byte[16];
        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);
        bool result = payload.TrySetSegment(4, 8);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result, Is.True);
            Assert.That(payload.Segment.Offset, Is.EqualTo(4));
            Assert.That(payload.Segment.Count, Is.EqualTo(8));
            Assert.That(payload.Segment.Array, Is.SameAs(buffer));
        }
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> where length exceeds the buffer must
    /// return <see langword="false"/>.
    /// </summary>
    [Test]
    public void AllocatedPayloadTrySetSegmentWithLengthExceedingBufferReturnsFalse()
    {
        byte[] buffer = new byte[8];
        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);
        bool result = payload.TrySetSegment(0, 9);
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> where offset + length exceeds the buffer
    /// must return <see langword="false"/>.
    /// </summary>
    [Test]
    public void AllocatedPayloadTrySetSegmentWithOffsetPlusLengthExceedingBufferReturnsFalse()
    {
        byte[] buffer = new byte[8];
        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);

        // offset=4, length=8 → 4+8=12 > 8
        bool result = payload.TrySetSegment(4, 8);
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// The indexer must reflect the offset after a successful
    /// <see cref="IPayloadOwner{T}.TrySetSegment"/> call.
    /// </summary>
    [Theory]
    public void AllocatedPayloadIndexerRespectsUpdatedSegmentOffset(
        [Values(0, 2, 4)] int offset,
        [Values(4, 8)] int length)
    {
        byte[] buffer = new byte[16];
        for (int i = 0; i < buffer.Length; i++)
            buffer[i] = (byte)i;

        using ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);
        bool moved = payload.TrySetSegment(offset, length);
        Assert.That(moved, Is.True);

        // payload[i] must equal buffer[i + offset]
        for (int i = 0; i < length; i++)
            Assert.That(payload[i], Is.EqualTo((byte)(i + offset)));
    }

    /// <summary>
    /// After <see cref="IPayloadOwner{T}.Dispose"/> the segment must be invalidated
    /// (<see cref="ArraySegment{T}.Array"/> is <see langword="null"/>).
    /// </summary>
    [Test]
    public void AllocatedPayloadDisposeInvalidatesSegment()
    {
        ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(new byte[8]);
        payload.Dispose();
        Assert.That(payload.Segment.Array, Is.Null);
    }

    /// <summary>
    /// The underlying GC-managed array must not be affected by <see cref="IPayloadOwner{T}.Dispose"/>.
    /// </summary>
    [Test]
    public void AllocatedPayloadDisposeDoesNotClearUnderlyingArray()
    {
        byte[] buffer = [1, 2, 3, 4];
        ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(buffer);
        payload.Dispose();

        // The wrapper is cleared, but the GC-managed array is untouched.
        using (Assert.EnterMultipleScope())
        {
            Assert.That(buffer[0], Is.EqualTo(1));
            Assert.That(buffer[1], Is.EqualTo(2));
            Assert.That(buffer[2], Is.EqualTo(3));
            Assert.That(buffer[3], Is.EqualTo(4));
        }
    }

    /// <summary>
    /// Calling <see cref="IPayloadOwner{T}.Dispose"/> more than once must not throw.
    /// </summary>
    [Test]
    public void AllocatedPayloadDisposeMultipleTimesDoesNotThrow()
    {
        ISegmentOwner<byte> payload = AllocatedSegment<byte>.Create(new byte[8]);
        Assert.DoesNotThrow(() => {
            payload.Dispose();
            payload.Dispose();
        });
    }

    #endregion
}

