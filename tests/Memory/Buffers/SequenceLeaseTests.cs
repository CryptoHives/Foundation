// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using CryptoHives.Foundation.Memory.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;
using System.Buffers;
using System.IO;

/// <summary>
/// Covers <see cref="SequenceLease{T}"/>: a payload paired with the disposable that ends its life, so
/// it can cross a scope boundary without an allocation.
/// </summary>
/// <remarks>
/// Not parallelizable: several tests reason about instance identity coming out of the shared pool.
/// </remarks>
[NonParallelizable]
public class SequenceLeaseTests
{
    private static byte[] Payload(int length, int seed = 1)
    {
        var data = new byte[length];
        new Random(seed).NextBytes(data);
        return data;
    }

    private static void Write(ArrayPoolBufferWriter<byte> writer, byte[] data)
    {
        int offset = 0;
        int chunk = 7;
        while (offset < data.Length)
        {
            int count = Math.Min(chunk, data.Length - offset);
            data.AsSpan(offset, count).CopyTo(writer.GetSpan(count));
            writer.Advance(count);
            offset += count;
            chunk = Math.Min(chunk * 3, 4096);
        }
    }

    private static void DrainSharedPool()
    {
        ObjectPool<ArrayPoolBufferWriter<byte>> pool = PoolFactory.SharedBufferWriterPool<byte>();
        for (int i = 0; i < 64; i++)
        {
            _ = pool.Get();
        }
    }

    /// <summary>The shape the type exists for: build inside, consume outside.</summary>
    private static SequenceLease<byte> BuildPayload(byte[] data)
    {
        ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
        Write(writer, data);
        return writer.LeaseSequence();
    }

    [Test]
    public void APayloadOutlivesTheScopeThatBuiltIt()
    {
        byte[] data = Payload(5_000);

        using SequenceLease<byte> payload = BuildPayload(data);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(payload.Length, Is.EqualTo(data.Length));
            Assert.That(payload.Sequence.ToArray(), Is.EqualTo(data));
            Assert.That(payload.IsEmpty, Is.False);
        }
    }

    [Test]
    public void DisposingTheLeaseReturnsTheWriterToThePool()
    {
        DrainSharedPool();

        ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
        Write(writer, Payload(1_000));

        SequenceLease<byte> lease = writer.LeaseSequence();
        lease.Dispose();

        ArrayPoolBufferWriter<byte> recycled = ObjectPools.RentBufferWriter<byte>();
        try
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(recycled, Is.SameAs(writer), "the lease should have returned the writer");
                Assert.That(() => Write(recycled, Payload(64)), Throws.Nothing, "and returned it healthy");
            }
        }
        finally
        {
            recycled.Dispose();
        }
    }

    [Test]
    public void ALeaseOverAMemoryStreamReadsBack()
    {
        byte[] data = Payload(3_000);

        SequenceLease<byte> payload;
        using var stream = new ArrayPoolMemoryStream(4, 64);
        stream.Write(data, 0, data.Length);
        payload = stream.LeaseSequence();

        using (payload)
        {
            Assert.That(payload.Sequence.ToArray(), Is.EqualTo(data));
        }

        // Disposing the lease disposed the stream, which released its buffers.
        Assert.That(stream.Length, Is.Zero);
    }

    [Test]
    public void ALeaseCanBeReadThroughAStream()
    {
        byte[] data = Payload(4_000);

        using SequenceLease<byte> payload = BuildPayload(data);
        using var reader = new ReadOnlySequenceMemoryStream(payload.Sequence);
        using var sink = new MemoryStream();

        reader.CopyTo(sink);

        Assert.That(sink.ToArray(), Is.EqualTo(data));
    }

    [Test]
    public void TheDefaultValueIsAnEmptyLeaseAndSafeToDispose()
    {
        SequenceLease<byte> lease = default;

        lease.Dispose();
        lease.Dispose();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(lease.IsEmpty, Is.True);
            Assert.That(lease.Length, Is.Zero);
            Assert.That(lease.Sequence.IsEmpty, Is.True);
        }
    }

    [Test]
    public void ALeaseWithNoOwnerDoesNotDisposeAnything()
    {
        byte[] data = Payload(100);
        var lease = new SequenceLease<byte>(new ReadOnlySequence<byte>(data), owner: null);

        lease.Dispose();

        Assert.That(lease.Sequence.ToArray(), Is.EqualTo(data), "nothing owned it, so nothing was released");
    }

    [Test]
    public void ACopiedLeaseDisposedTwiceDoesNotCorruptThePool()
    {
        // Copying the struct is a caller bug, but the producers tolerate a second dispose, so it must
        // degrade rather than poison the pool for the next renter.
        DrainSharedPool();

        SequenceLease<byte> lease = BuildPayload(Payload(500));
        SequenceLease<byte> copy = lease;

        lease.Dispose();
        copy.Dispose();

        ArrayPoolBufferWriter<byte> a = ObjectPools.RentBufferWriter<byte>();
        ArrayPoolBufferWriter<byte> b = ObjectPools.RentBufferWriter<byte>();
        try
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(a, Is.Not.SameAs(b), "the writer must not be pooled twice");
                Assert.That(() => Write(a, Payload(64)), Throws.Nothing);
                Assert.That(() => Write(b, Payload(64)), Throws.Nothing);
            }
        }
        finally
        {
            a.Dispose();
            b.Dispose();
        }
    }

    [Test]
    public void LeasingADisposedWriterIsRejected()
    {
        var writer = new ArrayPoolBufferWriter<byte>();
        Write(writer, Payload(100));
        writer.Dispose();

        Assert.That(() => writer.LeaseSequence(), Throws.TypeOf<ObjectDisposedException>());
    }

    [Test]
    public void ALeaseSatisfiesTheSequenceOwnerContract()
    {
        // Boxing is the documented cost of going polymorphic; the contract still has to hold.
        byte[] data = Payload(1_000);

        using SequenceLease<byte> owner = BuildPayload(data);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.Length, Is.EqualTo(data.Length));
            Assert.That(owner.IsEmpty, Is.False);
            Assert.That(owner.Sequence.ToArray(), Is.EqualTo(data));
        }
    }

    [Test]
    public void LeasesCompareByPayloadAndOwner()
    {
        using SequenceLease<byte> lease = BuildPayload(Payload(200));
        SequenceLease<byte> copy = lease;
        SequenceLease<byte> empty = default;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(lease, Is.EqualTo(copy));
            Assert.That(lease != empty, Is.True);
            Assert.That(lease, Is.EqualTo((object)copy));
        }
    }
}
