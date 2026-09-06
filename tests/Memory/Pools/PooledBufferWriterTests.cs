// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Pools;

using CryptoHives.Foundation.Memory.Buffers;
using CryptoHives.Foundation.Memory.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;
using System.Buffers;
using System.Linq;

/// <summary>
/// Covers pooling of <see cref="ArrayPoolBufferWriter{T}"/>: that a rented writer really is recycled,
/// and that disposal returns it to the pool rather than destroying it.
/// </summary>
/// <remarks>
/// Not parallelizable: these tests reason about the identity of instances coming out of a shared pool,
/// so a concurrent test renting from the same pool would make the assertions meaningless.
/// </remarks>
[NonParallelizable]
public class PooledBufferWriterTests
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

    /// <summary>Drains the shared pool so a test starts from a known state.</summary>
    private static void DrainSharedPool()
    {
        ObjectPool<ArrayPoolBufferWriter<byte>> pool = PoolFactory.SharedBufferWriterPool<byte>();
        for (int i = 0; i < 64; i++)
        {
            _ = pool.Get();
        }
    }

    // ------------------------------------------------------- identity is recycled

    [Test]
    public void RentedWriterIsRecycledRatherThanReallocated()
    {
        // Without this assertion every other test here would pass equally well against plain
        // allocation, and the whole feature would be untested.
        DrainSharedPool();

        ArrayPoolBufferWriter<byte> first = ObjectPools.RentBufferWriter<byte>();
        first.Dispose();

        ArrayPoolBufferWriter<byte> second = ObjectPools.RentBufferWriter<byte>();
        try
        {
            Assert.That(second, Is.SameAs(first), "the writer should come back out of the pool");
        }
        finally
        {
            second.Dispose();
        }
    }

    [Test]
    public void RecycledWriterStartsEmptyWithNoPayloadCarriedOver()
    {
        DrainSharedPool();

        byte[] first = Payload(5_000);
        ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
        Write(writer, first);
        writer.Dispose();

        byte[] second = Payload(300, seed: 2);
        using ArrayPoolBufferWriter<byte> reused = ObjectPools.RentBufferWriter<byte>();
        Write(reused, second);

        Assert.That(reused.GetReadOnlySequence().ToArray(), Is.EqualTo(second));
    }

    [Test]
    public void RecycledWriterHasItsChunkRampReset()
    {
        DrainSharedPool();

        // A big payload ramps the chunk size up toward the maximum.
        ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
        Write(writer, Payload(500_000));
        writer.Dispose();

        // After recycling, a tiny write should come back in a small first chunk again rather than
        // inheriting the ramped-up size.
        using ArrayPoolBufferWriter<byte> reused = ObjectPools.RentBufferWriter<byte>();
        int span = reused.GetSpan(1).Length;

        Assert.That(span, Is.LessThanOrEqualTo(ArrayPoolBufferWriter<byte>.DefaultChunkBytes),
            "the growth ramp should be back at its starting size");
    }

    // ------------------------------------------------------------------ disposal

    [Test]
    public void DoubleDisposeReturnsExactlyOnce()
    {
        DrainSharedPool();

        ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
        Write(writer, Payload(100));

        writer.Dispose();
        writer.Dispose();

        ArrayPoolBufferWriter<byte> a = ObjectPools.RentBufferWriter<byte>();
        ArrayPoolBufferWriter<byte> b = ObjectPools.RentBufferWriter<byte>();
        try
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(a, Is.Not.SameAs(b), "a double dispose must not put the same writer in twice");

                // Renting is not enough to prove the pool is healthy: the second dispose must not have
                // marked an instance sitting in the pool as disposed, or its next renter gets a writer
                // that throws on first use.
                Assert.That(() => Write(a, Payload(64)), Throws.Nothing, "writer A came back poisoned");
                Assert.That(() => Write(b, Payload(64)), Throws.Nothing, "writer B came back poisoned");
            }
        }
        finally
        {
            a.Dispose();
            b.Dispose();
        }
    }

    [Test]
    public void DisposeReleasesSegmentsEvenIfThePoolPolicyDoesNot()
    {
        // Dispose must hand the buffers back itself rather than relying on the pool's policy to do
        // it. Otherwise a writer returned to a pool whose policy does not reset would sit there still
        // holding rented arrays, and the next renter would find the previous payload in place.
        ObjectPool<ArrayPoolBufferWriter<byte>> inertPool = PoolFactory.CreatePool(
            () => new ArrayPoolBufferWriter<byte>(),
            static _ => true);                       // deliberately does not reset

        ArrayPoolBufferWriter<byte> writer = inertPool.Get();
        writer.AttachPool(inertPool);
        Write(writer, Payload(5_000));

        writer.Dispose();

        ArrayPoolBufferWriter<byte> recycled = inertPool.Get();
        try
        {
            using (Assert.EnterMultipleScope())
            {
                Assert.That(recycled, Is.SameAs(writer));
                Assert.That(recycled.GetReadOnlySequence().Length, Is.Zero,
                    "Dispose should release the segments before the writer reaches the pool");
            }
        }
        finally
        {
            recycled.Dispose();
        }
    }

    [Test]
    public void AnUnpooledWriterIsStillDestroyedByDispose()
    {
        var writer = new ArrayPoolBufferWriter<byte>();
        Write(writer, Payload(100));

        writer.Dispose();

        Assert.That(() => writer.GetSpan(1), Throws.TypeOf<ObjectDisposedException>());
    }

    [Test]
    public void TryResetRefusesADisposedWriter()
    {
        var writer = new ArrayPoolBufferWriter<byte>();
        Write(writer, Payload(100));
        writer.Dispose();

        Assert.That(writer.TryReset(), Is.False);
    }

    [Test]
    public void TryResetIsIdempotent()
    {
        using var writer = new ArrayPoolBufferWriter<byte>();
        Write(writer, Payload(1_000));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(writer.TryReset(), Is.True);
            Assert.That(writer.TryReset(), Is.True);
            Assert.That(writer.GetReadOnlySequence().Length, Is.Zero);
        }
    }


#if NET6_0_OR_GREATER
    [Test]
    public void ManyRentDisposeCyclesReachSteadyState()
    {
        DrainSharedPool();

        // Warm up so first-use allocations are not counted.
        for (int i = 0; i < 20; i++)
        {
            using ArrayPoolBufferWriter<byte> warm = ObjectPools.RentBufferWriter<byte>();
            Write(warm, Payload(10_000));
        }

        long before = GC.GetTotalAllocatedBytes(precise: true);

        for (int i = 0; i < 200; i++)
        {
            using ArrayPoolBufferWriter<byte> writer = ObjectPools.RentBufferWriter<byte>();
            Write(writer, Payload(10_000));
        }

        long perCycle = (GC.GetTotalAllocatedBytes(precise: true) - before) / 200;

        // Each cycle still allocates the payload array itself (10 KB) plus segment bookkeeping. The
        // point is that the writer and its buffers are not re-allocated, so the figure stays far
        // below what a fresh writer plus fresh buffers would cost.
        Assert.That(perCycle, Is.LessThan(64 * 1024), $"allocated {perCycle} bytes per cycle");
    }
#endif
}
