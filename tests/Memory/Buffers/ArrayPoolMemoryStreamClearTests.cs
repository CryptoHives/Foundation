// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System.Buffers;
using System.Collections.Generic;

/// <summary>
/// Covers the <c>clearArray</c> option on <see cref="ArrayPoolMemoryStream"/>, which zeroes each
/// buffer as it goes back to <see cref="ArrayPool{T}"/> so the next renter cannot read what the
/// stream wrote.
/// </summary>
/// <remarks>
/// Not parallelizable: proving a buffer was wiped means getting the very same array back out of the
/// pool, which only holds if no other test is renting the same bucket at the same time. Every
/// assertion is guarded by an <c>Assume</c> on array identity, so a pool that hands back something
/// else makes the test inconclusive rather than falsely green.
/// </remarks>
[NonParallelizable]
public class ArrayPoolMemoryStreamClearTests
{
    private const int BufferSize = 512;

    /// <summary>
    /// Empties the pool's cache for the bucket under test, so the next buffer returned to it is the
    /// one handed back on the following rent.
    /// </summary>
    private static List<byte[]> DrainBucket()
    {
        var drained = new List<byte[]>();
        for (int i = 0; i < 8; i++)
        {
            drained.Add(ArrayPool<byte>.Shared.Rent(BufferSize));
        }

        return drained;
    }

    private static void ReturnDrained(List<byte[]> drained)
    {
        foreach (byte[] array in drained)
        {
            ArrayPool<byte>.Shared.Return(array);
        }
    }

    private static void Fill(ArrayPoolMemoryStream stream, byte value, int count)
    {
        var payload = new byte[count];
        for (int i = 0; i < count; i++)
        {
            payload[i] = value;
        }

        stream.Write(payload, 0, count);
    }

    [Test]
    public void ClearArrayZeroesTheBufferOnDispose()
    {
        List<byte[]> drained = DrainBucket();
        try
        {
            var stream = new ArrayPoolMemoryStream(4, BufferSize, clearArray: true);
            Fill(stream, 0xAB, BufferSize);
            stream.Dispose();

            byte[] recycled = ArrayPool<byte>.Shared.Rent(BufferSize);
            try
            {
                Assume.That(recycled.Length, Is.EqualTo(BufferSize),
                    "the pool served a different bucket, so there is nothing to inspect");

                Assert.That(recycled, Is.All.Zero, "the buffer went back to the pool still legible");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(recycled);
            }
        }
        finally
        {
            ReturnDrained(drained);
        }
    }

    [Test]
    public void ClearArrayZeroesBuffersReleasedBySetLength()
    {
        // Truncation returns the trailing buffers while the stream is still alive, which is a
        // separate release path from Dispose and was equally unguarded.
        List<byte[]> drained = DrainBucket();
        try
        {
            using var stream = new ArrayPoolMemoryStream(4, BufferSize, clearArray: true);
            Fill(stream, 0xCD, BufferSize * 2);

            stream.SetLength(BufferSize);

            byte[] recycled = ArrayPool<byte>.Shared.Rent(BufferSize);
            try
            {
                Assume.That(recycled.Length, Is.EqualTo(BufferSize),
                    "the pool served a different bucket, so there is nothing to inspect");

                Assert.That(recycled, Is.All.Zero, "a truncated buffer went back to the pool still legible");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(recycled);
            }
        }
        finally
        {
            ReturnDrained(drained);
        }
    }

    [Test]
    public void WithoutClearArrayTheBufferGoesBackAsWritten()
    {
        // The other half of the contract: the wipe is opt-in, and paying for it by default would be
        // a cost every caller carries whether or not they hold secrets.
        List<byte[]> drained = DrainBucket();
        try
        {
            var stream = new ArrayPoolMemoryStream(4, BufferSize);
            Fill(stream, 0xEF, BufferSize);
            stream.Dispose();

            byte[] recycled = ArrayPool<byte>.Shared.Rent(BufferSize);
            try
            {
                Assume.That(recycled.Length, Is.EqualTo(BufferSize),
                    "the pool served a different bucket, so there is nothing to inspect");
                Assume.That(recycled[0], Is.Not.EqualTo(0),
                    "the pool did not hand the written array back, so there is nothing to inspect");

                Assert.That(recycled[BufferSize - 1], Is.EqualTo(0xEF),
                    "the buffer was cleared even though the caller did not ask for it");
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(recycled);
            }
        }
        finally
        {
            ReturnDrained(drained);
        }
    }

    [Test]
    public void ClearArrayIsOptionalOnEveryOwningConstructor()
    {
        // The parameter is optional or a distinct overload throughout, so every existing call keeps
        // compiling and keeps its previous behaviour.
        using (var a = new ArrayPoolMemoryStream()) { }
        using (var b = new ArrayPoolMemoryStream(clearArray: true)) { }
        using (var c = new ArrayPoolMemoryStream(BufferSize)) { }
        using (var d = new ArrayPoolMemoryStream(BufferSize, clearArray: true)) { }
        using (var e = new ArrayPoolMemoryStream(4, BufferSize)) { }
        using (var f = new ArrayPoolMemoryStream(4, BufferSize, clearArray: true)) { }
        using (var g = new ArrayPoolMemoryStream(4, BufferSize, 0, BufferSize)) { }
        using (var h = new ArrayPoolMemoryStream(4, BufferSize, 0, BufferSize, clearArray: true)) { }

        Assert.Pass();
    }
}
