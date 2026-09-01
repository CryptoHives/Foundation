// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Covers <c>PooledSegment&lt;T&gt;.Rent(minimumLength, clearArray)</c>, the opt-in that zeroes a
/// buffer as it goes back to <see cref="System.Buffers.ArrayPool{T}"/> so the next renter cannot read
/// what was in it.
/// </summary>
/// <remarks>
/// <para>
/// Not parallelizable: proving the buffer was wiped means getting the very same array back out of the
/// pool, which only holds if no other test is renting the same bucket at the same time.
/// </para>
/// <para>
/// There is no test for the negative case — that <c>clearArray: false</c> leaves the data — because a
/// debug build zeroes every returned buffer regardless, as a use-after-return diagnostic. Such a test
/// would pass in release and fail in debug.
/// </para>
/// </remarks>
[NonParallelizable]
public class PooledSegmentClearTests
{
    /// <summary>
    /// Empties the pool's cache for one bucket, so that the next buffer returned to it is the one
    /// handed back on the following rent.
    /// </summary>
    private static List<ISegmentOwner<byte>> DrainBucket(int length)
    {
        var drained = new List<ISegmentOwner<byte>>();
        for (int i = 0; i < 8; i++)
        {
            drained.Add(PooledSegment<byte>.Rent(length));
        }

        return drained;
    }

    [Test]
    public void RentingWithClearArrayZeroesTheBufferOnReturn()
    {
        const int Length = 512;

        List<ISegmentOwner<byte>> drained = DrainBucket(Length);
        try
        {
            ISegmentOwner<byte> secret = PooledSegment<byte>.Rent(Length, clearArray: true);
            byte[] array = secret.Segment.Array!;

            for (int i = 0; i < Length; i++)
            {
                secret[i] = 0xAB;
            }

            secret.Dispose();

            ISegmentOwner<byte> next = PooledSegment<byte>.Rent(Length);
            try
            {
                Assume.That(next.Segment.Array, Is.SameAs(array),
                    "the pool did not hand the same array back, so there is nothing to inspect");

                Assert.That(array, Is.All.Zero, "the buffer went back to the pool still legible");
            }
            finally
            {
                next.Dispose();
            }
        }
        finally
        {
            foreach (ISegmentOwner<byte> owner in drained)
            {
                owner.Dispose();
            }
        }
    }

    [Test]
    public void ClearingCoversTheWholeArrayNotJustTheSegmentWindow()
    {
        // A re-windowed segment must not leave the bytes outside the window readable: Dispose hands
        // the whole array back, so the whole array is what gets zeroed.
        const int Length = 512;

        List<ISegmentOwner<byte>> drained = DrainBucket(Length);
        try
        {
            ISegmentOwner<byte> secret = PooledSegment<byte>.Rent(Length, clearArray: true);
            byte[] array = secret.Segment.Array!;

            for (int i = 0; i < Length; i++)
            {
                secret[i] = 0xCD;
            }

            // Narrow the view to the middle, then dispose.
            Assert.That(secret.TrySetSegment(128, 64), Is.True);
            secret.Dispose();

            ISegmentOwner<byte> next = PooledSegment<byte>.Rent(Length);
            try
            {
                Assume.That(next.Segment.Array, Is.SameAs(array),
                    "the pool did not hand the same array back, so there is nothing to inspect");

                Assert.That(array, Is.All.Zero, "bytes outside the final window survived");
            }
            finally
            {
                next.Dispose();
            }
        }
        finally
        {
            foreach (ISegmentOwner<byte> owner in drained)
            {
                owner.Dispose();
            }
        }
    }

    [Test]
    public void ClearArrayDefaultsToOffAndRentIsSourceCompatible()
    {
        // The parameter is optional, so every existing Rent(length) call keeps compiling and keeps
        // its previous behaviour.
        using ISegmentOwner<byte> owner = PooledSegment<byte>.Rent(64);

        Assert.That(owner.Segment.Count, Is.EqualTo(64));
    }
}
